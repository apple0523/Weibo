using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Pic
    {
        public long ID { get; set; }
        public string OriginalPicUrl { get; set; }
        public string MidPicUrl { get; set; }
        public string SmallPicUrl { get; set; }
        public string ThumPicUrl { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
