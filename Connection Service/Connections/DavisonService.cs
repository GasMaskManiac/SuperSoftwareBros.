using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Text;

namespace ConnectionService.Connections
{
    public class DavisonService : IServiceInterface
    {
        public HttpClient GetDavisonService()
        {
            HttpClient davisonStore = new HttpClient();
            davisonStore.BaseAddress = new Uri("http://davisonstore.azurewebsites.net/");
            davisonStore.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            return davisonStore;
        }
    }
}
