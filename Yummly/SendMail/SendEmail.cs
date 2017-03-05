using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ErrorLog
{
    public static class ErrorLog
    {

        public static void SendMail(this Exception ex) 
        {
            string subject = ex.Message;
            StringBuilder body = new StringBuilder();
            body.Append("Stack Trace : " + ex.StackTrace + "<br/>");
            body.Append("Inner Exception : " + ex.InnerException + "<br/>");
            body.Append("Error Mesage :" + ex.Message + "<br/>");
            body.Append("Error Data :" + ex.Data + "<br/>");
            body.Append("Target Site :" + ex.TargetSite + "<br/>");
            body.Append("Source :" + ex.Source + "<br/>");
            

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("iadpro15@gmail.com", "harshpatel");

            MailMessage mm = new MailMessage("iadpro15@gmail.com", "iadpro15@gmail.com", subject, body.ToString());
            mm.IsBodyHtml = true;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        
        }




    }
}
