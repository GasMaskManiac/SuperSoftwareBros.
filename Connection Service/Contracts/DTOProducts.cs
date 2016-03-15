using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Three_Amigos.Contracts
{
    [DataContract]
    public class DTOProducts
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int Description { get; set; }
        [DataMember]
        public string Ean { get; set; }
        [DataMember]
        public DateTime ExpectedRestock { get; set; }
        [DataMember]
        public string ExtensionData { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public bool InStock { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double PriceForOne { get; set; }
        [DataMember]
        public double PriceForTen { get; set; }


    }
}