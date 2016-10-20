using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Weibo.Web.Controllers
{
    public class JsonpController : LoginController
    {
        //
        // GET: /Jsonp/

        public ActionResult Unread()
        {
            return View(CurrentUserConfig);
        }

    }
}
