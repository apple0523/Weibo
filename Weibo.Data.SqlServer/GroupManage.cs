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
        public long CreateGroup(Group group)
        {
            DbParameter[] parms =
            {
                DbHelper .MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,group.Name),
                DbHelper .MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,group.UID),
                DbHelper .MakeInParam("@Sort",(DbType)SqlDbType.Int,4,group.Sort)
            };

            return TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateGroup", parms), -1);
        }

        public bool UpdateGroupName(long Gid, string Name)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper .MakeInParam("@Name",(DbType)SqlDbType.NVarChar,50,Name),
                DbHelper .MakeInParam("@GID",(DbType)SqlDbType.BigInt,8,Gid)
                                          };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateGroupName", parms)) > 0;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return result;
        }

        public bool UpdateGroupSort( string SortList,long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper .MakeInParam("@SortList",(DbType)SqlDbType.VarChar,100,SortList),
                                              DbHelper .MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
                                          };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateGroupSort", parms)) > 0;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return result;
        }

        public bool DelGroup(long Gid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms = {
                                              DbHelper .MakeInParam("@GID",(DbType)SqlDbType.BigInt,8,Gid)
                                          };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelGroup", parms)) > 0;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return result;
        }

        public DataTable GetGroupsByUID(long UID)
        {
            return GetTableByQuery("TGroup", "UID=" + UID.ToString(), DbFields.GROUP, "Sort", "asc");
        }

        public IDataReader GetGroupByID(long GID)
        {
            return GetRowByID("TGroup", GID, DbFields.GROUP);
        }

        public IDataReader GetGroupByName(long UID, string Name)
        {
            string where = "UID=" + UID.ToString() + " And Name='" + Name + "'";
            return GetRowByQuery("TGroup", where, DbFields.GROUP);
        }

        public IDataReader GetTopSort(long UID)
        {
            return DbHelper.ExecuteReader(CommandType.Text, "Select top 1 * from TGroup where UID=" + UID.ToString() + " order by Sort desc");
        }

    }
}
