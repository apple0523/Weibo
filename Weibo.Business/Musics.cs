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
using System.Web;
using System.IO;


namespace Weibo.Business
{
    public class Musics
    {
        public static Music GetMusicByID(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Musics.GetMusicByID(id);
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

        public static long CreateMusic(Music music)
        {
            try
            {
                if (music != null)
                {
                    return Data.Musics.CreateMusic(music);
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


       

        public static bool IsMusicUrl(string url)
        {
            Regex reg = new Regex(@"\.mp3$", RegexOptions.IgnoreCase);
            if (reg.IsMatch(url))
            {
                return true;
            }
            else
                return false;
        }

        public static Music UploadMusic(User user)
        {
            try
            {
                if (user != null)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[0];
                    if (file != null)
                    {
                        string title = Path.GetFileNameWithoutExtension(file.FileName);
                        string exe = Path.GetExtension(file.FileName);
                        if (exe == ".mp3")
                        {
                            if (file.ContentLength < BaseConfigs.GetMusicUploadSize)
                            {
                                string dateNow = Utils.GetDate();
                                string path = BaseConfigs.GetMusicUploadPath + dateNow + "/";
                                Utils.CreateDir(path);
                                string guid = Guid.NewGuid().ToString();
                                string newFileName = guid + exe;
                                file.SaveAs(Utils.GetMapPath(path + newFileName));

                                Music music = new Music();
                                music.MusicUrl =BaseConfigs.GetWebDomain +path + newFileName;
                                music.Title = title;

                                music.ID = Musics.CreateMusic(music);
                                if (music.ID > 0)
                                {
                                    return music;
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null; 
            }
        }
    }
}
