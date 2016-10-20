using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Groups
    {
        public static long CreateGroup(Group group)
        {
            try
            {
                if (group == null)
                    return -1;
                return Data.Groups.CreateGroup(group);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool DelGroup(long Gid)
        {
            try
            {
                if (Gid > 0)
                    return Data.Groups.DelGroup(Gid);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateGroupName(long Gid, string Name)
        {
            try
            {
                if (Gid > 0&&!string.IsNullOrEmpty(Name))
                    return Data.Groups.UpdateGroupName(Gid,Name);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateGroupSort(string SortList,long uid)
        {
            try
            {
                if (!string.IsNullOrEmpty(SortList)&&uid>0)
                    return Data.Groups.UpdateGroupSort(SortList,uid);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static IList<Group> GetGroupsByUID(long UID)
        {
            try
            {
                if (UID > 0)
                    return Data.Groups.GetGroupsByUID(UID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Group GetGroupByID(long GID)
        {
            try
            {
                if (GID > 0)
                    return Data.Groups.GetGroupByID(GID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Group GetGroupByName(long UID, string Name)
        {
            try
            {
                if (UID > 0&&!string.IsNullOrEmpty(Name))
                    return Data.Groups.GetGroupByName(UID, Name);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Group GetTopSort(long UID)
        {
            try
            {
                if (UID > 0)
                    return Data.Groups.GetTopSort(UID);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static string GetGroupsString(string groupIDs, IList<Group> groups,int limitByte)
        {
            if (string.IsNullOrEmpty(groupIDs))
            {
                return "未分组";
            }
            else
            {
                string result = "";
                string[] groupArr = groupIDs.Split(',');
                for (int i = 0; i < groupArr.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Count; j++)
                    {
                        if ("a"+groups[j].ID.ToString()+"a" == groupArr[i])
                        {
                            result += groups[j].Name+",";
                        }
                    }
                }
                result = result.Remove(result.Length-1);
                string tmp = Utils.GetStringByte(result, limitByte);
                if (result.Length > tmp.Length)
                {
                    return tmp + "...";
                }
                else
                    return result;
            }
        }
    }
}
