using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class FavoriteModel : BaseInfoModel
    {
        public string CurSkinCss { get; set; }
 
        public IList<Favorite> MiniBlogs { get; set; }
        public int RecordCount { get; set; }
        public string Key { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
