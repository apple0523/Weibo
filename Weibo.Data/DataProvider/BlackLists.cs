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
	public class BlackLists
	{
		public static long CreateBlackList(BlackList blackList)
		{
			return DatabaseProvider.GetInstance().CreateBlackList(blackList);
		}
		public static bool DelBlackList(long id)
		{
			return DatabaseProvider.GetInstance().DelBlackList(id);
		}

        public static bool DelBlackListByUID(long uid,long pulledUid)
        {
            return DatabaseProvider.GetInstance().DelBlackListByUID(uid,pulledUid);
        }

		public static bool IsInBlackList(long uid, long pulledUid)
		{
			return DatabaseProvider.GetInstance().IsInBlackList(uid,pulledUid);
		}

		public static IList<BlackList> GetBlackListByUID(long uid)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetBlackListByUID(uid))
			{
				if (dt != null)
				{
					IList<BlackList> list = DbTranslate.Translate<BlackList>(dt);
					if (list != null && list.Count > 0)
					{
						return list;
					}
				}
			}
			return null;
		}

		public static IList<BlackList> GetBlackListByPager(int pageIndex, int pageSize, string where, ref int rowCount)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetBlackListByPager(pageIndex,pageSize,where,ref rowCount))
			{
				if (dt != null)
				{
					IList<BlackList> list = DbTranslate.Translate<BlackList>(dt);
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
