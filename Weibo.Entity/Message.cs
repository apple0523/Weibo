using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Message
    {
        public long ID { get; set; }
        public long UID { get; set; }
        public long ToUID { get; set; }
        public string Content { get; set; }
        public int Direction { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
