using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Weibo.Common;
using Weibo.Data;
using Weibo.Plugin.Video;
using Weibo.Config;
using Weibo.Entity;
using System.Text.RegularExpressions;

namespace Weibo.Business
{
    public class Videos
    {
        protected static IVideoCatch  VC;


        static Videos()
        {

            LoadVideoCatchPlugin();
        }

        public static void ReSetIVideoCatch()
        {

            LoadVideoCatchPlugin();
        }

        private static void LoadVideoCatchPlugin()
        {
            try
            {
                //读取相应的DLL信息
                Assembly asm = Assembly.LoadFrom(System.Web.HttpRuntime.BinDirectory + "Weibo.Plugin.Video.DefVideoCatch.dll");
                VC = (IVideoCatch)Activator.CreateInstance(asm.GetType("Weibo.Plugin.Video.DefVideoCatch", false, true));
            }
            catch(Exception ex)
            {
                try
                {
                    //读取相应的DLL信息
                    Assembly asm = Assembly.LoadFrom(Utils.GetMapPath("/bin/" + "Weibo.Plugin.Video.DefVideoCatch.dll"));
                    VC = (IVideoCatch)Activator.CreateInstance(asm.GetType("Weibo.Plugin.Video.DefVideoCatch", false, true));
                }
                catch(Exception ex1)
                {
                    Logs.WriteErrorLog(ex1);
                }
                Logs.WriteErrorLog(ex);
            }
        }

        public static VideoInfo GetVideo(string url)
        {
            try
            {
                VC.VideoUrl = url;
                return VC.Get();
            }
            catch(Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static bool IsVideoUrl(string url)
        {
            try
            {
                VC.VideoUrl = url;
                FromConst f = VC.CheckUrl();
                if (f == FromConst.NOTVIDEO)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static Video GetVideoByID(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Videos.GetVideoByID(id);
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

        public static long CreateVideo(VideoInfo vInfo)
        {
            try
            {
                if (vInfo != null)
                {
                    Video v = new Video();
                    v.FlvUrl = vInfo.FlvSrc;
                    if (vInfo.FromWebSite == FromConst.YOUKU)
                        v.FromWeb = TypeConfigs.GetVideoYouku;
                    if (vInfo.FromWebSite == FromConst.TUDOU)
                        v.FromWeb = TypeConfigs.GetVideoTudou;
                    if (vInfo.FromWebSite == FromConst._56)
                        v.FromWeb = TypeConfigs.GetVideo56;
                    if (vInfo.FromWebSite == FromConst.KU6)
                        v.FromWeb = TypeConfigs.GetVideoKu6;
                    if (vInfo.FromWebSite == FromConst.NOTVIDEO)
                        throw new Exception("改货不是视频");
                    v.ThumPicUrl = vInfo.ThumPic;
                    v.Title = vInfo.Title;
                    v.OriUrl = vInfo.Url;

                    return Data.Videos.CreateVideo(v);
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

        public static bool DelVideo(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Videos.DelVideo(id);
                }
                else
                {
                    return false ;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

       

    }
}
