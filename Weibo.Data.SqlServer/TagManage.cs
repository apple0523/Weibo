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
        public long CreateTag(Tag tag)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,tag.Name)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateTag", parms), -1);
        }

        public bool DelTag(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@TID",(DbType)SqlDbType.BigInt,8,id)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelTag", parms);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return true;
        }
        public DataTable GetTop10TagsByQuery(string where, string sortField, string sortType)
        {
            return GetTop10TableByQuery("TTag", where, DbFields.Tag, sortField, sortType);
        }
        public IDataReader GetTagByID(long id)
        {
            return GetRowByID("TTag", id, DbFields.Tag);
        }

        public IDataReader GetTagByName(string Name)
        {
            return GetRowByQuery("TTag", "Name='" + Name + "'", DbFields.Tag);
        }

        public DataTable GetInterestTag(long uid)
        {
            string query = string.Format("select top 50 {0} from {1} where ID not IN (select TagID from {2} where UID={3}) order by newid() desc", DbFields.Tag, "TTag", "TUserTag", uid.ToString());
            return GetTableByOriQuery(query);
        }



        public DataTable GetTagsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TTag", where, ref rowCount);
        }

        public bool UpdateTagForRefCount(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@TID",(DbType)SqlDbType.BigInt,4,id)
                                          };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateTagForRefCount", parms)) > 0;
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

        public long CreateUserTag(UserTag userTag)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@TagName",(DbType)SqlDbType.NVarChar,50,userTag.TagName),
				DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,userTag.UID),
				DbHelper.MakeInParam("@TagID",(DbType)SqlDbType.BigInt,8,userTag.TagID)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateUserTag", parms), -1);
        }

        public DataTable GetUserTagsByUID(long uid)
        {
            return GetTableByQuery("TUserTag", "UID=" + uid.ToString(), DbFields.USERTAG);
        }

        public IDataReader GetUserTagByUidTagid(long tagId, long uid)
        {
            return GetRowByQuery("TUserTag", "TagID=" + tagId.ToString() + "AND UID=" + uid.ToString(), DbFields.USERTAG);
        }
        public IDataReader GetUserTagByNameUID(string Name,long uid)
        {
            return GetRowByQuery("TUserTag", "UID="+uid.ToString()+" and TagName='" + Name + "'", DbFields.USERTAG);
        }
        public bool DelUserTag(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelUserTag", parms);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return true;
        }

        public int GetUserTagCount(long uid)
        {
            return GetCount("TUserTag", "UID=" + uid.ToString());
        }
    }
}
