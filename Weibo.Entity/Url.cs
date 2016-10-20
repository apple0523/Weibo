using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public class Url
    {
       public long ID { get; set; }
       public string OriginalUrl { get; set; }
       public string ShortLink { get; set; }
       public int RefCount { get; set; }
       public long MediaID { get; set; }
       public int Type { get; set; }
    }
}
