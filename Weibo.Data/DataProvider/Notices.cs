using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Collections;
using Weibo.Entity;
using System.Data;
namespace Weibo.Data
{
    public class Notices
    {
        public static long CreateNotice(Notice notice)
        {
            return DatabaseProvider.GetInstance().CreateNotice(notice);
        }

        public static bool DelNotice(long id)
        {
            return DatabaseProvider.GetInstance().DelNotice(id);
        }

        public static IList<Notice> GetNoticesByPager(string where, int pageIndex, int pageSize, ref int recordCount)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetNoticesByPager(pageIndex, pageSize, where, ref recordCount))
            {
                if (dt != null)
                {
                    IList<Notice> list = DbTranslate.Translate<Notice>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Notice GetNoticeByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetNoticeByID(id))
            {
                if (dr != null)
                {
                    IList<Notice> list = DbTranslate.Translate<Notice>(dr);
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
