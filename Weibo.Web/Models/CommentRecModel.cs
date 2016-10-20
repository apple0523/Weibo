using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class CommentRecModel:BaseInfoModel
    {
        public string CurSkinCss { get; set; }
        public IList<Comment> Comments { get; set; }
        public int RecordCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Key { get; set; }
        public int IsFollow { get; set; }
    }
}