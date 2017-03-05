using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Newtonsoft.Json;

namespace Yummly
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetData();


        }


        private void GetData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.yummly.com/v1/api/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("recipes?_app_id=0fd5d39d&_app_key=c80aa038f437173fdf436a5f4ca5cbeb&q=onion+soup").Result;

            if (response.IsSuccessStatusCode)
            {

                string users = response.Content.ReadAsStringAsync().Result;
                SearchRecipes objSearchRecipes = new SearchRecipes();

                objSearchRecipes = JsonConvert.DeserializeObject<SearchRecipes>(users.ToString());
                
                
                // var users = response.Content.ReadAsStringAsync();
                // usergrid.ItemsSource = users;

            }
            else
            {
                // MessageBox.Show("Error Code" + 
                // response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }



    }
}