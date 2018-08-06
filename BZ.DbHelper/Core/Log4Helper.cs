using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

[assembly: log4net.Config.DOMConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace BZ.DbHelper
{
    public class Log4Helper
    {
        private static ILog optLogger;
        private static ILog sqlLogger;
        private static string configFile = "log4net.config";

        static Log4Helper()
        {
            if (File.Exists(Log4NetConfigFile))
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    XmlConfigurator.ConfigureAndWatch(new FileInfo(Log4NetConfigFile));
                }
                else
                {
                    XmlConfigurator.Configure(new FileInfo(Log4NetConfigFile));
                }
            }
            else
            {
                BasicConfigurator.Configure();
            }
            //var repository = LogManager.GetRepository();
            //var appenders = repository.GetAppenders();
            //var targetApder = appenders.First(p => p.Name == "LogFileAppender") as RollingFileAppender;
            //targetApder.File = System.Web.HttpContext.Current.Server.MapPath("~/bin/LOGS/DBSQL/LOG");
            //targetApder.ActivateOptions();
            optLogger = log4net.LogManager.GetLogger("OPTLog");//GetLogger(typeof(Log4Helper));
            sqlLogger = log4net.LogManager.GetLogger("SQLLog");
        }

        #region Abbributes
        public static string Log4NetConfigFile
        {
            get
            {
                //return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configFile);
                //判断是Web程序还是window程序
                if (HttpContext.Current != null)
                {
                    //return Path.Combine(HttpRuntime.AppDomainAppPath, configFile);
                    return System.Web.HttpContext.Current.Server.MapPath("~/bin/" + configFile);
                }
                else
                {
                    return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), configFile);
                }
            }
        }

        public static ILog GetLogger(System.Type type)
        {
            return LogManager.GetLogger(type);
        }
        #endregion

        #region  记录执行操作日志 log type

        public static void Error(string message)
        {
            optLogger.Error(message);
        }

        public static void Warning(string message)
        {
            optLogger.Warn(message);
        }

        public static void Fatal(string message)
        {
            optLogger.Fatal(message);

        }

        public static void Info(string message)
        {
            optLogger.Info(message);
        }


        #endregion

        #region 执行SQL日志
        public static void SqlInfo(string message)
        {
            sqlLogger.Info(message);
        }

        public static void SqlError(string message)
        {
            sqlLogger.Error(message);
        }
        #endregion
        public static void ClearOldLogFiles(string keepDays)
        {
            int days = 0;
            int.TryParse(keepDays, out days);
            if (days <= 0)
            {
                return;
            }

            try
            {
                DateTime now = DateTime.Now;

                Hierarchy hierarchy = (Hierarchy)LogManager.GetLoggerRepository();
                foreach (IAppender appender in hierarchy.Root.Appenders)
                {
                    if (appender is RollingFileAppender)
                    {
                        string logPath = ((RollingFileAppender)appender).File;
                        DirectoryInfo dir = new DirectoryInfo(logPath.Substring(0, logPath.LastIndexOf("\\")));

                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (file.LastWriteTime < now.AddDays(-days))
                            {
                                file.Delete();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 记录执行SQL语句和执行SQL的时间
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">接收时间</param>
        public static void WriteSqlLogInfo(string sql, DateTime start, DateTime end)
        {
            TimeSpan span = end - start;
            Log4Helper.SqlInfo("************ SQL: " + sql);
            Log4Helper.SqlInfo("************ Start: " + start.ToString("yyyy/MM/dd HH:mm:ss") + "." + start.Millisecond.ToString("000")
                + ", End: " + end.ToString("yyyy/MM/dd HH:mm:ss") + "." + end.Millisecond.ToString("000")
                + ", Cost: " + span.TotalMilliseconds.ToString("0.000"));
            Log4Helper.SqlInfo("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// 记录执行SQL语句的异常
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="ex">异常</param>
        public static void WriteSqlLogError(string sql, Exception ex)
        {
            Log4Helper.SqlError("************ SQL: " + sql);
            Log4Helper.SqlError("************ exMessage: " + ex.Message);
            Log4Helper.SqlError("************ exStackTrace: " + ex.StackTrace);
            Log4Helper.SqlError("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

    }
}
