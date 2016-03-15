using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http;
using ThreeAmigosStoreServices.Models;

namespace ConnectionService.Connections
{
    public class _3AmigoService
    {
        public SqlConnection Get_3AmigoService()
        {
            string SQLConnectionString;

            SQLConnectionString = "Server=tcp:amigos.database.windows.net,1433;Database=3Amigo;User ID=HeadHoncho@amigos;Password={Doritos!};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection connection = new SqlConnection(SQLConnectionString);

            return connection;
        }

        public void _3AmigoPushProducts()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage davisonResponse;

            var DavisonProducts = new List<Three_Amigos.Models.TemporaryDavisonProductModel>().AsEnumerable();
            davisonResponse = davisonStore.GetAsync("api/Product").Result;
            if (davisonResponse.IsSuccessStatusCode)
            {
                DavisonProducts = davisonResponse.Content.ReadAsAsync<IEnumerable<Three_Amigos.Models.TemporaryDavisonProductModel>>().Result;
            }

            var allProducts = new List<ThreeAmigosStoreServices.Models.ProductModel>();
            allProducts.AddRange(DavisonProducts.Select(p => new ProductModel
            {
                StoreID = 1,
                StoreProductID = p.Id,
                EAN = p.Ean,
                CategoryID = p.CategoryId,
                CategoryName = p.CategoryName,
                BrandID = p.BrandId,
                BrandName = p.BrandName,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductPriceForOne = p.Price,
                ProductPriceForTen = p.Price * 10,
            }));

            HttpClient cuttersStore = new HttpClient();
            cuttersStore.BaseAddress = new Uri("http://undercutters.azurewebsites.net/");
            cuttersStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            HttpResponseMessage cuttersResponse;

            var CuttersProducts = new List<Three_Amigos.Models.TemporaryCuttersProductModel>().AsEnumerable();
            cuttersResponse = cuttersStore.GetAsync("api/Product").Result;
            if (cuttersResponse.IsSuccessStatusCode)
            {
                CuttersProducts = cuttersResponse.Content.ReadAsAsync<IEnumerable<Three_Amigos.Models.TemporaryCuttersProductModel>>().Result;
            }

            allProducts.AddRange(CuttersProducts.Select(p => new ProductModel
            {
                StoreID = 2,
                StoreProductID = p.Id,
                EAN = p.Ean,
                CategoryID = p.CategoryId,
                CategoryName = p.CategoryName,
                BrandID = p.BrandId,
                BrandName = p.BrandName,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductPriceForOne = p.Price,
                ProductPriceForTen = p.Price * 10,
                InStock = p.InStock,
                ExpectedRestock = p.ExpectedRestock,
            }));

            HttpClient dealersClient = new HttpClient();
            dealersClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            dealersClient.BaseAddress = new Uri("http://dodgydealers.azurewebsites.net/");

            HttpResponseMessage dealersResponse;

            var DealersProduct = new List<Three_Amigos.Models.TemporaryDealersProductModel>().AsEnumerable();
            dealersResponse = dealersClient.GetAsync("api/Product").Result;
            if (dealersResponse.IsSuccessStatusCode)
            {
                DealersProduct = dealersResponse.Content.ReadAsAsync<IEnumerable<Three_Amigos.Models.TemporaryDealersProductModel>>().Result;
            }

            allProducts.AddRange(DealersProduct.Select(p => new ProductModel
            {
                StoreID = 3,
                StoreProductID = p.Id,
                EAN = p.Ean,
                CategoryID = p.CategoryId,
                CategoryName = p.CategoryName,
                BrandID = p.BrandId,
                BrandName = p.BrandName,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductPriceForOne = p.Price,
                ProductPriceForTen = p.Price * 10,
                InStock = p.InStock,
                ExpectedRestock = p.ExpectedRestock,
                
            }));

            try
            {
                string SQLConnectionString;

                SQLConnectionString = "Server=tcp:amigos.database.windows.net,1433;Database=3Amigo;User ID=HeadHoncho@amigos;Password=Doritos!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlConnection connection = new SqlConnection(SQLConnectionString);

                var command = connection.CreateCommand();
                string commandString;
                commandString = string.Format(" INSERT INTO dbo.AllProducts VALUES (@StoreId, @ProductId, @Ean, @CategoryId, @CategoryName, @BrandId, @BrandName, @Description, @Price, @PriceForOne, @PriceForTen, @InStock, @ExpectedRestock, @StorePrice, @Active)");
                //commandString = string.Format(" INSERT INTO dbo.AllProducts VALUES ({0}, @StoreId, @ProductId, @Ean, @CategoryId, @CategoryName @BrandId, @BrandName, @Description, @Price, @PriceForOne, @PriceForTen, @InStock, @ExpectedRestock)");
                command.CommandText = commandString;

                foreach (ProductModel p in allProducts)
                {
                    //command.Parameters.Add((float)p.AmigosProductID);
                    //command.Parameters.Add((float)p.BrandID);
                    //command.Parameters.Add(p.Active);
                    //command.Parameters.Add(p.BrandName);
                    //command.Parameters.Add((float)p.CategoryID);
                    //command.Parameters.Add(p.CategoryName);
                    //command.Parameters.Add(p.EAN);
                    //command.Parameters.Add(p.ExpectedRestock);
                    //command.Parameters.Add(p.InStock);
                    //command.Parameters.Add(p.ProductDescription);
                    //command.Parameters.Add(p.ProductName);
                    //command.Parameters.Add((float)p.ProductPrice);
                    //command.Parameters.Add((float)p.ProductPriceForOne);
                    //command.Parameters.Add((float)p.ProductPriceForTen);
                    //command.Parameters.Add((float)p.StoreID);
                    //command.Parameters.Add((float)p.StorePrice);
                    //command.Parameters.Add((float)p.StoreProductID);
                    command.Parameters.AddWithValue("@StoreId",p.StoreID);
                    command.Parameters.AddWithValue("@ProductId", p.StoreProductID);
                    command.Parameters.AddWithValue("@Ean", p.EAN);
                    command.Parameters.AddWithValue("@CategoryId", p.StoreProductID);
                    command.Parameters.AddWithValue("@CategoryName", p.CategoryName);
                    command.Parameters.AddWithValue("@BrandId", p.BrandID);
                    command.Parameters.AddWithValue("@BrandName", p.BrandName);
                    command.Parameters.AddWithValue("@Description", p.ProductDescription);
                    command.Parameters.AddWithValue("@Price", p.ProductPrice);
                    command.Parameters.AddWithValue("@PriceForOne", p.ProductPriceForOne);
                    command.Parameters.AddWithValue("@PriceForTen", p.ProductPriceForTen);
                    if (p.InStock.HasValue)
                    {
                        command.Parameters.AddWithValue("@InStock", p.InStock);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@InStock", DBNull.Value);
                    }
                    if (p.ExpectedRestock.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExpectedRestock", p.ExpectedRestock);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ExpectedRestock", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@StorePrice", p.StorePrice);
                    if (p.Active.HasValue)
                    {
                        command.Parameters.AddWithValue("@Active", p.Active);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Active", 0);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fight With The exception: " + ex);
            }
        }
    }
}
