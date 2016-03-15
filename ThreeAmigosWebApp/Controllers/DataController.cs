using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConnectionService.Connections;
using ConnectionService;

namespace Three_Amigos.Controllers
{
    public class DataController : Controller
    {
        //Ignore Just Something I Was Trying Out Dunno How To Do This
        public void SetUpHttpConnections()
        {
            HttpClient DavisonStore = new HttpClient(); //Set Up DavisonStore Connection
            HttpClient UnderCutters = new HttpClient(); //Set Up UnderCutters Connection
            HttpClient DodgyDealers = new HttpClient(); //Set Up DodgyDealers Connection

            DavisonStore.BaseAddress = new System.Uri("http://davisonstore.azurewebsites.net/"); //Set Up DavisonStore URI http://davisonstore.azurewebsites.net/
            UnderCutters.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net/"); //Set Up UnderCutters URI http://undercutters.azurewebsites.net/
            DodgyDealers.BaseAddress = new System.Uri("http://dodgydealers.azurewebsites.net/"); //Set Up DodgyDealers URI http://dodgydealers.azurewebsites.net/

            DavisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up DavisonStore Parsing
            UnderCutters.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up UnderCutters Parsing
            DodgyDealers.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up DodgyDealers Parsing
        }

        /*
        public ActionResult Index()
        {

        }
        */

        // GET: Product
        public ActionResult Products()
        {

            var DavisonProducts = new List<ThreeAmigosStoreServices.Models.ProductModel>().AsEnumerable(); // Set Up Davison Collection
            var CuttersProducts = new List<ThreeAmigosStoreServices.Models.ProductModel>().AsEnumerable(); // Set Up Cutters Collection
            var DealersProducts = new List<ThreeAmigosStoreServices.Models.ProductModel>().AsEnumerable(); // Set Up Dealers Collection
            //var BazzarsProducts = new List<Models.TemporaryBazzarsProductModel>().AsEnumerable(); // Set Up Bazzars Collection

            HttpClient DavisonStore = new HttpClient(); //Set Up DavisonStore Connection
            HttpClient UnderCutters = new HttpClient(); //Set Up UnderCutters Connection
            HttpClient DodgyDealers = new HttpClient(); //Set Up DodgyDealers Connection


            DavisonStore.BaseAddress = new System.Uri("http://davisonstore.azurewebsites.net/"); //Set Up DavisonStore URI
            UnderCutters.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net/"); //Set Up UnderCutters URI
            DodgyDealers.BaseAddress = new System.Uri("http://dodgydealers.azurewebsites.net/"); //Set Up DodgyDealers URI

            DavisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up DavisonStore Parsing
            UnderCutters.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up UnderCutters Parsing
            DodgyDealers.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //Set Up DodgyDealers Parsing

            HttpResponseMessage davisonResponse = DavisonStore.GetAsync("api/Product").Result; // Set Up The Response Message For Getting The Content From The HttpClient
            if (davisonResponse.IsSuccessStatusCode) // Checks If The Response Was A Success
            {
                DavisonProducts = davisonResponse.Content.ReadAsAsync<IEnumerable<ThreeAmigosStoreServices.Models.ProductModel>>().Result; // If It Was A Success Grab All The Products
            }
            else
            {
                Debug.WriteLine("Could Not Get Davison Products"); // If It Wasnt A Success Tell The User
            }

            HttpResponseMessage CuttersResponse = UnderCutters.GetAsync("api/Product").Result; // Set Up The Response Message For Getting The Content From The HttpClient
            if (CuttersResponse.IsSuccessStatusCode) // Checks If The Response Was A Success
            {
                CuttersProducts = CuttersResponse.Content.ReadAsAsync<IEnumerable<ThreeAmigosStoreServices.Models.ProductModel>>().Result; // If It Was A Success Grab All The Products
            }
            else
            {
                Debug.WriteLine("Could Not Get Cutters Products"); // If It Wasnt A Success Tell The User
            }

            HttpResponseMessage DealersResponse = DodgyDealers.GetAsync("api/Product").Result; // Set Up The Response Message For Getting The Content From The HttpClient
            if (DealersResponse.IsSuccessStatusCode) // Checks If The Response Was A Success
            {
                DealersProducts = DealersResponse.Content.ReadAsAsync<IEnumerable<ThreeAmigosStoreServices.Models.ProductModel>>().Result; // If It Was A Success Grab All The Products
            }
            else
            {
                Debug.WriteLine("Could Not Get Dealers Products"); // If It Wasnt A Success Tell The User
            }

            var allProducts = new List<ThreeAmigosStoreServices.Models.ProductModel>(); // Create AllProducts Collection
            allProducts.AddRange(DavisonProducts.Select(p => new ThreeAmigosStoreServices.Models.ProductModel // Add Davison Products To AllProducts Collection
            {

            }));
            allProducts.AddRange(CuttersProducts.Select(p => new ThreeAmigosStoreServices.Models.ProductModel // Add Cutters Products To AllProducts Collection
            {
                StoreID = p.StoreID,
                StoreProductID = p.StoreProductID,
                AmigosProductID = p.AmigosProductID,
                EAN = p.EAN,
                CategoryID = p.CategoryID,
                CategoryName = p.CategoryName,
                BrandID = p.BrandID,
                BrandName = p.BrandName,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductPriceForOne = p.ProductPriceForOne,
                ProductPriceForTen = p.ProductPriceForTen,
                InStock = p.InStock,
                ExpectedRestock = p.ExpectedRestock,
                Active = p.Active
            }));
            allProducts.AddRange(DealersProducts.Select(p => new ThreeAmigosStoreServices.Models.ProductModel // Add Dealers Products To AllProducts Collection
            {
                StoreID = p.StoreID,
                StoreProductID = p.StoreProductID,
                AmigosProductID = p.AmigosProductID,
                EAN = p.EAN,
                CategoryID = p.CategoryID,
                CategoryName = p.CategoryName,
                BrandID = p.BrandID,
                BrandName = p.BrandName,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductPriceForOne = p.ProductPriceForOne,
                ProductPriceForTen = p.ProductPriceForTen,
                InStock = p.InStock,
                ExpectedRestock = p.ExpectedRestock,
                Active = p.Active
            }));

            return View(allProducts); // Return All The Products
        }

        //public ActionResult test()
        //{
        //    BazzarsBazaar.ServiceContractClient client = new BazzarsBazaar.ServiceContractClient();

        //    var categories = client.GetCategories();

        //    return View(categories);
        //}

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public void PushToDatabase()
        {
            ConnectionService.Connections._3AmigoService something = new _3AmigoService();
            something._3AmigoPushProducts();

            Debug.WriteLine("Yes");
            //ConnectionService.Connections._3AmigoService;
            //somehing.
            //ConnectionService.Connections._3AmigoService() something = new _3AmigoService();
            //something.
        }
    }
}