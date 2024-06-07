using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ActionPermission]
    public class JobPositionController : LoggedOnController
    {
        public IActionResult JobPositionList(int pageIndex = 1, int pageSize = 10, string keyword = "", int branchId = 0, int departmentId = 0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1 = 1";
            if (branchId > 0)
            {
                sql += " and BranchID= " + branchId;
            }
            if (departmentId > 0)
            {
                sql += " and DepartmentID= " + departmentId;
            }
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql += $" and JPName like '%{keyword}%' ";
            }


            var list = JobPositionInfoBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, "*");
            ViewBag.PageTitle = "岗位列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Keyword = keyword;
            ViewBag.Total = total;
            ViewBag.JobPositionList = list;
            ViewBag.BranchID = branchId;
            ViewBag.DepartmentID = departmentId;
            ViewBag.BranchList = BranchInfoBussiness.GetList();
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList();
            return View();

        }
        public IActionResult JobPositionEdit(int jobPositionId = 0)
        {
            var bac = jobPositionId == 0 ? new JobPositionInfo
            {
                JPPermissions = " ",
                JPAppendTime = DateTime.Now,
                JState = true
            } :

            JobPositionInfoBussiness.GetModel(jobPositionId);
            ViewBag.BranchList = BranchInfoBussiness.GetList();
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList();
            ViewBag.JPPermissionList = PermissionHelper.GetzTreeDataList(bac.JPPermissions);
            ViewBag.Bac = bac;
            return View();
        }

        [HttpPost]
        public IActionResult JobPositionSave(JobPositionInfo job)
        {
            job.JPRemark = job.JPRemark ?? "";
            job.JPPermissions = job.JPPermissions ?? "";
            if (job.JobPositionID == 0)
            {
                job.JPAppendTime = DateTime.Now;
                JobPositionInfoBussiness.Add(job);
            }
            else
            {
                JobPositionInfoBussiness.Update(job);
                UserServiceHelper.RefreshUserSession();
            }
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult JobPositionDel(int jobPositionId)
        {
            JobPositionInfo jobPosition = JobPositionInfoBussiness.GetModel(jobPositionId);
            if (jobPosition != null)
                JobPositionInfoBussiness.Delete(jobPositionId);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult JobPositionStatus(int jobPositionId, bool status)
        {
            JobPositionInfo jobPosition = JobPositionInfoBussiness.GetModel(jobPositionId);
            jobPosition.JState = status;
            JobPositionInfoBussiness.Update(jobPosition);
            return Json(new { status = true });
        }
    }
}