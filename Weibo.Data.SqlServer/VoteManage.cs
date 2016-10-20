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
        public long CreateVote(Vote vote)
        {
            DbParameter[] parms = 
            {
                DbHelper.MakeInParam("@Title",(DbType)SqlDbType.NVarChar,100,vote.Title),
                DbHelper.MakeInParam("@Remark",(DbType)SqlDbType.NVarChar,250,vote.Remark),
                DbHelper.MakeInParam("@PID",(DbType)SqlDbType.Int,8,vote.PID),
                DbHelper.MakeInParam("@ExpireTime",(DbType)SqlDbType.NVarChar,100,vote.ExpireTime),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,vote.Type),
                DbHelper.MakeInParam("@OptionCount",(DbType)SqlDbType.Int,4,vote.OptionCount),
                DbHelper.MakeInParam("@OnceSelCount",(DbType)SqlDbType.Int,4,vote.OnceSelCount),
                DbHelper.MakeInParam("@ResultVisible",(DbType)SqlDbType.Int,4,vote.ResultVisible),
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.Int,8,vote.UID)
            };

            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreateVote",parms),-1);
        }

        public bool DelVote(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,id)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelVote", parms);
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

        public bool UpdateVoteForJoinCount(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            var result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,id)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateVoteForJoinCount", parms);
                    trans.Commit();
                    result = true;
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
        public bool UpdateVoteForExpireTime(DateTime expireTime,long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            var result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,id),
                                              DbHelper.MakeInParam("@ExpireTime",(DbType)SqlDbType.DateTime,0,expireTime),
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateVoteForExpireTime", parms);
                    trans.Commit();
                    result = true;
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

        public IDataReader GetVoteByID(long id)
        {
            return GetRowByID("TVote", id, DbFields.VOTE);
        }

        public DataTable GetVoteByUID(long uid)
        {
            return GetTableByQuery("TVote","UID="+uid.ToString(),DbFields.VOTE);
        }

        public DataTable GetVotesByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TVote", where, ref rowCount);
        }
    }
}