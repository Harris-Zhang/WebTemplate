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
    public class SysRoleRep : BaseRep 
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysRoleModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO SYS_ROLE");
            sql.AppendLine("   (ROLE_ID, ROLE_NAME, ROLE_DESC, CREATE_USER, LM_USER)");
            sql.AppendLine(" VALUES");
            sql.AppendLine("   ($ROLE_ID, $ROLE_NAME, $ROLE_DESC, $CREATE_USER, $LM_USER)");

            SQLParameter[] parms ={
                                      new SQLParameter("ROLE_ID",typeof(string),model.ROLE_ID),
                                      new SQLParameter("ROLE_NAME",typeof(string),model.ROLE_NAME),
                                      new SQLParameter("ROLE_DESC",typeof(string),model.ROLE_DESC),
                                      new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER) 
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_ROLE WHERE ROLE_ID=$ROLE_ID");
            SQLParameter[] parms = { 
                                        new SQLParameter("ROLE_ID",typeof(string),id)
                                   };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(SysRoleModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_ROLE");
            sql.AppendLine("   SET ROLE_NAME = $ROLE_NAME, ROLE_DESC = $ROLE_DESC, LM_USER = $LM_USER, LM_TIME = GETDATE()");
            sql.AppendLine(" WHERE ROLE_ID = $ROLE_ID");
            SQLParameter[] parms = { 
                                       new SQLParameter("ROLE_NAME",typeof(string),model.ROLE_NAME),
                                       new SQLParameter("ROLE_DESC",typeof(string),model.ROLE_DESC),
                                       new SQLParameter("LM_USER",typeof(string),model.LM_USER),
                                       new SQLParameter("ROLE_ID",typeof(string),model.ROLE_ID)
                                   };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 根据名称获取角色信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public DataTable GetByRoleName(string roleName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ROLE_ID, ROLE_NAME, ROLE_DESC, CREATE_USER, CREATE_TIME");
            sql.AppendLine("  FROM SYS_ROLE");
            sql.AppendLine(" WHERE ROLE_NAME = $ROLE_NAME");
            SQLParameter[] parms = { 
                                        new SQLParameter("ROLE_NAME",typeof(string),roleName)
                                   };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }


        /// <summary>
        /// 根据ID获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ROLE_ID, ROLE_NAME, ROLE_DESC, CREATE_USER, CREATE_TIME");
            sql.AppendLine("  FROM SYS_ROLE");
            sql.AppendLine(" WHERE ROLE_ID = $ROLE_ID");
            SQLParameter[] parms = { 
                                        new SQLParameter("ROLE_ID",typeof(string),id)
                                   };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="pager"></param>
        /// <param name="roleName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public DataTable GetList(GridPager pager, string roleName, string desc)
        {
            List<SQLParameter> list = new List<SQLParameter>();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SR.ROLE_ID,");
            sql.AppendLine("       SR.ROLE_NAME,");
            sql.AppendLine("       SR.ROLE_DESC,");
            sql.AppendLine("       SR.CREATE_TIME,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER");
            sql.AppendLine("  FROM SYS_ROLE SR");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SR.CREATE_USER = SU.USER_CODE");
            sql.AppendLine(" WHERE 1=1 ");

            if (!string.IsNullOrEmpty(roleName))
            {
                sql.AppendLine("    AND SR.ROLE_NAME LIKE $ROLE_NAME");
                list.Add(new SQLParameter("ROLE_NAME", typeof(string), StringHelper.GetSqlLike(roleName)));
            }
            if (!string.IsNullOrEmpty(roleName))
            {
                sql.AppendLine("    AND SR.ROLE_DESC LIKE $ROLE_DESC");
                list.Add(new SQLParameter("ROLE_DESC", typeof(string), StringHelper.GetSqlLike(desc)));
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
        /// 获取角色列表（无当前人员）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetRoleNoUser(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ROLE_ID, ROLE_NAME, ROLE_DESC, CREATE_USER, CREATE_TIME");
            sql.AppendLine("  FROM SYS_ROLE ");
            sql.AppendLine(" WHERE ROLE_ID NOT IN (SELECT ROLE_ID FROM SYS_USER_ROLE WHERE USER_CODE = $USER_CODE)");

            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取角色列表（前期人员角色）
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetRoleYesUser(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ROLE_ID, ROLE_NAME, ROLE_DESC, CREATE_USER, CREATE_TIME");
            sql.AppendLine("  FROM SYS_ROLE ");
            sql.AppendLine(" WHERE ROLE_ID IN (SELECT ROLE_ID FROM SYS_USER_ROLE WHERE USER_CODE = $USER_CODE)");

            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 清理无用的角色权限
        /// </summary>
        public void ClearUnusedRightOpt()
        {
            //清理无用的按钮权限
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_RIGHT_OPT");
            sql.AppendLine(" WHERE MENU_ID + ROLE_ID IN");
            sql.AppendLine("       (SELECT MENU_ID + ROLE_ID");
            sql.AppendLine("          FROM SYS_RIGHT");
            sql.AppendLine("         WHERE ROLE_ID NOT IN (SELECT ROLE_ID FROM SYS_ROLE))");

            DB.CustomExecute(new SQLCondition(sql.ToString()));
            //清理无用的菜单权限
            sql.Length = 0;
            sql.AppendLine("DELETE FROM SYS_RIGHT WHERE ROLE_ID NOT IN (SELECT ROLE_ID FROM SYS_ROLE)");

            DB.CustomExecute(new SQLCondition(sql.ToString()));
        }
        /// <summary>
        /// 获取角色列表（distinct）
        /// </summary>
        /// <returns></returns>
        public DataTable GetListDistinctName()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT DISTINCT ROLE_ID, ROLE_NAME FROM SYS_ROLE ORDER BY ROLE_NAME");
            DataSet ds = DB.CustomDataSet(new SQLCondition(sql.ToString()));
            return ds.Tables[0];
        }
    }
}


















