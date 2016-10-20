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
    public class Pics
    {
        public static Pic GetPicByID(long id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetPicByID(id))
            {
                if (dr != null)
                {
                    IList<Pic> list = DbTranslate.Translate<Pic>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static long CreatePic(Pic pic)
        {
            return DatabaseProvider.GetInstance().CreatePic(pic);
        }

        public static bool DelPic(long id)
        {
            return DatabaseProvider.GetInstance().DelPic(id);
        }
    }
}
