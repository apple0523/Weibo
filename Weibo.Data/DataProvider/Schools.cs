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
    public class Schools
    {
        public static long CreateSchool(School school)
        {
            return DatabaseProvider.GetInstance().CreateSchool(school);
        }


        public static IList<School> GetShoolsByLetLocType(int Location, string letter,int type)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetShoolsByLetLocType(Location, letter, type))
            {
                if (dt != null)
                {
                    IList<School> list = DbTranslate.Translate<School>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static School GetSchoolByID(int id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetSchoolByID(id))
            {
                if (dr != null)
                {
                    IList<School> list = DbTranslate.Translate<School>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<School> GetSchoolsByLikeName(string name)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetSchoolsByLikeName(name))
            {
                if (dt != null)
                {
                    IList<School> list = DbTranslate.Translate<School>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }
    }
}
