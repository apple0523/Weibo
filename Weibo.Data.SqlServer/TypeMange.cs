using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Data;
using System.Data.Common;
using System.Data;
using Weibo.Entity;
using Weibo.Common;

namespace Weibo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public DataTable GetTypesByPID(int pid)
        {
            DbParameter[] parms=
            {
                   DbHelper.MakeInParam("@pid",(DbType)SqlDbType.Int,4,pid )
            };
            
           return DbHelper.ExecuteDataset(CommandType.Text,string .Format("SELECT {0} FROM TType where PID=@pid",DbFields.TYPE),parms).Tables[0];
        }

        public IDataReader GetTypeByID(int id)
        {
            DbParameter[] parms =
            {
                   DbHelper.MakeInParam("@id",(DbType)SqlDbType.Int,4,id )
            };

            return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT {0} FROM [TType] where [ID]=@id", DbFields.TYPE), parms);
        }
    }
}
