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
    public class FollowController : LoginController
    {
        //
        // GET: /Follow/

        public ActionResult List(Models.FollowListModel model)
        {
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<Follow> follows = null; ;
            int recordCount = 0 ;
            if (model.Page == 0)
                model.Page = 1;
            string viewPath = "";
            if (string.IsNullOrEmpty(model.OrderBy))
                model.OrderBy = "CreateTime";
            string where = "";
            if (model.CurUser.ID == model.uid)
            {
                ViewData["CurHeader"] = "MyFriend";
                
                
                
                if (model.gid > 0)
                    where = string.Format("GroupIDs like '%a{0}a%' or GroupIDs like 'a{0}a%'", model.gid.ToString());
                if (model.NoGroup > 0)
                {
                    where = string.Format("GroupIDs is null or GroupIDs like ''");
                }
                if (model.FriendShip > 0)
                {
                    where = string.Format("FriendShip=1");
                }
                follows = Users.GetMyFollowByPager(model.CurUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
                viewPath = "~/Views/Follow/MyList.cshtml";
            }
            else
            {
                model.OtherUser = Users.GetUserByID(model.uid);
                if (model.OtherUser != null)
                {
                    follows = Users.GetOtherFollowByPager(model.OtherUser.ID,model.CurUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
                    viewPath = "~/Views/Follow/OtherList.cshtml";
                }
                else
                {
                    return View();
                }
            }
            model.Follows = follows;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(viewPath, model);
        }


        public ActionResult Search(Models.FollowListModel model)
        {
            ViewData["CurHeader"] = "MyFriend";
            if (model.Page == 0)
                model.Page = 1;
            if (string.IsNullOrEmpty(model.OrderBy))
                model.OrderBy = "CreateTime";
            string where = "";
            if (!string.IsNullOrEmpty(model.Key))
                where = string.Format("NickName like '%{0}%' or NickName like '{0}' or NickName like '%{0}' or NickName like '{0}%' or Remark like '%{0}%' or Remark like '{0}' or Remark like '%{0}' or Remark like '{0}%'", model.Key);
            int recordCount = 0;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<Follow> follows = Users.GetMyFollowByPager(CurrentUser.ID, model.Page, 20, where, model.OrderBy, ref recordCount);
            model.Follows = follows;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(model);
        }
    }
}
