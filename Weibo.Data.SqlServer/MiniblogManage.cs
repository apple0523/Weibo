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
        public long CreateMiniBlog(MiniBlog miniBlog)
        {
           SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
           conn.Open();
           long  result = -1;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
                    {
                        DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,miniBlog.ID),
                        DbHelper.MakeInParam("@IDCode",(DbType)SqlDbType.VarChar,30,miniBlog.IDCode),
                        DbHelper.MakeInParam("@OriginalContent",(DbType)SqlDbType.NText,0,miniBlog.OriginalContent),
                        DbHelper.MakeInParam("@MediaContent",(DbType)SqlDbType.NText,0,miniBlog.MediaContent),
                        DbHelper.MakeInParam("@RealContent",(DbType)SqlDbType.NText,0,miniBlog.RealContent),
                        DbHelper.MakeInParam("@PicID",(DbType)SqlDbType.BigInt,8,miniBlog.PicID),
                        DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,miniBlog.UID),
                        DbHelper.MakeInParam("@OriginalMID",(DbType)SqlDbType.BigInt,8,miniBlog.OriginalMID),
                        DbHelper.MakeInParam("@OriginalMContent",(DbType)SqlDbType.NText,0,miniBlog.OriginalMContent),
                        DbHelper.MakeInParam("@QuoteMID",(DbType)SqlDbType.BigInt,8,miniBlog.QuoteMID),
                        DbHelper.MakeInParam("@IsOriginal",(DbType)SqlDbType.Int,4,miniBlog.IsOriginal),
                        DbHelper.MakeInParam("@IsHavePic",(DbType)SqlDbType.Int,4,miniBlog.IsHavePic),
                        DbHelper.MakeInParam("@IsHaveLink",(DbType)SqlDbType.Int,4,miniBlog.IsHaveLink),
                        DbHelper.MakeInParam("@IsHaveVideo",(DbType)SqlDbType.Int,4,miniBlog.IsHaveVideo),
                        DbHelper.MakeInParam("@IsHaveMusic",(DbType)SqlDbType.Int,4,miniBlog.IsHaveMusic),
                        DbHelper.MakeInParam("@IsHaveVote",(DbType)SqlDbType.Int,4,miniBlog.IsHaveVote),
                        DbHelper.MakeInParam("@FromID",(DbType)SqlDbType.Int,4,miniBlog.FromID),
                        DbHelper.MakeInParam("@ReferUID",(DbType)SqlDbType.VarChar,200,miniBlog.ReferUID)
                    };
                    result =TypeConverter.ObjectToLong( DbHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "CreateMiniBlog", parms),-1);
                    trans.Commit();
                 
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }

            }

            conn.Close();
            return result;
        }
        public DataTable GetTop500MiniBlogsByQuery(string where, string sortField, string sortType)
        {
            return GetTop500TableByQuery("TMiniBlog", where, DbFields.MINIBLOG, sortField, sortType);
        }
        public long CreateQuoteMiniBlog(MiniBlog miniBlog)
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
                        DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,miniBlog.ID),
                        DbHelper.MakeInParam("@IDCode",(DbType)SqlDbType.VarChar,30,miniBlog.IDCode),
                        DbHelper.MakeInParam("@OriginalContent",(DbType)SqlDbType.NText,0,miniBlog.OriginalContent),
                        DbHelper.MakeInParam("@MediaContent",(DbType)SqlDbType.NText,0,miniBlog.MediaContent),
                        DbHelper.MakeInParam("@RealContent",(DbType)SqlDbType.NText,0,miniBlog.RealContent),
                        DbHelper.MakeInParam("@PicID",(DbType)SqlDbType.BigInt,8,miniBlog.PicID),
                        DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,miniBlog.UID),
                        DbHelper.MakeInParam("@OriginalMID",(DbType)SqlDbType.BigInt,8,miniBlog.OriginalMID),
                        DbHelper.MakeInParam("@OriginalMContent",(DbType)SqlDbType.NText,0,miniBlog.OriginalMContent),
                        DbHelper.MakeInParam("@QuoteMID",(DbType)SqlDbType.BigInt,8,miniBlog.QuoteMID),
                        DbHelper.MakeInParam("@IsOriginal",(DbType)SqlDbType.Int,4,miniBlog.IsOriginal),
                        DbHelper.MakeInParam("@IsHavePic",(DbType)SqlDbType.Int,4,miniBlog.IsHavePic),
                        DbHelper.MakeInParam("@IsHaveLink",(DbType)SqlDbType.Int,4,miniBlog.IsHaveLink),
                        DbHelper.MakeInParam("@IsHaveVideo",(DbType)SqlDbType.Int,4,miniBlog.IsHaveVideo),
                        DbHelper.MakeInParam("@IsHaveMusic",(DbType)SqlDbType.Int,4,miniBlog.IsHaveMusic),
                        DbHelper.MakeInParam("@IsHaveVote",(DbType)SqlDbType.Int,4,miniBlog.IsHaveVote),
                        DbHelper.MakeInParam("@FromID",(DbType)SqlDbType.Int,4,miniBlog.FromID),
                        DbHelper.MakeInParam("@ReferUID",(DbType)SqlDbType.VarChar,200,miniBlog.ReferUID)
                    };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "CreateQuoteMiniBlog", parms), -1);
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




        public DataTable GetMiniBlogsByUID(int pageIndex,int pageSize,ref int rowCount,long uid)
        {
            string where = "UID=" + uid.ToString();
            return Pager(pageIndex, pageSize, "TMiniBlog", where, ref rowCount);
        }

        public DataTable GetMiniBlogsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TMiniBlog", where, ref rowCount);
        }

        public IDataReader GetMiniBlogByIDCode(string idCode)
        {
            DbParameter[] parms = 
            {
                DbHelper.MakeInParam("@IDCode",(DbType)SqlDbType.VarChar,30,idCode)
            };
            return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT {0} FROM TMiniBlog WHERE IDCode=@IDCode", DbFields.MINIBLOG), parms);
        }

        public IDataReader GetMiniBlogByID(long id)
        {
            return GetRowByID("TMiniBlog", id, DbFields.MINIBLOG);
        }

        public bool DelMiniBlogByMID(long mid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,mid)
                                          };
                   result=TypeConverter.ObjectToInt( DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelMiniBlogByMID", parms))>0;
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

        public long AddFavorite(long mid,long uid)
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
                        DbHelper.MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,mid),
                        DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
                        
                    };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "CreateFavorite", parms), -1);
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

        public bool DelFavorite(long mid, long uid)
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
                        DbHelper.MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,mid),
                        DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
                        
                    };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelFavorite", parms), -1)>0;
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

        public DataTable GetFavorteByPager(int pageIndex, int pageSize, long uid,string key,ref int rowCount)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                DbHelper.MakeInParam("@Key",(DbType)SqlDbType.NVarChar,1000,key)
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetFavoriteByPager", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[2].Value);
            return dt;
        }

        public DataTable GetAtMeByPager(int pageIndex, int pageSize,string key,int isFollow,int isOri,long uid, ref int rowCount)
        {
            string where = string.Format("(ReferUID like '%a{0}a%' or ReferUID like 'a{0}a%')",uid.ToString());
            if (!string.IsNullOrEmpty(key))
                where += string.Format("and (OriginalContent like '%{0}' or OriginalContent like '{0}%' or OriginalContent like '%{0}%' or OriginalContent like '{0}' or OriginalMContent like '%{0}' or OriginalMContent like '{0}%' or OriginalMContent like '%{0}%' or OriginalMContent like '{0}')",key);
            if (isFollow > 0 && uid > 0)
            {
                where += " and UID in (select FollowUID from TFollow where UID=" + uid.ToString() + ")";
            }
            if (isOri > 0)
                where += " and IsOriginal=1";
            return GetMiniBlogsByPager(pageIndex, pageSize, where, ref rowCount);
 
        }

        public DataTable SearchMiniBlog(int pageIndex,int pageSize,ref int rowCount,string key,int isOri,int location,DateTime? startTime,DateTime? endTime,int isMyself,int isMyFollow,
            long curUid, string someone, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
                DbHelper.MakeInParam("@Key",(DbType)SqlDbType.NVarChar,0,key),
                DbHelper.MakeInParam("@IsOri",(DbType)SqlDbType.Int,4,isOri),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,location),
                DbHelper.MakeInParam("@StartTime",(DbType)SqlDbType.DateTime,4,startTime),
                DbHelper.MakeInParam("@EndTime",(DbType)SqlDbType.DateTime,4,endTime),
                DbHelper.MakeInParam("@IsMyself",(DbType)SqlDbType.Int,4,isMyself),
                DbHelper.MakeInParam("@IsMyFollow",(DbType)SqlDbType.Int,4,isMyFollow),
                DbHelper.MakeInParam("@CurUID",(DbType)SqlDbType.Int,8,curUid),
                DbHelper.MakeInParam("@SomeOne",(DbType)SqlDbType.NVarChar,50,someone),
                DbHelper.MakeInParam("@IsHavePic",(DbType)SqlDbType.Int,4,isHavePic),
                DbHelper.MakeInParam("@IsHaveLink",(DbType)SqlDbType.Int,4,isHaveLink),
                DbHelper.MakeInParam("@IsHaveVideo",(DbType)SqlDbType.Int,4,isHaveVideo),
                DbHelper.MakeInParam("@IsHaveMusic",(DbType)SqlDbType.Int,4,isHaveMusic),
                DbHelper.MakeInParam("@IsHaveVote",(DbType)SqlDbType.Int,4,isHaveVote),
                DbHelper.MakeInParam("@Sort",(DbType)SqlDbType.VarChar,100,sort),
                                DbHelper.MakeInParam("@GroupID",(DbType)SqlDbType.BigInt,8,GroupID),
                DbHelper.MakeInParam("@IsFriendShip",(DbType)SqlDbType.Int,4,IsFriendShip)
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "SearchMiniBlog", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[2].Value);
            return dt;
        }


        public DataTable SearchMiniBlogForMbIndexAdvanced(int pageIndex, int pageSize, ref int rowCount, string key, int isOri,int isRet, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
            long curUid, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
                DbHelper.MakeInParam("@Key",(DbType)SqlDbType.NVarChar,0,key),
                DbHelper.MakeInParam("@IsOri",(DbType)SqlDbType.Int,4,isOri),
                DbHelper.MakeInParam("@IsRet",(DbType)SqlDbType.Int,4,isRet),
                DbHelper.MakeInParam("@StartTime",(DbType)SqlDbType.DateTime,4,startTime),
                DbHelper.MakeInParam("@EndTime",(DbType)SqlDbType.DateTime,4,endTime),
                DbHelper.MakeInParam("@IsMyself",(DbType)SqlDbType.Int,4,isMyself),
                DbHelper.MakeInParam("@IsMyFollow",(DbType)SqlDbType.Int,4,isMyFollow),
                DbHelper.MakeInParam("@CurUID",(DbType)SqlDbType.Int,8,curUid),
                DbHelper.MakeInParam("@IsHavePic",(DbType)SqlDbType.Int,4,isHavePic),
                DbHelper.MakeInParam("@IsHaveLink",(DbType)SqlDbType.Int,4,isHaveLink),
                DbHelper.MakeInParam("@IsHaveVideo",(DbType)SqlDbType.Int,4,isHaveVideo),
                DbHelper.MakeInParam("@IsHaveMusic",(DbType)SqlDbType.Int,4,isHaveMusic),
                DbHelper.MakeInParam("@IsHaveVote",(DbType)SqlDbType.Int,4,isHaveVote),
                DbHelper.MakeInParam("@Sort",(DbType)SqlDbType.VarChar,100,sort),
                                DbHelper.MakeInParam("@GroupID",(DbType)SqlDbType.BigInt,8,GroupID),
                DbHelper.MakeInParam("@IsFriendShip",(DbType)SqlDbType.Int,4,IsFriendShip)
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "SearchMiniBlogForMbIndexAdvanced", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[2].Value);
            return dt;
        }
    }
}
