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
using Weibo.Web.Models;
using System.IO;
namespace Weibo.Web.Controllers
{
    public class SetupController : LoginController
    {
        //
        // GET: /Setup/

        public ActionResult BaseInfo()
        {
            ViewData["AdditionHeader"] = "我的设置";
            BaseInfoModel model = new BaseInfoModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            return View(model);
        }

        public ActionResult EditPwd()
        {
            ViewData["AdditionHeader"] = "我的设置";
            BaseInfoModel model = new BaseInfoModel();
            model.CurUser = CurrentUser;
            return View(model);
        }
        public ActionResult Privacy()
        {
            ViewData["AdditionHeader"] = "我的设置";
            BaseInfoModel model = new BaseInfoModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            return View(model);
        }

        public ActionResult Notice()
        {
            ViewData["AdditionHeader"] = "我的设置";
            BaseInfoModel model = new BaseInfoModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            return View(model);
        }

        public ActionResult Education()
        {
            ViewData["AdditionHeader"] = "我的设置";
            EducationModel model = new EducationModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.Educations = Educations.GetEducationsByUID(model.CurUser.ID);
            return View(model);
        }

        public ActionResult Career()
        {
            ViewData["AdditionHeader"] = "我的设置";
            CareerModel model = new CareerModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.Careers = Careers.GetCareersByUID(model.CurUser.ID);
            return View(model);
        }



        public ActionResult ChangeAvatar()
        {
            ViewData["AdditionHeader"] = "我的设置";
            BaseInfoModel model = new BaseInfoModel();
            model.CurUser = CurrentUser;
            return View(model);
        }

        public void UploadAvatar()
        {
            ViewData["AdditionHeader"] = "我的设置";
            if (Request.Files[0] != null)
            {
                HttpPostedFileBase file = Request.Files[0];
                string path = BaseConfigs.GetAvartarUploadPath+"tmp/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath(path));
                Response.Write("<script type='text/javascript' type='language'>window.parent.uploadCallback('" + path + "');</script>");
                return;
            }
            Response.Write("<script type='text/javascript' type='language'>window.parent.App.alter('出错，稍后再试');</script>");
        }

        public ActionResult Tag()
        {
            ViewData["AdditionHeader"] = "我的设置";
            SetTagModel model = new SetTagModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.UserTags = Tags.GetUserTagsByUID(model.CurUser.ID);
            model.InterestTags = Tags.GetInterestTag(model.CurUser.ID);
            return View(model);
        }

        public ActionResult MySite()
        {
            ViewData["AdditionHeader"] = "我的设置";
            MySiteModel model = new MySiteModel();
            model.CurUser = CurrentUser;
            return View(model);
        }

       
        public ActionResult BlackList(string page)
        {
            ViewData["AdditionHeader"] = "我的设置";
            int pageIndex = 1;
            if (!string.IsNullOrEmpty(page))
            {
                pageIndex = Convert.ToInt32(page);
            }
            BlackListModel model = new BlackListModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            int recordCount = 0;
            model.BlackLists = BlackLists.GetMyBlackList(pageIndex, 10, model.CurUser.ID, ref recordCount);
            model.RecordCount = recordCount;
            model.PageIndex = pageIndex;
            model.PageSize = 10;
            return View(model);
        }
    }
}
