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
        public long CreateEducation(Education education)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,education.UID),
                DbHelper.MakeInParam("@SchoolID",(DbType)SqlDbType.Int,4,education.SchoolID),
               DbHelper.MakeInParam("@SchoolName",(DbType)SqlDbType.NVarChar,50,education.SchoolName),
                DbHelper.MakeInParam("@IsVisible",(DbType)SqlDbType.Int,4,education.IsVisible),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,education.Type),
                DbHelper.MakeInParam("@StartDate",(DbType)SqlDbType.NVarChar,10,education.StartDate),
                DbHelper.MakeInParam("@Remark",(DbType)SqlDbType.NVarChar,70,education.Remark)
            };
            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateEducation", parms), -1);
        }

        public IDataReader GetEducationByID(long id)
        {
            return GetRowByID("TEducation", id, DbFields.EDUCATION);
        }

        public DataTable GetEducationsByUID(long uid)
        {
            return GetTableByQuery("TEducation", "UID=" + uid.ToString(), DbFields.EDUCATION);
        }

        public DataTable GetEducationsByIsVisible(long uid, int isVisible)
        {
            return GetTableByQuery("TEducation", "UID=" + uid.ToString()+" and IsVisible="+isVisible.ToString(), DbFields.EDUCATION);
        }

        public bool DelEducation(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id),
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelEducation", parms), -1)>0;
        }

        public bool UpdateEducation(Education education)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,education.ID),
                DbHelper.MakeInParam("@SchoolID",(DbType)SqlDbType.Int,4,education.SchoolID),
                DbHelper.MakeInParam("@SchoolName",(DbType)SqlDbType.NVarChar,50,education.SchoolName),
                DbHelper.MakeInParam("@IsVisible",(DbType)SqlDbType.Int,4,education.IsVisible),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,education.Type),
                DbHelper.MakeInParam("@StartDate",(DbType)SqlDbType.NVarChar,10,education.StartDate),
                DbHelper.MakeInParam("@Remark",(DbType)SqlDbType.NVarChar,70,education.Remark)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateEducation", parms), -1)>0;
        }
    }
}
