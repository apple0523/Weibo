using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Tag
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int RefCount { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
