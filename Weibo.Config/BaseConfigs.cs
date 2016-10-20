using System;

namespace Weibo.Config
{


    /// <summary>
    /// 基本设置类
    /// </summary>
    public class BaseConfigs
    {

        private static System.Timers.Timer baseConfigTimer = new System.Timers.Timer(60000);

        private static BaseConfigInfo m_configinfo;

        /// <summary>
        /// 静态构造函数初始化相应实例和定时器
        /// </summary>
        static BaseConfigs()
        {
            m_configinfo = BaseConfigFileManager.LoadConfig();
            baseConfigTimer.AutoReset = true;
            baseConfigTimer.Enabled = true;
            baseConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            baseConfigTimer.Start();
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
            m_configinfo = BaseConfigFileManager.LoadConfig();
        }


        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetRealConfig()
        {
            m_configinfo = BaseConfigFileManager.LoadRealConfig();
        }

        public static BaseConfigInfo GetBaseConfig()
        {
            return m_configinfo;
        }

        /// <summary>
        /// 返回数据库连接串
        /// </summary>
        public static string GetDBConnectString
        {
            get
            {
                return GetBaseConfig().Dbconnectstring;
            }
        }


        //得到论坛创建人ID
        public static int GetFounderUid
        {
            get
            {
                return GetBaseConfig().Founderuid;
            }
        }

        /// <summary>
        /// 返回域名
        /// </summary>
        public static string GetWebDomain
        {
            get
            {
                return GetBaseConfig().WebDomain;
            }
        }

        /// <summary>
        /// 返回论坛数据库类型
        /// </summary>
        public static string GetDbType
        {
            get
            {
                return GetBaseConfig().Dbtype;
            }
        }

        public static string GetPwdEncodeKey
        {
            get 
            {
                return GetBaseConfig().PwdEncodeKey;
            }
        }

        public static string GetPwdEncodeType
        {
            get
            {
                return GetBaseConfig().PwdEncodeType;
            }
        }

        public static string GetWebTitle
        {
            get
            {
                return GetBaseConfig().WebTitle;
            }
        }

        public static string GetImageUploadPath
        {
            get
            {
                return GetBaseConfig().ImgUploadPath;
            }
        }

        public static int GetImgUploadSize
        {
            get
            {
                return GetBaseConfig().ImgUploadSize;
            }
        }

        public static string GetShortLinkDomainName
        {
            get
            {
                return GetBaseConfig().ShortLinkDomainName;
            }
        }

        public static string GetMusicUploadPath
        {
            get 
            {
                return GetBaseConfig().MusicUploadPath;
            }
        }

        public static int GetMusicUploadSize
        {
            get
            {
                return GetBaseConfig().MusicUploadSize;
            }
        }

        public static int GetCookieExpire
        {
            get
            {
                return GetBaseConfig().CookieExpire;
            }
        }

        public static string GetCookieDomain
        {
            get 
            {
                return GetBaseConfig().CookieDomain;
            }
        }

        public static DateTime GetStartDate
        {
            get
            {
                return GetBaseConfig().StartDate;
            }
        }

        public static int GetLogInFile
        {
            get
            {
                return GetBaseConfig().LogInFile;
            }
        }

        public static int GetLogInDB
        {
            get
            {
                return GetBaseConfig().LogInDB;
            }
        }

        public static string GetLogFilePath
        {
            get
            {
                return GetBaseConfig().LogFilePath;
            }
        }

        public static string GetAvartarUploadPath
        {
            get
            {
                return GetBaseConfig().AvartarUploadPath;
            }
        }
        /// <summary>
        /// 保存配置实例
        /// </summary>
        /// <param name="baseconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(BaseConfigInfo baseconfiginfo)
        {
            BaseConfigFileManager acfm = new BaseConfigFileManager();
            BaseConfigFileManager.ConfigInfo = baseconfiginfo;
            return acfm.SaveConfig();
        }

    }
}
