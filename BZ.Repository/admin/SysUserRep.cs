using BZ.Common;
using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Repository.admin
{
    public class SysUserRep : BaseRep 
    {
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPwd"></param>
        /// <param name="isQR"></param>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        public int EditPassword(string userId, string newPwd, bool isQR, string QRCode)
        {
            StringBuilder sql = new StringBuilder();
            int result = -1;
            if (isQR)
            {
                sql.AppendLine("UPDATE SYS_USER SET USER_PWD = $USER_PWD,QR_CODE=$QR_CODE,IS_C_PWD=1 WHERE USER_CODE = $USER_CODE");
                SQLParameter[] paras ={
                                     new SQLParameter("USER_PWD",typeof(string), newPwd),
                                     new SQLParameter("QR_CODE",typeof(string), QRCode),
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
                result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), paras));
            }
            else
            {
                sql.AppendLine("UPDATE SYS_USER SET USER_PWD = $USER_PWD,IS_C_PWD=1 WHERE USER_CODE = $USER_CODE");
                SQLParameter[] paras ={
                                     new SQLParameter("USER_PWD",typeof(string), newPwd),
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
                result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), paras));
            }
            result = result > 0 ? 1 : 0;
            return result;

        }

        /// <summary>
        /// 获取用户明细
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetById(string userId)
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
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE ");
 
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataTable Login(string userId, string pwd)
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
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE AND SU.USER_PWD = $USER_PWD");
            SQLParameter[] parms = {
                                       new SQLParameter("USER_CODE", typeof(string), userId),
                                       new SQLParameter("USER_PWD", typeof(string), pwd)};
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
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
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable GetList(GridPager pager, string userId, string userName, string roleId)
        {
            List<SQLParameter> list = new List<SQLParameter>();
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
            sql.AppendLine(" WHERE 1 = 1");

            if (!string.IsNullOrEmpty(userId))
            {
                sql.AppendLine("   AND SU.USER_CODE = $USER_CODE");
                list.Add(new SQLParameter("USER_CODE", typeof(string), userId));
            }
            if (!string.IsNullOrEmpty(userName))
            {
                sql.AppendLine("   AND SU.USER_NAME LIKE $USER_NAME");
                list.Add(new SQLParameter("USER_NAME", typeof(string), StringHelper.GetSqlLike(userName)));
            }
            //if (!string.IsNullOrEmpty(roleId))
            //{
            //    sql.AppendLine("   AND SUR.ROLEID = $ROLEID");
            //    list.Add(new SQLParameter("ROLEID", typeof(string), roleId.Trim()));
            //}
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
        /// 获取用户（无角色）
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="roleId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable GetUserNoRole(GridPager pager, string roleId, string user)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT USER_CODE, USER_NAME, USER_DESC");
            sql.AppendLine("  FROM SYS_USER ");
            sql.AppendLine(" WHERE IS_ABLED = 1 ");
            sql.AppendLine("   AND USER_CODE NOT IN (SELECT USER_CODE FROM SYS_USER_ROLE WHERE ROLE_ID = $ROLE_ID)");
            list.Add(new SQLParameter("ROLE_ID", typeof(string), roleId));
            if (!string.IsNullOrEmpty(user))
            {
                sql.AppendLine(" AND (USER_CODE LIKE $USER_CODE OR USER_NAME LIKE $USER_NAME)");
                list.Add(new SQLParameter("USER_CODE", typeof(string), StringHelper.GetSqlLike(user)));
                list.Add(new SQLParameter("USER_NAME", typeof(string), StringHelper.GetSqlLike(user)));
            }

            SQLParameter[] parms = list.ToArray(); ;
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
        /// 获取用户（有角色）
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="roleId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable GetUserYesRole(GridPager pager, string roleId, string user)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT USER_CODE, USER_NAME, USER_DESC");
            sql.AppendLine("  FROM SYS_USER ");
            sql.AppendLine(" WHERE IS_ABLED = 1 ");
            sql.AppendLine("   AND USER_CODE IN (SELECT USER_CODE FROM SYS_USER_ROLE WHERE ROLE_ID = $ROLE_ID)");
            list.Add(new SQLParameter("ROLE_ID", typeof(string), roleId));
            if (!string.IsNullOrEmpty(user))
            {
                sql.AppendLine(" AND (USER_CODE LIKE $USER_CODE OR USER_NAME LIKE $USER_NAME)");
                list.Add(new SQLParameter("USER_CODE", typeof(string), StringHelper.GetSqlLike(user)));
                list.Add(new SQLParameter("USER_NAME", typeof(string), StringHelper.GetSqlLike(user)));
            }

            SQLParameter[] parms = list.ToArray(); ;
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
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysUserModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_USER");
            sql.AppendLine("  (USER_CODE,");
            sql.AppendLine("   USER_NAME,");
            sql.AppendLine("   USER_SEX,");
            sql.AppendLine("   USER_PWD,");
            sql.AppendLine("   USER_POST,");
            sql.AppendLine("   USER_EMAIL,");
            sql.AppendLine("   USER_TEL,");
            sql.AppendLine("   USER_DESC,");
            sql.AppendLine("   QR_CODE,");
            sql.AppendLine("   IS_ABLED,");
            sql.AppendLine("   IS_C_PWD,");
            sql.AppendLine("   DEPT_CODE,");
            sql.AppendLine("   BOSS_ID,");
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($USER_CODE,");
            sql.AppendLine("   $USER_NAME,");
            sql.AppendLine("   $USER_SEX,");
            sql.AppendLine("   $USER_PWD,");
            sql.AppendLine("   $USER_POST,");
            sql.AppendLine("   $USER_EMAIL,");
            sql.AppendLine("   $USER_TEL,");
            sql.AppendLine("   $USER_DESC,");
            sql.AppendLine("   $QR_CODE,");
            sql.AppendLine("   $IS_ABLED,");
            sql.AppendLine("   $IS_C_PWD,");
            sql.AppendLine("   $DEPT_CODE,");
            sql.AppendLine("   $BOSS_ID,");
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)"); 
            SQLParameter[] parms ={
                                      new SQLParameter("USER_CODE",typeof(string),model.USER_CODE),
                                      new SQLParameter("USER_NAME",typeof(string),model.USER_NAME),
                                      new SQLParameter("USER_SEX",typeof(int),model.USER_SEX),
                                      new SQLParameter("USER_PWD",typeof(string),model.USER_PWD),
                                      new SQLParameter("USER_POST",typeof(string),model.USER_POST),
                                      new SQLParameter("USER_EMAIL",typeof(string),model.USER_EMAIL),
                                      new SQLParameter("USER_TEL",typeof(string),model.USER_TEL),
                                      new SQLParameter("USER_DESC",typeof(string),model.USER_DESC),
                                      new SQLParameter("QR_CODE",typeof(string),model.QR_CODE),
                                      new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                      new SQLParameter("IS_C_PWD",typeof(int),model.IS_C_PWD),
                                      new SQLParameter("DEPT_CODE",typeof(string),model.DEPT_CODE),
                                      new SQLParameter("BOSS_ID",typeof(string),model.BOSS_ID),
                                      new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER) 
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        } 
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(SysUserModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_USER");
            sql.AppendLine("   SET USER_NAME  = $USER_NAME,");
            sql.AppendLine("       USER_SEX   = $USER_SEX,");
            sql.AppendLine("       USER_PWD   = $USER_PWD,");
            sql.AppendLine("       USER_POST  = $USER_POST,");
            sql.AppendLine("       USER_EMAIL = $USER_EMAIL,");
            sql.AppendLine("       USER_TEL   = $USER_TEL,");
            sql.AppendLine("       USER_DESC  = $USER_DESC,");
            sql.AppendLine("       QR_CODE    = $QR_CODE,");
            sql.AppendLine("       IS_ABLED   = $IS_ABLED,");
            sql.AppendLine("       IS_C_PWD   = $IS_C_PWD,");
            sql.AppendLine("       DEPT_CODE  = $DEPT_CODE,");
            sql.AppendLine("       BOSS_ID    = $BOSS_ID,");
            sql.AppendLine("       LM_TIME    = GETDATE(),");
            sql.AppendLine("       LM_USER    = $LM_USER");
            sql.AppendLine(" WHERE USER_CODE = $USER_CODE");
             
            SQLParameter[] parms ={  
                                      new SQLParameter("USER_NAME",typeof(string),model.USER_NAME),
                                      new SQLParameter("USER_SEX",typeof(int),model.USER_SEX),
                                      new SQLParameter("USER_PWD",typeof(string),model.USER_PWD),
                                      new SQLParameter("USER_POST",typeof(string),model.USER_POST),
                                      new SQLParameter("USER_EMAIL",typeof(string),model.USER_EMAIL),
                                      new SQLParameter("USER_TEL",typeof(string),model.USER_TEL),
                                      new SQLParameter("USER_DESC",typeof(string),model.USER_DESC),
                                      new SQLParameter("QR_CODE",typeof(string),model.QR_CODE),
                                      new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                      new SQLParameter("IS_C_PWD",typeof(int),model.IS_C_PWD),
                                      new SQLParameter("DEPT_CODE",typeof(string),model.DEPT_CODE),
                                      new SQLParameter("BOSS_ID",typeof(string),model.BOSS_ID), 
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER),
                                      new SQLParameter("USER_CODE",typeof(string),model.USER_CODE),
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

         /// <summary>
         /// 删除
         /// </summary>
         /// <param name="userId"></param>
         /// <returns></returns>
        public int Delete(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_USER WHERE USER_CODE = $USER_CODE");
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 删除用户与角色的对应关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteSysUserRole(string userId, string roleId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM SYS_USER_ROLE WHERE USER_CODE = $USER_CODE AND ROLE_ID = $ROLE_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId),
                                     new SQLParameter("ROLE_ID",typeof(string),roleId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

        /// <summary>
        /// 删除用户与角色的对应关系
        /// </summary>
        /// <param name="userId">用户ID</param>
        public void DeleteSysUserRoleByUserId(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_USER_ROLE WHERE USER_CODE = $USER_CODE");
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            DB.CustomExecute(new SQLParamCondition(sql.ToString(), parms));
        }
        
        /// <summary>
        /// 删除用户与角色的对应关系
        /// </summary>
        /// <param name="roleId">角色ID</param>
        public void DeleteSysUserRoleByRoleId(string roleId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_USER_ROLE WHERE ROLE_ID = $ROLE_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("ROLE_ID",typeof(string),roleId)
                                 };
            DB.CustomExecute(new SQLParamCondition(sql.ToString(), parms));
        }
        /// <summary>
        /// 分配用户角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AllotSysUserRole(SysUserRoleModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_USER_ROLE");
            sql.AppendLine("  (USER_CODE, ROLE_ID, CREATE_USER, LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($USER_CODE, $ROLE_ID, $CREATE_USER, $LM_USER)");
 
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),model.USER_CODE),
                                     new SQLParameter("ROLE_ID",typeof(string),model.ROLE_ID),
                                     new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                     new SQLParameter("LM_USER",typeof(string),model.LM_USER)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 更新用户部门
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public int UpdateUserDept(string userId, string deptId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_USER");
            sql.AppendLine("   SET DEPT_CODE    = $DEPT_CODE");
            sql.AppendLine(" WHERE USER_CODE = $USER_CODE");
            SQLParameter[] parms ={
                                     new SQLParameter("DEPT_CODE",typeof(string),deptId),
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 根据部门获取用户列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="dept_code"></param>
        /// <returns></returns>
        public DataTable GetByDeptCode(GridPager pager, string dept_code)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SU.USER_CODE,");
            sql.AppendLine("       SU.USER_NAME,");
            sql.AppendLine("       SU.IS_ABLED");
            sql.AppendLine("  FROM SYS_USER SU");
            sql.AppendLine(" WHERE SU.DEPT_CODE = $DEPT_CODE");
            SQLParameter[] parms ={
                                     new SQLParameter("DEPT_CODE",typeof(string),dept_code)
                                 };

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
        /// 获取人员信息
        /// </summary>
        /// <param name="user_code">人员账号("123','123")</param>
        /// <returns></returns>
        public DataTable GetUserByIds(string user_code)
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
            sql.AppendFormat(" WHERE SU.USER_CODE IN ('{0}')",user_code);
            DataSet ds = DB.CustomDataSet(new SQLCondition(sql.ToString()));
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取用户信息(or)
        /// </summary>
        /// <param name="user_code">工号</param>
        /// <param name="user_name">姓名</param>
        /// <returns></returns>
        public DataTable GetUserByIdOrName(string user_code,string user_name)
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
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE");
            sql.AppendLine("    OR SU.USER_NAME = $USER_NAME");
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),user_code),
                                     new SQLParameter("USER_NAME",typeof(string),user_name)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

    }
}





















































