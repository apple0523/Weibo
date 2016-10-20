using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class SchUserModel : BaseInfoModel
    {

        public IList<User> Users { get; set; }
        public int RecordCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string Key { get; set; }
        public string School { get; set; }
        public string Tag { get; set; }
        public string Career { get; set; }
        public int Location { get; set; }
        public int Sex { get; set; }
        public string Age { get; set; }
    }
}