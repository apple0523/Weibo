using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Career
    {
        public long ID { get; set; }
        public long UID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int Location { get; set; }
        public int IsVisible { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Position { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
