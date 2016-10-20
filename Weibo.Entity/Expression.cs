using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Expression
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public string Url { get; set; }
        public string OriUrl { get; set; }
        public int IsDefault { get; set; }
        public int IsTop { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
