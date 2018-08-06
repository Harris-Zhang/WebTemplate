using BZ.Common;
using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysLogRep : BaseRep 
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysLogModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_LOG");
            sql.AppendLine("  (LOG_ID,");
            sql.AppendLine("   OPERATE_ID,");
            sql.AppendLine("   LOG_MSG,");
            sql.AppendLine("   LOG_RESULT,");
            sql.AppendLine("   LOG_TYPE,");
            sql.AppendLine("   LOG_MODULE,");
            sql.AppendLine("   LOG_DESC,");
            sql.AppendLine("   LOG_NAMESPACE,");
            sql.AppendLine("   LOG_CLASS,");
            sql.AppendLine("   LOG_METHOD,");
            sql.AppendLine("   JSON_TYPE,");
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($LOG_ID,");
            sql.AppendLine("   $OPERATE_ID,");
            sql.AppendLine("   $LOG_MSG,");
            sql.AppendLine("   $LOG_RESULT,");
            sql.AppendLine("   $LOG_TYPE,");
            sql.AppendLine("   $LOG_MODULE,");
            sql.AppendLine("   $LOG_DESC,");
            sql.AppendLine("   $LOG_NAMESPACE,");
            sql.AppendLine("   $LOG_CLASS,");
            sql.AppendLine("   $LOG_METHOD,");
            sql.AppendLine("   $JSON_TYPE,");
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)");
            SQLParameter[] parms ={
                                      new SQLParameter("LOG_ID",typeof(string),model.LOG_ID),
                                      new SQLParameter("OPERATE_ID",typeof(string),model.OPERATE_ID),
                                      new SQLParameter("LOG_MSG",typeof(string),model.LOG_MSG),
                                      new SQLParameter("LOG_RESULT",typeof(string),model.LOG_RESULT),
                                      new SQLParameter("LOG_TYPE",typeof(string),model.LOG_TYPE),
                                      new SQLParameter("LOG_MODULE",typeof(string),model.LOG_MODULE),
                                      new SQLParameter("LOG_DESC",typeof(string),model.LOG_DESC),
                                      new SQLParameter("LOG_NAMESPACE",typeof(string),model.LOG_NAMESPACE),
                                      new SQLParameter("LOG_CLASS",typeof(string),model.LOG_CLASS),
                                      new SQLParameter("LOG_METHOD",typeof(string),model.LOG_METHOD),
                                      new SQLParameter("JSON_TYPE",typeof(int),model.JSON_TYPE),
                                      new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER) 
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_LOG WHERE LOG_ID = $LOG_ID");
            SQLParameter[] parms = { new SQLParameter("LOG_ID", typeof(string), id) };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));

            return result;
        }
        /// <summary>
        /// 根据ID获取日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SL.CREATE_TIME,");
            sql.AppendLine("       SL.LOG_ID,");
            sql.AppendLine("       SU.USER_NAME OPERATE_ID,");
            sql.AppendLine("       SL.LOG_MSG,");
            sql.AppendLine("       SL.LOG_RESULT,");
            sql.AppendLine("       SL.LOG_TYPE,");
            sql.AppendLine("       SL.LOG_MODULE,");
            sql.AppendLine("       SL.LOG_DESC,");
            sql.AppendLine("       SL.LOG_NAMESPACE,");
            sql.AppendLine("       SL.LOG_CLASS,");
            sql.AppendLine("       SL.LOG_METHOD,"); 
            sql.AppendLine("       SL.JSON_TYPE,");
            sql.AppendLine("       SL.CREATE_USER,");
            sql.AppendLine("       SL.LM_TIME,");
            sql.AppendLine("       SL.LM_USER");
            sql.AppendLine("  FROM SYS_LOG SL");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SL.OPERATE_ID = SU.USER_CODE");
            sql.AppendLine(" WHERE SL.LOG_ID = $LOG_ID");
            SQLParameter[] parms = { new SQLParameter("LOG_ID", typeof(string), id) };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="model"></param>
        /// <param name="userName"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable GetList(GridPager pager, SysLogModel model, string userName, string sDate, string eDate)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SL.CREATE_TIME,");
            sql.AppendLine("       SL.LOG_ID,");
            sql.AppendLine("       SU.USER_NAME OPERATE_ID,");
            sql.AppendLine("       SL.LOG_MSG,");
            sql.AppendLine("       SL.LOG_RESULT,");
            sql.AppendLine("       SL.LOG_TYPE,");
            sql.AppendLine("       SL.LOG_MODULE,");
            sql.AppendLine("       SL.LOG_DESC,");
            sql.AppendLine("       SL.LOG_NAMESPACE,");
            sql.AppendLine("       SL.LOG_CLASS,");
            sql.AppendLine("       SL.LOG_METHOD,");
            sql.AppendLine("       SL.JSON_TYPE,");
            sql.AppendLine("       SL.CREATE_USER,");
            sql.AppendLine("       SL.LM_TIME,");
            sql.AppendLine("       SL.LM_USER");
            sql.AppendLine("  FROM SYS_LOG SL");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SL.OPERATE_ID = SU.USER_CODE");
            sql.AppendLine(" WHERE 1=1");
            if (!string.IsNullOrEmpty(userName))
            {
                sql.AppendLine(" AND SU.USER_NAME LIKE $USER_NAME ");
                list.Add(new SQLParameter("USER_NAME", typeof(string), StringHelper.GetSqlLike(userName)));
            }

            if (!string.IsNullOrEmpty(sDate))
            {
                sql.AppendLine(" AND SL.CREATE_TIME >= $SDATE ");
                list.Add(new SQLParameter("SDATE", typeof(string), sDate));
            }
            if (!string.IsNullOrEmpty(eDate))
            {
                sql.AppendLine(" AND SL.CREATE_TIME <= $EDATE ");
                list.Add(new SQLParameter("EDATE", typeof(string), eDate));
            }
            if (!string.IsNullOrEmpty(model.LOG_MSG))
            {
                sql.AppendLine(" AND SL.LOG_MSG LIKE $MSG ");
                list.Add(new SQLParameter("MSG", typeof(string), StringHelper.GetSqlLike(model.LOG_MSG)));
            }

            if (!string.IsNullOrEmpty(model.LOG_RESULT))
            {
                sql.AppendLine(" AND SL.LOG_RESULT = $RESULT");
                list.Add(new SQLParameter("RESULT", typeof(string), model.LOG_RESULT));
            }
            if (!string.IsNullOrEmpty(model.LOG_TYPE))
            {
                sql.AppendLine(" AND SL.LOG_TYPE = $TYPE");
                list.Add(new SQLParameter("TYPE", typeof(string), model.LOG_TYPE));
            }
            if (!string.IsNullOrEmpty(model.LOG_MODULE))
            {
                sql.AppendLine(" AND SL.LOG_MODULE = $MODULE");
                list.Add(new SQLParameter("MODULE", typeof(string), model.LOG_MODULE));
            }
            SQLParameter[] parms = list.ToArray();
            DataSet ds = null;
            if (!pager.isPage)
            {
                ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            }
            else
            {
                pager.totalRows = DB.GetCount(new SQLParamCondition(string.Format("SELECT COUNT(*) COUNT FROM ({0}) TMP", sql), parms));
                ds = DB.CustomDataSet(new PagerParamCondition(sql.ToString(), pager.sortOrder, pager.startIndex, pager.endIndex, parms, false));
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取 distinct 日志类别、结果、模块
        /// </summary>
        /// <param name="field">字段名</param>
        /// <returns></returns>
        public DataTable GetLogType(string field)
        {
            string sql = string.Format("SELECT DISTINCT {0} LOG_ID,{0} LOG_TYPE FROM SYS_LOG ORDER BY {0}", field);
            DataSet ds = DB.CustomDataSet(new SQLCondition(sql));
            return ds.Tables[0];
        }
    }
}












