using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;

namespace Weibo.Data
{
    public class Users
    {
        public static User GetUserByEmail(string email)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUerByEmail(email))
            {
                if (dr != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
          return null;
        }
        public static IList<User> GetTop10UsersByQuery(string where, string sortField, string sortType)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetTop10UsersByQuery(where, sortField, sortType))
            {
                if (dt != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }
        public static long CreateUser(User user)
        {
           return DatabaseProvider.GetInstance().CreateUser(user);
        }

        public static bool UpdateUser(User user)
        {
            return DatabaseProvider.GetInstance().UpdateUser(user);
        }

        public static bool UpdateUserConfig(UserConfig uc)
        {
            return DatabaseProvider.GetInstance().UpdateUserConfig(uc);
        }

        public static User GetUserByNickName(string nickName)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUserByNickName(nickName))
            {
                if (dr != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }


        public static User GetUerByCustomSite(string CustomSite)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUerByCustomSite(CustomSite))
            {
                if (dr != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }
        public static User GetUserByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUserByID(id))
            {
                if (dr != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }
        public static bool IsHaveCustomSite(string CustomSite)
        {
            return DatabaseProvider.GetInstance().IsHaveCustomSite(CustomSite);
        }
        public static UserConfig GetUserConfigByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUserConfigByID(id))
            {
                if (dr != null)
                {
                    IList<UserConfig> list = DbTranslate.Translate<UserConfig>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Fans> GetMyFanByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            using (DataTable dr = DatabaseProvider.GetInstance().GetMyFanByPager(uid,pageIndex, pageSize, where, orderby, ref rowCount))
            {
                if (dr != null)
                {
                    IList<Fans> list = DbTranslate.Translate<Fans>(dr);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<Fans> GetOtherFanByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            using (DataTable dr = DatabaseProvider.GetInstance().GetOtherFanByPager(otherUid,curUid, pageIndex, pageSize, where, orderby, ref rowCount))
            {
                if (dr != null)
                {
                    IList<Fans> list = DbTranslate.Translate<Fans>(dr);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<Follow> GetMyFollowByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            using (DataTable dr = DatabaseProvider.GetInstance().GetMyFollowByPager(uid,pageIndex, pageSize, where, orderby, ref rowCount))
            {
                if (dr != null)
                {
                    IList<Follow> list = DbTranslate.Translate<Follow>(dr);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<Follow> GetOtherFollowByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount)
        {
            using (DataTable dr = DatabaseProvider.GetInstance().GetOtherFollowByPager(otherUid,curUid, pageIndex, pageSize, where, orderby, ref rowCount))
            {
                if (dr != null)
                {
                    IList<Follow> list = DbTranslate.Translate<Follow>(dr);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Follow GetFollowByFuid(long fuid, long uid)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetFollowByFuid(fuid,uid))
            {
                if (dr != null)
                {
                    IList<Follow> list = DbTranslate.Translate<Follow>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static bool CreateFollow(long uid, long fuid, string remark,string groupIDs)
        {
            return DatabaseProvider.GetInstance().CreateFollow(uid, fuid, remark, groupIDs);
        }

        public static bool DelFollow(long fuid, long uid)
        {
            return DatabaseProvider.GetInstance().DelFollow(fuid, uid);
        }

        public static bool UpdateFollowRemark(long fuid, long uid, string remark)
        {
            return DatabaseProvider.GetInstance().UpdateFollowRemark(fuid, uid, remark);
        }

        public static bool UpdateFollowGroupID(long fuid, long uid, string groupID)
        {
            return DatabaseProvider.GetInstance().UpdateFollowGroupID(fuid, uid, groupID);
        }

        public static IList<User> SearchUser(int pageIndex, int pageSize, ref int rowCount, string key, string school, string tag, string career, int location, int sex, DateTime? birthDayStart, DateTime? birthDayEnd)
        {
            using (DataTable dr = DatabaseProvider.GetInstance().SearchUser( pageIndex,  pageSize, ref  rowCount,  key,  school,  tag,  career,  location,  sex,  birthDayStart, birthDayEnd))
            {
                if (dr != null)
                {
                    IList<User> list = DbTranslate.Translate<User>(dr);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static int GetRelateBetweenUsers(long UID, long WithUID)
        {
            return DatabaseProvider.GetInstance().GetRelateBetweenUsers(UID, WithUID);
        }

        public static bool UpdateCfgFollowCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgFollowCount(uid);
        }

        public static bool UpdateCfgNoticeCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgNoticeCount(uid);
        }

        public static bool UpdateCfgAtcmtCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgAtcmtCount(uid);
        }

        public static bool UpdateCfgAtmeCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgAtmeCount(uid);
        }

        public static bool UpdateCfgMsgCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgMsgCount(uid);
        }

        public static bool UpdateCfgCommentCount(long uid)
        {
            return DatabaseProvider.GetInstance().UpdateCfgCommentCount(uid);
        }
        public static bool ClearAllTipCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearAllTipCount(uid);
        }

        public static bool UpdateAllCfgNoticeCount()
        {
            return DatabaseProvider.GetInstance().UpdateAllCfgNoticeCount();
        }

        public static bool ClearCfgNoticeCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgNoticeCount(uid);
        }

        public static bool ClearCfgCommentCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgCommentCount(uid);
        }

        public static bool ClearCfgFollowCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgFollowCount(uid);
        }

        public static bool ClearCfgMsgCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgMsgCount(uid);
        }

        public static bool ClearCfgAtmeCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgAtmeCount(uid);
        }

        public static bool ClearCfgAtcmtCount(long uid)
        {
            return DatabaseProvider.GetInstance().ClearCfgAtcmtCount(uid);
        }
    }
}
