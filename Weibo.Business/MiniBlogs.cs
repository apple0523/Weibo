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
    public class MiniBlogs
    {
        public static string TransformToBBCode(string content)
        {
            try
            {
                Regex reg = new Regex(@"\[\w+\]");
                content = reg.Replace(content, ExpressionToBBCode);

                reg = new Regex(@"(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*");
                content = reg.Replace(content, UrlToBBCode);

                reg = new Regex(@"@\w+(\s|$|：|:)");
                content = reg.Replace(content, AtToBBCode);

                reg = new Regex(@"#[^#\s]+#");
                content = reg.Replace(content, TopicToBBCode);

                return content;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return content;
            }
        }

        private static string TopicToBBCode(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("#","");
            Topics.SaveTopic(v);
            return string.Format("[topic n='{0}']", v);
        }
        private static string UrlToBBCode(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value;
            string code = Urls.AnalysisUrl(v);
            if (!string.IsNullOrEmpty(code))
            {
                Url url = Urls.GetUrlByShortLink(code);
                string type = "normal";
                if (url.Type == TypeConfigs.GetUrlMusic) 
                type = "music";
                if (url.Type == TypeConfigs.GetUrlVideo)
                    type = "video";
                if (url.Type == TypeConfigs.GetUrlVote)
                    type = "vote";
                if (url != null)
                {
                    return string.Format("[url c='{0}' t='{1}' m='{2}' o='{3}']", code, type,url.MediaID,url.OriginalUrl);
                }
            }
            return v;
        }
        private static string AtToBBCode(System.Text.RegularExpressions.Match m)
        {
            if (m.Value[m.Value.Length - 1] == '：')
            {
                string v = m.Value.Trim().Replace("@", "").Replace("：","");
                return string.Format("[at n='{0}']：", v);
            }
            else if (m.Value[m.Value.Length - 1] == ':')
            {
                string v = m.Value.Trim().Replace("@", "").Replace(":", "");
                return string.Format("[at n='{0}']:", v);
            }

            else
            {
                string v = m.Value.Trim().Replace("@", "");
                return string.Format("[at n='{0}'] ", v);
            }
        }
        private static string ExpressionToBBCode(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace("[", "").Replace("]", "");
            if (Expressions.GetExpressionByName(v) != null)
                return string.Format("[exe n='{0}']", v);
            else
            {
                return m.Value;
            }
        }

        private static string GetAtStr(string content)
        {
            string str = "";
            try
            {

                Regex reg = new Regex(@"\[at\sn='(\w+)'\]");
                MatchCollection matches = reg.Matches(content);
                foreach (Match match in matches)
                {
                    User user = Users.GetUserByNickName(match.Groups[1].Value);
                    if (user != null)
                    {
                        if (!str.Contains("a" + user.ID.ToString() + "a,"))
                        str += "a"+user.ID.ToString() + "a,";
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

        private static string GetMediaContent(string picID, string content)
        {
            string mc = "{0},{1},{2},{3},{4},{5},{6}";
            string voteID = "-1";
            string musicID = "-1";
            string videoID = "-1";
            string picImg="";
            string videoImg="";
            string voteImg="";
            int count=0;
            if(picID!="-1")
            {
                Pic pic = Pics.GetPicByID(Convert.ToInt64(picID));
                if (pic != null)
                {
                    count++;
                    picImg = pic.ThumPicUrl;
                }
            }
            if (new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='video'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(content))
            {
                videoID = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='video'\sm='([0-9\-]+)'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(content).Result("$1");
                Video v = Videos.GetVideoByID(Convert.ToInt64(videoID));
                if (v != null)
                {
                    videoImg = v.ThumPicUrl;
                    count++;
                }
            }
            if (new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='music'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(content) && count < 2)
            {
                musicID = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='music'\sm='([0-9\-]+)'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(content).Result("$1");
                count++;
            }
            if (new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='vote'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(content) && count < 2)
            {
                voteID = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='vote'\sm='([0-9\-]+)'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(content).Result("$1");
                
                voteImg = "";
                Vote vote = Votes.GetVoteByID(Convert.ToInt64(voteID));
                if(vote!=null)
                {
                    Pic pic = Pics.GetPicByID(vote.PID);
                    if (pic != null)
                    {
                        voteImg = pic.ThumPicUrl;
                    }
                }
            }
            return string.Format(mc, picID, videoID, musicID, voteID,picImg,videoImg,voteImg);
            
        }

        public static long CreateOriginalMiniBlog(User user, string content,string picID,int fromID)
        {
            try
            {
                string originalCon=content;
                string  realCon = TransformToBBCode(content);
                string atStr = GetAtStr(realCon);
                MiniBlog miniblog = new MiniBlog();
                string idCode="";
                miniblog.ID = Data.DbGenerateID.GenerateID(ref idCode);
                miniblog.IDCode = idCode;
                Users.AtMeTip(atStr, user.ID,1);
                miniblog.ReferUID = atStr;
                miniblog.OriginalContent = originalCon;
                miniblog.RealContent = realCon;
                miniblog.PicID = Convert.ToInt64(picID);
                miniblog.UID = user.ID;
                miniblog.IsOriginal = 1;
                miniblog.IsHaveVote = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='vote'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(realCon) ? 1 : 0;
                miniblog.IsHaveVideo = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='video'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(realCon) ? 1 : 0;
                miniblog.IsHavePic =picID=="-1" ? 0 : 1;
                miniblog.IsHaveMusic = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='music'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(realCon) ? 1 : 0;
                miniblog.IsHaveLink = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='normal'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").IsMatch(realCon) ? 1 : 0;
                miniblog.FromID = fromID;
                Froms.UpdateFromForFromCount(fromID);
                miniblog.MediaContent = GetMediaContent(picID, realCon);
                miniblog.OriginalMID = -1;
                miniblog.QuoteMID = -1;
                miniblog.OriginalMContent = "";
                MiniBlogs.CreateMiniBlog(miniblog);
                return miniblog.ID;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }
        public static long CreateQuoteMiniBlog(User user, string oriMid, string quoMid, string content, string picID, int fromID)
        {
            try
            {
                MiniBlog oriMiniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(oriMid));
                if (oriMiniblog != null)
                {
                    string originalCon = content;
                    string realCon = TransformToBBCode(content);
                    string atStr = GetAtStr(realCon);
                    MiniBlog miniblog = new MiniBlog();
                    string idCode = "";
                    miniblog.ID = Data.DbGenerateID.GenerateID(ref idCode);
                    miniblog.IDCode = idCode;
                    if (!atStr.Contains("a" + oriMiniblog.UID.ToString() + "a,"))
                    {
                        atStr += "a" + oriMiniblog.UID.ToString() + "a,";
                    }
                    string[] oriAtArray = oriMiniblog.ReferUID.Split(',');
                    for (int i = 0; i < oriAtArray.Length - 1; i++)
                    {
                        if (!atStr.Contains(oriAtArray[i]))
                        {
                            atStr += oriAtArray[i] + ",";
                        }
                    }
                    Users.AtMeTip(atStr, user.ID,-1);
                    miniblog.ReferUID = atStr;
                    miniblog.OriginalContent = originalCon;
                    miniblog.RealContent = realCon;
                    miniblog.UID = user.ID;
                    miniblog.IsOriginal = 0;
                    miniblog.IsHaveVote = oriMiniblog.IsHaveVote;
                    miniblog.IsHaveVideo = oriMiniblog.IsHaveVideo;
                    miniblog.IsHavePic = oriMiniblog.IsHavePic;
                    miniblog.IsHaveMusic = oriMiniblog.IsHaveMusic;
                    miniblog.IsHaveLink = oriMiniblog.IsHaveLink;
                    miniblog.FromID = fromID;
                    Froms.UpdateFromForFromCount(fromID);
                    miniblog.MediaContent ="";
                    miniblog.OriginalMID = Convert.ToInt64(oriMid);
                    miniblog.QuoteMID = Convert.ToInt64(quoMid);
                    miniblog.OriginalMContent = oriMiniblog.OriginalContent;
                    MiniBlogs.CreateQuoteMiniBlog(miniblog);
                    return miniblog.ID;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }



        public static string BBCodeToHtml(string content)
        {
            try
            {
                content = Utils.HtmlEecode2(content);

                Regex reg = new Regex(@"\[exe\sn='\w+'\]");
                content = reg.Replace(content, ExeToHtml);

                reg = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='[a-zA-Z]+'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]");
                content = reg.Replace(content, UrlToHtml);

                reg = new Regex(@"\[at\sn='\w+'\]");
                content = reg.Replace(content, AtToHtml);

                reg = new Regex(@"\[topic\sn='[^#\s]+'\]");
                content = reg.Replace(content, TopicToHtml);

                return content;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return content;
            }
        }

        private static string ExeToHtml(System.Text.RegularExpressions.Match m)
        {
            string name = new Regex(@"\[exe\sn='(\w+)'\]").Match(m.Value).Groups[1].Value;
            Expression exe=Expressions.GetExpressionByName(name);
            if (exe != null)
            {
                string url;
                if (string.IsNullOrEmpty(exe.OriUrl))
                    url = exe.Url;
                else
                    url = exe.OriUrl;
                return string.Format("<img title=\"{1}\" src=\"{0}\"/>", url, name);
            }
            else
                return "[" + name + "]";
        }
        private static string UrlToHtml(System.Text.RegularExpressions.Match m)
        {
            string code = new Regex(@"\[url\sc='([0-9a-zA-Z]+)'\st='[a-zA-Z]+'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(m.Value).Groups[1].Value;
            string type = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='([a-zA-Z]+)'\sm='[0-9\-]+'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(m.Value).Groups[1].Value;
            string mediaID = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='[a-zA-Z]+'\sm='([0-9\-]+)'\so='[~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+'\]").Match(m.Value).Groups[1].Value;
            string oUrl = new Regex(@"\[url\sc='[0-9a-zA-Z]+'\st='[a-zA-Z]+'\sm='[0-9\-]+'\so='([~#\+\\\'\?\,\=\:/a-zA-Z0-9\.&%\$\-_]+)'\]").Match(m.Value).Groups[1].Value;
            string typeImg = "";
            if (type == "video")
            {
                typeImg="<img class=\"small_icon videoicon\" alt=\"\" src=\"/Content/Image/transparent.gif\">";
            }
            if (type == "vote")
            {
                typeImg = "<img class=\"small_icon voteicon\" alt=\"\" src=\"/Content/Image/transparent.gif\">";
            }
            if (type == "music")
            {
                typeImg = "<img class=\"small_icon musicico\" alt=\"\" src=\"/Content/Image/transparent.gif\">";
            }

            return string.Format("<a href=\"{0}\" target=\"_blank\" title=\"{3}\" type='{2}' code='{4}' mediaID='{5}'>{0}{1}</a>", BaseConfigs.GetShortLinkDomainName + code, typeImg, type, oUrl, code, mediaID);
        }
        private static string AtToHtml(System.Text.RegularExpressions.Match m)
        {
            string name = new Regex(@"\[at\sn='(\w+)'\]").Match(m.Value).Groups[1].Value;
            return string.Format("<a href='/n/{1}' target='_blank' uid='' namecard='true' uname='{0}' >@{0}</a>",name,Utils.UrlEncode(name));
        }
        private static string TopicToHtml(System.Text.RegularExpressions.Match m)
        {
            string name = new Regex(@"\[topic\sn='([^#\s]+)'\]").Match(m.Value).Groups[1].Value;
            return string.Format("<a href='/k/{1}' target='_blank' >#{0}#</a>", name, Utils.UrlEncode(name));
        }

        public static string ParseContentByShortlink(string content) 
        {
            try
            {
                Regex reg = null;
                reg = new Regex(@"(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*");
                content = reg.Replace(content, UrlToShortLink);
                return content;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return content;
            }
        }

        private static string UrlToShortLink(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value;
            if (v.Contains(BaseConfigs.GetShortLinkDomainName))
            {
                return v;
            }
            string code = UrlShort.ShortUrl(v)[0];
            return BaseConfigs.GetShortLinkDomainName + code;
        }

        public static long CreateMiniBlog(MiniBlog miniBlog)
        {
            try
            {
                if (miniBlog != null)
                {
                    return Data.MiniBlogs.CreateMiniBlog(miniBlog);
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

        public static long CreateQuoteMiniBlog(MiniBlog miniBlog)
        {
            try
            {
                if (miniBlog != null)
                {
                    return Data.MiniBlogs.CreateQuoteMiniBlog(miniBlog);
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

        public static MiniBlog GetMiniBlogByIDCode(string idCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(idCode))
                {
                    return Data.MiniBlogs.GetMiniBlogByIDCode(idCode);
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

        public static MiniBlog GetMiniBlogByID(long id)
        {
            try
            {
                if (id>0)
                {
                    return Data.MiniBlogs.GetMiniBlogByID(id);
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
        public static IList<MiniBlog> GetMiniBlogsByUID(long uid, int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if (uid>0&&pageIndex>0&&pageSize>0)
                {
                    return Data.MiniBlogs.GetMiniBlogsByUID(uid,pageIndex,pageSize,ref recordCount);
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
        public static bool DelMiniBlogByMID(long id)
        {
            try
            {
                if (id>0)
                {
                    return Data.MiniBlogs.DelMiniBlogByMID(id);
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
        public static bool DelFavorite(long mid, long uid)
        {
            try
            {
                if (mid > 0 && uid > 0)
                {
                    return Data.MiniBlogs.DelFavorite( mid,  uid);
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

        public static long AddFavorite(long mid, long uid)
        {
            try
            {
                if (mid > 0 && uid > 0)
                {
                    return Data.MiniBlogs.AddFavorite(mid, uid);
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

        public static IList<Favorite> GetFavorteByPager(long uid,string key, int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if (uid > 0 && pageIndex > 0 && pageSize > 0)
                {
                    return Data.MiniBlogs.GetFavorteByPager(pageIndex, pageSize, uid,key, ref recordCount);
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

        public static IList<MiniBlog> GetAtMeByPager(string key, int isFollow, int isOri, long uid, int pageIndex, int pageSize, ref int recordCount)
        {
            try
            {
                if (uid>0 && pageIndex > 0 && pageSize > 0)
                {
                    return Data.MiniBlogs.GetAtMeByPager(pageIndex, pageSize,key,isFollow,isOri,uid, ref recordCount);
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

        public static IList<MiniBlog> SearchMiniBlog(int pageIndex, int pageSize, ref int rowCount, string key, int isOri, int location, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
             long curUid, string someone, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            try
            {

                return Data.MiniBlogs.SearchMiniBlog(pageIndex, pageSize, ref rowCount, key, isOri, location, startTime, endTime, isMyself, isMyFollow, curUid, someone, isHavePic, isHaveLink, isHaveVideo, isHaveMusic, isHaveVote, sort,GroupID,IsFriendShip);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static IList<MiniBlog> SearchMiniBlogForMbIndexAdvanced(int pageIndex, int pageSize, ref int rowCount, string key, int isOri,int isRet, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
      long curUid, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            try
            {

                return Data.MiniBlogs.SearchMiniBlogForMbIndexAdvanced(pageIndex, pageSize, ref rowCount, key, isOri,isRet, startTime, endTime, isMyself, isMyFollow, curUid, isHavePic, isHaveLink, isHaveVideo, isHaveMusic, isHaveVote, sort, GroupID, IsFriendShip);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<MiniBlog> GetTop500MiniBlogsByQuery(string where, string sortField, string sortType)
        {
            try
            {
                string query = "1=1";
                if (!string.IsNullOrEmpty(where))
                {
                    query = where;
                }
                string field = "CreateTime";
                if (!string.IsNullOrEmpty(sortField))
                {
                    field = sortField;
                }
                string type = "desc";
                if (!string.IsNullOrEmpty(sortType))
                {
                    type = sortType;
                }
                return Data.MiniBlogs.GetTop500MiniBlogsByQuery(query, field, type);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}
