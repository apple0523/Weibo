using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Weibo.Common;
using Weibo.Config;
namespace Weibo.Data
{
    public class DbGenerateID
    {
        private static object lockObject = new object();

        public static long GenerateID(ref string IDCode)
        {
            lock (lockObject)
            {
                long i= DateTime.Now.Ticks-BaseConfigs.GetStartDate.Ticks;
                IDCode= new SixtyTwoScale(i).ToString();
                return i;
            }
            
        }
    }
}
