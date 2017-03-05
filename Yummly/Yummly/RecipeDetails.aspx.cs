using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.ApiCalls;
using System.Data;
using BusinessLayer;
using ErrorLog;

namespace Yummly
{
    public partial class RecipeDetails : System.Web.UI.Page
    {
        protected DataSet dsRecipeReviews = new DataSet();
        public string recipeId { get; set; }


        public Entities.RecipeDetails objRecipeDetails = new Entities.RecipeDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["UserId"] != null)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    recipeId = Request.QueryString["id"];
                    hdnRecipeId.Value = recipeId;
                    CallRecipeDetailsApi();
                    GetRecipeReviews();
                }
            }
            else
                Response.Redirect("/SignIn.aspx");
        }

        protected void CallRecipeDetailsApi() 
        {
            try
            {
                objRecipeDetails = CallApiBL.CallRecipeDetailsApi(recipeId);
                //objRecipeDetails.IngredientsCount = objRecipeDetails.ingredientLines.Count.ToString();

                BindDetails();
            }
            catch (Exception ex)
            {
                ex.SendMail();                
            }
        }

        protected void BindDetails()
        {
            try
            {
                rptIngredients.DataSource = objRecipeDetails.ingredientLines;
                rptIngredients.DataBind();
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
        }

        protected void GetRecipeReviews()
        {
            try
            {
                dsRecipeReviews = ReviewsBL.GetReviews(recipeId);
                if (dsRecipeReviews.Tables[0].Rows.Count > 0)
                {
                    rptUserReviews.DataSource = dsRecipeReviews;
                    rptUserReviews.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
        }

        [System.Web.Services.WebMethod]
        public static Boolean SubmitReview(string Review, string RecipeId)
        {
            Boolean response = false;
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    if (!String.IsNullOrEmpty(RecipeId) && !String.IsNullOrEmpty(Review))
                    {
                        response = ReviewsBL.SubmitReview(RecipeId, Review, HttpContext.Current.Session["UserId"].ToString());
                    }
                }
                else
                    HttpContext.Current.Response.Redirect("/SignIn.aspx");
            }
            catch (Exception ex)
            {
                ex.SendMail();
                response = false;
            }
            return response;
        }

        public void SetReview() 
        {
            
        }

    }
}