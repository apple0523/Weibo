using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Group
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long UID { get; set; }
        public DateTime CreateTime { get; set; }
        public int Sort { get; set; }
    }
}
