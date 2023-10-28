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
using Repository;

namespace Web.ACM
{
    public partial class Acm_Node : System.Web.UI.Page
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
              
                pnlSuccessMsg.Visible = false;
                ManageLang();
                databind();
                drpMYBUSID.DataSource = ClsActivities.GetParentCmb(TID);
                drpMYBUSID.DataTextField = "PageTitle";
                drpMYBUSID.DataValueField = "NodeID";
                drpMYBUSID.DataBind();
               // FillContractorID();
               // BindData();
                btnAdd.ValidationGroup = "ss";
                int CurrentID = 1;
                if (ViewState["Es"] != null)
                    CurrentID = Convert.ToInt32(ViewState["Es"]);
                //BindData();
                // FirstData();
               

               
                //int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
               
            }
        }

        private void databind()
        {
          int  TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            DataTable dt = ClsActivities.GetNode(0, TID1);
            Listview1.DataSource = dt;
            Listview1.DataBind();
        }
        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (e.CommandName == "btnEdit")
            {
                int NodeID = Convert.ToInt32(e.CommandArgument);
                DataTable NodeDt = ClsActivities.GetNode(NodeID, TID1);
                ViewState["NodeID"] = NodeDt.Rows[0]["NodeID"].ToString();
                txtPageTitle.Text = NodeDt.Rows[0]["PageTitle"].ToString();
                txtPageTitle1.Text = NodeDt.Rows[0]["PageTitle1"].ToString();
                txtPageTitle2.Text = NodeDt.Rows[0]["PageTitle2"].ToString();
                txtPageName.Text = NodeDt.Rows[0]["PagePath"].ToString();
                txtPagePath.Text = NodeDt.Rows[0]["NodeNavUrl"].ToString();
                Chkactivemenu.Checked = Convert.ToBoolean(NodeDt.Rows[0]["IsVisibleInMenu"]);
                bool IsParent = Convert.ToBoolean(NodeDt.Rows[0]["IsParent"]);
                CheckBox1.Checked = IsParent;
                if(!IsParent)
                {
                    drpMYBUSID.SelectedValue = NodeDt.Rows[0]["ParentID"].ToString();
                }
                btnAdd.Text = "Edit";
            }
            else if (e.CommandName == "btnDelete")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
            }

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
        public void GetShow()
        {

            lblMENU_NAME11s.Attributes["class"] = lblMENU_NAME21s.Attributes["class"] = lblMENU_NAME31s.Attributes["class"] = lblMYBUSID1s.Attributes["class"] = "control-label col-md-4  getshow";
             lblMENU_NAME12h.Attributes["class"] = lblMENU_NAME22h.Attributes["class"] = lblMENU_NAME32h.Attributes["class"]= lblMYBUSID2h.Attributes["class"] = "control-label col-md-4  gethide";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "ltr");

        }
        public void GetHide()
        {
             lblMENU_NAME11s.Attributes["class"] = lblMENU_NAME21s.Attributes["class"] = lblMENU_NAME31s.Attributes["class"] = lblDOC_PARENT1s.Attributes["class"] =  lblSMALLTEXT1s.Attributes["class"]   = lblMYBUSID1s.Attributes["class"] = "control-label col-md-4  gethide";
             lblMENU_NAME12h.Attributes["class"] = lblMENU_NAME22h.Attributes["class"] = lblMENU_NAME32h.Attributes["class"] = lblDOC_PARENT2h.Attributes["class"] =  lblSMALLTEXT2h.Attributes["class"]   = lblMYBUSID2h.Attributes["class"] = "control-label col-md-4  getshow";
            b.Attributes.Remove("dir");
            b.Attributes.Add("dir", "rtl");

        }
        public void RecieveLabel(string lang)
        {
            string str = "";
            string PID = ((ACMMaster)this.Master).getOwnPage();

            List<Database.TBLLabelDTL> List = ((ACMMaster)this.Master).Bindxml("ACM_FUNCTION_MST").Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();
            foreach (Database.TBLLabelDTL item in List)
            {

                if (lblMENU_NAME11s.ID == item.LabelID)
                    txtMENU_NAME11s.Text = lblMENU_NAME11s.Text = lblhMENU_NAME1.Text = item.LabelName;
                else if (lblMENU_NAME21s.ID == item.LabelID)
                    txtMENU_NAME21s.Text = lblMENU_NAME21s.Text = item.LabelName;
                else if (lblMENU_NAME31s.ID == item.LabelID)
                    txtMENU_NAME31s.Text = lblMENU_NAME31s.Text = item.LabelName;

                else if (lblSMALLTEXT1s.ID == item.LabelID)
                    txtSMALLTEXT1s.Text = lblSMALLTEXT1s.Text = item.LabelName;
              
              
                else if (lblMYBUSID1s.ID == item.LabelID)
                    txtMYBUSID1s.Text = lblMYBUSID1s.Text = item.LabelName;


                else if (lblMENU_NAME12h.ID == item.LabelID)
                    txtMENU_NAME12h.Text = lblMENU_NAME12h.Text = lblhMENU_NAME1.Text = item.LabelName;
                else if (lblMENU_NAME22h.ID == item.LabelID)
                    txtMENU_NAME22h.Text = lblMENU_NAME22h.Text = item.LabelName;
                else if (lblMENU_NAME32h.ID == item.LabelID)
                    txtMENU_NAME32h.Text = lblMENU_NAME32h.Text = item.LabelName;

                else if (lblSMALLTEXT2h.ID == item.LabelID)
                    txtSMALLTEXT2h.Text = lblSMALLTEXT2h.Text = item.LabelName;
               
             
              


              
                else
                    txtHeader.Text = lblHeader.Text = Label5.Text = item.LabelName;
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
  
       
        #endregion
        public void Clear()
        {
            //drpMENU_ID.SelectedIndex =0 ;
          
            //txtMENU_TYPE.Text = "";
            txtPageTitle.Text = "";
            txtPageTitle1.Text = "";
            txtPageTitle2.Text = "";
        
          
            txtPagePath.Text = "";
            //txtCRUP_ID.Text = "";
            //drpADDFLAGE.SelectedIndex =0 ;
            //drpEDITFLAGE.SelectedIndex =0 ;
            //drpDELFLAGE.SelectedIndex =0 ;
            //drpPRINTFLAGE.SelectedIndex =0 ;
            //drpAMIGLOBALE.SelectedIndex =0 ;
            //drpMYPERSONAL.SelectedIndex =0 ;
            txtPageName.Text = "";
            CheckBox1.Checked = false;
            Chkactivemenu.Checked = true;
            //drpICONPATH.SelectedValue = "";
         
           // drpMYBUSID.SelectedIndex = 0;
         
        }

        protected void CheckChange(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                drpMYBUSID.Enabled = true;
            }
            else
            {
                drpMYBUSID.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int ParentID = 0;
            if (CheckBox1.Checked == false)
            {
                ParentID = int.Parse(drpMYBUSID.SelectedValue.ToString());
            }
            if (btnAdd.Text == "AddNew")
            {

                Clear();
                btnAdd.Text = "Add";
                btnAdd.ValidationGroup = "submit";
            }

            else if (btnAdd.Text == "Add")
            {
               
                ClsActivities.SaveNode(txtPagePath.Text.Trim(), CheckBox1.Checked, ParentID, txtPagePath.Text.Trim(), txtPageTitle.Text.Trim(), txtPageTitle1.Text.Trim(), txtPageTitle2.Text.Trim(), Chkactivemenu.Checked, TID);
                Clear();
                btnAdd.Text = "AddNew";
                databind();
            }
            else
            {
                int NodeID = Convert.ToInt32(ViewState["NodeID"]);
                ClsActivities.EditNode(NodeID, txtPagePath.Text.Trim(), CheckBox1.Checked, ParentID, txtPagePath.Text.Trim(), txtPageTitle.Text.Trim(), txtPageTitle1.Text.Trim(), txtPageTitle2.Text.Trim(), Chkactivemenu.Checked);
                Clear();
                btnAdd.Text = "AddNew";
            }
            }
    }
}