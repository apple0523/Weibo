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
    public class Expressions
    {
        public static IList<Expression> GetAllExpressions()
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetAllExpressions())
            {
                if (dt != null)
                {
                    IList<Expression> list = DbTranslate.Translate<Expression>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
                return null;
            }
        }

        public static Expression GetExpressionByName(string name)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetExpressionByName(name))
            {
                if (dr != null)
                {
                    IList<Expression> list = DbTranslate.Translate<Expression>(dr);
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
