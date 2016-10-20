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
    public class MessageController : LoginController
    {
        //
        // GET: /Message/

        public ActionResult Index(string Page)
        {
            ViewData["AdditionHeader"] = "我的私信";
            int page = 1;
            if (!string.IsNullOrEmpty(Page))
            {
                page = Convert.ToInt32(Page);
            }
            MessageIndexModel model = new MessageIndexModel();
            int recordCount = 0;
            Users.ClearCfgMsgCount(CurrentUser.ID);
            model.Contacts = Messages.GetContactsByUID(CurrentUser.ID, page, 10, ref recordCount);
            model.PageIndex = page;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.PageSize = 10;
            model.RecordCount = recordCount;
            return View(model);
        }

        public ActionResult TalkList(string Page,string Uid)
        {
            ViewData["AdditionHeader"] = "我的私信";
            int page = 1;
            if (!string.IsNullOrEmpty(Page))
            {
                page = Convert.ToInt32(Page);
            }
            MessageDetailsModel model = new MessageDetailsModel();
            int recordCount = 0;
            model.TalkUser = Users.GetUserByID(Convert.ToInt64(Uid));
            if (model.TalkUser == null)
                return Content("出错");
            model.Messages = Messages.GetMessagesByUID(CurrentUser.ID,Convert.ToInt64(Uid), page, 30, ref recordCount);
            model.PageIndex = page;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.PageSize = 30;
            model.RecordCount = recordCount;
            return View(model);
        }

        public ActionResult Search(Models.MesgSearchModel model)
        {
            ViewData["AdditionHeader"] = "我的私信";
            if (model.Page == 0)
            {
                model.Page = 1;
            }
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.PageSize = 30;
            int recordCount = 0;
            model.Messages = Messages.SearchOthersMessage(model.Key,model.CurUser.ID,model.Page, 30, ref recordCount);
            model.RecordCount = recordCount;
            return View(model);
        }
    }
}
