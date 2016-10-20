using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
	public class UserTag
	{
		public long ID { get; set; }
		public long UID { get; set; }
		public long TagID { get; set; }
		public string TagName { get; set; }
		public DateTime CreateTime { get; set; }
	}
}
