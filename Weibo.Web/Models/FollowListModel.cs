using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class FollowListModel : BaseInfoModel
    {

        public IList<Follow> Follows { set; get; }
        public int RecordCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public int NoGroup { get; set; }
        public int FriendShip { get; set; }
        public long gid { get; set; }
        public string Key { get; set; }

        public long uid { get; set; }

        public User OtherUser { get; set; }
    }
}