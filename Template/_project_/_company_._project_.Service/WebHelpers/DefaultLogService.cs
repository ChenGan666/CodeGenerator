using System;
using System.Collections.Generic;
using FJData.Utils.Core.DI;
using FJData.Utils.Core.Extensions;
using FJData.Utils.Core.Helpers;
using FJData.Utils.Core.MemoryQueue;
using Microsoft.AspNetCore.Http;
using _company_._project_.BLL;
using _company_._project_.Entity;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace _company_._project_.Service.WebHelpers
{
    public static class DefaultLogService
    {
        private static readonly string OperaterQueueName = "LogQueue_Data";

        private static IHttpContextAccessor ContextAccessor => ServiceLocator.GetInstance<IHttpContextAccessor>();

        static DefaultLogService()
        {
            QueueManager.CreateQueue<LogRecord>(OperaterQueueName, ConsumeOperateQueue);
            NLogHelper.WriteInfo("LogQueueProvider创建内存队列成功");
        }

        /// <summary>
        ///     获取操作记录的异步任务队列
        /// </summary>
        private static AsyncQueue<LogRecord> OperateQueue
        {
            get { return QueueManager.GetQueue<LogRecord>(OperaterQueueName); }
        }

        private static void ConsumeOperateQueue(List<LogRecord> lstInfo)
        {
            try
            {
                foreach (var record in lstInfo)
                {
                    var logType = LogTypeBussiness.GetModel(record.TypeId);
                    var logLevel = LogLevelBussiness.GetModel(logType.LevelId);
                    record.LevelId = logLevel.Id;
                    if (logLevel.Status && logType.Status)
                        LogRecordBussiness.Add(record);
                }
            }
            catch (Exception ex)
            {
                NLogHelper.WriteException("ConsumeOperateQueue:" + lstInfo.Count, ex);
            }
        }

        /// <summary>
        /// 用户操作记录
        /// </summary>
        /// <param name="logDetail"></param>
        /// <param name="typeId"></param>
        /// <param name="logRemarks"></param>
        public static void AddOperationLog(int typeId, string logDetail, string logRemarks = "")
        {
            var ip = ContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var url = ContextAccessor.HttpContext.Request.AbsoluteUri();
            OperateQueue.PutMessage(
                new LogRecord()
                {
                    LogDetail = logDetail,
                    LogCreatorIP = ip,
                    LogRemarks = logRemarks,
                    LogUrl = url,
                    LogCreatorId = UserServiceHelper.CurrentEmployee?.EmployeeID ?? 0,
                    DateCode = DateTime.Now.ToDateCode(),
                    OperateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    TypeId = typeId
                });
        }

        public static void AddOperationLog(int typeId, Exception ex, string logDetail = "", string logRemarks = "")
        {
            AddOperationLog(typeId, BuildMessage(logDetail, ex), logRemarks);
        }

        private static string BuildMessage(string info, Exception ex = null)
        {
            var sb = new StringBuilder();
            var context = ServiceLocator.GetInstance<IHttpContextAccessor>()?.HttpContext;
            var request = context?.Request;
            sb.AppendFormat("============================\r\nTime:{0:yyyy-MM-dd HH:mm:ss.fff}\r\n{1}\r\n", DateTime.Now, info);

            if (request != null)
            {
                sb.AppendFormat("Url:{0}\r\n", request.GetDisplayUrl());
                if (null != request.UrlReferrer())
                {
                    sb.AppendFormat("UrlReferrer:{0}\r\n", request.UrlReferrer());
                }
                sb.AppendFormat("UserHostAddress:{0};{1};{2}\r\n",
                    request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    request.Headers["X-Forwarded-For"],
                    request.Headers["HTTP_NDUSER_FORWARDED_FOR_HAPROXY"]
                );
                //request.ServerVariables["LOCAL_ADDR"]);
            }

            if (ex != null)
            {
                if (ex is SqlException sqlEx)
                    sb.AppendFormat("Database:{0}\r\n", sqlEx.Server);
                sb.AppendFormat("Exception:{0}\r\n", ex);
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}