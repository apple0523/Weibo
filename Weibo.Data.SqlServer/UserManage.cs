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
    public partial class DataProvider :IDataProvider
    {
        public long CreateUser(User user) 
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Email",(DbType)SqlDbType.NVarChar,100,user.Email),
                DbHelper.MakeInParam("@NickName",(DbType)SqlDbType.NVarChar,100,user.NickName),
                DbHelper.MakeInParam("@PassWord",(DbType)SqlDbType.NVarChar,100,user.Password),
                DbHelper.MakeInParam("@Sex",(DbType)SqlDbType.Int,4,user.Sex),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,user.Location),
                DbHelper.MakeInParam("@IP",(DbType)SqlDbType.NVarChar,50,user.IP),
                DbHelper.MakeInParam("@LastMID",(DbType)SqlDbType.Int,4,user.LastMID)
            };
            return TypeConverter.ObjectToLong(
                                 DbHelper.ExecuteScalar(CommandType.StoredProcedure,
                                                        "CreateUser",parms),-1);
        }
        public DataTable GetTop10UsersByQuery(string where, string sortField, string sortType)
        {
            return GetTop10TableByQuery("TUser", where, DbFields.USER, sortField, sortType);
        }
        public IDataReader GetUersByID(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,id)
            };
            return DbHelper.ExecuteReader(CommandType.Text, "SELECT " + DbFields.USER + "FROM TUser WHERE ID=@ID", parms);

        }

        public IDataReader GetUerByCustomSite(string CustomSite)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@CustomSite",(DbType)SqlDbType.VarChar,20,CustomSite)
            };
            return DbHelper.ExecuteReader(CommandType.Text, "SELECT " + DbFields.USER + "FROM TUser WHERE CustomSite=@CustomSite", parms);

        }

        public IDataReader GetUerByEmail(string email)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Email",(DbType)SqlDbType.NVarChar,100,email)
            };
            return DbHelper.ExecuteReader(CommandType.Text, "SELECT " + DbFields.USER + "FROM TUser WHERE Email=@Email", parms);

        }

        public IDataReader GetUserByNickName(string nickName)
        {
            string where = "NickName='" + nickName+"'";
            return GetRowByQuery("TUser", where, DbFields.USER);
        }

        public IDataReader GetUserByID(long id)
        {
            string where = "ID="+id.ToString() ;
            return GetRowByQuery("TUser", where, DbFields.USER);
        }

        public DataTable GetUsersByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TUser", where,ref rowCount);
        }


        public bool UpdateUser(User user)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@ID",(DbType)SqlDbType.BigInt,8,user.ID),
                DbHelper.MakeInParam("@NickName",(DbType)SqlDbType.NVarChar,100,user.NickName),
                DbHelper.MakeInParam("@PassWord",(DbType)SqlDbType.NVarChar,100,user.Password),
                DbHelper.MakeInParam("@BigAvartar",(DbType)SqlDbType.NVarChar,200,user.BigAvartar),
                DbHelper.MakeInParam("@SmallAvartar",(DbType)SqlDbType.NVarChar,200,user.SmallAvartar),
                DbHelper.MakeInParam("@MidAvartar",(DbType)SqlDbType.NVarChar,200,user.MidAvartar),
                DbHelper.MakeInParam("@Sex",(DbType)SqlDbType.Int,4,user.Sex),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,user.Location),
                DbHelper.MakeInParam("@IP",(DbType)SqlDbType.NVarChar,50,user.IP),
                DbHelper.MakeInParam("@LastMID",(DbType)SqlDbType.BigInt,8,user.LastMID),
                DbHelper.MakeInParam("@IsEmailValidate",(DbType)SqlDbType.Int,4,user.IsEmailValidate),
                DbHelper.MakeInParam("@RealName",(DbType)SqlDbType.NVarChar,30,user.RealName),
                DbHelper.MakeInParam("@RealNameVisible",(DbType)SqlDbType.Int,4,user.RealNameVisible),
                DbHelper.MakeInParam("@BirthDay",(DbType)SqlDbType.DateTime,8,user.BirthDay),
                DbHelper.MakeInParam("@BirthDayVisible",(DbType)SqlDbType.Int,4,user.BirthDayVisible),
                DbHelper.MakeInParam("@Blog",(DbType)SqlDbType.VarChar,200,user.Blog),
                DbHelper.MakeInParam("@BlogVisible",(DbType)SqlDbType.Int,4,user.BlogVisible),
                DbHelper.MakeInParam("@ContactEmail",(DbType)SqlDbType.VarChar,200,user.ContactEmail),
                DbHelper.MakeInParam("@ContactEmailVisible",(DbType)SqlDbType.Int,4,user.ContactEmailVisible),
                DbHelper.MakeInParam("@QQ",(DbType)SqlDbType.VarChar,50,user.QQ),
                DbHelper.MakeInParam("@MSN",(DbType)SqlDbType.VarChar,200,user.MSN),
                DbHelper.MakeInParam("@QQVisible",(DbType)SqlDbType.Int,4,user.QQVisible),
                DbHelper.MakeInParam("@MSNVisible",(DbType)SqlDbType.Int,4,user.MSNVisible),
                DbHelper.MakeInParam("@Description",(DbType)SqlDbType.NVarChar,80,user.Description),
                DbHelper.MakeInParam("@Schools",(DbType)SqlDbType.NVarChar,80,user.Schools),
                DbHelper.MakeInParam("@Companies",(DbType)SqlDbType.NVarChar,80,user.Companies),
                DbHelper.MakeInParam("@Tags",(DbType)SqlDbType.NVarChar,80,user.Tags),
                DbHelper.MakeInParam("@CustomSite",(DbType)SqlDbType.NVarChar,80,user.CustomSite),
            };
            return TypeConverter.ObjectToLong(
                                 DbHelper.ExecuteNonQuery(CommandType.StoredProcedure,
                                                        "UpdateUser", parms), -1)==1;
        }

        public IDataReader GetUserConfigByID(long id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,id)
            };
            return DbHelper.ExecuteReader(CommandType.Text, "SELECT " + DbFields.USERCONFIG + "FROM TUserConfig WHERE UID=@UID", parms);
        }
        public bool IsHaveCustomSite(string CustomSite)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@CustomSite",(DbType)SqlDbType.VarChar,20,CustomSite)            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "IsHaveCustomSite", parms), -1) > 0;
        }

        public bool CreateFollow(long uid, long fuid, string remark,string GroupIDs)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms ={
                                           DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
                                           DbHelper.MakeInParam("@FollowUID",(DbType)SqlDbType.BigInt,8,fuid),
                                           DbHelper.MakeInParam("@Remark",(DbType)SqlDbType.NVarChar,100,remark),
                                           DbHelper.MakeInParam("@GroupIDs",(DbType)SqlDbType.NVarChar,1000,GroupIDs)
                                        };
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "CreateFollow", parms), -1) > 0;
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

        public bool DelFollow(long fuid, long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms ={
                                           DbHelper.MakeInParam("@FollowUID",(DbType)SqlDbType.BigInt,8,fuid),
										    DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
                                        };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DelFollow", parms), -1) > 0;
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

        public IDataReader GetFollowByFuid(long fuid, long uid)
        {
            return GetRowByQuery("TFollow", "FollowUID=" + fuid.ToString() + " and UID=" + uid.ToString(),DbFields.FOLLOW);
        }

        public bool UpdateFollowRemark(long fuid, long uid, string remark)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms ={
                                           DbHelper.MakeInParam("@FollowUID",(DbType)SqlDbType.BigInt,8,fuid),
										   DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
										   DbHelper.MakeInParam("@Remark",(DbType)SqlDbType.NVarChar,100,remark)
                                        };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateFollowRemark", parms), -1) > 0;
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

        public bool UpdateFollowGroupID(long fuid, long uid, string groupIDs)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms ={
                                           DbHelper.MakeInParam("@FollowUID",(DbType)SqlDbType.BigInt,8,fuid),
										   DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid),
										   DbHelper.MakeInParam("@GroupIDs",(DbType)SqlDbType.NVarChar,1000,groupIDs)
                                        };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateFollowGroupID", parms), -1) > 0;
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

        public bool UpdateUserConfig(UserConfig uc)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms ={
                                           DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uc.UID),
                                           DbHelper.MakeInParam("@TipsArray",(DbType)SqlDbType.VarChar,50,uc.TipsArray),
                                           DbHelper.MakeInParam("@ThemeID",(DbType)SqlDbType.Int,4,uc.ThemeID),
                                            DbHelper.MakeInParam("@IsThemeDIY",(DbType)SqlDbType.Int,4,uc.IsThemeDIY),
                                           DbHelper.MakeInParam("@WaterMarkPosition",(DbType)SqlDbType.Int,4,uc.WaterMarkPosition),
                                           DbHelper.MakeInParam("@WaterMarkStyle",(DbType)SqlDbType.Char,10,uc.WaterMarkStyle),
                                             DbHelper.MakeInParam("@IsCommentTip",(DbType)SqlDbType.Int,4,uc.IsCommentTip),
                                               DbHelper.MakeInParam("@IsFollowTip",(DbType)SqlDbType.Int,4,uc.IsFollowTip),
                                                 DbHelper.MakeInParam("@IsMsgTip",(DbType)SqlDbType.Int,4,uc.IsMsgTip),
                                                   DbHelper.MakeInParam("@IsAtTip ",(DbType)SqlDbType.Float,8,uc.IsAtTip ),
                                                 DbHelper.MakeInParam("@IsNoticeTip",(DbType)SqlDbType.Int,4,uc.IsNoticeTip),
                                                 DbHelper.MakeInParam("@IsCommentMe",(DbType)SqlDbType.Int,4,uc.IsCommentMe),
                                                 DbHelper.MakeInParam("@IsMsgMe",(DbType)SqlDbType.Int,4,uc.IsMsgMe)
                                        };
                    result = TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateUserConfig", parms)) > 0;
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

        public DataTable GetMyFollowByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.Int,8,uid),
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeInParam("@Where",(DbType)SqlDbType.NVarChar,4000,where),
				DbHelper.MakeInParam("@OrderBy",(DbType)SqlDbType.NVarChar,4000,orderby),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMyFollowByPager", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[5].Value);
            return dt;
        }

        public DataTable GetOtherFollowByPager(long otherUid,long curUid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@OtherUID",(DbType)SqlDbType.Int,8,otherUid),
                 DbHelper.MakeInParam("@CurUID",(DbType)SqlDbType.Int,8,curUid),
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeInParam("@Where",(DbType)SqlDbType.NVarChar,4000,where),
				DbHelper.MakeInParam("@OrderBy",(DbType)SqlDbType.NVarChar,4000,orderby),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetOtherFollowByPager", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[6].Value);
            return dt;
        }

        public DataTable GetMyFanByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.Int,8,uid),
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeInParam("@Where",(DbType)SqlDbType.NVarChar,4000,where),
				DbHelper.MakeInParam("@OrderBy",(DbType)SqlDbType.NVarChar,4000,orderby),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetMyFanByPager", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[5].Value);
            return dt;
        }

        public DataTable GetOtherFanByPager(long otherUid,long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@OtherUID",(DbType)SqlDbType.Int,8,otherUid),
                DbHelper.MakeInParam("@CurUID",(DbType)SqlDbType.Int,8,curUid),
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeInParam("@Where",(DbType)SqlDbType.NVarChar,4000,where),
				DbHelper.MakeInParam("@OrderBy",(DbType)SqlDbType.NVarChar,4000,orderby),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "GetOtherFanByPager", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[6].Value);
            return dt;
        }

        public DataTable SearchUser(int pageIndex, int pageSize, ref int rowCount, string key, string school, string tag, string career, int location, int sex, DateTime? birthDayStart, DateTime? birthDayEnd)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@PageIndex",(DbType)SqlDbType.Int,4,pageIndex),
                DbHelper.MakeInParam("@PageSize",(DbType)SqlDbType.Int,4,pageSize),
                DbHelper.MakeOutParam("@rowcount",(DbType)SqlDbType.Int,4),
                DbHelper.MakeInParam("@Key",(DbType)SqlDbType.NVarChar,0,key),
                DbHelper.MakeInParam("@School",(DbType)SqlDbType.NVarChar,0,school),
                DbHelper.MakeInParam("@Tag",(DbType)SqlDbType.NVarChar,0,tag),
                DbHelper.MakeInParam("@Career",(DbType)SqlDbType.NVarChar,0,career),
                DbHelper.MakeInParam("@Sex",(DbType)SqlDbType.Int,4,sex),
                DbHelper.MakeInParam("@Location",(DbType)SqlDbType.Int,4,location),
                DbHelper.MakeInParam("@BirthDayStart",(DbType)SqlDbType.DateTime,0,birthDayStart),
                DbHelper.MakeInParam("@BirthDayEnd",(DbType)SqlDbType.DateTime,0,birthDayEnd)

            };

            DataTable dt = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "SearchUser", parms).Tables[0];
            rowCount = TypeConverter.ObjectToInt(parms[2].Value);
            return dt;
        }

        public int GetRelateBetweenUsers(long UID,long WithUID)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.Int,8,UID),
                DbHelper.MakeInParam("@WithUID",(DbType)SqlDbType.Int,8,WithUID)
            };

            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "GetRelateBetweenUsers", parms));
        }

        public bool UpdateCfgFollowCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgFollowCount", parms), -1) > 0;
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

        public bool UpdateCfgNoticeCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgNoticeCount", parms), -1) > 0;
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

        public bool UpdateCfgAtcmtCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgAtcmtCount", parms), -1) > 0;
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

        public bool UpdateCfgAtmeCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgAtmeCount", parms), -1) > 0;
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

        public bool UpdateCfgMsgCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgMsgCount", parms), -1) > 0;
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

        public bool UpdateCfgCommentCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateCfgCommentCount", parms), -1) > 0;
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

        public bool UpdateAllCfgNoticeCount()
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {

                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "UpdateAllCfgNoticeCount"), -1) > 0;
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

        public bool ClearAllTipCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearAllTipCount", parms), -1) > 0;
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

        public bool ClearCfgNoticeCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgNoticeCount", parms), -1) > 0;
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
        public bool ClearCfgCommentCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgCommentCount", parms), -1) > 0;
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

        public bool ClearCfgFollowCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgFollowCount", parms), -1) > 0;
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

        public bool ClearCfgMsgCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgMsgCount", parms), -1) > 0;
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

        public bool ClearCfgAtmeCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgAtmeCount", parms), -1) > 0;
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

        public bool ClearCfgAtcmtCount(long uid)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();
            bool result = false;
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    DbParameter[] parms =
					{
						DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,uid)
					};
                    result = TypeConverter.ObjectToLong(DbHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "ClearCfgAtcmtCount", parms), -1) > 0;
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
    }
}
