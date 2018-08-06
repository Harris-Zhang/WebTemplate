using BZ.DbHelper.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.Interface
{
    public interface IDataQuery
    {
        /// <summary>
        /// 查询记录行数
        /// </summary>
        /// <param name="conditions">查询条件，其中需要包含count(*)的格式返回记录数</param>
        /// <returns>记录数</returns>
        /// <example>
        /// int result = 
        ///		this.DataProvider.GetCount(new SQLCondition("select count(*) from TableName"));
        /// </example>
        int GetCount(Condition conditions);

        /// <summary>
        /// 查询首行首列值
        /// </summary>
        /// <param name="sql">查询的Sql语句</param>
        /// <returns>首行首列值</returns>
        /// <example>
        /// object result = 
        ///		this.DataProvider.QuerySingle("select field1 from TableName");
        /// </example>
        object QuerySingle(Condition condition);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="conditions">SQL条件</param>
        /// <example>
        /// this.DataProvider.CustomExecute(new SQLCondition("update tableName set field1='' where field2=''"));
        /// </example>
        void CustomExecute(Condition condition);
        /// <summary>
        /// 执行相关事物
        /// </summary>
        /// <param name="listCondition"></param>
        void CustomExecute(List<Condition> listCondition);

        /// <summary>
        /// 执行SQL并返回影响行数
        /// </summary>
        /// <param name="conditions">SQL语句</param>
        /// <returns>影响行数</returns>
        int CustomExecuteWithReturn(Condition condition);
        /// <summary>
        /// 执行相关事物
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int CustomExecuteWithReturn(List<Condition> condition);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回DataSet数据集</returns>
        DataSet CustomDataSet(Condition condition);

        /// <summary>
        /// 查询SQL语句
        /// </summary>
        /// <param name="conditions">SQL条件</param>
        /// <returns>DataReader</returns>
        IDataReader CustomDataReader(Condition condition);

        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="conditions">Procedure条件</param>
        /// <example>
        /// 
        /// </example>
        void CustomProcedure(ref Condition condition);

        /// <summary>
        /// 执行Procedure(返回数据集)
        /// </summary>
        /// <param name="condition">Procedure条件</param>
        /// <returns>返回数据集</returns>
        DataSet CustomProcedureWithReturn(ref Condition condition);

    }
}
