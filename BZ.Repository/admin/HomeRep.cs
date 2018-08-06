using BZ.DbHelper.DataProvider;
using BZ.DbHelper.Interface;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class HomeRep:BaseRep
    {
        /// <summary>
        /// 获取当前用户菜单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetMenuByPersonId(string userid)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("       SM.MENU_NAME text,");
            sql.AppendLine("       SM.MENU_ID id,");
            sql.AppendLine("       SM.MENU_ICON icon,");
            sql.AppendLine("       SU.USER_CODE,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       'iframe-tab' targetType,");
            sql.AppendLine("       SM.MENU_PATH url");
            sql.AppendLine("  FROM SYS_USER SU");
            sql.AppendLine("  LEFT JOIN SYS_USER_ROLE SUR");
            sql.AppendLine("    ON SU.USER_CODE = SUR.USER_CODE");
            sql.AppendLine("  LEFT JOIN SYS_ROLE SR");
            sql.AppendLine("    ON SUR.ROLE_ID = SR.ROLE_ID");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT SRT");
            sql.AppendLine("    ON SR.ROLE_ID = SRT.ROLE_ID");
            sql.AppendLine("   AND SRT.RIGHT_FLAG = 1");
            sql.AppendLine("  LEFT JOIN SYS_MENU SM");
            sql.AppendLine("    ON SRT.MENU_ID = SM.MENU_ID");
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE");
            sql.AppendLine("   AND SM.MENU_TYPE = 'PC'");
            sql.AppendLine("   AND SM.MENU_ID <> '0'");
            sql.AppendLine("   AND SM.IS_ABLED = 1 ");
            sql.AppendLine(" ORDER BY SM.PARENT_ID, SM.MENU_SORT");
            SQLParameter[] Parms = {
                                       new SQLParameter("USER_CODE", typeof(string), userid)};
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), Parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable GetMenuByUserId(string userId, string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("       SM.MENU_NAME,");
            sql.AppendLine("       SM.MENU_ID,");
            sql.AppendLine("       SM.MENU_ICON,");
            sql.AppendLine("       SU.USER_CODE,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       SM.IS_END,");
            sql.AppendLine("       SM.MENU_PATH");
            sql.AppendLine("  FROM SYS_USER SU");
            sql.AppendLine("  LEFT JOIN SYS_USER_ROLE SUR");
            sql.AppendLine("    ON SU.USER_CODE = SUR.USER_CODE");
            sql.AppendLine("  LEFT JOIN SYS_ROLE SR");
            sql.AppendLine("    ON SUR.ROLE_ID = SR.ROLE_ID");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT SRT");
            sql.AppendLine("    ON SR.ROLE_ID = SRT.ROLE_ID");
            sql.AppendLine("   AND SRT.RIGHT_FLAG = 1");
            sql.AppendLine("  LEFT JOIN SYS_MENU SM");
            sql.AppendLine("    ON SRT.MENU_ID = SM.MENU_ID");
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE");
            sql.AppendLine("   AND SM.MENU_ID <> '0'");
            sql.AppendLine("   AND SM.PARENT_ID = $PARENT_ID");
            sql.AppendLine("   AND SM.IS_ABLED = 1 ");
            sql.AppendLine(" ORDER BY SM.PARENT_ID, SM.MENU_SORT");
            SQLParameter[] Parms = {
                                       new SQLParameter("USER_CODE", typeof(string), userId),
                                       new SQLParameter("PARENT_ID", typeof(string), parentId)
                                   };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), Parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取移动端 用户菜单列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetMobileMenuByUserId(string userid)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("       SM.MENU_NAME text,");
            sql.AppendLine("       SM.MENU_ID id,");
            sql.AppendLine("       SM.MENU_ICON icon,");
            sql.AppendLine("       SU.USER_CODE,");
            sql.AppendLine("       SM.PARENT_ID,");
            sql.AppendLine("       SM.MENU_SORT,");
            sql.AppendLine("       'iframe-tab' targetType,");
            sql.AppendLine("       SM.MENU_PATH url");
            sql.AppendLine("  FROM SYS_USER SU");
            sql.AppendLine("  LEFT JOIN SYS_USER_ROLE SUR");
            sql.AppendLine("    ON SU.USER_CODE = SUR.USER_CODE");
            sql.AppendLine("  LEFT JOIN SYS_ROLE SR");
            sql.AppendLine("    ON SUR.ROLE_ID = SR.ROLE_ID");
            sql.AppendLine("  LEFT JOIN SYS_RIGHT SRT");
            sql.AppendLine("    ON SR.ROLE_ID = SRT.ROLE_ID");
            sql.AppendLine("   AND SRT.RIGHT_FLAG = 1");
            sql.AppendLine("  LEFT JOIN SYS_MENU SM");
            sql.AppendLine("    ON SRT.MENU_ID = SM.MENU_ID");
            sql.AppendLine(" WHERE SU.USER_CODE = $USER_CODE");
            sql.AppendLine("   AND SM.MENU_TYPE = 'MP'");
            sql.AppendLine("   AND SM.MENU_ID <> '0'");
            sql.AppendLine("   AND SM.IS_ABLED = 1 ");
            sql.AppendLine(" ORDER BY SM.PARENT_ID, SM.MENU_SORT");
            SQLParameter[] Parms = {
                                       new SQLParameter("USER_CODE", typeof(string), userid)};
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), Parms));
            return ds.Tables[0];
        }
    }
}




















