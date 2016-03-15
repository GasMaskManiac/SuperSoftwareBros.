using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ConnectionService.Connections
{
    public class DealersService
    {
        public HttpClient GetDealersService()
        {
            HttpClient dealersClient = new HttpClient();
            dealersClient.BaseAddress = new Uri("http://dodgydealers.azurewebsites.net/");
            dealersClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            return dealersClient;
        }
    }
}
