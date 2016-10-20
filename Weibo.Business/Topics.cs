using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
	public class Topics
	{
		public static long CreateTopic(Topic topic)
		{
			try
			{
				if (topic == null)
					return -1;
				return Data.Topics.CreateTopic(topic);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return -1;
			}
		}

		public static bool DelTopic(long id)
		{
			try
			{
				if (id<=0)
					return false;
				return Data.Topics.DelTopic(id);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
			}
		}

        public static bool UpdateTopicForRefCount(long id)
		{
			try
			{
				if (id <= 0)
					return false;
                return Data.Topics.UpdateTopicForRefCount(id);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
			}
		}

		


		public static IList<Topic> GetTopicsBySearch(string searchName)
		{
			try
			{
				if (string.IsNullOrEmpty(searchName))
					return null;
				return Data.Topics.GetTopicsBySearch(searchName);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}

		public static Topic GetTopicByName(string Name)
		{
			try
			{
				if (string.IsNullOrEmpty(Name))
					return null;
				return Data.Topics.GetTopicByName(Name);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}

		public static IList<Topic> GetTopicsByPager(int pageIndex, int pageSize, string where, ref int rowCount)
		{
			try
			{
				return Data.Topics.GetTopicsByPager(pageIndex, pageSize, where, ref rowCount);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}

		public static long CreateStatisticTopic(StatisticTopic st)
		{
			try
			{
				if (st == null)
					return -1;
				return Data.Topics.CreateStatisticTopic(st);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return -1;
			}
		}

		public static bool DelAllStaticTopic()
		{
			try
			{
			
				return Data.Topics.DelAllStaticTopic();
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
			}
		}

		public static IList<StatisticTopic> GetTopStaticTopic(DateTime startTime, DateTime endTime, int topCount)
		{
			try
			{

				return Data.Topics.GetTopStaticTopic(startTime,endTime,topCount);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}

		public static long CreateUserTopic(UserTopic ut)
		{
			try
			{
				if (ut == null)
					return -1;
				return Data.Topics.CreateUserTopic(ut);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return -1;
			}
		}

		public static bool DelUserTopic(long id)
		{
			try
			{
				if (id <= 0) return false;
				return Data.Topics.DelUserTopic(id);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return false;
			}
		}

		public static UserTopic GetUserTopicByName(string Name)
		{
			try
			{
				if (string.IsNullOrEmpty(Name))
					return null;
				return Data.Topics.GetUserTopicByName(Name);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}

		public static IList<UserTopic> GetUserTopicByUID(long uid)
		{
			try
			{
				if (uid <= 0) return null;
				return Data.Topics.GetUserTopicByUID(uid);
			}
			catch (Exception ex)
			{
                Logs.WriteErrorLog(ex);
				return null;
			}
		}


        public static long SaveTopic(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                return -1;
            Topic t = GetTopicByName(Name);
            if (t == null)
            {
                t = new Topic();
                t.Name = Name;
                t.ID = CreateTopic(t);
                if (t.ID <= 0)
                    return -1;
            }
            UpdateTopicForRefCount(t.ID);
            StatisticTopic st = new StatisticTopic();
            st.TopicID = t.ID;
            st.TopicName = t.Name;
            st.ID = CreateStatisticTopic(st);
            return t.ID;
        }
	}
}
