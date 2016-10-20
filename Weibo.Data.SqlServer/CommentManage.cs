using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Weibo.Data;
using System.Data.Common;
using System.Data;
using Weibo.Entity;
using Weibo.Common;

namespace Weibo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public long CreateComment(Comment comment)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            long result = -1;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
                    {
                        DbHelper .MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,comment.UID),
                        DbHelper .MakeInParam("@ReplyUID",(DbType)SqlDbType.BigInt,8,comment.ReplyUID),
                        DbHelper .MakeInParam("@ReferUID",(DbType)SqlDbType.VarChar,0,comment.ReferUID),
                        DbHelper .MakeInParam("@Content",(DbType)SqlDbType.NText,0,comment.Content),
                        DbHelper .MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,comment.MID),
                        DbHelper .MakeInParam("@MUID",(DbType)SqlDbType.BigInt,8,comment.MUID),
                        DbHelper .MakeInParam("@ReplyContent",(DbType)SqlDbType.NVarChar,200,comment.ReplyContent)
                    };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(trans,CommandType.StoredProcedure, "CreateComment", parms),-1);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }

            }

            conn.Close();
            return result;
        }

        public bool DelCommentByCID(long cid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
                    {
                        DbHelper.MakeInParam("@CID",(DbType)SqlDbType.BigInt,8,cid)
                    };
                    result = DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelCommentByCID", parms) > 0;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return result;
        }

        public DataTable GetTop10CommentsByMid(long mid)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,mid)
            };
          return  DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT TOP 10 {0} FROM TComment where MID=@MID ORDER BY CreateTime desc", DbFields.COMMENT), parms).Tables[0];
        }

        public DataTable GetCommentsByMid(int pageIndex, int pageSize, long mid,long uid,int isFollow, ref int rowCount)
        {
            string where = "MID="+mid.ToString();
            if (isFollow > 0)
            {
                if (isFollow == 1)
                {
                    where += " and UID in (select FollowUID from TFollow where UID=" + uid.ToString() + ")";
                }
                else
                {
                    where += " and UID not in (select FollowUID from TFollow where UID=" + uid.ToString() + ") and UID <>"+uid.ToString();
                }
            }
            return Pager(pageIndex, pageSize, "TComment", where, ref rowCount);
        }

        public DataTable GetCommentsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TComment", where, ref rowCount);
        }

        public IDataReader GetCommentByID(long id)
        {
            return GetRowByID("TComment", id, DbFields.COMMENT);
        }

        public int GetCommentCountByMID(long Mid)
        {
            string where = "MID=" + Mid.ToString();
            return GetCount("TComment", where);
        }

        public DataTable GetAtCommentsByPager(int pageIndex, int pageSize,long uid,string key,int isFollow, ref int rowCount)
        {
            string where = string.Format("(ReferUID like '%a{0}a%' or ReferUID like 'a{0}a%')", uid.ToString());
            if (isFollow > 0 && uid > 0)
            {
                where += " and UID in (select FollowUID from TFollow where UID=" + uid.ToString() + ")";
            }
            if (!string.IsNullOrEmpty(key))
                where += string.Format("and (Content like '%{0}' or Content like '{0}%' or Content like '%{0}%' or Content like '{0}' )", key);
            return Pager(pageIndex, pageSize, "TComment", where, ref rowCount);
        }

        public DataTable GetRecCommentsByPager(int pageIndex, int pageSize,long uid,int isFollow,string key, ref int rowCount)
        {
            string where = string.Format("((ReplyUID={0} and UID<>{0})or (MUID={0} and UID<>{0} and ReplyUID=-1))", uid.ToString());
            if (isFollow > 0)
            {
                if (isFollow == 1)
                {
                    where += " and UID in (select FollowUID from TFollow where UID=" + uid.ToString() + ")";
                }
                else
                {
                    where += " and UID not in (select FollowUID from TFollow where UID=" + uid.ToString() + ")";
                }
            }
            if (!string.IsNullOrEmpty(key))
                where += string.Format("and (Content like '%{0}' or Content like '{0}%' or Content like '%{0}%' or Content like '{0}' )", key);

            return Pager(pageIndex, pageSize, "TComment", where, ref rowCount);
        }

        public DataTable GetSendCommentsByPager(int pageIndex, int pageSize, long uid,string key, ref int rowCount)
        {
            string where = string.Format("UID={0}", uid.ToString());
            if (!string.IsNullOrEmpty(key))
                where += string.Format("and (Content like '%{0}' or Content like '{0}%' or Content like '%{0}%' or Content like '{0}' )", key);
            return Pager(pageIndex, pageSize, "TComment", where, ref rowCount);
        }
    }
}
