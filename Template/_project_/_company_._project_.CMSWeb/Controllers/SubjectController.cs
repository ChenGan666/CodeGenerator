using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.CMSWeb.Helpers;
using FJData.Utils.Core.Extensions;

namespace _company_._project_.CMSWeb.Controllers
{
    public class SubjectController : BaseController
    {
        [Route("subject/{subject}")]
        public IActionResult Index(string subject, int pageNum = 1)
        {
            if (subject.IsNullOrEmpty())
                return Error404("错误");
            var sort = ContentSortHelper.SortList.FirstOrDefault(t => t.Filename == subject);
            if (sort == null)
                return Error404("错误");
            pageNum = pageNum <= 0 ? 1 : pageNum;
            var pageSize = CMSConfig.GetInt($"{subject}PageSize", CMSConfig.GetInt("pageSize", 10));
            string strWhere = "";
            if (sort.Pcode == "0")
            {
                var sorts = ContentSortHelper.SortList.Where(t => t.Tcode == sort.Scode).ToList();
                var scope = string.Join(",", sorts.Select(t => $"'{t.Scode}'"));
                strWhere = $"scode in ({scope})";
            }
            else
            {
                strWhere = $"scode='{sort.Scode}'";
            }
            var contentList = CmsContentBussiness.GetListByPage(pageSize, pageNum, strWhere, out int pageTotal, out int total, 1, "*", "date");
            contentList.ForEach(t => t.ContentSort = ContentSortHelper.SortList.FirstOrDefault(s => t.Scode == s.Scode));
            ViewBag.ContentList = contentList;
            SetPosition(sort.Scode);
            SetPage(pageNum, pageSize,pageTotal, total);
            ContentSortHelper.SetCurrentSort(sort.Id);
            var tpl = sort.Listtpl.IsNullOrEmpty() ? sort.Contenttpl : sort.Listtpl;
            return View(tpl);
        }

        [Route("subject/{subject}/{id}")]
        public IActionResult Detail(string subject, int id)
        {
            if (subject.IsNullOrEmpty())
                return Error404("错误");
            var sort = ContentSortHelper.SortList.FirstOrDefault(t => t.Filename == subject);
            if (sort == null)
                return Error404("错误");
            var content = CmsContentBussiness.GetModel(id);
            if (content == null)
                return Error404("错误");
            content.ContentSort = ContentSortHelper.SortList.FirstOrDefault(s => content.Scode == s.Scode);
            content.PreContent = CmsContentBussiness.GetList(1, $"date < '{content.Date.ToCurrentTime()}' and scode='{sort.Scode}'", "date desc").FirstOrDefault();
            content.NexContent = CmsContentBussiness.GetList(1, $"date > '{content.Date.ToCurrentTime()}' and scode='{sort.Scode}'", "date asc").FirstOrDefault();
            if (content.PreContent != null) 
                content.PreContent.ContentSort = content.ContentSort;
            if (content.NexContent != null)
                content.NexContent.ContentSort = content.ContentSort;
            content.PreLink = content.PreContent == null ? "没有了！" : $"<a href=\"{content.PreContent.Link}\">{content.PreContent.Title}</a>";
            content.NextLink = content.NexContent == null ? "没有了！" : $"<a href=\"{content.NexContent.Link}\">{content.NexContent.Title}</a>";
            ViewBag.Content = content;
            SetPosition(sort.Scode);
            ContentSortHelper.SetCurrentSort(sort.Id);
            return View(sort.Contenttpl);
        }
    }
}