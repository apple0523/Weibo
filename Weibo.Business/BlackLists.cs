using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
	public class BlackLists
	{
		public static long CreateBlackList(BlackList blackList )
		{
			try
			{
				if (blackList == null)
					return -1;
				return Data.BlackLists.CreateBlackList(blackList);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return -1;
			}
		}

		public static bool DelBlackList(long id)
		{
			try
			{
				if (id<=0)
					return false;
				return Data.BlackLists.DelBlackList(id);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
                
			}
		}

        public static bool DelBlackListByUID(long uid,long pulledUid)
        {
            try
            {
                if (uid <= 0||pulledUid<=0)
                    return false;
                return Data.BlackLists.DelBlackListByUID(uid,pulledUid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
              
            }
        }

		public static bool IsInBlackList(long uid,long pulledUid)
		{
			try
			{
				if (uid <= 0||pulledUid<=0)
					return false;
				return Data.BlackLists.IsInBlackList(uid,pulledUid);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
                
			}
		}

		public static IList<BlackList> GetBlackListByUID(long uid)
		{
			try
			{
				if (uid <= 0)
					return null;
				return Data.BlackLists.GetBlackListByUID(uid);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
                
			}
		}

		public static IList<BlackList> GetMyBlackList(int pageIndex, int pageSize,long uid,ref int rowCount)
		{
			try
			{
				string where = "UID=" + uid.ToString();
				return Data.BlackLists.GetBlackListByPager(pageIndex,pageSize,where,ref rowCount);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
                
			}
		}


	}
}
