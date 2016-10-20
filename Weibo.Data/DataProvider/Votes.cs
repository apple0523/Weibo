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
    public class Votes
    {
        public static long CreateVote(Vote vote)
        {
            return DatabaseProvider.GetInstance().CreateVote(vote);
        }

        public static bool UpdateVoteForJoinCount(long id)
        {
            return DatabaseProvider.GetInstance().UpdateVoteForJoinCount(id);
        }

        public static Vote GetVoteByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetVoteByID(id))
            {
                if (dr != null)
                {
                    IList<Vote> list = DbTranslate.Translate<Vote>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Vote> GetVoteByUID(long uid)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetVoteByUID(uid))
            {
                if (dt != null)
                {
                    IList<Vote> list = DbTranslate.Translate<Vote>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

    }
}
