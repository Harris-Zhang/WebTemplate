using BZ.DbHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using BZ.DbHelper.DataProvider;

namespace BZ.DbHelper.PersistBroker
{
    public class SQLitePersistBroker : AbstractPersistBroker, IPersistBroker
    {
        public SQLitePersistBroker(string connectionString)
            : base(new SQLiteConnection(connectionString))
        {

        }

        public SQLitePersistBroker(string connectionString, System.Globalization.CultureInfo cultureInfo)
            : base(new SQLiteConnection(connectionString), cultureInfo)
        {

        }
         

        public override void Execute(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
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
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
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
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                if (this.Transaction != null)
                {
                    command.Transaction = (SQLiteTransaction)this.Transaction;
                }
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter dataAdapter = null;
                SQLiteDataReader reader = null;
                try
                {
                    dataAdapter = new SQLiteDataAdapter(command);
                    dataAdapter.Fill(dataSet);
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
                return dataSet;
            }
        }

        public override DataSet QueryDataSet(string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            OpenConnection();
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);
                DataSet dataSet = new DataSet();
                SQLiteDataReader reader = null;
                SQLiteDataAdapter dataAdapter = null;

                DateTime dtStart = DateTime.Now;

                try
                {
                    dataAdapter = new SQLiteDataAdapter(command);
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
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
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
            using (SQLiteCommand command = (SQLiteCommand)this.Connection.CreateCommand())
            {
                CommandParam(command, commandText, parameterNames, parameterTypes, parameterSizes, parameterValues);
                //替换参数列表，用于写入log用的
                string sqlText = spellCommandText(command.CommandText, parameterNames, parameterTypes, parameterValues);

                SQLiteDataReader reader = null;

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
            throw new NotImplementedException();
        }

        public override DataSet ExecuteProcedureWithReturn(string commandText, ref ArrayList parameters)
        {
            throw new NotImplementedException();
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
        /// C#数据类型转换Access数据类型
        /// </summary>
        /// <param name="cType"></param>
        /// <returns></returns>
        private DbType CTypeToSType(Type cType)
        {
            if (cType == typeof(string))
            {
                return DbType.String;
            }

            if (cType == typeof(int))
            {
                return DbType.Int32;
            }

            if (cType == typeof(long))
            {
                return DbType.Decimal;
            }

            if (cType == typeof(double))
            {
                return DbType.Double;
            }

            if (cType == typeof(float))
            {
                return DbType.Single;
            }

            if (cType == typeof(decimal))
            {
                return DbType.Decimal;
            }

            if (cType == typeof(bool))
            {
                return DbType.Boolean;
            }

            if (cType == typeof(DateTime))
            {
                return DbType.DateTime;
            }

            if (cType == typeof(byte[]))
            {
                return DbType.Binary;
            }

            return DbType.Object;
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
        private void CommandParam(SQLiteCommand command, string commandText, string[] parameterNames, Type[] parameterTypes, int[] parameterSizes, object[] parameterValues)
        {
            command.CommandText = this.replaceParameterSymbol(commandText);
            for (int i = 0; i < parameterNames.Length; i++)
            {
                SQLiteParameter param;
                if (parameterSizes[i] > 0)
                    param = new SQLiteParameter(parameterNames[i], CTypeToSType(parameterTypes[i]), parameterSizes[i]);
                else
                    param = new SQLiteParameter(parameterNames[i], CTypeToSType(parameterTypes[i]));
                param.Value = IsDBNull(parameterValues[i]);
                command.Parameters.Add(param);
                //command.Parameters.Add(parameterNames[i], CTypeToOType(parameterTypes[i])).Value = parameterValues[i];
            }
            if (this.Transaction != null)
            {
                command.Transaction = (SQLiteTransaction)this.Transaction;
            }
        }
        /// <summary>
        /// 设定command参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <param name="parameterValues"></param>
        private void CommandParam(SQLiteCommand command, ArrayList parameters, ref object[] parameterValues)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                SQLParameter proc_parm = (SQLParameter)parameters[i];

                SQLiteParameter param;
                if (proc_parm.Size > 0)
                    param = new SQLiteParameter(proc_parm.Name, CTypeToSType(proc_parm.Type), proc_parm.Size);
                else
                    param = new SQLiteParameter(proc_parm.Name, CTypeToSType(proc_parm.Type));


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
                command.Transaction = (SQLiteTransaction)this.Transaction;
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
