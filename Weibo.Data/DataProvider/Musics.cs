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
    public class Musics
    {
        public static Music GetMusicByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetMusicByID(id))
            {
                if (dr != null)
                {
                    IList<Music> list = DbTranslate.Translate<Music>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static long CreateMusic(Music Music)
        {
            return DatabaseProvider.GetInstance().CreateMusic(Music);
        }


    }
}
