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
        public KwikiService()
        {
            try
            {
                HttpClient kwikiClient = new HttpClient();
                kwikiClient.BaseAddress = new Uri("http://khanskwikimart.azurewebsites.net/");
                kwikiClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An Error Was Found Causing Mischeif, Here Is The Rascal: " + ex);
            }
        }
    }
}
