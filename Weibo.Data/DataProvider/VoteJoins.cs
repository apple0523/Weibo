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
   public class VoteJoins
    {
        public static long CreateVoteJoin(VoteJoin voteJoin)
        {
            return DatabaseProvider.GetInstance().CreateVoteJoin(voteJoin);
        }

        public static VoteJoin GetVoteJoinByUID(long uid, long vid)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetVoteJoinByUID(uid,vid))
            {
                if (dr != null)
                {
                    IList<VoteJoin> list = DbTranslate.Translate<VoteJoin>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }
    }
}
