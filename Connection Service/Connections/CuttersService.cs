using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Text;

namespace ConnectionService.Connections
{
    public class CuttersService
    {
        public HttpClient GetCuttersService()
        {

            HttpClient cuttersClient = new HttpClient();
            cuttersClient.BaseAddress = new Uri("http://undercutters.azurewebsites.net/");
            cuttersClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            return cuttersClient;
        }
    }
}
