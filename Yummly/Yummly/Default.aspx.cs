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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPopularCuisines();
        }

        protected void BindPopularCuisines()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = PopularCuisinesBL.GetPopularCuisines();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptPopularCuisines.DataSource = ds;
                    rptPopularCuisines.DataBind();
                }
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            
        }
    }
}