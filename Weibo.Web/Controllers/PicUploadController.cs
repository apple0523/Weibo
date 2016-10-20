using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weibo.Config;
using System.Drawing;
using Weibo.Entity;
using Weibo.Business;
using Weibo.Common;

namespace Weibo.Web.Controllers
{
    public class PicUploadController :BaseController
    {
        //
        // GET: /PicUpload/
        [HttpPost]
        public ContentResult MyProfileUpload()
        {
            int error=1;
            string fileName="";
            Pic pic= Pics.UploadImg(CurrentUser,ref error,ref fileName);
            if(error>0)
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.PicUploadCallBack(1,\"" + pic.SmallPicUrl + "\",\"" + fileName + "\",\""+pic.ID.ToString()+"\");</script>");
               // Response.Write("<script type='text/javascript' type='language'>window.parent.App.PicUploadCallBack(1,\""+pic.SmallPicUrl+"\",\""+fileName+"\");</script>");
            else if (error == -1)
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.PicUploadCallBack(-1);</script>");
               // Response.Write("<script type='text/javascript' type='language'>window.parent.App.PicUploadCallBack(-1);</script>");
            }
            else
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.PicUploadCallBack(-2);</script>");
               // Response.Write("<script type='text/javascript' type='language'>window.parent.App.PicUploadCallBack(-2);</script>");
            }
           
        }

        public ContentResult VoteDiaUpload()
        {
            int error = 1;
            string fileName = "";
            Pic pic = Pics.UploadImg(CurrentUser, ref error, ref fileName);
            if (error > 0)
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.votePicCallBack(1,\"" + pic.ID.ToString() + "\",\"" + fileName + "\");</script>");
            else if (error == -1)
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.votePicCallBack(-1);</script>");
            }
            else
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.votePicCallBack(-2);</script>");
            }
        }

        public ContentResult ThemePicUpload()
        {
            int error = 1;
            string fileName = "";
            Pic pic = Pics.UploadImg(CurrentUser, ref error, ref fileName,false);
            if (error > 0)
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.skinManage.themePicCallBack(1,\"" + pic.ID.ToString() + "\",\"" + pic.OriginalPicUrl + "\");</script>");
            else if (error == -1)
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.skinManage.themePicCallBack(-1);</script>");
            }
            else
            {
                return Content("<script type='text/javascript' language='javascript'>window.parent.App.skinManage.themePicCallBack(-2);</script>");
            }
        }
    }
}
