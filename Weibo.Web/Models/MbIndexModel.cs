using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;
namespace Weibo.Web.Models
{
    public class MbIndexModel : BaseInfoModel
    {
        public string CurSkinCss { get; set; }

        public IList<MiniBlog> MiniBlogs { get; set; }

        public long gid { get; set; }

        public int IsFriendShip { get; set; }

        public long uid { get; set; }

        public string nickname { get; set; }

        public string site { get; set; }

        public string OthersSkinCss { get; set; }
        public User OtherUser { get; set; }
        public UserConfig OtherUserConfig { get; set; }

        public int RecordCount { get; set; }
        public int Page { get; set; }

        public int Buffer { get; set; }
        public int PageSize { get; set; }

        public string Key { get; set; }
        private int isOri = -1;
        public int IsOri
        {
            get { return isOri; }
            set { isOri = value; }
        }

        private int isRet = -1;
        public int IsRet
        {
            get { return isRet; }
            set { isRet = value; }
        }
        public int Location { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int IsMyself { get; set; }
        public int IsMyFollow { get; set; }
        public string SomeOne { get; set; }
        private int isHaveLink = -1;
        public int IsHaveLink
        { get { return isHaveLink; } set { isHaveLink = value; } }
        private int isHaveVideo = -1;
        public int IsHaveVideo { get { return isHaveVideo; } set { isHaveVideo = value; } }
        private int isHaveMusic = -1;
        public int IsHaveMusic { get { return isHaveMusic; } set { isHaveMusic = value; } }
        private int isHavePic = -1;
        public int IsHavePic { get { return isHavePic; } set { isHavePic = value; } }
        private int isHaveVote = -1;
        public int IsHaveVote { get { return isHaveVote; } set { isHaveVote = value; } }
        public string Sort { get; set; }

        public int IsAdvanced { get; set; }
    }
}