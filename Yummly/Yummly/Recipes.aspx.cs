using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLayer.ApiCalls;
using Entities;
using ErrorLog;


namespace Yummly
{
    public partial class Recipes : System.Web.UI.Page
    {
        string searchVal = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["UserId"] != null)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["q"]))
                    searchVal = Request.QueryString["q"];

                CallGetRecipeApi();
            }
            else
                Response.Redirect("/SignIn.aspx");
        }

        protected void CallGetRecipeApi()
        {
            try
            {
                SearchRecipes objSearchRecipe = new SearchRecipes();

                objSearchRecipe = CallApiBL.CallSearchRecipeApi(searchVal);

                foreach (Matches mat in objSearchRecipe.matches)
                {
                    if (mat.smallImageUrls != null && mat.smallImageUrls.Count > 0)
                        mat.smallImageUrl = mat.smallImageUrls[0];
                }

                rptRecipiesList.DataSource = objSearchRecipe.matches;
                rptRecipiesList.DataBind();
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
        }
    }
}