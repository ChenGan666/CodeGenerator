using System;
using Microsoft.AspNetCore.Mvc;
using _company_._project_.Service.Attributes;

namespace _company_._project_.Service.Controllers
{
    [SqlRecoder]
    public class CommonBaseController : Controller
    {
        /// <summary>
        /// 生成成功Json返回
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected JsonResult BuildSuccessResult(Object data, string type = "object")
        {
            return Json(new { status = true, data = data, type = type, errorCode = 0, errorDetail = "" });
        }

        /// <summary>
        /// 生成失败Json返回
        /// </summary>
        /// <param name="code"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        protected JsonResult BuildFailResult(int code = -1, string detail = "")
        {
            return Json(new
            {
                status = false,
                errorCode = code,
                errorDetail = detail
            });
        }
    }
}