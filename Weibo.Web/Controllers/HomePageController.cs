using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Weibo.Config;
using Weibo.Entity;
using Weibo.Web.Models;
using Weibo.Business;
namespace Weibo.Web.Controllers
{
    public class HomePageController : NormalController
    {
        //
        // GET: /HomePage/

        public ActionResult Index()
        {


            IndexModel model = new IndexModel();
            model.NewUsers = Users.GetTop10UsersByQuery("NickName<>''", "RegTime", "desc");
            model.RankUsers = Users.GetTop10UsersByQuery("NickName<>''", "FocusedCount", "desc");
            model.UsingUsers = Users.GetTop10UsersByQuery("NickName<>''", "LastUpdateDate", "desc");
            model.Topics = Topics.GetTopStaticTopic(DateTime.Now.AddMonths(-1), DateTime.Now, 10);
            return View(model);
        }


		public ActionResult Error()
		{
			return View();
		}

    }
}
