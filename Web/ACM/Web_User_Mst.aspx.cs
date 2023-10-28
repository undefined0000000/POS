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
using Classes;
using Repository;

namespace Web.ACM
{
    public partial class Web_User_Mst : System.Web.UI.Page
    {
        #region Step1
        int count = 0;
        int take = 0;
        int Skip = 0;
        int TID = 0;
        public static int ChoiceID = 0;
        #endregion
        Database.CallEntities DB = new Database.CallEntities();
        int TIDSession, LID, stMYTRANSID, UID, EMPID, Transid, Transsubid, CID, userID1, userTypeid = 0;
        string LangID, CURRENCY, USERID, Crypath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionLoad();
            if (!IsPostBack)
            {
                txtuserdate.Text = DateTime.Now.ToString("dd-MMM-yy");
                txtTill_DT.Text = DateTime.Now.ToString("dd-MMM-yy");
                int TID = Convert.ToInt32(Session["TID"]);
                Readonly();
                ManageLang();
                pnlSuccessMsg.Visible = false;
                TenentBind();
                FillContractorID();
                int CurrentID = 1;
                if (ViewState["Es"] != null)
                    CurrentID = Convert.ToInt32(ViewState["Es"]);
                //LastBindData();
                //BindData();
                //   FirstData();
                pnlGlogle.Visible = false;
                BindData();
                btnAdd.Visible = true;
            }
        }
        #region Step2
        public void BindData()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int LID = LocationID;


            //int TID = Convert.ToInt32(Session["TID"]);
                LID = LocationID;
            
