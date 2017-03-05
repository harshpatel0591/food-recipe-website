using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using ErrorLog;
using System.Web.Services;
using System.Text.RegularExpressions;
using Entities;


namespace Yummly
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method will be called for sign in using FB or Google only
        /// </summary>
        [WebMethod]
        public static string SetSessionabc(string FirstName, string LastName, string EmailId,string Type)
        {
            string response = "0";
            try
            {
                string userId = Common.UserDetails.GetUserDetails(FirstName, LastName, EmailId, Convert.ToInt32(Type), "");

                if (!String.IsNullOrEmpty(userId))
                {
                    HttpContext.Current.Session["UserId"] = userId;
                    HttpContext.Current.Session["FirstName"] = FirstName;
                    HttpContext.Current.Session["LastName"] = LastName;
                    HttpContext.Current.Session["Type"] = Type;
                    response = "1";
                }
                else
                    response = "0";
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            return response;
        }

        [WebMethod]
        public static string Test()
        {
            return "1";
        }

        public void FoodieLogin(object sender, EventArgs e)
        {
            bool isValidEmail = false;

            isValidEmail = Regex.IsMatch(txtEmailId.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            if (!String.IsNullOrEmpty(txtEmailId.Text) && !String.IsNullOrEmpty(txtPassword.Text) && isValidEmail && txtPassword.Text.Length > 5)
            {
                
                UserSession userDetails = new UserSession();
                userDetails = UserDetails.GetFoodieAccountDetails(txtEmailId.Text, txtPassword.Text);
                if (!String.IsNullOrEmpty(userDetails.FirstName) && !String.IsNullOrEmpty(userDetails.LastName) && !String.IsNullOrEmpty(userDetails.UserId))
                {
                    HttpContext.Current.Session["UserId"] = userDetails.UserId;
                    HttpContext.Current.Session["FirstName"] = userDetails.FirstName;
                    HttpContext.Current.Session["LastName"] = userDetails.LastName;
                    HttpContext.Current.Session["Type"] = "1";
                    Response.Redirect("/");
                }
                else
                    spnFoodieLoginStatus.InnerText = "Error while logging in.Please check your credentials";

            }
        }

    }
}