using System;

namespace Weibo.Common
{
    /// <summary>
    /// DNT自定义异常类。
    /// </summary>
    public class WeiboException : Exception
    {
        public WeiboException()
        {
            //
        }


        public WeiboException(string msg)
            : base(msg)
        {
            //
        }
    }
}
