using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI.Services.WriteLog
{
    public interface IWriteLog
    {
        public void WriteLogMessage(string message);
    }
}
