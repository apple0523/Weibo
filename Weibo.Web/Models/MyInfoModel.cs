using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class MyInfoModel : BaseInfoModel
    {
        public string CurSkinCss { get; set; }

        public IList<Career> MyCareer { get; set; }
        public IList<Education> MyEducation { get; set; }
    }
}