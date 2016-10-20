using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Weibo.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "DIYCSS", // 路由名称
                "DiyCss/{uid}", // 带有参数的 URL
                new { controller = "MbIndex", action = "DiyCss" }, // 参数默认值
            new { uid = @"\d+" }
                );

            routes.MapRoute(
                "Search", // 路由名称
                "k/{key}", // 带有参数的 URL
                new { controller = "Search", action = "MiniBlog", key = "" } // 参数默认值
            );
            routes.MapRoute(
           "Follow", // 路由名称
           "{uid}/Follow", // 带有参数的 URL
           new { controller = "Follow", action = "List" }, // 参数默认值
           new { uid = @"\d+" }
           );
            routes.MapRoute(
           "Fan", // 路由名称
           "{uid}/Fan", // 带有参数的 URL
           new { controller = "Fan", action = "List" }, // 参数默认值
           new { uid = @"\d+" }
           );
            routes.MapRoute(
           "Profile", // 路由名称
           "{uid}/Profile", // 带有参数的 URL
           new { controller = "MiniBlog", action = "My" }, // 参数默认值
           new { uid = @"\d+" }
           );
            routes.MapRoute(
           "Info", // 路由名称
           "{uid}/Info", // 带有参数的 URL
           new { controller = "MiniBlog", action = "Info" }, // 参数默认值
           new { uid = @"\d+" }
           );
            routes.MapRoute(
            "MiniBlogDetail", // 路由名称
            "{uid}/{IDCode}", // 带有参数的 URL
            new { controller = "MiniBlog", action = "details" }, // 参数默认值
            new { uid = @"\d+", IDCode = @"[0-9a-zA-Z]+" }
            );

            routes.MapRoute(
            "MbIndex2", // 路由名称
            "n/{nickname}", // 带有参数的 URL
            new { controller = "MbIndex", action = "Index" }
            );
            routes.MapRoute(
            "MbIndex", // 路由名称
            "{uid}/", // 带有参数的 URL
            new { controller = "MbIndex", action = "Index" }, // 参数默认值
            new { uid = @"\d+" }
            );
            routes.MapRoute(
           "MbIndex1", // 路由名称
           "{site}/", // 带有参数的 URL
           new { controller = "MbIndex", action = "Index" }, // 参数默认值
           new { site = @"\w+" }
           );

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "HomePage", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        //void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    /* Fix for the Flash Player Cookie bug in Non-IE browsers.
        //     * Since Flash Player always sends the IE cookies even in FireFox
        //     * we have to bypass the cookies by sending the values as part of the POST or GET
        //     * and overwrite the cookies with the passed in values.
        //     *
        //     * The theory is that at this point (BeginRequest) the cookies have not been read by
        //     * the Session and Authentication logic and if we update the cookies here we'll get our
        //     * Session and Authentication restored correctly
        //     */

        //    try
        //    {
        //        string session_param_name = "ASPSESSID";
        //        string session_cookie_name = "ASP.NET_SESSIONID";

        //        if (HttpContext.Current.Request.Form[session_param_name] != null)
        //        {
        //            UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
        //        }
        //        else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
        //        {
        //            UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Response.StatusCode = 500;
        //        Response.Write("Error Initializing Session");
        //    }

        //    try
        //    {
        //        string auth_param_name = "AUTHID";
        //        string auth_cookie_name = FormsAuthentication.FormsCookieName;

        //        if (HttpContext.Current.Request.Form[auth_param_name] != null)
        //        {
        //            UpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
        //        }
        //        else if (HttpContext.Current.Request.QueryString[auth_param_name] != null)
        //        {
        //            UpdateCookie(auth_cookie_name, HttpContext.Current.Request.QueryString[auth_param_name]);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        Response.StatusCode = 500;
        //        Response.Write("Error Initializing Forms Authentication");
        //    }
        //}
        //void UpdateCookie(string cookie_name, string cookie_value)
        //{
        //    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        //    if (cookie == null)
        //    {
        //        cookie = new HttpCookie(cookie_name);
        //        HttpContext.Current.Request.Cookies.Add(cookie);
        //    }
        //    cookie.Value = cookie_value;
        //    HttpContext.Current.Request.Cookies.Set(cookie);
        //}

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            Response.Clear();

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Error");

            Weibo.Business.Logs.WriteErrorLog(exception);
            Server.ClearError();


            Response.TrySkipIisCustomErrors = true;


            IController errorController = new Weibo.Web.Controllers.ErrorController();
            errorController.Execute(new RequestContext(
                 new HttpContextWrapper(Context), routeData));
        }
    }
}