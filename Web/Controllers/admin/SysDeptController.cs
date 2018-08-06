
using BZ.App.admin;
using BZ.Common;
using BZ.Domain.admin; 
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Core;

namespace Web.Controllers.admin
{
    public class SysDeptController : BaseController
    {
        SysDeptApp _deptApp = new SysDeptApp();


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dept_code"></param>
        /// <param name="name"></param>
        /// <param name="parent_code"></param>
        /// <param name="site_code"></param>
        /// <param name="site_name"></param>
        /// <param name="sort"></param>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="is_able"></param>
        /// <param name="is_end"></param>
        /// <returns></returns>
        public JsonResult Insert(string dept_code, string name, string parent_code, string site_code, string site_name, int sort, string type, string desc, bool is_able, bool is_end)
        {
            JsonMessage jsonMsg = _deptApp.Insert(dept_code, name, parent_code, site_code, site_name, sort, type, desc, is_able, is_end);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dept_code"></param>
        /// <returns></returns>
        public JsonResult Delete(string dept_code)
        {
            JsonMessage jsonMsg = _deptApp.Delete(dept_code);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }
        //修改
        public JsonResult Edit(string dept_code, string name, string parent_code, string site_code, string site_name, int sort, string type, string desc, bool is_able, bool is_end)
        {
            JsonMessage jsonMsg = _deptApp.Edit(dept_code, name, parent_code, site_code, site_name, sort, type, desc, is_able, is_end);
            return Json(jsonMsg, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetList(string id)
        {
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0000000000"; 
            IList<SysDeptModel> list = _deptApp.GetList(id);
            var json = from r in list
                       select new SysDeptModel()
                       {
                           DEPT_CODE = r.DEPT_CODE,
                           DEPT_NAME = r.DEPT_NAME,
                           PARENT_CODE = r.PARENT_CODE,
                           SITE_CODE = r.SITE_CODE,
                           SITE_NAME = r.SITE_NAME,
                           DEPT_SORT = r.DEPT_SORT,
                           DEPT_TYPE = r.DEPT_TYPE,
                           DEPT_DESC = r.DEPT_DESC,
                           IS_ABLE = r.IS_ABLE,
                           IS_END = r.IS_END,
                           CREATE_TIME = r.CREATE_TIME,
                           CREATE_USER = r.CREATE_USER,
                           state = r.IS_END == 1 ? "open" : "closed"
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取部门树
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetListComboTree(string id)
        {
            if (ValidateHelper.IsNullOrEmpty(id))
                id = "0000000000";

            IList<SysDeptModel> list = _deptApp.GetList(id);
            var json = from r in list.Where(a=>a.DEPT_CODE!= "0000000000")
                       select new
                       {
                           id = r.DEPT_CODE,
                           text = r.DEPT_NAME,
                           state = r.IS_END == 1 ? "open" : "closed"
                       };
            return Json(json, JsonRequestBehavior.AllowGet);
        }


    }
}
