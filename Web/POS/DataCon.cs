using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web.POS
{
    public class DataCon
    {
        static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);

        public static DataSet GetDataSet(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                Console.WriteLine(sql);
                DataSet ds = GetDataSet(sql);

                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public static int ExecuteSQL(string sql)
        {
           
            try
            {


                SqlCommand cmd = new SqlCommand(sql, cn);
                if (cn.State == ConnectionState.Closed)
                { cn.Open(); }
                int RC = cmd.ExecuteNonQuery();
                cn.Close();
                return RC;

            }
            catch (Exception exc)
            {
                return 0;
                
            }
         
        }
    }
}