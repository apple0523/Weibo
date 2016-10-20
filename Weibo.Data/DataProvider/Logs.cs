using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;

namespace Weibo.Data
{
    public class Logs
    {

        public static long CreateLog(Log log)
        {
            return DatabaseProvider.GetInstance().CreateLog(log);
        }
        public static bool DelLog(long id)
        {
            return DatabaseProvider.GetInstance().DelLog(id);
        }

       
    }
}

