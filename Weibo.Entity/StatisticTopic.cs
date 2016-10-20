using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
	public class StatisticTopic
	{
		public long ID { get; set; }
		public long TopicID { get; set; }
		public string TopicName { get; set; }
        public int RefCount { get; set; }
		public DateTime CreateTime { get; set; }
	}
}
