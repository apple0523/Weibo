using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weibo.Config
{
    [Serializable]
    public class TypeConfigInfo:IConfigInfo
    {
        #region root
        private int m_typeRoot=0;
        private int m_cityRoot=1;
        private int m_sexRoot = 2000;
        private int m_expressionRoot=3000;
        private int m_videoRoot = 4000;
        private int m_urlRoot = 4020;
        private int m_themeRoot = 4040;
        private int m_noticeRoot = 4060;
        private int m_schoolRoot = 4070;
        private int m_complaintConRoot = 4080;
        private int m_complaintReasonRoot = 4100;
        private int m_logRoot = 4110;

        #endregion 

        #region item
        private int m_video_youku = 40001;
        private int m_video_tudou = 4002;
        private int m_video_56 = 4003;
        private int m_video_ku6 = 4004;
        private int m_url_normal = 4021;
        private int m_url_video = 4022;
        private int m_url_music = 4023;
        private int m_url_vote = 4024;
        private int m_sex_male = 2001;
        private int m_sex_female = 2002;
        private int m_notice_sys = 4061;
        private int m_notice_normal = 4062;

        private int m_complaint_mb = 4081;
        private int m_complaint_cm = 4082;
        private int m_complaint_user = 4083;
        private int m_complaint_msg = 4084;

        private int m_log_error = 4111;

        #endregion
        public int TypeRoot 
        {
            get { return m_typeRoot; }
            set { m_typeRoot = value; }
        }

        public int CityRoot
        {
            get { return m_cityRoot; }
            set { m_cityRoot = value; }
        }

        public int SexRoot
        {
            get { return m_sexRoot; }
            set { m_sexRoot = value; }
        }

        public int ExpressionRoot
        {
            get { return m_expressionRoot; }
            set { m_expressionRoot = value; }
        }

        public int VideoRoot
        {
            get { return m_videoRoot; }
            set { m_videoRoot = value; }
        }

        public int VideoYouku
        {
            get { return m_video_youku; }
            set { m_video_youku = value; }
        }

        public int VideoTudou
        {
            get { return m_video_tudou; }
            set { m_video_tudou = value; }
        }
        public int Video56
        {
            get { return m_video_56; }
            set { m_video_56 = value; }

        }

        public int VideoKu6
        {
            get { return m_video_ku6; }
            set { m_video_ku6 = value; }
        }
        public int UrlRoot
        {
            get { return m_urlRoot; }
            set { m_urlRoot = value; }
        }
        public int UrlNormal
        {
            get { return m_url_normal; }
            set { m_url_normal = value; }
        }

        public int UrlVideo
        {
            get { return m_url_video; }
            set { m_url_video = value; }
        }

        public int UrlMusic
        {
            get { return m_url_music; }
            set { m_url_music = value; }
        }

        public int UrlVote
        {
            get { return m_url_vote; }
            set { m_url_vote = value; }
        }

        public int ThemeRoot
        {
            get { return m_themeRoot; }
            set { m_themeRoot = value; }
        }

        public int SexMale
        {
            get { return m_sex_male; }
            set { m_sex_male = value; }
        }

        public int SexFemale
        {
            get { return m_sex_female; }
            set { m_sex_female = value; }
        }

        public int NoticeRoot
        {
            get { return m_noticeRoot; }
            set { m_noticeRoot = value; }
        }

        public int NoticeSys
        {
            get { return m_notice_sys; }
            set { m_notice_sys = value; }
        }
        public int NoticeNormal
        {
            get { return m_notice_normal; }
            set { m_notice_normal = value; }
        }

        public int SchoolRoot
        {
            get { return m_schoolRoot; }
            set { m_schoolRoot = value; }
        }

        public int ComplaintConRoot
        {
            get { return m_complaintConRoot; }
            set { m_complaintConRoot = value; }
        }
        public int ComplaintReasonRoot
        {
            get { return m_complaintReasonRoot; }
            set { m_complaintReasonRoot = value; }
        }

        public int LogRoot {
            get { return m_logRoot; }
            set { m_logRoot = value; }
        }

        public int LogError
        {
            get { return m_log_error; }
            set { m_log_error = value; }
        }


        public int Complaint_mb
        {
            get { return m_complaint_mb; }
            set { m_complaint_mb = value; }
        }

        public int Complaint_cm
        {
            get { return m_complaint_cm; }
            set { m_complaint_cm = value; }
        }

        public int Complaint_user
        {
            get { return m_complaint_user; }
            set { m_complaint_user = value; }
        }

        public int Complaint_msg
        {
            get { return m_complaint_msg; }
            set { m_complaint_msg = value; }
        }
    }
}
