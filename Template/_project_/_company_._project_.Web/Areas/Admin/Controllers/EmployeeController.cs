using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{

    [ActionPermission]
    public class EmployeeController : LoggedOnController
    {
        public IActionResult EmployeeList(int pageIndex = 1, int pageSize = 10, string keyword = "", int branchId = 0, int departmentId = 0, int jobPositionId = 0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1 = 1 ";
            if (branchId > 0)
            {
                sql += " and BranchID= " + branchId;
            }
            if (departmentId > 0)
            {
                sql += " and DepartmentID= " + departmentId;
            }
            if (jobPositionId > 0)
            {
                sql += " and JobPositionID= " + jobPositionId;
            }
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql += $" and eName like '%{keyword}%' ";
            }
            string ShowFieldName = "*";
            ShowFieldName+=
              ",(select JobLevel from BaseJobPositionInfo  as  jpi where jpi.JobPositionID=BaseEmployeeInfo.JobPositionID)  as JobLevel"
            + ",isnull((select uName from BaseUserInfo as ui where ui.UserID=BaseEmployeeInfo.UserID),'') as UserName "
            + ",(select UserID from BaseUserInfo as ui where ui.EmployeeID =BaseEmployeeInfo.EmployeeID) as OldUserID,(select JPPermissions from BaseJobPositionInfo  as  jpi where jpi.JobPositionID=BaseEmployeeInfo.JobPositionID) as JPPermissions,(select bName from BaseBranchInfo where BranchID=BaseEmployeeInfo.BranchID) as BranchName,(select dName from BaseDepartmentInfo where DepartmentID=BaseEmployeeInfo.DepartmentID) as DepartmentName";
            var list = EmployeeInfoBussiness.GetListByPageExtend(pageSize, pageIndex, sql, out int pagetotal, out int total,1, ShowFieldName);
            ViewBag.PageTitle = "人员列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Keyword = keyword;
            ViewBag.Total = total;
            ViewBag.EmployeeList = list;
            ViewBag.BranchID = branchId;
            ViewBag.DepartmentID = departmentId;
            ViewBag.JobPositionID = jobPositionId;
            ViewBag.BranchList = BranchInfoBussiness.GetList(" 1=1 ");
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList(" 1 = 1");
            ViewBag.JobPositionList = JobPositionInfoBussiness.GetList("1=1");
            return View();

        }

        public IActionResult EmployeeEdit(int employeeId = 0)
        {
            var bac = employeeId == 0 ? new EmployeeInfo
            {
                IsSelf=true,
                eAppendTime = DateTime.Now,
                eState = true
            } :
            EmployeeInfoBussiness.GetModel(employeeId);
            ViewBag.BranchList = BranchInfoBussiness.GetList();
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList();
            ViewBag.JobPositionList = JobPositionInfoBussiness.GetList();
            ViewBag.Bac = bac;
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeSave(EmployeeInfo em)
        {

            if (em.EmployeeID == 0)
            {
                em.eAppendTime = DateTime.Now;
                EmployeeInfoBussiness.Add(em);
            }
            else
            {
                EmployeeInfoBussiness.Update(em);
            }
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult EmployeeDel(int employeeId)
        {
            EmployeeInfo employee = EmployeeInfoBussiness.GetModel(employeeId);
            if (employee != null)
                EmployeeInfoBussiness.Delete(employeeId);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult EmployeeStatus(int employeeId, bool status)
        {
            var employee = EmployeeInfoBussiness.GetModel(employeeId);
            employee.eState = status;
            EmployeeInfoBussiness.Update(employee);
            return Json(new { status = true });
        }
    }
}