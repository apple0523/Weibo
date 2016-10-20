using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public class Video
    {
       public long ID { get; set; }
       public string Title { get; set; }
       public string ThumPicUrl { get; set; }
       public string FlvUrl { get; set; }
       public string OriUrl { get; set; }
       public int FromWeb { get; set; }
       public DateTime CreateTime { get; set; }
    }
}
