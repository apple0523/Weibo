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
    public class Votes
    {
        public static long CreateVote(Vote vote)
        {
            try
            {
                if (vote != null)
                {
                   return Data.Votes.CreateVote(vote);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool UpdateVoteForJoinCount(long id)
        {
            try
            {
                if (id >0)
                {
                    return Data.Votes.UpdateVoteForJoinCount(id);
                }
                return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static Vote GetVoteByID(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Votes.GetVoteByID(id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Vote> GetVoteByUID(long uid)
        {
            try
            {
                if (uid > 0)
                {
                    return Data.Votes.GetVoteByUID(uid);
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static bool IsVoteUrl(string url)
        {
            Regex reg = new Regex((BaseConfigs.GetWebDomain+@"/Vote/\d+").Replace(":",@"\:").Replace(".",@"\."),RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        public static long GetVoteIdFromUrl(string url)
        {
            Regex reg = new Regex((BaseConfigs.GetWebDomain + @"/Vote/(\d+)").Replace(":", @"\:").Replace(".", @"\."), RegexOptions.IgnoreCase);
            Match match=  reg.Match(url);
            return Convert.ToInt64(match.Groups[1].Value);
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
            Expression e= Expressions.GetExpressionByName(v);
            if (e != null)
                return string.Format("<img alt='{0}' src='{1}' title='{0}'>", v,string.IsNullOrEmpty(e.OriUrl)?e.Url:e.Url);
            else
            {
                return m.Value;
            }
        }

        private static string TopicToHtml(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("#", "");
            return string.Format("<a href='/k/{1}' target='_blank' >#{0}#</a>", v, Utils.UrlEncode(v));
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
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a>:", v, Utils.UrlEncode(v));
            }
            else if (m.Value[m.Value.Length - 1] == '：')
            {
                string v = m.Value.Trim().Replace("@", "").Replace("：", "");
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a>：", v, Utils.UrlEncode(v));
            }
            else
            {
                string v = m.Value.Trim().Replace("@", "");
                return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a> ", v, Utils.UrlEncode(v));
            }
        }
    }
}
