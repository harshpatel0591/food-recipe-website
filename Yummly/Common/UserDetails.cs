using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using ErrorLog;
using Entities;
using DataLayer;

namespace Common
{
    public class UserDetails
    {
        public static string GetUserDetails(string firstName, string lastName, string emailId,int loginType,string password)
        {
            string response = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("Get_UserDetails");
            cmd.Connection = conn;
            try 
            {	        
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName",SqlDbType.VarChar,200).Value = firstName;
                cmd.Parameters.Add("@LastName",SqlDbType.VarChar,200).Value = lastName;
                cmd.Parameters.Add("@EmailId",SqlDbType.VarChar,200).Value = emailId;
                cmd.Parameters.Add("@LoginType",SqlDbType.Int).Value = loginType;
                cmd.Parameters.Add("@Password",SqlDbType.VarChar,200).Value = password;
                cmd.Parameters.Add("@UserId",SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteReader();
                response = cmd.Parameters["@UserId"].Value.ToString();
            }
	        catch (Exception ex)
	        {
		
	        }
            finally{
                conn.Close();
                cmd.Dispose();
            }
            return response;
        }



        public static int InsertUserDetails(string firstName, string lastName, string emailId, int loginType, string password)
        {
            int returnVal = 0;
            string response = "";
            string result = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("Insert_UserDetails");
            cmd.Connection = conn;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 200).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 200).Value = lastName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = emailId;
                cmd.Parameters.Add("@loginType", SqlDbType.TinyInt).Value = loginType;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = password;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Result", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteReader();
                response = cmd.Parameters["@UserId"].Value.ToString();
                result = cmd.Parameters["@Result"].Value.ToString();
                if (Convert.ToInt32(result) == 0 && Convert.ToInt32(response) <= 0)
                    returnVal = 0;
                else
                    returnVal = Convert.ToInt32(response);
                    
            }
            catch (Exception ex)
            {
                returnVal = 0;
                ex.SendMail();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return returnVal;
        }

        public static UserSession GetFoodieAccountDetails(string email,string password)
        {
            UserSession user = new UserSession();

            try
            {
                string sql = "select FirstName,LastName,Id from Users where EmailId =@email and Password = @password";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = password;
                DataSet ds = new DataSet();
                DataBase db = new DataBase();
                ds = db.GetDataSet(cmd);
                user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                user.UserId = ds.Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            return user;
        }

    }
}
