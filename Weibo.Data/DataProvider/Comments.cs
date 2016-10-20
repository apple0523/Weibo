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
   public class Comments
    {
       public static long CreateComment(Comment comment)
       {
           return DatabaseProvider.GetInstance().CreateComment(comment);
       }

       public static bool DelCommentByCID(long cid)
       {
           return DatabaseProvider.GetInstance().DelCommentByCID(cid);
       }

       public static IList<Comment> GetTop10CommentsByMid(long mid)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetTop10CommentsByMid(mid))
           {
               if (dt != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

       public static IList<Comment> GetCommentsByMid(int pageIndex, int pageSize, long mid,long uid,int isFollow, ref int rowCount)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetCommentsByMid(pageIndex,pageSize,mid,uid,isFollow,ref rowCount))
           {
               if (dt != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

       public static Comment GetCommentByID(long id)
       {
           using (IDataReader dr = DatabaseProvider.GetInstance().GetCommentByID(id))
           {
               if (dr != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dr);
                   dr.Close();
                   if (list != null && list.Count > 0)
                   {
                       return list[0];
                   }
               }
           }
           return null;
       }

       public static int GetCommentCountByMID(long Mid)
       {
           return DatabaseProvider.GetInstance().GetCommentCountByMID(Mid);
       }

       public static IList<Comment> GetAtCommentsByPager(long uid,string key,int isFollow, int pageIndex, int pageSize, ref int recordCount)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetAtCommentsByPager( pageIndex, pageSize,uid,key,isFollow, ref recordCount))
           {
               if (dt != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

       public static IList<Comment> GetRecCommentsByPager(long uid,int isFollow,string key, int pageIndex, int pageSize, ref int recordCount)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetRecCommentsByPager(pageIndex, pageSize, uid,isFollow,key, ref recordCount))
           {
               if (dt != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dt);
                   if (list != null && list.Count > 0)
                   {
                       return list;
                   }
               }
           }
           return null;
       }

       public static IList<Comment> GetSendCommentsByPager(long uid,string key, int pageIndex, int pageSize, ref int recordCount)
       {
           using (DataTable dt = DatabaseProvider.GetInstance().GetSendCommentsByPager(pageIndex, pageSize, uid,key, ref recordCount))
           {
               if (dt != null)
               {
                   IList<Comment> list = DbTranslate.Translate<Comment>(dt);
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
