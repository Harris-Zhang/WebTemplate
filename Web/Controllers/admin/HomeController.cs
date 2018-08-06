
using BZ.App.admin;
using BZ.Common;
using BZ.Domain.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Web.Core;

namespace Web.Controllers.admin
{
    public class HomeController : BaseController
    { 
        HomeApp _homeApp = new HomeApp();

        SysUserApp _userApp = new SysUserApp();

        /// <summary>
        /// 获取当前用户菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenuList()
        {
            JsonMessage jsonMsg = _homeApp.GetMenuList();
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
 
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUser()
        { 
            JsonMessage jsonMsg = _userApp.GetUser();
             
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);

        }
  
        public JsonResult GetUserMenuList(string id, string userId)
        {
            if (id == "0")
                return Json(new SysMenuModel(), JsonRequestBehavior.AllowGet); ;
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0";
            IList<SysMenuModel> list = _homeApp.GetMenuByUserId(UserId, id);
            var json = from r in list
                       select new
                       {
                           MENU_ID = r.MENU_ID,
                           MENU_NAME = r.MENU_NAME,
                           IS_ABLED = r.IS_ABLED,
                           IS_END = r.IS_END,
                           state = r.IS_END == 1 ? "open" : "closed",
                       };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoginOut()
        {
            FormsAuthentication.SignOut();
            SessionHelper.Clear();
            CookieHelper.ClearCookie("Account");
            return Json(ServiceResult.Message(1, ""), JsonRequestBehavior.AllowGet);
        }


    }
}
