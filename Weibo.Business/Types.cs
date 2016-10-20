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
    public class Types
    {
        public static IList<Entity.Type> GetTypesByPID(int pid)
        {
            try
            {
                if (pid != -1)
                {
                    return Data.Types.GetTypesByPID(pid);
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

        public static Entity.Type GetTypeByID(int id)
        {
            try
            {
                if (id != -1)
                {
                    return Data.Types.GetTypeByID(id);
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

        public static string GetCityTypesFullName(int id)
        {
            try
            {
                Entity.Type type = GetTypeByID(id);
                if (type != null)
                {
                    if (type.PID == TypeConfigs.GetCityRoot)
                    {
                        return type.Name;
                    }
                    else
                    {
                        Entity.Type type1 = GetTypeByID(type.PID);
                        if (type1 != null)
                        {
                            return string.Format("{0},{1}", type1.Name, type.Name);
                        }
                        else
                        {
                            return type.Name;
                        }
                    }
                }
                else
                {
                    throw new Exception("不存在类别");
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return "其他";
            }
        }
    }
}
