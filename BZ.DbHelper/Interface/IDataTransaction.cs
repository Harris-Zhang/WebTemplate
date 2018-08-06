using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.Interface
{
    public interface IDataTransaction
    {
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();
    }
}
