using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDI.Services.SendEmail;
using SimpleDI.Services.SendSMS;

namespace SimpleDI.ServiceUsage
{
    public class Inform
    {
        private readonly ISendEmail _emailService;
        private readonly ISendSMS _smsService;

        public Inform(ISendEmail emailService, ISendSMS smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        public void InformWithEmailAndSMS(string message)
        {
            Parallel.Invoke(() => _emailService.SendAnEmailMessage(message), () => _smsService.SendAnSMSMessage(message));
        }
    }
}
