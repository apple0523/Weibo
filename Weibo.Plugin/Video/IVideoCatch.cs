using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weibo.Config;


namespace Weibo.Plugin.Video
{
	public interface IVideoCatch
	{
		string VideoUrl { get; set; }
		VideoInfo Get();
		FromConst CheckUrl();
	}

	public class VideoInfo
	{
		public string Title { get; set; }
		public string FlvSrc { get; set; }
		public string ThumPic { get; set; }
		public string Url { get; set; }
        public FromConst FromWebSite { get; set; }
	}

	public enum FromConst
	{
		 YOUKU,
		KU6,
		TUDOU,
		_56,
		NOTVIDEO,
	}
}
