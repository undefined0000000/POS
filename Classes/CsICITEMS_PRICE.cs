using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CsICITEMS_PRICE
    {
        public int TenentID { get; set; }
        public long MYPRODID { get; set; }
        public int UOM { get; set; }
        public int MyID { get; set; }
        public string UserProdID { get; set; }
        public Nullable<decimal> ORIGINALPRICE { get; set; }
        public Nullable<int> MAXDISCOUNT { get; set; }
        public Nullable<decimal> SPECIALSALE { get; set; }
        public string REFERENCE { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string LOCATIONID { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public Nullable<decimal> basecost { get; set; }
        public Nullable<decimal> onlinesale1 { get; set; }
        public Nullable<decimal> onlinesale2 { get; set; }
        public Nullable<decimal> msrp { get; set; }
        public Nullable<decimal> price { get; set; }
        public string currency { get; set; }
        public Nullable<decimal> onlinesale3 { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }

        public static void Edit_Price( int TenentID , int locationid,int prodid,int uom,decimal msrp,decimal price)
        {

            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    SqlParameter roleID = new SqlParameter();
                    roleID.Direction = ParameterDirection.Output;
                    roleID.ParameterName = "RoleID";
                    roleID.SqlDbType = SqlDbType.Int;

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@TenentID", TenentID),
                         new SqlParameter("@LocationID", locationid),
                         new SqlParameter("@MyprodID", prodid),
                              new SqlParameter("@UOMID",uom),
                         new SqlParameter("@msrp", msrp) ,
                        new SqlParameter("@price", price)};
                    try
                    {


                       SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Update_ICIT_Price", param);

                       

                    }
                    catch (Exception)
                    {


                    }

                }
            }



            catch (Exception exp)
            {

                throw exp;
            }



        }


        public static void Save_Price(int TenentID, int locationid, int prodid, int uom, decimal msrp, decimal price)
        {
          
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {
                    

                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@TenentID", TenentID),
                         new SqlParameter("@LocationID", locationid),
                         new SqlParameter("@itemID", prodid),
                              new SqlParameter("@UOMID",uom),
                         new SqlParameter("@msrp", msrp) ,
                        new SqlParameter("@price", price)};
                    try
                    {


                        SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Insert_ICIT_Price", param);



                    }
                    catch (Exception ex)
                    {


                    }

                }
            }



            catch (Exception exp)
            {

                throw exp;
            }



        }
        public static DataTable getPrice(int TenentID, int locationid, int prodid)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = SqlHelper.createConnection())
                {


                    SqlParameter[] param = new SqlParameter[]{
                         new SqlParameter("@TenentID", TenentID),
                         new SqlParameter("@LocationID", locationid),
                         new SqlParameter("@itemID", prodid)

                };

                    DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Get_ICIT_Price", param).Tables[0];
                    return DT;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class CsICITEMS_PRICEList
    {
        public IList<CsICITEMS_PRICE> data { get; set; }
    }
    public class GetCsICITEMS_PRICE
    {
        public CsICITEMS_PRICE data { get; set; }
    }

  
}
