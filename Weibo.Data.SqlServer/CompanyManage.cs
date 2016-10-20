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
        public int CreateCompany(Company company)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,company.Name),

            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateCompany", parms), -1);
        }

        public DataTable GetCompanysByLikeName(string name)
        {
            return GetTop10TableByQuery("TCompany", string.Format("Name like '%{0}%' or Name like '{0}%' or Name like '%{0}' or Name like '{0}'", name), DbFields.COMPANY, "CreateTime", "desc");
        }

        public IDataReader GetCompanysByName(string name)
        {
            return GetRowByQuery("TCompany", string.Format("Name ='{0}'", name), DbFields.COMPANY);
        }

        public IDataReader GetCompanyByID(int id)
        {
            return GetRowByID("TCompany", id, DbFields.COMPANY);
        }
    }
}
