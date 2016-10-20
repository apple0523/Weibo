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
    public class Notices
    {
        public static long CreateNotice(Notice notice)
        {
            try
            {
                if (notice != null)
                {
                    if (notice.Type == TypeConfigs.GetNoticeSys)
                    {
                        Users.UpdateAllCfgNoticeCount();
                    }
                    else
                    {
                        UserConfig uc = Users.GetUserConfigByID(notice.ToUID);
                        if (uc.IsNoticeTip == 1)
                        Users.UpdateCfgNoticeCount(notice.ToUID);
                    }

                    return Data.Notices.CreateNotice(notice);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool DelNotice(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Notices.DelNotice(id);
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

        public static IList<Notice> GetNoticesByUID(long uid, int pageIndex, int pageSize, ref int rowCount)
        {
            try
            {
                if (uid > 0)
                {
                    string where = string.Format("ToUID={0} or Type={1}", uid.ToString(),TypeConfigs.GetNoticeSys.ToString());
                    return Data.Notices.GetNoticesByPager(where, pageIndex, pageSize, ref rowCount);
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

        public static Notice GetNoticeByID(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Notices.GetNoticeByID(id);
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

        public static string TransformContent(string content)
        {
            content = Utils.HtmlEecode2(content);

            Regex reg = new Regex(@"\[\w+\]");
            content = reg.Replace(content, ExpressionToHtml);

            reg = new Regex(@"(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*");
            content = reg.Replace(content, UrlToHtml);

            reg = new Regex(@"@\w+(\s|$|：|:)");
            content = reg.Replace(content, AtToHtml);

            reg = new Regex(@"#[^#\s]+#");
            content = reg.Replace(content, TopicToHtml);

            return content;

        }

        private static string ExpressionToHtml(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("[", "").Replace("]", "");
            Expression e = Expressions.GetExpressionByName(v);
            if (e != null)
                return string.Format("<img alt='{0}' src='{1}' title='{0}'>", v, string.IsNullOrEmpty(e.OriUrl) ? e.Url : e.Url);
            else
            {
                return m.Value;
            }
        }

        private static string TopicToHtml(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("#", "");
            return string.Format("<a href='/k/{1}' target='_blank' >#{0}#</a>", v, Utils.HtmlEncode(v));
        }

        private static string UrlToHtml(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value;
            return string.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", v);
        }

        private static string AtToHtml(System.Text.RegularExpressions.Match m)
        {
            if (m.Value[m.Value.Length - 1] == ':')
            {
                string v = m.Value.Trim().Replace("@", "").Replace(":", "");
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a>:", v, Utils.HtmlEncode(v));
            }
            else if (m.Value[m.Value.Length - 1] == '：')
            {
                string v = m.Value.Trim().Replace("@", "").Replace("：", "");
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a>：", v, Utils.HtmlEncode(v));
            }
            else
            {
                string v = m.Value.Trim().Replace("@", "");
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a> ", v, Utils.HtmlEncode(v));
            }
        }

    }


}
