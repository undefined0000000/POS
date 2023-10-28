using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;
using Database;
using System.Collections.Generic;
using Web.ACM;
using Classes;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Web.Hosting;
using AjaxControlToolkit;

namespace Web.ACM
{
    public partial class Acm_Function_Mst : System.Web.UI.Page
    {
        OleDbConnection Econ;
        SqlConnection con1;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
        SqlCommand command2 = new SqlCommand();
        #region Step1
        int count = 0;
        int take = 0;
        int Skip = 0;
        public static int ChoiceID = 0;
        bool flag = false;
        int TID = 0;
        #endregion
        Database.CallEntities DB = new Database.CallEntities();
        Database.CallEntities DB1 = new Database.CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            pnlSuccessMsg.Visible = false;
            if (!IsPostBack)
            {
                Readonly();
                ManageLang();
                pnlSuccessMsg.Visible = false;
                bindTenent();
                FillContractorID();
                BindData();
                btnAdd.ValidationGroup = "ss";
                int CurrentID = 1;
                if (ViewState["Es"] != null)
                    CurrentID = Convert.ToInt32(ViewState["Es"]);
                //BindData();
                // FirstData();
                txtACTIVETILLDATE.Text = DateTime.Now.ToShortDateString();

                lblIconpath.Attributes["class"] = drpICONPATH.SelectedValue.ToString();
                //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                //if (TID == 0)
                //{
                //    PNALGOL.Visible = true;
                //}
                //else
                //{
                //    DrpTENANT_ID.SelectedValue = TID.ToString();
                //    drplocation.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenentID == TID);
                //    drplocation.DataTextField = "LOCNAME1";
                //    drplocation.DataValueField = "LOCATIONID";
                //    drplocation.DataBind();
                //    drplocation.Items.Insert(0, new ListItem("---Select Location---", "0"));
                //    DrpUser.DataSource = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID && p.LOCATION_ID == LID); ;
                //    DrpUser.DataTextField = "FIRST_NAME";
                //    DrpUser.DataValueField = "USER_ID";
                //    DrpUser.DataBind();
                //    DrpUser.Items.Insert(0, new ListItem("---Select---", "0"));

                //    drplocation.SelectedValue = LID.ToString();
                //    ViewState["TenenatID"] = TID;
                //    ViewState["LocationID"] = LID;
                //}
            }
        }
        #region Step2
        public void BindData()
        {
            //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);
            var List = DB.FUNCTION_MST.OrderBy(m => m.MENU_ID).Where(p => p.ACTIVE_FLAG == 1 && p.TenentID == TID).ToList();
            Listview1.DataSource = List;
            Listview1.DataBind();
            //int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            //int Totalrec = List.Count();
            //((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);
        }
        #endregion

        #region #region Page Genarator
        public void GetShow()
        {

            lblMASTER_ID1s.Attributes["class"] = lblMODULE_ID1s.Attributes["class"] = lblMENU_TYPE1s.Attributes["class"] = lblMENU_NAME11s.Attributes["class"] = lblMENU_NAME21s.Attributes["class"] = lblMENU_NAME31s.Attributes["class"] = lblLINK1s.Attributes["class"] = lblURLREWRITE1s.Attributes["class"] = lblMENU_LOCATION1s.Attributes["class"] = lblMENU_ORDER1s.Attributes["class"] = lblDOC_PARENT1s.Attributes["class"] = lblADDFLAGE1s.Attributes["class"] = lblEDITFLAGE1s.Attributes["class"] = lblDELFLAGE1s.Attributes["class"] = lblPRINTFLAGE1s.Attributes["class"] = lblAMIGLOBALE1s.Attributes["class"] = lblMYPERSONAL1s.Attributes["class"] = lblSMALLTEXT1s.Attributes["class"] = lblACTIVETILLDATE1s.Attributes["class"] = lblICONPATH1s.Attributes["class"] = lblCOMMANLINE1s.Attributes["class"] = lblACTIVE_FLAG1s.Attributes["class"] = lblMETAKEYWORD1s.Attributes["class"] = lblMETADESCRIPTION1s.Attributes["class"] = lblHEADERVISIBLEDATA1s.Attributes["class"] = lblHEADERINVISIBLEDATA1s.Attributes["class"] = lblFOOTERVISIBLEDATA1s.Attributes["class"] = lblFOOTERINVISIBLEDATA1s.Attributes["class"] = lblREFID1s.Attributes["class"] = lblMYBUSID1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblMASTER_ID2h.Attributes["class"] = lblMODULE_ID2h.Attributes["class"] = lblMENU_TYPE2h.Attributes["class"] = lblMENU_NAME12h.Attributes["class"] = lblMENU_NAME22h.Attributes["class"] = lblMENU_NAME32h.Attributes["class"] = lblLINK2h.Attributes["class"] = lblURLREWRITE2h.Attributes["class"] = lblMENU_LOCATION2h.Attributes["class"] = lblMENU_ORDER2h.Attributes["class"] = lblDOC_PARENT2h.Attributes["class"] = lblADDFLAGE2h.Attributes["class"] = lblEDITFLAGE2h.Attributes["class"] = lblDELFLAGE2h.Attributes["class"] = lblPRINTFLAGE2h.Attributes["class"] = lblAMIGLOBALE2h.Attributes["class"] = lblMYPERSONAL2h.Attributes["class"] = lblSMALLTEXT2h.Attributes["class"] = lblACTIVETILLDATE2h.Attributes["class"] = lblICONPATH2h.Attributes["class"] = lblCOMMANLINE2h.Attributes["class"] = lblACTIVE_FLAG2h.Attributes["class"] = lblMETAKEYWORD2h.Attributes["class"] = lblMETADESCRIPTION2h.Attributes["class"] = lblHEADERVISIBLEDATA2h.Attributes["class"] = lblHEADERINVISIBLEDATA2h.Attributes["class"] = lblFOOTERVISIBLEDATA2h.Attributes["class"] = lblFOOTERINVISIBLEDATA2h.Attributes["class"] = lblREFID2h.Attributes["class"] = lblMYBUSID2h.Attributes["class"] = "control-label col-md-4  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }
        public void GetHide()
        {
            lblMASTER_ID1s.Attributes["class"] = lblMODULE_ID1s.Attributes["class"] = lblMENU_TYPE1s.Attributes["class"] = lblMENU_NAME11s.Attributes["class"] = lblMENU_NAME21s.Attributes["class"] = lblMENU_NAME31s.Attributes["class"] = lblLINK1s.Attributes["class"] = lblURLREWRITE1s.Attributes["class"] = lblMENU_LOCATION1s.Attributes["class"] = lblMENU_ORDER1s.Attributes["class"] = lblDOC_PARENT1s.Attributes["class"] = lblADDFLAGE1s.Attributes["class"] = lblEDITFLAGE1s.Attributes["class"] = lblDELFLAGE1s.Attributes["class"] = lblPRINTFLAGE1s.Attributes["class"] = lblAMIGLOBALE1s.Attributes["class"] = lblMYPERSONAL1s.Attributes["class"] = lblSMALLTEXT1s.Attributes["class"] = lblACTIVETILLDATE1s.Attributes["class"] = lblICONPATH1s.Attributes["class"] = lblCOMMANLINE1s.Attributes["class"] = lblACTIVE_FLAG1s.Attributes["class"] = lblMETAKEYWORD1s.Attributes["class"] = lblMETADESCRIPTION1s.Attributes["class"] = lblHEADERVISIBLEDATA1s.Attributes["class"] = lblHEADERINVISIBLEDATA1s.Attributes["class"] = lblFOOTERVISIBLEDATA1s.Attributes["class"] = lblFOOTERINVISIBLEDATA1s.Attributes["class"] = lblREFID1s.Attributes["class"] = lblMYBUSID1s.Attributes["class"] = "control-label col-md-4  gethide";
            lblMASTER_ID2h.Attributes["class"] = lblMODULE_ID2h.Attributes["class"] = lblMENU_TYPE2h.Attributes["class"] = lblMENU_NAME12h.Attributes["class"] = lblMENU_NAME22h.Attributes["class"] = lblMENU_NAME32h.Attributes["class"] = lblLINK2h.Attributes["class"] = lblURLREWRITE2h.Attributes["class"] = lblMENU_LOCATION2h.Attributes["class"] = lblMENU_ORDER2h.Attributes["class"] = lblDOC_PARENT2h.Attributes["class"] = lblADDFLAGE2h.Attributes["class"] = lblEDITFLAGE2h.Attributes["class"] = lblDELFLAGE2h.Attributes["class"] = lblPRINTFLAGE2h.Attributes["class"] = lblAMIGLOBALE2h.Attributes["class"] = lblMYPERSONAL2h.Attributes["class"] = lblSMALLTEXT2h.Attributes["class"] = lblACTIVETILLDATE2h.Attributes["class"] = lblICONPATH2h.Attributes["class"] = lblCOMMANLINE2h.Attributes["class"] = lblACTIVE_FLAG2h.Attributes["class"] = lblMETAKEYWORD2h.Attributes["class"] = lblMETADESCRIPTION2h.Attributes["class"] = lblHEADERVISIBLEDATA2h.Attributes["class"] = lblHEADERINVISIBLEDATA2h.Attributes["class"] = lblFOOTERVISIBLEDATA2h.Attributes["class"] = lblFOOTERINVISIBLEDATA2h.Attributes["class"] = lblREFID2h.Attributes["class"] = lblMYBUSID2h.Attributes["class"] = "control-label col-md-4  getshow";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "rtl");

        }
        protected void btnHide_Click(object sender, EventArgs e)
        {
            GetHide();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetShow();
        }
        #endregion
        public void Clear()
        {
            //drpMENU_ID.SelectedIndex =0 ;
            drpMASTER_ID.SelectedIndex = 0;
            drpMODULE_ID.SelectedIndex = 0;
            //txtMENU_TYPE.Text = "";
            txtMENU_NAME1.Text = "";
            txtMENU_NAME2.Text = "";
            txtMENU_NAME3.Text = "";
            txtLINK.Text = "";
            txtURLREWRITE.Text = "";
            drpMenuLocation.SelectedValue = "0";
            txtMENU_ORDER.Text = "";
            txtDOC_PARENT.Text = "";
            //txtCRUP_ID.Text = "";
            //drpADDFLAGE.SelectedIndex =0 ;
            //drpEDITFLAGE.SelectedIndex =0 ;
            //drpDELFLAGE.SelectedIndex =0 ;
            //drpPRINTFLAGE.SelectedIndex =0 ;
            //drpAMIGLOBALE.SelectedIndex =0 ;
            //drpMYPERSONAL.SelectedIndex =0 ;
            txtSMALLTEXT.Text = "";
            txtACTIVETILLDATE.Text = "";
            //drpICONPATH.SelectedValue = "";
            txtCOMMANLINE.Text = "";
            //drpACTIVE_FLAG.SelectedIndex =0 ;
            txtMETATITLE.Text = "";
            txtMETAKEYWORD.Text = "";
            txtMETADESCRIPTION.Text = "";
            txtHEADERVISIBLEDATA.Text = "";
            txtHEADERINVISIBLEDATA.Text = "";
            txtFOOTERVISIBLEDATA.Text = "";
            txtFOOTERINVISIBLEDATA.Text = "";
            drpREFID.SelectedIndex = 0;
            drpMYBUSID.SelectedIndex = 0;
            txtsp1.Text = "";
            txtsp2.Text = "";
            txtsp3.Text = "";
            txtsp4.Text = "";
            txtsp5.Text = "";
            txtvaluesp1.Text = "";
            txtvaluesp2.Text = "";
            txtvaluesp3.Text = "";
            txtvaluesp4.Text = "";
            txtvaluesp5.Text = "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //try
                //{

                if (btnAdd.Text == "AddNew")
                {

                    Write();
                    Clear();
                    btnAdd.Text = "Add";
                    btnAdd.ValidationGroup = "submit";
                }
                else if (btnAdd.Text == "Add")
                {
                    //Separator
                    decimal MENU_ORDER = 0;
                    int MASTER_ID = 0;
                    DateTime ACTIVETILLDATE = DateTime.Now;
                    if (Convert.ToInt32(DrpMultisubmenu.SelectedValue) != 0)
                    {
                        MASTER_ID = Convert.ToInt32(DrpMultisubmenu.SelectedValue);
                    }
                    else
                    {
                        if (Convert.ToInt32(drpMASTER_ID.SelectedValue) != 0)
                        {
                            MASTER_ID = Convert.ToInt32(drpMASTER_ID.SelectedValue);
                        }

                    }

                    int MODULEID = 0;
                    if (Convert.ToInt32(drpMODULE_ID.SelectedValue) != 0)
                        MODULEID = Convert.ToInt32(drpMODULE_ID.SelectedValue);
                    string MENU_TYPE = drpMenuLocation.SelectedValue;
                    string MENU_NAME1 = txtMENU_NAME1.Text;
                    string MENU_NAME2 = txtMENU_NAME2.Text;
                    string MENU_NAME3 = txtMENU_NAME3.Text;
                    string LINK = txtLINK.Text;
                    string URLREWRITE = txtURLREWRITE.Text;
                    string MENU_LOCATION = drpMenuLocation.SelectedValue;
                    if (txtMENU_ORDER.Text != "")
                        MENU_ORDER = Convert.ToDecimal(txtMENU_ORDER.Text);
                    else
                        MENU_ORDER = 0;
                    string DOC_PARENT = txtDOC_PARENT.Text;
                    //objFUNCTION_MST.CRUP_ID = txtCRUP_ID.Text;
                    int ADDFLAGE = cbADDFLAGE.Checked ? 1 : 0;
                    int EDITFLAGE = cbEDITFLAGE.Checked ? 1 : 0;
                    int DELFLAGE = cbDELFLAGE.Checked ? 1 : 0;
                    int PRINTFLAGE = cbPRINTFLAGE.Checked ? 1 : 0;
                    int AMIGLOBALE = cbAMIGLOBALE.Checked ? 1 : 0;
                    int MYPERSONAL = cbMYPERSONAL.Checked ? 1 : 0;
                    int REFID = 0;
                    int TenentID = 0;
                    int MYBUSID = 0;
                    int CRUP_ID = 1;
                    int Role_ID = 0;
                    string SMALLTEXT = txtSMALLTEXT.Text;
                    if (txtACTIVETILLDATE.Text != string.Empty)
                    {
                        ACTIVETILLDATE = Convert.ToDateTime(txtACTIVETILLDATE.Text);
                    }

                    string ICONPATH = drpICONPATH.SelectedItem.ToString();
                    string COMMANLINE = txtCOMMANLINE.Text;
                    int ACTIVE_FLAG = 1;
                    string METATITLE = txtMETATITLE.Text;
                    //objFUNCTION_MST.METATITLE = txtMETATITLE.Text;
                    string METAKEYWORD = txtMETAKEYWORD.Text;
                    string METADESCRIPTION = txtMETADESCRIPTION.Text;
                    string HEADERVISIBLEDATA = txtHEADERVISIBLEDATA.Text;
                    string HEADERINVISIBLEDATA = txtHEADERINVISIBLEDATA.Text;
                    string FOOTERVISIBLEDATA = txtFOOTERVISIBLEDATA.Text;
                    string FOOTERINVISIBLEDATA = txtFOOTERINVISIBLEDATA.Text;
                    DateTime ActiveMenuDate = Convert.ToDateTime(txtMenudate.Text);
                    bool ActiveMenu = Convert.ToBoolean(Chkactivemenu.Checked == true) ? true : false;
                    if (Convert.ToInt32(drpREFID.SelectedValue) != 0)
                    {
                        REFID = Convert.ToInt32(drpREFID.SelectedValue);
                    }

                    if (ViewState["TenenatID"] != null)
                    {
                        TenentID = Convert.ToInt32(ViewState["TenenatID"]);
                    }
                    else
                    {
                        TenentID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

                    }
                    if (Convert.ToInt32(drpMYBUSID.SelectedValue) != 0)
                    {
                        MYBUSID = Convert.ToInt32(drpMYBUSID.SelectedValue);
                    }
                    int LOCATIONID = 0;
                    if (ViewState["LocationID"] != null)
                    {

                        LOCATIONID = Convert.ToInt32(ViewState["LocationID"]);
                    }
                    else
                    {
                        LOCATIONID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                    }
                    if (DB.FUNCTION_MST.Where(p => p.MENU_NAME1 == txtMENU_NAME1.Text && p.TenentID == TenentID && p.MODULE_ID == MODULEID).Count() > 0)
                    {
                        lblMsg.Text = "Duplicate Found...";
                        pnlSuccessMsg.Visible = true;
                        return;
                    }
                    int MEMUID12 = DB.FUNCTION_MST.Where(p => p.TenentID == TenentID).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == TenentID).Max(p => p.MENU_ID) + 1) : 1;
                    if (DB.FUNCTION_MST.Where(p => p.TenentID == TenentID && p.MENU_ID == MEMUID12).Count() > 0)
                    {
                        lblMsg.Text = "Menu Id Is Duplicate...";
                        pnlSuccessMsg.Visible = true;
                        return;
                    }
                    string spname1 = "";
                    string spname2 = "";
                    string spname3 = "";
                    string spname4 = "";
                    string spname5 = "";
                    if (txtsp1.Text != "" && txtvaluesp1.Text != "")
                        spname1 = txtsp1.Text + "=" + txtvaluesp1.Text;
                    if (txtsp2.Text != "" && txtvaluesp2.Text != "")
                        spname2 = txtsp2.Text + "=" + txtvaluesp2.Text;
                    if (txtsp3.Text != "" && txtvaluesp3.Text != "")
                        spname3 = txtsp3.Text + "=" + txtvaluesp3.Text;
                    if (txtsp4.Text != "" && txtvaluesp4.Text != "")
                        spname4 = txtsp4.Text + "=" + txtvaluesp4.Text;
                    if (txtsp5.Text != "" && txtvaluesp5.Text != "")
                        spname5 = txtsp5.Text + "=" + txtvaluesp5.Text;

                    int MEMUID = Classes.ACMClass.InsertDataACMFunction(MEMUID12, MASTER_ID, MODULEID, MENU_TYPE, MENU_NAME1, MENU_NAME1,
                        MENU_NAME1, LINK, URLREWRITE, MENU_LOCATION, MENU_ORDER, DOC_PARENT, SMALLTEXT, ACTIVETILLDATE, ICONPATH,
                        COMMANLINE, METAKEYWORD, METADESCRIPTION, HEADERVISIBLEDATA, HEADERINVISIBLEDATA, FOOTERVISIBLEDATA,
                        FOOTERINVISIBLEDATA, REFID, TenentID, LOCATIONID, MYBUSID, CRUP_ID, METATITLE,
                        ADDFLAGE, EDITFLAGE, DELFLAGE, PRINTFLAGE, AMIGLOBALE, MYPERSONAL, ACTIVE_FLAG, ActiveMenuDate, ActiveMenu, spname1, spname2, spname3, spname4, spname5);
                    var list = DB.PRIVILEGE_MST.Where(p => p.TenentID == TenentID && p.MODULE_ID == MODULEID).ToList();

