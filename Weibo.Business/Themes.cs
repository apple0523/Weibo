using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Themes
    {
        public static int CreateThemeDIY(ThemeDIY diy)
        {
            try
            {
                if (diy != null)
                {
                    return Data.Themes.CreateThemeDIY(diy);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool UpdateThemeDIY(ThemeDIY diy)
        {
            try
            {
                if (diy != null)
                {
                    return Data.Themes.UpdateThemeDIY(diy);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static Theme GetThemeByID(int id)
        {
            try
            {
                if (id>0)
                {
                    return Data.Themes.GetThemeByID(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static ThemeDIY GetThemeDIYByUID(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Themes.GetThemeDIYByUID(uid);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Theme> GetThemesByType(int type)
        {
            try
            {
                if (type > 0)
                {
                    return Data.Themes.GetThemesByType(type);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Theme> GetRecommendThemes()
        {
            try
            {

                return Data.Themes.GetRecommendThemes();

            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}
