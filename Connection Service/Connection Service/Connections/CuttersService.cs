using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Text;

namespace ConnectionService.Connections
{
    class CuttersService
    {
        public CuttersService()
        {
            try
            {
                HttpClient cuttersClient = new HttpClient();
                cuttersClient.BaseAddress = new Uri("http://undercutters.azurewebsites.net/");
                cuttersClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An Error Was Found Causing Mischeif, Here Is The Rascal: " + ex);
            }
        }
    }
}
