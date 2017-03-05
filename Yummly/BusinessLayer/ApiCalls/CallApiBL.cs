using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLayer;
using Entities;
using Newtonsoft;
using Newtonsoft.Json;
using System.Configuration;
using ErrorLog;


namespace BusinessLayer.ApiCalls
{
    public class CallApiBL
    {
        public static SearchRecipes CallSearchRecipeApi(string searchVal) 
        {
            SearchRecipes objSearchRecipes = new SearchRecipes();

            try
            {
                string query = "recipes?_app_id=" + ConfigurationManager.AppSettings["App_Id"] + "&_app_key=" + ConfigurationManager.AppSettings["App_Key"] + "&q=" + searchVal;
                string json = CallApiAL.CallWebApi(query);


                if (!String.IsNullOrEmpty(json))
                    objSearchRecipes = JsonConvert.DeserializeObject<SearchRecipes>(json.ToString());
            }
            catch (Exception ex)
            {
                ex.SendMail();
                objSearchRecipes = new SearchRecipes();    
            }

            return objSearchRecipes;
        }


        public static RecipeDetails CallRecipeDetailsApi(string id)
        {
            RecipeDetails objRecipeDetails = new RecipeDetails();

            try
            {
                string query = "recipe/" + id + "?_app_id=" + ConfigurationManager.AppSettings["App_Id"] + "&_app_key=" + ConfigurationManager.AppSettings["App_Key"];
                string json = CallApiAL.CallWebApi(query);


                if (!String.IsNullOrEmpty(json))
                    objRecipeDetails = JsonConvert.DeserializeObject<RecipeDetails>(json.ToString());
            }
            catch (Exception ex)
            {
                ex.SendMail();
                objRecipeDetails = new RecipeDetails();    
            }

            return objRecipeDetails;
        }
  



    }
}
