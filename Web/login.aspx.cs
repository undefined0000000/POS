using Classes;
using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
        CallEntities DB = new CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                txtPass.Attributes["type"] = "password";

                if (Request.Cookies["acRememberPassword"] != null)
                {
                    if (Request.Cookies["acRememberPassword"].Value == "true")
                    {
                        if (Request.Browser.Cookies)
                        {
                            chkRememberPassword.Checked = true;
                            txtUser.Text = Request.Cookies["acUser"].Value;
                           // txtPass.Text = Request.Cookies["acPassword"].Value;
                            txttenent.Text = Request.Cookies["acTenant"].Value;

                            txtPass.Attributes.Add("autocomplete", "off");
                            

                        }
                    }
                }
            

            }
        }
       
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (chkRememberPassword.Checked)
                {
                    string acUser=txtUser.Text.ToString();
                    string acPassword = txtPass.Text.ToString();
                    string acTenant = txttenent.Text.ToString();
                    Response.Cookies["acRememberPassword"].Value = "true";
                    Response.Cookies["acRememberPassword"].Expires = DateTime.MaxValue;
                    Response.Cookies["acUser"].Value = acUser;
                    Response.Cookies["acUser"].Expires = DateTime.MaxValue;
                    Response.Cookies["acTenant"].Value = acTenant;
                    Response.Cookies["acTenant"].Expires = DateTime.MaxValue;
                    Response.Cookies["acPassword"].Value = acPassword;
                    Response.Cookies["acPassword"].Expires = DateTime.MaxValue;

                }
                else
                {
                    Response.Cookies["acRememberPassword"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["acUser"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["acTenant"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["acPassword"].Expires = DateTime.Now.AddDays(-1);

                }
            }
            catch (Exception ex)
            {
                lblusermatch.ForeColor = System.Drawing.Color.Red;
                lblusermatch.Text = ex.Message.ToString();
            }
           
            
            
            if(hideID.Value == "")
            {
              
            string Password1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(txtPass.Text);

                USER_MST CheckUserList = GlobleClass.EncryptionHelpers.LoginVerified(txttenent.Text, txtUser.Text, txtPass.Text);
                if (CheckUserList == null)
                {
                    lblusermatch.ForeColor = System.Drawing.Color.Red;
                    lblusermatch.Text = "Username and Password not match";
                    return;
                }
                lblusermatch.Text = "";
                DataTable dt= DAL.Get_login_Location(int.Parse(txttenent.Text), txtUser.Text, Password1);
                if(dt.Rows.Count == 0)
                {
                   
                    lblusermatch.ForeColor = System.Drawing.Color.Red;
                    lblusermatch.Text = "Location not Assigned";
                    return;
                }
            if (dt.Rows.Count ==1)
            {
                DAL.Edit_User_Location(int.Parse(txttenent.Text),int.Parse(dt.Rows[0][0].ToString()), txtUser.Text, Password1);
            }
           else
            {
                    drplocation.DataSource = dt;
                    drplocation.DataTextField = "LOCNAME1";
                    drplocation.DataValueField = "LOCATIONID";
                    drplocation.DataBind();
                    drplocation.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Loction--", "0"));
                    drplocation.Visible = true;
                    lbllocation.Visible = true;
                    Session["Password"] = txtPass.Text;

                    hideID.Value = "1";
                   

                    return;
            }
            }
            else if (hideID.Value == "1")
            {
                string a = drplocation.Text;
                string PasswordM = Classes.GlobleClass.EncryptionHelpers.Encrypt(txtPass.Text);
                DAL.Edit_User_Location(int.Parse(txttenent.Text), int.Parse(drplocation.SelectedValue.ToString()), txtUser.Text, PasswordM);
            }
            USER_MST UserList = GlobleClass.EncryptionHelpers.LoginVerified(txttenent.Text, txtUser.Text, txtPass.Text);
          
            if (UserList != null)
            {
                hideID.Value = "";
               
                Session["USER"] = UserList;
                int TID = Convert.ToInt32(txttenent.Text);
                Session["TerminalID"] = DAL.Get_login_Terminal(TID, UserList.LOCATION_ID);
                Session["SAFirstname"] = UserList.FIRST_NAME1.ToString();
                Session["LANGUAGE"] = "en-US";
                if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == UserList.TenentID).Count() == 1)
                {
                    var objMYCOMPANYSETUPs = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == UserList.TenentID);
                    Session["objMYCOMPANYSETUP"] = objMYCOMPANYSETUPs;
                }
                int Modulid = 0;
                //sahir
                if (DB.MODULE_MAP.Where(p => p.TenentID == TID && p.UserID == UserList.USER_ID).Count() > 0)
                {
                    Modulid = DB.MODULE_MAP.Single(p => p.UserID == UserList.USER_ID && p.TenentID == TID ).MODULE_ID;
                    Session["SiteModuleID"] = Modulid;
                }
                else
                {
                    Session["SiteModuleID"] = 39; 
                    //pnlErrorMsg.Visible = true;
                    //lblerrmsg.Text = "No Module for This User, please contact to Administrator...";
                   // return;
                }
               
                Database.POSCompSetup posclist = DB.POSCompSetups.SingleOrDefault(p => p.TenentID == TID);
                Database.POSLocSetup posLoclist = DB.POSLocSetups.SingleOrDefault(p => p.TenentID == TID && p.LocationID == 1);
                Database.POSTermSetup postermlist = DB.POSTermSetups.SingleOrDefault(p => p.TenentID == TID && p.LocationID ==1 && p.TerminalID == 1);
                Session["USER"] = UserList;                
                Session["POSCompSetup"] = posclist;
                Session["POSLocSetup"]  = posLoclist;
                Session["POSTermSetup"] = postermlist;
               
                
               
                Response.Redirect("Newdemo.aspx");
            }
            else
            {
                lblusermatch.ForeColor = System.Drawing.Color.Red;
                lblusermatch.Text = "Username and Password not match";
            }
        }

        public void adddayclose()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            string name = DB.USER_MST.Single(p => p.TenentID == TID && p.USER_ID == UID).FIRST_NAME;
            Database.DayClose objday = new Database.DayClose();
            objday.TenentID = TID;
            int ID = DB.DayCloses.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.DayCloses.Where(p => p.TenentID == TID).Max(p => p.ID) + 1) : 1;
            objday.ID = ID;
            objday.UserID = UID;
            objday.TrmID = "1";
            objday.ShiftID = 1;
            objday.Date = DateTime.Now;
            objday.OpAMT = 0;
            objday.ShiftSales = 0;
            objday.ShiftReturn = 0;
            objday.ShiftPurchase = 0;
            objday.ShiftCIH = 0;
            objday.VoucharAMT = 0;
            objday.ExpAMT = 0;
            objday.ChequeAMT = 0;
            objday.AMTDelivered = 0;
            objday.DeliveredTO = 0;
            objday.undeliverdAMT = 0;
            objday.RefNO = TID + UID + name + DateTime.Now;
            objday.Notes = "";
            objday.UploadDate = DateTime.Now.ToString();
            objday.Uploadby = name;
            objday.SynID = 9;
            objday.ShiftStutas = 1;
            objday.Employee = 1;
            DB.DayCloses.AddObject(objday);
            DB.SaveChanges();
            Session["ID"] = ID;
        }
    }
}