﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDI.Services.SendEmail;
using SimpleDI.Services.SendSMS;

namespace SimpleDI.ServiceUsage
{
    public class InformUseService
    {
        private readonly ISendEmail _emailService;
        private readonly ISendSms _smsService;

        public InformUseService(ISendEmail emailService, ISendSms smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        public void InformWithEmailAndSMS(string message)
        {
            Parallel.Invoke(() => _emailService.SendAnEmailMessage(message), () => _smsService.SendAnSmsMessage(message));
        }
    }
}
