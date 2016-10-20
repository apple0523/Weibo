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
        public int CreateSchool(School school)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,school.Name),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,school.Location),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,school.Type),
                DbHelper.MakeInParam("@FrontLetter",(DbType)SqlDbType.NChar,0,school.FrontLetter)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateSchool", parms), -1);
        }

        public DataTable GetShoolsByLetLocType(int Location, string letter,int type)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Letter",(DbType)SqlDbType.NChar,50,letter),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,Location),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,type),
            };
            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetShoolsByLetLocType", parms).Tables[0];
        }

        public IDataReader GetSchoolByID(int id)
        {
            return GetRowByID("TSchool", id, DbFields.SCHOOL);
        }

        public DataTable GetSchoolsByLikeName(string name)
        {
            return GetTop10TableByQuery("TSchool", string.Format("Name like '%{0}%' or Name like '{0}%' or Name like '%{0}' or Name like '{0}'", name), DbFields.SCHOOL, "CreateTime", "desc");
        }

    }
}
