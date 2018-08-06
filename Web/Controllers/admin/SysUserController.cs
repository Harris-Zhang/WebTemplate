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
    public class SysUserController : BaseController
    {
        //[Dependency]
        //public ISysUserApp _userApp { get; set; }
        //[Dependency]
        //public IAccountApp _accountApp { get; set; }

        SysUserApp _userApp = new SysUserApp();
        AccountApp _accountApp = new AccountApp();
        SysRoleApp _roleApp = new SysRoleApp();

        public JsonResult EditPassword(string oldPwd, string newPwd, string newPwdOk, bool isQR)
        {
            JsonMessage jsonMsg = _userApp.EditPassword(UserId, MD5Cryption.MD5(oldPwd), MD5Cryption.MD5(newPwd), MD5Cryption.MD5(newPwdOk), isQR, MD5Cryption.MD5(UserId + newPwd));

            if (jsonMsg.type == 1)
            {
                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket tickets = id.Ticket;
                SysUserModel userFromDB = _userApp.GetById(UserId);
                FormsAuthentication.SignOut();
                AccountModel model = new AccountModel();
                model.UserCode = userFromDB.USER_CODE;
                model.LoginNo = userFromDB.USER_CODE;
                model.UserName = userFromDB.USER_NAME;
                model.QRCode = userFromDB.QR_CODE;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                (
                    2,
                    userFromDB.USER_CODE,
                    DateTime.Now,
                    tickets.Expiration,
                    false,
                    new JavaScriptSerializer().Serialize(model)  //序列化新的用户对象
                );
                string encTicket = FormsAuthentication.Encrypt(ticket);   //加密
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                if (ticket.Expiration != new DateTime(9999, 12, 31))    //不是默认时间才设置过期时间，否则会话cookie
                    cookie.Expires = tickets.Expiration;
                Response.Cookies.Add(cookie);  //写入cookie
            }

            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList(GridPager pager, string userId, string userName, string roleId)
        {
            IList<SysUserModel> list = _userApp.GetList(pager, userId, userName, roleId);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysUserModel()
                        {

                            USER_CODE = r.USER_CODE,
                            USER_NAME = r.USER_NAME,
                            USER_EMAIL = r.USER_EMAIL,
                            USER_TEL = r.USER_TEL,
                            USER_SEX = r.USER_SEX,
                            USER_POST = r.USER_POST,
                            USER_DESC = r.USER_DESC,
                            IS_ABLED = r.IS_ABLED,
                            IS_C_PWD = r.IS_C_PWD,
                            DEPT_CODE = r.DEPT_CODE,
                            DEPT_NAME = r.DEPT_NAME,
                            QR_CODE = r.QR_CODE,
                            CREATE_TIME = r.CREATE_TIME,
                        }).ToArray()
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string userId)
        {
            SysUserModel model = _userApp.GetById(userId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserNoRole(GridPager pager, string roleId, string user)
        {
            IList<SysUserModel> list = _userApp.GetUserNoRole(pager, roleId, user);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysUserModel()
                        {
                            USER_CODE = r.USER_CODE,
                            USER_NAME = r.USER_NAME,
                            USER_DESC = r.USER_DESC
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserYesRole(GridPager pager, string roleId, string user)
        {
            IList<SysUserModel> list = _userApp.GetUserYesRole(pager, roleId, user);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysUserModel()
                        {
                            USER_CODE = r.USER_CODE,
                            USER_NAME = r.USER_NAME,
                            USER_DESC = r.USER_DESC
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [RightFilter(ActionName = "Insert")]
        public JsonResult Insert(string userId, string userName, string e_mail, string tel, bool sex, string post, bool isAble, bool isChangePwd, string desc)
        {
            JsonMessage jsonMsg = _userApp.Insert(userId, userName, e_mail, tel, sex, post, isAble, isChangePwd, desc);

            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(string userId, string userName, string e_mail, string tel, bool sex, string post, bool resetPwd, bool qrCode, bool isAble, bool isChangePwd, string desc)
        {
            JsonMessage jsonMsg = _userApp.Edit(userId, userName, e_mail, tel, sex, post, resetPwd, qrCode, isAble, isChangePwd, desc);

            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        [RightFilter(ActionName = "Del")]
        public JsonResult Delete(string userId)
        {
            JsonMessage jsonMsg = _userApp.Delete(userId);

            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllotSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = _userApp.AllotSysUserRole(userId, roleId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = _userApp.DeleteSysUserRole(userId, roleId);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateUserDept(string user_code, string dept_code)
        {
            JsonMessage jsonMsg = _userApp.UpdateUserDept(user_code, dept_code);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListDistinctName()
        {
            IList<SysRoleModel> list = _roleApp.GetListDistinctName();
            var json = from r in list
                       select new
                       {
                           ROLEID = r.ROLE_ID,
                           ROLENAME = r.ROLE_NAME
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByDeptCode(GridPager pager, string dept_code)
        {
            IList<SysUserModel> list = _userApp.GetByDeptCode(pager, dept_code);
            var json = new
            {
                total = pager.totalRows,
                rows = from r in list
                       select new
                       {
                           USER_CODE = r.USER_CODE,
                           USER_NAME = r.USER_NAME,
                           IS_ABLED = r.IS_ABLED
                       }
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 列印用户二维码标签
        /// </summary>
        /// <param name="user_code">用户账号</param>
        /// <param name="is_qr">是否QR(true 是二维码，false是一维码)</param>
        /// <returns></returns>
        public JsonResult PrinterUserQR(string user_code, bool is_qr)
        {
            JsonMessage jsonMsg = _userApp.PrinterUserQR(user_code, is_qr);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取用户信息(or)
        /// </summary>
        /// <param name="user_code">工号</param>
        /// <param name="user_name">姓名</param>
        /// <returns></returns>
        public JsonResult GetUserByIdOrName(string user_code, string user_name)
        {
            SysUserModel model = _userApp.GetUserByIdOrName(user_code, user_name);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
