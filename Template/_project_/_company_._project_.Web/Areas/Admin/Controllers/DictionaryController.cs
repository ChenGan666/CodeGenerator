using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Web.Areas.Admin.Controllers
{

    [ActionPermission]
    public class DictionaryController : AdminBaseController
    {
        public IActionResult Icon()
        {
            return View();
        }

        public IActionResult DictionaryList(int pid = 0, int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            var sql = $" Pid ="+pid;
            string ShowFieldName = "*";
            var dicList = DictionaryInfoBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageTitle = "字典列表";
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.pid = pid;
            ViewBag.DicList = dicList;
            ViewBag.Pid = pid;
            return View();
        }
        public IActionResult DictionaryEdit(int did = 0, int pid = 0)
        {
            var dic = did == 0 ? new DictionaryInfo
            {
                Pid = pid,
                CreateTime = DateTime.Now,
                Status = true
            } :
            DictionaryInfoBussiness.GetModel(did);

           
            ViewBag.Dic = dic;
            return View();
        }

        [HttpPost]
        public IActionResult DictionaryStatus(int did, bool status)
        {
            var dictionary =  DictionaryInfoBussiness.GetModel(did);
            dictionary.Status = status;
            dictionary.UpdateTime = DateTime.Now;
            DictionaryInfoBussiness.Update(dictionary);
            DictionaryHelper.InitDictionaryList();
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DictionarySort(int did, int sort)
        {
            DictionaryInfo dictionary = DictionaryInfoBussiness.GetModel(did);
            dictionary.Sort = sort;
            dictionary.UpdateTime = DateTime.Now;
            DictionaryInfoBussiness.Update(dictionary);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DictionarySave(DictionaryInfo dic)
        {
            dic.UpdateTime = DateTime.Now;
            if (dic.DicId == 0)
            {
                dic.CreateTime = DateTime.Now;
                dic.UpdateTime = DateTime.Now;
                if (dic.Pid != 0)
                {
                    var p = DictionaryInfoBussiness.GetModel(dic.Pid);
                    dic.Cid = (p == null || p.Pid == 0) ? 0 : p.Cid;
                }
                DictionaryInfoBussiness.Add(dic);
            }
            else
            {
                DictionaryInfoBussiness.Update(dic);
            }
           
            DictionaryHelper.InitDictionaryList();
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DictionaryDel(int did)
        {
            var d = DictionaryInfoBussiness.GetModel(did);
            if (d != null)
                DictionaryInfoBussiness.Delete(did);
            DictionaryHelper.InitDictionaryList();
            return Json(new { status = true });
        }
    }
}