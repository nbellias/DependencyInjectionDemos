using SimpleDI.Models;
using SimpleDI.Services.Authorize;
using SimpleDI.Services.WriteLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.SendEmail
{
    public class SendEmail : ISendEmail
    {
        private readonly IWriteLog _log;
        public SendEmail(IWriteLog log)
        {
            _log = log;
        }

        public void SendAnEmailMessage(string message)
        {
            Console.WriteLine("Sending Email: " + message);
            _log.WriteLogMessage($"{message} has been sent");
        }
    }

}
