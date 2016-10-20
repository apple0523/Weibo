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
   public class VoteOptions
    {
       public static long CreateVoteOption(VoteOption voteOption)
       {
           try
           {
               if (voteOption != null)
               {
                   return Data.VoteOptions.CreateVoteOption(voteOption);
               }
               return -1;
           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return -1;
           }
       }

       public static VoteOption GetVoteOptionByID(long id)
       {
           try
           {
               if (id>0)
               {
                   return Data.VoteOptions.GetVoteOptionByID(id);
               }
               return null;
           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return null;
           }
       }

       public static IList<VoteOption> GetVoteOptionsByVID(long vid)
       {
           try
           {
               if (vid > 0)
               {
                   return Data.VoteOptions.GetVoteOptionsByVID(vid);
               }
               return null;
           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return null;
           }

       }

       public static bool UpdateVoteOptionForVoteCount(long vid)
       {
           try
           {
               if (vid > 0)
               {
                   return Data.VoteOptions.UpdateVoteOptionForVoteCount(vid);
               }
               return false;
           }
           catch (Exception ex)
           {
               Logs.WriteErrorLog(ex);
               return false;
           }
       }
    }
}
