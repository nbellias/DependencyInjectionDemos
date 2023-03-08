using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.SendEmail
{
    public interface ISendEmail
    {
        public void SendAnEmailMessage(string message);
    }
}
