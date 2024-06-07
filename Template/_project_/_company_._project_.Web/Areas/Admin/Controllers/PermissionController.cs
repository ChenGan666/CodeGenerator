using System;
using FJData.Utils.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.BLL;
using _company_._project_.Entity;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Web.Areas.Admin.Controllers
{
    [ActionPermission]
    public class PermissionController : LoggedOnController
    {
        public IActionResult PermissionList(int pageIndex = 1, int pageSize = 10, string keyword = "", int parentId = 0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            var sql = "ParentID = " + parentId;
            keyword = keyword.ToSafeSql();
            if (!keyword.IsNullOrEmpty())
            {
                sql += $"  and PermissionName like '%{keyword}%' or PermissionValue like '%{keyword}%' ";
            }

            var list = PermissionInfoBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, "*");
            ViewBag.PageTitle = "权限控制列表";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Keyword = keyword;
            ViewBag.Total = total;
            ViewBag.ParentID = parentId;
            ViewBag.PermissionList = list;
            return View();

        }
        public IActionResult PermissionEdit(int permissionId = 0, int parentId = 0)
        {
            var pem = permissionId == 0 ? new PermissionInfo
            {
                ParentID = parentId,
                IsDeleted = false,
                IsUse = true,
                pAppendTime = DateTime.Now,
                pUpdateTime = DateTime.Now,

            } :
            PermissionInfoBussiness.GetModel(permissionId);
            ViewBag.Pem = pem;
            return View();
        }
        [HttpPost]
        public IActionResult PermissionSave(PermissionInfo pem)
        {
            pem.pUpdateTime = DateTime.Now;
            if (pem.PermissionID == 0)
            {
                pem.pAppendTime = DateTime.Now;
                PermissionInfoBussiness.Add(pem);
            }
            else
            {
                PermissionInfoBussiness.Update(pem);
            }
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult PermissionDel(int permissionId)
        {
            PermissionInfo permission = PermissionInfoBussiness.GetModel(permissionId);
            if (permission != null)
            {
                if (permission.IsDeleted)
                {
                    PermissionInfoBussiness.Delete(permissionId);
                    return Json(new { status = true });
                }
                else
                {
                    return Json(new { status = false, msg = "删除失败，不可删除！" });
                }
            }
            else
            {
                return Json(new { status = false, msg = "删除失败，记录不存在！" });
            }



        }
        [HttpPost]
        public IActionResult PermissionStatus(int permissionId, int type, bool status)
        {
            PermissionInfo permission = PermissionInfoBussiness.GetModel(permissionId);
            if (type == 1)
            {
                permission.IsDeleted = status;
            }
            else if (type == 2)
            {
                permission.IsUse = status;
            }
            PermissionInfoBussiness.Update(permission);
            return Json(new { status = true });
        }
    }
}