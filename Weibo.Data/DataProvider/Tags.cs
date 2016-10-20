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
    public class Tags
    {
        public static long CreateTag(Tag tag)
        {
            return DatabaseProvider.GetInstance().CreateTag(tag);
        }
        public static bool DelTag(long id)
        {
            return DatabaseProvider.GetInstance().DelTag(id);
        }

        public static bool UpdateTagForRefCount(long id)
        {
            return DatabaseProvider.GetInstance().UpdateTagForRefCount(id);
        }

        public static IList<Tag> GetTop10TagsByQuery(string where, string sortField, string sortType)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetTop10TagsByQuery(where, sortField, sortType))
            {
                if (dt != null)
                {
                    IList<Tag> list = DbTranslate.Translate<Tag>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Tag GetTagByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetTagByID(id))
            {
                if (dr != null)
                {
                    IList<Tag> list = DbTranslate.Translate<Tag>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static Tag GetTagByName(string Name)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetTagByName(Name))
            {
                if (dr != null)
                {
                    IList<Tag> list = DbTranslate.Translate<Tag>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Tag> GetInterestTag(long uid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetInterestTag(uid))
            {
                if (dt != null)
                {
                    IList<Tag> list = DbTranslate.Translate<Tag>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<UserTag> GetUserTagsByUID(long uid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetUserTagsByUID(uid))
            {
                if (dt != null)
                {
                    IList<UserTag> list = DbTranslate.Translate<UserTag>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static long CreateUserTag(UserTag userTag)
        {
            return DatabaseProvider.GetInstance().CreateUserTag(userTag);
        }
        public static bool DelUserTag(long id)
        {
            return DatabaseProvider.GetInstance().DelUserTag(id);
        }

        public static UserTag GetUserTagByUidTagid(long tagId, long uid)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUserTagByUidTagid(tagId, uid))
            {
                if (dr != null)
                {
                    IList<UserTag> list = DbTranslate.Translate<UserTag>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static int GetUserTagCount(long id)
        {
            return DatabaseProvider.GetInstance().GetUserTagCount(id);
        }

        public static UserTag GetUserTagByNameUID(string Name,long uid)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUserTagByNameUID(Name,uid))
            {
                if (dr != null)
                {
                    IList<UserTag> list = DbTranslate.Translate<UserTag>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }
    }
}
