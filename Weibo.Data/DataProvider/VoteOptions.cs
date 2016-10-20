using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;

namespace Weibo.Data
{
   public class VoteOptions
    {
       public static long CreateVoteOption(VoteOption voteOption)
       {
           return DatabaseProvider.GetInstance().CreateVoteOption(voteOption);
       }

       public static VoteOption GetVoteOptionByID(long id)
       {
           using (IDataReader dr = DatabaseProvider.GetInstance().GetVoteOptionByID(id))
           {
               if (dr != null)
               {
                   IList<VoteOption> list = DbTranslate.Translate<VoteOption>(dr);
                   dr.Close();
                   if (list != null && list.Count > 0)
                   {
                       return list[0];
                   }
               }
           }
           return null;
       }
       public static IList<VoteOption> GetVoteOptionsByVID(long vid)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetVoteOptionsByVID(vid))
           {
               if (dt != null)
               {
                   IList<VoteOption> list = DbTranslate.Translate<VoteOption>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

       public static bool UpdateVoteOptionForVoteCount(long vid)
       {
           return DatabaseProvider.GetInstance().UpdateVoteOptionForVoteCount(vid);
       }
    }
}
