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
        public long CreateLog(Log log)
        {
            DbParameter[] parms =
            {

                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,log.Type),
              DbHelper.MakeInParam("@Content",(DbType)SqlDbType.NText,50,log.Content),
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateLog", parms), -1);
        }



        public bool DelLog(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id),
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelLog", parms), -1) > 0;
        }

       
    }
}
