using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using ConnectionService.Connections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Three_Amigos.Models;

namespace Unit_test
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void davisonTest()
        {
            DavisonService davison = new DavisonService();

            Assert.IsInstanceOfType(davison, typeof(HttpClient));
        }
        [TestMethod]
        public void cuttersTest()
        {
            CuttersService cutters = new CuttersService();

            Assert.IsInstanceOfType(cutters, typeof(HttpClient));
        }
        [TestMethod]
        public void dealersTest()
        {
            DealersService dealers = new DealersService();

            Assert.IsInstanceOfType(dealers, typeof(HttpClient));
        }
        [TestMethod]
        public void kwikiTest()
        {
            KwikiService kwiki = new KwikiService();
            Assert.IsInstanceOfType(kwiki, typeof(HttpClient));
        }
        [TestMethod]
        public void _3AmigoTest()
        {
            _3AmigoService _3Amigo = new _3AmigoService();

            Assert.IsInstanceOfType(_3Amigo, typeof(SqlConnection));
        }
        [TestMethod]
        public void davisonConnectionTest()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage davisonResponse;

            var DavisonProducts = new List<TemporaryDavisonProductModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Products").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonProducts = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonProductModel>>().Result;
            }

            Assert.IsNotNull(DavisonProducts);

            var DavisonCategories = new List<TemporaryDavisonCategoriesModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Categories").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonCategories = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonCategoriesModel>>().Result;
            }

            Assert.IsNotNull(DavisonCategories);

            var DavisonBrands = new List<TemporaryDavisonBrandModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Brands").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonBrands = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonBrandModel>>().Result;
            }

            Assert.IsNotNull(DavisonBrands);
        }
        [TestMethod]
        public void davisonProductTest()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage davisonResponse;

            var DavisonProducts = new List<TemporaryDavisonProductModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Products").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonProducts = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonProductModel>>().Result;
            }

            var aProduct = DavisonProducts.FirstOrDefault();

            Assert.IsInstanceOfType(aProduct, typeof(TemporaryDavisonProductModel));
            Assert.IsNotNull(aProduct);
        }
        [TestMethod]
        public void davisonCategoryTest()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage davisonResponse;

            var DavisonCategories = new List<TemporaryDavisonCategoriesModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Categorys").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonCategories = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonCategoriesModel>>().Result;
            }

            var aCategory = DavisonCategories.FirstOrDefault();

            Assert.IsInstanceOfType(aCategory, typeof(TemporaryDavisonCategoriesModel));
            Assert.IsNotNull(aCategory);
        }
        [TestMethod]
        public void davisonBrandTest()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage davisonResponse;

            var DavisonBrands = new List<TemporaryDavisonBrandModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Brands").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonBrands = davisonResponse.Content.ReadAsAsync<IEnumerable<TemporaryDavisonBrandModel>>().Result;
            }

            var aBrand = DavisonBrands.FirstOrDefault();

            Assert.IsInstanceOfType(aBrand, typeof(TemporaryDavisonCategoriesModel));
            Assert.IsNotNull(aBrand);
        }

        //[TestMethod]
        //public void something()
        //{
        //    HttpClient davisonStore = new HttpClient();
        //    davisonStore.BaseAddress = new System.Uri("http://davisonstore.azurewebsites.net/");
        //    davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

        //    HttpResponseMessage davisonResponse;

        //    var DavisonBrands = new List<Three_Amigos.Models.TemporaryDavisonBrandModel>().AsEnumerable();
        //    davisonResponse = davisonStore.GetAsync("api/Brands").Result;
        //    if (davisonResponse.IsSuccessStatusCode)
        //    {
        //        DavisonBrands = davisonResponse.Content.ReadAsAsync<IEnumerable<Three_Amigos.Models.TemporaryDavisonBrandModel>>().Result;
        //    }

        //    string search = "whatever your searching";

        //    string result = (ViewResult) controller.Menu(search);

        //    Assert.Equals(search, result);
        //}


    }
}
