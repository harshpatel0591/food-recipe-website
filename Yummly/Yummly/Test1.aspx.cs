using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using ErrorLog;

namespace Yummly
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
            
            DataSet ds = new DataSet();
            ds = PopularCuisinesBL.GetPopularCuisines();
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptCuisines.DataSource = ds;
                rptCuisines.DataBind();

            }

        }

        [System.Web.Services.WebMethod]
        public static string AddUserEmail(string emailId)
        {
            return "1";

        }

        public void test() 
        {
            try
            {
                int i = 0;
                int ans = 1 / i;
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }

        }


    }
}