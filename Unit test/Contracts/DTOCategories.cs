using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Three_Amigos.Contracts
{
    [DataContract]
    public class DTOCategories
    {
        [DataMember]
        public int AvailableProductCount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}