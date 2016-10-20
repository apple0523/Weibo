using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class Contact
    {
        public long ID { get; set; }
        public long UID { get; set; }
        public long ToUID { get; set; }
        public int Direction { get; set; }
        public DateTime LastContactTime { get; set; }
        public long LastMID { get; set; }
        public string LastMContent { get; set; }
        public int MessageCount { get; set; }
    }
}
