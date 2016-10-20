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
    public class Messages
    {
        public static long CreateMessage(Message message)
        {
            return DatabaseProvider.GetInstance().CreateMessage(message);
        }

        public static bool DelMessageByMID(long mid)
        {
            return DatabaseProvider.GetInstance().DelMessageByMID(mid);
        }
        public static bool DelMessageByUID(long uid,long toUid)
        {
            return DatabaseProvider.GetInstance().DelMessageByUID(uid,toUid);
        }
        public static IList<Message> GetMessagesByPager(string where, int pageIndex, int pageSize, ref int recordCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetMessagesByPager(pageIndex, pageSize,where, ref recordCount))
            {
                if (dt != null)
                {
                    IList<Message> list = DbTranslate.Translate<Message>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Message GetMessageByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetMessageByID(id))
            {
                if (dr != null)
                {
                    IList<Message> list = DbTranslate.Translate<Message>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Contact> GetContactByPager(string where, int pageIndex, int pageSize, ref int recordCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetContactByPager(pageIndex, pageSize, where, ref recordCount))
            {
                if (dt != null)
                {
                    IList<Contact> list = DbTranslate.Translate<Contact>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static bool DelContact(long uid, long uid1)
        {
            return DatabaseProvider.GetInstance().DelContact(uid,uid1);
        }
    }
}
