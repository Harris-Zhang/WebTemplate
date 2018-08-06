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
    public class SysMenuController : BaseController
    {
      
        SysMenuApp _menuApp = new SysMenuApp();
        SysMenuOptApp _menuOpApp = new SysMenuOptApp();

        public JsonResult GetList(string id)
        {
            if (id == "0")
                return Json(new SysMenuModel(), JsonRequestBehavior.AllowGet); ;
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0";
            IList<SysMenuModel> list = _menuApp.GetList(id);

            var json = from r in list
                       select new SysMenuModel()
                       {
                           MENU_ID = r.MENU_ID,
                           MENU_NAME = r.MENU_NAME,
                           PARENT_ID = r.PARENT_ID,
                           MENU_CODE = r.MENU_CODE,
                           MENU_PATH = r.MENU_PATH,
                           MENU_ICON = r.MENU_ICON,
                           MENU_SORT = r.MENU_SORT,
                           MENU_TYPE = r.MENU_TYPE,
                           MENU_DESC = r.MENU_DESC,
                           IS_ABLED = r.IS_ABLED,
                           IS_END = r.IS_END,
                           state = r.IS_END == 1 ? "open" : "closed",
                           CREATE_TIME = r.CREATE_TIME,
                           CREATE_USER = r.CREATE_USER

                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetParentList(string id)
        {
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0";
            IList<SysMenuModel> list = _menuApp.GetParentList(id);
            var json = from r in list
                       select new
                       {
                           id = r.MENU_ID,
                           text = r.MENU_NAME,
                           state = "closed"
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string menuId)
        {
            SysMenuModel model = _menuApp.GetById(menuId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert(string menuName, string parentId, string code, string link, string icon, int sort, string type, string desc, bool isable, bool isend)
        {
            JsonMessage jsonMsg = _menuApp.Insert(menuName, parentId, code, link, icon, sort, type, desc, isable, isend);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(string menuId, string menuName, string parentId, string code, string link, string icon, int sort, string type, string desc, bool isable, bool isend)
        {
            JsonMessage jsonMsg = _menuApp.Edit(menuId, menuName, parentId, code, link, icon, sort, type, desc, isable, isend);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string menuId)
        {
            JsonMessage jsonMsg = _menuApp.Delete(menuId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOpListByMenuId(string menuId)
        {
            if (menuId == null)
            {
                return Json(EasyUIDataGridClear, JsonRequestBehavior.AllowGet);
            }
            IList<SysMenuOptModel> list = _menuOpApp.GetOpListByMenuId(menuId);
            var json = new
            {
                total = 0,
                rows = (from r in list
                        select new SysMenuOptModel()
                        {
                            MO_CODE = r.MO_CODE,
                            MO_NAME = r.MO_NAME,
                            MENU_ID = r.MENU_ID,
                            IS_ABLED = r.IS_ABLED,
                            MO_DESC = r.MO_DESC
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOpt(string mo_code, string menu_id)
        {
            JsonMessage jsonMsg = _menuOpApp.Delete(mo_code, menu_id);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertOpt(string keyCode, string name, string menuId, bool isValid, string desc)
        {
            JsonMessage jsonMsg = _menuOpApp.Insert(keyCode, name, menuId, isValid, desc);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListByRoleId(string id, string roleId)
        {
            if (id == "0")
                return Json(new SysMenuModel(), JsonRequestBehavior.AllowGet); ;
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0";
            IList<SysMenuModel> list = _menuApp.GetListByRoleId(roleId, id);
            var json = from r in list
                       select new SysMenuModel()
                       {
                           MENU_ID = r.MENU_ID,
                           MENU_NAME = r.MENU_NAME,
                           PARENT_ID = r.PARENT_ID,
                           MENU_CODE = r.MENU_CODE,
                           MENU_PATH = r.MENU_PATH,
                           MENU_ICON = r.MENU_ICON,
                           MENU_SORT = r.MENU_SORT,
                           MENU_TYPE = r.MENU_TYPE,
                           MENU_DESC = r.MENU_DESC,
                           IS_ABLED = r.IS_ABLED,
                           IS_END = r.IS_END,
                           state = r.IS_END == 1 ? "open" : "closed",
                           CREATE_TIME = r.CREATE_TIME,
                           CREATE_USER = r.CREATE_USER
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetConPath(string id)
        {
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "/html";
            id = id.Replace("replace_lp", "/");

            IList<SysMenuPath> list = _menuApp.GetConPath(id);
            var json = from r in list
                       select new SysMenuPath()
                       {
                           PATH_ID = r.PATH_ID,
                           PATH_NAME = r.PATH_NAME,
                           PATH_URL = r.PATH_URL,
                           PATH_TYPE = r.PATH_TYPE,
                           state = r.PATH_TYPE == "File" ? "open" : "closed"
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}
