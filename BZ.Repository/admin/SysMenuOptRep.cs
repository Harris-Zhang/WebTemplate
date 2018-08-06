using BZ.DbHelper.DataProvider;
using BZ.Domain.admin;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysMenuOptRep : BaseRep
    {
        /// <summary>
        /// 获取操作码
        /// </summary>
        /// <param name="menuId">菜单ID</param>
        /// <returns></returns>
        public DataTable GetOptListByMenuId(string menuId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT MO_CODE, MO_NAME, MENU_ID, IS_ABLED, MO_DESC");
            sql.AppendLine("  FROM SYS_MENU_OPT");
            sql.AppendLine(" WHERE MENU_ID = $MENU_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_ID",typeof(string),menuId)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取操作码明细
        /// </summary>
        /// <param name="mo_code">编码</param>
        /// <param name="menu_id">菜单ID</param>
        /// <returns></returns>
        public DataTable GetById(string mo_code, string menu_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT MO_CODE, MO_NAME, MENU_ID, IS_ABLED, MO_DESC");
            sql.AppendLine("  FROM SYS_MENU_OPT");
            sql.AppendLine(" WHERE MO_CODE = $MO_CODE AND MENU_ID = $MENU_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("MO_CODE",typeof(string),mo_code),
                                     new SQLParameter("MENU_ID",typeof(string),menu_id)
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取操作码明细（or）
        /// </summary>
        /// <param name="menuId">菜单ID</param>
        /// <param name="moName">操作码名称</param>
        /// <param name="moCode">操作码编码</param>
        /// <returns></returns>
        public DataTable GetByCodeOrName(string menuId, string moName, string moCode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT MO_CODE, MO_NAME, MENU_ID, IS_ABLED, MO_DESC");
            sql.AppendLine("  FROM SYS_MENU_OPT");
            sql.AppendLine(" WHERE MENU_ID=$MENU_ID");
            sql.AppendLine("   AND (MO_NAME = $MO_NAME");
            sql.AppendLine("    OR MO_CODE = $MO_CODE)");
            SQLParameter[] parms ={
                                     new SQLParameter("MENU_ID",typeof(string),menuId),
                                     new SQLParameter("MO_NAME",typeof(string),moName),
                                     new SQLParameter("MO_CODE",typeof(string),moCode),
                                 };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 添加操作码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysMenuOptModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_MENU_OPT");
            sql.AppendLine("  (MO_CODE, MO_NAME, MENU_ID, IS_ABLED, MO_DESC, CREATE_USER, LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($MO_CODE, $MO_NAME, $MENU_ID, $IS_ABLED, $MO_DESC, $CREATE_USER, $LM_USER)");
            SQLParameter[] parms ={
                                     new SQLParameter("MO_CODE",typeof(string),model.MO_CODE),
                                     new SQLParameter("MO_NAME",typeof(string),model.MO_NAME),
                                     new SQLParameter("MENU_ID",typeof(string),model.MENU_ID),
                                     new SQLParameter("IS_ABLED",typeof(int),model.IS_ABLED),
                                     new SQLParameter("MO_DESC",typeof(string),model.MO_DESC),
                                     new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                     new SQLParameter("LM_USER",typeof(string),model.LM_USER),
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;

        }
        /// <summary>
        /// 删除操作码
        /// </summary>
        /// <param name="moId">编码</param>
        /// <param name="menu_id">菜单ID</param>
        /// <returns></returns>
        public int Delete(string moId, string menu_id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM SYS_MENU_OPT WHERE MO_CODE = $MO_CODE AND MENU_ID = $MENU_ID");
            SQLParameter[] parms ={
                                     new SQLParameter("MO_CODE",typeof(string),moId),
                                     new SQLParameter("MENU_ID",typeof(string),menu_id),
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;

        }
    }
}




