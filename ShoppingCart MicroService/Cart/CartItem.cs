namespace ShoppingCart_MicroService.Cart
{
    public class CartItem
    {
        //The [Key] identifier allows the to be identified by the db as the Primary Key//
        //[Key]//
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
