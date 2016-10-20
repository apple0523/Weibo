using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Comment
    {
        public long ID { get; set; }
        public long UID { get; set; }
        public long ReplyUID { get; set; }
        public string ReferUID { get; set; }
        public string Content { get; set; }
        public long MID { get; set; }
        public long MUID { get; set; }
        public DateTime CreateTime { get; set; }
        public string ReplyContent { get; set; }
    }
}
