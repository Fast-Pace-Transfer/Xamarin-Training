using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyLoginApplication1
{
    public class LoginService
    {
        HttpClient client = new HttpClient();

        public async Task<Boolean> login(string username, string password)
        {
            var response = await client.GetAsync($"https://testauth.fastpacetransfer.com:8543/authenticate/fineract-service-bus/Fineract-Login?clientId={WebUtility.UrlEncode(username)}&credential={WebUtility.UrlEncode(password)}");
            if(response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
