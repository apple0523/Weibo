using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weibo.Web.Models
{
    public class EditNoticeModel
    {

        public int WaterMarkPosition { get; set; }
        public string WaterMarkStyle { get; set; }


        public int IsCommentTip { get; set; }
        public int IsFollowTip { get; set; }
        public int IsMsgTip { get; set; }

        public double IsAtTip { get; set; }
        public int IsNoticeTip { get; set; }

    }
}