using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
	public class IndexModel
	{
		public IList<StatisticTopic> Topics { get; set; }
		public IList<User> UsingUsers { get; set; }
		public IList<User> NewUsers { get; set; }
		public IList<User> RankUsers { get; set; }
	}
}