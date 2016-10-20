using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class DetailsModel:BaseInfoModel
    {
        public string CurSkinCss { get; set; }
        public MiniBlog MiniBlog { get; set; }

        public User OtherUser { get; set; }
        public UserConfig OtherUserConfig { get; set; }
        public string OtherSkinCss { get; set; }

        public long uid { get; set; }
        public string IDCode { get; set; }
    }
}