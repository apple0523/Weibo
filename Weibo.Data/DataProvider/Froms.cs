using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;
using System.Data;
using System.Xml;

namespace Weibo.Data
{
   public class Froms
    {
       public static From GetFromByUrl(string url)
       {
           using (IDataReader dr = DatabaseProvider.GetInstance().GetFromByUrl(url))
           {
               if (dr != null)
               {
                   IList<From> list = DbTranslate.Translate<From>(dr);
                   dr.Close();
                   if (list != null && list.Count > 0)
                   {
                       return list[0];
                   }
               }
           }
           return null;
       }

       public static From GetFromByID(int id)
       {
           using (IDataReader dr = DatabaseProvider.GetInstance().GetFromByID(id))
           {
               if (dr != null)
               {
                   IList<From> list = DbTranslate.Translate<From>(dr);
                   dr.Close();
                   if (list != null && list.Count > 0)
                   {
                       return list[0];
                   }
               }
           }
           return null;
       }

       public static bool UpdateFromForFromCount(int id)
       {
           return DatabaseProvider.GetInstance().UpdateFromForFromCount(id);
       }
    }
}
