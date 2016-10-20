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
        public long CreatePic(Pic pic)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@OriginalPicUrl",(DbType)SqlDbType.NVarChar,200,pic.OriginalPicUrl),
                DbHelper.MakeInParam("@MidPicUrl",(DbType)SqlDbType.NVarChar,200,pic.MidPicUrl),
                DbHelper .MakeInParam("@SmallPicUrl",(DbType)SqlDbType.NVarChar,200,pic.SmallPicUrl),
                DbHelper .MakeInParam("@ThumPicUrl",(DbType)SqlDbType.NVarChar,200,pic.ThumPicUrl)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreatePic",parms),-1);
        }

        public bool DelPic(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@PID",(DbType)SqlDbType.BigInt,8,id)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelPic", parms))>1;
        }

        public IDataReader GetPicByID(long id)
        {
            return GetRowByID("TPic", id, DbFields.PIC);
        }

        public DataTable GetPicsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TPic", where, ref rowCount);
        }
    }
}