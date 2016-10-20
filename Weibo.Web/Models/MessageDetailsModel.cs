using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class MessageDetailsModel : BaseInfoModel
    {

        public User TalkUser { get; set; }
        public IList<Message> Messages { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}