                    //Insert tempuser
                    int PRIVILEGE_ID = 0; //Convert.ToInt32(item.PRIVILEGE_ID);
                    int User_ID = 0;
                    if (Convert.ToInt32(DrpUser.SelectedValue) != 0)
                    {
                        User_ID = Convert.ToInt32(DrpUser.SelectedValue);
                        Database.USER_MST obj_user = DB.USER_MST.SingleOrDefault(p => p.TenentID == TenentID && p.USER_ID == User_ID);
                        Role_ID = Convert.ToInt32(obj_user.USER_TYPE);
                    }
                    else
                    {
                        User_ID = Convert.ToInt32(DB.USER_MST.Where(p => p.TenentID == TenentID).First().USER_ID);
                        Role_ID = Convert.ToInt32(DB.USER_MST.Where(p => p.TenentID == TenentID).First().USER_TYPE);
                    }

                    string flage = "Insert";
                    //Classes.ACMClass.UpdateTempUser(MEMUID12,
                    //    MASTER_ID, MODULEID, MENU_TYPE, MENU_NAME1,
                    //    MENU_NAME1, MENU_NAME1, LINK, URLREWRITE, MENU_LOCATION,
                    //    MENU_ORDER, DOC_PARENT, SMALLTEXT, ACTIVETILLDATE,
                    //    ICONPATH, COMMANLINE, METAKEYWORD, METADESCRIPTION, HEADERVISIBLEDATA,
                    //    HEADERINVISIBLEDATA, FOOTERVISIBLEDATA, FOOTERINVISIBLEDATA, REFID, TenentID,
                    //    LOCATIONID, MYBUSID, 0, METATITLE, ADDFLAGE,
                    //    EDITFLAGE, DELFLAGE, PRINTFLAGE, AMIGLOBALE,
                    //    MYPERSONAL, ACTIVE_FLAG, ActiveMenuDate,
                    //    ActiveMenu, User_ID, Role_ID, flage);


