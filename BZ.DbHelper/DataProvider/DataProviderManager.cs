
using BZ.DbHelper.Interface;
using BZ.DbHelper.PersistBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.DataProvider
{
    /// <summary>
    /// DomainDataProviderManager 的摘要说明。
    /// </summary>
    public class DataProviderManager
    {
        public DataProviderManager()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }



        public static IDataProvider DataProvider()
        {
            return DataProvider(null, new System.Globalization.CultureInfo("en-US", false));
        }

        public static IDataProvider DataProvider(System.Globalization.CultureInfo cultureInfo)
        {
            return DataProvider(null, cultureInfo);
        }

        public static IDataProvider DataProvider(DBType type)
        {
            return DataProvider(PersistBrokerFactory.PersistBroker(type), new System.Globalization.CultureInfo("en-US", false));
        }

        public static IDataProvider DataProvider(DBType type, string connectString)
        {
            return DataProvider(PersistBrokerFactory.PersistBroker(type, connectString), new System.Globalization.CultureInfo("en-US", false));
        }

        public static IDataProvider DataProvider(IPersistBroker persistBroker, System.Globalization.CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            }
            if (persistBroker == null)//目前只返回sqlserver的privider
            {
                return new SQLDataProvider(PersistBrokerFactory.PersistBroker(cultureInfo),cultureInfo);
            }
            else
            {
                return new SQLDataProvider(persistBroker, cultureInfo);
            }
        }
    }
}
