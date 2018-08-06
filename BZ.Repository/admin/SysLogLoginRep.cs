using BZ.Common;
using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysLogLoginRep : BaseRep 
    {
        /// <summary>
        /// 添加登录信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysLogLoginModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_LOG_LOGIN");
            sql.AppendLine("  (LOGIN_ID,");
            sql.AppendLine("   USER_CODE,");
            sql.AppendLine("   USER_PWD,");
            sql.AppendLine("   USER_PWD_LAWS,");
            sql.AppendLine("   LOGIN_IP,");
            sql.AppendLine("   LOGIN_RESULT,");
            sql.AppendLine("   LOGIN_MSG,");
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($LOGIN_ID,");
            sql.AppendLine("   $USER_CODE,");
            sql.AppendLine("   $USER_PWD,");
            sql.AppendLine("   $USER_PWD_LAWS,");
            sql.AppendLine("   $LOGIN_IP,");
            sql.AppendLine("   $LOGIN_RESULT,");
            sql.AppendLine("   $LOGIN_MSG,");
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)");
            SQLParameter[] parms ={
                                      new SQLParameter("LOGIN_ID",typeof(string),model.LOGIN_ID),
                                      new SQLParameter("USER_CODE",typeof(string),model.USER_CODE),
                                      new SQLParameter("USER_PWD",typeof(string),model.USER_PWD),
                                      new SQLParameter("USER_PWD_LAWS",typeof(string),model.USER_PWD_LAWS),
                                      new SQLParameter("LOGIN_IP",typeof(string),model.LOGIN_IP),
                                      new SQLParameter("LOGIN_RESULT",typeof(string),model.LOGIN_RESULT),
                                      new SQLParameter("LOGIN_MSG",typeof(string),model.LOGIN_MSG),
                                      new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER) 
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

        /// <summary>
        /// 删除登录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_LOG_LOGIN WHERE LOGIN_ID = $LOGIN_ID");
            SQLParameter[] parms = { new SQLParameter("LOGIN_ID", typeof(string), id) };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));

            return result;
        }
        /// <summary>
        /// 根据ID获取登录日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SL.CREATE_TIME,");
            sql.AppendLine("       SL.LOGIN_ID,");
            sql.AppendLine("       SL.USER_CODE,");
            sql.AppendLine("       SL.USER_PWD,");
            sql.AppendLine("       SL.USER_PWD_LAWS,");
            sql.AppendLine("       SL.LOGIN_IP,");
            sql.AppendLine("       SL.LOGIN_RESULT,");
            sql.AppendLine("       SL.LOGIN_MSG,");
            sql.AppendLine("       SL.CREATE_USER,");
            sql.AppendLine("       SL.LM_TIME,");
            sql.AppendLine("       SL.LM_USER");
            sql.AppendLine("  FROM SYS_LOG_LOGIN SL");
            sql.AppendLine(" WHERE SL.LOGIN_ID = $LOGIN_ID");
            SQLParameter[] parms = { new SQLParameter("LOGIN_ID", typeof(string), id) };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取登录日志列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="ip"></param>
        /// <param name="user_code"></param>
        /// <param name="sDate"></param>
        /// <param name="eDate"></param>
        /// <returns></returns>
        public DataTable GetList(GridPager pager, string ip, string user_code, string sDate, string eDate)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SL.CREATE_TIME,");
            sql.AppendLine("       SL.LOGIN_ID,");
            sql.AppendLine("       SL.USER_CODE,");
            sql.AppendLine("       SL.USER_PWD,");
            sql.AppendLine("       SL.USER_PWD_LAWS,");
            sql.AppendLine("       SL.LOGIN_IP,");
            sql.AppendLine("       SL.LOGIN_RESULT,");
            sql.AppendLine("       SL.LOGIN_MSG,");
            sql.AppendLine("       SL.CREATE_USER,");
            sql.AppendLine("       SL.LM_TIME,");
            sql.AppendLine("       SL.LM_USER");
            sql.AppendLine("  FROM SYS_LOG_LOGIN SL");
            sql.AppendLine(" WHERE 1 = 1");
            if (!string.IsNullOrEmpty(user_code))
            {
                sql.AppendLine(" AND SU.USER_CODE LIKE $USER_CODE ");
                list.Add(new SQLParameter("USER_CODE", typeof(string), StringHelper.GetSqlLike(user_code)));
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
            if (!string.IsNullOrEmpty(ip))
            {
                sql.AppendLine(" AND SL.LOGIN_IP = $LOGIN_IP ");
                list.Add(new SQLParameter("LOGIN_IP", typeof(string), ip));
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

 
    }
}












