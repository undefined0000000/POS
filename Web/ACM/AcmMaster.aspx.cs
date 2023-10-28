using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using System.Transactions;

namespace Web.ACM
{
    public partial class AcmMaster : System.Web.UI.Page
    {
        Database.CallEntities DB = new Database.CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdwon();
            }
        }
        public string SessionLoad1(int TID, int LID, int UID, int EMPID, string LangID)
        {
            TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            EMPID = Convert.ToInt32(((USER_MST)Session["USER"]).EmpID);
            LangID = Session["LANGUAGE"].ToString();
            string Ref = TID.ToString() + "," + LID.ToString() + "," + UID.ToString() + "," + EMPID.ToString() + "," + LangID;
            return Ref;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Database.USER_DTL objUSER_DTL = new Database.USER_DTL();
                objUSER_DTL.TenentID = 999999999;
                objUSER_DTL.USER_DETAIL_ID = DB.USER_DTL.Count() > 0 ? Convert.ToInt32(DB.USER_DTL.Max(p => p.USER_DETAIL_ID) + 1) : 1;
                objUSER_DTL.LOCATION_ID = 999999999;
                objUSER_DTL.CRUP_ID = 999999999;
                DB.USER_DTL.AddObject(objUSER_DTL);
                DB.SaveChanges();
                Database.USER_MST objUSER_MST = new Database.USER_MST();
                objUSER_MST.TenentID = 999999999;
                objUSER_MST.USER_ID = DB.USER_MST.Count() > 0 ? Convert.ToInt32(DB.USER_MST.Max(p => p.USER_ID) + 1) : 1;
                objUSER_MST.LOCATION_ID = 999999999;
                objUSER_MST.FIRST_NAME = txtfirstname.Text;
                objUSER_MST.LAST_NAME = txtlastname.Text;
                objUSER_MST.LOGIN_ID = txtlonginId.Text;
                objUSER_MST.PASSWORD = txtpassword.Text;
                objUSER_MST.CRUP_ID = 999999999;
                objUSER_MST.ACTIVE_FLAG = "Y";
                objUSER_MST.USER_DETAIL_ID = objUSER_DTL.USER_DETAIL_ID;
                DB.USER_MST.AddObject(objUSER_MST);
                DB.SaveChanges();
                Database.MODULE_MST objMODULE_MST = new Database.MODULE_MST();
                objMODULE_MST.TenentID = 999999999;
                objMODULE_MST.Module_Id = DB.MODULE_MST.Count() > 0 ? Convert.ToInt32(DB.MODULE_MST.Max(p => p.Module_Id) + 1) : 1;
               // objMODULE_MST.LOCATION_ID = 999999999;
                objMODULE_MST.MYSYSNAME = txtsysname.Text;
                objMODULE_MST.Module_Name = txtmodulname.Text;
                objMODULE_MST.Module_Desc = txtmoduldes.Text;
                objMODULE_MST.Parent_Module_id =Convert.ToInt32( drpmodulname.SelectedValue);
                objMODULE_MST.CRUP_ID = 999999999;
                objMODULE_MST.ACTIVE_FLAG = "Y";
                DB.MODULE_MST.AddObject(objMODULE_MST);
                DB.SaveChanges();
                Database.PRIVILEGE_MST objPRIVILEGE_MST = new Database.PRIVILEGE_MST();
                objPRIVILEGE_MST.TenentID = 999999999;
               // objPRIVILEGE_MST.LOCATION_ID = 999999999;
                objPRIVILEGE_MST.MODULE_ID = objMODULE_MST.Module_Id;
                objPRIVILEGE_MST.PRIVILEGE_DESC = txtprivileDesc.Text;
                objPRIVILEGE_MST.PRIVILEGE_NAME = txtprivilegename.Text;
                objPRIVILEGE_MST.CRUP_ID = 999999999;
                objPRIVILEGE_MST.ACTIVE_FLAG = "Y";
                DB.PRIVILEGE_MST.AddObject(objPRIVILEGE_MST);
                DB.SaveChanges();
                Database.ROLE_MST objROLE_MST = new Database.ROLE_MST();
                objROLE_MST.TenentID = 999999999;
              //  objROLE_MST.LOCATION_ID = 999999999;
                objROLE_MST.ROLE_NAME = txtrolename.Text;
                objROLE_MST.ROLE_DESC = txtroledesc.Text;
                objROLE_MST.ACTIVE_FROM_DT = Convert.ToDateTime(txtactiveformdate.Text);
                objROLE_MST.ACTIVE_TO_DT = Convert.ToDateTime(txtactivetodate.Text);
                objROLE_MST.ACTIVE_FLAG = "Y";
                objROLE_MST.CRUP_ID = 999999999;
                DB.ROLE_MST.AddObject(objROLE_MST);
                DB.SaveChanges();



                scope.Complete(); //  To commit.

            }
        }

        protected void btncensl_Click(object sender, EventArgs e)
        {

        }
        public void BindDropdwon()
        {
            Classes.EcommAdminClass.getdropdown(drpmodulname, 0, "", "", "", "MODULE_MST");
            //select * from MODULE_MST where Parent_Module_id =0 

            //drpmodulname.DataSource = DB.MODULE_MST.Where(p => p.Parent_Module_id == 0 && p.ACTIVE_FLAG == "Y");
            //drpmodulname.DataTextField = "Module_Name";
            //drpmodulname.DataValueField = "Module_Id";
            //drpmodulname.DataBind();
            //drpmodulname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Modul--", "0"));
        }
    }
}