using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;


namespace Weibo.Web.Models
{
    public class AjaxGetPagerCommentModel
    {
        public MiniBlog miniBlog { get; set; }
        public User CurUser { get; set; }
        public IList<Comment> comments { get; set; }
        public int recordCount { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}