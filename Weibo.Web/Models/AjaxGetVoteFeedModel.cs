using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class AjaxGetVoteFeedModel
    {
        public Vote Vote { get; set; }
        public IList<VoteOption> Options { get; set; }
        public User CurUser { get; set; }
        public User QuoUser { get; set; }
        public User PublishUser { get; set; }
    }
}