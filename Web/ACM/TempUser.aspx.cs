using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.ACM
{
    public partial class TempUser : System.Web.UI.Page
    {
        Database.CallEntities DB = new Database.CallEntities();
        private DataTable Persons
        {
            get { return ViewState["Persons"] != null ? (DataTable)ViewState["Persons"] : null; }
            set { ViewState["Persons"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void drpTenetID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);

            Classes.EcommAdminClass.getdropdown(drpLocationid, TID, "", "", "", "TBLLOCATION");
            //select * from TBLLOCATION where TenantID=1

            //drpLocationid.DataSource = DB.TBLLOCATIONs.Where(p => p.TenantID == TID && p.Active == "Y");
            //drpLocationid.DataTextField = "LOCNAME1";
            //drpLocationid.DataValueField = "LOCATIONID";
            //drpLocationid.DataBind();
            //drpLocationid.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Loction--", "0"));
        }

        protected void drpLocationid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            string LocId = LID.ToString();

            Classes.EcommAdminClass.getdropdown(drpUserName, TID, LocId, "", "", "USER_MST");
            //select * from USER_MST

            //drpUserName.DataSource = DB.USER_MST.Where(p => p.TenentID == TID && p.ACTIVE_FLAG == "Y" && p.LOCATION_ID == LID);
            //drpUserName.DataTextField = "FIRST_NAME";
            //drpUserName.DataValueField = "USER_ID";
            //drpUserName.DataBind();
            //drpUserName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User --", "0"));

            Classes.EcommAdminClass.getdropdown(drpMenuID, TID, "", "", "", "FUNCTION_MST");
            //select * from FUNCTION_MST where TenentID=1 and ACTIVE_FLAG=1

            //drpMenuID.DataSource = DB.FUNCTION_MST.Where(p => p.TenentID == TID && p.ACTIVE_FLAG == 1 );
            //drpMenuID.DataTextField = "MENU_NAME1";
            //drpMenuID.DataValueField = "MENU_ID";
            //drpMenuID.DataBind();
            //drpMenuID.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Function --", "0"));


          //  BindData(TID, LID);
            
            
            //for MODULE_MAP

        }

        public void BindData(int TID, int LID)
        {
            listprivilege123.DataSource = DB.PRIVILAGE_MENU.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID && p.LOCATION_ID == LID);
            listprivilege123.DataBind();
        }

        protected void drpUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);

            BindModucl(TID, UID);
            BindUserrolr(TID, UID);
            BindUserRights(TID, UID);
           
        }
        public void BindUserRights(int TID,int UID)
        {
            var result3 = (from URR in DB.USER_RIGHTS
                           join
                               pm in DB.PRIVILAGE_MENU on URR.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where URR.TenentID == TID && URR.USER_ID == UID
                           select new { URR.TenentID, URR.PRIVILEGE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, URR.USER_ID, URR.ADD_FLAG, URR.MODIFY_FLAG, URR.DELETE_FLAG, URR.VIEW_FLAG, URR.ALL_FLAG, a = pm.ADD_FLAG, b = pm.MODIFY_FLAG, c = pm.DELETE_FLAG, d = pm.VIEW_FLAG }).ToList();
            listuserrights123.DataSource = result3;
            listuserrights123.DataBind();
        }

        public void BindUserrolr(int TID,int UID)
        {
            var result1 = (from pm in DB.PRIVILAGE_MENU
                           join
                             ur in DB.USER_ROLE on pm.PRIVILEGE_ID equals ur.PRIVILEGE_ID
                           where ur.ACTIVE_FLAG == "Y" && ur.TenentID == TID && ur.USER_ID == UID && ur.ACTIVE_FROM_DT <= DateTime.Now && ur.ACTIVE_TO_DT >= DateTime.Now
                           select new { ur.TenentID, ur.PRIVILEGE_ID, ur.ROLE_ID, pm.PRIVILAGEFOR, pm.MENU_ID, pm.PRIVILEGE_MENU_ID, ur.ACTIVE_FLAG, ur.USER_ID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, ur.ACTIVE_TO_DT }).ToList();
            listuserrolr123.DataSource = result1;
            listuserrolr123.DataBind();
        }

        public void BindModucl(int TID, int UID)
        {
           
            var result2 = (from Module in DB.MODULE_MAP
                           join
                               pm in DB.PRIVILAGE_MENU on Module.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where Module.ACTIVE_FLAG == "Y" && Module.TenentID == TID && Module.UserID == UID
                           select new { Module.TenentID, Module.PRIVILEGE_ID, Module.MODULE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, Module.ACTIVE_FLAG, Module.UserID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, }).ToList();

            listmodule123.DataSource = result2;
            listmodule123.DataBind();
        }
        public string getMenuName(int PN)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            return DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == PN && p.TenentID == TID ).MENU_NAME1;
        }

        public string getpriveleg(int PID)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            return DB.PRIVILEGE_MST.SingleOrDefault(p => p.PRIVILEGE_ID == PID && p.TenentID == TID ).PRIVILEGE_NAME;
        }

        public string getModulName(int MID)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            return DB.MODULE_MST.SingleOrDefault(p => p.Module_Id == MID && p.TenentID == TID ).Module_Name;
        }

        public string getUserName(int UID)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            return DB.USER_MST.SingleOrDefault(p => p.USER_ID == UID && p.TenentID == TID && p.LOCATION_ID == LID).FIRST_NAME;
        }

        public string getRolrName(int RID)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            return DB.ROLE_MST.SingleOrDefault(p => p.ROLE_ID == RID && p.TenentID == TID ).ROLE_NAME;
        }

        protected void drpMenuID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["MID"] = null;
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            int MID = Convert.ToInt32(drpMenuID.SelectedValue);
            BindManuData(TID, UID, MID);
           
            ViewState["MID"] = 1; 
        }
        public void BindManuData(int TID,int UID,int MID)
        {
            List<Database.tempUser> userlist = new List<Database.tempUser>();
            Database.tempUser obj = new Database.tempUser();
            Database.FUNCTION_MST MenuObj = new Database.FUNCTION_MST();
            var result2 = (from Module in DB.MODULE_MAP
                           join
                               pm in DB.PRIVILAGE_MENU on Module.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where Module.ACTIVE_FLAG == "Y" && Module.TenentID == TID && Module.UserID == UID && pm.MENU_ID == MID
                           select new { Module.TenentID, Module.PRIVILEGE_ID, Module.MODULE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, Module.ACTIVE_FLAG, Module.UserID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, }).ToList();

            listmodule123.DataSource = result2;
            listmodule123.DataBind();

            var result1 = (from pm in DB.PRIVILAGE_MENU
                           join
                             ur in DB.USER_ROLE on pm.PRIVILEGE_ID equals ur.PRIVILEGE_ID
                           where ur.ACTIVE_FLAG == "Y" && ur.TenentID == TID && ur.USER_ID == UID && ur.ACTIVE_FROM_DT <= DateTime.Now && ur.ACTIVE_TO_DT >= DateTime.Now && pm.MENU_ID == MID
                           select new { ur.TenentID, ur.PRIVILEGE_ID, ur.ROLE_ID, pm.PRIVILAGEFOR, pm.MENU_ID, pm.PRIVILEGE_MENU_ID, ur.ACTIVE_FLAG, ur.USER_ID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, ur.ACTIVE_TO_DT }).ToList();
            listuserrolr123.DataSource = result1;
            listuserrolr123.DataBind();

            var result3 = (from URR in DB.USER_RIGHTS
                           join
                               pm in DB.PRIVILAGE_MENU on URR.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where URR.TenentID == TID && URR.USER_ID == UID && pm.MENU_ID == MID
                           select new { URR.TenentID, URR.PRIVILEGE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, URR.USER_ID, URR.ADD_FLAG, URR.MODIFY_FLAG, URR.DELETE_FLAG, URR.VIEW_FLAG, URR.ALL_FLAG, a = pm.ADD_FLAG, b = pm.MODIFY_FLAG, c = pm.DELETE_FLAG, d = pm.VIEW_FLAG }).ToList();
            listuserrights123.DataSource = result3;
            listuserrights123.DataBind();
        }
        protected void listprivilege123_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
                listprivilege123.EditIndex = e.NewEditIndex;
                BindData(TID, LID);
          
        }

        protected void listprivilege123_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            if (listprivilege123.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList drpprivilegeid = (e.Item.FindControl("drpprivilegeid") as DropDownList);

                Classes.EcommAdminClass.getdropdown(drpprivilegeid, TID, "", "", "", "PRIVILEGE_MST");
                //select * from PRIVILEGE_MST where ACTIVE_FLAG = 'Y'

                //drpprivilegeid.DataSource = DB.PRIVILEGE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drpprivilegeid.DataTextField = "PRIVILEGE_NAME";
                //drpprivilegeid.DataValueField = "PRIVILEGE_ID";
                //drpprivilegeid.DataBind();
                //drpprivilegeid.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Privilege--", "0"));
            }
        }

        protected void listprivilege123_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            listprivilege123.EditIndex = -1;
            BindData(TID, LID);
        }

        protected void listprivilege123_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int LID = Convert.ToInt32(drpLocationid.SelectedValue);
            string name = (listprivilege123.Items[e.ItemIndex].FindControl("lblName") as Label).Text;
            string Label9 = (listprivilege123.Items[e.ItemIndex].FindControl("Label9") as Label).Text;

            string drpprivilegeid = (listprivilege123.Items[e.ItemIndex].FindControl("drpprivilegeid") as DropDownList).SelectedItem.Value;
            foreach (DataRow row in Persons.Rows)
            {
                if (row["Name"].ToString() == name)
                {
                    row["Country"] = drpprivilegeid;
                    break;
                }
            }
            listprivilege123.EditIndex = -1;
            BindData(TID, LID);
        }

        protected void listmodule123_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName .SelectedValue);
            if (ViewState["MID"]!=null )
            {
                int MID = Convert.ToInt32(drpMenuID.SelectedValue);
                listmodule123.EditIndex = e.NewEditIndex;
                BindManuData(TID, UID, MID);
            }
            else
            {
                listmodule123.EditIndex = e.NewEditIndex;
                BindModucl(TID, UID);
            }
            
        }

        protected void listmodule123_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            if (listmodule123.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList drpmodul = (e.Item.FindControl("drpmodul") as DropDownList);
                DropDownList drpuser = (e.Item.FindControl("drpuser") as DropDownList);

                Classes.EcommAdminClass.getdropdown(drpmodul, TID, "", "", "", "MODULE_MST");
                //select * from MODULE_MST where ACTIVE_FLAG ='Y' 

                //drpmodul.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drpmodul.DataTextField = "Module_Name";
                //drpmodul.DataValueField = "Module_Id";
                //drpmodul.DataBind();
                //drpmodul.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Modul--", "0"));

                Classes.EcommAdminClass.getdropdown(drpuser, TID, "", "", "", "USER_MST");
                //select * from USER_MST where ACTIVE_FLAG = 'Y'

                //drpuser.DataSource = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drpuser.DataTextField = "FIRST_NAME";
                //drpuser.DataValueField = "USER_ID";
                //drpuser.DataBind();
                //drpuser.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User--", "0"));


            }
        }

        protected void listmodule123_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            listmodule123.EditIndex = -1;
            BindModucl(TID, UID);

        }

        protected void listmodule123_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }

        protected void listuserrolr123_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            if (ViewState["MID"] != null)
            {
                int MID = Convert.ToInt32(drpMenuID.SelectedValue);
                listuserrolr123.EditIndex = e.NewEditIndex;
                BindManuData(TID, UID, MID);
            }
            else
            {
                listuserrolr123.EditIndex = e.NewEditIndex;
                BindUserrolr(TID, UID);
            }
           
        }

        protected void listuserrolr123_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            if (listuserrolr123.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList drprole = (e.Item.FindControl("drprole") as DropDownList);
                DropDownList drpuser = (e.Item.FindControl("drpuser") as DropDownList);

                Classes.EcommAdminClass.getdropdown(drprole, TID, "", "", "", "ROLE_MST");
                //select * from ROLE_MST where ACTIVE_FLAG ='Y'

                //drprole.DataSource = DB.ROLE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drprole.DataTextField = "ROLE_NAME";
                //drprole.DataValueField = "ROLE_ID";
                //drprole.DataBind();
                //drprole.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Role--", "0"));

                Classes.EcommAdminClass.getdropdown(drpuser, TID, "", "", "", "USER_MST");
                //select * from USER_MST where ACTIVE_FLAG = 'Y'

                //drpuser.DataSource = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drpuser.DataTextField = "FIRST_NAME";
                //drpuser.DataValueField = "USER_ID";
                //drpuser.DataBind();
                //drpuser.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User--", "0"));

            }
        }

        protected void listuserrolr123_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            listuserrolr123.EditIndex = -1;
            BindUserrolr(TID, UID);
        }

        protected void listuserrolr123_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }

        protected void listuserrights123_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            if (ViewState["MID"] != null)
            {
                int MID = Convert.ToInt32(drpMenuID.SelectedValue);
                listuserrights123.EditIndex = e.NewEditIndex;
                BindManuData(TID, UID, MID);
            }
            else
            {
                listuserrights123.EditIndex = e.NewEditIndex;
                BindUserRights(TID, UID);
            }
        }

        protected void listuserrights123_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            if (listuserrights123.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
            {
                DropDownList drppriveleg = (e.Item.FindControl("drppriveleg") as DropDownList);
                DropDownList drpuser = (e.Item.FindControl("drpuser") as DropDownList);

                Classes.EcommAdminClass.getdropdown(drppriveleg, TID, "", "", "", "PRIVILEGE_MST");
                //select * from PRIVILEGE_MST where ACTIVE_FLAG = 'Y'

                //drppriveleg.DataSource = DB.PRIVILEGE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drppriveleg.DataTextField = "PRIVILEGE_NAME";
                //drppriveleg.DataValueField = "PRIVILEGE_ID";
                //drppriveleg.DataBind();
                //drppriveleg.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select PRIVILEGE NAME--", "0"));

                Classes.EcommAdminClass.getdropdown(drpuser, TID, "", "", "", "USER_MST");
                //select * from USER_MST where ACTIVE_FLAG = 'Y'

                //drpuser.DataSource = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID);
                //drpuser.DataTextField = "FIRST_NAME";
                //drpuser.DataValueField = "USER_ID";
                //drpuser.DataBind();
                //drpuser.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select USER NAME--", "0"));

            }
        }

        protected void listuserrights123_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            int TID = Convert.ToInt32(drpTenetID.SelectedValue);
            int UID = Convert.ToInt32(drpUserName.SelectedValue);
            listuserrights123.EditIndex = -1;
            BindUserRights(TID, UID);
        }

        protected void listuserrights123_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }

        protected void listmodule123_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName =="Update")
            {
                string[] strArrpMaster = (e.CommandArgument).ToString().Split(',');
                int MenuID = Convert.ToInt32(strArrpMaster[0].ToString());
                int ModulID = Convert.ToInt32(strArrpMaster[1].ToString());
                int UserID = Convert.ToInt32(strArrpMaster[2].ToString());
                DropDownList drpmodul = (DropDownList)e.Item.FindControl("drpmodul");
                 DropDownList drpuser = (DropDownList)e.Item.FindControl("drpuser");
                MODULE_MAP obj = DB.MODULE_MAP.Single(p => p.MODULE_ID == ModulID && p.UserID == UserID);
                obj.MODULE_ID =Convert .ToInt32 ( drpmodul.SelectedValue);
                obj.UserID = Convert.ToInt32(drpuser.SelectedValue);
                DB.SaveChanges();

            }
        }

    }
}