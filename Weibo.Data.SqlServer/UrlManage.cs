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
        public long CreateUrl(Url url)
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
                        DbHelper .MakeInParam("@OriginalUrl",(DbType)SqlDbType.NVarChar,200,url.OriginalUrl),
                        DbHelper .MakeInParam("@ShortLink",(DbType)SqlDbType.VarChar,50,url.ShortLink),
                        DbHelper .MakeInParam("@MediaID",(DbType)SqlDbType.BigInt,8,url.MediaID),
                        DbHelper .MakeInParam("@Type",(DbType)SqlDbType.Int,4,url.Type)
                    };
                   result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(trans,CommandType.StoredProcedure, "CreateUrl", parms), -1);
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

        public bool DelUrl(long id)
        {
            DbParameter[] parms = 
            {
                DbHelper .MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,id)
            };

            return TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure,"DelUrl",parms),-1)==1;

        }

        public IDataReader GetUrlByShortLink(string shortLinkCode)
        {
            string where = "ShortLink='" + shortLinkCode+"'";
            return GetRowByQuery("TUrl",where,DbFields.URL);
        }

        public DataTable GetUrlsByPager(int pageIndex,int pageSize,string where,ref int rowCount)
        {
            return Pager(pageIndex,pageSize,"TUrl",where,ref rowCount);
        }

        public bool UpdateUrlForRefCount(long id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,id)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateUrlForRefCount", parms);
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

        public bool UpdateUrlForMedia(long id,long MediaID,int type)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,id),
                                              DbHelper.MakeInParam("@MediaID",(DbType)SqlDbType.BigInt,8,MediaID),
                                              DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,type)
                                          };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateUrlForMedia", parms);
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

    }
}
