using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Common;
using Weibo.Config;
using System.Web;


namespace Weibo.Business
{
    public class Expressions
    {
        public static IList<Expression> GetAllExpression()
        {
            try
            {
                return Data.Expressions.GetAllExpressions();
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Expression GetExpressionByName(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return Data.Expressions.GetExpressionByName(name);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}
