using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessDTOs
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public string Sku;

        [DataMember]
        public double Amount;

        [DataMember]
        public string Currency;
    }
}