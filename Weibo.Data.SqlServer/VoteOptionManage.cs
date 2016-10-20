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
        public long CreateVoteOption(VoteOption voteOption)
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
                         DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,voteOption.VID),
                         DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,100,voteOption.Name)
                    };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateVoteOption", parms), -1);
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

        public IDataReader GetVoteOptionByID(long id)
        {
            return GetRowByID("TVoteOption", id, DbFields.VOTEOPTION);
        }

        public DataTable GetVoteOptionsByVID(long vid)
        {
            string where = "VID=" + vid.ToString();
            return GetTableByQuery("TVoteOption", where, DbFields.VOTEOPTION, "CreateTime", "asc");
        }

        public bool UpdateVoteOptionForVoteCount(long id)
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
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateVoteOptionForVoteCount", parms);
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
    }
}
