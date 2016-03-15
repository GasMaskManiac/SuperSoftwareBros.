using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ConnectionService.Connections
{
    class DealersService
    {
        public DealersService()
        {
            try
            {
                HttpClient dealersClient = new HttpClient();
                dealersClient.BaseAddress = new Uri("http://dodgydealers.azurewebsites.net/");
                dealersClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An Error Was Found Causing Mischeif, Here Is The Rascal: " + ex);
            }
        }
    }
}
