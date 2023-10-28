using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;

namespace Web.ECOMM.UserControl
{
    public partial class items : System.Web.UI.UserControl
    {
        CallEntities DB = new CallEntities();
        int TID, LID, UID, EMPID, userID1, userTypeid = 0;
        string LangID="";

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionLoad();
            if (!IsPostBack)
            {
                // BindData();
                if (Request.QueryString["MYTRANSID"] != null)
                {
                    int MYTRANSID = Convert.ToInt32(Request.QueryString["MYTRANSID"]);
                    listMulticoloerand.DataSource = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == MYTRANSID && p.locationID == LID && p.SWITCH1 == "1" && p.TenentID == TID);
                    listMulticoloerand.DataBind();
                    ICTR_HD_Sales obj = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TID);
                    lbltrzctiondate.Text = obj.PERIOD_CODE;
                    lblrefteshnomber.Text = obj.REFERENCE;
                    lblbactnumber.Text = obj.USERBATCHNO;
                }

            }

        }
        public void SessionLoad()
        {
            TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            EMPID = Convert.ToInt32(((USER_MST)Session["USER"]).EmpID);
            LangID = Session["LANGUAGE"].ToString();
            userID1 = ((USER_MST)Session["USER"]).USER_ID;
            userTypeid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_DETAIL_ID);

        }
        //public void BindData()
        //{
        //    List<Eco_TBLPRODUCT> List = Classes.EcommAdminClass.getDataEco_TBLPRODUCT().Where(p => p.TenentID == TID).ToList();
        //    listMulticoloerand.DataSource = List;
        //    listMulticoloerand.DataBind();
        //}


        public string getuom(int UID)
        {
            return DB.ICUOMs.Single(p => p.UOM == UID && p.TenentID == TID).UOMNAME1;
        }
        public int getQty(int PID)
        {
            return Convert.ToInt32( DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID).QTYINHAND);
        }
        List<ICIT_BR_BIN> ListICIT_BR_BIN = new List<ICIT_BR_BIN>();
        protected void listMulticoloerand_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListView listMUOMLIST = (ListView)e.Item.FindControl("listMUOMLIST");

            HyperLink hprMultibin = (HyperLink)e.Item.FindControl("hprMultibin");
            Label lblmultibin = (Label)e.Item.FindControl("lblmultibin");
            HyperLink hpeperishibal = (HyperLink)e.Item.FindControl("hpeperishibal");
            Label lblpereshibal = (Label)e.Item.FindControl("lblpereshibal");
            HyperLink hyperseriliz = (HyperLink)e.Item.FindControl("hyperseriliz");
            Label lblserilez = (Label)e.Item.FindControl("lblserilez");
            HyperLink hymultisize = (HyperLink)e.Item.FindControl("hymultisize");
            Label lblmultisiz = (Label)e.Item.FindControl("lblmultisiz");
            HyperLink HyperMulicolor = (HyperLink)e.Item.FindControl("HyperMulicolor");
            Label lblmultico = (Label)e.Item.FindControl("lblmultico");
            HyperLink linkmultiuom = (HyperLink)e.Item.FindControl("linkmultiuom");
            Label lblmultiuom = (Label)e.Item.FindControl("lblmultiuom");
            Label lblproductid = (Label)e.Item.FindControl("lblproductid");
            Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
            TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
            ListView listmulticoler = (ListView)e.Item.FindControl("listmulticoler");
            ListView listBin = (ListView)e.Item.FindControl("listBin");
            ListView listSize = (ListView)e.Item.FindControl("listSize");
            ListView listSerial = (ListView)e.Item.FindControl("listSerial");
            int ProduID = Convert.ToInt32(lblproductid.Text);
            int TCID = Convert.ToInt32(labeltarjication.Text);
            List<TBLPRODUCT> list = DB.TBLPRODUCTs.Where(p => p.MYPRODID == ProduID && p.ACTIVE == "1" && p.TenentID == TID).ToList();
            Boolean MultiColor = Convert.ToBoolean(list.Single(p=>p.TenentID == TID).MultiColor);
            Boolean MultiUOM = Convert.ToBoolean(list.Single(p => p.TenentID == TID).MultiUOM);
            Boolean Perishable = Convert.ToBoolean(list.Single(p => p.TenentID == TID).Perishable);
            Boolean MultiSize = Convert.ToBoolean(list.Single(p => p.TenentID == TID).MultiSize);
            Boolean Serialized = Convert.ToBoolean(list.Single(p => p.TenentID == TID).Serialized);
            Boolean MultiBinStore = Convert.ToBoolean(list.Single(p => p.TenentID == TID).MultiBinStore);
            if (MultiColor == Convert.ToBoolean(1))
            {
                HyperMulicolor.Visible = true;
                lblmultico.Visible = true;
                lblmultico.Text = "MultiColor" + "<br/>";
                if (DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MySysName == "PUR" && p.MyProdID == ProduID && p.Active == "D" && p.COLORID != 999999998 && p.RecodName == "MultiColor" && p.TenentID == TID).Count() > 0)
                {
                    List<ICIT_BR_TMP> List = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MySysName == "PUR" && p.MyProdID == ProduID && p.Active == "D" && p.COLORID != 999999998 && p.RecodName == "MultiColor" && p.TenentID == TID).ToList();
                    listmulticoler.DataSource = List;
                    listmulticoler.DataBind();
                    ViewState["MultiColor"] = List;
                }
                else
                {
                    //Haresh
                    //List<Eco_Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataEco_Tbl_Multi_Color_Size_Mst().Where(p => p.CompniyAndContactID == ProduID && p.RecordType == "MultiColor" && p.RecValue != "All Colors").ToList();
                    //listmulticoler.DataSource = List;
                    //listmulticoler.DataBind();
                    //ViewState["MultiColor"] = List;
                }
            }
            if (MultiUOM == Convert.ToBoolean(1))
            {

                linkmultiuom.Visible = true;
                lblmultiuom.Visible = true;
                lblmultiuom.Text = "MultiUOM" + "<br/>";
                if (DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "UOM" && p.TenentID == TID).Count() > 0)
                {
                    List<ICIT_BR_TMP> List3 = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "UOM" && p.TenentID == TID).ToList();

                    listMUOMLIST.DataSource = List3;
                    listMUOMLIST.DataBind();
                    ViewState["MultiUOM"] = List3;
                }
                else
                {
                    //Haresh
                    //List<Eco_Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataEco_Tbl_Multi_Color_Size_Mst().Where(p => p.CompniyAndContactID == ProduID && p.RecordType == "MultiUOM" && p.RecValue != "All Colors").ToList();
                    //listMUOMLIST.DataSource = List;
                    //listMUOMLIST.DataBind();
                    //ViewState["MultiUOM"] = List;
                }

            }
            if (MultiSize == Convert.ToBoolean(1))
            {
                hymultisize.Visible = true;
                lblmultisiz.Visible = true;
                lblmultisiz.Text = "MultiSize" + "<br/>";
                if (DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.SIZECODE != 999999998 && p.RecodName == "MultiSize" && p.TenentID == TID).Count() > 0)
                {
                    List<ICIT_BR_TMP> List2 = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.SIZECODE != 999999998 && p.RecodName == "MultiSize" && p.TenentID == TID).ToList();
                    listSize.DataSource = List2;
                    listSize.DataBind();
                    ViewState["MultiSize"] = List2;
                }
                else
                {
                    //Haresh
                    //List<Eco_Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataEco_Tbl_Multi_Color_Size_Mst().Where(p => p.CompniyAndContactID == ProduID && p.RecordType == "MultiSize" && p.RecValue != "All Size").ToList();
                    //listSize.DataSource = List;
                    //listSize.DataBind();
                    //ViewState["MultiSize"] = List;
                }

            }
            if (Serialized == Convert.ToBoolean(1))
            {
                hyperseriliz.Visible = true;
                lblserilez.Visible = true;
                lblserilez.Text = "Serialized" + "<br/>";
                if (DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.Active == "D" && p.MySysName == "PUR" && p.MyProdID == ProduID && p.Serial_Number != "NO" && p.RecodName == "Serialize" && p.TenentID == TID).Count() > 0)
                {
                    var ListSeril = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.Active == "D" && p.MySysName == "PUR" && p.MyProdID == ProduID && p.Serial_Number != "NO" && p.RecodName == "Serialize" && p.TenentID == TID).ToList();
                    listSerial.DataSource = ListSeril;
                    listSerial.DataBind();
                    ViewState["Serialized"] = ListSeril;
                }
                //else
                //{
                //    int PQTY = Convert.ToInt32(txtQty.Text);
                //    List<Eco_ICIT_BR_Serialize> ListICIT_BR_Serialize = new List<Eco_ICIT_BR_Serialize>();
                //    for (int i = 0; i <= PQTY - 1; i++)
                //    {
                //        Eco_ICIT_BR_Serialize obj = new Eco_ICIT_BR_Serialize();
                //        ListICIT_BR_Serialize.Add(obj);
                //    }
                //    listSerial.DataSource = ListICIT_BR_Serialize;
                //    listSerial.DataBind();
                //    ViewState["Serialized"] = ListICIT_BR_Serialize;
                //}


            }
            if (MultiBinStore == Convert.ToBoolean(1))
            {
                hprMultibin.Visible = true;
                lblmultibin.Visible = true;
                lblmultibin.Text = "MultiBinStore" + "<br/>";
                if (DB.ICIT_BR_TMP.Where(p => p.MyProdID == ProduID && p.MYTRANSID == TCID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "MultiBIN" && p.Bin_ID != 999999998 && p.TenentID == TID).Count() > 0)
                {
                    List<ICIT_BR_TMP> List = DB.ICIT_BR_TMP.Where(p => p.MyProdID == ProduID && p.MYTRANSID == TCID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "MultiBIN" && p.Bin_ID != 999999998 && p.TenentID == TID).ToList();
                    listBin.DataSource = List;
                    listBin.DataBind();
                    ViewState["BindBin"] = List;
                }
                //else
                //{
                //    ICIT_BR_BIN List = new ICIT_BR_BIN();
                //    ListICIT_BR_BIN.Add(List);
                //    listBin.DataSource = ListICIT_BR_BIN;
                //    listBin.DataBind();
                //    ViewState["ListICIT_BR_BIN"] = ListICIT_BR_BIN;
                //}


            }
            if (Perishable == Convert.ToBoolean(1))
            {
                hpeperishibal.Visible = true;
                lblpereshibal.Visible = true;
                lblpereshibal.Text = "Perishable" + "<br/>";
                TextBox txtPerBatchNo = (TextBox)e.Item.FindControl("txtPerBatchNo");
                TextBox txtProDate = (TextBox)e.Item.FindControl("txtProDate");
                TextBox txtExpDate = (TextBox)e.Item.FindControl("txtExpDate");
                TextBox txtLead2Dest = (TextBox)e.Item.FindControl("txtLead2Dest");
                if (DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "Perishable" && p.BatchNo != "999999998" && p.TenentID == TID).Count() > 0)
                {
                    ICIT_BR_TMP obj = DB.ICIT_BR_TMP.Single(p => p.MYTRANSID == TCID && p.MyProdID == ProduID && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "Perishable" && p.BatchNo != "999999998" && p.TenentID == TID);
                    txtPerBatchNo.Text = obj.BatchNo;
                    txtProDate.Text = obj.ProdDate.ToString();
                    txtExpDate.Text = obj.ExpiryDate.ToString();
                    txtLead2Dest.Text = obj.LeadDays2Destroy.ToString();
                }


            }

        }
        protected void listMulticoloerand_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // DateTime TACtionDate = Convert.ToDateTime(txtOrderDate.Text);
            string OICODID = lbltrzctiondate.Text.ToString();
            if (e.CommandName == "Multiuom")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                ListView listMUOMLIST = (ListView)e.Item.FindControl("listMUOMLIST");
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                int QTY = Convert.ToInt32(txtQty.Text);
                int Total = 0;
                for (int j = 0; j < listMUOMLIST.Items.Count; j++)
                {
                    TextBox txtmultisze = (TextBox)listMUOMLIST.Items[j].FindControl("Label38");
                    int TXT = Convert.ToInt32(txtmultisze.Text);
                    Total = Total + TXT;
                }
                if (QTY == Total)
                {
                    for (int j = 0; j < listMUOMLIST.Items.Count(); j++)
                    {
                        Label LBLCOLERID = (Label)listMUOMLIST.Items[j].FindControl("LBLCOLERID");
                        Label LblMyid = (Label)listMUOMLIST.Items[j].FindControl("LblMyid");
                        //TextBox txtuomQty = (TextBox)listMUOMLIST.Items[i].FindControl("txtuomQty");
                        TextBox Label38 = (TextBox)listMUOMLIST.Items[j].FindControl("Label38");
                        int TenentID = TID;
                        int MyProdID = MPID;
                        string period_code = OICODID;
                        string MySysName = "PUR";
                        int UOM = Convert.ToInt32(LBLCOLERID.Text);
                        int SIZECODE = 999999998;
                        int COLORID = 999999998;
                        int BinID = 999999998;
                        string BatchNo = "999999998";
                        string Serialize = "NO";
                        int MYTRANSID = TCNID;
                        int LocationID = LID;
                        int NewQty = Convert.ToInt32(Label38.Text);
                       
                        string Reference = lblrefteshnomber.Text;
                        string RecodName = "UOM";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active = "D";
                        int CRUP_ID = 999999998;
                        Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty, Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);

                    }
                }
                else
                {
                    pnlSuccessMsg123.Visible = true;
                    lblMsg123.Text = "Multi UOM Quantity Are Not Same";
                }
            }
            if (e.CommandName == "btnMultiColoer")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                ListView listmulticoler = (ListView)e.Item.FindControl("listmulticoler");
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                Label lblMultUom = (Label)e.Item.FindControl("lblMultUom");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                int QTY = Convert.ToInt32(txtQty.Text);
                int Total = 0;
                for (int j = 0; j < listmulticoler.Items.Count; j++)
                {
                    TextBox txtcoloerqty = (TextBox)listmulticoler.Items[j].FindControl("txtcoloerqty");
                    int TXT = Convert.ToInt32(txtcoloerqty.Text);
                    Total = Total + TXT;
                }
                if (QTY == Total)
                {
                    for (int j = 0; j < listmulticoler.Items.Count; j++)
                    {
                        Label LBLCOLERID = (Label)listmulticoler.Items[j].FindControl("LBLCOLERID");
                        Label LblMyid = (Label)listmulticoler.Items[j].FindControl("LblMyid");
                        //TextBox txtuomQty = (TextBox)listMUOMLIST.Items[i].FindControl("txtuomQty");
                        TextBox txtcoloerqty = (TextBox)listmulticoler.Items[j].FindControl("txtcoloerqty");
                        int TenentID = TID;
                        int MyProdID = MPID;
                        string period_code = OICODID;
                        string MySysName = "PUR";
                        int UOM = Convert.ToInt32(lblMultUom.Text);
                        int SIZECODE = 999999998;
                        int COLORID = Convert.ToInt32(LBLCOLERID.Text);
                        int BinID = 999999998;
                        string BatchNo = "999999998";
                        string Serialize = "NO";
                        int MYTRANSID = TCNID;
                        int LocationID = LID;
                        int NewQty = Convert.ToInt32(txtcoloerqty.Text);
                       
                        string Reference = lblrefteshnomber.Text;
                        string RecodName = "MultiColor";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active = "D";
                        int CRUP_ID = 999999998;
                        Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty, Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);
                    }
                }
                else
                {
                    pnlSuccessMsg123.Visible = true;
                    lblMsg123.Text = "Multi Color Quantity Are Not Same";
                }

            }
            if (e.CommandName == "btmMultisize")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                ListView listSize = (ListView)e.Item.FindControl("listSize");
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                Label lblMultUom = (Label)e.Item.FindControl("lblMultUom");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                int QTY = Convert.ToInt32(txtQty.Text);
                int Total = 0;
                for (int j = 0; j < listSize.Items.Count; j++)
                {
                    TextBox txtmultisze = (TextBox)listSize.Items[j].FindControl("txtmultisze");
                    int TXT = Convert.ToInt32(txtmultisze.Text);
                    Total = Total + TXT;
                }
                if (QTY == Total)
                {
                    for (int j = 0; j < listSize.Items.Count; j++)
                    {
                        Label LBLCOLERID = (Label)listSize.Items[j].FindControl("LBLCOLERID");
                        Label LblMyid = (Label)listSize.Items[j].FindControl("LblMyid");
                        //TextBox txtuomQty = (TextBox)listMUOMLIST.Items[i].FindControl("txtuomQty");
                        TextBox txtmultisze = (TextBox)listSize.Items[j].FindControl("txtmultisze");

                        int TenentID = TID;
                        int MyProdID = MPID;
                        string period_code = OICODID;
                        string MySysName = "PUR";
                        int UOM = Convert.ToInt32(lblMultUom.Text);
                        int SIZECODE = Convert.ToInt32(LBLCOLERID.Text);
                        int COLORID = 999999998;
                        int BinID = 999999998;
                        string BatchNo = "999999998";
                        string Serialize = "NO";
                        int MYTRANSID = TCNID;
                        int LocationID = LID;
                        int NewQty = Convert.ToInt32(txtmultisze.Text);
                       
                        string Reference = lblrefteshnomber.Text;
                        string RecodName = "MultiSize";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active = "D";
                        int CRUP_ID = 999999998;
                        Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty, Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);
                    }
                }
                else
                {
                    pnlSuccessMsg123.Visible = true;
                    lblMsg123.Text = "Multi Size Quantity Are Not Same";
                }

            }
            if (e.CommandName == "bltiSirroliez")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                ListView listSerial = (ListView)e.Item.FindControl("listSerial");
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                Label lblMultUom = (Label)e.Item.FindControl("lblMultUom");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                int QTY = Convert.ToInt32(txtQty.Text);
                int Total = 0;
                int Cunt = 0;
                int cuntj = 0;
                for (int i = 0; i < listSerial.Items.Count; i++)
                {
                    Cunt = i + 1;
                    TextBox txtlistSerial = (TextBox)listSerial.Items[i].FindControl("txtlistSerial");
                    string SERNuber = txtlistSerial.Text.ToString();
                    if (SERNuber == "")
                    {
                        pnlSuccessMsg123.Visible = true;
                        lblMsg123.Text = "Serial No " + Cunt + " Is Null";
                        return;
                    }
                    for (int j = 0; j < listSerial.Items.Count; j++)
                    {
                        cuntj = j + 1;
                        if (i != j)
                        {
                            TextBox txtSernuber = (TextBox)listSerial.Items[j].FindControl("txtlistSerial");
                            string SerNO = txtSernuber.Text.ToString();
                            if (SERNuber == SerNO)
                            {
                                pnlSuccessMsg123.Visible = true;
                                lblMsg123.Text = "Serial No " + Cunt + " Is Dublicat " + cuntj + " No";
                                return;
                            }
                        }
                    }
                }

                for (int j = 0; j < listSerial.Items.Count; j++)
                {
                    // Label LBLCOLERID = (Label)listSerial.Items[j].FindControl("LBLCOLERID");
                    Label LblMyid = (Label)listSerial.Items[j].FindControl("LblMyid");
                    //TextBox txtuomQty = (TextBox)listMUOMLIST.Items[i].FindControl("txtuomQty");
                    TextBox txtlistSerial = (TextBox)listSerial.Items[j].FindControl("txtlistSerial");
                    string SCRNO = txtlistSerial.Text.ToString();
                    int TenentID = TID;
                    int MyProdID = MPID;
                    string period_code = OICODID;
                    string MySysName = "PUR";
                    int UOM = Convert.ToInt32(lblMultUom.Text);
                    int SIZECODE = 999999998;
                    int COLORID = 999999998;
                    int BinID = 999999998;
                    string BatchNo = "999999998";
                    string Serialize = SCRNO;
                    int MYTRANSID = TCNID;
                    int LocationID = LID;
                    int NewQty = Convert.ToInt32(1);
                   
                    string Reference = lblrefteshnomber.Text;
                    string RecodName = "Serialize";
                    DateTime ProdDate = DateTime.Now;
                    DateTime ExpiryDate = DateTime.Now;
                    DateTime LeadDays2Destroy = DateTime.Now;
                    string Active = "D";
                    int CRUP_ID = 999999998;
                    Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty,  Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);
                }
            }
            if (e.CommandName == "Btnbinmulti")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                ListView listBin = (ListView)e.Item.FindControl("listBin");
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                Label lblMultUom = (Label)e.Item.FindControl("lblMultUom");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                int QTY = Convert.ToInt32(txtQty.Text);
                int Total = 0;
                for (int j = 0; j < listBin.Items.Count; j++)
                {
                    TextBox txtqty = (TextBox)listBin.Items[j].FindControl("txtqty");
                    int TXT = Convert.ToInt32(txtqty.Text);
                    Total = Total + TXT;
                }
                if (QTY == Total)
                {
                    for (int j = 0; j < listBin.Items.Count; j++)
                    {
                        // Label LBLCOLERID = (Label)listBin.Items[j].FindControl("LBLCOLERID");
                        Label lblbinid = (Label)listBin.Items[j].FindControl("lblbinid");
                        //TextBox txtuomQty = (TextBox)listMUOMLIST.Items[i].FindControl("txtuomQty");
                        TextBox txtqty = (TextBox)listBin.Items[j].FindControl("txtqty");
                        int TenentID = TID;
                        int MyProdID = MPID;
                        string period_code = OICODID;
                        string MySysName = "PUR";
                        int UOM = Convert.ToInt32(lblMultUom.Text);
                        int SIZECODE = 999999998;
                        int COLORID = 999999998;
                        int BinID = 999999998;
                        string BatchNo = lblbactnumber.Text;
                        string Serialize = "NO";
                        int MYTRANSID = TCNID;
                        int LocationID = LID;
                        int NewQty = Convert.ToInt32(txtqty.Text);
                       
                        string Reference = lblrefteshnomber.Text;
                        string RecodName = "MultiBIN";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active = "D";
                        int CRUP_ID = 999999998;
                        Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty, Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);
                    }
                }
                else
                {
                    pnlSuccessMsg123.Visible = true;
                    lblMsg123.Text = "Multi Bin Quantity Are Not Same";
                }

            }
            if (e.CommandName == "btnPerishable")
            {
                int MPID = Convert.ToInt32(e.CommandArgument);
                Label labeltarjication = (Label)e.Item.FindControl("labeltarjication");
                int TCNID = Convert.ToInt32(labeltarjication.Text);
                Label lblMultUom = (Label)e.Item.FindControl("lblMultUom");
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                TextBox txtProDate = (TextBox)e.Item.FindControl("txtProDate");
                TextBox txtExpDate = (TextBox)e.Item.FindControl("txtExpDate");
                TextBox txtLead2Dest = (TextBox)e.Item.FindControl("txtLead2Dest");
                TextBox txtPerBatchNo = (TextBox)e.Item.FindControl("txtPerBatchNo");
                int TenentID = TID;
                int MyProdID = MPID;
                string period_code = OICODID;
                string MySysName = "PUR";
                int UOM = Convert.ToInt32(lblMultUom.Text);
                int SIZECODE = 999999998;
                int COLORID = 999999998;
                int BinID = 999999998;
                string BatchNo = txtPerBatchNo.Text;
                string Serialize = "NO";
                int MYTRANSID = TCNID;
                int LocationID = LID;
                int NewQty = Convert.ToInt32(txtQty.Text);
               
                string Reference = lblrefteshnomber.Text;
                string RecodName = "Perishable";
                DateTime ProdDate = Convert.ToDateTime(txtProDate.Text);
                DateTime ExpiryDate = Convert.ToDateTime(txtExpDate.Text);
                DateTime LeadDays2Destroy = Convert.ToDateTime(txtLead2Dest.Text);
                string Active = "D";
                int CRUP_ID = 999999998;
                Classes.EcommAdminClass.insertICIT_BR_TMP(TenentID, MyProdID, period_code, MySysName, UOM, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSID, LocationID, NewQty,  Reference, RecodName, ProdDate, ExpiryDate, LeadDays2Destroy, Active, CRUP_ID);
            }

        }


        protected void listBin_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblbinid = (Label)e.Item.FindControl("lblbinid");
            //Label MYID = (Label)e.Item.FindControl("LblMyid");
            //Label lblbinid = (Label)e.Item.FindControl("lblbinid");
            //int Id = Convert.ToInt32(MYID.Text);
            DropDownList dropBacthCode = (DropDownList)e.Item.FindControl("dropBacthCode");
            Classes.EcommAdminClass.getdropdown(dropBacthCode, TID, "", "", "", "TBLBIN");
            if (lblbinid.Text != null)
            {
                int BID = Convert.ToInt32(lblbinid.Text);
                dropBacthCode.SelectedValue = BID.ToString();
            }

            //dropBacthCode.DataSource = DB.TBLBIN.Where(p => p.ACTIVE == "Y");
            //dropBacthCode.DataTextField = "BINDesc1";
            //dropBacthCode.DataValueField = "BIN_ID";
            //dropBacthCode.DataBind();
            //dropBacthCode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Bacth Name --", "0"));
            //dropBacthCode.SelectedValue = lblbinid.Text.ToString();
        }

        public string getcolerName(int UID)
        {
            return DB.Tbl_Multi_Color_Size_Mst.Single(p => p.RecTypeID == UID && p.TenentID == TID).RecValue;
        }
        public string getproducode(int PID)
        {
            return DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID).ProdName1;
        }

        protected void BTNRECIVE_Click(object sender, EventArgs e)
        {
            for (int i=0;i<listMulticoloerand.Items.Count;i++)
            {
                TextBox txtAmount1 = (TextBox)listMulticoloerand.Items[i].FindControl("txtAmount1");
                TextBox txtfoundqty = (TextBox)listMulticoloerand.Items[i].FindControl("txtfoundqty");
                //TextBox txtt = (TextBox)listMulticoloerand.Items[i].FindControl("txtt");
                int QTYTotal = Convert.ToInt32(txtAmount1.Text);
                int QTYFound = Convert.ToInt32(txtfoundqty.Text);
                int QTYDIFF = QTYTotal - QTYFound;
            }
        }
    }
}