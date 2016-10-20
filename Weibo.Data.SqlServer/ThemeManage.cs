using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Weibo.Data;
using System.Data.Common;
using System.Data;
using Weibo.Entity;
using Weibo.Common;

namespace Weibo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        public int CreateTheme(Theme theme)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,100,theme.Name),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,theme.Type),
                DbHelper.MakeInParam("@CssUrl",(DbType)SqlDbType.NVarChar,200,theme.CssUrl),
                DbHelper.MakeInParam("@IsRecommend",(DbType)SqlDbType.Int,4,theme.IsRecommend),
                DbHelper.MakeInParam("@ThumPicUrl",(DbType)SqlDbType.NVarChar,200,theme.ThumPicUrl)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure,"CreateTheme",parms),-1);
        }

        public bool UpdateTheme(Theme theme)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@Name",(DbType)SqlDbType.NVarChar,100,theme.Name),
                DbHelper.MakeInParam("@Type",(DbType)SqlDbType.Int,4,theme.Type),
                DbHelper.MakeInParam("@CssUrl",(DbType)SqlDbType.NVarChar,200,theme.CssUrl),
                DbHelper.MakeInParam("@IsRecommend",(DbType)SqlDbType.Int,4,theme.IsRecommend),
                DbHelper.MakeInParam("@ThumPicUrl",(DbType)SqlDbType.NVarChar,200,theme.ThumPicUrl),
                DbHelper.MakeInParam("@TID",(DbType)SqlDbType.Int,4,theme.ID),
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateTheme", parms))==1;
        }

        public bool DelTheme(int id)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@TID",(DbType)SqlDbType.Int,4,id)
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "DelTheme", parms)) > 1;
        }

        public IDataReader GetThemeByID(int id)
        {
            return GetRowByID("TTheme", id, DbFields.THEME);
        }

        public DataTable GetThemesByType(int type)
        {
            string where = "Type=" + type.ToString();
            return GetTableByQuery("TTheme", where, DbFields.THEME);
        }

        public DataTable GetRecommendThemes()
        {
            string where = "IsRecommend=1" ;
            return GetTableByQuery("TTheme", where, DbFields.THEME);
        }

        public DataTable GetThemesByPager(int pageIndex, int pageSize, string where, ref int rowCount)
        {
            return Pager(pageIndex, pageSize, "TTheme", where, ref rowCount);
        }

        public int CreateThemeDIY(ThemeDIY diy)
        {
            DbParameter[] parms =
            {
                DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,diy.UID),
                DbHelper.MakeInParam("@AlignStyleBg",(DbType)SqlDbType.Int,4,diy.AlignStyleBg),
                DbHelper.MakeInParam("@BgColor",(DbType)SqlDbType.VarChar,50,diy.BgColor),
                DbHelper.MakeInParam("@BgImgPid",(DbType)SqlDbType.BigInt,8,diy.BgImgPid),
                DbHelper.MakeInParam("@BorderStyle",(DbType)SqlDbType.VarChar,50,diy.BorderStyle),
                DbHelper.MakeInParam("@ContentColor",(DbType)SqlDbType.VarChar,50,diy.ContentColor),
                DbHelper.MakeInParam("@IsLockBg",(DbType)SqlDbType.Int,4,diy.IsLockBg),
                DbHelper.MakeInParam("@IsRepeatBg",(DbType)SqlDbType.Int,4,diy.IsRepeatBg),
                DbHelper.MakeInParam("@IsUseBg",(DbType)SqlDbType.Int,4,diy.IsUseBg),
                DbHelper.MakeInParam("@MainLinkColor",(DbType)SqlDbType.VarChar,50,diy.MainLinkColor),
                DbHelper.MakeInParam("@MainTxtColor",(DbType)SqlDbType.VarChar,50,diy.MainTxtColor),
                DbHelper.MakeInParam("@SubLinkColor",(DbType)SqlDbType.VarChar,50,diy.SubLinkColor),
                DbHelper.MakeInParam("@SubTxtColor",(DbType)SqlDbType.VarChar,50,diy.SubTxtColor),
             };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteScalar(CommandType.StoredProcedure, "CreateThemeDIY", parms), -1);
        }

        public bool UpdateThemeDIY(ThemeDIY diy)
        {
            DbParameter[] parms =
            {
 DbHelper.MakeInParam("@UID",(DbType)SqlDbType.BigInt,8,diy.UID),
                DbHelper.MakeInParam("@AlignStyleBg",(DbType)SqlDbType.Int,4,diy.AlignStyleBg),
                DbHelper.MakeInParam("@BgColor",(DbType)SqlDbType.VarChar,50,diy.BgColor),
                DbHelper.MakeInParam("@BgImgPid",(DbType)SqlDbType.BigInt,8,diy.BgImgPid),
                DbHelper.MakeInParam("@BorderStyle",(DbType)SqlDbType.VarChar,50,diy.BorderStyle),
                DbHelper.MakeInParam("@ContentColor",(DbType)SqlDbType.VarChar,50,diy.ContentColor),
                DbHelper.MakeInParam("@IsLockBg",(DbType)SqlDbType.Int,4,diy.IsLockBg),
                DbHelper.MakeInParam("@IsRepeatBg",(DbType)SqlDbType.Int,4,diy.IsRepeatBg),
                DbHelper.MakeInParam("@IsUseBg",(DbType)SqlDbType.Int,4,diy.IsUseBg),
                DbHelper.MakeInParam("@MainLinkColor",(DbType)SqlDbType.VarChar,50,diy.MainLinkColor),
                DbHelper.MakeInParam("@MainTxtColor",(DbType)SqlDbType.VarChar,50,diy.MainTxtColor),
                DbHelper.MakeInParam("@SubLinkColor",(DbType)SqlDbType.VarChar,50,diy.SubLinkColor),
                DbHelper.MakeInParam("@SubTxtColor",(DbType)SqlDbType.VarChar,50,diy.SubTxtColor),
            };
            return TypeConverter.ObjectToInt(DbHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateThemeDIY", parms)) == 1;
        }

        public IDataReader GetThemeDIYByUID(long uid)
        {
            return GetRowByQuery("TThemeDIY", "UID=" + uid.ToString(), DbFields.THEMEDIY);
        }

    }
}
