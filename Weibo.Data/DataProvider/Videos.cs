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
    public class Videos
    {
        public static Video GetVideoByID(long id)
        {
           using (IDataReader dr = DatabaseProvider.GetInstance().GetVideoByID(id))
            {
                if (dr != null)
                {
                    IList<Video> list = DbTranslate.Translate<Video>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static long CreateVideo(Video video)
        {
            return DatabaseProvider.GetInstance().CreateVideo(video);
        }

        public static bool DelVideo(long id)
        {
            return DatabaseProvider.GetInstance().DelVideo(id);
        }
    }
}


