using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessBaseTracing.Interfaces
{
    public interface ITracing
    {
        void Debug(string message);

        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Fatal(string message);
    }
}