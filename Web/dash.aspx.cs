using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Classes;

namespace Web
{
    public partial class dash : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
        SqlCommand command2 = new SqlCommand();
        CallEntities DB = new CallEntities();
        int TID, LID, stMYTRANSID, UID, EMPID, Transid, Transsubid, CID, userID1, userTypeid = 0;
        string LangID, CURRENCY, USERID, Crypath = "";
        string MNAME = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID); //Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (!IsPostBack)
            {
                bindDrop();
                POSAllTranc();
                DayCloseEntry();
                GetCashData();
                string DateNow = DateTime.Now.ToString("yyyy-MM-dd");
                Decimal TodaySale = 0;
                Decimal MonthlySale = 0;
                Decimal YearlySale = 0;
                Decimal ReturnSale = 0;

                Decimal MorningShift = 0;
                Decimal afternoonshift = 0;
                Decimal eveningshift = 0;
                Decimal nightshift = 0;
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                DAL.Dashboard_Report(TID, LID, DateNow, out TodaySale, out MonthlySale, out YearlySale,out ReturnSale);
                lbltodaysale.Text = TodaySale.ToString();
                lblMonthlySale.Text = MonthlySale.ToString();
                lblyearlySale.Text = YearlySale.ToString();
                lblsalereturn.Text = ReturnSale.ToString();


                DAL.Dashboard_Shift(TID, LID, DateNow, out MorningShift, out afternoonshift, out eveningshift, out nightshift);
                lblmorningsale.Text = MorningShift.ToString();
                lblafternoonsale.Text = afternoonshift.ToString();
                lbleveningsale.Text = eveningshift.ToString();
                lblnightsale.Text = nightshift.ToString();
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                var list = DB.DayCloses.Where(p => p.TenentID == TID && p.UserID == UID);
                decimal SUM = Convert.ToDecimal(list.Sum(m => m.ShiftSales));
                decimal Sums = Convert.ToDecimal(list.Sum(m => m.ShiftPurchase));
               // lblCashAmt.Text = "KD " + SUM.ToString();
               // lblShiftPurchase.Text = "KD " + Sums.ToString();
            }
           // Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "WelCome To POS Dashboad", "WelCome!", Classes.Toastr.ToastPosition.TopCenter);
          

        }
        public void ClosePriShift()
        {
            //select * from DayClose where ShiftStutas=0 order by ID desc limit 1
            string DateNow = DateTime.Now.ToString("yyyy-MM-dd");
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            string Condition = "where TenentID=" + TID + " and LocationID=" + LID + "  and Convert(Date, Date) != '" + DateNow + "' and ShiftStutas = 1 order by ID desc ";

            string sql1 = "Select top(1) ShiftID from DayClose " + Condition;
            SqlCommand CMD11 = new SqlCommand(sql1, con);
            SqlDataAdapter bb = new SqlDataAdapter(CMD11);
            DataSet ss = new DataSet();
            bb.Fill(ss);
            DataTable dt5 = ss.Tables[0];
            if (dt5.Rows.Count > 0)
            {
                decimal todayCash = 0;
                string Userid = "";
                string Shopid = "";
                string ShiftID = "";
                string Date = "";

                string sql = "select ((OpAMT + ShiftSales) - (ABS(ShiftReturn)  + ExpAMT  + AMTDelivered + Shiftpurchase  )) as TodayCash,OpAMT,ShiftSales,ChequeAMT,VoucharAMT, " +
                             " ExpAMT,ShiftReturn,Shiftpurchase,RefNO,AMTDelivered,undeliverdAMT,DeliveredTO,UserID,TrmID,ShiftID,Date  from DayClose " + Condition;
                SqlCommand cmd1 = new SqlCommand(sql, con);
                SqlDataAdapter bd = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                bd.Fill(ds);
                DataTable dt6 = ds.Tables[0];
                if (dt6.Rows.Count > 0)
                {
                    todayCash = Convert.ToDecimal(dt6.Rows[0]["TodayCash"]);
                    Userid = dt6.Rows[0]["UserID"].ToString();
                    Shopid = dt6.Rows[0]["TrmID"].ToString();
                    ShiftID = dt6.Rows[0]["ShiftID"].ToString();
                    Date = dt6.Rows[0]["Date"].ToString();

                }
                DateTime datevlaue = Convert.ToDateTime(Date);
                string dtvalue = datevlaue.ToString("yyyy-MM-dd");
                decimal TodayShiftCash = todayCash;
                decimal AMTDelivered = todayCash;

                string UploadDate = DateTime.Now.ToString("yyyy-MM-dd");

                string sqlupdate = " update DayClose set ShiftCIH=" + TodayShiftCash + " , undeliverdAMT=" + AMTDelivered + ",Employee=" + UserInfo.Userid + ",ShiftStutas=0, " +
                             " Uploadby= '" + UserInfo.UserName + "' , UploadDate = '" + UploadDate + "' , SynID = 2 " +
                             " where TenentID=" + TID + " and UserID = '" + Userid + "' and LocationID = " + LID + " and ShiftID = " + ShiftID + " and convert(Date,Date) = '" + dtvalue + "' ";
                SqlCommand editcmd = new SqlCommand(sqlupdate, con);
                con.Open();
                editcmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void LastShiftData()
        {
            string DateNow = DateTime.Now.ToString("yyyy-MM-dd");
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
           
                string SQl = "SELECT top(1) ISNULL(undeliverdAMT,0) as undeliverdAMT FROM DayClose where TenentID=" + TID + "  and LocationID = " + LID + " ORDER BY ID DESC";
            SqlCommand CMD11 = new SqlCommand(SQl, con);
            SqlDataAdapter bb = new SqlDataAdapter(CMD11);
            DataSet ss = new DataSet();
            bb.Fill(ss);
            DataTable dt5 = ss.Tables[0];
            if (dt5.Rows.Count > 0)
                {
                    txtOpeningbalance.Text = dt5.Rows[0]["undeliverdAMT"].ToString();
                }
           
        }
        public void DayCloseEntry()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            List<Database.DayClose> listmultiuom1 = new List<DayClose>();
            string CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt5 = DAL.Get_DayCloseEntry(TID, LID, CurrentDate);
            if(dt5.Rows.Count == 0)
            {
                ClosePriShift();
                LastShiftData();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#pnlopening').modal();});", true);
              
            }
            else
            {
                DataTable MaxIDdt = DAL.Get_DayCloseMaxID(TID, LID);
                int ID = int.Parse( MaxIDdt.Rows[0][0].ToString());// DB.DayCloses.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.DayCloses.Where(p => p.TenentID == TID && p.UserID == UID).Max(p => p.ID)) : 1;
                Session["ID"] = ID;
                DataTable ShiftDt = DAL.Get_DayClose_ShiftID(TID, LID);
                Session["ShiftID"] = ShiftDt.Rows[0][0].ToString();
            }
        }
        protected void btnopenshift_Click(object sender, System.EventArgs e)
        {
            adddayclose();
        }
        public void checksession()
        {
            if (Session["USER"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        public void bindDrop()
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            drpshift.DataSource = DB.Win_tbl_Shift;
            drpshift.DataTextField = "Shift_Name";
            drpshift.DataValueField = "ID";
            drpshift.DataBind();
         
            drpshiftby.DataSource = DB.Win_tbl_Shift;
            drpshiftby.DataTextField = "Shift_Name";
            drpshiftby.DataValueField = "ID";
            drpshiftby.DataBind();
            setshift();
         


            List<Database.DayClose> CloseList = DB.DayCloses.Where(p => p.TenentID == TID).ToList();
            DrpCloseDate.DataSource = CloseList;
            DrpCloseDate.DataTextField = "Date";
            DrpCloseDate.DataValueField = "Date";
            DrpCloseDate.DataBind();
            DrpCloseDate.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Date --", "0"));
            if (CloseList.Count() > 0)
            {
                DrpCloseDate.SelectedValue = CloseList.OrderBy(p => p.ID).Last().Date.ToString();
            }
        }
        public void setshift()
        {
            if (DateTime.Now.Hour < 12)
            {
                drpshift.SelectedValue = "1";
                drpshiftby.SelectedValue = "1";
            }
            else if (DateTime.Now.Hour < 16)
            {
                drpshift.SelectedValue = "2";
                drpshiftby.SelectedValue = "2";
            }
            else if (DateTime.Now.Hour < 20)
            {
                drpshift.SelectedValue = "3";
                drpshiftby.SelectedValue = "3";
            }
            else
            {
                drpshift.SelectedValue = "4";
                drpshiftby.SelectedValue = "4";
            }
        }
        public void GetCashData()
        {
            string Shopid = "1";
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            if (DB.Win_usermgt.Where(p => p.TenentID == TID).Count() > 0)
            {
                Shopid = DB.Win_usermgt.Where(p => p.TenentID == TID).First().Shopid;
            }
            string Date = "";
            if (DrpCloseDate.SelectedValue == "0")
            {
                return;
            }
            else
            {
                Date = Convert.ToDateTime(DrpCloseDate.SelectedValue).ToString("yyyy-MM-dd");
            }

            decimal todayCash = 0;
            decimal OpAMT = 0;
            decimal ShiftSales = 0;
            decimal ChequeAMT = 0;
            decimal VoucharAMT = 0;
            decimal ExpAMT = 0;
            decimal ShiftReturn = 0;
            decimal Shiftpurchase = 0;
            decimal AMTDelivered = 0;
            decimal undeliverdAMT = 0;
            int DeliveredTO = 0;

            string RefNO = "";
            //int ValidShif = getShiftID();

            String Username = ((USER_MST)Session["USER"]).LOGIN_ID;
            int LocID = ((USER_MST)Session["USER"]).LOCATION_ID;
            string ShiftID = drpshift.SelectedValue.ToString();
            string Condition1 = "where TenentID=" + TID + " and ShiftID = " + ShiftID + " and LocationID=" + LocID + " and CONVERT(Date,Date) = '" + Date + "'";

            string sql1 = "select ((OpAMT + Abs(ShiftSales)) - (Abs(ShiftReturn) + Abs(VoucharAMT) - Abs(ExpAMT)  -  Abs(Shiftpurchase)  )) as TodayCash,OpAMT,ShiftSales,ChequeAMT,VoucharAMT,ExpAMT,ShiftCIH,ShiftReturn,Shiftpurchase,RefNO,IsNULL(AMTDelivered,0) as AMTDelivered,IsNULL(undeliverdAMT,0) as undeliverdAMT,DeliveredTO from DayClose " + Condition1;
            SqlCommand CMD11 = new SqlCommand(sql1, con);
            SqlDataAdapter bb = new SqlDataAdapter(CMD11);
            DataSet ss = new DataSet();
            bb.Fill(ss);
            DataTable dt11 = ss.Tables[0];
            if (dt11.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt11.Rows[0]["TodayCash"]);
                OpAMT = Convert.ToDecimal(dt11.Rows[0]["OpAMT"]);
                ShiftSales = Convert.ToDecimal(dt11.Rows[0]["ShiftSales"]);
                ChequeAMT = Convert.ToDecimal(dt11.Rows[0]["ChequeAMT"]);
                VoucharAMT = Convert.ToDecimal(dt11.Rows[0]["VoucharAMT"]);
                ExpAMT = Convert.ToDecimal(dt11.Rows[0]["ExpAMT"]);
                ShiftReturn = Convert.ToDecimal(dt11.Rows[0]["ShiftReturn"]);
                Shiftpurchase = Convert.ToDecimal(dt11.Rows[0]["Shiftpurchase"]);
                RefNO = dt11.Rows[0]["RefNO"].ToString();
                AMTDelivered = Convert.ToDecimal(dt11.Rows[0]["AMTDelivered"]);
                undeliverdAMT = Convert.ToDecimal(dt11.Rows[0]["undeliverdAMT"]);
                if (dt11.Rows[0]["DeliveredTO"] != DBNull.Value)
                    DeliveredTO = Convert.ToInt32(dt11.Rows[0]["DeliveredTO"]);
            }
            lblOpeningamt.Text = OpAMT.ToString("N3");
            lblTodayShiftCash.Text = todayCash.ToString("N3");
            lblCashAmt.Text = ShiftSales.ToString("N3");
            lblChequeAmt.Text = ChequeAMT.ToString("N3");
            lblVouchar.Text = VoucharAMT.ToString("N3");
            lblExpense.Text = ExpAMT.ToString("N3");
            lblReturnAmt.Text = ShiftReturn.ToString("N3");
            lblShiftPurchase.Text = Shiftpurchase.ToString("N3");
            lblReference.Text = RefNO;
            if (dt11.Rows.Count > 0)
            {
                POSAllTranc();
            }
        }

        public void adddayclose()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
        bool Status=    DAL.Get_DayClose_Insertion(TID, UID, LID, int.Parse( drpshiftby.SelectedValue.ToString()),decimal.Parse(txtOpeningbalance.Text));
          if(Status)
            {
                Session["ShiftID"] = drpshiftby.SelectedValue.ToString();
            }
            //Database.DayClose objday = new Database.DayClose();
            //objday.TenentID = TID;
            //int ID = DB.DayCloses.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.DayCloses.Where(p => p.TenentID == TID).Max(p => p.ID) + 1) : 1;
            //objday.ID = ID;
            //objday.UserID = UID;
            //objday.TrmID = "1";
            //objday.ShiftID = 1;
            //objday.Date = DateTime.Now;
            //objday.OpAMT = 0;
            //objday.ShiftSales = 0;
            //objday.ShiftReturn = 0;
            //objday.ShiftPurchase = 0;
            //objday.ShiftCIH = 0;
            //objday.VoucharAMT = 0;
            //objday.ExpAMT = 0;
            //objday.ChequeAMT = 0;
            //objday.AMTDelivered = 0;
            //objday.DeliveredTO = 0;
            //objday.undeliverdAMT = 0;
            //objday.RefNO = TID + UID + name + DateTime.Now;
            //objday.Notes = "";
            //objday.UploadDate = DateTime.Now.ToString();
            //objday.Uploadby = name;
            //objday.SynID = 9;
            //objday.ShiftStutas = 1;
            //objday.Employee = 1;
            //DB.DayCloses.AddObject(objday);
            //DB.SaveChanges();
            DataTable MaxIDdt = DAL.Get_DayCloseMaxID(TID, LID);
            int ID = int.Parse(MaxIDdt.Rows[0][0].ToString());// DB.DayCloses.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.DayCloses.Where(p => p.TenentID == TID && p.UserID == UID).Max(p => p.ID)) : 1;
            Session["ID"] = ID;
        }
        public void POSAllTranc()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            string Shopid = "";
            if (DB.Win_usermgt.Where(p => p.TenentID == TID).Count() > 0)
            {
                Shopid = DB.Win_usermgt.Where(p => p.TenentID == TID).First().Shopid;
            }
            string stdate = "";
            if (DrpCloseDate.SelectedValue == "0")
            {
                return;
            }
            else
            {

                //DateTime startdate = Convert.ToDateTime(DrpCloseDate.SelectedValue);
                //string stdatea = startdate.ToString("yyyy-MM-dd");
                //string onlytime = " 12:00:00 AM";
                //string onlytime1 = " 11:59:59 PM";
                //string dates = DrpCloseDate.SelectedValue;
                //string date1 = stdatea + onlytime;
                //DateTime stdates = Convert.ToDateTime(date1);
                //DateTime stud2 = Convert.ToDateTime(stdatea + onlytime1);

                //string com = "select * from ICTR_DT_Sales where TenentID=" + TID + " and EXPIRYDATE BETWEEN '" + stdates + "' AND    '" + stud2 + "'";
                //SqlCommand CMDs = new SqlCommand(com, con);
                //SqlDataAdapter ADBs = new SqlDataAdapter(CMDs);
                //DataSet dss = new DataSet();
                //ADBs.Fill(dss);
                //DataTable dts = dss.Tables[0];
                //ListView3.DataSource = dts;
                //ListView3.DataBind();
            }



        }
        protected void drpshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCashData();
            POSAllTranc();

        }

        protected void DrpCloseDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCashData();
            POSAllTranc();
        }
        protected void lblTodayShiftCash_Click(object sender, EventArgs e)
        {
            POSAllTranc();
        }
        public string GetCust(int ID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.TBLCOMPANYSETUPs.Where(p => p.COMPID == ID && p.TenentID == TID).Count() > 0)
            {
                string ProductCode = DB.TBLCOMPANYSETUPs.Single(p => p.COMPID == ID && p.TenentID == TID).COMPNAME1;
                return ProductCode;
            }
            else
            {
                return "Record Not Found";
            }
        }
        public string GetItemeN(int ID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.TBLPRODUCTs.Where(p => p.MYPRODID == ID && p.TenentID == TID).Count() > 0)
            {
                string ProductCode = DB.TBLPRODUCTs.Single(p => p.MYPRODID == ID && p.TenentID == TID).ProdName1;
                return ProductCode;
            }
            else
            {
                return "Record Not Found";
            }
        }
        protected void ListView3_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label Label12 = (Label)e.Item.FindControl("Label12");
            Label Label15 = (Label)e.Item.FindControl("Label15");
            Label Label11 = (Label)e.Item.FindControl("Label15");
            string Type = Label12.Text.ToString();
            if (Type == "Cash")
            {
                Label15.Text = " (IN)";
                Label11.Attributes["class"] = "label label-success label-sm";
            }
            else
            {
                Label15.Text = " (OUT)";
                Label11.Attributes["class"] = "label label-danger label-sm";
            }
        }

        public static class UserInfo
        {
            public static string LOGO { get; set; }
            public static int Userid { get; set; }
            public static string UserName { get; set; }
            public static string UserPassword { get; set; }
            public static string usertype { get; set; }
            public static string invoiceNo { get; set; }
            public static string Shopid { get; set; }
            public static int ShiftID { get; set; }
            public static string usernamWK { get; set; }
            public static string Language { get; set; }
            public static bool addcustomerflag { get; set; }
            public static string Customer_name { get; set; }
            public static string ExpireDate { get; set; }
            public static int TenentID { get; set; }
            public static string Database_path { get; set; }
            public static string Img_path { get; set; }
            public static bool EditTransation { get; set; }
            public static string InvoicetransNO { get; set; }
            public static int Invoice { get; set; }
            public static string TranjationPerform { get; set; }
            public static string MDiPerent { get; set; }

        }
    }
}