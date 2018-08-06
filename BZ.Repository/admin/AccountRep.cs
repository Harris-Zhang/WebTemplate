using BZ.DbHelper.DataProvider; 
using System;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class AccountRep : BaseRep,IDisposable
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataTable Login(string userId, string pwd)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT USER_CODE,USER_NAME,USER_PWD,IS_ABLED,IS_C_PWD,QR_CODE,DEPT_CODE FROM SYS_USER ");
            sql.AppendLine("WHERE USER_CODE=$USER_CODE AND USER_PWD=$USER_PWD");
            SQLParameter[] Parms = {
                                       new SQLParameter("USER_CODE", typeof(string), userId),
                                       new SQLParameter("USER_PWD", typeof(string), pwd)};
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), Parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="qr_code">二维码</param>
        /// <returns></returns>
        public DataTable Login(string qr_code)
        { 
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SU.CREATE_TIME,");
            sql.AppendLine("       SU.USER_CODE,");
            sql.AppendLine("       SU.USER_NAME,");
            sql.AppendLine("       SU.USER_SEX,");
            sql.AppendLine("       SU.USER_PWD,");
            sql.AppendLine("       SU.USER_POST,");
            sql.AppendLine("       SU.USER_EMAIL,");
            sql.AppendLine("       SU.USER_TEL,");
            sql.AppendLine("       SU.USER_DESC,");
            sql.AppendLine("       SU.QR_CODE,");
            sql.AppendLine("       SU.IS_ABLED,");
            sql.AppendLine("       SU.IS_C_PWD,");
            sql.AppendLine("       SU.DEPT_CODE,");
            sql.AppendLine("       SD.DEPT_NAME,");
            sql.AppendLine("       SU.BOSS_ID,");
            sql.AppendLine("       SU.CREATE_USER,");
            sql.AppendLine("       SU.LM_TIME,");
            sql.AppendLine("       SU.LM_USER");
            sql.AppendLine("  FROM SYS_USER SU");
            sql.AppendLine("  LEFT JOIN SYS_DEPT SD");
            sql.AppendLine("    ON SU.DEPT_CODE = SD.DEPT_CODE");
            sql.AppendLine(" WHERE SU.QR_CODE = $QR_CODE");
            SQLParameter[] Parms = {
                                       new SQLParameter("QR_CODE", typeof(string), qr_code)
            };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), Parms));
            return ds.Tables[0];
        }

    }
}
