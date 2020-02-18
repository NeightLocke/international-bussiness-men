using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessDTOs;
using InternationalBusinessFileManager.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessFileManager
{
    public class PersistentManager : IPersistentManager
    {
        private readonly ITracing _myTracing;

        public PersistentManager(ITracing myTracing)
        {
            this._myTracing = myTracing;
        }

        public void Write(object instance)
        {
            try
            {
                _myTracing.Debug(string.Format("{0} --- {1}", nameof(PersistentManager), nameof(Write)));
                string directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (instance is IEnumerable<Rates> rateList)
                {
                    using (StreamWriter file = File.CreateText(directoryPath + @"/rates.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, rateList);
                    }
                }
                else if (instance is IEnumerable<Transaction> transactionList)
                {
                    using (StreamWriter file = File.CreateText(directoryPath + @"/transactions.json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, transactionList);
                    }
                }
            }
            catch (Exception ex)
            {
                _myTracing.Error(string.Format("Error when the data had been saving in disk : {0}", ex.Message));
            }
        }
    }
}