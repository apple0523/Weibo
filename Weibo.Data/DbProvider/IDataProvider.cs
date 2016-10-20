using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;

using Weibo.Entity;

namespace Weibo.Data
{
    public partial interface IDataProvider
    {
        #region User
        long CreateUser(User user);
        IDataReader GetUersByID(long id);
        bool UpdateUser(User user);
        IDataReader GetUerByEmail(string email);
        DataTable GetUsersByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetUserByNickName(string nickName);
        IDataReader GetUserConfigByID(long id);
        IDataReader GetUserByID(long id);
        bool IsHaveCustomSite(string CustomSite);
        bool CreateFollow(long uid, long fuid, string remark, string GroupIDs);
        bool DelFollow(long fuid, long uid);
        bool UpdateFollowRemark(long fuid, long uid, string remark);
        bool UpdateFollowGroupID(long fuid, long uid, string groupIDs);
        bool UpdateUserConfig(UserConfig uc);
        DataTable GetMyFollowByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount);
        DataTable GetMyFanByPager(long uid,int pageIndex, int pageSize, string where, string orderby, ref int rowCount);
        IDataReader GetFollowByFuid(long fuid, long uid);
        DataTable SearchUser(int pageIndex, int pageSize, ref int rowCount, string key, string school, string tag, string career, int location, int sex, DateTime? birthDayStart, DateTime? birthDayEnd);
        int GetRelateBetweenUsers(long UID, long WithUID);
        DataTable GetTop10UsersByQuery(string where, string sortField, string sortType);
        bool UpdateCfgFollowCount(long uid);
        bool UpdateCfgNoticeCount(long uid);
        bool UpdateCfgAtcmtCount(long uid);
        bool UpdateCfgAtmeCount(long uid);
        bool UpdateCfgMsgCount(long uid);
        bool UpdateCfgCommentCount(long uid);
        bool UpdateAllCfgNoticeCount();
        bool ClearAllTipCount(long uid);
        bool ClearCfgNoticeCount(long uid);
        bool ClearCfgCommentCount(long uid);
        bool ClearCfgFollowCount(long uid);
        bool ClearCfgMsgCount(long uid);
        bool ClearCfgAtmeCount(long uid);
        bool ClearCfgAtcmtCount(long uid);
        IDataReader GetUerByCustomSite(string CustomSite);
        DataTable GetOtherFanByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount);
        DataTable GetOtherFollowByPager(long otherUid, long curUid, int pageIndex, int pageSize, string where, string orderby, ref int rowCount);
        #endregion

        #region Type
        DataTable GetTypesByPID(int pid);
        IDataReader GetTypeByID(int id);
        #endregion

        #region MiniBlog
        long CreateMiniBlog(MiniBlog miniBlog);
        DataTable GetMiniBlogsByUID(int pageIndex, int pageSize, ref int rowCount, long uid);
        IDataReader GetMiniBlogByIDCode(string idCode);
        bool DelMiniBlogByMID(long mid);
        DataTable GetMiniBlogsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetMiniBlogByID(long id);
        long CreateQuoteMiniBlog(MiniBlog miniBlog); 
        long AddFavorite(long mid, long uid);
        bool DelFavorite(long mid, long uid);
        DataTable GetFavorteByPager(int pageIndex, int pageSize, long uid, string key, ref int rowCount);
        DataTable GetAtMeByPager(int pageIndex, int pageSize,  string key, int isFollow, int isOri, long uid, ref int rowCount);
        DataTable SearchMiniBlog(int pageIndex, int pageSize, ref int rowCount, string key, int isOri, int location, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
            long curUid, string someone, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip);
        DataTable GetTop500MiniBlogsByQuery(string where, string sortField, string sortType);
        DataTable SearchMiniBlogForMbIndexAdvanced(int pageIndex, int pageSize, ref int rowCount, string key, int isOri,int isRet, DateTime? startTime, DateTime? endTime, int isMyself, int isMyFollow,
            long curUid, int isHavePic, int isHaveLink, int isHaveVideo, int isHaveMusic, int isHaveVote, string sort, long GroupID, int IsFriendShip);
        #endregion

        #region Comment
        long CreateComment(Comment comment);
        bool DelCommentByCID(long cid);
        DataTable GetTop10CommentsByMid(long mid);
        DataTable GetCommentsByMid(int pageIndex, int pageSize, long mid, long uid, int isFollow, ref int rowCount);
        DataTable GetCommentsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetCommentByID(long id);
        int GetCommentCountByMID(long Mid);
        DataTable GetAtCommentsByPager(int pageIndex, int pageSize, long uid, string key, int isFollow, ref int rowCount);
        DataTable GetRecCommentsByPager(int pageIndex, int pageSize, long uid, int isFollow, string key, ref int rowCount);
        DataTable GetSendCommentsByPager(int pageIndex, int pageSize, long uid, string key, ref int rowCount);
        #endregion

        #region Complaint
        long CreateComplaint(Complaint complaint);
        bool DelComplaint(long complaintID);
        bool HandleComplaint(long complaintID,DateTime HandleTime,string HandleResult);
        DataTable GetComplaintsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetComplaintByID(long id);
        #endregion

        #region Expression
        int CreateExpression(Expression expression);
        bool UpdateExpression(Expression expression);
        bool DelExpression(int eid);
        DataTable GetExpressionsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetExpressionByID(int id);
        DataTable GetAllExpressions();
        IDataReader GetExpressionByName(string name);
        #endregion

        #region Message
        long CreateMessage(Message message);
        bool DelMessageByMID(long mid);
        bool DelMessageByUID(long uid, long toUid);
        DataTable GetMessagesByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetMessageByID(long id);
        DataTable GetContactByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        bool DelContact(long uid, long uid1);
        #endregion

        #region Music
        long CreateMusic(Music music);
        DataTable GetMusicsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetMusicByID(long id);
        #endregion

        #region Notice
        long CreateNotice(Notice notice);
        bool DelNotice(long id);
        bool ReadNotice(long id);
        DataTable GetNoticesByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        IDataReader GetNoticeByID(long id);
        #endregion

        #region Pic
        long CreatePic(Pic pic);
        bool DelPic(long id);
        IDataReader GetPicByID(long id);
        DataTable GetPicsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        #endregion

        #region Tag
        long CreateTag(Tag tag);
        bool DelTag(long id);
        IDataReader GetTagByID(long id);
        DataTable GetTagsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        bool UpdateTagForRefCount(long id);
        DataTable GetUserTagsByUID(long uid);
        IDataReader GetTagByName(string Name);
        long CreateUserTag(UserTag userTag);
        IDataReader GetUserTagByUidTagid(long tagId, long uid);
        bool DelUserTag(long id);
        int GetUserTagCount(long uid);
        IDataReader GetUserTagByNameUID(string Name,long uid);
        DataTable GetInterestTag(long uid);
        DataTable GetTop10TagsByQuery(string where, string sortField, string sortType);
        #endregion

        #region Theme
        int CreateTheme(Theme theme);
        bool UpdateTheme(Theme theme);
        bool DelTheme(int id);
        IDataReader GetThemeByID(int id);
        DataTable GetThemesByType(int type);
        DataTable GetRecommendThemes();
        DataTable GetThemesByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        int CreateThemeDIY(ThemeDIY diy); 
        bool UpdateThemeDIY(ThemeDIY diy);
        IDataReader GetThemeDIYByUID(long uid);
        #endregion

        #region Topic
        long CreateTopic(Topic topic);
        bool DelTopic(long id);
        bool UpdateTopicForRefCount(long id);
        DataTable GetTopicsBySearch(string searchName);
        IDataReader GetTopicByName(string Name);
        DataTable GetTopicsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        long CreateStatisticTopic(StatisticTopic st);
        bool DelAllStaticTopic();
        DataTable GetTopStaticTopic(DateTime startTime, DateTime endTime, int topCount);
        long CreateUserTopic(UserTopic ut);
        IDataReader GetUserTopicByName(string Name);
        bool DelUserTopic(long id);
        DataTable GetUserTopicByUID(long uid);
        #endregion

        #region Url
        long CreateUrl(Url url);
        bool DelUrl(long id);
        IDataReader GetUrlByShortLink(string shortLinkCode);
        DataTable GetUrlsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        bool UpdateUrlForRefCount(long id);
        bool UpdateUrlForMedia(long id,long MediaID,int type);
        #endregion

        #region Video
        long CreateVideo(Video video);
        bool DelVideo(long id);
        IDataReader GetVideoByID(long id);
        DataTable GetVideosByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        #endregion

        #region Vote
        long CreateVote(Vote vote);
        bool DelVote(long id);
        bool UpdateVoteForJoinCount(long id);
        bool UpdateVoteForExpireTime(DateTime expireTime, long id);
        IDataReader GetVoteByID(long id);
        DataTable GetVotesByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        DataTable GetVoteByUID(long uid);
        #endregion

        #region VoteOption
        long CreateVoteOption(VoteOption voteOption);
        IDataReader GetVoteOptionByID(long id);
        DataTable GetVoteOptionsByVID(long vid);
        bool UpdateVoteOptionForVoteCount(long id);
        #endregion

        #region VoteJoin
        IDataReader GetVoteJoinByUID(long uid, long vid);
        long CreateVoteJoin(VoteJoin voteJoin);
        #endregion
        #region From
        int CreateFrom(From from);
        IDataReader GetFromByID(int id);
        IDataReader GetFromByUrl(string url);
        DataTable GetFromsByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        bool UpdateFromForFromCount(int id);
        #endregion

        #region Group
        long CreateGroup(Group group);
        bool UpdateGroupName(long Gid, string Name);
        bool UpdateGroupSort(string SortList,long uid);
        bool DelGroup(long Gid);
        DataTable GetGroupsByUID(long UID);
        IDataReader GetGroupByID(long GID);
        IDataReader GetGroupByName(long UID, string Name);
        IDataReader GetTopSort(long UID);
        #endregion

        #region Base
        DataTable Pager(int pageIndex, int pageSize, string tableName, string where, ref int rowCount);
        IDataReader GetRowByID(string tableName, int id, string field);
        IDataReader GetRowByID(string tableName, long id, string field);
        IDataReader GetRowByQuery(string tableName, string query, string field);
        DataTable GetTableByQuery(string tableName, string query, string field);
        DataTable GetTableByQuery(string tableName, string query, string field, string sortField, string sortType);
        DataTable GetTop10TableByQuery(string tableName, string query, string field, string sortField, string sortType);
        DataTable GetAll(string tableName, string field, string sortField, string sortType);
        int GetCount(string tableName, string where);
        DataTable GetTableByOriQuery(string query);
        #endregion

        #region School
        int CreateSchool(School school);
        DataTable GetShoolsByLetLocType(int Location, string letter,int type);
        IDataReader GetSchoolByID(int id);
        DataTable GetSchoolsByLikeName(string name);
        #endregion

        #region Education
        long CreateEducation(Education education);
        IDataReader GetEducationByID(long id);
        DataTable GetEducationsByUID(long uid);
        DataTable GetEducationsByIsVisible(long uid, int isVisible);
        bool DelEducation(long id);
        bool UpdateEducation(Education education);
        #endregion

        #region Company
        int CreateCompany(Company company);
        IDataReader GetCompanysByName(string name);
        DataTable GetCompanysByLikeName(string name);
        IDataReader GetCompanyByID(int id);
        #endregion

        #region Career
        long CreateCareer(Career career);
        IDataReader GetCareerByID(long id);
        DataTable GetCareersByUID(long uid);
        DataTable GetCareersByIsVisible(long uid, int isVisible);
        bool DelCareer(long id);
        bool UpdateCareer(Career career);
        #endregion

        #region BlackList
        long CreateBlackList(BlackList blackList);
        bool DelBlackList(long id);
        bool IsInBlackList(long uid, long pulledUid);
        DataTable GetBlackListByUID(long uid);
        DataTable GetBlackListByPager(int pageIndex, int pageSize, string where, ref int rowCount);
        bool DelBlackListByUID(long uid, long pulledUid);
        #endregion

        #region Log
        long CreateLog(Log log);
        bool DelLog(long id);
        #endregion

    }
}
