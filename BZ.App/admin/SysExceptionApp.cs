using BZ.Common;
using BZ.Domain.admin; 
using BZ.Repository.admin;
using System;
using System.Collections.Generic;
using System.Data;

namespace BZ.App.admin
{
    public class SysExceptionApp : BaseApp 
    {
        /// <summary>
        /// 当前操作模块
        /// </summary>
        const string OPT_MODEL = "SysException|系统异常管理";
        //[Dependency]
        //public ISysExceptionRep _exceptionRep { get; set; }

        SysExceptionRep _exceptionRep = new SysExceptionRep();

        public JsonMessage Delete(string id)
        {
            JsonMessage jsonMsg = new JsonMessage();//返回Json
            int result = -1;//类型(成功 、失败)
            _exceptionRep.BeginTransaction();
            try
            {
                string[] ids = id.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    result = _exceptionRep.Delete(ids[i]);
                }
                _exceptionRep.CommitTransaction();
                jsonMsg = ServiceResult.Message(1, "删除成功");
            }
            catch (Exception ex)
            {
                _exceptionRep.RollbackTransaction();
                jsonMsg = ServiceResult.Message(-1, ex.Message);
                WriteSystemException(ex, this.GetType(), OPT_MODEL, id+":删除系统异常异常");
            }
             
            //写入log
            WriteSystemLog(jsonMsg, DELETE, OPT_MODEL,id+ ":删除系统异常");

            return jsonMsg;
        }

        public SysExceptionModel GetById(string id)
        {
            DataTable dt = _exceptionRep.GetById(id);
            IList<SysExceptionModel> list = ConverHelper.ToList<SysExceptionModel>(dt);
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public IList<SysExceptionModel> GetList(GridPager pager, string userName, string sDate, string eDate)
        {
            DataTable dt = _exceptionRep.GetList(pager, userName, sDate, eDate);
            IList<SysExceptionModel> list = ConverHelper.ToList<SysExceptionModel>(dt);
            return list;
        }
    }
}
