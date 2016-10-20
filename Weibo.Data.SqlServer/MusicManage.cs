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
        public long CreateMusic(Music music)
        {
            DbParameter[] parms = 
            {
                DbHelper .MakeInParam("@MusicUrl",(DbType)SqlDbType.NVarChar,200,music.MusicUrl),
                DbHelper .MakeInParam("@Title",(DbType)SqlDbType.NVarChar,200,music.Title)
            };

            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreateMusic",parms),-1);
        }

        public DataTable GetMusicsByPager(int pageIndex, int pageSize,string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TMusic", where, ref rowCount);
        }

        public IDataReader GetMusicByID(long id)
        {
            return GetRowByID("TMusic", id, DbFields.MUSIC);
        }
    }
}
