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
        public long CreateTopic(Topic topic)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,100,topic.Name)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateTopic", parms), -1);
        }

        public bool DelTopic(long id)
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
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelTopic", parms);
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

        public bool UpdateTopicForRefCount(long id)
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
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateTopicForRefCount", parms);
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

       
        public DataTable GetTopicsBySearch(string searchName)
        {
            string where = string.Format("(Name like '%{0}' or Name like '{0}%' or Name like '{0}' or Name like '%{0}%') and Name<>'{0}'", searchName);
            return GetTop10TableByQuery("TTopic", where, DbFields.TOPIC, "RefCount", "desc");
        }

        public IDataReader GetTopicByName(string Name)
        {
            return GetRowByQuery("TTopic", "Name='" + Name + "'", DbFields.TOPIC);
        }

        public DataTable GetTopicsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TTopic", where, ref rowCount);
        }

        public long CreateStatisticTopic(StatisticTopic st)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@TopicID",(DbType)SqlDbType.BigInt,8,st.TopicID),
				DbHelper.MakeInParam("@TopicName",(DbType)SqlDbType.NVarChar,100,st.TopicName)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateStatisticTopic", parms), -1);
        }

        public bool DelAllStaticTopic()
        {
            return TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelAllStaticTopic"), -1) > 0;
        }

        public DataTable GetTopStaticTopic(DateTime startTime, DateTime endTime, int topCount)
        {
            DbParameter[] parms =
            {
				 DbHelper.MakeInParam("@StartTime",(DbType)SqlDbType.DateTime,4,startTime),
                 DbHelper.MakeInParam("@EndTime",(DbType)SqlDbType.DateTime,4,endTime),
				  DbHelper.MakeInParam("@TopCount",(DbType)SqlDbType.Int,4,topCount)
			};
            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetTopStaticTopic", parms).Tables[0];
            return dt;
        }

        public long CreateUserTopic(UserTopic ut)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,ut.UID),
				 DbHelper.MakeInParam("@TopicID",(DbType)SqlDbType.BigInt,8,ut.TopicID),
				 DbHelper.MakeInParam("@TopicName",(DbType)SqlDbType.NVarChar,100,ut.TopicName)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateUserTopic", parms), -1);
        }

        public IDataReader GetUserTopicByName(string Name)
        {
            return GetRowByQuery("TUserTopic", "TopicName='" + Name + "'", DbFields.USERTOPIC);
        }

        public bool DelUserTopic(long id)
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
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelUserTopic", parms);
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

        public DataTable GetUserTopicByUID(long uid)
        {
            return GetTableByQuery("TUserTopic", "UID=" + uid.ToString(), DbFields.USERTOPIC);
        }
    }
}
