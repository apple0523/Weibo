using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Notice
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long UID { get; set; }
        public long ToUID { get; set; }
        public int Type { get; set; }
        public int IsRead { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
