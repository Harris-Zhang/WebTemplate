using BZ.DbHelper;
using BZ.DbHelper.DataProvider;
using BZ.DbHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ.Repository
{
    public class BaseRep
    {

        protected static IDataProvider DB = DataProviderManager.DataProvider(DBType.SqlServer,Config.ConnectionString);

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTransaction()
        {
            DB.BeginTransaction();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            DB.CommitTransaction();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            DB.RollbackTransaction();
        }
        public void Dispose() { }
    }
}
