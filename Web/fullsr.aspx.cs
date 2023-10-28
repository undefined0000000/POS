using AjaxControlToolkit;
using Classes;
using Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
//using Newtonsoft.Json;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.ECOMM.UserControl;
using Web.POS;
using Web.Sales;

using System.Diagnostics;

using System.Web.SessionState;

namespace Web
{
    public partial class fullsr : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
        SqlCommand command2 = new SqlCommand();
        CallEntities DB = new CallEntities();
        static private string bearerToken = ConfigurationManager.AppSettings["bearerToken"];
        static private string Baseurl = ConfigurationManager.AppSettings["Baseurl"];
        PropertyFile objProFile = new PropertyFile();
        string LangID, CURRENCY, USERID, Crypath = "";
        int LID = 1;
        int TID = 0;
        int TerminalID = 1;

        int Transid = 4101;
        int transsubid = 410103;
        List<Database.ICTR_DT_Sales_tmp> TempListICTR_DT123 = new List<Database.ICTR_DT_Sales_tmp>();
        List<Database.ICTRPayTerms_HD> TempICTRPayTerms_HD = new List<Database.ICTRPayTerms_HD>();
        protected void Page_Load(object sender, EventArgs e)
        {


            checksession();
            LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            TerminalID = int.Parse(Session["TerminalID"].ToString());
            if (!IsPostBack)
            {

                TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);

                //
                Label labelTID = this.FindControl("LabelTID") as Label;
                labelTID.Text = "" + TID;

                Label labelLID = this.FindControl("LabelLID") as Label;
                labelLID.Text = "" + LID;
                //

                Debug.WriteLine(">>>>>>>>>>>>>> first load" + labelTID.Text + ", " + labelLID.Text);

                string CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt5 = DAL.Get_DayCloseEntry(TID, LID, CurrentDate);
                bool CheckCustomerSetting = DAL.CheckForCustomerSetting(TID, UID);
                chkcustomer.Checked = CheckCustomerSetting;
                DataTable printdt = DAL.Get_LocInfo(TID, UID);
                String PrintP = printdt.Rows[0]["PrintPanel"].ToString();
                if (PrintP == "A4")
                {
                    drpPrint.SelectedValue = "2";
                }
                else
                {
                    drpPrint.SelectedValue = "1";
                }
                if (dt5.Rows.Count == 0)
                {
                    Response.Redirect("Newdemo.aspx");
                }
                btnorder.Enabled = false;
                BtnCOD.Enabled = false;
                btndraft.Enabled = false;
                btnpaymentlist.Enabled = false;

                checksession();
                FirstBind();
                drpPayBy.DataSource = DAL.Get_PaymentType(TID);
                drpPayBy.DataTextField = "PaymentType";
                drpPayBy.DataValueField = "ID";
                drpPayBy.DataBind();
                Session["GetMYTRANSID"] = null;
                Session["Invoice"] = null;
                ViewState["InvoiceProd"] = null;

                bindropdown();
                //BindProduct();
                //GetProductDescription();yogesh
                //Classes.EcommAdminClass.getdropdown(ddlProduct, TID, LID.ToString(), "", "", "TBLPRODUCTWithICIT_BR");
                //Classes.EcommAdminClass.getdropdown(ddlUOM, TID, "", "", "", "ICUOM");
                //  List<TempProduct> Tlist = new List<TempProduct>();
                //Sahir Invoice
                int InvoiceID = 0;
                Int64 MYTRANSID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);// DB.ICTR_HD_Sales.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;
                //InvoiceItem.GetMYTRANSID(MYTRANSID);
                //Session["GetMYTRANSID"] = MYTRANSID;
                //int MYTRANSID = DB.ICTR_MYTRANSID.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_MYTRANSID.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;
                Session["GetMYTRANSID"] = MYTRANSID;
                lblinvoice.Text = "Inv" + MYTRANSID;
                List<TempProduct> Tlist = new List<TempProduct>();
                if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
                {
                    int mytid = Convert.ToInt32(Request.QueryString["MytransID"]);
                    Session["GetMYTRANSID"] = mytid;

                    lblinvoice.Text = "Inv" + mytid;
                    if (DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == mytid && p.locationID == LID).Count() > 0)
                    {
                        int custid = Convert.ToInt32(DB.ICTR_HD_Sales.Single(p => p.TenentID == TID && p.MYTRANSID == mytid && p.locationID == LID).CUSTVENDID);
                        txtcustomer.Text = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID & p.COMPID == custid).COMPNAME1;
                    }

                    List<Database.ICTR_DT_Sales_tmp> Tlistw = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == mytid && p.locationID == LID).ToList();
                    if (Tlistw.Count() > 0)
                    {
                        foreach (var item in Tlistw)
                        {
                            TempProduct obj = new TempProduct();
                            obj.Tenent = item.TenentID;
                            obj.product_id = Convert.ToInt32(item.MyProdID);
                            obj.UOMID = Convert.ToInt32(item.UOM); // change by dipak
                            int uomi = obj.UOMID;
                            obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == uomi).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == uomi).UOMNAME1 : "Not Name"; // change by dipak
                            //obj.Shopid = purobj.Shopid;//yogesh
                            obj.product_name = item.DESCRIPTION;
                            obj.product_name_Arabic = item.DESCRIPTION;
                            obj.product_name_print = item.DESCRIPTION;
                            obj.price = Convert.ToDecimal(item.UNITPRICE);//price
                            string alter = DB.TBLPRODUCTs.Single(p => p.TenentID == TID && p.MYPRODID == obj.product_id).AlternateCode1;
                            obj.CustItemCode = alter;
                            obj.msrp = Convert.ToDecimal(item.UNITPRICE);//total
                            obj.OpQty = Convert.ToInt32(item.QUANTITY);//qty)
                            decimal qty = Convert.ToInt32(1);//qty
                            decimal Dis = Convert.ToDecimal(0);//yogesh
                            decimal msrp = (Convert.ToDecimal(item.UNITPRICE) * qty);//total
                            decimal Fdis = ((msrp * Dis) / 100);
                            decimal price = obj.price;
                            obj.Total = (msrp);
                            obj.Discount = Math.Round(Fdis, 3);
                            Tlist.Add(obj);
                        }


                        var list = Tlistw;
                        BindInvoceList(Tlist);
                    }
                    else
                    {
                        List<Database.ICTR_DT_Sales> Tlists = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == mytid && p.locationID == LID).ToList();
                        foreach (var item in Tlists)
                        {
                            TempProduct obj = new TempProduct();
                            obj.Tenent = item.TenentID;
                            obj.product_id = Convert.ToInt32(item.MyProdID);
                            obj.UOMID = Convert.ToInt32(item.UOM); // change by dipak
                            int uomi = obj.UOMID;
                            obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == uomi).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == uomi).UOMNAME1 : "Not Name"; // change by dipak
                            //obj.Shopid = purobj.Shopid;//yogesh
                            obj.product_name = item.DESCRIPTION;
                            obj.product_name_Arabic = item.DESCRIPTION;
                            obj.product_name_print = item.DESCRIPTION;
                            obj.price = Convert.ToDecimal(item.UNITPRICE);//price
                            string alter = DB.TBLPRODUCTs.Single(p => p.TenentID == TID && p.MYPRODID == obj.product_id).AlternateCode1;
                            obj.CustItemCode = alter;
                            obj.msrp = Convert.ToDecimal(item.UNITPRICE);//total
                            obj.OpQty = Convert.ToInt32(item.QUANTITY);//qty)
                            decimal qty = obj.OpQty;//qty
                            decimal Dis = Convert.ToDecimal(0);//yogesh
                            decimal msrp = (Convert.ToDecimal(item.UNITPRICE) * qty);//total
                            decimal Fdis = ((msrp * Dis) / 100);
                            decimal price = obj.price;
                            obj.Total = (msrp);
                            obj.Discount = Math.Round(Fdis, 3);
                            obj.RowTotal = msrp;
                            Tlist.Add(obj);

                        }
                        var list = Tlists;
                        BindInvoceList(Tlist);
                    }
                }
            }
            txtItemSearch.Focus();

        }

        public void checksession()
        {
            if (Session["USER"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }


        protected void GetTime(object sender, EventArgs e)
        {
            DateTime currentDt = DateTime.Now;
            int dd = currentDt.Day;
            int mm = currentDt.Month;
            int yy = currentDt.Year;
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

            List<Database.ICTR_HD_Sales> listmultiuom1 = new List<ICTR_HD_Sales>();
            listmultiuom1 = DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.TRANSDATE.Day == dd && p.TRANSDATE.Month == mm && p.TRANSDATE.Year == yy && p.MYTRANSID != 0).OrderByDescending(p => p.MYTRANSID).ToList();
            if (listmultiuom1.Count() > 0)
            {
                // lbltimers.Text = listmultiuom1.Sum(p => p.TerminalID).ToString();
                //lbltimers.Visible = true;
            }
        }

        public void FirstBind()
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int USetting = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            List<Database.View_ProductCatWiseData> listmultiuom1 = DAL.Get_Item_View_Location(TID, LID);// DB.View_ProductCatWiseData.Where(p => p.TenentID == TID).ToList();
            int count = listmultiuom1.Count();
            if (count > 0)
            {
                bool checkpossetting = DAL.CheckForPOSSetting(TID, USetting);
                Session["POSSetting"] = checkpossetting;
                if (checkpossetting)
                {
                    Session["ProductNameE"] = "product_name";
                    Session["ProductName"] = "ProdName1";
                    Session["CategoryName"] = "CAT_NAME1";

                }
                else
                {
                    Session["ProductNameE"] = "product_name_arabic";
                    Session["ProductName"] = "ProdName2";
                    Session["CategoryName"] = "CAT_NAME2";
                }

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(listmultiuom1);


                Label labeTotalData = this.FindControl("totalCateData") as Label;
                labeTotalData.Text = "" + json;



                Label labelProductName = this.FindControl("idfProductName") as Label;
                labelProductName.Text = "" + Session["ProductName"];


                ListCategory.DataSource = listmultiuom1.Select(m => new { m.CAT_NAME1, m.CAT_NAME2, m.MainCategoryID, m.DefaultPic }).Distinct();// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                ListCategory.DataBind();


                int firstCateID = Convert.ToInt32(listmultiuom1[0].MainCategoryID);
                ItemList.DataSource = listmultiuom1.Where(p => p.MainCategoryID == firstCateID);// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                ItemList.DataBind();
                ItemCountLeft();




            }
            customerlist.DataSource = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "y" && p.BUYER == true && p.TenentID == TID).Take(5);
            customerlist.DataBind();


        }
        public void ItemCountLeft()
        {
            pnlitemNavigation.Visible = ItemList.Items.Count >= 18 ? true : false;
            lblitemTotal.Text = ItemList.Items.Count.ToString();
        }

        [WebMethod(EnableSession = true)]

        public static string getAllCart()
        {
/*            Debug.WriteLine(">>>>>>>>get all cart jsonData" + jsonData);

            JObject jsonObject = JObject.Parse(jsonData);

            int TID = (int)jsonObject["TID"];
            int LID = (int)jsonObject["LID"];

            Debug.WriteLine(">>>>>>>>get all cart " + TID + ", " + LID);*/

            // int TID = Convert.ToInt32(((USER_MST)HttpContext.Current.Session["USER"]).TenentID);
            List<Database.View_ProductCatWiseData> listItems = DAL.Get_Item_View_Location(17, 6);

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(listItems);

            // Return the JSON response
            return json;
        }
        public void btnCategoryall_Click(object sender, EventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            ItemList.DataSource = DAL.Get_Item_View_Location(TID, LID);//  DB.View_ProductCatWiseData.Where(p => p.TenentID == TID).ToList();// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
            ItemList.DataBind();
            ItemCountLeft();

        }


        [WebMethod(EnableSession = true)]
        public static string getCartItems()
        {

            /*            JObject jsonObject = JObject.Parse(jsonData);

                        int TID = (int)jsonObject["TID"];
                        int LID = (int)jsonObject["LID"];
                        int CID = (int)jsonObject["CID"];*/
            /*            Debug.WriteLine(">>>>>>>>get all cart " + jsonData);
            */
            List<Database.View_ProductCatWiseData> listItems = DAL.Get_Item_View_Category(17, 6, 42);

            // Serialize the items to JSON
            var serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(listItems);

            // Return the JSON response
            return json;
        }

        protected void ListCategory_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DisplayCat")
            {
                checksession();
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int CatID = Convert.ToInt32(e.CommandArgument);
                Label lblcatnames = (Label)e.Item.FindControl("lblcatnames");
                Label labelcatenameblue = (Label)e.Item.FindControl("labelcatenameblue");


                //List<Database.View_ProductCatWiseData> listmultiuom1 = DB.View_ProductCatWiseData.Where(p => p.TenentID == TID).ToList();
                //int count = listmultiuom1.Count();
                //if (count > 0)
                //{
                // ViewState["CID"] = CatID;




                //////////////// blocked by me
                ItemList.DataSource = DAL.Get_Item_View_Category(TID, LID, CatID);// DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CatID);// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                Debug.WriteLine(">>>>>>>>>>>>>>" + TID + ", " + LID);
                ItemList.DataBind();
                ItemCountLeft();
                ///////////////// blocked by me

                //if (ViewState["CID"] != null && ViewState["CID"] != "0")
                //{
                //    int CID = Convert.ToInt32(ViewState["CID"]);
                //    lblcatnames.Visible = false;
                //    labelcatenameblue.Visible = true;
                //    ItemList.DataSource = DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CID);// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                //    ItemList.DataBind();
                //    ItemCountLeft();
                //}
                //else
                //{
                //    lblcatnames.Visible = true;
                //    labelcatenameblue.Visible = false;
                //}
                //if (DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CatID).Count()>0)
                //{
                //    lblcatnames.Visible = false;
                //    labelcatenameblue.Visible = true;

                //}
                //else
                //{
                //    lblcatnames.Visible = true;
                //    labelcatenameblue.Visible = false;
                //}
                //}

            }
        }

        protected void Listview2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int IItemCount = 0;
            List<TempProduct> Tlist = new List<TempProduct>();
            if (e.CommandName == "LnkProdAdd" || e.CommandName == "LnkProdAdd_Update" )
            {
                string[] ID = e.CommandArgument.ToString().Split('~');
                string Prodname = ID[0].ToString();
                int Prodid = Convert.ToInt32(ID[1]);
                string UOMIDd = ID[2].ToString();

                DataTable purobj = DAL.Get_Item_View_Product(TID, LID, Prodid);// DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Prodid);
                int UMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString());

                TempProduct obj = new TempProduct();
                if (ViewState["InvoiceProd"] == null)
                {
                    obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                    obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                    obj.UOMID = Convert.ToInt32(UMID);
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                    obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                    obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                    obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                    obj.supplier = purobj.Rows[0]["Option1"].ToString();
                    obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                    //obj.status = Convert.ToInt32(purobj.Rows[0]["Option1"].ToString());//yogesh
                    obj.price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                    obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"].ToString());
                    obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"].ToString());
                    obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"].ToString());
                    obj.RowTotal = Convert.ToDecimal(purobj.Rows[0]["RowTotal"].ToString());
                    //if(Tlist.Where(p => p.Tenent == TID && p.product_id == purobj.MYPRODID).Count() > 0)
                    //{
                    //    decimal qty = Convert.ToInt32(1);
                    //}
                    decimal qty = Convert.ToInt32(1);//qty
                    decimal Dis = Convert.ToDecimal(0);//yogesh
                    decimal msrp = (Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString()) * qty);//total
                    decimal Fdis = ((msrp * Dis) / 100);
                    decimal price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());
                    obj.Total = (msrp);
                    obj.Discount = Math.Round(Fdis, 3);
                    obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                    obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                    obj.Remarks = "";
                    obj.BatchNo = "1";

                    Tlist.Add(obj);

                }
                else
                {
                    Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
                    if (Tlist.Where(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).Count() > 0) // change by dipak
                    {
                        decimal qty = Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).OpQty); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                        int PID = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                        CalcDirectProd(PID, UMID);  // change by dipak
                    }
                    else
                    {
                        obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                        obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                        obj.UOMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString()); // change by dipak
                        obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                        //obj.Shopid = purobj.Shopid;
                        obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                        obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                        obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                        obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                        obj.supplier = purobj.Rows[0]["Option1"].ToString();
                        obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                        //obj.status = Convert.ToInt32(purobj.Rows[0]["Option2"].ToString());//yogesh
                        obj.price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                        obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                        obj.OpQty = Convert.ToInt32(1);//qty
                        obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"].ToString());
                        obj.QtyOut = Convert.ToInt32(purobj.Rows[0]["QTYSOLD"].ToString());
                        obj.QtyRecived = Convert.ToInt32(purobj.Rows[0]["QTYRCVD"].ToString());
                        obj.RowTotal = Convert.ToDecimal(purobj.Rows[0]["RowTotal"].ToString());
                        obj.OpQty = Convert.ToInt32(1);//qty

                        decimal qtys = Convert.ToInt32(1);//qty
                        decimal Diss = Convert.ToDecimal(0);//yogesh
                        decimal msrps = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                        decimal Fdiss = ((msrps * Diss) / 100);
                        decimal price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                        obj.Total = (msrps);
                        obj.Discount = Math.Round(Fdiss, 3);
                        obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                        obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                        obj.BatchNo = "1";
                        Tlist.Add(obj);

                    }

                }
                BindInvoceList(Tlist);
                txtItemSearch.Text = "";
                txtItemSearch.Focus();
            }
        }
        public void CalcDirectProd(int pid, int uomid) //Change by dipak
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
            TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);

            decimal msrp = Convert.ToDecimal(Calc.msrp);
            decimal RTotal = Convert.ToDecimal(Calc.msrp * (Calc.OpQty + 1));
            int QTY = Convert.ToInt32(Calc.OpQty);
            QTY = QTY + 1;
            decimal total = Convert.ToDecimal(msrp * QTY);
            string SUMID = uomid.ToString();
            // decimal DisRate = GetDisRate(pid, SUMID);yogesh

            //decimal Fdis = ((msrp * DisRate) / 100);yogesh

            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).msrp = msrp;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).Total = total;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).OpQty = QTY;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).RowTotal = RTotal;
            // Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid && p.BatchNo == BatchNo).Discount = Fdis;yogesh

            BindInvoceList(Tlist);
        }

        public void CalcDirectProd1(int pid, int uomid, decimal Qty, decimal Mrprice, string comments) //Change by dipak
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
            TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);

            decimal msrp = Convert.ToDecimal(Mrprice);
            decimal QTY = Convert.ToDecimal(Qty);
            decimal RTotal = msrp * Qty;


            decimal total = Convert.ToDecimal(msrp * QTY);
            string SUMID = uomid.ToString();
            // decimal DisRate = GetDisRate(pid, SUMID);yogesh

            //decimal Fdis = ((msrp * DisRate) / 100);yogesh

            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).msrp = msrp;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).Total = total;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).OpQty = QTY;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).RowTotal = RTotal;
            Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).Remarks = comments;
            // Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid && p.BatchNo == BatchNo).Discount = Fdis;yogesh

            BindInvoceList(Tlist);
        }
        List<TempProduct> Tlist = new List<TempProduct>();
        List<TempProduct> TlistInvoice1 = new List<TempProduct>();
        public void BindInvoceList(List<TempProduct> Tlist)
        {
            ViewState["InvoiceProd"] = Tlist;
            ViewState["Listinvoice1"] = Tlist;
            Listview1.DataSource = Tlist; //TempListICTR_DT123;
            Listview1.DataBind();
            ListInvoice1.DataSource = Tlist;
            ListInvoice1.DataBind();
            decimal FTotalInvoice1 = Convert.ToDecimal(Tlist.Sum(p => p.Total));
            lblinvoice1total.Text = FTotalInvoice1.ToString();

            lbliitemCount.Text = "(" + Listview1.Items.Count.ToString() + ")";
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                int IID = Convert.ToInt32(Request.QueryString["MytransID"]);
                int IIDs = Convert.ToInt32(Session["GetMYTRANSID"]);
                lblinvoice.Text = "Inv" + IIDs;
                lbldr.Visible = true;
                string paymentmode = Session["PaymentStatus"].ToString();
                if (paymentmode == "Draft")
                {
                    lbldr.Text = Session["PaymentStatus"] + "(" + IID + ")";
                }
                else
                {
                    lbldr.Visible = false;
                }
            }
            else
            {
                Int64 IID = Convert.ToInt64(Session["GetMYTRANSID"]);
                lblinvoice.Text = "Inv" + IID;
            }

            FinalCalc();
            if (lbliitemCount.Text != null && lbliitemCount.Text != "")
            {
                btnorder.Enabled = true;
                BtnCOD.Enabled = true;
                btndraft.Enabled = true;
                btnpaymentlist.Visible = false;
                BtnPayment.Visible = true;

            }
            else
            {
                btnorder.Enabled = false;
                BtnCOD.Enabled = false;
                btndraft.Enabled = false;
                btnpaymentlist.Visible = true;
                BtnPayment.Visible = false;
                btnpaymentlist.Enabled = false;
            }
        }


        public void FinalCalc()
        {

            panelMsg.Visible = false;
            lblErreorMsg.Text = "";
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

            decimal FTotal = Convert.ToDecimal(Tlist.Sum(p => p.Total));
            lbldeliverycharges.Text = txtdeliverycharges.Text;
            // Decimal Discount =  Convert.ToDecimal( lblDiscount.Text);
            FTotall.Text = txtPopupPaidAmount.Text = txtcpaidamount.Text = txtchangepaidamount.Text = lblPopupPaidAmount.Text = FTotal.ToString();
            FsubTotal.Text = FTotal.ToString();
            decimal DisInternal = Convert.ToDecimal(Tlist.Sum(p => p.Discount));
            DisInternal = Math.Round(DisInternal, 3);
            lblDiscount.Text = DisInternal.ToString();

            if (Tlist.Count() > 0)
            {
                try
                {
                    string str = "";
                    decimal DICUNT = 0;
                    decimal DICUNTOTAL = 0;
                    decimal InvoiceDes = 0;

                    if (txtDisPercent.Text.Contains("%"))
                    {
                        str = txtDisPercent.Text.Replace('%', ' ');
                        decimal DeliveryTotal = Convert.ToDecimal(txtdeliverycharges.Text);
                        decimal Ftotal = Convert.ToDecimal(FTotal) + DeliveryTotal;

                        DICUNT = Convert.ToDecimal(str);
                        DICUNTOTAL = Ftotal - (Ftotal * (DICUNT / 100));
                        InvoiceDes = (Ftotal * (DICUNT / 100));
                        DICUNTOTAL = DICUNTOTAL - DisInternal;

                        string roundsubtotal = Math.Round(DICUNTOTAL, 3).ToString();
                        //lblInvoiceDisPer.Text = DICUNT.ToString();
                        //lblinvoiceDis.Text = Math.Round(InvoiceDes, 3).ToString();
                        lblDiscount.Text = InvoiceDes.ToString("N3");
                        FsubTotal.Text = Ftotal.ToString();//roundsubtotal;
                        FTotall.Text = txtPopupPaidAmount.Text = txtcpaidamount.Text = txtchangepaidamount.Text = lblPopupPaidAmount.Text = lblPopupPaidAmount.Text = roundsubtotal;
                        //lblPayable.Text = roundsubtotal;
                        //txtcashReceived.Text = roundsubtotal;
                        //lblTotalpayableAmtPY.Text = roundsubtotal;
                        //txtPaidAmount.Text = roundsubtotal;
                        //lblChangeAMT.Text = "0.000";
                    }
                    else
                    {
                        str = txtDisPercent.Text;
                        decimal Ftotal = Convert.ToDecimal(FTotal);
                        decimal DeliveryTotal = Convert.ToDecimal(txtdeliverycharges.Text);
                        DICUNT = Convert.ToDecimal(str);
                        decimal Disper = (Ftotal * DICUNT) / 100;
                        DICUNTOTAL = (Ftotal + DeliveryTotal) - DICUNT;
                        InvoiceDes = DICUNT;
                        DICUNTOTAL = DICUNTOTAL - DisInternal;

                        string roundsubtotal = Math.Round(DICUNTOTAL, 3).ToString();
                        lblDiscount.Text = DICUNT.ToString("N3");
                        //lblInvoiceDisPer.Text = Disper.ToString();
                        //lblinvoiceDis.Text = Math.Round(InvoiceDes, 3).ToString();
                        FsubTotal.Text = Ftotal.ToString();

                        FTotall.Text = txtPopupPaidAmount.Text = txtcpaidamount.Text = txtchangepaidamount.Text = lblPopupPaidAmount.Text = lblPopupPaidAmount.Text = roundsubtotal;
                        // txtPopupPaidAmount.Text = FTotall.Text;
                        //lblPayable.Text = roundsubtotal;
                        //txtcashReceived.Text = roundsubtotal;
                        //lblTotalpayableAmtPY.Text = roundsubtotal;
                        //txtPaidAmount.Text = roundsubtotal;
                        //lblChangeAMT.Text = "0.000";
                    }
                }
                catch
                {
                    //panelMsg.Visible = true;
                    //lblErreorMsg.Text = "insert Valid Discount";
                    return;
                }
            }
            else
            {
                //Cancel();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        public void Cancel()
        {
            Response.Redirect("fullsr.aspx");
            //List<TempProduct> Tlist = new List<TempProduct>();
            //FTotall.Text = "0";
            //FsubTotal.Text = "0";
            ////txtSidPoint.Text = "0";
            //txtDisPercent.Text = "0";
            ////lblPayable.Text = "0";
            ////txtcashReceived.Text = "0";
            ////lblChangeAMT.Text = "0";

            //Listview1.DataSource = Tlist;
            //Listview1.DataBind();
            //ViewState["InvoiceProd"] = null;
            //lbliitemCount.Text = "0";

        }


        protected void Listview2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            Label Prod = (Label)e.Item.FindControl("Prod");
            Label lbladdon = (Label)e.Item.FindControl("lbladdon");
            System.Web.UI.WebControls.Image lnkimg = (System.Web.UI.WebControls.Image)e.Item.FindControl("lnkimg");
            long myprodid = Convert.ToInt64(Prod.Text);
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                DataTable imgdt = DAL.Get_ProductImage(TID, int.Parse(myprodid.ToString()));
                if (imgdt.Rows.Count > 0)
                {
                    lnkimg.ImageUrl = "/ECOMM/Upload/" + imgdt.Rows[0]["PICTURE"].ToString();
                }
                else
                {
                    DataTable CompanyDt = DAL.Get_CompanyInfo(TID);
                    lnkimg.ImageUrl = CompanyDt.Rows[0]["Imageurl"].ToString();

                }
            }
            if (DB.TBLPRODUCTs.Where(p => p.TenentID == TID && p.MYPRODID == myprodid && p.Multiaddon == true).Count() > 0)
            {
                lbladdon.Visible = true;
                lbladdon.Text = "Addon";
            }
            else
            {
                lbladdon.Visible = false;
            }
        }

        protected void txtcashamount_TextChanged(object sender, EventArgs e)
        {
            if (txtcash.Text == string.Empty) { txtcash.Text = "0"; }
            decimal changeamt = Convert.ToDecimal(txtcash.Text) - Convert.ToDecimal(txtPopupPaidAmount.Text);
            txtchange.Text = changeamt.ToString();
        }

        protected void Listview1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
            if (e.CommandName == "ProdPlus")
            {
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                string[] ID = e.CommandArgument.ToString().Split('-');
                int pid = Convert.ToInt32(ID[0]);
                int uomid = Convert.ToInt32(ID[1]);  // change by dipak
                string BatchNo = ID[2].ToString();
                TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);

                decimal Onhand = Calc.OnHand;

                decimal msrp = Convert.ToDecimal(Calc.msrp);
                int QTY = Convert.ToInt32(txtQty.Text);

                QTY = QTY + 1;
                txtQty.Text = QTY.ToString();
                //decimal total = Convert.ToDecimal(msrp * QTY);
                //string SUMID = uomid.ToString();  // change by dipak
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).msrp = msrp;  
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).OpQty = QTY; 
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).Total = total;  

                //BindInvoceList(Tlist);
            }
            if (e.CommandName == "ProdMinus")
            {
                checksession();
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                string[] ID = e.CommandArgument.ToString().Split('-');
                int pid = Convert.ToInt32(ID[0]);
                int uomid = Convert.ToInt32(ID[1]);  // change by dipak
                string BatchNo = ID[2].ToString();
                TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);  // change by dipak

                decimal Onhand = Calc.OnHand;

                decimal msrp = Convert.ToDecimal(Calc.msrp);
                int QTY = Convert.ToInt32(txtQty.Text);
                QTY = QTY - 1;
                txtQty.Text = QTY.ToString();
                //decimal total = Convert.ToDecimal(msrp * QTY);
                //string SUMID = uomid.ToString();  // change by dipak
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).msrp = msrp;  // change by dipak
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).OpQty = QTY;  // change by dipak
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).Total = total;  // change by dipak

                //BindInvoceList(Tlist);
            }
            if (e.CommandName == "ProdEdit")
            {

                string[] ID = e.CommandArgument.ToString().Split('-');
                int pid = Convert.ToInt32(ID[0]);
                int uomid = Convert.ToInt32(ID[1]);  // change by dipak
                string BatchNo = ID[2].ToString();
                TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);
                string prodname = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid).product_name;
                lblimagename.Text = prodname;
                Database.ImageTable ImgPath = DB.ImageTables.Single(p => p.TenentID == TID && p.MYPRODID == pid);
                Image1.ImageUrl = "/ECOMM/Upload/" + ImgPath.PICTURE;
                Image1.ImageUrl = "";
            }


            if (e.CommandName == "ProdRemove")
            {
                int TotalRows = Listview1.Items.Count();
                if (TotalRows == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you can not delete last item , add another item than delete')", true);
                    return;
                }
                string[] ID = e.CommandArgument.ToString().Split('-');
                int pid = Convert.ToInt32(ID[0]);
                int uomid = Convert.ToInt32(ID[1]);  // change by dipak
                string BatchNo = ID[2].ToString();
                Int64 MyTrandID = Convert.ToInt64(Session["GetMYTRANSID"].ToString());
                if (Session["GetMYTRANSID"] != null)
                {
                    if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MyTrandID && p.locationID == LID && p.MyProdID == pid).Count() > 0)
                    {
                        DAL.Delete_Sales_Prod(TID, LID, pid, MyTrandID);
                    }
                }


                TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == uomid);  // change by dipak

                Tlist.Remove(Calc);
                BindInvoceList(Tlist);
            }
            if (e.CommandName == "ProdApply")
            {
                TempProduct obj = new TempProduct();
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                TextBox txtcomments = (TextBox)e.Item.FindControl("txtcomments");
                TextBox txtpricepopup = (TextBox)e.Item.FindControl("txtpricepopup");
                if (decimal.Parse(txtpricepopup.Text) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product price can not be zero')", true);
                    return;
                }
                Label Prodcart = (Label)e.Item.FindControl("Prodcart");
                bool flag = false;
                ListView Listaddon = (ListView)e.Item.FindControl("Listaddon");
                for (int i = 0; i < Listaddon.Items.Count; i++)
                {
                    CheckBox chkitemcheck = (CheckBox)Listaddon.Items[i].FindControl("chkitemcheck");
                    if (chkitemcheck.Checked)
                    {
                        flag = true;
                        break;
                    }

                }

                for (int i = 0; i < Listaddon.Items.Count; i++)
                {

                    CheckBox chkitemcheck = (CheckBox)Listaddon.Items[i].FindControl("chkitemcheck");

                    if (chkitemcheck.Checked == true)
                    {
                        Label lbladdonid = (Label)Listaddon.Items[i].FindControl("lbladdonid");

                        int Id = Convert.ToInt32(lbladdonid.Text);
                        DataTable purobj = DAL.Get_Item_View_Product(TID, LID, Id);// DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Id);
                        int UMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString());
                        Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
                        if (Tlist.Where(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).Count() > 0)
                        {
                            decimal qty = Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).OpQty); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                            int PID = int.Parse(purobj.Rows[0]["MYPRODID"].ToString());
                            CalcDirectProd(PID, UMID);
                        }
                        else
                        {
                            //  Tlistinvoice2 = ((List<TempProduct>)ViewState["Listinvoice2"]).ToList();
                            obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                            obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"]);
                            obj.UOMID = Convert.ToInt32(purobj.Rows[0]["UOM"]); // change by dipak
                            obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                                                                                                                                                                                                  //obj.Shopid = purobj.Shopid;
                            obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                            obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                            obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                            obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                            obj.supplier = purobj.Rows[0]["Option1"].ToString();
                            obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                            //obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                            obj.price = Convert.ToDecimal(purobj.Rows[0]["price"]);//price
                            obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"]);//total
                            obj.OpQty = Convert.ToInt32(1);//qty
                            obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"]);
                            obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"]);
                            obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"]);
                            decimal qtys = Convert.ToInt32(1);//qty

                            decimal Diss = Convert.ToDecimal(0);//yogesh
                            decimal msrps = (Convert.ToDecimal(purobj.Rows[0]["msrp"]) * qtys);//total
                            decimal Fdiss = ((msrps * Diss) / 100);
                            decimal price = Convert.ToDecimal(purobj.Rows[0]["price"]);
                            obj.Total = (msrps);
                            obj.Discount = Math.Round(Fdiss, 3);
                            obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                            obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                            obj.BatchNo = "1";
                            decimal total = Convert.ToDecimal(obj.price * qtys);
                            obj.Remarks = txtcomments.Text;
                            Tlist.Add(obj);
                        }
                    }
                    ViewState["InvoiceProd"] = Tlist;
                }




                Listview1.DataSource = Tlist; //TempListICTR_DT123;
                Listview1.DataBind();
                int pid = Convert.ToInt32(Prodcart.Text);
                //int uomid = 1;  // change by dipak

                //TempProduct Calc = Tlist.Single(p => p.Tenent == TID && p.product_id == pid );

                //int Onhand = Calc.OnHand;
                decimal msrpparameter = Convert.ToDecimal(txtpricepopup.Text);
                //int QTY = Convert.ToInt32(Calc.OpQty);
                decimal QTYParameter = Convert.ToDecimal(txtQty.Text);
                string comments = txtcomments.Text;
                decimal prices = Convert.ToDecimal(txtpricepopup.Text);
                //decimal total = Convert.ToDecimal(prices * QTY);
                //string SUMID = uomid.ToString();  // change by dipak
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid ).msrp = msrp;
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid).OpQty = QTY;
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid).Total = total;
                //Tlist.Single(p => p.Tenent == TID && p.product_id == pid).price = prices;
                //Database.TBLPRODUCT objprod = DB.TBLPRODUCTs.Single(p => p.TenentID == TID && p.MYPRODID == pid);
                //objprod.price = Convert.ToDecimal(txtpricepopup.Text);
                // objprod.msrp = Convert.ToDecimal(txtpricepopup.Text);
                DataTable OBJLOCAL = DAL.Get_Item_View_Product(TID, LID, pid);// DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Id);
                int UMID1 = Convert.ToInt32(OBJLOCAL.Rows[0]["UOM"].ToString());
                if (Tlist.Where(p => p.Tenent == TID && p.product_id == pid && p.UOMID == UMID1).Count() > 0) // change by dipak
                {
                    decimal qty = QTYParameter; Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == UMID1).OpQty); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                    decimal Nmrsp = msrpparameter;

                    // Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == pid && p.UOMID == UMID1).msrp); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                    int PID = Convert.ToInt32(pid);
                    CalcDirectProd1(PID, UMID1, qty, Nmrsp, comments);  // change by dipak
                }
                DB.SaveChanges();
                BindInvoceList(Tlist);
            }
        }

        protected void Listview1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            Label Prod = (Label)e.Item.FindControl("Prodcart");
            ListView Listaddon = (ListView)e.Item.FindControl("Listaddon");
            System.Web.UI.WebControls.Image ilnkimg = (System.Web.UI.WebControls.Image)e.Item.FindControl("ilnkimg");
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                long myprodid = Convert.ToInt64(Prod.Text);
                if (DB.ImageTables.Where(p => p.TenentID == TID && p.MYPRODID == myprodid).Count() > 0)
                {
                    Database.ImageTable ImgPath = DB.ImageTables.Single(p => p.TenentID == TID && p.MYPRODID == myprodid);
                    ilnkimg.ImageUrl = "/ECOMM/Upload/" + ImgPath.PICTURE;
                }
                else
                {
                    DataTable CompanyDt = DAL.Get_CompanyInfo(TID);
                    ilnkimg.ImageUrl = CompanyDt.Rows[0]["Imageurl"].ToString();

                }
            }
            int PID = Convert.ToInt32(Prod.Text);

            Listaddon.DataSource = DB.Tbl_Multi_Color_Size_Mst.Where(p => p.TenentID == TID && p.CompniyAndContactID == PID && p.RecordType == "MultiAddon");
            Listaddon.DataBind();
        }


        [WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCustomer(string prefixText, int count)
        {

            int TID = Convert.ToInt32(((USER_MST)HttpContext.Current.Session["USER"]).TenentID);
            string conStr;
            conStr = WebConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString;
            //string sqlQuery = "SELECT [Name]+' - '+ [Phone]+' - '+ [EmailAddress],[ID] FROM [Win_tbl_customer] WHERE TenentID='" + TID + "' and PeopleType='Customer' and (Name like '%' + @COMPNAME  + '%' or EmailAddress like '%' + @COMPNAME  + '%' or Phone like '%' + @COMPNAME  + '%')";
            string sqlQuery = "SELECT [COMPNAME1]+' - '+MOBPHONE,[COMPID] FROM [TBLCOMPANYSETUP] WHERE TenentID='" + TID + "' and BUYER = 'true' and Active = 'Y' and (COMPNAME1 like @COMPNAME  + '%' or COMPNAME2 like @COMPNAME  + '%' or COMPNAME3 like @COMPNAME  + '%' or MOBPHONE like @COMPNAME  + '%')";
            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.AddWithValue("@COMPNAME", prefixText);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> custList = new List<string>();
            string custItem = string.Empty;
            while (dr.Read())
            {
                custItem = AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[1].ToString());
                custList.Add(custItem);
            }
            conn.Close();
            dr.Close();
            return custList.ToArray();
        }

        public string getprodnameui(int SID)
        {
            if (DB.TBLPRODUCTs.Where(p => p.MYPRODID == SID && p.TenentID == TID).Count() > 0)
            {
                string ProductCode = DB.TBLPRODUCTs.Single(p => p.MYPRODID == SID && p.TenentID == TID).UserProdID;
                return ProductCode;
            }
            else
            {
                return "Record Not Found";
            }

        }


        protected void btnorder_Click(object sender, EventArgs e)
        {

            int TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID1 = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            if (DAL.CheckForCustomerSetting(TID1, UID1))
            {
                if (txtcustomer.Text.ToUpper() == "CASH" || txtcustomer.Text == "")
                {
                    // ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Customer Must be Required...');", true);
                    // txtcustomer.Focus();
                    // return;
                    Session["btnname"] = "order";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#listcustomer').modal();});", true);
                    return;
                }
            }
            if (Session["GetMYTRANSID"] != null)
            {
                checksession();
                TransNo = Convert.ToInt32(Session["Invoice"]);
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

                int InvoiceID = 0;

                Int64 MTID = 0;
                if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
                {
                    MTID = Convert.ToInt32(Session["GetMYTRANSID"]);

                }
                else
                {
                    MTID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);//
                }
                List<Database.ICTR_DT_Sales> listTempDt = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID).ToList();

                string PrintURL = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103).InvoicePrintURL;
                FinalConfirm();
                Session["GetMYTRANSID"] = null;
                //// Response.Redirect("LocalInvoice.aspx?Tranjestion=" + TransNo);
                FTotall.Text = txtPopupPaidAmount.Text = lblPopupPaidAmount.Text = "0";
                txtchangepaidamount.Text = "0";
                txtcpaidamount.Text = "0";
                bintlist();


            }
        }

        protected void btnorderKNET_Click(object sender, EventArgs e)
        {

            int TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID1 = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            if (DAL.CheckForCustomerSetting(TID1, UID1))
            {
                if (txtcustomer.Text.ToUpper() == "CASH" || txtcustomer.Text == "")
                {
                    // ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Customer Must be Required...');", true);
                    // txtcustomer.Focus();
                    // return;
                    Session["btnname"] = "order";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#listcustomer').modal();});", true);
                    return;
                }
            }
            if (Session["GetMYTRANSID"] != null)
            {
                checksession();
                TransNo = Convert.ToInt32(Session["Invoice"]);
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int InvoiceID = 0;
                Int64 MTID = 0;
                if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
                {
                    MTID = Convert.ToInt32(Session["GetMYTRANSID"]);
                }
                else
                {
                    MTID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);//
                }
                List<Database.ICTR_DT_Sales> listTempDt = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID).ToList();

                string PrintURL = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103).InvoicePrintURL;
                FinalConfirmKNET();
                Session["GetMYTRANSID"] = null;
                //// Response.Redirect("LocalInvoice.aspx?Tranjestion=" + TransNo);
                FTotall.Text = txtPopupPaidAmount.Text = lblPopupPaidAmount.Text = "0";
                txtchangepaidamount.Text = "0";
                txtcpaidamount.Text = "0";
                bintlist();


            }
        }

        public void bintlist()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            ViewState["InvoiceProd"] = null;
            Session["InvoiceProd"] = null;
            List<TempProduct> Tlist = new List<TempProduct>();
            List<TempProduct> TlistInvoice1 = new List<TempProduct>();
            ViewState["InvoiceProd"] = Tlist;
            Listview1.DataSource = Tlist; //TempListICTR_DT123;
            Listview1.DataBind();
            int InvoiceID = 0;
            Int64 MYTRANSID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);// DB.ICTR_HD_Sales.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;
            Session["GetMYTRANSID"] = MYTRANSID;
            lblinvoice.Text = "Inv" + MYTRANSID;
            lbliitemCount.Text = "(" + Listview1.Items.Count.ToString() + ")";
            FTotall.Text = "0.00";
            FsubTotal.Text = "0.00";
            lblDiscount.Text = "0.00";
            txtDisPercent.Text = "0.00";
            txtcustomer.Text = "Cash";
            lblDiscount.Text = "0.00";
            ChIsCredit.Checked = false;
        }
        public int Pidalcode(DateTime Time)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int PODID = 0;
            var TBLPERIODS = DB.TBLPERIODS.Where(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.MYSYSNAME == "SAL" && p.TenentID == TID).ToList();
            if (TBLPERIODS.Count() > 0)
                PODID = Convert.ToInt32(TBLPERIODS.Single(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.MYSYSNAME == "SAL" && p.TenentID == TID).PERIOD_CODE);
            return PODID;
        }

        public decimal getConversionBaseQty(int Fuom, int Tuom, decimal qty)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.ICUOMCONVs.Where(p => p.TenentID == TID && p.FUOM == Fuom && p.TUOM == Tuom).Count() > 0)
            {
                Database.ICUOMCONV obj = DB.ICUOMCONVs.Single(p => p.TenentID == TID && p.FUOM == Fuom && p.TUOM == Tuom);
                decimal Conv = Convert.ToDecimal(obj.ConvRatio);
                decimal quantity = qty * Conv;
                quantity = Math.Round(quantity, 3);
                return quantity;
            }
            return qty;
        }

        public decimal getConversionToQty(int Fuom, int Tuom, decimal qty)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.ICUOMCONVs.Where(p => p.TenentID == TID && p.FUOM == Fuom && p.TUOM == Tuom).Count() > 0)
            {
                Database.ICUOMCONV obj = DB.ICUOMCONVs.Single(p => p.TenentID == TID && p.FUOM == Fuom && p.TUOM == Tuom);
                decimal Conv = Convert.ToDecimal(obj.CONVERSION);
                decimal quantity = qty * Conv;
                quantity = Math.Round(quantity, 3);
                return quantity;
            }
            return qty;
        }

        int TransNo = 0;

        public int GetSalesID(string InvoiceNO)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            string sql3 = "select * from ICTR_HD_Sales where TenentID=" + TID + " and InvoiceNO='" + InvoiceNO + "' ";
            DataTable dt3 = DataCon.GetDataTable(sql3);
            int Mytransid = 0;
            if (dt3.Rows.Count > 0)
            {
                Mytransid = Convert.ToInt32(dt3.Rows[0]["sales_id"]);
            }
            else
            {
                Mytransid = 0;
            }
            return Mytransid;
        }
        public void FinalConfirm()
        {

            if (ViewState["InvoiceProd"] == null)
                return;
            checksession();
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int InvoiceID = 0;
            Int64 MTID = 0;
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                MTID = Convert.ToInt32(Session["GetMYTRANSID"]);
                if (Session["GetMYTRANSID"] != null)
                {
                    List<Database.ICTR_DT_Sales> Tlistw = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == MTID).ToList();

                    foreach (Database.ICTR_DT_Sales items in Tlistw)
                    {
                        int prodid = int.Parse(items.MyProdID.ToString());
                        if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID && p.MyProdID == prodid).Count() > 0)
                        {
                            DAL.Reverse_InvoiceQt(TID, LID, prodid, MTID);
                        }
                    }

                }
            }
            else
            {
                MTID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);//
            }
            //  List<Database.ICTR_DT_Sales> listTempDt = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID).ToList();

            //List<Database.ICTRPayTerms_HD> listicpayHD = DB.ICTRPayTerms_HD.Where(p => p.TenentID == TID && p.MyTransID == MTID).ToList();
            /// int LID = 1;//Convert.ToInt32(((POSLocSetup)Session["POSLocSetup"]).LocationID);
            /// sahir reverse
            //int terminal = Convert.ToInt32(((POSTermSetup)Session["POSTermSetup"]).LocationID);
            int COMPID = 0;
            string Status = "";
            string UseID = "ponline";//((USER_MST)Session["USER"]).LOGIN_ID;
            DateTime TACtionDate = DateTime.Now;
            string OICODID = Pidalcode(TACtionDate).ToString();
            if (DB.TBLCOMPANYSETUPs.Where(p => p.USERID == UseID && p.TenentID == TID).Count() == 1)
                COMPID = DB.TBLCOMPANYSETUPs.Single(p => p.USERID == UseID && p.TenentID == TID).COMPID;

            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

            List<SalesItemList> ListSend = new List<SalesItemList>();
            foreach (TempProduct item in Tlist)
            {
                SalesItemList Obj = new SalesItemList();
                Obj.Items_Name = item.product_name;
                Obj.UOMNAME = item.UOMNAME; // change by dipak to UOM
                Obj.UOMID = item.UOMID; // change by dipak to UOM
                decimal Price = item.msrp;
                Obj.Price = Price;
                Obj.Qty = Convert.ToDecimal(item.OpQty);
                decimal Total = Convert.ToInt32(item.Total);
                Total = Math.Round(Total, 3);
                Obj.Total = Total;
                Obj.itemID = item.product_id.ToString();
                Obj.CustItemCode = item.CustItemCode;
                Obj.Remarks = item.Remarks;

                ListSend.Add(Obj);
            }
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
            CashSave2 sendObj1 = new CashSave2();
            string invoice = "INV" + MTID;
            sendObj1.TenentID = TID;
            sendObj1.LID = LID;
            sendObj1.MYTRANSID = MTID;
            sendObj1.DESCRIPTION = txtcustomer.Text;
            sendObj1.Userid = UID;
            sendObj1.UserName = name;
            sendObj1.DID = Convert.ToInt32(Session["ID"]);
            sendObj1.Invoice = invoice;

            string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
            if (ChIsCredit.Checked == true)
            {
                sendObj1.PaymentMode = "Credit";
                sendObj1.PaymentStatus = "Credit";
                sendObj1.OrderStatus = "New";
                sendObj1.DeliveryStatus = "Processed";

            }
            else
            {
                sendObj1.PaymentMode = "Cash";
                sendObj1.PaymentStatus = "Cash";
                sendObj1.OrderStatus = "New";
                sendObj1.DeliveryStatus = "Under the Process";
            }
            if (Customer.Contains('-'))
            {
                Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
            }
            sendObj1.Customer = Customer;

            sendObj1.Orderway = BtnOrdertypeMain.Text;
            int C_id = HiddenField3.Value != null && HiddenField3.Value != "" ? Convert.ToInt32(HiddenField3.Value) : 1;
            sendObj1.CustomerID = C_id != 0 ? C_id : 1;

            decimal Predis = Convert.ToDecimal(lblDiscount.Text);
            decimal Invoidis = Convert.ToDecimal(lblDiscount.Text);
            decimal Fdis = Predis + Invoidis;

            sendObj1.DiscountTotaloverall = lblDiscount.Text.ToString();
            sendObj1.overalldisRate = lblDiscount.Text != "" ? lblDiscount.Text : "0";
            sendObj1.Delivery_Cahrge = txtdeliverycharges.Text;  //lblDelivery.Text != "" ? lblDelivery.Text : "0";
            sendObj1.DiscountAmt = lblDiscount.Text.ToString();
            sendObj1.TotalPayable = Convert.ToDecimal(FTotall.Text);

            if (txtCashRecived.Text != null && txtCashRecived.Text != "")
            {
                sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);
            }
            sendObj1.ChangeAmount = Convert.ToDecimal(txtbalance.Text);

            sendObj1.dgrvSalesItemList = ListSend;
            fullConfirmnew(sendObj1);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Add("Authentication", bearerToken);
            //    HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/fullConfirmnew", sendObj1).Result;
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();

            //        //Response.Redirect("LocalInvoice.aspx?Tranjestion=" + mytransid);


            //        // Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //    }
            //    else
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();
            //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('" + MSg + "');", true);
            //    }
            //}
            Int64 mytransid = MTID; //GetSalesID(MSg);
            decimal total = Convert.ToDecimal(FTotall.Text);
            //  CurrencyConversion("KWD", "USD");
            //
            Session["GetMYTRANSID"] = null;
            bintlist();
            ViewState["GridPayment"] = null;
            GridPayment.DataSource = null;
            GridPayment.Items.Clear();
            GridPayment.DataBind();
            txtPopupPaidAmount.Text = "0.000";
            txtchangepaidamount.Text = "";
            txtcpaidamount.Text = "";
            txtchangecashamount.Text = "";
            txtchangechangeamount.Text = "";
            txtchange.Text = "";
            txtcash.Text = "";
            txtPayReffrance.Text = "";
            lblPaid.Text = "";
            lblPopupPaidAmount.Text = "";
            UpdatePanel3.Update();
            GridPayment.DataSource = null;
            GridPayment.DataBind();
            printInv(MTID);

            //if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            //{
            //    Cancel();
            //}
        }
        public void FinalConfirmKNET()
        {

            if (ViewState["InvoiceProd"] == null)
                return;
            checksession();
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int InvoiceID = 0;
            Int64 MTID = 0;
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                MTID = Convert.ToInt32(Session["GetMYTRANSID"]);
            }
            else
            {
                MTID = DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID);//
            }
            List<Database.ICTR_DT_Sales> listTempDt = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID).ToList();

            //List<Database.ICTRPayTerms_HD> listicpayHD = DB.ICTRPayTerms_HD.Where(p => p.TenentID == TID && p.MyTransID == MTID).ToList();
            /// int LID = 1;//Convert.ToInt32(((POSLocSetup)Session["POSLocSetup"]).LocationID);
            /// sahir reverse
            //int terminal = Convert.ToInt32(((POSTermSetup)Session["POSTermSetup"]).LocationID);
            int COMPID = 0;
            string Status = "";
            string UseID = "ponline";//((USER_MST)Session["USER"]).LOGIN_ID;
            DateTime TACtionDate = DateTime.Now;
            string OICODID = Pidalcode(TACtionDate).ToString();
            if (DB.TBLCOMPANYSETUPs.Where(p => p.USERID == UseID && p.TenentID == TID).Count() == 1)
                COMPID = DB.TBLCOMPANYSETUPs.Single(p => p.USERID == UseID && p.TenentID == TID).COMPID;

            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

            List<SalesItemList> ListSend = new List<SalesItemList>();
            foreach (TempProduct item in Tlist)
            {
                SalesItemList Obj = new SalesItemList();
                Obj.Items_Name = item.product_name;
                Obj.UOMNAME = item.UOMNAME; // change by dipak to UOM
                Obj.UOMID = item.UOMID; // change by dipak to UOM
                decimal Price = item.msrp;
                Obj.Price = Price;
                Obj.Qty = Convert.ToDecimal(item.OpQty);
                decimal Total = Convert.ToInt32(item.Total);
                Total = Math.Round(Total, 3);
                Obj.Total = Total;
                Obj.itemID = item.product_id.ToString();
                Obj.CustItemCode = item.CustItemCode;
                Obj.Remarks = item.Remarks;

                ListSend.Add(Obj);
            }
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
            CashSave2 sendObj1 = new CashSave2();
            string invoice = "INV" + MTID;
            sendObj1.TenentID = TID;
            sendObj1.LID = LID;
            sendObj1.MYTRANSID = MTID;
            sendObj1.DESCRIPTION = txtcustomer.Text;
            sendObj1.Userid = UID;
            sendObj1.UserName = name;
            sendObj1.DID = Convert.ToInt32(Session["ID"]);
            sendObj1.Invoice = invoice;

            string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
            if (ChIsCredit.Checked == true)
            {
                sendObj1.PaymentMode = "Credit";
                sendObj1.PaymentStatus = "Credit";
                sendObj1.OrderStatus = "New";
                sendObj1.DeliveryStatus = "Processed";

            }
            else
            {
                sendObj1.PaymentMode = "Knet";
                sendObj1.PaymentStatus = "Knet";
                sendObj1.OrderStatus = "New";
                sendObj1.DeliveryStatus = "Under the Process";
            }
            if (Customer.Contains('-'))
            {
                Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
            }
            sendObj1.Customer = Customer;

            sendObj1.Orderway = BtnOrdertypeMain.Text;
            int C_id = HiddenField3.Value != null && HiddenField3.Value != "" ? Convert.ToInt32(HiddenField3.Value) : 1;
            sendObj1.CustomerID = C_id != 0 ? C_id : 1;

            decimal Predis = Convert.ToDecimal(lblDiscount.Text);
            decimal Invoidis = Convert.ToDecimal(lblDiscount.Text);
            decimal Fdis = Predis + Invoidis;

            sendObj1.DiscountTotaloverall = lblDiscount.Text.ToString();
            sendObj1.overalldisRate = lblDiscount.Text != "" ? lblDiscount.Text : "0";
            sendObj1.Delivery_Cahrge = txtdeliverycharges.Text; //lblDelivery.Text != "" ? lblDelivery.Text : "0";
            sendObj1.DiscountAmt = lblDiscount.Text.ToString();
            sendObj1.TotalPayable = Convert.ToDecimal(FTotall.Text);

            if (txtCashRecived.Text != null && txtCashRecived.Text != "")
            {
                sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);
            }
            sendObj1.ChangeAmount = Convert.ToDecimal(txtbalance.Text);

            sendObj1.dgrvSalesItemList = ListSend;
            fullConfirmnew(sendObj1);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Add("Authentication", bearerToken);
            //    HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/fullConfirmnew", sendObj1).Result;
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();

            //        //Response.Redirect("LocalInvoice.aspx?Tranjestion=" + mytransid);


            //        // Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //    }
            //    else
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();
            //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('" + MSg + "');", true);
            //    }
            //}
            Int64 mytransid = MTID; //GetSalesID(MSg);
            decimal total = Convert.ToDecimal(FTotall.Text);
            //  CurrencyConversion("KWD", "USD");
            //
            Session["GetMYTRANSID"] = null;
            bintlist();
            ViewState["GridPayment"] = null;
            GridPayment.DataSource = null;
            GridPayment.Items.Clear();
            GridPayment.DataBind();
            txtPopupPaidAmount.Text = "0.000";
            txtchangepaidamount.Text = "";
            txtcpaidamount.Text = "";
            txtchangecashamount.Text = "";
            txtchangechangeamount.Text = "";
            txtchange.Text = "";
            txtcash.Text = "";
            txtPayReffrance.Text = "";
            lblPaid.Text = "";
            lblPopupPaidAmount.Text = "";
            UpdatePanel3.Update();
            GridPayment.DataSource = null;
            GridPayment.DataBind();
            printInv(MTID);

            //if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            //{
            //    Cancel();
            //}
        }

        public string CurrencyConversion(string From, string To)
        {
            string url = string.Format("https://free.currconv.com/api/v7/convert?q={0}_{1}&compact=ultra&apiKey=639cb8721c1ab74345bf", From, To);
            WebClient client = new WebClient();
            string rates = client.DownloadString(url);
            dynamic data = JObject.Parse(rates);
            string dt = From + "_" + To;
            string finalTotal = "";
            if (dt == "KWD_USD")
                finalTotal = data.KWD_USD;
            else if (dt == "USD_KWD")
                finalTotal = data.USD_KWD;
            decimal FT = Convert.ToDecimal(finalTotal);
            decimal ltotal = Convert.ToDecimal(FTotall.Text);
            decimal total = ltotal * FT;
            Session["total"] = total;
            return "";
        }
        public void BindHD(int MYTRANSID)
        {


        }

        protected void btnSelectCustomer_Click(object sender, System.EventArgs e)
        {


        }

        public void deletetemp()
        {
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                checksession();
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int MYTID = Convert.ToInt32(Request.QueryString["MytransID"]);
                Database.ICTR_HD_Sales_tmp objdet = DB.ICTR_HD_Sales_tmp.Single(p => p.TenentID == TID && p.MYTRANSID == MYTID);
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
        }

        protected void btndraft_Click(object sender, System.EventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                deletetemp();
                int MYTID = Convert.ToInt32(Request.QueryString["MytransID"]);
                int mytransid = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 2) : 1; ; ;
                if (mytransid == 1)
                {
                    mytransid = mytransid + 1;//DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID)) : 1; ; ;
                }
                List<TempProduct> Tlist1 = (List<TempProduct>)ViewState["InvoiceProd"];
                //int Mytransid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;
                foreach (TempProduct item in Tlist1)
                {
                    // int TID = TID;
                    int location = 1;
                    int terminal = 1;
                    int Myid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == mytransid).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == mytransid).Max(p => p.MYID) + 1) : 1; ;
                    int PrID = item.product_id;
                    string Reftype = "POS";
                    string PERIOD_CODE = "POS";
                    string MYSYSNAME = "SAL";

                    string RefSubtype = "POS";
                    string mysys = "PUR";
                    string prname = item.product_name;
                    string UOM = "99999";
                    decimal qty = item.OpQty;
                    decimal price = item.price;
                    decimal amount = price * qty;
                    string GLPOST = "2";
                    string GLPOST1 = "2";
                    string GLPOSTREF = "2";
                    string GLPOSTREF1 = "2";
                    string ICPOST = "2";
                    string ICPOSTREF = "2";
                    int CountryID = 36;
                    int QuantityDelivered = 0;
                    int Amount = 500;
                    string DeliveredLocaTenantID = null;
                    string AmountDelivered = null;
                    string DeliveryRef = "DeliverRef";
                    string UserBatch = "123";
                    string maintranstype = "ACT";
                    string TransType = "PaymentVoucher";
                    decimal OVERHEADAMOUNT = 1;
                    string BATCHNO = "1";
                    int ToTenentID = 9000052;
                    int TOLOCATIONID = 1;
                    string MainTranType = "O";
                    string TranType = "POS Invoice";
                    int transid = 4101;
                    int transsubid = 410103;
                    decimal COMPID = 1;
                    // decimal CUSTVENDID = 1;
                    string LF = "L";
                    string ACTIVITYCODE = "1";
                    decimal MYDOCNO = 1;
                    string USERBATCHNO = "1";
                    decimal TOTQTY1 = item.OpQty;
                    decimal TOTAMT = Convert.ToDecimal(FTotall.Text);
                    decimal AmtPaid = 1;
                    string PROJECTNO = "1";
                    string CounterID = "1";
                    string PrintedCounterInvoiceNo = "1";
                    int JOID = 1;
                    DateTime TRANSDATE = DateTime.Now;
                    string REFERENCE = "POS";
                    string NOTES = "POS";
                    int CRUP_ID = 1;
                    string USERID = ((USER_MST)Session["USER"]).USER_ID.ToString();
                    int COMPANYID = 0;
                    DateTime ENTRYDATE = DateTime.Now;
                    DateTime ENTRYTIME = DateTime.Now;
                    DateTime UPDTTIME = DateTime.Now;
                    string InvoiceNO = "0";
                    decimal Discount = 1;
                    string Status = null;
                    int Terms = 0;
                    string Custmerid = null;
                    string Swit1 = null;
                    string ExtraField2 = null;
                    int RefTransID = 0;
                    string Reason = null;
                    string TransDocNo = null;
                    int LinkTransID = MYTID;
                    int invoice_Type = 0;
                    int invoice_Source = 0;
                    string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                    if (Customer.Contains('-'))
                    {
                        Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                    }
                    int CID = Convert.ToInt32(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == Customer).COMPID);
                    decimal CUSTVENDID = Convert.ToInt32(CID);

                    Classes.EcommAdminClass.insert_ICTR_DT_Sales_tmp(TID, mytransid, LID, Myid, PrID, Reftype, RefSubtype, PERIOD_CODE, MYSYSNAME, 1, 1, 1, prname, UOM, qty, price, amount, OVERHEADAMOUNT, BATCHNO, 1, "1", "1", 1, 1, LinkTransID, 1, 1, 1, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, true, "1", 1, 1, "1", "");
                    if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == mytransid).Count() < 1)
                    {
                        Classes.EcommAdminClass.insert_ICTR_HD_Sales_tmp(TID, mytransid, ToTenentID, TOLOCATIONID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, "1", ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY1, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, true, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                    }

                }

            }

            else
            {
                if (ViewState["InvoiceProd"] == null)
                    return;
                int Mytransid = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1; ; ;
                List<TempProduct> Tlist1 = (List<TempProduct>)ViewState["InvoiceProd"];
                //int Mytransid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;

                foreach (TempProduct item in Tlist1)
                {

                    int location = 1;
                    int terminal = 1;
                    int Myid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Max(p => p.MYID) + 1) : 1; ;
                    int PrID = item.product_id;
                    string Reftype = "POS";
                    string PERIOD_CODE = "POS";
                    string MYSYSNAME = "SAL";

                    string RefSubtype = "POS";
                    string mysys = "PUR";
                    string prname = item.product_name;
                    string UOM = "99999";
                    decimal qty = item.OpQty;
                    decimal price = item.price;
                    decimal amount = price * qty;
                    string GLPOST = "2";
                    string GLPOST1 = "2";
                    string GLPOSTREF = "2";
                    string GLPOSTREF1 = "2";
                    string ICPOST = "2";
                    string ICPOSTREF = "2";
                    int CountryID = 36;
                    int QuantityDelivered = 0;
                    int Amount = 500;
                    string DeliveredLocaTenantID = null;
                    string AmountDelivered = null;
                    string DeliveryRef = "DeliverRef";
                    string UserBatch = "123";
                    string maintranstype = "ACT";
                    string TransType = "PaymentVoucher";
                    decimal OVERHEADAMOUNT = 1;
                    string BATCHNO = "1";
                    int ToTenentID = Convert.ToInt32(Session["TID"]); ;
                    int TOLOCATIONID = 1;
                    string MainTranType = "O";
                    string TranType = "POS Invoice";
                    int transid = 4101;
                    int transsubid = 410103;
                    decimal COMPID = 1;
                    // decimal CUSTVENDID = 1;
                    string LF = "L";
                    string ACTIVITYCODE = "1";
                    decimal MYDOCNO = 1;
                    string USERBATCHNO = "1";
                    decimal TOTQTY1 = item.OpQty;
                    decimal TOTAMT = Convert.ToDecimal(FTotall.Text);
                    decimal AmtPaid = 1;
                    string PROJECTNO = "1";
                    string CounterID = "1";
                    string PrintedCounterInvoiceNo = "1";
                    int JOID = 1;
                    DateTime TRANSDATE = DateTime.Now;
                    string REFERENCE = "POS";
                    string NOTES = "POS";
                    int CRUP_ID = 1;
                    string USERID = ((USER_MST)Session["USER"]).USER_ID.ToString();
                    int COMPANYID = 0;
                    DateTime ENTRYDATE = DateTime.Now;
                    DateTime ENTRYTIME = DateTime.Now;
                    DateTime UPDTTIME = DateTime.Now;
                    string InvoiceNO = "0";
                    decimal Discount = 1;
                    string Status = null;
                    int Terms = 0;
                    string Custmerid = null;
                    string Swit1 = null;
                    string ExtraField2 = null;
                    int RefTransID = 0;
                    string Reason = null;
                    string TransDocNo = null;
                    int LinkTransID = 0;
                    int invoice_Type = 0;
                    int invoice_Source = 0;
                    string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                    if (Customer.Contains('-'))
                    {
                        Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                    }
                    int CID = Convert.ToInt32(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == Customer).COMPID);
                    decimal CUSTVENDID = Convert.ToInt32(CID); //Convert.ToInt32(HiddenField3.Value);


                    Classes.EcommAdminClass.insert_ICTR_DT_Sales_tmp(TID, Mytransid, LID, Myid, PrID, Reftype, RefSubtype, PERIOD_CODE, MYSYSNAME, 1, 1, 1, prname, UOM, qty, price, amount, OVERHEADAMOUNT, BATCHNO, 1, "1", "1", 1, 1, 1, 1, 1, 1, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, true, "1", 1, 1, "1", "");
                    if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Count() < 1)
                    {
                        Classes.EcommAdminClass.insert_ICTR_HD_Sales_tmp(TID, Mytransid, ToTenentID, TOLOCATIONID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, "1", ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY1, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, true, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                    }
                }
            }
            Cancel();
            Response.Redirect("Fullsr.aspx");

        }
        protected void BtnSearchitem_Click(object sender, System.EventArgs e)
        {
            if (txtItemSearch.Text != "")
            {
                checksession();
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                string SearchStr = txtItemSearch.Text;
                DataTable itemdt = DAL.Get_Item_View(TID, LID, SearchStr); // DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && (p.CAT_NAME1.Contains(SearchStr) || p.ProdName1.Contains(SearchStr) || p.BarCode.Contains(SearchStr)));// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();

                if (itemdt.Rows.Count == 1)
                {
                    int Prodid = int.Parse(itemdt.Rows[0]["MYPRODID"].ToString());
                    DataTable purobj = DAL.Get_Item_View_Product(TID, LID, Prodid);// DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Prodid);
                    int UMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString());

                    TempProduct obj = new TempProduct();
                    if (ViewState["InvoiceProd"] == null)
                    {
                        obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                        obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                        obj.UOMID = Convert.ToInt32(UMID);
                        obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                        obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                        obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                        obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                        obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                        obj.supplier = purobj.Rows[0]["Option1"].ToString();
                        obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                        //obj.status = Convert.ToInt32(purobj.Rows[0]["Option1"].ToString());//yogesh
                        obj.price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                        obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                        obj.OpQty = Convert.ToInt32(1);//qty
                        obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"].ToString());
                        obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"].ToString());
                        obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"].ToString());
                        obj.RowTotal = Convert.ToDecimal(purobj.Rows[0]["RowTotal"].ToString());
                        //if(Tlist.Where(p => p.Tenent == TID && p.product_id == purobj.MYPRODID).Count() > 0)
                        //{
                        //    decimal qty = Convert.ToInt32(1);
                        //}
                        decimal qty = Convert.ToInt32(1);//qty
                        decimal Dis = Convert.ToDecimal(0);//yogesh
                        decimal msrp = (Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString()) * qty);//total
                        decimal Fdis = ((msrp * Dis) / 100);
                        decimal price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());
                        obj.Total = (msrp);
                        obj.Discount = Math.Round(Fdis, 3);
                        obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                        obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                        obj.Remarks = "";
                        obj.BatchNo = "1";

                        Tlist.Add(obj);

                    }
                    else
                    {
                        Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();
                        if (Tlist.Where(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).Count() > 0) // change by dipak
                        {
                            decimal qty = Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).OpQty); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                            int PID = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                            CalcDirectProd(PID, UMID);  // change by dipak
                        }
                        else
                        {
                            obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                            obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"].ToString());
                            obj.UOMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString()); // change by dipak
                            obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                                                                                                                                                                                                  //obj.Shopid = purobj.Shopid;
                            obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                            obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                            obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                            obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                            obj.supplier = purobj.Rows[0]["Option1"].ToString();
                            obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                            //obj.status = Convert.ToInt32(purobj.Rows[0]["Option2"].ToString());//yogesh
                            obj.price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                            obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                            obj.OpQty = Convert.ToInt32(1);//qty
                            obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"].ToString());
                            obj.QtyOut = Convert.ToInt32(purobj.Rows[0]["QTYSOLD"].ToString());
                            obj.QtyRecived = Convert.ToInt32(purobj.Rows[0]["QTYRCVD"].ToString());
                            obj.RowTotal = Convert.ToDecimal(purobj.Rows[0]["RowTotal"].ToString());
                            obj.OpQty = Convert.ToInt32(1);//qty

                            decimal qtys = Convert.ToInt32(1);//qty
                            decimal Diss = Convert.ToDecimal(0);//yogesh
                            decimal msrps = Convert.ToDecimal(purobj.Rows[0]["msrp"].ToString());//total
                            decimal Fdiss = ((msrps * Diss) / 100);
                            decimal price = Convert.ToDecimal(purobj.Rows[0]["price"].ToString());//price
                            obj.Total = (msrps);
                            obj.Discount = Math.Round(Fdiss, 3);
                            obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                            obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                            obj.BatchNo = "1";
                            Tlist.Add(obj);

                        }

                    }
                    BindInvoceList(Tlist);
                    txtItemSearch.Text = "";
                    txtItemSearch.Focus();
                }
                else
                {
                    ItemList.DataSource = itemdt;
                    ItemList.DataBind();
                    ItemCountLeft();
                }

            }
        }

        public void bindropdown()
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

            drpptype.DataSource = DB.REFTABLEs.Where(p => p.ACTIVE == "Y" && p.REFTYPE == "PRODTYPE" && p.REFSUBTYPE == "PRODTYPE" && p.TenentID == TID);
            drpptype.DataTextField = "REFNAME1";
            drpptype.DataValueField = "REFID";
            drpptype.DataBind();
            drpptype.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Product Type--", "0"));

            drpuom.DataSource = DB.ICUOMs.Where(p => p.TenentID == TID);
            drpuom.DataTextField = "UOMNAME1";
            drpuom.DataValueField = "UOM";
            drpuom.DataBind();
            drpuom.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Product Type--", "0"));

            drpcategory.DataSource = DB.CAT_MST.Where(p => p.TenentID == TID && p.Active == "1");
            drpcategory.DataTextField = "CAT_NAME1";
            drpcategory.DataValueField = "CATID";
            drpcategory.DataBind();
            drpcategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Product Type--", "0"));

            drpcity.DataSource = DB.tblCityStatesCounties.Where(p => p.COUNTRYID == 126).OrderBy(a => a.CityEnglish);
            drpcity.DataTextField = "CityEnglish";
            drpcity.DataValueField = "CityID";
            drpcity.DataBind();
            drpcity.SelectedValue = 1.ToString();
            //drpcity.Items.Insert(0, new ListItem("-- Select --", "0"));


        }

        protected void txtDisPercent_TextChanged(object sender, System.EventArgs e)
        {
            FinalCalc();
            UpdatePanel3.Update();
        }

        protected void txtDelivery_TextChanged(object sender, System.EventArgs e)
        {
            FinalCalc();
            UpdatePanel3.Update();
        }

        public void printInv(Int64 TRCID)
        {

            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

            checksession();
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID); ;
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
            //if(TID == 17)
            //{ 
            //txtstore.Text = objlocation.LOCNAME1;
            //}
            //else if (TID == 18 && TID == 19 && TID==20)
            //{
            //    txtstore.Text ="";
            //}
            UserAddress.Text = Add2;
            lblA4CustomerAdd.Text = Add2;
            //lblAddress.Text = Add1;
            UserMobile.Text = objcopm.MOBPHONE;
            //  lblA4CustomerPhone.Text = objcopm.MOBPHONE;
            //lblmobile.Text = objlocation.;
            //  lbldate.Text = DateTime.Now.ToString();
            string TIme = objICTR_HD.TRANSDATE.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            BindProduct(TID, LID, TRCID);
            // string url = "Report/InvoiceViewer.aspx?TRCID=" +  TRCID ;

            // string s = "window.open('" + url + "', 'popup_window', 'width=450,height=500,left=100,top=100,resizable=yes');";
            // ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            // pnlReport.Visible = true;

            tblsetupsalesh obj = DB.tblsetupsaleshes.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103);

            DataTable CompanyDt = DAL.Get_CompanyInfo(TID);
            DataTable QuotationDT = DAL.Get_SalesQuotation(TID, LID, TRCID);
            if (CompanyDt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(CompanyDt.Rows[0]["Islocation"]))
                {
                    txtstore.Text = objlocation.LOCNAME1;
                    lblstorea4.Text = objlocation.LOCNAME1;
                }
                else
                {
                    txtstore.Text = "";
                    lblstorea4.Text = "";
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
            //if(TID == 17)
            //{ 
            //logoid.ImageUrl = "../ECOMM/Upload/logo.png";
            //    Label8.Text = "Atyab Al-Saeed For Perfumes Co";
            //    Label9.Text = "Office-51 Floor -15, Panasonic Tower, Al-Qibla";
            //    Label10.Text = "94701017,55192284";
            //    //Label14.Text = ";
            //    Label13.Text = "Info@atyabalsaeed.com.kw";
            //    Label11.Text = "<b>Note: </b> Sold merchandise will be returned and exchanged within 14 days from the date of purchase";
            //    Label12.Text = "البضاعة المباعة ترد وتستبدل خلال ١٤ يوم من تاريخ الشراء";
            //}
            //else if (TID == 18)
            //{
            //    logoid.ImageUrl = "../ECOMM/Upload/ov.png";
            //    Label8.Text = "OV Restaurant";
            //    Label9.Text = "Abu al Hasaniya";
            //    Label10.Text = "";
            //    Label14.Text = "";
            //    Label13.Text = "";
            //    Label11.Text = "<h2>Thank you for order</h2>";
            //    Label12.Text = "";
            //}

            //else if (TID == 19)
            //{
            //    logoid.ImageUrl = "../ECOMM/Upload/padel.png";
            //    Label8.Text = "Dar al Reem";
            //    Label9.Text = "Hawali Block 4 Tunis Street";
            //    Label10.Text = "";
            //    Label14.Text = "";
            //    Label13.Text = "";
            //    Label11.Text = "<h2>Thank you for order</h2>";
            //    Label12.Text = "";
            //}

            //else if (TID == 20)
            //{
            //    logoid.ImageUrl = "../ECOMM/Upload/kna.png";
            //    Label8.Text = "Fayonka";
            //    Label9.Text = "Bruit Street Hawally, Kuwait";
            //    Label10.Text = "99814941";
            //    Label14.Text = "";
            //    Label13.Text = "";
            //    Label11.Text = "<h2>Thank you for order</h2>";
            //    Label12.Text = "";
            //}
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
            // Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Order save successfully", "Successfully!", Classes.Toastr.ToastPosition.TopCenter);


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
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            return DB.TBLPRODUCTs.Single(p => p.MYPRODID == SID && p.TenentID == TID).BarCode;
        }
        public string Getproductdescriptio(int PID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            return DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID).REMARKS;
        }
        public string GetDesc(string DSC)
        {
            string Descrip = DSC.Replace("-", "<br />");
            return Descrip;
        }
        protected void BtnClose_Click(object sender, System.EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

            customerlist.DataSource = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "y" && p.BUYER == true && p.TenentID == TID).Take(5);
            customerlist.DataBind();
            txtCustomerNameSearch.Text = "";
        }

        protected void BtnSaveSetting_Click(object sender, System.EventArgs e)
        {
            bool ChkCustomerstatus = chkcustomer.Checked;
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int Lid = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            DAL.CustomerSetting(TID, UID, ChkCustomerstatus);
            DAL.Edit_PrintPanel(TID, UID, drpPrint.SelectedItem.Text);

        }
        protected void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Cancel();
        }

        protected void btnsubmit_Click(object sender, System.EventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            Database.TBLPRODUCT objprod = new Database.TBLPRODUCT();
            objprod.TenentID = TID;
            long MYprod = DB.TBLPRODUCTs.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt64(DB.TBLPRODUCTs.Where(p => p.TenentID == TID).Max(p => p.MYPRODID) + 1) : 1;
            objprod.MYPRODID = MYprod;
            objprod.LOCATION_ID = 1;
            objprod.BarCode = MYprod.ToString();
            objprod.AlternateCode1 = "99999";
            objprod.AlternateCode2 = "99999";
            if (drpuom.SelectedValue == "0")
            {
                objprod.UOM = 99999;
            }
            else
            {
                objprod.UOM = Convert.ToInt32(drpuom.SelectedValue);
            }

            objprod.SIZECODE = 999999999;
            objprod.ProdTypeRefId = Convert.ToInt32(drpptype.SelectedValue);
            objprod.SupplyMethodID = 99981;
            objprod.ProdMethodID = 99991;
            objprod.ShortName = txtname.Text;
            objprod.DescToprint = "digital Product";
            objprod.ProdName1 = txtname.Text;
            objprod.ProdName2 = txtitemnamearb.Text;
            objprod.ProdName3 = txtname.Text;
            objprod.LASTPURDATE = DateTime.Now;
            objprod.Brand = "99999";
            objprod.QTYINHAND = 1;

            objprod.REMARKS = "";
            if (drpcategory.SelectedValue == "0")
                objprod.MainCategoryID = 99999;
            else
                objprod.MainCategoryID = Convert.ToInt32(drpcategory.SelectedValue);
            objprod.basecost = 99999;
            objprod.onlinesale1 = 99999;
            objprod.msrp = Convert.ToDecimal(txtitemprice.Text);
            objprod.price = Convert.ToDecimal(txtitemprice.Text);
            objprod.currency = "126";
            objprod.QTYRCVD = 10;
            objprod.QTYSOLD = 10;
            objprod.PICTURE = null;
            objprod.ACTIVE = "1";
            objprod.DIRECTSALE = "1";
            objprod.DISPDATE3 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            objprod.Warranty = "0";
            objprod.LASTPURDATE = DateTime.Now;
            objprod.LASTSALDATE = DateTime.Now;
            objprod.COLORID = "999999999";
            objprod.onlinesale3 = 0;
            objprod.InternalNotes = "100";
            if (FileUpload1.HasFile)
            {
                Database.ImageTable objImageTable = new Database.ImageTable();
                objImageTable.TenentID = TID;
                objImageTable.MYPRODID = MYprod;
                objImageTable.ImageID = 98801;
                FileUpload1.SaveAs(Server.MapPath("ECOMM/Upload/") + FileUpload1.FileName);
                objImageTable.PICTURE = FileUpload1.FileName;
                objImageTable.sortnumber = 999999999;
                objImageTable.Active = "1";
                objImageTable.COLORID = 0;
                objImageTable.SIZECODE = 0;
                DB.ImageTables.AddObject(objImageTable);
                DB.SaveChanges();
            }
            objprod.Serialized = false;
            objprod.HotItem = false;
            objprod.SKU = null;
            objprod.MultiBinStore = true;
            objprod.Perishable = true;
            objprod.SaleAllow = true;
            objprod.PurAllow = true;
            DB.TBLPRODUCTs.AddObject(objprod);
            DB.SaveChanges();
            FirstBind();
        }

        protected void Btnuse_Click(object sender, System.EventArgs e)
        {
            int CPID = 0;
            try
            {


                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                CPID = DB.TBLCOMPANYSETUPs.Single(p => p.BUSPHONE1 == txtphone.Text && p.TenentID == TID).COMPID;
                HiddenField3.Value = CPID.ToString();
                txtcustomer.Text = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID & p.COMPID == CPID).COMPNAME1;
                HiddenpaymentCustomer.Value = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID & p.COMPID == CPID).COMPNAME1;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Record Found , Try Again')", true);

            }
        }

        protected void Button1_Click2(object sender, System.EventArgs e)
        {
            checksession();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.TBLCOMPANYSETUPs.Where(p => p.BUSPHONE1 == txtphone.Text && p.TenentID == TID).Count() < 1)
            {



                TBLCOMPANYSETUP obj_Compay = new TBLCOMPANYSETUP();
                obj_Compay.TenentID = TID;
                obj_Compay.COMPID = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Max(p => p.COMPID) + 1) : 1;
                if (txtcname.Text == string.Empty || txtcname.Text == "")
                {
                    obj_Compay.COMPNAME1 = txtphone.Text.Trim();
                    obj_Compay.COMPNAME2 = txtcname2.Text.Trim();
                    obj_Compay.COMPNAME3 = txtphone.Text.Trim();

                }
                else
                {
                    obj_Compay.COMPNAME1 = txtcname.Text.Trim();
                    obj_Compay.COMPNAME2 = txtcname2.Text.Trim();
                    obj_Compay.COMPNAME3 = Translate(txtcname.Text, "fr");
                }
                obj_Compay.PHYSICALLOCID = "KWT";
                obj_Compay.COUNTRYID = 126;
                obj_Compay.EMAIL = txtemail.Text;
                obj_Compay.EMAIL1 = txtemail.Text;
                obj_Compay.EMAIL2 = txtemail.Text;
                obj_Compay.ADDR1 = txtaddress.Text;
                obj_Compay.ADDR2 = txtaddress.Text;
                obj_Compay.STATE = "1906";
                obj_Compay.FAX = "00000";
                obj_Compay.FAX1 = "00000";
                obj_Compay.FAX2 = "00000";
                obj_Compay.BUSPHONE1 = txtphone.Text;
                obj_Compay.BUSPHONE2 = txtphone.Text;
                obj_Compay.BUSPHONE3 = txtphone.Text;
                obj_Compay.BUSPHONE4 = txtphone.Text;
                obj_Compay.MOBPHONE = txtphone.Text;
                obj_Compay.ZIPCODE = "00000";
                obj_Compay.POSTALCODE = "00000";
                obj_Compay.CITY = drpcity.SelectedValue;
                obj_Compay.Approved = 1;
                obj_Compay.Active = "Y";
                obj_Compay.CompanyType = "82003";
                obj_Compay.BUYER = true;
                obj_Compay.MYPRODID = 0;
                obj_Compay.MYCONLOCID = 0;
                DB.TBLCOMPANYSETUPs.AddObject(obj_Compay);
                DB.SaveChanges();
                txtcname.Text = "";
                txtcname2.Text = "";

                txtphone.Text = "";
                txtemail.Text = "";
                txtaddress.Text = "";
                HiddenField3.Value = obj_Compay.COMPID.ToString();
                txtcustomer.Text = obj_Compay.COMPNAME1;
                customerlist.DataSource = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "y" && p.BUYER == true && p.TenentID == TID).Take(5);
                customerlist.DataBind();
                txtCustomerNameSearch.Text = "";
                //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#listcustomer').modal();});", true);
                // lblphone.Visible = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Phone number Already Taken.');", true);
                //   lblphone.Visible = true;
            }
        }
        public string Translate(string textvalue, string to)
        {
            string appId = "A70C584051881A30549986E65FF4B92B95B353A5";//go to http://msdn.microsoft.com/en-us/library/ff512386.aspx to obtain AppId.
            // string textvalue = "Translate this for me";
            string from = "en";

            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId=" + appId + "&text=" + textvalue + "&from=" + from + "&to=" + to;
            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
                    return translation;
                    //return "";
                }
            }
            catch (WebException e)
            {
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        protected void txtcname_TextChanged(object sender, System.EventArgs e)
        {
            string pname = txtcname.Text;
            txtcname2.Text = Translate(txtcname.Text, "ar");
        }

        protected void txtname_TextChanged(object sender, System.EventArgs e)
        {
            string pname = txtname.Text;
            txtitemnamearb.Text = Translate(txtname.Text, "ar");
        }

        protected void Listcustomer_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            int c_id = Convert.ToInt32(e.CommandArgument);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (e.CommandName == "GetCustomer")
            {
                HiddenField3.Value = c_id.ToString();
                txtcustomer.Text = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID & p.COMPID == c_id).COMPNAME1;
                HiddenpaymentCustomer.Value = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID & p.COMPID == c_id).COMPNAME1;
                customerlist.DataSource = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "y" && p.BUYER == true && p.TenentID == TID).Take(5);
                customerlist.DataBind();
                txtCustomerNameSearch.Text = "";
                if (Session["btnname"].ToString() == "orderpop")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#PnlPayment').modal();});", true);
                }
                // updatepanelcustomer.Update();

            }
            else if (e.CommandName == "Edit")
            {

                Response.Redirect("CRM/CompanyMaster.aspx?COMPID=" + c_id.ToString() + "&SrEdit=" + "Yes");
            }

        }
        protected void Listaddon_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            TempProduct obj = new TempProduct();
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (e.CommandName == "Addon")
            {

                int Id = Convert.ToInt32(e.CommandArgument);
                DataTable purobj = DAL.Get_Item_View_Product(TID, LID, Id);//  DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Id && p.LOCATION_ID==LID);
                int UMID = Convert.ToInt32(purobj.Rows[0]["UOM"].ToString());
                Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

                if (Tlist.Where(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).Count() > 0)
                {
                    decimal qty = Convert.ToDecimal(Tlist.Single(p => p.Tenent == TID && p.product_id == int.Parse(purobj.Rows[0]["MYPRODID"].ToString()) && p.UOMID == UMID).OpQty); // change by dipak && p.OnHand >= p.QtyOut).OpQty
                    int PID = Convert.ToInt32(int.Parse(purobj.Rows[0]["MYPRODID"].ToString()));
                    CalcDirectProd(PID, UMID);
                }
                else
                {

                    obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                    obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"]);
                    obj.UOMID = Convert.ToInt32(purobj.Rows[0]["UOM"]); // change by dipak
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    //obj.Shopid = purobj.Shopid;
                    obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                    obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                    obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                    obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                    obj.supplier = purobj.Rows[0]["Option1"].ToString();
                    obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                    //obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                    obj.price = Convert.ToDecimal(purobj.Rows[0]["price"]);//price
                    obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"]);//total
                    obj.RowTotal = Convert.ToDecimal(purobj.Rows[0]["RowTotal"].ToString());
                    obj.Total = obj.msrp;
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"]);
                    obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                    obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"]);
                    obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"]);

                    Tlist.Add(obj);

                    BindInvoceList(Tlist);
                }

            }
        }

        protected void BtnCOD_Click(object sender, System.EventArgs e)
        {
            if (txtcustomer.Text.ToUpper() == "CASH")
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Customer Must be Required...');", true);
                txtcustomer.Focus();
                return;
            }

            if (ViewState["InvoiceProd"] == null)
                return;
            checksession();
            int MTID = 0;
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                MTID = Convert.ToInt32(Request.QueryString["MytransID"]);
            }
            else
            {
                MTID = Convert.ToInt32(Session["GetMYTRANSID"]);
            }

            List<Database.ICTR_DT_Sales> listTempDt = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID).ToList();
            //List<Database.ICTRPayTerms_HD> listicpayHD = DB.ICTRPayTerms_HD.Where(p => p.TenentID == TID && p.MyTransID == MTID).ToList();
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);//Convert.ToInt32(((POSLocSetup)Session["POSLocSetup"]).LocationID);
                                                                               // int terminal = Convert.ToInt32(((POSTermSetup)Session["POSTermSetup"]).LocationID);
            int COMPID = 0;
            string Status = "";
            string UseID = "ponline";//((USER_MST)Session["USER"]).LOGIN_ID;
            DateTime TACtionDate = DateTime.Now;
            string OICODID = Pidalcode(TACtionDate).ToString();
            if (DB.TBLCOMPANYSETUPs.Where(p => p.USERID == UseID && p.TenentID == TID).Count() == 1)
                COMPID = DB.TBLCOMPANYSETUPs.Single(p => p.USERID == UseID && p.TenentID == TID).COMPID;

            List<TempProduct> Tlist = new List<TempProduct>();
            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

            List<SalesItemList> ListSend = new List<SalesItemList>();
            foreach (TempProduct item in Tlist)
            {
                SalesItemList Obj = new SalesItemList();
                Obj.Items_Name = item.product_name;
                Obj.UOMNAME = item.UOMNAME;
                Obj.UOMID = item.UOMID;
                decimal Price = item.msrp;
                Obj.Price = Price;
                Obj.Qty = Convert.ToDecimal(item.OpQty);
                decimal Total = Convert.ToInt32(item.Total);
                Total = Math.Round(Total, 3);
                Obj.Total = Total;
                Obj.itemID = item.product_id.ToString();
                Obj.CustItemCode = item.CustItemCode;
                ListSend.Add(Obj);
            }
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
            CashSave2 sendObj1 = new CashSave2();
            string invoice = "INV" + MTID;
            sendObj1.TenentID = TID;
            sendObj1.LID = LID;
            sendObj1.MYTRANSID = MTID;
            sendObj1.DESCRIPTION = txtcustomer.Text;
            sendObj1.Userid = UID;
            sendObj1.UserName = name;
            sendObj1.PaymentMode = "COD";
            sendObj1.PaymentStatus = "COD";
            sendObj1.OrderStatus = "New";
            sendObj1.DeliveryStatus = "Under the Process";
            sendObj1.DID = Convert.ToInt32(Session["ID"]);
            sendObj1.Invoice = invoice;
            sendObj1.Orderway = BtnOrdertypeMain.Text;
            string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
            if (ChIsCredit.Checked == true)
            {
                sendObj1.PaymentMode = "Credit";
            }
            else
            {

            }
            if (Customer.Contains('-'))
            {
                Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
            }
            sendObj1.Customer = Customer;
            int C_id = HiddenField3.Value != null && HiddenField3.Value != "" ? Convert.ToInt32(HiddenField3.Value) : 1;
            sendObj1.CustomerID = C_id != 0 ? C_id : 1;

            decimal Predis = Convert.ToDecimal(lblDiscount.Text);
            decimal Invoidis = Convert.ToDecimal(lblDiscount.Text);
            decimal Fdis = Predis + Invoidis;

            sendObj1.DiscountTotaloverall = lblDiscount.Text.ToString();
            sendObj1.overalldisRate = lblDiscount.Text != "" ? lblDiscount.Text : "0";
            sendObj1.Delivery_Cahrge = txtdeliverycharges.Text; //lblDelivery.Text != "" ? lblDelivery.Text : "0";
            sendObj1.DiscountAmt = lblDiscount.Text.ToString();
            sendObj1.TotalPayable = Convert.ToDecimal(FTotall.Text);
            if (txtCashRecived.Text != null && txtCashRecived.Text != "")
            {
                sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);
            }


            sendObj1.dgrvSalesItemList = ListSend;

            fullConfirmnew(sendObj1);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Add("Authentication", bearerToken);
            //    HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/fullConfirmnew", sendObj1).Result;
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();

            //        //Response.Redirect("LocalInvoice.aspx?Tranjestion=" + mytransid);


            //        // Page.Response.Redirect(Page.Request.Url.ToString(), true);
            //    }
            //    else
            //    {
            //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
            //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
            //        string MSg = rootobject.data.ToString();
            //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('" + MSg + "');", true);
            //    }
            //}
            int mytransid = MTID; //GetSalesID(MSg);
            printInv(MTID);
            bintlist();
        }

        public void fullConfirmnew(CashSave2 sendObj1)

        {
            try
            {
                if (sendObj1.TenentID == 0 || sendObj1.MYTRANSID == 0 || sendObj1.Userid == 0 || sendObj1.CustomerID == 0 || sendObj1.UserName == "" || sendObj1.DESCRIPTION == "" || sendObj1.Invoice == "")
                {
                    return;
                }
                List<SalesItemList> dgrvSalesItemList = sendObj1.dgrvSalesItemList.ToList();
                List<PaymentData> GridPayment = new List<PaymentData>();

                if (sendObj1.GridPayment != null)
                {
                    GridPayment = sendObj1.GridPayment.ToList();
                }
                if (dgrvSalesItemList.Count() < 1)
                {

                    return;
                }
                else if (GridPayment.Count() > 0)
                {
                    foreach (PaymentData items in GridPayment)
                    {
                        if (items.payment_type == "" || items.payment_type == null || items.payment_amount == 0)
                        {
                            // if (items.payment_type != "Cash" && (items.Reffrance_NO == "" || items.Reffrance_NO == null))
                            // {
                            //     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                            //     return;
                            // }
                            // else 
                            if (items.payment_type == null || items.payment_type == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                                return;
                            }
                            else
                            {

                            }

                        }
                    }
                }
                else
                {
                    foreach (SalesItemList items in dgrvSalesItemList)
                    {
                        // Items_Name, Price, Qty, Total, itemID, CustItemCode
                        if (items.Items_Name == "" || items.Items_Name == null || items.UOMNAME == "" || items.UOMNAME == null || items.Price == 0 || items.Qty == 0 || items.itemID == "0" || items.itemID == "" || items.itemID == null || items.CustItemCode == "" || items.CustItemCode == null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                            return;
                        }
                    }
                }

                int TenentID = sendObj1.TenentID;
                Int64 MYTransid = sendObj1.MYTRANSID;
                int LID = sendObj1.LID;
                int CustomerID = sendObj1.CustomerID;
                string DiscountTotaloverall = sendObj1.DiscountTotaloverall;//!= null && sendObj1.DiscountTotaloverall != "" ? sendObj1.DiscountTotaloverall : "0";
                decimal TotalPayable = sendObj1.TotalPayable;
                decimal TotalCashRecived = sendObj1.TotalPayable;
                int userid = sendObj1.Userid;
                string invoice = sendObj1.Invoice;
                string UserName = sendObj1.UserName != "" && sendObj1.UserName != null ? sendObj1.UserName : DB.USER_MST.Where(p => p.TenentID == TenentID && p.USER_ID == userid).FirstOrDefault().FIRST_NAME.ToString();
                string Customer = sendObj1.Customer != "" && sendObj1.Customer != null ? sendObj1.Customer : DB.Win_tbl_customer.Where(p => p.TenentID == TenentID && p.ID == CustomerID).FirstOrDefault().Name;
                int ID = sendObj1.DID;
                string Oway = sendObj1.Orderway;
                //!= null && sendObj1.OrderWay != "" ? sendObj1.OrderWay : "Walk In - Walk In";
                string overalldisRate = sendObj1.overalldisRate;//!= null && sendObj1.overalldisRate != "" ? sendObj1.overalldisRate : "0";
                string Delivery_Cahrge = sendObj1.Delivery_Cahrge;
                string PaymentMode = sendObj1.PaymentMode;
                decimal changeamount = sendObj1.ChangeAmount;
                string paymentstatus = sendObj1.PaymentStatus;
                string orderstaus = sendObj1.OrderStatus;
                string DeliveryStatus = sendObj1.DeliveryStatus;
                string MSG = Cash_Sales(TenentID, LID, MYTransid, userid, UserName, TotalPayable, changeamount, TotalCashRecived, paymentstatus, orderstaus, DeliveryStatus, Customer, DiscountTotaloverall, CustomerID, overalldisRate, Delivery_Cahrge, dgrvSalesItemList, invoice, PaymentMode, GridPayment, Oway);
                if (MSG == "er")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error in Payment Saving , Try Again')", true);
                    return;
                }
                DateTime dt = DateTime.Now;
                string stdate = dt.ToString("yyyy-MM-dd");
                DateTime dt1 = Convert.ToDateTime(stdate);


                if (ID != null && ID != 0)
                {
                    DayClose objday = DB.DayCloses.Single(p => p.TenentID == TenentID && p.ID == ID);
                    objday.OpAMT = 0;
                    string amount = (DB.ICTR_HD_Sales.Single(p => p.TenentID == TenentID && p.MYTRANSID == MYTransid && p.locationID == LID).TOTAMT).ToString();
                    objday.ShiftSales = Convert.ToDecimal(amount);
                    objday.ShiftReturn = Convert.ToDecimal(amount);
                    //DB.SaveChanges();
                }


                return;

            }
            catch (Exception ex)
            {
                if (sendObj1.TenentID != 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('We Found problem in TenentID!')", true);
                    return;
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('We Found problem in TenentID!')", true);
                    return;


                }
            }
        }

        public string Cash_Sales(int TenentID, int LID, Int64 Mytransid, int Userid, string UserName, decimal TotalPayable, decimal changeamount, decimal TotalCashRecived, string paymentstatus, string orderstatus, string DeliveryStatus, string Customer, string DiscountTotaloverall, int CustomerID, string overalldisRate, string Delivery_Cahrge, List<SalesItemList> dgrvSalesItemList, string invoice, string Payment, List<PaymentData> GridPayment, string Oway)
        {
            string salesdate = "";
            DateTime sales_date = Convert.ToDateTime(DateTime.Now);
            salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            if (Mytransid == 0)
            {
                string Err = "Sorry ! You don't have enough product in Item cart \n  Please Add to cart";
                return Err;
            }


            else
            {
                string InvoiceNO = "";
                string Invo = "";
                string Transid = "";
                string trno = "";
                int InvoiceID = 0;
                string Sales_ID = "";
                if (invoice != null && invoice != "")
                {
                    InvoiceNO = invoice;
                    Invo = InvoiceNO;

                    Transid = DAL.GetInvoiceNo(TenentID, LID, TerminalID, out InvoiceID).ToString(); //GetSalesIDFromInvoice(TenentID, Mytransid).ToString();
                    Sales_ID = Mytransid.ToString();
                    trno = Sales_ID;
                }
                else
                {
                    InvoiceNO = "INV" + Mytransid;//GetSalesIDFromInvoice(TenentID, Mytransid).ToString();
                    Invo = InvoiceNO;

                    Transid = DAL.GetInvoiceNo(TenentID, LID, TerminalID, out InvoiceID).ToString(); // get_sales_id(TenentID);
                    Sales_ID = Mytransid.ToString();
                    trno = Sales_ID;
                }

                string Comment = "Cash";
                string PaymentStutas = "";
                if (Payment == "COD")
                {
                    PaymentStutas = "Pending";
                }
                else
                {
                    PaymentStutas = "Success";
                }
                decimal TotalPay_amount = TotalPayable;
                decimal ChangeAmount = changeamount;
                decimal dueAmount = 0;


                string PaymentMode = Payment;
                // List<PaymentData> GridPayment = new List<PaymentData>();

                string ShiftID = Session["ShiftID"].ToString();

                bool Status = payment_itemsave(TenentID, LID, TotalPayable, ChangeAmount, dueAmount, salesdate, Comment, PaymentStutas, trno, InvoiceNO, Customer, CustomerID, DiscountTotaloverall, overalldisRate, Delivery_Cahrge, UserName, "1", Userid, int.Parse(ShiftID), GridPayment, Payment);
                //if (!Status)
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error in Payment Saving')", true);
                //    return "er";
                //}

                // payment_itemsave(TenentID, TotalPayable, ChangeAmount, dueAmount, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), Comment, PaymentStutas, trno, InvoiceNO, Customer, CustomerID, DiscountTotaloverall, overalldisRate, Delivery_Cahrge, UserName,  Userid, GridPayment);

                // string OrderWay = "Paid - send to Kitchen";
                string OrderStutas = "Paid - send to Kitchen";
                int OrderTotal = 1;
                int COD = 0;
                string PaymentStatus = paymentstatus;
                string orderstatuss = orderstatus;
                string deliverystaus = DeliveryStatus;
                string Oways = Oway;
                string discunt = DiscountTotaloverall;

                sales_item(TenentID, LID, DateTime.Now.ToString("yyyy-MM-dd").ToString(), OrderStutas, COD, PaymentMode, trno, InvoiceID.ToString(), Customer, CustomerID, PaymentStatus, orderstatuss, deliverystaus, TotalPayable, UserName, "1", int.Parse(trno), dgrvSalesItemList, Oways, discunt);

                string ActivityName = "sales Cash Transaction";
                string LogData = "Save Sales Transaction as Cash with InvoiceNO = " + Invo + " ";

                return InvoiceNO;
            }
        }

        public static void DeleteSales_itemOrder(int TenentID, int Mytransid)
        {

            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql3 = "Delete from ICTR_HD_Sales_tmp where Mytransid  = '" + Mytransid + "' and TenentID = " + TenentID + "";
            DataCon.ExecuteSQL(sql3);
        }

        public static bool IsPerishable(int TenentID, int ProdID)
        {
            string sql12 = " select * from TBLPRODUCT where TenentID = " + TenentID + " and MYPRODID = '" + ProdID + "' ";
            DataTable dt1 = DataCon.GetDataTable(sql12);
            if (dt1.Rows.Count > 0)
            {
                int Perishable = Convert.ToInt32(dt1.Rows[0]["IsPerishable"]);
                if (Perishable == 1)
                    return true;
                else
                    return false;

            }
            else
            {
                return false;
            }
        }


        public static int getICIT_BR_TMPMYid(int TenentID, int MyProdID, int UOM)
        {
            int ID12 = 1;
            string sql12 = "select * from ICTR_DT_Sales_tmp where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
            int rc = DataCon.ExecuteSQL(sql12);
            DataTable dt1 = DataCon.GetDataTable(sql12);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICTR_DT_Sales_tmp where TenentID=" + TenentID + " and MyProdID='" + MyProdID + "' and UOM='" + UOM + "' ";
                DataTable dt12 = DataCon.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }

        public int Pidalcode(DateTime? Time = null, int TenentID = 0, string MYSYSNAME = null)
        {

            int PODID = 0;
            List<TBLPERIOD> ListTBLPERIOD = DB.TBLPERIODS.Where(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.TenentID == TenentID && p.MYSYSNAME == MYSYSNAME).ToList();
            if (ListTBLPERIOD.Count() > 0)
            {
                PODID = Convert.ToInt32(ListTBLPERIOD.Single(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.TenentID == TenentID && p.MYSYSNAME == MYSYSNAME).PERIOD_CODE);

            }
            return PODID;
        }

        public void InsertPerishableTemp(int TenentID, int MyProdID, int UOMID, int customer, string Batch_No, int MYTRANSID, string MySysName, string Prodname, int UOM, decimal unitprice, decimal amount, double qty, DateTime ProdDate, DateTime ExpiryDate, string LeadDays2Destroy, string UserName)
        {
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string q = "select * from ICTR_DT_Sales_tmp where TenentID=" + TenentID + " and MyProdID =" + MyProdID + "  and UOM=" + UOMID + " and BatchNo='" + Batch_No + "' and MYTRANSID=" + MYTRANSID + " and MySysName='" + MySysName + "' ";
            DataTable dt1 = DataCon.GetDataTable(q);

            string q2 = "select * from ICTR_HD_Sales_tmp where TenentID=" + TenentID + " and MYTRANSID =" + MYTRANSID + "  and UOM=" + UOMID + " ' ";
            DataTable dt2 = DataCon.GetDataTable(q);

            if (dt1.Rows.Count < 1)
            {
                //string period_code = "201801";
                //int SIZECODE = 999999998;
                //int COLORID = 999999998;
                //int Bin_ID = 999999998;
                //string Serial_Number = "NO";
                //string RecodName = "Perishable";

                int LocationID = 1;

                int ID = getICIT_BR_TMPMYid(TenentID, MyProdID, UOMID);

                if (DB.ICTR_DT_Sales_tmp.Where(c => c.TenentID == TenentID && c.locationID == 1 && c.MYTRANSID == MYTRANSID).Count() < 1)
                {
                    ICTR_DT_Sales_tmp objdt = new ICTR_DT_Sales_tmp();
                    objdt.TenentID = TenentID;
                    objdt.locationID = 1;
                    objdt.TerminalID = 1;
                    objdt.MYTRANSID = MYTRANSID;
                    var ListICTR_DT = DB.ICTR_DT_Sales_tmp.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
                    int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
                    objdt.MYID = MYIDDT;
                    objdt.TerminalID = 1;
                    objdt.MyProdID = MyProdID;
                    objdt.REFTYPE = "POS";
                    objdt.REFSUBTYPE = "POS";
                    DateTime trnsDates = DateTime.Now;
                    string MySysNames = "SAL";
                    string PERIOD_CODE = Pidalcode(trnsDates, TenentID, MySysNames).ToString();
                    objdt.PERIOD_CODE = PERIOD_CODE;
                    objdt.MYSYSNAME = "SAL";
                    objdt.JOID = 1;
                    objdt.JOBORDERDTMYID = 1;
                    objdt.ACTIVITYID = 1;
                    objdt.DESCRIPTION = Prodname;
                    objdt.UOM = UOMID.ToString();
                    objdt.QUANTITY = Convert.ToDecimal(qty);
                    objdt.UNITPRICE = unitprice;
                    objdt.AMOUNT = objdt.QUANTITY * objdt.UNITPRICE;
                    objdt.OVERHEADAMOUNT = 1;
                    objdt.BATCHNO = "1";
                    objdt.BIN_ID = 1;
                    objdt.BIN_TYPE = "1";
                    objdt.GRNREF = "1";
                    objdt.DISPER = 1;
                    objdt.DISAMT = 0;
                    objdt.TAXAMT = 1;
                    objdt.TAXPER = 1;
                    objdt.PROMOTIONAMT = 1;
                    objdt.GLPOST = "2";
                    objdt.GLPOST1 = "2";
                    objdt.GLPOSTREF1 = "2";
                    objdt.GLPOSTREF = "2";
                    objdt.ICPOST = "2";
                    objdt.ICPOSTREF = "2";
                    objdt.EXPIRYDATE = DateTime.Now;
                    objdt.COMPANYID = customer;
                    objdt.SWITCH1 = "1";
                    objdt.ACTIVE = true;
                    objdt.Stutas = "Draft";
                    DB.ICTR_DT_Sales_tmp.AddObject(objdt);
                    DB.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Successfully')", true);
                }

                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Duplicate Record Found')", true);
                    return;

                }
            }


            else
            {
                ICTR_DT_Sales_tmp objdt = DB.ICTR_DT_Sales_tmp.Single(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID);
                objdt.MyProdID = MyProdID;
                objdt.REFTYPE = "POS";
                objdt.REFSUBTYPE = "POS";
                DateTime trnsDates = DateTime.Now;
                string MySysNames = "SAL";
                string PERIOD_CODE = Pidalcode(trnsDates, TenentID, MySysNames).ToString();
                objdt.PERIOD_CODE = PERIOD_CODE;
                objdt.MYSYSNAME = "SAL";
                objdt.JOID = 1;
                objdt.JOBORDERDTMYID = 1;
                objdt.ACTIVITYID = 1;
                objdt.DESCRIPTION = Prodname;
                objdt.UOM = UOMID.ToString();
                objdt.QUANTITY = Convert.ToDecimal(qty);
                objdt.UNITPRICE = unitprice;
                objdt.AMOUNT = objdt.QUANTITY * objdt.UNITPRICE;
                objdt.OVERHEADAMOUNT = 1;
                objdt.BATCHNO = "1";
                objdt.BIN_ID = 1;
                objdt.BIN_TYPE = "1";
                objdt.GRNREF = "1";
                objdt.DISPER = 1;
                objdt.DISAMT = 0;
                objdt.TAXAMT = 1;
                objdt.TAXPER = 1;
                objdt.PROMOTIONAMT = 1;
                objdt.GLPOST = "2";
                objdt.GLPOST1 = "2";
                objdt.GLPOSTREF1 = "2";
                objdt.GLPOSTREF = "2";
                objdt.ICPOST = "2";
                objdt.ICPOSTREF = "2";
                objdt.EXPIRYDATE = DateTime.Now;
                objdt.COMPANYID = customer;
                objdt.SWITCH1 = "1";
                objdt.ACTIVE = true;
                // objdt.DelFlag = true;
                objdt.Stutas = "Draft";
                DB.SaveChanges();

            }

            if (dt2.Rows.Count < 1)
            {

                DateTime Todate = DateTime.Now;
                ICTR_HD_Sales_tmp objICTR_HD = new ICTR_HD_Sales_tmp();
                bool flag = false;
                if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID).Count() < 1)
                {
                    objICTR_HD = new ICTR_HD_Sales_tmp();
                    flag = true;
                }
                else
                {
                    objICTR_HD = DB.ICTR_HD_Sales_tmp.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
                }
                objICTR_HD.TenentID = TenentID;
                objICTR_HD.MYTRANSID = MYTRANSID;
                objICTR_HD.ToTenantID = TenentID;
                objICTR_HD.locationID = 1;
                objICTR_HD.MainTranType = "O";
                objICTR_HD.TransType = "POS Invoice";
                objICTR_HD.transid = 4101;
                objICTR_HD.transsubid = 410103;
                objICTR_HD.TranType = "POS Invoice";
                objICTR_HD.COMPID = 1;
                objICTR_HD.MYSYSNAME = "SAL";
                objICTR_HD.CUSTVENDID = customer;
                objICTR_HD.LF = "L";
                DateTime trnsDates = DateTime.Now;
                string MySysNames = "SAL";
                string PERIOD_CODE = Pidalcode(trnsDates, TenentID, MySysNames).ToString();
                objICTR_HD.PERIOD_CODE = PERIOD_CODE;
                objICTR_HD.ACTIVITYCODE = "1";
                objICTR_HD.MYDOCNO = 1;
                objICTR_HD.USERBATCHNO = "1";
                objICTR_HD.TOTAMT = amount;
                objICTR_HD.TOTQTY = Convert.ToDecimal(qty);
                objICTR_HD.AmtPaid = amount;
                objICTR_HD.PROJECTNO = "1";
                objICTR_HD.CounterID = "1";
                objICTR_HD.PrintedCounterInvoiceNo = "1";
                objICTR_HD.JOID = 1;
                objICTR_HD.TRANSDATE = DateTime.Now;
                objICTR_HD.REFERENCE = "POS";
                objICTR_HD.NOTES = "POS";
                objICTR_HD.GLPOST = "2";
                objICTR_HD.GLPOST1 = "2";
                objICTR_HD.GLPOSTREF = "2";
                objICTR_HD.GLPOSTREF1 = "2";
                objICTR_HD.ICPOST = "2";
                objICTR_HD.ICPOSTREF = "2";
                // objICTR_HD.USERID = userid;
                objICTR_HD.ACTIVE = true;
                //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
                //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
                objICTR_HD.COMPANYID = 1;
                objICTR_HD.ENTRYDATE = DateTime.Now;
                objICTR_HD.ENTRYTIME = DateTime.Now;
                objICTR_HD.UPDTTIME = DateTime.Now;

                objICTR_HD.Status = "DSO";
                objICTR_HD.Terms = 0;
                objICTR_HD.ExtraField1 = "0";
                objICTR_HD.ExtraField2 = "0";
                objICTR_HD.ExtraSwitch1 = "0";
                objICTR_HD.RefTransID = 0;
                objICTR_HD.ExtraSwitch2 = "";
                objICTR_HD.TransDocNo = "";
                objICTR_HD.LinkTransID = 0;
                objICTR_HD.InvoiceNO = "INV" + MYTRANSID;
                objICTR_HD.invoice_Source = 1;
                objICTR_HD.invoice_Type = 1;

                // objICTR_HD.ExtraSwitch2 = "";
                if (flag == true)
                {
                    DB.ICTR_HD_Sales_tmp.AddObject(objICTR_HD);
                }
                DB.SaveChanges();

            }

        }

        public bool sales_item(int TenentID, int LID, string salesdate, string OrderStutas, int COD, string PaymentMode, string trno, string invoiceNO, string Customer, int CustomerID, string paymentstatus, string orderstatus, string DeliveryStatus, decimal TotalPayable, string UserName, string Shopid, int Mytransid, List<SalesItemList> dgrvSalesItemList, string Oway, string discunt)
        {
            if (salesdate != "")
            {
                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime sales_date = DateTime.Now;
                salesdate = sales_date.ToString("yyyy-MM-dd");
            }



            POSTermSetup objterm = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID);

            string MainTranType = "O";
            string TransType = objterm.TranType;
            string TranType = objterm.Transsubtype;
            decimal COMPID1 = CustomerID;
            string MYSYSNAME = objterm.MYSYSNAME;
            string Customer2 = Customer;
            if (Customer2.Contains('-'))
            {
                Customer2 = Customer != "" ? Customer.Split('-')[0].Trim() : "Cash";
            }
            int CID = int.Parse(COMPID1.ToString());// Convert.ToInt32(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TenentID && p.COMPNAME1 == Customer).COMPID);

            decimal CUSTVENDID = Convert.ToInt32(CID);
            string PERIOD_CODE = objterm.Period_code;
            string ACTIVITYCODE = "0";
            decimal MYDOCNO = 1;
            string USERBATCHNO = "99999";

            decimal TOTAMT, TOTQTY1 = 0;
            decimal AmtPaid = 1;
            string PROJECTNO = "99999";
            string CounterID = "1";
            string PrintedCounterInvoiceNo = "1";
            DateTime TRANSDATE = DateTime.Now; //DateTime.ParseExact(txtOrderDate.Text, "dd-MMM-yy", System.Globalization.CultureInfo.InvariantCulture);
            string REFERENCE = objterm.RefType;
            string NOTES = objterm.RefType;
            int JOID = 1;
            int CRUP_ID = Convert.ToInt32(999999);
            string GLPOST = objterm.GLPOST;
            string GLPOST1 = objterm.GLPOST1;
            string GLPOSTREF = objterm.GLPOSTREF;
            string GLPOSTREF1 = objterm.GLPOSTREF1;
            string ICPOST = objterm.ICPOST;
            string ICPOSTREF = objterm.ICPOSTREF;
            int COMPANYID = Convert.ToInt32(objterm.CounterID);
            bool ACTIVE = Convert.ToBoolean(true);
            DateTime Curentdatetime = DateTime.Now;
            DateTime ENTRYDATE = Curentdatetime;
            DateTime ENTRYTIME = Curentdatetime;
            int Terms = 1;
            DateTime UPDTTIME = Curentdatetime;
            decimal Discount = Convert.ToDecimal(0);
            string DatainserStatest = "Add";

            string InvoiceNo = invoiceNO;
            int rows = dgrvSalesItemList.Count();
            string Query1 = "select * from ICTR_HD_Sales where TenentID = " + TenentID + " and Mytransid='" + Mytransid + "' and LocationID=" + LID + "";
            DataTable dtQuery1 = DataCon.GetDataTable(Query1);
            if (dtQuery1.Rows.Count > 0)
            {
                if (dtQuery1.Rows.Count > 0)
                {
                    DeleteSales_itemOrder(TenentID, Mytransid);


                    ICTR_HD_Sales ObjHDSale = new ICTR_HD_Sales();

                    ObjHDSale = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == Mytransid && p.TenentID == TenentID && p.locationID == LID);

                    ObjHDSale.TenentID = TenentID;
                    ObjHDSale.MYTRANSID = Mytransid;

                    ObjHDSale.locationID = LID;

                    ObjHDSale.COMPID = CID;

                    ObjHDSale.payment_type = paymentstatus;



                    ObjHDSale.PaymentStatus = paymentstatus;
                    ObjHDSale.OrderStatus = orderstatus;
                    ObjHDSale.DeliveryStatus = DeliveryStatus;
                    ObjHDSale.Orderway = Oway;

                    ObjHDSale.TOTAMT = TotalPayable; // quantity * PRice;// Convert.ToDecimal(FTotall.Text);



                    ObjHDSale.USERID = ((USER_MST)Session["USER"]).USER_ID.ToString();


                    if (PaymentMode == "Cash")
                    {
                        ObjHDSale.Status = "Final";
                    }
                    else if (PaymentMode == "COD")
                    {
                        ObjHDSale.Status = "COD";
                    }
                    else if (PaymentMode == "Credit")
                    {
                        ObjHDSale.Status = "Credit";
                    }
                    else if (PaymentMode == "Draft")
                    {
                        ObjHDSale.Status = "Draft";
                    }

                    ObjHDSale.Discount = Convert.ToDecimal(discunt);
                    ObjHDSale.CUSTVENDID = int.Parse(CID.ToString());
                    // objICTR_HD.ExtraSwitch2 = "";

                    DAL.Update_HDSale(ObjHDSale);
                }


            }
            foreach (SalesItemList Items in dgrvSalesItemList)
            {
                string CustItemCode1 = Items.CustItemCode;
                string itemid = Items.itemID;
                int ProdID = Convert.ToInt32(Items.itemID);
                int LocationID = LID;
                //int TerminalID=db.POSTermSetups.Single(p=>p.TenentID == TenentID && p.LocationID == LID).TerminalID;
                //int ShiftID = db.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID).TerminalID;
                string itNam = Items.Items_Name;
                double qty = Convert.ToDouble(Items.Qty);
                double Rprice = Convert.ToDouble(Items.Price);
                double total = Convert.ToDouble(Items.Total);
                double dis = Convert.ToDouble(Items.Dis); //discount rate
                double taxapply = Convert.ToDouble(Items.taxapply);
                int kitchendisplay = Convert.ToInt32(Items.kitchendisplay);
                string CustItemCode = Items.CustItemCode;
                int customer = Items.CustomerID;
                int prodid = Convert.ToInt32(itemid);
                string Prodname = Items.Items_Name;
                string description = Items.Items_Name;

                string BatchNo = Items.BatchNo != null ? Items.BatchNo.ToString() : "0";
                string ExpiryDate = Items.ExpiryDate != null ? Items.ExpiryDate.ToString() : "";

                DateTime ExpiryDate1 = Convert.ToDateTime(ExpiryDate);

                string UOMNAME = Items.UOMNAME;
                int UOMID = Items.UOMID;//getuomid(TenentID, uom);
                int MYTRANSID = Mytransid;//Convert.ToInt32(trno);
                decimal unitprice = Items.Price;
                decimal amount = Items.Price * Items.Qty;
                DateTime ProdDate = DateTime.Now;
                string LeadDays2Destroy = "";

                bool flag1 = false;//IsPerishable(TenentID, prodid);
                if (flag1 == true)
                {
                    string query = "select BatchNo,OnHand,ProdDate,ExpiryDate,LeadDays2Destroy from ICIT_BR_Perishable where TenentID=" + TenentID + " and MyProdID =" + ProdID + "  and UOM=" + UOMID + " and OnHand>=1 and BatchNo = '" + BatchNo + "' ";
                    DataTable dtquery = DataCon.GetDataTable(query);
                    if (dtquery.Rows.Count > 0)
                    {
                        ProdDate = Convert.ToDateTime(dtquery.Rows[0]["ProdDate"]);
                        LeadDays2Destroy = dtquery.Rows[0]["LeadDays2Destroy"].ToString();
                    }

                    InsertPerishableTemp(TenentID, ProdID, UOMID, customer, BatchNo, MYTRANSID, "SAL", Prodname, UOMID, unitprice, amount, qty, ProdDate, ExpiryDate1, LeadDays2Destroy, UserName);
                }

                string product_name_print = Prodname;
                decimal PRice = unitprice;
                decimal msrp = unitprice;
                decimal discount = 1;//Convert.ToDouble(prof[0].Discount);
                decimal quantity = Items.Qty;
                // int sales_id = Convert.ToInt32(trno);
                int TenentID2 = TenentID;
                string HDQuery = "select * from ICTR_HD_Sales where TenentID = " + TenentID2 + " and Mytransid='" + Mytransid + "' and LocationID=" + LID + "";
                DataTable dtHDQuery = DataCon.GetDataTable(HDQuery);



                if (dtHDQuery.Rows.Count == 0)
                {

                    ICTR_HD_Sales objICTR_HD = new ICTR_HD_Sales();
                    bool flag = false;
                    if (DatainserStatest == "Add")
                    {
                        objICTR_HD = new ICTR_HD_Sales();
                        flag = true;
                        objICTR_HD.InvoiceNO = InvoiceNo.ToString();

                    }
                    else
                    {
                        objICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == Mytransid && p.TenentID == TenentID && p.locationID == LID);
                    }
                    objICTR_HD.TenentID = TenentID;
                    objICTR_HD.MYTRANSID = Mytransid;
                    //objICTR_HD.ToTenentID = ToTenentID;
                    POSTermSetup objterms = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID);
                    objICTR_HD.locationID = LID;
                    objICTR_HD.TerminalID = objterm.TerminalID;
                    objICTR_HD.MainTranType = MainTranType;
                    objICTR_HD.TransType = TranType;
                    objICTR_HD.transid = objterms.transid;
                    objICTR_HD.transsubid = objterms.transsubid;
                    objICTR_HD.TranType = objterms.RefType;
                    objICTR_HD.COMPID = CID;
                    objICTR_HD.MYSYSNAME = objterms.MYSYSNAME;
                    objICTR_HD.payment_type = paymentstatus;
                    objICTR_HD.CUSTVENDID = Convert.ToDecimal(CUSTVENDID);
                    objICTR_HD.LF = "L";
                    objICTR_HD.PERIOD_CODE = objterms.Period_code;
                    objICTR_HD.ACTIVITYCODE = ACTIVITYCODE;
                    objICTR_HD.PaymentStatus = paymentstatus;
                    objICTR_HD.OrderStatus = orderstatus;
                    objICTR_HD.DeliveryStatus = DeliveryStatus;
                    objICTR_HD.Orderway = Oway;
                    objICTR_HD.MYDOCNO = MYDOCNO;
                    objICTR_HD.USERBATCHNO = USERBATCHNO;
                    objICTR_HD.TOTAMT = TotalPayable; // quantity * PRice;// Convert.ToDecimal(FTotall.Text);
                    objICTR_HD.TOTQTY = TOTQTY1;
                    objICTR_HD.AmtPaid = AmtPaid;
                    objICTR_HD.PROJECTNO = PROJECTNO;
                    objICTR_HD.CounterID = CounterID;
                    objICTR_HD.PrintedCounterInvoiceNo = PrintedCounterInvoiceNo;
                    objICTR_HD.JOID = JOID;
                    objICTR_HD.TRANSDATE = Convert.ToDateTime(TRANSDATE);
                    objICTR_HD.REFERENCE = REFERENCE;
                    objICTR_HD.NOTES = NOTES;
                    objICTR_HD.GLPOST = objterms.GLPOST;
                    objICTR_HD.GLPOST1 = objterms.GLPOST1;
                    objICTR_HD.GLPOSTREF = objterms.GLPOSTREF;
                    objICTR_HD.GLPOSTREF1 = objterms.GLPOSTREF1;
                    objICTR_HD.ICPOST = objterms.ICPOST;
                    objICTR_HD.ICPOSTREF = objterms.ICPOSTREF;

                    objICTR_HD.USERID = ((USER_MST)Session["USER"]).USER_ID.ToString();
                    objICTR_HD.ACTIVE = true;
                    //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
                    //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
                    objICTR_HD.COMPANYID = COMPANYID;
                    objICTR_HD.ENTRYDATE = ENTRYDATE;
                    objICTR_HD.ENTRYTIME = ENTRYTIME;
                    objICTR_HD.UPDTTIME = UPDTTIME;
                    objICTR_HD.Discount = Discount;
                    if (PaymentMode == "Cash")
                    {
                        objICTR_HD.Status = "Final";
                    }
                    else if (PaymentMode == "COD")
                    {
                        objICTR_HD.Status = "COD";
                    }
                    else if (PaymentMode == "Credit")
                    {
                        objICTR_HD.Status = "Credit";
                    }
                    else if (PaymentMode == "Draft")
                    {
                        objICTR_HD.Status = "Draft";
                    }
                    objICTR_HD.Terms = Terms;
                    objICTR_HD.ExtraField1 = objterms.ExtraField1;
                    objICTR_HD.ExtraField1 = objterms.ExtraField2;
                    objICTR_HD.ExtraField2 = objterms.ExtraField2;
                    objICTR_HD.ExtraSwitch1 = objterms.ExtraSwitch1;
                    objICTR_HD.RefTransID = MYTRANSID;
                    objICTR_HD.TransDocNo = invoiceNO;

                    objICTR_HD.Discount = Convert.ToDecimal(discunt);

                    // objICTR_HD.ExtraSwitch2 = "";
                    if (flag == true)
                    {
                        DB.ICTR_HD_Sales.AddObject(objICTR_HD);


                    }
                    DB.SaveChanges();
                }


            }
            if (txtQuotation.Text.Trim() != "" || txtlpo.Text.Trim() != "")
            {
                DAL.Insert_SalesQuotation(TenentID, LID, Mytransid, txtQuotation.Text, txtlpo.Text);
            }
            foreach (SalesItemList Items in dgrvSalesItemList)
            {
                string itemid = Items.itemID;

                DateTime trnsDates = DateTime.Now;
                string MySysNames = "SAL";

                int ProdID = Convert.ToInt32(Items.itemID);
                int MYID = DB.ICTR_DT_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == LID).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == LID).Max(p => p.MYID) + 1) : 1;
                string itNames = Items.Items_Name;
                int Uom = Convert.ToInt32(DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.MYPRODID == ProdID).UOM);
                POSTermSetup objterms = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID);
                double taxapply = Convert.ToDouble(Items.taxapply);
                int kitchendisplay = Convert.ToInt32(Items.kitchendisplay);
                string CustItemCode = Items.CustItemCode;
                int customer = Items.CustomerID;
                int prodid = Convert.ToInt32(itemid);
                string Prodname = Items.Items_Name;
                string REFTYPE = objterms.RefType;
                string REFSUBTYPE = objterms.RefSubtype;
                int JOBORDERDTMYID = 1;
                int ACTIVITYID = 0;
                string DESCRIPTION = itNames;
                string UOM = Uom.ToString();
                decimal QUANTITY = Items.Qty;
                decimal UNITPRICE = Items.Price;//
                decimal AMOUNT = QUANTITY * UNITPRICE;//lblTotalCurrency.Text
                string BATCHNO = "1";
                int BIN_ID = Convert.ToInt32(objterms.BIN_ID);
                string BIN_TYPE = objterms.BIN_TYPE;
                string GRNREF = objterms.GRNREF;
                int COMPANYID1 = CID;
                int locationID = LID;
                decimal TAXAMT = Convert.ToDecimal(0.0);
                decimal TAXPER = Convert.ToDecimal(0.0);
                decimal PROMOTIONAMT = Convert.ToDecimal(10.00);
                decimal OVERHEADAMOUNT = Convert.ToDecimal(0.000);
                DateTime EXPIRYDATE = DateTime.Now;
                string SWITCH1 = "0".ToString();
                string remarks = Items.Remarks;
                int DelFlag = 0;
                string ITEMID = "1";
                //remarks sahir
                if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == locationID && p.MyProdID == ProdID).Count() > 0)
                {
                    ICTR_DT_Sales objICTR_DT = DB.ICTR_DT_Sales.Single(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == locationID && p.MyProdID == ProdID);

                    objICTR_DT.MyProdID = ProdID;
                    objICTR_DT.REFTYPE = REFTYPE;
                    objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                    objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                    objICTR_DT.MYSYSNAME = objterms.MYSYSNAME;
                    objICTR_DT.JOID = 1;
                    objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                    objICTR_DT.ACTIVITYID = ACTIVITYID;
                    objICTR_DT.DESCRIPTION = DESCRIPTION;
                    objICTR_DT.UOM = UOM;
                    objICTR_DT.QUANTITY = QUANTITY;
                    objICTR_DT.UNITPRICE = UNITPRICE;
                    objICTR_DT.AMOUNT = AMOUNT;
                    objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                    objICTR_DT.BATCHNO = BATCHNO;
                    objICTR_DT.BIN_ID = BIN_ID;
                    objICTR_DT.BIN_TYPE = BIN_TYPE;
                    objICTR_DT.GRNREF = GRNREF;
                    objICTR_DT.DISPER = 1;
                    objICTR_DT.DISAMT = 0;
                    objICTR_DT.TAXAMT = TAXAMT;
                    objICTR_DT.TAXPER = TAXPER;
                    objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                    objICTR_DT.GLPOST = objterms.GLPOST;
                    objICTR_DT.GLPOST1 = objterms.GLPOST1;
                    objICTR_DT.GLPOSTREF1 = objterms.GLPOSTREF1;
                    objICTR_DT.GLPOSTREF = objterms.GLPOSTREF;
                    objICTR_DT.ICPOST = objterms.ICPOST;
                    objICTR_DT.ICPOSTREF = objterms.ICPOSTREF;
                    objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                    objICTR_DT.COMPANYID = COMPANYID1;
                    objICTR_DT.SWITCH1 = SWITCH1;
                    objICTR_DT.ACTIVE = true;
                    objICTR_DT.DelFlag = DelFlag;
                    objICTR_DT.Stutas = objterms.Stutas;
                    objICTR_DT.Remarks = remarks;


                    DB.SaveChanges();
                }
                else
                {
                    ICTR_DT_Sales objICTR_DT = new ICTR_DT_Sales();
                    objICTR_DT.TenentID = TenentID;
                    objICTR_DT.MYTRANSID = Mytransid;
                    objICTR_DT.locationID = locationID;
                    objICTR_DT.TerminalID = objterms.TerminalID;
                    var ListICTR_DT = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == Mytransid && p.TenentID == TenentID && p.locationID == LID);
                    int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
                    objICTR_DT.MYID = MYIDDT;
                    objICTR_DT.MyProdID = ProdID;
                    objICTR_DT.REFTYPE = objterms.RefType;
                    objICTR_DT.REFSUBTYPE = objterms.RefSubtype;

                    objICTR_DT.PERIOD_CODE = objterms.Period_code;
                    objICTR_DT.MYSYSNAME = objterms.MYSYSNAME;
                    objICTR_DT.JOID = 1;
                    objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                    objICTR_DT.ACTIVITYID = ACTIVITYID;
                    objICTR_DT.DESCRIPTION = DESCRIPTION;
                    objICTR_DT.UOM = UOM;
                    objICTR_DT.QUANTITY = QUANTITY;
                    objICTR_DT.UNITPRICE = UNITPRICE;
                    objICTR_DT.AMOUNT = AMOUNT;
                    objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                    objICTR_DT.BATCHNO = BATCHNO;
                    objICTR_DT.BIN_ID = BIN_ID;
                    objICTR_DT.BIN_TYPE = BIN_TYPE;
                    objICTR_DT.GRNREF = GRNREF;
                    objICTR_DT.DISPER = 1;
                    objICTR_DT.DISAMT = 0;
                    objICTR_DT.TAXAMT = TAXAMT;
                    objICTR_DT.TAXPER = TAXPER;
                    objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                    objICTR_DT.GLPOST = objterms.GLPOST;
                    objICTR_DT.GLPOST1 = objterms.GLPOST1;
                    objICTR_DT.GLPOSTREF1 = objterms.GLPOSTREF1;
                    objICTR_DT.GLPOSTREF = objterms.GLPOSTREF;
                    objICTR_DT.ICPOST = objterms.ICPOST;
                    objICTR_DT.ICPOSTREF = objterms.ICPOSTREF;
                    objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                    objICTR_DT.COMPANYID = COMPANYID1;
                    objICTR_DT.SWITCH1 = SWITCH1;
                    objICTR_DT.ACTIVE = true;
                    objICTR_DT.DelFlag = DelFlag;
                    objICTR_DT.Stutas = objterms.Stutas;
                    if (remarks != null)
                    {
                        objICTR_DT.Remarks = remarks;
                    }
                    DB.ICTR_DT_Sales.AddObject(objICTR_DT);
                    DB.SaveChanges();
                }

            }

            foreach (SalesItemList Items in dgrvSalesItemList)
            {
                int ProdID = Convert.ToInt32(Items.itemID);
                string Periodcode = "201701";
                string MySysName = "SAL";
                //int UOM = 1;
                int UOM = Convert.ToInt32(DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.MYPRODID == ProdID).UOM);
                int SIZECODE = 999999998;
                int COLORID = 999999998;
                int BinID = 999999998;
                string BatchNo = "999999998";
                string Serialize = "1";
                int MYTRANSID = Mytransid;
                int LocationID = LID;
                decimal NewQty = Convert.ToDecimal(1);
                string Reference = "POS";
                string RecodName = "Serialize";
                DateTime ProdDate = DateTime.Now;
                DateTime ExpiryDate = DateTime.Now;
                DateTime LeadDays2Destroy = DateTime.Now;
                string Active = "D";
                bool MinusAllow = false;
                if (DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == ProdID && p.period_code == Periodcode && p.MySysName == MySysName && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).Count() > 0)
                {
                    var List = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == ProdID && p.period_code == Periodcode && p.MySysName == MySysName && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).ToList();
                    foreach (ICIT_BR_TMP item in List)
                    {
                        DB.ICIT_BR_TMP.DeleteObject(item);
                        DB.SaveChanges();
                    }
                }
                ICIT_BR_TMP objICIT_BR_TMP = new ICIT_BR_TMP();
                objICIT_BR_TMP.TenentID = TenentID;
                objICIT_BR_TMP.MyProdID = ProdID;
                objICIT_BR_TMP.period_code = Periodcode;
                objICIT_BR_TMP.MySysName = MySysName;
                objICIT_BR_TMP.UOM = UOM;
                objICIT_BR_TMP.SIZECODE = SIZECODE;
                objICIT_BR_TMP.COLORID = COLORID;
                objICIT_BR_TMP.Bin_ID = BinID;
                objICIT_BR_TMP.BatchNo = BatchNo;
                objICIT_BR_TMP.Serial_Number = Serialize;
                objICIT_BR_TMP.MYTRANSID = MYTRANSID;
                objICIT_BR_TMP.LocationID = LocationID;
                if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.LocationID == LocationID && p.MyProdID == ProdID).Count() == 1)
                {
                    ICIT_BR obj = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.LocationID == LocationID && p.MyProdID == ProdID);
                    objICIT_BR_TMP.OpQty = obj.OpQty;
                    objICIT_BR_TMP.OnHand = obj.OnHand;
                    objICIT_BR_TMP.QtyOut = obj.QtyOut;
                    objICIT_BR_TMP.QtyConsumed = obj.QtyConsumed;
                    objICIT_BR_TMP.QtyReserved = obj.QtyReserved;
                    objICIT_BR_TMP.QtyReceived = obj.QtyReceived;
                    objICIT_BR_TMP.MinQty = obj.MinQty;
                    objICIT_BR_TMP.MaxQty = obj.MaxQty;
                    objICIT_BR_TMP.LeadTime = obj.LeadTime;
                }
                else
                {
                    objICIT_BR_TMP.OpQty = 0;
                    objICIT_BR_TMP.OnHand = 0;
                    objICIT_BR_TMP.QtyOut = 0;
                    objICIT_BR_TMP.price = 0;
                    objICIT_BR_TMP.QtyConsumed = 0;
                    objICIT_BR_TMP.QtyReserved = 0;
                    objICIT_BR_TMP.MinQty = 0;
                    objICIT_BR_TMP.QtyReceived = 0;
                    objICIT_BR_TMP.MaxQty = 0;
                    objICIT_BR_TMP.LeadTime = 0;
                }
                objICIT_BR_TMP.NewQty = NewQty;
                objICIT_BR_TMP.Reference = Reference;
                objICIT_BR_TMP.RecodName = RecodName;
                objICIT_BR_TMP.ProdDate = ProdDate;
                objICIT_BR_TMP.ExpiryDate = ExpiryDate;
                objICIT_BR_TMP.LeadDays2Destroy = LeadDays2Destroy;
                objICIT_BR_TMP.Active = Active;
                objICIT_BR_TMP.CRUP_ID = CRUP_ID;
                objICIT_BR_TMP.MinusAllow = MinusAllow;
                DB.ICIT_BR_TMP.AddObject(objICIT_BR_TMP);
                DB.SaveChanges();
            }

            foreach (SalesItemList Items in dgrvSalesItemList)
            {
                string itemid = Items.itemID;
                DateTime trnsDates = DateTime.Now;
                string MySysNames = "SAL";


                int ProdID = Convert.ToInt32(Items.itemID);
                int MYID = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == LID).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == Mytransid && p.locationID == LID).Max(p => p.MYID) + 1) : 1;
                string itNames = Items.Items_Name;
                //uom sahir
                int Uom = Convert.ToInt32(DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.MYPRODID == ProdID).UOM);

                double taxapply = Convert.ToDouble(Items.taxapply);
                int kitchendisplay = Convert.ToInt32(Items.kitchendisplay);
                string CustItemCode = Items.CustItemCode;
                int customer = Items.CustomerID;
                int prodid = Convert.ToInt32(itemid);
                string Prodname = Items.Items_Name;
                // string REFTYPE = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID).RefType; //"LF";
                //string REFSUBTYPE = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID).RefSubtype;//"LF";
                // int JOBORDERDTMYID = 1;
                //int ACTIVITYID = 0;
                string DESCRIPTION = itNames;
                string UOM = Uom.ToString();
                decimal QUANTITY = Items.Qty;
                decimal UNITPRICE = Items.Price;//
                decimal AMOUNT = QUANTITY * UNITPRICE;//lblTotalCurrency.Text
                                                      // string BATCHNO = DB.POSLocSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID).BatchNo; ;
                                                      //int BIN_ID = Convert.ToInt32(DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID).BIN_ID);
                                                      //string BIN_TYPE = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID).BIN_TYPE;
                                                      //string GRNREF = DB.POSTermSetups.Single(p => p.TenentID == TenentID && p.LocationID == LID && p.TerminalID == TerminalID).GRNREF;
                int COMPANYID1 = CID;
                int TID = TenentID;
                int LOID = LID;
                // int Transid = Convert.ToInt32(DB.POSTermSetups.Single(p => p.TenentID == TID && p.LocationID == LOID && p.TerminalID == TerminalID).transid);

                // int transsubid = Convert.ToInt32(DB.POSTermSetups.Single(p => p.TenentID == TID && p.LocationID == LOID && p.TerminalID == TerminalID).transsubid);
                int MYTRANSID = Mytransid;
                string Reference = "POS";
                DateTime trnsDate = DateTime.Now;
                // string MySysName = DB.POSTermSetups.Single(p => p.TenentID == TID && p.LocationID == LOID && p.TerminalID == TerminalID).MYSYSNAME; //"SAL";
                int MyProdID = Convert.ToInt32(Items.itemID);
                TBLPRODUCT obj = DB.TBLPRODUCTs.Single(p => p.MYPRODID == MyProdID && p.TenentID == TID);
                Boolean MultiUOM = Convert.ToBoolean(obj.MultiUOM);
                Boolean MultiColor = Convert.ToBoolean(obj.MultiColor);
                Boolean Perishable = Convert.ToBoolean(obj.Perishable);
                Boolean MultiSize = Convert.ToBoolean(obj.MultiSize);
                Boolean Serialized = Convert.ToBoolean(obj.Serialized);
                Boolean MultiBinStore = Convert.ToBoolean(obj.MultiBinStore);
                bool flag2 = false;
                bool multiuom = Convert.ToBoolean(DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.MYPRODID == ProdID).MultiUOM);
                bool multi = Convert.ToBoolean(multiuom);
                decimal QTY = Convert.ToDecimal(QUANTITY);
                int DT_UOM = Convert.ToInt32(UOM);
                if (multi == true)
                {
                    int BaseUOM = Convert.ToInt32(UOM);
                    bool checkExpRatio = Convert.ToBoolean(DB.ICUOMs.Single(p => p.TenentID == TenentID && p.UOM == BaseUOM).CalculateAspectRatio);
                    var MultiConvList = DB.ICITEMS_PRICE.Where(p => p.TenentID == TenentID && p.MYPRODID == ProdID).ToList();
                    if (checkExpRatio == true)
                    {
                        decimal BaseQTYY = getConversionBaseQty(BaseUOM, DT_UOM, QTY);

                        foreach (var MuItem in MultiConvList)
                        {
                            decimal newQty = QTY;

                            int ToUOM = Convert.ToInt32(MuItem.UOM);
                            if (ToUOM != DT_UOM)
                            {
                                if (ToUOM == BaseUOM)
                                {
                                    newQty = BaseQTYY;
                                }
                                else
                                {
                                    newQty = getConversionToQty(BaseUOM, ToUOM, BaseQTYY);
                                }
                            }
                            flag2 = postprocess(TID, LID, Transid, transsubid, MYTRANSID, MYID, QUANTITY, Reference, trnsDate, "SAL", MyProdID, ICPOST, UNITPRICE, obj, DT_UOM);
                        }
                    }
                    else
                    {
                        flag2 = postprocess(TID, LID, Transid, transsubid, MYTRANSID, MYID, QUANTITY, Reference, trnsDate, "SAL", MyProdID, ICPOST, UNITPRICE, obj, DT_UOM);
                    }
                }
                else
                {
                    flag2 = postprocess(TID, LID, Transid, transsubid, MYTRANSID, MYID, QUANTITY, Reference, trnsDate, "SAL", MyProdID, ICPOST, UNITPRICE, obj, DT_UOM);
                }
                //bool flag1 = Classes.EcommAdminClass.postprocess(TID, LID, Transid, Transsubid, MYTRANSID, MYID, QUANTITY, Reference, trnsDate, MySysName, MyProdID, ICPOST, UNITPRICE, obj, UOM1);
                if (flag2 == false)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One of the Posting Parameter is Blank/Null/Zero!')", true);

                }
                // return true;
            }


            return true;
        }

        protected void listproduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Use your column value below
                string str = e.Row.Cells[4].Text.ToString();
                // or you can try str == String.Empty in below condition as necessary.
                if (String.IsNullOrEmpty(str))
                {
                    e.Row.Visible = false;
                }
            }
        }
        public void PostICIT_BR(int TenentID, int Location, int MYTRANSID, int MYPRODID, int UOM, string period_code, decimal NewQty, decimal UnitCost, string Bin_Per, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {
            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;


            ICIT_BR objICIT_BR = new ICIT_BR();
            period_code = "0";
            if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MYPRODID && p.LocationID == Location && p.Active == "Y").Count() > 0)
            {


                objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MYPRODID && p.LocationID == Location && p.Active == "Y");
                OPQTY = Convert.ToDecimal(objICIT_BR.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR.QtyReceived);

                //------------------ OpQtyBeh   ---------------------------------//
                if (objsubtype.OpQtyBeh == "+")
                {
                    OPQTY = OPQTY + NewQty;
                }
                else if (objsubtype.OpQtyBeh == "-")
                {
                    OPQTY = OPQTY - NewQty;
                }
                else { }

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);
            }
            else
            {

                objICIT_BR.MySysName = objsubtype.MYSYSNAME;
                objICIT_BR.UnitCost = UnitCost;

                //------------------ OpQtyBeh   ---------------------------------//
                if (objsubtype.OpQtyBeh == "+")
                {
                    OPQTY = OPQTY + NewQty;
                }
                else if (objsubtype.OpQtyBeh == "-")
                {
                    OPQTY = OPQTY - NewQty;
                }
                else { }

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                ONHANDTOTAL = ONHANDQTY - NewQty;//  (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);
                RoleFlag = true;

            }

            objICIT_BR.TenentID = TenentID;
            objICIT_BR.MyProdID = MYPRODID;
            objICIT_BR.period_code = period_code;


            //check uom
            objICIT_BR.UOM = UOM;
            objICIT_BR.LocationID = Location;
            objICIT_BR.MYTRANSID = MYTRANSID;
            objICIT_BR.Bin_Per = Bin_Per;
            objICIT_BR.OpQty = OPQTY;
            objICIT_BR.OnHand = ONHANDTOTAL;
            objICIT_BR.QtyOut = QtyOut;
            objICIT_BR.QtyConsumed = QtyConsumed;
            objICIT_BR.QtyReserved = QtyReserved;
            objICIT_BR.QtyReceived = QtyReceived;
            objICIT_BR.Reference = Reference;
            objICIT_BR.Active = Active;
            objICIT_BR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.ICIT_BR.AddObject(objICIT_BR);
            }
            DB.SaveChanges();

            if (DB.TBLPRODUCTs.Where(p => p.TenentID == TenentID && p.UOM == UOM && p.MYPRODID == MYPRODID).Count() == 1)
            {
                TBLPRODUCT obj = DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.UOM == UOM && p.MYPRODID == MYPRODID);
                obj.QTYINHAND = ONHANDTOTAL;
                DB.SaveChanges();
            }
            DB.ICIT_BR.Detach(objICIT_BR);
            objICIT_BR = null;

        }

        public void PostICIT_BR_SIZECOLOR(int TenentID, int Location, int MYTRANSID, int MyProdID, int UOM, string period_code, int SIZECODE, int COLORID, decimal NewQty, decimal UnitCost, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;
            decimal Qtyofoled = 0;
            decimal Qtyofnew = 0;

            if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
            {
                objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                OPQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReceived);


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //check if toTenentID != null

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                //----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_SIZECOLOR.MySysName = "IC";


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //check if toTenentID != null

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                //----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);
                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();
        }


        public void PostICIT_BR_SIZE(int TenentID, int Location, int MYTRANSID, int MyProdID, int UOM, string period_code, int SIZECODE, int COLORID, decimal NewQty, decimal UnitCost, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;

            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;



            if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
            {
                objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                OPQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }



                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_SIZECOLOR.MySysName = objsubtype.MYSYSNAME;
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }



                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);

                RoleFlag = true;
            }


            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();

        }

        public void PostICIT_BR_BIN(int TenentID, int Location, int MYTRANSID, int MyProdID, string MySysName, int UOM, string period_code, decimal NewQty, decimal UnitCost, string Bin_Per, string Reference, string Active, int CRUP_ID, int Bin_ID, tbltranssubtype objsubtype)
        {

            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;
            decimal QTYOUTNEW = 0;
            decimal QTYINNEW = 0;
            ICIT_BR_BIN objICIT_BR_BIN = new ICIT_BR_BIN();



            if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
            {
                objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                OPQTY = Convert.ToDecimal(objICIT_BR_BIN.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_BIN.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_BIN.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_BIN.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_BIN.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_BIN.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;

                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    QtyOut = QtyOut + NewQty;

                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_BIN.MySysName = MySysName;

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }



                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);

                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_BIN.TenentID = TenentID;
            objICIT_BR_BIN.MyProdID = MyProdID;
            objICIT_BR_BIN.period_code = period_code;
            objICIT_BR_BIN.Bin_ID = Bin_ID;
            objICIT_BR_BIN.UOM = UOM;
            objICIT_BR_BIN.LocationID = Location;
            objICIT_BR_BIN.MYTRANSID = MYTRANSID;
            objICIT_BR_BIN.OpQty = OPQTY;
            objICIT_BR_BIN.OnHand = ONHANDTOTAL;
            objICIT_BR_BIN.QtyOut = QtyOut;
            objICIT_BR_BIN.QtyConsumed = QtyConsumed;
            objICIT_BR_BIN.QtyReserved = QtyReserved;
            objICIT_BR_BIN.QtyReceived = QtyReceived;
            objICIT_BR_BIN.MinQty = 0;
            objICIT_BR_BIN.MaxQty = 0;
            objICIT_BR_BIN.LeadTime = 0;
            objICIT_BR_BIN.Reference = Reference;
            objICIT_BR_BIN.Active = Active;
            objICIT_BR_BIN.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_BIN.AddObject(objICIT_BR_BIN);
            DB.SaveChanges();


        }

        public bool postprocess(int TenentID = 0, int LID = 0, int transid = 0, int trnassubid = 0, int MYTRANSID = 0, int MYID = 0, decimal QTY = 0, string Reference = null, DateTime? trnsDate = null, string MySysName = null, int MyProdID = 0, string ICPOST = null, decimal UnitCost = 0, TBLPRODUCT objTBLPRODUCT = null, int UOM = 0)//parimal  ICTR_DT objDT, ICTR_HD Objhd,
        {
            //check perameter value is not null,space and  zero
            if (TenentID != null && TenentID != 0 && LID != null && LID != 0 && UOM != null && UOM != 0 && transid != null && transid != 0 && trnassubid != null && trnassubid != 0 && MYTRANSID != null && MYTRANSID != 0 && QTY != null && QTY != 0 && trnsDate != null && MySysName != null && MySysName != "" && MyProdID != null && MyProdID != 0 && ICPOST != null && ICPOST != "" && UnitCost != null && UnitCost != 0 && objTBLPRODUCT != null)//&& Reference != null && Reference != ""
            {

                Reference = "";
                if (ICPOST != "0")
                {
                    //objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == MyProdID && p.TenentID == TenentID);
                    Boolean MultiUOM = Convert.ToBoolean(objTBLPRODUCT.MultiUOM);
                    Boolean MultiColor = Convert.ToBoolean(objTBLPRODUCT.MultiColor);
                    Boolean Perishable = Convert.ToBoolean(objTBLPRODUCT.Perishable);
                    Boolean MultiSize = Convert.ToBoolean(objTBLPRODUCT.MultiSize);
                    Boolean Serialized = Convert.ToBoolean(objTBLPRODUCT.Serialized);
                    Boolean MultiBinStore = Convert.ToBoolean(objTBLPRODUCT.MultiBinStore);

                    tbltranssubtype objsubtype = DB.tbltranssubtypes.Single(p => p.TenentID == TenentID && p.transid == transid && p.transsubid == trnassubid);


                    decimal nwQTY = 0;
                    string Bin_Per = "N";
                    string Active = "Y";
                    int CRUP_ID = 99999999;
                    int SIZECODE = 999999998;

                    string period_code = Pidalcode(trnsDate, TenentID, MySysName).ToString();
                    if (MultiUOM != Convert.ToBoolean(1))
                    {
                        PostICIT_BR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, QTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, objsubtype);
                    }

                    if (MultiColor == Convert.ToBoolean(1))
                    {
                        List<ICIT_BR_TMP> listmulticoler = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == MYTRANSID && p.MySysName == MySysName && p.MyProdID == MyProdID && p.UOM == UOM && p.Active == "D" && p.COLORID != 999999998 && p.RecodName == "MultiColor" && p.TenentID == TenentID).ToList();
                        foreach (ICIT_BR_TMP ItemColor in listmulticoler)
                        {
                            int COLORID = ItemColor.COLORID;
                            Reference = ItemColor.Reference.ToString();
                            Active = "Y";
                            SIZECODE = ItemColor.SIZECODE;
                            UOM = ItemColor.UOM;
                            nwQTY = Convert.ToDecimal(ItemColor.NewQty);

                            PostICIT_BR_SIZECOLOR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, SIZECODE, COLORID, nwQTY, UnitCost, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }

                    if (MultiSize == Convert.ToBoolean(1))
                    {
                        List<ICIT_BR_TMP> listmultisize = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "MultiSize" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();

                        foreach (ICIT_BR_TMP Itemsize in listmultisize)
                        {
                            int COLORID = Itemsize.COLORID;
                            Reference = Itemsize.Reference.ToString();
                            Active = "Y";
                            SIZECODE = Itemsize.SIZECODE;
                            UOM = Itemsize.UOM;
                            nwQTY = Convert.ToDecimal(Itemsize.NewQty);

                            PostICIT_BR_SIZE(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, SIZECODE, COLORID, nwQTY, UnitCost, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }
                    if (MultiUOM == Convert.ToBoolean(1))
                    {
                        //List<Database.ICIT_BR_TMP> listMUOMLIST = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "UOM" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();
                        //foreach (Database.ICIT_BR_TMP ItemMUOM in listMUOMLIST)
                        //{
                        //    int COLORID = ItemMUOM.COLORID;
                        //    Reference = ItemMUOM.Reference.ToString();
                        //    Active = "Y";
                        //    SIZECODE = ItemMUOM.SIZECODE;
                        //    UOM = ItemMUOM.UOM;
                        //    nwQTY = Convert.ToDecimal(ItemMUOM.NewQty);

                        nwQTY = QTY;
                        PostICIT_BR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, nwQTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, objsubtype);
                        //}
                    }

                    if (MultiBinStore == Convert.ToBoolean(1))
                    {
                        List<ICIT_BR_TMP> listBin123 = DB.ICIT_BR_TMP.Where(p => p.MyProdID == MyProdID && p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.UOM == UOM && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "MultiBIN" && p.Bin_ID != 999999998).ToList();
                        foreach (ICIT_BR_TMP ItemMUOM in listBin123)
                        {
                            int COLORID = ItemMUOM.COLORID;
                            Reference = ItemMUOM.Reference.ToString();
                            Active = "Y";
                            int Bin_ID = Convert.ToInt32(ItemMUOM.Bin_ID);
                            SIZECODE = ItemMUOM.SIZECODE;
                            UOM = ItemMUOM.UOM;
                            nwQTY = Convert.ToDecimal(ItemMUOM.NewQty);
                            PostICIT_BR_BIN(TenentID, LID, MYTRANSID, MyProdID, MySysName, UOM, period_code, nwQTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, Bin_ID, objsubtype);
                        }
                    }

                    if (Perishable == Convert.ToBoolean(1))
                    {
                        List<ICIT_BR_TMP> listperishibal = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "Perishable" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();
                        foreach (ICIT_BR_TMP Itemperishibal in listperishibal)
                        {
                            int COLORID = Itemperishibal.COLORID;
                            Reference = Itemperishibal.Reference.ToString();
                            Active = "Y";
                            int Bin_ID = Convert.ToInt32(Itemperishibal.Bin_ID);
                            SIZECODE = Itemperishibal.SIZECODE;
                            UOM = Itemperishibal.UOM;
                            string BatchNo = Itemperishibal.BatchNo.ToString();
                            DateTime ProdDate = Convert.ToDateTime(Itemperishibal.ProdDate);
                            DateTime ExpiryDate = Convert.ToDateTime(Itemperishibal.ExpiryDate);
                            DateTime LeadDays2Destroy = Convert.ToDateTime(Itemperishibal.LeadDays2Destroy);

                            PostICIT_BR_Perishable(TenentID, MyProdID, period_code, MySysName, UOM, BatchNo, LID, MYTRANSID, QTY, ProdDate, ExpiryDate, LeadDays2Destroy, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }

                    if (Serialized == Convert.ToBoolean(1))
                    {
                        List<ICIT_BR_TMP> listSerial = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID && p.UOM == UOM && p.Active == "D" && p.MySysName == MySysName && p.MyProdID == MyProdID && p.Serial_Number != "NO" && p.RecodName == "Serialize").ToList();
                        foreach (ICIT_BR_TMP ItemSerial in listSerial)
                        {
                            int COLORID = ItemSerial.COLORID;
                            Reference = ItemSerial.Reference.ToString();
                            Active = "Y";
                            SIZECODE = ItemSerial.SIZECODE;
                            string Serial_Number = ItemSerial.Serial_Number.ToString();
                            string Flag_GRN_GTN = "N";
                            string UOM1 = ItemSerial.UOM.ToString();
                            bool MinusAllow = Convert.ToBoolean(ItemSerial.MinusAllow);
                            PostICIT_BR_Serialize(TenentID, MyProdID, period_code, MySysName, UOM1, Serial_Number, LID, MYTRANSID, Flag_GRN_GTN, Active, CRUP_ID, objsubtype, MinusAllow);
                        }
                    }

                    //objDT.ICPOST = "0";
                    //DB.SaveChanges();

                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public void PostICIT_BR_Serialize(int TenentID, int MyProdID, string period_code, string MySysName, string UOM, string Serial_Number, int Location, int MyTransID, string Flag_GRN_GTN, string Active, int CRUP_ID, tbltranssubtype objsubtype, bool MinusAllow)
        {

            //if (objsubtype.MYSYSNAME == MySysName)
            //{
            if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            {
                ICIT_BR_Serialize objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);

                objICIT_BR_Serialize.Serial_Number = Serial_Number;
                objICIT_BR_Serialize.Active = "N";
                objICIT_BR_Serialize.MinusAllow = MinusAllow;

                DB.SaveChanges();
            }
            else
            {
                ICIT_BR_Serialize objICIT_BR_Serialize = new ICIT_BR_Serialize();
                objICIT_BR_Serialize.MySysName = MySysName;
                objICIT_BR_Serialize.TenentID = TenentID;
                objICIT_BR_Serialize.MyProdID = MyProdID;
                objICIT_BR_Serialize.period_code = period_code;
                objICIT_BR_Serialize.UOM = UOM;
                objICIT_BR_Serialize.Serial_Number = Serial_Number;
                objICIT_BR_Serialize.LocationID = Location;
                objICIT_BR_Serialize.Flag_GRN_GTN = Flag_GRN_GTN;
                objICIT_BR_Serialize.MyTransID = MyTransID;
                objICIT_BR_Serialize.CRUP_ID = CRUP_ID;
                if (MinusAllow == true)
                {
                    objICIT_BR_Serialize.Active = "N";
                }
                else
                {
                    objICIT_BR_Serialize.Active = "Y";
                }

                objICIT_BR_Serialize.MinusAllow = MinusAllow;
                DB.ICIT_BR_Serialize.AddObject(objICIT_BR_Serialize);

                DB.SaveChanges();

            }
        }


        public void PostICIT_BR_Perishable(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, string BatchNo, int Location, int MYTRANSID, decimal NewQty, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            bool RoleFlag = false;

            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;

            ICIT_BR_Perishable objICIT_BR_Perishable = new ICIT_BR_Perishable();

            if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
            {
                objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                OPQTY = Convert.ToDecimal(objICIT_BR_Perishable.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_Perishable.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_Perishable.QtyOut);
                //QtyConsumed= Convert.ToInt32(objICIT_BR_Perishable)
                QtyReceived = Convert.ToDecimal(objICIT_BR_Perishable.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }
                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }



                //----------------- QtyAtDestination  -------------------------------//

                if (objsubtype.QtyAtDestination == "+")
                {
                    QtyReceived = QtyReceived + NewQty;

                }
                else if (objsubtype.QtyAtDestination == "-")
                {
                    QtyOut = QtyOut + NewQty;

                }
                else
                { }



                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut);//+ QtyConsumed


            }
            else
            {

                objICIT_BR_Perishable.MySysName = MySysName;


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }
                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }



                //----------------- QtyAtDestination  -------------------------------//

                if (objsubtype.QtyAtDestination == "+")
                {
                    QtyReceived = QtyReceived + NewQty;

                }
                else if (objsubtype.QtyAtDestination == "-")
                {
                    QtyOut = QtyOut + NewQty;

                }
                else
                { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = ONHANDQTY - NewQty;// (OPQTY + QtyReceived) - (QtyOut);//+ QtyConsumed
                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_Perishable.TenentID = TenentID;
            objICIT_BR_Perishable.MyProdID = MyProdID;
            objICIT_BR_Perishable.period_code = period_code;
            objICIT_BR_Perishable.UOM = UOM;
            objICIT_BR_Perishable.BatchNo = BatchNo;
            objICIT_BR_Perishable.LocationID = Location;
            objICIT_BR_Perishable.MYTRANSID = MYTRANSID;
            objICIT_BR_Perishable.OpQty = OPQTY;
            objICIT_BR_Perishable.OnHand = ONHANDTOTAL;
            objICIT_BR_Perishable.QtyOut = QtyOut;
            objICIT_BR_Perishable.QtyReceived = QtyReceived;
            objICIT_BR_Perishable.ProdDate = ProdDate;
            objICIT_BR_Perishable.ExpiryDate = ExpiryDate;
            objICIT_BR_Perishable.LeadDays2Destroy = LeadDays2Destroy;
            objICIT_BR_Perishable.Reference = Reference;
            objICIT_BR_Perishable.Active = Active;
            objICIT_BR_Perishable.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_Perishable.AddObject(objICIT_BR_Perishable);
            DB.SaveChanges();

        }



        public int getPaymentid(int TenentID, string sales_id)
        {
            int ID12 = 1;
            string sqlIT = "select * from ICTR_sales_payment where TenentID=" + TenentID + " and sales_id='" + sales_id + "'  ";
            DataTable dt1 = DataCon.GetDataTable(sqlIT);

            if (dt1.Rows.Count > 0)
            {
                string sql123 = " select MAX(ID) from ICTR_sales_payment where TenentID=" + TenentID + " and sales_id='" + sales_id + "' ";
                DataTable dt12 = DataCon.GetDataTable(sql123);
                if (dt12.Rows.Count > 0)
                {
                    int id = Convert.ToInt32(dt12.Rows[0][0]);
                    ID12 = id + 1;
                }
            }
            return ID12;
        }


        public static void Update_ShiftSales_DayClose(int TenentID, int Userid, int LID, string Shopid, int ShiftID, decimal ShiftSales)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            // string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DAL.Get_DayClose(TenentID, Userid, LID, ShiftID, Date);
            if (dt5.Rows.Count > 0)
            {
                decimal ShiftSalesold = Convert.ToDecimal(dt5.Rows[0]["ShiftSales"]);
                decimal TShiftSales = ShiftSales + ShiftSalesold;

                string sql1 = " Update DayClose set ShiftSales=" + TShiftSales + " where TenentID=" + TenentID + " and ShiftID = " + ShiftID + " and LocationID = " + LID + " and convert(Date,Date) = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);

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

        public static void Update_VoucharAMT_DayClose(int TenentID, int Userid, int LID, string Shopid, int ShiftID, decimal VoucharAMT)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            //string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DAL.Get_DayClose(TenentID, Userid, LID, ShiftID, Date);
            if (dt5.Rows.Count > 0)
            {
                decimal VoucharAMTold = Convert.ToDecimal(dt5.Rows[0]["VoucharAMT"]);
                VoucharAMT = VoucharAMT + VoucharAMTold;

                string sql1 = " Update DayClose set VoucharAMT=" + VoucharAMT + " where TenentID=" + TenentID + "  and LocationID = " + LID + " and ShiftID = " + ShiftID + " and Convert(Date,Date) = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, LID, Shopid, ShiftID, 0);
            }
        }

        public static void Update_ChequeAMT_DayClose(int TenentID, int Userid, int LID, string Shopid, int ShiftID, decimal ChequeAMT)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            // string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DAL.Get_DayClose(TenentID, Userid, LID, ShiftID, Date);
            if (dt5.Rows.Count > 0)
            {
                decimal ChequeAMTold = Convert.ToDecimal(dt5.Rows[0]["ChequeAMT"]);
                ChequeAMT = ChequeAMT + ChequeAMTold;

                string sql1 = " Update DayClose set ChequeAMT=" + ChequeAMT + " where TenentID=" + TenentID + "  and LocationID = " + LID + " and ShiftID = " + ShiftID + " and Convert(Date,Date) = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);

                Update_ShiftCIH_DayClose(TenentID, Userid, LID, Shopid, ShiftID, 0);
            }
        }


        public static void Update_ShiftCIH_DayClose(int TenentID, int Userid, int LID, string Shopid, int ShiftID, decimal payamount)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            decimal todayCash = 0;

            string Condition = "where TenentID=" + TenentID + "  and LocationID = " + LID + " and ShiftID = " + ShiftID + " and Convert(Date,Date) = '" + Date + "' ";
            string sql = "select ((OpAMT + ShiftSales + VoucharAMT + ChequeAMT) - (ShiftReturn  + ExpAMT  + AMTDelivered + Shiftpurchase  )) as TodayCash from DayClose " + Condition;
            DataTable dt = DataCon.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                todayCash = Convert.ToDecimal(dt.Rows[0]["TodayCash"]);

            }

            // string sql5 = "Select * from DayClose where TenentID=" + TenentID + " and UserID = '" + Userid + "' and TrmID = '" + Shopid + "' and ShiftID = " + ShiftID + " and Date = '" + Date + "' ";
            DataTable dt5 = DAL.Get_DayClose(TenentID, Userid, LID, ShiftID, Date);
            if (dt5.Rows.Count > 0)
            {
                decimal TotalCash = todayCash + payamount;
                string sql1 = " Update DayClose set ShiftCIH=" + TotalCash + " where TenentID=" + TenentID + "  and LocationID = " + LID + " and ShiftID = " + ShiftID + " and Convert(Date,Date) = '" + Date + "'  ";
                DataCon.ExecuteSQL(sql1);
            }
        }


        public bool payment_itemsave(int TenentID, int LocationID, decimal payamount, decimal changeamount, decimal dueamount, string salesdate, string Comment, string PaymentStutas, string trno, string invoiceNO, string Customer, int CustomerID, string DiscountTotaloverall, string overalldisRate, string Delivery_Cahrge, string UserName, string Shopid, int Userid, int ShiftID, List<PaymentData> GridPayment, String Payment)
        {
            try
            {
                DAL.Delete_Payment(TenentID, int.Parse(trno), LocationID);
                DAL.Delete_Voucher(TenentID, trno, LocationID);

                DateTime sales_date = Convert.ToDateTime(salesdate);
                salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
                // string payamount        = lblTotalPayable.Text;
                //  string changeamount     = "0";
                //string due              =  "0";
                string vat = "0";
                string vatRate = "0";

                if (GridPayment.Count() > 0)
                {
                    ClsVouchers v = new ClsVouchers();
                    int flag = 0;
                    int rows = 0;
                    foreach (PaymentData items in GridPayment)
                    {

                        //string payment_type = items.payment_type;
                        //string Reffrance = items.Reffrance_NO;
                        //decimal payment_amount = Convert.ToDecimal(items.payment_amount);
                        //dueamount = payamount - payment_amount;
                        int ID = getPaymentid(TenentID, trno);
                        string payment_type = items.payment_type;
                        DataTable paymentdt = DAL.Get_PaymentTypename(TenentID, payment_type);
                        string payment_mode = paymentdt.Rows[0]["PaymentMethod"].ToString();

                        string Reffrance = items.Reffrance_NO;
                        decimal payment_amount = Convert.ToDecimal(items.payment_amount);
                        dueamount = changeamount;

                        string Query = "select * from ICTR_sales_payment where TenentID = " + TenentID + " and sales_id='" + trno + "' and payment_type='" + payment_type + "' and sales_time = '" + DateTime.Now + "' ";
                        DataTable dtQuery = DataCon.GetDataTable(Query);

                        if (dtQuery.Rows.Count < 1)
                        {
                            string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                            //string sqlWin = " insert into ICTR_sales_payment (TenentID,ID, sales_id,return_id, payment_type,Reffrance,payment_amount,change_amount,due_amount, dis, vat, " +
                            //               " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                            //               "  values (" + TenentID + "," + ID + ",'" + trno + "',0,'" + payment_type + "','" + Reffrance + "' , '" + payment_amount + "', '" + changeamount + "', " +
                            //               " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                            //               "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                            // flag = DataCon.ExecuteSQL(sqlWin);
                            bool Status;
                            int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                            DAL.Create_Sale_Payment(TenentID, LocationID, ID, Convert.ToInt32(trno), payment_type, "", payment_amount, changeamount, dueamount, Convert.ToDecimal(DiscountTotaloverall), Convert.ToDecimal(vat),
                             salesdate, int.Parse(CustomerID.ToString()), UserID.ToString(), Comment, Convert.ToInt32(Shopid), Convert.ToDecimal(overalldisRate), Convert.ToDecimal(vatRate), invoiceNO, Customer, Convert.ToDecimal(Delivery_Cahrge), PaymentStutas, Userid.ToString(), ShiftID, out Status);

                            ClsVoucherDetail p = new ClsVoucherDetail();
                            p.Account_ID = int.Parse(CustomerID.ToString());
                            p.Amount = payment_amount;
                            p.PaymentType = payment_type;


                            v.VoucherDetail.Add(p);







                        }



                        if (PaymentStutas != "Pending")
                        {
                            if (payment_mode == "Cash")
                            {
                                decimal ShiftSales = Convert.ToDecimal(payment_amount);
                                Update_ShiftSales_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);
                            }
                            else if (payment_mode == "Gift Card")
                            {
                                decimal VoucharAMT = Convert.ToDecimal(payment_amount);
                                Update_VoucharAMT_DayClose(TenentID, Userid, LID, Shopid, ShiftID, VoucharAMT);
                            }
                            else
                            {
                                decimal ChequeAMT = Convert.ToDecimal(payment_amount);
                                Update_ChequeAMT_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ChequeAMT);
                            }
                        }
                        //sahir for credit
                        //else
                        //{
                        //    decimal ShiftSales = Convert.ToDecimal(payment_amount);
                        //    Update_ShiftSales_DayCloseCredit(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);
                        //}
                    }

                    v.TanentID = TenentID;
                    v.LocationID = LocationID;
                    v.VoucherID = 0;
                    v.VoucherType_ID = 1;
                    v.Account_ID = CustomerID;
                    v.VoucherDate = DateTime.Now;
                    v.ReceiverName = UserName;
                    v.ReferenceNo = "Sale";
                    v.CreatedBy = 1;
                    v.Narrations = Comment;
                    v.VoucherCode = trno;

                    v.ToAccount_ID = CustomerID;
                    v.Amount = payamount;

                    DAL.SaveVoucher(v, false, false);

                    return true;

                }
                else
                {

                    if (Payment == "Cash")
                    {
                        int ID = getPaymentid(TenentID, trno);


                        //string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        //string sql1Win = " insert into ICTR_sales_payment (TenentID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                        //                  " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas) " +
                        //                  "  values (" + TenentID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '" + payamount + "', '" + changeamount + "', " +
                        //                  " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                        //                  "  '" + UserName + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "')";
                        //int flag1 = DataCon.ExecuteSQL(sql1Win);
                        bool Status;
                        int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                        DAL.Create_Sale_Payment(TenentID, LocationID, ID, Convert.ToInt32(trno), Payment, "", payamount, changeamount, dueamount, Convert.ToDecimal(DiscountTotaloverall), Convert.ToDecimal(vat),
                            salesdate, int.Parse(CustomerID.ToString()), UserID.ToString(), Comment, Convert.ToInt32(Shopid), Convert.ToDecimal(overalldisRate), Convert.ToDecimal(vatRate), invoiceNO, Customer, Convert.ToDecimal(Delivery_Cahrge), PaymentStutas, Userid.ToString(), ShiftID, out Status);


                        if (PaymentStutas != "Pending")
                        {
                            decimal ShiftSales = Convert.ToDecimal(payamount);
                            Update_ShiftSales_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);
                        }
                        ClsVouchers v = new ClsVouchers();
                        v.TanentID = TenentID;
                        v.LocationID = LocationID;
                        v.VoucherID = 0;
                        v.VoucherType_ID = 1;
                        v.Account_ID = CustomerID;
                        v.VoucherDate = DateTime.Now;
                        v.ReceiverName = UserName;
                        v.ReferenceNo = "Sale";
                        v.CreatedBy = 1;
                        v.Narrations = Comment;
                        v.VoucherCode = trno;

                        v.ToAccount_ID = CustomerID;
                        v.Amount = payamount;

                        DAL.SaveVoucher(v, false, true);

                        return true;

                    }

                    else if (Payment == "COD")
                    {
                        int ID = getPaymentid(TenentID, trno);


                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                        string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,ShiftID) " +
                                      "  values (" + TenentID + "," + LocationID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '0.00', '0.00', " +
                                      " '" + payamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserID.ToString() + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "'," + ShiftID + ")";
                        int flag1 = DataCon.ExecuteSQL(sql1Win);
                        if (flag1 == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (Payment == "Credit")
                    {
                        int ID = getPaymentid(TenentID, trno);


                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                        string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,ShiftID) " +
                                      "  values (" + TenentID + "," + LocationID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '0.00', '0.00', " +
                                      " '" + payamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserID.ToString() + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "'," + ShiftID + ")";
                        int flag1 = DataCon.ExecuteSQL(sql1Win);

                        //decimal ShiftSales = Convert.ToDecimal(payamount);
                        //Update_ShiftSales_DayCloseCredit(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);

                        ClsVouchers v = new ClsVouchers();
                        v.TanentID = TenentID;
                        v.LocationID = LocationID;
                        v.VoucherID = 0;
                        v.VoucherType_ID = 1;
                        v.Account_ID = CustomerID;
                        v.VoucherDate = DateTime.Now;
                        v.ReceiverName = UserName;
                        v.ReferenceNo = "Sale";
                        v.CreatedBy = 1;
                        v.Narrations = Comment;
                        v.VoucherCode = trno;

                        v.ToAccount_ID = CustomerID;
                        v.Amount = payamount;

                        DAL.SaveVoucher(v, true, true);
                        if (flag1 == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        string UploadDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        int ID = getPaymentid(TenentID, trno);
                        int UserID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                        string sql1Win = " insert into ICTR_sales_payment (TenentID,LocationID,ID, sales_id,return_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                                      " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate,InvoiceNO,Customer,Uploadby ,UploadDate ,SynID,Delivery_Cahrge,PaymentStutas,ShiftID) " +
                                      "  values (" + TenentID + "," + LocationID + "," + ID + ",'" + trno + "',0,'" + Payment + "', '" + payamount + "', '" + changeamount + "', " +
                                      " '" + dueamount + "', '" + DiscountTotaloverall + "', '" + vat + "', '" + salesdate + "', '" + CustomerID + "', " +
                                      "  '" + UserID.ToString() + "','" + Comment + "','POS','" + Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "','" + invoiceNO + "', N'" + Customer + "','" + UserName + "' , '" + UploadDate + "'  , 1 ," + Delivery_Cahrge + ",'" + PaymentStutas + "'," + ShiftID + ")";
                        int flag1 = DataCon.ExecuteSQL(sql1Win);



                        if (PaymentStutas != "Pending")
                        {
                            decimal ShiftSales = Convert.ToDecimal(payamount);
                            Update_ShiftSales_DayClose(TenentID, Userid, LID, Shopid, ShiftID, ShiftSales);
                        }


                        // decimal ShiftSalescredit = Convert.ToDecimal(payamount);
                        // Update_ShiftSales_DayCloseCredit(TenentID, Userid, LID, Shopid, ShiftID, ShiftSalescredit);
                        if (flag1 == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public string get_sales_id(int TenentID)
        {
            string ID = "";

            string sql = "select  *  from ICTR_HD_Sales where TenentID =" + TenentID + " order by MYTRANSID desc";
            DataTable dt = DataCon.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                ID = (Convert.ToDouble(dt.Rows[0]["MYTRANSID"].ToString()) + 1).ToString();
            }
            else
            {
                ID = "1";
            }

            return ID;
        }



        protected void BtnWalkin_Click(object sender, System.EventArgs e)
        {
            BtnOrdertypeMain.Text = "Order: Walk In";
            DrpTablelist.Visible = false;
        }

        protected void BtnTalabat_Click(object sender, System.EventArgs e)
        {
            BtnOrdertypeMain.Text = "Order: Talabat";
            DrpTablelist.Visible = false;
        }

        protected void BtnCarriage_Click(object sender, System.EventArgs e)
        {
            BtnOrdertypeMain.Text = "Order: Carriage";
            DrpTablelist.Visible = false;
        }

        protected void BtnHomeDelevery_Click(object sender, System.EventArgs e)
        {
            BtnOrdertypeMain.Text = "Order: Home Delivery";
            DrpTablelist.Visible = false;
        }

        protected void BtnDainingTable_Click(object sender, System.EventArgs e)
        {
            BtnOrdertypeMain.Text = "Order: Daining";
            DrpTablelist.Visible = true;
        }

        protected void ChIsCredit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (txtcustomer.Text.ToUpper() == "CASH")
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Customer Must be Required...');", true);
                txtcustomer.Focus();
                ChIsCredit.Checked = false;
            }

        }

        List<PaymentDatasale> ListPayment = new List<PaymentDatasale>();

        protected void btnaddpaymenttype_Click(object sender, System.EventArgs e)
        {
            if (drpPayBy.SelectedItem.Text != "0")
            {

                if (ViewState["GridPayment"] != null)
                {
                    ListPayment = ((List<PaymentDatasale>)ViewState["GridPayment"]).ToList();
                }

                panelMsg.Visible = false;
                lblErreorMsg.Text = "";

                if (txtPopupPaidAmount.Text == "" || txtPopupPaidAmount.Text == ".")
                {
                    return;
                }


                decimal Totalpay = Convert.ToDecimal(lblPopupPaidAmount.Text);
                if (lblPaid.Text == string.Empty) { lblPaid.Text = "0"; }
                decimal totalPaid = Convert.ToDecimal(lblPaid.Text);

                decimal rest = (Totalpay - totalPaid);
                decimal Enter = Convert.ToDecimal(txtPopupPaidAmount.Text);

                if (Enter > rest)
                {
                    txtPopupPaidAmount.Focus();
                    txtPopupPaidAmount.Text = (rest).ToString();
                    txtchangepaidamount.Text = (rest).ToString();
                    txtcpaidamount.Text = (rest).ToString();
                    panelMsg.Visible = true;
                    lblErreorMsg.Text = "Plase Enter Less Than " + rest;
                    return;
                }

                if (Totalpay > totalPaid)
                {
                    int IID = Convert.ToInt32(Session["GetMYTRANSID"]);
                    int sales_id = IID;
                    string payment_type = drpPayBy.SelectedItem.ToString().Trim();

                    decimal payment_amount = Convert.ToDecimal(txtPopupPaidAmount.Text);
                    string Reffrance_NO = txtPayReffrance.Text;

                    //  if (payment_type != "CASH" && payment_type != "Cash" && Reffrance_NO == "")
                    //  {
                    //      txtPayReffrance.Focus();
                    //      panelMsg.Visible = true;
                    //      lblrefreq.Visible = true;
                    //      return;
                    //  }
                    if (payment_type != "CASH" && payment_type != "Cash" && Reffrance_NO != "")
                    {
                        lblrefreq.Visible = false;
                    }

                    if (ListPayment.Where(p => p.payment_type == payment_type).Count() < 1)  //If new item
                    {
                        PaymentDatasale Obj = new PaymentDatasale();
                        Obj.invoice = sales_id.ToString();
                        Obj.payment_type = payment_type;
                        if (payment_type == "Cash" && payment_type != "Cash")
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
                    txtchangepaidamount.Text = (Totalpay - sum).ToString();
                    txtcpaidamount.Text = (Totalpay - sum).ToString();
                    txtPayReffrance.Text = "";
                    drpPayBy.SelectedValue = "1";
                    ChangedueCalculation();
                }
                else
                {

                }
            }
            if (lblPopupPaidAmount.Text == lblPaid.Text)
            {
                txtbalance.Text = "0.00";
            }
        }

        public void ChangedueCalculation()
        {
            if (Convert.ToDouble(FTotall.Text) >= Convert.ToDouble(FTotall.Text))
            {
                double changeAmt = Convert.ToDouble(FTotall.Text) - Convert.ToDouble(FTotall.Text);
                changeAmt = Math.Round(changeAmt, 3);
                //txtChangeAmount.Text = changeAmt.ToString();
                //txtDueAmount.Text = "0";
            }
            if (Convert.ToDouble(FTotall.Text) <= Convert.ToDouble(FTotall.Text))
            {
                double changeAmt = Convert.ToDouble(FTotall.Text) - Convert.ToDouble(FTotall.Text);
                changeAmt = Math.Round(changeAmt, 3);
                //txtDueAmount.Text = changeAmt.ToString();
                //txtChangeAmount.Text = "0";
            }
        }

        protected void GridPayment_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            if (e.CommandName == "GridRemove")
            {
                string payment_type = e.CommandArgument.ToString();

                List<PaymentDatasale> ListPayment = new List<PaymentDatasale>();
                ListPayment = ((List<PaymentDatasale>)ViewState["GridPayment"]).ToList();
                if (ListPayment.Where(p => p.payment_type == payment_type).Count() > 0)
                {
                    PaymentDatasale obj = ListPayment.Where(p => p.payment_type == payment_type).FirstOrDefault();
                    ListPayment.Remove(obj);
                    ViewState["GridPayment"] = ListPayment;
                    GridPayment.DataSource = ListPayment;
                    GridPayment.DataBind();
                    decimal Totalpay = Convert.ToDecimal(lblPopupPaidAmount.Text);

                    decimal sum = ListPayment.Sum(p => p.payment_amount);

                    lblPaid.Text = sum.ToString();
                    txtPopupPaidAmount.Text = (Totalpay - sum).ToString();
                    txtchangepaidamount.Text = (Totalpay - sum).ToString();
                    txtcpaidamount.Text = (Totalpay - sum).ToString();
                    ChangedueCalculation();

                }
            }
        }

        protected void btnpopuporder_Click(object sender, System.EventArgs e)
        {
            int TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID1 = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            if (DAL.CheckForCustomerSetting(TID1, UID1))
            {
                if (txtcustomer.Text.ToUpper() == "CASH")
                {
                    Session["btnname"] = "orderpop";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#listcustomer').modal();});", true);
                    return;
                }
            }
            if (ViewState["GridPayment"] != null)
            {
                OnlySave(true);
                Session["GetMYTRANSID"] = null;
                bintlist();
                ViewState["GridPayment"] = null;
                GridPayment.DataSource = null;
                GridPayment.Items.Clear();
                GridPayment.DataBind();
                txtPopupPaidAmount.Text = "0.000";
                txtchangepaidamount.Text = "";
                txtcpaidamount.Text = "";
                txtchange.Text = "";
                txtcash.Text = "";
                txtPayReffrance.Text = "";
                lblPaid.Text = "";
                lblPopupPaidAmount.Text = "";
                UpdatePanel3.Update();

            }
            else
            {
                btnorderKNET_Click(null, null);
            }
        }

        protected void btnpopupsaveonly_Click(object sender, System.EventArgs e)
        {

        }

        protected void btnpopupcancel_Click(object sender, System.EventArgs e)
        {

        }


        public void OnlySave(bool Print)
        {

            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            panelMsg.Visible = false;
            lblErreorMsg.Text = "";



            List<TempProduct> Tlist = new List<TempProduct>();

            Tlist = ((List<TempProduct>)ViewState["InvoiceProd"]).ToList();

            List<PaymentDatasale> ListPayment = new List<PaymentDatasale>();
            ListPayment = ((List<PaymentDatasale>)ViewState["GridPayment"]).ToList();

            List<SalesItemList> ListSend = new List<SalesItemList>();

            foreach (TempProduct item in Tlist)
            {
                SalesItemList Obj = new SalesItemList();
                Obj.Items_Name = item.product_name;
                Obj.UOMNAME = item.UOMNAME; // change by dipak to UOM
                Obj.UOMID = item.UOMID; // change by dipak to UOM
                decimal Price = Convert.ToInt32(item.msrp);
                Price = Math.Round(Price, 3);
                Obj.Price = Price;
                Obj.Qty = Convert.ToDecimal(item.OpQty);
                decimal Total = Convert.ToInt32(item.Total);
                Total = Math.Round(Total, 3);
                Obj.Total = Total;
                Obj.Remarks = item.Remarks;
                Obj.itemID = item.product_id.ToString();
                Obj.CustItemCode = item.CustItemCode;

                ListSend.Add(Obj);
            }

            List<PaymentData> GridPayment = new List<PaymentData>();

            foreach (PaymentDatasale item in ListPayment)
            {
                PaymentData Obj = new PaymentData();
                Obj.payment_type = item.payment_type;
                Obj.Reffrance_NO = item.Reffrance_NO;
                Obj.payment_amount = item.payment_amount;
                GridPayment.Add(Obj);
            }

            if (Request.QueryString["MytransID"] != null && Request.QueryString["MytransID"] != "0")
            {
                int MTID = Convert.ToInt32(Request.QueryString["MytransID"]);
                if (Session["GetMYTRANSID"] != null)
                {
                    List<Database.ICTR_DT_Sales> Tlistw = DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.locationID == LID && p.MYTRANSID == MTID).ToList();

                    foreach (Database.ICTR_DT_Sales items in Tlistw)
                    {
                        int prodid = int.Parse(items.MyProdID.ToString());
                        if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TID && p.MYTRANSID == MTID && p.locationID == LID && p.MyProdID == prodid).Count() > 0)
                        {
                            DAL.Reverse_InvoiceQt(TID, LID, prodid, MTID);
                        }
                    }

                }
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID); ;
                string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
                CashSave2 sendObj1 = new CashSave2();
                string invoice = "INV" + MTID;
                sendObj1.TenentID = TID;
                sendObj1.LID = LID;
                sendObj1.MYTRANSID = MTID;
                sendObj1.DESCRIPTION = txtcustomer.Text;
                sendObj1.Userid = UID;
                sendObj1.UserName = name;
                sendObj1.DID = Convert.ToInt32(Session["ID"]);
                sendObj1.Invoice = invoice;
                if (ChIsCredit.Checked == true)
                {
                    sendObj1.PaymentMode = "Credit";
                    sendObj1.PaymentStatus = "Credit";
                    sendObj1.OrderStatus = "New";
                    sendObj1.DeliveryStatus = "Processed";
                }
                else
                {
                    sendObj1.OrderStatus = "New";
                    sendObj1.PaymentStatus = drpPayBy.SelectedItem.Text;
                    sendObj1.DeliveryStatus = "Under the Process";
                }
                string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                if (Customer.Contains('-'))
                {
                    Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                }
                sendObj1.Customer = Customer;
                int C_id = HiddenField3.Value != null && HiddenField3.Value != "" ? Convert.ToInt32(HiddenField3.Value) : 1;
                sendObj1.CustomerID = C_id != 0 ? C_id : 1;

                decimal Predis = Convert.ToDecimal(lblDiscount.Text);
                decimal Invoidis = Convert.ToDecimal(lblDiscount.Text);
                decimal Fdis = Predis + Invoidis;
                sendObj1.Orderway = BtnOrdertypeMain.Text;
                sendObj1.DiscountTotaloverall = lblDiscount.Text.ToString();
                sendObj1.overalldisRate = lblDiscount.Text != "" ? lblDiscount.Text : "0";
                sendObj1.Delivery_Cahrge = txtdeliverycharges.Text; //lblDelivery.Text != "" ? lblDelivery.Text : "0";
                sendObj1.DiscountAmt = lblDiscount.Text.ToString();
                sendObj1.TotalPayable = Convert.ToDecimal(FTotall.Text);
                if (txtCashRecived.Text != null && txtCashRecived.Text != "")
                {
                    sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);
                }
                sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);// txtcashReceived.Text != "" ? Convert.ToDecimal(txtcashReceived.Text) : 0;
                sendObj1.Orderway = BtnOrdertypeMain.Text;
                sendObj1.dgrvSalesItemList = ListSend;
                sendObj1.GridPayment = GridPayment;
                sendObj1.ChangeAmount = Convert.ToDecimal(txtbalance.Text);
                fullConfirmnew(sendObj1);
                printInv(MTID);
                //sahir commit api
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(Baseurl);
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.DefaultRequestHeaders.Add("Authentication", bearerToken);
                //    HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/FullConfirmpament", sendObj1).Result;
                //    if (responseMessage.IsSuccessStatusCode)
                //    {
                //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
                //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
                //        string MSg = rootobject.data.ToString();
                //
                //        //Response.Redirect("LocalInvoice.aspx?Tranjestion=" + mytransid);
                //
                //
                //        // Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //    }
                //    else
                //    {
                //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
                //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
                //        string MSg = rootobject.data.ToString();
                //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('" + MSg + "');", true);
                //    }
                //}

            }
            else
            {
                int InvoiceID = 0;
                Int64 MTID = int.Parse(DAL.GetInvoiceNo(TID, LID, TerminalID, out InvoiceID).ToString());// Convert.ToInt32(Session["GetMYTRANSID"]);
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
                CashSave2 sendObj1 = new CashSave2();
                string invoice = "INV" + MTID;
                sendObj1.TenentID = TID;
                sendObj1.LID = LID;
                sendObj1.MYTRANSID = MTID;
                sendObj1.DESCRIPTION = txtcustomer.Text;
                sendObj1.Userid = UID;

                sendObj1.UserName = name;
                sendObj1.DID = Convert.ToInt32(Session["ID"]);
                sendObj1.Invoice = invoice;
                if (ChIsCredit.Checked == true)
                {
                    sendObj1.PaymentMode = "Credit";
                    sendObj1.PaymentStatus = "Credit";
                    sendObj1.OrderStatus = "New";
                    sendObj1.DeliveryStatus = "Processed";
                }
                else
                {
                    sendObj1.OrderStatus = "New";
                    sendObj1.PaymentStatus = drpPayBy.SelectedItem.Text;

                    sendObj1.DeliveryStatus = "Under the Process";
                }
                string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                if (Customer.Contains('-'))
                {
                    Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                }
                sendObj1.Customer = Customer;
                int C_id = HiddenField3.Value != null && HiddenField3.Value != "" ? Convert.ToInt32(HiddenField3.Value) : 1;
                sendObj1.CustomerID = C_id != 0 ? C_id : 1;

                decimal Predis = Convert.ToDecimal(lblDiscount.Text);
                decimal Invoidis = Convert.ToDecimal(lblDiscount.Text);
                decimal Fdis = Predis + Invoidis;
                sendObj1.Orderway = BtnOrdertypeMain.Text;
                sendObj1.DiscountTotaloverall = lblDiscount.Text.ToString();
                sendObj1.overalldisRate = lblDiscount.Text != "" ? lblDiscount.Text : "0";
                sendObj1.Delivery_Cahrge = txtdeliverycharges.Text; //lblDelivery.Text != "" ? lblDelivery.Text : "0";
                sendObj1.DiscountAmt = lblDiscount.Text.ToString();
                sendObj1.TotalPayable = Convert.ToDecimal(FTotall.Text);
                if (txtCashRecived.Text != null && txtCashRecived.Text != "")
                {
                    sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);
                }
                sendObj1.TotalCashRecived = Convert.ToDecimal(FTotall.Text);// txtcashReceived.Text != "" ? Convert.ToDecimal(txtcashReceived.Text) : 0;
                sendObj1.dgrvSalesItemList = ListSend;
                sendObj1.GridPayment = GridPayment;
                sendObj1.ChangeAmount = Convert.ToDecimal(txtbalance.Text);
                sendObj1.payment_type = drpPayBy.SelectedItem.Text;
                fullConfirmnew(sendObj1);

                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(Baseurl);
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.DefaultRequestHeaders.Add("Authentication", bearerToken);
                //    HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/fullConfirmnew", sendObj1).Result;
                //    if (responseMessage.IsSuccessStatusCode)
                //    {
                //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
                //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
                //        string MSg = rootobject.data.ToString();

                //        //Response.Redirect("LocalInvoice.aspx?Tranjestion=" + mytransid);


                //        // Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //    }
                //    else
                //    {
                //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
                //        var rootobject = JsonConvert.DeserializeObject<Response>(EmpResponse);
                //        string MSg = rootobject.data.ToString();
                //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('" + MSg + "');", true);
                //    }
                //}
                //int mytransid = MTID; //GetSalesID(MSg);

                printInv(MTID);

            }


        }


        public void FullConfirmpament(CashSave2 sendObj1)
        {
            try
            {
                if (sendObj1.TenentID == 0 || sendObj1.MYTRANSID == 0 || sendObj1.Userid == 0 || sendObj1.CustomerID == 0 || sendObj1.UserName == "" || sendObj1.DESCRIPTION == "" || sendObj1.Invoice == "")
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null mandatory Parameter Please correct and try again')", true);
                    return;
                }
                List<SalesItemList> dgrvSalesItemList = sendObj1.dgrvSalesItemList.ToList();
                List<PaymentData> GridPayment = new List<PaymentData>();

                if (sendObj1.GridPayment != null)
                {
                    GridPayment = sendObj1.GridPayment.ToList();
                }
                if (dgrvSalesItemList.Count() < 1)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null Item List')", true);
                    return;

                }
                else if (GridPayment.Count() > 0)
                {
                    foreach (PaymentData items in GridPayment)
                    {
                        if (items.payment_type == "" || items.payment_type == null || items.Reffrance_NO == "" || items.Reffrance_NO == null || items.payment_amount == 0)
                        {
                            if (items.payment_type != "Cash" && (items.Reffrance_NO == "" || items.Reffrance_NO == null))
                            {

                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                                return;

                            }
                            else if (items.payment_type == null || items.payment_type == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                                return;
                            }
                            else
                            {

                            }

                        }
                    }
                }
                else
                {
                    foreach (SalesItemList items in dgrvSalesItemList)
                    {
                        // Items_Name, Price, Qty, Total, itemID, CustItemCode
                        if (items.Items_Name == "" || items.Items_Name == null || items.UOMNAME == "" || items.UOMNAME == null || items.Price == 0 || items.Qty == 0 || items.Total == 0 || items.itemID == "0" || items.itemID == "" || items.itemID == null || items.CustItemCode == "" || items.CustItemCode == null)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('WE Get null perameter in Payment List')", true);
                            return;

                        }
                    }
                }

                int TenentID = sendObj1.TenentID;
                Int64 MYTransid = sendObj1.MYTRANSID;
                int LID = sendObj1.LID;
                int CustomerID = sendObj1.CustomerID;
                string DiscountTotaloverall = sendObj1.DiscountTotaloverall;//!= null && sendObj1.DiscountTotaloverall != "" ? sendObj1.DiscountTotaloverall : "0";
                decimal TotalPayable = sendObj1.TotalPayable;
                decimal TotalCashRecived = sendObj1.TotalPayable;
                int userid = sendObj1.Userid;
                string invoice = sendObj1.Invoice;
                string UserName = sendObj1.UserName != "" && sendObj1.UserName != null ? sendObj1.UserName : DB.USER_MST.Where(p => p.TenentID == TenentID && p.USER_ID == userid).FirstOrDefault().FIRST_NAME.ToString();
                string Customer = sendObj1.Customer != "" && sendObj1.Customer != null ? sendObj1.Customer : DB.Win_tbl_customer.Where(p => p.TenentID == TenentID && p.ID == CustomerID).FirstOrDefault().Name;
                int ID = sendObj1.DID;
                string paymentstatus = sendObj1.PaymentStatus;
                string orderstaus = sendObj1.OrderStatus;
                string DeliveryStatus = sendObj1.DeliveryStatus;
                string overalldisRate = sendObj1.overalldisRate;//!= null && sendObj1.overalldisRate != "" ? sendObj1.overalldisRate : "0";
                string Delivery_Cahrge = sendObj1.Delivery_Cahrge;
                string PaymentMode = sendObj1.PaymentMode;
                decimal changepayment = sendObj1.ChangeAmount;
                string Oway = sendObj1.Orderway;
                string MSG = Cash_Salespayment(TenentID, LID, MYTransid, userid, UserName, TotalPayable, changepayment, TotalCashRecived, paymentstatus, orderstaus, DeliveryStatus, Customer, DiscountTotaloverall, CustomerID, overalldisRate, Delivery_Cahrge, dgrvSalesItemList, invoice, PaymentMode, GridPayment, Oway);
                DateTime dt = DateTime.Now;
                string stdate = dt.ToString("yyyy-MM-dd");
                DateTime dt1 = Convert.ToDateTime(stdate);


                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

            }
            catch (Exception ex)
            {
                if (sendObj1.TenentID != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something Went Wrong! Please try again later')", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('We Found problem in TenentID')", true);
                    return;
                }
            }
        }



        public string Cash_Salespayment(int TenentID, int LocationID, Int64 Mytransid, int Userid, string UserName, decimal TotalPayable, decimal changepayment, decimal TotalCashRecived, string paymentstatus, string orderstatus, string DeliveryStatus, string Customer, string DiscountTotaloverall, int CustomerID, string overalldisRate, string Delivery_Cahrge, List<SalesItemList> dgrvSalesItemList, string invoice, string Payment, List<PaymentData> GridPayment, string Oway)
        {
            string salesdate = "";
            DateTime sales_date = Convert.ToDateTime(DateTime.Now);
            salesdate = sales_date.ToString("yyyy-MM-dd HH:mm:ss");
            if (Mytransid == 0)
            {
                string Err = "Sorry ! You don't have enough product in Item cart \n  Please Add to cart";
                return Err;
            }


            else
            {
                string InvoiceNO = "";
                string Invo = "";
                string Transid = "";
                string trno = "";
                int InvoiceID = 0;
                string Sales_ID = "";
                if (invoice != null && invoice != "")
                {
                    InvoiceNO = invoice;
                    Invo = InvoiceNO;
                    Transid = "INV" + Mytransid; //GetSalesIDFromInvoice(TenentID, Mytransid).ToString();
                    Sales_ID = Mytransid.ToString();
                    trno = Sales_ID;
                }
                else
                {
                    InvoiceNO = "INV" + Mytransid;//GetSalesIDFromInvoice(TenentID, Mytransid).ToString();
                    Invo = InvoiceNO;
                    Transid = DAL.GetInvoiceNo(TenentID, LID, TerminalID, out InvoiceID).ToString();// get_sales_id(TenentID);
                    Sales_ID = Mytransid.ToString();
                    trno = Sales_ID;
                }

                string Comment = "Cash";
                string PaymentStutas = "";
                if (Payment == "COD")
                {
                    PaymentStutas = "Pending";
                }
                else
                {
                    PaymentStutas = "Success";
                }
                decimal TotalPay_amount = TotalPayable;

                decimal dueAmount = 0;

                //if (TotalPayable > TotalPay_amount)
                //{
                //    decimal due = TotalPayable - TotalPay_amount;
                //    dueAmount = due;
                //}
                //else if (TotalPay_amount > TotalPayable)
                //{
                //    decimal change = TotalPay_amount - TotalPayable;
                //    ChangeAmount = change;
                //}
                //else
                //{
                //    dueAmount = 0;
                //    ChangeAmount = 0;

                //}

                string PaymentMode = Payment;
                // List<PaymentData> GridPayment = new List<PaymentData>();

                decimal ChangeAmount = changepayment;
                string ShiftID = Session["ShiftID"].ToString();
                payment_itemsave(TenentID, LocationID, TotalPayable, ChangeAmount, dueAmount, salesdate, Comment, PaymentStutas, trno, InvoiceNO, Customer, CustomerID, DiscountTotaloverall, overalldisRate, Delivery_Cahrge, UserName, "1", Userid, int.Parse(ShiftID), GridPayment, Payment);

                // payment_itemsave(TenentID, TotalPayable, ChangeAmount, dueAmount, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString(), Comment, PaymentStutas, trno, InvoiceNO, Customer, CustomerID, DiscountTotaloverall, overalldisRate, Delivery_Cahrge, UserName,  Userid, GridPayment);

                // string OrderWay = "Paid - send to Kitchen";
                string OrderStutas = "Paid - send to Kitchen";
                int OrderTotal = 1;
                int COD = 0;

                string ActivityName = "sales Cash Transaction";
                string LogData = "Save Sales Transaction as Cash with InvoiceNO = " + Invo + " ";



                //    scope.Complete();
                //}

                return InvoiceNO;
            }
        }
        protected void CustomerSearch_TextChanged(object sender, System.EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            customerlist.DataSource = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "y" && p.TenentID == TID && (p.COMPNAME1.Contains(txtCustomerNameSearch.Text.Trim()) || p.BUSPHONE1.Contains(txtCustomerNameSearch.Text.Trim())));
            customerlist.DataBind();
            txtphone.Text = txtCustomerNameSearch.Text;
            txtcustomer.Text = "ali";
        }


        protected void txtPopupPaidAmount_TextChanged(object sender, System.EventArgs e)
        {
            if (lblPaid.Text != "0" && lblPaid.Text != null)
            {
                decimal total = Convert.ToDecimal(lblPopupPaidAmount.Text);
                decimal paid;
                if (lblPaid.Text == string.Empty) { paid = 0; }
                else { paid = Convert.ToDecimal(lblPaid.Text); }

                decimal crack = Convert.ToDecimal(txtPopupPaidAmount.Text);
                txtchangepaidamount.Text = crack.ToString();
                txtcpaidamount.Text = crack.ToString();
                txtchangecashamount.Text = "";
                txtchangechangeamount.Text = "";
                txtbalance.Text = (total - paid - crack).ToString();
            }

            else if (txtPopupPaidAmount.Text != "0" && txtPopupPaidAmount.Text != null)
            {
                decimal total = Convert.ToDecimal(lblPopupPaidAmount.Text);
                decimal paid;
                if (txtPopupPaidAmount.Text == string.Empty)
                { paid = 0; }
                else
                { paid = Convert.ToDecimal(txtPopupPaidAmount.Text); }
                txtchangepaidamount.Text = paid.ToString();
                txtcpaidamount.Text = paid.ToString();
                txtchangecashamount.Text = "";
                txtchangechangeamount.Text = "";
                txtbalance.Text = (total - paid).ToString();
            }
        }
        protected void txtphone_TextChanged(object sender, System.EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (DB.TBLCOMPANYSETUPs.Where(p => p.BUSPHONE1 == txtphone.Text && p.TenentID == TID).Count() < 1)
            {
                lblphone.Visible = false;
            }
            else
            {

                lblphone.Visible = true;
            }
            txtphone.Focus();
        }

        protected void txtCashRecived_TextChanged(object sender, System.EventArgs e)
        {
            if (txtCashRecived.Text != "0" && txtCashRecived.Text != null)
            {
                decimal total = Convert.ToDecimal(FTotall.Text);
                decimal paid = Convert.ToDecimal(txtCashRecived.Text);
                txtChangeAmt.Text = (total - paid).ToString();
            }
        }

        protected void Listsplit_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {

        }

        protected void chkinv1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        protected void chkinv2_CheckedChanged(object sender, System.EventArgs e)
        {

        }


        List<TempProduct> Tlistinvoice1 = new List<TempProduct>();
        List<TempProduct> Tlistinvoice2 = new List<TempProduct>();
        protected void ListInvoice1_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            if (e.CommandName == "moveinvoice")
            {
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                Tlistinvoice1 = ((List<TempProduct>)ViewState["Listinvoice1"]).ToList();

                int Id = Convert.ToInt32(e.CommandArgument);
                TempProduct obj = new TempProduct();
                DataTable purobj = DAL.Get_Item_View_Product(TID, LID, Id);// DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Id);
                int UMID = Convert.ToInt32(purobj.Rows[0]["UOM"]);
                if (ViewState["Listinvoice2"] == null)
                {
                    obj.Tenent = TID;
                    obj.product_id = Id;
                    obj.UOMID = Convert.ToInt32(UMID);
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                    obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                    obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                    obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                    obj.supplier = purobj.Rows[0]["Option1"].ToString();
                    obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                    //obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                    obj.price = Convert.ToDecimal(purobj.Rows[0]["price"]);//price
                    obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"]);//total
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"]);
                    obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"]);
                    obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"]);
                    //if(Tlist.Where(p => p.Tenent == TID && p.product_id == purobj.MYPRODID).Count() > 0)
                    //{
                    //    decimal qty = Convert.ToInt32(1);
                    //}
                    decimal qty = Convert.ToInt32(1);//qty
                    decimal Dis = Convert.ToDecimal(0);//yogesh
                    decimal msrp = (Convert.ToDecimal(purobj.Rows[0]["msrp"]) * qty);//total
                    decimal Fdis = ((msrp * Dis) / 100);
                    obj.Total = (msrp * qty);
                    obj.Discount = Math.Round(Fdis, 3);
                    obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                    obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                    obj.BatchNo = "1";
                    Tlistinvoice2.Add(obj);
                    ViewState["Listinvoice2"] = Tlistinvoice2;
                    Listinvoice2.DataSource = Tlistinvoice2;//Tlistinvoice2.Where(p => p.product_id == Id && p.Tenent == TID);
                    Listinvoice2.DataBind();

                }
                else
                {
                    Tlistinvoice2 = ((List<TempProduct>)ViewState["Listinvoice2"]).ToList();
                    obj.Tenent = int.Parse(purobj.Rows[0]["TenentID"].ToString());
                    obj.product_id = Convert.ToInt32(purobj.Rows[0]["MYPRODID"]);
                    obj.UOMID = Convert.ToInt32(purobj.Rows[0]["UOM"]); // change by dipak
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    //obj.Shopid = purobj.Shopid;
                    obj.product_name = purobj.Rows[0]["ProdName1"].ToString();
                    obj.product_name_Arabic = purobj.Rows[0]["ProdName2"].ToString();
                    obj.product_name_print = purobj.Rows[0]["ProdName3"].ToString();
                    obj.category = purobj.Rows[0]["CAT_NAME1"].ToString();
                    obj.supplier = purobj.Rows[0]["Option1"].ToString();
                    obj.imagename = purobj.Rows[0]["DefaultPic"].ToString();
                    //obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                    obj.price = Convert.ToDecimal(purobj.Rows[0]["price"]);//price
                    obj.msrp = Convert.ToDecimal(purobj.Rows[0]["msrp"]);//total
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToDecimal(purobj.Rows[0]["QTYINHAND"]);
                    obj.QtyOut = Convert.ToDecimal(purobj.Rows[0]["QTYSOLD"]);
                    obj.QtyRecived = Convert.ToDecimal(purobj.Rows[0]["QTYRCVD"]);


                    decimal qtys = Convert.ToInt32(1);//qty
                    decimal Diss = Convert.ToDecimal(0);//yogesh
                    decimal msrp = (Convert.ToDecimal(purobj.Rows[0]["msrp"]) * qtys);//total
                    decimal Fdis = ((msrp * Diss) / 100);
                    obj.Total = (msrp * qtys);
                    obj.Discount = Math.Round(Fdis, 3);
                    obj.CustItemCode = purobj.Rows[0]["AlternateCode1"].ToString();
                    obj.BarCode = purobj.Rows[0]["BarCode"].ToString();
                    obj.BatchNo = "1";

                    Tlistinvoice2.Add(obj);
                    ViewState["Listinvoice2"] = Tlistinvoice2;
                    Listinvoice2.DataSource = Tlistinvoice2;
                    Listinvoice2.DataBind();


                }
                TempProduct Calc = Tlistinvoice1.Single(p => p.Tenent == TID && p.product_id == Id);
                Tlistinvoice1.Remove(Calc);
                ViewState["Listinvoice1"] = Tlistinvoice1;
                ListInvoice1.DataSource = Tlistinvoice1;
                ListInvoice1.DataBind();

                Tlistinvoice1 = ((List<TempProduct>)ViewState["Listinvoice1"]).ToList();
                Tlistinvoice2 = ((List<TempProduct>)ViewState["Listinvoice2"]).ToList();

                decimal FTotalInvoice1 = Convert.ToDecimal(Tlistinvoice1.Sum(p => p.Total));
                decimal FTotalInvoice2 = Convert.ToDecimal(Tlistinvoice2.Sum(p => p.Total));

                lblinvoice1total.Text = FTotalInvoice1.ToString();
                lblinvoice2total.Text = FTotalInvoice2.ToString();
            }
        }

        protected void Listinvoice2_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            if (e.CommandName == "moveinvoicein")
            {
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                Tlistinvoice2 = ((List<TempProduct>)ViewState["Listinvoice2"]).ToList();
                int Id = Convert.ToInt32(e.CommandArgument);
                TempProduct obj = new TempProduct();
                Database.View_ProductCatWiseData purobj = DB.View_ProductCatWiseData.Single(p => p.TenentID == TID && p.MYPRODID == Id && p.LocationID == LID);
                int UMID = Convert.ToInt32(purobj.UOM);
                if (ViewState["Listinvoice1"] == null)
                {
                    obj.Tenent = TID;
                    obj.product_id = Id;
                    obj.UOMID = Convert.ToInt32(UMID);
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    obj.product_name = purobj.ProdName1;
                    obj.product_name_Arabic = purobj.ProdName2;
                    obj.product_name_print = purobj.ProdName3;
                    obj.category = purobj.CAT_NAME1;
                    obj.supplier = purobj.Option1;
                    obj.imagename = purobj.DefaultPic;
                    obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                    obj.price = Convert.ToDecimal(purobj.price);//price
                    obj.msrp = Convert.ToDecimal(purobj.msrp);//total
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToInt32(purobj.OnHand);
                    obj.QtyOut = Convert.ToInt32(purobj.QTYSOLD);
                    obj.QtyRecived = Convert.ToInt32(purobj.QTYRCVD);
                    //if(Tlist.Where(p => p.Tenent == TID && p.product_id == purobj.MYPRODID).Count() > 0)
                    //{
                    //    decimal qty = Convert.ToInt32(1);
                    //}
                    decimal qty = Convert.ToInt32(1);//qty
                    decimal Dis = Convert.ToDecimal(0);//yogesh
                    decimal msrp = (Convert.ToDecimal(purobj.msrp) * qty);//total
                    decimal Fdis = ((msrp * Dis) / 100);
                    decimal price = Convert.ToDecimal(purobj.price);
                    obj.Total = (msrp);
                    obj.Discount = Math.Round(Fdis, 3);
                    obj.CustItemCode = purobj.AlternateCode1;
                    obj.BarCode = purobj.BarCode;
                    obj.BatchNo = purobj.BatchNo;
                    Tlistinvoice1.Add(obj);
                    ViewState["Listinvoice1"] = Tlistinvoice1;
                    ListInvoice1.DataSource = Tlistinvoice1;//Tlistinvoice2.Where(p => p.product_id == Id && p.Tenent == TID);
                    ListInvoice1.DataBind();

                }
                else
                {
                    Tlistinvoice1 = ((List<TempProduct>)ViewState["Listinvoice1"]).ToList();
                    obj.Tenent = purobj.TenentID;
                    obj.product_id = Convert.ToInt32(purobj.MYPRODID);
                    obj.UOMID = Convert.ToInt32(purobj.UOM); // change by dipak
                    obj.UOMNAME = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == UMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UMID).UOMNAME1 : "Not Name"; // change by dipak
                    //obj.Shopid = purobj.Shopid;
                    obj.product_name = purobj.ProdName1;
                    obj.product_name_Arabic = purobj.ProdName2;
                    obj.product_name_print = purobj.ProdName3;
                    obj.category = purobj.CAT_NAME1;
                    obj.supplier = purobj.Option1;//yogesh
                    //obj.taxapply = Convert.ToInt32(purobj.taxapply);//yogesh
                    obj.imagename = purobj.DefaultPic;
                    obj.status = Convert.ToInt32(purobj.Option2);//yogesh
                    obj.price = Convert.ToDecimal(purobj.price);//price
                    obj.msrp = Convert.ToDecimal(purobj.msrp);//total
                    obj.OpQty = Convert.ToInt32(1);//qty
                    obj.OnHand = Convert.ToInt32(purobj.OnHand);
                    obj.QtyOut = Convert.ToInt32(purobj.QTYSOLD);
                    obj.QtyRecived = Convert.ToInt32(purobj.QTYRCVD);
                    decimal qtys = Convert.ToInt32(1);//qty
                    decimal Diss = Convert.ToDecimal(0);//yogesh
                    decimal msrps = (Convert.ToDecimal(purobj.msrp) * qtys);//total
                    decimal Fdiss = ((msrps * Diss) / 100);
                    decimal price = Convert.ToDecimal(purobj.price);
                    obj.Total = (msrps);
                    obj.Discount = Math.Round(Fdiss, 3);
                    obj.CustItemCode = purobj.AlternateCode1;
                    obj.BarCode = purobj.BarCode;
                    obj.BatchNo = purobj.BatchNo;
                    Tlistinvoice1.Add(obj);
                    ViewState["Listinvoice1"] = Tlistinvoice1;
                    ListInvoice1.DataSource = Tlistinvoice1;
                    ListInvoice1.DataBind();
                }
                TempProduct Calc = Tlistinvoice2.Single(p => p.Tenent == TID && p.product_id == Id);
                Tlistinvoice2.Remove(Calc);
                ViewState["Listinvoice2"] = Tlistinvoice2;
                Listinvoice2.DataSource = Tlistinvoice2;
                Listinvoice2.DataBind();


                Tlistinvoice1 = ((List<TempProduct>)ViewState["Listinvoice1"]).ToList();
                Tlistinvoice2 = ((List<TempProduct>)ViewState["Listinvoice2"]).ToList();

                decimal FTotalInvoice1 = Convert.ToDecimal(Tlistinvoice1.Sum(p => p.Total));
                decimal FTotalInvoice2 = Convert.ToDecimal(Tlistinvoice2.Sum(p => p.Total));

                lblinvoice1total.Text = FTotalInvoice1.ToString();
                lblinvoice2total.Text = FTotalInvoice2.ToString();
            }
        }

        protected void btninvoicedraft_Click(object sender, System.EventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (ViewState["Listinvoice1"] == null)
                return;
            int Mytransid = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1; ; ;
            List<TempProduct> Tlistinvoice1 = (List<TempProduct>)ViewState["Listinvoice1"];
            foreach (TempProduct item in Tlistinvoice1)
            {

                int location = 1;
                int terminal = 1;
                int Myid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Max(p => p.MYID) + 1) : 1; ;
                int PrID = item.product_id;
                string Reftype = "POS";
                string PERIOD_CODE = "POS";
                string MYSYSNAME = "SAL";

                string RefSubtype = "POS";
                string mysys = "PUR";
                string prname = item.product_name;
                string UOM = "99999";
                decimal qty = item.OpQty;
                decimal price = item.price;
                decimal amount = price * qty;
                string GLPOST = "2";
                string GLPOST1 = "2";
                string GLPOSTREF = "2";
                string GLPOSTREF1 = "2";
                string ICPOST = "2";
                string ICPOSTREF = "2";
                int CountryID = 36;
                int QuantityDelivered = 0;
                int Amount = 500;
                string DeliveredLocaTenantID = null;
                string AmountDelivered = null;
                string DeliveryRef = "DeliverRef";
                string UserBatch = "123";
                string maintranstype = "ACT";
                string TransType = "PaymentVoucher";
                decimal OVERHEADAMOUNT = 1;
                string BATCHNO = "1";
                int ToTenentID = Convert.ToInt32(Session["TID"]); ;
                int TOLOCATIONID = 1;
                string MainTranType = "O";
                string TranType = "POS Invoice";
                int transid = 4101;
                int transsubid = 410103;
                decimal COMPID = 1;
                // decimal CUSTVENDID = 1;
                string LF = "L";
                string ACTIVITYCODE = "1";
                decimal MYDOCNO = 1;
                string USERBATCHNO = "1";
                decimal TOTQTY1 = item.OpQty;
                decimal TOTAMT = Convert.ToDecimal(lblinvoice1total.Text);
                decimal AmtPaid = 1;
                string PROJECTNO = "1";
                string CounterID = "1";
                string PrintedCounterInvoiceNo = "1";
                int JOID = 1;
                DateTime TRANSDATE = DateTime.Now;
                string REFERENCE = "POS";
                string NOTES = "POS";
                int CRUP_ID = 1;
                string USERID = "1";
                int COMPANYID = 0;
                DateTime ENTRYDATE = DateTime.Now;
                DateTime ENTRYTIME = DateTime.Now;
                DateTime UPDTTIME = DateTime.Now;
                string InvoiceNO = "0";
                decimal Discount = 1;
                string Status = null;
                int Terms = 0;
                string Custmerid = null;
                string Swit1 = null;
                string ExtraField2 = null;
                int RefTransID = 0;
                string Reason = null;
                string TransDocNo = null;
                int LinkTransID = 0;
                int invoice_Type = 0;
                int invoice_Source = 0;
                string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                if (Customer.Contains('-'))
                {
                    Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                }
                int CID = Convert.ToInt32(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == Customer).COMPID);
                decimal CUSTVENDID = Convert.ToInt32(CID); //Convert.ToInt32(HiddenField3.Value);


                Classes.EcommAdminClass.insert_ICTR_DT_Sales_tmp(TID, Mytransid, LID, Myid, PrID, Reftype, RefSubtype, PERIOD_CODE, MYSYSNAME, 1, 1, 1, prname, UOM, qty, price, amount, OVERHEADAMOUNT, BATCHNO, 1, "1", "1", 1, 1, 1, 1, 1, 1, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, true, "1", 1, 1, "1", "");
                if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransid).Count() < 1)
                {
                    Classes.EcommAdminClass.insert_ICTR_HD_Sales_tmp(TID, Mytransid, ToTenentID, TOLOCATIONID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, "1", ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY1, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, true, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                }
            }


            if (ViewState["Listinvoice2"] == null)
                return;
            int Mytransids = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1; ; ;
            List<TempProduct> Tlistinvoice2 = (List<TempProduct>)ViewState["Listinvoice2"];
            //int Mytransid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;

            foreach (TempProduct item in Tlistinvoice2)
            {

                int location = 1;
                int terminal = 1;
                int Myid = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransids).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransids).Max(p => p.MYID) + 1) : 1; ;
                int PrID = item.product_id;
                string Reftype = "POS";
                string PERIOD_CODE = "POS";
                string MYSYSNAME = "SAL";

                string RefSubtype = "POS";
                string mysys = "PUR";
                string prname = item.product_name;
                string UOM = "99999";
                decimal qty = item.OpQty;
                decimal price = item.price;
                decimal amount = price * qty;
                string GLPOST = "2";
                string GLPOST1 = "2";
                string GLPOSTREF = "2";
                string GLPOSTREF1 = "2";
                string ICPOST = "2";
                string ICPOSTREF = "2";
                int CountryID = 36;
                int QuantityDelivered = 0;
                int Amount = 500;
                string DeliveredLocaTenantID = null;
                string AmountDelivered = null;
                string DeliveryRef = "DeliverRef";
                string UserBatch = "123";
                string maintranstype = "ACT";
                string TransType = "PaymentVoucher";
                decimal OVERHEADAMOUNT = 1;
                string BATCHNO = "1";
                int ToTenentID = Convert.ToInt32(Session["TID"]); ;
                int TOLOCATIONID = 1;
                string MainTranType = "O";
                string TranType = "POS Invoice";
                int transid = 4101;
                int transsubid = 410103;
                decimal COMPID = 1;
                // decimal CUSTVENDID = 1;
                string LF = "L";
                string ACTIVITYCODE = "1";
                decimal MYDOCNO = 1;
                string USERBATCHNO = "1";
                decimal TOTQTY1 = item.OpQty;
                decimal TOTAMT = Convert.ToDecimal(lblinvoice2total.Text);
                decimal AmtPaid = 1;
                string PROJECTNO = "1";
                string CounterID = "1";
                string PrintedCounterInvoiceNo = "1";
                int JOID = 1;
                DateTime TRANSDATE = DateTime.Now;
                string REFERENCE = "POS";
                string NOTES = "POS";
                int CRUP_ID = 1;
                string USERID = "1";
                int COMPANYID = 0;
                DateTime ENTRYDATE = DateTime.Now;
                DateTime ENTRYTIME = DateTime.Now;
                DateTime UPDTTIME = DateTime.Now;
                string InvoiceNO = "0";
                decimal Discount = 1;
                string Status = null;
                int Terms = 0;
                string Custmerid = null;
                string Swit1 = null;
                string ExtraField2 = null;
                int RefTransID = 0;
                string Reason = null;
                string TransDocNo = null;
                int LinkTransID = 0;
                int invoice_Type = 0;
                int invoice_Source = 0;
                string Customer = txtcustomer.Text != "" ? txtcustomer.Text : "Cash";
                if (Customer.Contains('-'))
                {
                    Customer = txtcustomer.Text != "" ? txtcustomer.Text.ToString().Split('-')[0].Trim() : "Cash";
                }
                int CID = Convert.ToInt32(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == Customer).COMPID);
                decimal CUSTVENDID = Convert.ToInt32(CID); //Convert.ToInt32(HiddenField3.Value);


                Classes.EcommAdminClass.insert_ICTR_DT_Sales_tmp(TID, Mytransids, LID, Myid, PrID, Reftype, RefSubtype, PERIOD_CODE, MYSYSNAME, 1, 1, 1, prname, UOM, qty, price, amount, OVERHEADAMOUNT, BATCHNO, 1, "1", "1", 1, 1, 1, 1, 1, 1, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, true, "1", 1, 1, "1", "");
                if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TID && p.MYTRANSID == Mytransids).Count() < 1)
                {
                    Classes.EcommAdminClass.insert_ICTR_HD_Sales_tmp(TID, Mytransids, ToTenentID, TOLOCATIONID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, "1", ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY1, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, true, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                }
            }


        }

        protected void Listaddon_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            Label lbladdonid = (Label)e.Item.FindControl("lbladdonid");
            Label lbladdonprice = (Label)e.Item.FindControl("lbladdonprice");
            int Myprodid = Convert.ToInt32(lbladdonid.Text);
            string price = DB.TBLPRODUCTs.Single(p => p.TenentID == TID & p.MYPRODID == Myprodid).price.ToString();
            lbladdonprice.Text = price;
        }

        protected void ListCategory_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {

            Label lbladdonid = (Label)e.Item.FindControl("lbladdonid");
            Label lbladdonprice = (Label)e.Item.FindControl("lbladdonprice");
            Label lblmaincat = (Label)e.Item.FindControl("lblmaincat");
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int CatID = Convert.ToInt32(lblmaincat.Text);
            Label lblcatnames = (Label)e.Item.FindControl("lblcatnames");
            Label labelcatenameblue = (Label)e.Item.FindControl("labelcatenameblue");
            if (ViewState["CID"] != null && ViewState["CID"] != "0")
            {
                int CID = Convert.ToInt32(ViewState["CID"]);
                lblcatnames.Visible = false;
                labelcatenameblue.Visible = true;
                ItemList.DataSource = DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CID);// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
                ItemList.DataBind();
                ItemCountLeft();

            }
            else
            {
                lblcatnames.Visible = true;
                labelcatenameblue.Visible = false;
            }
            //if (DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CatID).Count() > 0)
            //{
            //    lblcatnames.Visible = false;
            //    labelcatenameblue.Visible = true;
            //    ItemList.DataSource = DB.View_ProductCatWiseData.Where(p => p.TenentID == TID && p.MainCategoryID == CatID);// listmultiuom1.GroupBy(a=>a.MainCategoryID).ToList();
            //    ItemList.DataBind();
            //    ItemCountLeft();
            //}
            //else
            //{
            //    lblcatnames.Visible = true;
            //    labelcatenameblue.Visible = false;
            //}

        }
    }
}