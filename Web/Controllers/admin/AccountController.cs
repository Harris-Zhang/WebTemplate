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
    
    public class AccountController : Controller
    { 
        AccountApp _accountApp = new AccountApp();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public JsonResult Login(string userName, string pwd)
        {
            AccountModel user = new AccountModel();
            
            JsonMessage jsonMsg = _accountApp.Login(ref user, userName, pwd); 
 
            return Json(jsonMsg,JsonRequestBehavior.AllowGet);
            
        }

    }
}
