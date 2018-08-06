using BZ.Common;
using BZ.DbHelper.DataProvider;
using BZ.Domain.admin;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysExceptionRep : BaseRep
    {
        /// <summary>
        /// 添加异常记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysExceptionModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_EXCEPTION");
            sql.AppendLine("  (EX_ID,");
            sql.AppendLine("   EX_HELPLINK,");
            sql.AppendLine("   EX_MESSAGE,");
            sql.AppendLine("   EX_SOURCE,");
            sql.AppendLine("   EX_STACK,");
            sql.AppendLine("   EX_TARGET,");
            sql.AppendLine("   EX_DATA,");
            sql.AppendLine("   EX_NAMESPACE,");
            sql.AppendLine("   EX_CLASS,");
            sql.AppendLine("   EX_METHOD,");
            sql.AppendLine("   EX_TYPE,");
            sql.AppendLine("   EX_DESC,");
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($EX_ID,");
            sql.AppendLine("   $EX_HELPLINK,");
            sql.AppendLine("   $EX_MESSAGE,");
            sql.AppendLine("   $EX_SOURCE,");
            sql.AppendLine("   $EX_STACK,");
            sql.AppendLine("   $EX_TARGET,");
            sql.AppendLine("   $EX_DATA,");
            sql.AppendLine("   $EX_NAMESPACE,");
            sql.AppendLine("   $EX_CLASS,");
            sql.AppendLine("   $EX_METHOD,");
            sql.AppendLine("   $EX_TYPE,");
            sql.AppendLine("   $EX_DESC,");
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)");
            SQLParameter[] parms ={
                                      new SQLParameter("EX_ID",typeof(string),model.EX_ID),
                                      new SQLParameter("EX_HELPLINK",typeof(string),model.EX_HELPLINK),
                                      new SQLParameter("EX_MESSAGE",typeof(string),model.EX_MESSAGE),
                                      new SQLParameter("EX_SOURCE",typeof(string),model.EX_SOURCE),
                                      new SQLParameter("EX_STACK",typeof(string),model.EX_STACK),
                                      new SQLParameter("EX_TARGET",typeof(string),model.EX_TARGET),
                                      new SQLParameter("EX_DATA",typeof(string),model.EX_DATA),
                                      new SQLParameter("EX_NAMESPACE",typeof(string),model.EX_NAMESPACE),
                                      new SQLParameter("EX_CLASS",typeof(string),model.EX_CLASS),
                                      new SQLParameter("EX_METHOD",typeof(string),model.EX_METHOD),
                                      new SQLParameter("EX_TYPE",typeof(string),model.EX_TYPE),
                                      new SQLParameter("EX_DESC",typeof(string),model.EX_DESC),
                                      new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;

        }
        /// <summary>
        /// 删除异常记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_EXCEPTION WHERE EX_ID = $EX_ID");
            SQLParameter[] parms = { new SQLParameter("EX_ID", typeof(string), id) };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 获取异常记录明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT EX.CREATE_TIME,");
            sql.AppendLine("       EX.EX_ID,");
            sql.AppendLine("       EX.EX_HELPLINK,");
            sql.AppendLine("       EX.EX_MESSAGE,");
            sql.AppendLine("       EX.EX_SOURCE,");
            sql.AppendLine("       EX.EX_STACK,");
            sql.AppendLine("       EX.EX_TARGET,");
            sql.AppendLine("       EX.EX_DATA,");
            sql.AppendLine("       EX.EX_NAMESPACE,");
            sql.AppendLine("       EX.EX_CLASS,");
            sql.AppendLine("       EX.EX_METHOD,");
            sql.AppendLine("       EX.EX_TYPE,");
            sql.AppendLine("       EX.EX_DESC,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       EX.LM_TIME,");
            sql.AppendLine("       EX.LM_USER");
            sql.AppendLine("  FROM SYS_EXCEPTION EX");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON EX.CREATE_USER = SU.USER_CODE");
            sql.AppendLine(" WHERE EX.EX_ID = $EX_ID");
            SQLParameter[] parms = { new SQLParameter("EX_ID", typeof(string), id) };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        public DataTable GetList(GridPager pager, string userName, string sDate, string eDate)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT EX.CREATE_TIME,");
            sql.AppendLine("       EX.EX_ID,");
            sql.AppendLine("       EX.EX_HELPLINK,");
            sql.AppendLine("       EX.EX_MESSAGE,");
            sql.AppendLine("       EX.EX_SOURCE,");
            sql.AppendLine("       EX.EX_STACK,");
            sql.AppendLine("       EX.EX_TARGET,");
            sql.AppendLine("       EX.EX_DATA,");
            sql.AppendLine("       EX.EX_NAMESPACE,");
            sql.AppendLine("       EX.EX_CLASS,");
            sql.AppendLine("       EX.EX_METHOD,");
            sql.AppendLine("       EX.EX_TYPE,");
            sql.AppendLine("       EX.EX_DESC,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       EX.LM_TIME,");
            sql.AppendLine("       EX.LM_USER");
            sql.AppendLine("  FROM SYS_EXCEPTION EX");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON EX.CREATE_USER = SU.USER_CODE");
            sql.AppendLine(" WHERE 1=1");

            if (!string.IsNullOrEmpty(userName))
            {
                sql.AppendLine(" AND SU.USER_NAME LIKE $USER_NAME");
                list.Add(new SQLParameter("USER_NAME", typeof(string), StringHelper.GetSqlLike(userName)));
            }
            if (!string.IsNullOrEmpty(sDate))
            {
                sql.AppendLine(" AND EX.CREATE_TIME >= $SDATE ");
                list.Add(new SQLParameter("SDATE", typeof(string), sDate));
            }
            if (!string.IsNullOrEmpty(eDate))
            {
                sql.AppendLine(" AND EX.CREATE_TIME <= $EDATE ");
                list.Add(new SQLParameter("EDATE", typeof(string), eDate));
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
            //pager.totalRows = DB.GetCount(new SQLParamCondition(string.Format("SELECT COUNT(*) COUNT FROM ({0}) TMP", sql), parms));

            //DataSet ds = DB.CustomDataSet(new PagerParamCondition(sql.ToString(), pager.sortOrder, pager.startIndex, pager.endIndex, parms, false));
            return ds.Tables[0];
        }

    }
}












































