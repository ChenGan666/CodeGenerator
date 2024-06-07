using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{

    [ActionPermission]
    public class BranchController : AdminBaseController
    {
     
        public IActionResult BranchList(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            var sql = $" bName like '%{keyword}%' ";
            string ShowFieldName = "*";
            var list = BranchInfoBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total,  1, ShowFieldName);
            ViewBag.PageTitle = "分支机构列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Keyword = keyword;
            ViewBag.Total = total;
            ViewBag.BranchList = list;
            return View();
         
        }

        public IActionResult BranchEdit(int branchId = 0)
        {
            var bac = branchId == 0 ? new BranchInfo
            {
                bAppendTime = DateTime.Now,
                bState = true
            }:
            BranchInfoBussiness.GetModel(branchId);
            ViewBag.Bac = bac;
            return View();
        }
        [HttpPost]
        public IActionResult BranchSave(BranchInfo bra)
        {
            if (bra.BranchID == 0)
            {
               
                bra.bAppendTime = DateTime.Now;
                BranchInfoBussiness.Add(bra);
            }
            else
            {
                BranchInfoBussiness.Update(bra);
            }
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult BranchDel(int branchId)
        {
            BranchInfo branch = BranchInfoBussiness.GetModel(branchId);
            if (branch != null)
                BranchInfoBussiness.Delete(branchId);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult BranchStatus(int branchId, bool status)
        {
            BranchInfo branch = BranchInfoBussiness.GetModel(branchId);
            branch.bState = status;
            BranchInfoBussiness.Update(branch);
            return Json(new { status = true });
        }
    }
}