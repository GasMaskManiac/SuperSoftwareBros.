using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_MicroService
{
    class CartActions
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionId = "CartId";

        public void AddToCart(int id, int quantity)
        {
            // Add item to the cart collection
            // Find item by Id in products collection
            // Add quantity passed in to the collection also
            // Add individual price, times price by quantity
            // bulk discount
        }

        public void RemoveItem(int id)
        {
            // Find item in the cart collection by id
            // Remove product from collection
        }

        public decimal TotalCost()
        {
            // Sum of product price * quantity

        }
    }
}
