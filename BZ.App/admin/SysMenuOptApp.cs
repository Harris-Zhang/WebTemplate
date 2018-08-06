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
    public class SysMenuOptApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysMenuOpt|菜单按钮管理";

        SysMenuOptRep _menuOpApp = new SysMenuOptRep();

        /// <summary>
        /// 添加操作码
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="name"></param>
        /// <param name="menuId"></param>
        /// <param name="isValid"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public JsonMessage Insert(string keyCode, string name, string menuId, bool isValid, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _menuOpApp.GetByCodeOrName(menuId, name, keyCode);
                if (!ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, " 添加操作码失败，操作码名称或代码重复");
                }
                SysMenuOptModel model = new SysMenuOptModel();
                model.MO_CODE = keyCode;
                model.MO_NAME = name;
                model.MENU_ID = menuId;
                model.IS_ABLED = isValid ? 1 : 0;
                model.MO_DESC = desc;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;
                result = _menuOpApp.Insert(model);

                jsonMsg = ServiceResult.Message(1, "添加操作码成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "为菜单[" + menuId + "]添加操作码[" + keyCode + "]失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, menuId + ":" + keyCode + ":添加操作码");

            return jsonMsg;

        }
        /// <summary>
        /// 删除操作码
        /// </summary>
        /// <param name="moId"></param>
        /// <param name="menu_id"></param>
        /// <returns></returns>
        public JsonMessage Delete(string moId, string menu_id)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _menuOpApp.GetById(moId, menu_id);

                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "操作码删除失败，操作码不存在");
                }
                result = _menuOpApp.Delete(moId, menu_id);
                jsonMsg = ServiceResult.Message(1, "操作码删除成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, menu_id + ":" + moId + ":删除操作码失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, DELETE, OPT_MODEL, menu_id + ":" + moId + ":删除操作码");

            return jsonMsg;

        }
        /// <summary>
        /// 获取操作码列表
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public IList<SysMenuOptModel> GetOpListByMenuId(string menuId)
        {
            DataTable dt = _menuOpApp.GetOptListByMenuId(menuId);
            IList<SysMenuOptModel> list = ConverHelper.ToList<SysMenuOptModel>(dt);
            return list;
        }
    }
}
