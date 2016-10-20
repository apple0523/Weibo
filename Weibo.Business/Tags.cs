using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Tags
    {
        public static long CreateTag(Tag tag)
        {
            try
            {
                if (tag == null)
                    return -1;
                return Data.Tags.CreateTag(tag);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool UpdateTagForRefCount(long id)
        {
            try
            {
                if (id <= 0)
                    return false;
                return Data.Tags.UpdateTagForRefCount(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static IList<Tag> GetTop10TagsByQuery(string where, string sortField, string sortType)
        {
            try
            {
                string query = "1=1";
                if (!string.IsNullOrEmpty(where))
                {
                    query = where;
                }
                string field = "CreateTime";
                if (!string.IsNullOrEmpty(sortField))
                {
                    field = sortField;
                }
                string type = "desc";
                if (!string.IsNullOrEmpty(sortType))
                {
                    type = sortType;
                }
                return Data.Tags.GetTop10TagsByQuery(query, field, type);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static Tag GetTagByID(long id)
        {
            try
            {
                if (id <= 0)
                    return null;
                return Data.Tags.GetTagByID(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Tag GetTagByName(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                    return null;
                return Data.Tags.GetTagByName(Name);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Tag> GetInterestTag(long uid)
        {
            try
            {
                if (uid <= 0)
                    return null;
                return Data.Tags.GetInterestTag(uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<UserTag> GetUserTagsByUID(long uid)
        {
            try
            {
                if (uid <= 0)
                    return null;
                return Data.Tags.GetUserTagsByUID(uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static long CreateUserTag(UserTag userTag)
        {
            try
            {
                if (userTag == null)
                    return -1;
                return Data.Tags.CreateUserTag(userTag);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool DelUserTag(long id)
        {
            try
            {
                if (id <= 0)
                    return false;
                return Data.Tags.DelUserTag(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static UserTag GetUserTagByUidTagid(long uid, long tagid)
        {
            try
            {
                if (uid <= 0 && tagid <= 0)
                    return null;
                return Data.Tags.GetUserTagByUidTagid(tagid, uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static int GetUserTagCount(long uid)
        {
            try
            {
                if (uid <= 0)
                    return 0;
                return Data.Tags.GetUserTagCount(uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return 0;
            }
        }

        public static UserTag GetUserTagByNameUID(string Name,long uid)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)||uid<=0)
                    return null;
                return Data.Tags.GetUserTagByNameUID(Name,uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

    }
}
