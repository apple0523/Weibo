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
		public long CreateBlackList(BlackList blackList)
		{
			DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,blackList.UID),
                DbHelper.MakeInParam("@PulledUID",(DbType)SqlDbType.BigInt,8,blackList.PulledUID)
            };
			return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateBlackList", parms), -1);
		}

		public bool DelBlackList(long id)
		{
			DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id)
            };
			return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelBlackList", parms), -1)>0;
		}

        public bool DelBlackListByUID(long uid,long pulledUid)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                DbHelper.MakeInParam("@PulledUID",(DbType)SqlDbType.BigInt,8,pulledUid)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelBlackListByUID", parms), -1) > 0;
        }

		public bool IsInBlackList(long uid,long pulledUid)
		{
			DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                DbHelper.MakeInParam("@PulledUID",(DbType)SqlDbType.BigInt,8,pulledUid)
            };
			return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "IsInBlackList", parms), -1)>0;
		}

		public DataTable GetBlackListByUID(long uid)
		{
			return GetTableByQuery("TBlackList", "UID=" + uid.ToString(), DbFields.BLACKLIST);
		}

		public DataTable GetBlackListByPager(int pageIndex, int pageSize, string where, ref int rowCount)
		{
            return Pager(pageIndex, pageSize, "TBlackList", where, ref rowCount);
		}
	}
}
