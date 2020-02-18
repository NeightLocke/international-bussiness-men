using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessFileManager.Interfaces
{
    public interface IDataProvider
    {
        string GetDataFromUri(string endpoint);
    }
}
