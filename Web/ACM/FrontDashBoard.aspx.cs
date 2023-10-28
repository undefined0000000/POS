using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using Web.CRM;
using Classes;
using AjaxControlToolkit;
namespace Web.ACM
{
    public partial class FrontDashBoard : System.Web.UI.Page
    {
        Database.CallEntities DB = new Database.CallEntities();
        //Database.CallEntities DBACMENTITY = new Database.CallEntities();
        //Database.ERPEntities DB1 = new Database.ERPEntities();
        string TypeName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getStatusAll();
                FillContractorID();
                //  Clear();
            }
        }
        public void BindData(int LocaID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (ViewState["TenentID"] != null)
            {
                //   string REFType = ViewState["REFTYPE"].ToString();
                int TeID = Convert.ToInt32(ViewState["TenentID"]);
                int LocID = Convert.ToInt32(LocaID);
                drpComid.DataSource = DB.TBLCOMPANYSETUPs.Where(P => P.TenentID == TeID).OrderBy(a => a.COMPNAME);
                drpComid.DataTextField = "COMPNAME";
                drpComid.DataValueField = "CompID";
                drpComid.DataBind();
                drpComid.Items.Insert(0, new ListItem("-- Select --", "0"));



                drpActivitycode.DataSource = DB.CRMMainActivities.Where(P => P.TenentID == TeID && P.ACTIVITYE == "Ticket");
                drpActivitycode.DataTextField = "Reference";
                drpActivitycode.DataValueField = "Reference";
                drpActivitycode.DataBind();
                drpActivitycode.Items.Insert(0, new ListItem("-- Select --", "0"));

                //drpActivitytype.DataSource = DB.CRMMainActivities.Where(P => P.ACTIVITYE == "Ticket" && P.TenentID == TeID);
                //drpActivitytype.DataTextField = "Reference";
                //drpActivitytype.DataValueField = "ACTIVITYCODE";
                //drpActivitytype.DataBind();
                //drpActivitytype.Items.Insert(0, new ListItem("-- Select --", "0"));


                Classes.EcommAdminClass.getdropdown(drpStatus, TeID, "ACTVTY", "STATUS", "", "REFTABLEs");
                //select * from REFTABLE where REFTYPE='ACTVTY' and REFSUBTYPE = 'STATUS' 

                //drpStatus.DataSource = DB.REFTABLEs.Where(p => p.TenentID == TeID && p.REFTYPE == "ACTVTY" && p.REFSUBTYPE == "STATUS");
                //drpStatus.DataTextField = "REFNAME1";
                //drpStatus.DataValueField = "REFID";
                //drpStatus.DataBind();
                //drpStatus.Items.Insert(0, new ListItem("-- Select --", "0"));

                Classes.EcommAdminClass.getdropdown(drpReftype, TeID, "0", "", "", "MODULE_MST");
                //select * from MODULE_MST where Parent_Module_id =0 

                //drpReftype.DataSource = DB.MODULE_MST.Where(p => p.TenentID == TeID);
                //drpReftype.DataTextField = "Module_Name";
                //drpReftype.DataValueField = "Module_Id";
                //drpReftype.DataBind();
                //drpReftype.Items.Insert(0, new ListItem("-- Select --", "0"));

                //DrpModuleName.Items.Clear();
                //DrpModuleName.DataSource = DB1.MODULE_MST.Where(p => p.TenentID == TeID);
                //DrpModuleName.DataTextField = "Module_Name";
                //DrpModuleName.DataValueField = "Module_Id";
                //DrpModuleName.DataBind();
                //DrpModuleName.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        public void FillContractorID()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            var Datas = (from fun1 in DB.TBLLOCATIONs
                         select new
                         {
                             fun1.TenentID,

                         }
    ).Distinct();
            DrpTenent_ID.DataSource = Datas;
            DrpTenent_ID.DataTextField = "TenentID";
            DrpTenent_ID.DataValueField = "TenentID";
            DrpTenent_ID.DataBind();
            DrpTenent_ID.Items.Insert(0, new ListItem("---Select---", "---Select---"));

            if (TID != 0)
            {
                DrpTenent_ID.SelectedValue = TID.ToString();
                DrpTenent_ID.Enabled = false;
                ViewState["TenentID"] = TID;
                string LID = ((USER_MST)Session["USER"]).LOCATION_ID.ToString();
                int ROLLID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                int Locationid = Convert.ToInt32(LID);
                Classes.EcommAdminClass.getdropdown(Drp_Location, TID, LID, "", "", "TBLLOCATION");
                Drp_Location.SelectedValue = LID;
                Drp_Location.Enabled = false;
                drpReftype.Enabled = true;


                var List = DB.View_Moduel_map.Where(p => p.TenentID == TID && p.LOCATION_ID == Locationid && p.USER_ID == UID).ToList();
                Classes.EcommAdminClass.getdropdown(drpReftype, TID, "0", "", "", "MODULE_MST");
                //select * from TBLLOCATION where TenentID=1

                drpReftype.DataSource = List;
                drpReftype.DataTextField = "Module_Name";
                drpReftype.DataValueField = "MODULE_ID";
                drpReftype.DataBind();
                drpReftype.Items.Insert(0, new ListItem("---Select Ref Type---", "0"));
                //   Drp_Location.Enabled = true;

            }
            //drpRefsubtype.Items.Insert(0, new ListItem("-- Select --", "0"));

            // DrpModuleName.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(drpReftype.SelectedValue) != 0)
            {
                string AID = (drpReftype.SelectedItem.Text).ToString();
                int Modual = Convert.ToInt32(drpReftype.SelectedValue);
                string RefSubID = (drpRefsubtype.SelectedItem.Text);
                int TeID = Convert.ToInt32(ViewState["TenentID"]);
                //Database.CRMMainActivity obj_MainActivity = DB.CRMMainActivities.SingleOrDefault(p => p.ACTIVITYA == RefSubID);
                int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                //obj_MainActivity.ACTIVITYA = txtActivityPerform.Text;
                //obj_MainActivity.UPDTTIME = DateTime.Now;
                //obj_MainActivity.GROUPCODE = 
                // string Type = obj_MainActivity.REFTYPE;
                Label3.Text = RefSubID;
                string UID1 = UID.ToString();

                //Database.CRMMainActivity OBJMainAct = DB.CRMMainActivities.Single(p => p.TenentID == TeID && p.ACTIVITYE == RefSubID && p.ModuleID == Modual && p.Active == true);

                //List<Database.TBLGROUP_USER> listGroup = DB.TBLGROUP_USER.Where(p => p.TenentID == TeID && p.ITGROUPID == OBJMainAct.GROUPCODE && p.USERCODE == UID1 && p.ACTIVE == "1").ToList();
                //if (listGroup.Count()>0)
                //{
                listserch.DataSource = DB.CRMMainActivities.Where(p => p.ACTIVITYE == RefSubID && p.TenentID == TeID && p.ModuleID == Modual && p.Active == true);//&&p.USERCODE==UID;
                listserch.DataBind();
                Crmlist.Visible = false;
                //}

            }
        }

        protected void listserch_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "LinkChangeStatus")
            {
                int AC = Convert.ToInt32(e.CommandArgument);
                ViewState["ActivityID"] = AC;
                ModalPopupExtender2.Show();

            }
        }

        protected void LinkButtonStatusSave_Click(object sender, EventArgs e)
        {
            if (ViewState["ActivityID"] != null)
            {
                int ActiID = Convert.ToInt32(ViewState["ActivityID"]);
                //k//Database.CRMActivity obj_Activity = DB.CRMActivities.SingleOrDefault(p => p.ID == ActiID && p.TenentID == 362);
                if (Convert.ToInt32(drpStatus.SelectedValue) != 0)
                {
                    //k//obj_Activity.MyStatus = drpStatus.SelectedItem.Text;
                }
                DB.SaveChanges();
            }
        }


        protected void DrpCRM_MainActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Label3

            //if (Convert.ToInt32(DrpCRM_MainActivity.SelectedValue) != 0)
            //{
            //    int ActivityCode = Convert.ToInt32(DrpCRM_MainActivity.SelectedValue);

            //}
        }

        protected void btnCancelACTIVITY_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveACTIVITY_Click1(object sender, EventArgs e)
        {
            //using (var scope = new System.Transactions.TransactionScope())
            //{
            //    try
            //    {
            string UID = (((USER_MST)Session["USER"]).LOGIN_ID);
            int TID = Convert.ToInt32(ViewState["TenentID"]); //Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (ViewState["Edit"] != null)
            {
                string[] str = txtInitialDate.Text.Split('/');
                string[] str1 = txtDeadLineDate.Text.Split('/');
                int postMonth = Convert.ToInt32(str[0]);
                int postday = Convert.ToInt32(str[1]);
                int postYear = Convert.ToInt32(str[2]);
                DateTime Fdate = Convert.ToDateTime(postMonth + "/" + postday + "/" + postYear);
                int postMonth1 = Convert.ToInt32(str1[0]);
                int postday1 = Convert.ToInt32(str1[1]);
                int postYear1 = Convert.ToInt32(str1[2]);
                DateTime Tdate = Convert.ToDateTime(postMonth1 + "/" + postday1 + "/" + postYear1);
                if (Tdate.Date < Fdate.Date)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Deadline Date should be grater than From date');", true);
                    return;
                }
                if (Fdate.Date < DateTime.Now.Date)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Initial Date should be Less than Today date');", true);
                    return;
                }
                if (Tdate.Date < DateTime.Now.Date)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('Deadline Date should be Less than Today date');", true);
                    return;
                }
                int ID = Convert.ToInt32(ViewState["Edit"]);
                Database.CRMActivity objtbl_CRMActivities = DB.CRMActivities.Single(p => p.MyLineNo == ID && p.TenentID == TID);
                objtbl_CRMActivities.COMPID = Convert.ToInt32(drpComid.SelectedValue);
                //k//objtbl_CRMActivities.ACTIVITYCODE = Convert.ToInt32(drpActivitycode.SelectedValue);
                objtbl_CRMActivities.ACTIVITYTYPE = drpReftype.SelectedItem.Text;
                objtbl_CRMActivities.REFTYPE = drpReftype.SelectedValue;
                objtbl_CRMActivities.REFSUBTYPE = drpRefsubtype.SelectedValue;
                objtbl_CRMActivities.MyLineNo = Convert.ToInt32(txtMylineno.Text);
                //k//objtbl_CRMActivities.USERCODE = txtUSERCODE.Text;
                //k//objtbl_CRMActivities.ReferenceNo = txtReferenceNo.Text;
                objtbl_CRMActivities.EarlierRefNo = txtEarlierRefNo.Text;
                objtbl_CRMActivities.NextUser = txtNextUser.Text;
                objtbl_CRMActivities.NextRefNo = txtNextRefNo.Text;
                objtbl_CRMActivities.AMIGLOBAL = ckbAmiglobal.Checked ? "Y" : "N";
                objtbl_CRMActivities.MYPERSONNEL = ckbMypersonnel.Checked ? "Y" : "N";
                objtbl_CRMActivities.ActivityPerform = txtActivityPerform.Text;
                objtbl_CRMActivities.REMINDERNOTE = txtREMINDERNOTE.Text;
                objtbl_CRMActivities.ESTCOST = Convert.ToInt32(txtESTCOST.Text);
                objtbl_CRMActivities.GROUPCODE = txtGROUPCODE.Text;
                objtbl_CRMActivities.USERCODEENTERED = txtUSERCODEENTERED.Text;
                objtbl_CRMActivities.UPDTTIME = Convert.ToDateTime(txtUPDTTIME.Text);
                objtbl_CRMActivities.USERNAME = txtUSERNAME.Text;
                objtbl_CRMActivities.InitialDate = Convert.ToDateTime(txtInitialDate.Text);
                objtbl_CRMActivities.DeadLineDate = Convert.ToDateTime(txtDeadLineDate.Text);
                ViewState["Edit"] = null;
                DB.SaveChanges();

                // btnAdd.Text = "Add New";
                //       ((DMSMaster)Page.Master).UpdateLog("From CRM Activities for CRMActivity,ID:" + objtbl_CRMActivities.MyLineNo.ToString() + objtbl_CRMActivities.ReferenceNo.ToString() + objtbl_CRMActivities.RouteID.ToString(), Convert.ToInt32(objtbl_CRMActivities.CRUP_ID), "CRMActivity", UID);
            }
            else
            {
                //string strUName = ((USER_MST)Session["USER"]).FIRST_NAME;
                string strUName = (((USER_MST)Session["USER"]).LOGIN_ID);
                //k//int ActivityCode = DB.CRMMainActivities.Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Max(p => p.ACTIVITYCODE) + 1) : 1;
                // int REFID = DBACMENTITY.REFTABLE.Count() > 0 ? Convert.ToInt32(DBACMENTITY.REFTABLE.Max(p => p.ActivityID) + 1) : 1;
                //k//string REFNO = "TICKET_" + ActivityCode + "_" + ActivityCode;
                //  string Type1 = Session["PageType"].ToString();
                int RoleID = 0;
                int RID = 0;
                int CID = 1;
                //int UDI1 = Convert.ToInt32(((ERP_WEB_USER_MST)Session["USER"]).USER_ID); ;
                string AAType1 = "";
                string Type1 = "";
                int LocationID = 0;
                int TenenatID = 0;
                int ModuleID = 0;
                if (Convert.ToInt32(drpRefsubtype.SelectedValue) != 0)
                {
                    AAType1 = Convert.ToString(drpRefsubtype.SelectedItem.Text);
                }
                if (Convert.ToInt32(drpReftype.SelectedValue) != 0)
                {
                    Type1 = Convert.ToString(drpReftype.SelectedItem.Text);
                    ModuleID = Convert.ToInt32(drpReftype.SelectedValue);
                }
                if (Convert.ToInt32(DrpTenent_ID.SelectedValue) != 0)
                {
                    TenenatID = Convert.ToInt32(DrpTenent_ID.SelectedValue);
                }
                if (Convert.ToInt32(Drp_Location.SelectedValue) != 0)
                {
                    LocationID = Convert.ToInt32(Drp_Location.SelectedValue);
                }
                if (Convert.ToInt32(drpComid.SelectedValue) != 0)
                {
                    CID = Convert.ToInt32(drpComid.SelectedValue);
                }
                int AType = Convert.ToInt32(ActionMaster.ActionType.Ticket);
                RoleID = DB.CRMMainActivities.Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Max(p => p.MyID) + 1) : 1;
                Database.CRMMainActivity objCRMMainActivities = new Database.CRMMainActivity();
                objCRMMainActivities.MyID = RID;
                objCRMMainActivities.TenentID = TenenatID;
                objCRMMainActivities.COMPID = CID;
                objCRMMainActivities.Prefix = "ONL";
                //k//objCRMMainActivities.ACTIVITYCODE = ActivityCode;
                objCRMMainActivities.RouteID = DB.CRMMainActivities.Where(p => p.MyID == RID).Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Where(p => p.MyID == RID).Max(p => p.RouteID) + 1) : 1;
                //k//objCRMMainActivities.REFTYPE = Type1;
                //k//objCRMMainActivities.REFSUBTYPE = AAType1;
                //k//objCRMMainActivities.ACTIVITYTYPE = ModuleID;
                //  objCRMMainActivities.USERCODE = strUName;
                objCRMMainActivities.ACTIVITYE = AAType1;//ACTIVITYA
                //objCRMMainActivities.USERCODE = UDI1;
                //k//objCRMMainActivities.Reference = REFNO;
                //   objCRMMainActivities.AMIGLOBAL = "Y";
                //    objCRMMainActivities.MYPERSONNEL = "N";
                objCRMMainActivities.INTERVALDAYS = 1;
                //     objCRMMainActivities.REPEATFOREVER = "A";
                objCRMMainActivities.REPEATTILL = DateTime.Now;
                //k//objCRMMainActivities.ESTCOST = DB.CRMMainActivities.Where(p => p.ACTIVITYCODE == RoleID).Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Where(p => p.ACTIVITYCODE == RoleID).Max(p => p.ESTCOST) + 1) : 1;
                //   objCRMMainActivities.GROUPCODE = drpSDepartment.SelectedValue;
                objCRMMainActivities.USERCODEENTERED = "1";//drppriority.SelectedValue;
                objCRMMainActivities.UPDTTIME = DateTime.Now;
                objCRMMainActivities.USERNAME = strUName;
                objCRMMainActivities.Remarks = "";
                objCRMMainActivities.Version = "";
                objCRMMainActivities.MyStatus = "Pending";
                objCRMMainActivities.CRUP_ID = 1;
                objCRMMainActivities.ModuleID = 7;
                objCRMMainActivities.Type = 1;
                objCRMMainActivities.ACTIVITYA = txtActivityPerform.Text;
                // objCRMMainActivities.RouteID = 1;
                //   objCRMMainActivities.GROUPCODE = txtGROUPCODE.Text;
                DB.CRMMainActivities.AddObject(objCRMMainActivities);
                DB.SaveChanges();

                Database.CRMActivity objCRMActivity = new Database.CRMActivity();
                objCRMActivity.COMPID = CID;
                objCRMActivity.TenentID = TenenatID;
                //k//objCRMActivity.ACTIVITYCODE = ActivityCode;
                objCRMActivity.REFTYPE = Type1;
                objCRMActivity.REFSUBTYPE = ActionMaster.ActionType.Ticket.ToString();
                objCRMActivity.ACTIVITYTYPE = "CRM";
                objCRMActivity.Prefix = "ONL";
                // objCRMActivity.acti = "CRM";
                objCRMActivity.MyLineNo = objCRMMainActivities.MyID; //Insert MainActivityID
                objCRMActivity.GroupBy = "Tikit";
                //k//objCRMActivity.USERCODE = strUName;
                //k//objCRMActivity.ReferenceNo = REFNO; //objCRMMainActivities.Reference;
                objCRMActivity.NextRefNo = "N";
                objCRMActivity.AMIGLOBAL = "Y";
                objCRMActivity.MYPERSONNEL = "N";
                objCRMActivity.ActivityPerform = objCRMMainActivities.Remarks;
                objCRMActivity.REMINDERNOTE = objCRMMainActivities.Version;
                objCRMActivity.ESTCOST = Convert.ToInt32(objCRMMainActivities.ESTCOST);
                objCRMActivity.GROUPCODE = "1";
                objCRMActivity.USERCODEENTERED = strUName;
                objCRMActivity.UPDTTIME = DateTime.Now;
                objCRMActivity.USERNAME = strUName;
                objCRMActivity.RouteID = "Ticket";
                objCRMActivity.MyStatus = "Pending";
                objCRMActivity.Active = "Y";
                objCRMActivity.PerfReferenceNo = "";
                objCRMMainActivities.MainID = 7;//Insert Module ID
                objCRMActivity.ToColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.ToColumn) + 1) : 1;
                objCRMActivity.FromColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.FromColumn) + 1) : 1;
                objCRMActivity.Version = strUName + " Reply";
                DB.CRMActivities.AddObject(objCRMActivity);
                DB.SaveChanges();

                //insert data in action master
                // Database.REFTABLE obj_Reference11 = new Database.REFTABLE();
                //obj_Reference11.TenentID = TenenatID;
                //obj_Reference11.Location_ID = LocationID;
                //obj_Reference11.ActivityID = ActivityCode;
                //obj_Reference11.MainActivityType = Type1;
                //obj_Reference11.NameEng = txtActivityPerform.Text;
                //obj_Reference11.SubActivityType = AAType1;
                //obj_Reference11.SHORTNAME = AAType1;
                //obj_Reference11.NameEng = AAType1;
                //obj_Reference11.NameOth2 = AAType1;
                //obj_Reference11.NameOth3 = AAType1;
                //obj_Reference11.CRUP_ID = 1;
                //obj_Reference11.ACTIVE = "Y";
                //obj_Reference11.Parameter4 = ActivityCode;
                //obj_Reference11.Parameter7 = 7;//Insert module ID
                //obj_Reference11.Parameter1 = REFNO;  //Reference NO
                //MenuID=ModuleID
                DateTime date = DateTime.Now;
                //k//ACMClass.InsertDATAACMREFTABLE(TenenatID, LocationID, ModuleID, ActivityCode, Type1, AAType1, AAType1, AAType1, AAType1, AAType1, "", REFNO, "", "", ActivityCode, "", "", 7, 1, 1, 1, "", "Y", 1, "", date);

                //insert data in rights table 
                //Database.ACTIVITYRIGHTS obj_ActiRights = new Database.ACTIVITYRIGHTS();
                //obj_ActiRights.TenentID = TenenatID;
                //obj_ActiRights.LOCATION_ID = LocationID;
                //obj_ActiRights.USER_ID = 0;
                //obj_ActiRights.Activity_ID = ActivityCode;
                //obj_ActiRights.Module_ID = (ModuleID);
                //obj_ActiRights.ADD_FLAG = false;
                //obj_ActiRights.MODIFY_FLAG = false;
                //obj_ActiRights.DELETE_FLAG = false;
                //obj_ActiRights.VIEW_FLAG = false;
                //obj_ActiRights.ALL_FLAG = false;
                //obj_ActiRights.CRUP_ID = 1;
                //DBACMENTITY.ACTIVITYRIGHTS.AddObject(obj_ActiRights);
                //DB.SaveChanges();
                //k//ACMClass.INSERTDATAACESSRIGHTS(TenenatID, LocationID, 0, ActivityCode, ModuleID, false, false, false, false, false, 1);

                //}
                // DB.SaveChanges();
                //scope.Complete(); //  To commit.
                //}
                //catch (Exception ex)
                //{
                //    throw;
                //}
            }
        }

        protected void DrpModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(DrpModuleName.SelectedValue) != 0)
            //{
            //    string REFType = (DrpModuleName.SelectedItem.Text).ToString();// ViewState["REFTYPE"].ToString();
            //    int TeID = Convert.ToInt32(ViewState["TenentID"]);

            //    drpReftype.DataSource = DB.REFTABLE.Where(P => P.REFTYPE == REFType && P.TenentID == TeID).GroupBy(a => a.REFTYPE).Select(grp => grp.FirstOrDefault());
            //    drpReftype.DataTextField = "REFTYPE";
            //    drpReftype.DataValueField = "REFID";
            //    drpReftype.DataBind();
            //    drpReftype.Items.Insert(0, new ListItem("-- Select --", "0"));

            //    var data = (from activity in DB.CRMMainActivities.Where(p => p.TenentID == TeID && p.REFTYPE == REFType)
            //                select new
            //                {
            //                    Name = activity.ACTIVITYA + "-" + activity.Reference,
            //                    ID = activity.ACTIVITYCODE
            //                });
            //    DrpCRM_MainActivity.DataSource = data;
            //    DrpCRM_MainActivity.DataTextField = "Name";
            //    DrpCRM_MainActivity.DataValueField = "ID";
            //    DrpCRM_MainActivity.DataBind();
            //    DrpCRM_MainActivity.Items.Insert(0, new ListItem("-- Select --", "0"));
            //}

        }

        protected void DrpTenent_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpTenent_ID.SelectedValue.ToString() != "---Select---")
            {
                //  ViewState["REFTYPE"] = DrpModuleName.SelectedItem.Text;
                ViewState["TenentID"] = Convert.ToInt32(DrpTenent_ID.SelectedValue);
                int TTID = Convert.ToInt32(DrpTenent_ID.SelectedValue);

                Classes.EcommAdminClass.getdropdown(Drp_Location, TTID, "", "", "", "TBLLOCATION");
                //select * from TBLLOCATION where TenentID=1

                //Drp_Location.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenentID == TTID);
                //Drp_Location.DataTextField = "LOCNAME1";
                //Drp_Location.DataValueField = "LOCATIONID";
                //Drp_Location.DataBind();
                //Drp_Location.Items.Insert(0, new ListItem("---Select Location---", "0"));
                Drp_Location.Enabled = true;
            }
        }

        protected void drpReftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(drpReftype.SelectedValue) != 0)
            {
                string RefType = drpReftype.SelectedItem.Text;
                ViewState["REF"] = drpReftype.SelectedItem.Text;
                if (ViewState["TenentID"] != null && ViewState["REF"] != null)
                {
                    // string REFType = ViewState["REFTYPE"].ToString();
                    int TeID = Convert.ToInt32(ViewState["TenentID"]);
                    string RefType11 = ViewState["REF"].ToString();
                    int ModuleID = Convert.ToInt32(drpReftype.SelectedValue);

                    drpRefsubtype.Items.Clear();
                    drpRefsubtype.DataSource = DB.CRMMainActivities.Where(P => P.TenentID == TeID && P.ModuleID == ModuleID && P.Active == true).GroupBy(a => a.ACTIVITYE).Select(grp => grp.FirstOrDefault());
                    drpRefsubtype.DataTextField = "ACTIVITYE";
                    drpRefsubtype.DataValueField = "MasterCODE";
                    drpRefsubtype.DataBind();
                    drpRefsubtype.Items.Insert(0, new ListItem("-- Select --", "0"));
                    drpRefsubtype.Enabled = true;
                    btnfind.Enabled = true;
                }
            }
            else
            {

            }
        }
        protected void ltsRemainderNotes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "btnclick123")
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    LinkButton linkID = (LinkButton)e.Item.FindControl("btnclick123");
                    Label tikitID = (Label)e.Item.FindControl("tikitID");
                    int Tikitno = Convert.ToInt32(tikitID.Text);
                    ViewState["TIkitNumber"] = Tikitno;
                    panChat.Visible = true;

                    int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                    //string UIN = ((USER_MST)Session["LoginID"]).LOGIN_ID;


                    listChet.DataSource = DB.CRMActivities.Where(p => p.TenentID == TID && p.GroupBy == "Ticket" && p.ESTCOST == Tikitno);
                    listChet.DataBind();

                    ListHistoy.DataSource = DB.CRMActivities.Where(p => p.TenentID == TID && p.GroupBy == "Ticket" && p.ESTCOST == Tikitno);
                    ListHistoy.DataBind();

                }
            }

        }
        public void getCommunicatinData()
        {
            int Tikitno = Convert.ToInt32(ViewState["TIkitNumber"]);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            listChet.DataSource = DB.CRMActivities.Where(p => p.TenentID == TID && p.GroupBy == "Ticket" && p.ESTCOST == Tikitno);
            listChet.DataBind();
            ListHistoy.DataSource = DB.CRMActivities.Where(p => p.TenentID == TID && p.GroupBy == "Ticket" && p.ESTCOST == Tikitno);
            ListHistoy.DataBind();
        }

        public void ClenCat()
        {
            txtComent.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strUName = ((USER_MST)Session["USER"]).FIRST_NAME;
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int RoleID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
            int CID = Convert.ToInt32(((USER_MST)Session["USER"]).CompId);
            int tiki = Convert.ToInt32(ViewState["TIkitNumber"]);
            if (RoleID == 2)
            {
                Database.CRMActivity objCRMActivity = new Database.CRMActivity();
                objCRMActivity.COMPID = CID;
                objCRMActivity.TenentID = TID;
                //k//objCRMActivity.ACTIVITYCODE = tiki;
                objCRMActivity.REFTYPE = "Eco";
                objCRMActivity.REFSUBTYPE = "Reference";
                objCRMActivity.ACTIVITYTYPE = "TKT";
                objCRMActivity.MyLineNo = TID;
                //k//objCRMActivity.USERCODE = strUName;
                //k//objCRMActivity.ReferenceNo = "Anser";
                objCRMActivity.NextRefNo = "N";
                objCRMActivity.GroupBy = "Ticket";
                objCRMActivity.AMIGLOBAL = "Y";
                objCRMActivity.MYPERSONNEL = "N";
                objCRMActivity.ActivityPerform = txtComent.Text;
                objCRMActivity.REMINDERNOTE = txtComent.Text;
                objCRMActivity.ESTCOST = tiki;
                objCRMActivity.GROUPCODE = "1";
                objCRMActivity.USERCODEENTERED = strUName;
                objCRMActivity.UPDTTIME = DateTime.Now;
                objCRMActivity.USERNAME = strUName;
                objCRMActivity.RouteID = "Ticket";
                objCRMActivity.MyStatus = drpStatus.SelectedValue;
                objCRMActivity.Active = "Y";
                objCRMActivity.ToColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.ToColumn) + 1) : 1;
                objCRMActivity.FromColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.FromColumn) + 1) : 1;
                objCRMActivity.Version = "Suppot Reply";
                DB.CRMActivities.AddObject(objCRMActivity);
                DB.SaveChanges();
                //k//Database.CRMMainActivity objCRMMainActivities = DB.CRMMainActivities.Single(p => p.ACTIVITYCODE == tiki);
                //k//objCRMMainActivities.MyStatus = drpStatus.SelectedValue;
                DB.SaveChanges();
                //string Status = drpStatus.SelectedValue;
                getStatusAll();
                getCommunicatinData();
                ClenCat();

            }
            else
            {
                Database.CRMActivity objCRMActivity = new Database.CRMActivity();
                objCRMActivity.COMPID = CID;
                objCRMActivity.TenentID = TID;
                //k//objCRMActivity.ACTIVITYCODE = tiki;
                objCRMActivity.REFTYPE = "Eco";
                objCRMActivity.REFSUBTYPE = "Reference";
                objCRMActivity.ACTIVITYTYPE = "TKT";
                objCRMActivity.MyLineNo = TID;
                //k//objCRMActivity.USERCODE = strUName;
                //k//objCRMActivity.ReferenceNo = "Anser";
                objCRMActivity.NextRefNo = "N";
                objCRMActivity.GroupBy = "Ticket";
                objCRMActivity.AMIGLOBAL = "Y";
                objCRMActivity.MYPERSONNEL = "N";
                objCRMActivity.ActivityPerform = txtComent.Text;
                objCRMActivity.REMINDERNOTE = txtComent.Text;
                objCRMActivity.ESTCOST = tiki;
                objCRMActivity.GROUPCODE = "1";
                objCRMActivity.USERCODEENTERED = strUName;
                objCRMActivity.UPDTTIME = DateTime.Now;
                objCRMActivity.USERNAME = strUName;
                objCRMActivity.RouteID = "Ticket";
                objCRMActivity.MyStatus = "Pending";
                objCRMActivity.Active = "Y";
                objCRMActivity.ToColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.ToColumn) + 1) : 1;
                objCRMActivity.FromColumn = DB.CRMActivities.Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Max(p => p.FromColumn) + 1) : 1;
                objCRMActivity.Version = strUName + " Reply";
                DB.CRMActivities.AddObject(objCRMActivity);
                DB.SaveChanges();
                getCommunicatinData();
                ClenCat();

            }
            Clear();
        }

        public void getStatusAll()
        {
            if (ViewState["TenentID"] != null)
            {
                if (Convert.ToInt32(drpRefsubtype.SelectedValue) != 0)
                {
                    int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                    int TID = Convert.ToInt32(ViewState["TenentID"]);
                    int Code = Convert.ToInt32(drpRefsubtype.SelectedValue); //Convert.ToInt32(DrpCRM_MainActivity.SelectedValue);

                    // int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                    int RoleID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                    string UIN = (((USER_MST)Session["USER"]).LOGIN_ID).ToString();
                    // int RoleID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                    if (RoleID == 2)
                    {
                        //k//ltsRemainderNotes.DataSource = DB.CRMMainActivities.Where(p => p.TenentID == TID && p.ACTIVITYE == "Ticket" && p.ACTIVITYCODE == Code).OrderByDescending(p => p.UPDTTIME);
                        ltsRemainderNotes.DataBind();
                    }
                    else
                    {
                        //k//ltsRemainderNotes.DataSource = DB.CRMMainActivities.Where(p => p.TenentID == TID && p.ACTIVITYE == "Ticket" && p.ACTIVITYCODE == Code).OrderByDescending(p => p.UPDTTIME);
                        ltsRemainderNotes.DataBind();
                    }
                }

            }


        }

        protected void drpRefsubtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  ShowTicket
            if (Convert.ToInt32(drpRefsubtype.SelectedValue) != 0)
            {
                if (drpRefsubtype.SelectedItem.Text == "Ticket")
                {
                    ShowTicket.Visible = true;
                    pnlActivityPerform.Visible = false;
                    pnlAmiGlobal.Visible = false;
                    pnlDeadLineDate.Visible = false;
                    pnlDocumnetName.Visible = false;
                    pnlEarlierRefNo.Visible = false;
                    pnlEstCost.Visible = false;
                    pnlGroupCode.Visible = false;
                    pnlInitialDate.Visible = false;
                    pnlMyPersonnel.Visible = false;
                    pnlNextUser.Visible = false;
                    pnlReferenceNo.Visible = false;
                    pnlReminderNote.Visible = false;
                    pnlUpDtTime.Visible = false;
                    pnlUserCode.Visible = false;
                    pnlUserCodeEntered.Visible = false;
                    pnlUserName.Visible = false;
                    panellineno.Visible = false;
                    TypeName = "Ticket";
                    //if (Convert.ToInt32(DrpCRM_MainActivity.SelectedValue) != 0)
                    //{

                    //    getStatusAll();
                    //}

                }
                else if (drpRefsubtype.SelectedItem.Text == "CAMPAIGN")
                {
                    ChangeLabelForCampaign("Campaign");
                    //TypeName = "Campaign";
                }
                else if (drpRefsubtype.SelectedItem.Text == "LEAD")
                {
                    ChangeLabelForLead("Lead");
                    //TypeName = "Lead";
                }
                else if (drpRefsubtype.SelectedItem.Text == "OPPRTUNITY")
                {
                    ChangeLabelForOppertunity("Oppertunity");
                    // TypeName = "Oppertunity";
                }
                if (Convert.ToInt32(drpRefsubtype.SelectedValue) != 0)
                {
                    Label31.Text = "CRM Activity For " + drpRefsubtype.SelectedItem.Text;
                }
            }
        }


        public void ChangeLabelForCampaign(string Type)
        {
            TypeName = Type;
            ShowTicket.Visible = false;
            pnlActivityPerform.Visible = true;
            pnlAmiGlobal.Visible = true;
            pnlDeadLineDate.Visible = true;
            pnlDocumnetName.Visible = true;
            pnlEarlierRefNo.Visible = true;
            pnlEstCost.Visible = true;
            pnlGroupCode.Visible = true;
            pnlInitialDate.Visible = true;
            pnlMyPersonnel.Visible = true;
            pnlNextUser.Visible = true;
            pnlReferenceNo.Visible = true;
            pnlReminderNote.Visible = true;
            pnlUpDtTime.Visible = true;
            pnlUserCode.Visible = true;
            pnlUserCodeEntered.Visible = true;
            pnlUserName.Visible = true;
            panellineno.Visible = true;



            // Label31.Text = "CRM Activity For" + Type;
            lblActivityPerform.Text = TypeName + " " + "Activity Perform1";
            lblamiglobal.Text = TypeName + " " + "amiglobal1";
            lblDeadLineDate.Text = TypeName + " " + "DeadLine Date1";
            lbldocname.Text = TypeName + " " + "Document Name";
            lblearlierrefno.Text = TypeName + " " + "Earlier Refno";
            lblEstCost.Text = TypeName + " " + "EstCost";
            lblGroupCode.Text = TypeName + " " + "Group Code";
            lblInitialDate.Text = TypeName + " " + "Initial Date";
            lblmylineno.Text = TypeName + " " + "MyLineno";
            lblmypersonnel.Text = TypeName + " " + "My Personnel";
            lblnesxtuser.Text = TypeName + " " + "Nesxt User";
            lblrefno.Text = TypeName + " " + "Ref Number";
            lblReminderNote.Text = TypeName + " " + "Reminder Note";
            lblUpDtTime.Text = TypeName + " " + "Up Dt Time";
            lblusercode.Text = TypeName + " " + "User Code";
            lblUserCodeEntered.Text = TypeName + " " + "User Code Entered";
            lblUserName.Text = TypeName + " " + "User Name";
        }

        public void ChangeLabelForOppertunity(string Type)
        {
            TypeName = Type;
            ShowTicket.Visible = false;
            pnlActivityPerform.Visible = true;
            pnlAmiGlobal.Visible = true;
            pnlDeadLineDate.Visible = true;
            pnlDocumnetName.Visible = true;
            pnlEarlierRefNo.Visible = true;
            pnlEstCost.Visible = true;
            pnlGroupCode.Visible = true;
            pnlInitialDate.Visible = true;
            pnlMyPersonnel.Visible = true;
            pnlNextUser.Visible = true;
            pnlReferenceNo.Visible = true;
            pnlReminderNote.Visible = true;
            pnlUpDtTime.Visible = true;
            pnlUserCode.Visible = true;
            pnlUserCodeEntered.Visible = true;
            pnlUserName.Visible = true;
            panellineno.Visible = true;

            //  Label31.Text = "CRM Activity For" + Type;
            lblActivityPerform.Text = TypeName + " " + "Activity Perform1";
            lblamiglobal.Text = TypeName + " " + "amiglobal1";
            lblDeadLineDate.Text = TypeName + " " + "DeadLine Date1";
            lbldocname.Text = TypeName + " " + "Document Name";
            lblearlierrefno.Text = TypeName + " " + "Earlier Refno";
            lblEstCost.Text = TypeName + " " + "EstCost";
            lblGroupCode.Text = TypeName + " " + "Group Code";
            lblInitialDate.Text = TypeName + " " + "Initial Date";
            lblmylineno.Text = TypeName + " " + "MyLineno";
            lblmypersonnel.Text = TypeName + " " + "My Personnel";
            lblnesxtuser.Text = TypeName + " " + "Nesxt User";
            lblrefno.Text = TypeName + " " + "Ref Number";
            lblReminderNote.Text = TypeName + " " + "Reminder Note";
            lblUpDtTime.Text = TypeName + " " + "Up Dt Time";
            lblusercode.Text = TypeName + " " + "User Code";
            lblUserCodeEntered.Text = TypeName + " " + "User Code Entered";
            lblUserName.Text = TypeName + " " + "User Name";
        }
        public void ChangeLabelForLead(string Type)
        {
            TypeName = Type;
            ShowTicket.Visible = false;
            pnlActivityPerform.Visible = true;
            pnlAmiGlobal.Visible = true;
            pnlDeadLineDate.Visible = true;
            pnlDocumnetName.Visible = true;
            pnlEarlierRefNo.Visible = true;
            pnlEstCost.Visible = true;
            pnlGroupCode.Visible = true;
            pnlInitialDate.Visible = true;
            pnlMyPersonnel.Visible = true;
            pnlNextUser.Visible = true;
            pnlReferenceNo.Visible = true;
            pnlReminderNote.Visible = true;
            pnlUpDtTime.Visible = true;
            pnlUserCode.Visible = true;
            pnlUserCodeEntered.Visible = true;
            pnlUserName.Visible = true;
            panellineno.Visible = true;
            // Label31.Text = "CRM Activity For" + Type;
            lblActivityPerform.Text = TypeName + " " + "Activity Perform1";
            lblamiglobal.Text = TypeName + " " + "amiglobal1";
            lblDeadLineDate.Text = TypeName + " " + "DeadLine Date1";
            lbldocname.Text = TypeName + " " + "Document Name";
            lblearlierrefno.Text = TypeName + " " + "Earlier Refno";
            lblEstCost.Text = TypeName + " " + "EstCost";
            lblGroupCode.Text = TypeName + " " + "Group Code";
            lblInitialDate.Text = TypeName + " " + "Initial Date";
            lblmylineno.Text = TypeName + " " + "MyLineno";
            lblmypersonnel.Text = TypeName + " " + "My Personnel";
            lblnesxtuser.Text = TypeName + " " + "Nesxt User";
            lblrefno.Text = TypeName + " " + "Ref Number";
            lblReminderNote.Text = TypeName + " " + "Reminder Note";
            lblUpDtTime.Text = TypeName + " " + "Up Dt Time";
            lblusercode.Text = TypeName + " " + "User Code";
            lblUserCodeEntered.Text = TypeName + " " + "User Code Entered";
            lblUserName.Text = TypeName + " " + "User Name";
        }

        public void Clear()
        {
            drpComid.Text = "";
            drpActivitycode.Text = "";
            drpReftype.Text = "";
            drpRefsubtype.SelectedIndex = 0;
            // drpActivitytype.SelectedIndex = 0;
            txtUSERCODE.Text = "";
            DrpTenent_ID.SelectedIndex = 0;
            // DrpModuleName.SelectedIndex = 0;
            //  DrpCRM_MainActivity.SelectedIndex = 0;
            ckbAmiglobal.Checked = false;
            ckbMypersonnel.Checked = false;
            Drp_Location.SelectedIndex = 0;
            drpReftype.SelectedIndex = 0;
            drpActivitycode.SelectedIndex = 0;
            drpRefsubtype.SelectedIndex = 0;
            drpComid.SelectedIndex = 0;
            txtInitialDate.Text = DateTime.Now.ToShortDateString();
            txtUPDTTIME.Text = DateTime.Now.ToShortDateString();
            txtDeadLineDate.Text = DateTime.Now.ToShortDateString();
            txtREMINDERNOTE.Text = "";
            txtESTCOST.Text = "";
            txtGROUPCODE.Text = "";
            txtUSERCODEENTERED.Text = "";
        }

        protected void Drp_Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Drp_Location.SelectedValue) != 0)
            {
                if (ViewState["TenentID"] != null)
                {
                    //   string REFType = ViewState["REFTYPE"].ToString();
                    int TeID = Convert.ToInt32(ViewState["TenentID"]);

                    Classes.EcommAdminClass.getdropdown(drpReftype, TeID, "0", "", "", "MODULE_MST");
                    //select * from MODULE_MST where Parent_Module_id =0 

                    //drpReftype.DataSource = DB.MODULE_MST.Where(p => p.TenentID == TeID);
                    //drpReftype.DataTextField = "Module_Name";
                    //drpReftype.DataValueField = "Module_Id";
                    //drpReftype.DataBind();
                    //drpReftype.Items.Insert(0, new ListItem("-- Select --", "0"));
                    drpReftype.Enabled = true;
                }
            }

        }

        public string getsqu(int doc, string RouteID)
        {
            int DRPTID = Convert.ToInt32(DrpTenent_ID.SelectedValue);
            if (DB.tbl_StepsTable.Where(p => p.TenentID == DRPTID && p.DocID == doc && p.RouteID == RouteID).Count() > 0)
            {
                return DB.tbl_StepsTable.Single(p => p.TenentID == DRPTID && p.DocID == doc && p.RouteID == RouteID).SeqNo.ToString();
            }
            else
            {
                return "";
            }

        }

        protected void listserch_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {

            //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int DRPTID = Convert.ToInt32(DrpTenent_ID.SelectedValue);
            if (e.CommandName == "btnEditACTIVITY")
            {
                string[] ID = e.CommandArgument.ToString().Split(',');
                int str1 = Convert.ToInt32(ID[0].ToString());
                Label lblid = (Label)e.Item.FindControl("lblid");

                Label lblCOMPID = (Label)e.Item.FindControl("lblCOMPID");

                int COMPID = Convert.ToInt32(lblCOMPID.Text);
                int DOCNO = Convert.ToInt32(lblid.Text);

                string UID = ((USER_MST)Session["USER"]).USER_ID.ToString();
                int LID = Convert.ToInt32(Drp_Location.SelectedValue);
                //LinkButton linkREF=(LinkButton)e.Item.FindControl("btnACTIVITYEdit");//e.Item.FindControl("btnACTIVITYEdit");
                //int TID = Convert.ToInt32(e.CommandArgument);
                int str2 = Convert.ToInt32(ID[1].ToString());
                List<Database.CRMActivity> List = DB.CRMActivities.Where(p => p.MasterCODE == str2 && p.TenentID == DRPTID).ToList();// && p.Active == "Y"
                List<Database.CRMActivity> Listfinal = new List<Database.CRMActivity>();

                foreach (Database.CRMActivity items in List)
                {
                    string USERCODE = UID.ToString();
                    int GroupCode = Convert.ToInt32(items.GROUPCODE);
                    List<Database.TBLGROUP_USER> tblGroup = DB.TBLGROUP_USER.Where(p => p.TenentID == DRPTID && p.ITGROUPID == GroupCode && p.USERCODE == USERCODE && p.ACTIVE == "1").ToList();

                    int count = tblGroup.Count();

                    if (count > 0)
                    {
                        Listfinal.Add(items);
                    }
                }
                ListView1.DataSource = Listfinal;
                ListView1.DataBind();
                for (int i = 0; i < ListView1.Items.Count; i++)
                {
                    Label lblMylinenumber = (Label)ListView1.Items[i].FindControl("lblMylinenumber");
                    Label MasterCODE = (Label)ListView1.Items[i].FindControl("lblMasterCODE");
                    Label lblType = (Label)ListView1.Items[i].FindControl("lblType");
                    LinkButton btnACTIVITYEdit = (LinkButton)ListView1.Items[i].FindControl("btnACTIVITYEdit");
                    Label lblsquno = (Label)ListView1.Items[i].FindControl("lblsquno");
                    Label lblGroup = (Label)ListView1.Items[i].FindControl("lblGroup");

                    int seq = lblsquno.Text != "" ? Convert.ToInt32(lblsquno.Text) : 1;
                    int ID1 = Convert.ToInt32(lblMylinenumber.Text);
                    int MstCode = Convert.ToInt32(MasterCODE.Text);
                    int Type = lblType.Text != "" ? Convert.ToInt32(lblType.Text) : 0;


                    int GroupCode = Convert.ToInt32(lblGroup.Text);
                    List<Database.TBLGROUP_USER> tblGroup = DB.TBLGROUP_USER.Where(p => p.TenentID == DRPTID && p.ITGROUPID == GroupCode && p.USERCODE == UID && p.ACTIVE == "1").ToList();

                    int count = tblGroup.Count();

                    if (count > 0)
                    {
                        if (DB.CRMProgHWs.Where(p => p.ActivityID == ID1 && p.TenentID == DRPTID && p.RunningSerial == Type).Count() > 0)
                        {
                            CRMProgHW obj = DB.CRMProgHWs.Single(p => p.ActivityID == ID1 && p.TenentID == DRPTID && p.RunningSerial == Type);
                            string url = obj.URL;
                            btnACTIVITYEdit.Text = obj.ButtionName;
                            btnACTIVITYEdit.PostBackUrl = url + "?TactionNo=" + DOCNO + "&DocNo=" + DOCNO + "&DashboardSeq=" + seq + "&RefNo=" + 12006 + "&COMPID=" + COMPID + "&MstCode=" + MstCode + "&Type=" + Type;
                            btnACTIVITYEdit.Visible = true;
                        }
                        else
                        {
                            btnACTIVITYEdit.Visible = false;
                        }
                    }
                    else
                    {
                        btnACTIVITYEdit.Visible = false;
                    }


                }
                lblactivityname.Text = DB.CRMMainActivities.Single(p => p.TenentID == DRPTID && p.MasterCODE == str2).DisplayFDName;
                Crmlist.Visible = true;
                // Database.ACM_CRMMainActivities objCRM_tbl_Campaign_Mst = DBACMENTITY.ACM_CRMMainActivities.Single(p => p.MasterCODE == str2  && p.TenentID == str1);
                // //Database.ACM_CRMMainActivities objCRM_tbl_Campaign_Mst = DBACMENTITY.ACM_CRMMainActivities.Single(p => p.TenentID == TID);
                //drpComid.SelectedIndex = objCRM_tbl_Campaign_Mst.COMPID;
                //drpActivitycode.SelectedIndex = objCRM_tbl_Campaign_Mst.MasterCODE;
                //txtMylineno.Text = objCRM_tbl_Campaign_Mst.RouteID.ToString();
                //txtUSERCODE.Text = objCRM_tbl_Campaign_Mst.USERCODE.ToString();
                //txtReferenceNo.Text = objCRM_tbl_Campaign_Mst.Reference;
                //txtEarlierRefNo.Text = objCRM_tbl_Campaign_Mst.ESTCOST.ToString();
                //txtNextUser.Text = objCRM_tbl_Campaign_Mst.USERNAME;
                //txtREMINDERNOTE.Text = objCRM_tbl_Campaign_Mst.REMINDERNOTE;
                //txtESTCOST.Text = objCRM_tbl_Campaign_Mst.ESTCOST.ToString();
                //txtGROUPCODE.Text = objCRM_tbl_Campaign_Mst.GROUPCODE.ToString();
                //txtUSERCODEENTERED.Text = objCRM_tbl_Campaign_Mst.USERCODE.ToString();
                //txtUPDTTIME.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.UPDTTIME).ToShortDateString();
                //txtUSERNAME.Text = objCRM_tbl_Campaign_Mst.USERNAME;
                // txtInitialDate.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.REPEATTILL).ToShortDateString();
                // txtDeadLineDate.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.UPDTTIME).ToShortDateString();
                // ckbAmiglobal.Checked = (objCRM_tbl_Campaign_Mst.AMIGLOBAL == true) ? true : false;
                // ckbMypersonnel.Checked = (objCRM_tbl_Campaign_Mst.MYPERSONNEL == true) ? true : false;


                // ViewState["Edit"] = ID;




            }
            // PostBackUrl='EditActivityData.aspx?REFNO=<%#Eval("ACTIVITYCODE")%>&REF=<%#Eval("CollectionName")%>'
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (e.CommandName == "btnEdit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                Database.CRMActivity objCRM_tbl_Campaign_Mst = DB.CRMActivities.Single(p => p.MyLineNo == ID);
                int MSI = Convert.ToInt32(objCRM_tbl_Campaign_Mst.MasterCODE);
                int TCTID = Convert.ToInt32(DB.CRMMainActivities.Single(p => p.MasterCODE == MSI).MyID);
                Response.Redirect(objCRM_tbl_Campaign_Mst.UrlRedirct + "?TactionNo=" + TCTID);
                Session["AcmTenant"] = TID;
                // //Database.ACM_CRMMainActivities objCRM_tbl_Campaign_Mst = DBACMENTITY.ACM_CRMMainActivities.Single(p => p.TenentID == TID);
                // if (objCRM_tbl_Campaign_Mst.COMPID != null && objCRM_tbl_Campaign_Mst.COMPID != 0)
                //     drpComid.SelectedValue = objCRM_tbl_Campaign_Mst.COMPID.ToString();
                // if (objCRM_tbl_Campaign_Mst.ActivityID != null && objCRM_tbl_Campaign_Mst.ActivityID != 0)
                //     drpActivitycode.SelectedValue = objCRM_tbl_Campaign_Mst.ActivityID.ToString();
                // txtMylineno.Text = objCRM_tbl_Campaign_Mst.RouteID.ToString();
                // txtUSERCODE.Text = objCRM_tbl_Campaign_Mst.USERNAME.ToString();
                // txtReferenceNo.Text = objCRM_tbl_Campaign_Mst.REFTYPE;
                // txtEarlierRefNo.Text = objCRM_tbl_Campaign_Mst.ESTCOST.ToString();
                // txtNextUser.Text = objCRM_tbl_Campaign_Mst.USERNAME;
                // txtREMINDERNOTE.Text = objCRM_tbl_Campaign_Mst.REMINDERNOTE;
                // txtESTCOST.Text = objCRM_tbl_Campaign_Mst.ESTCOST.ToString();
                // txtGROUPCODE.Text = objCRM_tbl_Campaign_Mst.GROUPCODE.ToString();
                // txtUSERCODEENTERED.Text = objCRM_tbl_Campaign_Mst.USERNAME.ToString();
                // txtUPDTTIME.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.UPDTTIME).ToString("MM/dd/yyyy");
                // txtUSERNAME.Text = objCRM_tbl_Campaign_Mst.USERNAME;
                // txtInitialDate.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.InitialDate).ToString("MM/dd/yyyy");
                // txtDeadLineDate.Text = Convert.ToDateTime(objCRM_tbl_Campaign_Mst.DeadLineDate).ToString("MM/dd/yyyy");
                // ckbAmiglobal.Checked = (objCRM_tbl_Campaign_Mst.AMIGLOBAL == "Y") ? true : false;
                // ckbMypersonnel.Checked = (objCRM_tbl_Campaign_Mst.MYPERSONNEL == "Y") ? true : false;
                // ViewState["Edit"] = ID;
            }
            if (e.CommandName == "BtnSatrt")
            {
                DropDownList drpActivityStatus = (DropDownList)e.Item.FindControl("drpActivityStatus");
                // LinkButton btnstaer=(LinkButton)e.Item.FindControl("btnstaer");
                ModalPopupExtender ModalPopupExtender7 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender7");
                ModalPopupExtender ModalPopupExtender1 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender1");
                ModalPopupExtender ModalPopupExtender3 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender3");
                ModalPopupExtender ModalPopupExtender4 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender4");
                ModalPopupExtender ModalPopupExtender5 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender5");
                ModalPopupExtender ModalPopupExtender6 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender6");
                ModalPopupExtender ModalPopupExtender8 = (ModalPopupExtender)e.Item.FindControl("ModalPopupExtender8");
                int ID = Convert.ToInt32(drpActivityStatus.SelectedValue);
                if (ID == 1240101)
                    ModalPopupExtender7.Show();//In Progress
                if (ID == 1240107)
                    ModalPopupExtender1.Show();//Open Activity
                if (ID == 10608)
                    ModalPopupExtender3.Show();//Forward
                if (ID == 1240102)
                    ModalPopupExtender4.Show();//resedual
                if (ID == 1240102)
                    ModalPopupExtender5.Show();//Close Activity
                if (ID == 1240105)
                    ModalPopupExtender6.Show();//Indefinite
                if (ID == 1240106)
                    ModalPopupExtender8.Show();//Unknown
            }
            if (e.CommandName == "btnforwordactivity")
            {
                string[] ID = e.CommandArgument.ToString().Split('-');
                int Tene = Convert.ToInt32(ID[0]);
                int MasterCode = Convert.ToInt32(ID[1]);
                int Activityid = Convert.ToInt32(ID[2]);
                int LinkMaster = Convert.ToInt32(ID[3]);
                //int ID = Convert.ToInt32(e.CommandArgument);
                int LID = Convert.ToInt32(Drp_Location.SelectedValue);
                DropDownList drpuserlist = (DropDownList)e.Item.FindControl("drpuserlist");
                DropDownList drpActivityStatus = (DropDownList)e.Item.FindControl("drpActivityStatus");
                int StatusID = Convert.ToInt32(drpActivityStatus.SelectedValue);
                string ButtionName = "Forward To " + drpuserlist.SelectedItem.ToString();
                Label DocID = (Label)e.Item.FindControl("lblDocNO");
                //Database.CRMMainActivity obj = DB.CRMMainActivities.Single(p => p.TenentID == TID && p.MasterCODE == ID);
                Database.CRMActivity objCRMActivity = DB.CRMActivities.Single(p => p.TenentID == Tene && p.MasterCODE == MasterCode && p.ActivityID == Activityid && p.LinkMasterCODE == LinkMaster);// && p.Active == "Y"
                int COMPID = objCRMActivity.COMPID;
                int activityid = Convert.ToInt32(objCRMActivity.ActivityID);

                int newActivityid = DB.CRMActivities.Where(p => p.TenentID == TID && p.COMPID == COMPID && p.MasterCODE == MasterCode).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TID && p.COMPID == COMPID && p.MasterCODE == MasterCode).Max(p => p.ActivityID) + 1) : 1;

                Database.CRMProgHW HWobj = DB.CRMProgHWs.Single(p => p.TenentID == TID && p.ActivityID == activityid && p.RunningSerial == LinkMaster);
                string Parameter2 = HWobj.Parameter2;
                DateTime? Ndate = null;
                if (HWobj.ReminderDate != null)
                    Ndate = HWobj.ReminderDate;
                string URL = HWobj.URL;
                string URLWrite = HWobj.URLRewrite;

                int DocNO = Convert.ToInt32(DocID.Text);
                string REFNO = objCRMActivity.EarlierRefNo;
                string UserID = drpuserlist.SelectedItem.Text;
                int UID = Convert.ToInt32(drpuserlist.SelectedValue);

                string Activitytype = "CRM_NOTE_FOWARD";
                int LMN = Classes.CRMClass.InsertActivity(Tene, LID, COMPID, MasterCode, MasterCode, REFNO, UserID, REFNO, newActivityid, Activitytype, UID, DocNO, 0, "Y", "1");
                Classes.ACMClass.InsertDataCRMProgHW(Tene, newActivityid, StatusID, ButtionName, true, Parameter2, "", true, DateTime.Now, 0, Ndate, URL, URLWrite, LMN);
            }
        }

        protected void drpActivityStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(Drp_Location.SelectedValue);
            int TTID = Convert.ToInt32(DrpTenent_ID.SelectedValue);
            DropDownList drpstatus = (DropDownList)e.Item.FindControl("drpstatus");
            DropDownList drpprority = (DropDownList)e.Item.FindControl("drpprority");
            DropDownList drpActivityStatus = (DropDownList)e.Item.FindControl("drpActivityStatus");
            DropDownList drpuserlist = (DropDownList)e.Item.FindControl("drpuserlist");
            TextBox txttime = (TextBox)e.Item.FindControl("txttime");
            TextBox txtowner = (TextBox)e.Item.FindControl("txtowner");
            Label lblMylinenumber = (Label)e.Item.FindControl("lblMylinenumber");
            Label lblusername = (Label)e.Item.FindControl("lblusername");
            Label lblGroup = (Label)e.Item.FindControl("lblGroup");
            txtowner.Text = lblusername.Text;
            string ACTID = lblMylinenumber.Text;
            //Classes.EcommAdminClass.getdropdown(drpActivityStatus, TTID, ACTID, "", "", "CRMBaseTable");
            Classes.EcommAdminClass.getdropdown(drpActivityStatus, TTID, "ACTVTY", "CRMSTATUS", "", "REFTABLE");
            Classes.EcommAdminClass.getdropdown(drpstatus, TTID, "ACTVTY", "STATUS", "", "REFTABLE");
            Classes.EcommAdminClass.getdropdown(drpprority, TTID, "ACTVTY", "PRIORITY", "", "REFTABLE");
            txttime.Text = DateTime.Now.ToShortTimeString();

            Database.USER_ROLE obj = DB.USER_ROLE.Where(p => p.TenentID == TTID && p.LOCATION_ID == LID && p.USER_ID == UID).FirstOrDefault();
            if (obj != null)
            {
                int ROLID = obj.ROLE_ID;
                List<Database.View_Role> LIST = DB.View_Role.Where(p => p.ROLE_ID == ROLID && p.USER_ID != UID && p.TenentID == TTID).GroupBy(p => p.USER_ID).Select(p => p.FirstOrDefault()).ToList();
                drpuserlist.DataSource = LIST;
                drpuserlist.DataTextField = "FIRST_NAME";
                drpuserlist.DataValueField = "USER_ID";
                drpuserlist.DataBind();
                drpuserlist.Items.Insert(0, new ListItem("-- Select User --", "0"));
            }


        }

        public string getgroupname(int Grop)
        {
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            int TID = Convert.ToInt32(DrpTenent_ID.SelectedValue);//Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int LID = Convert.ToInt32(Drp_Location.SelectedValue);//Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);

            List<Database.TBLGROUP> listgroup = DB.TBLGROUPs.Where(p => p.TenentID == TID && p.LocationId == LID && p.ITGROUPID == Grop).ToList();
            if (listgroup.Count() > 0)
            {
                return listgroup.Single(p => p.TenentID == TID && p.LocationId == LID && p.ITGROUPID == Grop).ITGROUPDESC1;
            }
            else
            {
                return "";
            }

        }

        protected void btnShowallActivity_Click(object sender, EventArgs e)
        {
            //string AID = (drpReftype.SelectedItem.Text).ToString();
            int Modual = Convert.ToInt32(drpReftype.SelectedValue);
            //string RefSubID = (drpRefsubtype.SelectedItem.Text);
            int TeID = Convert.ToInt32(ViewState["TenentID"]);
            //Database.CRMMainActivity obj_MainActivity = DB.CRMMainActivities.SingleOrDefault(p => p.ACTIVITYA == RefSubID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            //obj_MainActivity.ACTIVITYA = txtActivityPerform.Text;
            //obj_MainActivity.UPDTTIME = DateTime.Now;
            //obj_MainActivity.GROUPCODE = 
            // string Type = obj_MainActivity.REFTYPE;
            //Label3.Text = RefSubID;
            string UID1 = UID.ToString();

            //Database.CRMMainActivity OBJMainAct = DB.CRMMainActivities.Single(p => p.TenentID == TeID && p.ACTIVITYE == RefSubID && p.ModuleID == Modual && p.Active == true);

            //List<Database.TBLGROUP_USER> listGroup = DB.TBLGROUP_USER.Where(p => p.TenentID == TeID && p.ITGROUPID == OBJMainAct.GROUPCODE && p.USERCODE == UID1 && p.ACTIVE == "1").ToList();
            //if (listGroup.Count()>0)
            //{
            listserch.DataSource = DB.CRMMainActivities.Where(p => p.TenentID == TeID && p.ModuleID == Modual && p.Active == true);//&&p.USERCODE==UID;
            listserch.DataBind();
            Crmlist.Visible = false;
        }




    }
}