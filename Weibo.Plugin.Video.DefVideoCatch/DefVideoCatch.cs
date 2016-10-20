using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Net;

namespace Weibo.Plugin.Video
{
	[VideoCatch("视频获取插件", Version = "2.0", Author = "Shaojunjie ", DllFileName = "Weibo.Plugin.Mail.DefVideoCatch.dll")]
	public class DefVideoCatch : IVideoCatch
	{

		#region IVideoCatch 成员

		public string VideoUrl
		{
			get;
			set;
		}

		public VideoInfo Get()
		{
            FromConst fc = CheckUrl();
            switch(fc)
            {
                case FromConst.KU6: return Ku6API.GetVideoInfo(VideoUrl);
                case FromConst.YOUKU: return YoukuAPI.GetVideoInfo(VideoUrl) ;
                case FromConst._56: return _56API.GetVideoInfo(VideoUrl);
                case FromConst.TUDOU: return TudouAPI.GetVideoInfo(VideoUrl);
                default: return null;
            }

		}

		public FromConst CheckUrl()
		{
			Regex regV = new Regex(@"ku6\.com", RegexOptions.IgnoreCase);
			if (regV.IsMatch(VideoUrl))
			{
				return FromConst.KU6;
			}
			regV = new Regex(@"youku\.com", RegexOptions.IgnoreCase);
			if (regV.IsMatch(VideoUrl))
			{
				return FromConst.YOUKU;
			}

			regV = new Regex(@"56\.com", RegexOptions.IgnoreCase);
			if (regV.IsMatch(VideoUrl))
			{
				return FromConst._56;
			}
			regV = new Regex(@"tudou\.com", RegexOptions.IgnoreCase);
			if (regV.IsMatch(VideoUrl))
			{
				return FromConst.TUDOU;
			}
			return FromConst.NOTVIDEO;
		}
		#endregion

		#region ku6

        class Ku6API
        {
            private static string GetVID(string url)
            {
                Regex reg = new Regex(@"([0-9A-Za-z\-_\.]+)\.html$", RegexOptions.IgnoreCase);
                return reg.Match(url).Result("$1");
            }

            public static VideoInfo GetVideoInfo(string url)
            {

                WebClient wb = new WebClient();
                try
                {
                    string jsonUrl = "http://vo.ku6.com/fetchVideo4Player/1/{id}.html";

                    string id = GetVID(url);
                    if (string.IsNullOrEmpty(id))
                        return null;
                    jsonUrl = jsonUrl.Replace("{id}", id);
                    string str = Encoding.UTF8.GetString((wb.DownloadData(jsonUrl)));
                    Regex regTitle = new Regex("\"t\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    Regex regLogo = new Regex("\"bigpicpath\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    string title = UnicodeToGB(regTitle.Match(str).Result("$1"));
                    string logo = UnicodeToGB(regLogo.Match(str).Result("$1"));
                    VideoInfo v = new VideoInfo();
                    v.FromWebSite = FromConst.KU6;
                    v.ThumPic = logo;
                    v.Title = title;
                    v.Url = url;
                    v.FlvSrc = "http://player.ku6.com/refer/"+id+"/v.swf";
                    return v;
                }

                catch
                {
                    wb.Dispose();
                    return null;
                }
                finally
                {
                    wb.Dispose();
                }

            }
        }
		#endregion

        #region youku
     

        class YoukuAPI
        {
            private static string GetVID(string url)
            {
                Regex reg = new Regex(@"id_([0-9A-Za-z=]+)\.html$", RegexOptions.IgnoreCase);
                return reg.Match(url).Result("$1").Replace("=", "");
            }


            public static VideoInfo GetVideoInfo(string url)
            {

                  WebClient wb = new WebClient();
                  try
                  {
                      string jsonUrl = "http://v.youku.com/player/getPlayList/VideoIDS/{id}/";

                      string id = GetVID(url);
                      if (string.IsNullOrEmpty(id))
                          return null;
                      jsonUrl = jsonUrl.Replace("{id}", id);
                      string str = Encoding.UTF8.GetString((wb.DownloadData(jsonUrl)));
                      Regex regTitle = new Regex("\"title\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                      Regex regLogo = new Regex("\"logo\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                      string title = UnicodeToGB(regTitle.Match(str).Result("$1"));
                      string logo = regLogo.Match(str).Result("$1").Replace("\\/","/");
                      VideoInfo v = new VideoInfo();
                      v.FromWebSite = FromConst.YOUKU;
                      v.ThumPic = logo;
                      v.Title = title;
                      v.Url = url;
                      v.FlvSrc = "http://player.youku.com/player.php/sid/" + id + "/v.swf";
                      return v;
                  }

                  catch
                  {
                      wb.Dispose();
                      return null;
                  }
                  finally
                  {
                      wb.Dispose();
                  }

            }
        }
    
