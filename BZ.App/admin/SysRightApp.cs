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
    public class SysRightApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysRight|权限管理";
        //[Dependency]
        //public ISysRightRep _rightRep { get; set; }

        //[Dependency]
        //public ISysMenuRep _menuRep { get; set; }

        SysRightRep _rightRep = new SysRightRep();
        SysMenuRep _menuRep = new SysMenuRep();

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public IList<permModel> GetPermission(string userId, string url )
        {
            DataTable dt = _rightRep.GetPermission(userId, url );
            IList<permModel> list = ConverHelper.ToList<permModel>(dt);
            return list;
        }
        /// <summary>
        /// 分配角色权限
        /// </summary>
        /// <param name="menu_id"></param>
        /// <param name="role_id"></param>
        /// <param name="mo_codes"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public JsonMessage UpdateRight(string menu_id,string role_id , string mo_codes, bool isValid)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _rightRep.BeginTransaction();
            try
            {
                int cc= _rightRep.UpdateRightOptByMenuIdAndRoleId(menu_id, role_id);
                string[] mo_code = mo_codes.Split(',');
                foreach (string code in mo_code)
                {
                    SysRightOptModel model = new SysRightOptModel();

                    model.MENU_ID = menu_id;
                    model.ROLE_ID = role_id;
                    model.MO_CODE = code;
                    model.IS_ABLED = isValid ? 1 : 0;
                    model.CREATE_USER = UserID;
                    model.LM_USER = UserID;

                    //判断RightOpt是否存在，有就更新  否则就添加
                    if (_rightRep.UpdateRightOpt(model) < 1)
                    {
                        _rightRep.InsertRightOpt(model);
                    }
                }
                //_rightRep.InsertSysRight(UserID, UserID);
                _rightRep.UpdateRightFlagByMenuIdAndRoleId(1, menu_id, role_id);
 
                DataTable dt3 = _menuRep.GetById(menu_id);//获取父级ID
                if (dt3.Rows.Count > 0)
                {
                    string tmp_parentId = dt3.Rows[0]["PARENT_ID"].ToString();
                    DataTable dt4 = _rightRep.GetRightByMenuParentIdAndRoleId(tmp_parentId, role_id);
                    if (dt4.Rows.Count > 0)
                        _rightRep.UpdateRightFlagByMenuIdAndRoleId(1, tmp_parentId, role_id);
                    else
                        _rightRep.UpdateRightFlagByMenuIdAndRoleId(0, tmp_parentId, role_id);
                }
                result = 1;

                _rightRep.CommitTransaction();
                jsonMsg = ServiceResult.Message(1, "操作成功");
            }
            catch (Exception ex)
            {
                _rightRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "分配角色权限失败");
                
            } 

            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, "分配角色权限");

            return jsonMsg;

        }

        public IList<SysMenuOptRightModel> GetRightByMenuIdAndRoleId(string moduleId, string roleId)
        {
            DataTable dt = _rightRep.GetRightByMenuIdAndRoleId(moduleId, roleId);
            IList<SysMenuOptRightModel> list = ConverHelper.ToList<SysMenuOptRightModel>(dt);
            return list;
        }
    }
}
