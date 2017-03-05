using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yummly.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected string loginType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            loginType = "";
            if (Session["Type"] != null) 
            {
                loginType = Session["Type"].ToString();
            }
        }

        protected void ClearSession(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/");
        }
    }
}