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
    public class MiniBlogs
    {
        public static long CreateMiniBlog(MiniBlog miniBlog)
        {
            return DatabaseProvider.GetInstance().CreateMiniBlog(miniBlog);
        }

        public static long CreateQuoteMiniBlog(MiniBlog miniBlog)
        {
            return DatabaseProvider.GetInstance().CreateQuoteMiniBlog(miniBlog);
        }

        public static MiniBlog GetMiniBlogByIDCode(string idCode)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetMiniBlogByIDCode(idCode))
            {
                if (dr != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<MiniBlog> GetTop500MiniBlogsByQuery(string where, string sortField, string sortType)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetTop500MiniBlogsByQuery(where, sortField, sortType))
            {
                if (dt != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }
        public static MiniBlog GetMiniBlogByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetMiniBlogByID(id))
            {
                if (dr != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }
        public static IList<MiniBlog> GetMiniBlogsByUID(long uid,int pageIndex,int pageSize,ref int recordCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetMiniBlogsByUID(pageIndex,pageSize,ref recordCount,uid))
            {
                if (dt != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static bool DelMiniBlogByMID(long mid)
        {
            return DatabaseProvider.GetInstance().DelMiniBlogByMID(mid);
        }

        public static long AddFavorite(long mid, long uid)
        {
            return DatabaseProvider.GetInstance().AddFavorite(mid, uid);
        }
        public static bool DelFavorite(long mid, long uid)
        {
            return DatabaseProvider.GetInstance().DelFavorite(mid, uid);
        }

        public static IList<Favorite> GetFavorteByPager(int pageIndex, int pageSize, long uid,string key, ref int rowCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetFavorteByPager(pageIndex, pageSize, uid,key, ref rowCount))
            {

                if (dt != null)
                {
                    IList<Favorite> list = DbTranslate.Translate<Favorite>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<MiniBlog> GetAtMeByPager(int pageIndex, int pageSize, string key,int isFollow,int isOri,long uid, ref int rowCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetAtMeByPager(pageIndex, pageSize,key,isFollow,isOri,uid, ref rowCount))
            {

                if (dt != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<MiniBlog> SearchMiniBlog(int pageIndex, int pageSize, ref int rowCount, string key, int isOri, int location, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
             long curUid, string someone, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().SearchMiniBlog(pageIndex,pageSize,ref rowCount,key,isOri,location,startTime,endTime,isMyself,isMyFollow,curUid,someone,isHavePic,isHaveLink,isHaveVideo,isHaveMusic,isHaveVote,sort,GroupID,IsFriendShip))
            {

                if (dt != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static IList<MiniBlog> SearchMiniBlogForMbIndexAdvanced(int pageIndex, int pageSize, ref int rowCount, string key, int isOri,int isRet,DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
     long curUid, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().SearchMiniBlogForMbIndexAdvanced(pageIndex, pageSize, ref rowCount, key, isOri,isRet, startTime, endTime, isMyself, isMyFollow, curUid, isHavePic, isHaveLink, isHaveVideo, isHaveMusic, isHaveVote, sort, GroupID, IsFriendShip))
            {

                if (dt != null)
                {
                    IList<MiniBlog> list = DbTranslate.Translate<MiniBlog>(dt);
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
