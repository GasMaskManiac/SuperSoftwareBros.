using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_MicroService.Cart
{
    class CartActions
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionId = "CartId";

        private List<CartItem> CartList = new List<CartItem>(); 

        public void AddToCart(int id, int quantity)
        {
            
            // Add item to the cart collection
            // Find item by Id in products collection
            // Add quantity passed in to the collection also
            // Add individual price, times price by quantity
            // bulk discount
        }

        public void RemoveItem(int id, int quantity)
        {
            // Find item in the cart collection by id
            // Remove product from collection
            // if no quantity is specified, remove 1
        }

        public IEnumerable<CartItem> Items
        {
            get { return CartList; }
        }

        public decimal TotalCost()
        {
            return 0;
            // Sum of product price * quantity
        }


    }
}
