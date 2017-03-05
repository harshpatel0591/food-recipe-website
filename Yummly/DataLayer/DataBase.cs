using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorLog;

namespace DataLayer
{
    public class DataBase
    {
        public string connectionString = "";
        public DataBase()
        {
            connectionString = ConfigurationManager.AppSettings["connectionString"];
        }

        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            finally
            {
                conn.Close();
                da.Dispose();
            }
            return ds;
        }

        public DataSet GetDataSet(SqlCommand sqlcmd)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                sqlcmd.Connection = conn;
                da.SelectCommand = sqlcmd;
                conn.Open();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ex.SendMail();
            }
            finally
            {
                conn.Close();
                da.Dispose();
            }
            return ds;
        }

        public string InsertQry(SqlCommand cmd) 
        {
            string resp = "0";
            SqlConnection conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteReader();
                resp = "1";
            }
            catch (Exception ex)
            {
                ex.SendMail();
                resp = "0";
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return resp;
        }

    }
}
