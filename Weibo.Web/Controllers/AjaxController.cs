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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Weibo.Web.Controllers
{
    public class AjaxController : BaseController
    {
        public JsonResult JudgeLogin()
        {
            if (!IsLogin) return NotLogin();
            else
                return Json(new JsonModel(CodeStruct.HaveLogon, new { name = CurrentUser.NickName, id = CurrentUser.ID }));
        }
        public JsonResult CheckEmail(string email)
        {

            JsonModel jsonM;
            User user = Users.GetUserByEmail(email);
            if (user != null)
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "1");
            }
            else
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "0");
            }
                return Json(jsonM);
        }

        public JsonResult CheckNickName(string name)
        {

            JsonModel jsonM;
            User user = Users.GetUserByNickName(name);
            if (user != null)
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "1");
            }
            else
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "0");
            }
            return Json(jsonM);
        }

        public JsonResult CheckNickName1(string name)
        {

            JsonModel jsonM;
            User user = Users.GetUserByNickName(name);
            if (user != null&&user.NickName!=CurrentUser.NickName)
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "1");
            }
            else
            {
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, "0");
            }
            return Json(jsonM);
        }

        public JsonResult CheckCode(string Code)
        {
            JsonModel jsonM;
            if (Session["CheckCode"] != null)
            {
                if (Session["CheckCode"].ToString().ToLower() == Code.Trim().ToLower())
                {
                    jsonM = new JsonModel(CodeStruct.ReturnSuccess, "0");
                }
                else
                {
                    jsonM = new JsonModel(CodeStruct.ReturnSuccess, "1");
                }
            }
            else
            jsonM = new JsonModel(CodeStruct.ReturnSuccess, "1");

            return Json(jsonM);
        }

        public JsonResult ReSendEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                return Json(new JsonModel(CodeStruct.Error, "0"));
            else
            {
                try
                {
                    Users.SendRegEmail(Email);
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, "1"));
                }
                catch (Exception ex)
                {
                    return Json(new JsonModel(CodeStruct.Error, "0"));
                }
            }
        }

        public JsonResult GetCity(string Type, string Val)
        {
            var val = TypeConverter.StrToInt(Val);
            IList<Entity.Type> citys = Types.GetTypesByPID(val);
            JsonModel jsonM;
            if (Type == "City")
            {
                Entity.Type item = new Entity.Type();
                item.CreateTime = DateTime.Now;
                item.ID = -1;
                item.Name = "不限";
                item.PID = val;
                if (citys == null)
                {
                    citys = new List<Entity.Type>();
                    Entity.Type item1 = new Entity.Type();
                    item1.CreateTime = DateTime.Now;
                    item1.ID = -2;
                    item1.Name = "城市/地区";
                    item1.PID = val;
                    citys.Insert(0, item1);
                }
                citys.Insert(0, item);
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, citys);
            }
            else
            {
                Entity.Type item = new Entity.Type();
                item.CreateTime = DateTime.Now;
                item.ID = -1;
                item.Name = "省/直辖市";
                item.PID = val;
                if (citys == null)
                    citys = new List<Entity.Type>();
                citys.Insert(0, item);
                jsonM = new JsonModel(CodeStruct.ReturnSuccess, citys);
            }

            return Json(jsonM,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCity1(string Type, string Val)
        {
            var val = TypeConverter.StrToInt(Val);
            IList<Entity.Type> citys = Types.GetTypesByPID(val);
            JsonModel jsonM;
            if (Type == "City")
            {
                Entity.Type item = new Entity.Type();
                item.CreateTime = DateTime.Now;
                item.ID = -1;
                item.Name = "不限";
                item.PID = val;
                if (citys == null)
                    citys = new List<Entity.Type>();
                citys.Insert(0, item);
            }
            jsonM = new JsonModel(CodeStruct.ReturnSuccess, citys);

            return Json(jsonM, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetExpressionType()
        {
            IList<Entity.Type> eType = Types.GetTypesByPID(TypeConfigs.GetExpressionRoot);
            Entity.Type newType = new Entity.Type();
            newType.CreateTime = DateTime.Now;
            newType.ID = 9999;
            newType.Name = "默认";
            newType.PID = 10000;
            eType.Insert(0, newType);
            JsonModel jsonM = new JsonModel(CodeStruct.ReturnSuccess, eType);
            return Json(jsonM);
        }
        public JsonResult GetExpressions()
        {
            IList<Entity.Expression> expressions = Expressions.GetAllExpression();
            JsonModel jsonM = new JsonModel(CodeStruct.ReturnSuccess, expressions);
            return Json(jsonM);
        }

        public JsonResult CheckVideoUrl(string Url)
        {
            JsonModel jsonM = null;
            if (Videos.IsVideoUrl(Url))
            {
               string code= Urls.AnalysisUrl(Url);
               if (!string.IsNullOrEmpty(code))
               {
                   jsonM = new JsonModel(CodeStruct.ReturnSuccess, BaseConfigs.GetShortLinkDomainName + code);
                   return Json(jsonM);
               }
            }
            jsonM = new JsonModel(CodeStruct.NotUrl, "-1");
            return Json(jsonM);
        }

        public JsonResult CheckMusicUrl(string Url)
        {
            JsonModel jsonM = null;
            if (Musics.IsMusicUrl(Url))
            {
                string code = Urls.AnalysisUrl(Url);
                if (!string.IsNullOrEmpty(code))
                {
                    jsonM = new JsonModel(CodeStruct.ReturnSuccess, BaseConfigs.GetShortLinkDomainName + code);
                    return Json(jsonM);
                }
            }
            jsonM = new JsonModel(CodeStruct.NotUrl, "-1");
            return Json(jsonM);
        }


        public JsonResult CreateOriginalMiniBlog(string Content,string AttachPic)
        {
            if (!string.IsNullOrEmpty(Content) && !string.IsNullOrEmpty(AttachPic))
            {
                if (!IsLogin) return NotLogin();
                if (CurrentUser.LastInputContent == Utils.HtmlDecode(Content)) return Json(new JsonModel(CodeStruct.RepeatContent, "1"));
               From f=Froms.GetFromByUrl(BaseConfigs.GetWebDomain);
               Content = Utils.HtmlDecode(Content);
               if (f != null)
               {
                   MiniBlogs.CreateOriginalMiniBlog(CurrentUser, Content, AttachPic, f.ID);
               }
               else
               {
                   MiniBlogs.CreateOriginalMiniBlog(CurrentUser, Content, AttachPic, -1);
               }
               return Json(new JsonModel(CodeStruct.CreateSuccess, "1"));
            }
            else
                return Json(new JsonModel(CodeStruct.Error, "1"));
                
           
        }

        public JsonResult CreateQuoteMiniBlog(string Content, string oriMid, string quoMid,string isRoot,string isLast)
        {
            if ( !string.IsNullOrEmpty(oriMid) && !string.IsNullOrEmpty(quoMid))
            {
                Content = Utils.HtmlDecode(Content);
               if (!IsLogin) return NotLogin();
               if (CurrentUser.LastInputContent == Content) return Json(new JsonModel(CodeStruct.RepeatContent, "1"));
               if (string.IsNullOrEmpty(Content) || Content == "随便说点什么吧...")
                   Content = "转发微博";
               From f=Froms.GetFromByUrl(BaseConfigs.GetWebDomain);
              

               if (isLast != "null")
               {
                   MiniBlog quomini = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(quoMid));
                   if (quomini != null)
                   {
                       if (!BlackLists.IsInBlackList(quomini.UID, CurrentUser.ID))
                       {
                           UserConfig uc = Users.GetUserConfigByID(quomini.UID);
                           if (uc.IsCommentMe == 1)
                           {
                               Comments.CreateNoReplyComment(CurrentUser, quomini.ID, quomini.UID, Content);
                           }
                           else if(uc.IsCommentMe==2)
                           {
                               int relation = Users.GetRelateBetweenUsers(quomini.UID,CurrentUser.ID);
                               if (relation == 1 || relation == 2)
                               {
                                   Comments.CreateNoReplyComment(CurrentUser, quomini.ID, quomini.UID, Content);
                               }
                           }
                       }
                       
                   }
               }
               if (isRoot != "null")
               {
                   MiniBlog orimini = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(oriMid));
                   if (orimini != null)
                   {
                       if (!BlackLists.IsInBlackList(orimini.UID, CurrentUser.ID))
                       {
                           UserConfig uc = Users.GetUserConfigByID(orimini.UID);
                           if (uc.IsCommentMe == 1)
                           {
                               Comments.CreateNoReplyComment(CurrentUser, orimini.ID, orimini.UID, Content);
                           }
                           else if (uc.IsCommentMe == 2)
                           {
                               int relation = Users.GetRelateBetweenUsers(orimini.UID,CurrentUser.ID);
                               if (relation == 1 || relation == 2)
                               {
                                   Comments.CreateNoReplyComment(CurrentUser, orimini.ID, orimini.UID, Content);
                               }
                           }
                       }
                   }
               }
               if (f != null)
                   MiniBlogs.CreateQuoteMiniBlog(CurrentUser,oriMid,quoMid, Content,"-1", f.ID);
               else
               {
                   MiniBlogs.CreateQuoteMiniBlog(CurrentUser,oriMid,quoMid, Content,"-1",-1);
               }
               return Json(new JsonModel(CodeStruct.QuoteSuccess, "1"));
            }
            else
                return Json(new JsonModel(CodeStruct.Error, "1"));
            
        }
        public JsonResult GetVideo(string Vid)
        {
            if (!string.IsNullOrEmpty(Vid))
            {
                if (!IsLogin) return NotLogin();
                string template = "<embed width=\"440\" height=\"356\" wmode=\"transparent\" type=\"application/x-shockwave-flash\" src=\"{0}\" quality=\"hight\" allowfullscreen=\"true\" flashvars=\"isAutoPlay=true&autoPlay=true&auto=1&adss=0\" pluginspage=\"http://get.adobe.com/cn/flashplayer/\" style=\"visibility: visible;\" allowscriptaccess=\"never\" >";
                Video v = Videos.GetVideoByID(Convert.ToInt64(Vid));
                if (v != null)
                {
                    string result = string.Format(template, v.FlvUrl);
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, new { Title=v.Title,Flv=result,Url=v.OriUrl}));
                }
            }
                return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetMusic(string MusicID)
        {
            if (!string.IsNullOrEmpty(MusicID))
            {
                if (!IsLogin) return NotLogin();
                string template = "<embed width=\"290\" height=\"40\" wmode=\"transparent\" type=\"application/x-shockwave-flash\" src=\"/MusicPlayer/player.swf\" flashvars=\"playerID=10&bg=0xf5f5f5&leftbg=0xdadada&lefticon=0xb5b5b5&rightbg=0xf1f1f1&rightbghover=0xdadada&righticon=0xb5b5b5&righticonhover=0xb5b5b5&text=0x666666&slider=0x666666&track=0xFFFFFF&border=0x666666&loader=0x9FFFB8&autostart=yes&soundFile={0}\" />";
                Music m = Musics.GetMusicByID(Convert.ToInt64(MusicID));
                if (m != null)
                {
                    string result = string.Format(template, m.MusicUrl);
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, new { Title =m.Title, Flv = result, Url = m.MusicUrl}));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetComments(string Mid, string OwnerUid)
        {
            if (!string.IsNullOrEmpty(Mid) && !string.IsNullOrEmpty(OwnerUid))
            {
                MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(Mid));
                if (miniblog != null)
                {
                    if (!IsLogin) return NotLogin();
                    AjaxGetCommentModel model = new AjaxGetCommentModel();
                    model.CurUser = CurrentUser;

                    model.miniBlog = miniblog;
                    IList<Comment> comments = Comments.GetTop10CommentsByMid(Convert.ToInt64(Mid));
                    model.comments = comments;
                    string data = RenderRazorViewToString("GetCommentsHtml", model);
                    if (!string.IsNullOrEmpty(data))
                    {
                        return Json(new JsonModel(CodeStruct.ReturnSuccess, data));
                    }
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoMiniBlogExist, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelComment(long cid)
        {
            if (!IsLogin) return NotLogin();
            if (cid > 0)
            {
                Comment comment = Comments.GetCommentByID(cid);
                if (comment != null)
                {
                    long mid = comment.MID;
                    if (Comments.DelCommentByCID(cid))
                    {
                        MiniBlog miniBlog=MiniBlogs.GetMiniBlogByID(mid);
                        if (miniBlog != null)
                        {
                            AjaxGetCommentModel model = new AjaxGetCommentModel();
                            model.CurUser = CurrentUser;

                            model.miniBlog = miniBlog;
                            IList<Comment> comments = Comments.GetTop10CommentsByMid(mid);
                            model.comments = comments;
                            string data = RenderRazorViewToString("GetCommentListHtml", model);
                            if (!string.IsNullOrEmpty(data))
                            {
                                return Json(new JsonModel(CodeStruct.DelSuccess, data));
                            }

                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult AddComment(string Mid, string OwnerUid, string content, string replyCid, string replyUid,string agree,string isRoot)
        {
            if (!IsLogin) return NotLogin();
            if (CurrentUser.LastInputContent == Utils.HtmlDecode(content)) return Json(new JsonModel(CodeStruct.RepeatContent, "1"));
            if(BlackLists.IsInBlackList(Convert.ToInt64(OwnerUid),CurrentUser.ID))
            {
                return Json(new JsonModel(CodeStruct.InBlackList, "1"));
            }
            UserConfig uc = Users.GetUserConfigByID(Convert.ToInt64(OwnerUid));
            if (uc.IsCommentMe == 2&&OwnerUid!=CurrentUser.ID.ToString())
            {
                int relation = Users.GetRelateBetweenUsers(Convert.ToInt64(OwnerUid), CurrentUser.ID);
                if (relation != 1 && relation != 2)
                {
                    return Json(new JsonModel(CodeStruct.NotCommentToSb, "1"));
                }
            }
            MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(Mid));
            if (miniblog != null)
            {
                if (agree != "null")
                {
                    var oriMid = -1.0;
                    string con = "";
                    if (replyUid == "null")
                    {
                        con = content;
                    }
                    else
                    {
                        Entity.User user = Users.GetUserByID(Convert.ToInt64(replyUid));
                        Comment relyComment = Comments.GetCommentByID(Convert.ToInt64(replyCid));
                        con = content;
                        con += "//@" + user.NickName + ":" + relyComment.Content;
                    }
                    if (miniblog.IsOriginal == 1)
                    {
                        oriMid = miniblog.ID;
                    }
                    else
                    {
                        oriMid = miniblog.OriginalMID;
                        Entity.User user = Users.GetUserByID(miniblog.UID);
                        con = con + "//@" + user.NickName+":"+ miniblog.OriginalContent;
                    }
                    con = Utils.GetStringByte(con, 280);
                    From f = Froms.GetFromByUrl(BaseConfigs.GetWebDomain);
                    MiniBlogs.CreateQuoteMiniBlog(CurrentUser,oriMid.ToString(), miniblog.ID.ToString(), Utils.HtmlDecode(con), null, f.ID);

                }
                if (isRoot != "null")
                {
                    MiniBlog oriMini=MiniBlogs.GetMiniBlogByID(miniblog.OriginalMID);
                    if(oriMini!=null)
                    Comments.CreateNoReplyComment(CurrentUser, miniblog.OriginalMID,oriMini.UID , Utils.HtmlDecode(content));
                }
                if (replyUid != "null")
                {
                    if (Comments.CreateReplyComment(CurrentUser, Convert.ToInt64(Mid), Convert.ToInt64(OwnerUid), Utils.HtmlDecode(content), Convert.ToInt64(replyCid), Convert.ToInt64(replyUid)) > 0)
                    {
                        AjaxGetCommentModel model = new AjaxGetCommentModel();
                        model.CurUser = CurrentUser;

                        model.miniBlog = miniblog;
                        IList<Comment> comments = Comments.GetTop10CommentsByMid(Convert.ToInt64(Mid));
                        model.comments = comments;
                        string data = RenderRazorViewToString("GetCommentListHtml", model);
                        if (!string.IsNullOrEmpty(data))
                        {
                            return Json(new JsonModel(CodeStruct.ReturnSuccess, data));
                        }
                    }
                }
                else
                {
                    if (Comments.CreateNoReplyComment(CurrentUser, Convert.ToInt64(Mid), Convert.ToInt64(OwnerUid), Utils.HtmlDecode(content)) > 0)
                    {
                        AjaxGetCommentModel model = new AjaxGetCommentModel();
                        model.CurUser = CurrentUser;
                        model.miniBlog = miniblog;
                        IList<Comment> comments = Comments.GetTop10CommentsByMid(Convert.ToInt64(Mid));
                        model.comments = comments;
                        string data = RenderRazorViewToString("GetCommentListHtml", model);
                        if (!string.IsNullOrEmpty(data))
                        {
                            return Json(new JsonModel(CodeStruct.ReturnSuccess, data));
                        }
                    }
                }
            }
            else
            {
                return Json(new JsonModel(CodeStruct.NoMiniBlogExist, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetPagerCommentsHtml(string Mid, string OwnerUid)
        {
            if (!string.IsNullOrEmpty(Mid) && !string.IsNullOrEmpty(OwnerUid))
            {
                MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(Mid));
                if (miniblog != null)
                {
                    if (!IsLogin) return NotLogin();
                    AjaxGetPagerCommentModel model = new AjaxGetPagerCommentModel();
                    model.CurUser = CurrentUser;

                    model.miniBlog = miniblog;
                    int recordCount=0;
                    IList<Comment> comments = Comments.GetCommentsByMid(1, 20, Convert.ToInt64(Mid), 0, 0, ref recordCount);
                    model.comments = comments;
                    string data = RenderRazorViewToString("GetPagerCommentsHtml", model);
                    if (!string.IsNullOrEmpty(data))
                    {
                        return Json(new PagerJsonModel(CodeStruct.ReturnSuccess, data,recordCount));
                    }
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoMiniBlogExist, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetPagerCommentsList(string Mid, string OwnerUid, string Page,int isFollow, string PageSize)
        {
            if (!string.IsNullOrEmpty(Mid) && !string.IsNullOrEmpty(OwnerUid))
            {
                MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(Mid));
                if (miniblog != null)
                {
                    if (!IsLogin) return NotLogin();
                    AjaxGetPagerCommentModel model = new AjaxGetPagerCommentModel();
                    model.CurUser = CurrentUser;

                    model.miniBlog = miniblog;
                    int recordCount = 0;
                    IList<Comment> comments = Comments.GetCommentsByMid(Convert.ToInt32(Page), Convert.ToInt32(PageSize), Convert.ToInt64(Mid),CurrentUser.ID,isFollow, ref recordCount);
                    model.comments = comments;
                    string data = RenderRazorViewToString("GetPagerCommentsList", model);
                    if (!string.IsNullOrEmpty(data))
                    {
                        return Json(new PagerJsonModel(CodeStruct.ReturnSuccess, data, recordCount));
                    }
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoMiniBlogExist, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddFavorite(string MID,string UID)
        {
            if (!string.IsNullOrEmpty(MID) && !string.IsNullOrEmpty(UID))
            {
                MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(Convert.ToInt64(MID));
                if (miniblog != null)
                {
                    if (!IsLogin) return NotLogin();
                    if (MiniBlogs.AddFavorite(Convert.ToInt64(MID), Convert.ToInt32(UID)) > 0)
                    {
                        return Json(new JsonModel(CodeStruct.FavoriteSuccess, "1"));
                    }
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoMiniBlogExist, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelFavorite(string MID, string UID)
        {
            if (!string.IsNullOrEmpty(MID) && !string.IsNullOrEmpty(UID))
            {
                    if (!IsLogin) return NotLogin();
                    if (MiniBlogs.DelFavorite(Convert.ToInt64(MID), Convert.ToInt32(UID)) )
                    {
                        return Json(new JsonModel(CodeStruct.FavoriteCancel, "1"));
                    }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetVoteDiaHtml()
        {
            if (!IsLogin) return NotLogin();
            IList<Vote> votes = Votes.GetVoteByUID(CurrentUser.ID);
            VotesModel model = new VotesModel();
            model.Votes = votes;
            var data=RenderRazorViewToString("GetVoteDiaHtml", model);
            return Json(new JsonModel(CodeStruct.ReturnSuccess,data));
        }


        public JsonResult CreateVote(string Title,string Remark,string ImgPid,string Options,string DisplayType,string OptionType,string OptionNum,string ExpireTime)
        {
            if (!string.IsNullOrEmpty(Title) && Options.Split(',').Length-1 > 1 && Options.Split(',').Length-1<=20)
            {
                if (!IsLogin) return NotLogin();
                Vote vote = new Vote();
                vote.Title =Utils.HtmlDecode(Title);
                vote.Remark = string.IsNullOrEmpty(Remark)?null:Utils.HtmlDecode(Remark);
                vote.ResultVisible = Convert.ToInt16(DisplayType);
                vote.ExpireTime = DateTime.Parse(ExpireTime);
                if (OptionType == "2")
                {
                    int onceSelCount= Convert.ToInt16(OptionNum);
                    int optionCount=Options.Split(',').Length ;
                    if (optionCount < onceSelCount)
                        vote.OnceSelCount = optionCount;
                    else
                        vote.OnceSelCount = onceSelCount;
                }
                else
                    vote.OnceSelCount = -1;
                vote.OptionCount = 0;
                if (!string.IsNullOrEmpty(ImgPid))
                {
                    Pic pic = Pics.GetPicByID(Convert.ToInt32(ImgPid));
                    if (pic != null)
                    {
                        vote.PID = pic.ID;
                    }
                }
                vote.Type = Convert.ToInt16(OptionType);
                vote.UID = CurrentUser.ID;
                long vid = Votes.CreateVote(vote);
                if (vid > 0)
                {
                    string[] OptArray= Options.Split(',');
                    for (int i = 0; i < OptArray.Length-1; i++)
                    {
                        VoteOption vp = new VoteOption();
                        vp.Name =Utils.HtmlDecode(OptArray[i]);
                        vp.VID = vid;
                        VoteOptions.CreateVoteOption(vp);
                    }
                    return Json(new JsonModel(CodeStruct.CreateSuccess, string.Format("我发起了一个投票【{0}】，地址 {1} ",Title,BaseConfigs.GetWebDomain+"/Vote/"+vid.ToString())));
                }
            }

            return Json(new JsonModel(CodeStruct.Error,"1"));
        }

        public JsonResult GetVoteFeedHtml(string mid, string vid)
        {
            if (!string.IsNullOrEmpty(mid) && !string.IsNullOrEmpty(vid))
            {
                if (!IsLogin) return NotLogin();
                Vote vote = Votes.GetVoteByID(Convert.ToInt64(vid));
                if (vote != null)
                {
                    MiniBlog miniBlog=MiniBlogs.GetMiniBlogByID(Convert.ToInt64(mid));
                    if (miniBlog != null)
                    {
                        Entity.User user = Users.GetUserByID(miniBlog.UID);
                        if (user != null)
                        {
                            AjaxGetVoteFeedModel model = new AjaxGetVoteFeedModel();
                            model.Vote = vote;
                            IList<VoteOption> options = VoteOptions.GetVoteOptionsByVID(vote.ID);
                            if (options != null)
                            {
                                model.Options = options;
                                model.CurUser = CurrentUser;
                                model.QuoUser = user;
                                Entity.User publishUser = Users.GetUserByID(vote.UID);
                                if (publishUser != null)
                                {
                                    model.PublishUser = publishUser;
                                    string data = RenderRazorViewToString("GetVoteFeedHtml", model);
                                    return Json(new VoteJsonModel(CodeStruct.ReturnSuccess, data,vote.Title,BaseConfigs.GetWebDomain+"/Vote/"+vote.ID.ToString()));
                                }
                            }
                        }
                    }

                }
                
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult JoinVote(string vid, string selItemIDs,string niMing,string feedMiniBlog)
        {
            if (!string.IsNullOrEmpty(vid) && !string.IsNullOrEmpty(selItemIDs))
            {
                if (!IsLogin) return NotLogin();
                Vote vote = Votes.GetVoteByID(Convert.ToInt64(vid));
                if (vote != null)
                {
                    if (VoteJoins.GetVoteJoinByUID(CurrentUser.ID, Convert.ToInt64(vid)) == null)
                    {
                        string[] idArray = selItemIDs.Split(',');
                        string selNameNames = "";
                        for (int i = 0; i < idArray.Length - 1; i++)
                        {
                            VoteOption option = VoteOptions.GetVoteOptionByID(Convert.ToInt64(idArray[i]));
                            selNameNames += option.Name + ",";
                        }
                        VoteJoin join = new VoteJoin();
                        join.IsAnonymous = string.IsNullOrEmpty(niMing) ? 0 : 1;
                        join.SelVoteItemIDs = selItemIDs;
                        join.SelVoteItemNames = selNameNames;
                        join.UID = CurrentUser.ID;
                        join.VID = Convert.ToInt64(vid);
                        if (VoteJoins.CreateVoteJoin(join) > 0)
                        {
                            if (!string.IsNullOrEmpty(feedMiniBlog))
                            {
                                var mbContent = string.Format("给你们介绍一个投票【{1}】，地址：{0}", BaseConfigs.GetWebDomain + "/Vote/" + vid, vote.Title);
                                From f = Froms.GetFromByUrl(BaseConfigs.GetWebDomain);
                                MiniBlogs.CreateOriginalMiniBlog(CurrentUser, mbContent, "-1", f.ID);
                            }
                                return Json(new JsonModel(CodeStruct.VoteSuccess, "1"));
                        }
                    }
                }

            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult SaveTheme(string Color, string Border, string Lock, string Pid,string Repeat,string Align,string UseBg,string ThemeId)
        {
            if (!string.IsNullOrEmpty(Color) && !string.IsNullOrEmpty(Border) && !string.IsNullOrEmpty(Lock) && !string.IsNullOrEmpty(Pid) && !string.IsNullOrEmpty(Repeat) && !string.IsNullOrEmpty(Align) && !string.IsNullOrEmpty(UseBg) && !string.IsNullOrEmpty(ThemeId))
            {
                if (!IsLogin) return NotLogin();
                if (Convert.ToInt64(ThemeId) < 0)
                {
                    ThemeDIY diy = Themes.GetThemeDIYByUID(CurrentUser.ID);
                    bool isCreate = false;
                    if (diy == null)
                    {
                        diy = new ThemeDIY();
                        diy.BgImgPid = -1;
                        diy.UID = CurrentUser.ID;
                        isCreate = true;
                    }

                    diy.AlignStyleBg = Align == "left" ? 1 : (Align == "center" ? 2 : 3);
                    string[] colors = Color.Split(',');
                    diy.BgColor = colors[0];
                    if (UseBg == "true")
                    {
                        diy.BgImgPid = Convert.ToInt64(Pid);
                    }
                    diy.BorderStyle = Border;
                    diy.ContentColor = colors[5];
                    diy.IsLockBg = Lock == "scroll" ? 0 : 1;
                    diy.IsRepeatBg = Repeat == "repeat" ? 1 : 0;
                    diy.IsUseBg = UseBg == "true" ? 1 : 0;
                    diy.MainLinkColor = colors[2];
                    diy.MainTxtColor = colors[1];
                    diy.SubLinkColor = colors[4];
                    diy.SubTxtColor = colors[3];
                    if (isCreate)
                    {
                        if (Themes.CreateThemeDIY(diy) > 0)
                        {
                            UserConfig uc = Users.GetUserConfigByID(CurrentUser.ID);
                            if (uc != null)
                            {
                                uc.IsThemeDIY = 1;
                                if (Users.UpdateUserConfig(uc))
                                {
                                    return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Themes.UpdateThemeDIY(diy))
                        {
                            UserConfig uc = Users.GetUserConfigByID(CurrentUser.ID);
                            if (uc != null)
                            {
                                uc.IsThemeDIY = 1;
                                if (Users.UpdateUserConfig(uc))
                                {
                                    return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                                }
                            }
                        }
                    }
                }
                else
                {
                    UserConfig uc = Users.GetUserConfigByID(CurrentUser.ID);
                    if (uc != null)
                    {
                        uc.IsThemeDIY = 0;
                        uc.ThemeID = Convert.ToInt32(ThemeId);
                        if (Users.UpdateUserConfig(uc))
                        {
                            return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                        }
                    }
                }
            }
           
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddGroup(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (!IsLogin) return NotLogin();
                Group g = Groups.GetGroupByName(CurrentUser.ID, Name);
                if (g == null)
                {
                    g = new Group();
                    g.UID = CurrentUser.ID;
                    g.Name = Name;
                    Group sortG = Groups.GetTopSort(CurrentUser.ID);
                    if (sortG != null)
                    {
                        g.Sort = sortG.Sort + 1;
                    }
                    else
                    {
                        g.Sort = 1;
                    }
                    long gid=Groups.CreateGroup(g);
                    Group newg = Groups.GetGroupByID(gid);
                    if (newg != null)
                        return Json(new JsonModel(CodeStruct.CreateSuccess, newg));
                }
                else
                    return Json(new JsonModel(CodeStruct.ExistGroup, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult SortGroup(string gids)
        {
            if (!IsLogin) return NotLogin();
            if (!string.IsNullOrEmpty(gids))
            {
                if (Groups.UpdateGroupSort(gids, CurrentUser.ID))
                {
                    return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult GetAllGroup(long fuid)
        {
            if (!IsLogin) return NotLogin();
            long uid = CurrentUser.ID;
            IList<Group> allGroups = Groups.GetGroupsByUID(uid);
            if (allGroups != null)
            {
                if (fuid > 0)
                {
                    Follow follow = Users.GetFollowByFuid(fuid, uid);
                    if (follow != null)
                    {
                        IList<object> temp = new List<object>();
                        foreach (Group g in allGroups)
                        {
                            if (!string.IsNullOrEmpty(follow.GroupIDs) && follow.GroupIDs.Contains("a" + g.ID + "a"))
                            {
                                temp.Add(new { ID = g.ID, Name = g.Name, IsSet = 1 });
                            }
                            else
                            {
                                temp.Add(new { ID = g.ID, Name = g.Name, IsSet = 0 });
                            }
                        }
                        return Json(new JsonModel(CodeStruct.ReturnSuccess, temp));
                    }
                }
                else
                return Json(new JsonModel(CodeStruct.ReturnSuccess, allGroups));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditGroupName(string Name, string Gid)
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Gid))
            {
                if (!IsLogin) return NotLogin();
                Group g = Groups.GetGroupByName(CurrentUser.ID, Name);
                if (g == null)
                {
                    Group editG = Groups.GetGroupByID(Convert.ToInt64(Gid));
                    if (editG != null)
                    {
                        if (Groups.UpdateGroupName(Convert.ToInt64(Gid), Name))
                            return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                    }
                }
                else
                    return Json(new JsonModel(CodeStruct.ExistGroup, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetFollowListByKey(string key)
		{
			if (!string.IsNullOrEmpty(key))
			{
				if (!IsLogin) return NotLogin();
				int recordCount=0;
				string where = string.Format("NickName like '%{0}%' or NickName like '{0}' or NickName like '%{0}' or NickName like '{0}%' or Remark like '%{0}%' or Remark like '{0}' or Remark like '%{0}' or Remark like '{0}%'",key);
				IList<Follow> follows = Users.GetMyFollowByPager(CurrentUser.ID,1,10,where ,"CreateTime",ref recordCount);
				if (follows != null && follows.Count > 0)
				{
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
					for (int i = 0; i < follows.Count; i++)
					{
                        AutoCompleteModel auto = new AutoCompleteModel();
						if (!string.IsNullOrEmpty(follows[i].Remark))
						{
							auto.Title = follows[i].NickName + "(" + follows[i].Remark + ")";
						}
                        else
                        {
                            auto.Title=follows[i].NickName;
                        }
                        auto.NickName = follows[i].NickName;
                        auto.ID = follows[i].ID;
                        autos.Add(auto);
					}
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
				}
				else
				{
					return Json(new JsonModel(CodeStruct.NoResult, "1"));
				}

			}
			return Json(new JsonModel(CodeStruct.Error, "1"));
		}

		public JsonResult GetFanListByKey(string key)
		{
			if (!string.IsNullOrEmpty(key))
			{
				if (!IsLogin) return NotLogin();
				int recordCount = 0;
				string where = string.Format("NickName like '%{0}%' or NickName like '{0}' or NickName like '%{0}' or NickName like '{0}%' ", key);
				IList<Fans> fans = Users.GetMyFanByPager(CurrentUser.ID,1, 10, where, "CreateTime", ref recordCount);
                if (fans != null && fans.Count > 0)
                {
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
                    for (int i = 0; i < fans.Count; i++)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();

                        auto.Title = fans[i].NickName;

                        auto.NickName = fans[i].NickName;
                        auto.ID = fans[i].ID;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }

			}
			return Json(new JsonModel(CodeStruct.Error, "1"));
		}

        public JsonResult GetFollowByAssignBox(string type, string gid, string page, string pagesize)
        {
            if (!string.IsNullOrEmpty(gid) && !string.IsNullOrEmpty(gid))
            {
                if (!IsLogin) return NotLogin();
                int recordCount = 0;
                string where = "";
                IList<Follow> follows = null;
                int Page = Convert.ToInt16(page);
                int PageSize = Convert.ToInt16(pagesize);
                if (type == "all")
                {
                    where = "";
                    
                }
                else if (type == "ng")
                {
                    where = "GroupIDs='' or GroupIDs is null";

                }
                else
                {
                    where = string.Format("GroupIDs like '%a{0}a%' or GroupIDs like 'a{0}a%'", gid);
                }
                follows = Users.GetMyFollowByPager(CurrentUser.ID, Page, PageSize, where, "CreateTime", ref recordCount);
                if (follows != null &&follows.Count>0)
                {
                    IList<simpleFollowModel> autos = new List<simpleFollowModel>();
                    for (int i = 0; i < follows.Count; i++)
                    {
                        simpleFollowModel auto = new simpleFollowModel();
                        if (!string.IsNullOrEmpty(follows[i].Remark))
                        {
                            auto.Title = follows[i].NickName + "(" + follows[i].Remark + ")";
                        }
                        else
                        {
                            auto.Title = follows[i].NickName;
                        }
                        auto.NickName = follows[i].NickName;
                        auto.ID = follows[i].ID;
                        auto.avatar = follows[i].MidAvartar;
                        autos.Add(auto);
                    }
                    return Json(new PagerJsonModel(CodeStruct.ReturnSuccess, autos,recordCount));

                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
              
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AssignFollowsToGroup(string gid,string follows)
        {
            if (!string.IsNullOrEmpty(gid) && !string.IsNullOrEmpty(follows))
            {
                if (!IsLogin) return NotLogin();
                string[] followArr = follows.Split(',');
                for (int i = 0; i < followArr.Length-1; i++)
                {
                    Follow follow = Users.GetFollowByFuid(Convert.ToInt64(followArr[i]), CurrentUser.ID);
                    if (follow != null)
                    {
                        if (string.IsNullOrEmpty(follow.GroupIDs)||!follow.GroupIDs.Contains("a" + gid + "a"))
                        {
                            string groupIDs = follow.GroupIDs + "a" + gid.ToString() + "a,";
                            Users.UpdateFollowGroupID(Convert.ToInt64(followArr[i]), CurrentUser.ID, groupIDs);
                        }
                    }
                }
                return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelGroup(string gid)
        {
            if (!string.IsNullOrEmpty(gid))
            {
                if (!IsLogin) return NotLogin();
                Group group = Groups.GetGroupByID(Convert.ToInt64(gid));
                if (group != null)
                {
                    if(Groups.DelGroup(Convert.ToInt64(gid)))
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult SetGroup(string gids,string remark,long fuid)
        {
            if (fuid>0)
            {
                if (!IsLogin) return NotLogin();
                if (!string.IsNullOrEmpty(gids))
                {
                    string[] gs = gids.Split(',');
                    gids = "";
                    foreach (string g in gs)
                    {
                        if (!string.IsNullOrEmpty(g))
                        {
                            Group group = Groups.GetGroupByID(Convert.ToInt64(g));
                            if (group != null)
                            {
                                gids += "a" + group.ID + "a,";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(gids))
                    {
                        Users.UpdateFollowGroupID(fuid, CurrentUser.ID, gids);
                    }
                }
                else
                {
                    Users.UpdateFollowGroupID(fuid, CurrentUser.ID, "");
                }
                if (!string.IsNullOrEmpty(remark))
                {
                    Users.UpdateFollowRemark(fuid, CurrentUser.ID, remark);
                }
                return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditFollowGroup(string uid, string gid)
        {
            if (!string.IsNullOrEmpty(gid)&&!string.IsNullOrEmpty(uid))
            {
                if (!IsLogin) return NotLogin();
                Group group = Groups.GetGroupByID(Convert.ToInt64(gid));
                if (group != null)
                {
                    IList<Group> allGroups=Groups.GetGroupsByUID(CurrentUser.ID);
                    if (allGroups != null)
                    {
                        Follow follow = Users.GetFollowByFuid(Convert.ToInt64(uid), CurrentUser.ID);
                        if (follow != null)
                        {
                            if (follow.GroupIDs!=null&&follow.GroupIDs.Contains("a" + gid + "a"))
                                return Json(new JsonModel(CodeStruct.SaveSuccess, Groups.GetGroupsString(follow.GroupIDs, allGroups, 14) + "|" + follow.GroupIDs));
                            else
                            {
                                string groupIds = follow.GroupIDs + "a" + gid + "a,";
                                if(Users.UpdateFollowGroupID(Convert.ToInt64(uid),CurrentUser.ID,groupIds))
                                {
                                    return Json(new JsonModel(CodeStruct.SaveSuccess, Groups.GetGroupsString(groupIds, allGroups, 14) + "|" + groupIds));
                                }
                            }
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }


        public JsonResult DelFollowGroup(string uid, string gid)
        {
            if (!string.IsNullOrEmpty(gid) && !string.IsNullOrEmpty(uid))
            {
                if (!IsLogin) return NotLogin();
                Group group = Groups.GetGroupByID(Convert.ToInt64(gid));
                if (group != null)
                {
                    IList<Group> allGroups = Groups.GetGroupsByUID(CurrentUser.ID);
                    if (allGroups != null)
                    {
                        Follow follow = Users.GetFollowByFuid(Convert.ToInt64(uid), CurrentUser.ID);
                        if (follow != null)
                        {
                            if (string.IsNullOrEmpty(follow.GroupIDs)||!follow.GroupIDs.Contains("a" + gid + "a"))
                            {
                                if(string.IsNullOrEmpty(follow.GroupIDs))
                                    return Json(new JsonModel(CodeStruct.SaveSuccess,"未分组|"));
                                else
                                return Json(new JsonModel(CodeStruct.SaveSuccess, Groups.GetGroupsString(follow.GroupIDs, allGroups, 14) + "|" + follow.GroupIDs));
                            }
                            else
                            {
                                string groupIds = follow.GroupIDs.Replace("a" + gid + "a,","");
                                if (Users.UpdateFollowGroupID(Convert.ToInt64(uid), CurrentUser.ID, groupIds))
                                {
                                    if (string.IsNullOrEmpty(follow.GroupIDs))
                                        return Json(new JsonModel(CodeStruct.SaveSuccess, "未分组|"));
                                    else
                                    return Json(new JsonModel(CodeStruct.SaveSuccess, Groups.GetGroupsString(groupIds, allGroups, 14) + "|" + groupIds));
                                }
                            }
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult EditRemark(string uid, string remark)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                if (!IsLogin) return NotLogin();
                Follow follow = Users.GetFollowByFuid(Convert.ToInt64(uid), CurrentUser.ID);
                if (follow != null) 
                {
                    if (Users.UpdateFollowRemark(Convert.ToInt64(uid), CurrentUser.ID, remark))
                    {
                        return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult CreateMessage(string NickName, string Content)
        {
            if (!string.IsNullOrEmpty(NickName) && !string.IsNullOrEmpty(Content))
            {
                Content = Utils.HtmlDecode(Content);
                if (!IsLogin) return NotLogin();
                User talkUser = Users.GetUserByNickName(NickName);
                if (talkUser != null)
                {
                    if (talkUser.ID == CurrentUser.ID)
                    {
                        return Json(new JsonModel(CodeStruct.MessageMyself, "1"));
                    }

                    if (BlackLists.IsInBlackList(talkUser.ID, CurrentUser.ID))
                    {
                        return Json(new JsonModel(CodeStruct.InBlackList, "1"));
                    }
                    UserConfig uc=Users.GetUserConfigByID(talkUser.ID);
                    if (uc.IsMsgMe == 2)
                    {
                        int relation = Users.GetRelateBetweenUsers(talkUser.ID, CurrentUser.ID);
                        if (relation != 1 && relation != 2)
                        {
                            return Json(new JsonModel(CodeStruct.NotMsgToSb, "1"));
                        }
                    }

                   Message message=new Message();
                    message.Content=Content;
                    message.ToUID=talkUser.ID;
                    message.UID=CurrentUser.ID;
                   if(Messages.CreateMessage(message)>0)
                   {
                       return Json(new JsonModel(CodeStruct.CreateSuccess, "1"));
                   }
                }
                else
                return Json(new JsonModel(CodeStruct.NoUserExist, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult SaveUserBaseInfo(string nick,string real,string isreal,string location,string sex,string birth,string isbirth,string isblog,string blog,string email,string isemail,string qq,string isqq,string msn,string ismsn,string dec) 
        {
            if (!IsLogin) return NotLogin();
            Entity.User saveUser=CurrentUser;
            saveUser.NickName = nick;
            saveUser.RealName = real;
            saveUser.RealNameVisible = Convert.ToInt32(isreal);
            saveUser.Location = Convert.ToInt32(location);
            saveUser.Sex = Convert.ToInt32(sex);
            saveUser.BirthDay = Convert.ToDateTime(birth);
            saveUser.BirthDayVisible = Convert.ToInt32(isbirth);
            saveUser.Blog = blog;
            saveUser.BlogVisible = Convert.ToInt32(isblog);
            saveUser.ContactEmail = email;
            saveUser.ContactEmailVisible = Convert.ToInt32(isemail);
            saveUser.QQ = qq;
            saveUser.QQVisible = Convert.ToInt32(isqq);
            saveUser.MSN = msn;
            saveUser.MSNVisible = Convert.ToInt32(ismsn);
            saveUser.Description = dec;
            if (Users.UpadateUser(saveUser))
            {
                return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult EditPwd(string oldpwd,string newpwd)
        {
            if (!string.IsNullOrEmpty(oldpwd) && !string.IsNullOrEmpty(newpwd))
            {
                if (!IsLogin) return NotLogin();
                if (CurrentUser.Password != (BaseConfigs.GetPwdEncodeType == "AES" ? AES.Encode(oldpwd, BaseConfigs.GetPwdEncodeKey) : DES.Encode(oldpwd, BaseConfigs.GetPwdEncodeKey)))
                {
                    return Json(new JsonModel(CodeStruct.WrongPwd, "1"));
                }
                else
                {
                    Entity.User newUser = CurrentUser;
                    newUser.Password = BaseConfigs.GetPwdEncodeType == "AES" ? AES.Encode(newpwd, BaseConfigs.GetPwdEncodeKey) : DES.Encode(newpwd, BaseConfigs.GetPwdEncodeKey);
                    if (Users.UpadateUser(newUser))
                    {
                        Utils.WriteCookie("weibo", "PWD",Utils.UrlEncode(newUser.Password));
                        return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult CreateCareer(string companyName,string remark,string isVisible,string location,string startdate,string enddate)
        {
            if (!string.IsNullOrEmpty(companyName))
            {
                if (!IsLogin) return NotLogin();
                Company company = Companies.GetCompanysByName(companyName);
                if (company == null)
                {
                    company = new Company();
                    company.Name = companyName;
                    company.ID=Companies.CreateCompany(company);
                    if (!(company.ID > 0))
                    {
                        return Json(new JsonModel(CodeStruct.Error, "1"));
                    }
                }
                Career career = new Career();
                career.CompanyID = company.ID;
                career.CompanyName = company.Name;
                career.StartDate = startdate;
                career.Position = remark;
                career.IsVisible = Convert.ToInt32(isVisible);
                career.Location = Convert.ToInt32(location);
                career.EndDate = enddate;
                career.UID = CurrentUser.ID;
                career.ID=Careers.CreateCareer(career);
                if (career.ID > 0)
                {
                    if (Users.UpdateUserCompanies(CurrentUser.ID))
                    {
                        string data = RenderRazorViewToString("GetCareerHtml", career);
                        return Json(new JsonModel(CodeStruct.CreateSuccess, data));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditCareer(string careerid,string companyName, string remark, string isVisible, string location, string startdate, string enddate)
        {
            if (!string.IsNullOrEmpty(companyName))
            {
                if (!IsLogin) return NotLogin();
                Career career = Careers.GetCareerByID(Convert.ToInt64(careerid));
                if (career != null)
                {
                    Company company = Companies.GetCompanysByName(companyName);
                    if (company == null)
                    {
                        company = new Company();
                        company.Name = companyName;
                        company.ID = Companies.CreateCompany(company);
                        if (!(company.ID > 0))
                        {
                            return Json(new JsonModel(CodeStruct.Error, "1"));
                        }
                    }
                    career.CompanyID = company.ID;
                    career.CompanyName = company.Name;
                    career.StartDate = startdate;
                    career.Position = remark;
                    career.IsVisible = Convert.ToInt32(isVisible);
                    career.Location = Convert.ToInt32(location);
                    career.EndDate = enddate;
                    career.UID = CurrentUser.ID;
                    if (Careers.UpdateCareer(career))
                    {
                        if (Users.UpdateUserCompanies(CurrentUser.ID))
                        {
                            string data = RenderRazorViewToString("GetCareerHtml", career);
                            return Json(new JsonModel(CodeStruct.SaveSuccess, data));
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelCareer(string careerid)
        {
            if (!string.IsNullOrEmpty(careerid))
            {
                if (!IsLogin) return NotLogin();
                if (Careers.DelCareer(Convert.ToInt64(careerid)))
                {
                    if(Users.UpdateUserCompanies(CurrentUser.ID))
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
                }
                
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult autoCompleteCompany(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!IsLogin) return NotLogin();
                IList<Company> companies = Companies.GetCompanysByLikeName(key);
                if (companies != null)
                {
                    IList<AutoCompleteModel> autos=new List<AutoCompleteModel>();
                    foreach (Company company in companies)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();
                        auto.ID = company.ID;
                        auto.Title = company.Name;
                        auto.NickName = company.Name;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult getCareerDetail(string careerid)
        {
            if (!string.IsNullOrEmpty(careerid))
            {
                if (!IsLogin) return NotLogin();
                Career career = Careers.GetCareerByID(Convert.ToInt64(careerid));
                if (career != null)
                {
                    Company company = Companies.GetCompanyByID(career.CompanyID);
                    if (company != null)
                    {
                        int city =-1;
                      int province =-1;
                        Weibo.Entity.Type type = Types.GetTypeByID(career.Location);
                        if (type != null)
                        {
                            if (type.PID == TypeConfigs.GetCityRoot)
                            {
                                province = type.ID;
                                city = -1;
                            }
                            else
                            {
                                city = type.ID;
                                province = type.PID;
                            }
                        }
                        object o = new { cname =company.Name,city=city,province=province,remark=career.Position,start=career.StartDate,end=career.EndDate,isvisible=career.IsVisible };
                        return Json(new JsonModel(CodeStruct.ReturnSuccess,o));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult cutAvatar(string imgSrc, string x, string y, string x1, string y1, string zoom)
        {
            if (!string.IsNullOrEmpty(imgSrc) && !string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(y) && !string.IsNullOrEmpty(x1) && !string.IsNullOrEmpty(y1) && !string.IsNullOrEmpty(zoom))
            {
                if (!IsLogin) return NotLogin();
                try
                {
                    int dx = Convert.ToInt32(x);
                    int dy = Convert.ToInt32(y);
                    int dx1 = Convert.ToInt32(x1);
                    int dy1 = Convert.ToInt32(y1);
                    double dzoom = Convert.ToDouble(zoom);
                    string exe = Path.GetExtension(imgSrc);
                    Image image = Image.FromFile(Server.MapPath(imgSrc));
                    int width = dx1 - dx;
                    int height = dy1 - dy;
                    if (dzoom != 1)
                    {
                        width = (int)((dx1 - dx) * dzoom);
                        height = (int)((dy1 - dy) * dzoom);
                        dx = (int)(dx * dzoom);
                        dy = (int)(dy * dzoom);
                    }

                    Image cutedImage = new System.Drawing.Bitmap(180, 180);
                    Graphics g = Graphics.FromImage(cutedImage);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Clear(Color.White);
                    g.DrawImage(image, new Rectangle(0, 0, cutedImage.Width, cutedImage.Height), new Rectangle(dx, dy, width, height), System.Drawing.GraphicsUnit.Pixel);

                    string dir = BaseConfigs.GetAvartarUploadPath+"180/" + CurrentUser.ID.ToString() + "/";
                    string fulldir = Server.MapPath(dir);
                    if (!Directory.Exists(fulldir))
                    {
                        Directory.CreateDirectory(fulldir);
                    }
                    string saveOriPath = dir + Guid.NewGuid().ToString() + exe;
                    cutedImage.Save(Server.MapPath(saveOriPath));
                    cutedImage.Dispose();
                    g.Dispose();

                    cutedImage = new System.Drawing.Bitmap(50, 50);
                    g = Graphics.FromImage(cutedImage);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Clear(Color.White);
                    g.DrawImage(image, new Rectangle(0, 0, cutedImage.Width, cutedImage.Height), new Rectangle(dx, dy, width, height), System.Drawing.GraphicsUnit.Pixel);

                    dir = BaseConfigs.GetAvartarUploadPath+"50/" + CurrentUser.ID.ToString() + "/";
                    fulldir = Server.MapPath(dir);
                    if (!Directory.Exists(fulldir))
                    {
                        Directory.CreateDirectory(fulldir);
                    }
                    string saveMidPath = dir + Guid.NewGuid().ToString() + exe;
                    cutedImage.Save(Server.MapPath(saveMidPath));
                    cutedImage.Dispose();
                    g.Dispose();

                    cutedImage = new System.Drawing.Bitmap(30, 30);
                    g = Graphics.FromImage(cutedImage);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Clear(Color.White);
                    g.DrawImage(image, new Rectangle(0, 0, cutedImage.Width, cutedImage.Height), new Rectangle(dx, dy, width, height), System.Drawing.GraphicsUnit.Pixel);

                    dir = BaseConfigs.GetAvartarUploadPath+"30/" + CurrentUser.ID.ToString() + "/";
                    fulldir = Server.MapPath(dir);
                    if (!Directory.Exists(fulldir))
                    {
                        Directory.CreateDirectory(fulldir);
                    }
                    string saveSmallPath = dir + Guid.NewGuid().ToString() + exe;
                    cutedImage.Save(Server.MapPath(saveSmallPath));
                    cutedImage.Dispose();
                    g.Dispose();
                    image.Dispose();

               

                    User saveUser = CurrentUser;
                    saveUser.SmallAvartar = saveSmallPath;
                    saveUser.MidAvartar = saveMidPath;
                    saveUser.BigAvartar = saveOriPath;
                    if (Users.UpadateUser(saveUser))
                    {
                        return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                    }

                }
                catch(Exception ex)
                {
                    return Json(new JsonModel(CodeStruct.Error, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetShoolsByLetLocType(string letter, string location, string type)
		{
            if (!string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(type))
			{
                IList<School> schools = Schools.GetShoolsByLetLocType(Convert.ToInt32(location), letter,Convert.ToInt32(type));
				if (schools != null)
				{
					return Json(new JsonModel(CodeStruct.ReturnSuccess, schools));
				}
				else
				{
					return Json(new JsonModel(CodeStruct.NoResult, "1"));
				}
			}
			return Json(new JsonModel(CodeStruct.Error, "1"));
		}

        public JsonResult autoCompleteSchool(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!IsLogin) return NotLogin();
                IList<School> schools = Schools.GetSchoolsByLikeName(key);
                if (schools != null)
                {
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
                    foreach (School school in schools)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();
                        auto.ID = school.ID;
                        auto.Title = school.Name;
                        auto.NickName = school.Name;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult CreateEducation(string isVisible, string schoolType, string schoolName,string schoolId, string startdate, string remark)
        {
            if (!string.IsNullOrEmpty(schoolId) && !string.IsNullOrEmpty(schoolType) && !string.IsNullOrEmpty(schoolName))
            {
                if (!IsLogin) return NotLogin();
                School school = Schools.GetSchoolByID(Convert.ToInt32(schoolId));
                if (school != null)
                {
                    if (school.Name == schoolName)
                    {
                        Education education = new Education();
                        education.IsVisible = Convert.ToInt32(isVisible);
                        education.Remark = remark;
                        education.SchoolID = Convert.ToInt32(schoolId);
                        education.SchoolName = schoolName;
                        education.StartDate = startdate;
                        education.Type = Convert.ToInt32(schoolType);
                        education.UID = CurrentUser.ID;
                        education.ID = Educations.CreateEducation(education);
                        if (education.ID > 0)
                        {
                            if (Users.UpdateUserSchools(CurrentUser.ID))
                            {
                                string data = RenderRazorViewToString("GetEducationHtml", education);
                                return Json(new JsonModel(CodeStruct.CreateSuccess, data));
                            }
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditEducation(string educationId,string isVisible, string schoolType, string schoolName, string schoolId, string startdate, string remark)
        {
            if (!string.IsNullOrEmpty(schoolId) && !string.IsNullOrEmpty(schoolType) && !string.IsNullOrEmpty(schoolName) && !string.IsNullOrEmpty(educationId))
            {
                if (!IsLogin) return NotLogin();
                School school = Schools.GetSchoolByID(Convert.ToInt32(schoolId));
                if (school != null)
                {
                    if (school.Name == schoolName)
                    {
                        Education education = Educations.GetEducationByID(Convert.ToInt64(educationId));
                        if (education != null)
                        {
                            education.IsVisible = Convert.ToInt32(isVisible);
                            education.Remark = remark;
                            education.SchoolID = Convert.ToInt32(schoolId);
                            education.SchoolName = schoolName;
                            education.StartDate = startdate;
                            education.Type = Convert.ToInt32(schoolType);
                            education.UID = CurrentUser.ID;
                            if (Educations.UpdateEducation(education))
                            {
                                if (Users.UpdateUserSchools(CurrentUser.ID))
                                {
                                    string data = RenderRazorViewToString("GetEducationHtml", education);
                                    return Json(new JsonModel(CodeStruct.SaveSuccess, data));
                                }
                            }
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelEducation(string educationId)
        {
            if (!string.IsNullOrEmpty(educationId))
            {
                if (!IsLogin) return NotLogin();
                if (Educations.DelEducation(Convert.ToInt64(educationId)))
                {
                    if (Users.UpdateUserSchools(CurrentUser.ID))
                        return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
                }

            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

   
        public JsonResult getEducationDetail(string educationId)
        {
            if (!string.IsNullOrEmpty(educationId))
            {
                if (!IsLogin) return NotLogin();
                Education education = Educations.GetEducationByID(Convert.ToInt64(educationId));
                if (education != null)
                {
                    School school = Schools.GetSchoolByID(education.SchoolID);
                    if (school != null)
                    {
                        object o = new {IsVisible= education.IsVisible,Remark= education.Remark,SchoolID=education.SchoolID,SchoolName=education.SchoolName,StartDate= education.StartDate,Type=education.Type};
                        return Json(new JsonModel(CodeStruct.ReturnSuccess, o));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddTagByID(string tagid)
        {
            if (!string.IsNullOrEmpty(tagid))
            {
                if (!IsLogin) return NotLogin();
                long curUID = CurrentUser.ID;
                if (Tags.GetUserTagCount(curUID) == 10)
                {
                    return Json(new JsonModel(CodeStruct.ExceedTags, "1"));
                }
                Tag t = Tags.GetTagByID(Convert.ToInt64(tagid));
                if (t != null)
                {
                    UserTag ut = Tags.GetUserTagByUidTagid(curUID, t.ID);
                    if (ut == null)
                    {
                        ut = new UserTag();
                        ut.TagID = t.ID;
                        ut.TagName = t.Name;
                        ut.UID = curUID;
                        ut.ID=Tags.CreateUserTag(ut) ;
                        if (ut.ID > 0)
                        {
                            Tags.UpdateTagForRefCount(t.ID);
                            if (Users.UpdateUserTags(curUID))
                            {
                                return Json(new JsonModel(CodeStruct.CreateSuccess, ut));
                            }
                        }
                    }
                    return Json(new JsonModel(CodeStruct.ExistTag, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddTags(string tags)
        {
            if (!string.IsNullOrEmpty(tags))
            {
                if (!IsLogin) return NotLogin();
                long curUID = CurrentUser.ID;
                int curTagCount = Tags.GetUserTagCount(curUID);
                if (curTagCount == 10)
                {
                    return Json(new JsonModel(CodeStruct.ExceedTags, "1"));
                }
                string[] tagStrs = tags.Split(',');
                IList<UserTag> tagList = new List<UserTag>();
                foreach (string tagStr in tagStrs)
                {
                    if (string.IsNullOrEmpty(tagStr))
                        continue;
                    Tag tag = Tags.GetTagByName(tagStr);
                    if (tag == null)
                    {
                        tag = new Tag();
                        tag.Name = tagStr;
                        tag.ID = Tags.CreateTag(tag);
                        if (tag.ID < 0)
                        {
                            return Json(new JsonModel(CodeStruct.Error, "1"));
                        }
                    }
                    if (curTagCount == 10)
                    {
                        break;
                    }
                    UserTag ut = Tags.GetUserTagByNameUID(tagStr, curUID);
                    if (ut != null)
                    {
                        continue;
                    }
                    else
                    {
                        ut = new UserTag();
                        ut.UID = curUID;
                        ut.TagName = tagStr;
                        ut.TagID = tag.ID;
                        ut.ID = Tags.CreateUserTag(ut);
                        if (ut.ID > 0)
                        {
                            tagList.Add(ut);
                            curTagCount++;
                            Tags.UpdateTagForRefCount(tag.ID);
                        }
                    }

                }
                if (tagList.Count > 0)
                {
                    if (Users.UpdateUserTags(curUID))
                    {
                        return Json(new JsonModel(CodeStruct.CreateSuccess, tagList));
                    }
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.ExceedTags, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                if (!IsLogin) return NotLogin();
                long curUID = CurrentUser.ID;
                int curTagCount = Tags.GetUserTagCount(curUID);
                if (curTagCount == 10)
                {
                    return Json(new JsonModel(CodeStruct.ExceedTags, "1"));
                }

                Tag newTag = Tags.GetTagByName(tag);
                if (newTag == null)
                {
                    newTag = new Tag();
                    newTag.Name = tag;
                    newTag.ID = Tags.CreateTag(newTag);
                    if (newTag.ID < 0)
                    {
                        return Json(new JsonModel(CodeStruct.Error, "1"));
                    }
                }
                UserTag ut = Tags.GetUserTagByNameUID(tag, curUID);
                if (ut != null)
                {
                    return Json(new JsonModel(CodeStruct.ExistTag, "1"));
                }
                else
                {
                    ut = new UserTag();
                    ut.UID = curUID;
                    ut.TagName = tag;
                    ut.TagID = newTag.ID;
                    ut.ID = Tags.CreateUserTag(ut);
                    if (ut.ID > 0)
                    {

                        Tags.UpdateTagForRefCount(newTag.ID);
                    }
                }

                if (Users.UpdateUserTags(curUID))
                {
                    return Json(new JsonModel(CodeStruct.CreateSuccess, ut));
                }

            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult autoCompleteTag(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!IsLogin) return NotLogin();
                IList<Tag> tags = Tags.GetTop10TagsByQuery(string.Format("Name like '{0}' or Name like '%{0}' or Name like '{0}%' or Name like '%{0}%'", key),null,null);
                if (tags != null)
                {
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
                    foreach (Tag tag in tags)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();
                        auto.ID = tag.ID;
                        auto.Title = tag.Name;
                        auto.NickName = tag.Name;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult DelUserTag(string tagid)
        {
            if (!string.IsNullOrEmpty(tagid))
            {
                if (!IsLogin) return NotLogin();
                if (Tags.DelUserTag(Convert.ToInt64(tagid)))
                {
                    if (Users.UpdateUserTags(CurrentUser.ID))
                    {
                        return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelBlackList(string bid)
		{
            if (!string.IsNullOrEmpty(bid))
			{
			   if (!IsLogin) return NotLogin();
			   if(BlackLists.DelBlackList(Convert.ToInt64(bid)))
			   {
                   return Json(new JsonModel(CodeStruct.DelBlackList, "1"));
			   }
			}
		   return Json(new JsonModel(CodeStruct.Error, "1"));
		}

        public JsonResult DelBlackListByUID(string uid)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                if (!IsLogin) return NotLogin();
                if (BlackLists.DelBlackListByUID(CurrentUser.ID,Convert.ToInt64(uid)))
                {
                    return Json(new JsonModel(CodeStruct.DelBlackList, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddBlackList(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (!IsLogin) return NotLogin();
                if (BlackLists.CreateBlackList(new BlackList { PulledUID=Convert.ToInt64(id),UID=CurrentUser.ID })>0)
                {
                    return Json(new JsonModel(CodeStruct.AddBlackList, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditCustomSite(string customSite)
        {
            if (!string.IsNullOrEmpty(customSite))
            {
                if (!IsLogin) return NotLogin();
                if (Users.IsHaveCustomSite(customSite))
                {
                    return Json(new JsonModel(CodeStruct.ExistSite, "1"));
                }
                else
                {
                    User user = CurrentUser;
                    if (string.IsNullOrEmpty(user.CustomSite))
                    {
                        user.CustomSite = customSite.ToLower().Trim();
                        if (Users.UpadateUser(user))
                        {
                            return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
                        }
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult autoCompleteTopic(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!IsLogin) return NotLogin();
                IList<Topic> topics = Topics.GetTopicsBySearch(key);
                if (topics != null)
                {
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
                    foreach (Topic topic in topics)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();
                        auto.ID = topic.ID;
                        auto.Title = topic.Name;
                        auto.NickName = topic.Name;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult AddUserTopic(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (!IsLogin) return NotLogin();
                long tid = Topics.SaveTopic(name);
                if (tid > 0)
                {
                    UserTopic ut = Topics.GetUserTopicByName(name);
                    if (ut == null)
                    {
                        ut = new UserTopic();
                        ut.TopicID = tid;
                        ut.TopicName = name;
                        ut.UID = CurrentUser.ID;
                        ut.ID = Topics.CreateUserTopic(ut);
                        if (ut.ID > 0)
                        {
                            return Json(new JsonModel(CodeStruct.CreateSuccess, ut));
                        }
                    }
                    else
                    {
                        return Json(new JsonModel(CodeStruct.ExistUserTopic, "1"));
                    }
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelUserTopic(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (!IsLogin) return NotLogin();
                if (Topics.DelUserTopic(Convert.ToInt64(id)))
                {
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetIndexMiniblog()
        {
            IList<MiniBlog> miniblogs = MiniBlogs.GetTop500MiniBlogsByQuery(null,null,"desc");
            if (miniblogs != null)
            {
                IList<object> temp = new List<object>();
                for (int i = miniblogs.Count - 1; i >= 0;i-- )
                {
                    Entity.User u = Users.GetUserByID(miniblogs[i].UID);
                    if (u != null)
                    {
                        object o = new { name = u.NickName, avatar = u.MidAvartar, uid = miniblogs[i].UID, content = Utils.HtmlEncode(miniblogs[i].OriginalContent), time = DateSpan.Get(miniblogs[i].CreateTime) };
                        temp.Add(o);
                    }
                }
                return Json(new JsonModel(CodeStruct.ReturnSuccess, temp));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult FollowOne(string id) 
		{
			if (!string.IsNullOrEmpty(id))
			{
				if (!IsLogin) return NotLogin();
                if(BlackLists.IsInBlackList(CurrentUser.ID,Convert.ToInt64(id)))
                {
                    return Json(new JsonModel(CodeStruct.InMyBlackList, "1"));
                }
                if (BlackLists.IsInBlackList(Convert.ToInt64(id), CurrentUser.ID))
                {
                    return Json(new JsonModel(CodeStruct.InBlackList, "1"));
                }
				if(Users.CreateFollow(CurrentUser.ID,Convert.ToInt64(id),null,null))
				{
                    int relation = Users.GetRelateBetweenUsers(CurrentUser.ID, Convert.ToInt64((id)));
                    return Json(new JsonModel(CodeStruct.CreateSuccess, relation));
				}
			}
			return Json(new JsonModel(CodeStruct.Error, "1"));
         }

		public JsonResult CancelFollow(string id)
		{
			if (!string.IsNullOrEmpty(id))
			{
				if (!IsLogin) return NotLogin();
				if (Users.DelFollow(Convert.ToInt64(id),CurrentUser.ID))
				{
                    int relation = Users.GetRelateBetweenUsers(CurrentUser.ID, Convert.ToInt64((id)));
					return Json(new JsonModel(CodeStruct.DelSuccess, relation));
				}
			}
			return Json(new JsonModel(CodeStruct.Error, "1"));
		}

        public JsonResult CancelFan(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (!IsLogin) return NotLogin();
                if (Users.DelFollow(CurrentUser.ID,Convert.ToInt64(id)))
                {
                    int relation = Users.GetRelateBetweenUsers(CurrentUser.ID, Convert.ToInt64((id)));
                    return Json(new JsonModel(CodeStruct.DelSuccess, relation));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult autoCompleteUser(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (!IsLogin) return NotLogin();
                IList<User> users = Users.GetTop10UsersByQuery(string.Format("NickName like '{0}' or NickName like '%{0}' or NickName like '{0}%' or NickName like '%{0}%'",key),"FocusedCount","desc");
                if (users != null)
                {
                    IList<AutoCompleteModel> autos = new List<AutoCompleteModel>();
                    foreach (User user in users)
                    {
                        AutoCompleteModel auto = new AutoCompleteModel();
                        auto.ID = user.ID;
                        auto.Title = user.NickName;
                        auto.NickName = user.NickName;
                        autos.Add(auto);
                    }
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, autos));
                }
                else
                {
                    return Json(new JsonModel(CodeStruct.NoResult, "1"));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult ClearTip()
        {
            if (!IsLogin) return NotLogin();
            if (Users.ClearAllTipCount(CurrentUser.ID))
            {
                return Json(new JsonModel(CodeStruct.ReturnSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }
        public JsonResult GetNameCard(string name)
        {
            if (!IsLogin) return NotLogin();
            if (!string.IsNullOrEmpty(name))
            {
                Models.NameCardModel model = new NameCardModel();
                model.CurUser = CurrentUser;
                model.NCUser = Users.GetUserByNickName(name);
                if (model.NCUser != null)
                {
                    model.NCUserConfig = Users.GetUserConfigByID(model.NCUser.ID);
                    model.Relation = Users.GetRelateBetweenUsers(model.CurUser.ID, model.NCUser.ID);
                }
                string data = RenderRazorViewToString("NameCard", model);
                if (!string.IsNullOrEmpty(data))
                {
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, data));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditPrivacy(string message, string comment)
        {
            if (!IsLogin) return NotLogin();
            if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(comment))
            {
                UserConfig uc = CurrentUserConfig;
                uc.IsCommentMe = Convert.ToInt16(comment)>0?1:0;
                uc.IsMsgMe = Convert.ToInt16(message) > 0 ? 1 : 0;
                if (Users.UpdateUserConfig(uc))
                    return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelMiniBlog(long mid)
        {
            if (!IsLogin) return NotLogin();
            if (mid>0)
            {
              if(MiniBlogs.DelMiniBlogByMID(mid))
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelMessageByMid(long mid)
        {
            if (!IsLogin) return NotLogin();
            if (mid > 0)
            {
                if (Messages.DelMessageByMID(mid))
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelMessageByUid(long uid,long toUid)
        {
            if (!IsLogin) return NotLogin();
            if (uid > 0&&toUid>0)
            {
                if (Messages.DelMessageByUID(uid,toUid))
                    return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult EditNotice(EditNoticeModel model)
        {
            if (!IsLogin) return NotLogin();
            if (model!=null)
            {
                UserConfig uc = CurrentUserConfig;
                uc.IsAtTip = model.IsAtTip;
                uc.IsCommentTip = model.IsCommentTip;
                uc.IsFollowTip = model.IsFollowTip;
                uc.IsMsgTip = model.IsMsgTip;
                uc.IsNoticeTip = model.IsNoticeTip;
                uc.WaterMarkPosition = model.WaterMarkPosition;
                uc.WaterMarkStyle = model.WaterMarkStyle;
                if (Users.UpdateUserConfig(uc))
                    return Json(new JsonModel(CodeStruct.SaveSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult GetComplaintContent(AjaxComplaintContentModel model)
        {
            if (!IsLogin) return NotLogin();
            if (model != null&&model.ToUID>0)
            {
                model.CurUser = CurrentUser;
                model.CurUserConfig = CurrentUserConfig;
                model.reasons = Types.GetTypesByPID(TypeConfigs.GetComplaintReasonRoot);
                string data = RenderRazorViewToString("GetComplaintContent", model);
                if (!string.IsNullOrEmpty(data))
                {
                    return Json(new JsonModel(CodeStruct.ReturnSuccess, data));
                }
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult CreateComplaint(Complaint model)
        {
            if (!IsLogin) return NotLogin();
            if (model != null)
            {
                model.UID = CurrentUser.ID;
                if(Complaints.CreateComplaint(model)>0)
                return Json(new JsonModel(CodeStruct.ReportSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult DelArrayComment(string cids)
        {
            if (!IsLogin) return NotLogin();
            if (!string.IsNullOrEmpty(cids))
            {
                string[] strs = cids.Split(',');
                foreach (string s in strs)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                       Comments.DelCommentByCID(Convert.ToInt64(s));
                    }
                }
                return Json(new JsonModel(CodeStruct.DelSuccess, "1"));
            }
            return Json(new JsonModel(CodeStruct.Error, "1"));
        }

        public JsonResult InitQuoteBox(long mid)
        {
              if (!IsLogin) return NotLogin();
              if (mid>0)
              {
                  MiniBlog miniblog = MiniBlogs.GetMiniBlogByID(mid);
                  MiniBlog oriMiniblog=MiniBlogs.GetMiniBlogByID(miniblog.OriginalMID);
                  if (miniblog != null)
                  {
                      Entity.User user = Users.GetUserByID(miniblog.UID);
                      Entity.User oriUser = null;
                      if (oriMiniblog != null)
                      {
                           oriUser =Users.GetUserByID(oriMiniblog.UID);

                      }
                      return Json(new JsonModel(CodeStruct.ReturnSuccess, new {
                      Name=user.NickName,Content=MiniBlogs.ParseContentByShortlink(miniblog.OriginalContent),
                      oriName = oriUser == null ? "" : oriUser.NickName,
                      oriContent = oriUser == null ? "" : MiniBlogs.ParseContentByShortlink(oriMiniblog.OriginalContent),
                      url=BaseConfigs.GetWebDomain+"/"+miniblog.UID.ToString()+"/"+miniblog.IDCode.ToString()
                      }));
                  }
              }
              return Json(new JsonModel(CodeStruct.Error, "1"));
        }
    }
}
