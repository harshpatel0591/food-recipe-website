using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ErrorLog;

namespace DataLayer
{
    public class ReviewsDL
    {

        public static DataSet GetReviews(string recipeId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_RecipeReviews");
                cmd.Parameters.Add(new SqlParameter("@RecipeId",SqlDbType.VarChar,500)).Value = recipeId;
                cmd.CommandType = CommandType.StoredProcedure;
                DataBase db = new DataBase();
                ds = db.GetDataSet(cmd);
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            return ds;
        }

        public static Boolean SetReview(string recipeId, string review, string userId) 
        {
            Boolean response = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Insert_RecipeReview");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@review", SqlDbType.VarChar, 1000).Value = review;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@recipeId", SqlDbType.VarChar, 500).Value = recipeId;
                DataBase db = new DataBase();
                db.InsertQry(cmd);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;   
            }
            return response;
        }


    }
}
