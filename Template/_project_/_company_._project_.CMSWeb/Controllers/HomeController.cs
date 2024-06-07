using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Senparc.CO2NET.Extensions;
using _company_._project_.BLL;
using _company_._project_.CMSWeb.Helpers;
using _company_._project_.Entity;

namespace _company_._project_.CMSWeb.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            _viewsDir = CMSConfig.GetString("tpl_html_dir");
        }

        private string _viewsDir;

        public IActionResult Index()
        {
            var sortList = ContentSortHelper.SortList;
            var contentSorts = sortList.Where(t => t.Pcode == "5").ToList();
            var contentSortScope = string.Join(",", contentSorts.Select(t => $"'{t.Scode}'"));
            var contentList = CmsContentBussiness.GetList(4, $"scode in ({contentSortScope})", "date desc");
            var newsSorts = sortList.Where(t => t.Pcode == "2").ToList();
            var newsSortScope = string.Join(",", newsSorts.Select(t => $"'{t.Scode}'"));
            var newsList = CmsContentBussiness.GetList(4, $"scode in ({newsSortScope})", "date desc");
            foreach (var c in contentList)
            {
                c.ContentSort = sortList.FirstOrDefault(t => t.Scode == c.Scode);
            }
            foreach (var news in newsList)
            {
                news.ContentSort = sortList.FirstOrDefault(t => t.Scode == news.Scode);
            }
            var content = CmsContentBussiness.GetList(1, "", "id asc").First();
            content.ContentSort = sortList.FirstOrDefault(t => t.Scode == "1");
            ViewBag.SlideList = CmsSlideBussiness.GetList();
            ViewBag.Content = content;
            ViewBag.SortList = sortList;
            ViewBag.ContentList = contentList;
            ViewBag.NewsList = newsList;
            SetPosition();
            ContentSortHelper.SetCurrentSort(0);
            return View();
        }


        public IActionResult Sitemap()
        {
            return null;
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
