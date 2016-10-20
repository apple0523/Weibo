
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
   public class VoteJoins
    {
       public static long CreateVoteJoin(VoteJoin voteJoin)
       {
           try
           {
               if (voteJoin != null)
               {
                   return Data.VoteJoins.CreateVoteJoin(voteJoin);
               }
               return -1;

           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return -1;
           }

       }

       public static VoteJoin GetVoteJoinByUID(long uid,long vid)
       {
           try
           {
               if (uid >0&&vid>0)
               {
                   return Data.VoteJoins.GetVoteJoinByUID(uid,vid);
               }
               return null;

           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return null;
           }
       }
    }
}
