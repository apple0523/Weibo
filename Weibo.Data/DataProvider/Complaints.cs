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
    public class Complaints
    {
        public static long CreateComplaint(Complaint complaint)
        {
            return DatabaseProvider.GetInstance().CreateComplaint(complaint);
        }
    }
}
