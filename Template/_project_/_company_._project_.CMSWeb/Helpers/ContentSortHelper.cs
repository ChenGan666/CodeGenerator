using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FJData.Utils.Core.DI;
using FJData.Utils.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using _company_._project_.BLL;
using _company_._project_.Entity;

namespace _company_._project_.CMSWeb.Helpers
{
    public class ContentSortHelper
    {
        private static IHttpContextAccessor ContextAccessor => ServiceLocator.GetInstance<IHttpContextAccessor>();

        private static HttpContext HttpContext => ContextAccessor?.HttpContext;

        private static ISession Session => HttpContext?.Session;

        private static string SortKey = "_SortKey_";

        public static CmsContentSort CurrentSort => GetCurrentSort();

        private static List<CmsContentSort> _sortList;

        public static List<CmsContentSort> SortList
        {
            get
            {
                if (_sortList == null)
                    InitSortList();
                return _sortList;
            }
        }

        static ContentSortHelper()
        {
            InitSortList();
        }

        private static void InitSortList()
        {
            var slist = CmsContentSortBussiness.GetList();
            foreach (var s in slist)
            {
                s.ParentSort = s.Pcode == "0" ? null : slist.FirstOrDefault(t => t.Scode == s.Pcode);
                s.ChildrenSorts = slist.Where(t => t.Pcode == s.Scode).ToList();
            }

            foreach (var s in slist)
            {
                var top = s;
                while (top != null && top.Pcode != "0")
                {
                    top = slist.FirstOrDefault(t=>t.Scode == top.Pcode);
                }

                s.TopSort = top;
            }

            foreach (var s in slist)
            {
                s.Rows = CmsContentBussiness.GetRecordCount($"scode='{s.Scode}'");
                if (!s.IsTop)
                {
                    s.TopSort.Rows += s.Rows;
                }
            }
            _sortList = slist;
        }


        public static void SetCurrentSort(int sid)
        {
            Session.Set(SortKey, sid);
        }

        private static CmsContentSort GetCurrentSort()
        {
            var sid = Session.Get<int>(SortKey);
            var sort = SortList.FirstOrDefault(t => t.Id == sid);
            if (sort == null)
            {
                sort = new CmsContentSort();
                sort.Scode = "0";
            }
            return sort;
        }
    }
}
