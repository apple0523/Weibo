using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Companies
    {
        public static int CreateCompany(Company company)
        {
            try
            {
                if (company == null)
                    return -1;
                return Data.Companies.CreateCompany(company);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static Company GetCompanysByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return null;
                return Data.Companies.GetCompanysByName(name);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<Company> GetCompanysByLikeName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return null;
                return Data.Companies.GetCompanysByLikeName(name);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Company GetCompanyByID(int id)
        {
            try
            {
                if (id <= 0)
                    return null;
                return Data.Companies.GetCompanyByID(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}
