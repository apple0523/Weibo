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
   public class Eduications
    {

       public static long CreateEducation(Education education)
        {
            return DatabaseProvider.GetInstance().CreateEducation(education);
        }
       public static bool DelEducation(long id)
       {
           return DatabaseProvider.GetInstance().DelEducation(id);
       }

       public static bool UpdateEducation(Education education)
       {
           return DatabaseProvider.GetInstance().UpdateEducation(education);
       }

       public static IList<Education> GetEducationsByUID(long uid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetEducationsByUID(uid))
            {
                if (dt != null)
                {
                    IList<Education> list = DbTranslate.Translate<Education>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

       public static IList<Education> GetEducationsByIsVisible(long uid,int isVisible)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetEducationsByIsVisible(uid,isVisible))
           {
               if (dt != null)
               {
                   IList<Education> list = DbTranslate.Translate<Education>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

        public static Education GetEducationByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetEducationByID(id))
            {
                if (dr != null)
                {
                    IList<Education> list = DbTranslate.Translate<Education>(dr);
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
