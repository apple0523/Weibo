using System;
using System.Reflection;
using System.Text;
using System.Data;
using System.Threading;

using Weibo.Common;
using Weibo.Data;
using Weibo.Plugin.Mail;
using Weibo.Config;

namespace Weibo.Business
{
    /// <summary>
    /// 邮件发送类的调用封装类
    /// </summary>
    public class Emails
    {
        protected static EmailConfigInfo emailinfo = EmailConfigs.GetConfig();
        protected static BaseConfigInfo configinfo = BaseConfigs.GetBaseConfig();


        protected static ISmtpMail ESM;


        static Emails()
        {
            if (emailinfo.DllFileName.ToLower().IndexOf(".dll") <= 0)
                emailinfo.DllFileName = emailinfo.DllFileName + ".dll";

            LoadEmailPlugin();
        }

        //重设置当前邮件发送类的实例对象
        public static void ReSetISmtpMail()
        {
            emailinfo = EmailConfigs.GetConfig();

            LoadEmailPlugin();
        }

        /// <summary>
        /// 加载email插件
        /// </summary>
        private static void LoadEmailPlugin()
        {
            try
            {
                //读取相应的DLL信息
                Assembly asm = Assembly.LoadFrom(System.Web.HttpRuntime.BinDirectory + emailinfo.DllFileName);
                ESM = (ISmtpMail)Activator.CreateInstance(asm.GetType(emailinfo.PluginNameSpace, false, true));
            }
            catch
            {
                try
                {
                    //读取相应的DLL信息
                    Assembly asm = Assembly.LoadFrom(Utils.GetMapPath("/bin/" + emailinfo.DllFileName));
                    ESM = (ISmtpMail)Activator.CreateInstance(asm.GetType(emailinfo.PluginNameSpace, false, true));
                }
                catch(Exception ex)
                {
                    Logs.WriteErrorLog(ex);
                    ESM = new SmtpMail();
                }
            }
        }




        /// <summary>
        /// 注册邮件内容函数
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Email">EMAIL地址</param>
        /// <param name="authstr">相应注册用户的激活链接串参数</param>
        /// <returns></returns>
        public static bool RegSmtpMail(string UserName, string Email, string authstr)
        {
            string forumurl = "http://" + WeiboRequest.GetCurrentFullHost() + "/";

            try
            {
                ESM.RecipientName = UserName;//设定收件人姓名
                ESM.AddRecipient(Email);
                ESM.MailDomainPort = emailinfo.Port;
                ESM.From = emailinfo.Sysemail;
                ESM.FromName = configinfo.WebTitle;
                ESM.Html = true;
                ESM.Subject = "请验证你的邮箱完成注册.";

                StringBuilder body = new StringBuilder();
                body.Append(emailinfo.Emailcontent.Replace("{webtitle}", configinfo.WebTitle));
                body.Replace("{weburl}", string.Format("<a href=\"{0}\">{0}</a>", configinfo.WebDomain));
                body.Replace("{forumurl}", string.Format("<a href=\"{0}\">{0}</a>", forumurl));
                body.Replace("{forumtitle}", configinfo.WebTitle);

                ESM.Body = "<pre style=\"width:100%;word-wrap:break-word\">  激活您帐户的链接为:<a href=" + forumurl + "User/EmailValidate/?val=" + authstr.Trim() + "  target=_blank>" + forumurl + "User/EmailValidate/" + authstr.Trim() + "</a>"+"\r\n\r\n"+body.ToString() + "</pre>";
                ESM.MailDomain = emailinfo.Smtp;
                ESM.MailServerUserName = emailinfo.Username;
                ESM.MailServerPassWord = emailinfo.Password;

                return ESM.Send();
            }
            catch(Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }


        /// <summary>
        /// 邮件通知服务
        /// </summary>
        /// <param name="Email">email地址</param>
        /// <param name="title">邮件的标题</param>
        /// <param name="body">邮件内容</param>
        /// <returns></returns>
        public static bool SendEmailNotify(string Email, string title, string body)
        {
            try
            {
                ESM.AddRecipient(Email);
                ESM.MailDomainPort = emailinfo.Port;
                ESM.From = emailinfo.Sysemail;//设定发件人地址(必须填写)
                ESM.FromName = configinfo.WebTitle;
                ESM.Html = true;//设定正文是否HTML格式。
                ESM.Subject = title;

                ESM.Body = "<pre style=\"width:100%;word-wrap:break-word\">" + body.ToString() + "</pre>";
                ESM.MailDomain = emailinfo.Smtp;
                ESM.MailServerUserName = emailinfo.Username;
                ESM.MailServerPassWord = emailinfo.Password;

                //开始发送
                return ESM.Send();
            }
            catch(Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }






        /// <summary>
        /// 多线程发送邮箱类
        /// </summary>
        public class EmailMultiThread : Emails
        {
            #region 私有成员
            private string m_username = "";

            private string m_email = "";

            private string m_title = "";

            private string m_body = "";

            private bool m_issuccess = false;
            #endregion

            #region 公有属性
            /// <summary>
            /// 收件人姓名
            /// </summary>
            public string UserName
            {
                get { return m_username; }
            }

            /// <summary>
            /// 收件人邮箱地址
            /// </summary>
            public string Email
            {
                get { return m_email; }
            }

            /// <summary>
            /// 邮件标题
            /// </summary>
            public string Title
            {
                get { return m_title; }
            }

            /// <summary>
            /// 邮件内容
            /// </summary>
            public string Body
            {
                get { return m_body; }
            }

            /// <summary>
            /// 是否发送成功
            /// </summary>
            public bool IsSuccess
            {
                get { return m_issuccess; }
                set { m_issuccess = value; }
            }
            #endregion

            public EmailMultiThread(string UserName, string Email, string Title, string Body)
            {
                m_username = UserName;
                m_email = Email;
                m_title = Title;
                m_body = Body;
            }

            public void Send()
            {
                lock (emailinfo)
                {
                    try
                    {
                        ESM.MailDomainPort = emailinfo.Port;
                        ESM.AddRecipient(this.Email);
                        ESM.RecipientName = this.UserName;//设定收件人姓名

                        ESM.From = emailinfo.Sysemail;
                        ESM.FromName = configinfo.WebTitle;
                        ESM.Html = true;
                        ESM.Subject = this.Title;
                        ESM.Body = "<pre style=\"width:100%;word-wrap:break-word\">" + this.Body.ToString() + "</pre>";
                        ESM.MailDomain = emailinfo.Smtp;
                        ESM.MailServerUserName = emailinfo.Username;
                        ESM.MailServerPassWord = emailinfo.Password;

                        //开始发送
                        this.IsSuccess = ESM.Send();
                    }
                    catch(Exception ex)
                    {
                        Logs.WriteErrorLog(ex);
                    }
                }
                Thread.CurrentThread.Abort();
            }
        }
    }
}