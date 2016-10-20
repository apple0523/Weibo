using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class NameCardModel
    {
        public User CurUser { get; set; }
        public User NCUser { get; set; }
        public UserConfig NCUserConfig { get; set; }
        public int Relation { get; set; }
    }
}
