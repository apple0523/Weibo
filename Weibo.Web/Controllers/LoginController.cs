using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Mvc;
using System.Data;
using Weibo.Config;
using Weibo.Entity;
using System.Web.Routing;
using Weibo.Web.Models;
using Weibo.Business;
using Weibo.Common;

namespace Weibo.Web.Controllers
{
    public class LoginController : BaseController
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (!IsLogin)
            {
                Response.Redirect("/User/Login/?BackUrl=" + Utils.UrlEncode(Request.Url.ToString()));
            }
            else
            {
                if (CurrentUser.NickName == "")
                {
                    Response.Redirect("/User/FullInfo/");
                }
            }
        }


    }
}
