using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weibo.Web.Models;
using Weibo.Business;
using Weibo.Entity;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Web.Controllers
{
    public class NoticeController : LoginController
    {
        //
        // GET: /Notice/

        public ActionResult Index(string page)
        {
            ViewData["AdditionHeader"] = "我的通知";
            if (string.IsNullOrEmpty(page))
                page = "1";
            int recordCount = 0;
            Users.ClearCfgNoticeCount(CurrentUser.ID);
            NoticeListModel model = new NoticeListModel();
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.Notices = Notices.GetNoticesByUID(CurrentUser.ID, Convert.ToInt32(page), 20, ref recordCount);
            model.PageIndex = Convert.ToInt32(page);
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(model);
        }

    }
}
