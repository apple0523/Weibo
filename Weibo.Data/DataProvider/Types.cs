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
    public class Types
    {
        public static IList<Entity.Type> GetTypesByPID(int pid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetTypesByPID(pid))
            {
                if (dt != null)
                {
                    IList<Entity.Type> list = DbTranslate.Translate<Entity.Type>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
                return null;

            }
        }

        public static Entity.Type GetTypeByID(int id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetTypeByID(id))
            {
                if (dr != null)
                {
                    IList<Entity.Type> list = DbTranslate.Translate<Entity.Type>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
                return null;

            }
        }
    }
}
