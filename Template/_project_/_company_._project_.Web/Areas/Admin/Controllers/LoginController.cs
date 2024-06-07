using System;
using System.Linq;
using FJData.Utils.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    public class LoginController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            password = EncryptHelper.MD5Encrypt(password);
            int userId =  UserInfoBussiness.GetList($"uName='{name}' and uPWD='{password}'").FirstOrDefault()?.UserID ?? 0;
            if(userId<=0)
                return Json(new { status = false, msg = "账户或者密码错误！" });
            var user = UserInfoBussiness.GetModel(userId);
            if(user==null)
                return Json(new { status = false, msg = "该账户不存在！" });
            //账户锁
            if (!user.uState)
                return Json(new { status = false, msg = "该账户已被管理员锁定,请联系管理员解锁！" });
            EmployeeInfo employee = user.EmployeeID > 0 ? EmployeeInfoBussiness.EmployeeInfo_GetModelExtend(user.EmployeeID) : null;
            if (employee == null)
                return Json(new { status = false, msg = "账户需要绑定人员信息，请联系管理员处理绑定！" });
            //人员锁
            if (!employee.eState)
                return Json(new { status = false, msg = "账户需要绑定人员已被管理员锁定，请联系管理员解锁！" });
            //写入Cookie或者Session
            UserServiceHelper.SetEmployeeSession(employee, true);
            user.olTime += 1;
            user.uUpAppendTime = DateTime.Now;
            UserInfoBussiness.Update(user);
            return Json(new { status = true, msg = "登陆成功！" });
        }

        public IActionResult LoginOut()
        {
            //清除session 然后跳转到登录页面
            UserServiceHelper.ClearLoginSessionAndCookie();
            return Redirect("/Login/Index");
        }
    }
}