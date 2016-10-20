using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weibo.Business;
using Weibo.Entity;
using Weibo.Config;

namespace Weibo.ShortUrl.Controllers
{
    public class UrlController : Controller
    {
        //
        // GET: /Url/

        public void Transfer(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Url url = Urls.GetUrlByShortLink(id);
                if (url != null)
                {
                    Urls.UpdateUrlForRefCount(url.ID);
                    Response.Redirect(url.OriginalUrl);
                }
            }
            Response.Redirect(BaseConfigs.GetWebDomain);
        }

    }
}
