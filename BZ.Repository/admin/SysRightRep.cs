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
    public class SysRightRep : BaseRep 
    {

        /// <summary>
        /// 分配角色
        /// </summary>
        public void InsertSysRight(string create_user, string lm_user)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_RIGHT");
            sql.AppendLine("  (MENU_ID, ROLE_ID, RIGHT_FLAG, CREATE_USER, LM_USER)");
            sql.AppendLine("  SELECT DISTINCT SM.MENU_ID, SR.ROLE_ID, 0, $CREATE_USER, $LM_USER");
            sql.AppendLine("    FROM SYS_MENU SM, SYS_ROLE SR");
            sql.AppendLine("   WHERE SM.MENU_ID + SR.ROLE_ID NOT IN");
            sql.AppendLine("         (SELECT MENU_ID + ROLE_ID FROM SYS_RIGHT) "); 
            SQLParameter[] parms ={
                                     new SQLParameter("CREATE_USER",typeof(string),create_user),
                                     new SQLParameter("LM_USER",typeof(string),lm_user)
                                 };
            int result= DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
        }
        /// <summary>
        /// 清理无用的项
        /// </summary>
        public void ClearUnusedRightOpt()
        {
            StringBuilder sql = new StringBuilder();
            //删除无用的操作码权限
            sql.AppendLine("DELETE FROM SYS_RIGHT_OPT");
            sql.AppendLine(" WHERE MENU_ID + ROLE_ID + MO_CODE NOT IN");
            sql.AppendLine("       (SELECT SMO.MENU_ID + SR.ROLE_ID + SMO.MO_CODE");
            sql.AppendLine("          FROM SYS_RIGHT SR, SYS_MENU_OPT SMO");
            sql.AppendLine("         WHERE SR.MENU_ID = SMO.MENU_ID)");  
            DB.CustomExecute(new SQLCondition(sql.ToString()));
            //删除无用的菜单权限
            sql.Length = 0;
            sql.AppendLine(" DELETE FROM SYS_RIGHT");
            sql.AppendLine(" WHERE MENU_ID NOT IN ( SELECT MENU_ID FROM SYS_MENU )");

            DB.CustomExecute(new SQLCondition(sql.ToString()));
            //删除无用的操作码
            sql.Length = 0;
            sql.AppendLine("DELETE FROM SYS_MENU_OPT");
            sql.AppendLine(" WHERE  MENU_ID NOT IN ( SELECT MENU_ID  FROM  SYS_MENU )");
            DB.CustomExecute(new SQLCondition(sql.ToString()));
        }

        /// <summary>
        /// 获取用户操作码权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="url">Action地址</param>
        /// <returns></returns>
        public DataTable GetPermission(string userId, string url)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT DISTINCT MO_CODE KEYCODE, IS_ABLED ISVALID");
            sql.AppendLine("  FROM SYS_RIGHT_OPT SRO");
            sql.AppendLine(" WHERE SRO.MENU_ID + SRO.ROLE_ID IN");
            sql.AppendLine("       (SELECT SR.MENU_ID + SR.ROLE_ID");
            sql.AppendLine("          FROM SYS_RIGHT SR, SYS_MENU SM");
            sql.AppendLine("         WHERE SR.ROLE_ID IN (SELECT SUR.ROLE_ID");
            sql.AppendLine("                                FROM SYS_USER_ROLE SUR");
            sql.AppendLine("                               WHERE SUR.USER_CODE = $USER_ID)");
            sql.AppendLine("           AND SR.MENU_ID = SM.MENU_ID");
            sql.AppendLine("           AND SM.MENU_PATH = $URL)");
            sql.AppendLine("   AND SRO.IS_ABLED = 1");  
            SQLParameter[] parms ={
                                     new SQLParameter("USER_ID",typeof(string),userId),
                                     new SQLParameter("URL",typeof(string),url)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        } 
        /// <summary>
        /// 更新权限按钮标识
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRightOpt(SysRightOptModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_RIGHT_OPT SET IS_ABLED = $IS_ABLED WHERE MENU_ID = $MENU_ID AND ROLE_ID=$ROLE_ID AND MO_CODE=$MO_CODE");
            SQLParameter[] parms ={
                                     new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                     new SQLParameter("MENU_ID",typeof(string),model.MENU_ID),
                                     new SQLParameter("ROLE_ID",typeof(string),model.ROLE_ID),
                                     new SQLParameter("MO_CODE",typeof(string),model.MO_CODE)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 更新权限按钮标识
        /// </summary>
        /// <param name="menu_id"></param>
        /// <param name="role_id"></param>
        /// <returns></returns>
        public int UpdateRightOptByMenuIdAndRoleId(string menu_id, string role_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_RIGHT_OPT SET IS_ABLED = 0 WHERE MENU_ID = $MENU_ID AND ROLE_ID=$ROLE_ID");
            SQLParameter[] parms ={ 
                                     new SQLParameter("MENU_ID",typeof(string),menu_id),
                                     new SQLParameter("ROLE_ID",typeof(string),role_id)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 添加权限按钮标识
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertRightOpt(SysRightOptModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_RIGHT_OPT");
            sql.AppendLine("  (MENU_ID, ROLE_ID, MO_CODE, IS_ABLED, CREATE_USER, LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($MENU_ID, $ROLE_ID, $MO_CODE, $IS_ABLED, $CREATE_USER, $LM_USER)");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_ID",typeof(string),model.MENU_ID),
                                     new SQLParameter("ROLE_ID",typeof(string),model.ROLE_ID),
                                     new SQLParameter("MO_CODE",typeof(string),model.MO_CODE),
                                     new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                     new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                     new SQLParameter("LM_USER",typeof(string),model.LM_USER)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;

        }
  
        /// <summary>
        /// 更新权限标识
        /// </summary>
        /// <param name="rightFlag"></param>
        /// <param name="menuId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int UpdateRightFlagByMenuIdAndRoleId(int rightFlag, string menuId, string roleId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_RIGHT");
            sql.AppendLine("   SET RIGHT_FLAG = $RIGHT_FLAG");
            sql.AppendLine(" WHERE MENU_ID = $MENU_ID");
            sql.AppendLine("   AND ROLE_ID = $ROLE_ID");

            SQLParameter[] parms ={
                                     new SQLParameter("RIGHT_FLAG",typeof(int),rightFlag),
                                     new SQLParameter("MENU_ID",typeof(string),menuId),
                                     new SQLParameter("ROLE_ID",typeof(string),roleId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 获取父级菜单权限
        /// </summary>
        /// <param name="menuParentId">菜单父级ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public DataTable GetRightByMenuParentIdAndRoleId(string menuParentId, string roleId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT MENU_ID, ROLE_ID, RIGHT_FLAG");
            sql.AppendLine("  FROM SYS_RIGHT");
            sql.AppendLine(" WHERE MENU_ID IN (SELECT MENU_ID FROM SYS_MENU WHERE PARENT_ID = $PARENT_ID)");
            sql.AppendLine("   AND ROLE_ID = $ROLE_ID");
            sql.AppendLine("   AND RIGHT_FLAG = 1");

            SQLParameter[] parms ={
                                     new SQLParameter("PARENT_ID",typeof(string),menuParentId),
                                     new SQLParameter("ROLE_ID",typeof(string),roleId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取菜单 操作码权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable GetRightByMenuIdAndRoleId(string menuId, string roleId)
        {
            StringBuilder sql = new StringBuilder();
 
            sql.AppendLine("SELECT SMO.MENU_ID,");
            sql.AppendLine("       SRO.ROLE_ID,");
            sql.AppendLine("       SMO.MO_CODE,");
            sql.AppendLine("       SMO.MO_NAME,");
            sql.AppendLine("       ISNULL(SRO.IS_ABLED, 0) IS_ABLED");
            sql.AppendLine("  FROM SYS_MENU_OPT SMO");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT_OPT SRO");
            sql.AppendLine("    ON SMO.MENU_ID = SRO.MENU_ID");
            sql.AppendLine("   AND SMO.MO_CODE = SRO.MO_CODE");
            sql.AppendLine("   AND SRO.ROLE_ID = $ROLE_ID");
            sql.AppendLine(" WHERE SMO.MENU_ID = $MENU_ID");
             
            SQLParameter[] parms = {
                new SQLParameter("ROLE_ID",typeof(string),roleId),
                new SQLParameter("MENU_ID",typeof(string),menuId)
            };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }


    }
} 