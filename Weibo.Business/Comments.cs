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
    public class Comments
    {
        public static long CreateComment(Comment comment)
        {
            try
            {
                if (comment == null)
                    return -1;
                return Data.Comments.CreateComment(comment);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
                
            }
        }

        public static bool DelCommentByCID(long cid)
        {
            try
            {
                if (cid > 0)
                    return Data.Comments.DelCommentByCID(cid);
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
               
            }
        }

        public static IList<Comment> GetTop10CommentsByMid(long mid)
        {
            try
            {
                if (mid > 0)
                    return Data.Comments.GetTop10CommentsByMid(mid);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
                
            }
        }

        public static Comment GetCommentByID(long id)
        {
            try
            {
                if (id > 0)
                    return Data.Comments.GetCommentByID( id);
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
              
            }
        }

        public static IList<Comment> GetCommentsByMid(int pageIndex, int pageSize, long mid,long uid,int isFollow, ref int rowCount)
        {
            try
            {
                return Data.Comments.GetCommentsByMid(pageIndex, pageSize, mid,uid,isFollow,ref rowCount);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
             
            }
        }

        public static int GetCommentCountByMID(long Mid)
        {
            try
            {
                if (Mid > 0)
                    return Data.Comments.GetCommentCountByMID(Mid);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return 0;
                
            }
        }

       

        public static IList<Comment> GetAtCommentsByPager(long uid,string key,int isFollow, int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if ( uid>0&& pageIndex != -1 && pageSize > 0)
                {
                    return Data.Comments.GetAtCommentsByPager(uid,key,isFollow, pageIndex, pageSize, ref recordCount);
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

        public static IList<Comment> GetSendCommentsByPager(long uid,string key,int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if (uid >0&& pageIndex != -1 && pageSize > 0)
                {
                    return Data.Comments.GetSendCommentsByPager(uid,key, pageIndex, pageSize, ref recordCount);
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

        public static IList<Comment> GetRecCommentsByPager(long uid,int isFollow,string key, int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if (uid > 0 && pageIndex != -1 && pageSize > 0)
                {
                    return Data.Comments.GetRecCommentsByPager(uid,isFollow,key, pageIndex, pageSize, ref recordCount);
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





        public static long CreateNoReplyComment(User user, long Mid,long MUid, string Content)
        {
            try
            {
                Comment comment = new Comment();
                comment.MID = Mid;
                comment.MUID = MUid;
                comment.Content = Content;
                comment.ReferUID = GetAtStr(Content);
                Users.AtCmtTip(comment.ReferUID, user.ID, -1);
                if (user.ID != MUid)
                {
                    UserConfig uc = Users.GetUserConfigByID(MUid);
                    if (uc.IsCommentTip == 1)
                    {
                        Users.UpdateCfgCommentCount(MUid);
                    }
                    else if (uc.IsCommentTip == 2)
                    {
                        int relation = Users.GetRelateBetweenUsers(MUid, user.ID);
                        if (relation == 1 || relation == 2)
                        {
                            Users.UpdateCfgCommentCount(MUid);
                        }
                    }
                }
                comment.ReplyContent = "";
                comment.ReplyUID = -1;
                comment.UID = user.ID;
                comment.ID=  CreateComment(comment);
                return comment.ID;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }
        public static long CreateReplyComment(User user, long Mid, long MUid, string Content,long replyCid,long replyUid)
        {
            try
            {
                Comment replyComment = GetCommentByID(replyCid);
                if (replyComment == null)
                    return -1;
                Comment comment = new Comment();
                comment.MID = Mid;
                comment.MUID = MUid;
                comment.Content = Content;
                comment.ReferUID = GetAtStr(Content);
                Users.AtCmtTip(comment.ReferUID, user.ID, replyUid);
                if (user.ID != replyUid)
                {
                    UserConfig uc = Users.GetUserConfigByID(replyUid);
                    if (uc.IsCommentTip == 1)
                    {
                        Users.UpdateCfgCommentCount(replyUid);
                    }
                    else if (uc.IsCommentTip == 2)
                    {
                        int relation = Users.GetRelateBetweenUsers(replyUid, user.ID);
                        if (relation == 1 || relation == 2)
                        {
                            Users.UpdateCfgCommentCount(replyUid);
                        }
                    }
                }
                comment.ReplyContent = replyComment.Content;
                comment.ReplyUID = replyUid;
                comment.UID = user.ID;
                comment.ID = CreateComment(comment);
                return comment.ID;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static string TransformContent(string content)
        {
            return TransformContent(content, false, false, false, false);
        }

        public static string TransformContent(string content,bool NotUrlNotAtNotTopic)
        {
            return TransformContent(content, false, NotUrlNotAtNotTopic, NotUrlNotAtNotTopic, NotUrlNotAtNotTopic);
        }

        public static string TransformContent(string content,bool NotExe,bool NotUrl,bool NotAt,bool NotTopic)
        {
            content = Utils.HtmlEecode2(content);
            Regex reg = null;
            if (!NotExe)
            {
                reg = new Regex(@"\[\w+\]");
                content = reg.Replace(content, ExpressionToHtml);
            }
            if (!NotUrl)
            {
                reg = new Regex(@"(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*");
                content = reg.Replace(content, UrlToHtml);
            }
            if (!NotAt)
            {
                reg = new Regex(@"@\w+(\s|$|：|:)");
                content = reg.Replace(content, AtToHtml);
            }

            if (!NotTopic)
            {
                reg = new Regex(@"#[^#\s]+#");
                content = reg.Replace(content, TopicToHtml);
            }
            return content;

        }

        private static string ExpressionToHtml(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("[", "").Replace("]", "");
            Expression e = Expressions.GetExpressionByName(v);
            if (e != null)
                return string.Format("<img alt='{0}' src='{1}' title='{0}'>", v, string.IsNullOrEmpty(e.OriUrl) ? e.Url : e.OriUrl);
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

        private static string GetAtStr(string content)
        {
            string str = "";
            try
            {

                Regex reg = new Regex(@"@(\w+)(\s|$|：|:)");
                MatchCollection matches = reg.Matches(content);
                foreach (Match match in matches)
                {
                    User user = Users.GetUserByNickName(match.Groups[1].Value);
                    if (user != null)
                    {
                        if (!str.Contains("a" + user.ID.ToString() + "a,"))
                        str += "a" + user.ID.ToString() + "a,";
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return str;
            }
        }

    }
}
