using BZ.DbHelper.DataProvider;
using BZ.DbHelper.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.DataProvider
{
    public class SQLDataProvider : MarshalByRefObject, IDataProvider
    {
        private IPersistBroker _persistBroker;
        private System.Globalization.CultureInfo _cultureInfo;

        /// <summary>
        /// 构造
        /// </summary>
        public SQLDataProvider()
        {

        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="persistBroker">持久化连接</param>
        /// <param name="cultureInfo"></param>
        public SQLDataProvider(IPersistBroker persistBroker, System.Globalization.CultureInfo cultureInfo)
        {
            this._persistBroker = persistBroker;
            this._cultureInfo = cultureInfo;
        }

        public bool AutoCloseConnection
        {
            get { return _persistBroker.AutoCloseConnection; }
            set { _persistBroker.AutoCloseConnection = value; }
        }

        public IPersistBroker PersistBroker
        {
            get { return _persistBroker; }
        }

        public System.Globalization.CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
        }

        public void BeginTransaction()
        {
            this._persistBroker.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            this._persistBroker.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            this._persistBroker.CommitTransaction();
        }

        public int GetCount(Condition condition)
        {
            //throw new NotImplementedException();
            object result = QuerySingle(condition);
            return Convert.ToInt32(result);
        }

        public virtual object QuerySingle(Condition condition)
        {
            if (condition.SQLType == SQLType.Command)
            {
                string[] parameterNames = null;
                Type[] parameterTypes = null;
                int[] parameterSizes = null;
                object[] parameterValues = null;
                SplitParameter(condition, ref parameterNames, ref parameterTypes, ref parameterSizes, ref parameterValues);

                return this._persistBroker.QuerySingle(condition.SQLText, parameterNames, parameterTypes, parameterSizes, parameterValues);
            }
            else
            {
                return this._persistBroker.QuerySingle(condition.SQLText);
            }

        }

        public virtual void CustomExecute(Condition condition)
        {
            if (condition.SQLType == SQLType.Command)
            {
                string[] parameterNames = null;
                Type[] parameterTypes = null;
                int[] parameterSizes = null;
                object[] parameterValues = null;
                SplitParameter(condition, ref parameterNames, ref parameterTypes, ref parameterSizes, ref parameterValues);

                this._persistBroker.Execute(condition.SQLText, parameterNames, parameterTypes, parameterSizes, parameterValues);
            }
            else
            {
                this._persistBroker.Execute(condition.SQLText);
            }
        }

        public virtual void CustomExecute(List<Condition> listCondition)
        {
            this._persistBroker.BeginTransaction();
            try
            {
                foreach (Condition condition in listCondition)
                {
                    CustomExecute(condition);
                }
                this._persistBroker.CommitTransaction();
            }
            catch (Exception ex)
            {
                this._persistBroker.RollbackTransaction();
                throw ex;
            }
        }

        public virtual int CustomExecuteWithReturn(Condition condition)
        {
            if (condition.SQLType == SQLType.Command)
            {
                string[] parameterNames = null;
                Type[] parameterTypes = null;
                int[] parameterSizes = null;
                object[] parameterValues = null;
                SplitParameter(condition, ref parameterNames, ref parameterTypes, ref parameterSizes, ref parameterValues);

                return this._persistBroker.ExecuteWithReturn(condition.SQLText, parameterNames, parameterTypes, parameterSizes, parameterValues);
            }
            else
            {
                return this._persistBroker.ExecuteWithReturn(condition.SQLText);
            }
        }

        public virtual int CustomExecuteWithReturn(List<Condition> listCondition)
        {
            this._persistBroker.BeginTransaction();
            int result = 0;
            try
            {
                foreach (Condition condition in listCondition)
                {
                    result += CustomExecuteWithReturn(condition);
                }
                this._persistBroker.CommitTransaction();
            }
            catch (Exception ex)
            {
                result = 0;
                this._persistBroker.RollbackTransaction();
                throw ex;
            }
            return result;
        }

        public virtual DataSet CustomDataSet(Condition condition)
        {
            if (condition.SQLType == SQLType.Command)
            {
                string[] parameterNames = null;
                Type[] parameterTypes = null;
                int[] parameterSizes = null;
                object[] parameterValues = null;
                SplitParameter(condition, ref parameterNames, ref parameterTypes, ref parameterSizes, ref parameterValues);

                return this._persistBroker.QueryDataSet(condition.SQLText, parameterNames, parameterTypes, parameterSizes, parameterValues);
            }
            else
            {
                return this._persistBroker.QueryDataSet(condition.SQLText);
            }
        }

        public virtual IDataReader CustomDataReader(Condition condition)
        {
            if (condition.SQLType == SQLType.Command)
            {
                string[] parameterNames = null;
                Type[] parameterTypes = null;
                int[] parameterSizes = null;
                object[] parameterValues = null;
                SplitParameter(condition, ref parameterNames, ref parameterTypes, ref parameterSizes, ref parameterValues);

                return this._persistBroker.QueryDataReader(condition.SQLText, parameterNames, parameterTypes, parameterSizes, parameterValues);
            }
            else
            {
                return this._persistBroker.QueryDataReader(condition.SQLText);
            }
        }

        public virtual void CustomProcedure(ref Condition condition)
        {
            if (condition.SQLType == SQLType.StoredProcedure)
            {
                if (condition is ProcedureParamCondition)
                {
                    ProcedureParamCondition paramCondition = (ProcedureParamCondition)condition;

                    ArrayList paras = new ArrayList(paramCondition.Parameters.Length);

                    foreach (SQLParameter param in paramCondition.Parameters)
                    {
                        paras.Add(param);

                    }

                    this._persistBroker.ExecuteProcedure(condition.SQLText, ref paras);
                    for (int i = 0; i < paramCondition.Parameters.Length; i++)
                    {
                        if ((paramCondition.Parameters[i].Direction == DirectionType.InputOutput)
                            || (paramCondition.Parameters[i].Direction == DirectionType.Output)
                            || (paramCondition.Parameters[i].Direction == DirectionType.ReturnValue))
                        {
                            paramCondition.Parameters[i].Value = ((SQLParameter)paras[i]).Value;
                        }
                    }
                }
                else
                {
                    this._persistBroker.ExecuteProcedure(condition.SQLText);
                }
            }
            else
            {
                this._persistBroker.Execute(condition.SQLText);
            }
        }

        public virtual DataSet CustomProcedureWithReturn(ref Condition condition)
        {
            if (condition.SQLType == SQLType.StoredProcedure)
            {
                if (condition is ProcedureParamCondition)
                {
                    ProcedureParamCondition paramCondition = (ProcedureParamCondition)condition;
                    ArrayList paras = new ArrayList(paramCondition.Parameters.Length);

                    foreach (SQLParameter param in paramCondition.Parameters)
                    {
                        paras.Add(param);

                    }

                    DataSet ds = this._persistBroker.ExecuteProcedureWithReturn(condition.SQLText, ref paras);
                    for (int i = 0; i < paramCondition.Parameters.Length; i++)
                    {
                        if ((paramCondition.Parameters[i].Direction == DirectionType.InputOutput)
                            || (paramCondition.Parameters[i].Direction == DirectionType.Output)
                            || (paramCondition.Parameters[i].Direction == DirectionType.ReturnValue))
                        {
                            paramCondition.Parameters[i].Value = ((SQLParameter)paras[i]).Value;
                        }
                    }
                    return ds;
                }
                else
                {
                    return this._persistBroker.ExecuteProcedureWithReturn(condition.SQLText);
                }
            }
            else
            {
                return this._persistBroker.QueryDataSet(condition.SQLText);
            }
        }

        private void SplitParameter(Condition condition, ref string[] parameterNames, ref Type[] parameterTypes, ref int[] parameterSizes, ref object[] parameterValues)
        {
            SQLParamCondition paramCondition = (SQLParamCondition)condition;
            int length = paramCondition.Parameters.Length;
            parameterNames = new string[length];
            parameterTypes = new Type[length];
            parameterSizes = new int[length];
            parameterValues = new object[length];


            for (int i = 0; i < paramCondition.Parameters.Length; i++)
            {
                parameterNames[i] = paramCondition.Parameters[i].Name;
                parameterTypes[i] = paramCondition.Parameters[i].Type;
                parameterSizes[i] = paramCondition.Parameters[i].Size;
                parameterValues[i] = paramCondition.Parameters[i].Value;
            }

            //ArrayList parameterNames = new ArrayList(length);
            //ArrayList parameterTypes = new ArrayList(length);
            //ArrayList parameterValues = new ArrayList(length);
            //foreach (SQLParameter parm in paramCondition.Parameters)
            //{
            //    parameterNames.Add(parm.Name);
            //    parameterTypes.Add(parm.Type);
            //    parameterValues.Add(parm.Value);
            //}
        }
    }
}
