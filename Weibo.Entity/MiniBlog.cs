using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class MiniBlog
    {
        public long ID { get; set; }
        public string IDCode { get; set; }
        public string OriginalContent { get; set; }
        public string MediaContent { get; set; }
        public string RealContent { get; set; }
        public long PicID { get; set; }
        public long UID { get; set; }
        public long OriginalMID { get; set; }
        public string OriginalMContent { get; set; }
        public long QuoteMID { get; set; }
        public int QuoteCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreateTime { get; set; }
        public int IsOriginal { get; set; }
        public int IsHavePic { get; set; }
        public int IsHaveLink { get; set; }
        public int IsHaveVideo { get; set; }
        public int IsHaveMusic { get; set; }
        public int IsHaveVote { get; set; }
        public int FromID { get; set; }
        public string ReferUID { get; set; }
    }

    public class Favorite : MiniBlog
    {
        public DateTime FavoriteTime { get; set; }
    }
}
