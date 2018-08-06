using BZ.DbHelper;
using BZ.DbHelper.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace BZ.DbHelper.PersistBroker
{
    public abstract class AbstractPersistBroker : MarshalByRefObject, IPersistBroker
    {

        private bool _autoCloseConn = true;

        /// <summary>
        /// 是否自动关闭连接
        /// </summary>
        public bool AutoCloseConnection
        {
            get { return _autoCloseConn; }
            set { _autoCloseConn = value; }
        }

        private System.Globalization.CultureInfo _cultureInfo = null;
        private IDbConnection _connection = null;
        private IDbTransaction _transaction = null;
        private object _lock = new object();

        public AbstractPersistBroker(IDbConnection connection)
            : this(connection, new System.Globalization.CultureInfo("en-US", false))
        {

        }

        public AbstractPersistBroker(IDbConnection connection, System.Globalization.CultureInfo cultureInfo)
        {
            this._connection = connection;
            this._cultureInfo = cultureInfo;
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        protected IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public bool IsInTransaction
        {
            get
            {
                lock (_lock)
                {
                    if (this._transaction != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenConnection()
        {
            if (this._connection != null)
            {
                if (this._connection.State != ConnectionState.Open)
                {
                    try
                    {
                        this._connection.Open();

                    }
                    catch (Exception ex)
                    {



                    }
                }
            }
        }

        public void CloseConnection()
        {
            if (this._connection != null)
            {
                if (this._connection.State != ConnectionState.Closed)
                {
                    try
                    {
                        this._connection.Close();

                    }
                    catch (Exception ex)
                    {



                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        public void Execute(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;
                }
                try
                {
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {


                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (this._transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
            }
        }

        public abstract void Execute(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);


        public int ExecuteWithReturn(string commandText)
        {
            int result = 0;
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;
                }
                try
                {
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {


                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (this._transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
                return result;
            }
        }

        public abstract int ExecuteWithReturn(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);


        #region 不用
        //        public DataSet QueryDataSet(string commandText)
        //        {
        //            OpenConnection();
        //            using (IDbCommand command = this._connection.CreateCommand())
        //            {
        //                command.CommandText = commandText;
        //                if (this._transaction != null)
        //                {
        //                    command.Transaction = this.Transaction;
        //                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
        //                    //    command.Transaction = this._transaction;
        //                }

        //                DataSet dataSet = new DataSet();
        //                IDataReader reader = null;
        //                IDbDataAdapter dataAdapter = null;
        //#if DEBUG
        //                DateTime dtStart = DateTime.Now;
        //
        //                try
        //                { 
        //                    reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
        //#if DEBUG
        //                    DateTime dtEnd = DateTime.Now;
        //                    Log4Helper.WriteSqlLogInfo(command.CommandText, dtStart, dtEnd);
        //
        //                    do
        //                    {
        //                        DataTable dt = new DataTable();
        //                        for (int i = 0; i < reader.FieldCount; i++)
        //                        {
        //                            if (!dt.Columns.Contains(reader.GetName(i)))
        //                            {
        //                                DataColumn dc = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
        //                                dt.Columns.Add(dc);
        //                            }
        //                        }

        //                        while (reader.Read())
        //                        {
        //                            DataRow dr = dt.NewRow();
        //                            for (int i = 0; i < reader.FieldCount; i++)
        //                            {
        //                                object objVal = reader[i];
        //                                dr[reader.GetName(i)] = objVal;
        //                            }
        //                            dt.Rows.Add(dr);
        //                        }

        //                        dataSet.Tables.Add(dt);
        //                    } while (reader.NextResult());
        //                    reader.Close();
        //                }
        //                catch (Exception e)
        //                {
        //#if DEBUG
        //                    Log4Helper.WriteSqlLogError(command.CommandText, e);
        //
        //                    if (reader != null)
        //                        reader.Close();
        //                    throw new Exception(e.Message);
        //                }
        //                finally
        //                {
        //                    if (this.Transaction == null && AutoCloseConnection == true)
        //                    {
        //                        CloseConnection();
        //                    }
        //                }
        //                return dataSet;

        //            }
        //        }
        #endregion

        public abstract DataSet QueryDataSet(string commandText);

        public abstract DataSet QueryDataSet(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        public object QuerySingle(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;

                }

                object result = null;
                try
                {
                    result = command.ExecuteScalar();

                }
                catch (Exception e)
                {


                    throw new Exception(e.Message);
                }
                finally
                {
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
                return result;
            }
        }

        public abstract object QuerySingle(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        public IDataReader QueryDataReader(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;
                }

                IDataReader reader = null;

                try
                {
                    reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                }
                catch (Exception e)
                {

                    if (reader != null)
                        reader.Close();
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }
                return reader;

            }
        }

        public abstract IDataReader QueryDataReader(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues);

        public void ExecuteProcedure(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;
                }

                try
                {
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {


                    throw new Exception(e.Message);
                }
                finally
                {
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }

            }

        }

        public abstract void ExecuteProcedure(string commandText, ref ArrayList parameters);


        public DataSet ExecuteProcedureWithReturn(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this._connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                if (this._transaction != null)
                {
                    command.Transaction = this.Transaction;
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    //    command.Transaction = this._transaction;
                }

                DataSet dataSet = new DataSet();
                IDataReader reader = null;

                try
                {
                    reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                    do
                    {
                        DataTable dt = new DataTable();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!dt.Columns.Contains(reader.GetName(i)))
                            {
                                DataColumn dc = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                                dt.Columns.Add(dc);
                            }
                        }

                        while (reader.Read())
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                object objVal = reader[i];
                                dr[reader.GetName(i)] = objVal;
                            }
                            dt.Rows.Add(dr);
                        }

                        dataSet.Tables.Add(dt);
                    } while (reader.NextResult());

                    reader.Close();
                }
                catch (Exception e)
                {

                    if (reader != null)
                        reader.Close();
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
                return dataSet;

            }
        }

        public abstract DataSet ExecuteProcedureWithReturn(string commandText, ref ArrayList parameters);


        #region IPersistBrokerTransaction 成员

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTransaction()
        {
            lock (_lock)
            {
                if (this._transaction != null)
                {
                    throw new RemotingException("Internal: 不支持嵌套的事务.");

                }
                OpenConnection();

                this._transaction = this._connection.BeginTransaction();


            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            lock (_lock)
            {
                if (this._transaction == null)
                {
                    return;
                }

                try
                {
                    this._transaction.Rollback();

                }
                finally
                {
                    this._transaction = null;
                }
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            lock (_lock)
            {
                if (this._transaction == null)
                {
                    return;
                }

                try
                {
                    this._transaction.Commit();
                }
                finally
                {
                    this._transaction = null;
                }
            }
        }

        #endregion
    }
}
