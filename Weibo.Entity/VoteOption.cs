using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class VoteOption
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int VoteCount { get; set; }
        public long VID { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
