using NLog.Fluent;
using SimpleDI.Models;
using SimpleDI.Services.Authorize;
using SimpleDI.Services.WriteLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.SendSMS
{
    public class SendSMS: ISendSMS
    {
        private readonly IWriteLog _log;
        
        public SendSMS(IWriteLog log)
        {
            _log = log;
        }

        public void SendAnSMSMessage(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
            _log.WriteLogMessage($"{message} has been sent");
        }
    }
    
}
