using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FJData.Utils.Core.DI;
using FJData.Utils.Core.Helpers;
using Senparc.CO2NET.Extensions;

namespace _company_._project_.CMSWeb.Helpers
{
    public class GlobalLabel
    {
        private static IHttpContextAccessor ContextAccessor => ServiceLocator.GetInstance<IHttpContextAccessor>();

        private static HttpContext HttpContext => ContextAccessor?.HttpContext;

        private static ISession Session => HttpContext?.Session;

        public static string PageTitle => CMSConfig.GetString("index_title", $"{SiteTitle}-{SiteSubTitle}");

        public static string SiteTitle => "";

        public static string SiteSubTitle => "";

        /// <summary>
        /// 当前网址
        /// </summary>
        public static string HttpUrl => HttpContext?.Request.Scheme + "://" + HttpContext?.Request.Host;

        /// <summary>
        /// 当前页面
        /// </summary>
        public static string PageUrl => HttpContext?.Request.Scheme + "://" + HttpContext.Request?.Host + HttpContext.Request?.Path.Value + HttpContext.Request?.QueryString.Value;


        public static string GetQrCode(string url = "")
        {
            if (url.IsNullOrEmpty())
                url = PageUrl;
            return "";
        }

        /// <summary>
        /// Action 运行时间
        /// </summary>
        public static string RunTime => Session.GetString(Service.Attributes.RunTime.RunTimeKey);

        public static string SiteTplPath => "";

        public static string Company => "";

        public static string CompanyLicense => "";

        public static string SiteIcp => "";

        public static string CompanyAddress => "";

        public static string CompanyPhone => "";

        public static string CompanyEmail => "";

        public static string CompanyQQ => "";

        public static string SiteCopyright => "Copyright © 2018-2020 PbootCMS All Rights Reserved.";


        public static string CompanyMobile => "";


        public static string CompanyWeiXin => "";


        public static string SiteStatistical => "";

        public static string SitePath => "";

        public static string SiteLogo => "/images/logo.png";

        public static string PageKeywords => "";
        public static string PageDescription => "";

        public static string MsgAction => "";

        public static string SearchAction => "";


        public static string GetParameter(string name)
        {
            return HttpContext.Request.Query.ContainsKey(name) ? HttpContext.Request.Query[name].ToString() : "";
        }
    }
}
