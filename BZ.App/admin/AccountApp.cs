using BZ.Common;
using BZ.Domain.admin;
using BZ.Repository.admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.App.admin
{
    public class AccountApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "Login|用户登陆";


        SysUserRep _userRep = new SysUserRep();
        AppVersionRep _appRep = new AppVersionRep();

        SysLogLoginRep _loglRep = new SysLogLoginRep();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model">返回用户信息</param>
        /// <param name="user_id">登录名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public JsonMessage Login(ref AccountModel model, string user_id, string pwd)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败) 
            try
            {
                if (ValidateHelper.IsNullOrEmpty(StringHelper.Trim(user_id)))
                {
                    throw new CustomException(0, "用户名不能为空");
                }
                if (ValidateHelper.IsNullOrEmpty(pwd))
                {
                    throw new CustomException(0, "密码不能为空");
                }

                //UserID = userId;
                DataTable dt = _userRep.Login(user_id, MD5Cryption.MD5(pwd));
                IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
                if (list.Count < 1)
                {
                    throw new CustomException(2, "用户名或密码错误");//用户名或密码错误
                }
                if (!ConverHelper.ToBool(list[0].IS_ABLED))
                {
                    throw new CustomException(3, "账号已被禁用，请联系系统管理员");//账号是否被禁用
                }
                model.UserCode = list[0].USER_CODE;
                model.UserName = list[0].USER_NAME;
                model.LoginNo = list[0].USER_CODE;
                model.QRCode = list[0].QR_CODE;
                model.DeptCode = list[0].DEPT_CODE;

                jsonMsg = ServiceResult.Message(1, "登录成功");

                SessionHelper.SetSession("Account", model);

                CookieHelper.SetCookie("Account", DESCryption.Encrypt(ConverHelper.ToJson(model)));

            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
            }
            //写入log 
            SysLogLoginModel log = new SysLogLoginModel();
            log.LOGIN_ID = GuidHelper.GenerateComb().ToString();
            log.USER_CODE = user_id;
            log.USER_PWD = MD5Cryption.MD5(pwd);
            log.USER_PWD_LAWS = pwd;
            log.LOGIN_IP = NetHelper.GetUserIp;
            log.LOGIN_RESULT = jsonMsg.type == 1 ? "SUCCESS" : "FAIL";
            log.LOGIN_MSG = jsonMsg.message;
            _loglRep.Insert(log);

            return jsonMsg;

        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model">返回用户信息</param>
        /// <param name="user_id">登录名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public JsonMessage Login(string user_id, string pwd, string qr_code)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败) 
            try
            {
                if (ValidateHelper.IsNullOrEmpty(user_id) && ValidateHelper.IsNullOrEmpty(qr_code))
                {
                    throw new CustomException(0, "用户名和二维码不能同时为空");
                }
                if (ValidateHelper.IsNullOrEmpty(pwd) && ValidateHelper.IsNullOrEmpty(qr_code))
                {
                    throw new CustomException(0, "密码和二维码不能同时为空");
                }
                DataTable dt;
                if (ValidateHelper.IsNullOrEmpty(qr_code))
                    dt = _userRep.Login(user_id, pwd);
                else
                    dt = _userRep.Login(qr_code);
                IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
                if (list.Count < 1)
                {
                    if (ValidateHelper.IsNullOrEmpty(qr_code))
                        throw new CustomException(2, "用户名或密码错误");//用户名或密码错误
                    else
                        throw new CustomException(2, "二维码不正确");//二维码不正确
                }
                if (!ConverHelper.ToBool(list[0].IS_ABLED))
                {
                    throw new CustomException(3, "账号已被禁用，请联系系统管理员");//账号是否被禁用
                }

                jsonMsg = ServiceResult.Message(1, "登录成功", list[0]);

            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);

            }

            //写入log 
            SysLogLoginModel log = new SysLogLoginModel();
            log.LOGIN_ID = GuidHelper.GenerateComb().ToString();
            log.USER_CODE = user_id;
            log.USER_PWD = MD5Cryption.MD5(pwd);
            log.USER_PWD_LAWS = ValidateHelper.IsNullOrEmpty(user_id) ? qr_code : pwd;
            log.LOGIN_IP = NetHelper.GetUserIp;
            log.LOGIN_RESULT = jsonMsg.type == 1 ? "SUCCESS" : "FAIL";
            log.LOGIN_MSG = jsonMsg.message;
            _loglRep.Insert(log);

            return jsonMsg;

        }

        /// <summary>
        /// 获取app最新版本号
        /// </summary>
        /// <returns></returns>
        public AppVersionModel GetNewAppVersion()
        {
            DataTable dt = _appRep.GetNewAppVersion();
            if (ValidateHelper.IsDataTableNotData(dt))
            {
                return new AppVersionModel();
            }
            IList<AppVersionModel> list = ConverHelper.ToList<AppVersionModel>(dt);
            return list[0];
        }
    }
}
