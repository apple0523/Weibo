using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Music
    {
        public long ID { get; set; }
        public string MusicUrl { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
