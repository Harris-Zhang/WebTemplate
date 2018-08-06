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
    public class SysRoleController : BaseController
    { 
        SysRoleApp _roleApp = new SysRoleApp();

        public JsonResult GetList(GridPager pager, string roleName, string desc)
        {
            IList<SysRoleModel> list = _roleApp.GetList(pager, roleName, desc);
            var json = new
            {
                total = pager.totalRows,
                totalPages = pager.totalPages,
                rows = (from r in list
                        select new SysRoleModel()
                        {
                            ROLE_ID = r.ROLE_ID,
                            ROLE_NAME = r.ROLE_NAME,
                            ROLE_DESC = r.ROLE_DESC,
                            CREATE_TIME = r.CREATE_TIME,
                            CREATE_USER = r.CREATE_USER
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string roleId)
        {
            SysRoleModel model = _roleApp.GetById(roleId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string roleId)
        {
            JsonMessage jsonMsg = _roleApp.Delete(roleId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(string roleId, string roleName, string desc)
        {
            JsonMessage jsonMsg = _roleApp.Edit(roleId, roleName, desc);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Insert(string roleName, string desc)
        {
            JsonMessage jsonMsg = _roleApp.Insert(roleName, desc);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoleNoUser(string userId)
        {
            IList<SysRoleModel> list = _roleApp.GetRoleNoUser(userId);
            var json = new
            {
                total = list.Count,
                totalPages = 1,
                rows = (from r in list
                        select new SysRoleModel()
                        {
                            ROLE_ID = r.ROLE_ID,
                            ROLE_NAME = r.ROLE_NAME,
                            ROLE_DESC = r.ROLE_DESC
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoleYesUser(string userId)
        {
            IList<SysRoleModel> list = _roleApp.GetRoleYesUser(userId);
            var json = new
            {
                //total = pager.totalRows,
                rows = (from r in list
                        select new SysRoleModel()
                        {
                            ROLE_ID = r.ROLE_ID,
                            ROLE_NAME = r.ROLE_NAME,
                            ROLE_DESC = r.ROLE_DESC
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllotSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = _roleApp.AllotSysUserRole(userId, roleId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }


    }
}
