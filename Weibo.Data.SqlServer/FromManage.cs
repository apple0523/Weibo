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
        public int CreateFrom(From from)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@FromName",(DbType)SqlDbType.NVarChar,50,from.FromName),
                DbHelper.MakeInParam("@FromUrl",(DbType)SqlDbType.VarChar,50,from.FromUrl)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateFrom", parms), -1);
        }

        public IDataReader GetFromByID(int id)
        {
            return GetRowByID("TFrom", id, DbFields.FROM);
        }

        public IDataReader GetFromByUrl(string url)
        {
            return GetRowByQuery("TFrom", "FromUrl='" + url + "'", DbFields.FROM);
        }

        public DataTable GetFromsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TFrom", where, ref rowCount);
        }

        public bool UpdateFromForFromCount(int id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@FID",(DbType)SqlDbType.Int,4,id)
                                          };
                  result=TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateFromForFromCount", parms))>0;
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
