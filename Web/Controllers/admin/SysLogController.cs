using BZ.App.admin;
using BZ.Common;
using BZ.Domain.admin; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Web.Core;
namespace Web.Controllers.admin
{
    public class SysLogController : BaseController
    {
        //[Dependency]
        //public ISysLogApp _logApp { get; set; }

        SysLogApp _logApp = new SysLogApp();

        public JsonResult GetList(GridPager pager, string res, string type, string module, string userName, string sDate, string eDate)
        {
            IList<SysLogModel> list = _logApp.GetList(pager, "", res, type, module, userName, sDate, eDate);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysLogModel()
                        {
                            LOG_ID = r.LOG_ID,
                            OPERATE_ID = r.OPERATE_ID,
                            LOG_MSG = r.LOG_MSG,
                            LOG_RESULT = r.LOG_RESULT,
                            LOG_TYPE = r.LOG_TYPE,
                            LOG_MODULE = r.LOG_MODULE,
                            LOG_NAMESPACE = r.LOG_NAMESPACE,
                            LOG_CLASS = r.LOG_CLASS,
                            LOG_METHOD = r.LOG_METHOD,
                            LOG_DESC = r.LOG_DESC,
                            CREATE_TIME = r.CREATE_TIME,
                        })
            };
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string logId)
        {
            JsonMessage jsonMsg = _logApp.Delete(logId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string logId)
        {
            SysLogModel model = _logApp.GetById(logId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLogType(string field)
        {
            IList<SysLogModel> list = _logApp.GetLogType(field);
            var json = from r in list
                       select new
                       {
                           id=r.LOG_ID,
                           text=r.LOG_TYPE
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
