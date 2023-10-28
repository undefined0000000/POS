using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using Web.POS;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Web.Configuration;
using AjaxControlToolkit;
using System.Transactions;
using System.Net.Http;
using System.Net.Http.Headers;
//using Newtonsoft.Json;
using System.Drawing;
using System.Collections;
using System.Net;
using System.IO;

using Web.Sales;

using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json;
using Classes;
using System.Globalization;

namespace Web
{
    public partial class OrderList : System.Web.UI.Page
    {
        CallEntities DB = new CallEntities();
        
        int Transid = 4101;
        int Transsubid = 410103;
        static private string bearerToken = ConfigurationManager.AppSettings["bearerToken"];
        static private string Baseurl = ConfigurationManager.AppSettings["Baseurl"];
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnorder]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                List<Database.DayClose> listmultiuom1 = new List<DayClose>();
                string CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt5 = DAL.Get_DayCloseEntry(TID, LID, CurrentDate);
                if (dt5.Rows.Count == 0)
                {
                    Response.Redirect("NewDemo.aspx");
                }
                    GridData(2);
               
                binddrop();
            }
        }


        public void checksession()
        {
            if (Session["USER"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        protected void BtnSearchitem_Click(object sender, System.EventArgs e)
        {
            if (generalSearch.Text != "")
            {
                checksession();
             
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                string SearchStr = generalSearch.Text.Trim();
                grdPO.DataSource = DAL.Orderlist_search(TID, LID, SearchStr); // DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && (p.CAT_NAME1.Contains(SearchStr) || p.ProdName1.Contains(SearchStr) || p.BarCode.Contains(SearchStr)));// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                grdPO.DataBind();
              
            }
        }

        public void ExportToCSV<T>(List<T> List, string FileName)
        {

            //yogesh
            if (List.Count > 0)
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName + ".csv"));
                Response.ContentType = "text/csv";
                string strValue = string.Empty;
                string CStrValue = string.Empty;
                GridView GridView1 = new GridView();
                GridView1.DataSource = List;
                GridView1.AllowPaging = false;
                GridView1.DataBind();


                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(GridView1.Rows[i].Cells[j].Text.ToString()))
                        {
                            if (j > 0)
                            {
                                if (GridView1.Rows[i].Cells[j].Text == "&nbsp;")
                                    CStrValue = "";
                                else
                                    CStrValue = GridView1.Rows[i].Cells[j].Text.ToString();
                                strValue = strValue + "," + CStrValue;

                            }
                            else
                            {
                                if (string.IsNullOrEmpty(strValue))
                                    strValue = GridView1.Rows[i].Cells[j].Text.ToString();
                                else
                                    strValue = strValue + Environment.NewLine + GridView1.Rows[i].Cells[j].Text.ToString();
                            }
                        }
                    }
                    // strValue = strValue + Environment.NewLine;
                }
                Response.Write(strValue.ToString());
                Response.End();

            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DateTime currentDt = DateTime.Now;
            int dd = currentDt.Day;
            int mm = currentDt.Month;
            int yy = currentDt.Year;
            List<Database.View_SalesControl> List = DAL.Get_OrderList(TID, LID, Transid, Transsubid, "Cancelled", dd, mm, yy, currentDt, 2).OrderByDescending(p => p.MYTRANSID).ToList();
            ExportToCSV<View_SalesControl>(List, "Order_List");

        }

        public void GridData(int isfull)
        {
            Session["ID"] = isfull.ToString();
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DateTime currentDt = DateTime.Now;
            int dd = currentDt.Day;
            int mm = currentDt.Month;
            int yy = currentDt.Year;
            DataTable dt = new DataTable();
            List<Database.View_SalesControl> listmultiuom1 = new List<View_SalesControl>();
            if (isfull == 1)//full
            {
                // listmultiuom1 = DB.View_SalesControl.Where(p => p.TenentID == TID && p.locationID == LID && p.transid == Transid && p.transsubid == Transsubid && p.locationID == LID).OrderByDescending(p => p.MYTRANSID).ToList();
                dt = DAL.Get_OrderList1(TID, LID, Transid, Transsubid, "C", 0, 0, 0, currentDt, 1);
                //lbllistDate.Text = listmultiuom1.Last().TRANSDATE.ToShortDateString() + " To " + currentDt.ToShortDateString();
            }
            else if (isfull == 2)//today
            {
                // listmultiuom1 = DB.View_SalesControl.Where(p => p.TenentID == TID && p.locationID==LID && p.TRANSDATE.Day == dd && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.transid == Transid && p.transsubid == Transsubid && p.OrderStatus != "Canceled" ).OrderByDescending(p => p.MYTRANSID).ToList();
                dt = DAL.Get_OrderList1(TID, LID, Transid, Transsubid, "Cancelled", dd, mm, yy, currentDt, 2);
               // lbllistDate.Text = currentDt.ToShortDateString();
            }
            else if (isfull == 3)//week 
            {
                DateTime mondayOfLastWeek = currentDt.AddDays(-(int)currentDt.DayOfWeek);
                // listmultiuom1 = DB.View_SalesControl.Where(p => p.TenentID == TID && p.locationID == LID && p.TRANSDATE >= mondayOfLastWeek && p.TRANSDATE <= currentDt && p.transid == Transid && p.transsubid == Transsubid).OrderByDescending(p => p.MYTRANSID).ToList();
                dt = DAL.Get_OrderList1(TID, LID, Transid, Transsubid, "Cancelled", dd, mm, yy, mondayOfLastWeek, 3);
                lbllistDate.Text = mondayOfLastWeek.ToShortDateString() + " To " + currentDt.ToShortDateString();
            }
            else if (isfull == 4)//month
            {
                var lastDayOfMonth = DateTime.DaysInMonth(currentDt.Year, currentDt.Month);
                //  listmultiuom1 = DB.View_SalesControl.Where(p => p.TenentID == TID && p.locationID == LID && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.transid == Transid && p.transsubid == Transsubid ).OrderByDescending(p => p.MYTRANSID).ToList();
                dt = DAL.Get_OrderList1(TID, LID, Transid, Transsubid, "Cancelled", dd, mm, yy,currentDt, 4);
                lbllistDate.Text = mm + "/01/" + yy + " To " + mm + "/" + lastDayOfMonth.ToString() + "/" + yy;
            }
            int count = dt.Rows.Count;
            if (count > 0)
            {
                grdPO.DataSource = dt;// listmultiuom1.Select(m => new { m.CUSTVENDID, m.TOTAMT, m.Status, m.USERID, m.TRANSDATE, m.TransDocNo, m.MYTRANSID, m.Orderway, m.PaymentStatus, m.OrderStatus, m.DeliveryStatus,m.PaymentType }).Distinct();//DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && (p.Status == "SO" || p.Status == "DSO" && p.transid == Transid && p.transsubid == Transsubid)).OrderByDescending(p => p.MYTRANSID);// p.ACTIVE==true &&
               
                grdPO.DataBind();
                for (int i = 0; i < grdPO.Items.Count; i++)
                {
                    Label lblMYTRANSID = (Label)grdPO.Items[i].FindControl("lblMYTRANSID");
                    int stMYTRANSID = Convert.ToInt32(lblMYTRANSID.Text);
                    if (i == 0)
                    {
                        //BindHD(stMYTRANSID);
                        //BindDTui(stMYTRANSID);
                        // readMode();
                        // readMode();
                    }


                    LinkButton Print = (LinkButton)grdPO.Items[i].FindControl("Print");
                    LinkButton lnkbtnPurchase_Order = (LinkButton)grdPO.Items[i].FindControl("lnkbtnPurchase_Order");
                    Label lbluserid = (Label)grdPO.Items[i].FindControl("lbluserid");
                    Label lblStatus = (Label)grdPO.Items[i].FindControl("lblStatus");
                    Label lblorderstatus = (Label)grdPO.Items[i].FindControl("lblorderstatus");
                    Label lblpayment = (Label)grdPO.Items[i].FindControl("lblpayment");
                    Label lbldelivery = (Label)grdPO.Items[i].FindControl("lbldelivery");
                    LinkButton lnkbtndelete = (LinkButton)grdPO.Items[i].FindControl("lnkbtndelete");
                    LinkButton lnkassignemp = (LinkButton)grdPO.Items[i].FindControl("lnkassignemp");
                    LinkButton lnkpayment = (LinkButton)grdPO.Items[i].FindControl("lnkpayment");
                    LinkButton lnkdelivery = (LinkButton)grdPO.Items[i].FindControl("lnkdelivery");
                    LinkButton lnksalesreturn = (LinkButton)grdPO.Items[i].FindControl("lnksalesreturn");
                    CheckBox chkmyid = (CheckBox)grdPO.Items[i].FindControl("chkmyid");
                    Button btnassingemp = (Button)grdPO.Items[i].FindControl("btnassingemp");
                    Button btnpayment = (Button)grdPO.Items[i].FindControl("btnpayment");
                    Label lblpt = (Label)grdPO.Items[i].FindControl("lblpt");
                    

                    if (lblorderstatus.Text == "New" && lblpayment.Text == "Cash" && lbldelivery.Text == "Under the Process")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = true;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }

                    else if (lblorderstatus.Text == "Completed" && lblpayment.Text == "Cash" && lbldelivery.Text == "Delivered")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = false;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = false;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }
                    else if (lblorderstatus.Text == "New" && lblpayment.Text == "COD" && lbldelivery.Text == "Processed")
                    {
                        lnkbtndelete.Visible = true;
                        lnkassignemp.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = false;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                    }
                    else if (lbldelivery.Text == "Rejected with Reason")
                    {
                        lnkbtndelete.Visible = false;
                        lnkassignemp.Visible = false;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = false;
                        lnksalesreturn.Visible = false;
                        lnkdelivery.Visible = false;
                   
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                    }



                    else if (lblorderstatus.Text == "New" && lblpayment.Text == "COD" && lbldelivery.Text == "Under the Process")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = false;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                       // lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }
                    else if (lblorderstatus.Text == "New" && lblpayment.Text == "COD" && lbldelivery.Text == "Driver Assign")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = true;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivery";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }
                    else if (lblorderstatus.Text == "New" && lblpayment.Text == "COD" && lbldelivery.Text == "Driver On Way" && lblpt.Text == "1")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = false;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = true;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }
                    else if (lblorderstatus.Text == "New" && lblpayment.Text == "COD" && lbldelivery.Text == "Driver On Way")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = false;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivery";
                        lblpayment.Visible = false;
                      
                                //by sahir
                                // txtPopupPaidAmount.Text = lblPopupPaidAmount.Text = lblPopupPaidAmount.Text = "4";
                                lnkpayment.Visible = true;
                        lnkassignemp.Visible = false;
                    }
                    else if (lblorderstatus.Text == "Completed" && lblpayment.Text == "Cash" && lbldelivery.Text == "Delivered")
                    {
                        lnkbtndelete.Visible = true;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = false;
                        lnksalesreturn.Visible = true;
                        lnkdelivery.Visible = false;
                        lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                        lnkassignemp.Visible = false;
                    }
                    
                    else if (lblorderstatus.Text == "Completed")
                    {
                        lnkbtndelete.Visible = false;
                        lnkassignemp.Visible = false;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = false;
                        lnkbtndelete.Visible = false;
                        lnkpayment.Visible = false;
                        lblpayment.Visible = false;
                    }

                    //if (lblpayment.Text == "Cash")
                    //{
                    //    chkmyid.Visible = true;
                    //    lnkbtndelete.Visible = false;
                    //    lnkassignemp.Visible = false;
                    //    Print.Visible = true;
                    //    //btnassingemp.Visible = false;
                    //    //btnpayment.Visible = false;
                    //    lnksalesreturn.Visible = true;

                    //}
                    //else if (lbldelivery.Text == "Driver On Way")
                    //{
                    //    chkmyid.Visible = true;
                    //    lnkbtnPurchase_Order.Visible = true;
                    //    lnkbtndelete.Visible = true;
                    //    lnkassignemp.Visible = false;
                    //    Print.Visible = true;
                    //    //btnassingemp.Visible = false;
                    //    //btnpayment.Visible = false;
                    //    lnksalesreturn.Visible = true;
                    //    lnkdelivery.Visible = true;
                    //    lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                    //}
                    else if (lbldelivery.Text == "Delivered")
                    {
                        chkmyid.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnkbtndelete.Visible = false;
                        lnkassignemp.Visible = false;
                        Print.Visible = true;
                        //btnassingemp.Visible = false;
                        //btnpayment.Visible = false;
                        lnksalesreturn.Visible = false;
                        lnkdelivery.Visible = false;
                        lblpayment.Visible = false;
                        lnkpayment.Visible = false;
                    }
                    else
                    {
                        lnkbtndelete.Visible = false;
                        lnkassignemp.Visible = false;
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnksalesreturn.Visible = true;
                        lnkbtndelete.Visible = true;
                    }
                }
            }

        }
        public string getsuppername(int ID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            return DB.TBLCOMPANYSETUPs.Single(p => p.COMPID == ID && p.TenentID == TID).COMPNAME1;
        }

        protected void drpemployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            if (drpemployee.SelectedValue != null && drpemployee.SelectedValue != "0")
            {
                for (int i = 0; i < grdPO.Items.Count; i++)
                {
                    CheckBox chkmyid = (CheckBox)grdPO.Items[i].FindControl("chkmyid");

                    if (chkmyid.Checked == true)
                    {
                        Label lblMYTRANSID = (Label)grdPO.Items[i].FindControl("lblMYTRANSID");
                        LinkButton lnkdelivery = (LinkButton)grdPO.Items[i].FindControl("lnkdelivery");
                        Label lblStatus = (Label)grdPO.Items[i].FindControl("lblStatus");
                        int MID = Convert.ToInt32(lblMYTRANSID.Text);
                        Database.ICTR_HD_Sales objsale = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MID && p.locationID == LID);
                        objsale.SoldByEmp_ID = drpemployee.SelectedValue;
                        objsale.DeliveryStatus = "Driver On Way";
                        DB.SaveChanges();
                        GridData(2);
                        if (lblStatus.Text == "COD")
                        {
                            lnkdelivery.Visible = true;
                        }
                    }
                }
            }
        }

        protected void GetTime(object sender, EventArgs e)
        {
           // GridData(2);
        }

        protected void btnpopuporder_Click(object sender, EventArgs e)
        {
            OnlySave(true);
            ViewState["GridPayment"] = null;
            GridPayment.DataSource = null;
            GridPayment.DataBind();
            txtPopupPaidAmount.Text = "0.000";
            txtPayReffrance.Text = "";
            lblPaid.Text = "";
            lblPopupPaidAmount.Text = "";
        }

        public void OnlySave(bool Print)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int MyTransId = Convert.ToInt32(ViewState["paymentID"]);
            int customerid = Convert.ToInt32(DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MyTransId && p.locationID == LID).CUSTVENDID);
            string custname = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPID == customerid).COMPNAME1;
            List<PaymentData> GridPayment = new List<PaymentData>();
            List<PaymentDatasale> ListPayment = new List<PaymentDatasale>();
            ListPayment = ((List<PaymentDatasale>)ViewState["GridPayment"]).ToList();

            foreach (PaymentDatasale item in ListPayment)
            {
                PaymentData Obj = new PaymentData();
                Obj.payment_type = item.payment_type;
                Obj.Reffrance_NO = item.Reffrance_NO;
                Obj.payment_amount = item.payment_amount;
                GridPayment.Add(Obj);
            }
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID); 
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
            CashSave2 sendObj1 = new CashSave2();
            string invoice = "INV" + MyTransId;
            sendObj1.TenentID = TID;
            sendObj1.LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID); 
            sendObj1.MYTRANSID = MyTransId;
            sendObj1.DESCRIPTION = custname;
            sendObj1.Userid = UID;
            sendObj1.UserName = name;
            sendObj1.DID = Convert.ToInt32(Session["ID"]);
            sendObj1.Invoice = invoice;
            string Customer = custname;
            if (Customer.Contains('-'))
            {
                Customer = custname;
            }
            sendObj1.Customer = Customer;
            int C_id = customerid;
            sendObj1.CustomerID = C_id != 0 ? C_id : 1;

            decimal Predis = 0;//Convert.ToDecimal(lblDiscount.Text);
            decimal Invoidis = 0;//Convert.ToDecimal(lblDiscount.Text);
            decimal Fdis = Predis + Invoidis;

            sendObj1.DiscountTotaloverall = Fdis.ToString();
            sendObj1.overalldisRate = "0";
            sendObj1.Delivery_Cahrge = "0"; //lblDelivery.Text != "" ? lblDelivery.Text : "0";
            sendObj1.DiscountAmt = Fdis.ToString();
            sendObj1.TotalPayable = Convert.ToDecimal(lblPopupPaidAmount.Text);
            sendObj1.TotalCashRecived = Convert.ToDecimal(lblPopupPaidAmount.Text);// txtcashReceived.Text != "" ? Convert.ToDecimal(txtcashReceived.Text) : 0;
            sendObj1.DeliveryStatus = "Under the Process";
            sendObj1.GridPayment = GridPayment;
            decimal payamount = Convert.ToDecimal(lblPopupPaidAmount.Text);
            decimal changeamount = Convert.ToDecimal(txtbalance.Text);
            string salesdate = DateTime.Now.ToString();
            string Comment = txtPaymentComment.Text;
            string PaymentStutas = ViewState["paymentmode"].ToString();
            string trno = ViewState["paymentID"].ToString();
            sendObj1.GridPayment = GridPayment;
            string Invoice = "INV" + trno;
            payment_itemsave(TID, payamount, changeamount, changeamount, salesdate, Comment, PaymentStutas, trno, Invoice, Customer, C_id, "0", "0", "0", name, "1", UID, 1, GridPayment, PaymentStutas);
        }


        public int getPaymentid(int TenentID, string sales_id)
        {
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int ID12 = 1;
            string sqlIT = "select * from ICTR_sales_payment where TenentID=" + TenentID + " and LocationID =" + LID + " and sales_id='" + sales_id + "'  ";
            DataTable dt1 = DataCon.GetDataTable(sqlIT);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICTR_sales_payment where TenentID=" + TenentID + " and LocationID =" + LID + " and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataCon.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public void payment_itemsave(int TenentID, decimal payamount, decimal changeamount, decimal dueamount, string salesdate, string Comment, string PaymentStutas, string trno, string invoiceNO, string Customer, int CustomerID, string DiscountTotaloverall, string overalldisRate, string Delivery_Cahrge, string UserName, string Shopid, int Userid, int ShiftID, List<PaymentData> GridPayment, String Payment)
        {
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DateTime sales_date = Convert.ToDateTime(salesdate);
            salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            // string payamount        = lblTotalPayable.Text;
            //  string changeamount     = "0";
            //string due              =  "0";
            string vat = "0";
            string vatRate = "0";

            if (GridPayment.Count() > 0)
            {
                foreach (PaymentData items in GridPayment)
                {

                    int ID = getPaymentid(TenentID, trno);
                    string payment_type = items.payment_type;
                    string Reffrance = items.Reffrance_NO;
                    decimal payment_amount = Convert.ToDecimal(items.payment_amount);
                    dueamount = changeamount;//payamount - payment_amount;

                    string Query = "select * from ICTR_sales_payment where TenentID = " + TenentID + " and LocationID = " + LID + " and sales_id='" + trno + "' and payment_type='" + payment_type + "' and sales_time = '" + DateTime.Now + "' ";
                    DataTable dtQuery = DataCon.GetDataTable(Query);
                    if (dtQuery.Rows.Count < 1)
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        string sqlWin = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                                       " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                                       "  values (" + TenentID + "," + LID + "," + ID + ",'" + trno + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                                       " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                       "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                        int flag1 = DataCon.ExecuteSQL(sqlWin);
                    }
                    else
                    {
                        decimal DiscountTotal = Convert.ToDecimal(DiscountTotaloverall);
                        string Reff1 = GetPAyReff(TenentID, trno, payment_type);

                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        Reffrance = Reffrance + "," + Reff1;
                        Reffrance = Reffrance.Trim();
                        Reffrance = Reffrance.TrimStart(',');
                        Reffrance = Reffrance.TrimEnd(',');
                        Reffrance = Reffrance.Trim();

                        string sum = GetPaySum(TenentID, trno, payment_type);

                        string[] S = sum.Split(',');

                        decimal payment_amount1 = Convert.ToDecimal(S[0]);
                        decimal change_amount1 = Convert.ToDecimal(txtbalance.Text);
                        // dueamount = payamount - payment_amount;
                        decimal due_amount1 = payamount - payment_amount;
                        decimal dis1 = 0;
                        decimal vat1 = 0;//Convert.ToDecimal(S[4]);

                        payment_amount = payment_amount + payment_amount1;
                        changeamount = changeamount + change_amount1;
                        dueamount = dueamount + due_amount1;
                        DiscountTotal = DiscountTotal + dis1;
                        vat = vat + vat1;

                        string sqlWin = "  Update ICTR_sales_payment set Reffrance = '" + Reffrance + "',payment_amount = '" + payment_amount + "',change_amount = '" + changeamount + "', " +
                        " due_amount = '" + dueamount + "', dis = '" + DiscountTotal + "', vat= '" + vat + "' " +
                        " where TenentID = " + TenentID + " and LocationID =" + LID + " and sales_id='" + trno + "' and payment_type='" + payment_type + "' ";
                        DataCon.ExecuteSQL(sqlWin);
                    }

                    if (PaymentStutas != "Pending")
                    {
                        if (payment_type == "Cash")
                        {
                            decimal ShiftSales = Convert.ToDecimal(payment_amount);
                            Update_ShiftSales_DayClose(TenentID, Userid, Shopid, ShiftID, ShiftSales);
                        }
                        else if (payment_type == "Gift Card")
                        {
                            decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                            Update_VoucharAMT_DayClose(TenentID, Userid, Shopid, ShiftID, VoucharAMT);
                        }
                        else
                        {
                            decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                            Update_ChequeAMT_DayClose(TenentID, Userid, Shopid, ShiftID, ChequeAMT);
                        }
                    }
                }
            }
            else
            {

                if (Payment == "Cash")
                {
                    int ID = getPaymentid(TenentID, trno);


                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                                      "  values (" + TenentID + "," + LID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '" + payamount + "', '" + changeamount + "', " +
                                      " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                    int flag1 = DataCon.ExecuteSQL(sql1Win);


                    if (PaymentStutas != "Pending")
                    {
                        decimal ShiftSales = Convert.ToDecimal(payamount);
                        Update_ShiftSales_DayClose(TenentID, Userid, Shopid, ShiftID, ShiftSales);
                    }

                }

                else if (Payment == "COD")
                {
                    int ID = getPaymentid(TenentID, trno);


                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                                      "  values (" + TenentID + "," + LID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '0.00', '0.00', " +
                                      " '" + payamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                    int flag1 = DataCon.ExecuteSQL(sql1Win);
                }
                else if (Payment == "Credit")
                {
                    int ID = getPaymentid(TenentID, trno);


                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                                      "  values (" + TenentID + "," + LID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '0.00', '0.00', " +
                                      " '" + payamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                    int flag1 = DataCon.ExecuteSQL(sql1Win);
                }
                else
                {
                    string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    int ID = getPaymentid(TenentID, trno);
                    string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                                      "  values (" + TenentID + "," + LID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '" + payamount + "', '" + changeamount + "', " +
                                      " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                    int flag1 = DataCon.ExecuteSQL(sql1Win);


                    if (PaymentStutas != "Pending")
                    {
                        decimal ShiftSales = Convert.ToDecimal(payamount);
                        Update_ShiftSales_DayClose(TenentID, Userid, Shopid, ShiftID, ShiftSales);
                    }
                }
            }
            int trnos = Convert.ToInt32(ViewState["paymentID"]);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            List<Database.ICTR_sales_payment> List = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == trnos && p.locationID == LID).ToList();

            if (List.Count > 0)
            {
                decimal due = Convert.ToDecimal(List.LastOrDefault().due_amount);
                if (due == 0)
                {
                    int ID = Convert.ToInt32(ViewState["paymentID"]);
                    Database.ICTR_HD_Sales objsale = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == ID && p.locationID == LID);
                    string status = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == ID && p.locationID == LID).PaymentStatus;
                    objsale.PaymentType = 1;
                    // objsale.PaymentStatus = status + "and" + "Cash paid";
                    DB.SaveChanges();
                }
                else
                {
                    int ID = Convert.ToInt32(ViewState["paymentID"]);
                    Database.ICTR_HD_Sales objsale = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == ID && p.locationID == LID);
                    objsale.PaymentType = 0;
                    DB.SaveChanges();
                }
            }
            GridData(2);


        }

        public static void Update_ChequeAMT_DayClose(int TenentID, int Userid, string Shopid, int ShiftID, decimal ChequeAMT)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataCon.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal ChequeAMTold = Convert.ToDecimal(dt5.Rows[0]["ChequeAMT"]);
                ChequeAMT = ChequeAMT + ChequeAMTold;

                string sql1 = " Update DayClose set ChequeAMT=" + ChequeAMT + " where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, Shopid, ShiftID);
            }
        }
        public string GetPaySum(int TenentID, string sales_id, string payment_type)
        {
            string sum = "";
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            string Query = "select * from ICTR_sales_payment where TenentID = " + TenentID + " and LocationID =" + LID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
            DataTable dtQuery = DataCon.GetDataTable(Query);

            int Count = dtQuery.Rows.Count;

            //payment_amount,change_amount,due_amount,dis,vat

            decimal payment_amount = 0;
            decimal change_amount = 0;
            decimal due_amount = 0;
            decimal dis = 0;
            decimal vat = 0;

            for (int i = 0; i < Count; i++)
            {
                decimal payment_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["payment_amount"]);
                decimal change_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["change_amount"]);
                decimal due_amount1 = Convert.ToDecimal(dtQuery.Rows[i]["due_amount"]);
                decimal dis1 = Convert.ToDecimal(dtQuery.Rows[i]["dis"]);
                decimal vat1 = Convert.ToDecimal(dtQuery.Rows[i]["vat"]);

                payment_amount = payment_amount + payment_amount1;
                change_amount = change_amount + change_amount1;
                due_amount = due_amount + due_amount1;
                dis = dis + dis1;
                vat = vat + vat1;
            }

            sum = payment_amount.ToString();
            return sum;
        }
        public string GetPAyReff(int TenentID, string sales_id, string payment_type)
        {
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            string Reff = "";
            string Query = "select * from ICTR_sales_payment where TenentID = " + TenentID + " and LocationID =" + LID + " and sales_id='" + sales_id + "' and payment_type='" + payment_type + "' ";
            DataTable dtQuery = DataCon.GetDataTable(Query);

            int Count = dtQuery.Rows.Count;

            for (int i = 0; i < Count; i++)
            {
                if (dtQuery.Rows[i]["Reffrance"] != null)
                {
                    string Reff1 = dtQuery.Rows[i]["Reffrance"].ToString();
                    if (Reff1 != "")
                    {
                        Reff = Reff1 + "," + Reff;
                    }
                }
            }

            Reff = Reff.Trim();
            Reff = Reff.TrimStart(',');
            Reff = Reff.TrimEnd(',');
            return Reff;
        }
        public static void Update_VoucharAMT_DayClose(int TenentID, int Userid, string Shopid, int ShiftID, decimal VoucharAMT)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataCon.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal VoucharAMTold = Convert.ToDecimal(dt5.Rows[0]["VoucharAMT"]);
                VoucharAMT = VoucharAMT + VoucharAMTold;

                string sql1 = " Update DayClose set VoucharAMT=" + VoucharAMT + " where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, Shopid, ShiftID);
            }
        }
        public static void Update_ShiftCIH_DayClose(int TenentID, int Userid, string Shopid, int ShiftID)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            decimal todayCash = 0;

            string Condition = "where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            string sql = "select ((OpAMT + ShiftSales) - (ShiftReturn + VoucharAMT + ExpAMT + ChequeAMT + AMTDelivered + Shiftpurchase  )) as TodayCash from DayClose " + Condition;
            DataTable dt = DataCon.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt.Rows[0]["TodayCash"]);

            }

            string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataCon.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                string sql1 = " Update DayClose set ShiftCIH=" + todayCash + " where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);
            }
        }


        public static void Update_ShiftSales_DayClose(int TenentID, int Userid, string Shopid, int ShiftID, decimal ShiftSales)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DataCon.GetDataTable(sql5);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftSalesold = Convert.ToDecimal(dt5.Rows[0]["ShiftSales"]);
                ShiftSales = ShiftSales + ShiftSalesold;

                string sql1 = " Update DayClose set ShiftSales=" + ShiftSales + " where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, Shopid, ShiftID);

            }

        }

        public static void Update_Shiftreturn_DayClose(int TenentID, int Userid, int LID, string Shopid, int ShiftID, decimal ShiftReturn)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            // string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DAL.Get_DayClose(TenentID, Userid, LID, ShiftID, Date);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftReturnOld = Convert.ToDecimal(dt5.Rows[0]["ShiftReturn"]);
                decimal TShitfRetrun = ShiftReturn + ShiftReturnOld;

                string sql1 = " Update DayClose set ShiftReturn=" + TShitfRetrun + " where TenentID=" + TenentID + " and ShiftID = " + ShiftID + " and LocationID = " + LID + " and convert(Date,Date) = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                //Update_ShiftCIH_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);

            }

        }

        protected void txtPopupPaidAmount_TextChanged(object sender, System.EventArgs e)
        {
            if (lblPaid.Text != "0" && lblPaid.Text != null)
            {
                decimal total = Convert.ToDecimal(lblPopupPaidAmount.Text);
                decimal paid = Convert.ToDecimal(lblPaid.Text);
                decimal crack = Convert.ToDecimal(txtPopupPaidAmount.Text);
                txtbalance.Text = (total - paid - crack).ToString();
            }

            else if (txtPopupPaidAmount.Text != "0" && txtPopupPaidAmount.Text != null)
            {
                decimal total = Convert.ToDecimal(lblPopupPaidAmount.Text);
                decimal paid = Convert.ToDecimal(txtPopupPaidAmount.Text);
                txtbalance.Text = (total - paid).ToString();
            }
        }

        public void ChangedueCalculation()
        {
            if (Convert.ToDouble(lblPopupPaidAmount.Text) >= Convert.ToDouble(lblPopupPaidAmount.Text))
            {
                double changeAmt = Convert.ToDouble(lblPopupPaidAmount.Text) - Convert.ToDouble(lblPopupPaidAmount.Text);
                changeAmt = Math.Round(changeAmt, 3);
                //txtChangeAmount.Text = changeAmt.ToString();
                //txtDueAmount.Text = "0";
            }
            if (Convert.ToDouble(lblPopupPaidAmount.Text) <= Convert.ToDouble(lblPopupPaidAmount.Text))
            {
                double changeAmt = Convert.ToDouble(lblPopupPaidAmount.Text) - Convert.ToDouble(lblPopupPaidAmount.Text);
                changeAmt = Math.Round(changeAmt, 3);
                //txtDueAmount.Text = changeAmt.ToString();
                //txtChangeAmount.Text = "0";
            }
        }

        List<PaymentDatasale> ListPayment = new List<PaymentDatasale>();
        protected void btnaddpaymenttype_Click(object sender, System.EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            if (drpPayBy.SelectedValue != "0")
            {


                if (ViewState["GridPayment"] != null)
                {
                    ListPayment = ((List<PaymentDatasale>)ViewState["GridPayment"]).ToList();
                }

                if (txtPopupPaidAmount.Text == "" || txtPopupPaidAmount.Text == ".")
                {
                    return;
                }

                decimal Totalpay = Convert.ToDecimal(lblPopupPaidAmount.Text);
                int ID = Convert.ToInt32(ViewState["paymentID"]);
                var listpay = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == ID && p.locationID == LID);
                decimal totalpay = Convert.ToDecimal(listpay.Sum(m => m.payment_amount));
                lblPaid.Text = totalpay.ToString();
                decimal totalPaid = Convert.ToDecimal(lblPaid.Text);

                decimal rest = (Totalpay - totalPaid);
                decimal Enter = Convert.ToDecimal(txtPopupPaidAmount.Text);

                if (Enter > rest)
                {
                    txtPopupPaidAmount.Focus();
                    txtPopupPaidAmount.Text = (rest).ToString();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Plase Enter Less Than ')" + rest, true);
                    return;
                }

                if (Totalpay > totalPaid)
                {
                    int IID = Convert.ToInt32(Session["GetMYTRANSID"]);
                    int sales_id = IID;
                    string payment_type = drpPayBy.SelectedItem.ToString().Trim();
                    decimal payment_amount = Convert.ToDecimal(txtPopupPaidAmount.Text);
                    string Reffrance_NO = txtPayReffrance.Text;

                    if (payment_type != "CASH" && Reffrance_NO == "")
                    {
                        txtPayReffrance.Focus();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reffrance_NO Can Not Be Empty in')" + payment_type, true);

                        return;
                    }

                    if (ListPayment.Where(p => p.payment_type == payment_type).Count() < 1)  //If new item
                    {
                        PaymentDatasale Obj = new PaymentDatasale();
                        Obj.invoice = sales_id.ToString();
                        Obj.payment_type = payment_type;
                        if (payment_type == "Cash")
                        {
                            Obj.Reffrance_NO = "0";
                        }
                        else
                        {
                            Obj.Reffrance_NO = Reffrance_NO;
                        }
                        Obj.payment_amount = payment_amount;
                        ListPayment.Add(Obj);
                        ViewState["GridPayment"] = ListPayment;
                        GridPayment.DataSource = ListPayment;
                        GridPayment.DataBind();
                    }
                    else
                    {
                        decimal OldVal = Convert.ToInt32(ListPayment.Where(p => p.payment_type == payment_type).FirstOrDefault().payment_amount);

                        decimal New = OldVal + payment_amount;
                        ListPayment.Where(p => p.payment_type == payment_type).FirstOrDefault().payment_amount = New;

                        string Reffrance = ListPayment.Where(p => p.payment_type == payment_type).FirstOrDefault().Reffrance_NO.ToString();

                        Reffrance = Reffrance + ", " + Reffrance_NO;

                        ListPayment.Where(p => p.payment_type == payment_type).FirstOrDefault().Reffrance_NO = Reffrance;
                        ViewState["GridPayment"] = ListPayment;
                        GridPayment.DataSource = ListPayment;
                        GridPayment.DataBind();
                    }

                    decimal sum = ListPayment.Sum(p => p.payment_amount);
                    lblPaid.Text = sum.ToString();
                    txtPopupPaidAmount.Text = (Totalpay - sum).ToString();
                    txtPayReffrance.Text = "";
                    drpPayBy.SelectedValue = "0";
                    ChangedueCalculation();
                }
                else
                {

                }
                if (lblPopupPaidAmount.Text == lblPaid.Text)
                {
                    txtbalance.Text = "0.00";
                }
            }
        }

        public void EditSalesh(int ID, int VW)
        {
            //clearHDPanel();
            ////BindData();
            //btnPenel.Visible = true;
            //Database.ICTR_HD OBJICTR_HD = DB.ICTR_HD.Single(p => p.MYTRANSID == ID && p.TenentID == TID);
            //if (OBJICTR_HD.ExtraField2 != "")
            //    drpselsmen.SelectedValue = OBJICTR_HD.ExtraField2;
            //CID = Convert.ToInt32(OBJICTR_HD.CUSTVENDID);
            //Database.TBLCOMPANYSETUP onj = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPID == CID);
            ////txtLocationSearch.Text = onj.COMPNAME1;
            //HiddenField3.Value = CID.ToString();
            //DRPLocationSearch.SelectedValue = CID.ToString();
            //if (OBJICTR_HD.USERBATCHNO != null || OBJICTR_HD.USERBATCHNO != "")
            //{
            //    txtBatchNo.Text = OBJICTR_HD.USERBATCHNO.ToString();
            //}
            //if (OBJICTR_HD.TRANSDATE != null)
            //{
            //    txtOrderDate.Text = OBJICTR_HD.TRANSDATE.ToString("dd-MMM-yy");
            //}
            //if (OBJICTR_HD.MYTRANSID != null)
            //{
            //    txtTraNoHD.Text = OBJICTR_HD.MYTRANSID.ToString();
            //}
            //if (OBJICTR_HD.REFERENCE != null && OBJICTR_HD.REFERENCE != "")
            //{
            //    txtrefreshno.Text = OBJICTR_HD.REFERENCE.ToString();
            //}
            //if (OBJICTR_HD.NOTES != null && OBJICTR_HD.NOTES != "")
            //{
            //    txtNoteHD.Text = OBJICTR_HD.NOTES.ToString();
            //}
            //if (OBJICTR_HD.TransDocNo != null)
            //{
            //    SubSerialNo.Text = OBJICTR_HD.TransDocNo.ToString();
            //}
            //if (OBJICTR_HD.TOTAMT != null)
            //{
            //    txttotxl.Text = OBJICTR_HD.TOTAMT.ToString();
            //}
            //if (OBJICTR_HD.Terms != null && OBJICTR_HD.Terms == 0)
            //{
            //    drpterms.SelectedValue = OBJICTR_HD.Terms.ToString();
            //}
            //else
            //{
            //    drpterms.SelectedValue = "2114";
            //}
            //var listcost = DB.ICTRPayTerms_HD.Where(p => p.MyTransID == ID && p.TenentID == TID).ToList();
            //if (listcost.Count() > 0)
            //{
            //    ViewState["TempEco_ICCATEGORY"] = listcost;
            //    //Session["Invoice"] = ID;
            //    Repeater3.DataSource = (List<Database.ICTRPayTerms_HD>)ViewState["TempEco_ICCATEGORY"];
            //    Repeater3.DataBind();
            //}
            //else
            //{
            //    Repeater3.DataSource = (List<Database.ICTRPayTerms_HD>)ViewState["TempEco_ICCATEGORY"]; ;
            //    Repeater3.DataBind();
            //}
            ////btnAddItemsIn.Visible = true;
            //// btnAddDT.Visible = false;
            ////BindDT(ID);yogesh
            ////BindDTui(ID);
            //if (VW == 0)
            //    BindTempDT(ID, 0);
            //else if (VW == 1)
            //    BindTempDT(ID, 1);
            ////ListItems.Visible = true;
            ////panelRed.Visible = true;

            //Session["Invoice"] = ID;
            //ViewState["HDMYtrctionid"] = ID;
            //Session["GetMYTRANSID"] = ID;
            //btnConfirmOrder.Text = "Save";
            //btnSaveData.Visible = true;
            ////btnConfirmOrder.Visible = true;yogesh20042017

            //if (OBJICTR_HD.ACTIVE == true)
            //{
            //    string Statesh = OBJICTR_HD.Status;
            //    if (Statesh == "SO")
            //        readMode();
            //    else
            //        WrietMode();
            //}
            //else
            //{
            //    WrietMode();
            //}


        }

        public void binddrop()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            drpemployee.DataSource = DB.tbl_Employee.Where(p => p.TenentID == TID);
            drpemployee.DataTextField = "firstname";
            drpemployee.DataValueField = "employeeID";
            drpemployee.DataBind();
            drpemployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Employe--", "0"));
        }
        protected void grdPO_ItemCommand(object source, ListViewCommandEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            if (e.CommandName == "Edit")
            {
                checksession();
               //  int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);


                int MYTID = Convert.ToInt32(e.CommandArgument);
                string payment = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID && p.locationID == LID).PaymentStatus;
                Session["PaymentStatus"] = payment;
                Response.Redirect("fullsr.aspx?MytransID=" + MYTID);

                EditSalesh(MYTID, 0);

            }
            if (e.CommandName == "Salesreturn")
            {
                //  checksession();
                ////  int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                //  int MYTID = Convert.ToInt32(e.CommandArgument);
                //  string paymentstatus = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID && p.locationID == LID).PaymentStatus;
                //  Session["PaymentStatus"] = paymentstatus;
                //  Response.Redirect("fullsrreturn.aspx?MytransID=" + MYTID);
                checksession();
                //  int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect(string.Format("Sales/Sales_return.aspx?MyTransID={0}&option={1}", MYTID, "Edit"));
            }

            if (e.CommandName == "Productreturn")
            {
                checksession();
                //  int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect(string.Format("Sales/Sales_return.aspx?MyTransID={0}&option={1}", MYTID, "Edit"));

            }

            if (e.CommandName == "chektrue" || e.CommandName == "Assign")
            {

               // int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                LinkButton lnkassignemp = (LinkButton)e.Item.FindControl("lnkassignemp");
                LinkButton lnkbtnPurchase_Order = (LinkButton)e.Item.FindControl("lnkbtnPurchase_Order");
                LinkButton Print = (LinkButton)e.Item.FindControl("Print");
                LinkButton lnkbtndelete = (LinkButton)e.Item.FindControl("lnkbtndelete");
                LinkButton lnkpayment = (LinkButton)e.Item.FindControl("lnkpayment");
                LinkButton lnksalesreturn = (LinkButton)e.Item.FindControl("lnksalesreturn");
                LinkButton lnkdelivery = (LinkButton)e.Item.FindControl("lnkdelivery");
                Button btnpayment = (Button)e.Item.FindControl("btnpayment");
                Button btnassingemp = (Button)e.Item.FindControl("btnassingemp");
                Label lblMYTRANSID = (Label)e.Item.FindControl("lblMYTRANSID");
                Label lblpayment = (Label)e.Item.FindControl("lblpayment");
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                Label lbldelivery = (Label)e.Item.FindControl("lbldelivery");
                CheckBox chkmyid = (CheckBox)e.Item.FindControl("chkmyid");

                if (chkmyid.Checked == true)
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    string paymentmode = lblStatus.Text;
                    decimal payment = Convert.ToDecimal(DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == ID && p.locationID == LID).TOTAMT);
                    var listpay = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == ID);
                    decimal totalpay = Convert.ToDecimal(listpay.Sum(m => m.payment_amount));
                    lblPaid.Text = totalpay.ToString();
                    lblPopupPaidAmount.Text = payment.ToString();
                    txtPopupPaidAmount.Text = payment.ToString();

                    lnkbtndelete.Visible = true;
                    lnkassignemp.Visible = true;
                    Print.Visible = true;
                    lnkbtnPurchase_Order.Visible = true;
                    lnksalesreturn.Visible = true;
                    lnkdelivery.Visible = false;
                    lnkdelivery.Text = "<i class='la la-leaf'></i> Delivered";
                    if (lblpayment.Text == "COD" && lbldelivery.Text == "Driver On Way")
                    {
                        lnkpayment.Visible = true;
                        lnkassignemp.Visible = false;
                    }
                    else
                    {
                        lnkpayment.Visible = false;
                    }
                    
                    ViewState["paymentID"] = ID;
                    ViewState["paymentmode"] = paymentmode;
                }
                else
                {
                    lnkassignemp.Visible = true;
                    //btnpayment.Visible = true;
                    lnkpayment.Visible = false;
                    //btnassingemp.Visible = true;
                    lnkassignemp.Visible = true;
                    lnkpayment.Visible = false;
                    lnkdelivery.Visible = false;
                    lnksalesreturn.Visible = true;
                    lnkpayment.Visible = false;
                }

            }
            if (e.CommandName == "Btnview")
            {
                checksession();
               // int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(e.CommandArgument);
                EditSalesh(MYTID, 1);
                //readMode();
                //ListITtemDT.Visible = true;
                //panelRed.Visible = false;
                //lblmodev.Text = "(View Only)";
                //lblmode.Text = "(View Only)";
                //lblmodeitem.Text = "(View Only)";
            }
            if (e.CommandName == "Delete")
            {
                checksession();
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");

               //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(e.CommandArgument);
                if(lblStatus.Text == "Draft")
                {
                    Database.ICTR_HD_Sales_tmp objdet = DB.ICTR_HD_Sales_tmp.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID && p.locationID == LID);
                    DB.ICTR_HD_Sales_tmp.DeleteObject(objdet);
                    DB.SaveChanges();


                    List<ICTR_DT_Sales_tmp> list1 = new List<ICTR_DT_Sales_tmp>();
                    List<Database.ICTR_DT_Sales_tmp> Tlistw = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == MYTID).ToList();
                    foreach (Database.ICTR_DT_Sales_tmp items in Tlistw)
                    {
                        DB.ICTR_DT_Sales_tmp.DeleteObject(items);
                        DB.SaveChanges();
                    }
                }
                else
                {
                    decimal TotAMT = 0;
                Database.ICTR_HD_Sales OBJICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == MYTID && p.TenentID == TID && p.locationID == LID);
                    TotAMT = Convert.ToDecimal( OBJICTR_HD.TOTAMT);
                    OBJICTR_HD.OrderStatus = "Canceled";
                OBJICTR_HD.PaymentStatus = "Cancel";
                OBJICTR_HD.DeliveryStatus = "Cancel With Remarks";
                DB.SaveChanges();

                    List<ICTR_DT_Sales> list1 = new List<ICTR_DT_Sales>();
                    List<Database.ICTR_DT_Sales> Tlistw = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.locationID==LID && p.MYTRANSID == MYTID).ToList();

                    foreach (Database.ICTR_DT_Sales items in Tlistw)
                    {
                        int ProdID = int.Parse(items.MyProdID.ToString());
                        DAL.Reverse_InvoiceQt(TID, LID, ProdID, MYTID);

                    }

                        //cancel sahir
                        string ShiftID = Session["ShiftID"].ToString();
                  //  Update_Shiftreturn_DayClose(TID, 0, LID, "1", int.Parse(ShiftID), TotAMT);
                }
                Response.Redirect("orderlist.aspx");
            }
            if (e.CommandName == "ReceiveProduct")
            {

                int MYTID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("GoofsTransferNotes.aspx?Tranjestion=" + MYTID);
            }
            if (e.CommandName == "btnprient")
            {
                checksession();
               // int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                string PrintURL = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid).InvoicePrintURL;
                int MYTID = Convert.ToInt32(e.CommandArgument);
                if (MYTID != 0)
                {
                    printInv(MYTID);
                }
            }
            if (e.CommandName == "delivery")
            {

                //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(e.CommandArgument);
                LinkButton lnkdelivery = (LinkButton)e.Item.FindControl("lnkdelivery");
                if (lnkdelivery.Text == "<i class='la la-leaf'></i> Delivered")
                {
                    List<Database.ICTR_sales_payment> listpayment = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == MYTID && p.locationID == LID).ToList();
                    foreach (Database.ICTR_sales_payment item in listpayment)
                    {
                        item.PaymentStutas = "Success";
                        DB.SaveChanges();
                    }
                    Database.ICTR_HD_Sales objsale = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID && p.locationID == LID);
                    objsale.OrderStatus = "Completed";
                    objsale.PaymentStatus = "Cash";
                    objsale.DeliveryStatus = "Delivered";
                    DB.SaveChanges();
                    GridData(2);
                }
                //else
                //{
                //    List<Database.ICTR_sales_payment> listpayment = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == MYTID).ToList();
                //    foreach (Database.ICTR_sales_payment item in listpayment)
                //    {
                //        item.PaymentStutas = "Success";
                //        DB.SaveChanges();
                //    }
                //    Database.ICTR_HD_Sales objsale = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID);
                //    objsale.DeliveryStatus = "Driver On Way";
                //    DB.SaveChanges();
                //    GridData(2);

                //}
            }
           if(e.CommandName == "Assign")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openHistModal();", true);
            }
        }

        public void printInv(int TRCID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);


            checksession();
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            ICTR_HD_Sales objICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.locationID == LID);
            int CUTID = Convert.ToInt32(objICTR_HD.CUSTVENDID);
            if (DB.ICIT_BR_ReferenceNo.Where(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.RefID == 10512).Count() > 0)
            {
                ICIT_BR_ReferenceNo objbrre = DB.ICIT_BR_ReferenceNo.Single(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.RefID == 10512);
                //lbllponumber.Text = objbrre.ReferenceNo;
            }
            if (objICTR_HD.Terms != 0 && objICTR_HD.Terms != null)
            {
                int RID = Convert.ToInt32(objICTR_HD.Terms);
                //pnltrrms.Visible = true;
                //lblterms.Text = DB.REFTABLEs.Single(p => p.TenentID == TID && p.REFID == RID).REFNAME1;
            }
            else
            {
                //pnltrrms.Visible = false;
            }
            if (objICTR_HD.ExtraSwitch1 == "1")
            {
                //lblcseandcredt.Text = "CREDIT";
                //lblcseandcredtarabic.Text =lblcseandcredt.Text;
            }
            else
            {
                //    lblcseandcredt.Text = "CASH";
                //    lblcseandcredtarabic.Text = lblcseandcredt.Text;
            }

            //else
            //{
            //    lblcseandcredt.Text = "Corp";
            //}
            TBLCOMPANYSETUP objcopm = DB.TBLCOMPANYSETUPs.Single(p => p.COMPID == CUTID && p.TenentID == TID);
            TBLLOCATION objlocation = DB.TBLLOCATIONs.Single(p => p.LOCATIONID == LID && p.TenentID == TID);
            labelUSerNAme.Text = objcopm.COMPNAME1 + " - " + objcopm.COMPNAME2;
            lblA4Customer.Text = objcopm.COMPNAME1 + " - <br /> " + objcopm.COMPNAME2;
            string Add1 = objlocation.ADDRESS;
            string Add2 = objcopm.ADDR2;
           
            UserAddress.Text = Add2;
            //lblAddress.Text = Add1;
            lblA4CustomerAdd.Text = Add2;
            UserMobile.Text = objcopm.MOBPHONE;
            //lblmobile.Text = objlocation.;
            //  lbldate.Text = DateTime.Now.ToString();
            DateTime TIme = objICTR_HD.TRANSDATE;

            BindProduct(TID, LID, TRCID);
            // string url = "Report/InvoiceViewer.aspx?TRCID=" +  TRCID ;

            // string s = "window.open('" + url + "', 'popup_window', 'width=450,height=500,left=100,top=100,resizable=yes');";
            // ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            // pnlReport.Visible = true;

            tblsetupsalesh obj = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103);
            //lblpayment.Text = obj.PaymentDetails;                 
            //lblteglin.Text = txtteglin.Text =  obj.TagLine;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            DataTable CompanyDt = DAL.Get_CompanyInfo(TID);
            DataTable QuotationDT = DAL.Get_SalesQuotation(TID, LID, TRCID);
            if (CompanyDt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(CompanyDt.Rows[0]["Islocation"]))
                {
                    txtstore.Text = objlocation.LOCNAME1;
                }
                else
                {
                    txtstore.Text = "";
                }

                logoid.ImageUrl = CompanyDt.Rows[0]["ImageUrl"].ToString();
                Label8.Text = CompanyDt.Rows[0]["CompanyName"].ToString();
                Label9.Text = CompanyDt.Rows[0]["CompanyAddress"].ToString();
                Label10.Text = CompanyDt.Rows[0]["Phone"].ToString();
                //Label14.Text = ";
                Label13.Text = CompanyDt.Rows[0]["Email"].ToString();
                Label11.Text = CompanyDt.Rows[0]["Note"].ToString();
                Label12.Text = CompanyDt.Rows[0]["ArabicNote"].ToString();
                lblNoteEnglish.Text = CompanyDt.Rows[0]["Note"].ToString();
                lblNoteArabic.Text = CompanyDt.Rows[0]["ArabicNote"].ToString();
                //A4
                //A4
                logoida4.ImageUrl = CompanyDt.Rows[0]["ImageUrl"].ToString();
                lblcompanynamea4.Text = CompanyDt.Rows[0]["CompanyName"].ToString();
                lblCompanynamearabicA4.Text = CompanyDt.Rows[0]["CompanyNameArabic"].ToString();
                lblcompanyaddressa4.Text = CompanyDt.Rows[0]["CompanyAddress"].ToString();
                lblcompanyphonea4.Text = CompanyDt.Rows[0]["Phone"].ToString();
                //Label14.Text = ";
                lblcompanyemaila4.Text = CompanyDt.Rows[0]["Email"].ToString();
                if (QuotationDT.Rows.Count > 0)
                {
                    lblQuotation.Text = QuotationDT.Rows[0]["QuotationNo"].ToString();
                    lblLPP.Text = QuotationDT.Rows[0]["LPONo"].ToString();
                }
                lblcustomerCode.Text = objICTR_HD.CUSTVENDID.ToString();
            }
            else
            {
                logoid.ImageUrl = "../ECOMM/Upload/Company.png";
                Label8.Text = "Company Name";
                Label9.Text = "Company Address";
                Label10.Text = "Phone Number";
                //Label14.Text = ";
                Label13.Text = "Company@Email Addrees";
                Label11.Text = "<b>Note: </b> Sold merchandise will be returned and exchanged within 14 days from the date of purchase";
                Label12.Text = "البضاعة المباعة ترد وتستبدل خلال ١٤ يوم من تاريخ الشراء";
            }

            //    if (TID == 17)
            //    {
            //        logoid.ImageUrl = "../ECOMM/Upload/logo.png";
            //        Label8.Text = "Atyab Al-Saeed For Perfumes Co";
            //        Label9.Text = "Office-51 Floor -15, Panasonic Tower, Al-Qibla";
            //        Label10.Text = "94701017,55192284";
            //        //Label14.Text = ";
            //        Label13.Text = "Info@atyabalsaeed.com.kw";
            //        Label11.Text = "<b> Note: </b> Sold merchandise will be returned and exchanged within 14 days from the date of purchase";
            //        Label12.Text = "البضاعة المباعة ترد وتستبدل خلال ١٤ يوم من تاريخ الشراء";
            //    }
            //    else if (TID == 18)
            //    {
            //        logoid.ImageUrl = "../ECOMM/Upload/ov.png";
            //        Label8.Text = "OV Restaurant";
            //        Label9.Text = "Abu al Hasaniya";
            //        Label10.Text = "";
            //        Label14.Text = "";
            //        Label13.Text = "";
            //        Label11.Text = "<h2>Thank you for order</h2>";
            //        Label12.Text = "";

            //}
            //    else if (TID == 19)
            //    {
            //        logoid.ImageUrl = "../ECOMM/Upload/padel.png";
            //        Label8.Text = "Dar Al Reem";
            //        Label9.Text = "Hawali Block 4 Tunis Street";
            //        Label10.Text = "";
            //        Label14.Text = "";
            //        Label13.Text = "";
            //        Label11.Text = "<h2>Thank you for order</h2>";
            //        Label12.Text = "";
            //    }
            //    else if (TID == 20)
            //    {
            //        logoid.ImageUrl = "../ECOMM/Upload/kna.png";
            //        Label8.Text = "Fayonka";
            //        Label9.Text = "Bruit Street Hawally, Kuwait";
            //        Label10.Text = "99814941";
            //        Label14.Text = "";
            //        Label13.Text = "";
            //        Label11.Text = "<h2>Thank you for order</h2>";
            //        Label12.Text = "";
            //    }
            //public void printInv(int TRCID)
            //{
            //    checksession();
            //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //    int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);

            //    ICTR_HD_Sales objICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.locationID == LID);
            //    //int EID = Convert.ToInt32(objICTR_HD.ExtraField2);
            //    //lblSalemen.Text = DB.tbl_Employee.Single(p => p.TanentId == TID && p.LocationID == LID && p.employeeID == EID).firstname;
            //    int CUTID = Convert.ToInt32(objICTR_HD.CUSTVENDID);
            //    lblpaymenttype.Text = objICTR_HD.payment_type;
            //    if (DB.ICIT_BR_ReferenceNo.Where(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.RefID == 10512).Count() > 0)
            //    {
            //        ICIT_BR_ReferenceNo objbrre = DB.ICIT_BR_ReferenceNo.Single(p => p.MYTRANSID == TRCID && p.TenentID == TID && p.RefID == 10512);
            //        //lbllponumber.Text = objbrre.ReferenceNo;
            //    }
            //    if (objICTR_HD.Terms != 0 && objICTR_HD.Terms != null)
            //    {
            //        int RID = Convert.ToInt32(objICTR_HD.Terms);
            //        //pnltrrms.Visible = true;
            //        //lblterms.Text = DB.REFTABLEs.Single(p => p.TenentID == TID && p.REFID == RID).REFNAME1;
            //    }
            //    else
            //    {
            //        //pnltrrms.Visible = false;
            //    }
            //    if (objICTR_HD.ExtraSwitch1 == "1")
            //    {
            //        //lblcseandcredt.Text = "CREDIT";
            //        //lblcseandcredtarabic.Text =lblcseandcredt.Text;
            //    }
            //    else
            //    {
            //        //    lblcseandcredt.Text = "CASH";
            //        //    lblcseandcredtarabic.Text = lblcseandcredt.Text;
            //    }
            //    //else
            //    //{
            //    //    lblcseandcredt.Text = "Corp";
            //    //}
            //    TBLCOMPANYSETUP objcopm = DB.TBLCOMPANYSETUPs.Single(p => p.COMPID == CUTID && p.TenentID == TID);

            //    labelUSerNAme.Text = objcopm.COMPNAME1;
            //    string Add1 = objcopm.ADDR1;
            //    string Add2 = objcopm.ADDR2;
            //    labelUSerNAme.Text = objcopm.COMPNAME1;
            //    // lblphone.Text = objcopm.MOBPHONE;
            //    lblmobile.Text = objcopm.MOBPHONE;
            //    //  lbldate.Text = DateTime.Now.ToString();
            //    DateTime TIme = objICTR_HD.TRANSDATE;

            //    BindProduct(TID, LID, TRCID);
            //    tblsetupsalesh obj = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103);

            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            DataTable locinfo = DAL.Get_LocInfo(TID, UID);
            String PrintMethod = locinfo.Rows[0]["PrintPanel"].ToString();
            if (PrintMethod.ToString() == "A4")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Script", "PrintPanelA4();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Script", "PrintPanel();", true);
            }
        }

        public string getfuctername(int FID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (FID == 0 || FID == null)
            {
                return null;
            }
            else
            {
                return DB.TBLCOMPANYSETUPs.SingleOrDefault(p => p.TenentID == TID && p.COMPID == FID).COMPNAME1;
            }

        }
        public void BindProduct(int TID, int LID, Int64 TRCID)
        {
            bool Status = DAL.CheckForInvoice(TID, TRCID, LID);
            if (Status)
            {
                //int UID = Convert.ToInt32(((TBLCONTACT)Session["USER"]).ContactMyID);
                DataTable listdt = DAL.Report_Sale_Invoice(TID, LID, TRCID);// DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == TRCID);
                listProductst.DataSource = listdt;
                listProductst.DataBind();

                listproductA4.DataSource = listdt;
                listproductA4.DataBind();



                Listviewpayment.DataSource = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == TRCID && p.locationID == LID);
                Listviewpayment.DataBind();

                listpaymentA4.DataSource = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == TRCID && p.locationID == LID);
                listpaymentA4.DataBind();

                var listHD = DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == TRCID && p.locationID == LID);


                //decimal SUM = Convert.ToDecimal(list.Sum(m => m.payment_amount));

                var listpay = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == TRCID && p.locationID == LID);
                decimal SUM = Convert.ToDecimal(listpay.Sum(m => m.payment_amount));
                decimal DISCUNT = Convert.ToDecimal(listpay.Min(m => m.dis));
                decimal DeliveryCharges = Convert.ToDecimal(listpay.Min(m => m.Delivery_Cahrge));
                decimal due = Convert.ToDecimal(listpay.Min(m => m.due_amount));
                // lbldue.Text = due.ToString();
                decimal TAmount = Convert.ToDecimal(SUM + DISCUNT + due);



                // lbldue.Text = due.ToString();
                decimal paid = SUM - (due + DeliveryCharges);
                // lblDiscount.Text = "0.00";
                decimal MINISUM = SUM;
                MINISUM = Math.Round(MINISUM, 3);
                lblpin.Text = TRCID.ToString();
                lblA4InvoiceID.Text = TRCID.ToString();
                CultureInfo[] cultures = new CultureInfo[] {CultureInfo.InvariantCulture,
                                                  new CultureInfo("en-us")};
                lblDate.Text = Convert.ToDateTime(listdt.Rows[0]["EDate"]).ToString("dd MMMM yyyy HH:mm:ss");
                lblA4InvoiceDate.Text = Convert.ToDateTime(listdt.Rows[0]["EDate"]).ToString("dd MMMM yyyy HH:mm:ss");

                // Database.ICTR_sales_payment objsale = DB.ICTR_sales_payment.Single(p => p.TenentID == TID && p.sales_id == TRCID && p.locationID == LID);

                Database.ICTR_HD_Sales objnew = DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == TRCID && p.locationID == LID);
                {
                    if (objnew.payment_type == "Credit")
                    {

                        lblSubtotal.Text = paid.ToString();

                        lblGalredTot.Text = TAmount.ToString();//GalredTotal.ToString();

                        lbldeliver.Text = DeliveryCharges.ToString();

                        //lblDiscount.Text = "0.00";
                        Label3.Text = DISCUNT.ToString();

                        lblA4Subtotal.Text = paid.ToString();
                        //lblA4Delivery.Text = DeliveryCharges.ToString(); ///lbldue.Text = due.ToString();
                        lblA4Discount.Text = DISCUNT.ToString();
                        lblA4Grandtotal.Text = TAmount.ToString();//GalredTotal.ToString();
                    }
                    else if (objnew.payment_type == "COD")
                    {
                        //lblDiscount.Text = DISCUNT.ToString();
                        MINISUM = Math.Round(MINISUM, 3);
                        lblSubtotal.Text = paid.ToString(); //MINISUM.ToString();
                        lbldeliver.Text = DeliveryCharges.ToString();                                 /// lbldue.Text = due.ToString();
                        lblGalredTot.Text = "0.00";//GalredTotal.ToString();
                        Label3.Text = DISCUNT.ToString();

                        lblA4Subtotal.Text = paid.ToString();
                        //lblA4Delivery.Text = DeliveryCharges.ToString(); ///lbldue.Text = due.ToString();
                        lblA4Discount.Text = DISCUNT.ToString();
                        lblA4Grandtotal.Text = "0.00";
                    }
                    else
                    {
                        //lblDiscount.Text = DISCUNT.ToString();
                        MINISUM = Math.Round(MINISUM, 3);
                        lblSubtotal.Text = paid.ToString();
                        // lbldue.Text = due.ToString();
                        lbldeliver.Text = DeliveryCharges.ToString();
                        lblGalredTot.Text = MINISUM.ToString();//GalredTotal.ToString();
                        Label3.Text = DISCUNT.ToString();

                        lblA4Subtotal.Text = paid.ToString();
                        //lblA4Delivery.Text = DeliveryCharges.ToString(); ///lbldue.Text = due.ToString();
                        lblA4Discount.Text = DISCUNT.ToString();
                        lblA4Grandtotal.Text = MINISUM.ToString();//GalredTotal.ToString();
                    }
                }

                /// lblpaymenttype.Text = objsale.payment_type + " ";
                string[] FunWord = MINISUM.ToString().Split('.');

                int W1 = Convert.ToInt32(FunWord[0]);
                int W2 = 0;
                if (W1 != 0)
                {
                    W2 = Convert.ToInt32(FunWord[1]);
                }

                string WoredQ = words(W1);
                string WordPoint = "";
                if (W2 == 0 || W2 == 00 || W2 == 000)
                { }
                else
                {
                    WordPoint = words(W2);
                }
                DataTable CompanyDt = DAL.Get_CompanyInfo(TID);
                if (CompanyDt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(CompanyDt.Rows[0]["Inwords"]))
                    {
                        DataTable Locations = DAL.Get_Location(LID, TID);
                        string Currency = Locations.Rows[0]["Currency"].ToString();
                        if (WordPoint == "")
                        {
                            lblword.Text = "<b> In Words : </b>  " + Currency + "  <b> " + WoredQ + " </b>  Only  ";
                            lblA4words.Text = "<b> In Words : </b>  " + Currency + "  <b> " + WoredQ + " </b>  Only  ";
                        }
                        else
                        {
                            lblword.Text = "<b> In Words : </b>   " + Currency + " <b> " + WoredQ + " & 0." + W2 + "/1000   </b> Only";
                            lblA4words.Text = "<b> In Words : </b>   " + Currency + " <b> " + WoredQ + " & 0." + W2 + "/1000   </b> Only";
                        }
                    }
                }
                //if(TID == 17) { 
                //if (WordPoint == "")
                //    lblword.Text = "<b>In Words : </b>  Dinars  <b> " + WoredQ + " </b> Only ";
                //else
                //    lblword.Text = "<b>In Words : </b>  Dinars <b> " + WoredQ + " & 0." + W2 + "/1000 Fils </b> Only";
                //    }
                //else if( TID == 18 && TID == 19)
                //    {
                //        lblword.Text = "";
                //    }
            }
            //Kuwaiti Dinars Zero & 0.500/1000 Fils Only
        }
        //public void BindProduct(int TID, int LID, int TRCID)
        //{

        //    //int UID = Convert.ToInt32(((TBLCONTACT)Session["USER"]).ContactMyID);
        //    DataTable listdt = DAL.Report_Sale_Invoice(TID, LID, TRCID);// DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == TRCID);
        //    listProductst.DataSource = listdt;
        //    listProductst.DataBind();

        //    Listviewpayment.DataSource = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == TRCID && p.payment_amount != 0);
        //    Listviewpayment.DataBind();
        //    decimal SUM = Convert.ToDecimal(listdt.Rows[0]["payment_amount"]);
        //    decimal DISCUNT = Convert.ToDecimal(listdt.Rows[0]["DISAMT"]);
        //    //lblDiscount.Text = DISCUNT.ToString();
        //    var listpay = DB.ICTR_sales_payment.Where(p => p.TenentID == TID && p.sales_id == TRCID);
        //    decimal due = Convert.ToDecimal(listpay.Min(m => m.due_amount));
        //    decimal MINISUM = SUM - DISCUNT;
        //    MINISUM = Math.Round(MINISUM, 3);
        //    //decimal Vat = Convert.ToDecimal(lblVat.Text);
        //    //decimal MianSub = (MINISUM * Vat) / 100;
        //    //decimal GalredTotal = MINISUM;// +Vat;
        //    //int Total = Convert.ToInt32(GalredTotal);
        //    lblSubtotal.Text = SUM.ToString();
        //    //lbldue.Text = due.ToString();
        //    decimal paid = SUM - due;
        //    lblGalredTot.Text = paid.ToString();//GalredTotal.ToString();
        //    Label3.Text = DISCUNT.ToString();
        //    string[] FunWord = MINISUM.ToString().Split('.');
        //    int W1 = Convert.ToInt32(FunWord[0]);
        //    int W2 = Convert.ToInt32(000);

        //    string WoredQ = words(W1);
        //    string WordPoint = "";
        //    if (W2 == 0 || W2 == 00 || W2 == 000)
        //    { }
        //    else
        //    {
        //        WordPoint = words(W2);
        //    }
        //    if (WordPoint == "")
        //        lblword.Text = " Kuwaiti Dinars <b>" + WoredQ + "</b> Only";
        //    else
        //        lblword.Text = " Kuwaiti Dinars <b>" + WoredQ + " & 0." + W2 + "/1000</b> Fils Only";

        //    //Kuwaiti Dinars Zero & 0.500/1000 Fils Only
        //}
        public string words(int numbers)
        {
            int number = numbers;
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
"Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
"Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
"Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }

        public string getprodname(int SID)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            return DB.TBLPRODUCTs.Single(p => p.MYPRODID == SID && p.TenentID == TID).BarCode;
        }

        public string GetDesc(string DSC)
        {
            checksession();
            string Descrip = DSC.Replace("\n", "<br />");
            return Descrip;
        }
        protected void grdPO_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            LinkButton lnkdelivery = (LinkButton)e.Item.FindControl("lnkdelivery");
            Label lblMYTRANSID = (Label)e.Item.FindControl("lblMYTRANSID");
            Label lblStatus = (Label)e.Item.FindControl("lblStatus");
            LinkButton lnkassignemp = (LinkButton)e.Item.FindControl("lnkassignemp");
            Button btnassingemp = (Button)e.Item.FindControl("btnassingemp");
            Button btnpayment = (Button)e.Item.FindControl("btnpayment");

            CheckBox chkmyid = (CheckBox)e.Item.FindControl("chkmyid");
            int MID = Convert.ToInt32(lblMYTRANSID.Text);

            List<ICTR_HD_Sales> list = DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == MID && p.SoldByEmp_ID != "0" && p.SoldByEmp_ID != null).ToList();

            if (list.Count() > 0)
            {
                lnkassignemp.Visible = false;
                lnkdelivery.Visible = true;
            }
        }

        protected void BtnWeek_Click(object sender, System.EventArgs e)
        {
            GridData(3);
          
        }

        protected void BtnMonth_Click(object sender, System.EventArgs e)
        {
            GridData(4);
           
        }

        protected void BtnFull_Click(object sender, System.EventArgs e)
        {
            GridData(1);
         
        }

        public string Statustmp(int MYTRANSID)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            var listHD = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.locationID == LID).ToList();
            if (listHD.Count() > 0)
            {
                string Status = listHD.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).Status;
                bool Active = Convert.ToBoolean(listHD.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ACTIVE);
                if (Status == "SO" && Active == true)
                {
                    return "Final";
                }
                else if (Status == "DSO" && Active == true)
                {
                    return "Draft";
                }
                else
                {
                    return "Deleted";
                }
            }
            else
            {
                return "";
            }

        }
        public string Status(int MYTRANSID)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            var listHD = DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.locationID == LID).ToList();
            if (listHD.Count() > 0)
            {
                string Status = listHD.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).Status;
                bool Active = Convert.ToBoolean(listHD.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ACTIVE);
                if (Status == "Final" && Active == true)
                {
                    return "Final";
                }
                else if (Status == "COD" && Active == true)
                {
                    return "COD";
                }
                else if (Status == "Credit" && Active == true)
                {
                    return "Credit";
                }
                else if (Status == "Credit" && Active == true)
                {
                    return "Draft";
                }
                else
                {
                    return "cash";
                }
            }
            else
            {
                return "";
            }

        }

        protected void lnkdraft_Click(object sender, System.EventArgs e)
        {
            checksession();
            List<Database.ICTR_HD_Sales_tmp> listmultiuom1 = new List<ICTR_HD_Sales_tmp>();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DateTime currentDt = DateTime.Now;
            int dd = currentDt.Day;
            int mm = currentDt.Month;
            int yy = currentDt.Year;
            listmultiuom1 = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.locationID == LID && p.TRANSDATE.Day == dd && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.Status == "Draft" && p.transid == Transid && p.transsubid == Transsubid).OrderByDescending(p => p.MYTRANSID).ToList();
            lbllistDate.Text = currentDt.ToShortDateString();
            int count = listmultiuom1.Count();
            if (count > 0)
            {
                grdPO.DataSource = listmultiuom1.Select(m => new { m.CUSTVENDID, m.TOTAMT, m.Status, m.USERID, m.TRANSDATE, m.TransDocNo, m.MYTRANSID, m.PaymentStatus, m.OrderStatus, m.DeliveryStatus, m.Orderway, m.PaymentType }).Distinct();//DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && (p.Status == "SO" || p.Status == "DSO" && p.transid == Transid && p.transsubid == Transsubid)).OrderByDescending(p => p.MYTRANSID);// p.ACTIVE==true &&
                grdPO.DataBind();
                for (int i = 0; i < grdPO.Items.Count; i++)
                {
                    Label lblMYTRANSID = (Label)grdPO.Items[i].FindControl("lblMYTRANSID");
                    int stMYTRANSID = Convert.ToInt32(lblMYTRANSID.Text);
                    if (i == 0)
                    {
                        //BindHD(stMYTRANSID);
                        //BindDTui(stMYTRANSID);
                        // readMode();
                    }
                    LinkButton Print = (LinkButton)grdPO.Items[i].FindControl("Print");
                    LinkButton lnkbtnPurchase_Order = (LinkButton)grdPO.Items[i].FindControl("lnkbtnPurchase_Order");
                    Label lbluserid = (Label)grdPO.Items[i].FindControl("lbluserid");
                    Label lblStatus = (Label)grdPO.Items[i].FindControl("lblStatus");
                    LinkButton lnkbtndelete = (LinkButton)grdPO.Items[i].FindControl("lnkbtndelete");
                    Label lblspnoo = (Label)grdPO.Items[i].FindControl("lblspnoo");
                    //Label lbldraftlabl = (Label)grdPO.Items[i].FindControl("lbldraftlabl");
                    //lbldraftlabl.Visible = true;
                    lblspnoo.Text = "Draft";

                    string Steate = Statustmp(stMYTRANSID);
                    if (Steate == "Draft")
                    {
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnkbtndelete.Visible = true;
                    }

                    if (Steate == "Final")
                    {
                        Print.Visible = true;
                    }



                    string Active = Status(stMYTRANSID);
                    if (Active == "Deleted")
                    {
                        Print.Visible = true;
                        lnkbtndelete.Visible = false;
                    }

                }
            }
            else
            {
                grdPO.DataSource = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID  && p.TRANSDATE.Day == dd && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.Status == "DSO" && p.transid == Transid && p.transsubid == Transsubid).OrderByDescending(p => p.MYTRANSID).ToList();
                grdPO.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            checksession();
            List<Database.View_SalesControl> listmultiuom1 = new List<View_SalesControl>();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DateTime currentDt = DateTime.Now;
            int dd = currentDt.Day;
            int mm = currentDt.Month;
            int yy = currentDt.Year;
            listmultiuom1 = DB.View_SalesControl.Where(p => p.TenentID == TID && p.locationID == LID && p.TRANSDATE.Day == dd && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.OrderStatus == "Completed" && p.transid == Transid && p.transsubid == Transsubid).OrderByDescending(p => p.MYTRANSID).ToList();
            lbllistDate.Text = currentDt.ToShortDateString();
            int count = listmultiuom1.Count();
            if (count > 0)
            {
                grdPO.DataSource = listmultiuom1.Select(m => new { m.CUSTVENDID, m.TOTAMT, m.Status, m.USERID, m.TRANSDATE, m.TransDocNo, m.MYTRANSID,m.PaymentStatus,m.OrderStatus, m.DeliveryStatus ,m.Orderway,m.PaymentType }).Distinct();//DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && (p.Status == "SO" || p.Status == "DSO" && p.transid == Transid && p.transsubid == Transsubid)).OrderByDescending(p => p.MYTRANSID);// p.ACTIVE==true &&
                grdPO.DataBind();
                for (int i = 0; i < grdPO.Items.Count; i++)
                {
                    Label lblMYTRANSID = (Label)grdPO.Items[i].FindControl("lblMYTRANSID");
                    int stMYTRANSID = Convert.ToInt32(lblMYTRANSID.Text);
                    if (i == 0)
                    {
                        //BindHD(stMYTRANSID);
                        //BindDTui(stMYTRANSID);
                        // readMode();
                    }
                    LinkButton Print = (LinkButton)grdPO.Items[i].FindControl("Print");
                    LinkButton lnkbtnPurchase_Order = (LinkButton)grdPO.Items[i].FindControl("lnkbtnPurchase_Order");
                    Label lbluserid = (Label)grdPO.Items[i].FindControl("lbluserid");
                    Label lblStatus = (Label)grdPO.Items[i].FindControl("lblStatus");
                    LinkButton lnkbtndelete = (LinkButton)grdPO.Items[i].FindControl("lnkbtndelete");



                    string Steate = Status(stMYTRANSID);
                    if (Steate == "Draft")
                    {
                        Print.Visible = true;
                        lnkbtnPurchase_Order.Visible = true;
                        lnkbtndelete.Visible = true;
                    }

                    if (Steate == "Final")
                    {
                        Print.Visible = true;
                    }
                    string Active = Status(stMYTRANSID);
                    if (Active == "Deleted")
                    {
                        Print.Visible = true;
                        lnkbtndelete.Visible = false;
                    }
                }
            }
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager dp = (DataPager)grdPO.FindControl("DataPager1");
           dp.SetPageProperties(e.StartRowIndex, int.Parse(drpShowGrid.SelectedItem.Text), false);

           GridData(int.Parse(Session["ID"].ToString()));
        }
        protected void drpShowGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataPager dp = (DataPager)grdPO.FindControl("DataPager1");
            dp.SetPageProperties(0, int.Parse(drpShowGrid.SelectedItem.Text), true);
            GridData(int.Parse(Session["ID"].ToString()));


        }
    }
}