using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ErrorLog;

namespace DataLayer
{
    public class SubscribeEmailDL
    {
        public static string InsertUserEmail(string emailId) 
        {
            DataBase db = new DataBase();
            string response = "0";
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_SubscribeUserEmail");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.VarChar, 100)).Value = emailId;
                response = db.InsertQry(cmd);
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            return response;
        }

    }
}
