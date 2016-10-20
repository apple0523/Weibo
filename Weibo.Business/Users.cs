using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Common;
using Weibo.Config;
using System.Web;

namespace Weibo.Business
{
    public class Users
    {
        public static User GetUserByEmail(string Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    return Data.Users.GetUserByEmail(Email);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static User GetUserByID(long id)
        {
            try
            {
                if (id>0)
                {
                    return Data.Users.GetUserByID(id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static User GetUserByNickName(string nickName)
        {
            try
            {
                if (!string.IsNullOrEmpty(nickName))
                {
                    return Data.Users.GetUserByNickName(nickName);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static User GetUerByCustomSite(string CustomSite)
        {
            try
            {
                if (!string.IsNullOrEmpty(CustomSite))
                {
                    return Data.Users.GetUerByCustomSite(CustomSite);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }public static IList<User> GetTop10UsersByQuery(string where, string sortField, string sortType)
        {
            try
            {
                string query = "1=1";
                if (!string.IsNullOrEmpty(where))
                {
                    query = where;
                }
                string field = "RegTime";
                if (!string.IsNullOrEmpty(sortField))
                {
                    field = sortField;
                }
                string type = "desc";
                if (!string.IsNullOrEmpty(sortType))
                {
                    type = sortType;
                }
                return Data.Users.GetTop10UsersByQuery(query, field, type);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static bool UpadateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    return Data.Users.UpdateUser(user);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }
        public static bool UpdateUserConfig(UserConfig uc)
        {
            try
            {
                if (uc != null)
                {
                    return Data.Users.UpdateUserConfig(uc);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static User Login(string email, string pwd)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pwd))
                {
                    User user = GetUserByEmail(email);
                    if (user != null)
                    {
                        if (user.Password == (BaseConfigs.GetPwdEncodeType == "AES" ? AES.Encode(pwd, BaseConfigs.GetPwdEncodeKey) : DES.Encode(pwd, BaseConfigs.GetPwdEncodeKey)))
                            return user;
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static long CreateUser(string email,string pwd)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pwd))
                {
                    User user = new User();
                    user.Email = email;
                    user.IP = Utils.GetRealIP();
                    user.NickName = "";
                    user.Password = BaseConfigs.GetPwdEncodeType == "AES" ? AES.Encode(pwd, BaseConfigs.GetPwdEncodeKey) : DES.Encode(pwd, BaseConfigs.GetPwdEncodeKey);
                    user.Sex = -1;
                    user.Location = -1;
                    user.LastMID = -1;
                    long result=Data.Users.CreateUser(user);

                    SendRegEmail(email);

                    if(result>0)
                        return result;
                    else
                        return -1;
                }
                return -1;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static void SendRegEmail(string email)
        {
            try
            {
                string authStr = BaseConfigs.GetPwdEncodeType == "AES" ? AES.Encode(email, BaseConfigs.GetPwdEncodeKey) : DES.Encode(email, BaseConfigs.GetPwdEncodeKey);
                Emails.RegSmtpMail(email, "542752480@qq.com", HttpContext.Current.Server.UrlEncode(authStr));
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                throw ex;
            }
        }

        public static UserConfig GetUserConfigByID(long id)
        {
            try
            {
                if (id>0)
                {
                    return Data.Users.GetUserConfigByID(id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static bool IsHaveCustomSite(string CustomSite)
        {
            try
            {
                if (!string.IsNullOrEmpty(CustomSite))
                {
                    return Data.Users.IsHaveCustomSite(CustomSite);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static IList<Fans> GetMyFanByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            try
            {
                if (pageIndex > 0&&uid>0)
                {
                    return Data.Users.GetMyFanByPager(uid,pageIndex, pageSize, where, orderby, ref rowCount);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Fans> GetOtherFanByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            try
            {
                if (pageIndex > 0 && otherUid > 0&&curUid>0)
                {
                    return Data.Users.GetOtherFanByPager(otherUid,curUid, pageIndex, pageSize, where, orderby, ref rowCount);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Follow> GetMyFollowByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            try
            {
                if (pageIndex > 0 &&uid>0)
                {
                    return Data.Users.GetMyFollowByPager(uid,pageIndex, pageSize, where, orderby, ref rowCount);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Follow> GetOtherFollowByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            try
            {
                if (pageIndex > 0 && curUid > 0&&otherUid>0)
                {
                    return Data.Users.GetOtherFollowByPager(otherUid, curUid, pageIndex, pageSize, where, orderby, ref rowCount);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static bool CreateFollow(long uid, long fuid, string remark,string groupID)
        {
            try
            {
                if (uid > 0 && fuid > 0)
                {
                    UserConfig uc = GetUserConfigByID(fuid);
                    if(uc.IsFollowTip==1)
                    Users.UpdateCfgFollowCount(fuid);
                    return Data.Users.CreateFollow(uid, fuid, remark, groupID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool DelFollow(long fuid, long uid)
        {
            try
            {
                if (fuid > 0 && uid > 0)
                {
                    return Data.Users.DelFollow(fuid, uid);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateFollowRemark(long fuid, long uid, string remark)
        {
            try
            {
                if (fuid > 0 && uid > 0)
                {
                    return Data.Users.UpdateFollowRemark(fuid, uid, remark);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateFollowGroupID(long fuid, long uid, string groupID)
        {
            try
            {
                if (fuid > 0 && uid > 0)
                {
                    return Data.Users.UpdateFollowGroupID(fuid, uid, groupID);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static Follow GetFollowByFuid(long fuid, long uid)
        {
            try
            {
                if (fuid > 0 && uid > 0)
                {
                    return Data.Users.GetFollowByFuid(fuid, uid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }


        public static bool UpdateUserCompanies(long uid)
        {
            try
            {
                IList<Career> careers = Careers.GetCareersByUID(uid);
                string str = "";
                if (careers != null)
                {
                   
                    foreach (Career career in careers)
                    {
                            str +=career.CompanyName + ",";
                    }
                   
                }
                User user = Users.GetUserByID(uid);
                if (user != null)
                {
                    user.Companies = str;
                    if (Users.UpadateUser(user))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }

        }

        public static bool UpdateUserSchools(long uid)
        {
            try
            {
                IList<Education> educations = Educations.GetEducationsByUID(uid);
                string str = "";
                if (educations != null)
                {
                    
                    foreach (Education education in educations)
                    {
                      
                            str += education.SchoolName + ",";
                    }
                   
                }
                User user = Users.GetUserByID(uid);
                if (user != null)
                {
                    user.Schools = str;
                    if (Users.UpadateUser(user))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }

        }

        public static bool UpdateUserTags(long uid)
        {
            try
            {
                IList<UserTag> userTags = Tags.GetUserTagsByUID(uid);
                string str = "";
                if (userTags != null)
                {
                   
                    foreach (UserTag userTag in userTags)
                    {

                        str += userTag.TagName + ",";
                    }
                  
                }
                User user = Users.GetUserByID(uid);
                if (user != null)
                {
                    user.Tags = str;
                    if (Users.UpadateUser(user))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }

        }

        public static IList<User> SearchUser(int pageIndex, int pageSize, ref int rowCount, string key, string school, string tag, string career, int location, int sex, DateTime? birthDayStart, DateTime? birthDayEnd)
        {
            try
            {
                return Data.Users.SearchUser( pageIndex,  pageSize, ref  rowCount,  key,  school,  tag,  career,  location,  sex,  birthDayStart, birthDayEnd);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static int GetRelateBetweenUsers(long UID, long WithUID)
        {
            try
            {
                if (UID <= 0 || WithUID <= 0)
                    return -1;
                else
                    return Data.Users.GetRelateBetweenUsers(UID, WithUID);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool UpdateCfgFollowCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgFollowCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateCfgCommentCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgCommentCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateCfgMsgCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgMsgCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateCfgAtmeCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgAtmeCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateCfgAtcmtCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgAtcmtCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateCfgNoticeCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.UpdateCfgNoticeCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateAllCfgNoticeCount()
        {
            try
            {

                    return Data.Users.UpdateAllCfgNoticeCount();


            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool ClearAllTipCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearAllTipCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static void AtMeTip(string atstr, long curUID,int isOri)
        {
            if (!string.IsNullOrEmpty(atstr))
            {
                string[] AtArray = atstr.Split(',');
                for (int i = 0; i < AtArray.Length - 1; i++)
                {
                    long uid = Convert.ToInt64(AtArray[i].Replace("a", ""));
                    if (curUID != uid)
                    {
                        UserConfig uc = Users.GetUserConfigByID(uid);
                        if (uc.IsAtTip == 1.1)
                        {
                            Users.UpdateCfgAtmeCount(uid);
                        }
                        else if (uc.IsAtTip == 1.2)
                        {
                            if (isOri == 1)
                            {
                                Users.UpdateCfgAtmeCount(uid);
                            }
                        }
                        else if (uc.IsAtTip == 2.1)
                        {
                            int relation = GetRelateBetweenUsers(uid, curUID);
                            if (relation == 1 || relation == 2)
                            {
                                Users.UpdateCfgAtmeCount(uid);
                            }
                        }
                        else if (uc.IsAtTip == 2.2)
                        {
                            int relation = GetRelateBetweenUsers(uid, curUID);
                            if ((relation == 1 || relation == 2)&&isOri==1)
                            {
                                Users.UpdateCfgAtmeCount(uid);
                            }
                        }
                    }
                }
            }
        }

        public static void AtCmtTip(string atstr, long curUID,long replyUID)
        {
            if (!string.IsNullOrEmpty(atstr))
            {
                string[] AtArray = atstr.Split(',');
                for (int i = 0; i < AtArray.Length - 1; i++)
                {
                    long uid = Convert.ToInt64(AtArray[i].Replace("a", ""));
                    if (curUID != uid&&replyUID!=uid)
                    {
                        UserConfig uc = Users.GetUserConfigByID(uid);
                        if(uc.IsAtTip==1.1||uc.IsAtTip==1.2)
                        Users.UpdateCfgAtcmtCount(uid);
                        else if (uc.IsAtTip == 2.1 || uc.IsAtTip == 2.2)
                        {
                              int relation = GetRelateBetweenUsers(uid, curUID);
                              if (relation == 1 || relation == 2)
                              {
                                  Users.UpdateCfgAtcmtCount(uid);
                              }
                        }
                    }
                }
            }
        }

        public static bool ClearCfgNoticeCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgNoticeCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool ClearCfgCommentCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgCommentCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool ClearCfgFollowCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgFollowCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool ClearCfgMsgCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgMsgCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool ClearCfgAtmeCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgAtmeCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }


        public static bool ClearCfgAtcmtCount(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Users.ClearCfgAtcmtCount(uid);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }
    }
}
