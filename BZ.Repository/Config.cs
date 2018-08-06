using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace BZ.Repository
{
    public class Config
    {
        private static string connectionString;
        /// <summary>
        /// 默认数据库路径
        /// </summary>
        public static string ConnectionString
        {
            get {
                connectionString = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                return Config.connectionString; 
            }
            
        }

        private static string erpConnectionString;
        /// <summary>
        /// ERP数据库路径
        /// </summary>
        public static string ErpConnectionString
        {
            get
            {
                erpConnectionString = System.Configuration.ConfigurationManager.AppSettings["ErpConnectionString"].ToString();
                return Config.erpConnectionString;
            }

        }
  
    }
}
