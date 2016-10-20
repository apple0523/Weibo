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
    public class CommentController : LoginController
    {
        //
        // GET: /Comment/

        public ActionResult AtMeCmt(AtCmtModel model)
        {
            if (model.Page == 0)
                model.Page = 1;
            int recordCount = 0;
            Users.ClearCfgAtcmtCount(CurrentUser.ID);
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<Comment> comments = Comments.GetAtCommentsByPager(model.CurUser.ID,model.Key,model.IsFollow, model.Page, 20, ref recordCount);
                model.Comments = comments;
                model.PageSize = 20;
                model.RecordCount = recordCount;
                return View(model);
        }

        public ActionResult Receive(CommentRecModel model)
        {
            if (model.Page == 0)
                model.Page = 1;
            int recordCount = 0;
            Users.ClearCfgCommentCount(CurrentUser.ID);
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<Comment> comments = Comments.GetRecCommentsByPager(model.CurUser.ID,model.IsFollow,model.Key,model.Page, 20, ref recordCount);
                
                model.Comments = comments;
                model.PageSize = 20;
                model.RecordCount = recordCount;
                return View(model);
            
        }
        public ActionResult Send(CommentSendModel model)
        {
            if (model.Page == 0)
                model.Page = 1;
            int recordCount = 0;
            Users.ClearCfgCommentCount(CurrentUser.ID);
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<Comment> comments = Comments.GetSendCommentsByPager(model.CurUser.ID,model.Key,model.Page, 20, ref recordCount);
                model.Comments = comments;
                model.PageSize = 20;
                model.RecordCount = recordCount;
                return View(model);
        }

    }
}
