using BZ.DbHelper.DataProvider; 
using System;
using System.Data;
using System.Text;

namespace BZ.Repository.admin
{
    public class AppVersionRep : BaseRep,IDisposable
    {
        /// <summary>
        /// 获取app最新版本号
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewAppVersion()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.AppendLine("SELECT CREATE_TIME, VERSION_CODE, VERSION_DESC, APP_URL, APP_NAME");
            sqlstr.AppendLine("  FROM APP_VERSION_UPDATE");
            sqlstr.AppendLine(" WHERE IS_ABLED = 'Y'"); 
            DataSet ds = DB.CustomDataSet(new SQLCondition(sqlstr.ToString()));
            return ds.Tables[0];
        }
         

    }
}


