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
        public long CreateNotice(Notice notice)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Title",(DbType)SqlDbType.NVarChar,50,notice.Title),
                DbHelper.MakeInParam("@Content",(DbType)SqlDbType.NText,0,notice.Content),
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,notice.UID),
                DbHelper.MakeInParam("@ToUID",(DbType)SqlDbType.BigInt,8,notice.ToUID),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,notice.Type)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreateNotice",parms),-1);
        }

        public bool DelNotice(long id)
        {
            DbParameter[] parms =
            {

                DbHelper.MakeInParam("@NID",(DbType)SqlDbType.BigInt,8,id)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "DelNotice", parms),-1)==1;
        }

        public bool ReadNotice(long id)
        {
            DbParameter[] parms =
            {

                DbHelper.MakeInParam("@NID",(DbType)SqlDbType.Int,4,id)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "ReadNotice", parms),-1) == 1;

        }

        public DataTable GetNoticesByPager(int pageIndex,int pageSize,string where,ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TNotice", where, ref rowCount);
        }

        public IDataReader GetNoticeByID(long id)
        {
            return GetRowByID("TNotice", id, DbFields.NOTICE);
        }
    }
}
