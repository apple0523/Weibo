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
       public long CreateVoteJoin(VoteJoin voteJoin)
       {
           SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
           conn.Open();
           long result = -1;
           using (SqlTransaction trans = conn.BeginTransaction())
           {
               try
               {
                   DbParameter[] parms =
                    {
                         DbHelper.MakeInParam("@VID",(DbType)SqlDbType.BigInt,8,voteJoin.VID),
                         DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,voteJoin.UID),
                         DbHelper.MakeInParam("@SelVoteItemIDs",(DbType)SqlDbType.VarChar,300,voteJoin.SelVoteItemIDs),
                         DbHelper.MakeInParam("@SelVoteItemNames",(DbType)SqlDbType.VarChar,500,voteJoin.SelVoteItemNames),
                         DbHelper.MakeInParam("@IsAnonymous",(DbType)SqlDbType.Int,4,voteJoin.IsAnonymous),
                         DbHelper.MakeInParam("@SelCount",(DbType)SqlDbType.Int,4,voteJoin.SelVoteItemIDs.Split(',').Length-1),
                    };
                   result = TypeConverter.ObjectToLong(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateVoteJoin", parms), -1);
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


       public IDataReader GetVoteJoinByUID(long uid,long vid)
       {
           return GetRowByQuery("TVoteJoin", "UID=" + uid.ToString()+" and VID="+vid.ToString(), DbFields.VOTEJOIN);
       }
    }
}
