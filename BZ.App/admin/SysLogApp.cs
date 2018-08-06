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
    public class SysLogApp : BaseApp 
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysLog|日志管理"; 
        SysLogRep _logRep = new SysLogRep();

        public JsonMessage Insert(string userid, string msg, string res, string type, string module, string space, string eclass, string emethed, string desc)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            try
            {
                SysLogModel model = new SysLogModel();
                model.LOG_ID = GuidHelper.GenerateComb().ToString().ToUpper(); 
                model.OPERATE_ID = userid;
                model.LOG_MSG = msg;
                model.LOG_RESULT = res;
                model.LOG_TYPE = type;
                model.LOG_MODULE = module;
                model.LOG_NAMESPACE = space;
                model.LOG_CLASS = eclass;
                model.LOG_METHOD = emethed;
                model.LOG_DESC = desc;
                result = _logRep.Insert(model);
                jsonMsg = ServiceResult.Message(1, "添加日志成功");
            }
            catch (Exception ex)
            {
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, "添加日志失败");
            } 

            return jsonMsg;
        }

        public JsonMessage Delete(string id)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _logRep.BeginTransaction();
            try
            {
                string[] ids = id.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    result = _logRep.Delete(ids[i]);
                }
                _logRep.CommitTransaction();
                jsonMsg = ServiceResult.Message(1, "删除日志成功");
            }
            catch (Exception ex)
            { 
                _logRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, id+":删除日志失败");
            }
             
            return jsonMsg;
 
        }

        public SysLogModel GetById(string id)
        {
            DataTable dt = _logRep.GetById(id);
            IList<SysLogModel> list = ConverHelper.ToList<SysLogModel>(dt);
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public IList<SysLogModel> GetList(GridPager pager, string msg, string res, string type, string module, string userName, string sDate, string eDate)
        {
            SysLogModel model = new SysLogModel();
            model.LOG_MSG = msg;
            model.LOG_RESULT = res;
            model.LOG_TYPE = type;
            model.LOG_MODULE = module;
            DataTable dt = _logRep.GetList(pager, model, userName, sDate, eDate);
            IList<SysLogModel> list = ConverHelper.ToList<SysLogModel>(dt);
            return list;
        }

        public IList<SysLogModel> GetLogType(string field)
        {
            DataTable dt = _logRep.GetLogType(field);
            IList<SysLogModel> list = ConverHelper.ToList<SysLogModel>(dt);
            if (list.Count > 0)
            {
                SysLogModel model = new SysLogModel();
                model.LOG_ID = "";
                model.LOG_TYPE = "--ALL--";
                list.Insert(0, model);
            }
            return list;
        }
    }
}
