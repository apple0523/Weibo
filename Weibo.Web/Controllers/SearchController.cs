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
using Weibo.Web.Models;
namespace Weibo.Web.Controllers
{
    public class SearchController : LoginController
    {
        //
        // GET: /Search/

        public ActionResult MiniBlog(SchMiniblogModel model)
        {
            if (model.Page == 0)
            {
                model.Page = 1;
            }
            if (!string.IsNullOrEmpty(model.timescope))
            {
                if (model.timescope == "1hour")
                {
                    model.StartTime = DateTime.Now.AddHours(-1);
                    model.EndTime = DateTime.Now;
                }
                else if (model.timescope == "24hour")
                {
                    model.StartTime = DateTime.Now.AddHours(-24);
                    model.EndTime = DateTime.Now;
                }
                else if (model.timescope == "1week")
                {
                    model.StartTime = DateTime.Now.AddDays(-7);
                    model.EndTime = DateTime.Now;
                }
                else if (model.timescope == "15days")
                {
                    model.StartTime = DateTime.Now.AddDays(-15);
                    model.EndTime = DateTime.Now;
                }
                else if (model.timescope == "1month")
                {
                    model.StartTime = DateTime.Now.AddMonths(-1);
                    model.EndTime = DateTime.Now;
                }
                else if (model.timescope == "custom")
                {
                    if (model.StartTime == null)
                    {
                        model.StartTime = new DateTime(2000, 1, 1);
                    }
                    if (model.EndTime == null)
                    {
                        model.EndTime = DateTime.Now;
                    }
                }
            }
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.PageSize = 20;
            int rowCount = 0;
            model.MiniBlogs = MiniBlogs.SearchMiniBlog(model.Page, 20, ref rowCount, model.Key, model.IsOri, model.Location, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, CurrentUser.ID, model.SomeOne, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort,0,0);
            model.RecordCount = rowCount;
            model.statisticTopics = Topics.GetTopStaticTopic(DateTime.Now.AddMonths(-1), DateTime.Now, 10);
            model.RelatedTopics = Topics.GetTopicsBySearch(model.Key);
            ViewData["URL"] = Request.Url.PathAndQuery;
            Topics.SaveTopic(model.Key);
            UserTopic ut = Topics.GetUserTopicByName(model.Key);
            if (ut != null)
                model.CurUserTopicID = ut.ID;
            else
                model.CurUserTopicID = -1;
            return View(model);
        }

        public ActionResult User(SchUserModel model)
        {
            if (model.Page == 0)
            {
                model.Page = 1;
            }
            DateTime? birthStart = null;
            DateTime? birthEnd = null;
            if (model.Age == "18")
            {
                birthStart = DateTime.Now.AddYears(-18);
                birthEnd = DateTime.Now;
            }
            if (model.Age == "22")
            {
                birthStart = DateTime.Now.AddYears(-22);
                birthEnd = DateTime.Now.AddYears(-18);
            }
            if (model.Age == "29")
            {
                birthStart = DateTime.Now.AddYears(-29);
                birthEnd = DateTime.Now.AddYears(-22);
            }
            if (model.Age == "39")
            {
                birthStart = DateTime.Now.AddYears(-39);
                birthEnd = DateTime.Now.AddYears(-29);
            }
            if (model.Age == "40")
            {
                birthStart = DateTime.MinValue;
                birthEnd = DateTime.Now.AddYears(-39);
            }
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.PageSize = 20;
            int rowCount = 0;
            model.Users = Users.SearchUser(model.Page, model.PageSize, ref rowCount, model.Key, model.School, model.Tag, model.Career, model.Location, model.Sex, birthStart,birthEnd);
            model.RecordCount = rowCount;
            if (string.IsNullOrEmpty(model.Key))
            {
                if (!string.IsNullOrEmpty(model.School))
                {
                    model.Key = model.School;
                }
                else if (!string.IsNullOrEmpty(model.Tag))
                {
                    model.Key = model.Tag;
                }
                else if (!string.IsNullOrEmpty(model.Career))
                {
                    model.Key = model.Career;
                }
                else
                {
                    Redirect(BaseConfigs.GetWebDomain);
                }
            }
            ViewData["URL"] = Request.Url.PathAndQuery;
            return View(model);

        }

    }
}
