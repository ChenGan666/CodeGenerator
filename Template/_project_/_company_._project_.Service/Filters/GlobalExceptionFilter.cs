using Microsoft.AspNetCore.Mvc.Filters;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Service.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            DefaultLogService.AddOperationLog(1, filterContext.Exception);
            filterContext.ExceptionHandled = false;
        }
    }
}
