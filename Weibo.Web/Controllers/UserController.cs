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
namespace Weibo.Web.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormService.SignOut();
            return RedirectToAction("Index", "HomePage");
        }

        [HttpPost]
        public void IframeLogin(FormCollection collection)
        {
            string name = collection["hdLoginname"].ToString();
            string pwd = collection["hdPassword"].ToString();
            string remusrname = collection["hdReUsername"].ToString();
            Entity.User user = Users.Login(name, pwd);
            if (user == null)
                Response.Write("<script type='text/javascript' type='language'>window.parent.loginCallBack(false);</script>");
            else
            {
                if (user.IsEmailValidate == 0)
                {
                    Response.Write("<script type='text/javascript' type='language'>window.parent.loginCallBack(true,0);</script>");
                }
                else
                {
                    FormService.SignIn(user, remusrname == "true");
                    if (user.NickName == "")
                    {
                        Response.Write("<script type='text/javascript' type='language'>window.parent.loginCallBack(true,1);</script>");
                    }
                    else
                    {
                        if (BackUrl != null)
                            Response.Write("<script type='text/javascript' type='language'>window.parent.loginCallBack(true,2,\""+BackUrl+"\");</script>");
                        else
                            Response.Write("<script type='text/javascript' type='language'>window.parent.loginCallBack(true,2);</script>");
                    }
                }
            }
        }

        [HttpPost]
        public void IframeModLogin(FormCollection collection)
        {
            string name = collection["hdLoginname"].ToString();
            string pwd = collection["hdPassword"].ToString();
            string remusrname = collection["hdReUsername"].ToString();
            Entity.User user = Users.Login(name, pwd);
            if (user == null)
                Response.Write("<script type='text/javascript' type='language'>window.parent.App.loginCallBack(false);</script>");
            else
            {
                if (user.IsEmailValidate == 0)
                {
                    Response.Write("<script type='text/javascript' type='language'>window.parent.App.loginCallBack(true,0);</script>");
                }
                else
                {
                    FormService.SignIn(user, remusrname == "true");
                    if (user.NickName == "")
                    {
                        Response.Write("<script type='text/javascript' type='language'>window.parent.App.loginCallBack(true,1);</script>");
                    }
                    else
                        Response.Write("<script type='text/javascript' type='language'>window.parent.App.loginCallBack(true,2);</script>");
                }
            }
        }

        [HttpPost]
        public void IframeReg(FormCollection collection)
        {
            string email = collection["formMail"].ToString();
            string pwd = collection["formPwd"].ToString();
            /////////验证
            ///TODO:
            ////////
            if (Users.CreateUser(email, pwd) > -1)
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.RegCallback(true,\""+email+"\");</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.RegCallback(false);</script>");

            }
            
        }
       
        [HttpPost]
        public void IframeModReg(FormCollection collection)
        {
            string email = collection["formMail"].ToString();
            string pwd = collection["formPwd"].ToString();
            /////////验证
            ///TODO:
            ////////
            if (Users.CreateUser(email, pwd) > -1)
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.App.regCallBack(true,\""+email+"\");</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.App.regCallBack(false);</script>");

            }
        }

		public ActionResult RegSuccess(string email)
		{
            ViewData["Email"] = email;
 			return View();
		}

        public ActionResult Reg()
        {
            return View();
        }

        public ActionResult FullInfo()
        {
            try
            {
                ViewData["UserEmail"] = CurrentUser.Email;
                return View();
            }
            catch (Exception e)
            {
               return RedirectToAction("Login");
            }
        }


        public ActionResult EmailValidate(string val)
        {
            
            if (string.IsNullOrEmpty(val))
            {
               return RedirectToAction("Login");
            }
            else
            {
                string email = BaseConfigs.GetPwdEncodeType == "AES" ? AES.Decode(val, BaseConfigs.GetPwdEncodeKey) : DES.Decode(val, BaseConfigs.GetPwdEncodeKey);
                Entity.User user = Users.GetUserByEmail(email);
                if (user != null)
                {
                    user.IsEmailValidate = 1;
                    if (Users.UpadateUser(user))
                    {
                        ViewData["Result"] = "成功";
                    }
                    else
                    {
                        ViewData["Result"] = "失败";
                    }
                }
                else
                    ViewData["Result"] = "失败";
            }
            return View();
        }

        public void IframeFullInfo(FormCollection collection)
        {
            string nickName = collection["formNickName"].ToString();
            string province = collection["formProvince"].ToString();
            string city = collection["formCity"].ToString();
            string sex = collection["formSex"].ToString();
            User updateUser = CurrentUser;
            updateUser.NickName = nickName;
            updateUser.Location = city == "-1" ? TypeConverter.StrToInt(province) : TypeConverter.StrToInt(city);
            IList<Entity.Type> list = Types.GetTypesByPID(TypeConfigs.GetSexRoot);
            updateUser.Sex = sex == "true" ? list[0].ID : list[1].ID;
            updateUser.BigAvartar = sex == "true" ? "/Upload/Avartar/180/0/1.gif" : "/Upload/Avartar/180/0/0.gif";
            updateUser.MidAvartar = sex == "true" ? "/Upload/Avartar/50/0/1.gif" : "/Upload/Avartar/50/0/0.gif";
            updateUser.SmallAvartar = sex == "true" ? "/Upload/Avartar/30/0/1.gif" : "/Upload/Avartar/30/0/0.gif";
            if (Users.UpadateUser(updateUser))
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.fullInfoCallBack(true);</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript' type='language'>window.parent.fullInfoCallBack(false);</script>");

            }
        }

        #region 验证码
        public void GetCheckCode()
        {
            CreateCheckCodeImage(GenerateCheckCode());
        }

        private string GenerateCheckCode()            //绘制4个随机数或字母
        {
            int number;
            char code;
            string checkCode = String.Empty;

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }

            Session["CheckCode"] = checkCode;

            return checkCode;
        }

        public void CreateCheckCodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap(100, 35);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(Color.White);

                //画图片的背景噪音线
                for (int i = 0; i < 2; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }

                Font font = new System.Drawing.Font("Arial", 25, (System.Drawing.FontStyle.Bold));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion

    }
}
