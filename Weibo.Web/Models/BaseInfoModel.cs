using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class BaseInfoModel
    {
        public User CurUser { get; set; }
        public UserConfig CurUserConfig { get; set; }
    }
}