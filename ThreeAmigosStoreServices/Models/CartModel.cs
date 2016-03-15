using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigosStoreServices.Models
{
    class CartModel
    {
        int ProductID { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
    }
}
