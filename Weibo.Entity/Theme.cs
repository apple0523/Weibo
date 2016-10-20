using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Theme
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string CssUrl { get; set; }
        public int IsRecommend { get; set; }
        public DateTime CreateTime { get; set; }
        public string ThumPicUrl { get; set; }
    }
}
