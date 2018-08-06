using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BZ.DbHelper.Interface
{
    public interface IDataProvider : IDataTransaction, IDataQuery
    {
        /// <summary>
        /// 是否支持手动关闭连接
        /// 是否 自动关闭连接
        /// </summary>
        bool AutoCloseConnection
        {
            get;
            set;
        }
    }
}
