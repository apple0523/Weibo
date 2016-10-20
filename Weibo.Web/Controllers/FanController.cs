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
    public class FanController : LoginController
    {
        //
        // GET: /Fan/

        public ActionResult List(Models.FanListModel model)
        {
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            if (model.Page == 0)
                model.Page = 1;
            if (string.IsNullOrEmpty(model.OrderBy))
                model.OrderBy = "CreateTime";
            string where = "";
            int recordCount = 0;
            string viewPath = "";
            IList<Fans> fans = null;
            if (model.CurUser.ID == model.uid)
            {
                ViewData["CurHeader"] = "MyFriend";


                Users.ClearCfgFollowCount(CurrentUser.ID);
                fans = Users.GetMyFanByPager(CurrentUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
                viewPath = "~/Views/Fan/MyList.cshtml";
            }
            else
            {
                model.OtherUser = Users.GetUserByID(model.uid);
                if (model.OtherUser != null)
                {
                    fans = Users.GetOtherFanByPager(model.OtherUser.ID, model.CurUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
                    viewPath = "~/Views/Fan/OtherList.cshtml";
                }
                else
                {
                    return View();
                }
            }
            model.Fans = fans;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(viewPath,model);
        }

        public ActionResult Search(Models.FanListModel model)
        {
            ViewData["CurHeader"] = "MyFriend";
            if (model.Page == 0)
                model.Page = 1;
            if (string.IsNullOrEmpty(model.OrderBy))
                model.OrderBy = "CreateTime";string where = "";
            if(!string.IsNullOrEmpty(model.Key))
            	where = string.Format("NickName like '%{0}%' or NickName like '{0}' or NickName like '%{0}' or NickName like '{0}%' ", model.Key);

            int recordCount = 0;
            Users.ClearCfgFollowCount(CurrentUser.ID);
            IList<Fans> fans = Users.GetMyFanByPager(CurrentUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.Fans = fans;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(model);
        }
    }
}
