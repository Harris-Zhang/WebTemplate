using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.Interface
{
    /// <summary>
    /// 原始数据层类的接口
    /// </summary>
    public interface IPersistBroker : IPersistBrokerTransaction
    {
        /// <summary>
        /// 是否支持手动关闭连接
        /// 是否 自动关闭连接
        /// </summary>
        bool AutoCloseConnection
        {
            get;
            set;
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        void OpenConnection();
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        void Execute(string commandText);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameterNames">参数名称列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        void Execute(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);


        /// <summary>
        /// 执行SQL 并返回受影响的行数
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>受影响的行数</returns>
        int ExecuteWithReturn(string commandText);

        /// <summary>
        /// 执行SQL 并返回受影响的行数
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameterNames">参数名称列表</param>
        /// <param name="parameterTypes">参数类型类别</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteWithReturn(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        /// <summary>
        /// 执行SQL 语句查询并返回弱类型DataSet
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>查询结果（DataSet）</returns>
        DataSet QueryDataSet(string commandText);

        /// <summary>
        /// 执行SQL 语句查询并返回弱类型DataSet
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameterNames">参数名称列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>查询结果（DataSet）</returns>
        DataSet QueryDataSet(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        /// <summary>
        /// 执行SQL语句 返回结果集中的第一行第一列(object 类型).
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>结果集中的第一行第一列</returns>
        object QuerySingle(string commandText);

        /// <summary>
        /// 执行SQL语句 返回结果集中的第一行第一列(object 类型).
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameterNames">参数名称列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>结果集中的第一行第一列</returns>
        object QuerySingle(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        /// <summary>
        /// 执行SQL语句 返回结果集(IDataReader类型)
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>结果集(IDataReader)</returns>
        IDataReader QueryDataReader(string commandText);

        /// <summary>
        /// 执行SQL语句 返回结果集(IDataReader类型)
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameterNames">参数名称列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>结果集(IDataReader)</returns>
        IDataReader QueryDataReader(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        void ExecuteProcedure(string commandText);

        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <param name="parameters">参数列表</param>
        void ExecuteProcedure(string commandText, ref ArrayList parameters);

        /// <summary>
        /// 执行Procedure 带返回结果集
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <returns>返回结果集</returns>
        DataSet ExecuteProcedureWithReturn(string commandText);

        /// <summary>
        /// 执行Procedure 带返回结果集
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回结果集</returns>
        DataSet ExecuteProcedureWithReturn(string commandText, ref ArrayList parameters);
    }
}
