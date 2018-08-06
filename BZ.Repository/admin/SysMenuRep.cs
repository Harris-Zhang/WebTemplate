using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysMenuRep : BaseRep 
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysMenuModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_MENU");
            sql.AppendLine("  (MENU_ID,");
            sql.AppendLine("   MENU_CODE,");
            sql.AppendLine("   MENU_NAME,");
            sql.AppendLine("   MENU_PATH,");
            sql.AppendLine("   MENU_ICON,");
            sql.AppendLine("   MENU_SORT,");
            sql.AppendLine("   MENU_DESC,");
            sql.AppendLine("   MENU_TYPE,");
            sql.AppendLine("   IS_ABLED,");
            sql.AppendLine("   IS_END,");
            sql.AppendLine("   PARENT_ID,");
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($MENU_ID,");
            sql.AppendLine("   $MENU_CODE,");
            sql.AppendLine("   $MENU_NAME,");
            sql.AppendLine("   $MENU_PATH,");
            sql.AppendLine("   $MENU_ICON,");
            sql.AppendLine("   $MENU_SORT,");
            sql.AppendLine("   $MENU_DESC,");
            sql.AppendLine("   $MENU_TYPE,");
            sql.AppendLine("   $IS_ABLED,");
            sql.AppendLine("   $IS_END,");
            sql.AppendLine("   $PARENT_ID,");
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)"); 
                   
            SQLParameter[] parms = {  
                                       new SQLParameter("MENU_ID",typeof(string),model.MENU_ID),
                                       new SQLParameter("MENU_CODE",typeof(string),model.MENU_CODE),
                                       new SQLParameter("MENU_NAME",typeof(string),model.MENU_NAME),
                                       new SQLParameter("MENU_PATH",typeof(string),model.MENU_PATH),
                                       new SQLParameter("MENU_ICON",typeof(string),model.MENU_ICON),
                                       new SQLParameter("MENU_SORT",typeof(string),model.MENU_SORT),
                                       new SQLParameter("MENU_DESC",typeof(string),model.MENU_DESC),
                                       new SQLParameter("MENU_TYPE",typeof(string),model.MENU_TYPE),
                                       new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                       new SQLParameter("IS_END",typeof(int),model.IS_END),
                                       new SQLParameter("PARENT_ID",typeof(string),model.PARENT_ID),
                                       new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER), 
                                       new SQLParameter("LM_USER",typeof(string),model.LM_USER) 
                                   };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_MENU WHERE MENU_ID = $MENU_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_ID",typeof(string),id)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public int DeleteByParentId(string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_MENU WHERE PARENT_ID = $PARENT_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("PARENT_ID",typeof(string),parentId)
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(SysMenuModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_MENU");
            sql.AppendLine("   SET MENU_CODE  = $MENU_CODE,");
            sql.AppendLine("       MENU_NAME  = $MENU_NAME,");
            sql.AppendLine("       MENU_PATH  = $MENU_PATH,");
            sql.AppendLine("       MENU_ICON  = $MENU_ICON,");
            sql.AppendLine("       MENU_SORT  = $MENU_SORT,");
            sql.AppendLine("       MENU_DESC  = $MENU_DESC,");
            sql.AppendLine("       MENU_TYPE  = $MENU_TYPE,");
            sql.AppendLine("       IS_ABLED   = $IS_ABLED,");
            sql.AppendLine("       IS_END     = $IS_END,");
            sql.AppendLine("       PARENT_ID  = $PARENT_ID,");
            sql.AppendLine("       LM_TIME    = GETDATE(),");
            sql.AppendLine("       LM_USER    = $LM_USER");
            sql.AppendLine(" WHERE MENU_ID = $MENU_ID");
            SQLParameter[] parms = {  
                                       new SQLParameter("MENU_CODE",typeof(string),model.MENU_CODE),
                                       new SQLParameter("MENU_NAME",typeof(string),model.MENU_NAME),
                                       new SQLParameter("MENU_PATH",typeof(string),model.MENU_PATH),
                                       new SQLParameter("MENU_ICON",typeof(string),model.MENU_ICON),
                                       new SQLParameter("MENU_SORT",typeof(string),model.MENU_SORT),
                                       new SQLParameter("MENU_DESC",typeof(string),model.MENU_DESC),
                                       new SQLParameter("MENU_TYPE",typeof(string),model.MENU_TYPE),
                                       new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                       new SQLParameter("IS_END",typeof(int),model.IS_END),
                                       new SQLParameter("PARENT_ID",typeof(string),model.PARENT_ID),
                                       new SQLParameter("LM_USER",typeof(string),model.LM_USER),
                                       new SQLParameter("MENU_ID",typeof(string),model.MENU_ID),
                                   };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        } 
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public DataTable GetList(string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SM.CREATE_TIME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_CODE,");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_PATH,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.MENU_DESC,");
            sql.AppendLine("       SM.MENU_TYPE,");
            sql.AppendLine("       SM.IS_ABLED,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       SM.LM_TIME,");
            sql.AppendLine("       SM.LM_USER");
            sql.AppendLine("  FROM SYS_MENU SM");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SM.CREATE_USER = SU.USER_CODE");
            sql.AppendLine(" WHERE SM.PARENT_ID = $PARENT_ID");
            sql.AppendLine(" ORDER BY SM.MENU_SORT"); 
            SQLParameter[] parms ={
                                     new SQLParameter("PARENT_ID",typeof(string),parentId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        } 
        /// <summary>
        /// 获取菜单（ID、NAME、parent_id）
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public DataTable GetParentList(string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT MENU_ID,MENU_NAME,PARENT_ID ");
            sql.AppendLine("  FROM SYS_MENU ");
            sql.AppendLine(" WHERE PARENT_ID = $PARENT_ID");
            sql.AppendLine("   AND IS_END = 0");
            //sql.AppendLine("   AND MENU_ID <> '0'");
            SQLParameter[] parms ={
                                     new SQLParameter("PARENT_ID",typeof(string),parentId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        } 
        /// <summary>
        /// 获取菜单明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetById(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SM.CREATE_TIME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_CODE,");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_PATH,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.MENU_DESC,");
            sql.AppendLine("       SM.MENU_TYPE,");
            sql.AppendLine("       SM.IS_ABLED,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       SM.LM_TIME,");
            sql.AppendLine("       SM.LM_USER");
            sql.AppendLine("  FROM SYS_MENU SM");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SM.CREATE_USER = SU.USER_CODE");
            sql.AppendLine(" WHERE SM.MENU_ID = $MENU_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_ID",typeof(string),id)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        } 
        /// <summary>
        /// 根据角色获取菜单
        /// </summary>
        /// <param name="roleId">角色</param>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public DataTable GetListByRoleId(string roleId, string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SM.CREATE_TIME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_CODE,");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_PATH,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.MENU_DESC,");
            sql.AppendLine("       SM.MENU_TYPE,");
            sql.AppendLine("       SM.IS_ABLED,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       SM.LM_TIME,");
            sql.AppendLine("       SM.LM_USER");
            sql.AppendLine("  FROM SYS_MENU SM");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SM.CREATE_USER = SU.USER_CODE");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT SR");
            sql.AppendLine("    ON SM.MENU_ID = SR.MENU_ID");
            sql.AppendLine(" WHERE SR.RIGHT_FLAG = 1");
            sql.AppendLine("   AND SR.ROLE_ID = $ROLE_ID");
            sql.AppendLine("   AND SM.PARENT_ID = $PARENT_ID");
            sql.AppendLine(" ORDER BY SM.MENU_SORT");
            SQLParameter[] parms ={
                                     new SQLParameter("ROLE_ID",typeof(string),roleId),
                                     new SQLParameter("PARENT_ID",typeof(string),parentId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据用户获取菜单
        /// </summary>
        /// <param name="userId">用户账号</param>
        /// <param name="parentId">父级ID</param>
        /// <returns></returns>
        public DataTable GetListByUserId(string userId, string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SM.CREATE_TIME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_CODE,");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_PATH,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.MENU_DESC,");
            sql.AppendLine("       SM.MENU_TYPE,");
            sql.AppendLine("       SM.IS_ABLED,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SU.USER_NAME CREATE_USER,");
            sql.AppendLine("       SM.LM_TIME,");
            sql.AppendLine("       SM.LM_USER");
            sql.AppendLine("  FROM SYS_MENU SM");
            sql.AppendLine("  LEFT JOIN SYS_USER SU");
            sql.AppendLine("    ON SM.CREATE_USER = SU.USER_CODE");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT SR");
            sql.AppendLine("    ON SM.MENU_ID = SR.MENU_ID");
            sql.AppendLine(" WHERE SR.RIGHT_FLAG = 1");
            sql.AppendLine("  AND SU.USER_CODE = $USER_CODE");
            sql.AppendLine("  AND SM.PARENT_ID = $PARENT_ID");
            sql.AppendLine(" ORDER BY SM.MENU_SORT");
            SQLParameter[] parms ={
                                     new SQLParameter("USER_CODE",typeof(string),userId),
                                     new SQLParameter("PARENT_ID",typeof(string),parentId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据code Or name 获取菜单
        /// </summary>
        /// <param name="menu_code"></param>
        /// <param name="menu_name"></param>
        /// <returns></returns>
        public DataTable GetByCodeOrName(string menu_code,string menu_name)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SM.CREATE_TIME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_CODE,");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_PATH,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.MENU_DESC,");
            sql.AppendLine("       SM.MENU_TYPE,");
            sql.AppendLine("       SM.IS_ABLED,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SM.CREATE_USER,");
            sql.AppendLine("       SM.LM_TIME,");
            sql.AppendLine("       SM.LM_USER");
            sql.AppendLine("  FROM SYS_MENU SM"); 
            sql.AppendLine(" WHERE SM.MENU_CODE = $MENU_CODE");
            sql.AppendLine("    OR SM.MENU_NAME = $MENU_NAME");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_CODE",typeof(string),menu_code),
                                     new SQLParameter("MENU_NAME",typeof(string),menu_name)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
    }
}

































