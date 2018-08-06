using BZ.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BZ.DbHelper.DataProvider
{

    /// <summary>
    /// SQL 查询参数
    /// </summary>
    /// <example>
    ///	StringBuilder sql = new StringBuilder();
    /// sql.Append(" INSERT INTO [TableName]");
    /// sql.Append("   (Field1, Field2, Field3, Field4)");
    /// sql.Append(" VALUES");
    /// sql.Append("   ($Field1, $Field2, $Field3, $Field4)");
    ///
    /// SQLParameter[] parms ={
    ///                           new SQLParameter("Field1",typeof(string), Value1 ),
    ///                           new SQLParameter("Field2",typeof(string), Value2 ),
    ///                           new SQLParameter("Field3",typeof(string), Value3 ),
    ///                           new SQLParameter("Field4",typeof(string), Value4 ),
    ///                      };
    /// int result = DB.CustomExecuteWithReturn(new SQLParamCondition(sql.ToString(), parms));
    /// </example>
    [Serializable]
    public class SQLParameter
    {
        private string _name;
        private Type _type;
        private int _size;
        private DirectionType _direction;
        private object _value;


        /// <summary>
        /// SQL查询参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="type">类型</param>
        /// <param name="value">值</param>
        public SQLParameter(string name, Type type, object value)
        {
            this._name = name;
            this._type = type;
            this._size = -1;
            this._direction = DirectionType.Input;
            this._value = value;
        }

        public SQLParameter(string name, Type type, int size, object value)
        {
            this._name = name;
            this._type = type;
            this._size = size;
            this._direction = DirectionType.Input;
            this._value = value;

        }

        public SQLParameter(string name, Type type, DirectionType direction, object value)
        {
            this._name = name;
            this._type = type;
            this._size = -1;
            this._direction = direction;
            this._value = value;
        }

        public SQLParameter(string name, Type type, int size, DirectionType direction, object value)
        {
            this._name = name;
            this._type = type;
            this._size = size;
            this._direction = direction;
            this._value = value;
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        public Type Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
        /// <summary>
        /// 参数长度
        /// </summary>
        public int Size
        {
            get { return this._size; }
            set { this._size = value; }
        }


        /// <summary>
        /// 参数方向
        /// </summary>
        public DirectionType Direction
        {
            get
            {
                return this._direction;
            }
            set
            {
                this._direction = value;
            }
        }


    }

    /// <summary>
    /// SQL 查询条件
    /// </summary>
    [Serializable]
    public class Condition
    {
        private SQLType _sqlType = SQLType.Text;
        private string _sql = string.Empty;
        public Condition()
        {
            _sqlType = SQLType.Text;
        }

        public Condition(SQLType sqlType)
        {
            _sqlType = sqlType;
        }
        /// <summary>
        /// SQL语句
        /// </summary>
        public virtual string SQLText
        {
            get { return _sql; }
            set { _sql = value; }
        }
        /// <summary>
        /// SQL语句类型
        /// </summary>
        public SQLType SQLType
        {
            get { return _sqlType; }
        }
    }

    /// <summary>
    /// 完整SQL条件,没有参数
    /// </summary>
    /// <example>
    /// int result = 
    ///		this.DataProvider.GetCount(new SQLCondition("SELECT COUNT(*) FROM TableName WHERE 1=1 "));
    /// </example>
    [Serializable]
    public class SQLCondition : Condition
    {
        /// <summary>
        /// 完整SQL条件
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public SQLCondition(string sql)
            : base(SQLType.Text)
        {
            this.SQLText = sql;
        }
    }

    /// <summary>
    /// SQL 查询参数和条件组合
    /// </summary>
    /// <example>
    /// SQLParameter[] parms ={
    ///                          new SQLParameter("Field1",typeof(string),Value1)
    ///                      };
    /// DataSet ds = DB.CustomDataSet(new SQLParamCondition("SELECT FieldNames FROM TableName WHERE Field1=$Field1", parms));
    /// return ds.Tables[0];
    /// </example>
    [Serializable]
    public class SQLParamCondition : Condition
    {
        private SQLParameter[] _parameters;

        /// <summary>
        /// SQL 查询参数和条件组合
        /// </summary>
        /// <param name="sql">带参数的SQL语句</param>
        /// <param name="parameters">参数列表</param>
        public SQLParamCondition(string sql, SQLParameter[] parameters)
            : base(SQLType.Command)
        {
            this.SQLText = sql;
            this._parameters = parameters;
        }

        /// <summary>
        /// 参数列表
        /// </summary>
        public SQLParameter[] Parameters
        {
            get { return this._parameters; }
        }
    }

    /// <summary>
    /// SQL 分页和参数组合(不带参数$)
    /// </summary>
    /// <example>
    /// DataSet ds = DB.CustomDataSet(new PagerCondition("SELECT FieldNames FROM TableName WHERE 1=1",1,20));
    /// </example>
    [Serializable]
    public class PagerCondition : Condition
    {

        /// <summary>
        /// SQL 分页和参数组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="group">是否有没有Group By子句</param>
        public PagerCondition(string sql, int inclusive, int exclusive, bool group)
            : base(SQLType.Text)
        {
            this.BuildPagerSql(sql, inclusive, exclusive, group);
        }

        /// <summary>
        /// SQL 分页和参数组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="orderbyFields">有Group By子句时，order by要用取出的结果集的字段名</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="group">是否有没有Group By子句</param>
        public PagerCondition(string sql, string orderbyFields, int inclusive, int exclusive, bool group)
            : base(SQLType.Text)
        {
            this.BuildPagerSql(sql, orderbyFields, inclusive, exclusive, group);
        }

        /// <summary>
        /// SQL 分页和参数组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        public PagerCondition(string sql, int inclusive, int exclusive)
            : this(sql, inclusive, exclusive, false)
        {
        }

        /// <summary>
        /// SQL 分页和参数组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="orderbyFields">有Group By子句时，order by要用取出的结果集的字段名</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        public PagerCondition(string sql, string orderbyFields, int inclusive, int exclusive)
            : this(sql, orderbyFields, inclusive, exclusive, false)
        {
        }

        private void BuildPagerSql(string sql, int inclusive, int exclusive, bool group)
        {
            if (!group)
            {
                this.SQLText = sql.Trim().Remove(0, 6);

                if (this.SQLText.Trim().StartsWith("*"))
                {
                    throw new Exception("SELECT中,[*]禁止使用");
                }

                this.SQLText = string.Format("select * from (select rownum as rid,{0}) tb where rid between {1} and {2}",
                    this.SQLText,
                    inclusive.ToString(),
                    exclusive.ToString());
            }
            else
            {
                this.SQLText = string.Format("select * from (select rownum as rid, result.* from ({0}) result) as a where rid between {1} and {2}",
                    sql,
                    inclusive.ToString(),
                    exclusive.ToString());
            }

        }
        /// <summary>
        /// 自动Build分页SQL语句
        /// </summary>
        /// <param name="sql">不带条件的SQL</param>
        /// <param name="orderbyFields">排序字段</param>
        /// <param name="inclusive">起始记录号</param>
        /// <param name="exclusive">结束记录号</param>
        /// <param name="group">是否有没有Group By子句</param>
        private void BuildPagerSql(string sql, string orderbyFields, int inclusive, int exclusive, bool group)
        {
            string LeadingTable = GetLeadingSql(sql);//获取Leading 的表名称
            if (!group)
            {
                this.SQLText = sql.Trim().Remove(0, 6);

                if (this.SQLText.Trim().StartsWith("*"))
                {
                    throw new Exception("SELECT中,[*]禁止使用");
                }
                this.SQLText = string.Format(@"select * from (select /*+ leading({4}) */  ROW_NUMBER() OVER (ORDER BY {0}) as rid,zh.* from( select{1} )zh) tb where rid between {2} and {3}",
                                                            orderbyFields,
                                                            this.SQLText,
                                                            inclusive.ToString(),
                                                            exclusive.ToString(),
                                                            LeadingTable);
            }
            else
            {
                this.SQLText = string.Format(@"select * from (select /*+ leading({4}) */  ROW_NUMBER() OVER (ORDER BY {0}) as rid, result.* from ({1}) result) tb where rid between {2} and {3}",
                                            orderbyFields,
                                            sql,
                                            inclusive.ToString(),
                                            exclusive.ToString(),
                                            LeadingTable);
            }
        }
        /// <summary>
        ///获取Leading 的表名称
        ///添加此方法的原因	:	数据表分区后连接查询出现错误,必须指定连接首表  /*+ leading(tblitem) */
        ///解决方法			:	指定连接表名
        ///获取方法			:	获取第一个from后面的表名作为首连接表
        ///注意				:	此方法只是适用以上情况,最好的做法是首连接表是作为参数传入的
        ///修改				:	判断是否能够取得空格的index
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns>转化后的SQL</returns>
        private string GetLeadingSql(string sql)
        {
            string[] splitSTR = Regex.Split(sql, "from", RegexOptions.IgnoreCase);
            string afterFromStr = splitSTR[1].Trim();
            int index = afterFromStr.IndexOf(' ', 0, afterFromStr.Length);

            string LeadingtableName = afterFromStr;
            if (index >= 0)
            {
                LeadingtableName = afterFromStr.Substring(0, index);
            }

            return LeadingtableName;
        }
    }

    /// <summary>
    /// SQL 分页和参数组合(带参数$)
    /// </summary>
    [Serializable]
    public class PagerParamCondition : SQLParamCondition
    {
        /// <summary>
        /// SQL 参数、分页组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="parameters">参数列表</param>
        public PagerParamCondition(string sql, int inclusive, int exclusive, SQLParameter[] parameters)
            : base(sql, parameters)
        {
            this.SQLText = new PagerCondition(sql, inclusive, exclusive).SQLText;
        }
        /// <summary>
        /// SQL 参数、分页组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="orderbyFields">有Group By子句时，order by要用取出的结果集的字段名</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="parameters">参数列表</param>
        public PagerParamCondition(string sql, string orderbyFields, int inclusive, int exclusive, SQLParameter[] parameters)
            : base(sql, parameters)
        {
            this.SQLText = new PagerCondition(sql, orderbyFields, inclusive, exclusive).SQLText;
        }

        /// <summary>
        /// SQL 参数、分页组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="group">是否有没有Group By子句</param>
        public PagerParamCondition(string sql, int inclusive, int exclusive, SQLParameter[] parameters, bool group)
            : base(sql, parameters)
        {
            this.SQLText = new PagerCondition(sql, inclusive, exclusive, group).SQLText;
        }

        /// <summary>
        /// SQL 参数、分页组合
        /// </summary>
        /// <param name="sql">查询数据的SQL语句</param>
        /// <param name="orderbyFields">有Group By子句时，order by要用取出的结果集的字段名</param>
        /// <param name="inclusive">起始记录行</param>
        /// <param name="exclusive">读取行数</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="group">是否有没有Group By子句</param>
        public PagerParamCondition(string sql, string orderbyFields, int inclusive, int exclusive, SQLParameter[] parameters, bool group)
            : base(sql, parameters)
        {
            this.SQLText = new PagerCondition(sql, orderbyFields, inclusive, exclusive, group).SQLText;
        }
    }



    /// <summary>
    /// Procedure执行(不需要传递参数)
    /// </summary>
    public class ProcedureCondition : Condition
    {
        public ProcedureCondition(string Procedure)
            : base(SQLType.StoredProcedure)
        {
            this.SQLText = Procedure;
        }
    }

    /// <summary>
    /// Procedure 查询参数和条件组合
    /// </summary>
    /// <example>
    /// SQLParameter[] parm ={
    ///                            new SQLParameter("p_userid",typeof(string),10,DirectionType.Input,"a123457"),
    ///                            new SQLParameter("p_value",typeof(string),10,DirectionType.Input,"4321"),
    ///                            new SQLParameter("p_username",typeof(string),10,DirectionType.Output,"a123457"),
    ///                            new SQLParameter("p_sumtotal",typeof(string),-1,DirectionType.InputOutput,21)
    ///                        };
    /// Condition sc = new ProcedureParamCondition("p_test02", parm);
    /// DB.CustomProcedure(ref sc);
    /// </example>
    [Serializable]
    public class ProcedureParamCondition : Condition
    {
        private SQLParameter[] _parameters;

        /// <summary>
        /// Procedure 查询参数和条件组合
        /// </summary>
        /// <param name="sql">带参数的SQL语句</param>
        /// <param name="parameters">参数列表</param>
        public ProcedureParamCondition(string Procedure, SQLParameter[] parameters)
            : base(SQLType.StoredProcedure)
        {
            this.SQLText = Procedure;
            this._parameters = parameters;
        }

        /// <summary>
        /// 参数列表
        /// </summary>
        public SQLParameter[] Parameters
        {
            get
            {
                return this._parameters;
            }
            set
            {
                this._parameters = value;
            }
        }
    }
}
