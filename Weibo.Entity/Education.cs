using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Education
    {
        public long ID { get; set; }
        public long UID { get; set; }
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public int IsVisible { get; set; }
        public int Type { get; set; }
        public string StartDate { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
