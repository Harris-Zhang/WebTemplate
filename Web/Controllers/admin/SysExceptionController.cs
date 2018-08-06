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
    public class SysExceptionController : BaseController
    { 
        SysExceptionApp _exceptionApp = new SysExceptionApp();

        public JsonResult GetList(GridPager pager, string userName, string sDate, string eDate)
        {
            IList<SysExceptionModel> list = _exceptionApp.GetList(pager, userName, sDate, eDate);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysExceptionModel()
                        {
                            EX_ID = r.EX_ID,
                            EX_HELPLINK = r.EX_HELPLINK,
                            EX_MESSAGE = r.EX_MESSAGE,
                            EX_SOURCE = r.EX_SOURCE,
                            EX_STACK = r.EX_STACK,
                            EX_TARGET = r.EX_TARGET,
                            EX_DATA = r.EX_DATA,
                            EX_NAMESPACE = r.EX_NAMESPACE,
                            EX_CLASS = r.EX_CLASS,
                            EX_METHOD = r.EX_METHOD,
                            EX_TYPE = r.EX_TYPE,
                            EX_DESC = r.EX_DESC,
                            CREATE_USER = r.CREATE_USER,
                            CREATE_TIME = r.CREATE_TIME,
                        })
            };
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList2( GridPager pager, string userName, string sDate, string eDate)
        {
            IList<SysExceptionModel> list = _exceptionApp.GetList(pager, userName, sDate, eDate);
            var json = new
            {
                total = pager.totalRows,
                totalPages=pager.totalPages,
                rows = (from r in list
                        select new SysExceptionModel()
                        {
                            EX_ID = r.EX_ID,
                            EX_HELPLINK = r.EX_HELPLINK,
                            EX_MESSAGE = r.EX_MESSAGE,
                            EX_SOURCE = r.EX_SOURCE,
                            EX_STACK = r.EX_STACK,
                            EX_TARGET = r.EX_TARGET,
                            EX_DATA = r.EX_DATA,
                            EX_NAMESPACE = r.EX_NAMESPACE,
                            EX_CLASS = r.EX_CLASS,
                            EX_METHOD = r.EX_METHOD,
                            EX_TYPE = r.EX_TYPE,
                            EX_DESC = r.EX_DESC,
                            CREATE_USER = r.CREATE_USER,
                            CREATE_TIME = r.CREATE_TIME,
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string exId)
        {
            JsonMessage jsonMsg = _exceptionApp.Delete(exId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string exId)
        {
            SysExceptionModel model = _exceptionApp.GetById(exId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
