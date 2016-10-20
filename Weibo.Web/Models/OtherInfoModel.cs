using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class OtherInfoModel : BaseInfoModel
    {
        public string CurSkinCss { get; set; }
        public string OthersSkinCss { get; set; }
        public User OtherUser { get; set; }
        public UserConfig OtherUserConfig { get; set; }

        public IList<Career> OtherCareer { get; set; }
        public IList<Education> OtherEducation { get; set; }
    }
}