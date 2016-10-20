using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Entity
{
    public class VoteJoin
    {
        public long ID{get;set;}
        public long VID{get;set;}
        public long UID{get;set;}
        public string SelVoteItemIDs{get;set;}
        public string SelVoteItemNames{get;set;}
        public int IsAnonymous{get;set;}
        public DateTime CreateTime{get;set;}
    }


}
