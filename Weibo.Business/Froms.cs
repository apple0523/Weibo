using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Entity;

namespace Weibo.Business
{
    public class Froms
    {
        public static From GetFromByID(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Froms.GetFromByID(id);
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

        public static From GetFromByUrl(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    return Data.Froms.GetFromByUrl(url);
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

        public static bool UpdateFromForFromCount(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Froms.UpdateFromForFromCount(id);
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
    }
}
