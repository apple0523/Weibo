using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weibo.Entity;
using Weibo.Common;
using Weibo.Config;
using Weibo.Business;
using Weibo.Web.Models;

namespace Weibo.Web.Controllers
{
    public class MusicController : Controller
    {
        //
        // GET: /Music/

        [HttpPost]
        public JsonResult Upload()
        {
            try
            {
                if (Request.Form["weibo"] == null)
                    throw new Exception();
                string cookie = Request.Form["weibo"].ToString();
                string uid=cookie.Split('&')[0].Replace("UID=","");
                string pwd=Utils.UrlDecode(cookie.Split('&')[1].Replace("PWD=",""));
                User CurrentUser = Users.GetUserByID(TypeConverter.StrToLong(uid, -1));
                if(CurrentUser==null)
                    throw new Exception();
                if(CurrentUser.Password!=pwd)
                    throw new Exception();
                Music music = Musics.UploadMusic(CurrentUser);
                if (music != null)
                {
                    Entity.Url url = new Url();
                    url.MediaID = music.ID;
                    url.ShortLink = UrlShort.ShortUrl(music.MusicUrl)[0];
                    url.OriginalUrl = music.MusicUrl;
                    url.Type = TypeConfigs.GetUrlMusic;
                    url.ID = Urls.CreateUrl(url);
                    if (url.ID > 0)
                    {

                        string shortlink = BaseConfigs.GetShortLinkDomainName + url.ShortLink;
                        return Json(new JsonModel(CodeStruct.UploadSuccess, shortlink + " " + music.Title));

                    }
                }
                return Json(new JsonModel(CodeStruct.Error, "-1"));
            }
            catch (Exception ex)
            {
                return Json(new JsonModel(CodeStruct.Error, "-1"));
            }
        }

    }
}
