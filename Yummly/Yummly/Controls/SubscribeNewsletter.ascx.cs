using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Yummly.Controls
{
    public partial class SubscribeNewsletter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubscribeEmail(object sender, EventArgs e) 
        {
            if (SubscribeEmailBL.InsertUserEmail(txtEmail.Text) == "1") 
            {
                Response.Redirect("/ThankYou.aspx");    
            }
            
        
        }
    }
}