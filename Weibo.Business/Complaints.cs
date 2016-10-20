using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Complaints
    {
        public static long CreateComplaint(Complaint complaint)
        {
            try
            {
                if (complaint == null)
                    return -1;
                return Data.Complaints.CreateComplaint(complaint);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }
    }
}
