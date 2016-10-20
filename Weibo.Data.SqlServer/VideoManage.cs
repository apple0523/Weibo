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
        public long CreateVideo(Video video)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Title",(DbType)SqlDbType.NVarChar,100,video.Title),
                DbHelper.MakeInParam("@ThumPicUrl",(DbType)SqlDbType.NVarChar,200,video.ThumPicUrl),
                DbHelper.MakeInParam("@FlvUrl",(DbType)SqlDbType.NVarChar,200,video.FlvUrl),
                DbHelper.MakeInParam("@OriUrl",(DbType)SqlDbType.NVarChar,200,video.OriUrl),
                DbHelper.MakeInParam("@FromWeb",(DbType)SqlDbType.Int,4,video.FromWeb)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreateVideo",parms),-1);
        }

        public bool DelVideo(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,id)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelVideo", parms),-1) == 1;
        }

        public IDataReader GetVideoByID(long id)
        {
            return GetRowByID("TVideo",id,DbFields.VIDEO);
        }

        public DataTable GetVideosByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex,pageSize,"TVideo",where,ref rowCount);
        }
    }
}
