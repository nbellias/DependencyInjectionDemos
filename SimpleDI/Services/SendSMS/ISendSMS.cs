using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.SendSMS
{
    public interface ISendSms
    {
        public void SendAnSmsMessage(string message);
    }
}
