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
    public class SitemapController : BaseController
    {
        public IActionResult Index()
        {
            Response.Headers.Add("Content-type", "text/xml;charset=utf-8");
            var str = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            str += "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:mobile=\"http://www.baidu.com/schemas/sitemap-mobile/1/\">'\n";
            str += MakeNode("", DateTime.Now.ToString("yyyy-MM-dd"), 1.00M); // 根目录

            var urlBreakChar = CMSConfig.GetString("url_break_char", "_");
            var sorts = CmsContentSortBussiness.GetSorts();
            foreach (var s in sorts)
            {
                if (!s.Outlink.IsNullOrEmpty())
                {
                    continue;
                }
                else if (s.Type == 1)
                {
                    s.UrlName = s.UrlName.IsNullOrEmpty() ? "list" : s.UrlName;
                    string link;
                    if (!s.Filename.IsNullOrEmpty())
                    {
                        link = Url.Action("Index", "Subject", new { subject = s.Filename });
                    }
                    else
                    {
                        link = Url.Action("Index", "Subject", new { subject = s.Filename + urlBreakChar + s.Scode });
                    }
                    str += MakeNode(link, DateTime.Now.ToString("yyyy-MM-dd"), 0.80M);
                }
                else
                {
                    s.UrlName = s.UrlName.IsNullOrEmpty() ? "list" : s.UrlName;
                    string link;
                    if (!s.Filename.IsNullOrEmpty())
                    {
                        link = Url.Action("Index", "Subject", new { subject = s.Filename });
                    }
                    else
                    {
                        link = Url.Action("Index", "Subject", new { subject = s.Filename + urlBreakChar + s.Scode });
                    }
                    str += MakeNode(link, DateTime.Now.ToString("yyyy-MM-dd"), 0.80M);
                    var contents = CmsContentSortBussiness.GetSortContent(s.Scode);
                    foreach (var s2 in contents)
                    {
                        if (!s2.Outlink.IsNullOrEmpty())
                        {
                            continue;
                        }
                        else
                        {
                            s2.UrlName = s2.UrlName.IsNullOrEmpty() ? "list" : s2.UrlName;
                            if (!s2.Filename.IsNullOrEmpty() && !s2.SortFilename.IsNullOrEmpty())
                            {
                                link = Url.Action("Index", "Subject", new { subject = s2.SortFilename + "/" + s2.Filename });
                            }
                            else if (!s2.SortFilename.IsNullOrEmpty())
                            {
                                link = Url.Action("Index", "Subject", new { subject = s2.SortFilename + "/" + s2.Id });
                            }
                            else if(!s2.ContentFilename.IsNullOrEmpty()) {
                                link = Url.Action("Index", "Subject", new { subject = s2.UrlName + urlBreakChar + s2.Scode + "/" + s2.Filename });
                            } else
                            {
                                link = Url.Action("Index", "Subject", new { subject = s2.UrlName + urlBreakChar + s2.Scode + "/" + s2.Id });
                            }
                        }
                        str += MakeNode(link, DateTime.Now.ToString("yyyy-MM-dd"), 0.80M);
                    }
                }
            }
            str += "\n</urlset>";
            return Content(str);
        }

        // 生成结点信息
        private string MakeNode(string link, string date, decimal priority = 0.60M)
        {
            var node = $@"
<url>
    <mobile:mobile type=""pc,mobile""/>
    <loc>{GlobalLabel.HttpUrl}{link}</loc>
    <priority>{priority}</priority>
    <lastmod>{date}</lastmod>
    <changefreq>Always</changefreq>
</url>";
            return node;
        }
    }
}