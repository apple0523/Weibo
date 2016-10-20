using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public class Vote
    {
       public long ID { get; set; }
       public string Title { get; set; }
       public string Remark { get; set; }
       public long PID { get; set; }
       public DateTime CreateTime { get; set; }
       public DateTime ExpireTime { get; set; }
       public int JoinCount { get; set; }
       public int Type { get; set; }
       public long UID { get; set; }
       public int OptionCount { get; set; }
       public int OnceSelCount { get; set; }
       public int ResultVisible { get; set; }
    }
}
