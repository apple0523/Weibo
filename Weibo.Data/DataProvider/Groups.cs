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
    public class Groups
    {
        public static long CreateGroup(Group group)
        {
            return DatabaseProvider.GetInstance().CreateGroup(group);
        }

        public static bool UpdateGroupName(long Gid, string Name)
        {
            return DatabaseProvider.GetInstance().UpdateGroupName(Gid,Name);
        }

        public static bool UpdateGroupSort(string SortList,long uid)
        {
            return DatabaseProvider.GetInstance().UpdateGroupSort(SortList,uid);
        }

        public static bool DelGroup(long Gid)
        {
            return DatabaseProvider.GetInstance().DelGroup(Gid);
        }


        public static IList<Group> GetGroupsByUID(long UID)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetGroupsByUID(UID))
            {
                if (dt != null)
                {
                    IList<Group> list = DbTranslate.Translate<Group>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Group GetGroupByID(long GID)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetGroupByID(GID))
            {
                if (dr != null)
                {
                    IList<Group> list = DbTranslate.Translate<Group>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static Group GetGroupByName(long UID, string Name)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetGroupByName(UID,Name))
            {
                if (dr != null)
                {
                    IList<Group> list = DbTranslate.Translate<Group>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static Group GetTopSort(long UID)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetTopSort(UID))
            {
                if (dr != null)
                {
                    IList<Group> list = DbTranslate.Translate<Group>(dr);
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
