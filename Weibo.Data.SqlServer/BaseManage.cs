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
       public DataTable Pager(int pageIndex, int pageSize,string tableName,string where, ref int rowCount)
        {
            DbParameter[] parms=
            {
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeInParam("@TableName",(DbType)SqlDbType.NVarChar,4000,tableName),
                DbHelper.MakeInParam("@Where",(DbType)SqlDbType.NVarChar,4000,where),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
            };

            DataTable dt= DbHelper.ExecuteDataset(CommandType.StoredProcedure, "Pager", parms).Tables[0];
            rowCount =TypeConverter.ObjectToInt( parms[4].Value);
            return dt;
        }

       public IDataReader GetRowByID(string tableName, int id, string field)
       {
           DbParameter[] parms =
            {
                DbHelper .MakeInParam("@ID",(DbType)SqlDbType.Int,4,id)
            };
           return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT {0} FROM {1} where ID=@ID",field,tableName), parms);

       }

       public IDataReader GetRowByID(string tableName, long id, string field)
       {
           DbParameter[] parms =
            {
                DbHelper .MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id)
            };
           return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT {0} FROM {1} where ID=@ID", field, tableName), parms);

       }

       public IDataReader GetRowByQuery(string tableName, string query, string field)
       {
           return DbHelper.ExecuteReader(CommandType.Text, string.Format("SELECT {0} FROM {1} where {2}", field, tableName,query));
       }

       public DataTable GetTableByQuery(string tableName, string query, string field)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT {0} FROM {1} where {2} order by [CreateTime] desc", field, tableName, query)).Tables[0];
       }

       public DataTable GetTableByQuery(string tableName, string query, string field,string sortField,string sortType)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT {0} FROM {1} where {2} order by [{3}] {4}", field, tableName, query,sortField,sortType)).Tables[0];
       }

       public DataTable GetTableByOriQuery(string query)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, query).Tables[0];
       }

       public DataTable GetTop10TableByQuery(string tableName, string query, string field, string sortField, string sortType)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT TOP 10 {0} FROM {1} where {2} order by [{3}] {4}", field, tableName, query, sortField, sortType)).Tables[0];
       }
       public DataTable GetTop500TableByQuery(string tableName, string query, string field, string sortField, string sortType)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT TOP 500 {0} FROM {1} where {2} order by [{3}] {4}", field, tableName, query, sortField, sortType)).Tables[0];
       }

       public DataTable GetAll(string tableName, string field, string sortField, string sortType)
       {
           return DbHelper.ExecuteDataset(CommandType.Text, string.Format("SELECT {0} FROM {1} order by [{2}] {3}", field, tableName, sortField, sortType)).Tables[0];
       }

       public int GetCount(string tableName, string where)
       {
           return TypeConverter.ObjectToInt(DbHelper .ExecuteScalar(CommandType.Text,string.Format("SELECT COUNT(*) FROM {1} where {0}",where,tableName)),0);
       }
    }
}




