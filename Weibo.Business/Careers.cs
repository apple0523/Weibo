using System;
using System.Collections.Generic;
using System.Linq;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Config;
using Weibo.Common;

namespace Weibo.Business
{
    public class Careers
    {
        public static long CreateCareer(Career career)
        {
            try
            {
                if (career == null)
                    return -1;
                return Data.Careers.CreateCareer(career);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return -1;
                
            }
        }

        public static bool DelCareer(long id)
        {
            try
            {
                if (id <= 0)
                    return false;
                return Data.Careers.DelCareer(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
               
            }
        }

        public static bool UpdateCareer(Career career)
        {
            try
            {
                if (career == null)
                    return false;
                return Data.Careers.UpdateCareer(career);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
                
            }
        }

        public static IList<Career> GetCareersByUID(long uid)
        {
            try
            {
                if (uid <= 0) return null;
                return Data.Careers.GetCareersByUID(uid);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
             
            }
        }
        public static IList<Career> GetCareersByIsVisible(long uid, int isVisible)
        {
            try
            {
                if (uid <= 0 && isVisible <= 0) return null;
                return Data.Careers.GetCareersByIsVisible(uid, isVisible);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
                
            }
        }
        public static Career GetCareerByID(long id)
        {
            try
            {
                if (id <= 0)
                    return null;
                return Data.Careers.GetCareerByID(id);
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
               
            }
        }
    }
}
