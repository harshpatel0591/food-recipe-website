using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ErrorLog;

namespace BusinessLayer
{
    public class ReviewsBL
    {
        public static DataSet GetReviews(string recipeId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ReviewsDL.GetReviews(recipeId);
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            return ds;
        }

        public static Boolean SubmitReview(string recipeId,string review,string userId) 
        {
            return ReviewsDL.SetReview(recipeId, review, userId);
        }


    }
}
