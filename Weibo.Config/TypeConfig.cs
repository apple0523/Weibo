using System;

namespace Weibo.Config
{


    /// <summary>
    /// 基本设置类
    /// </summary>
    public class TypeConfigs
    {

        private static System.Timers.Timer typeConfigTimer = new System.Timers.Timer(60000);

        private static TypeConfigInfo m_configinfo;

        /// <summary>
        /// 静态构造函数初始化相应实例和定时器
        /// </summary>
        static TypeConfigs()
        {
            m_configinfo = TypeConfigFileManager.LoadConfig();
            typeConfigTimer.AutoReset = true;
            typeConfigTimer.Enabled = true;
            typeConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            typeConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }


        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            m_configinfo = TypeConfigFileManager.LoadConfig();
        }


        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetRealConfig()
        {
            m_configinfo = TypeConfigFileManager.LoadRealConfig();
        }

        public static TypeConfigInfo GetTypeConfig()
        {
            return m_configinfo;
        }


        public static int GetTypeRoot
        {
            get
            {
                return GetTypeConfig().TypeRoot;
            }
        }


 
        public static int GetCityRoot
        {
            get
            {
                return GetTypeConfig().CityRoot;
            }
        }


        public static int GetSexRoot
        {
            get
            {
                return GetTypeConfig().SexRoot;
            }
        }

        public static int GetExpressionRoot
        {
            get
            {
                return GetTypeConfig().ExpressionRoot;
            }
        }

        public static int GetVideoRoot
        {
            get
            {
                return GetTypeConfig().VideoRoot;
            }
        }

        public static int GetVideoYouku
        {
            get 
            {
                return GetTypeConfig().VideoYouku;
            }
        }

        public static int GetVideoTudou
        {
            get
            {
                return GetTypeConfig().VideoTudou;
            }
        }

        public static int GetVideo56
        {
            get
            {
                return GetTypeConfig().Video56;
            }
        }

        public static int GetVideoKu6
        {
            get
            {
                return GetTypeConfig().VideoKu6;
            }
        }
        public static int GetUrlRoot
        {
            get
            {
                return GetTypeConfig().UrlRoot;
            }
        }

        public static int GetUrlNormal
        {
            get
            {
                return GetTypeConfig().UrlNormal;
            }
        }

        public static int GetUrlVideo
        {
            get
            {
                return GetTypeConfig().UrlVideo;
            }
        }

        public static int GetUrlMusic
        {
            get
            {
                return GetTypeConfig().UrlMusic;
            }
        }


        public static int GetUrlVote
        {
            get
            {
                return GetTypeConfig().UrlVote;
            }
        }

        public static int GetThemeRoot
        {
            get { return GetTypeConfig().ThemeRoot; }
        }

        public static int GetSexMale
        {
            get { return GetTypeConfig().SexMale; }
        }

        public static int GetSexFemale
        {
            get { return GetTypeConfig().SexFemale; }
        }

        public static int GetNoticeRoot
        {
            get { return GetTypeConfig().NoticeRoot; }
        }

        public static int GetNoticeSys
        {
            get { return GetTypeConfig().NoticeSys; }
        }
        public static int GetNoticeNormal
        {
            get { return GetTypeConfig().NoticeNormal; }
        }

        public static int GetSchoolRoot
        {
            get { return GetTypeConfig().SchoolRoot; }
        }
        public static int GetComplaintConRoot
        {
            get { return GetTypeConfig().ComplaintConRoot; }
        }

        public static int GetComplaintReasonRoot
        {
            get { return GetTypeConfig().ComplaintReasonRoot; }
        }

        public static int GetComplaint_mb
        {
            get { return GetTypeConfig().Complaint_mb; }
        }

        public static int GetComplaint_cm
        {
            get { return GetTypeConfig().Complaint_cm; }
        }

        public static int GetComplaint_user
        {
            get { return GetTypeConfig().Complaint_user; }
        }

        public static int GetComplaint_msg
        {
            get { return GetTypeConfig().Complaint_msg; }
        }

        public static int GetLogRoot
        {
            get { return GetTypeConfig().LogRoot; }
        }

        public static int GetLogError
        {
            get { return GetTypeConfig().LogError; }
        }


        /// <summary>
        /// 保存配置实例
        /// </summary>
        /// <param name="typeconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(TypeConfigInfo typeconfiginfo)
        {
            TypeConfigFileManager acfm = new TypeConfigFileManager();
            TypeConfigFileManager.ConfigInfo = typeconfiginfo;
            return acfm.SaveConfig();
        }

    }
}
