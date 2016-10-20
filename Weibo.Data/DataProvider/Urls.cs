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
    public class Urls
    {
        public static Url GetUrlByShortLink(string shortLink)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetUrlByShortLink(shortLink))
            {
                if (dr != null)
                {
                    IList<Url> list = DbTranslate.Translate<Url>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static long CreateUrl(Url url)
        {
            return DatabaseProvider.GetInstance().CreateUrl(url);
        }

        public static bool DelUrl(long id)
        {
            return DatabaseProvider.GetInstance().DelUrl(id);
        }

        public static bool UpdateUrlForRefCount(long id)
        {
            return DatabaseProvider.GetInstance().UpdateUrlForRefCount(id);
        }

        public static bool UpdateUrlForMedia(long id,long mediaID,int type)
        {
            return DatabaseProvider.GetInstance().UpdateUrlForMedia(id,mediaID,type);
        }
    }
}
