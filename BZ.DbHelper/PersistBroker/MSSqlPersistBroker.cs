using BZ.DbHelper.DataProvider;
using BZ.DbHelper.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.DbHelper.PersistBroker
{
    public class MSSqlPersistBroker : AbstractPersistBroker, IPersistBroker
    {

        public MSSqlPersistBroker(string connectionString)
            : base(new SqlConnection(connectionString))
        {

        }

        public MSSqlPersistBroker(string connectionString, System.Globalization.CultureInfo cultureInfo)
            : base(new SqlConnection(connectionString), cultureInfo)
        {

        }

        public override void Execute(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                //重组参数列表
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);
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
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
            }
        }

        public override int ExecuteWithReturn(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            int result = 0;
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);
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
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
                return result;
            }
        }

        public override DataSet QueryDataSet(string commandText)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this.Transaction != null)
                {
                    command.Transaction = (SqlTransaction)this.Transaction;
                }
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = null;
                SqlDataReader reader = null;

                try
                {
                    dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataSet);

                    //reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                }
                catch (Exception e)
                {
                    //if (reader != null)
                    //    reader.Close();
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

        public override DataSet QueryDataSet(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter = null;
                SqlDataReader reader = null;

                try
                {
                    dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataSet);

                    //reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                    //do
                    //{
                    //    DataTable dt = new DataTable();
                    //    for (int i = 0; i < reader.FieldCount; i++)
                    //    {
                    //        if (!dt.Columns.Contains(reader.GetName(i)))
                    //        {
                    //            DataColumn dc = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                    //            dt.Columns.Add(dc);
                    //        }
                    //    }

                    //    while (reader.Read())
                    //    {
                    //        DataRow dr = dt.NewRow();
                    //        for (int i = 0; i < reader.FieldCount; i++)
                    //        {
                    //            object objVal = reader[i];
                    //            dr[reader.GetName(i)] = objVal;
                    //        }
                    //        dt.Rows.Add(dr);
                    //    }

                    //    dataSet.Tables.Add(dt);
                    //} while (reader.NextResult());
                    //reader.Close();
                }
                catch (Exception e)
                {
                    //if (reader != null)
                    //    reader.Close();
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

        public override object QuerySingle(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);

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

        public override IDataReader QueryDataReader(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);

                SqlDataReader reader = null;

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

        public override void ExecuteProcedure(string commandText, ref ArrayList parameters)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                object[] parameterValues = new object[parameters.Count];

                CommandParam(command, parameters, ref parameterValues);
                try
                {
                    command.ExecuteNonQuery();

                    for (int i = 0; i < parameters.Count; i++)
                    {
                        if (((SQLParameter)parameters[i]).Direction != DirectionType.Input)
                        {
                            ((SQLParameter)parameters[i]).Value = ((SqlParameter)parameterValues[i]).Value;
                        }
                    }

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

        public override DataSet ExecuteProcedureWithReturn(string commandText, ref ArrayList parameters)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;
                object[] parameterValues = new object[parameters.Count];
                CommandParam(command, parameters, ref parameterValues);

                DataSet dataSet = new DataSet();
                SqlDataReader reader = null;

                try
                {
                    reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                    for (int i = 0; i < parameters.Count; i++)
                    {
                        if (((SQLParameter)parameters[i]).Direction != DirectionType.Input)
                        {
                            ((SQLParameter)parameters[i]).Value = ((SqlParameter)parameterValues[i]).Value;
                        }
                    }

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

        #region 公共方法，替换和转换参数用的
        /// <summary>
        /// 替换参数符号
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        private string replaceParameterSymbol(string commandText)
        {
            //return new Regex(@"\$([0-9A-Za-z]+)").Replace(commandText, "?");
            return commandText.Replace("$", "@");
        }
        /// <summary>
        /// C#数据类型转换SqlServer数据类型
        /// </summary>
        /// <param name="cType"></param>
        /// <returns></returns>
        private SqlDbType CTypeToSType(Type cType)
        {
            if (cType == typeof(string))
            {
                return SqlDbType.VarChar;
            }

            if (cType == typeof(int))
            {
                return SqlDbType.Int;
            }

            if (cType == typeof(long))
            {
                return SqlDbType.BigInt;
            }

            if (cType == typeof(double))
            {
                return SqlDbType.Float;
            }

            if (cType == typeof(float))
            {
                return SqlDbType.Float;
            }

            if (cType == typeof(decimal))
            {
                return SqlDbType.Decimal;
            }

            if (cType == typeof(bool))
            {
                return SqlDbType.VarChar;
            }

            if (cType == typeof(DateTime))
            {
                return SqlDbType.VarChar;
            }

            if (cType == typeof(byte[]))
            {
                return SqlDbType.Binary;
            }

            return SqlDbType.Variant;
        }

        /// <summary>
        /// 设定command参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterNames"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        private void CommandParam(SqlCommand command, string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            command.CommandText = this.replaceParameterSymbol(commandText);
            for (int i = 0; i < parameterNames.Length; i++)
            {
                SqlParameter param;
                if (parameterSizes[i] > 0)
                    param = new SqlParameter(parameterNames[i], CTypeToSType(parameterTypes[i]), parameterSizes[i]);
                else
                    param = new SqlParameter(parameterNames[i], CTypeToSType(parameterTypes[i]));
                param.Value = IsDBNull(parameterValues[i]);
                command.Parameters.Add(param);
                //command.Parameters.Add(parameterNames[i], CTypeToOType(parameterTypes[i])).Value = parameterValues[i];
            }
            if (this.Transaction != null)
            {
                command.Transaction = (SqlTransaction)this.Transaction;
            }
        }
        /// <summary>
        /// 设定command参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <param name="parameterValues"></param>
        private void CommandParam(SqlCommand command, ArrayList parameters, ref object[] parameterValues)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                SQLParameter proc_parm = (SQLParameter)parameters[i];

                SqlParameter param;
                if (proc_parm.Size > 0)
                    param = new SqlParameter(proc_parm.Name, CTypeToSType(proc_parm.Type), proc_parm.Size);
                else
                    param = new SqlParameter(proc_parm.Name, CTypeToSType(proc_parm.Type));


                if (proc_parm.Direction != DirectionType.Input)
                {
                    param.Direction = (ParameterDirection)System.Enum.Parse(typeof(ParameterDirection), System.Enum.GetName(typeof(DirectionType), proc_parm.Direction));
                }
                else
                {
                    param.Direction = ParameterDirection.Input;
                }
                param.Value = IsDBNull(proc_parm.Value);
                parameterValues[i] = param;
                command.Parameters.Add(param);
            }
            if (this.Transaction != null)
            {
                command.Transaction = (SqlTransaction)this.Transaction;
            }
        }

        /// <summary>
        /// 替换参数列表，用于写入log用的
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        private string spellCommandText(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                string value = SqlValuesType(parameterTypes[i], parameterValues[i]);
                commandText = commandText.Replace("@" + parameters[i], value);
            }
            return commandText;
        }

        /// <summary>
        /// 参数值转换
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SqlValuesType(Type type, object value)
        {
            if (type == typeof(string))
            {
                return "'" + value + "'";
            }

            if (type == typeof(int))
            {
                return value.ToString();
            }

            if (type == typeof(long))
            {
                return value.ToString();
            }

            if (type == typeof(double))
            {
                return value.ToString();
            }

            if (type == typeof(float))
            {
                return value.ToString();
            }

            if (type == typeof(decimal))
            {
                return value.ToString();
            }

            if (type == typeof(bool))
            {
                return value.ToString();
            }

            if (type == typeof(DateTime))
            {
                return "'" + value + "'";
            }

            if (type == typeof(byte[]))
            {
                return "'" + value + "'";
            }

            return value.ToString();
        }

        private object IsDBNull(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            return value;
        }
        #endregion
    }
}
