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
    public class SysRoleApp : BaseApp 
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysRole|角色设定";

        SysRoleRep _roleRep = new SysRoleRep();
        SysMenuRep _menuRep = new SysMenuRep();
        SysUserRep _userRep = new SysUserRep();
        SysRightRep _rightRep = new SysRightRep();

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public JsonMessage Insert(string roleName, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _roleRep.GetByRoleName(roleName);
                if (!ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "角色名称重复，请重新填写 ");//角色名称重复，请重新填写 
                }
                SysRoleModel model = new SysRoleModel();
                model.ROLE_ID = GuidHelper.GenerateComb().ToString().ToUpper();
                model.ROLE_NAME = roleName;
                model.ROLE_DESC = desc;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;
                result = _roleRep.Insert(model);
                if (result == 1)
                {
                    _rightRep.InsertSysRight(model.CREATE_USER, model.LM_USER);
                }
                jsonMsg = ServiceResult.Message(1, "角色添加成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {//记录异常
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "添加角色失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, "添加角色信息");

            return jsonMsg;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public JsonMessage Delete(string roleId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _roleRep.GetById(roleId);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "角色删除失败，角色不存在");//
                }

                result = _roleRep.Delete(roleId);
                if (result > 0)
                {
                    _userRep.DeleteSysUserRoleByRoleId(roleId);//根据角色ID 删除用户与角色的对应关系
                    _roleRep.ClearUnusedRightOpt();
                }
                jsonMsg = ServiceResult.Message(1, "角色删除成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "删除角色失败");
            }
             
            //写入log
            WriteSystemLog(jsonMsg, DELETE, OPT_MODEL, "删除角色");

            return jsonMsg;

        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public JsonMessage Edit(string roleId, string roleName, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _roleRep.GetById(roleId);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "角色修改失败，角色不存在");//
                }

                SysRoleModel model = new SysRoleModel();
                model.ROLE_ID = roleId;
                model.ROLE_NAME = roleName;
                model.ROLE_DESC = desc;
                model.LM_USER = UserID;
                result = _roleRep.Edit(model);
                jsonMsg = ServiceResult.Message(1, "角色修改成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "修改角色失败");
            }
             
            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, "修改角色信息");

            return jsonMsg;
        }

        public IList<SysRoleModel> GetList(GridPager pager, string roleName, string desc)
        {
            DataTable dt = _roleRep.GetList(pager, roleName, desc);
            IList<SysRoleModel> list = ConverHelper.ToList<SysRoleModel>(dt);
            return list;
        }

        public SysRoleModel GetById(string roleId)
        {
            DataTable dt = _roleRep.GetById(roleId);
            IList<SysRoleModel> list = ConverHelper.ToList<SysRoleModel>(dt);
            return list[0];
        }


        public IList<SysRoleModel> GetRoleNoUser(string userId)
        {
            DataTable dt = _roleRep.GetRoleNoUser(userId);
            IList<SysRoleModel> list = ConverHelper.ToList<SysRoleModel>(dt);
            return list;
        }

        public IList<SysRoleModel> GetRoleYesUser(string userId)
        {
            DataTable dt = _roleRep.GetRoleYesUser(userId);
            IList<SysRoleModel> list = ConverHelper.ToList<SysRoleModel>(dt);
            return list;
        }

        public JsonMessage AllotSysUserRole(string userId, string roleId)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _userRep.BeginTransaction();//事务开始
            try
            {
                _userRep.DeleteSysUserRoleByRoleId(roleId);
                string[] userIds = userId.Split(',');
                for (int i = 0; i < userIds.Length; i++)
                {
                    SysUserRoleModel model = new SysUserRoleModel();
                    model.USER_CODE = userIds[i];
                    model.ROLE_ID = roleId;
                    model.CREATE_USER = UserID;
                    model.LM_USER = UserID;
                    result = _userRep.AllotSysUserRole(model);
                }
                _userRep.CommitTransaction();
                jsonMsg = ServiceResult.Message(1, "分配成功");
            }
            catch (Exception ex)
            {
                _userRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "用户分配角色失败"); 
            }

            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, "用户分配角色");

            return jsonMsg;

        }

        public IList<SysRoleModel> GetListDistinctName()
        {
            DataTable dt = _roleRep.GetListDistinctName();
            IList<SysRoleModel> list = ConverHelper.ToList<SysRoleModel>(dt);
            if (list.Count > 0)
            {
                SysRoleModel model = new SysRoleModel();
                model.ROLE_ID = "";
                model.ROLE_NAME = "--ALL--";
                list.Insert(0, model);
            }
            return list;
        }
    }
}
