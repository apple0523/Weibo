using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class SetTagModel : BaseInfoModel
	{
 
		public IList<UserTag> UserTags { get; set; }
        public IList<Tag> InterestTags { get; set; }
	}
}