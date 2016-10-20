using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weibo.Web.Models
{
    public class JsonModel
    {
        public string Code { get; set; }
        public object Data { get; set; }
        public JsonModel(string code, object data)
        {
            Code = code;
            Data=data;
        }
    }

    public class PagerJsonModel : JsonModel
    {
        public int Count { get; set; }
        public PagerJsonModel(string code, object data,int count):base(code,data)
        {
            Count = count;
        }

    }

    public class VoteJsonModel : JsonModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public VoteJsonModel(string code, object data, string title,string url)
            : base(code, data)
        {
            this.Title = title;
            this.Url = url;
        }
    }

    public class AutoCompleteModel
    {
        public string Title { get; set; }
        public string NickName { get; set; }
        public long ID { get; set; }
    }

    public class simpleFollowModel:AutoCompleteModel
    {
        public string avatar { get; set; }
    }

   

    public struct CodeStruct
    {
        public static string HaveLogon = "A00000";
        public static string NoLogin = "A00001";
        public static string NoUserExist = "A00002";
        public static string Error = "A00003";
        public static string SaveSuccess = "A00004";
        public static string ReturnSuccess="A00005";
        public static string ParmsError = "A00006";
        public static string NotUrl = "A00007";
        public static string UploadSuccess = "A00008";
        public static string CreateSuccess = "A00009";
        public static string QuoteSuccess = "A00010";
        public static string NoMiniBlogExist = "A00011";
        public static string FavoriteSuccess = "A00012";
        public static string FavoriteCancel = "A00013";
        public static string VoteSuccess = "A00014";
        public static string ExistGroup = "A00015";
        public static string RepeatContent = "A00016";
        public static string NoResult = "A00017";
        public static string DelSuccess = "A00018";
        public static string MessageMyself = "A00019";
        public static string WrongPwd = "A00020";
        public static string ExceedTags = "A00021";
        public static string ExistTag = "A00022";
        public static string DelBlackList = "A00023";
        public static string ExistSite = "A00024";
        public static string ExistUserTopic = "A00025";
        public static string InBlackList = "A00026";
        public static string NotMsgToSb = "A00027";
        public static string NotCommentToSb = "A00028";
        public static string InMyBlackList = "A00029";
        public static string AddBlackList = "A00030";

        public static string ReportSuccess = "A00031";
    }
    
}