                    ////insert data in PRIVILAGE_MENU table
                    ////add below untill all the module is inserted
                    ////used check box and used same module
                    //if (DB.PRIVILEGE_MST.Where(p => p.TenentID == TenentID && p.MODULE_ID == MODULEID).Count() > 0)
                    //{
                    //    Database.PRIVILEGE_MST obj_Privil = DB.PRIVILEGE_MST.SingleOrDefault(p => p.TenentID == TenentID && p.MODULE_ID == MODULEID);
                    //    if (DB.PRIVILAGE_MENU.Where(p => p.PRIVILEGE_ID == obj_Privil.PRIVILEGE_ID && p.LOCATION_ID == LOCATIONID && p.TenentID == TenentID).Count() == 0)
                    //    {
                    //        Classes.ACMClass.InsertDataACMPRIVILAGEMENU(TenentID, LOCATIONID, obj_Privil.PRIVILEGE_ID, MEMUID);
                    //    }
                    //    if (DB.MODULE_MAP.Where(p => p.PRIVILEGE_ID == obj_Privil.PRIVILEGE_ID && p.LOCATION_ID == LOCATIONID && p.TenentID == TenentID && p.UserID == User_ID).Count() == 0)
                    //    {
                    //        //insert data in ACMMODULEMAP table
                    //        Classes.ACMClass.InsertDataACMMODULEMAP(TenentID, LOCATIONID, obj_Privil.PRIVILEGE_ID, MODULEID, User_ID);
                    //    }
                    //    //insert data in ACMUSERROLE table
                    //    if (DB.USER_ROLE.Where(p => p.PRIVILEGE_ID == obj_Privil.PRIVILEGE_ID && p.LOCATION_ID == LOCATIONID && p.TenentID == TenentID && p.USER_ID == User_ID).Count() == 0)
                    //    {
                    //        Classes.ACMClass.InsertDataACMUSERROLE(TenentID, LOCATIONID, obj_Privil.PRIVILEGE_ID, User_ID, Role_ID, 0, ACTIVETILLDATE, ActiveMenuDate, 1, "Y");
                    //    }
                    //    if (DB.USER_RIGHTS.Where(p => p.PRIVILEGE_ID == obj_Privil.PRIVILEGE_ID && p.USER_ID == User_ID && p.TenentID == TenentID && p.LOCATION_ID == LOCATIONID).Count() == 0)
                    //    {
                    //        //insert data in USER_RIGHT table
                    //        Classes.ACMClass.InsertDataACMUSERRIGHTS(TenentID, LOCATIONID, obj_Privil.PRIVILEGE_ID, User_ID);
                    //    }
                    //}



                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Save Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);

                    Readonly();
                    btnAdd.Text = "AddNew";
                    btnAdd.ValidationGroup = "ss";
                    FillContractorID();

                }
                else if (btnAdd.Text == "Update")
                {

                    if (ViewState["Edit"] != null && ViewState["TeEdit"] != null)
                    {
                        int MenuID = Convert.ToInt32(ViewState["Edit"]);
                        int TenentID1 = Convert.ToInt32(ViewState["TeEdit"]);
                        int ID = Convert.ToInt32(ViewState["Edit"]);
                        Database.FUNCTION_MST objFUNCTION_MST = DB.FUNCTION_MST.Single(p => p.MENU_ID == MenuID && p.TenentID == TenentID1);
                        objFUNCTION_MST.MASTER_ID = Convert.ToInt32(drpMASTER_ID.SelectedValue);
                        objFUNCTION_MST.MODULE_ID = Convert.ToInt32(drpMODULE_ID.SelectedValue);
                        if (Convert.ToInt32(drpMENU_TYPE.SelectedValue) != 0)
                        {
                            objFUNCTION_MST.MENU_TYPE = drpMENU_TYPE.SelectedValue;
                        }

                        objFUNCTION_MST.MENU_NAME1 = txtMENU_NAME1.Text;
                        objFUNCTION_MST.MENU_NAME2 = txtMENU_NAME2.Text;
                        objFUNCTION_MST.MENU_NAME3 = txtMENU_NAME3.Text;
                        objFUNCTION_MST.LINK = txtLINK.Text;
                        objFUNCTION_MST.URLREWRITE = txtURLREWRITE.Text;
                        objFUNCTION_MST.MENU_LOCATION = drpMenuLocation.SelectedValue;
                        int TenentID = 0;
                        if (ViewState["TenenatID"] != null)
                        {
                            TenentID = Convert.ToInt32(ViewState["TenenatID"]);
                        }

                        if (txtMENU_ORDER.Text != "")
                        {
                            objFUNCTION_MST.MENU_ORDER = Convert.ToDecimal(txtMENU_ORDER.Text);
                        }
                        else
                        {
                            objFUNCTION_MST.MENU_ORDER = 0;
                        }
                        objFUNCTION_MST.DOC_PARENT = txtDOC_PARENT.Text;
                        //objFUNCTION_MST.CRUP_ID = txtCRUP_ID.Text;
                        int ADDFLAGE = cbADDFLAGE.Checked ? 1 : 0;
                        int EDITFLAGE = cbEDITFLAGE.Checked ? 1 : 0;
                        int DELFLAGE = cbDELFLAGE.Checked ? 1 : 0;
                        int PRINTFLAGE = cbPRINTFLAGE.Checked ? 1 : 0;
                        int AMIGLOBALE = cbAMIGLOBALE.Checked ? 1 : 0;
                        int MYPERSONAL = cbMYPERSONAL.Checked ? 1 : 0;
                        objFUNCTION_MST.ADDFLAGE = ADDFLAGE;
                        objFUNCTION_MST.EDITFLAGE = EDITFLAGE;
                        objFUNCTION_MST.DELFLAGE = DELFLAGE;
                        objFUNCTION_MST.PRINTFLAGE = PRINTFLAGE;
                        objFUNCTION_MST.AMIGLOBALE = AMIGLOBALE;
                        objFUNCTION_MST.MYPERSONAL = MYPERSONAL;
                        objFUNCTION_MST.SMALLTEXT = txtSMALLTEXT.Text;
                        if (txtACTIVETILLDATE.Text != null && txtACTIVETILLDATE.Text != "")
                        {
                            objFUNCTION_MST.ACTIVETILLDATE = Convert.ToDateTime(txtACTIVETILLDATE.Text);
                        }
                        else
                        {
                            objFUNCTION_MST.ACTIVETILLDATE = DateTime.Now;
                        }

                        objFUNCTION_MST.ICONPATH = drpICONPATH.SelectedItem.ToString();
                        objFUNCTION_MST.COMMANLINE = txtCOMMANLINE.Text;
                        objFUNCTION_MST.ACTIVE_FLAG = cbACTIVE_FLAG.Checked ? 1 : 0;
                        objFUNCTION_MST.METATITLE = txtMETATITLE.Text;
                        objFUNCTION_MST.METAKEYWORD = txtMETAKEYWORD.Text;
                        objFUNCTION_MST.METADESCRIPTION = txtMETADESCRIPTION.Text;
                        objFUNCTION_MST.HEADERVISIBLEDATA = txtHEADERVISIBLEDATA.Text;
                        objFUNCTION_MST.HEADERINVISIBLEDATA = txtHEADERINVISIBLEDATA.Text;
                        objFUNCTION_MST.FOOTERVISIBLEDATA = txtFOOTERVISIBLEDATA.Text;
                        objFUNCTION_MST.FOOTERINVISIBLEDATA = txtFOOTERINVISIBLEDATA.Text;
                        objFUNCTION_MST.MENUDATE = Convert.ToDateTime(txtMenudate.Text);
                        objFUNCTION_MST.ACTIVEMENU = Chkactivemenu.Checked == true ? true : false;
                        if (Convert.ToInt32(drpREFID.SelectedValue) != 0)
                        {
                            objFUNCTION_MST.REFID = Convert.ToInt32(drpREFID.SelectedValue);
                        }
                        if (Convert.ToInt32(drpMYBUSID.SelectedValue) != 0)
                        {
                            objFUNCTION_MST.MYBUSID = Convert.ToInt32(drpMYBUSID.SelectedValue);
                        }

                        //Classes.ACMClass.InsertDataACMFunction(MEMUID, MASTER_ID, MODULE_ID, MENU_TYPE, MENU_NAME1, MENU_NAME1, MENU_NAME1, LINK, URLREWRITE, MENU_LOCATION, MENU_ORDER, DOC_PARENT, SMALLTEXT, ACTIVETILLDATE, ICONPATH, COMMANLINE, METAKEYWORD, METADESCRIPTION, HEADERVISIBLEDATA, HEADERINVISIBLEDATA, FOOTERVISIBLEDATA, FOOTERINVISIBLEDATA, REFID, TenentID, MYBUSID);

                        ViewState["Edit"] = null;
                        ViewState["MMID"] = MenuID;
                        btnAdd.Text = "AddNew";
                        btnAdd.ValidationGroup = "ss";
                        DB.SaveChanges();

                        //update tempuser
                        int user = Convert.ToInt32(DB.USER_MST.Where(p => p.TenentID == TenentID).First().USER_ID);
                        int ROLE = Convert.ToInt32(DB.USER_MST.Where(p => p.TenentID == TenentID).First().USER_TYPE);
                        string flage = "Update";
                        int Master = Convert.ToInt32(drpMASTER_ID.SelectedValue);
                        EditPrivilage(MenuID, Master, TenentID1);
                        //Classes.ACMClass.UpdateTempUser(MenuID, Convert.ToInt32(drpMASTER_ID.SelectedValue), Convert.ToInt32(drpMODULE_ID.SelectedValue), drpMENU_TYPE.SelectedValue, txtMENU_NAME1.Text, txtMENU_NAME2.Text,
                        //txtMENU_NAME3.Text, txtLINK.Text, txtURLREWRITE.Text, drpMenuLocation.SelectedValue, Convert.ToDecimal(txtMENU_ORDER.Text), txtDOC_PARENT.Text, txtSMALLTEXT.Text, Convert.ToDateTime(txtACTIVETILLDATE.Text), drpICONPATH.SelectedItem.ToString(),
                        //txtCOMMANLINE.Text, txtMETAKEYWORD.Text, txtMETADESCRIPTION.Text, txtHEADERVISIBLEDATA.Text, txtHEADERINVISIBLEDATA.Text, txtFOOTERVISIBLEDATA.Text,
                        //txtFOOTERVISIBLEDATA.Text, Convert.ToInt32(drpREFID.SelectedValue), TenentID, 1, Convert.ToInt32(drpMYBUSID.SelectedValue), 0, txtMETATITLE.Text,
                        //ADDFLAGE, EDITFLAGE, DELFLAGE, PRINTFLAGE, AMIGLOBALE, MYPERSONAL, cbACTIVE_FLAG.Checked ? 1 : 0, Convert.ToDateTime(txtMenudate.Text), Convert.ToBoolean(Chkactivemenu.Checked == true) ? true : false, user, ROLE, flage);

                        Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Edit Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);

                        Readonly();

                    }
                }
                BindData();

                scope.Complete(); //  To commit.

                //}
                //catch (Exception ex)
                //{
                //    throw;
                //}
            }
        }
        public void EditPrivilage(int Memu,int Master,int Tenent)
        {
            List<Database.PRIVILAGE_MENUDemon> editList = DB.PRIVILAGE_MENUDemon.Where(p => p.MENU_ID == Memu).ToList();
            foreach (Database.PRIVILAGE_MENUDemon Edititem in editList)
            {
                Database.PRIVILAGE_MENUDemon PriDel = DB.PRIVILAGE_MENUDemon.Single(p => p.TenentID == Edititem.TenentID && p.PRIVILEGE_MENU_ID == Edititem.PRIVILEGE_MENU_ID && p.PRIVILEGE_ID == Edititem.PRIVILEGE_ID && p.PRIVILAGEFOR == Edititem.PRIVILAGEFOR && p.MENU_ID == Edititem.MENU_ID);
                PriDel.MASTER_ID = Master;
                DB.SaveChanges();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["Previous"].ToString());
        }
        public void bindTenent()
        {
            var Datas = (from fun1 in DB.TBLLOCATIONs
                         select new
                         {
                             fun1.TenentID,

                         }
       ).Distinct();
            //DrpTENANT_ID.DataSource = Datas;
            //DrpTENANT_ID.DataTextField = "TenentID";
            //DrpTENANT_ID.DataValueField = "TenentID";
            //DrpTENANT_ID.DataBind();
            //DrpTENANT_ID.Items.Insert(0, new ListItem("---Select---", "00"));

            //copy Tenent
            var CopyTenet = (from fun1 in DB.TBLLOCATIONs
                             select new
                             {
                                 fun1.TenentID,

                             }).Distinct();
            drpCopyTenent.DataSource = CopyTenet;
            drpCopyTenent.DataTextField = "TenentID";
            drpCopyTenent.DataValueField = "TenentID";
            drpCopyTenent.DataBind();
            drpCopyTenent.Items.Insert(0, new ListItem("---Select---", "00"));
            drpcopyModule.Items.Insert(0, new ListItem("--Select Module--", "0"));
            drpcopyMaster.Items.Insert(0, new ListItem("--Select Master--", "0"));
        }
        public void FillContractorID()
        {
            //int TID = 0;
            //if (DrpTENANT_ID.SelectedValue != "00" && DrpTENANT_ID.SelectedValue != "")
            //{
            //    TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);
            //}
            //else
            //{
            //    TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //}          
            Classes.EcommAdminClass.getdropdown(drpMASTER_ID, TID, "", "", "", "FUNCTION_MST");
            //drpMASTER_ID.DataSource = DB.FUNCTION_MST;
            //drpMASTER_ID.DataTextField = "MENU_NAME1";
            //drpMASTER_ID.DataValueField = "MENU_ID";
            //drpMASTER_ID.DataBind();
            //drpMASTER_ID.Items.Insert(0, new ListItem("---Select Master Menu---", "0"));

            Classes.EcommAdminClass.getdropdown(drpMODULE_ID, TID, "0", "", "", "MODULE_MST");
            //drpMODULE_ID.DataSource = DB.MODULE_MST;
            //drpMODULE_ID.DataTextField = "Module_Name";
            //drpMODULE_ID.DataValueField = "Module_Id";
            //drpMODULE_ID.DataBind();
            //drpMODULE_ID.Items.Insert(0, new ListItem("---Select Module Name---", "0"));
            DrpMultisubmenu.Items.Insert(0, new ListItem("---Select Module Name---", "0"));
            Classes.EcommAdminClass.getdropdown(drpICONPATH, TID, "ACM", "ICON", "", "REFTABLE");
            //select * from REFTABLE where REFTYPE='ACM' and REFSUBTYPE='ICON'

            //var Datas1 = (from fun1 in DB.FUNCTION_MST.Where(p => p.REFID != null)
            //              select new
            //              {
            //                  fun1.REFID
            //              }
            // ).Distinct();

            //drpREFID.DataSource = DB.REFTABLEs.Where(p => p.REFSUBTYPE == "Domain" && p.REFTYPE == "Domain");
            //drpREFID.DataTextField = "REFNAME1";
            //drpREFID.DataValueField = "REFID";
            //drpREFID.DataBind();
            //drpREFID.Items.Insert(0, new ListItem("---Select---", "0"));
            Classes.EcommAdminClass.getdropdown(drpREFID, 0, "Domain", "Domain", "", "REFTABLE");
            //select * from REFTABLE where REFTYPE='Domain' and REFSUBTYPE='Domain'

            //drpMYBUSID.DataSource = DB.MYBUS;
            //drpMYBUSID.DataTextField = "BUSNAME1";
            //drpMYBUSID.DataValueField = "BUSID";
            //drpMYBUSID.DataBind();
            //drpMYBUSID.Items.Insert(0, new ListItem("---Select---", "0"));
            Classes.EcommAdminClass.getdropdown(drpMYBUSID, 1, "", "", "", "MYBUS");
            //select * from MYBUS where TenentID=1

            DrpUser.Items.Insert(0, new ListItem("---Select---", "0"));





        }

        #region Page genarator navigation
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            FirstData();
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            NextData();
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            PrevData();
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            LastData();
        }
        public void FirstData()
        {
            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;
            if (Listview1.SelectedDataKey[2].ToString() != null)
            {
                drpMASTER_ID.SelectedValue = Listview1.SelectedDataKey[2].ToString();
            }
            if (Listview1.SelectedDataKey[3].ToString() != null)
            {
                drpMODULE_ID.SelectedValue = Listview1.SelectedDataKey[3].ToString();
            }

            // drpMENU_TYPE.SelectedValue = Listview1.SelectedDataKey[4].ToString();
            txtMENU_NAME1.Text = Listview1.SelectedDataKey[5].ToString();
            txtMENU_NAME2.Text = Listview1.SelectedDataKey[6].ToString();
            txtMENU_NAME3.Text = Listview1.SelectedDataKey[7].ToString();
            txtLINK.Text = Listview1.SelectedDataKey[8].ToString();
            txtURLREWRITE.Text = Listview1.SelectedDataKey[9].ToString();
            drpMenuLocation.SelectedValue = Listview1.SelectedDataKey[10].ToString();
            txtMENU_ORDER.Text = Listview1.SelectedDataKey[11].ToString();
            txtDOC_PARENT.Text = Listview1.SelectedDataKey[12] != null ? Listview1.SelectedDataKey[12].ToString() : "";
            Boolean id = Convert.ToBoolean(Listview1.SelectedDataKey[18]);
            cbAMIGLOBALE.Checked = id;
            //drpDOC_PARENT.SelectedValue = Listview1.SelectedDataKey[10].ToString();
            // cbADDFLAGE.Checked = Listview1.SelectedDataKey[11];
            txtSMALLTEXT.Text = Listview1.SelectedDataKey[20] != null ? Listview1.SelectedDataKey[20].ToString() : "";
            txtACTIVETILLDATE.Text = Convert.ToDateTime(Listview1.SelectedDataKey[21]).ToString("dd/MM/yyyy");
            drpICONPATH.SelectedItem.Text = Listview1.SelectedDataKey[22].ToString();
            txtCOMMANLINE.Text = Listview1.SelectedDataKey[23] != null ? Listview1.SelectedDataKey[23].ToString() : "";
            //string test = Listview1.SelectedDataKey[22].ToString();
            if (Listview1.SelectedDataKey[25] != null)
                txtMETATITLE.Text = Listview1.SelectedDataKey[25].ToString();
            if (Listview1.SelectedDataKey[26] != null)
                txtMETADESCRIPTION.Text = Listview1.SelectedDataKey[26].ToString();
            if (Listview1.SelectedDataKey[27] != null)
                txtHEADERVISIBLEDATA.Text = Listview1.SelectedDataKey[27].ToString();
            if (Listview1.SelectedDataKey[28] != null)
                txtHEADERINVISIBLEDATA.Text = Listview1.SelectedDataKey[28].ToString();
            if (Listview1.SelectedDataKey[32] != null)
                drpREFID.SelectedValue = Listview1.SelectedDataKey[32].ToString();
            if (Listview1.SelectedDataKey[33] != null)
                drpMYBUSID.SelectedValue = Listview1.SelectedDataKey[33].ToString();
            pnlSuccessMsg.Visible = false;
            if (drpMenuLocation.SelectedValue == "Left Menu")
                MenuSepret.Visible = true;
            else
                MenuSepret.Visible = false;

        }
        public void NextData()
        {

            if (Listview1.SelectedIndex != Listview1.Items.Count - 1)
            {
                Listview1.SelectedIndex = Listview1.SelectedIndex + 1;
                if (Listview1.SelectedDataKey[2].ToString() != null)
                {
                    drpMASTER_ID.SelectedValue = Listview1.SelectedDataKey[2].ToString();
                }
                if (Listview1.SelectedDataKey[3].ToString() != null)
                {
                    drpMODULE_ID.SelectedValue = Listview1.SelectedDataKey[3].ToString();
                }

                // drpMENU_TYPE.SelectedValue = Listview1.SelectedDataKey[4].ToString();
                txtMENU_NAME1.Text = Listview1.SelectedDataKey[5].ToString();
                txtMENU_NAME2.Text = Listview1.SelectedDataKey[6].ToString();
                txtMENU_NAME3.Text = Listview1.SelectedDataKey[7].ToString();
                txtLINK.Text = Listview1.SelectedDataKey[8].ToString();
                txtURLREWRITE.Text = Listview1.SelectedDataKey[9].ToString();
                drpMenuLocation.SelectedValue = Listview1.SelectedDataKey[10].ToString();
                txtMENU_ORDER.Text = Listview1.SelectedDataKey[11].ToString();
                txtDOC_PARENT.Text = Listview1.SelectedDataKey[12] != null ? Listview1.SelectedDataKey[12].ToString() : "";
                Boolean id = Convert.ToBoolean(Listview1.SelectedDataKey[18]);
                cbAMIGLOBALE.Checked = id;
                //drpDOC_PARENT.SelectedValue = Listview1.SelectedDataKey[10].ToString();
                // cbADDFLAGE.Checked = Listview1.SelectedDataKey[11];
                txtSMALLTEXT.Text = Listview1.SelectedDataKey[20] != null ? Listview1.SelectedDataKey[20].ToString() : "";
                txtACTIVETILLDATE.Text = Convert.ToDateTime(Listview1.SelectedDataKey[21]).ToString("dd/MM/yyyy");
                drpICONPATH.SelectedItem.Text = Listview1.SelectedDataKey[22].ToString();
                txtCOMMANLINE.Text = Listview1.SelectedDataKey[23] != null ? Listview1.SelectedDataKey[23].ToString() : "";
                //string test = Listview1.SelectedDataKey[22].ToString();
                if (Listview1.SelectedDataKey[25] != null)
                    txtMETATITLE.Text = Listview1.SelectedDataKey[25].ToString();
                if (Listview1.SelectedDataKey[26] != null)
                    txtMETADESCRIPTION.Text = Listview1.SelectedDataKey[26].ToString();
                if (Listview1.SelectedDataKey[27] != null)
                    txtHEADERVISIBLEDATA.Text = Listview1.SelectedDataKey[27].ToString();
                if (Listview1.SelectedDataKey[28] != null)
                    txtHEADERINVISIBLEDATA.Text = Listview1.SelectedDataKey[28].ToString();
                if (Listview1.SelectedDataKey[32] != null)
                    drpREFID.SelectedValue = Listview1.SelectedDataKey[32].ToString();
                if (Listview1.SelectedDataKey[33] != null)
                    drpMYBUSID.SelectedValue = Listview1.SelectedDataKey[33].ToString();
            }
            else
            {
                lblMsg.Text = "This is last record";
                pnlSuccessMsg.Visible = true;
            }
            if (drpMenuLocation.SelectedValue == "Left Menu")
                MenuSepret.Visible = true;
            else
                MenuSepret.Visible = false;

        }
        public void PrevData()
        {
            if (Listview1.SelectedIndex == 0)
            {
                lblMsg.Text = "This is first record";
                pnlSuccessMsg.Visible = true;

            }
            else
            {
                pnlSuccessMsg.Visible = false;
                Listview1.SelectedIndex = Listview1.SelectedIndex - 1;
                if (Listview1.SelectedDataKey[2].ToString() != null)
                {
                    drpMASTER_ID.SelectedValue = Listview1.SelectedDataKey[2].ToString();
                }
                if (Listview1.SelectedDataKey[3].ToString() != null)
                {
                    drpMODULE_ID.SelectedValue = Listview1.SelectedDataKey[3].ToString();
                }

                // drpMENU_TYPE.SelectedValue = Listview1.SelectedDataKey[4].ToString();
                txtMENU_NAME1.Text = Listview1.SelectedDataKey[5].ToString();
                txtMENU_NAME2.Text = Listview1.SelectedDataKey[6].ToString();
                txtMENU_NAME3.Text = Listview1.SelectedDataKey[7].ToString();
                txtLINK.Text = Listview1.SelectedDataKey[8].ToString();
                txtURLREWRITE.Text = Listview1.SelectedDataKey[9].ToString();
                drpMenuLocation.SelectedValue = Listview1.SelectedDataKey[10].ToString();
                txtMENU_ORDER.Text = Listview1.SelectedDataKey[11].ToString();
                txtDOC_PARENT.Text = Listview1.SelectedDataKey[12] != null ? Listview1.SelectedDataKey[12].ToString() : "";
                Boolean id = Convert.ToBoolean(Listview1.SelectedDataKey[18]);
                cbAMIGLOBALE.Checked = id;
                //drpDOC_PARENT.SelectedValue = Listview1.SelectedDataKey[10].ToString();
                // cbADDFLAGE.Checked = Listview1.SelectedDataKey[11];
                txtSMALLTEXT.Text = Listview1.SelectedDataKey[20] != null ? Listview1.SelectedDataKey[20].ToString() : "";
                txtACTIVETILLDATE.Text = Convert.ToDateTime(Listview1.SelectedDataKey[21]).ToString("dd/MM/yyyy");
                drpICONPATH.SelectedItem.Text = Listview1.SelectedDataKey[22].ToString();
                txtCOMMANLINE.Text = Listview1.SelectedDataKey[23] != null ? Listview1.SelectedDataKey[23].ToString() : "";
                //string test = Listview1.SelectedDataKey[22].ToString();
                if (Listview1.SelectedDataKey[25] != null)
                    txtMETATITLE.Text = Listview1.SelectedDataKey[25].ToString();
                if (Listview1.SelectedDataKey[26] != null)
                    txtMETADESCRIPTION.Text = Listview1.SelectedDataKey[26].ToString();
                if (Listview1.SelectedDataKey[27] != null)
                    txtHEADERVISIBLEDATA.Text = Listview1.SelectedDataKey[27].ToString();
                if (Listview1.SelectedDataKey[28] != null)
                    txtHEADERINVISIBLEDATA.Text = Listview1.SelectedDataKey[28].ToString();
                if (Listview1.SelectedDataKey[32] != null)
                    drpREFID.SelectedValue = Listview1.SelectedDataKey[32].ToString();
                if (Listview1.SelectedDataKey[33] != null)
                    drpMYBUSID.SelectedValue = Listview1.SelectedDataKey[33].ToString();
            }
            if (drpMenuLocation.SelectedValue == "Left Menu")
                MenuSepret.Visible = true;
            else
                MenuSepret.Visible = false;
        }
        public void LastData()
        {
            Listview1.SelectedIndex = Listview1.Items.Count - 1;
            if (Listview1.SelectedDataKey[2].ToString() != null)
            {
                drpMASTER_ID.SelectedValue = Listview1.SelectedDataKey[2].ToString();
            }
            if (Listview1.SelectedDataKey[3].ToString() != null)
            {
                drpMODULE_ID.SelectedValue = Listview1.SelectedDataKey[3].ToString();
            }

            // drpMENU_TYPE.SelectedValue = Listview1.SelectedDataKey[4].ToString();
            txtMENU_NAME1.Text = Listview1.SelectedDataKey[5].ToString();
            txtMENU_NAME2.Text = Listview1.SelectedDataKey[6].ToString();
            txtMENU_NAME3.Text = Listview1.SelectedDataKey[7].ToString();
            txtLINK.Text = Listview1.SelectedDataKey[8].ToString();
            txtURLREWRITE.Text = Listview1.SelectedDataKey[9].ToString();
            drpMenuLocation.SelectedValue = Listview1.SelectedDataKey[10].ToString();
            txtMENU_ORDER.Text = Listview1.SelectedDataKey[11].ToString();
            txtDOC_PARENT.Text = Listview1.SelectedDataKey[12] != null ? Listview1.SelectedDataKey[12].ToString() : "";
            Boolean id = Convert.ToBoolean(Listview1.SelectedDataKey[18]);
            cbAMIGLOBALE.Checked = id;
            //drpDOC_PARENT.SelectedValue = Listview1.SelectedDataKey[10].ToString();
            // cbADDFLAGE.Checked = Listview1.SelectedDataKey[11];
            txtSMALLTEXT.Text = Listview1.SelectedDataKey[20] != null ? Listview1.SelectedDataKey[20].ToString() : "";
            txtACTIVETILLDATE.Text = Convert.ToDateTime(Listview1.SelectedDataKey[21]).ToString("dd/MM/yyyy");
            drpICONPATH.SelectedItem.Text = Listview1.SelectedDataKey[22].ToString();
            txtCOMMANLINE.Text = Listview1.SelectedDataKey[23] != null ? Listview1.SelectedDataKey[23].ToString() : "";
            //string test = Listview1.SelectedDataKey[22].ToString();
            if (Listview1.SelectedDataKey[25] != null)
                txtMETATITLE.Text = Listview1.SelectedDataKey[25].ToString();
            if (Listview1.SelectedDataKey[26] != null)
                txtMETADESCRIPTION.Text = Listview1.SelectedDataKey[26].ToString();
            if (Listview1.SelectedDataKey[27] != null)
                txtHEADERVISIBLEDATA.Text = Listview1.SelectedDataKey[27].ToString();
            if (Listview1.SelectedDataKey[28] != null)
                txtHEADERINVISIBLEDATA.Text = Listview1.SelectedDataKey[28].ToString();
            if (Listview1.SelectedDataKey[32] != null)
                drpREFID.SelectedValue = Listview1.SelectedDataKey[32].ToString();
            if (Listview1.SelectedDataKey[33] != null)
                drpMYBUSID.SelectedValue = Listview1.SelectedDataKey[33].ToString();
            if (drpMenuLocation.SelectedValue == "Left Menu")
                MenuSepret.Visible = true;
            else
                MenuSepret.Visible = false;
        }

        #endregion


        #region PAge Genarator language

        protected void btnEditLable_Click(object sender, EventArgs e)
        {
            if (Session["LANGUAGE"].ToString() == "ar-KW")
            {
                if (btnEditLable.Text == "Update Label")
                {

                    //2false
                    lblMASTER_ID2h.Visible = lblMODULE_ID2h.Visible = lblMENU_TYPE2h.Visible = lblMENU_NAME12h.Visible = lblMENU_NAME22h.Visible = lblMENU_NAME32h.Visible = lblLINK2h.Visible = lblURLREWRITE2h.Visible = lblMENU_LOCATION2h.Visible = lblMENU_ORDER2h.Visible = lblDOC_PARENT2h.Visible = lblADDFLAGE2h.Visible = lblEDITFLAGE2h.Visible = lblDELFLAGE2h.Visible = lblPRINTFLAGE2h.Visible = lblAMIGLOBALE2h.Visible = lblMYPERSONAL2h.Visible = lblSMALLTEXT2h.Visible = lblACTIVETILLDATE2h.Visible = lblICONPATH2h.Visible = lblCOMMANLINE2h.Visible = lblACTIVE_FLAG2h.Visible = lblMETAKEYWORD2h.Visible = lblMETADESCRIPTION2h.Visible = lblHEADERVISIBLEDATA2h.Visible = lblHEADERINVISIBLEDATA2h.Visible = lblFOOTERVISIBLEDATA2h.Visible = lblFOOTERINVISIBLEDATA2h.Visible = lblREFID2h.Visible = lblMYBUSID2h.Visible = false;
                    //2true
                    txtMASTER_ID2h.Visible = txtMODULE_ID2h.Visible = txtMENU_TYPE2h.Visible = txtMENU_NAME12h.Visible = txtMENU_NAME22h.Visible = txtMENU_NAME32h.Visible = txtLINK2h.Visible = txtURLREWRITE2h.Visible = txtMENU_LOCATION2h.Visible = txtMENU_ORDER2h.Visible = txtDOC_PARENT2h.Visible = txtADDFLAGE2h.Visible = txtEDITFLAGE2h.Visible = txtDELFLAGE2h.Visible = txtPRINTFLAGE2h.Visible = txtAMIGLOBALE2h.Visible = txtMYPERSONAL2h.Visible = txtSMALLTEXT2h.Visible = txtACTIVETILLDATE2h.Visible = txtICONPATH2h.Visible = txtCOMMANLINE2h.Visible = txtACTIVE_FLAG2h.Visible = txtMETAKEYWORD2h.Visible = txtMETADESCRIPTION2h.Visible = txtHEADERVISIBLEDATA2h.Visible = txtHEADERINVISIBLEDATA2h.Visible = txtFOOTERVISIBLEDATA2h.Visible = txtFOOTERINVISIBLEDATA2h.Visible = txtREFID2h.Visible = txtMYBUSID2h.Visible = true;

                    //header
                    lblHeader.Visible = false;
                    txtHeader.Visible = true;
                    btnEditLable.Text = "Save Label";
                }
                else
                {
                    SaveLabel(Session["LANGUAGE"].ToString());

                    ManageLang();
                    btnEditLable.Text = "Update Label";
                    //2true
                    lblMASTER_ID2h.Visible = lblMODULE_ID2h.Visible = lblMENU_TYPE2h.Visible = lblMENU_NAME12h.Visible = lblMENU_NAME22h.Visible = lblMENU_NAME32h.Visible = lblLINK2h.Visible = lblURLREWRITE2h.Visible = lblMENU_LOCATION2h.Visible = lblMENU_ORDER2h.Visible = lblDOC_PARENT2h.Visible = lblADDFLAGE2h.Visible = lblEDITFLAGE2h.Visible = lblDELFLAGE2h.Visible = lblPRINTFLAGE2h.Visible = lblAMIGLOBALE2h.Visible = lblMYPERSONAL2h.Visible = lblSMALLTEXT2h.Visible = lblACTIVETILLDATE2h.Visible = lblICONPATH2h.Visible = lblCOMMANLINE2h.Visible = lblACTIVE_FLAG2h.Visible = lblMETAKEYWORD2h.Visible = lblMETADESCRIPTION2h.Visible = lblHEADERVISIBLEDATA2h.Visible = lblHEADERINVISIBLEDATA2h.Visible = lblFOOTERVISIBLEDATA2h.Visible = lblFOOTERINVISIBLEDATA2h.Visible = lblREFID2h.Visible = lblMYBUSID2h.Visible = true;
                    //2false
                    txtMASTER_ID2h.Visible = txtMODULE_ID2h.Visible = txtMENU_TYPE2h.Visible = txtMENU_NAME12h.Visible = txtMENU_NAME22h.Visible = txtMENU_NAME32h.Visible = txtLINK2h.Visible = txtURLREWRITE2h.Visible = txtMENU_LOCATION2h.Visible = txtMENU_ORDER2h.Visible = txtDOC_PARENT2h.Visible = txtADDFLAGE2h.Visible = txtEDITFLAGE2h.Visible = txtDELFLAGE2h.Visible = txtPRINTFLAGE2h.Visible = txtAMIGLOBALE2h.Visible = txtMYPERSONAL2h.Visible = txtSMALLTEXT2h.Visible = txtACTIVETILLDATE2h.Visible = txtICONPATH2h.Visible = txtCOMMANLINE2h.Visible = txtACTIVE_FLAG2h.Visible = txtMETAKEYWORD2h.Visible = txtMETADESCRIPTION2h.Visible = txtHEADERVISIBLEDATA2h.Visible = txtHEADERINVISIBLEDATA2h.Visible = txtFOOTERVISIBLEDATA2h.Visible = txtFOOTERINVISIBLEDATA2h.Visible = txtREFID2h.Visible = txtMYBUSID2h.Visible = false;

                    //header
                    lblHeader.Visible = true;
                    txtHeader.Visible = false;
                }
            }
            else
            {
                if (btnEditLable.Text == "Update Label")
                {
                    //1false
                    lblMASTER_ID1s.Visible = lblMODULE_ID1s.Visible = lblMENU_TYPE1s.Visible = lblMENU_NAME11s.Visible = lblMENU_NAME21s.Visible = lblMENU_NAME31s.Visible = lblLINK1s.Visible = lblURLREWRITE1s.Visible = lblMENU_LOCATION1s.Visible = lblMENU_ORDER1s.Visible = lblDOC_PARENT1s.Visible = lblADDFLAGE1s.Visible = lblEDITFLAGE1s.Visible = lblDELFLAGE1s.Visible = lblPRINTFLAGE1s.Visible = lblAMIGLOBALE1s.Visible = lblMYPERSONAL1s.Visible = lblSMALLTEXT1s.Visible = lblACTIVETILLDATE1s.Visible = lblICONPATH1s.Visible = lblCOMMANLINE1s.Visible = lblACTIVE_FLAG1s.Visible = lblMETAKEYWORD1s.Visible = lblMETADESCRIPTION1s.Visible = lblHEADERVISIBLEDATA1s.Visible = lblHEADERINVISIBLEDATA1s.Visible = lblFOOTERVISIBLEDATA1s.Visible = lblFOOTERINVISIBLEDATA1s.Visible = lblREFID1s.Visible = lblMYBUSID1s.Visible = false;
                    //1true
                    txtMASTER_ID1s.Visible = txtMODULE_ID1s.Visible = txtMENU_TYPE1s.Visible = txtMENU_NAME11s.Visible = txtMENU_NAME21s.Visible = txtMENU_NAME31s.Visible = txtLINK1s.Visible = txtURLREWRITE1s.Visible = txtMENU_LOCATION1s.Visible = txtMENU_ORDER1s.Visible = txtDOC_PARENT1s.Visible = txtADDFLAGE1s.Visible = txtEDITFLAGE1s.Visible = txtDELFLAGE1s.Visible = txtPRINTFLAGE1s.Visible = txtAMIGLOBALE1s.Visible = txtMYPERSONAL1s.Visible = txtSMALLTEXT1s.Visible = txtACTIVETILLDATE1s.Visible = txtICONPATH1s.Visible = txtCOMMANLINE1s.Visible = txtACTIVE_FLAG1s.Visible = txtMETAKEYWORD1s.Visible = txtMETADESCRIPTION1s.Visible = txtHEADERVISIBLEDATA1s.Visible = txtHEADERINVISIBLEDATA1s.Visible = txtFOOTERVISIBLEDATA1s.Visible = txtFOOTERINVISIBLEDATA1s.Visible = txtREFID1s.Visible = txtMYBUSID1s.Visible = true;
                    //header
                    lblHeader.Visible = false;
                    txtHeader.Visible = true;
                    btnEditLable.Text = "Save Label";
                }
                else
                {
                    SaveLabel(Session["LANGUAGE"].ToString());
                    ManageLang();
                    btnEditLable.Text = "Update Label";
                    //1true
                    lblMASTER_ID1s.Visible = lblMODULE_ID1s.Visible = lblMENU_TYPE1s.Visible = lblMENU_NAME11s.Visible = lblMENU_NAME21s.Visible = lblMENU_NAME31s.Visible = lblLINK1s.Visible = lblURLREWRITE1s.Visible = lblMENU_LOCATION1s.Visible = lblMENU_ORDER1s.Visible = lblDOC_PARENT1s.Visible = lblADDFLAGE1s.Visible = lblEDITFLAGE1s.Visible = lblDELFLAGE1s.Visible = lblPRINTFLAGE1s.Visible = lblAMIGLOBALE1s.Visible = lblMYPERSONAL1s.Visible = lblSMALLTEXT1s.Visible = lblACTIVETILLDATE1s.Visible = lblICONPATH1s.Visible = lblCOMMANLINE1s.Visible = lblACTIVE_FLAG1s.Visible = lblMETAKEYWORD1s.Visible = lblMETADESCRIPTION1s.Visible = lblHEADERVISIBLEDATA1s.Visible = lblHEADERINVISIBLEDATA1s.Visible = lblFOOTERVISIBLEDATA1s.Visible = lblFOOTERINVISIBLEDATA1s.Visible = lblREFID1s.Visible = lblMYBUSID1s.Visible = true;
                    //1false
                    txtMASTER_ID1s.Visible = txtMODULE_ID1s.Visible = txtMENU_TYPE1s.Visible = txtMENU_NAME11s.Visible = txtMENU_NAME21s.Visible = txtMENU_NAME31s.Visible = txtLINK1s.Visible = txtURLREWRITE1s.Visible = txtMENU_LOCATION1s.Visible = txtMENU_ORDER1s.Visible = txtDOC_PARENT1s.Visible = txtADDFLAGE1s.Visible = txtEDITFLAGE1s.Visible = txtDELFLAGE1s.Visible = txtPRINTFLAGE1s.Visible = txtAMIGLOBALE1s.Visible = txtMYPERSONAL1s.Visible = txtSMALLTEXT1s.Visible = txtACTIVETILLDATE1s.Visible = txtICONPATH1s.Visible = txtCOMMANLINE1s.Visible = txtACTIVE_FLAG1s.Visible = txtMETAKEYWORD1s.Visible = txtMETADESCRIPTION1s.Visible = txtHEADERVISIBLEDATA1s.Visible = txtHEADERINVISIBLEDATA1s.Visible = txtFOOTERVISIBLEDATA1s.Visible = txtFOOTERINVISIBLEDATA1s.Visible = txtREFID1s.Visible = txtMYBUSID1s.Visible = false;
                    //header
                    lblHeader.Visible = true;
                    txtHeader.Visible = false;
                }
            }
        }
        public void RecieveLabel(string lang)
        {
            string str = "";
            string PID = ((ACMMaster)this.Master).getOwnPage();

            List<Database.TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("ACM_FUNCTION_MST").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.TBLLabelDTL item in List)
            {
                if (lblMASTER_ID1s.ID == item.LabelID)
                    txtMASTER_ID1s.Text = lblMASTER_ID1s.Text = item.LabelName;
                else if (lblMODULE_ID1s.ID == item.LabelID)
                    txtMODULE_ID1s.Text = lblMODULE_ID1s.Text = lblhMODULE_ID.Text = item.LabelName;
                else if (lblMENU_TYPE1s.ID == item.LabelID)
                    txtMENU_TYPE1s.Text = lblMENU_TYPE1s.Text = item.LabelName;
                else if (lblMENU_NAME11s.ID == item.LabelID)
                    txtMENU_NAME11s.Text = lblMENU_NAME11s.Text = lblhMENU_NAME1.Text = item.LabelName;
                else if (lblMENU_NAME21s.ID == item.LabelID)
                    txtMENU_NAME21s.Text = lblMENU_NAME21s.Text = item.LabelName;
                else if (lblMENU_NAME31s.ID == item.LabelID)
                    txtMENU_NAME31s.Text = lblMENU_NAME31s.Text = item.LabelName;
                else if (lblLINK1s.ID == item.LabelID)
                    txtLINK1s.Text = lblLINK1s.Text = item.LabelName;//lblhLINK.Text =
                else if (lblURLREWRITE1s.ID == item.LabelID)
                    txtURLREWRITE1s.Text = lblURLREWRITE1s.Text = lblhURLREWRITE.Text = item.LabelName;
                else if (lblMENU_LOCATION1s.ID == item.LabelID)
                    txtMENU_LOCATION1s.Text = lblMENU_LOCATION1s.Text = item.LabelName;
                else if (lblMENU_ORDER1s.ID == item.LabelID)
                    txtMENU_ORDER1s.Text = lblMENU_ORDER1s.Text = lblhMENU_ORDER.Text = item.LabelName;
                else if (lblDOC_PARENT1s.ID == item.LabelID)
                    txtDOC_PARENT1s.Text = lblDOC_PARENT1s.Text = item.LabelName;
                else if (lblADDFLAGE1s.ID == item.LabelID)
                    txtADDFLAGE1s.Text = lblADDFLAGE1s.Text = item.LabelName;
                else if (lblEDITFLAGE1s.ID == item.LabelID)
                    txtEDITFLAGE1s.Text = lblEDITFLAGE1s.Text = item.LabelName;
                else if (lblDELFLAGE1s.ID == item.LabelID)
                    txtDELFLAGE1s.Text = lblDELFLAGE1s.Text = item.LabelName;
                else if (lblPRINTFLAGE1s.ID == item.LabelID)
                    txtPRINTFLAGE1s.Text = lblPRINTFLAGE1s.Text = item.LabelName;
                else if (lblAMIGLOBALE1s.ID == item.LabelID)
                    txtAMIGLOBALE1s.Text = lblAMIGLOBALE1s.Text = item.LabelName;//lblhAMIGLOBALE.Text = 
                else if (lblMYPERSONAL1s.ID == item.LabelID)
                    txtMYPERSONAL1s.Text = lblMYPERSONAL1s.Text = item.LabelName;
                else if (lblSMALLTEXT1s.ID == item.LabelID)
                    txtSMALLTEXT1s.Text = lblSMALLTEXT1s.Text = item.LabelName;
                else if (lblACTIVETILLDATE1s.ID == item.LabelID)
                    txtACTIVETILLDATE1s.Text = lblACTIVETILLDATE1s.Text = lblhACTIVETILLDATE.Text = item.LabelName;
                else if (lblICONPATH1s.ID == item.LabelID)
                    txtICONPATH1s.Text = lblICONPATH1s.Text = item.LabelName;
                else if (lblCOMMANLINE1s.ID == item.LabelID)
                    txtCOMMANLINE1s.Text = lblCOMMANLINE1s.Text = item.LabelName;
                else if (lblACTIVE_FLAG1s.ID == item.LabelID)
                    txtACTIVE_FLAG1s.Text = lblACTIVE_FLAG1s.Text = item.LabelName;
                else if (lblMETAKEYWORD1s.ID == item.LabelID)
                    txtMETAKEYWORD1s.Text = lblMETAKEYWORD1s.Text = item.LabelName;
                else if (lblMETADESCRIPTION1s.ID == item.LabelID)
                    txtMETADESCRIPTION1s.Text = lblMETADESCRIPTION1s.Text = item.LabelName;
                else if (lblHEADERVISIBLEDATA1s.ID == item.LabelID)
                    txtHEADERVISIBLEDATA1s.Text = lblHEADERVISIBLEDATA1s.Text = item.LabelName;
                else if (lblHEADERINVISIBLEDATA1s.ID == item.LabelID)
                    txtHEADERINVISIBLEDATA1s.Text = lblHEADERINVISIBLEDATA1s.Text = item.LabelName;
                else if (lblFOOTERVISIBLEDATA1s.ID == item.LabelID)
                    txtFOOTERVISIBLEDATA1s.Text = lblFOOTERVISIBLEDATA1s.Text = item.LabelName;
                else if (lblFOOTERINVISIBLEDATA1s.ID == item.LabelID)
                    txtFOOTERINVISIBLEDATA1s.Text = lblFOOTERINVISIBLEDATA1s.Text = item.LabelName;
                else if (lblREFID1s.ID == item.LabelID)
                    txtREFID1s.Text = lblREFID1s.Text = item.LabelName;
                else if (lblMYBUSID1s.ID == item.LabelID)
                    txtMYBUSID1s.Text = lblMYBUSID1s.Text = item.LabelName;

                else if (lblMASTER_ID2h.ID == item.LabelID)
                    txtMASTER_ID2h.Text = lblMASTER_ID2h.Text = item.LabelName;
                else if (lblMODULE_ID2h.ID == item.LabelID)
                    txtMODULE_ID2h.Text = lblMODULE_ID2h.Text = lblhMODULE_ID.Text = item.LabelName;
                else if (lblMENU_TYPE2h.ID == item.LabelID)
                    txtMENU_TYPE2h.Text = lblMENU_TYPE2h.Text = item.LabelName;
                else if (lblMENU_NAME12h.ID == item.LabelID)
                    txtMENU_NAME12h.Text = lblMENU_NAME12h.Text = lblhMENU_NAME1.Text = item.LabelName;
                else if (lblMENU_NAME22h.ID == item.LabelID)
                    txtMENU_NAME22h.Text = lblMENU_NAME22h.Text = item.LabelName;
                else if (lblMENU_NAME32h.ID == item.LabelID)
                    txtMENU_NAME32h.Text = lblMENU_NAME32h.Text = item.LabelName;
                else if (lblLINK2h.ID == item.LabelID)
                    txtLINK2h.Text = lblLINK2h.Text = item.LabelName;//lblhLINK.Text =
                else if (lblURLREWRITE2h.ID == item.LabelID)
                    txtURLREWRITE2h.Text = lblURLREWRITE2h.Text = lblhURLREWRITE.Text = item.LabelName;
                else if (lblMENU_LOCATION2h.ID == item.LabelID)
                    txtMENU_LOCATION2h.Text = lblMENU_LOCATION2h.Text = item.LabelName;
                else if (lblMENU_ORDER2h.ID == item.LabelID)
                    txtMENU_ORDER2h.Text = lblMENU_ORDER2h.Text = lblhMENU_ORDER.Text = item.LabelName;
                else if (lblDOC_PARENT2h.ID == item.LabelID)
                    txtDOC_PARENT2h.Text = lblDOC_PARENT2h.Text = item.LabelName;
                else if (lblADDFLAGE2h.ID == item.LabelID)
                    txtADDFLAGE2h.Text = lblADDFLAGE2h.Text = item.LabelName;
                else if (lblEDITFLAGE2h.ID == item.LabelID)
                    txtEDITFLAGE2h.Text = lblEDITFLAGE2h.Text = item.LabelName;
                else if (lblDELFLAGE2h.ID == item.LabelID)
                    txtDELFLAGE2h.Text = lblDELFLAGE2h.Text = item.LabelName;
                else if (lblPRINTFLAGE2h.ID == item.LabelID)
                    txtPRINTFLAGE2h.Text = lblPRINTFLAGE2h.Text = item.LabelName;
                else if (lblAMIGLOBALE2h.ID == item.LabelID)
                    txtAMIGLOBALE2h.Text = lblAMIGLOBALE2h.Text = item.LabelName;//lblhAMIGLOBALE.Text = 
                else if (lblMYPERSONAL2h.ID == item.LabelID)
                    txtMYPERSONAL2h.Text = lblMYPERSONAL2h.Text = item.LabelName;
                else if (lblSMALLTEXT2h.ID == item.LabelID)
                    txtSMALLTEXT2h.Text = lblSMALLTEXT2h.Text = item.LabelName;
                else if (lblACTIVETILLDATE2h.ID == item.LabelID)
                    txtACTIVETILLDATE2h.Text = lblACTIVETILLDATE2h.Text = lblhACTIVETILLDATE.Text = item.LabelName;
                else if (lblICONPATH2h.ID == item.LabelID)
                    txtICONPATH2h.Text = lblICONPATH2h.Text = item.LabelName;
                else if (lblCOMMANLINE2h.ID == item.LabelID)
                    txtCOMMANLINE2h.Text = lblCOMMANLINE2h.Text = item.LabelName;
                else if (lblACTIVE_FLAG2h.ID == item.LabelID)
                    txtACTIVE_FLAG2h.Text = lblACTIVE_FLAG2h.Text = item.LabelName;

                else if (lblMETAKEYWORD2h.ID == item.LabelID)
                    txtMETAKEYWORD2h.Text = lblMETAKEYWORD2h.Text = item.LabelName;
                else if (lblMETADESCRIPTION2h.ID == item.LabelID)
                    txtMETADESCRIPTION2h.Text = lblMETADESCRIPTION2h.Text = item.LabelName;
                else if (lblHEADERVISIBLEDATA2h.ID == item.LabelID)
                    txtHEADERVISIBLEDATA2h.Text = lblHEADERVISIBLEDATA2h.Text = item.LabelName;
                else if (lblHEADERINVISIBLEDATA2h.ID == item.LabelID)
                    txtHEADERINVISIBLEDATA2h.Text = lblHEADERINVISIBLEDATA2h.Text = item.LabelName;
                else if (lblFOOTERVISIBLEDATA2h.ID == item.LabelID)
                    txtFOOTERVISIBLEDATA2h.Text = lblFOOTERVISIBLEDATA2h.Text = item.LabelName;
                else if (lblFOOTERINVISIBLEDATA2h.ID == item.LabelID)
                    txtFOOTERINVISIBLEDATA2h.Text = lblFOOTERINVISIBLEDATA2h.Text = item.LabelName;
                else if (lblREFID2h.ID == item.LabelID)
                    txtREFID2h.Text = lblREFID2h.Text = item.LabelName;
                else if (lblMYBUSID2h.ID == item.LabelID)
                    txtMYBUSID2h.Text = lblMYBUSID2h.Text = item.LabelName;

                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
            }
            drpSort.Items.Clear();
            drpSort.Items.Insert(0, new ListItem("---Sorting By---", "0"));
            drpSort.Items.Insert(1, new ListItem(lblhMODULE_ID.Text, "1"));
            drpSort.Items.Insert(2, new ListItem(lblhMENU_NAME1.Text, "2"));
            //drpSort.Items.Insert(3, new ListItem(lblhLINK.Text, "3"));
            drpSort.Items.Insert(3, new ListItem(lblhURLREWRITE.Text, "3"));
            drpSort.Items.Insert(4, new ListItem(lblhMENU_ORDER.Text, "4"));
            //drpSort.Items.Insert(6, new ListItem(lblhAMIGLOBALE.Text, "6"));
            drpSort.Items.Insert(5, new ListItem(lblhACTIVETILLDATE.Text, "5"));

        }
        public void SaveLabel(string lang)
        {
            string PID = ((ACMMaster)this.Master).getOwnPage();
            //List<Database.TBLLabelDTL> List = DB.TBLLabelDTLs.Where(p => p.LabelMstID == PID  && p.LANGDISP == lang).ToList();
            List<Database.TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("ACM_FUNCTION_MST").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("\\ACM\\xml\\ACM_FUNCTION_MST.xml"));
            foreach (Database.TBLLabelDTL item in List)
            {

                var obj = ((ACMMaster)this.Master).Bindxml("ACM_FUNCTION_MST").Single(p => p.LabelID == item.LabelID && p.LabelMstID == PID && p.LANGDISP == lang);
                int i = obj.ID - 1;

                if (lblMASTER_ID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMASTER_ID1s.Text;
                else if (lblMODULE_ID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMODULE_ID1s.Text;
                else if (lblMENU_TYPE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_TYPE1s.Text;
                else if (lblMENU_NAME11s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME11s.Text;
                else if (lblMENU_NAME21s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME21s.Text;
                else if (lblMENU_NAME31s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME31s.Text;
                else if (lblLINK1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLINK1s.Text;
                else if (lblURLREWRITE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtURLREWRITE1s.Text;
                else if (lblMENU_LOCATION1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_LOCATION1s.Text;
                else if (lblMENU_ORDER1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_ORDER1s.Text;
                else if (lblDOC_PARENT1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtDOC_PARENT1s.Text;
                else if (lblADDFLAGE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDFLAGE1s.Text;
                else if (lblEDITFLAGE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtEDITFLAGE1s.Text;
                else if (lblDELFLAGE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtDELFLAGE1s.Text;
                else if (lblPRINTFLAGE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPRINTFLAGE1s.Text;
                else if (lblAMIGLOBALE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtAMIGLOBALE1s.Text;
                else if (lblMYPERSONAL1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMYPERSONAL1s.Text;
                else if (lblSMALLTEXT1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSMALLTEXT1s.Text;
                else if (lblACTIVETILLDATE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtACTIVETILLDATE1s.Text;
                else if (lblICONPATH1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtICONPATH1s.Text;
                else if (lblCOMMANLINE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCOMMANLINE1s.Text;
                else if (lblACTIVE_FLAG1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtACTIVE_FLAG1s.Text;
                else if (lblMETAKEYWORD1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMETAKEYWORD1s.Text;
                else if (lblMETADESCRIPTION1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMETADESCRIPTION1s.Text;
                else if (lblHEADERVISIBLEDATA1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHEADERVISIBLEDATA1s.Text;
                else if (lblHEADERINVISIBLEDATA1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHEADERINVISIBLEDATA1s.Text;
                else if (lblFOOTERVISIBLEDATA1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFOOTERVISIBLEDATA1s.Text;
                else if (lblFOOTERINVISIBLEDATA1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFOOTERINVISIBLEDATA1s.Text;
                else if (lblREFID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtREFID1s.Text;
                else if (lblMYBUSID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMYBUSID1s.Text;
                else if (lblMASTER_ID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMASTER_ID2h.Text;
                else if (lblMODULE_ID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMODULE_ID2h.Text;
                else if (lblMENU_TYPE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_TYPE2h.Text;
                else if (lblMENU_NAME12h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME12h.Text;
                else if (lblMENU_NAME22h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME22h.Text;
                else if (lblMENU_NAME32h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_NAME32h.Text;
                else if (lblLINK2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLINK2h.Text;
                else if (lblURLREWRITE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtURLREWRITE2h.Text;
                else if (lblMENU_LOCATION2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_LOCATION2h.Text;
                else if (lblMENU_ORDER2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMENU_ORDER2h.Text;
                else if (lblDOC_PARENT2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtDOC_PARENT2h.Text;
                else if (lblADDFLAGE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDFLAGE2h.Text;
                else if (lblEDITFLAGE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtEDITFLAGE2h.Text;
                else if (lblDELFLAGE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtDELFLAGE2h.Text;
                else if (lblPRINTFLAGE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPRINTFLAGE2h.Text;
                else if (lblAMIGLOBALE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtAMIGLOBALE2h.Text;
                else if (lblMYPERSONAL2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMYPERSONAL2h.Text;
                else if (lblSMALLTEXT2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSMALLTEXT2h.Text;
                else if (lblACTIVETILLDATE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtACTIVETILLDATE2h.Text;
                else if (lblICONPATH2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtICONPATH2h.Text;
                else if (lblCOMMANLINE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCOMMANLINE2h.Text;
                else if (lblACTIVE_FLAG2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtACTIVE_FLAG2h.Text;
                else if (lblMETAKEYWORD2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMETAKEYWORD2h.Text;
                else if (lblMETADESCRIPTION2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMETADESCRIPTION2h.Text;
                else if (lblHEADERVISIBLEDATA2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHEADERVISIBLEDATA2h.Text;
                else if (lblHEADERINVISIBLEDATA2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHEADERINVISIBLEDATA2h.Text;
                else if (lblFOOTERVISIBLEDATA2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFOOTERVISIBLEDATA2h.Text;
                else if (lblFOOTERINVISIBLEDATA2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFOOTERINVISIBLEDATA2h.Text;
                else if (lblREFID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtREFID2h.Text;
                else if (lblMYBUSID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMYBUSID2h.Text;

                else
                    ds.Tables[0].Rows[i]["LabelName"] = txtHeader.Text;
            }
            ds.WriteXml(Server.MapPath("\\ACM\\xml\\ACM_FUNCTION_MST.xml"));

        }
        public void ManageLang()
        {
            //for Language

            if (Session["LANGUAGE"] != null)
            {
                RecieveLabel(Session["LANGUAGE"].ToString());
                if (Session["LANGUAGE"].ToString() == "ar-KW")
                    GetHide();
                else
                    GetShow();
            }

        }
        protected void LanguageFrance_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "fr-FR";
            ManageLang();
        }
        protected void LanguageArabic_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "ar-KW";
            ManageLang();
        }
        protected void LanguageEnglish_Click(object sender, EventArgs e)
        {
            Session["LANGUAGE"] = "en-US";
            ManageLang();
        }

        #endregion
        public void Write()
        {
            //navigation.Visible = false;
            //drpMENU_ID.Enabled = true;
            drpMASTER_ID.Enabled = true;
            drpMODULE_ID.Enabled = true;
            //txtMENU_TYPE.Enabled = true;
            txtMENU_NAME1.Enabled = true;
            txtMENU_NAME2.Enabled = true;
            txtMENU_NAME3.Enabled = true;
            txtLINK.Enabled = true;
            txtURLREWRITE.Enabled = true;
            drpMenuLocation.Enabled = true;
            txtMENU_ORDER.Enabled = true;
            txtDOC_PARENT.Enabled = true;
            //txtCRUP_ID.Enabled = true;
            //drpADDFLAGE.Enabled = true;
            //drpEDITFLAGE.Enabled = true;
            //drpDELFLAGE.Enabled = true;
            //DrpTENANT_ID.Enabled = true;
            //drpAMIGLOBALE.Enabled = true;
            //drpMYPERSONAL.Enabled = true;
            txtSMALLTEXT.Enabled = true;
            txtACTIVETILLDATE.Enabled = true;
            drpICONPATH.Enabled = true;
            txtCOMMANLINE.Enabled = true;
            //drpACTIVE_FLAG.Enabled = true;
            txtMETATITLE.Enabled = true;
            txtMETAKEYWORD.Enabled = true;
            txtMETADESCRIPTION.Enabled = true;
            txtHEADERVISIBLEDATA.Enabled = true;
            txtHEADERINVISIBLEDATA.Enabled = true;
            txtFOOTERVISIBLEDATA.Enabled = true;
            txtFOOTERINVISIBLEDATA.Enabled = true;
            drpREFID.Enabled = true;
            drpMYBUSID.Enabled = true;
            DrpUser.Enabled = true;
            drpMenuLocation.Enabled = true;
            txtMenudate.Enabled = true;
            txtsp1.Enabled = true;
            txtsp2.Enabled = true;
            txtsp3.Enabled = true;
            txtsp4.Enabled = true;
            txtsp5.Enabled = true;
            txtvaluesp1.Enabled = true;
            txtvaluesp2.Enabled = true;
            txtvaluesp3.Enabled = true;
            txtvaluesp4.Enabled = true;
            txtvaluesp5.Enabled = true;
        }
        public void Readonly()
        {
            //navigation.Visible = true;
            //drpMENU_ID.Enabled = false;
            drpMASTER_ID.Enabled = false;
            drpMODULE_ID.Enabled = false;
            //txtMENU_TYPE.Enabled = false;
            txtMENU_NAME1.Enabled = false;
            txtMENU_NAME2.Enabled = false;
            txtMENU_NAME3.Enabled = false;
            txtLINK.Enabled = false;
            txtURLREWRITE.Enabled = false;
            //txtMENU_LOCATION.Enabled = false;
            txtMENU_ORDER.Enabled = false;
            txtDOC_PARENT.Enabled = false;
            //DrpTENANT_ID.Enabled = false;
            //txtCRUP_ID.Enabled = false;
            //drpADDFLAGE.Enabled = false;
            //drpEDITFLAGE.Enabled = false;
            //drpDELFLAGE.Enabled = false;
            //drpPRINTFLAGE.Enabled = false;
            //drpAMIGLOBALE.Enabled = false;
            //drpMYPERSONAL.Enabled = false;
            txtSMALLTEXT.Enabled = false;
            txtACTIVETILLDATE.Enabled = false;
            drpICONPATH.Enabled = false;
            txtCOMMANLINE.Enabled = false;
            //drpACTIVE_FLAG.Enabled = false;
            txtMETATITLE.Enabled = false;
            txtMETAKEYWORD.Enabled = false;
            txtMETADESCRIPTION.Enabled = false;
            txtHEADERVISIBLEDATA.Enabled = false;
            txtHEADERINVISIBLEDATA.Enabled = false;
            txtFOOTERVISIBLEDATA.Enabled = false;
            txtFOOTERINVISIBLEDATA.Enabled = false;
            drpREFID.Enabled = false;
            drpMYBUSID.Enabled = false;
            DrpUser.Enabled = false;
            drpMenuLocation.Enabled = false;
            txtMenudate.Enabled = false;
            txtsp1.Enabled = false;
            txtsp2.Enabled = false;
            txtsp3.Enabled = false;
            txtsp4.Enabled = false;
            txtsp5.Enabled = false;
            txtvaluesp1.Enabled = false;
            txtvaluesp2.Enabled = false;
            txtvaluesp3.Enabled = false;
            txtvaluesp4.Enabled = false;
            txtvaluesp5.Enabled = false;
        }
        #region Listview
        //protected void btnNext1_Click(object sender, EventArgs e)
        //{
        //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count();
        //    if (ViewState["Take"] == null && ViewState["Skip"] == null)
        //    {
        //        ViewState["Take"] = Showdata;
        //        ViewState["Skip"] = 0;
        //    }
        //    take = Convert.ToInt32(ViewState["Take"]);
        //    take = take + Showdata;
        //    Skip = take - Showdata;

        //    ((ACMMaster)Page.Master).BindList(Listview1, (DB.FUNCTION_MST.Where(p => p.TenentID == TID).OrderBy(m => m.MENU_ID).Take(take).Skip(Skip)).ToList());
        //    ViewState["Take"] = take;
        //    ViewState["Skip"] = Skip;
        //    if (take == Totalrec && Skip == (Totalrec - Showdata))
        //        btnNext1.Enabled = false;
        //    else
        //        btnNext1.Enabled = true;
        //    if (take == Showdata && Skip == 0)
        //        btnPrevious1.Enabled = false;
        //    else
        //        btnPrevious1.Enabled = true;

        //    ChoiceID = take / Showdata;

        //    ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2, Totalrec);
        //    lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";

        //}
        //protected void btnPrevious1_Click(object sender, EventArgs e)
        //{
        //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //    {
        //        int Totalrec = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count();
        //        Skip = Convert.ToInt32(ViewState["Skip"]);
        //        take = Skip;
        //        Skip = take - Showdata;
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.FUNCTION_MST.Where(p => p.TenentID == TID).OrderBy(m => m.MENU_ID).Take(take).Skip(Skip)).ToList());
        //        ViewState["Take"] = take;
        //        ViewState["Skip"] = Skip;
        //        if (take == Showdata && Skip == 0)
        //            btnPrevious1.Enabled = false;
        //        else
        //            btnPrevious1.Enabled = true;

        //        if (take == Totalrec && Skip == (Totalrec - Showdata))
        //            btnNext1.Enabled = false;
        //        else
        //            btnNext1.Enabled = true;

        //        ChoiceID = take / Showdata;
        //        ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2, Totalrec);
        //        lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";
        //    }
        //}
        //protected void btnfirst_Click(object sender, EventArgs e)
        //{
        //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //    {
        //        int Totalrec = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count();
        //        take = Showdata;
        //        Skip = 0;
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.FUNCTION_MST.Where(p => p.TenentID == TID).OrderBy(m => m.MENU_ID).Take(take).Skip(Skip)).ToList());
        //        ViewState["Take"] = take;
        //        ViewState["Skip"] = Skip;
        //        btnPrevious1.Enabled = false;
        //        ChoiceID = 0;
        //        ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2, Totalrec);
        //        if (take == Totalrec && Skip == (Totalrec - Showdata))
        //            btnNext1.Enabled = false;
        //        else
        //            btnNext1.Enabled = true;
        //        lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";

        //    }
        //}
        //protected void btnLast1_Click(object sender, EventArgs e)
        //{
        //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count();
        //    take = Totalrec;
        //    Skip = Totalrec - Showdata;
        //    ((ACMMaster)Page.Master).BindList(Listview1, (DB.FUNCTION_MST.Where(p => p.TenentID == TID).OrderBy(m => m.MENU_ID).Take(take).Skip(Skip)).ToList());
        //    ViewState["Take"] = take;
        //    ViewState["Skip"] = Skip;
        //    btnNext1.Enabled = false;
        //    btnPrevious1.Enabled = true;
        //    ChoiceID = take / Showdata;
        //    ((ACMMaster)Page.Master).GetCurrentNavigationLast(ChoiceID, Showdata, ListView2, Totalrec);
        //    lblShowinfEntry.Text = "Showing " + ViewState["Skip"].ToString() + " to " + ViewState["Take"].ToString() + " of " + Totalrec + " entries";
        //}
        protected void btnlistreload_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnPagereload_Click(object sender, EventArgs e)
        {
            Readonly();
            ManageLang();
            pnlSuccessMsg.Visible = false;
            FillContractorID();
            int CurrentID = 1;
            if (ViewState["Es"] != null)
                CurrentID = Convert.ToInt32(ViewState["Es"]);
            BindData();
            FirstData();
        }


        protected void Listview1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //try
                //{

                if (e.CommandName == "btnDelete")
                {

                    string[] MulID = (e.CommandArgument).ToString().Split(',');
                    int MenuID = Convert.ToInt32(MulID[0]);
                    int TenentID = Convert.ToInt32(MulID[1]);
                    Database.FUNCTION_MST objFUNCTION_MST = DB.FUNCTION_MST.Single(p => p.MENU_ID == MenuID && p.TenentID == TenentID);
                    objFUNCTION_MST.ACTIVE_FLAG = 0;
                    DB.SaveChanges();
                    List<Database.PRIVILAGE_MENUDemon> DeleteList = DB.PRIVILAGE_MENUDemon.Where(p => p.MENU_ID == MenuID).ToList();
                    foreach(Database.PRIVILAGE_MENUDemon Delitem in DeleteList)
                    {                        
                        Database.PRIVILAGE_MENUDemon PriDel = DB.PRIVILAGE_MENUDemon.Single(p => p.TenentID == Delitem.TenentID && p.PRIVILEGE_MENU_ID == Delitem.PRIVILEGE_MENU_ID && p.PRIVILEGE_ID == Delitem.PRIVILEGE_ID && p.PRIVILAGEFOR == Delitem.PRIVILAGEFOR && p.MENU_ID == Delitem.MENU_ID);
                        DB.PRIVILAGE_MENUDemon.DeleteObject(PriDel);
                        DB.SaveChanges();
                    }
                    BindData();
                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Deleted Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);                    
                }

                if (e.CommandName == "btnEdit")
                {
                    string[] MulID = (e.CommandArgument).ToString().Split(',');
                    int MenuID = Convert.ToInt32(MulID[0]);
                    int TenentID = Convert.ToInt32(MulID[1]);
                    FillContractorID();
                    //Database.tempUser objtemp = DB.tempUsers.Single(p => p.TenentID == TenentID && p.MENUID == MenuID);
                    Database.FUNCTION_MST objFUNCTION_MST = DB.FUNCTION_MST.Single(p => p.MENU_ID == MenuID && p.TenentID == TenentID);

                    drpMASTER_ID.SelectedValue = objFUNCTION_MST.MASTER_ID.ToString();
                    drpMODULE_ID.SelectedValue = objFUNCTION_MST.MODULE_ID.ToString();
                    //DrpUser.SelectedValue = objtemp.UserID.ToString();
                    //txtMETATITLE.Text = objtemp.METATITLE.ToString();

                    txtMENU_NAME1.Text = objFUNCTION_MST.MENU_NAME1.ToString();
                    txtMENU_NAME2.Text = objFUNCTION_MST.MENU_NAME2.ToString();
                    txtMENU_NAME3.Text = objFUNCTION_MST.MENU_NAME3.ToString();
                    txtLINK.Text = objFUNCTION_MST.LINK.ToString();
                    txtURLREWRITE.Text = objFUNCTION_MST.URLREWRITE.ToString();
                    drpMenuLocation.SelectedValue = objFUNCTION_MST.MENU_LOCATION.ToString();
                    txtMENU_ORDER.Text = objFUNCTION_MST.MENU_ORDER.ToString();
                    txtDOC_PARENT.Text = objFUNCTION_MST.DOC_PARENT;
                    cbADDFLAGE.Checked = objFUNCTION_MST.ADDFLAGE == 1 ? true : false;
                    cbEDITFLAGE.Checked = objFUNCTION_MST.EDITFLAGE == 1 ? true : false;
                    cbDELFLAGE.Checked = objFUNCTION_MST.DELFLAGE == 1 ? true : false;
                    cbPRINTFLAGE.Checked = objFUNCTION_MST.PRINTFLAGE == 1 ? true : false;
                    cbAMIGLOBALE.Checked = objFUNCTION_MST.AMIGLOBALE == 1 ? true : false;
                    cbMYPERSONAL.Checked = objFUNCTION_MST.MYPERSONAL == 1 ? true : false;
                    // txtCRUP_ID.Text = objFUNCTION_MST.CRUP_ID.ToString();
                    //  drpADDFLAGE.SelectedValue = objFUNCTION_MST.ADDFLAGE.ToString();
                    // drpEDITFLAGE.SelectedValue = objFUNCTION_MST.EDITFLAGE.ToString();
                    // drpDELFLAGE.SelectedValue = objFUNCTION_MST.DELFLAGE.ToString();
                    //  drpPRINTFLAGE.SelectedValue = objFUNCTION_MST.PRINTFLAGE.ToString();
                    //  drpAMIGLOBALE.SelectedValue = objFUNCTION_MST.AMIGLOBALE.ToString();
                    //  drpMYPERSONAL.SelectedValue = objFUNCTION_MST.MYPERSONAL.ToString();
                    txtSMALLTEXT.Text = objFUNCTION_MST.SMALLTEXT;

                    txtACTIVETILLDATE.Text = Convert.ToDateTime(objFUNCTION_MST.ACTIVETILLDATE).ToShortDateString();
                    drpICONPATH.SelectedItem.Text = objFUNCTION_MST.ICONPATH;
                    txtCOMMANLINE.Text = objFUNCTION_MST.COMMANLINE;
                    //  drpACTIVE_FLAG.SelectedValue = objFUNCTION_MST.ACTIVE_FLAG.ToString();
                    txtMETATITLE.Text = objFUNCTION_MST.METATITLE;
                    txtMETAKEYWORD.Text = objFUNCTION_MST.METAKEYWORD;
                    txtMETADESCRIPTION.Text = objFUNCTION_MST.METADESCRIPTION;
                    txtHEADERVISIBLEDATA.Text = objFUNCTION_MST.HEADERVISIBLEDATA;
                    txtHEADERINVISIBLEDATA.Text = objFUNCTION_MST.HEADERINVISIBLEDATA;
                    txtFOOTERVISIBLEDATA.Text = objFUNCTION_MST.FOOTERVISIBLEDATA;
                    txtFOOTERINVISIBLEDATA.Text = objFUNCTION_MST.FOOTERINVISIBLEDATA;
                    txtMenudate.Text = Convert.ToDateTime(objFUNCTION_MST.MENUDATE).ToShortDateString();
                    Chkactivemenu.Checked = objFUNCTION_MST.ACTIVEMENU == true ? true : false;
                    if (objFUNCTION_MST.REFID != null)
                        drpREFID.SelectedValue = objFUNCTION_MST.REFID.ToString();
                    if (objFUNCTION_MST.MYBUSID != null)
                        drpMYBUSID.SelectedValue = objFUNCTION_MST.MYBUSID.ToString();
                    btnAdd.Text = "Update";
                    btnAdd.ValidationGroup = "submit";
                    ViewState["Edit"] = MenuID;
                    ViewState["TeEdit"] = TenentID;
                    if (drpMenuLocation.SelectedValue == "Left Menu")
                        MenuSepret.Visible = true;
                    else
                        MenuSepret.Visible = false;
                    if (Convert.ToInt32(drpMODULE_ID.SelectedValue) != 0)
                    {                       
                        int MID = Convert.ToInt32(drpMODULE_ID.SelectedValue);
                        string MenuID11 = MID.ToString();
                        drpMASTER_ID.Items.Clear();
                        Classes.EcommAdminClass.getdropdown(drpMASTER_ID, TID, "Separator", MenuID11, "", "FUNCTION_MST");                       
                    }
                    else
                    {
                        drpMASTER_ID.Items.Insert(0, new ListItem("---Select Master Menu---", "0"));
                    }
                    Write();
                }
                if (e.CommandName == "coppy")//panel
                {
                    ViewState["CMenuID"] = ViewState["CTenentID"] = ViewState["CModulID"] = null;
                    string[] ID = e.CommandArgument.ToString().Split(',');
                    int menuid = Convert.ToInt32(ID[0]);
                    int tenet = Convert.ToInt32(ID[1]);
                    int Modulid = Convert.ToInt32(ID[2]);
                    ViewState["CMenuID"] = menuid;
                    ViewState["CTenentID"] = tenet;
                    ViewState["CModulID"] = Modulid;
                    pnlcoppy.Visible = true;
                    string MID = getmodulname(Modulid);
                    string menu = DB.FUNCTION_MST.Single(p => p.TenentID == tenet && p.MENU_ID == menuid).MENU_NAME1;
                    mark.Text = "you copy menu from Tenent is '" + tenet + "' & Module is '" + MID + "' & menu is '" + menu + "'";
                    drpcopyMaster.Focus();
                }
                if (e.CommandName == "copy")//popup
                {
                    string Str = "";
                    string[] ID = e.CommandArgument.ToString().Split(',');
                    int menuid = Convert.ToInt32(ID[0]);
                    int tenet = Convert.ToInt32(ID[1]);
                    int Modulid = Convert.ToInt32(ID[2]);
                    DropDownList drpCopyTenent = (DropDownList)e.Item.FindControl("drpCopyTenent");
                    DropDownList drpcopyModule = (DropDownList)e.Item.FindControl("drpcopyModule");
                    DropDownList drpcopyMaster = (DropDownList)e.Item.FindControl("drpcopyMaster");
                    CheckBox Chkoverwrite = (CheckBox)e.Item.FindControl("Chkoverwrite");

                    int copytenent = Convert.ToInt32(drpCopyTenent.SelectedValue);
                    int copyModule = Convert.ToInt32(drpcopyModule.SelectedValue);
                    int copyMaster = Convert.ToInt32(drpcopyMaster.SelectedValue);

                    int MEMUID12 = DB.FUNCTION_MST.Where(p => p.TenentID == tenet).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == tenet).Max(p => p.MENU_ID) + 1) : 1;
                    int MID = 0;
                    if (DB.MODULE_MST.Where(p => p.TenentID == copytenent && p.Module_Id == Modulid && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y").Count() > 0)
                    {
                        MID = Convert.ToInt32(DB.MODULE_MST.Where(p => p.TenentID == copytenent && p.Module_Id == Modulid && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y").FirstOrDefault().Module_Id);
                    }
                    else
                    {
                        Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Warning, "You Have a No Module For This Tenent", "Warning!", Classes.Toastr.ToastPosition.TopCenter);
                        return;
                    }
                    if (copytenent != 0 && copyModule != 0 && copyMaster != 0)
                    {
                        Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + ", MENU_ID = " + MEMUID12 + ",MODULE_ID=" + copyModule + ",MASTER_ID=" + copyMaster + " where TenentID = " + tenet + " AND MENU_ID = " + menuid + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
                        //Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
                        Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + ",MENUID = " + MEMUID12 + ",MODULE_ID=" + copyModule + ",MASTER_ID=" + copyMaster + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
                        command2 = new SqlCommand(Str, con);
                        con.Open();
                        command2.ExecuteReader();
                        con.Close();
                    }
                    else
                    {
                        if (tenet == copytenent)
                        {
                            Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + ", MENU_ID = " + MEMUID12 + " where TenentID = " + tenet + " AND MENU_ID = " + menuid + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
                            //Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
                            Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + ",MENUID = " + MEMUID12 + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
                            command2 = new SqlCommand(Str, con);
                            con.Open();
                            command2.ExecuteReader();
                            con.Close();
                        }
                        else
                        {
                            if (DB.FUNCTION_MST.Where(p => p.TenentID == copytenent && p.MENU_ID == menuid && p.MODULE_ID == MID).Count() == 0)
                            {
                                //Str += "INSERT INTO [dbo].[FUNCTION_MST](" + copytenent + ",[MENU_ID],[MASTER_ID],[MODULE_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[LINK],[Urloption],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[CRUP_ID],[ADDFLAGE],[EDITFLAGE],[DELFLAGE],[PRINTFLAGE],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ACTIVETILLDATE],[ICONPATH],[COMMANLINE],[ACTIVE_FLAG],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[LABLEFLAG],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name],[ACTIVEMENU],[MENUDATE])select " + tenet + "," + menuid + ",[MASTER_ID]," + Modulid + ",[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[LINK],[Urloption],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[CRUP_ID],[ADDFLAGE],[EDITFLAGE],[DELFLAGE],[PRINTFLAGE],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ACTIVETILLDATE],[ICONPATH],[COMMANLINE],[ACTIVE_FLAG],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[LABLEFLAG],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name],[ACTIVEMENU],[MENUDATE] from [FUNCTION_MST] where [TenentID]=" + tenet + " And [MENU_ID]=" + menuid + ";";
                                //Str += "INSERT INTO [dbo].[tempUser](" + copytenent + ",[PRIVILAGEID],[PRIVILAGESOURCE],[MENUID],[LocationID],[PRIVILAGE_MENUID],[MODULE_ID],[UserID],[ROLE_ID],[ADD_FLAG],[MODIFY_FLAG],[DELETE_FLAG],[VIEW_FLAG],[PRINTFLAGE],[ALL_FLAG],[LINK],[MASTER_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ICONPATH],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[ACTIVETILLDATE],[ACTIVEMENU],[ACTIVEPRIVILAGE],[ACTIVEMODULE],[ACTIVEROLE],[URADD_FLAG],[URMODIFY_FLAG],[URDELETE_FLAG],[URVIEW_FLAG],[URALL_FLAG],[IsLabelUpdate],[CRUP_ID],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name]) select " + tenet + ",[PRIVILAGEID],[PRIVILAGESOURCE]," + menuid + ",[LocationID],[PRIVILAGE_MENUID],[MODULE_ID],[UserID],[ROLE_ID],[ADD_FLAG],[MODIFY_FLAG],[DELETE_FLAG],[VIEW_FLAG],[PRINTFLAGE],[ALL_FLAG],[LINK],[MASTER_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ICONPATH],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[ACTIVETILLDATE],[ACTIVEMENU],[ACTIVEPRIVILAGE],[ACTIVEMODULE],[ACTIVEROLE],[URADD_FLAG],[URMODIFY_FLAG],[URDELETE_FLAG],[URVIEW_FLAG],[URALL_FLAG],[IsLabelUpdate],[CRUP_ID],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name] from [tempUser] where TenentID=" + tenet + " And [MENUID]=" + menuid + ";";
                                Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
                                Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";

                                command2 = new SqlCommand(Str, con);
                                con.Open();
                                command2.ExecuteReader();
                                con.Close();
                                Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Menu Copy Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                            }
                            else
                            {
                                if (Chkoverwrite.Checked == true)
                                {
                                    Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + " where TenentID = " + tenet + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
                                    command2 = new SqlCommand(Str, con);
                                    con.Open();
                                    command2.ExecuteReader();
                                    con.Close();
                                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Menu OverWrite Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                                }
                                else
                                {
                                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Warning, "This Menu Is Allready Exist", "Warning!", Classes.Toastr.ToastPosition.TopCenter);
                                    return;
                                }
                            }
                        }
                        //
                    }
                }
                if (e.CommandName == "btncopy")
                {
                    string[] MulID = (e.CommandArgument).ToString().Split(',');
                    int MenuID = Convert.ToInt32(MulID[0]);
                    int TenentID = Convert.ToInt32(MulID[1]);
                    Database.FUNCTION_MST objFUNCTION_MST = DB.FUNCTION_MST.Single(p => p.MENU_ID == MenuID && p.TenentID == TenentID);
                    Database.tempUser objtemp = DB.tempUsers.Single(p => p.TenentID == TenentID && p.MENUID == MenuID);
                    int User_ID = Convert.ToInt32(objtemp.UserID);
                    int Role_ID = Convert.ToInt32(objtemp.ROLE_ID);

                    decimal MENU_ORDER = Convert.ToInt64(objFUNCTION_MST.MENU_ORDER);
                    int MASTER_ID = Convert.ToInt32(objFUNCTION_MST.MASTER_ID);
                    DateTime ACTIVETILLDATE = Convert.ToDateTime(objFUNCTION_MST.ACTIVETILLDATE);

                    int MODULEID = Convert.ToInt32(objFUNCTION_MST.MODULE_ID);
                    string MENU_TYPE = objFUNCTION_MST.MENU_TYPE;
                    string MENU_NAME1 = objFUNCTION_MST.MENU_NAME1;
                    string MENU_NAME2 = objFUNCTION_MST.MENU_NAME2;
                    string MENU_NAME3 = objFUNCTION_MST.MENU_NAME3;
                    string LINK = objFUNCTION_MST.LINK;
                    string URLREWRITE = objFUNCTION_MST.URLREWRITE;
                    string MENU_LOCATION = objFUNCTION_MST.MENU_LOCATION;
                    // MENU_ORDER = objFUNCTION_MST.MENU_ORDER;
                    string DOC_PARENT = objFUNCTION_MST.DOC_PARENT;
                    //objFUNCTION_MST.CRUP_ID = txtCRUP_ID.Text;
                    int ADDFLAGE = Convert.ToInt32(objFUNCTION_MST.ADDFLAGE);
                    int EDITFLAGE = Convert.ToInt32(objFUNCTION_MST.EDITFLAGE);
                    int DELFLAGE = Convert.ToInt32(objFUNCTION_MST.DELFLAGE);
                    int PRINTFLAGE = Convert.ToInt32(objFUNCTION_MST.PRINTFLAGE);
                    int AMIGLOBALE = Convert.ToInt32(objFUNCTION_MST.AMIGLOBALE);
                    int MYPERSONAL = Convert.ToInt32(objFUNCTION_MST.MYPERSONAL);
                    int REFID = Convert.ToInt32(objFUNCTION_MST.REFID);
                    int TenentID1 = Convert.ToInt32(objFUNCTION_MST.TenentID);
                    int MYBUSID = Convert.ToInt32(objFUNCTION_MST.MYBUSID);
                    int CRUP_ID = Convert.ToInt32(objFUNCTION_MST.CRUP_ID);
                    //  int Role_ID =Convert.ToInt32( objFUNCTION_MST.Role_ID;
                    string SMALLTEXT = objFUNCTION_MST.SMALLTEXT;
                    string ICONPATH = objFUNCTION_MST.ICONPATH;
                    string COMMANLINE = objFUNCTION_MST.COMMANLINE;
                    int ACTIVE_FLAG = Convert.ToInt32(objFUNCTION_MST.ACTIVE_FLAG);
                    string METATITLE = txtMETATITLE.Text;
                    //objFUNCTION_MST.METATITLE = txtMETATITLE.Text;
                    string METAKEYWORD = objFUNCTION_MST.METAKEYWORD;
                    string METADESCRIPTION = objFUNCTION_MST.METADESCRIPTION;
                    string HEADERVISIBLEDATA = objFUNCTION_MST.HEADERVISIBLEDATA;
                    string HEADERINVISIBLEDATA = objFUNCTION_MST.HEADERINVISIBLEDATA;
                    string FOOTERVISIBLEDATA = objFUNCTION_MST.FOOTERVISIBLEDATA;
                    string FOOTERINVISIBLEDATA = objFUNCTION_MST.FOOTERINVISIBLEDATA;
                    DateTime ActiveMenuDate = Convert.ToDateTime(objFUNCTION_MST.MENUDATE);
                    bool ActiveMenu = Convert.ToBoolean(objFUNCTION_MST.ACTIVEMENU);
                    string spname1 = objFUNCTION_MST.SP1Name.ToString();
                    string spname2 = objFUNCTION_MST.SP2Name.ToString();
                    string spname3 = objFUNCTION_MST.SP3Name.ToString();
                    string spname4 = objFUNCTION_MST.SP4Name.ToString();
                    string spname5 = objFUNCTION_MST.SP5Name.ToString();

                    int LOCATIONID = 1;
                    int MEMUID12 = DB.FUNCTION_MST.Where(p => p.TenentID == TenentID1).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == TenentID1).Max(p => p.MENU_ID) + 1) : 1;

                    int MEMUID = Classes.ACMClass.InsertDataACMFunction(MEMUID12, MASTER_ID, MODULEID, MENU_TYPE, MENU_NAME1, MENU_NAME1,
                        MENU_NAME1, LINK, URLREWRITE, MENU_LOCATION, MENU_ORDER, DOC_PARENT, SMALLTEXT, ACTIVETILLDATE, ICONPATH,
                        COMMANLINE, METAKEYWORD, METADESCRIPTION, HEADERVISIBLEDATA, HEADERINVISIBLEDATA, FOOTERVISIBLEDATA,
                        FOOTERINVISIBLEDATA, REFID, TenentID, LOCATIONID, MYBUSID, CRUP_ID, METATITLE,
                        ADDFLAGE, EDITFLAGE, DELFLAGE, PRINTFLAGE, AMIGLOBALE, MYPERSONAL, ACTIVE_FLAG, ActiveMenuDate, ActiveMenu, spname1, spname2, spname3, spname4, spname5);

                    string flage = "Insert";
                    Classes.ACMClass.UpdateTempUser(MEMUID12,
                       MASTER_ID, MODULEID, MENU_TYPE, MENU_NAME1,
                       MENU_NAME1, MENU_NAME1, LINK, URLREWRITE, MENU_LOCATION,
                       MENU_ORDER, DOC_PARENT, SMALLTEXT, ACTIVETILLDATE,
                       ICONPATH, COMMANLINE, METAKEYWORD, METADESCRIPTION, HEADERVISIBLEDATA,
                       HEADERINVISIBLEDATA, FOOTERVISIBLEDATA, FOOTERINVISIBLEDATA, REFID, TenentID,
                       LOCATIONID, MYBUSID, 0, METATITLE, ADDFLAGE,
                       EDITFLAGE, DELFLAGE, PRINTFLAGE, AMIGLOBALE,
                       MYPERSONAL, ACTIVE_FLAG, ActiveMenuDate,
                       ActiveMenu, User_ID, Role_ID, flage);

                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Copy Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                    //lblMsg.Text = "Data Copy Successfully";
                    //pnlSuccessMsg.Visible = true;
                    BindData();

                }
                scope.Complete(); //  To commit.
                //}
                //catch (Exception ex)
                //{
                //    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", ex.Message, true);
                //    throw;
                //}
            }
        }

        //protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{
        //    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count();
        //    if (e.CommandName == "LinkPageavigation")
        //    {
        //        int ID = Convert.ToInt32(e.CommandArgument);
        //        ViewState["Take"] = ID * Showdata;
        //        ViewState["Skip"] = (ID * Showdata) - Showdata;
        //        int Tvalue = Convert.ToInt32(ViewState["Take"]);
        //        int Svalue = Convert.ToInt32(ViewState["Skip"]);
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.FUNCTION_MST.Where(p => p.TenentID == TID).OrderBy(m => m.MENU_ID).Take(Tvalue).Skip(Svalue)).ToList());
        //        ChoiceID = ID;
        //        ((ACMMaster)Page.Master).GetCurrentNavigation(ChoiceID, Showdata, ListView2, Totalrec);
        //        if (Tvalue == Showdata && Svalue == 0)
        //            btnPrevious1.Enabled = false;
        //        else
        //            btnPrevious1.Enabled = true;
        //        if (take == Totalrec && Skip == (Totalrec - Showdata))
        //            btnNext1.Enabled = false;
        //        else
        //            btnNext1.Enabled = true;
        //    }
        //    lblShowinfEntry.Text = "Showing " + ViewState["Skip"].ToString() + " to " + ViewState["Take"].ToString() + " of " + Totalrec + " entries";


        //}

        //protected void drpShowGrid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindData();
        //}
        //protected void AnswerList_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    LinkButton lb = e.Item.FindControl("LinkPageavigation") as LinkButton;
        //    ScriptManager control = this.Master.FindControl("toolscriptmanagerID") as ScriptManager;
        //    control.RegisterAsyncPostBackControl(lb);  // ToolkitScriptManager
        //}
        #endregion
        protected void drpMenuLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DrpTENANT_ID.SelectedValue == "00")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please choose Tenant  !!');", true);
            //    return;
            //}



            string ID = drpMenuLocation.SelectedValue;
            if (ID == "Left Menu")
            {
                MenuSepret.Visible = true;
                // drpMASTER_ID

            }
            else
            {
                MenuSepret.Visible = false;

            }
        }

        protected void drpMENU_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkTenantLocation() != true)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please choose Tenant or Location !!');", true);
            //    return;
            //}
            if (Convert.ToInt32(drpMENU_TYPE.SelectedValue) == 2)
            {
                if (Convert.ToInt32(drpMASTER_ID.SelectedValue) != 0)
                {
                    int TenentID = 0;
                    int Master_ID = Convert.ToInt32(drpMASTER_ID.SelectedValue);
                    var List_Function = DB.FUNCTION_MST.Where(p => p.TenentID == TenentID && p.MASTER_ID == Master_ID).ToList();
                    //Database.FUNCTION_MST obj_ACM_Function = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == Master_ID);//change by dipak
                    if (List_Function.Count() < 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please enter value in Level 1. !!');", true);
                    }
                    else
                    {
                        submenupanel.Visible = true;
                        DrpMultisubmenu.DataSource = List_Function;//DB.FUNCTION_MST.Where(p => p.MENU_TYPE == "1" && p.TenentID == TID && p.LOCATION_ID == LID && p.MASTER_ID == obj_ACM_Function.MASTER_ID);
                        DrpMultisubmenu.DataTextField = "MENU_NAME1";
                        DrpMultisubmenu.DataValueField = "MENU_ID";
                        DrpMultisubmenu.DataBind();
                        DrpMultisubmenu.Items.Insert(0, new ListItem("---Select---", "0"));
                    }
                    //drpMENU_TYPE.DataSource = DB.FUNCTION_MST.Where(p => p.MENU_TYPE == "1" && p.TenentID == TID && p.LOCATION_ID == 1 && p.MASTER_ID == Master_ID);
                    //drpMENU_TYPE.DataTextField = "MENU_NAME1";
                    //drpMENU_TYPE.DataValueField = "MENU_ID";
                    //drpMENU_TYPE.DataBind();
                }
            }
        }
        protected void drpMODULE_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkTenantLocation() != true)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please choose Tenant or Location !!');", true);
            //    return;
            //}
            //if (ViewState["LocationID"] != null && ViewState["TenenatID"] != null && Convert.ToInt32(drpMODULE_ID.SelectedValue) != 0)
            //{
            if (Convert.ToInt32(drpMODULE_ID.SelectedValue) != 0)
            {
                //int TID = Convert.ToInt32(ViewState["TenenatID"]);
                //int LID = Convert.ToInt32(ViewState["LocationID"]);
                int MID = Convert.ToInt32(drpMODULE_ID.SelectedValue);
                string MenuID = MID.ToString();
                drpMASTER_ID.Items.Clear();
                //drpMASTER_ID.DataSource = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.MENU_TYPE == "Separator" && p.MODULE_ID == MID);
                //drpMASTER_ID.DataTextField = "MENU_NAME1";
                //drpMASTER_ID.DataValueField = "MENU_ID";
                //drpMASTER_ID.DataBind();
                ////drpMASTER_ID.Items.Insert(1, new ListItem("Home", "1044"));
                //drpMASTER_ID.Items.Insert(0, new ListItem("---Select Master Menu---", "0"));
                Classes.EcommAdminClass.getdropdown(drpMASTER_ID, TID, "Separator", MenuID, "", "FUNCTION_MST");
                //select * from FUNCTION_MST where MENU_TYPE = 'Separator' and TenentID=1
            }
            else
            {
                drpMASTER_ID.Items.Insert(0, new ListItem("---Select Master Menu---", "0"));
            }

        }
        protected void drpMASTER_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkTenantLocation() != true)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please choose Tenant or Location !!');", true);
            //    return;
            //}


            if (Convert.ToInt32(drpMENU_TYPE.SelectedValue) == 2)
            {

                if (ViewState["LocationID"] != null)
                {
                    if (Convert.ToInt32(drpMASTER_ID.SelectedValue) != 0)
                    {
                        int TID = Convert.ToInt32(ViewState["TenenatID"]);
                        int LID = Convert.ToInt32(ViewState["LocationID"]);
                        int Master_ID = Convert.ToInt32(drpMASTER_ID.SelectedValue);
                        var List_Function = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.MASTER_ID == Master_ID).ToList();
                        //Database.FUNCTION_MST obj_ACM_Function = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == Master_ID);//change by Dipak
                        if (List_Function.Count() < 1)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyScript", "alert('Please enter value in Level 1. !!');", true);
                        }
                        else
                        {
                            submenupanel.Visible = true;
                            DrpMultisubmenu.DataSource = List_Function;//DB.FUNCTION_MST.Where(p => p.MENU_TYPE == "1" && p.TenentID == TID && p.LOCATION_ID == LID && p.MASTER_ID == obj_ACM_Function.MASTER_ID);
                            DrpMultisubmenu.DataTextField = "MENU_NAME1";
                            DrpMultisubmenu.DataValueField = "MENU_ID";
                            DrpMultisubmenu.DataBind();
                            DrpMultisubmenu.Items.Insert(0, new ListItem("---Select---", "0"));
                        }

                    }
                }
            }
        }
        //protected void DrpTENANT_ID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);

        //    drplocation.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenentID == TID);
        //    drplocation.DataTextField = "LOCNAME1";
        //    drplocation.DataValueField = "LOCATIONID";
        //    drplocation.DataBind();
        //    drplocation.Items.Insert(0, new ListItem("---Select Location---", "0"));
        //    ViewState["TenenatID"] = TID;
        //    if (DrpTENANT_ID.SelectedValue != "00")
        //        drplocation.Enabled = true;
        //    else
        //        drplocation.Enabled = false;
        //}
        //protected void drplocation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnGO.Enabled = true;
        //}
        //protected void btnGO_Click(object sender, EventArgs e)
        //{
        //    if (Convert.ToInt32(drplocation.SelectedValue) != 0)
        //    {
        //        int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);
        //        int LID = Convert.ToInt32(drplocation.SelectedValue);
        //        FillContractorID();
        //        ViewState["TenenatID"] = TID;
        //        ViewState["LocationID"] = LID;

        //        drpMODULE_ID.Items.Clear();
        //        drpMODULE_ID.DataSource = DB.MODULE_MST.Where(p => p.TenentID == TID && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y");
        //        drpMODULE_ID.DataTextField = "Module_Name";
        //        drpMODULE_ID.DataValueField = "Module_Id";
        //        drpMODULE_ID.DataBind();
        //        drpMODULE_ID.Items.Insert(0, new ListItem("---Select---", "0"));

        //        DrpUser.Items.Clear();
        //        var Datas = (from fun12 in DB.USER_MST.Where(p => p.TenentID == TID && p.LOCATION_ID == LID)
        //                     select new
        //                     {
        //                         Name = fun12.FIRST_NAME + "" + fun12.LAST_NAME,
        //                         ID = fun12.USER_ID

        //                     }).Distinct();
        //        DrpUser.DataSource = Datas;
        //        DrpUser.DataTextField = "Name";
        //        DrpUser.DataValueField = "ID";
        //        DrpUser.DataBind();
        //        DrpUser.Items.Insert(0, new ListItem("---Select---", "0"));

        //        var List = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.ACTIVE_FLAG == 1).ToList();
        //        Listview1.DataSource = List;
        //        Listview1.DataBind();

        //        pnlcoppy.Visible = false;

        //    }
        //}
        protected void drpICONPATH_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIconpath.Attributes["class"] = drpICONPATH.SelectedItem.ToString();
        }
        //public bool checkTenantLocation()
        //{
        //    if (drplocation.SelectedValue == "0" || DrpTENANT_ID.SelectedValue == "00")
        //        return false;
        //    else
        //        return true;
        //}
        public string getmodulname(int ID)
        {
            //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);

            if (DB.MODULE_MST.Where(p => p.Module_Id == ID && p.TenentID == TID).Count() > 0)
            {
                return DB.MODULE_MST.Single(p => p.Module_Id == ID && p.TenentID == TID).Module_Name;
            }
            else
            {
                return "";
            }
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    var List = DB.FUNCTION_MST.OrderBy(m => m.MENU_ID).Where(p => p.ACTIVE_FLAG == 1 && p.MENU_NAME1.Contains(txtSearch.Text)).ToList();
        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = List.Count();
        //    ((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);
        //}

        protected void drpSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);

            var List = DB.FUNCTION_MST.OrderBy(m => m.MENU_ID).Where(p => p.ACTIVE_FLAG == 1).ToList();
            if (drpSort.SelectedValue == "1")
                List = DB.FUNCTION_MST.OrderBy(m => m.MODULE_ID).Where(p => p.ACTIVE_FLAG == 1).ToList();
            if (drpSort.SelectedValue == "2")
                List = DB.FUNCTION_MST.OrderBy(m => m.MENU_NAME1).Where(p => p.ACTIVE_FLAG == 1).ToList();
            //if (drpSort.SelectedValue == "3")
            //    List = DB.FUNCTION_MST.OrderBy(m => m.LINK).Where(p => p.ACTIVE_FLAG == 1).ToList();
            if (drpSort.SelectedValue == "3")
                List = DB.FUNCTION_MST.OrderBy(m => m.URLREWRITE).Where(p => p.ACTIVE_FLAG == 1).ToList();
            if (drpSort.SelectedValue == "4")
                List = DB.FUNCTION_MST.OrderBy(m => m.MENU_ORDER).Where(p => p.ACTIVE_FLAG == 1).ToList();
            //if (drpSort.SelectedValue == "6")
            //    List = DB.FUNCTION_MST.OrderBy(m => m.AMIGLOBALE).Where(p => p.ACTIVE_FLAG == 1).ToList();
            if (drpSort.SelectedValue == "5")
                List = DB.FUNCTION_MST.OrderBy(m => m.ACTIVETILLDATE).Where(p => p.ACTIVE_FLAG == 1).ToList();
            Listview1.DataSource = List.Where(p => p.TenentID == TID);
            Listview1.DataBind();
            //int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
            //int Totalrec = List.Count();
            //((ACMMaster)Page.Master).Loadlist(Showdata, take, Skip, ChoiceID, lblShowinfEntry, btnPrevious1, btnNext1, Listview1, ListView2, Totalrec, List);

        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            //int TID = Convert.ToInt32(DrpTENANT_ID.SelectedValue);
            int MID = Convert.ToInt32(ViewState["MMID"]);
            if (MID > 0)
                Listview1.DataSource = DB.FUNCTION_MST.OrderBy(m => m.MENU_ID).Where(p => p.ACTIVE_FLAG == 1 && p.TenentID == TID && p.MENU_ID == MID);
            else
                Listview1.DataSource = DB.FUNCTION_MST.OrderBy(m => m.MENU_ID).Where(p => p.ACTIVE_FLAG == 1 && p.TenentID == TID);
            Listview1.DataBind();
        }

        protected void Listview1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //DropDownList drpCopyTenent = (DropDownList)e.Item.FindControl("drpCopyTenent");
            //DropDownList drpcopyModule = (DropDownList)e.Item.FindControl("drpcopyModule");
            //var Datas = (from fun1 in DB.TBLLOCATIONs
            //             select new
            //             {
            //                 fun1.TenentID,

            //             }).Distinct();
            //drpCopyTenent.DataSource = Datas;
            //drpCopyTenent.DataTextField = "TenentID";
            //drpCopyTenent.DataValueField = "TenentID";
            //drpCopyTenent.DataBind();
            //drpCopyTenent.Items.Insert(0, new ListItem("---Select---", "00"));


        }

        protected void drpcopyModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < Listview1.Items.Count; i++)
            //{
            //    DropDownList drpCopyTenent = (DropDownList)Listview1.Items[i].FindControl("drpCopyTenent");
            //    DropDownList drpcopyModule = (DropDownList)Listview1.Items[i].FindControl("drpcopyModule");
            //    DropDownList drpcopyMaster = (DropDownList)Listview1.Items[i].FindControl("drpcopyMaster");
            //    ModalPopupExtender ModalPopupExtender1 = (ModalPopupExtender)Listview1.Items[i].FindControl("ModalPopupExtender1");
            //    int TID = Convert.ToInt32(drpCopyTenent.SelectedValue);
            //    int Module = Convert.ToInt32(drpcopyModule.SelectedValue);
            //    drpcopyMaster.DataSource = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
            //    drpcopyMaster.DataTextField = "MENU_NAME1";
            //    drpcopyMaster.DataValueField = "MENU_ID";
            //    drpcopyMaster.DataBind();
            //    drpcopyMaster.Items.Insert(0, new ListItem("--Select Master--", "0"));
            //    ModalPopupExtender1.Show();
            //}
            int TID = Convert.ToInt32(drpCopyTenent.SelectedValue);
            int Module = Convert.ToInt32(drpcopyModule.SelectedValue);
            drpcopyMaster.DataSource = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
            drpcopyMaster.DataTextField = "MENU_NAME1";
            drpcopyMaster.DataValueField = "MENU_ID";
            drpcopyMaster.DataBind();
            drpcopyMaster.Items.Insert(0, new ListItem("--Select Master--", "0"));

            if (DB.MODULE_MST.Where(p => p.TenentID == TID && p.Module_Id == Module && p.ACTIVE_FLAG == "Y").Count() == 0)
            {
                if (DB.MODULE_MST.Where(p => p.TenentID == TID && p.Module_Id == Module).Count() > 0)
                {
                    Database.MODULE_MST OBJActive = DB.MODULE_MST.Single(p => p.TenentID == TID && p.Module_Id == Module);
                    OBJActive.ACTIVE_FLAG = "Y";
                    DB.SaveChanges();
                    int ParentModuleID = Convert.ToInt32(OBJActive.Parent_Module_id);
                    Database.MODULE_MST pOBJActive = DB.MODULE_MST.Single(p => p.TenentID == TID && p.Module_Id == ParentModuleID);
                    pOBJActive.ACTIVE_FLAG = "Y";
                    DB.SaveChanges();
                }
                else
                {
                    Database.MODULE_MST OBJActive = DB.MODULE_MST.Single(p => p.TenentID == 0 && p.Module_Id == Module);
                    Database.MODULE_MST newobj = new Database.MODULE_MST();
                    newobj.TenentID = TID;
                    newobj.Module_Id = OBJActive.Module_Id;
                    newobj.MYSYSNAME = OBJActive.MYSYSNAME;
                    newobj.Module_Name = OBJActive.Module_Name;
                    newobj.Module_NameO = OBJActive.Module_NameO;
                    newobj.Module_NameT = OBJActive.Module_NameT;
                    newobj.Module_Desc = OBJActive.Module_Desc;
                    newobj.Parent_Module_id = OBJActive.Parent_Module_id;
                    newobj.Module_Order = OBJActive.Module_Order;
                    newobj.ACTIVE_FLAG = "Y";
                    newobj.CRUP_ID = OBJActive.CRUP_ID;
                    newobj.Module_Location = OBJActive.Module_Location;
                    newobj.ACTIVEMODULE = OBJActive.ACTIVEMODULE;
                    newobj.MODULEDATE = OBJActive.MODULEDATE;
                    DB.MODULE_MST.AddObject(newobj);
                    DB.SaveChanges();

                    int ParentModuleID = Convert.ToInt32(OBJActive.Parent_Module_id);
                    Database.MODULE_MST pOBJActive = DB.MODULE_MST.Single(p => p.TenentID == 0 && p.Module_Id == ParentModuleID);
                    Database.MODULE_MST pnewobj = new Database.MODULE_MST();
                    pnewobj.TenentID = TID;
                    pnewobj.Module_Id = pOBJActive.Module_Id;
                    pnewobj.MYSYSNAME = pOBJActive.MYSYSNAME;
                    pnewobj.Module_Name = pOBJActive.Module_Name;
                    pnewobj.Module_NameO = pOBJActive.Module_NameO;
                    pnewobj.Module_NameT = pOBJActive.Module_NameT;
                    pnewobj.Module_Desc = pOBJActive.Module_Desc;
                    pnewobj.Parent_Module_id = pOBJActive.Parent_Module_id;
                    pnewobj.Module_Order = pOBJActive.Module_Order;
                    pnewobj.ACTIVE_FLAG = "Y";
                    pnewobj.CRUP_ID = pOBJActive.CRUP_ID;
                    pnewobj.Module_Location = pOBJActive.Module_Location;
                    pnewobj.ACTIVEMODULE = pOBJActive.ACTIVEMODULE;
                    pnewobj.MODULEDATE = pOBJActive.MODULEDATE;
                    DB.MODULE_MST.AddObject(pnewobj);
                    DB.SaveChanges();
                }

                List<Database.FUNCTION_MST> ListFun = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator").ToList();
                List<Database.tempUser> ListTempuser = DB.tempUsers.Where(p => p.TenentID == TID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator").ToList();
                if (ListFun.Count() > 0)
                {
                    foreach (Database.FUNCTION_MST item in ListFun)
                    {
                        Database.FUNCTION_MST objFUN = DB.FUNCTION_MST.Single(p => p.TenentID == TID && p.MENU_ID == item.MENU_ID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
                        objFUN.ACTIVE_FLAG = 1;
                        objFUN.ACTIVEMENU = true;
                        objFUN.ACTIVETILLDATE = new DateTime(DateTime.Today.Year, 1, 1);
                        objFUN.MENUDATE = new DateTime(DateTime.Today.Year, 12, 28);
                        DB.SaveChanges();
                    }
                    foreach (Database.tempUser item in ListTempuser)
                    {
                        Database.tempUser objtemp = DB.tempUsers.Single(p => p.TenentID == TID && p.MENUID == item.MENUID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
                        objtemp.ACTIVEMENU = true;
                        objtemp.ACTIVETILLDATE = new DateTime(DateTime.Today.Year, 12, 28);
                        DB.SaveChanges();
                    }
                }
                else
                {
                    List<Database.FUNCTION_MST> ListFun_0 = DB.FUNCTION_MST.Where(p => p.TenentID == 0 && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator").ToList();
                    List<Database.tempUser> ListTempuser_0 = DB.tempUsers.Where(p => p.TenentID == 0 && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator").ToList();
                    foreach (Database.FUNCTION_MST item in ListFun_0)
                    {
                        Database.FUNCTION_MST objFUN_0 = DB.FUNCTION_MST.Single(p => p.TenentID == item.TenentID && p.MENU_ID == item.MENU_ID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
                        Database.FUNCTION_MST funobj = new Database.FUNCTION_MST();
                        funobj.TenentID = TID;
                        int Menu = DB.FUNCTION_MST.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == TID).Max(p => p.MENU_ID) + 1) : 1;
                        funobj.MENU_ID = Menu;
                        funobj.MASTER_ID = objFUN_0.MASTER_ID;
                        funobj.MODULE_ID = objFUN_0.MODULE_ID;
                        funobj.MENU_TYPE = objFUN_0.MENU_TYPE;
                        funobj.MENU_NAME1 = objFUN_0.MENU_NAME1;
                        funobj.MENU_NAME2 = objFUN_0.MENU_NAME1;
                        funobj.MENU_NAME3 = objFUN_0.MENU_NAME3;
                        funobj.LINK = objFUN_0.LINK;
                        funobj.Urloption = objFUN_0.Urloption;
                        funobj.URLREWRITE = objFUN_0.URLREWRITE;
                        funobj.MENU_LOCATION = objFUN_0.MENU_LOCATION;
                        funobj.MENU_ORDER = objFUN_0.MENU_ORDER;
                        funobj.DOC_PARENT = objFUN_0.DOC_PARENT;
                        funobj.CRUP_ID = objFUN_0.CRUP_ID;
                        funobj.ADDFLAGE = objFUN_0.ADDFLAGE;
                        funobj.EDITFLAGE = objFUN_0.EDITFLAGE;
                        funobj.DELFLAGE = objFUN_0.DELFLAGE;
                        funobj.PRINTFLAGE = objFUN_0.PRINTFLAGE;
                        funobj.AMIGLOBALE = objFUN_0.AMIGLOBALE;
                        funobj.MYPERSONAL = objFUN_0.MYPERSONAL;
                        funobj.SMALLTEXT = objFUN_0.SMALLTEXT;
                        funobj.ACTIVETILLDATE = objFUN_0.ACTIVETILLDATE;
                        funobj.ICONPATH = objFUN_0.ICONPATH;
                        funobj.COMMANLINE = objFUN_0.COMMANLINE;
                        funobj.ACTIVE_FLAG = objFUN_0.ACTIVE_FLAG;
                        funobj.METATITLE = objFUN_0.METATITLE;
                        funobj.METAKEYWORD = objFUN_0.METAKEYWORD;
                        funobj.METADESCRIPTION = objFUN_0.METADESCRIPTION;
                        funobj.HEADERVISIBLEDATA = objFUN_0.HEADERVISIBLEDATA;
                        funobj.HEADERINVISIBLEDATA = objFUN_0.HEADERINVISIBLEDATA;
                        funobj.FOOTERVISIBLEDATA = objFUN_0.FOOTERVISIBLEDATA;
                        funobj.FOOTERINVISIBLEDATA = objFUN_0.FOOTERINVISIBLEDATA;
                        funobj.REFID = objFUN_0.REFID;
                        funobj.MYBUSID = objFUN_0.MYBUSID;
                        funobj.LABLEFLAG = objFUN_0.LABLEFLAG;
                        funobj.SP1 = objFUN_0.SP1;
                        funobj.SP2 = objFUN_0.SP2;
                        funobj.SP3 = objFUN_0.SP3;
                        funobj.SP4 = objFUN_0.SP4;
                        funobj.SP5 = objFUN_0.SP5;
                        funobj.SP1Name = objFUN_0.SP1Name;
                        funobj.SP2Name = objFUN_0.SP2Name;
                        funobj.SP3Name = objFUN_0.SP3Name;
                        funobj.SP4Name = objFUN_0.SP4Name;
                        funobj.SP5Name = objFUN_0.SP5Name;
                        funobj.ACTIVEMENU = objFUN_0.ACTIVEMENU;
                        funobj.MENUDATE = objFUN_0.MENUDATE;
                        DB.FUNCTION_MST.AddObject(funobj);

                        Database.tempUser objtemp_0 = DB.tempUsers.Single(p => p.TenentID == item.TenentID && p.MENUID == item.MENU_ID && p.MODULE_ID == Module && p.MENU_LOCATION == "Separator");
                        Database.tempUser tempobj = new Database.tempUser();
                        tempobj.TenentID = TID;
                        tempobj.MENUID = Menu;
                        tempobj.PRIVILAGEID = objtemp_0.PRIVILAGEID;
                        tempobj.PRIVILAGESOURCE = objtemp_0.PRIVILAGESOURCE;
                        tempobj.LocationID = objtemp_0.LocationID;
                        tempobj.PRIVILAGE_MENUID = objtemp_0.PRIVILAGE_MENUID;
                        tempobj.MODULE_ID = objtemp_0.MODULE_ID;
                        tempobj.UserID = DB.USER_MST.Where(p => p.TenentID == TID).First().USER_ID;
                        tempobj.ROLE_ID = DB.USER_MST.Where(p => p.TenentID == TID).First().USER_TYPE;
                        tempobj.ADD_FLAG = objtemp_0.ADD_FLAG;
                        tempobj.MODIFY_FLAG = objtemp_0.MODIFY_FLAG;
                        tempobj.DELETE_FLAG = objtemp_0.DELETE_FLAG;
                        tempobj.VIEW_FLAG = objtemp_0.VIEW_FLAG;
                        tempobj.PRINTFLAGE = objtemp_0.PRINTFLAGE;
                        tempobj.ALL_FLAG = objtemp_0.ALL_FLAG;
                        tempobj.LINK = objtemp_0.LINK;
                        tempobj.MASTER_ID = objtemp_0.MASTER_ID;
                        tempobj.MENU_TYPE = objtemp_0.MENU_TYPE;
                        tempobj.MENU_NAME1 = objtemp_0.MENU_NAME1;
                        tempobj.MENU_NAME2 = objtemp_0.MENU_NAME2;
                        tempobj.MENU_NAME3 = objtemp_0.MENU_NAME3;
                        tempobj.URLREWRITE = objtemp_0.URLREWRITE;
                        tempobj.MENU_LOCATION = objtemp_0.MENU_LOCATION;
                        tempobj.MENU_ORDER = objtemp_0.MENU_ORDER;
                        tempobj.DOC_PARENT = objtemp_0.DOC_PARENT;
                        tempobj.AMIGLOBALE = objtemp_0.AMIGLOBALE;
                        tempobj.MYPERSONAL = objtemp_0.MYPERSONAL;
                        tempobj.SMALLTEXT = objtemp_0.SMALLTEXT;
                        tempobj.ICONPATH = objtemp_0.ICONPATH;
                        tempobj.METATITLE = objtemp_0.METATITLE;
                        tempobj.METAKEYWORD = objtemp_0.METAKEYWORD;
                        tempobj.METADESCRIPTION = objtemp_0.METADESCRIPTION;
                        tempobj.HEADERVISIBLEDATA = objtemp_0.HEADERVISIBLEDATA;
                        tempobj.HEADERINVISIBLEDATA = objtemp_0.HEADERINVISIBLEDATA;
                        tempobj.FOOTERVISIBLEDATA = objtemp_0.FOOTERVISIBLEDATA;
                        tempobj.FOOTERINVISIBLEDATA = objtemp_0.FOOTERINVISIBLEDATA;
                        tempobj.REFID = objtemp_0.REFID;
                        tempobj.MYBUSID = objtemp_0.MYBUSID;
                        tempobj.ACTIVETILLDATE = objtemp_0.ACTIVETILLDATE;
                        tempobj.ACTIVEMENU = objtemp_0.ACTIVEMENU;
                        tempobj.ACTIVEPRIVILAGE = objtemp_0.ACTIVEPRIVILAGE;
                        tempobj.ACTIVEMODULE = objtemp_0.ACTIVEMODULE;
                        tempobj.ACTIVEROLE = objtemp_0.ACTIVEROLE;
                        tempobj.URADD_FLAG = objtemp_0.URADD_FLAG;
                        tempobj.URMODIFY_FLAG = objtemp_0.URMODIFY_FLAG;
                        tempobj.URDELETE_FLAG = objtemp_0.URDELETE_FLAG;
                        tempobj.URVIEW_FLAG = objtemp_0.URVIEW_FLAG;
                        tempobj.URALL_FLAG = objtemp_0.URALL_FLAG;
                        tempobj.IsLabelUpdate = objtemp_0.IsLabelUpdate;
                        tempobj.CRUP_ID = objtemp_0.CRUP_ID;
                        tempobj.SP1 = objtemp_0.SP1;
                        tempobj.SP2 = objtemp_0.SP2;
                        tempobj.SP3 = objtemp_0.SP3;
                        tempobj.SP4 = objtemp_0.SP4;
                        tempobj.SP5 = objtemp_0.SP5;
                        tempobj.SP1Name = objtemp_0.SP1Name;
                        tempobj.SP2Name = objtemp_0.SP2Name;
                        tempobj.SP3Name = objtemp_0.SP3Name;
                        tempobj.SP4Name = objtemp_0.SP4Name;
                        tempobj.SP5Name = objtemp_0.SP5Name;

                    }
                }



            }
        }

        protected void drpCopyTenent_TextChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < Listview1.Items.Count; i++)
            //{
            //    DropDownList drpCopyTenent = (DropDownList)Listview1.Items[i].FindControl("drpCopyTenent");
            //    DropDownList drpcopyModule = (DropDownList)Listview1.Items[i].FindControl("drpcopyModule");
            //    ModalPopupExtender ModalPopupExtender1 = (ModalPopupExtender)Listview1.Items[i].FindControl("ModalPopupExtender1");
            //    int TID = Convert.ToInt32(drpCopyTenent.SelectedValue);
            //    Classes.EcommAdminClass.getdropdown(drpcopyModule, TID, "0", "", "", "MODULE_MST");
            //    drpcopyModule.DataSource = DB.MODULE_MST.Where(p => p.TenentID == TID && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y");
            //    drpcopyModule.DataTextField = "Module_Name";
            //    drpcopyModule.DataValueField = "Module_Id";
            //    drpcopyModule.DataBind();
            //    drpcopyModule.Items.Insert(0, new ListItem("--Select Module--", "0"));
            //    ModalPopupExtender1.Show();
            //}
            int TID = Convert.ToInt32(drpCopyTenent.SelectedValue);
            drpcopyModule.DataSource = DB.MODULE_MST.Where(p => p.TenentID == TID && p.Parent_Module_id != 0);//&& p.ACTIVE_FLAG == "Y"
            drpcopyModule.DataTextField = "Module_Name";
            drpcopyModule.DataValueField = "Module_Id";
            drpcopyModule.DataBind();
            drpcopyModule.Items.Insert(0, new ListItem("--Select Module--", "0"));


        }

        //protected void btnpnlforcopy_Click(object sender, EventArgs e)
        //{
        //    if(ViewState["CMenuID"] != null && ViewState["CTenentID"] != null && ViewState["CModulID"] != null)
        //    {
        //        string Str = "";
        //        int menuid = Convert.ToInt32(ViewState["CMenuID"]);
        //        int tenet = Convert.ToInt32(ViewState["CTenentID"]);
        //        int Modulid = Convert.ToInt32(ViewState["CModulID"]);

        //        int copytenent = Convert.ToInt32(drpCopyTenent.SelectedValue);
        //        int copyModule = Convert.ToInt32(drpcopyModule.SelectedValue);
        //        int copyMaster = Convert.ToInt32(drpcopyMaster.SelectedValue);

        //        int MEMUID12 = DB.FUNCTION_MST.Where(p => p.TenentID == tenet).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == tenet).Max(p => p.MENU_ID) + 1) : 1;
        //        int MID = 0;
        //        if (DB.MODULE_MST.Where(p => p.TenentID == copytenent && p.Module_Id == Modulid && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y").Count() > 0)
        //        {
        //            MID = Convert.ToInt32(DB.MODULE_MST.Where(p => p.TenentID == copytenent && p.Module_Id == Modulid && p.Parent_Module_id != 0 && p.ACTIVE_FLAG == "Y").FirstOrDefault().Module_Id);
        //        }
        //        else
        //        {
        //            Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Warning, "You Have a No Module For This Tenent", "Warning!", Classes.Toastr.ToastPosition.TopCenter);
        //            return;
        //        }
        //        if (copytenent != 00 && copyModule != 0 && copyMaster != 0)
        //        {
        //            int MEMUID_1 = DB.FUNCTION_MST.Where(p => p.TenentID == copytenent).Count() > 0 ? Convert.ToInt32(DB.FUNCTION_MST.Where(p => p.TenentID == copytenent).Max(p => p.MENU_ID) + 1) : 1;
        //            Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + ", MENU_ID = " + MEMUID_1 + ",MODULE_ID=" + copyModule + ",MASTER_ID=" + copyMaster + " where TenentID = " + tenet + " AND MENU_ID = " + menuid + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
        //            //Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
        //            Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + ",MENUID = " + MEMUID_1 + ",MODULE_ID=" + copyModule + ",MASTER_ID=" + copyMaster + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
        //            command2 = new SqlCommand(Str, con);
        //            con.Open();
        //            command2.ExecuteReader();
        //            con.Close();

        //            Database.tempUser objtemp1 = DB.tempUsers.Single(p => p.TenentID == copytenent && p.MENUID == MEMUID_1);
        //            objtemp1.UserID = DB.USER_MST.Where(p => p.TenentID == copytenent).First().USER_ID;
        //            objtemp1.ROLE_ID = DB.USER_MST.Where(p => p.TenentID == copytenent).First().USER_TYPE;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            if (tenet == copytenent)
        //            {
        //                Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + ", MENU_ID = " + MEMUID12 + " where TenentID = " + tenet + " AND MENU_ID = " + menuid + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
        //                //Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
        //                Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + ",MENUID = " + MEMUID12 + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";
        //                command2 = new SqlCommand(Str, con);
        //                con.Open();
        //                command2.ExecuteReader();
        //                con.Close();
        //            }
        //            else
        //            {
        //                if (DB.FUNCTION_MST.Where(p => p.TenentID == copytenent && p.MENU_ID == menuid && p.MODULE_ID == MID).Count() == 0)
        //                {
        //                    //Str += "INSERT INTO [dbo].[FUNCTION_MST](" + copytenent + ",[MENU_ID],[MASTER_ID],[MODULE_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[LINK],[Urloption],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[CRUP_ID],[ADDFLAGE],[EDITFLAGE],[DELFLAGE],[PRINTFLAGE],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ACTIVETILLDATE],[ICONPATH],[COMMANLINE],[ACTIVE_FLAG],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[LABLEFLAG],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name],[ACTIVEMENU],[MENUDATE])select " + tenet + "," + menuid + ",[MASTER_ID]," + Modulid + ",[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[LINK],[Urloption],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[CRUP_ID],[ADDFLAGE],[EDITFLAGE],[DELFLAGE],[PRINTFLAGE],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ACTIVETILLDATE],[ICONPATH],[COMMANLINE],[ACTIVE_FLAG],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[LABLEFLAG],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name],[ACTIVEMENU],[MENUDATE] from [FUNCTION_MST] where [TenentID]=" + tenet + " And [MENU_ID]=" + menuid + ";";
        //                    //Str += "INSERT INTO [dbo].[tempUser](" + copytenent + ",[PRIVILAGEID],[PRIVILAGESOURCE],[MENUID],[LocationID],[PRIVILAGE_MENUID],[MODULE_ID],[UserID],[ROLE_ID],[ADD_FLAG],[MODIFY_FLAG],[DELETE_FLAG],[VIEW_FLAG],[PRINTFLAGE],[ALL_FLAG],[LINK],[MASTER_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ICONPATH],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[ACTIVETILLDATE],[ACTIVEMENU],[ACTIVEPRIVILAGE],[ACTIVEMODULE],[ACTIVEROLE],[URADD_FLAG],[URMODIFY_FLAG],[URDELETE_FLAG],[URVIEW_FLAG],[URALL_FLAG],[IsLabelUpdate],[CRUP_ID],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name]) select " + tenet + ",[PRIVILAGEID],[PRIVILAGESOURCE]," + menuid + ",[LocationID],[PRIVILAGE_MENUID],[MODULE_ID],[UserID],[ROLE_ID],[ADD_FLAG],[MODIFY_FLAG],[DELETE_FLAG],[VIEW_FLAG],[PRINTFLAGE],[ALL_FLAG],[LINK],[MASTER_ID],[MENU_TYPE],[MENU_NAME1],[MENU_NAME2],[MENU_NAME3],[URLREWRITE],[MENU_LOCATION],[MENU_ORDER],[DOC_PARENT],[AMIGLOBALE],[MYPERSONAL],[SMALLTEXT],[ICONPATH],[METATITLE],[METAKEYWORD],[METADESCRIPTION],[HEADERVISIBLEDATA],[HEADERINVISIBLEDATA],[FOOTERVISIBLEDATA],[FOOTERINVISIBLEDATA],[REFID],[MYBUSID],[ACTIVETILLDATE],[ACTIVEMENU],[ACTIVEPRIVILAGE],[ACTIVEMODULE],[ACTIVEROLE],[URADD_FLAG],[URMODIFY_FLAG],[URDELETE_FLAG],[URVIEW_FLAG],[URALL_FLAG],[IsLabelUpdate],[CRUP_ID],[SP1],[SP2],[SP3],[SP4],[SP5],[SP1Name],[SP2Name],[SP3Name],[SP4Name],[SP5Name] from [tempUser] where TenentID=" + tenet + " And [MENUID]=" + menuid + ";";
        //                    Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO FUNCTION_MST select * from TempCopy_FUNCTION_MST where TenentID = " + copytenent + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
        //                    Str += "select * into TempCopy_tempUser from tempUser where TenentID = " + tenet + " AND MENUID=" + menuid + ";update TempCopy_tempUser set TenentID = " + copytenent + " where TenentID = " + tenet + ";INSERT INTO tempUser select * from TempCopy_tempUser where TenentID = " + copytenent + ";SELECT * FROM TempCopy_tempUser;drop table TempCopy_tempUser;";

        //                    command2 = new SqlCommand(Str, con);
        //                    con.Open();
        //                    command2.ExecuteReader();
        //                    con.Close();
        //                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Menu Copy Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
        //                }
        //                else
        //                {
        //                    if (Chkoverwrite.Checked == true)
        //                    {
        //                        Str += "select * into TempCopy_FUNCTION_MST from FUNCTION_MST where TenentID = " + tenet + " AND MENU_ID=" + menuid + ";update TempCopy_FUNCTION_MST set TenentID = " + copytenent + " where TenentID = " + tenet + ";SELECT * FROM TempCopy_FUNCTION_MST;drop table TempCopy_FUNCTION_MST;";
        //                        command2 = new SqlCommand(Str, con);
        //                        con.Open();
        //                        command2.ExecuteReader();
        //                        con.Close();
        //                        Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Menu OverWrite Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
        //                    }
        //                    else
        //                    {
        //                        Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Warning, "This Menu Is Allready Exist", "Warning!", Classes.Toastr.ToastPosition.TopCenter);
        //                        return;
        //                    }
        //                }
        //            }

        //        }
        //        pnlcoppy.Visible = false;
        //    }           
        //}

        protected void btncancle1_Click(object sender, EventArgs e)
        {
            pnlcoppy.Visible = false;
        }








    }
}