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
    public class Companies
    {
        public static int CreateCompany(Company company)
        {
            return DatabaseProvider.GetInstance().CreateCompany(company);
        }


        public static Company GetCompanysByName(string name)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetCompanysByName(name))
            {
                if (dr != null)
                {
                    IList<Company> list = DbTranslate.Translate<Company>(dr);
                    dr.Close();
                    if (list != null && list.Count > 0)
                    {
                        return list[0];
                    }
                }
            }
            return null;
        }

        public static IList<Company> GetCompanysByLikeName(string name)
        {
            using (DataTable dt = DatabaseProvider.GetInstance().GetCompanysByLikeName(name))
            {
                if (dt != null)
                {
                    IList<Company> list = DbTranslate.Translate<Company>(dt);
                    if (list != null && list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        public static Company GetCompanyByID(int id)
        {
            using (IDataReader dr = DatabaseProvider.GetInstance().GetCompanyByID(id))
            {
                if (dr != null)
                {
                    IList<Company> list = DbTranslate.Translate<Company>(dr);
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
