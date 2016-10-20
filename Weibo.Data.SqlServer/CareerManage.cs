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
        public long CreateCareer(Career career)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,career.UID),
                DbHelper.MakeInParam("@CompanyID",(DbType)SqlDbType.Int,4,career.CompanyID),
                DbHelper.MakeInParam("@CompanyName",(DbType)SqlDbType.NVarChar,50,career.CompanyName),
                DbHelper.MakeInParam("@IsVisible",(DbType)SqlDbType.Int,4,career.IsVisible),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,career.Location),
                DbHelper.MakeInParam("@StartDate",(DbType)SqlDbType.NVarChar,10,career.StartDate),
                DbHelper.MakeInParam("@EndDate",(DbType)SqlDbType.NVarChar,10,career.EndDate),
                DbHelper.MakeInParam("@Position",(DbType)SqlDbType.NVarChar,70,career.Position)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateCareer", parms), -1);
        }

        public IDataReader GetCareerByID(long id)
        {
            return GetRowByID("TCareer", id, DbFields.CAREER);
        }

        public DataTable GetCareersByUID(long uid)
        {
            return GetTableByQuery("TCareer", "UID=" + uid.ToString(), DbFields.CAREER);
        }

        public DataTable GetCareersByIsVisible(long uid, int isVisible)
        {
            return GetTableByQuery("TCareer", "UID=" + uid.ToString() + " and IsVisible=" + isVisible.ToString(), DbFields.CAREER);
        }

        public bool DelCareer(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id),
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelCareer", parms), -1) > 0;
        }

        public bool UpdateCareer(Career career)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,career.ID),
                DbHelper.MakeInParam("@CompanyID",(DbType)SqlDbType.Int,4,career.CompanyID),
                DbHelper.MakeInParam("@CompanyName",(DbType)SqlDbType.NVarChar,50,career.CompanyName),
                DbHelper.MakeInParam("@IsVisible",(DbType)SqlDbType.Int,4,career.IsVisible),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,career.Location),
                DbHelper.MakeInParam("@StartDate",(DbType)SqlDbType.NVarChar,10,career.StartDate),
                DbHelper.MakeInParam("@EndDate",(DbType)SqlDbType.NVarChar,10,career.EndDate),
                DbHelper.MakeInParam("@Position",(DbType)SqlDbType.NVarChar,70,career.Position)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateCareer", parms), -1) > 0;
        }
    }
}
