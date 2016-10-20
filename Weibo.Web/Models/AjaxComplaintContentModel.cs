using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class AjaxComplaintContentModel:BaseInfoModel
    {
        public IList<Entity.Type> reasons { get; set; }
        public long ToUID { get; set; }
        public int ConType { get; set; }
        public long ConID { get; set; }
    }
}