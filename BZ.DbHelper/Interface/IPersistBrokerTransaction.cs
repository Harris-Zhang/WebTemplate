using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.Interface
{
    public interface IPersistBrokerTransaction
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        bool IsInTransaction { get; }
    }
}
