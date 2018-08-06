using BZ.App.admin;
using BZ.Common;
using BZ.Domain.admin; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Core
{
    public class BaseController : Controller
    {
        public string UserId
        {
            get
            {
                return GetAccount.UserCode;
            }
        } 

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns>用户信息</returns>
        public AccountModel GetAccount
        {
            get
            {
                if (SessionHelper.GetSession("Account") == null)
                {
                    string cookie_account = CookieHelper.GetCookie("Account");
                    if (ValidateHelper.IsNullOrEmpty(cookie_account))
                    {
                        return new AccountModel();
                    }
                    SessionHelper.SetSession("Account", ConverHelper.JsonToObj<AccountModel>(DESCryption.Decrypt(cookie_account)));
                }
                AccountModel account = (AccountModel)SessionHelper.GetSession("Account");
                return account;
            }
        }
 

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 返回JsonResult.24         /// </summary>
        /// <param name="data">数据</param>
        /// <param name="behavior">行为</param>
        /// <param name="format">json中dateTime类型的格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }
        /// <summary>
        /// 返回JsonResult42         /// </summary>
        /// <param name="data">数据</param>
        /// <param name="format">数据格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = format
            };
        }
         
        //清空 easyui Datagrid 
        public object EasyUIDataGridClear
        {
            get
            {
                var clear = new
                {
                    total = 0,
                    rows = ""
                };
                return clear;
            }
        }
 
    }
}