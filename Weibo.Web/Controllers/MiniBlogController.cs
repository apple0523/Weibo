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
    public class MbIndexController : BaseController
    {
        public ActionResult Index(Models.MbIndexModel model)
        {
            if (model.Page == 0)
            {
                model.Page = 1;
            }
            model.PageSize = 30;
            if (!string.IsNullOrEmpty(model.site))
            {
                model.OtherUser = Users.GetUerByCustomSite(model.site);

            }
            if (!string.IsNullOrEmpty(model.nickname))
            {
                model.OtherUser = Users.GetUserByNickName(model.nickname);
            }
            if (model.uid > 0)
            {
                model.OtherUser = Users.GetUserByID(model.uid);
                if (model.OtherUser != null&&!Request.IsAjaxRequest())
                {
                    if (!string.IsNullOrEmpty(model.OtherUser.CustomSite))
                    {
                        return Redirect("/" + model.OtherUser.CustomSite);
                    }
                }
            }
            if (model.OtherUser != null)
            {
                if (CurrentUser != null)
                {
                    if (CurrentUser.ID == model.OtherUser.ID)
                    {
                        model.CurUser = CurrentUser;
                        if (!Request.IsAjaxRequest())
                        {
                            ViewData["CurHeader"] = "MyProfile";
                            model.CurSkinCss = CurrentCssUrl;
                            model.CurUserConfig = CurrentUserConfig;
                        }
                        if (Request.IsAjaxRequest())
                        {
                            if (model.gid == 0 && model.IsFriendShip == 0)
                            {
                                model.IsMyFollow = 1;
                            }
                            int rowCount = 0;
                            if (model.IsAdvanced > 0)
                            {
                                if (model.EndTime == null)
                                {
                                    model.EndTime = DateTime.MaxValue;
                                }
                                if (model.StartTime == null)
                                {
                                    model.StartTime = new DateTime(2000, 1, 1);
                                }
                                model.MiniBlogs = MiniBlogs.SearchMiniBlogForMbIndexAdvanced((model.Page-1)*3+model.Buffer+1, model.PageSize/3, ref rowCount, model.Key, model.IsOri, model.IsRet, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.CurUser.ID, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, model.gid, model.IsFriendShip);
                            }
                            else
                                model.MiniBlogs = MiniBlogs.SearchMiniBlog((model.Page - 1) * 3 + model.Buffer+1, model.PageSize / 3, ref rowCount, model.Key, model.IsOri, model.Location, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.CurUser.ID, model.SomeOne, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, model.gid, model.IsFriendShip);
                            model.RecordCount = rowCount;
                            string data = RenderRazorViewToString("~/Views/MiniBlog/MyAjaxProfile.cshtml", model);
                            if (!string.IsNullOrEmpty(data))
                            {
                                return Json(new  PagerJsonModel (CodeStruct.ReturnSuccess, data,model.RecordCount), JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new JsonModel(CodeStruct.NoResult, data), JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return View("~/Views/MiniBlog/myprofile.cshtml", model);
                        }
                    }
                    else
                    {
                        model.CurUser = CurrentUser;
                        if (!Request.IsAjaxRequest())
                        {
                            model.OtherUserConfig = Users.GetUserConfigByID(model.OtherUser.ID);

                            model.CurUserConfig = CurrentUserConfig;
                            if (model.OtherUserConfig.IsThemeDIY == 1)
                                model.OthersSkinCss = "/DiyCss/" + model.OtherUser.ID.ToString();
                            else
                            {
                                Theme t = Themes.GetThemeByID(model.OtherUserConfig.ThemeID);
                                if (t != null)
                                {
                                    model.OthersSkinCss = t.CssUrl;
                                }
                                else
                                    model.OthersSkinCss = "";
                            }
                        }
                        else
                        {
                            model.IsMyself = 1;

                            int rowCount = 0;
                            if (model.IsAdvanced > 0)
                            {
                                if (model.EndTime == null)
                                {
                                    model.EndTime = DateTime.MaxValue;
                                }
                                if (model.StartTime == null)
                                {
                                    model.StartTime = new DateTime(2000, 1, 1);
                                }
                                model.MiniBlogs = MiniBlogs.SearchMiniBlogForMbIndexAdvanced((model.Page-1)*3+model.Buffer+1, model.PageSize/3, ref rowCount, model.Key, model.IsOri, model.IsRet, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.OtherUser.ID, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, model.gid, model.IsFriendShip);
                            }
                            else
                                model.MiniBlogs = MiniBlogs.SearchMiniBlog((model.Page - 1) * 3 + model.Buffer + 1, model.PageSize / 3, ref rowCount, model.Key, model.IsOri, model.Location, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.OtherUser.ID, model.SomeOne, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, model.gid, model.IsFriendShip);
                            model.RecordCount = rowCount;
                        }
                        if (!Request.IsAjaxRequest())
                        {
                            return View("~/Views/MiniBlog/OthersProfile.cshtml", model);
                        }
                        else
                        {
                            string data = RenderRazorViewToString("~/Views/MiniBlog/OthersAjaxMiniBlog.cshtml", model);
                            if (!string.IsNullOrEmpty(data))
                            {
                                return Json(new JsonModel(CodeStruct.ReturnSuccess, data), JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new JsonModel(CodeStruct.NoResult, data), JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
                else
                {
                    model.OtherUserConfig = Users.GetUserConfigByID(model.OtherUser.ID);
                    model.IsMyself = 1;
                    if (model.OtherUserConfig.IsThemeDIY == 1)
                        model.OthersSkinCss = "/DiyCss/" + model.OtherUser.ID.ToString();
                    else
                    {
                        Theme t = Themes.GetThemeByID(model.OtherUserConfig.ThemeID);
                        if (t != null)
                        {
                            model.OthersSkinCss = t.CssUrl;
                        }
                        else
                            model.OthersSkinCss = "";
                    }

                    int rowCount = 0;

                    model.MiniBlogs = MiniBlogs.SearchMiniBlog(model.Page, model.PageSize, ref rowCount, model.Key, model.IsOri, model.Location, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.OtherUser.ID, model.SomeOne, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, model.gid, model.IsFriendShip);
                    model.RecordCount = rowCount;
                    return View("~/Views/MiniBlog/Nologin.cshtml", model);
                }

            }
            else
            {
                throw new Exception("找不到用户");
            }
           
        }

        public ActionResult DiyCss(long uid)
        {
            Models.DiyCssModel model = new Models.DiyCssModel();
            model.Diy = Themes.GetThemeDIYByUID(uid);
            this.Response.ContentType = "text/css";
            return View("~/Views/MiniBlog/DiyCss.cshtml", model);
        }
    }
    
    public class MiniBlogController : LoginController
    {
        //
        // GET: /MiniBlog/

        public ActionResult Info(long uid)
        {
            if (CurrentUser.ID == uid)
            {
                Models.MyInfoModel model = new Models.MyInfoModel();
                model.CurSkinCss = CurrentCssUrl;
                model.CurUser = CurrentUser;
                model.CurUserConfig = CurrentUserConfig;
                model.MyCareer = Careers.GetCareersByUID(model.CurUser.ID);
                model.MyEducation = Educations.GetEducationsByUID(model.CurUser.ID);
                return View("~/Views/MiniBlog/MyInfo.cshtml", model);
            }
            else
            {
                Models.OtherInfoModel model = new Models.OtherInfoModel();
                model.CurUser = CurrentUser;
                model.CurUserConfig = CurrentUserConfig;
                model.OtherUser = Users.GetUserByID(uid);
                model.OtherUserConfig = Users.GetUserConfigByID(model.OtherUser.ID);
                model.OtherCareer = Careers.GetCareersByUID(model.OtherUser.ID);
                model.OtherEducation = Educations.GetEducationsByUID(model.OtherUser.ID);
                if (model.OtherUserConfig.IsThemeDIY == 1)
                    model.OthersSkinCss = "/DiyCss/"+model.OtherUser.ID.ToString();
                else
                {
                    Theme t = Themes.GetThemeByID(model.OtherUserConfig.ThemeID);
                    if (t != null)
                    {
                        model.OthersSkinCss = t.CssUrl;
                    }
                    else
                        model.OthersSkinCss = "";
                }
                return View("~/Views/MiniBlog/OtherInfo.cshtml", model);
            }
        }

        public ActionResult My(Models.MyMiniBlogModel model)
        {
            if (model.Page == 0)
            {
                model.Page = 1;
            }
            model.CurUser = CurrentUser;
            if (!Request.IsAjaxRequest())
            {
                ViewData["CurHeader"] = "MyMiniblog";

                model.CurSkinCss = CurrentCssUrl;
                model.CurUserConfig = CurrentUserConfig;
            }
            else
            {
                model.PageSize = 30;
                int rowCount = 0;
                model.IsMyself = 1;
                if (model.IsAdvanced > 0)
                {
                    if (model.EndTime == null)
                    {
                        model.EndTime = DateTime.MaxValue;
                    }
                    if (model.StartTime == null)
                    {
                        model.StartTime = new DateTime(2000, 1, 1);
                    }
                    model.MiniBlogs = MiniBlogs.SearchMiniBlogForMbIndexAdvanced((model.Page - 1) * 3 + model.Buffer + 1, model.PageSize / 3, ref rowCount, model.Key, model.IsOri, model.IsRet, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.CurUser.ID, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, 0, 0);
                }
                else
                    model.MiniBlogs = MiniBlogs.SearchMiniBlog((model.Page - 1) * 3 + model.Buffer + 1, model.PageSize / 3, ref rowCount, model.Key, model.IsOri, model.Location, model.StartTime, model.EndTime, model.IsMyself, model.IsMyFollow, model.CurUser.ID, model.SomeOne, model.IsHavePic, model.IsHaveLink, model.IsHaveVideo, model.IsHaveMusic, model.IsHaveVote, model.Sort, 0, 0);
                model.RecordCount = rowCount;
            }
            if (Request.IsAjaxRequest())
            {
                string data = RenderRazorViewToString("MyAjaxMiniBlog", model);
                if (!string.IsNullOrEmpty(data))
                {
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, data),JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, data), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return View(model);
            }
        }



        public ActionResult details( Models.DetailsModel model)
        {
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            if (string.IsNullOrEmpty(model.IDCode))
                throw new Exception("微博不存在");
            MiniBlog miniBlog = MiniBlogs.GetMiniBlogByIDCode(model.IDCode);
            if (miniBlog != null)
            {
                if (miniBlog.UID != CurrentUser.ID)
                {
                    model.OtherUser = Users.GetUserByID(miniBlog.UID);
                    model.OtherUserConfig = Users.GetUserConfigByID(miniBlog.UID);
                    if (model.OtherUserConfig.IsThemeDIY == 1)
                        model.OtherSkinCss = "/DiyCss/" + model.OtherUser.ID;

                    else
                    {
                        Theme t = Themes.GetThemeByID(model.OtherUserConfig.ThemeID);
                        if (t != null)
                        {
                            model.OtherSkinCss = t.CssUrl;
                        }
                    }
                }
                else
                {
                    if (model.CurUserConfig.IsThemeDIY == 1)
                        model.CurSkinCss = "/DiyCss/" + model.CurUser.ID;

                    else
                    {
                        Theme t = Themes.GetThemeByID(model.CurUserConfig.ThemeID);
                        if (t != null)
                        {
                            model.CurSkinCss = t.CssUrl;
                        }
                    }
                }
                model.MiniBlog = miniBlog;
               


                return View(model);
            }
            else
                throw new Exception("微博不存在");
        }

        public ActionResult Fav(Models.FavoriteModel model)
        {
            if (model.Page==0)
                model.Page = 1;
            int recordCount = 0;
            IList<Favorite> favs = MiniBlogs.GetFavorteByPager(CurrentUser.ID,model.Key, model.Page, 20, ref recordCount);
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            model.MiniBlogs = favs;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(model);
        }

        public ActionResult AtMe(Models.AtMeModel model)
        {
            if (model.Page == 0)
                model.Page = 1;
            Users.ClearCfgAtmeCount(CurrentUser.ID);
            int recordCount = 0;
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            IList<MiniBlog> miniBlogs = MiniBlogs.GetAtMeByPager(model.Key,model.IsFollow,model.IsOri,model.CurUser.ID, model.Page, 20, ref recordCount);
            
            model.MiniBlogs = miniBlogs;
            model.PageSize = 20;
            model.RecordCount = recordCount;
            return View(model);
        }

        public ActionResult MySkin()
        {
            Models.MySkinModel model = new Models.MySkinModel();
            ViewData["CurHeader"] = "MySkin";
            model.CurSkinCss = CurrentCssUrl;
            model.CurUser = CurrentUser;
            model.CurUserConfig = CurrentUserConfig;
            int recordCount = 0;
            model.MiniBlogs = MiniBlogs.GetMiniBlogsByUID(CurrentUser.ID, 1, 100, ref recordCount);
            return View(model);
        }


    }
}
