using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public  class Type
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public int PID { get; set; }
       public DateTime CreateTime { get; set; }
    }
}
