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
    public class SysDeptApp : BaseApp
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysDept|部门管理";
        SysDeptRep _deptRep = new SysDeptRep();

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="parentId"></param>
        /// <param name="site_code"></param>
        /// <param name="site_name"></param>
        /// <param name="sort"></param>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="isAble"></param>
        /// <param name="isEnd"></param>
        /// <returns></returns>
        public JsonMessage Insert(string code, string name, string parent_code, string site_code, string site_name, int sort, string type, string desc, bool isAble, bool isEnd)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _deptRep.GetById(parent_code);
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new CustomException(0, "添加失败，父节点不存在，请刷新后在试");//添加失败，父节点不存在，请刷新后在试
                }

                DataTable dt2 = _deptRep.GetByCodeOrName(code, name);
                if (!ValidateHelper.IsDataTableNotData(dt2))
                {
                    throw new CustomException(0, "添加失败，部门编号或名称已存在");
                }

                SysDeptModel model = new SysDeptModel();
                model.DEPT_CODE = code;
                model.DEPT_NAME = name;
                model.PARENT_CODE = parent_code;
                model.SITE_CODE = site_code;
                model.SITE_NAME = site_name;
                model.DEPT_SORT = sort;
                model.DEPT_TYPE = "LOCAL";
                model.DEPT_DESC = desc;
                model.IS_ABLE = isAble ? 1 : 0;
                model.IS_END = isEnd ? 1 : 0;
                model.CREATE_USER = UserID;
                model.LM_USER = UserID;

                result = _deptRep.Insert(model);
                jsonMsg = ServiceResult.Message(1, "添加成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, name + ":添加部门信息失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, CREATE, OPT_MODEL, name + ":添加部门信息");

            return jsonMsg;

        }

        public JsonMessage Delete(string dept_code)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                if (dept_code == "0000000000")
                {
                    throw new CustomException(0, "删除失败，顶级菜单不能删除");//
                }
                DataTable dt = _deptRep.GetByParentId(dept_code);
                if (!ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "删除失败，该部门下存在子部门，请先删除子部门"); //
                }
                DataTable dt_n = _deptRep.GetById(dept_code);
                if (ValidateHelper.IsDataTableNotData(dt_n))
                {
                    throw new CustomException(0, "删除失败，该部门不存在，请刷新后再试");//
                }

                result = _deptRep.Delete(dept_code);
                jsonMsg = ServiceResult.Message(1, "删除成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, dept_code + ":删除部门信息失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, DELETE, OPT_MODEL, dept_code + ":删除部门信息");

            return jsonMsg;

        }
        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="dept_code"></param>
        /// <param name="name"></param>
        /// <param name="parent_code"></param>
        /// <param name="site_code"></param>
        /// <param name="site_name"></param>
        /// <param name="sort"></param>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="isAble"></param>
        /// <param name="isEnd"></param>
        /// <returns></returns>
        public JsonMessage Edit(string dept_code, string name, string parent_code, string site_code, string site_name, int sort, string type, string desc, bool isAble, bool isEnd)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                DataTable dt = _deptRep.GetById(dept_code);
                if (ValidateHelper.IsDataTableNotData(dt))
                {
                    throw new CustomException(0, "更新失败，该部门不存在，请刷新后再试");//
                }

                SysDeptModel model = new SysDeptModel();
                model.DEPT_CODE = dept_code;
                model.DEPT_NAME = name;
                model.PARENT_CODE = parent_code;
                model.SITE_CODE = site_code;
                model.SITE_NAME = site_name;
                model.DEPT_SORT = sort;
                model.DEPT_TYPE = "LOCAL";
                model.DEPT_DESC = desc;
                model.IS_ABLE = isAble ? 1 : 0;
                model.IS_END = isEnd ? 1 : 0;
                model.LM_USER = UserID;

                result = _deptRep.Edit(model);
                jsonMsg = ServiceResult.Message(1, "更新成功");
            }
            catch (CustomException ex)
            {
                jsonMsg = ServiceResult.Message(ex.ResultFlag, ex.Message);
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, dept_code + ":更新部门信息失败");
            }

            //写入log
            WriteSystemLog(jsonMsg, UPDATE, OPT_MODEL, dept_code + ":更新部门信息");

            return jsonMsg;

        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="parent_code"></param>
        /// <returns></returns>
        public IList<SysDeptModel> GetList(string parent_code)
        {
            DataTable dt = _deptRep.GetList(parent_code);
            IList<SysDeptModel> list = ConverHelper.ToList<SysDeptModel>(dt);
            return list;
        }

    }
}