        #endregion

        #region 56


        class _56API
        {
            private static string GetVID(string url)
            {
                Regex reg = new Regex(@"v_([0-9A-Za-z]+)\.html$", RegexOptions.IgnoreCase);
                return reg.Match(url).Result("$1");
            }


            public static VideoInfo GetVideoInfo(string url)
            {

                WebClient wb = new WebClient();
                try
                {
                    string jsonUrl = "http://vxml.56.com/json/{id}/?src=out";

                    string id = GetVID(url);
                    if (string.IsNullOrEmpty(id))
                        return null;
                    jsonUrl = jsonUrl.Replace("{id}", id);
                    string str = Encoding.UTF8.GetString((wb.DownloadData(jsonUrl)));
                    Regex regTitle = new Regex("\"Subject\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    Regex regLogo = new Regex("\"img\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    string title = regTitle.Match(str).Result("$1");
                    string logo = regLogo.Match(str).Result("$1");
                    VideoInfo v = new VideoInfo();
                    v.FromWebSite = FromConst._56;
                    v.ThumPic = logo;
                    v.Title = title;
                    v.Url = url;
                    v.FlvSrc = "http://player.56.com/v_"+id+".swf";
                    return v;
                }

                catch
                {
                    wb.Dispose();
                    return null;
                }
                finally
                {
                    wb.Dispose();
                }

            }
        }
       
        #endregion

        #region Tudou


        class TudouAPI
        {
            private static string GetVID(string url)
            {
                Regex reg = new Regex(@"\/view\/([\w-]+)/?", RegexOptions.IgnoreCase);
                return reg.Match(url).Result("$1");
            }


            public static VideoInfo GetVideoInfo(string url)
            {

                WebClient wb = new WebClient();
                try
                {
                    string jsonUrl = "http://api.tudou.com/v3/gw?method=item.info.get&appKey=7ee7a34f14a4c74b&format=json&itemCodes={id}";

                    string id = GetVID(url);
                    if (string.IsNullOrEmpty(id))
                        return null;
                    jsonUrl = jsonUrl.Replace("{id}", id);
                    string str = Encoding.UTF8.GetString((wb.DownloadData(jsonUrl)));
                    Regex regTitle = new Regex("\"title\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    Regex regLogo = new Regex("\"picUrl\":\"([^\"]+)\"", RegexOptions.IgnoreCase);
                    string title = regTitle.Match(str).Result("$1");
                    string logo = regLogo.Match(str).Result("$1");
                    VideoInfo v = new VideoInfo();
                    v.FromWebSite = FromConst.TUDOU;
                    v.ThumPic = logo;
                    v.Title = title;
                    v.Url = url;
                    v.FlvSrc = "http://www.tudou.com/v/"+id+"/v.swf";
                    return v;
                }

                catch
                {
                    wb.Dispose();
                    return null;
                }
                finally
                {
                    wb.Dispose();
                }

            }
        }

        #endregion

        #region common
        private static string UnicodeToGB(string text)
        {
            Regex Regex = new Regex("\\\\u[\\w]{4}");
            return Regex.Replace(text, new System.Text.RegularExpressions.MatchEvaluator(ReplaceUnicode));

        }
        private static string ReplaceUnicode(System.Text.RegularExpressions.Match m)
        {
            string v = m.Value.Replace(@"\u", "");
            string word = v;
            byte[] codes = new byte[2];
            int code = Convert.ToInt32(word.Substring(0, 2), 16);
            int code2 = Convert.ToInt32(word.Substring(2), 16);
            codes[0] = (byte)code2;
            codes[1] = (byte)code;
            return Encoding.Unicode.GetString(codes);
        }
        #endregion
    }
}

