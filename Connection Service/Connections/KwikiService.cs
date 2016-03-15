using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ConnectionService.Connections
{
    public class KwikiService
    {
        public HttpClient GetKwikiService()
        {
            HttpClient kwikiClient = new HttpClient();
            kwikiClient.BaseAddress = new Uri("http://khanskwikimart.azurewebsites.net/");
            kwikiClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            return kwikiClient;
        }
    }
}
