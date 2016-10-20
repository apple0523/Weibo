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
        public int CreateExpression(Expression expression)
        {
            DbParameter[] parms =
            {
                DbHelper .MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,expression.Name),
                DbHelper .MakeInParam("@Code",(DbType)SqlDbType.NVarChar,50,expression.Code),
                DbHelper .MakeInParam("@Type",(DbType)SqlDbType.Int,4,expression.Type),
                DbHelper .MakeInParam("@Url",(DbType)SqlDbType.NVarChar,200,expression.Url),
                DbHelper .MakeInParam("@OriUrlUrl",(DbType)SqlDbType.NVarChar,200,expression.OriUrl),
                DbHelper .MakeInParam("@IsDefault",(DbType)SqlDbType.Int,4,expression.IsDefault),
                DbHelper .MakeInParam("@IsTop",(DbType)SqlDbType.Int,4,expression.IsTop)

            };

            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateExpression", parms),-1);
        }

        public bool UpdateExpression(Expression expression)
        {
            DbParameter[] parms =
            {
                DbHelper .MakeInParam("@EID",(DbType)SqlDbType.Int,4,expression.ID),
                DbHelper .MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,expression.Name),
                DbHelper .MakeInParam("@Code",(DbType)SqlDbType.NVarChar,50,expression.Code),
                DbHelper .MakeInParam("@Type",(DbType)SqlDbType.Int,4,expression.Type),
                DbHelper .MakeInParam("@Url",(DbType)SqlDbType.NVarChar,200,expression.Url),
                DbHelper .MakeInParam("@OriUrlUrl",(DbType)SqlDbType.NVarChar,200,expression.OriUrl),
                DbHelper .MakeInParam("@IsDefault",(DbType)SqlDbType.Int,4,expression.IsDefault),
                DbHelper .MakeInParam("@IsTop",(DbType)SqlDbType.Int,4,expression.IsTop)
            };

            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateExpressionByEID", parms))>0;
        }

        public bool DelExpression(int eid)
        {
            DbParameter[] parms =
            {
                DbHelper .MakeInParam("@EID",(DbType)SqlDbType.Int,4,eid)
            };

            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelExpressionByEID", parms)) >0;

        }

        public DataTable GetExpressionsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TExpression", where, ref rowCount);
        }

        public IDataReader GetExpressionByID(int id)
        {
            return GetRowByID("TExpression", id, DbFields.EXPRESSION);
        }

        public IDataReader GetExpressionByName(string name)
        {
            return GetRowByQuery("TExpression","Name='"+name+"'",DbFields.EXPRESSION);
        }

        public DataTable GetAllExpressions()
        {
            return GetAll("TExpression", DbFields.EXPRESSION, "CreateTime", "asc");
        }

    }
}
