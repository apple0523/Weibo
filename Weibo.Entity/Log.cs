using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Log
    {
        public long ID { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
