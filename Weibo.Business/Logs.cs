using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;
using System.IO;
using System.Web.UI;
using System.Web;
namespace Weibo.Business
{
    public class Logs
    {
        public static void WriteErrorLog(Exception ex)
        {
            try
            {
                if ( ex!=null)
                {


                    string content = "类型：" + Types.GetTypeByID(TypeConfigs.GetLogError).Name + "\r\n";
                    content += "时间：" + DateTime.Now.ToString() + "\r\n";
                    content += "来源：" + ex.TargetSite.ReflectedType.ToString() + "." + ex.TargetSite.Name + "\r\n";
                    content += "内容：" + ex.Message + "\r\n";
                    if (BaseConfigs.GetLogInDB == 1)
                    {
                        Log log = new Log();
                        log.Content = content;
                        log.Type = TypeConfigs.GetLogError;
                        Data.Logs.CreateLog(log);
                    }
                    if (BaseConfigs.GetLogInFile == 1)
                    {
                        Page page = new Page();
                        HttpServerUtility server = page.Server;
                        string dir = server.MapPath(BaseConfigs.GetLogFilePath);


                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir); 
                        }

                        string path = dir + DateTime.Now.ToString("yyyy-MM-dd")+".txt";

                        StreamWriter FileWriter = new StreamWriter(path, true); //创建日志文件
                        FileWriter.Write("---------------------------------------------------\r\n");
                        FileWriter.Write(content);
                        FileWriter.Close(); //关闭StreamWriter对象
                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }


    }
}
