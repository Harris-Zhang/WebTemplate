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
    public class SysRightController : BaseController
    { 

        SysRightApp _rightApp = new SysRightApp();
        public JsonResult GetPermission()
        {
            //string url = Request.Url.AbsolutePath;
            //url = Request.Path;
            //url = Request.RawUrl;
            //url = Request.Url.PathAndQuery;
            //object con = RouteData.Route.GetRouteData(this.HttpContext).Values["controller"];
            //con = RouteData.Route.GetRouteData(this.HttpContext).Values["action"];
            string url = Request.UrlReferrer.AbsolutePath;

            IList<permModel> list = _rightApp.GetPermission(UserId, url);
            var json = from r in list
                       select new permModel()
                       {
                           KEYCODE = r.KEYCODE,
                           ISVALID = r.ISVALID
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateRight(string menu_id, string role_id, string mo_codes, bool isValid)
        {
            JsonMessage jsonMsg = _rightApp.UpdateRight(menu_id, role_id, mo_codes, isValid);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRightByMenuIdAndRoleId(string menuId, string roleId)
        {
            if (menuId == null || roleId == null)
                return Json(EasyUIDataGridClear, JsonRequestBehavior.AllowGet);
            IList<SysMenuOptRightModel> list = _rightApp.GetRightByMenuIdAndRoleId(menuId, roleId);
            var json = new
            {
                total = 0,
                rows = (from r in list
                        select new SysMenuOptRightModel()
                        {
                            MENU_ID = r.MENU_ID,
                            ROLE_ID = r.ROLE_ID,
                            MO_CODE = r.MO_CODE,
                            MO_NAME = r.MO_NAME,
                            IS_ABLED = r.IS_ABLED 
                        }).ToArray()

            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
