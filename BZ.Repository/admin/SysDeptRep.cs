using BZ.DbHelper.DataProvider;
using BZ.Domain.admin; 
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class SysDeptRep : BaseRep 
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(SysDeptModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO SYS_DEPT");
            sql.AppendLine("  (DEPT_CODE,");
            sql.AppendLine("   DEPT_NAME,");
            sql.AppendLine("   PARENT_CODE,");
            sql.AppendLine("   SITE_CODE,");
            sql.AppendLine("   SITE_NAME,");
            sql.AppendLine("   DEPT_SORT,");
            sql.AppendLine("   DEPT_TYPE,");
            sql.AppendLine("   DEPT_DESC,");
            sql.AppendLine("   IS_ABLE,");
            sql.AppendLine("   IS_END,"); 
            sql.AppendLine("   CREATE_USER,");
            sql.AppendLine("   LM_USER)");
            sql.AppendLine("VALUES");
            sql.AppendLine("  ($DEPT_CODE,");
            sql.AppendLine("   $DEPT_NAME,");
            sql.AppendLine("   $PARENT_CODE,");
            sql.AppendLine("   $SITE_CODE,");
            sql.AppendLine("   $SITE_NAME,");
            sql.AppendLine("   $DEPT_SORT,");
            sql.AppendLine("   $DEPT_TYPE,");
            sql.AppendLine("   $DEPT_DESC,");
            sql.AppendLine("   $IS_ABLE,");
            sql.AppendLine("   $IS_END,"); 
            sql.AppendLine("   $CREATE_USER,");
            sql.AppendLine("   $LM_USER)");
            SQLParameter[] parms={
                                     new SQLParameter("DEPT_CODE",typeof(string),model.DEPT_CODE),
                                     new SQLParameter("DEPT_NAME",typeof(string),model.DEPT_NAME),
                                     new SQLParameter("PARENT_CODE",typeof(string),model.PARENT_CODE),
                                     new SQLParameter("SITE_CODE",typeof(string),model.SITE_CODE),
                                     new SQLParameter("SITE_NAME",typeof(string),model.SITE_NAME),
                                     new SQLParameter("DEPT_SORT",typeof(int),model.DEPT_SORT),
                                     new SQLParameter("DEPT_TYPE",typeof(string),model.DEPT_TYPE),
                                     new SQLParameter("DEPT_DESC",typeof(string),model.DEPT_DESC),
                                     new SQLParameter("IS_ABLE",typeof(int),model.IS_ABLE),
                                     new SQLParameter("IS_END",typeof(int),model.IS_END), 
                                     new SQLParameter("CREATE_USER",typeof(string),model.CREATE_USER),
                                     new SQLParameter("LM_USER ",typeof(string),model.LM_USER),
                                 };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dept_code"></param>
        /// <returns></returns>
        public int Delete(string dept_code)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_DEPT WHERE DEPT_CODE = $DEPT_CODE");
            SQLParameter[] parms ={
                                      new SQLParameter("DEPT_CODE",typeof(string),dept_code)
                                  };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(SysDeptModel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE SYS_DEPT");
            sql.AppendLine("   SET DEPT_NAME   = $DEPT_NAME,");
            sql.AppendLine("       PARENT_CODE = $PARENT_CODE,");
            sql.AppendLine("       SITE_CODE   = $SITE_CODE,");
            sql.AppendLine("       SITE_NAME   = $SITE_NAME,");
            sql.AppendLine("       DEPT_SORT   = $DEPT_SORT,");
            sql.AppendLine("       DEPT_TYPE   = $DEPT_TYPE,");
            sql.AppendLine("       DEPT_DESC   = $DEPT_DESC,");
            sql.AppendLine("       IS_ABLE     = $IS_ABLE,");
            sql.AppendLine("       IS_END      = $IS_END,"); 
            sql.AppendLine("       LM_TIME     = GETDATE(),");
            sql.AppendLine("       LM_USER     = $LM_USER");
            sql.AppendLine(" WHERE DEPT_CODE = $DEPT_CODE");
 
            SQLParameter[] parms ={
                                      new SQLParameter("DEPT_NAME",typeof(string),model.DEPT_NAME),
                                      new SQLParameter("PARENT_CODE",typeof(string),model.PARENT_CODE),
                                      new SQLParameter("SITE_CODE",typeof(string),model.SITE_CODE),
                                      new SQLParameter("SITE_NAME",typeof(string),model.SITE_NAME),
                                      new SQLParameter("DEPT_SORT",typeof(int),model.DEPT_SORT),
                                      new SQLParameter("DEPT_TYPE",typeof(string),model.DEPT_TYPE),
                                      new SQLParameter("DEPT_DESC",typeof(string),model.DEPT_DESC),
                                      new SQLParameter("IS_ABLE",typeof(int),model.IS_ABLE),
                                      new SQLParameter("IS_END",typeof(int),model.IS_END), 
                                      new SQLParameter("LM_USER",typeof(string),model.LM_USER),
                                      new SQLParameter("DEPT_CODE",typeof(string),model.DEPT_CODE),
                                  };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
        /// <summary>
        /// 获取部门信息列表
        /// </summary>
        /// <param name="parentId">父级编号</param>
        /// <returns></returns>
        public DataTable GetList(string parentId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT CREATE_TIME,");
            sql.AppendLine("       DEPT_CODE,");
            sql.AppendLine("       DEPT_NAME,");
            sql.AppendLine("       PARENT_CODE,");
            sql.AppendLine("       SITE_CODE,");
            sql.AppendLine("       SITE_NAME,");
            sql.AppendLine("       DEPT_SORT,");
            sql.AppendLine("       DEPT_TYPE,");
            sql.AppendLine("       DEPT_DESC,");
            sql.AppendLine("       IS_ABLE,");
            sql.AppendLine("       IS_END,"); 
            sql.AppendLine("       CREATE_USER,");
            sql.AppendLine("       LM_TIME,");
            sql.AppendLine("       LM_USER");
            sql.AppendLine("  FROM SYS_DEPT"); 
            sql.AppendLine("  WHERE PARENT_CODE = $PARENT_CODE");
            SQLParameter[] parms ={
                                      new SQLParameter("PARENT_CODE",typeof(string),parentId) 
                                  };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取部门信息列表
        /// </summary>
        /// <param name="parent_code">父级编号</param>
        /// <returns></returns>
        public DataTable GetByParentId(string parent_code)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT CREATE_TIME,");
            sql.AppendLine("       DEPT_CODE,");
            sql.AppendLine("       DEPT_NAME,");
            sql.AppendLine("       PARENT_CODE,");
            sql.AppendLine("       SITE_CODE,");
            sql.AppendLine("       SITE_NAME,");
            sql.AppendLine("       DEPT_SORT,");
            sql.AppendLine("       DEPT_TYPE,");
            sql.AppendLine("       DEPT_DESC,");
            sql.AppendLine("       IS_ABLE,");
            sql.AppendLine("       IS_END,"); 
            sql.AppendLine("       CREATE_USER,");
            sql.AppendLine("       LM_TIME,");
            sql.AppendLine("       LM_USER");
            sql.AppendLine("  FROM SYS_DEPT");
            sql.AppendLine("  WHERE PARENT_CODE = $PARENT_CODE");
            SQLParameter[] parms ={
                                      new SQLParameter("PARENT_CODE",typeof(string),parent_code) 
                                  };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="dept_code">编号</param>
        /// <returns></returns>
        public DataTable GetById(string dept_code)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT CREATE_TIME,");
            sql.AppendLine("       DEPT_CODE,");
            sql.AppendLine("       DEPT_NAME,");
            sql.AppendLine("       PARENT_CODE,");
            sql.AppendLine("       SITE_CODE,");
            sql.AppendLine("       SITE_NAME,");
            sql.AppendLine("       DEPT_SORT,");
            sql.AppendLine("       DEPT_TYPE,");
            sql.AppendLine("       DEPT_DESC,");
            sql.AppendLine("       IS_ABLE,");
            sql.AppendLine("       IS_END,"); 
            sql.AppendLine("       CREATE_USER,");
            sql.AppendLine("       LM_TIME,");
            sql.AppendLine("       LM_USER");
            sql.AppendLine("  FROM SYS_DEPT");
            sql.AppendLine("  WHERE DEPT_CODE = $DEPT_CODE");
            SQLParameter[] parms ={
                                      new SQLParameter("DEPT_CODE",typeof(string),dept_code)
                                  };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="dept_code">部门编号</param>
        /// <param name="dept_name">部门名称</param>
        /// <returns></returns>
        public DataTable GetByCodeOrName(string dept_code,string dept_name)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT CREATE_TIME,");
            sql.AppendLine("       DEPT_CODE,");
            sql.AppendLine("       DEPT_NAME,");
            sql.AppendLine("       PARENT_CODE,");
            sql.AppendLine("       SITE_CODE,");
            sql.AppendLine("       SITE_NAME,");
            sql.AppendLine("       DEPT_SORT,");
            sql.AppendLine("       DEPT_TYPE,");
            sql.AppendLine("       DEPT_DESC,");
            sql.AppendLine("       IS_ABLE,");
            sql.AppendLine("       IS_END,");
            sql.AppendLine("       CREATE_USER,");
            sql.AppendLine("       LM_TIME,");
            sql.AppendLine("       LM_USER");
            sql.AppendLine("  FROM SYS_DEPT");
            sql.AppendLine("  WHERE DEPT_CODE = $DEPT_CODE");
            sql.AppendLine("     OR DEPT_NAME = $DEPT_NAME");
            SQLParameter[] parms ={
                                      new SQLParameter("DEPT_CODE",typeof(string),dept_code),
                                      new SQLParameter("DEPT_NAME",typeof(string),dept_name)
                                  };
            DataSet ds = DB.CustomDataSet(new SQLParamCondition(sql.ToString(), parms));
            return ds.Tables[0];
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        public int DeleteByType(string type)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("DELETE FROM SYS_DEPT WHERE DEPT_TYPE = $DEPT_TYPE");
            SQLParameter[] parms ={
                                      new SQLParameter("DEPT_TYPE",typeof(string),type)
                                  };
            int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
            return result;
        }
    }
}






















































