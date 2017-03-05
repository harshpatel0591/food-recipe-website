using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ErrorLog;

namespace DataLayer
{
    public class PopularCuisinesDL
    {
        public static DataSet GetPopularCuisines() 
        {
            DataSet ds = new DataSet();
            try
            {
                DataBase db = new DataBase();
                string sql = "SELECT Id,CuisineName,Query,ImageUrl FROM PopularCuisines WHERE IsActive = 1";
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
