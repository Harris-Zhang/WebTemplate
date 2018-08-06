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
    public class SysUserApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysUser|用户管理";


        SysUserRep _userRep = new SysUserRep();

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户账号</param>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <param name="newPwdOk">二次新密码</param>
        /// <param name="isQR">是否更改二维码</param>
        /// <param name="QRCode">加密二维码</param>
        /// <returns></returns>
        public JsonMessage EditPassword(string userId, string oldPwd, string newPwd, string newPwdOk, bool isQR, string QRCode)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                SysUserModel model = null;
                DataTable dt = _userRep.Login(userId, oldPwd);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "旧密码不正确");
                }
                if (ValidateHelper.IsNullOrEmpty(userId))
                {
                    throw new CustomException(0, "非法操作，用户名不能为空");
                }
                if (ValidateHelper.IsNullOrEmpty(newPwd))
                {
                    throw new CustomException(0, "新密码不能为空");
                }
                if (oldPwd == newPwd)
                {
                    throw new CustomException(0, "旧密码不能已新密码一致");
                }
                if (newPwd != newPwdOk)
                {
                    throw new CustomException(0, "两次密码不一致");
                }

                result = _userRep.EditPassword(userId, newPwd, isQR, QRCode);
                jsonMsg = ServiceResult.Message(result, "密码修改成功");
            }
            catch(CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "用户自行修改密码失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, "用户修改密码");

            return jsonMsg;

        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public SysUserModel GetById(string userId)
        {
            DataTable dt = _userRep.GetById(userId);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            if (list.Count > 0)
                return list[0];
            return null;
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public JsonMessage GetUser()
        {
            JsonMessage jsonMsg = new JsonMessage();
            try
            {
                DataTable dt = _userRep.GetById(UserID);
                IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
                if (list.Count > 0)
                    jsonMsg = ServiceResult.Message(1, "获取成功", list[0]);
                else
                    jsonMsg = ServiceResult.Message(0, "获取失败，用户不存在，请确认", list[0]);

            }
            catch(CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
            }
            return jsonMsg;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IList<SysUserModel> GetList(GridPager pager, string userId, string userName, string roleId)
        {
            DataTable dt = _userRep.GetList(pager, userId, userName, roleId);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            return list;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="roleId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public IList<SysUserModel> GetUserNoRole(GridPager pager, string roleId, string user)
        {
            DataTable dt = _userRep.GetUserNoRole(pager, roleId, user);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            return list;
        }

        public IList<SysUserModel> GetUserYesRole(GridPager pager, string roleId, string user)
        {
            DataTable dt = _userRep.GetUserYesRole(pager, roleId, user);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            return list;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="e_mail"></param>
        /// <param name="tel"></param>
        /// <param name="sex"></param>
        /// <param name="post"></param>
        /// <param name="isAble"></param>
        /// <param name="isChangePwd"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public JsonMessage Insert(string userId, string userName, string e_mail, string tel, bool sex, string post, bool isAble, bool isChangePwd, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _userRep.GetById(userId);
                if (dt.Rows.Count > 0)
                {
                    throw new CustomException(0, "该用户已存在");//该用户已存在 
                }

                string newPwd = "123456";
                SysUserModel model = new SysUserModel();
                model.USER_CODE = userId;
                model.USER_NAME = userName;
                model.USER_PWD = MD5Cryption.MD5(newPwd);
                model.USER_EMAIL = e_mail;
                model.USER_TEL = tel;
                model.USER_SEX = sex ? 1 : 0;
                model.USER_POST = post;
                model.IS_ABLED = isAble ? 1 : 0;
                model.IS_C_PWD = isChangePwd ? 1 : 0;
                model.QR_CODE = DESCryption.Encrypt(userId + newPwd);
                model.USER_DESC = desc;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;

                result = _userRep.Insert(model);
                jsonMsg = ServiceResult.Message(result, "添加用户成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "添加用户失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "添加用户");

            return jsonMsg;

        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="e_mail"></param>
        /// <param name="tel"></param>
        /// <param name="sex"></param>
        /// <param name="post"></param>
        /// <param name="resetPwd"></param>
        /// <param name="qrCode"></param>
        /// <param name="isAble"></param>
        /// <param name="isChangePwd"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public JsonMessage Edit(string userId, string userName, string e_mail, string tel, bool sex, string post, bool resetPwd, bool qrCode, bool isAble, bool isChangePwd, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _userRep.GetById(userId);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "该用户不存在");
                }

                string newPwd = "123456";
                SysUserModel model = new SysUserModel();
                model.USER_CODE = userId;
                model.USER_NAME = userName;
                model.USER_PWD = resetPwd ? MD5Cryption.MD5(newPwd) : dt.Rows[0]["USER_PWD"].ToString();
                model.USER_EMAIL = e_mail;
                model.USER_TEL = tel;
                model.USER_SEX = sex ? 1 : 0;
                model.USER_POST = post;
                model.IS_ABLED = isAble ? 1 : 0;
                model.IS_C_PWD = isChangePwd ? 1 : 0;
                model.QR_CODE = qrCode ? DESCryption.Encrypt(userId + newPwd) : dt.Rows[0]["QR_CODE"].ToString();
                model.USER_DESC = desc;
                model.LM_USER = UserID;
                result = _userRep.Edit(model);

                jsonMsg = ServiceResult.Message(result, "修改用户成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "修改用户失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "修改用户");

            return jsonMsg;

        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonMessage Delete(string userId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {

                result = _userRep.Delete(userId);
                if (result > 0)
                {
                    _userRep.DeleteSysUserRoleByUserId(userId);//根据用户ID 删除用户与角色的对应关系
                }
                jsonMsg = ServiceResult.Message(result, "删除成功");
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, userId+":删除用户失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, userId + ":删除用户");

            return jsonMsg;

        }

        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonMessage AllotSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _userRep.BeginTransaction();
            try
            {
                _userRep.DeleteSysUserRoleByUserId(userId);
                string[] roleIds = roleId.Split(',');
                for (int i = 0; i < roleIds.Length; i++)
                {
                    SysUserRoleModel model = new SysUserRoleModel();
                    model.USER_CODE = userId;
                    model.ROLE_ID = roleIds[i];
                    model.CREATE_USER = UserID;
                    model.LM_USER = UserID;
                    result = _userRep.AllotSysUserRole(model);
                }
                _userRep.CommitTransaction();

                jsonMsg = ServiceResult.Message(result, "操作成功");
            }
            catch (Exception ex)
            {
                _userRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "用户分配角色失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "用户分配角色");

            return jsonMsg;

        }

        /// <summary>
        /// 删除角色与人员的对应关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonMessage DeleteSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                result = _userRep.DeleteSysUserRole(userId, roleId);
                jsonMsg = ServiceResult.Message(result, "操作成功");
            }
            catch (Exception ex)
            {
                _userRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "删除角色与人员的对应关系失败");

            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "删除角色与人员的对应关系");

            return jsonMsg;

        }
        /// <summary>
        /// 设定用户部门
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public JsonMessage UpdateUserDept(string userId, string deptId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _userRep.GetById(userId);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "该用户不存在");//  
                }
                result = _userRep.UpdateUserDept(userId, deptId);

                jsonMsg = ServiceResult.Message(result, "更新成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "设定用户部门失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "设定用户部门");

            return jsonMsg;

        }

        public IList<SysUserModel> GetByDeptCode(GridPager pager, string dept_code)
        {
            DataTable dt = _userRep.GetByDeptCode(pager, dept_code);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            return list;
        }

        /// <summary>
        /// 列印用户二维码标签
        /// </summary>
        /// <param name="user_code">用户账号</param>
        /// <param name="is_qr">是否QR(true 是二维码，false是一维码)</param>
        /// <returns></returns>
        public JsonMessage PrinterUserQR(string user_code, bool is_qr)
        {
            string tmpUser = user_code.Replace(",", "','");
            DataTable dt = _userRep.GetUserByIds(tmpUser);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            string nowDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string img = "<img style='width: 342px;' src='/route/common/BarQRImg/GetBarCodeImg?text=";
            string tbl = "";
            tbl = "<table style='width:18cm' border='1' cellspacing='10'><tr height='120px'>";
            if (is_qr == true)
                img = "<img style='width: 100px;' src='/route/common/BarQRImg/GetQrCodeImg?size=3&text=";
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 3 == 0 && i != 0)
                {

                    if (is_qr == true)
                    {
                        if (i % 18 == 0)
                        {
                            tbl += "</tr><tr height='140px' style='page-break-before:always;' >";
                        }
                        else
                        {
                            tbl += "</tr><tr height='140px'  >";
                        }
                    }
                    else
                    {
                        if (i % 30 == 0)
                        {
                            tbl += "</tr><tr height='140px' style='page-break-before:always;' >";
                        }
                        else
                        {
                            tbl += "</tr><tr height='140px'  >";
                        }
                    }


                }

                tbl += "<td style='text-align: center; width: 5.5cm; font-size: 16px;'>" + list[i].USER_CODE + "<br/>" + list[i].USER_NAME + "<br/>";
                tbl += img + list[i].QR_CODE + "' /> " + "<br/>" + nowDate + "</td>";
                if (i == list.Count - 1 && i % 3 != 0)
                {
                    tbl += "</tr>";
                }
            }
            tbl += "</table>";

            JsonMessage jsonMsg = ServiceResult.Message(1, "", tbl);
            return jsonMsg;
        }
        /// <summary>
        /// 获取用户信息(or)
        /// </summary>
        /// <param name="user_code">工号</param>
        /// <param name="user_name">姓名</param>
        /// <returns></returns>
        public SysUserModel GetUserByIdOrName(string user_code, string user_name)
        {
            DataTable dt = _userRep.GetUserByIdOrName(user_code, user_name);
            IList<SysUserModel> list = ConverHelper.ToList<SysUserModel>(dt);
            if (list.Count > 0)
                return list[0];
            return new SysUserModel() ;
        }
    }
}
