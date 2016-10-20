using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Data
{
    public class DbFields
    {
        public const string USER = "[ID],[Email],[NickName],[Password],[BigAvartar],[MidAvartar],[SmallAvartar],[FocusCount],[FocusedCount],[MiniBlogCount],[Sex],[Location],[RegTime],[IP],[LastMID],[IsEmailValidate],[LastMContent],[LastInputContent],[LastUpdateDate],[RealName] ,[RealNameVisible],[BirthDay] ,[BirthDayVisible],[Blog],[BlogVisible],[ContactEmail],[ContactEmailVisible],[QQVisible],[QQ],[MSN],[MSNVisible],[Description],[Schools],[Companies],[Tags],[CustomSite]";
        public const string USERCONFIG = "[UID],[TipsArray],[ThemeID],[IsThemeDIY],[WaterMarkPosition],[WaterMarkStyle],[FollowCount],[CommentCount],[MsgCount],[AtmeCount],[AtcmtCount],[NoticeCount],[IsCommentTip],[IsFollowTip] ,[IsMsgTip],[IsAtTip],[IsNoticeTip],[IsCommentMe],[IsMsgMe]";
        public const string TYPE = "[ID],[Name],[PID],[CreateTime]";
        public const string MINIBLOG = "[ID],[IDCode],[OriginalContent],[MediaContent],[RealContent],[PicID],[UID],[OriginalMID],[OriginalMContent],[QuoteMID],[QuoteCount],[CommentCount],[CreateTime],[IsOriginal],[IsHavePic],[IsHaveLink],[IsHaveVideo],[IsHaveMusic],[IsHaveVote],[FromID],[ReferUID]";
        public const string EXPRESSION = "[ID],[Name],[Code],[Type],[Url],[OriUrl],[IsDefault],[IsTop],[CreateTime]";
        public const string COMPLAINT = "[ID],[UID],[ToUID],[ComplaintConType],[ComplaintConID] ,[ComplaintReason],[ComplaintSupplement],[CreateTime],[IsHandle],[HandleTime],[HandleResult]";
        public const string MESSAGE = "[ID],[UID],[ToUID],[Content],[Direction],[CreateTime]";
        public const string COMMENT = "[ID],[UID],[ReplyUID],[ReferUID],[Content],[MID],[MUID],[CreateTime],[ReplyContent]";
        public const string MUSIC = "[ID],[MusicUrl],[Title],[CreateTime]";
        public const string NOTICE = "[ID] ,[Title],[Content],[UID],[ToUID],[Type],[IsRead],[CreateTime]";
        public const string PIC = "[ID] ,[OriginalPicUrl],[MidPicUrl],[SmallPicUrl],[ThumPicUrl],[CreateTime]";
        public const string Tag = "[ID],[Name],[RefCount],[CreateTime]";
        public const string THEME = "[ID],[Name],[Type],[CssUrl],[IsRecommend] ,[CreateTime],[ThumPicUrl]";
        public const string TOPIC = "[ID],[Name] ,[RefCount],[CreateTime]";
        public const string URL = "[ID] ,[OriginalUrl],[ShortLink],[RefCount] ,[MediaID] ,[Type]";
        public const string VIDEO = "[ID],[Title],[ThumPicUrl],[FlvUrl],[OriUrl],[FromWeb],[CreatTime]";
        public const string VOTE = "[ID],[Title],[Remark],[PID] ,[CreateTime],[ExpireTime],[JoinCount],[Type] ,[UID],[OptionCount],[OnceSelCount],[ResultVisible]";
        public const string VOTEOPTION = "[ID],[Name],[VoteCount],[VID],[CreateTime]";
        public const string VOTEJOIN = "[ID],[VID],[UID],[SelVoteItemIDs],[SelVoteItemNames],[IsAnonymous],[CreateTime]";
        public const string FROM = "[ID],[FromName],[FromUrl],[FromCount],[CreateTime]";
        public const string THEMEDIY="[UID],[BgImgPid],[IsUseBg],[IsLockBg],[IsRepeatBg],[AlignStyleBg],[BgColor] ,[MainTxtColor],[MainLinkColor],[SubTxtColor],[SubLinkColor],[ContentColor],[BorderStyle]";
        public const string GROUP = "[ID],[Name],[UID],[CreateTime],[Sort]";
        public const string FOLLOW = "[UID],[FollowUID],[Remark],[LastContactTime],[GroupIDs],[CreateTime]";
        public const string CONTACT = " [ID],[UID],[ToUID],[Direction],[LastContactTime],[LastMID],[LastMContent],[MessageCount]";
        public const string SCHOOL = "[ID],[Name],[Location],[Type],[FrontLetter],[CreateTime]";
        public const string EDUCATION = "[ID] ,[UID],[SchoolID],[SchoolName],[IsVisible],[Type],[StartDate],[Remark],[CreateTime]";
        public const string COMPANY = "[ID],[Name],[CreateTime]";
        public const string CAREER = "[ID],[UID],[CompanyID],[CompanyName],[Location],[IsVisible],[StartDate],[EndDate],[Position],[CreateTime]";
        public const string USERTAG = "[ID],[UID],[TagID],[TagName],[CreateTime]";
        public const string BLACKLIST = "[ID],[UID],[PulledUID],[CreateTime]";
        public const string STATICTOPIC = "[ID],[TopicID],[TopicName],[RefCount],[CreateTime]";
        public const string USERTOPIC = "[ID],[UID],[TopicID],[TopicName],[CreateTime]";
        public const string LOG = "[ID],[TYPE],[CONTENT],[CREATETIME]";
    }
}
