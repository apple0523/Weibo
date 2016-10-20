using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Weibo.Config;
using Weibo.Entity;
using Weibo.Common;

namespace Weibo.Web.Models
{
    #region service
    public interface IFormsAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        void SignOut();
        long UID { get; }
        string PWD { get; }
        bool IsAuthenticated { get; }
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(User user, bool createPersistentCookie)
        {
            if (user == null) throw new ArgumentException("值不能为 null 或为空。", "userName");

            HttpCookie cookie = new HttpCookie("weibo");
            cookie.Values["UID"] = user.ID.ToString();
            cookie.Values["PWD"] = Utils.UrlEncode(user.Password);
            //cookie.Domain = BaseConfigs.GetCookieDomain;
            if (createPersistentCookie)
            {
                cookie.Expires = DateTime.Now.AddDays(BaseConfigs.GetCookieExpire);
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }



        public void SignOut()
        {
            HttpCookie cookie = new HttpCookie("weibo");
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddDays(-1);
            //cookie.Domain = BaseConfigs.GetCookieDomain;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public long UID
        {
            get
            {
                try
                {
                    return TypeConverter.StrToLong(HttpContext.Current.Request.Cookies["weibo"].Values["UID"].ToString(),-1);
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        public string PWD
        {
            get
            {
                try
                {
                    return Utils.UrlDecode(HttpContext.Current.Request.Cookies["weibo"].Values["PWD"].ToString());
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.Request.Cookies["weibo"] != null;
            }
        }

    }
    #endregion
}