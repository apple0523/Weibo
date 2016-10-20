using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;
using System.Data;

namespace Weibo.Data
{
    public class Themes
    {
        public static Theme GetThemeByID(int id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetThemeByID(id))
            {
                if (dr != null)
                {
                    IList<Theme> list = DbTranslate.Translate<Theme>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Theme> GetThemesByType(int type)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetThemesByType(type))
            {
                if (dt != null)
                {
                    IList<Theme> list = DbTranslate.Translate<Theme>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }


        public static IList<Theme> GetRecommendThemes()
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetRecommendThemes())
            {
                if (dt != null)
                {
                    IList<Theme> list = DbTranslate.Translate<Theme>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static int CreateThemeDIY(ThemeDIY diy)
        {
            return DatabaseProvider.GetInstance().CreateThemeDIY(diy);
        }

        public static bool UpdateThemeDIY(ThemeDIY diy)
        {
            return DatabaseProvider.GetInstance().UpdateThemeDIY(diy);
        }

        public static ThemeDIY GetThemeDIYByUID(long uid)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetThemeDIYByUID(uid))
            {
                if (dr != null)
                {
                    IList<ThemeDIY> list = DbTranslate.Translate<ThemeDIY>(dr);
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
