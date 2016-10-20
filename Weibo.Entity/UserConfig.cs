using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class UserConfig
    {
        public long UID { get; set; }
        public string TipsArray { get; set; }
        public int ThemeID { get; set; }
        public int IsThemeDIY { get; set; }
        public int WaterMarkPosition { get; set; }
        public string WaterMarkStyle { get; set; }
        public int FollowCount { get; set; }
        public int CommentCount { get; set; }
        public int MsgCount { get; set; }
        public int AtmeCount { get; set; }
        public int AtcmtCount { get; set; }
        public int NoticeCount { get; set; }


        public int IsCommentTip { get; set; }
        public int IsFollowTip { get; set; }
        public int IsMsgTip { get; set; }

        public double IsAtTip { get; set; }
        public int IsNoticeTip { get; set; }

        public int IsCommentMe { get; set; }
        public int IsMsgMe { get; set; }
    }
}
