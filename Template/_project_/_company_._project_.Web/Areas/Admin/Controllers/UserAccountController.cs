using System;
using FJData.Utils.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    [ActionPermission]
    public class UserAccountController : LoggedOnController
    {

  
        public IActionResult UserAccountList(int pageIndex = 1, int pageSize = 10, string keyword = "", int branchId = 0, int departmentId = 0)
        {

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1 = 1";
            if (branchId > 0)
            {
                sql += " and   BranchID= " + branchId;
            }
            if (departmentId > 0)
            {
                sql += " and   DepartmentID= " + departmentId;
            }
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql += $"  and uName like '%{keyword}%' ";
            }
            string ShowFieldName = "*,(select bName from BaseBranchInfo where BaseBranchInfo.BranchID=BaseUserInfo.BranchID) as BranchName ";
            ShowFieldName += ",(select dName from BaseDepartmentInfo where BaseDepartmentInfo.DepartmentID=BaseUserInfo.DepartmentID) as DepartmentName ";
             var list = UserInfoBussiness.GetListByPageExtend(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "操作账户列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Keyword = keyword;
            ViewBag.Total = total;
            ViewBag.UserAccountList = list;
            ViewBag.BranchID = branchId;
            ViewBag.DepartmentID = departmentId;
            ViewBag.BranchList = BranchInfoBussiness.GetList(" 1=1 ");
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList(" 1 = 1");

            return View();

        }

        public IActionResult UserAccountEdit(int userId = 0)
        {
            var user = userId == 0 ? new UserInfo
            {
                uCode = "",
                uType = 0,
                olTime = 0,
                uLastIP = HttpContext.Connection.RemoteIpAddress.ToString(),
                uAppendTime = DateTime.Now,
                uUpAppendTime = DateTime.Now,
                uState = true
            } :
             UserInfoBussiness.GetModel(userId);

            ViewBag.BranchList = BranchInfoBussiness.GetList("");
            ViewBag.DepartmentList = DepartmentInfoBussiness.GetList("");
            ViewBag.EmployeeList = EmployeeInfoBussiness.GetList();
            ViewBag.User = user;
            return View();
        }

        [HttpPost]

        public IActionResult UserAccountSave(UserInfo User)
        {
            User.uPWD = (User.uPWD != "" || User.uPWD != null) ? EncryptHelper.MD5Encrypt(User.uPWD) : "";
            User.uCode = User.uCode ?? "";
            if (User.UserID == 0)
            {
                User.uAppendTime = DateTime.Now;
                UserInfoBussiness.Add(User);
            }
            else
            {
                UserInfoBussiness.Update(User);
            }
            return Json(new { status = true });
        }

        [HttpPost]
        [ActionPermission]
        public IActionResult UserAccountDel(int userId)
        {
            UserInfo user = UserInfoBussiness.GetModel(userId);
            if (user != null)
                UserInfoBussiness.Delete(userId);
            return Json(new { status = true });
        }
        [HttpPost]

        public IActionResult UserAccountStatus(int userId, bool status)
        {
            UserInfo user = UserInfoBussiness.GetModel(userId);
            user.uState = status;
            UserInfoBussiness.Update(user);

            return Json(new { status = true });
        }
    }
}