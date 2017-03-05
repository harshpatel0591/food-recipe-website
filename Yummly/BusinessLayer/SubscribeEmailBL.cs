using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;
using DataLayer;
using ErrorLog;

namespace BusinessLayer
{
    public class SubscribeEmailBL
    {
        public static string InsertUserEmail(string emailId)
        {
            return SubscribeEmailDL.InsertUserEmail(emailId);
        }

        public static DataSet GetAllEmails()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "select EmailId from SubscribeEmail where IsActive=1";
                DataBase db = new DataBase();
                ds = db.GetDataSet(sql);
            }
            catch (Exception ex)
            {
                ex.SendMail();   
            }
            return ds;
        }


    }
}
