using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
	public class BlackList
	{
		public long ID { get; set; }
		public long UID { get; set; }
		public long PulledUID { get; set; }
		public DateTime CreateTime { get; set; }
	}
}
