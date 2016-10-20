using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
    namespace System.Web.Mvc.Html
    {
        public static class Extention
        {
            public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int CurrentIndex, int ItemCount, int PageSize)
            {
                string Link = htmlHelper.ViewContext.HttpContext.Request.Url.ToString();
                if (Link.Contains('?'))
                {
                    if (Link.Contains("page"))
                    {
                        Regex reg = new Regex(@"&*page=\d+", RegexOptions.IgnoreCase);
                        Link = reg.Replace(Link, "");
                    }
                    if (Link.Split('?')[1] == "")
                    {
                        Link += "page=";
                    }
                    else
                    Link += "&page=";
                }
                else
                {
                    Link += "?page=";
                }
                int pageNum = ItemCount / PageSize;
                if (ItemCount % PageSize > 0)
                    pageNum++;
                string divStr = "<div class='fanye MIB_txtbl rt'>{0}</div>";
                string pagerStr = "";
                if (pageNum > 1)
                {
                    if (CurrentIndex > 1)
                    {
                        pagerStr += string.Format("<a class='btn_num btn_numWidth' href='{0}'><em>上一页</em></a> ", Link + (CurrentIndex - 1).ToString());
                    }

                    if (pageNum < 6)
                    {
                        for (int i = 1; i <= pageNum; i++)
                        {
                            if (CurrentIndex == i)
                            {
                                pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                            }
                            else
                            {
                                pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (CurrentIndex < 4)
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("...<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + pageNum.ToString(), pageNum.ToString());

                        }
                        else if ((pageNum - 3) < CurrentIndex)
                        {
                            pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a>... ", Link + "1", "1");
                            for (int i = (pageNum - 4); i <= pageNum; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                        }
                        else if (CurrentIndex > 3 && (pageNum - 2) > CurrentIndex)
                        {
                            pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a>... ", Link + "1", "1");
                            for (int i = CurrentIndex - 2; i <= CurrentIndex + 2; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("...<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + pageNum.ToString(), pageNum.ToString());

                        }
                    }
                    if (CurrentIndex < pageNum)
                    {
                        pagerStr += string.Format("<a class='btn_num btn_numWidth' href='{0}'><em>下一页</em></a>", Link + (CurrentIndex + 1).ToString());
                    }

                    return MvcHtmlString.Create(string.Format(divStr, pagerStr));
                }
                else
                {
                    return MvcHtmlString.Empty;
                }
            }

            public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int CurrentIndex, int ItemCount, int PageSize,bool IsAjax)
            {
                string Link = htmlHelper.ViewContext.HttpContext.Request.Url.PathAndQuery;
                if (Link.Contains('?'))
                {
                    if (Link.Contains("page"))
                    {
                        Regex reg = new Regex(@"&*page=\d+", RegexOptions.IgnoreCase);
                        Link = reg.Replace(Link, "");
                    }
                    if (Link.Contains("Buffer"))
                    {
                        Regex reg = new Regex(@"&*Buffer=\d+", RegexOptions.IgnoreCase);
                        Link = reg.Replace(Link, "");
                    }
                    if (Link.Split('?')[1] == "")
                    {
                        Link += "page=";
                    }
                    else
                        Link += "&page=";
                }
                else
                {
                    Link += "?page=";
                 
                }
                if (IsAjax)
                    Link = "#!" + Link;
                int pageNum = ItemCount / PageSize;
                if (ItemCount % PageSize > 0)
                    pageNum++;
                string divStr = "<div class='fanye MIB_txtbl rt'>{0}</div>";
                string pagerStr = "";
                if (pageNum > 1)
                {
                    if (CurrentIndex > 1)
                    {
                        pagerStr += string.Format("<a class='btn_num btn_numWidth' href='{0}'><em>上一页</em></a> ", Link + (CurrentIndex - 1).ToString());
                    }

                    if (pageNum < 6)
                    {
                        for (int i = 1; i <= pageNum; i++)
                        {
                            if (CurrentIndex == i)
                            {
                                pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                            }
                            else
                            {
                                pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (CurrentIndex < 4)
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("...<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + pageNum.ToString(), pageNum.ToString());

                        }
                        else if ((pageNum - 3) < CurrentIndex)
                        {
                            pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a>... ", Link + "1", "1");
                            for (int i = (pageNum - 4); i <= pageNum; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                        }
                        else if (CurrentIndex > 3 && (pageNum - 2) > CurrentIndex)
                        {
                            pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a>... ", Link + "1", "1");
                            for (int i = CurrentIndex - 2; i <= CurrentIndex + 2; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<span>{0}</span> ", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("...<a class='btn_num' href='{0}'><em>{1}</em></a> ", Link + pageNum.ToString(), pageNum.ToString());

                        }
                    }
                    if (CurrentIndex < pageNum)
                    {
                        pagerStr += string.Format("<a class='btn_num btn_numWidth' href='{0}'><em>下一页</em></a>", Link + (CurrentIndex + 1).ToString());
                    }

                    return MvcHtmlString.Create(string.Format(divStr, pagerStr));
                }
                else
                {
                    return MvcHtmlString.Empty;
                }
            }

            public static MvcHtmlString NoticePager(this HtmlHelper htmlHelper, int CurrentIndex, int ItemCount, int PageSize)
            {
                string Link = htmlHelper.ViewContext.HttpContext.Request.Url.ToString();
                if (Link.Contains('?'))
                {
                    if (Link.Contains("page"))
                    {
                        Regex reg = new Regex(@"&*page=\d+", RegexOptions.IgnoreCase);
                        Link = reg.Replace(Link, "");
                    }
                    if (Link.Split('?')[1] == "")
                    {
                        Link += "page=";
                    }
                    else
                        Link += "&page=";
                }
                else
                {
                    Link += "?page=";
                }
                int pageNum = ItemCount / PageSize;
                if (ItemCount % PageSize > 0)
                    pageNum++;
                string divStr = " <div class=\"rt\"><ul class=\"lsfy_num\">{0}</ul></div>";
                string pagerStr = "";
                if (pageNum > 1)
                {
                    if (CurrentIndex > 1)
                    {
                        pagerStr += string.Format("<li class=\"lnk_first\"><a href=\"{0}\"><em>&lt;</em>上一页</a></li>", Link + (CurrentIndex - 1).ToString());
                    }

                    if (pageNum < 6)
                    {
                        for (int i = 1; i <= pageNum; i++)
                        {
                            if (CurrentIndex == i)
                            {
                                pagerStr += string.Format("<li class=\"current\"><a href=\"###\">{0}</a></li>", i.ToString());
                            }
                            else
                            {
                                pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li>", Link + i.ToString(), i.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (CurrentIndex < 4)
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<li class=\"current\"><a href=\"###\">{0}</a></li>", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li>", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("<li><a href=\"###\">...</a></li><li><a href=\"{0}\">{1}</a></li>", Link + pageNum.ToString(), pageNum.ToString());

                        }
                        else if ((pageNum - 3) < CurrentIndex)
                        {
                            pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li><li><a href=\"###\">...</a></li><li>", Link + "1", "1");
                            for (int i = (pageNum - 4); i <= pageNum; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<li class=\"current\"><a href=\"###\">{0}</a></li>", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li>", Link + i.ToString(), i.ToString());
                                }
                            }
                        }
                        else if (CurrentIndex > 3 && (pageNum - 2) > CurrentIndex)
                        {
                            pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li><li><a href=\"###\">...</a></li><li>", Link + "1", "1");
                            for (int i = CurrentIndex - 2; i <= CurrentIndex + 2; i++)
                            {
                                if (CurrentIndex == i)
                                {
                                    pagerStr += string.Format("<li class=\"current\"><a href=\"###\">{0}</a></li>", i.ToString());
                                }
                                else
                                {
                                    pagerStr += string.Format("<li><a href=\"{0}\">{1}</a></li>", Link + i.ToString(), i.ToString());
                                }
                            }
                            pagerStr += string.Format("<li><a href=\"###\">...</a></li><li><li><a href=\"{0}\">{1}</a></li>", Link + pageNum.ToString(), pageNum.ToString());

                        }
                    }
                    if (CurrentIndex < pageNum)
                    {
                        pagerStr += string.Format("<li class=\"lnk_last\"><a href=\"{0}\">下一页<em>&gt;</em></a></li>", Link + (CurrentIndex + 1).ToString());
                    }

                    return MvcHtmlString.Create(string.Format(divStr, pagerStr));
                }
                else
                {
                    return MvcHtmlString.Empty;
                }
            }



        }
    }