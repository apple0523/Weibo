using System;

namespace Weibo.Config
{
    /// <summary>
    /// 基本设置描述类, 加[Serializable]标记为可序列化
    /// </summary>
    [Serializable]
    public class BaseConfigInfo : IConfigInfo
    {
        #region 私有字段

        //private string m_dbconnectstring = "Data Source=AP-LAWRENCE\\SQLEXPRESS;User ID=sa;Password=welcome;Initial Catalog=Weibo;Pooling=true";		// 数据库连接串-格式(中文为用户修改的内容)：Data Source=数据库服务器地址;User ID=您的数据库用户名;Password=您的数据库用户密码;Initial Catalog=数据库名称;Pooling=true
        private string m_dbconnectstring = "Data Source=CNO-9943L32;User ID=sa;Password=Marykay2016;Initial Catalog=Weibo;Pooling=true";		// 数据库连接串-格式(中文为用户修改的内容)：Data Source=数据库服务器地址;User ID=您的数据库用户名;Password=您的数据库用户密码;Initial Catalog=数据库名称;Pooling=true

        private string m_webDomain = "http://www.wangla.website/";			// 域名
        private int m_CookieExpire = 7;
        private string m_CookieDomain = "localhost";
        private string m_dbtype = "SqlServer";
        private int m_founderuid = 0;				// 创始人
        private string m_pwdencodeKey = "ABCD1234";//密码key
        private string m_pwdencodeType = "DES";//加密类型 AES,DES
        private string m_webtitle = "微博";
        private string m_imguploadpath = "/Upload/Image/";
        private string m_musicuploadpath = "/Upload/Music/";
        private int m_imguploadsize = 1024 * 1024 * 5;
        private string m_shortLink = "http://localhost:1111/";
        private int m_musicuploadsize = 1024 * 1024 * 10;
        private DateTime m_startDate = new DateTime(2016,8,1);

        private int m_logInFile = 1;
        private int m_logInDB = 1;
        private string m_logFilePath = "/Log/";

        private string m_avartarUploadPath = "/Upload/Avartar/";
        #endregion

        #region 属性

        /// <summary>
        /// 数据库连接串
        /// 格式(中文为用户修改的内容)：
        ///    Data Source=数据库服务器地址;
        ///    User ID=您的数据库用户名;
        ///    Password=您的数据库用户密码;
        ///    Initial Catalog=数据库名称;Pooling=true
        /// </summary>
        public string Dbconnectstring
        {
            get { return m_dbconnectstring; }
            set { m_dbconnectstring = value; }
        }


        /// <summary>
        /// 域名
        /// </summary>
        public string WebDomain
        {
            get { return m_webDomain; }
            set { m_webDomain = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string Dbtype
        {
            get { return m_dbtype; }
            set { m_dbtype = value; }
        }

        /// <summary>
        /// 创始人ID
        /// </summary>
        public int Founderuid
        {
            get { return m_founderuid; }
            set { m_founderuid = value; }
        }


        public string PwdEncodeKey
        {
            get { return m_pwdencodeKey; }
            set { m_pwdencodeKey = value; }
        }

        public string PwdEncodeType
        {
            get { return m_pwdencodeType; }
            set { m_pwdencodeType = value; }
        }

        public string WebTitle
        {
            get { return m_webtitle; }
            set { m_webtitle = value; }
        }

        public string ImgUploadPath
        {
            get { return m_imguploadpath; }
            set { m_imguploadpath = value; }
        }

        public int ImgUploadSize
        {
            get { return m_imguploadsize; }
            set { m_imguploadsize = value; }
        }

        public int MusicUploadSize
        {
            get { return m_musicuploadsize; }
            set { m_musicuploadsize = value; }
        }

        public string MusicUploadPath
        {
            get { return m_musicuploadpath; }
            set { m_musicuploadpath = value; }
        }

        public string ShortLinkDomainName
        {
            get { return m_shortLink; }
            set { m_shortLink = value; }
        }

        public int CookieExpire
        {
            get { return m_CookieExpire; }
            set { m_CookieExpire = value; }
        }
        public string CookieDomain
        {
            get { return m_CookieDomain; }
            set { m_CookieDomain = value; }
        }

        public DateTime StartDate
        {
            get { return m_startDate; }
            set { m_startDate = value; }
        }

        public int LogInFile
        {
            get { return m_logInFile; }
            set { m_logInFile = value; }
        }

        public int LogInDB
        {
            get { return m_logInDB; }
            set { m_logInDB = value; }
        }

        public string LogFilePath
        {
            get { return m_logFilePath; }
            set { m_logFilePath = value; }
        }

        public string AvartarUploadPath
        {
            get { return m_avartarUploadPath; }
            set { m_avartarUploadPath = value; }
        }

        #endregion
    }
}
