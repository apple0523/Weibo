using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Educations
    {
        public static long CreateEducation(Education education)
        {
            try
            {
                if (education == null)
                    return -1;
                return Data.Eduications.CreateEducation(education);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
            }
        }

        public static bool DelEducation(long id)
        {
            try
            {
                if (id <= 0)
                    return false;
                return Data.Eduications.DelEducation(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static bool UpdateEducation(Education education)
        {
            try
            {
                if (education == null)
                    return false;
                return Data.Eduications.UpdateEducation(education);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static IList<Education> GetEducationsByUID(long uid)
        {
            try
            {
                if (uid <= 0) return null;
                return Data.Eduications.GetEducationsByUID(uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static IList<Education> GetEducationsByIsVisible(long uid, int isVisible)
        {
            try
            {
                if (uid <= 0 && isVisible <= 0) return null;
                return Data.Eduications.GetEducationsByIsVisible(uid, isVisible);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
        public static Education GetEducationByID(long id)
        {
            try
            {
                if (id <= 0)
                    return null;
                return Data.Eduications.GetEducationByID(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }
    }
}