using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Xml;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Common;
using Weibo.Config;
using System.Web;
using Weibo.Plugin.Video;
using System.IO;
namespace Weibo.Business
{
    public class Urls
    {
        public static Url GetUrlByShortLink(string shortLink)
        {
            try
            {
                if (!string.IsNullOrEmpty(shortLink))
                {
                    return Data.Urls.GetUrlByShortLink(shortLink);
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

        public static long CreateUrl(Url url)
        {
            try
            {
                if (url != null)
                {
                  return  Data.Urls.CreateUrl(url);
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

        public static bool DelUrl(long id)
        {
            try
            {
                if (id > -1)
                {
                    return Data.Urls.DelUrl(id);

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

        public static bool UpdateUrlForRefCount(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Urls.UpdateUrlForRefCount(id);
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

        public static bool UpdateUrlForMedia(long id,long mediaID,int type)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Urls.UpdateUrlForMedia(id,mediaID,type);
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

        public static string AnalysisUrl(string url)
        {
            try
            {
                if (!Utils.IsURL(url))
                    return null;

                string tmpCode="";
                if (IsShortLink(url, ref tmpCode))
                {
                    return tmpCode;
                }

                string shortlink= UrlShort.ShortUrl(url)[0];
                Url u=GetUrlByShortLink(shortlink);
                if (u != null)
                {
                    UpdateUrlForRefCount(u.ID);
                }
                else
                {
                    u = new Url();
                    u.MediaID = -1;
                    u.OriginalUrl = url;
                    u.ShortLink = shortlink;
                    u.Type = TypeConfigs.GetUrlNormal;
                    u.ID=Urls.CreateUrl(u);
                }
                if (u.MediaID<0)
                {
                    long mediaID = 0; 
                    int type = TypeConfigs.GetUrlNormal;
                    if (Videos.IsVideoUrl(url))
                    {
                        VideoInfo vInfo = Videos.GetVideo(url);
                        if (vInfo != null)
                        {
                            long vid = Videos.CreateVideo(vInfo);
                            if (vid > 0)
                            {
                                mediaID = vid;
                                type = TypeConfigs.GetUrlVideo;
                            }
                        }
                    }
                    if (Musics.IsMusicUrl(url))
                    {
                        Music music = new Music();
                        music.Title = Path.GetFileNameWithoutExtension(url);
                        music.MusicUrl = url;
                        long mid = Musics.CreateMusic(music);
                        if (mid > 0)
                        {
                            mediaID = mid;
                            type = TypeConfigs.GetUrlMusic;
                        }
                    }
                    if (Votes.IsVoteUrl(url))
                    {
                        long vid = Votes.GetVoteIdFromUrl(url);
                        Vote vote = Votes.GetVoteByID(vid);
                        if (vote != null)
                        {
                            mediaID = vote.ID;
                            type = TypeConfigs.GetUrlVote;
                        }
                    }
                    if (mediaID != 0)
                    {
                        UpdateUrlForMedia(u.ID, mediaID, type);
                        return shortlink;
                    }
                    else
                    {
                        return shortlink;
                    }

                }
                else
                {
                    return shortlink;
                }



            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static bool IsShortLink(string url,ref string code)
        {
            string expression=BaseConfigs.GetShortLinkDomainName.Replace(".",@"\.").Replace(":",@"\:");
            expression+="([0-9a-zA-Z]+)";
            Regex reg = new Regex(expression, RegexOptions.IgnoreCase);
            if (reg.IsMatch(url))
            {
                code = reg.Match(url).Result("$1");
                return true;
            }
            else
            {
                code = null;
                return false;
            }
        }
    }
}
