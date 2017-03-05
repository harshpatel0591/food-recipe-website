using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendNewsLetter;
using System.Data;
using BusinessLayer;
using ErrorLog;

namespace Yummly
{
    public partial class SendNewsletter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendLetter(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = new DataSet();
                string subject = txtSubject.Text;
                string content = txtContent.Text;
                DataTable dt = new DataTable();

                ds = SubscribeEmailBL.GetAllEmails();
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string emailId = dr["EmailId"].ToString();
                    SendMail.SendNewsLetter(subject, emailId, content);
                }
                txtStatus.Text = "Newsletter sent successfully";
            }
            catch (Exception ex)
            {
                txtStatus.Text = "Error while sending the newsletter.";
                ex.SendMail();
            }
        }
    }
}