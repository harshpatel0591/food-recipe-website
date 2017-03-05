using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yummly
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserAccount(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;
            string emailId = txtEmail.Text;
            string password = txtPassword.Text;
            bool isValidEmail = false;

            isValidEmail = Regex.IsMatch(emailId,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase,TimeSpan.FromMilliseconds(250));

            if (!String.IsNullOrEmpty(fname) && !String.IsNullOrEmpty(lname) && !String.IsNullOrEmpty(emailId) && isValidEmail && !String.IsNullOrEmpty(password) && (password.Length > 5))
            {
                SubmitUserDetails(fname,lname,emailId,password);
            }
            else
                emailValidStatus.InnerHtml = "Please enter valid Information";
        }

        protected void SubmitUserDetails(string firstName,string lastName,string emailId,string password) 
        {
            int userId = 0;
            userId = Common.UserDetails.InsertUserDetails(firstName, lastName, emailId, 1, password);
            if (userId <= 0) 
            {
                emailValidStatus.InnerHtml = "Account alreay exists.Please login from our login page.";
            }
            else
            {
                HttpContext.Current.Session["UserId"] = userId;
                HttpContext.Current.Session["FirstName"] = firstName;
                HttpContext.Current.Session["LastName"] = lastName;
                HttpContext.Current.Session["Type"] = "1";
                Response.Redirect("/");
            }

            
        }

    }
}