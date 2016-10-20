using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public class From
    {
       public int ID { get; set; }
       public string FromName { get; set; }
       public string FromUrl { get; set; }
       public int FromCount { get; set; }
       public DateTime CreateTime { get; set; }
    }
}
