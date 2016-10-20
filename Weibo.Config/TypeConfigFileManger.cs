using System;
using System.Text;
using System.Web;
using System.IO;

using Weibo.Common;


namespace Weibo.Config
{

    /// <summary>
    /// 基本设置信息管理类
    /// </summary>
    class TypeConfigFileManager : Weibo.Config.DefaultConfigFileManager
    {
        private static TypeConfigInfo m_configinfo;

        /// <summary>
        /// 锁对象
        /// </summary>
        private static object m_lockHelper = new object();

        /// <summary>
        /// 文件修改时间
        /// </summary>
        private static DateTime m_fileoldchange;




        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static TypeConfigFileManager()
        {
            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);
            m_configinfo = (TypeConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(TypeConfigInfo));
        }

        /// <summary>
        /// 当前配置类的实例
        /// </summary>
        public new static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set { m_configinfo = (TypeConfigInfo)value; }
        }



        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        public static string filename = null;


        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        filename = context.Server.MapPath("~/Config/Type.config");
                        if (!File.Exists(filename))
                        {
                            filename = context.Server.MapPath("/Config/Type.config");
                        }
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Type.config");
                    }

                    if (!File.Exists(filename))
                    {
                        throw new WeiboException("发生错误: 虚拟目录或网站根目录下没有正确的Type.config文件");
                    }
                }
                return filename;
            }

        }

        /// <summary>
        /// 加载配置类
        /// </summary>
        /// <returns></returns>
        public static TypeConfigInfo LoadConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo);
            return ConfigInfo as TypeConfigInfo;
        }

        /// <summary>
        /// 加载真正有效的配置类
        /// </summary>
        /// <returns></returns>
        public static TypeConfigInfo LoadRealConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, false);
            return ConfigInfo as TypeConfigInfo;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}
