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
	public class Topics
	{
		public static long CreateTopic(Topic topic)
		{
			return DatabaseProvider.GetInstance().CreateTopic(topic);
		}
		public static bool DelTopic(long id)
		{
			return DatabaseProvider.GetInstance().DelTopic(id);
		}

        public static bool UpdateTopicForRefCount(long id)
		{
            return DatabaseProvider.GetInstance().UpdateTopicForRefCount(id);
		}


		public static IList<Topic> GetTopicsBySearch(string searchName)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetTopicsBySearch(searchName))
			{
				if (dt != null)
				{
					IList<Topic> list = DbTranslate.Translate<Topic>(dt);
					if (list != null && list.Count > 0)
					{
						return list;
					}
				}
			}
			return null;
		}

		public static Topic GetTopicByName(string Name)
		{
			using (IDataReader dr = DatabaseProvider.GetInstance().GetTopicByName(Name))
			{
				if (dr != null)
				{
					IList<Topic> list = DbTranslate.Translate<Topic>(dr);
					dr.Close();
					if (list != null && list.Count > 0)
					{
						return list[0];
					}
				}
			}
			return null;
		}

		public static IList<Topic> GetTopicsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetTopicsByPager(pageIndex,pageSize,where,ref rowCount))
			{
				if (dt != null)
				{
					IList<Topic> list = DbTranslate.Translate<Topic>(dt);
					if (list != null && list.Count > 0)
					{
						return list;
					}
				}
			}
			return null;
		}

		public static long CreateStatisticTopic(StatisticTopic st)
		{
			return DatabaseProvider.GetInstance().CreateStatisticTopic(st);
		}
		public static bool DelAllStaticTopic()
		{
			return DatabaseProvider.GetInstance().DelAllStaticTopic();
		}
		public static IList<StatisticTopic> GetTopStaticTopic(DateTime startTime, DateTime endTime, int topCount)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetTopStaticTopic(startTime,endTime,topCount))
			{
				if (dt != null)
				{
					IList<StatisticTopic> list = DbTranslate.Translate<StatisticTopic>(dt);
					if (list != null && list.Count > 0)
					{
						return list;
					}
				}
			}
			return null;
		}

		public static long CreateUserTopic(UserTopic ut)
		{
			return DatabaseProvider.GetInstance().CreateUserTopic(ut);
		}
		public static bool  DelUserTopic(long id)
		{
			return DatabaseProvider.GetInstance().DelUserTopic( id);
		}

		public static UserTopic GetUserTopicByName(string Name)
		{
			using (IDataReader dr = DatabaseProvider.GetInstance().GetUserTopicByName(Name))
			{
				if (dr != null)
				{
					IList<UserTopic> list = DbTranslate.Translate<UserTopic>(dr);
					dr.Close();
					if (list != null && list.Count > 0)
					{
						return list[0];
					}
				}
			}
			return null;
		}

		public static IList<UserTopic> GetUserTopicByUID(long uid)
		{
			using (DataTable dt = DatabaseProvider.GetInstance().GetUserTopicByUID(uid))
			{
				if (dt != null)
				{
					IList<UserTopic> list = DbTranslate.Translate<UserTopic>(dt);
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
