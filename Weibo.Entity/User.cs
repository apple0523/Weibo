using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class User
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string BigAvartar { get; set; }
        public string MidAvartar { get; set; }
        public string SmallAvartar { get; set; }
        public int FocusCount { get; set; }
        public int FocusedCount { get; set; }
        public int MiniBlogCount { get; set; }
        public int Sex { get; set; }
        public int Location { get; set; }
        public DateTime RegTime { get; set; }
        public string IP { get; set; }
        public long LastMID { get; set; }
        public int IsEmailValidate { get; set; }
        public string LastMContent { get; set; }
        public string LastInputContent { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string RealName { get; set; }
        public int? RealNameVisible { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? BirthDayVisible { get; set; }
        public string Blog { get; set; }
        public int? BlogVisible { get; set; }
        public string ContactEmail { get; set; }
        public int? ContactEmailVisible { get; set; }
        public string QQ { get; set; }
        public int? QQVisible { get; set; }
        public string MSN { get; set; }
        public int? MSNVisible { get; set; }
        public string Description { get; set; }
        public string Schools { get; set; }
        public string Companies { get; set; }
        public string Tags { get; set; }
        public string CustomSite { get; set; }
    }

    public class Fans : User
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastContactTime { get; set; }
        public int FriendShip { get; set; }
    }

    public class Follow : User
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastContactTime { get; set; }
        public string Remark { get; set; }
        public string GroupIDs { get; set; }
        public int FriendShip { get; set; }
    }
}
