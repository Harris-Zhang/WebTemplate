using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper
{
    /// <summary>
    /// SQL 类型
    /// </summary>
    public enum SQLType
    {
        Text,
        Command,
        StoredProcedure
    }
    /// <summary>
    /// Direction 类型
    /// </summary>
    public enum DirectionType
    {
        Input,
        InputOutput,
        Output,
        ReturnValue
    }

    /// <summary>
    /// 连接到不同数据库
    /// </summary>
    public enum DBType
    {
        //DBType 表示连接到不同的数据库
         
        /// <summary>
        /// OraclePersistBroker
        /// </summary>
        Oracle,

        /// <summary>
        /// MSSqlPersistBroker
        /// </summary>
        SqlServer,

        /// <summary>
        /// AccessPersistBroker
        /// </summary>
        Access,

        /// <summary>
        /// SQLitePersistBroker
        /// </summary>
        SQLite,

        /// <summary>
        /// MySqlPersistBroker
        /// </summary>
        MySql
    }
}
