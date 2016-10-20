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
        public long CreateComplaint(Complaint complaint)
        {
            DbParameter[] parms =
            {

                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,complaint.UID),
                DbHelper.MakeInParam("@ToUID",(DbType)SqlDbType.BigInt,8,complaint.ToUID),
                DbHelper.MakeInParam("@ComplaintConType",(DbType)SqlDbType.Int,4,complaint.ComplaintConType),
                DbHelper.MakeInParam("@ComplaintConID",(DbType)SqlDbType.BigInt,8,complaint.ComplaintConID),
                DbHelper.MakeInParam("@ComplaintReason",(DbType)SqlDbType.Int,4,complaint.ComplaintReason),
                DbHelper.MakeInParam("@ComplaintSupplement",(DbType)SqlDbType.NText,0,complaint.ComplaintSupplement),

            };
            return TypeConverter.ObjectToLong(
                                 DbHelper.ExecuteScalar(CommandType.StoredProcedure,
                                                        "CreateComplaint", parms), -1);
        }

        public bool DelComplaint(long complaintID)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
                    {
                        DbHelper.MakeInParam("@ComplaintID",(DbType)SqlDbType.BigInt,8,complaintID)
                    };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelComplaint", parms);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return true;
        }

        public bool HandleComplaint(long complaintID,DateTime HandleTime,string HandleResult)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
                    {
                        DbHelper.MakeInParam("@ComplaintID",(DbType)SqlDbType.BigInt,8,complaintID),
                        DbHelper.MakeInParam("@HandleTime",(DbType)SqlDbType.DateTime,0,HandleTime),
                        DbHelper.MakeInParam("@HandleResult",(DbType)SqlDbType.NText,0,HandleResult)
                    };
                    DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "HandleComplaint", parms);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            conn.Close();
            return true;
        }

        public DataTable GetComplaintsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TComplaint", where, ref rowCount);
        }

        public IDataReader GetComplaintByID(long id)
        {
            return GetRowByID("TComplaint", id, DbFields.COMPLAINT);
        }
    }
}
