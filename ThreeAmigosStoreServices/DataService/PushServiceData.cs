using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using System.Net.Http.Formatting;

namespace ThreeAmigosStoreServices.DataService
{
    class PushServiceData
    {
        public void PushProducts()
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


            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000)
            {
                HttpResponseMessage davisonResponse = DavisonStore.GetAsync("api/Product").Result;
                if (davisonResponse.IsSuccessStatusCode)
                {
                    try {
                       // DavisonProducts = davisonResponse.Content.ReadAsAsync<IEnumerable<ThreeAmigosService.Models.ProductModel>>().Result; // If It Was A Success Grab All The Products
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Could not connect to Davison Service" + e);
                    }
                }
            }
        }
    }
}
