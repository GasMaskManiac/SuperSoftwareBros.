using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Three_Amigos.Contracts
{
    [DataContract]
    public class DTOOrder
    {
        [DataMember]
        public int AccountName { get; set; }
        [DataMember]
        public int CardNumber { get; set; }
        [DataMember]
        public int ExtensionData { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductEan { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ProductName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int TotalPrice { get; set; }
        [DataMember]
        public int When { get; set; }
    }
}