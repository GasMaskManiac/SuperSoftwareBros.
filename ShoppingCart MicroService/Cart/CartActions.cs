using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_MicroService.Cart
{
    class CartActions
    {
        public string ShoppingCartId { get; set; }

        public const string CartSessionId = "CartId";

        private List<CartItem> CartItem = new List<CartItem>(); 

        public void AddToCart(int id, int quantity)
        {
            CartItem item = CartItem.FirstOrDefault(p => p.Product.AmigosProductID == id);

            if (item == null)
            {
                CartItem.Add(new CartItem{ProductId = id, Quantity = quantity});
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(int id)
        {
            // Find item in the cart collection by id
            // Remove product from collection

            CartItem.RemoveAll(i => i.Product.AmigosProductID == id);
        }

        public void Clear()
        {
            // Remove all items from the cart collection
            CartItem.Clear();
        }

        public IEnumerable<CartItem> Items
        {
            get { return CartItem; }
        }

        public double TotalCost()
        {
            // Sum of product price * quantity
            return CartItem.Sum(i => i.Product.ProductPrice*i.Quantity);
            
        }


    }
}
