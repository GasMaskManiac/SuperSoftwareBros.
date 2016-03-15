using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Three_Amigos.Models
{
    public class TemporaryDealersCategoriesModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int AvailableProductCount { get; set; }
    }
}