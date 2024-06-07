using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    [ActionPermission]
    public class DepartmentController : LoggedOnController
    {
        public IActionResult DepartmentList(int pageIndex = 1, int pageSize = 10, string keyword = "",  int branchId = 0)
         {

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = $" dName like '%{keyword}%' ";
            if (branchId > 0)
            {
                sql += " and BranchID =" + branchId;
            }
            string ShowFieldName = "*,(select bName from BaseBranchInfo where BaseBranchInfo.BranchID=BaseDepartmentInfo.BranchID) as BranchName ";
            var list = DepartmentInfoBussiness.GetListByPageExtend(pageSize, pageIndex, sql, out int pagetotal,out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "部门列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.BranchID = branchId;
            ViewBag.keyword = keyword;
            ViewBag.DepartmentList = list;
            ViewBag.BranchList = BranchInfoBussiness.GetList();
            return View();

         }
        public IActionResult DepartmentEdit(int departmentId = 0)
        {
            var dic = departmentId == 0 ? new DepartmentInfo
            {
                dAppendTime = DateTime.Now,
                dState = true
            } :
            DepartmentInfoBussiness.GetModel(departmentId);

            ViewBag.BranchList = BranchInfoBussiness.GetList();
            ViewBag.Dic = dic;
            return View();
        }
        [HttpPost]
        public IActionResult DepartmentSave(DepartmentInfo dic)
        {
            if (dic.DepartmentID == 0)
            {
                dic.dAppendTime = DateTime.Now;
                DepartmentInfoBussiness.Add(dic);
            }
            else
            {
                DepartmentInfoBussiness.Update(dic);
            }

            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DepartmentDel(int departmentId)
        {
            DepartmentInfo department = DepartmentInfoBussiness.GetModel(departmentId);
            if (department != null)
                DepartmentInfoBussiness.Delete(departmentId);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DepartmentStatus(int departmentId, bool status)
        {
            DepartmentInfo department = DepartmentInfoBussiness.GetModel(departmentId);
            department.dState = status;
            DepartmentInfoBussiness.Update(department);

            return Json(new { status = true });
        }
    }
}