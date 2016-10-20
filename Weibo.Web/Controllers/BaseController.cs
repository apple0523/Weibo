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
using System.IO;

namespace Weibo.Web.Controllers
{
    public class BaseController : Controller
    {
        public bool IsLogin
        {
            get
            {
                return FormService.IsAuthenticated&&CurrentUser!=null;
            }
        }

        private User currentUser;
        public User CurrentUser
        {
            get
            {
                if (FormService.IsAuthenticated&&currentUser==null)
                {
                    User user = Users.GetUserByID(FormService.UID);
                    if (user != null)
                    {
                        if (user.Password == FormService.PWD)
                        {
                            currentUser = user;
                            return currentUser;
                        }
                    }
                        return null;
                }
                else
                    return currentUser;
            }
        }

        private UserConfig currentUserConfig;
        public UserConfig CurrentUserConfig
        {
            get
            {
                if (FormService.IsAuthenticated&&currentUserConfig==null)
                {
                    UserConfig userc = Users.GetUserConfigByID(FormService.UID);
                    if (userc != null)
                    {
                        currentUserConfig = userc;
                        return currentUserConfig;
                        
                    }
                    return null;
                }
                else
                    return currentUserConfig;
            }
        }

        private string currentCssUrl;
        public string CurrentCssUrl
        {
            get {
                if (string.IsNullOrEmpty(currentCssUrl))
                {
                    UserConfig uc = CurrentUserConfig;
                    if (uc.IsThemeDIY == 1)
                    {
                        currentCssUrl="/DiyCss/" + uc.UID;
                        return currentCssUrl;
                    }
                    else
                    {
                        Theme t = Themes.GetThemeByID(uc.ThemeID);
                        if (t != null)
                        {
                            currentCssUrl = t.CssUrl;
                            return currentCssUrl;
                        }
                        else
                            return "";
                    }
                }
                else
                    return currentCssUrl;
            }
        }

        public FormsAuthenticationService FormService
        {
            get
            {
                if (_formService == null)
                {
                    return _formService = new FormsAuthenticationService();
                }
                else
                {
                    return _formService;
                }
            }
        }

        private FormsAuthenticationService _formService = null;


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }


        public JsonResult NotLogin()
        {
          return Json(new JsonModel(CodeStruct.NoLogin, -1));
        }

        public string BackUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(WeiboRequest.GetQueryString("BackUrl")))
                {
                    return WeiboRequest.GetQueryString("BackUrl");
                }
                else
                    return null;
            }
        }

        public  string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}