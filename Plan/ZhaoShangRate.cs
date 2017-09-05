using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Extends;
using System.Text.RegularExpressions;
using Model;
namespace Plan
{
    public class ZhaoShangRate
    {
        public List<RateModel> GetHtml()
        {
            string url = "http://fx.cmbchina.com/hq/";
            var http = new WebHttp();
            var html = http.WebReq(url);
            var  result = new List<RateModel>();
            
            var reg = new Regex("<div id=\"realRateInfo\">\\s+?<table [^*]+?</table>"); 
            var regVal = reg.Match(html).Value;
             
            var trReg = new Regex("<tr[^*]+?</tr>");
            var resList = trReg.Matches(regVal);

            for (int i = 0; i < resList.Count; i++)
            {
                var tds = new Regex("<td[^*]+?>(?<val>[^*]+?)</td>").Matches(resList[i].Value);
 
                result.Add(new RateModel()
                {
                    Name = tds[0].Groups["val"].Value.Trim(),
                    SpotVal = tds[6].Groups["val"].Value.Trim()
                }); 

            }
            return result;
        }

        /// <summary>
        /// 正则表达式取值
        /// </summary>
        /// <param name="HtmlCode">源码</param>
        /// <param name="RegexString">正则表达式</param>
        /// <param name="GroupKey">正则表达式分组关键字</param>
        /// <param name="RightToLeft">是否从右到左</param>
        /// <returns></returns>
        public string[] GetRegValue(string HtmlCode, string RegexString, string GroupKey, bool RightToLeft=false)
        {
            MatchCollection m;
            Regex r;
            if (RightToLeft == true)
            {
                r = new Regex(RegexString, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            }
            else
            {
                r = new Regex(RegexString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            m = r.Matches(HtmlCode);
            string[] MatchValue = new string[m.Count];
            for (int i = 0; i < m.Count; i++)
            {
                MatchValue[i] = m[i].Groups[GroupKey].Value;
            }
            return MatchValue;
        }


    }
}
