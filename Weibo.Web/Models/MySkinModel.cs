using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class MySkinModel:BaseInfoModel
    {
        public string CurSkinCss { get; set; }

        public IList<MiniBlog> MiniBlogs { get; set; }
    }
}