using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigosStoreServices.Models
{
    public class ProductModel
    {
        public int StoreID { get; set; }
        public int StoreProductID { get; set; }
        public int AmigosProductID { get; set; }
        public string EAN { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductPriceForOne { get; set; }
        public decimal ProductPriceForTen { get; set; }
        public Nullable<bool> InStock { get; set; }
        public Nullable<DateTime> ExpectedRestock { get; set; }
        public Nullable<bool> Active { get; set; }
        public decimal StorePrice { get; set; }
      
    }
}
