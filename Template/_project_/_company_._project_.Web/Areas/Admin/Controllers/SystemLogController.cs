using System;
using Microsoft.AspNetCore.Mvc;
using FJData.DeviceSystem.BLL;
using FJData.DeviceSystem.Entity;
using FJData.DeviceSystem.Service.Attributes;

namespace FJData.DeviceSystem.Web.Areas.Admin.Controllers
{
    [ActionPermission]
    public class SystemLogController: AdminBaseController
    {
        public IActionResult LogLevelList(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = "";
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql = $" LevelName like '%{keyword}%' ";
            }
            string ShowFieldName = "*";
            var list = LogLevelBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "日志等级";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.keyword = keyword;
            ViewBag.LogLevelList = list;
        
            return View();
        }
        public IActionResult LogLevelEdit(int Id = 0)
        {
            var Loglv = Id == 0 ? new LogLevel
            {
                Status = true
            } :
            LogLevelBussiness.GetModel(Id);
            ViewBag.Loglv = Loglv;
            return View();
        }
        [HttpPost]
        public IActionResult LogLevelSave(LogLevel Loglv)
        {
            if (Loglv.Id == 0)
            {
                Loglv.CreateTime = DateTime.Now;
                LogLevelBussiness.Add(Loglv);
            }
            else
            {
                LogLevelBussiness.Update(Loglv);
            }

            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult LogLevelDel(int Id)
        {
            LogLevel Loglv = LogLevelBussiness.GetModel(Id);
            if (Loglv != null)
                LogLevelBussiness.Delete(Id);
            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult LogLevelStatus(int Id, bool status)
        {
            LogLevel Loglv = LogLevelBussiness.GetModel(Id);
            Loglv.Status = status;
            LogLevelBussiness.Update(Loglv);

            return Json(new { status = true });
        }
        public IActionResult LogRecordList(int pageIndex = 1, int pageSize = 10, string keyword = "",int LevelId =0, int MarkId =0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1 = 1";

            if (LevelId > 0)
            {
                sql += " and LevelId=" + LevelId;
            }
            if (MarkId > 0)
            {
                sql += " and MarkId=" + MarkId;
            }
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql = $" LogDetail like '%{keyword}%' ";
            }
            string ShowFieldName = "*";
            var list = LogRecordBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "日志信息";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.keyword = keyword;
            ViewBag.LogRecordList = list;
            ViewBag.LogLevelList = LogLevelBussiness.GetList("1=1");
            ViewBag.LogTypeList = LogMarkBussiness.GetList("1=1");
            ViewBag.LogRecordList = list;
            ViewBag.LevelId = LevelId;
            ViewBag.MarkId = MarkId;

            return View();
        }
        [HttpPost]
        public IActionResult LogRecordDel(int Id)
        {
            LogRecord LogRd = LogRecordBussiness.GetModel(Id);
            if (LogRd != null)
                LogRecordBussiness.Delete(Id);
            return Json(new { status = true });
        }

        public IActionResult LogMarkList(int pageIndex = 1, int pageSize = 10, string keyword = "", int LevelId = 0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1=1 ";
            keyword = keyword != null ? keyword.Trim() : "";
            if (keyword.Trim() != "")
            {
                sql += $" and MarkName like '%{keyword}%' ";
            }
            if (LevelId > 0)
            {
                sql += $" and LevelId = {LevelId} ";
            }
            string ShowFieldName = "*";
            var list = LogMarkBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "日志类型";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.keyword = keyword;
            ViewBag.LogTypeList = list;
            ViewBag.LogLevelList = LogLevelBussiness.GetList("1=1");
            ViewBag.LevelId = LevelId;


            return View();

        }
        public IActionResult LogMarkEdit(int Id = 0,int ClassId = 0)
        {
            var LogT = Id == 0 ? new LogMark
            {
                ClassId = ClassId,
                Status = true
            } :
            LogMarkBussiness.GetModel(Id);
            ViewBag.LogT = LogT;
            ViewBag.LogLevelList = LogLevelBussiness.GetList("1=1");
            return View();
        }
        [HttpPost]
        public IActionResult LogTypeSave(LogMark LogT)
        {
            if (LogT.Id == 0)
            {
                LogT.CreateTime = DateTime.Now;
                LogMarkBussiness.Add(LogT);
            }
            else
            {
                LogMarkBussiness.Update(LogT);
            }

            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult LogTypeDel(int Id)
        {
            LogMark LogT = LogMarkBussiness.GetModel(Id);
            if (LogT != null)
                LogMarkBussiness.Delete(Id);
            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult LogTypeStatus(int Id, bool status)
        {
            LogMark LogT = LogMarkBussiness.GetModel(Id);
            LogT.Status = status;
            LogMarkBussiness.Update(LogT);

            return Json(new { status = true });
        }
        public IActionResult LogTypeClassList(int pageIndex = 1, int pageSize = 10, string keyword = "", int ParentId = 0)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;
            string sql = " 1 = 1 ";
            if (keyword.Trim() != "")
            {
                sql += $" AND  ClassName like '%{keyword}%' ";
            }
            if (ParentId > 0)
            {
                sql += $" AND  ParentId = {ParentId} ";
            }
            string ShowFieldName = "*";
            var list = LogMarkClassBussiness.GetListByPage(pageSize, pageIndex, sql, out int pagetotal, out int total, 1, ShowFieldName);
            ViewBag.PageTitle = "日志分类";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.PageTotal = pagetotal;
            ViewBag.Total = total;
            ViewBag.keyword = keyword;
            ViewBag.LogMarkClassList = list;
            ViewBag.ParentId = ParentId;
            return View();
        }
        public IActionResult LogMarkClassEdit(int Id = 0,int ParentId=0,int RootId=0)
        {
            var LogC = Id == 0 ? new LogMarkClass
            {
                RootId= RootId,
                ParentId = ParentId,
                CreateTime = DateTime.Now
            } :
            LogMarkClassBussiness.GetModel(Id);
            ViewBag.LogC = LogC;
            return View();
        }
        [HttpPost]
        public IActionResult LogTypeClassSave(LogMarkClass LogC)
        {
            if (LogC.Id == 0)
            {
                LogC.CreateTime = DateTime.Now;
                LogMarkClassBussiness.Add(LogC);
            }
            else
            {
                LogMarkClassBussiness.Update(LogC);
            }

            return Json(new { status = true });
        }
        [HttpPost]
        public IActionResult LogTypeClassDel(int Id)
        {
            LogMarkClass LogC = LogMarkClassBussiness.GetModel(Id);
            if (LogC != null)
                LogMarkClassBussiness.Delete(Id);
            return Json(new { status = true });
        }
       


    }
}
