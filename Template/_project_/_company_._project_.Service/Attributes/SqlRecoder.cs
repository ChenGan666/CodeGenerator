using System;
using FJData.Utils.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using _company_._project_.DAL;
using _company_._project_.Service.WebHelpers;

namespace _company_._project_.Service.Attributes
{
    /// <summary>
    /// 判断用户是否有行为权限
    /// </summary>
    public class SqlRecoder : ActionFilterAttribute
    {
        public SqlRecoderType RecoderType = SqlRecoderType.ALL;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.ActionDescriptor.RouteValues["controller"];
            var action = context.ActionDescriptor.RouteValues["action"];
            DbLoger.InitLog();
            DbLoger.AddLog($"访问/{controller}/{action}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string log = DbLoger.GetLog();
            if (RecoderType == SqlRecoderType.DB || RecoderType == SqlRecoderType.ALL)
                DefaultLogService.AddOperationLog(2, log);
            if (RecoderType == SqlRecoderType.TXT || RecoderType == SqlRecoderType.ALL)
                NLogHelper.WriteCustom(log, "/SQL/");
            base.OnActionExecuted(context);
        }

        public enum SqlRecoderType
        {
            /// <summary>
            /// 数据库
            /// </summary>
            DB,
            /// <summary>
            /// 文本
            /// </summary>
            TXT,
            /// <summary>
            /// 所有
            /// </summary>
            ALL
        }
    }
}