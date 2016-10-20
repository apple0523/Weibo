using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class CareerModel : BaseInfoModel
    {
        public IList<Career> Careers { get; set; }
    }
}