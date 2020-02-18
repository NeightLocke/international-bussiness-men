using InternationalBusinessBaseTracing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessBaseTracing
{
    public class Log4NetTracing : ITracing
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Warning(string message)
        {
            log.Warn(message);
        }
    }
}