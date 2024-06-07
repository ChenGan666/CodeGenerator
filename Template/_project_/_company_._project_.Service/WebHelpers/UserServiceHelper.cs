using System;
using FJData.Utils.Core.DI;
using FJData.Utils.Core.Extensions;
using FJData.Utils.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using _company_._project_.BLL;
using _company_._project_.Entity;

namespace _company_._project_.Service.WebHelpers
{
    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    public class UserServiceHelper
    {
        public static EmployeeInfo CurrentEmployee => GetEmployeeSession();
        

        private const int UserKeepDay = 30;

        private static IHttpContextAccessor ContextAccessor => ServiceLocator.GetInstance<IHttpContextAccessor>();

        private static ISession Session => ContextAccessor.HttpContext.Session;

        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            return CurrentEmployee != null;  
        }

        /// <summary>
        /// 获取登录用户
        /// </summary>
        /// <returns></returns>
        private static EmployeeInfo GetEmployeeSession()
        {
            var sessionStr = Session.Get<string>("Employee") ?? "";  
            var admin = sessionStr.Trim() != "" ?(EmployeeInfo)JsonConvert.DeserializeObject(sessionStr, typeof(EmployeeInfo)) : null;
            if (admin != null)
                return admin;
            var key = ContextAccessor.HttpContext.Request.Cookies["Employee"] ?? "";
            if (string.IsNullOrEmpty(key))
                return null;
            var keys = EncryptHelper.DESDecrypt(key).Split('|');
            if (keys.Length == 2 && DateTime.Now < keys[1].ToDateTime())
            {
                admin = EmployeeInfoBussiness.EmployeeInfo_GetModelExtend(int.Parse(keys[0]));
                if (admin != null)
                    SetEmployeeSession(admin);
            }
            return admin;
        }

        /// <summary>
        /// 登录后保存用户信息
        /// </summary>
        public static void SetEmployeeSession(EmployeeInfo employee, bool isKeep = false)
        {
            if (isKeep)
            {
                ContextAccessor.HttpContext.Response.Cookies.Append
                (
                    "Employee",
                    EncryptHelper.DESEncrypt($"{ employee.EmployeeID}|{ DateTime.Now.AddDays(UserKeepDay)}"),
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(UserKeepDay)
                    }
                );
            }
            Session.Set("Employee", JsonConvert.SerializeObject(employee));
        }

        /// <summary>
        /// 清空登录信息
        /// </summary>
        public static void ClearLoginSessionAndCookie()
        {
            ContextAccessor.HttpContext.Session.Clear();
            ContextAccessor.HttpContext.Response.Cookies.Delete("Employee");
        }

        /// <summary>
        /// 判断用户拥有此权限值
        /// </summary>
        /// <param name="permissionValue"></param>
        /// <returns></returns>
        public static bool UserIsOwnPermission(string permissionValue)
        {
            var permission = PermissionInfoBussiness.GetModelByPermissionValue(permissionValue);
           
            if (permission != null)
            {
                if (CurrentEmployee.JPPermissions == "X")
                {
                    return true;
                }
                return ("," + CurrentEmployee.JPPermissions + ",").IndexOf(","+ permission.PermissionID+",") > -1;
            }
            else
            {
                return false;
            }

        }

        public static void RefreshUserSession()
        {
            EmployeeInfo employee =  EmployeeInfoBussiness.EmployeeInfo_GetModelExtend(CurrentEmployee.EmployeeID);
            SetEmployeeSession(employee, false);
        }

        /// <summary>
        /// 菜单权限检查，有呈现
        /// </summary>
        /// <param PermissionValue="">权限值</param>
        /// <param name="permissionValue"></param>
        public static  bool CheckUserPermission(string permissionValue)
        {
            if (CurrentEmployee.JPPermissions == "X")
            {
                return true;
            }
            var pList = PermissionInfoBussiness.GetModelByPermissionIdStr(CurrentEmployee.JPPermissions);
            var check = false;
            if (pList != null)
            {
                foreach (var item in pList)
                {
                    if (item.PermissionValue.IndexOf(permissionValue) > -1)
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }
    }
}