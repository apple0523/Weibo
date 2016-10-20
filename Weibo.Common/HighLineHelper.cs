using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Weibo.Common
{
    public class HighLineHelper
    {
        private static string replaceKeyword(System.Text.RegularExpressions.Match m)
        {
            return "<span style='color:red'>" + m.Result("$0") + "</span>";
        }


        public static string HighLine(string input, string keyword)
        {
            Regex reg = new Regex(@"<(.[^>]*)>", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(input);
            string temp = "";
            string temp1 = input;
            if (matches != null && matches.Count > 0)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string str = "";
                    if (i == 0)
                    {
                        str = temp1.Substring(0, matches[0].Index);
                        str = new Regex(keyword, RegexOptions.IgnoreCase).Replace(str, replaceKeyword);
                        str += temp1.Substring(matches[0].Index, matches[0].Length);
                    }
                    else
                    {
                        string s = temp1.Substring(matches[i - 1].Index + matches[i - 1].Length, matches[i].Index - matches[i - 1].Index - matches[i - 1].Length);
                        s = new Regex(keyword, RegexOptions.IgnoreCase).Replace(s, replaceKeyword);
                        str = s + temp1.Substring(matches[i].Index, matches[i].Length);


                    }
                    if (i == matches.Count - 1)
                    {
                        string s1 = temp1.Substring(matches[i].Index + matches[i].Length);
                        s1 = new Regex(keyword, RegexOptions.IgnoreCase).Replace(s1, replaceKeyword);
                        str += s1;
                    }
                    temp += str;
                }
                return temp;
            }
            else
            {
                return new Regex(keyword, RegexOptions.IgnoreCase).Replace(input, replaceKeyword);
            }
        }
    }
}
