using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Service.Attributes
{
    /// <summary>
    /// 判断用户是否有行为权限
    /// </summary>
    public class ActionPermission : ActionFilterAttribute
    {
        public string PermissionValue = "";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var areaName = context.ActionDescriptor.RouteValues.ContainsKey("area") ? context.ActionDescriptor.RouteValues["area"] : "";

            var controllerName = context.ActionDescriptor.RouteValues["controller"];

            var actionName = context.ActionDescriptor.RouteValues["action"];

            PermissionValue = $"{areaName}/{controllerName}/{actionName}";

            if (areaName.Trim().ToLower() == "admin")
            {
                PermissionValue = $"/{controllerName}/{actionName}";
            }

            if (!UserServiceHelper.UserIsOwnPermission(PermissionValue))
            {
                context.Result = GetErrorResult("无此权限！");
            }
            base.OnActionExecuting(context);
        }

        private static JsonResult GetErrorResult(string msg)
        {
            return new JsonResult(new
            {
                status = false,
                msg
            });
        }
    }
}