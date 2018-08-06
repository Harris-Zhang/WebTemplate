using BZ.DbHelper;
using BZ.DbHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.PersistBroker
{
    public class PersistBrokerFactory
    {
        public PersistBrokerFactory()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        private static string connectionString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"].ToString();

        public static IPersistBroker PersistBroker()
        {
            return PersistBroker(new System.Globalization.CultureInfo("en-US", false));
        }

        public static IPersistBroker PersistBroker(System.Globalization.CultureInfo cultureInfo)
        {
            return PersistBroker(DBType.SqlServer, connectionString, cultureInfo);
        }

        public static IPersistBroker PersistBroker(DBType type)
        {
            return PersistBroker(type, connectionString);
        }

        public static IPersistBroker PersistBroker(DBType type, string connectString)
        {
            return PersistBroker(type, connectString, new System.Globalization.CultureInfo("en-US", false));
        }

        public static IPersistBroker PersistBroker(DBType type, string connectString, System.Globalization.CultureInfo cultureInfo)
        {

            switch (type)
            {
                case DBType.SqlServer:
                    return new MSSqlPersistBroker(connectString, cultureInfo);
                case DBType.Oracle:
                    return new OraclePersistBroker(connectString, cultureInfo);
                case DBType.Access:
                    return new AccessPersistBroker(connectString, cultureInfo);
                case DBType.SQLite:
                    return new SQLitePersistBroker(connectString, cultureInfo);
                case DBType.MySql:
                    throw new Exception("MySql数据库连接未实现，请先实现MySql数据库代码");
                default:
                    throw new Exception("未知的数据库类型");
            }
        }
    }
}
