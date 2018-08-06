using BZ.Common;
using BZ.Domain.admin;
using BZ.Repository.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.App
{
    public class BaseApp
    {
        /// <summary>
        /// 记录模块操作方法
        /// </summary>
        protected const string CREATE = "CREATE|创建";
        protected const string DELETE = "DELETE|删除";
        protected const string UPDATE = "UPDATE|更新";
        protected const string SELECT = "SELECT|查找";


        public static string UserID
        {
            get
            {
                if (SessionHelper.GetSession("Account") == null)
                {
                    string cookie_account = CookieHelper.GetCookie("Account");
                    if (ValidateHelper.IsNullOrEmpty(cookie_account))
                    {
                        throw new CustomException(-2, "登陆超时，请重新登陆");
                    }
                    SessionHelper.SetSession("Account", ConverHelper.JsonToObj<AccountModel>(DESCryption.Decrypt(cookie_account)));
                }
                AccountModel account = (AccountModel)SessionHelper.GetSession("Account");
                return account.UserCode;
                //if (ValidateHelper.IsNullOrEmpty(_userID))
                //    throw new Exception("您登陆已经超时，请退出重新登陆！");
                //else
                //    return _userID;
            }
            //set { _userID = value; }
        }

        public static string UserName
        {
            get
            {
                AccountModel account = (AccountModel)SessionHelper.GetSession("Account");
                return account.UserName;

            }
        }
        /// <summary>
        /// erp用户id
        /// </summary>
        public static string ErpUserId
        {
            get
            {
                AccountModel account = (AccountModel)SessionHelper.GetSession("Account");
                if (ValidateHelper.IsNullOrEmpty(account.ErpUserId))
                {
                    throw new CustomException(-1, "账号【" + account.UserCode + "】，无ERP账号权限，请联系IT");
                }
                return account.ErpUserId;
            }
        }

        private static string _langName = "ZH_CN";

        public static string LangName
        {
            get { return BaseApp._langName; }
            set { BaseApp._langName = value; }
        }

        //protected IDomainDataProvider DB = DbHelper.DomainDataProvider.DomainDataProviderManager.DomainDataProvider("ODPPersistBroker", BZ.DbHelper.Config.Config.WmsConnectionString);

        /// <summary>
        /// 记录系统异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="type">哪个类</param>
        /// <param name="E_TYPE">哪个模块</param>
        /// <param name="remark1">说明</param>
        public void WriteSystemException(Exception ex, Type type, string E_Module, string remark1 = "")
        {

            try
            {

                SysExceptionRep exceiptionRep = new SysExceptionRep();

                string enamespace = type.FullName;
                string eclass = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
                string emethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;

                SysExceptionModel model = new SysExceptionModel()
                {
                    EX_ID = GuidHelper.GenerateComb().ToString().ToUpper(),
                    EX_HELPLINK = ex.HelpLink,
                    EX_MESSAGE = ex.Message,
                    EX_SOURCE = ex.Source,
                    EX_STACK = ex.StackTrace,
                    EX_TARGET = ex.TargetSite.ToString(),
                    EX_DATA = ex.Data.ToString(),
                    EX_NAMESPACE = enamespace,
                    EX_CLASS = eclass,
                    EX_METHOD = emethod,
                    EX_TYPE = E_Module,
                    EX_DESC = remark1,
                    CREATE_USER = UserID,
                    LM_USER = UserID

                };

                exceiptionRep.Insert(model);

            }
            catch (Exception ep)
            {
                LogHelper.Error(ep.Message);//异常失败写入txt
            }
        }

        /// <summary>
        /// 记录系统异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="type">哪个类</param>
        /// <param name="E_TYPE">哪个模块</param>
        /// <param name="remark1">说明</param>
        public void WriteSystemException(string oper, Exception ex, Type type, string E_Module, string remark1 = "")
        {
            try
            {

                SysExceptionRep exceiptionRep = new SysExceptionRep();

                string enamespace = type.FullName;
                string eclass = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
                string emethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;

                SysExceptionModel model = new SysExceptionModel()
                {
                    EX_ID = GuidHelper.GenerateComb().ToString().ToUpper(),
                    EX_HELPLINK = ex.HelpLink,
                    EX_MESSAGE = ex.Message,
                    EX_SOURCE = ex.Source,
                    EX_STACK = ex.StackTrace,
                    EX_TARGET = ex.TargetSite.ToString(),
                    EX_DATA = ex.Data.ToString(),
                    EX_NAMESPACE = enamespace,
                    EX_CLASS = eclass,
                    EX_METHOD = emethod,
                    EX_TYPE = E_Module,
                    EX_DESC = remark1,
                    CREATE_USER = oper,
                    LM_USER = oper
                };
                exceiptionRep.Insert(model);

            }
            catch (Exception ep)
            {
                LogHelper.Error(ep.Message);//异常失败写入txt
            }
        }

        /// <summary>
        /// 记录系统操作日志
        /// </summary>
        /// <param name="oper">操作人员</param>
        /// <param name="jsonMsg">返回前台的json 消息</param>
        /// <param name="type">类型(增、删、查、改)</param>
        /// <param name="module">操作模块</param>
        /// <param name="desc">备注说明</param>
        public static void WriteSystemLog(string oper, JsonMessage jsonMsg, string type, string module, string desc = "")
        {
            try
            {
                string enamespace = "";
                string eclass = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
                string emethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;

                SysLogRep _logRep = new SysLogRep();
                SysLogModel model = new SysLogModel();
                model.LOG_ID = GuidHelper.GenerateComb().ToString().ToUpper();
                model.OPERATE_ID = oper;
                model.LOG_MSG = jsonMsg.message;
                model.LOG_RESULT = jsonMsg.type == 1 ? "SUCCESS" : "FAIL";
                model.LOG_TYPE = type;
                model.LOG_MODULE = module;
                model.LOG_DESC = desc;
                model.LOG_NAMESPACE = enamespace;
                model.LOG_CLASS = eclass;
                model.LOG_METHOD = emethod;
                model.JSON_TYPE = jsonMsg.type;
                model.CREATE_USER = oper;
                model.LM_USER = oper;
                _logRep.Insert(model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);//异常失败写入txt
            }

        }

        /// <summary>
        /// 记录系统操作日志
        /// </summary>
        /// <param name="jsonMsg">返回前台的json 消息</param>
        /// <param name="type">类型(增、删、查、改)</param>
        /// <param name="module">操作模块</param>
        /// <param name="desc">备注说明</param>
        public void WriteSystemLog(JsonMessage jsonMsg, string type, string module, string desc = "")
        {
            try
            {
                string enamespace = "";
                string eclass = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
                string emethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;


                SysLogRep _logRep = new SysLogRep();
                SysLogModel model = new SysLogModel();
                model.LOG_ID = GuidHelper.GenerateComb().ToString().ToUpper();
                model.OPERATE_ID = UserID;
                model.LOG_MSG = jsonMsg.message;
                model.LOG_RESULT = jsonMsg.type == 1 ? "SUCCESS" : "FAIL";
                model.LOG_TYPE = type;
                model.LOG_MODULE = module;
                model.LOG_DESC = desc;
                model.LOG_NAMESPACE = enamespace;
                model.LOG_CLASS = eclass;
                model.LOG_METHOD = emethod;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;
                _logRep.Insert(model);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message);//异常失败写入txt
            }
        }

        /// <summary>
        /// 记录多语言日志
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public string GetLanguage(string langKey)
        {
            string langValue = langKey;
            SysLanguageRep _langRep = new SysLanguageRep();
            DataTable dt = _langRep.GetByServerSystem(langKey);
            if (dt != null && dt.Rows.Count > 0)
            {
                langValue = dt.Rows[0][_langName.ToUpper()].ToString();
            }
            return langValue;
        }
    }
}
