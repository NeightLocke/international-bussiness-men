using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessDTOs
{
    [DataContract]
    public class Rates
    {
        [DataMember]
        public string From;

        [DataMember]
        public string To;

        [DataMember]
        public double Rate;
    }
}