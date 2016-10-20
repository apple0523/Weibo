using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
   public class Complaint
    {
       public long ID { get; set; }
       public long UID { get; set; }
       public long ToUID { get; set; }
       public int ComplaintConType { get; set; }
       public long ComplaintConID { get; set; }
       public int ComplaintReason { get; set; }
       public string ComplaintSupplement { get; set; }
       public DateTime CreateTime { get; set; }
       public int IsHandle { get; set; }
       public DateTime HandleTime { get; set; }
       public string HandleResult { get; set; }
    }
}
