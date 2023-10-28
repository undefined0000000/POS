using Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Classes
{
    public class ClsVouchers
    {
        public int TanentID { get; set; }
        public int LocationID { get; set; }
       
        public DateTime VoucherDate { get; set; }
        public int VoucherID { get; set; }
     
     
        public int VoucherType_ID { get; set; }
    
        public int Account_ID { get; set; }
        public int ApprovedBy { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
     
        public bool IsPost { get; set; }
        public bool IsExpense { get; set; }
        public bool IsIBT { get; set; }
        public string VoucherCode { get; set; }

      
        public string ReceiverName { get; set; }
      
        public string ReferenceNo { get; set; }
        public string TempDetails { get; set; }

        public string Narrations { get; set; }
    
   

        //public List<ClsVoucherDetail>  { get; set; }
        public List<ClsVoucherDetail> VoucherDetail { get; set; } = new List<ClsVoucherDetail>();

        // Single Entry Forms..

        public int FromAccount_ID { get; set; }
      
        public int ToAccount_ID { get; set; }

       
        public decimal Amount { get; set; }
        public decimal AmountPay { get; set; }
        public decimal GrandTotal { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
    }
    public class ClsVoucherDetail
    {
        public Int64 VoucherDetail_ID { get; set; }
        public int CostCenter_ID { get; set; }
        public int Account_ID { get; set; }
        public string AccountName { get; set; }

    
  
        public decimal Amount { get; set; }


  
        public decimal Cr { get; set; }

    
        public decimal Dr { get; set; }

    
        public string Particular { get; set; }

        public string PaymentType { get; set; }

        public string ChequeNo { get; set; }

       
        public string ChequeDate { get; set; }

    }
    public static class  DAL
    {
        public static DataTable Get_Recipe(int TenentID, int RecipeID,int Qty,int locationID)
        {
      

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Production_Recipe", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@RecipeID", RecipeID);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                  // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
      
        }

        public static decimal Get_CollectedPayment(int TenentID, int locationID,string PaymentType)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_CollectedPayment", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                cmd.Parameters.AddWithValue("@locationID", locationID);
               // cmd.Parameters.AddWithValue("@voucherDate", VoucherDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return decimal.Parse( dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static decimal Get_CustomerCredit(int TenentID, int locationID, int CustomerID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Account_Get_CustomerCredit", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                // cmd.Parameters.AddWithValue("@voucherDate", VoucherDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return decimal.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Customerledger(int TenentID, int locationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Account_Get_Summaryledger", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
              
                cmd.Parameters.AddWithValue("@locationID", locationID);
                // cmd.Parameters.AddWithValue("@voucherDate", VoucherDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool SaveVoucher(ClsVouchers v,bool IsCredit,bool Issingle)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RowNo", typeof(Int32));
            dt.Columns.Add("Account_ID", typeof(Int32));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Particular", typeof(string));
            dt.Columns.Add("ChequeNo", typeof(string));
            dt.Columns.Add("ChequeDate", typeof(string));
         
            dt.Columns.Add("IsBankTransfer", typeof(bool));
            dt.Columns.Add("TransferToAccount", typeof(string));
            dt.Columns.Add("Dr", typeof(decimal));
            dt.Columns.Add("Cr", typeof(decimal));
            dt.Columns.Add("ReferenceDate", typeof(DateTime));
            dt.Columns.Add("PaymentType", typeof(string));
            int RowNo = 0;
            if (Issingle)
            {
                if (!IsCredit)
                {

                    dt.Rows.Add(1, v.Account_ID, v.Amount, "Pripaid", "0", null, 0, null, v.Amount, 0, null,"-");
                    dt.Rows.Add(2, v.ToAccount_ID, v.Amount * -1, "Cash", "0", null, 0, null, 0, v.Amount, null, "Cash");
                }
                else
                {
                    dt.Rows.Add(1, v.Account_ID, v.Amount, "Credit", "0", null, 0, null, v.Amount, 0, null, "Credit");
                }
            }
            else
            {

                dt.Rows.Add(RowNo, v.Account_ID, v.Amount, "PriPaid", null, null, 0, null, v.Amount, 0, null, "-");
                foreach (ClsVoucherDetail d in v.VoucherDetail)
                    {
                      
                        RowNo += 1;
                    
                               
                                RowNo += 1;
                                dt.Rows.Add(RowNo, v.Account_ID, d.Amount * -1, "Collect Through Payments", null, null, 0, null, 0, d.Amount, null, d.PaymentType);
                    
                    }
                }
         
          
         
            bool result = false;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("[Accounts_SaveVoucher]", conn);
                cmd.Parameters.AddWithValue("@TanentID", v.TanentID);
                cmd.Parameters.AddWithValue("@LocationID", v.LocationID);
                cmd.Parameters.AddWithValue("@VoucherID", v.VoucherID);
                cmd.Parameters.AddWithValue("@VoucherType_ID", v.VoucherType_ID);
                cmd.Parameters.AddWithValue("@Account_ID", v.Account_ID);
                cmd.Parameters.AddWithValue("@VoucherDate", v.VoucherDate);
                cmd.Parameters.AddWithValue("@Narrations", v.Narrations);
                cmd.Parameters.AddWithValue("@ReceiverName", v.ReceiverName);
                cmd.Parameters.AddWithValue("@ReferenceNo", v.ReferenceNo);
                cmd.Parameters.AddWithValue("@CreatedBy", v.CreatedBy);
                cmd.Parameters.AddWithValue("@VoucherCode", v.VoucherCode);
                cmd.Parameters.AddWithValue("@VoucherDetail", dt).SqlDbType = SqlDbType.Structured;
               
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                result = Convert.ToBoolean( cmd.ExecuteNonQuery());
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return result;
        }

     
        public static bool SaveVoucherPayment(ClsVouchers v, bool IsCredit,bool IsOpening)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RowNo", typeof(Int32));
            dt.Columns.Add("Account_ID", typeof(Int32));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Particular", typeof(string));
            dt.Columns.Add("ChequeNo", typeof(string));
            dt.Columns.Add("ChequeDate", typeof(string));

            dt.Columns.Add("IsBankTransfer", typeof(bool));
            dt.Columns.Add("TransferToAccount", typeof(string));
            dt.Columns.Add("Dr", typeof(decimal));
            dt.Columns.Add("Cr", typeof(decimal));
            dt.Columns.Add("ReferenceDate", typeof(DateTime));
            dt.Columns.Add("PaymentType", typeof(string));
            if (!IsOpening)
            {
                foreach (ClsVoucherDetail d in v.VoucherDetail)
                {


                    dt.Rows.Add(1, v.Account_ID, v.Amount * -1,  "Collect Through" + " " + d.PaymentType .ToString(), null, null, 0, null, 0, v.Amount, null,d.PaymentType);

                }


            }
            else
            {
                foreach (ClsVoucherDetail d in v.VoucherDetail)
                {
                    dt.Rows.Add(1, v.Account_ID, v.Amount, "Opening Amount", "0", null, 0, null, v.Amount, 0, null, "Credit");
                }

            }


            bool result = false;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("[Accounts_SaveVoucher]", conn);
                cmd.Parameters.AddWithValue("@TanentID", v.TanentID);
                cmd.Parameters.AddWithValue("@LocationID", v.LocationID);
                cmd.Parameters.AddWithValue("@VoucherID", v.VoucherID);
                cmd.Parameters.AddWithValue("@VoucherType_ID", v.VoucherType_ID);
                cmd.Parameters.AddWithValue("@Account_ID", v.Account_ID);
                cmd.Parameters.AddWithValue("@VoucherDate", v.VoucherDate);
                cmd.Parameters.AddWithValue("@Narrations", v.Narrations);
                cmd.Parameters.AddWithValue("@ReceiverName", v.ReceiverName);
                cmd.Parameters.AddWithValue("@ReferenceNo", v.ReferenceNo);
                cmd.Parameters.AddWithValue("@CreatedBy", v.CreatedBy);
                cmd.Parameters.AddWithValue("@VoucherCode", v.VoucherCode);
                cmd.Parameters.AddWithValue("@VoucherDetail", dt).SqlDbType = SqlDbType.Structured;
              //  cmd.Parameters.Add("@result", SqlDbType.NVarChar , 500);
               // cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
              //  string a = cmd.Parameters["@result"].Value.ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
            return result;
        }

        public static DataTable GetAccountLedger(int TenentID,int LocationID,int AccountID,string FromDate,string ToDate,out decimal OpeningBalance)
        {



            decimal OpBalance = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("[Accounts_GetAccountLedger]", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@locationID", LocationID);
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
               
                cmd.Parameters.AddWithValue("@OpeningBalance", OpBalance).Direction = ParameterDirection.Output;
               

                DataSet ds = new DataSet();
                conn.Open();
                Adapter.Fill(ds);
                conn.Close();
                

                OpBalance = Math.Floor( Convert.ToDecimal ( cmd.Parameters["@OpeningBalance"].Value));
             
                OpeningBalance = OpBalance;
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                OpeningBalance = 0;
                return null;
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
           
        }
        public static DataTable Get_ProductDetailwithcost(int TenentID, int locationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCost_Price", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_ProductDetailwithcostCategory(int TenentID, int locationID,int CategoryID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCost_PriceCategory", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_ProductDetailwithcostProduct(int TenentID, int locationID, string SearchParameter)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCost_PriceProduct", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@Searchparameter", SearchParameter);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Subscription(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_GetSubscription", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
               
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_SubscriptionCustomer(int TenentID,int CustomerID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_ServiceCustomer", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_SubscriptiononID(int TenentID, int CustomerID,int SubscriptionID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Serviceonsubscription", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CompanyReport(int TenentID,int Compid)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCompany_grid", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CompID", Compid);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CompanyGridsaved(int TenentID,int refid, string orderby)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCompany_gridsaved", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@RefID", refid);
                cmd.Parameters.AddWithValue("@Orderby", orderby);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Subscription_Service(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Service", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataSet Get_Subscription_ServiceID(int TenentID,int serviceID)
        {


            DataSet dt = new DataSet();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_ServiceID", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Tables.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_SubscriptionID(int TenentID,int SubscriptionID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_GetSubscriptionID", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_DeliveryNoteForPurchase(int TenentID, int SupplierID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_DeliveryNoteforpuchase", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_lpoForPurchase(int TenentID, int SupplierID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_LPOforpuchase", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_lpodeliveryForPurchase(int TenentID, int lpoid)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Deliveryforpuchase", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", lpoid);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Dt_Sale(int TenentID, int LocationID,int SaleID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_DT_Sale", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@SalesID", SaleID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_DeliveryNoteForPurchaseID(int TenentID, int DeliveryID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_DeliveryNoteforpuchaseID", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DeliveryID", DeliveryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_ProductImage(int TenentID, int ProductID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetProductImage", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CompanyInfo(int TenentID)
        {
            
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_CompanyInfo", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
        
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_LocInfo(int TenentID,int UserID)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetLocSetup", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static List<USER_MST> GetLogin(int TenentID, string UserID ,String Password)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("LoginUser", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID",UserID);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                List<USER_MST> UserLIst = new List<USER_MST>();
                foreach (DataRow row in dt.Rows)
                {
      
   
     
    
        USER_MST p = new USER_MST();
                    p.TenentID = int.Parse(row["TenentID"].ToString());
                    p.USER_ID = int.Parse(row["USER_ID"].ToString());
                    p.LOCATION_ID = int.Parse(row["LOCATION_ID"].ToString());

                    p.FIRST_NAME = row["FIRST_NAME"].ToString();
                    p.LAST_NAME = row["LAST_NAME"].ToString();
                    p.FIRST_NAME1 = row["FIRST_NAME1"].ToString();
                    p.FIRST_NAME2 = row["FIRST_NAME2"].ToString();
                    p.LAST_NAME1 = row["LAST_NAME1"].ToString();
                    p.LAST_NAME2 = row["LAST_NAME2"].ToString();
                    p.LOGIN_ID = row["LOGIN_ID"].ToString();
                    p.ACTIVE_FLAG = row["ACTIVE_FLAG"].ToString();
                   // p.ACTIVEUSER =  Convert.ToBoolean( row["ACTIVEUSER"].ToString());
                    // p.Option2 = Convert.ToBoolean(row["Option2"].ToString());
                    p.PASSWORD = (row["PASSWORD"].ToString());
                    p.USER_TYPE = Convert.ToInt32(row["USER_TYPE"].ToString());

                    UserLIst.Add(p);
                }
                if (dt.Rows.Count > 0)
                {

                    return UserLIst;
                }
                else
                {
                    return UserLIst;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_ICIT_BR(int TenentID, int myprodid, int locationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_ICIT_BR", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MyProdID", myprodid);
                cmd.Parameters.AddWithValue("@LocationID", locationID);
              
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_DayClose(int TenentID, int UserID, int locationID,int ShiftID,string DayDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_Get", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
               
                cmd.Parameters.AddWithValue("@LocationID", locationID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@DayDate", DayDate);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable DayClose_DetailReport(int TenentID, int locationID,int ShiftID ,int UserID, string FromDate,string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_DetailReport", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);

                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_DayCloseEntry(int TenentID, int locationID, string DayDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_GetEntry", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);
               
               
                cmd.Parameters.AddWithValue("@DayDate", DayDate);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_DayClosePayment(int TenentID, int locationID,int ShiftID, string DayDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_PaymentPreview", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);

                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@DayDate", DayDate);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CreditAMT(int TenentID,int locationid, int ShiftID,int UserID,string DayDate)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {

                SqlParameter[] param = new SqlParameter[]{
                     new SqlParameter("@TenentID",TenentID),
                     new SqlParameter("@LocationID",locationid),
                     new SqlParameter("@UserID",UserID),
                      new SqlParameter("@ShiftID",ShiftID),
                      new SqlParameter("@DayDate",DayDate),


                };
                DataTable dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DayClose_GetCreditAMT", param).Tables[0];
                return dt;

            }

        }
        public static DataTable Get_KNETAMT(int TenentID, int locationid, int ShiftID, int UserID,string DayDate)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {

                SqlParameter[] param = new SqlParameter[]{
                     new SqlParameter("@TenentID",TenentID),
                     new SqlParameter("@LocationID",locationid),
                     new SqlParameter("@UserID",UserID),
                      new SqlParameter("@ShiftID",ShiftID),
                      new SqlParameter("@DayDate",DayDate),


                };
                DataTable dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DayClose_GetKNETAMT", param).Tables[0];
                return dt;

            }

        }

        public static DataTable Get_KNETAMTreturn(int TenentID, int locationid, int ShiftID, int UserID, string DayDate)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {

                SqlParameter[] param = new SqlParameter[]{
                     new SqlParameter("@TenentID",TenentID),
                     new SqlParameter("@LocationID",locationid),
                     new SqlParameter("@UserID",UserID),
                      new SqlParameter("@ShiftID",ShiftID),
                      new SqlParameter("@DayDate",DayDate),


                };
                DataTable dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DayClose_GetKNETAMTreturn", param).Tables[0];
                return dt;

            }

        }
        public static DataTable Get_CashAMT(int TenentID, int locationid, int ShiftID, int UserID,string DayDate)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {

                SqlParameter[] param = new SqlParameter[]{
                     new SqlParameter("@TenentID",TenentID),
                     new SqlParameter("@LocationID",locationid),
                     new SqlParameter("@UserID",UserID),
                      new SqlParameter("@ShiftID",ShiftID),
                      new SqlParameter("@DayDate",DayDate),


                };
                DataTable dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DayClose_GetCashAMT", param).Tables[0];
                return dt;

            }

        }

        public static DataTable Get_CashAMTreturn(int TenentID, int locationid, int ShiftID, int UserID, string DayDate)
        {

            using (SqlConnection con = SqlHelper.createConnection())
            {

                SqlParameter[] param = new SqlParameter[]{
                     new SqlParameter("@TenentID",TenentID),
                     new SqlParameter("@LocationID",locationid),
                     new SqlParameter("@UserID",UserID),
                      new SqlParameter("@ShiftID",ShiftID),
                      new SqlParameter("@DayDate",DayDate),


                };
                DataTable dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DayClose_GetCashAMTreturn", param).Tables[0];
                return dt;

            }

        }
        public static DataTable Get_DayCloseMaxID(int TenentID, int locationID)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_MaxID", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);
                //cmd.Parameters.AddWithValue("@UserID", UserID);

          

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_DayClose_ShiftID(int TenentID, int locationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_ShiftID", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);
                //cmd.Parameters.AddWithValue("@UserID", UserID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_SalesQuotation(int TenentID, int locationID,Int64 MyTransID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_SalesQuotation", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", locationID);
                cmd.Parameters.AddWithValue("@MyTransID", MyTransID);
                //cmd.Parameters.AddWithValue("@UserID", UserID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static bool Get_DayClose_Insertion(int TenentID, int UserID, int locationID,int ShiftID,decimal openingbalance)
        {


         
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DayClose_Insert", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@LocationID", locationID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@openingbalance", openingbalance);

                cmd.CommandType = CommandType.StoredProcedure;

               
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
              

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_Employee(tbl_Employee tbl,bool isSuper,int DepartmentID)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Insert_Employee", conn);
                cmd.Parameters.AddWithValue("@TenentID", tbl.TenentID);
                cmd.Parameters.AddWithValue("@EmployeeID", tbl.employeeID);
                cmd.Parameters.AddWithValue("@LocationID", tbl.LocationID);
                cmd.Parameters.AddWithValue("@FirstName", tbl.firstname);
                cmd.Parameters.AddWithValue("@Lastname", tbl.lastname);
                cmd.Parameters.AddWithValue("@MiddleName", tbl.middle_name);
                cmd.Parameters.AddWithValue("@Mobileno", tbl.emp_mobile);
                cmd.Parameters.AddWithValue("@SupervisorID", tbl.MainHRRoleID);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@UserID", tbl.userID);
                cmd.Parameters.AddWithValue("@IsSuper", isSuper);
                cmd.Parameters.AddWithValue("@IsActive", tbl.Active);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_SalesQuotation(int TenentID,int LocationID,Int64 MyTransID,string Quotation,String LPOno)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Insert_SalesQuotation", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
         
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@MyTransID", MyTransID);
                cmd.Parameters.AddWithValue("@QuotationNo", Quotation);
                cmd.Parameters.AddWithValue("@LPONo", LPOno);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Save_Company(TBLCOMPANYSETUP company,string Block,string Floor,String Street,string House,string Facebook,string InstaID)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Save_CompanyCustomer", conn);
                cmd.Parameters.AddWithValue("@TenentID", company.TenentID);
                cmd.Parameters.AddWithValue("@COMPID", company.COMPID);
                cmd.Parameters.AddWithValue("@COMPNAME1", company.COMPNAME1);
                cmd.Parameters.AddWithValue("@COMPNAME2", company.COMPNAME2);
                cmd.Parameters.AddWithValue("@COMPNAME3", company.COMPNAME3);

                cmd.Parameters.AddWithValue("@BirthDate", company.BirthDate);
                cmd.Parameters.AddWithValue("@CivilID", company.CivilID);
                cmd.Parameters.AddWithValue("@EMAIL", company.EMAIL1);
                cmd.Parameters.AddWithValue("@EMAIL1", company.EMAIL1);
                cmd.Parameters.AddWithValue("@EMAIL2", company.EMAIL1);
                cmd.Parameters.AddWithValue("@ADDR1", company.ADDR1);
                cmd.Parameters.AddWithValue("@ADDR2", company.ADDR2);
                cmd.Parameters.AddWithValue("@CITY", company.CITY);
                cmd.Parameters.AddWithValue("@STATE", company.STATE);
                cmd.Parameters.AddWithValue("@POSTALCODE", company.POSTALCODE);
                cmd.Parameters.AddWithValue("@ZIPCODE", company.ZIPCODE);
                cmd.Parameters.AddWithValue("@Language", company.PRIMLANGUGE);
                cmd.Parameters.AddWithValue("@MYCONLOCID", "1");
                cmd.Parameters.AddWithValue("@COUNTRYID", company.COUNTRYID);
                cmd.Parameters.AddWithValue("@BUSPHONE1", company.BUSPHONE1);
                cmd.Parameters.AddWithValue("@BUSPHONE2", company.BUSPHONE1);
                cmd.Parameters.AddWithValue("@BUSPHONE3", company.BUSPHONE1);
                cmd.Parameters.AddWithValue("@BUSPHONE4", company.BUSPHONE1);
                cmd.Parameters.AddWithValue("@MOBPHONE", company.MOBPHONE);
                cmd.Parameters.AddWithValue("@FAX", company.FAX);
                cmd.Parameters.AddWithValue("@FAX1", company.FAX);
                cmd.Parameters.AddWithValue("@FAX2", company.FAX);
                cmd.Parameters.AddWithValue("@REMARKS", company.REMARKS);
                cmd.Parameters.AddWithValue("@Keyword", company.Keyword);
                cmd.Parameters.AddWithValue("@USERID", company.USERID);
                cmd.Parameters.AddWithValue("@Images", company.Images);

                cmd.Parameters.AddWithValue("@BARCODE", company.BARCODE);
                cmd.Parameters.AddWithValue("@Block", Block);
                cmd.Parameters.AddWithValue("@Avtar", "");
                cmd.Parameters.AddWithValue("@Marketting", company.Marketting);
                cmd.Parameters.AddWithValue("@Street", Street);
                cmd.Parameters.AddWithValue("@Floor", Floor);
                cmd.Parameters.AddWithValue("@House", House);
                cmd.Parameters.AddWithValue("@Webpage", company.WEBPAGE);
                cmd.Parameters.AddWithValue("@ISMINISTRY", company.ISMINISTRY);
                cmd.Parameters.AddWithValue("@ISSMB", company.ISSMB);
                cmd.Parameters.AddWithValue("@ISCORPORATE", company.ISCORPORATE);

                cmd.Parameters.AddWithValue("@INHAWALLY", company.INHAWALLY);
                cmd.Parameters.AddWithValue("@SALER", company.SALER);
                cmd.Parameters.AddWithValue("@BUYER", company.BUYER);
                cmd.Parameters.AddWithValue("@SALEDEPROD", company.SALEDEPROD);
                cmd.Parameters.AddWithValue("@EMAISUB", company.EMAISUB);
                cmd.Parameters.AddWithValue("@PRODUCTDEALIN", company.PRODUCTDEALIN);
                cmd.Parameters.AddWithValue("@Datasource", company.datasource);
                cmd.Parameters.AddWithValue("@CompanyType", company.CompanyType);

                cmd.Parameters.AddWithValue("@FacebookID", Facebook);
                cmd.Parameters.AddWithValue("@InstaID", InstaID);




                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Save_Subscription(int TenentID, int locationID,string SubscriptionName,bool isparts,bool isproduct,int SubscrptionID)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_SaveSubscription", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@SubscriptionID", SubscrptionID);
                cmd.Parameters.AddWithValue("@LocationID", locationID);
                cmd.Parameters.AddWithValue("@SubscriptionName", SubscriptionName);
                cmd.Parameters.AddWithValue("@IsParts", isparts);
                cmd.Parameters.AddWithValue("@IsProduct", isproduct);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Save_Subscription_Service(int TenentID, int locationID,int CustomerID,string Remarks,DataTable dt)
        {

           

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("complaint_save_service", conn);
                cmd.Parameters.AddWithValue("@productdt", dt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
              
                cmd.Parameters.AddWithValue("@LocationID", locationID);
               
                cmd.Parameters.AddWithValue("@CustomerID", @CustomerID);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool Edit_Complaint_Department(int TenentID, int masterCode,int DepartmentID,int SuperID,int Followup)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Edit_Department", conn);
                
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MasterCode", masterCode);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@SuperID", SuperID);
                cmd.Parameters.AddWithValue("@Followup", Followup);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Edit_PrintPanel(int TenentID, int UserID,string PrintPanel)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Edit_PrintPanel", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PrintPanel", PrintPanel);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool Edit_Subscription_Service(int TenentID,int ServiceID, int locationID, int CustomerID, string Remarks, DataTable dt)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("complaint_Edit_service", conn);
                cmd.Parameters.AddWithValue("@productdt", dt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@LocationID", locationID);
                cmd.Parameters.AddWithValue("@CustomerID", @CustomerID);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool Delete_Service_Product(int TenentID, int ServiceID, int ProdID)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Delete_Product", conn);
                
                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@ServiceId", ServiceID);

                cmd.Parameters.AddWithValue("@MyprodID", ProdID);
                
                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_PaymentType(int TenentID,int ID,string PaymentType,String PaymentMethod,bool IsActive)
        {



            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Insert_PaymentType", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);

                cmd.CommandType = CommandType.StoredProcedure;


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_PaymentType(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_PaymentType", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

               

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_SuperVisor(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_SuperVisor", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Department(int TenentID,int SuperID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Department", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@SuperVisorID", SuperID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Employee(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Select_Employee", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
               
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Dept_Supervisor(int TenentID,int DeptID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Select_Supervisor", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DeptID", DeptID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Dept_Employee(int TenentID, int DeptID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Select_Dept_Employee", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DeptID", DeptID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_EmployeewithID(int TenentID,int EmployeeID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Select_EmployeeID", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_companycustomer(int TenentID,int compid)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("get_companycustomer", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CompID", compid);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_PaymentTypeID(int TenentID,int ID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_PaymentTypeID", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ID", ID);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_PaymentTypename(int TenentID, string paymenttype)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_PaymentTypename", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@paymenttype", paymenttype);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Purchase_Product(int TenentID,  int locationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Product_Purchaseddl", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
              
                cmd.Parameters.AddWithValue("@locationID", locationID);
            
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Purchase_ProductCategory(int TenentID, int locationID,int CategoryID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Product_PurchaseddlCategory", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable HD_Sale_Purchase(int TenentID, string LFO,int UID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_HDSale_Purchase", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LFO", LFO);
                cmd.Parameters.AddWithValue("@UserID", UID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Purchase_ProductSearch(int TenentID, int locationID,string Search)
        {
          

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Product_PurchaseddlSearch", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@Searchparameter", Search);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Report_SalePrinting(int TenentID, int LocationID, string FromDate,string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Report_Sale", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Report_Sale(int TenentID, int LocationID,string Payment, string FromDate, string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Report_Sale", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Payment", Payment);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Report_Category(int TenentID, int LocationID, int UserID ,string ItemID,int CategoryId , string FromDate, string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("CategoryReport", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                
                cmd.Parameters.AddWithValue("@CategoryID", CategoryId);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Report_ItemHistory(int TenentID, int LocationID, int UserID, string ItemID, int CategoryId,int CustomerID, string FromDate, string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Item_HistoryReport", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@UserID", UserID);

                cmd.Parameters.AddWithValue("@CategoryID", CategoryId);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }



        public static DataTable UserReport_Sale(int TenentID, int LocationID, string Payment, string FromDate, string ToDate,int UserID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("UserReport_Sale", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Payment", Payment);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Report_Sale_Invoice(int TenentID, int LocationID,Int64 InvoiceID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Report_Sale_Invoice", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);
            
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Stock_Transfer_Main(int TenentID, int LocationID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Stock_Transfer_Main", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_ReceivedList(int TenentID,int FromLocation, int ToLocationID,string FromDate,string ToDate)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Stock_RecievedList", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@FromLocationID", FromLocation);
                cmd.Parameters.AddWithValue("@ToLocation", ToLocationID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Stock_Transfer_Detail(int TenentID, int TransferID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Stock_Transfer_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Stock_Received_Detail(int TenentID, int TransferID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Stock_Received_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Stock_Transfer_ForEdit(int TenentID, int TransferID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Stock_Transfer_ForEdit", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                return dt;
                }
                else
                {
                return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Item_Recipe(int TenentID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Search_Item_Receipe", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@Searchparameter", SearchParam);
               
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Item_View(int TenentID, int LocationID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Search_Item_View", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Searchparameter", SearchParam);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Orderlist_search(int TenentID, int LocationID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("OrderList_Search", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Search", SearchParam);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Orderlist_searchInvoice(int TenentID, int LocationID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("OrderList_SearchInvoice", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Search", SearchParam);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static List<View_ProductCatWiseData> Get_Item_View_Location(int TenentID, int LocationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Search_Item_View_Location", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                List<View_ProductCatWiseData> ProductList = new List<View_ProductCatWiseData>();
                foreach (DataRow row in dt.Rows)
                {
                    View_ProductCatWiseData p = new View_ProductCatWiseData();
                    p.UOM = int.Parse(row["UOM"].ToString());
                    p.TenentID = int.Parse(row["TenentID"].ToString());
                    p.MYPRODID = int.Parse(row["MYPRODID"].ToString());

                    p.ProdName1 = row["ProdName1"].ToString();
                    p.ProdName2 = row["ProdName2"].ToString();
                    p.ProdName3 = row["ProdName3"].ToString();
                    p.CAT_NAME1 = row["CAT_NAME1"].ToString();
                    p.CAT_NAME2 = row["CAT_NAME2"].ToString();
                    p.Option1 = row["Option1"].ToString();
                    p.DefaultPic = row["DefaultPic"].ToString();
                   // p.Option2 = Convert.ToBoolean(row["Option2"].ToString());
                    p.price = Convert.ToDecimal(row["price"].ToString());
                    p.msrp = Convert.ToDecimal(row["msrp"].ToString());
                    p.MainCategoryID = int.Parse(row["MainCategoryID"].ToString());
                    p.OnHand = Convert.ToDecimal(row["QTYINHAND"].ToString());
                    p.QTYSOLD = Convert.ToInt64(row["QTYSOLD"].ToString());
                    p.QTYRCVD = Convert.ToInt64(row["QTYRCVD"].ToString());
                    p.AlternateCode1 = row["AlternateCode1"].ToString();
                    p.BarCode = row["BarCode"].ToString();
                    p.BatchNo = "1";
                    ProductList.Add(p);
                }
                if (dt.Rows.Count > 0)
                {

                    return ProductList;
                }
                else
                {
                    return ProductList;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Item_View_Product(int TenentID, int LocationID,int ProductID)
        {


            DataTable productdt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Search_Item_View_Product", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@MyprodID", ProductID);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(productdt);
                conn.Close();
               // List< View_ProductCatWiseData> pl = new List<View_ProductCatWiseData>();
                //foreach (DataRow row in productdt.Rows)
                //{
                //    View_ProductCatWiseData p = new View_ProductCatWiseData();
                //    p.UOM = int.Parse( row["UOM"].ToString());
                //    p.TenentID = int.Parse(row["TenentID"].ToString());
                //    p.MYPRODID = int.Parse(row["MYPRODID"].ToString());

                //    p.ProdName1 = row["ProdName1"].ToString();
                //    p.ProdName2 = row["ProdName2"].ToString();
                //    p.ProdName3 = row["ProdName3"].ToString();
                //    p.CAT_NAME1 = row["CAT_NAME1"].ToString();
                //    p.Option1 = row["Option1"].ToString();
                //    p.DefaultPic= row["DefaultPic"].ToString();
                //    p.Option2 =  Convert.ToBoolean( row["Option2"].ToString());
                //    p.price = Convert.ToDecimal(row["ProdName3"].ToString());
                //    p.msrp = Convert.ToDecimal(row["ProdName3"].ToString());

                //    p.OnHand = Convert.ToDecimal( row["ProdName3"].ToString());
                //    p.QTYSOLD = Convert.ToInt64(row["ProdName3"].ToString());
                //    p.QTYRCVD = Convert.ToInt64(row["ProdName3"].ToString());
                //    p.AlternateCode1 =row["ProdName3"].ToString();
                //    p.BarCode = row["ProdName3"].ToString();
                //    p.BatchNo = row["ProdName3"].ToString();
                   
                //}
                if (productdt.Rows.Count > 0)
                {

                    return productdt;
                }
                else
                {
                    return productdt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static List<View_SalesControl> Get_OrderList(int TenentID, int LocationID,int transid,int subtransid,string orderstatus,int transday,int transmonth, int transyear,DateTime lastmonth,int IsFull)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("view_saleControl", conn);
   
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TransID", transid);
                cmd.Parameters.AddWithValue("@SubTransID", subtransid);
                cmd.Parameters.AddWithValue("@OrderStatus", orderstatus);
                cmd.Parameters.AddWithValue("@transDay", transday);

                cmd.Parameters.AddWithValue("@transMonth", transmonth);
                cmd.Parameters.AddWithValue("@transYear", transyear);
                cmd.Parameters.AddWithValue("@lastmonth", lastmonth);
                cmd.Parameters.AddWithValue("@IsFull", IsFull);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                List<View_SalesControl> ProductList = new List<View_SalesControl>();
                foreach (DataRow row in dt.Rows)
                {
                    View_SalesControl p = new View_SalesControl();
                    p.TenentID = int.Parse(row["TenentID"].ToString());
                    p.locationID = int.Parse(row["LocationID"].ToString());
                    p.MYTRANSID = int.Parse(row["MYTRANSID"].ToString());

                    p.Status = row["Status"].ToString();
                    p.CUSTVENDID = int.Parse( row["CUSTVENDID"].ToString());
                    p.TRANSDATE = DateTime.Parse( row["TRANSDATE"].ToString());
                    p.USERID = row["USERID"].ToString();
                    p.TOTAMT = decimal.Parse( row["TOTAMT"].ToString());
                    p.Orderway = row["Orderway"].ToString();

                   // p.PaymentStatus = row["PaymentStatus"].ToString();
                    p.OrderStatus = row["OrderStatus"].ToString();
                    p.DeliveryStatus = row["DeliveryStatus"].ToString();
                    p.PaymentStatus = row["PaymentType"].ToString();

                   
                    ProductList.Add(p);
                }
                if (dt.Rows.Count > 0)
                {

                    return ProductList;
                }
                else
                {
                    return ProductList;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_OrderList1(int TenentID, int LocationID, int transid, int subtransid, string orderstatus, int transday, int transmonth, int transyear, DateTime lastmonth, int IsFull)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("view_saleControl", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TransID", transid);
                cmd.Parameters.AddWithValue("@SubTransID", subtransid);
                cmd.Parameters.AddWithValue("@OrderStatus", orderstatus);
                cmd.Parameters.AddWithValue("@transDay", transday);

                cmd.Parameters.AddWithValue("@transMonth", transmonth);
                cmd.Parameters.AddWithValue("@transYear", transyear);
                cmd.Parameters.AddWithValue("@lastmonth", lastmonth);
                cmd.Parameters.AddWithValue("@IsFull", IsFull);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                List<View_SalesControl> ProductList = new List<View_SalesControl>();
                foreach (DataRow row in dt.Rows)
                {
                    View_SalesControl p = new View_SalesControl();
                    p.TenentID = int.Parse(row["TenentID"].ToString());
                    p.locationID = int.Parse(row["LocationID"].ToString());
                    p.MYTRANSID = int.Parse(row["MYTRANSID"].ToString());

                    p.Status = row["Status"].ToString();
                    p.CUSTVENDID = int.Parse(row["CUSTVENDID"].ToString());
                    p.TRANSDATE = DateTime.Parse(row["TRANSDATE"].ToString());
                    p.USERID = row["USERID"].ToString();
                    p.TOTAMT = decimal.Parse(row["TOTAMT"].ToString());
                    p.Orderway = row["Orderway"].ToString();

                    // p.PaymentStatus = row["PaymentStatus"].ToString();
                    p.OrderStatus = row["OrderStatus"].ToString();
                    p.DeliveryStatus = row["DeliveryStatus"].ToString();
                    p.PaymentStatus = row["PaymentType"].ToString();


                    ProductList.Add(p);
                }
                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static List<View_ProductCatWiseData> Get_Item_View_Category(int TenentID, int LocationID, int CategoryID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Search_Item_View_Category", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                List<View_ProductCatWiseData> ProductList = new List<View_ProductCatWiseData>();
                foreach (DataRow row in dt.Rows)
                {
                    View_ProductCatWiseData p = new View_ProductCatWiseData();
                    p.UOM = int.Parse(row["UOM"].ToString());
                    p.TenentID = int.Parse(row["TenentID"].ToString());
                    p.MYPRODID = int.Parse(row["MYPRODID"].ToString());

                    p.ProdName1 = row["ProdName1"].ToString();
                    p.ProdName2 = row["ProdName2"].ToString();
                    p.ProdName3 = row["ProdName3"].ToString();
                    p.CAT_NAME1 = row["CAT_NAME1"].ToString();
                    p.CAT_NAME2 = row["CAT_NAME2"].ToString();
                    p.Option1 = row["Option1"].ToString();
                    p.DefaultPic = row["DefaultPic"].ToString();
                    // p.Option2 = Convert.ToBoolean(row["Option2"].ToString());
                    p.price = Convert.ToDecimal(row["price"].ToString());
                    p.msrp = Convert.ToDecimal(row["msrp"].ToString());
                    p.MainCategoryID = int.Parse(row["MainCategoryID"].ToString());
                    p.OnHand = Convert.ToDecimal(row["QTYINHAND"].ToString());
                    p.QTYSOLD = Convert.ToInt64(row["QTYSOLD"].ToString());
                    p.QTYRCVD = Convert.ToInt64(row["QTYRCVD"].ToString());
                    p.AlternateCode1 = row["AlternateCode1"].ToString();
                    p.BarCode = row["BarCode"].ToString();
                    p.BatchNo = "1";
                    ProductList.Add(p);
                }
                if (dt.Rows.Count > 0)
                {

                    return ProductList;
                }
                else
                {
                    return ProductList;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Main_Stock(int TenentID,int LocationID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Main_Stock", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Searchparameter", SearchParam);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Main_StockAlert(int TenentID,int CategoryID, int LocationID, string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {

                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Main_StockAlert", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Searchparameter", SearchParam);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_Category(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {

                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Category", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
              

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_User_Location(int TenentID, int UserID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_User_Locations", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
              

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Term_Location(int TenentID, int locationid)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Location_Terminals", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID",locationid);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_User(int TenentID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetUserTenent", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
               


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Customer(int TenentID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Customer", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CategoryCombo(int TenentID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetCategory", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_ItemCombo(int TenentID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetItem", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Location(int LID,int TenentID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_LocationName", conn);

                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_User_Detail(int TenentID, int UserID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_User_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_login_Location(int TenentID, string Username,string Password)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_login_Locations", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Password", Password);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static int Get_login_Terminal(int TenentID, int LocationID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Terminal_Login", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows[0][0].ToString()!=string.Empty)
                {

                    return int.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }



        public static DataTable Get_Completed_Delivery(int TenentID, int LPOID, int SupplierID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Completed_Delivery", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Completed_Delivery_Detail(int TenentID, int DeliveryID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Completed_Delivery_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DeliveryID", DeliveryID);
             
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Completed_Delivery_DetailLPO(int TenentID, int LPOID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Completed_Delivery_LPODetail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_LPO(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_LPO", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_LPO_Detail(int TenentID,int LPOID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("GetLPO_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_LPOPrint(int TenentID,int LPOID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("LPO_Print", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_StockPrint(int TenentID, int TransferID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("StockTransferPrint", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_DraftPrint(int DraftID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Draftprint", conn);

              
                cmd.Parameters.AddWithValue("@DraftID", DraftID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_PendingDraftDetail(int DraftID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_PendingDraftDetail", conn);


                cmd.Parameters.AddWithValue("@DraftID", DraftID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_PendingDraftDetailforStockTransfer(int DraftID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_PendingDraftDetailforStocktransfer", conn);


                cmd.Parameters.AddWithValue("@DraftID", DraftID);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static DataTable Get_ProductionLPO(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_ProductionLPO", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
              
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Production(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_Recipe_Production", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
            
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Production_Detail(int TenentID,int ProductionID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_Recipe_Production_Detail", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ProductionID", ProductionID);
          

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Production_Date(int TenentID,string FromDate,string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Select_Recipe_Production_Date", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_stock_Date(int TenentID, string FromDate, string ToDate,int LocationID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("StockDetailforprint", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);


                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Draft_Date(int TenentID, int UserID,string FromDate,string ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_DraftLPO_Date", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", @UserID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static void ProductionMaster(int TenentID ,int RecipeID, int UserID, string name, string ArabicName, int StoreID, int RecipeQty,string SerialNumber,out bool Status,DataTable stockdt)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_productionmaster", conn);


                cmd.Parameters.AddWithValue("@StockType", stockdt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                
                cmd.Parameters.AddWithValue("@ProductionName", name);
                cmd.Parameters.AddWithValue("@ProductionName_Arabic", ArabicName);
                cmd.Parameters.AddWithValue("@StoreID", StoreID);
                cmd.Parameters.AddWithValue("@RecipeQty", RecipeQty);
                cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                
                cmd.Parameters.AddWithValue("@RecipeID", RecipeID);
                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.ExecuteNonQuery();
                
                    Status = (bool)cmd.Parameters["@Status"].Value;
                    conn.Close();
               




            }
            catch (Exception ex)
            {
                Status = false;
            
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Insert_CrmMainactivity(CRMMainActivity ob,int SuperID,int SubscriptionID,out int MasterCode)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
       
                cmd = new SqlCommand("Complaint_Save_CrmMainActivities", conn);
                cmd.Parameters.AddWithValue("@TenentID", ob.TenentID);
                cmd.Parameters.AddWithValue("@COMPID", ob.COMPID);
                cmd.Parameters.AddWithValue("@MasterCODE", ob.MasterCODE);
                cmd.Parameters.AddWithValue("@LinkMasterCODE", ob.LinkMasterCODE);
                cmd.Parameters.AddWithValue("@LocationID", ob.LocationID);
                cmd.Parameters.AddWithValue("@MyID", ob.MyID);
                cmd.Parameters.AddWithValue("@Prefix", ob.Prefix);
                cmd.Parameters.AddWithValue("@RouteID", ob.RouteID);
                cmd.Parameters.AddWithValue("@USERCODE", ob.USERCODE);
                cmd.Parameters.AddWithValue("@ACTIVITYE", ob.ACTIVITYE);
                cmd.Parameters.AddWithValue("@ACTIVITYA", ob.ACTIVITYA);
                cmd.Parameters.AddWithValue("@ACTIVITYA2", ob.ACTIVITYA2);
                cmd.Parameters.AddWithValue("@Reference", ob.Reference);
                cmd.Parameters.AddWithValue("@AMIGLOBAL", ob.AMIGLOBAL);
                cmd.Parameters.AddWithValue("@MYPERSONNEL", ob.MYPERSONNEL);
                cmd.Parameters.AddWithValue("@INTERVALDAYS", ob.INTERVALDAYS);
                cmd.Parameters.AddWithValue("@REPEATFOREVER", ob.REPEATFOREVER);
                cmd.Parameters.AddWithValue("@REPEATTILL", ob.REPEATTILL);
                cmd.Parameters.AddWithValue("@REMINDERNOTE", ob.REMINDERNOTE);
                cmd.Parameters.AddWithValue("@ESTCOST", ob.ESTCOST);
                cmd.Parameters.AddWithValue("@GROUPCODE", ob.GROUPCODE);
                cmd.Parameters.AddWithValue("@USERCODEENTERED", ob.USERCODEENTERED);
                cmd.Parameters.AddWithValue("@UPDTTIME", ob.UPDTTIME);
                cmd.Parameters.AddWithValue("@USERNAME", ob.USERNAME);
                cmd.Parameters.AddWithValue("@Emp_ID", ob.Emp_ID);
                cmd.Parameters.AddWithValue("@Remarks", ob.Remarks);
                cmd.Parameters.AddWithValue("@CRUP_ID", ob.CRUP_ID);
                cmd.Parameters.AddWithValue("@Version", ob.Version);
                cmd.Parameters.AddWithValue("@Type", ob.Type);
                cmd.Parameters.AddWithValue("@MyStatus", ob.MyStatus);
                cmd.Parameters.AddWithValue("@MainID", ob.MainID);
                cmd.Parameters.AddWithValue("@ModuleID", ob.ModuleID);
                cmd.Parameters.AddWithValue("@DisplayFDName", ob.DisplayFDName);
                cmd.Parameters.AddWithValue("@Description", ob.Description);
                cmd.Parameters.AddWithValue("@Ratting", ob.Ratting);
                cmd.Parameters.AddWithValue("@Active", ob.Active);

                cmd.Parameters.AddWithValue("@JobDone", ob.JobDone);
                cmd.Parameters.AddWithValue("@UploadDate", ob.UploadDate);
      
                cmd.Parameters.AddWithValue("@UseReciepeName", ob.UseReciepeName);
                cmd.Parameters.AddWithValue("@UseReciepeID", ob.PUseReciepeID);
                cmd.Parameters.AddWithValue("@TickDepartmentID", ob.TickDepartmentID);
                cmd.Parameters.AddWithValue("@TickComplainType", ob.TickComplainType);
                cmd.Parameters.AddWithValue("@TickPhysicalLocation", ob.TickPhysicalLocation);
                cmd.Parameters.AddWithValue("@TickCatID", ob.TickCatID);

                cmd.Parameters.AddWithValue("@TickSubCatID", ob.TickSubCatID);
                cmd.Parameters.AddWithValue("@PUseReciepeID", ob.PUseReciepeID);
                cmd.Parameters.AddWithValue("@Patient_Name", ob.Patient_Name);
                cmd.Parameters.AddWithValue("@MRN", ob.MRN);
                cmd.Parameters.AddWithValue("@StaffInvoice", ob.StaffInvoice);
                cmd.Parameters.AddWithValue("@IRDone", ob.IRDone);
                cmd.Parameters.AddWithValue("@ReportedBy", ob.ReportedBy);
                cmd.Parameters.AddWithValue("@ComplaintNumber", ob.ComplaintNumber);
                cmd.Parameters.AddWithValue("@Contact", ob.Contact);
                cmd.Parameters.AddWithValue("@IncidentReport", ob.IncidentReport);
                cmd.Parameters.AddWithValue("@FoloEmp", ob.FoloEmp);
                cmd.Parameters.AddWithValue("@subject", ob.subject);
                cmd.Parameters.AddWithValue("@SuperID", SuperID);
                cmd.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
                cmd.Parameters.Add("@Masterout", SqlDbType.Int);
                cmd.Parameters["@Masterout"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

          
                conn.Close();

                MasterCode =  (int)cmd.Parameters["@Masterout"].Value;



            }
            catch (Exception ex)
            {
                MasterCode = 0;
                //Status = false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Check_Payment(int TenentID,string PaymentType)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Check_Payment", conn);


                cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.Add("@Flag", SqlDbType.Bit);
                cmd.Parameters["@Flag"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                
                conn.Close();
                return (bool)cmd.Parameters["@Flag"].Value;




            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Dashboard_Report(int TenentID, int LocationID,string todaydate, out decimal todaysale,out decimal monthlysale , out decimal yearlysale, out decimal Returnsale)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Dashboard_todaysale", conn);


               
                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", LocationID);
          
                cmd.Parameters.AddWithValue("@DayDate", todaydate);
       
                cmd.Parameters.Add("@TodaySale", SqlDbType.Decimal);
                cmd.Parameters["@TodaySale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@MonthlySale", SqlDbType.Decimal);
                cmd.Parameters["@MonthlySale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@YearlySale", SqlDbType.Decimal);
                cmd.Parameters["@YearlySale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@ReturnSale", SqlDbType.Decimal);
                cmd.Parameters["@ReturnSale"].Direction = ParameterDirection.Output;



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                todaysale = (decimal)cmd.Parameters["@TodaySale"].Value;
                monthlysale = (decimal)cmd.Parameters["@MonthlySale"].Value;
                yearlysale = (decimal)cmd.Parameters["@YearlySale"].Value;
                Returnsale = (decimal)cmd.Parameters["@ReturnSale"].Value;
                conn.Close();





            }
            catch (Exception ex)
            {
                monthlysale = 0;
                yearlysale = 0;
                todaysale = 0;
                Returnsale = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Dashboard_Shift(int TenentID, int LocationID, string todaydate, out decimal MorningSale, out decimal afternoonsale, out decimal eveningsale, out decimal nighsale)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Dashboard_ShiftSale", conn);



                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", LocationID);

                cmd.Parameters.AddWithValue("@DayDate", todaydate);

       
                cmd.Parameters.Add("@MorningSale", SqlDbType.Decimal);
                cmd.Parameters["@MorningSale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@AfternoonSale", SqlDbType.Decimal);
                cmd.Parameters["@AfternoonSale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@EveningSale", SqlDbType.Decimal);
                cmd.Parameters["@EveningSale"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@NightSale", SqlDbType.Decimal);
                cmd.Parameters["@NightSale"].Direction = ParameterDirection.Output;



                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                MorningSale = (decimal)cmd.Parameters["@MorningSale"].Value;
                afternoonsale = (decimal)cmd.Parameters["@AfternoonSale"].Value;
                eveningsale = (decimal)cmd.Parameters["@EveningSale"].Value;
                nighsale = (decimal)cmd.Parameters["@NightSale"].Value;
                conn.Close();

            }
            catch (Exception ex)
            {
                MorningSale = 0;
                eveningsale = 0;
                afternoonsale = 0;
                nighsale = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void DayClose_Close(int TenentID,int LocationID ,int ShiftID,int UserID,string CloseDate,out int State)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("DayClose_Close", conn);


            
                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@CloseDate", CloseDate);
             

               
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                State = (int)cmd.Parameters["@Status"].Value;
                conn.Close();





            }
            catch (Exception ex)
            {
                State = 2;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool DayClose_ShiftStatus(int TenentID, int LocationID, int ShiftID, int UserID, string CloseDate)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool Status = false;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("DayClose_ShiftStatus", conn);



                cmd.Parameters.AddWithValue("@TenentID", TenentID);

                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@CloseDate", CloseDate);



                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;
                conn.Close();
                return Status;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void CheckCategoryID(int TenentID,string CategoryName,out int CategoryID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CheckCategoryID", conn);


               

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@CatName", CategoryName);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int);
                cmd.Parameters["@CategoryID"].Direction = ParameterDirection.Output;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                CategoryID = (int)cmd.Parameters["@CategoryID"].Value;
                conn.Close();


            }
            catch (Exception ex)
            {
                CategoryID = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void StockTransfer_Close(int TenentID,int TransferID )
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Stock_Transfer_Close", conn);




                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);
               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

              
                conn.Close();


            }
            catch (Exception ex)
            {
             

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static void CheckUOM(int TenentID, string UOMName, out int UOM)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CheckUOMID", conn);




                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UOMName", UOMName);
                cmd.Parameters.Add("@UOM", SqlDbType.Int);
                cmd.Parameters["@UOM"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                UOM = (int)cmd.Parameters["@UOM"].Value;
                conn.Close();


            }
            catch (Exception ex)
            {
                UOM = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void CheckTypeID(int TenentID, string TypeName, out int ProdTypeID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CheckProductTypeID", conn);




                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("ProdType", TypeName);
                cmd.Parameters.Add("@ProdRefID", SqlDbType.Int);
                cmd.Parameters["@ProdRefID"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                ProdTypeID = (int)cmd.Parameters["@ProdRefID"].Value;
                conn.Close();


            }
            catch (Exception ex)
            {
                ProdTypeID = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }




        public static bool CheckForInvoice(int tenentID ,Int64 SaleID,int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CheckforInvoice", conn);


                cmd.Parameters.AddWithValue("@InvoiceID", SaleID);
                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);

                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

               bool Status =  (bool)cmd.Parameters["@Status"].Value;
                conn.Close();
                return Status;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool CheckForCustomerSetting(int tenentID, int UserID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Check_CustomerSetting", conn);


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@TenentID", tenentID);
               

                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                bool Status = (bool)cmd.Parameters["@Status"].Value;
                conn.Close();
                return Status;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static bool CheckForPOSSetting(int tenentID, int UserID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Check_POSSetting", conn);


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@TenentID", tenentID);


                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                bool Status = (bool)cmd.Parameters["@Status"].Value;
                conn.Close();
                return Status;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool LocationSetup(int tenentID, int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_LocationSetup", conn);


                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);


             

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

            
                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static bool Set_POSSetting(int tenentID, int UserID,bool chkname)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Set_POSSetting", conn);


                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@checkname", chkname);




                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool CustomerSetting(int tenentID, int UserID,bool IsCustomer)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CustomerSetting", conn);


                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@IsCustomer", IsCustomer);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static bool ImportPriceAndBR(int tenentID, int LocationID,int ProdID,string UserProdID,decimal Price,decimal msrp,string currency,int uom,decimal onhand)
        {
 
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_Price", conn);

                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@ProdID", ProdID);
                cmd.Parameters.AddWithValue("@UserProdID", UserProdID);
                cmd.Parameters.AddWithValue("@ORIGINALPRICE", Price);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@msrp", msrp);
                cmd.Parameters.AddWithValue("@basecost", msrp);
                cmd.Parameters.AddWithValue("@COMPANYID", 0);
                cmd.Parameters.AddWithValue("@currency", currency);
                cmd.Parameters.AddWithValue("@UOM", uom);
                cmd.Parameters.AddWithValue("@OnHand", onhand);
            
             




                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_BR(int tenentID, int LocationID, int ProdID,  decimal msrp,decimal price, int uom, decimal onhand)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_BrOPening", conn);

                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@ProdID", ProdID);
             
                cmd.Parameters.AddWithValue("@msrp", msrp);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@UOM", uom);
                cmd.Parameters.AddWithValue("@OnHand", onhand);






                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_ICIT_Price(int tenentID, int LocationID,int myprodid,int uom, decimal Price, decimal msrp)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_ICIT_Price", conn);

                cmd.Parameters.AddWithValue("@TenentID", tenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@itemID", myprodid);

                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@msrp", msrp);
                cmd.Parameters.AddWithValue("@UOMID",uom );
           





                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


                conn.Close();
                return true;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void Create_LPO(int TenentID,int DraftID,string LpoName,string NameArabic, int SupplierID, int ProjectID, string refference, string batchno, string Note,int UserID,int LocationID,  out bool Status, DataTable LPOdt,out int LPOID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Create_LPO", conn);


                cmd.Parameters.AddWithValue("@LPOType", LPOdt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DraftID", DraftID);
                cmd.Parameters.AddWithValue("@LPOName", LpoName);
                cmd.Parameters.AddWithValue("@NameArabic", NameArabic);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                cmd.Parameters.AddWithValue("@RefferenceNo", refference);
                cmd.Parameters.AddWithValue("@BatchNo", batchno);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LPOID", SqlDbType.Int);
                cmd.Parameters["@LPOID"].Direction = ParameterDirection.Output;


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;
                LPOID = (int)cmd.Parameters["@LPOID"].Value;
                conn.Close();





            }
            catch (Exception ex)
            {
                Status = false;
                LPOID = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Reverse_InvoiceQt(int TenentID, int LocationID, int ProdID, Int64 SaleID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Reverse_InvoiceQty", conn);


                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MyprodID", ProdID);
                cmd.Parameters.AddWithValue("@Sales_id", SaleID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();





            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static void Delete_Sales_Prod(int TenentID , int LocationID ,int ProdID,Int64 SaleID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Delete_Sales_Item", conn);


                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MyprodID", ProdID);
                cmd.Parameters.AddWithValue("@Sales_id", SaleID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();





            }
            catch (Exception ex)
            {
            

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void Create_Sale_Payment(int TenentID,int LocationID,int ID, int sales_id,string payment_type,string Reffrance,decimal payment_amount,decimal change_amount, decimal due_amount,
            decimal dis, decimal vat,string sales_time,int c_id,string emp_id,string comment,int Shopid , decimal ovdisrate , decimal vaterate,string InvoiceNO,string Customer, decimal Delivery_Cahrge,string PaymentStutas,string uploadby,int ShiftID,out bool Status)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_Sale_Payment", conn);

                cmd.Parameters.AddWithValue("@vat", vat);
                cmd.Parameters.AddWithValue("@sales_time", sales_time);
                cmd.Parameters.AddWithValue("@c_id", c_id);
                cmd.Parameters.AddWithValue("@emp_id", emp_id);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@shopid", Shopid);
                cmd.Parameters.AddWithValue("@ovdisrate", ovdisrate);
                cmd.Parameters.AddWithValue("@vaterate", vaterate);
                cmd.Parameters.AddWithValue("@InvoiceNO", InvoiceNO);
                cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@Delivery_Cahrge", Delivery_Cahrge);
                cmd.Parameters.AddWithValue("@PaymentStutas", PaymentStutas);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);


                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@sales_id", sales_id);
                cmd.Parameters.AddWithValue("@payment_type", payment_type);
                cmd.Parameters.AddWithValue("@Reffrance", Reffrance);
                cmd.Parameters.AddWithValue("@payment_amount", payment_amount);
                cmd.Parameters.AddWithValue("@change_amount", change_amount);
                cmd.Parameters.AddWithValue("@due_amount", due_amount);
                cmd.Parameters.AddWithValue("@dis", dis);
                cmd.Parameters.AddWithValue("@uploadby", uploadby);

                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                


               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;
        
                conn.Close();





            }
            catch (Exception ex)
            {
                Status = false;
               

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Create_Sale_Paymentreturn(int TenentID, int LocationID, int ID, Int64 sales_id, string payment_type, string Reffrance, decimal payment_amount, decimal change_amount, decimal due_amount,
           decimal dis, decimal vat, string sales_time, int c_id, string emp_id, string comment, int Shopid, decimal ovdisrate, decimal vaterate, string InvoiceNO, string Customer, decimal Delivery_Cahrge, string PaymentStutas, string uploadby, int ShiftID, out bool Status)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_Sale_PaymentReturn", conn);

                cmd.Parameters.AddWithValue("@vat", vat);
                cmd.Parameters.AddWithValue("@sales_time", sales_time);
                cmd.Parameters.AddWithValue("@c_id", c_id);
                cmd.Parameters.AddWithValue("@emp_id", emp_id);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@shopid", Shopid);
                cmd.Parameters.AddWithValue("@ovdisrate", ovdisrate);
                cmd.Parameters.AddWithValue("@vaterate", vaterate);
                cmd.Parameters.AddWithValue("@InvoiceNO", InvoiceNO);
                cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@Delivery_Cahrge", Delivery_Cahrge);
                cmd.Parameters.AddWithValue("@PaymentStutas", PaymentStutas);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);


                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@sales_id", sales_id);
                cmd.Parameters.AddWithValue("@payment_type", payment_type);
                cmd.Parameters.AddWithValue("@Reffrance", Reffrance);
                cmd.Parameters.AddWithValue("@payment_amount", payment_amount);
                cmd.Parameters.AddWithValue("@change_amount", change_amount);
                cmd.Parameters.AddWithValue("@due_amount", due_amount);
                cmd.Parameters.AddWithValue("@dis", dis);
                cmd.Parameters.AddWithValue("@uploadby", uploadby);

                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;




                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;

                conn.Close();





            }
            catch (Exception ex)
            {
                Status = false;


            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Create_Stock_Transfer(int TenentID, int DraftID, string Reffernce, string Note, int FromLocation,int ToLocation, int UserID, DataTable StockDt,  out bool Status, out int StockID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Create_Stock_Transfer", conn);


                cmd.Parameters.AddWithValue("@TransferType", StockDt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@DraftID", DraftID);
                cmd.Parameters.AddWithValue("@Refference", Reffernce);
                cmd.Parameters.AddWithValue("@FromLocation", FromLocation);
                cmd.Parameters.AddWithValue("@ToLocation", ToLocation);
              
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LPOID", SqlDbType.Int);
                cmd.Parameters["@LPOID"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Er", SqlDbType.VarChar,500);
               
                cmd.Parameters["@Er"].Direction = ParameterDirection.Output;


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;
                StockID = (int)cmd.Parameters["@LPOID"].Value;
                string er = (string)cmd.Parameters["@Er"].Value;
                conn.Close();

            }
            catch (Exception ex)
            {
                Status = false;
                StockID = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Edit_ConfirmOrder(int TenentID,int LocationID,Int64 mytransid,int SupplierID,string PaymentType,String TransDate,string InvoiceNo,string PaymentStatus,decimal PaymentAmount,decimal Balance)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Edit_ConfirmPurchase", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@MyTransID", mytransid);
                cmd.Parameters.AddWithValue("@ActivityDate", TransDate);
                cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                cmd.Parameters.AddWithValue("@paymentstatus", PaymentStatus);
                cmd.Parameters.AddWithValue("@paymentamount", PaymentAmount);
                cmd.Parameters.AddWithValue("@paymentbalance", Balance);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
               

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Delete_Payment(int TenentID, Int64 SaleID,int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Delete_Payment_Invoice", conn);

                cmd.Parameters.AddWithValue("@SaleID", SaleID);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
               

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Delete_Voucher(int TenentID, string VoucherCode, int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Get_DeleteVoucher", conn);

                cmd.Parameters.AddWithValue("@vouchercode", VoucherCode);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@locationID", LocationID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void Delete_Draft(int TenentID, int DraftID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Delete_Draft", conn);

                cmd.Parameters.AddWithValue("DraftID", DraftID);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void Update_HDSale( ICTR_HD_Sales obj)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Update_SaleHD", conn);


                cmd.Parameters.AddWithValue("@MYTRANSID", obj.MYTRANSID);
                cmd.Parameters.AddWithValue("@locationID", obj.locationID);
                cmd.Parameters.AddWithValue("@COMPID", obj.COMPID);
                cmd.Parameters.AddWithValue("@PaymentStatus", obj.PaymentStatus);
                cmd.Parameters.AddWithValue("@TenentID", obj.TenentID);
                cmd.Parameters.AddWithValue("@OrderStatus", obj.OrderStatus);
                cmd.Parameters.AddWithValue("@DeliveryStatus", obj.DeliveryStatus);
                cmd.Parameters.AddWithValue("@Status", obj.Status);
                cmd.Parameters.AddWithValue("@Orderway", obj.Orderway);

                cmd.Parameters.AddWithValue("@TOTAMT", obj.TOTAMT);
                cmd.Parameters.AddWithValue("@USERID", obj.USERID);
               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
         

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void Update_CatMST(CAT_MST obj)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Edit_Cat_mst", conn);

  
                cmd.Parameters.AddWithValue("@TenentID", obj.TenentID);
                cmd.Parameters.AddWithValue("@CatID", obj.CATID);
                cmd.Parameters.AddWithValue("@Parent_ID", obj.PARENT_CATID);
                cmd.Parameters.AddWithValue("@Short_Name", obj.SHORT_NAME);
                cmd.Parameters.AddWithValue("@CAT_Name1", obj.CAT_NAME1);
                cmd.Parameters.AddWithValue("@CAT_Name2", obj.CAT_NAME2);
                cmd.Parameters.AddWithValue("@CAT_Name3", obj.CAT_NAME3);
                cmd.Parameters.AddWithValue("@CAT_Desc", obj.CAT_DESCRIPTION);
                cmd.Parameters.AddWithValue("@Cat_Type", obj.CAT_TYPE);
                cmd.Parameters.AddWithValue("@SupplierPercent", obj.SupplierPercent);
                cmd.Parameters.AddWithValue("@Switch1", obj.switch1);
                cmd.Parameters.AddWithValue("@Switch2", obj.switch2);
                cmd.Parameters.AddWithValue("@AlwaysShow", obj.AlwaysShow);
                cmd.Parameters.AddWithValue("@Switch3", obj.switch3);
                cmd.Parameters.AddWithValue("@color", obj.COLOR_NAME);
                cmd.Parameters.AddWithValue("@Warranty", obj.WARRANTY);
                cmd.Parameters.AddWithValue("@Pic", obj.DefaultPic);
                cmd.Parameters.AddWithValue("@Active", obj.Active);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static void Receive_Stock_Transfer(int TenentID,DataTable stockdt, int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
     
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Stock_Transfer_Receive", conn);

                cmd.Parameters.AddWithValue("@TransferType", stockdt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.Add("@Stat", SqlDbType.VarChar,1000);
                cmd.Parameters["@Stat"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                string a = cmd.Parameters["@Stat"].Value.ToString();


                conn.Close();

            }
            catch (Exception ex)
            {
               

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }



        public static void Create_Delivery(int TenentID, int LPOID, string Note, int UserID,string DeliveryDate ,  DataTable DeliveryDt,out bool Status,out int DeliveryID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Create_Delivery", conn);


                cmd.Parameters.AddWithValue("@DType", DeliveryDt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);
                cmd.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);

                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.Add("@Status", SqlDbType.Bit);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DelID", SqlDbType.Int);
                cmd.Parameters["@DelID"].Direction = ParameterDirection.Output;


                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Status = (bool)cmd.Parameters["@Status"].Value;
                DeliveryID = (int)cmd.Parameters["@DelID"].Value;
                conn.Close();





            }
            catch (Exception ex)
            {
                Status = false;
                DeliveryID = 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool CheckDraft(int TenentID,int ItemID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("CheckDraftItem", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);


                cmd.Parameters.Add("@Check", SqlDbType.Bit);
                cmd.Parameters["@Check"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

               bool Status=  (bool)cmd.Parameters["@Check"].Value;
                conn.Close();
                return Status;





            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static Int64 GetInvoiceNoPurchase(int TenentID, int LocationID, int TerminalID, out int InvoiceNo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                
                cmd = new SqlCommand("Get_InvoiceNopurchase", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                cmd.Parameters.Add("@SaleID", SqlDbType.Int);
                cmd.Parameters["@SaleID"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                if(conn != null && conn.State == ConnectionState.Closed)
                { 
                conn.Open();
                }
                cmd.ExecuteNonQuery();
                int SalesID = Convert.ToInt32(cmd.Parameters["@SaleID"].Value);
                //string Tenent = TenentID.ToString().PadLeft(3, '0');
                //string location = LocationID.ToString().PadLeft(2, '0');
                //string Terminal = TerminalID.ToString().PadLeft(2, '0');
                Int64 NewSaleid = Int64.Parse(2101.ToString() + SalesID.ToString());
                conn.Close();
                InvoiceNo = SalesID;
                return NewSaleid;

            }
            catch (Exception ex)
            {
                InvoiceNo = 0;
                return 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static Int64 GetInvoiceNo(int TenentID, int LocationID,int TerminalID , out int InvoiceNo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Get_InvoiceNo", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@TerminalID", TerminalID);
                cmd.Parameters.Add("@SaleID", SqlDbType.Int);
                cmd.Parameters["@SaleID"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                int SalesID = Convert.ToInt32(cmd.Parameters["@SaleID"].Value);
                string Tenent = TenentID.ToString().PadLeft(3, '0');
                string location = LocationID.ToString().PadLeft(2, '0');
                string Terminal = TerminalID.ToString().PadLeft(2, '0');
                Int64 NewSaleid = Int64.Parse(Tenent.ToString() + location.ToString() + Terminal.ToString() + SalesID.ToString());
                conn.Close();
                InvoiceNo = SalesID;
                return NewSaleid;

            }
            catch (Exception ex)
            {
                InvoiceNo=0;
                return 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static Int64 GetVoucherCode(int TenentID, int LocationID, out int InvoiceNo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Account_GetVoucherCode", conn);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
   
                cmd.Parameters.Add("@VoucherCode", SqlDbType.Int);
                cmd.Parameters["@VoucherCode"].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                int SalesID = Convert.ToInt32(cmd.Parameters["@VoucherCode"].Value);
              
                conn.Close();
                InvoiceNo = SalesID;
                return SalesID;

            }
            catch (Exception ex)
            {
                InvoiceNo = 0;
                return 0;

            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool Stockeffect(int TenentID, int ItemCode,decimal Qty,string IoSwitch,int ProductionID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("StockEffect_Recipe", conn);
              

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MyProductID", ItemCode);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@IOSwitch", IoSwitch);
                cmd.Parameters.AddWithValue("@ProductionID", ProductionID);


                cmd.CommandType = CommandType.StoredProcedure;
              int effect =  cmd.ExecuteNonQuery();
                if(effect == 1)
                {
                    conn.Close();
                    return true;
                   
                }
                else
                { conn.Close(); return false;  }
               
                

               

            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
              
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static void LPODelivery( int ItemCode,int LPOID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("LPO_Delivery", conn);


                cmd.Parameters.AddWithValue("@ItemID", ItemCode);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);
              
                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();
                if (effect == 1)
                {
                    conn.Close();
                   

                }
                else
                { conn.Close(); }





            }
            catch (Exception ex)
            {

               
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool LPO_Draft(int TenentID,int FromLocation,int ToLocation, int RecipeID, decimal RecipeQty,string batchno,DataTable DraftDt,int UserID,out int Check,out int DraftID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_LPO_Draft", conn);
             
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@FromLocation", FromLocation);
                cmd.Parameters.AddWithValue("@ToLocation", ToLocation);
                cmd.Parameters.AddWithValue("@RecipeID", RecipeID);
                cmd.Parameters.AddWithValue("@RecipeQty", RecipeQty);
                cmd.Parameters.AddWithValue("@batchno", batchno);
                cmd.Parameters.AddWithValue("@Draft_Type", DraftDt);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.Add("@Check", SqlDbType.Int);
                cmd.Parameters["@Check"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DraftID", SqlDbType.Int);
                cmd.Parameters["@DraftID"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();
                
                    conn.Close();
                Check = (int)cmd.Parameters["@Check"].Value;
                DraftID = (int)cmd.Parameters["@DraftID"].Value;
                return true;


            }
            catch (Exception ex)
            {
                Check = 2;
                DraftID = 0;
                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static bool Insert_DayClosePayment(int TenentID, int UserID, int LocationID, int ShiftID,string CloseDate,decimal CashOnHand,DataTable daydt,out int status)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Dayclose_payment_insertion", conn);

                cmd.Parameters.AddWithValue("@DayCloseType", daydt);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@ShiftID", ShiftID);

                cmd.Parameters.AddWithValue("@CloseDate", CloseDate);
             
                cmd.Parameters.AddWithValue("@CashOnHand", CashOnHand);
             
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();
                status = int.Parse(cmd.Parameters["@Status"].Value.ToString());
                return true;


            }
            catch (Exception ex)
            {
                status = 0;
                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_User_Location(int TenentID, int UserID,int LocationID,int Assignby)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_User_Locations", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Assignby", Assignby);
              

                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();
              
                return true;


            }
            catch (Exception ex)
            {
             
                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Insert_Term_Location(int TenentID, int TermID, int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Insert_Term_Location", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TerminalID", TermID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);



                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }


        public static bool delete_User_Location(int TenentID, int UserID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Delete_User_Locations", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
              

                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool delete_Term_Location(int TenentID, int LocationID)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Delete_Term_Locations", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);


                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Edit_User_Location(int TenentID, int LocationID,string UserName,string Password)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Update_User_Location", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);


                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static bool Edit_StockTransfer(int TenentID, int TransferID,string Refference,string Note,int FromLocation,int ToLocation ,DataTable Stock)
        {

            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {

                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand("Edit_StockTransfer", conn);
               
                cmd.Parameters.AddWithValue("@StockType", Stock);
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@TransferID", TransferID);
                cmd.Parameters.AddWithValue("@Ref", Refference);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@FromLocation", FromLocation);
                cmd.Parameters.AddWithValue("@ToLocation", ToLocation);


                cmd.CommandType = CommandType.StoredProcedure;
                int effect = cmd.ExecuteNonQuery();

                conn.Close();

                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {

                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Draft(int TenentID,int UserID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_DraftLPO", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", @UserID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_CrmMainActivity(int TenentID, int MasterCode)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_CrmMainActivity", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MasterCode", MasterCode);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint(int TenentID, int UserID,string mystatus,string activity,int Years)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint", conn);
            
                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);
                cmd.Parameters.AddWithValue("@ACTIVITYE", activity);
                cmd.Parameters.AddWithValue("@dtyear", Years);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint_DashBaord(int TenentID, int UserID, string mystatus, String UploadDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint_Dashboard", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);
     
                cmd.Parameters.AddWithValue("@UploadDate", UploadDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint_DashBaordMonthYear(int TenentID, int UserID, string mystatus)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint_Dashboard_MonthYear", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint_DashBaordYear(int TenentID, int UserID, string mystatus)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint_Dashboard_Year", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint_Grid(int TenentID, int UserID, string Type,string SearchParam)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Grid_Complaint", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@SearchParam", SearchParam);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Complaint_DashBaord_Month(int TenentID, int UserID, string mystatus, String FromDate,String ToDate)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint_Dashboard_Month", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);

                cmd.Parameters.AddWithValue("@StartDate", FromDate);
                cmd.Parameters.AddWithValue("@EndDate", ToDate);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public static DataTable Get_Complaint_MasterCode(int TenentID, int MyID, string mystatus, int MasterCode)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Complaint_Get_Complaint_MasterCode", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@MyID", MyID);
                cmd.Parameters.AddWithValue("@MyStatus", mystatus);

                cmd.Parameters.AddWithValue("@MasterCode", MasterCode);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_paymentpurchase(int TenentID,int LocationID, int UserID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_Purchase_Payment", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("LocationID", LocationID);
                cmd.Parameters.AddWithValue("@MyTransID", @UserID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_Delivery(int TenentID, int LPOID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_LPO_Delivery", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                cmd.Parameters.AddWithValue("@LPOID", LPOID);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }

        public static DataTable Get_PendingDraft(int TenentID)
        {


            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("Get_pendingDraft", conn);

                cmd.Parameters.AddWithValue("@TenentID", TenentID);
                
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                conn.Open();
                Adapter.Fill(dt);
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    return dt;
                }
                else
                {
                    return dt;
                    // throw new Exception("No Record Found");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }

        }
    }
}
