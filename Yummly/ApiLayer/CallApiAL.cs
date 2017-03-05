using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ErrorLog;

namespace ApiLayer
{
    public class CallApiAL
    {
        public static string CallWebApi(string query) 
        {
            string responseVal = "";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseApiUrl"]);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(query).Result;

                if (response.IsSuccessStatusCode)
                {

                    responseVal = response.Content.ReadAsStringAsync().Result;

                    //SearchRecipes objSearchRecipes = new SearchRecipes();
                    //objSearchRecipes = JsonConvert.DeserializeObject<SearchRecipes>(users.ToString());

                }
                else
                {
                    responseVal = "";
                }
            }
            catch (Exception ex)
            {
                ex.SendMail();
                responseVal = "";
            }
            
            return responseVal;
        }

    }
}
