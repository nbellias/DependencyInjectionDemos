using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.SendSMS
{
    public interface ISendSMS
    {
        public void SendAnSMSMessage(string message);
    }
}
