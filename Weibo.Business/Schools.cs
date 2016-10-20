using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Schools
    {
        public static long CreateSchool(School school)
        {
            try
            {
                if (school == null)
                    return -1;
                return Data.Schools.CreateSchool(school);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static IList<School> GetShoolsByLetLocType(int Location, string letter,int type)
        {
            try
            {
                return Data.Schools.GetShoolsByLetLocType(Location, letter,type);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static School GetSchoolByID(int id)
        {
            try
            {
                if (id <=0)
                    return null;
                return Data.Schools.GetSchoolByID(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static IList<School> GetSchoolsByLikeName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return null;
                return Data.Schools.GetSchoolsByLikeName(name);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}