            USerListBind(TID, LID);

        }
        #endregion
        #region PAge Genarator

        public void GetShow()
        {

            lblFIRST_NAME1s.Attributes["class"] = lblLAST_NAME1s.Attributes["class"] = lblFIRST_NAME11s.Attributes["class"] = lblLAST_NAME11s.Attributes["class"] = lblFIRST_NAME21s.Attributes["class"] = lblLAST_NAME21s.Attributes["class"] = lblHOUSE_NO1s.Attributes["class"] = lblSTREET1s.Attributes["class"] = lblADDRESS11s.Attributes["class"] = lblADDRESS21s.Attributes["class"] = lblCITY1s.Attributes["class"] = lblCOUNTRY1s.Attributes["class"] = lblSTATE1s.Attributes["class"] = lblZIP1s.Attributes["class"] = lblPH_NO1s.Attributes["class"] = lblFAX_NO1s.Attributes["class"] = lblPINCODE_NO1s.Attributes["class"] = lblPOST_OFFICE1s.Attributes["class"] = lblPAN_NO1s.Attributes["class"] = lblEMAIL_ADDRESS1s.Attributes["class"] = lblMOBILE_NUM1s.Attributes["class"] = lblLOGIN_ID1s.Attributes["class"] = lblPASSWORD1s.Attributes["class"] = lblUSER_TYPE1s.Attributes["class"] = lblTill_DT2h.Attributes["class"] = "control-label col-md-4  getshow";
            lblREMARKS1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblFIRST_NAME2h.Attributes["class"] = lblLAST_NAME2h.Attributes["class"] = lblFIRST_NAME12h.Attributes["class"] = lblLAST_NAME12h.Attributes["class"] = lblFIRST_NAME22h.Attributes["class"] = lblLAST_NAME22h.Attributes["class"] = lblHOUSE_NO2h.Attributes["class"] = lblSTREET2h.Attributes["class"] = lblADDRESS12h.Attributes["class"] = lblADDRESS22h.Attributes["class"] = lblCITY2h.Attributes["class"] = lblCOUNTRY2h.Attributes["class"] = lblSTATE2h.Attributes["class"] = lblZIP2h.Attributes["class"] = lblPH_NO2h.Attributes["class"] = lblFAX_NO2h.Attributes["class"] = lblPINCODE_NO2h.Attributes["class"] = lblPOST_OFFICE2h.Attributes["class"] = lblPAN_NO2h.Attributes["class"] = lblEMAIL_ADDRESS2h.Attributes["class"] = lblMOBILE_NUM2h.Attributes["class"] = lblLOGIN_ID2h.Attributes["class"] = lblPASSWORD2h.Attributes["class"] = lblUSER_TYPE2h.Attributes["class"] = lblTill_DT2h.Attributes["class"] = "control-label col-md-4  gethide";
            lblREMARKS2h.Attributes["class"] = "control-label col-md-2  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }

        public void GetHide()
        {
            lblFIRST_NAME1s.Attributes["class"] = lblLAST_NAME1s.Attributes["class"] = lblFIRST_NAME11s.Attributes["class"] = lblLAST_NAME11s.Attributes["class"] = lblFIRST_NAME21s.Attributes["class"] = lblLAST_NAME21s.Attributes["class"] = lblHOUSE_NO1s.Attributes["class"] = lblSTREET1s.Attributes["class"] = lblADDRESS11s.Attributes["class"] = lblADDRESS21s.Attributes["class"] = lblCITY1s.Attributes["class"] = lblCOUNTRY1s.Attributes["class"] = lblSTATE1s.Attributes["class"] = lblZIP1s.Attributes["class"] = lblPH_NO1s.Attributes["class"] = lblFAX_NO1s.Attributes["class"] = lblPINCODE_NO1s.Attributes["class"] = lblPOST_OFFICE1s.Attributes["class"] = lblPAN_NO1s.Attributes["class"] = lblEMAIL_ADDRESS1s.Attributes["class"] = lblMOBILE_NUM1s.Attributes["class"] = lblLOGIN_ID1s.Attributes["class"] = lblPASSWORD1s.Attributes["class"] = lblUSER_TYPE1s.Attributes["class"] = lblTill_DT1s.Attributes["class"] = "control-label col-md-4  gethide";
            lblREMARKS1s.Attributes["class"] = "control-label col-md-2  gethide";
            lblFIRST_NAME2h.Attributes["class"] = lblLAST_NAME2h.Attributes["class"] = lblFIRST_NAME12h.Attributes["class"] = lblLAST_NAME12h.Attributes["class"] = lblFIRST_NAME22h.Attributes["class"] = lblLAST_NAME22h.Attributes["class"] = lblHOUSE_NO2h.Attributes["class"] = lblSTREET2h.Attributes["class"] = lblADDRESS12h.Attributes["class"] = lblADDRESS22h.Attributes["class"] = lblCITY2h.Attributes["class"] = lblCOUNTRY2h.Attributes["class"] = lblSTATE2h.Attributes["class"] = lblZIP2h.Attributes["class"] = lblPH_NO2h.Attributes["class"] = lblFAX_NO2h.Attributes["class"] = lblPINCODE_NO2h.Attributes["class"] = lblPOST_OFFICE2h.Attributes["class"] = lblPAN_NO2h.Attributes["class"] = lblEMAIL_ADDRESS2h.Attributes["class"] = lblMOBILE_NUM2h.Attributes["class"] = lblLOGIN_ID2h.Attributes["class"] = lblPASSWORD2h.Attributes["class"] = lblUSER_TYPE2h.Attributes["class"] = lblTill_DT1s.Attributes["class"] = "control-label col-md-4  getshow";
            lblREMARKS2h.Attributes["class"] = "control-label col-md-2 getshow";
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
            // drpUSER_DETAIL_ID.SelectedIndex = 0;
            txtFIRST_NAME.Text = "";
            txtLAST_NAME.Text = "";
            txtFIRST_NAME1.Text = "";
            txtLAST_NAME1.Text = "";
            txtFIRST_NAME2.Text = "";
            txtLAST_NAME2.Text = "";

            txtHOUSE_NO.Text = "";
            txtSTREET.Text = "";
            txtADDRESS1.Text = "";
            txtADDRESS2.Text = "";
            txtCITY.Text = "";
            drpCOUNTRY.SelectedIndex = 0;
            drpSTATE.SelectedIndex = 0;
            //drpLoctionId.SelectedIndex = 0;
            //drpTenentID.SelectedIndex = 0;
            txtZIP.Text = "";
            txtPH_NO.Text = "";
            txtFAX_NO.Text = "";
            // txtFROM_REG_DT.Text = "";
            //txtVILLAGE_TOWN_CITY.Text = "";
            //txtTEHSIL.Text = "";
            txtPINCODE_NO.Text = "";
            txtPOST_OFFICE.Text = "";
            txtPAN_NO.Text = "";
            txtEMAIL_ADDRESS.Text = "";
            txtMOBILE_NUM.Text = "";
            //drpSEC_QUES.SelectedIndex = 0;
            //txtSEC_ANS.Text = "";
            txtLOGIN_ID.Text = "";
            txtPASSWORD.Text = "";
            drpUSER_TYPE.SelectedIndex = 0;
            txtREMARKS.Text = "";
            //txtAvtar.Text = "";
            //drpCompId.SelectedIndex = 0;
            txtTill_DT.Text = "";
            //DrpDefaulrLang.SelectedIndex = 1;
            // txtCRUP_ID.Text = "";

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //try
                //{
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                if (btnAdd.Text == "AddNew")
                {

                    Write();
                    Clear();
                    btnAdd.ValidationGroup = "s";
                    btnAdd.Text = "Add";
                }
                else if (btnAdd.Text == "Add")
                {
                    Database.USER_DTL objUSER_DTL = new Database.USER_DTL();
                    objUSER_DTL.TenentID = TID;
                    
                    objUSER_DTL.USER_DETAIL_ID = DB.USER_DTL.Count() > 0 ? Convert.ToInt32(DB.USER_DTL.Max(p => p.USER_DETAIL_ID) + 1) : 1;
                    //objUSER_DTL.COUNTRY_CODE = txtCOUNTRY_CODE.Text;
                    //objUSER_DTL.TITLE = txtTITLE.Text;
                    objUSER_DTL.HOUSE_NO = txtHOUSE_NO.Text;
                    objUSER_DTL.STREET = txtSTREET.Text;
                    objUSER_DTL.ADDRESS1 = txtADDRESS1.Text;
                    objUSER_DTL.ADDRESS2 = txtADDRESS2.Text;
                    objUSER_DTL.CITY = txtCITY.Text;
                    if (Convert.ToInt32(drpCOUNTRY.SelectedValue) != 0)
                    {
                        objUSER_DTL.COUNTRY = Convert.ToInt32(drpCOUNTRY.SelectedValue);
                    }
                    if (Convert.ToInt32(drpSTATE.SelectedValue) != 0)
                    {
                        objUSER_DTL.STATE = drpSTATE.SelectedValue;
                    }

                    objUSER_DTL.ZIP = txtZIP.Text;
                    objUSER_DTL.PH_NO = txtPH_NO.Text;
                    objUSER_DTL.FAX_NO = txtFAX_NO.Text;
                    //objUSER_DTL.VILLAGE_TOWN_CITY = txtVILLAGE_TOWN_CITY.Text;
                    //objUSER_DTL.TEHSIL = txtTEHSIL.Text;
                    objUSER_DTL.PINCODE_NO = txtPINCODE_NO.Text;
                    objUSER_DTL.POST_OFFICE = txtPOST_OFFICE.Text;
                    objUSER_DTL.PAN_NO = txtPAN_NO.Text;
                    objUSER_DTL.EMAIL_ADDRESS = txtEMAIL_ADDRESS.Text;
                    if (txtMOBILE_NUM.Text != "" && txtMOBILE_NUM.Text != null)
                        objUSER_DTL.MOBILE_NUM = Convert.ToInt64(txtMOBILE_NUM.Text);
                    //objUSER_DTL.SEC_QUES = drpSEC_QUES.SelectedValue;
                    //objUSER_DTL.SEC_ANS = txtSEC_ANS.Text;
                    if (drpLocation.SelectedValue != "0")
                    {
                        objUSER_DTL.LOCATION_ID = int.Parse( drpLocation.SelectedValue.ToString());
                    }
                    DB.USER_DTL.AddObject(objUSER_DTL);
                    DB.SaveChanges();

                   
                    int UserTenent = 0;
                    int Locationid = 1;

                    UserTenent = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID); ;
                        Locationid = int.Parse(drpLocation.SelectedValue.ToString());
                   
                    int Userid = DB.USER_MST.Count() > 0 ? Convert.ToInt32(DB.USER_MST.Max(p => p.USER_ID) + 1) : 1;
                    string FIRST_NAME = txtFIRST_NAME.Text;
                    string LAST_NAME = txtLAST_NAME.Text;
                    string FIRST_NAME1 = txtFIRST_NAME1.Text;
                    string LAST_NAME1 = txtLAST_NAME1.Text;
                    string FIRST_NAME2 = txtFIRST_NAME2.Text;
                    string LAST_NAME2 = txtLAST_NAME2.Text;
                    string LOGIN_ID = txtLOGIN_ID.Text;
                    string PASSWORD = Classes.GlobleClass.EncryptionHelpers.Encrypt(txtPASSWORD.Text);
                    string PASSWORD_CHNG = txtPASSWORD.Text;
                    int USER_TYPE = Convert.ToInt32(drpUSER_TYPE.SelectedValue);
                    string REMARKS = txtREMARKS.Text;
                    string ACTIVE_FLAG = "Y";
                    DateTime LAST_LOGIN_DT = DateTime.Now;
                    string ACC_LOCK = "Y";
                    string FIRST_TIME = "Y";
                    string EmailAddress = txtEMAIL_ADDRESS.Text;
                    string Avtar = "Image";
                    DateTime Till_DT = Convert.ToDateTime(txtTill_DT.Text);
                    //int CompId = Convert.ToInt32(drpCompId.SelectedValue);
                    int USER_DETAIL_ID = objUSER_DTL.USER_DETAIL_ID;
                    bool ACTIVEUSER = CHKActiveUser.Checked == true ? true : false;
                    DateTime USERDATE = Convert.ToDateTime(txtuserdate.Text);
                    string Lang1 = DrpDefaulrLang.SelectedValue;
                    string Flage = "ADD";

                  bool Status =  Classes.ACMClass.InsertWeb_User_MST(UserTenent, Userid, Locationid, FIRST_NAME, LAST_NAME, FIRST_NAME1, LAST_NAME1, FIRST_NAME2, LAST_NAME2, LOGIN_ID, PASSWORD, PASSWORD_CHNG, USER_TYPE, REMARKS, ACTIVE_FLAG, LAST_LOGIN_DT, ACC_LOCK, FIRST_TIME, EmailAddress, Avtar, Till_DT, 1, USER_DETAIL_ID, ACTIVEUSER, USERDATE, Flage, Lang1);
                    ////////////////////////////////////////////////////////////
                    ///
                    if(Status)
                    {
                        DAL.Insert_User_Location(TID, Userid, int.Parse(drpLocation.SelectedValue.ToString()), UID);
                    }

                    //  Clear();
                    //lblMsg.Text = "  Data Save Successfully";
                    //pnlSuccessMsg.Visible = true;
                    Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Save Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                    // BindData();
                    //  navigation.Visible = true;
                    BindData();
                    Readonly();
                    btnAdd.Text = "AddNew";
                    // FirstData();
                }
                else if (btnAdd.Text == "Update")
                {

                    if (ViewState["Edit"] != null)
                    {
                        int TenentID = Convert.ToInt32(Session["TID"]);
                        int LOCATION_ID = int.Parse(drpLocation.SelectedValue.ToString());
                        
                            TenentID = TID;
                            LOCATION_ID = 1;
                        
                        int ID = Convert.ToInt32(ViewState["Edit"]);
                        if (DB.USER_MST.Where(p => p.USER_ID == ID && p.TenentID == TenentID).Count() > 0)
                        {
                            int USERDIID = Convert.ToInt32(DB.USER_MST.Single(p => p.USER_ID == ID && p.TenentID == TenentID).USER_DETAIL_ID);
                          
                            Database.USER_DTL objUSER_DTL = new Database.USER_DTL();

                                objUSER_DTL = DB.USER_DTL.SingleOrDefault(p => p.USER_DETAIL_ID == USERDIID && p.TenentID == TenentID);
                            if (objUSER_DTL != null)
                            {

                                //objUSER_DTL.COUNTRY_CODE = txtCOUNTRY_CODE.Text;
                                //objUSER_DTL.TITLE = txtTITLE.Text;
                                objUSER_DTL.HOUSE_NO = txtHOUSE_NO.Text;
                                objUSER_DTL.STREET = txtSTREET.Text;
                                objUSER_DTL.ADDRESS1 = txtADDRESS1.Text;
                                objUSER_DTL.ADDRESS2 = txtADDRESS2.Text;
                                objUSER_DTL.CITY = txtCITY.Text;

                                if (Convert.ToInt32(drpCOUNTRY.SelectedValue) != 0)
                                {
                                    objUSER_DTL.COUNTRY = Convert.ToInt32(drpCOUNTRY.SelectedValue);
                                }
                                if (Convert.ToInt32(drpSTATE.SelectedValue) != 0)
                                {
                                    objUSER_DTL.STATE = drpSTATE.SelectedValue;
                                }

                                objUSER_DTL.ZIP = txtZIP.Text;
                                objUSER_DTL.PH_NO = txtPH_NO.Text;
                                objUSER_DTL.FAX_NO = txtFAX_NO.Text;
                                //objUSER_DTL.VILLAGE_TOWN_CITY = txtVILLAGE_TOWN_CITY.Text;
                                //objUSER_DTL.TEHSIL = txtTEHSIL.Text;
                                objUSER_DTL.PINCODE_NO = txtPINCODE_NO.Text;
                                objUSER_DTL.POST_OFFICE = txtPOST_OFFICE.Text;
                                objUSER_DTL.PAN_NO = txtPAN_NO.Text;
                                objUSER_DTL.EMAIL_ADDRESS = txtEMAIL_ADDRESS.Text;
                                //objUSER_DTL.LOCATION_ID = int.Parse(drpLocation.SelectedValue.ToString());
                                if (txtMOBILE_NUM.Text == "")
                                {
                                    objUSER_DTL.MOBILE_NUM = 99999;
                                }
                                else
                                {
                                    objUSER_DTL.MOBILE_NUM = Convert.ToInt64(txtMOBILE_NUM.Text);
                                }
                                //if (Convert.ToInt32(drpSEC_QUES.SelectedValue) != 0)
                                //{
                                //    objUSER_DTL.SEC_QUES = drpSEC_QUES.SelectedValue;
                                //}

                                //objUSER_DTL.SEC_ANS = txtSEC_ANS.Text;

                                DB.SaveChanges();
                            }
                        

                            ViewState["UDID"] = USERDIID;
                        }
                        


                        int UserID = Convert.ToInt32(ID);
                        Database.USER_MST objUSER_MST = DB.USER_MST.Single(p => p.USER_ID == ID && p.TenentID == TenentID);
                        string FIRST_NAME = txtFIRST_NAME.Text;
                        string LAST_NAME = txtLAST_NAME.Text;
                        string FIRST_NAME1 = txtFIRST_NAME1.Text;
                        string LAST_NAME1 = txtLAST_NAME1.Text;
                        string FIRST_NAME2 = txtFIRST_NAME2.Text;
                        string LAST_NAME2 = txtLAST_NAME2.Text;
                        string LOGIN_ID = txtLOGIN_ID.Text;
                       // string PASSWORD1 = txtPASSWORD.Text.Trim();//Classes.GlobleClass.EncryptionHelpers.Encrypt(txtPASSWORD.Text);
                        string PASSWORD_CHNG = objUSER_MST.PASSWORD;

                        string PASSWORD = objUSER_MST.PASSWORD;
                        int USER_TYPE = Convert.ToInt32(drpUSER_TYPE.SelectedValue);
                        string REMARKS = txtREMARKS.Text;
                        string ACTIVE_FLAG = "Y";
                        DateTime LAST_LOGIN_DT = DateTime.Now;
                        string ACC_LOCK = "Y";
                        string FIRST_TIME = "Y";
                        string EmailAddress = txtEMAIL_ADDRESS.Text;
                        string Avtar = "Image";
                        DateTime Till_DT = Convert.ToDateTime(txtTill_DT.Text);

                        //int CompId = Convert.ToInt32(drpCompId.SelectedValue);
                        int USER_DETAIL_ID = 0;
                        if (ViewState["UDID"] != null)
                        {
                            int udid = Convert.ToInt32(ViewState["UDID"]);
                            USER_DETAIL_ID = udid;
                        }
                        bool ACTIVEUSER = CHKActiveUser.Checked == true ? true : false;
                        DateTime USERDATE = Convert.ToDateTime(txtuserdate.Text);
                        string Lang1 = DrpDefaulrLang.SelectedValue;
                        string Flage = "EDIT";
                        Classes.ACMClass.UpdateWeb_User_MST(TenentID, UserID, LOCATION_ID, FIRST_NAME, LAST_NAME, FIRST_NAME1, LAST_NAME1, FIRST_NAME2, LAST_NAME2, LOGIN_ID, objUSER_MST.PASSWORD, PASSWORD_CHNG, USER_TYPE, REMARKS, ACTIVE_FLAG, LAST_LOGIN_DT, ACC_LOCK, FIRST_TIME, EmailAddress, Avtar, Till_DT, 1, USER_DETAIL_ID, ACTIVEUSER, USERDATE, Flage, Lang1);
                        /////////////////////////////////////////////////////////
                       

                        ViewState["Edit"] = null;
                        btnAdd.Text = "Add New";
                        if (Request.QueryString["TID"] != null)
                        {
                            btnAdd.Visible = false;
                        }


                        // Clear();
                        //lblMsg.Text = "  Data Edit Successfully";
                        //pnlSuccessMsg.Visible = true;
                        Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Edit Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                      
                        //  BindData();
                        // navigation.Visible = true;
                        Readonly();
                        //  FirstData();
                    }
                }
       

                scope.Complete(); //  To commit.

            }
            BindData();
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //}
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["Previous"].ToString());
        }
        public void TenentBind()
        {
            var Datas = (from fun1 in DB.TBLLOCATIONs
                         select new
                         {
                             fun1.TenentID,

                         }
       ).Distinct();
            drpTenentID.DataSource = Datas;
            drpTenentID.DataTextField = "TenentID";
            drpTenentID.DataValueField = "TenentID";
            drpTenentID.DataBind();
            drpTenentID.Items.Insert(0, new ListItem("---Select---", "00"));
        }
        public void SessionLoad()
        {
            string Ref = ((ACMMaster)Page.Master).SessionLoad1(TID, LID, UID, EMPID, LangID);

            string[] id = Ref.Split(',');
            TIDSession = Convert.ToInt32(id[0]);
            LID = Convert.ToInt32(id[1]);
            UID = Convert.ToInt32(id[2]);
            EMPID = Convert.ToInt32(id[3]);
            LangID = id[4].ToString();
            userID1 = ((USER_MST)Session["USER"]).USER_ID;
            userTypeid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_DETAIL_ID);
        }
        public void FillContractorID()
        {
            int TID = 0;
            if (Request.QueryString["TID"] != null)
            {
                TID = Convert.ToInt32(Request.QueryString["TID"]);
            }
            else
            {
                TID = Convert.ToInt32(drpTenentID.SelectedValue);
            }

            Classes.EcommAdminClass.getdropdown(drpCOUNTRY, TIDSession, "", "", "", "tblCOUNTRY");
            //Classes.EcommAdminClass.getdropdown(DrpDefaulrLang, 0, "", "", "", "tblLanguage");
            DrpDefaulrLang.DataSource = DB.tblLanguages.Where(p => p.TenentID == TIDSession);
            DrpDefaulrLang.DataTextField = "LangName1";
            DrpDefaulrLang.DataValueField = "CULTUREOCDE";
            DrpDefaulrLang.DataBind();
            DrpDefaulrLang.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            drpUSER_TYPE.DataSource = ClsActivities.getAllRole(TIDSession);
            drpUSER_TYPE.DataTextField = "RoleName";
            drpUSER_TYPE.DataValueField = "RoleID";
            drpUSER_TYPE.DataBind();
            drpUSER_TYPE.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            //  Classes.EcommAdminClass.getdropdown(drpUSER_TYPE, TIDSession, "", "", "", "ROLE_MST");
            //}
            //else
            //{
            //    drpUSER_TYPE.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select USER_TYPE--", "0"));
            //}
            
            drpLocation.DataSource = DAL.Get_User_Location(TIDSession, UID);
            drpLocation.DataTextField = "LOCNAME1";
            drpLocation.DataValueField = "LOCATIONID";
            drpLocation.DataBind();
            drpLocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Loction--", "0"));
            drpLocation.SelectedValue = LID.ToString();
          

            drpSTATE.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select STATE--", "0"));
        }

        #region PAge Genarator navigation

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
        public void LastBindData()
        {

            int str1 = Convert.ToInt32(DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y").Max(p => p.USER_ID));
            int USERDIID = Convert.ToInt32(DB.USER_MST.Single(p => p.USER_ID == str1).USER_DETAIL_ID);
            if (DB.USER_DTL.Where(p => p.USER_DETAIL_ID == USERDIID).Count() > 0)
            {
                Database.USER_DTL objUSER_DTL = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == USERDIID);
                //txtCOUNTRY_CODE.Text = objUSER_DTL.COUNTRY_CODE;
                //txtTITLE.Text = objUSER_DTL.TITLE;
                txtHOUSE_NO.Text = objUSER_DTL.HOUSE_NO;
                txtSTREET.Text = objUSER_DTL.STREET;
                txtADDRESS1.Text = objUSER_DTL.ADDRESS1;
                txtADDRESS2.Text = objUSER_DTL.ADDRESS2;
                txtCITY.Text = objUSER_DTL.CITY;
                drpCOUNTRY.SelectedValue = objUSER_DTL.COUNTRY.ToString();
                int CID = Convert.ToInt32(drpCOUNTRY.SelectedValue);
                bindsate(CID);

                drpSTATE.SelectedValue = objUSER_DTL.STATE;
                txtZIP.Text = objUSER_DTL.ZIP;
                txtPH_NO.Text = objUSER_DTL.PH_NO;
                txtFAX_NO.Text = objUSER_DTL.FAX_NO;
                //txtVILLAGE_TOWN_CITY.Text = objUSER_DTL.VILLAGE_TOWN_CITY;
                //txtTEHSIL.Text = objUSER_DTL.TEHSIL;
                txtPINCODE_NO.Text = objUSER_DTL.PINCODE_NO;
                txtPOST_OFFICE.Text = objUSER_DTL.POST_OFFICE;
                txtPAN_NO.Text = objUSER_DTL.PAN_NO;
                txtEMAIL_ADDRESS.Text = objUSER_DTL.EMAIL_ADDRESS;
                txtMOBILE_NUM.Text = objUSER_DTL.MOBILE_NUM.ToString();
                //drpSEC_QUES.SelectedValue = objUSER_DTL.SEC_QUES;
                //txtSEC_ANS.Text = objUSER_DTL.SEC_ANS;
            }

            Database.USER_MST objUSER_MST = DB.USER_MST.Single(p => p.USER_ID == str1);
            //drpTenentID.SelectedValue = objUSER_MST.TenentID.ToString();
            //drpLoctionId.SelectedValue = objUSER_MST.LOCATION_ID.ToString();
            //   drpUSER_DETAIL_ID.SelectedValue = objUSER_MST.USER_DETAIL_ID.ToString();
            txtFIRST_NAME.Text = objUSER_MST.FIRST_NAME.ToString();
            txtLAST_NAME.Text = objUSER_MST.LAST_NAME.ToString();
            txtFIRST_NAME1.Text = objUSER_MST.FIRST_NAME1;
            txtLAST_NAME1.Text = objUSER_MST.LAST_NAME1;
            txtFIRST_NAME2.Text = objUSER_MST.FIRST_NAME2;
            txtLAST_NAME2.Text = objUSER_MST.LAST_NAME2;
            txtLOGIN_ID.Text = objUSER_MST.LOGIN_ID;
            txtPASSWORD.Text = objUSER_MST.PASSWORD;
            drpUSER_TYPE.SelectedValue = objUSER_MST.USER_TYPE.ToString();
            txtREMARKS.Text = objUSER_MST.REMARKS;
            //if (objUSER_MST.Avtar != null)
            //{
            //    txtAvtar.Text = objUSER_MST.Avtar.ToString();
            //}

            //drpCompId.SelectedValue = objUSER_MST.CompId.ToString();
        }
        public void FirstData()
        {
            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;

            Label lblUSERID = (Label)Listview1.Items[0].FindControl("lblUSERID");
            if (lblUSERID.Text != null && lblUSERID.Text != "")
            {
                int UserDetailid = Convert.ToInt32(lblUSERID.Text);
                Database.USER_DTL objdetail = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == UserDetailid);
                txtCITY.Text = objdetail.CITY != null && objdetail.CITY != null ? objdetail.CITY : "";
                drpCOUNTRY.SelectedValue = objdetail.COUNTRY != null && objdetail.COUNTRY != null ? objdetail.COUNTRY.ToString() : "";
                txtZIP.Text = objdetail.ZIP != null && objdetail.ZIP != null ? objdetail.ZIP : " ";
                txtPH_NO.Text = objdetail.PH_NO != null && objdetail.PH_NO != null ? objdetail.PH_NO : " ";
                txtFAX_NO.Text = objdetail.FAX_NO != null && objdetail.FAX_NO != null ? objdetail.FAX_NO : " ";
                //txtVILLAGE_TOWN_CITY.Text = objdetail.VILLAGE_TOWN_CITY != null && objdetail.VILLAGE_TOWN_CITY != null ? objdetail.VILLAGE_TOWN_CITY : " ";
                //txtTEHSIL.Text = objdetail.TEHSIL != null && objdetail.TEHSIL != null ? objdetail.TEHSIL : "";
                txtPINCODE_NO.Text = objdetail.PINCODE_NO != null && objdetail.PINCODE_NO != null ? objdetail.PINCODE_NO : " ";
                txtPOST_OFFICE.Text = objdetail.POST_OFFICE != null && objdetail.POST_OFFICE != null ? objdetail.POST_OFFICE : " ";
                txtPAN_NO.Text = objdetail.PAN_NO != null && objdetail.PAN_NO != null ? objdetail.PAN_NO : " ";
                txtEMAIL_ADDRESS.Text = objdetail.EMAIL_ADDRESS != null && objdetail.EMAIL_ADDRESS != null ? objdetail.EMAIL_ADDRESS : " ";
                txtMOBILE_NUM.Text = objdetail.MOBILE_NUM != null && objdetail.MOBILE_NUM != null ? objdetail.MOBILE_NUM.ToString() : " ";
                //txtSEC_ANS.Text = objdetail.SEC_ANS != null && objdetail.SEC_ANS != null ? objdetail.SEC_ANS : " ";
                //txtCOUNTRY_CODE.Text = objdetail.COUNTRY_CODE != null && objdetail.COUNTRY_CODE != null ? objdetail.COUNTRY_CODE : " ";
                //txtTITLE.Text = objdetail.TITLE != null && objdetail.TITLE != null ? objdetail.TITLE : " ";
                txtHOUSE_NO.Text = objdetail.HOUSE_NO != null && objdetail.HOUSE_NO != null ? objdetail.HOUSE_NO : " ";
                txtSTREET.Text = objdetail.STREET != null && objdetail.STREET != null ? objdetail.STREET : " ";
                txtADDRESS1.Text = objdetail.ADDRESS1 != null && objdetail.ADDRESS1 != null ? objdetail.ADDRESS1 : " ";
                txtADDRESS2.Text = objdetail.ADDRESS2 != null && objdetail.ADDRESS2 != null ? objdetail.ADDRESS2 : " ";
            }
            //  drpUSER_DETAIL_ID.SelectedValue = Listview1.SelectedDataKey[0].ToString();
            txtFIRST_NAME.Text = Listview1.SelectedDataKey[0].ToString();
            txtLAST_NAME.Text = Listview1.SelectedDataKey[1].ToString();
            txtFIRST_NAME1.Text = Listview1.SelectedDataKey[2].ToString();
            txtLAST_NAME1.Text = Listview1.SelectedDataKey[3].ToString();
            txtFIRST_NAME2.Text = Listview1.SelectedDataKey[4].ToString();
            txtLAST_NAME2.Text = Listview1.SelectedDataKey[5].ToString();

            //  txtSTATE.Text = Listview1.SelectedDataKey[0].ToString();
            //  txtFROM_REG_DT.Text = Listview1.SelectedDataKey[0].ToString();     
            // txtSEC_QUES.Text = Listview1.SelectedDataKey[0].ToString();
            txtLOGIN_ID.Text = Listview1.SelectedDataKey[6].ToString();
            txtPASSWORD.Text = Listview1.SelectedDataKey[7].ToString();
            //drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            if (Convert.ToInt32(drpUSER_TYPE.SelectedValue) != 0)
            {
                drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            }
            txtREMARKS.Text = Listview1.SelectedDataKey[9] != null ? Listview1.SelectedDataKey[9].ToString() : "";
            //txtAvtar.Text = Listview1.SelectedDataKey[10] != null ? Listview1.SelectedDataKey[10].ToString() : "";
            ////drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //if (Convert.ToInt32(drpCompId.SelectedValue) != 0)
            //{
            //    drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //}
            //  txtCRUP_ID.Text = Listview1.SelectedDataKey[0].ToString();

        }
        public void NextData()
        {

            //if (Listview1.SelectedIndex != Listview1.Items.Count - 1)
            //{
            //    Listview1.SelectedIndex = Listview1.SelectedIndex + 1;


            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;

            Label lblUSERID = (Label)Listview1.Items[0].FindControl("lblUSERID");
            if (lblUSERID.Text != null && lblUSERID.Text != "")
            {
                int UserDetailid = Convert.ToInt32(lblUSERID.Text);
                Database.USER_DTL objdetail = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == UserDetailid);
                txtCITY.Text = objdetail.CITY != null && objdetail.CITY != null ? objdetail.CITY : "";
                drpCOUNTRY.SelectedValue = objdetail.COUNTRY != null && objdetail.COUNTRY != null ? objdetail.COUNTRY.ToString() : "";
                txtZIP.Text = objdetail.ZIP != null && objdetail.ZIP != null ? objdetail.ZIP : " ";
                txtPH_NO.Text = objdetail.PH_NO != null && objdetail.PH_NO != null ? objdetail.PH_NO : " ";
                txtFAX_NO.Text = objdetail.FAX_NO != null && objdetail.FAX_NO != null ? objdetail.FAX_NO : " ";
                //txtVILLAGE_TOWN_CITY.Text = objdetail.VILLAGE_TOWN_CITY != null && objdetail.VILLAGE_TOWN_CITY != null ? objdetail.VILLAGE_TOWN_CITY : " ";
                //txtTEHSIL.Text = objdetail.TEHSIL != null && objdetail.TEHSIL != null ? objdetail.TEHSIL : "";
                txtPINCODE_NO.Text = objdetail.PINCODE_NO != null && objdetail.PINCODE_NO != null ? objdetail.PINCODE_NO : " ";
                txtPOST_OFFICE.Text = objdetail.POST_OFFICE != null && objdetail.POST_OFFICE != null ? objdetail.POST_OFFICE : " ";
                txtPAN_NO.Text = objdetail.PAN_NO != null && objdetail.PAN_NO != null ? objdetail.PAN_NO : " ";
                txtEMAIL_ADDRESS.Text = objdetail.EMAIL_ADDRESS != null && objdetail.EMAIL_ADDRESS != null ? objdetail.EMAIL_ADDRESS : " ";
                txtMOBILE_NUM.Text = objdetail.MOBILE_NUM != null && objdetail.MOBILE_NUM != null ? objdetail.MOBILE_NUM.ToString() : " ";
                //txtSEC_ANS.Text = objdetail.SEC_ANS != null && objdetail.SEC_ANS != null ? objdetail.SEC_ANS : " ";
                //txtCOUNTRY_CODE.Text = objdetail.COUNTRY_CODE != null && objdetail.COUNTRY_CODE != null ? objdetail.COUNTRY_CODE : " ";
                //txtTITLE.Text = objdetail.TITLE != null && objdetail.TITLE != null ? objdetail.TITLE : " ";
                txtHOUSE_NO.Text = objdetail.HOUSE_NO != null && objdetail.HOUSE_NO != null ? objdetail.HOUSE_NO : " ";
                txtSTREET.Text = objdetail.STREET != null && objdetail.STREET != null ? objdetail.STREET : " ";
                txtADDRESS1.Text = objdetail.ADDRESS1 != null && objdetail.ADDRESS1 != null ? objdetail.ADDRESS1 : " ";
                txtADDRESS2.Text = objdetail.ADDRESS2 != null && objdetail.ADDRESS2 != null ? objdetail.ADDRESS2 : " ";
            }
            //  drpUSER_DETAIL_ID.SelectedValue = Listview1.SelectedDataKey[0].ToString();
            txtFIRST_NAME.Text = Listview1.SelectedDataKey[0].ToString();
            txtLAST_NAME.Text = Listview1.SelectedDataKey[1].ToString();
            txtFIRST_NAME1.Text = Listview1.SelectedDataKey[2].ToString();
            txtLAST_NAME1.Text = Listview1.SelectedDataKey[3].ToString();
            txtFIRST_NAME2.Text = Listview1.SelectedDataKey[4].ToString();
            txtLAST_NAME2.Text = Listview1.SelectedDataKey[5].ToString();

            //  txtSTATE.Text = Listview1.SelectedDataKey[0].ToString();
            //  txtFROM_REG_DT.Text = Listview1.SelectedDataKey[0].ToString();     
            // txtSEC_QUES.Text = Listview1.SelectedDataKey[0].ToString();
            txtLOGIN_ID.Text = Listview1.SelectedDataKey[6].ToString();
            txtPASSWORD.Text = Listview1.SelectedDataKey[7].ToString();
            //drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            if (Convert.ToInt32(drpUSER_TYPE.SelectedValue) != 0)
            {
                drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            }
            txtREMARKS.Text = Listview1.SelectedDataKey[9] != null ? Listview1.SelectedDataKey[9].ToString() : "";
            //txtAvtar.Text = Listview1.SelectedDataKey[10] != null ? Listview1.SelectedDataKey[10].ToString() : "";
            ////drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //if (Convert.ToInt32(drpCompId.SelectedValue) != 0)
            //{
            //    drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //}
            //  txtCRUP_ID.Text = Listview1.SelectedDataKey[0].ToString();
        }


        public void PrevData()
        {
            //if (Listview1.SelectedIndex == 0)
            //{
            //    lblMsg.Text = "This is first record";
            //    pnlSuccessMsg.Visible = true;

            //}
            //else
            //{
            //    pnlSuccessMsg.Visible = false;
            //    Listview1.SelectedIndex = Listview1.SelectedIndex - 1;


            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;

            Label lblUSERID = (Label)Listview1.Items[0].FindControl("lblUSERID");
            if (lblUSERID.Text != null && lblUSERID.Text != "")
            {
                int UserDetailid = Convert.ToInt32(lblUSERID.Text);
                Database.USER_DTL objdetail = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == UserDetailid);
                txtCITY.Text = objdetail.CITY != null && objdetail.CITY != null ? objdetail.CITY : "";
                drpCOUNTRY.SelectedValue = objdetail.COUNTRY != null && objdetail.COUNTRY != null ? objdetail.COUNTRY.ToString() : "";
                txtZIP.Text = objdetail.ZIP != null && objdetail.ZIP != null ? objdetail.ZIP : " ";
                txtPH_NO.Text = objdetail.PH_NO != null && objdetail.PH_NO != null ? objdetail.PH_NO : " ";
                txtFAX_NO.Text = objdetail.FAX_NO != null && objdetail.FAX_NO != null ? objdetail.FAX_NO : " ";
                //txtVILLAGE_TOWN_CITY.Text = objdetail.VILLAGE_TOWN_CITY != null && objdetail.VILLAGE_TOWN_CITY != null ? objdetail.VILLAGE_TOWN_CITY : " ";
                //txtTEHSIL.Text = objdetail.TEHSIL != null && objdetail.TEHSIL != null ? objdetail.TEHSIL : "";
                txtPINCODE_NO.Text = objdetail.PINCODE_NO != null && objdetail.PINCODE_NO != null ? objdetail.PINCODE_NO : " ";
                txtPOST_OFFICE.Text = objdetail.POST_OFFICE != null && objdetail.POST_OFFICE != null ? objdetail.POST_OFFICE : " ";
                txtPAN_NO.Text = objdetail.PAN_NO != null && objdetail.PAN_NO != null ? objdetail.PAN_NO : " ";
                txtEMAIL_ADDRESS.Text = objdetail.EMAIL_ADDRESS != null && objdetail.EMAIL_ADDRESS != null ? objdetail.EMAIL_ADDRESS : " ";
                txtMOBILE_NUM.Text = objdetail.MOBILE_NUM != null && objdetail.MOBILE_NUM != null ? objdetail.MOBILE_NUM.ToString() : " ";
                //txtSEC_ANS.Text = objdetail.SEC_ANS != null && objdetail.SEC_ANS != null ? objdetail.SEC_ANS : " ";
                //txtCOUNTRY_CODE.Text = objdetail.COUNTRY_CODE != null && objdetail.COUNTRY_CODE != null ? objdetail.COUNTRY_CODE : " ";
                //txtTITLE.Text = objdetail.TITLE != null && objdetail.TITLE != null ? objdetail.TITLE : " ";
                txtHOUSE_NO.Text = objdetail.HOUSE_NO != null && objdetail.HOUSE_NO != null ? objdetail.HOUSE_NO : " ";
                txtSTREET.Text = objdetail.STREET != null && objdetail.STREET != null ? objdetail.STREET : " ";
                txtADDRESS1.Text = objdetail.ADDRESS1 != null && objdetail.ADDRESS1 != null ? objdetail.ADDRESS1 : " ";
                txtADDRESS2.Text = objdetail.ADDRESS2 != null && objdetail.ADDRESS2 != null ? objdetail.ADDRESS2 : " ";
            }
            //  drpUSER_DETAIL_ID.SelectedValue = Listview1.SelectedDataKey[0].ToString();
            txtFIRST_NAME.Text = Listview1.SelectedDataKey[0].ToString();
            txtLAST_NAME.Text = Listview1.SelectedDataKey[1].ToString();
            txtFIRST_NAME1.Text = Listview1.SelectedDataKey[2].ToString();
            txtLAST_NAME1.Text = Listview1.SelectedDataKey[3].ToString();
            txtFIRST_NAME2.Text = Listview1.SelectedDataKey[4].ToString();
            txtLAST_NAME2.Text = Listview1.SelectedDataKey[5].ToString();

            //  txtSTATE.Text = Listview1.SelectedDataKey[0].ToString();
            //  txtFROM_REG_DT.Text = Listview1.SelectedDataKey[0].ToString();     
            // txtSEC_QUES.Text = Listview1.SelectedDataKey[0].ToString();
            txtLOGIN_ID.Text = Listview1.SelectedDataKey[6].ToString();
            txtPASSWORD.Text = Listview1.SelectedDataKey[7].ToString();
            //drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            if (Convert.ToInt32(drpUSER_TYPE.SelectedValue) != 0)
            {
                drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            }
            txtREMARKS.Text = Listview1.SelectedDataKey[9] != null ? Listview1.SelectedDataKey[9].ToString() : "";
            //txtAvtar.Text = Listview1.SelectedDataKey[10] != null ? Listview1.SelectedDataKey[10].ToString() : "";
            ////drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //if (Convert.ToInt32(drpCompId.SelectedValue) != 0)
            //{
            //    drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //}
            //  txtCRUP_ID.Text = Listview1.SelectedDataKey[0].ToString();
        }



        public void LastData()
        {
            //Listview1.SelectedIndex = Listview1.Items.Count - 1;

            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;

            Label lblUSERID = (Label)Listview1.Items[0].FindControl("lblUSERID");
            if (lblUSERID.Text != null && lblUSERID.Text != "")
            {
                int UserDetailid = Convert.ToInt32(lblUSERID.Text);
                Database.USER_DTL objdetail = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == UserDetailid);
                txtCITY.Text = objdetail.CITY != null && objdetail.CITY != null ? objdetail.CITY : "";
                drpCOUNTRY.SelectedValue = objdetail.COUNTRY != null && objdetail.COUNTRY != null ? objdetail.COUNTRY.ToString() : "";
                txtZIP.Text = objdetail.ZIP != null && objdetail.ZIP != null ? objdetail.ZIP : " ";
                txtPH_NO.Text = objdetail.PH_NO != null && objdetail.PH_NO != null ? objdetail.PH_NO : " ";
                txtFAX_NO.Text = objdetail.FAX_NO != null && objdetail.FAX_NO != null ? objdetail.FAX_NO : " ";
                //txtVILLAGE_TOWN_CITY.Text = objdetail.VILLAGE_TOWN_CITY != null && objdetail.VILLAGE_TOWN_CITY != null ? objdetail.VILLAGE_TOWN_CITY : " ";
                //txtTEHSIL.Text = objdetail.TEHSIL != null && objdetail.TEHSIL != null ? objdetail.TEHSIL : "";
                txtPINCODE_NO.Text = objdetail.PINCODE_NO != null && objdetail.PINCODE_NO != null ? objdetail.PINCODE_NO : " ";
                txtPOST_OFFICE.Text = objdetail.POST_OFFICE != null && objdetail.POST_OFFICE != null ? objdetail.POST_OFFICE : " ";
                txtPAN_NO.Text = objdetail.PAN_NO != null && objdetail.PAN_NO != null ? objdetail.PAN_NO : " ";
                txtEMAIL_ADDRESS.Text = objdetail.EMAIL_ADDRESS != null && objdetail.EMAIL_ADDRESS != null ? objdetail.EMAIL_ADDRESS : " ";
                txtMOBILE_NUM.Text = objdetail.MOBILE_NUM != null && objdetail.MOBILE_NUM != null ? objdetail.MOBILE_NUM.ToString() : " ";
                //txtSEC_ANS.Text = objdetail.SEC_ANS != null && objdetail.SEC_ANS != null ? objdetail.SEC_ANS : " ";
                //txtCOUNTRY_CODE.Text = objdetail.COUNTRY_CODE != null && objdetail.COUNTRY_CODE != null ? objdetail.COUNTRY_CODE : " ";
                //txtTITLE.Text = objdetail.TITLE != null && objdetail.TITLE != null ? objdetail.TITLE : " ";
                txtHOUSE_NO.Text = objdetail.HOUSE_NO != null && objdetail.HOUSE_NO != null ? objdetail.HOUSE_NO : " ";
                txtSTREET.Text = objdetail.STREET != null && objdetail.STREET != null ? objdetail.STREET : " ";
                txtADDRESS1.Text = objdetail.ADDRESS1 != null && objdetail.ADDRESS1 != null ? objdetail.ADDRESS1 : " ";
                txtADDRESS2.Text = objdetail.ADDRESS2 != null && objdetail.ADDRESS2 != null ? objdetail.ADDRESS2 : " ";
            }
            //  drpUSER_DETAIL_ID.SelectedValue = Listview1.SelectedDataKey[0].ToString();
            txtFIRST_NAME.Text = Listview1.SelectedDataKey[0].ToString();
            txtLAST_NAME.Text = Listview1.SelectedDataKey[1].ToString();
            txtFIRST_NAME1.Text = Listview1.SelectedDataKey[2].ToString();
            txtLAST_NAME1.Text = Listview1.SelectedDataKey[3].ToString();
            txtFIRST_NAME2.Text = Listview1.SelectedDataKey[4].ToString();
            txtLAST_NAME2.Text = Listview1.SelectedDataKey[5].ToString();

            //  txtSTATE.Text = Listview1.SelectedDataKey[0].ToString();
            //  txtFROM_REG_DT.Text = Listview1.SelectedDataKey[0].ToString();     
            // txtSEC_QUES.Text = Listview1.SelectedDataKey[0].ToString();
            txtLOGIN_ID.Text = Listview1.SelectedDataKey[6].ToString();
            txtPASSWORD.Text = Listview1.SelectedDataKey[7].ToString();
            //drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            if (Convert.ToInt32(drpUSER_TYPE.SelectedValue) != 0)
            {
                drpUSER_TYPE.SelectedValue = Listview1.SelectedDataKey[8] != null ? Listview1.SelectedDataKey[8].ToString() : "0";
            }
            txtREMARKS.Text = Listview1.SelectedDataKey[9] != null ? Listview1.SelectedDataKey[9].ToString() : "";
            //txtAvtar.Text = Listview1.SelectedDataKey[10] != null ? Listview1.SelectedDataKey[10].ToString() : "";
            ////drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //if (Convert.ToInt32(drpCompId.SelectedValue) != 0)
            //{
            //    drpCompId.SelectedValue = Listview1.SelectedDataKey[11] != null ? Listview1.SelectedDataKey[11].ToString() : "0";
            //}
            //  txtCRUP_ID.Text = Listview1.SelectedDataKey[0].ToString();
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
                    lblFIRST_NAME2h.Visible = lblLAST_NAME2h.Visible = lblFIRST_NAME12h.Visible = lblLAST_NAME12h.Visible = lblFIRST_NAME22h.Visible = lblLAST_NAME22h.Visible = lblHOUSE_NO2h.Visible = lblSTREET2h.Visible = lblADDRESS12h.Visible = lblADDRESS22h.Visible = lblCITY2h.Visible = lblCOUNTRY2h.Visible = lblSTATE2h.Visible = lblZIP2h.Visible = lblPH_NO2h.Visible = lblFAX_NO2h.Visible = lblPINCODE_NO2h.Visible = lblPOST_OFFICE2h.Visible = lblPAN_NO2h.Visible = lblEMAIL_ADDRESS2h.Visible = lblMOBILE_NUM2h.Visible = lblLOGIN_ID2h.Visible = lblPASSWORD2h.Visible = lblUSER_TYPE2h.Visible = lblREMARKS2h.Visible = lblTill_DT2h.Visible = false;
                    //2true
                    txtFIRST_NAME2h.Visible = txtLAST_NAME2h.Visible = txtFIRST_NAME12h.Visible = txtLAST_NAME12h.Visible = txtFIRST_NAME22h.Visible = txtLAST_NAME22h.Visible = txtHOUSE_NO2h.Visible = txtSTREET2h.Visible = txtADDRESS12h.Visible = txtADDRESS22h.Visible = txtCITY2h.Visible = txtCOUNTRY2h.Visible = txtSTATE2h.Visible = txtZIP2h.Visible = txtPH_NO2h.Visible = txtFAX_NO2h.Visible = txtPINCODE_NO2h.Visible = txtPOST_OFFICE2h.Visible = txtPAN_NO2h.Visible = txtEMAIL_ADDRESS2h.Visible = txtMOBILE_NUM2h.Visible = txtLOGIN_ID2h.Visible = txtPASSWORD2h.Visible = txtUSER_TYPE2h.Visible = txtREMARKS2h.Visible = txtTill_DT2h.Visible = true;

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
                    lblFIRST_NAME2h.Visible = lblLAST_NAME2h.Visible = lblFIRST_NAME12h.Visible = lblLAST_NAME12h.Visible = lblFIRST_NAME22h.Visible = lblLAST_NAME22h.Visible = lblHOUSE_NO2h.Visible = lblSTREET2h.Visible = lblADDRESS12h.Visible = lblADDRESS22h.Visible = lblCITY2h.Visible = lblCOUNTRY2h.Visible = lblSTATE2h.Visible = lblZIP2h.Visible = lblPH_NO2h.Visible = lblFAX_NO2h.Visible = lblPINCODE_NO2h.Visible = lblPOST_OFFICE2h.Visible = lblPAN_NO2h.Visible = lblEMAIL_ADDRESS2h.Visible = lblMOBILE_NUM2h.Visible = lblLOGIN_ID2h.Visible = lblPASSWORD2h.Visible = lblUSER_TYPE2h.Visible = lblREMARKS2h.Visible = lblTill_DT2h.Visible = true;
                    //2false
                    txtFIRST_NAME2h.Visible = txtLAST_NAME2h.Visible = txtFIRST_NAME12h.Visible = txtLAST_NAME12h.Visible = txtFIRST_NAME22h.Visible = txtLAST_NAME22h.Visible = txtHOUSE_NO2h.Visible = txtSTREET2h.Visible = txtADDRESS12h.Visible = txtADDRESS22h.Visible = txtCITY2h.Visible = txtCOUNTRY2h.Visible = txtSTATE2h.Visible = txtZIP2h.Visible = txtPH_NO2h.Visible = txtFAX_NO2h.Visible = txtPINCODE_NO2h.Visible = txtPOST_OFFICE2h.Visible = txtPAN_NO2h.Visible = txtEMAIL_ADDRESS2h.Visible = txtMOBILE_NUM2h.Visible = txtLOGIN_ID2h.Visible = txtPASSWORD2h.Visible = txtUSER_TYPE2h.Visible = txtREMARKS2h.Visible = txtTill_DT2h.Visible = false;

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
                    lblFIRST_NAME1s.Visible = lblLAST_NAME1s.Visible = lblFIRST_NAME11s.Visible = lblLAST_NAME11s.Visible = lblFIRST_NAME21s.Visible = lblLAST_NAME21s.Visible = lblHOUSE_NO1s.Visible = lblSTREET1s.Visible = lblADDRESS11s.Visible = lblADDRESS21s.Visible = lblCITY1s.Visible = lblCOUNTRY1s.Visible = lblSTATE1s.Visible = lblZIP1s.Visible = lblPH_NO1s.Visible = lblFAX_NO1s.Visible = lblPINCODE_NO1s.Visible = lblPOST_OFFICE1s.Visible = lblPAN_NO1s.Visible = lblEMAIL_ADDRESS1s.Visible = lblMOBILE_NUM1s.Visible = lblLOGIN_ID1s.Visible = lblPASSWORD1s.Visible = lblUSER_TYPE1s.Visible = lblREMARKS1s.Visible = lblTill_DT1s.Visible = lblTill_DT1s.Visible = false;
                    //1true
                    txtFIRST_NAME1s.Visible = txtLAST_NAME1s.Visible = txtFIRST_NAME11s.Visible = txtLAST_NAME11s.Visible = txtFIRST_NAME21s.Visible = txtLAST_NAME21s.Visible = txtHOUSE_NO1s.Visible = txtSTREET1s.Visible = txtADDRESS11s.Visible = txtADDRESS21s.Visible = txtCITY1s.Visible = txtCOUNTRY1s.Visible = txtSTATE1s.Visible = txtZIP1s.Visible = txtPH_NO1s.Visible = txtFAX_NO1s.Visible = txtPINCODE_NO1s.Visible = txtPOST_OFFICE1s.Visible = txtPAN_NO1s.Visible = txtEMAIL_ADDRESS1s.Visible = txtMOBILE_NUM1s.Visible = txtLOGIN_ID1s.Visible = txtPASSWORD1s.Visible = txtUSER_TYPE1s.Visible = txtREMARKS1s.Visible = txtTill_DT1s.Visible = txtTill_DT1s.Visible = true;
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
                    lblFIRST_NAME1s.Visible = lblLAST_NAME1s.Visible = lblFIRST_NAME11s.Visible = lblLAST_NAME11s.Visible = lblFIRST_NAME21s.Visible = lblLAST_NAME21s.Visible = lblHOUSE_NO1s.Visible = lblSTREET1s.Visible = lblADDRESS11s.Visible = lblADDRESS21s.Visible = lblCITY1s.Visible = lblCOUNTRY1s.Visible = lblSTATE1s.Visible = lblZIP1s.Visible = lblPH_NO1s.Visible = lblFAX_NO1s.Visible = lblPINCODE_NO1s.Visible = lblPOST_OFFICE1s.Visible = lblPAN_NO1s.Visible = lblEMAIL_ADDRESS1s.Visible = lblMOBILE_NUM1s.Visible = lblLOGIN_ID1s.Visible = lblPASSWORD1s.Visible = lblUSER_TYPE1s.Visible = lblREMARKS1s.Visible = lblTill_DT1s.Visible = lblTill_DT1s.Visible = true;
                    //1false
                    txtFIRST_NAME1s.Visible = txtLAST_NAME1s.Visible = txtFIRST_NAME11s.Visible = txtLAST_NAME11s.Visible = txtFIRST_NAME21s.Visible = txtLAST_NAME21s.Visible = txtHOUSE_NO1s.Visible = txtSTREET1s.Visible = txtADDRESS11s.Visible = txtADDRESS21s.Visible = txtCITY1s.Visible = txtCOUNTRY1s.Visible = txtSTATE1s.Visible = txtZIP1s.Visible = txtPH_NO1s.Visible = txtFAX_NO1s.Visible = txtPINCODE_NO1s.Visible = txtPOST_OFFICE1s.Visible = txtPAN_NO1s.Visible = txtEMAIL_ADDRESS1s.Visible = txtMOBILE_NUM1s.Visible = txtLOGIN_ID1s.Visible = txtPASSWORD1s.Visible = txtUSER_TYPE1s.Visible = txtREMARKS1s.Visible = txtTill_DT1s.Visible = txtTill_DT1s.Visible = false;
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

            List<Database.TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("ERP_WEB_USER_MST").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.TBLLabelDTL item in List)
            {
                if (lblFIRST_NAME1s.ID == item.LabelID)
                    txtFIRST_NAME1s.Text = lblFIRST_NAME1s.Text = lblhFIRST_NAME.Text = item.LabelName;
                else if (lblLAST_NAME1s.ID == item.LabelID)
                    txtLAST_NAME1s.Text = lblLAST_NAME1s.Text = lblhLAST_NAME.Text = item.LabelName;
                else if (lblFIRST_NAME11s.ID == item.LabelID)
                    txtFIRST_NAME11s.Text = lblFIRST_NAME11s.Text = item.LabelName;
                else if (lblLAST_NAME11s.ID == item.LabelID)
                    txtLAST_NAME11s.Text = lblLAST_NAME11s.Text = item.LabelName;
                else if (lblFIRST_NAME21s.ID == item.LabelID)
                    txtFIRST_NAME21s.Text = lblFIRST_NAME21s.Text = item.LabelName;
                else if (lblLAST_NAME21s.ID == item.LabelID)
                    txtLAST_NAME21s.Text = lblLAST_NAME21s.Text = item.LabelName;
                //else if (lblCOUNTRY_CODE1s.ID == item.LabelID)
                //    txtCOUNTRY_CODE1s.Text = lblCOUNTRY_CODE1s.Text = item.LabelName;
                //else if (lblTITLE1s.ID == item.LabelID)
                //    txtTITLE1s.Text = lblTITLE1s.Text = item.LabelName;
                else if (lblHOUSE_NO1s.ID == item.LabelID)
                    txtHOUSE_NO1s.Text = lblHOUSE_NO1s.Text = item.LabelName;
                else if (lblSTREET1s.ID == item.LabelID)
                    txtSTREET1s.Text = lblSTREET1s.Text = item.LabelName;
                else if (lblADDRESS11s.ID == item.LabelID)
                    txtADDRESS11s.Text = lblADDRESS11s.Text = item.LabelName;
                else if (lblADDRESS21s.ID == item.LabelID)
                    txtADDRESS21s.Text = lblADDRESS21s.Text = item.LabelName;
                else if (lblCITY1s.ID == item.LabelID)
                    txtCITY1s.Text = lblCITY1s.Text = lblhCITY.Text = item.LabelName;
                else if (lblCOUNTRY1s.ID == item.LabelID)
                    txtCOUNTRY1s.Text = lblCOUNTRY1s.Text = item.LabelName;
                else if (lblSTATE1s.ID == item.LabelID)
                    txtSTATE1s.Text = lblSTATE1s.Text = item.LabelName;
                else if (lblZIP1s.ID == item.LabelID)
                    txtZIP1s.Text = lblZIP1s.Text = item.LabelName;
                else if (lblPH_NO1s.ID == item.LabelID)
                    txtPH_NO1s.Text = lblPH_NO1s.Text = lblhPH_NO.Text = item.LabelName;
                else if (lblFAX_NO1s.ID == item.LabelID)
                    txtFAX_NO1s.Text = lblFAX_NO1s.Text = item.LabelName;
                //else if (lblVILLAGE_TOWN_CITY1s.ID == item.LabelID)
                //    txtVILLAGE_TOWN_CITY1s.Text = lblVILLAGE_TOWN_CITY1s.Text = item.LabelName;
                //else if (lblTEHSIL1s.ID == item.LabelID)
                //    txtTEHSIL1s.Text = lblTEHSIL1s.Text = item.LabelName;
                else if (lblPINCODE_NO1s.ID == item.LabelID)
                    txtPINCODE_NO1s.Text = lblPINCODE_NO1s.Text = item.LabelName;
                else if (lblPOST_OFFICE1s.ID == item.LabelID)
                    txtPOST_OFFICE1s.Text = lblPOST_OFFICE1s.Text = item.LabelName;
                else if (lblPAN_NO1s.ID == item.LabelID)
                    txtPAN_NO1s.Text = lblPAN_NO1s.Text = item.LabelName;
                else if (lblEMAIL_ADDRESS1s.ID == item.LabelID)
                    txtEMAIL_ADDRESS1s.Text = lblEMAIL_ADDRESS1s.Text = item.LabelName;
                else if (lblMOBILE_NUM1s.ID == item.LabelID)
                    txtMOBILE_NUM1s.Text = lblMOBILE_NUM1s.Text = item.LabelName;
                //else if (lblSEC_QUES1s.ID == item.LabelID)
                //    txtSEC_QUES1s.Text = lblSEC_QUES1s.Text = item.LabelName;
                //else if (lblSEC_ANS1s.ID == item.LabelID)
                //    txtSEC_ANS1s.Text = lblSEC_ANS1s.Text = item.LabelName;
                else if (lblLOGIN_ID1s.ID == item.LabelID)
                    txtLOGIN_ID1s.Text = lblLOGIN_ID1s.Text = lblhLOGIN_ID.Text = item.LabelName;
                else if (lblPASSWORD1s.ID == item.LabelID)
                    txtPASSWORD1s.Text = lblPASSWORD1s.Text = lblhPASSWORD.Text = item.LabelName;
                else if (lblUSER_TYPE1s.ID == item.LabelID)
                    txtUSER_TYPE1s.Text = lblUSER_TYPE1s.Text = lblhUSER_TYPE.Text = item.LabelName;
                else if (lblREMARKS1s.ID == item.LabelID)
                    txtREMARKS1s.Text = lblREMARKS1s.Text = item.LabelName;
                //else if (lblAvtar1s.ID == item.LabelID)
                //    txtAvtar1s.Text = lblAvtar1s.Text = item.LabelName;
                //else if (lblCompId1s.ID == item.LabelID)
                //    txtCompId1s.Text = lblCompId1s.Text = item.LabelName;
                else if (lblFIRST_NAME2h.ID == item.LabelID)
                    txtFIRST_NAME2h.Text = lblFIRST_NAME2h.Text = lblhFIRST_NAME.Text = item.LabelName;
                else if (lblLAST_NAME2h.ID == item.LabelID)
                    txtLAST_NAME2h.Text = lblLAST_NAME2h.Text = lblhLAST_NAME.Text = item.LabelName;
                else if (lblFIRST_NAME12h.ID == item.LabelID)
                    txtFIRST_NAME12h.Text = lblFIRST_NAME12h.Text = item.LabelName;
                else if (lblLAST_NAME12h.ID == item.LabelID)
                    txtLAST_NAME12h.Text = lblLAST_NAME12h.Text = item.LabelName;
                else if (lblFIRST_NAME22h.ID == item.LabelID)
                    txtFIRST_NAME22h.Text = lblFIRST_NAME22h.Text = item.LabelName;
                else if (lblLAST_NAME22h.ID == item.LabelID)
                    txtLAST_NAME22h.Text = lblLAST_NAME22h.Text = item.LabelName;
                //else if (lblCOUNTRY_CODE2h.ID == item.LabelID)
                //    txtCOUNTRY_CODE2h.Text = lblCOUNTRY_CODE2h.Text = item.LabelName;
                //else if (lblTITLE2h.ID == item.LabelID)
                //    txtTITLE2h.Text = lblTITLE2h.Text = item.LabelName;
                else if (lblHOUSE_NO2h.ID == item.LabelID)
                    txtHOUSE_NO2h.Text = lblHOUSE_NO2h.Text = item.LabelName;
                else if (lblSTREET2h.ID == item.LabelID)
                    txtSTREET2h.Text = lblSTREET2h.Text = item.LabelName;
                else if (lblADDRESS12h.ID == item.LabelID)
                    txtADDRESS12h.Text = lblADDRESS12h.Text = item.LabelName;
                else if (lblADDRESS22h.ID == item.LabelID)
                    txtADDRESS22h.Text = lblADDRESS22h.Text = item.LabelName;
                else if (lblCITY2h.ID == item.LabelID)
                    txtCITY2h.Text = lblCITY2h.Text = lblhCITY.Text = item.LabelName;
                else if (lblCOUNTRY2h.ID == item.LabelID)
                    txtCOUNTRY2h.Text = lblCOUNTRY2h.Text = item.LabelName;
                else if (lblSTATE2h.ID == item.LabelID)
                    txtSTATE2h.Text = lblSTATE2h.Text = item.LabelName;
                else if (lblZIP2h.ID == item.LabelID)
                    txtZIP2h.Text = lblZIP2h.Text = item.LabelName;
                else if (lblPH_NO2h.ID == item.LabelID)
                    txtPH_NO2h.Text = lblPH_NO2h.Text = lblhPH_NO.Text = item.LabelName;
                else if (lblFAX_NO2h.ID == item.LabelID)
                    txtFAX_NO2h.Text = lblFAX_NO2h.Text = item.LabelName;
                //else if (lblVILLAGE_TOWN_CITY2h.ID == item.LabelID)
                //    txtVILLAGE_TOWN_CITY2h.Text = lblVILLAGE_TOWN_CITY2h.Text = item.LabelName;
                //else if (lblTEHSIL2h.ID == item.LabelID)
                //    txtTEHSIL2h.Text = lblTEHSIL2h.Text = item.LabelName;
                else if (lblPINCODE_NO2h.ID == item.LabelID)
                    txtPINCODE_NO2h.Text = lblPINCODE_NO2h.Text = item.LabelName;
                else if (lblPOST_OFFICE2h.ID == item.LabelID)
                    txtPOST_OFFICE2h.Text = lblPOST_OFFICE2h.Text = item.LabelName;
                else if (lblPAN_NO2h.ID == item.LabelID)
                    txtPAN_NO2h.Text = lblPAN_NO2h.Text = item.LabelName;
                else if (lblEMAIL_ADDRESS2h.ID == item.LabelID)
                    txtEMAIL_ADDRESS2h.Text = lblEMAIL_ADDRESS2h.Text = item.LabelName;
                else if (lblMOBILE_NUM2h.ID == item.LabelID)
                    txtMOBILE_NUM2h.Text = lblMOBILE_NUM2h.Text = item.LabelName;
                //else if (lblSEC_QUES2h.ID == item.LabelID)
                //    txtSEC_QUES2h.Text = lblSEC_QUES2h.Text = item.LabelName;
                //else if (lblSEC_ANS2h.ID == item.LabelID)
                //    txtSEC_ANS2h.Text = lblSEC_ANS2h.Text = item.LabelName;
                else if (lblLOGIN_ID2h.ID == item.LabelID)
                    txtLOGIN_ID2h.Text = lblLOGIN_ID2h.Text = lblhLOGIN_ID.Text = item.LabelName;
                else if (lblPASSWORD2h.ID == item.LabelID)
                    txtPASSWORD2h.Text = lblPASSWORD2h.Text = lblhPASSWORD.Text = item.LabelName;
                else if (lblUSER_TYPE2h.ID == item.LabelID)
                    txtUSER_TYPE2h.Text = lblUSER_TYPE2h.Text = lblhUSER_TYPE.Text = item.LabelName;
                else if (lblREMARKS2h.ID == item.LabelID)
                    txtREMARKS2h.Text = lblREMARKS2h.Text = item.LabelName;
                //else if (lblAvtar2h.ID == item.LabelID)
                //    txtAvtar2h.Text = lblAvtar2h.Text = item.LabelName;
                //else if (lblCompId2h.ID == item.LabelID)
                //    txtCompId2h.Text = lblCompId2h.Text = item.LabelName;
                else if (lblTill_DT2h.ID == item.LabelID)
                    txtTill_DT2h.Text = lblTill_DT2h.Text = item.LabelName;
                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
            }

        }
        public void SaveLabel(string lang)
        {
            string PID = ((ACMMaster)this.Master).getOwnPage();
            //List<Database.TBLLabelDTL> List = DB.TBLLabelDTLs.Where(p => p.LabelMstID == PID  && p.LANGDISP == lang).ToList();
            List<Database.TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("ERP_WEB_USER_MST").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("\\ACM\\xml\\ERP_WEB_USER_MST.xml"));
            foreach (Database.TBLLabelDTL item in List)
            {

                var obj = ((ACMMaster)this.Master).Bindxml("ERP_WEB_USER_MST").Single(p => p.LabelID == item.LabelID && p.LabelMstID == PID && p.LANGDISP == lang);
                int i = obj.ID - 1;

                if (lblFIRST_NAME1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME1s.Text;
                else if (lblLAST_NAME1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME1s.Text;
                else if (lblFIRST_NAME11s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME11s.Text;
                else if (lblLAST_NAME11s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME11s.Text;
                else if (lblFIRST_NAME21s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME21s.Text;
                else if (lblLAST_NAME21s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME21s.Text;
                //else if (lblCOUNTRY_CODE1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtCOUNTRY_CODE1s.Text;
                //else if (lblTITLE1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTITLE1s.Text;
                else if (lblHOUSE_NO1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHOUSE_NO1s.Text;
                else if (lblSTREET1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSTREET1s.Text;
                else if (lblADDRESS11s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDRESS11s.Text;
                else if (lblADDRESS21s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDRESS21s.Text;
                else if (lblCITY1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCITY1s.Text;
                else if (lblCOUNTRY1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCOUNTRY1s.Text;
                else if (lblSTATE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSTATE1s.Text;
                else if (lblZIP1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtZIP1s.Text;
                else if (lblPH_NO1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPH_NO1s.Text;
                else if (lblFAX_NO1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFAX_NO1s.Text;
                //else if (lblVILLAGE_TOWN_CITY1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtVILLAGE_TOWN_CITY1s.Text;
                //else if (lblTEHSIL1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTEHSIL1s.Text;
                else if (lblPINCODE_NO1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPINCODE_NO1s.Text;
                else if (lblPOST_OFFICE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPOST_OFFICE1s.Text;
                else if (lblPAN_NO1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPAN_NO1s.Text;
                else if (lblEMAIL_ADDRESS1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtEMAIL_ADDRESS1s.Text;
                else if (lblMOBILE_NUM1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMOBILE_NUM1s.Text;
                //else if (lblSEC_QUES1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtSEC_QUES1s.Text;
                //else if (lblSEC_ANS1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtSEC_ANS1s.Text;
                else if (lblLOGIN_ID1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLOGIN_ID1s.Text;
                else if (lblPASSWORD1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPASSWORD1s.Text;
                else if (lblUSER_TYPE1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtUSER_TYPE1s.Text;
                else if (lblREMARKS1s.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtREMARKS1s.Text;
                //else if (lblAvtar1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtAvtar1s.Text;
                //else if (lblCompId1s.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtCompId1s.Text;
                else if (lblFIRST_NAME2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME2h.Text;
                else if (lblLAST_NAME2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME2h.Text;
                else if (lblFIRST_NAME12h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME12h.Text;
                else if (lblLAST_NAME12h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME12h.Text;
                else if (lblFIRST_NAME22h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFIRST_NAME22h.Text;
                else if (lblLAST_NAME22h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLAST_NAME22h.Text;
                //else if (lblCOUNTRY_CODE2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtCOUNTRY_CODE2h.Text;
                //else if (lblTITLE2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTITLE2h.Text;
                else if (lblHOUSE_NO2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtHOUSE_NO2h.Text;
                else if (lblSTREET2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSTREET2h.Text;
                else if (lblADDRESS12h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDRESS12h.Text;
                else if (lblADDRESS22h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtADDRESS22h.Text;
                else if (lblCITY2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCITY2h.Text;
                else if (lblCOUNTRY2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtCOUNTRY2h.Text;
                else if (lblSTATE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtSTATE2h.Text;
                else if (lblZIP2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtZIP2h.Text;
                else if (lblPH_NO2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPH_NO2h.Text;
                else if (lblFAX_NO2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtFAX_NO2h.Text;
                //else if (lblVILLAGE_TOWN_CITY2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtVILLAGE_TOWN_CITY2h.Text;
                //else if (lblTEHSIL2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtTEHSIL2h.Text;
                else if (lblPINCODE_NO2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPINCODE_NO2h.Text;
                else if (lblPOST_OFFICE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPOST_OFFICE2h.Text;
                else if (lblPAN_NO2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPAN_NO2h.Text;
                else if (lblEMAIL_ADDRESS2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtEMAIL_ADDRESS2h.Text;
                else if (lblMOBILE_NUM2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtMOBILE_NUM2h.Text;
                //else if (lblSEC_QUES2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtSEC_QUES2h.Text;
                //else if (lblSEC_ANS2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtSEC_ANS2h.Text;
                else if (lblLOGIN_ID2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtLOGIN_ID2h.Text;
                else if (lblPASSWORD2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtPASSWORD2h.Text;
                else if (lblUSER_TYPE2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtUSER_TYPE2h.Text;
                else if (lblREMARKS2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtREMARKS2h.Text;
                //else if (lblAvtar2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtAvtar2h.Text;
                //else if (lblCompId2h.ID == item.LabelID)
                //    ds.Tables[0].Rows[i]["LabelName"] = txtCompId2h.Text;
                else if (lblTill_DT2h.ID == item.LabelID)
                    ds.Tables[0].Rows[i]["LabelName"] = txtTill_DT2h.Text;
                else
                    ds.Tables[0].Rows[i]["LabelName"] = txtHeader.Text;
            }
            ds.WriteXml(Server.MapPath("\\ACM\\xml\\ERP_WEB_USER_MST.xml"));

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
            //  navigation.Visible = false;
            // drpUSER_DETAIL_ID.Enabled = true;
            drpLoctionId.Enabled = true;
            drpTenentID.Enabled = true;
            txtFIRST_NAME.Enabled = true;
            txtLAST_NAME.Enabled = true;
            txtFIRST_NAME1.Enabled = true;
            txtLAST_NAME1.Enabled = true;
            txtFIRST_NAME2.Enabled = true;
            txtLAST_NAME2.Enabled = true;
            //txtCOUNTRY_CODE.Enabled = true;
            //txtTITLE.Enabled = true;
            txtHOUSE_NO.Enabled = true;
            txtSTREET.Enabled = true;
            txtADDRESS1.Enabled = true;
            txtADDRESS2.Enabled = true;
            txtCITY.Enabled = true;
            drpCOUNTRY.Enabled = true;
            drpSTATE.Enabled = true;
            txtZIP.Enabled = true;
            txtPH_NO.Enabled = true;
            txtFAX_NO.Enabled = true;
            //  drpFROM_REG_DT.Enabled = true;
            //txtVILLAGE_TOWN_CITY.Enabled = true;
            //txtTEHSIL.Enabled = true;
            txtPINCODE_NO.Enabled = true;
            txtPOST_OFFICE.Enabled = true;
            txtPAN_NO.Enabled = true;
            txtEMAIL_ADDRESS.Enabled = true;
            txtMOBILE_NUM.Enabled = true;
            //drpSEC_QUES.Enabled = true;
            //txtSEC_ANS.Enabled = true;
            txtLOGIN_ID.Enabled = true;
            txtPASSWORD.Enabled = true;
            drpUSER_TYPE.Enabled = true;
            txtREMARKS.Enabled = true;
            //txtAvtar.Enabled = true;
            //drpCompId.Enabled = true;
            txtTill_DT.Enabled = true;
            CHKActiveUser.Enabled = true;
            txtuserdate.Enabled = true;
            DrpDefaulrLang.Enabled = true;
            // txtCRUP_ID.Enabled = true;

        }
        public void Readonly()
        {
            // navigation.Visible = true;
            //   drpUSER_DETAIL_ID.Enabled = false;
            //drpLoctionId.Enabled = false;
            //drpTenentID.Enabled = false;
            txtFIRST_NAME.Enabled = false;
            txtLAST_NAME.Enabled = false;
            txtFIRST_NAME1.Enabled = false;
            txtLAST_NAME1.Enabled = false;
            txtFIRST_NAME2.Enabled = false;
            txtLAST_NAME2.Enabled = false;
            //txtCOUNTRY_CODE.Enabled = false;
            //txtTITLE.Enabled = false;
            txtHOUSE_NO.Enabled = false;
            txtSTREET.Enabled = false;
            txtADDRESS1.Enabled = false;
            txtADDRESS2.Enabled = false;
            txtCITY.Enabled = false;
            drpCOUNTRY.Enabled = false;
            drpSTATE.Enabled = false;
            txtZIP.Enabled = false;
            txtPH_NO.Enabled = false;
            txtFAX_NO.Enabled = false;
            //  txtFROM_REG_DT.Enabled = false;
            //txtVILLAGE_TOWN_CITY.Enabled = false;
            //txtTEHSIL.Enabled = false;
            txtPINCODE_NO.Enabled = false;
            txtPOST_OFFICE.Enabled = false;
            txtPAN_NO.Enabled = false;
            txtEMAIL_ADDRESS.Enabled = false;
            txtMOBILE_NUM.Enabled = false;
            //drpSEC_QUES.Enabled = false;
            //txtSEC_ANS.Enabled = false;
            txtLOGIN_ID.Enabled = false;
            txtPASSWORD.Enabled = false;
            drpUSER_TYPE.Enabled = false;
            txtREMARKS.Enabled = false;
            //txtAvtar.Enabled = false;
            //drpCompId.Enabled = false;
            txtTill_DT.Enabled = false;
            // txtCRUP_ID.Enabled = false;
            CHKActiveUser.Enabled = false;
            txtuserdate.Enabled = false;
            DrpDefaulrLang.Enabled = false;

        }

        #region Listview
        //protected void btnNext1_Click(object sender, EventArgs e)
        //{

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.USER_MST.Count();
        //    if (ViewState["Take"] == null && ViewState["Skip"] == null)
        //    {
        //        ViewState["Take"] = Showdata;
        //        ViewState["Skip"] = 0;
        //    }
        //    take = Convert.ToInt32(ViewState["Take"]);
        //    take = take + Showdata;
        //    Skip = take - Showdata;

        //    ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(take).Skip(Skip)).ToList());
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

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //    {
        //        int Totalrec = DB.USER_MST.Count();
        //        Skip = Convert.ToInt32(ViewState["Skip"]);
        //        take = Skip;
        //        Skip = take - Showdata;
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(take).Skip(Skip)).ToList());
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

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //    {
        //        int Totalrec = DB.USER_MST.Count();
        //        take = Showdata;
        //        Skip = 0;
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(take).Skip(Skip)).ToList());
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

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.USER_MST.Count();
        //    take = Totalrec;
        //    Skip = Totalrec - Showdata;
        //    ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(take).Skip(Skip)).ToList());
        //    ViewState["Take"] = take;
        //    ViewState["Skip"] = Skip;
        //    btnNext1.Enabled = false;
        //    btnPrevious1.Enabled = true;
        //    ChoiceID = take / Showdata;
        //    ((ACMMaster)Page.Master).GetCurrentNavigationLast(ChoiceID, Showdata, ListView2, Totalrec);
        //    lblShowinfEntry.Text = "Showing " + ViewState["Skip"].ToString() + " to " + ViewState["Take"].ToString() + " of " + Totalrec + " entries";
        //}
        //protected void btnlistreload_Click(object sender, EventArgs e)
        //{
        //    BindData();
        //}
        protected void btnPagereload_Click(object sender, EventArgs e)
        {
            Readonly();
            ManageLang();
            pnlSuccessMsg.Visible = false;
            //FillContractorID();
            int CurrentID = 1;
            if (ViewState["Es"] != null)
                CurrentID = Convert.ToInt32(ViewState["Es"]);
            BindData();
            //  FirstData();
        }


        protected void Listview1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            drpUSER_TYPE.DataSource = ClsActivities.getAllRole(TIDSession);
            drpUSER_TYPE.DataTextField = "RoleName";
            drpUSER_TYPE.DataValueField = "RoleID";
            drpUSER_TYPE.DataBind();
           // using (TransactionScope scope = new TransactionScope())
          //  {
                //try
                //{
                int TID = Convert.ToInt32(Session["TID"]);
                Classes.EcommAdminClass.getdropdown(drpLoctionId, TIDSession, "", "", "", "TBLLOCATION");
          
                if (e.CommandName == "btnDelete")
                {

                    //string[] ID = e.CommandArgument.ToString().Split(',');
                    int str1 = Convert.ToInt32(e.CommandArgument);
                    // string str2 = ID[1].ToString();

                    Database.USER_MST objSOJobDesc = DB.USER_MST.Single(p => p.USER_ID == str1);
                    objSOJobDesc.ACTIVE_FLAG = "N";
                    objSOJobDesc.LoginActive = 0;
                    DB.SaveChanges();
                   // Classes.Toastr.ShowToast(Page, Classes.Toastr.ToastType.Success, "Data Deleted Successfully", "Success!", Classes.Toastr.ToastPosition.TopCenter);
                    BindData();
                    int Tvalue = Convert.ToInt32(ViewState["Take"]);
                    int Svalue = Convert.ToInt32(ViewState["Skip"]);
                   // ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(Tvalue).Skip(Svalue)).ToList());

                }

                if (e.CommandName == "btnChangepass")
                {
                    TextBox txtpass = (TextBox)e.Item.FindControl("txtpass");
                    TextBox txtconpass = (TextBox)e.Item.FindControl("txtconpass");
                    Panel penalmsg = (Panel)e.Item.FindControl("penalmsg");
                    Label lblmsg = (Label)e.Item.FindControl("lblmsg");
                    penalmsg.Visible = false;
                    lblmsg.Text = "";

                    if (txtpass.Text == txtconpass.Text)
                    {
                        string pass = Classes.GlobleClass.EncryptionHelpers.Encrypt(txtpass.Text);
                        int str1 = Convert.ToInt32(e.CommandArgument);
                        Database.USER_MST objUSER_MST = DB.USER_MST.Single(p => p.USER_ID == str1);
                        objUSER_MST.PASSWORD = pass;
                        DB.SaveChanges();
                    }
                    else
                    {
                        penalmsg.Visible = false;
                        lblmsg.Text = "Enter Confirm Password same as password";
                        return;
                    }

                }

                if (e.CommandName == "btnEdit")
                {

                  
                   
                    int str1 = Convert.ToInt32(e.CommandArgument);
                    if (DB.USER_MST.Where(p => p.USER_ID == str1 && p.TenentID == TID).Count() > 0)
                    {
                        int USERDIID = Convert.ToInt32(DB.USER_MST.Single(p => p.USER_ID == str1 && p.TenentID == TID).USER_DETAIL_ID);
                        if (DB.USER_DTL.Where(p => p.USER_DETAIL_ID == USERDIID && p.TenentID == TID).Count() > 0)
                        {
                            Database.USER_DTL objUSER_DTL = DB.USER_DTL.Single(p => p.USER_DETAIL_ID == USERDIID && p.TenentID == TID);
                            if (objUSER_DTL.COUNTRY_CODE == null || objUSER_DTL.COUNTRY_CODE == "")
                                //    txtCOUNTRY_CODE.Text = objUSER_DTL.COUNTRY_CODE;
                                //txtTITLE.Text = objUSER_DTL.TITLE;
                                txtHOUSE_NO.Text = objUSER_DTL.HOUSE_NO;
                            txtSTREET.Text = objUSER_DTL.STREET;
                            txtADDRESS1.Text = objUSER_DTL.ADDRESS1;
                            txtADDRESS2.Text = objUSER_DTL.ADDRESS2;
                            txtCITY.Text = objUSER_DTL.CITY;
                            drpLocation.SelectedValue =  objUSER_DTL.LOCATION_ID.ToString();
                            drpCOUNTRY.SelectedValue = objUSER_DTL.COUNTRY.ToString();
                            int CID = Convert.ToInt32(drpCOUNTRY.SelectedValue);
                            //bindsate(CID);
                            drpSTATE.DataSource = DB.tblStates.Where(p => p.ACTIVE1 == "Y" && p.COUNTRYID == CID);
                            drpSTATE.DataTextField = "MYNAME1";
                            drpSTATE.DataValueField = "StateID";
                            drpSTATE.DataBind();
                            drpSTATE.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select STATE--", "0"));
                            drpSTATE.SelectedValue = objUSER_DTL.STATE;
                            txtZIP.Text = objUSER_DTL.ZIP;
                            txtPH_NO.Text = objUSER_DTL.PH_NO;
                            txtFAX_NO.Text = objUSER_DTL.FAX_NO;
                            //txtVILLAGE_TOWN_CITY.Text = objUSER_DTL.VILLAGE_TOWN_CITY;
                            //txtTEHSIL.Text = objUSER_DTL.TEHSIL;
                            txtPINCODE_NO.Text = objUSER_DTL.PINCODE_NO;
                            txtPOST_OFFICE.Text = objUSER_DTL.POST_OFFICE;
                            txtPAN_NO.Text = objUSER_DTL.PAN_NO;
                            txtEMAIL_ADDRESS.Text = objUSER_DTL.EMAIL_ADDRESS;
                            txtMOBILE_NUM.Text = objUSER_DTL.MOBILE_NUM.ToString();
                            //drpSEC_QUES.SelectedValue = objUSER_DTL.SEC_QUES;
                            //txtSEC_ANS.Text = objUSER_DTL.SEC_ANS;
                        }
                    }
                     TID = Convert.ToInt32(Session["TID"]);
                    Database.USER_MST objUSER_MST = DB.USER_MST.Single(p => p.USER_ID == str1 && p.TenentID == TIDSession);
                    drpTenentID.SelectedValue = objUSER_MST.TenentID.ToString();
                    drpLoctionId.SelectedValue = objUSER_MST.LOCATION_ID.ToString();
                    //   drpUSER_DETAIL_ID.SelectedValue = objUSER_MST.USER_DETAIL_ID.ToString();
                    txtFIRST_NAME.Text = objUSER_MST.FIRST_NAME.ToString();
                    txtLAST_NAME.Text = objUSER_MST.LAST_NAME.ToString();
                    txtFIRST_NAME1.Text = objUSER_MST.FIRST_NAME1.ToString();
                    txtLAST_NAME1.Text = objUSER_MST.LAST_NAME1.ToString();
                    txtFIRST_NAME2.Text = objUSER_MST.FIRST_NAME2.ToString();
                    txtLAST_NAME2.Text = objUSER_MST.LAST_NAME2.ToString();
                    txtLOGIN_ID.Text = objUSER_MST.LOGIN_ID.ToString();
                    string PASSWORD = Classes.GlobleClass.EncryptionHelpers.Decrypt(objUSER_MST.PASSWORD).ToString();
                    txtPASSWORD.Text = PASSWORD;
                    drpUSER_TYPE.SelectedValue = objUSER_MST.USER_TYPE.ToString();
                    txtREMARKS.Text = objUSER_MST.REMARKS.ToString();
                    if (objUSER_MST.EmailAddress != null && objUSER_MST.EmailAddress != "")
                    {
                        txtEMAIL_ADDRESS.Text = objUSER_MST.EmailAddress.ToString();
                    }

                    CHKActiveUser.Checked = objUSER_MST.ACTIVEUSER == true ? true : false;
                    txtuserdate.Text = Convert.ToDateTime(objUSER_MST.USERDATE).ToShortDateString();
                    txtTill_DT.Text = Convert.ToDateTime(objUSER_MST.Till_DT).ToShortDateString();
                    //drpCompId.SelectedValue = objUSER_MST.CompId.ToString();
                    if (objUSER_MST.Language1 != null)
                        DrpDefaulrLang.SelectedValue = objUSER_MST.Language1.ToString();
                    //if (objUSER_MST.Avtar == null || objUSER_MST.Avtar == "")
                    //txtAvtar.Text = objUSER_MST.Avtar.ToString();
                    //if (objUSER_MST.CompId == null || objUSER_MST.CompId == 0)

                    //  txtCRUP_ID.Text = objUSER_MST.CRUP_ID.ToString();

                    btnAdd.Text = "Update";
                    ViewState["Edit"] = str1;
                    Write();
                    btnAdd.Visible = true;
                }
              //  scope.Complete(); //  To commit.
                //}
                //catch (Exception ex)
                //{
                //    ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", ex.Message, true);
                //    throw;
                //}
           // }
        }

        //protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{

        //    int Showdata = Convert.ToInt32(drpShowGrid.SelectedValue);
        //    int Totalrec = DB.USER_MST.Count();
        //    if (e.CommandName == "LinkPageavigation")
        //    {
        //        int ID = Convert.ToInt32(e.CommandArgument);
        //        ViewState["Take"] = ID * Showdata;
        //        ViewState["Skip"] = (ID * Showdata) - Showdata;
        //        int Tvalue = Convert.ToInt32(ViewState["Take"]);
        //        int Svalue = Convert.ToInt32(ViewState["Skip"]);
        //        ((ACMMaster)Page.Master).BindList(Listview1, (DB.USER_MST.OrderBy(m => m.USER_ID).Take(Tvalue).Skip(Svalue)).ToList());
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

        protected void drpCOUNTRY_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CID = Convert.ToInt32(drpCOUNTRY.SelectedValue);
            bindsate(CID);
        }
        public void bindsate(int CID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            string ContID = CID.ToString();

            Classes.EcommAdminClass.getdropdown(drpSTATE, TID, ContID, "", "", "tblStates");
            //select * from tblStates where  ACTIVE='Y'

            //drpSTATE.DataSource = DB.tblStates.Where(p => p.ACTIVE == "Y" && p.TenantID == TID && p.COUNTRYID == CID);
            //drpSTATE.DataTextField = "MYNAME1";
            //drpSTATE.DataValueField = "StateID";
            //drpSTATE.DataBind();
            //drpSTATE.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select STATE--", "0"));
        }
        public string getcity(int CID)
        {
            if (CID == 0 || CID == null)
            {
                return "";
            }
            else
            {
                int tid = Convert.ToInt32(Session["TID"]);
                int lid = 1;

                
                    lid = 1;
               


                if (DB.USER_DTL.Where(p => p.USER_DETAIL_ID == CID).Count() > 0)
                {
                    //return DB.USER_DTL.SingleOrDefault(p => p.USER_DETAIL_ID == CID).CITY;
                    // return DB.USER_DTL.GroupBy(p => p.USER_DETAIL_ID).Select(p => p.FirstOrDefault().CITY).ToString();
                    if (DB.USER_DTL.Where(p => p.USER_DETAIL_ID == CID && p.TenentID == tid && p.LOCATION_ID == lid).Count() > 0)
                    {
                        return DB.USER_DTL.Single(p => p.USER_DETAIL_ID == CID && p.TenentID == tid && p.LOCATION_ID == lid).CITY;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }

        }

        public string getPhonnumber(int PID)
        {
            if (PID == 0 || PID == null)
            {
                return "";
            }
            else
            {
                int tid = Convert.ToInt32(Session["TID"]);
                int lid = 1;
               
                   
                    lid = 1;
              
                if (DB.USER_DTL.Where(p => p.USER_DETAIL_ID == PID && p.TenentID == tid && p.LOCATION_ID == lid).Count() > 0)
                {
                    //return DB.USER_DTL.SingleOrDefault(p => p.USER_DETAIL_ID == PID).PH_NO;
                    //return DB.USER_DTL.GroupBy(p => p.USER_DETAIL_ID).Select(p => p.FirstOrDefault().PH_NO).ToString();
                    return DB.USER_DTL.Single(p => p.USER_DETAIL_ID == PID && p.TenentID == tid && p.LOCATION_ID == lid).PAN_NO;
                }
                else
                {
                    return "";
                }
            }

        }

        public string getUserType(int UTID)
        {
            if (UTID == 0 || UTID == null)
            {
                return "0";
            }
            else
            {
                TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int tid = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int lid = 1;
                
                   
                    lid = 1;
               
                if (DB.ROLE_MST.Where(p => p.ROLE_ID == UTID && p.TenentID == tid).Count() > 0)
                {
                    return DB.ROLE_MST.SingleOrDefault(p => p.ROLE_ID == UTID && p.TenentID == tid).ROLE_NAME;
                    //return DB.ROLE_MST.GroupBy(p => p.ROLE_ID).Select(p => p.SingleOrDefault().ROLE_NAME).ToString();
                    //return DB.USER_MST.Single(p => p.USER_TYPE == UTID && p.TenentID == tid && p.LOCATION_ID == lid).USER_TYPE.ToString();
                }
                else
                {
                    return "0";
                }
            }
        }

        protected void drpTenentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(drpTenentID.SelectedValue);

            Classes.EcommAdminClass.getdropdown(drpLoctionId, TID, "", "", "", "TBLLOCATION");
            int LID = Convert.ToInt32(drpLoctionId.SelectedValue);
            //select * from TBLLOCATION where Active='Y'

            //drpLoctionId.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenantID == TID);
            //drpLoctionId.DataTextField = "LOCNAME1";
            //drpLoctionId.DataValueField = "LOCATIONID";
            //drpLoctionId.DataBind();
            //drpLoctionId.Items.Insert(0, new ListItem("---Select Location---", "0"));

            // Classes.EcommAdminClass.getdropdown(drpUSER_TYPE, TID, "", "", "", "ROLE_MST");
            //select * from ROLE_MST where ACTIVE_FLAG ='Y'


         


        }

        protected void drpLoctionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGO.Enabled = true;
            //FillContractorID();
        }

        protected void btnGO_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(Session["TID"]);
            int lid = 1;
            USerListBind(tid, lid);
        }
        public void USerListBind(int Tenent, int Location)
        {

            // List<Database.USER_MST> List = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == Tenent && p.LOCATION_ID == Location).OrderBy(m => m.USER_ID).ToList();
            DataTable UserDt = DAL.Get_User_Detail(Tenent, UID);
            Listview1.DataSource = UserDt;
            Listview1.DataBind();
        }
    }
}