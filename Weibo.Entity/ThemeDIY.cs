using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class ThemeDIY
    {
        public long UID { get; set; }
        public long BgImgPid{get;set;}
        public int IsUseBg{get;set;}
        public int IsLockBg{get;set;}
        public int IsRepeatBg{get;set;}
        public int AlignStyleBg{get;set;}
        public string BgColor{get;set;}
        public string MainTxtColor{get;set;}
        public string MainLinkColor{get;set;}
        public string SubTxtColor{get;set;}
        public string SubLinkColor{get;set;}
        public string ContentColor{get;set;}
        public string BorderStyle{get;set;}
    }
}
