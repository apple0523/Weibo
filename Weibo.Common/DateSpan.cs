using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Common
{
    public class DateSpan
    {
        public static string Get(DateTime past)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - past;
    
            
            if (past.Year == now.Year)
            {
                if (ts.Days < 1&&now.Day==past.Day)
                {
                    if (ts.Hours < 1)
                    {
                        if (ts.Minutes < 1)
                        {
                            return ts.Seconds.ToString() + "秒前";
                        }
                        return ts.Minutes.ToString() + "分钟前";
                    }
                    return "今天 " + past.ToString("HH:mm");
                }
                return string.Format("{0}月{1}日 {2}:{3}", past.Month.ToString(), past.Day.ToString(), past.Hour.ToString("#00"), past.Minute.ToString("#00"));
            }
            return string.Format("{4}-{0}-{1} {2}:{3}", past.Month.ToString(), past.Day.ToString(), past.Hour.ToString("#00"), past.Minute.ToString("#00"), past.Year.ToString());

        }
    }
}
