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
    public class Careers
    {

        public static long CreateCareer(Career Career)
        {
            return DatabaseProvider.GetInstance().CreateCareer(Career);
        }
        public static bool DelCareer(long id)
        {
            return DatabaseProvider.GetInstance().DelCareer(id);
        }

        public static bool UpdateCareer(Career Career)
        {
            return DatabaseProvider.GetInstance().UpdateCareer(Career);
        }

        public static IList<Career> GetCareersByUID(long uid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetCareersByUID(uid))
            {
                if (dt != null)
                {
                    IList<Career> list = DbTranslate.Translate<Career>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<Career> GetCareersByIsVisible(long uid, int isVisible)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetCareersByIsVisible(uid, isVisible))
            {
                if (dt != null)
                {
                    IList<Career> list = DbTranslate.Translate<Career>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Career GetCareerByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetCareerByID(id))
            {
                if (dr != null)
                {
                    IList<Career> list = DbTranslate.Translate<Career>(dr);
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

