using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Data;
using System.Data.Common;
using System.Data;
using Weibo.Entity;
using Weibo.Common;
using System.Data.SqlClient;
namespace Weibo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public long CreateMessage(Message message)
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
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,message.UID),
                DbHelper.MakeInParam("@ToUID",(DbType)SqlDbType.BigInt,8,message.ToUID),
                DbHelper.MakeInParam("@Content",(DbType)SqlDbType.NText,0,message.Content)
            };

                    result= TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(trans,CommandType.StoredProcedure, "CreateMessage", parms), -1);
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

        public bool DelMessageByMID(long mid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result =false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
            {
                DbHelper.MakeInParam("@MID",(DbType)SqlDbType.BigInt,8,mid),
            };

                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelMessageByMID", parms), -1) > 0;
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

        public bool DelMessageByUID(long uid, long toUid)
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
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                 DbHelper.MakeInParam("@ToUID",(DbType)SqlDbType.BigInt,8,toUid),
            };

                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelMessageByUID", parms), -1) > 0;
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

        public DataTable GetMessagesByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
           return Pager(pageIndex, pageSize, "TMessage", where, ref rowCount);
        }

        public IDataReader GetMessageByID(long id)
        {
            return GetRowByID("TMessage",id,DbFields.MESSAGE);
        }

        public DataTable GetContactByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TContact", where, ref rowCount);
        }

        public bool DelContact(long uid,long uid1)
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
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                DbHelper.MakeInParam("@UID1",(DbType)SqlDbType.BigInt,8,uid1),
            };

                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelContact", parms), -1) > 0;
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
    }
}
