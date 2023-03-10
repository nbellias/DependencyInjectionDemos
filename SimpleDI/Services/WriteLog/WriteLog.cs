using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.WriteLog
{
    public class WriteLog: IWriteLog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public WriteLog()
        {
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("NLog.config");
        }

        public void WriteLogMessage(string message)
        {
            try
            {
                logger.Info("Writing Log: " + message);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An unhandled exception occurred");
            }
            
        }

        public void ShutdownLogManager()
        {
            logger.Info("Shuting down log manager...done");
            LogManager.Shutdown();
        }
    }
}
