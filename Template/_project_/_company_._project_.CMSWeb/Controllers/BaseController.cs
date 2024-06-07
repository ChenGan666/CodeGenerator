using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senparc.CO2NET.Extensions;
using _company_._project_.CMSWeb.Helpers;
using _company_._project_.Service.Attributes;
using _company_._project_.Service.Controllers;

namespace _company_._project_.CMSWeb.Controllers
{
    [RunTime]
    [SqlRecoder(RecoderType = SqlRecoder.SqlRecoderType.TXT)]
    public class BaseController : Controller
    {
        protected void SetPage(int pageNum, int pageSize, int pageTotal, int total)
        {
            ViewBag.PageNum = pageNum;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pageTotal;
            ViewBag.Total = total;
            ViewBag.PageShowNum = CMSConfig.GetInt("pageShowNum");
        }

        protected void SetPosition(string scode = "0", string separator = ">", string separatorIcon = "", string indexText = "首页", string indexIcon = "")
        {
            if (!separatorIcon.IsNullOrEmpty()) {
                separator = $"<i class=\"{separatorIcon}\"></i>";
            }
            else if(separator.IsNullOrEmpty()) {
                separator = ">>";
            }

            if (!indexIcon.IsNullOrEmpty()) {
                indexText = $"<i class=\"{indexIcon}\"></i>";
            }
            else if(indexText.IsNullOrEmpty()) {
                indexText = "首页";
            }

            var outHtml = $"<a href=\"/\" >{indexText}</a>";
            var sort = ContentSortHelper.SortList.FirstOrDefault(t => t.Scode == scode);
            var tmp = "";
            while (sort!= null)
            {
                tmp = $"{separator}<a href=\"{sort.Link}\">{sort.Name}</a>" + tmp;
                sort = sort.ParentSort;
            }
            ViewBag.Position = outHtml + tmp;
        }

        protected IActionResult Error404(string msg)
        {
            ViewBag.Msg = msg;
            return Content(msg);
        }

        #region 私有方法

        private Dictionary<string, string> GetContentDic()
        {
            return new Dictionary<string, string>();
        }

        #endregion
    }
}