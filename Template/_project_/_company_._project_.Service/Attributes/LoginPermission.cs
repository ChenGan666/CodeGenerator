using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Service.Attributes
{
    /// <summary>
    /// 判断用户登录情况
    /// </summary>
    public class LoginPermission : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!UserServiceHelper.IsLogin())
            {
                context.Result = new RedirectResult("/admin/login/index");
            }
            base.OnActionExecuting(context);
        }
    }
}