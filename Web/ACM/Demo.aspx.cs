using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using Classes;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Web.ACM
{
    public partial class Demo : System.Web.UI.Page
    {
        List<Navigation> ChoiceList = new List<Navigation>();
        Database.CallEntities DB = new Database.CallEntities();
        int TID = 0;
        int userID = 0;
        int LocationID = 0;
        SqlConnection con;
        SqlCommand command2 = new SqlCommand();
        protected void Page_Init(object sender, EventArgs e)
        {

            CheckLogin();
        }
        public void CheckLogin()
        {
            if (Session["USER"] == null || Session["USER"] == "0")
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Parimal
            //string lFirstName = "";
            //USER_MST UserList1 = GlobleClass.EncryptionHelpers.LoginVerified("6", "HealthBar", "test@1");
            //lFirstName = UserList1.FIRST_NAME.ToString() + " " + UserList1.LAST_NAME.ToString();
            //Session["USER"] = UserList1;
            //Session["LANGUAGE"] = "en-US";// DDLLanguage.SelectedValue;
            //Session["Firstname"] = lFirstName.ToString();
            //Session["SiteModuleID"] = 2054;
            //Session["SAFirstname"] = UserList1.FIRST_NAME1.ToString();
            //HttpCookie aCookie = new HttpCookie("tgadmin");
            //aCookie.Values["UserName"] = UserList1.USER_ID.ToString();
            //aCookie.Values["CLANGUAGE"] = "en-US";// DDLLanguage.SelectedValue;
            //if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == UserList1.TenentID).Count() == 1)
            //{
            //    var objMYCOMPANYSETUPs = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == UserList1.TenentID);
            //    Session["objMYCOMPANYSETUP"] = objMYCOMPANYSETUPs;
            //}
            ////aCookie.Values["Password"] = txtPass.Text.ToString();
            ////aCookie.Values["TenetID"] = txtTenantId.Text.ToString();
            ////aCookie.Values["username"] = dsfactory.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsfactory.Tables[0].Rows[0]["LastName"].ToString();
            //aCookie.Expires = DateTime.Now.AddMinutes(30);
            //Response.Cookies.Add(aCookie);

            //Parimal


            TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (Session["USER"] != null && string.IsNullOrEmpty(Session["USER"].ToString()))//error
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CheckMaitanance();
                this.ifrm.Attributes.Add("onload", "setIframeHeight(document.getElementById('" + ifrm.ClientID + "'));");
                if (HeadOffieName() == "")
                {
                    if (Session["SAFirstname"] == null)
                        Session.Abandon();
                    //Response.Redirect("Login.aspx");
                }
                else
                {
                    HttpCookie aCookie = Request.Cookies["tgadmin"];
                    aCookie = Request.Cookies["tgadmin"];
                    int UID = Convert.ToInt32(aCookie.Values["UserName"]);
                    string Lang = aCookie.Values["CLANGUAGE"];
                    int Modulid = DB.MODULE_MAP.Single(p =>p.TenentID==TID && p.UserID == UID && p.SP1Name == "DefaultSet").MODULE_ID;
                    USER_MST UserList = DB.USER_MST.Single(p => p.USER_ID == UID && p.TenentID == TID);
                    Session["USER"] = UserList;
                    Session["Firstname"] = UserList.FIRST_NAME.ToString();
                    Session["SiteModuleID"] = Modulid;
                    Session["LANGUAGE"] = Lang;
                }
                if (Session["USER"] == null || Session["USER"] == "0")
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");

                }

                if (TID == 7)
                {
                    linkCheckIn.Visible = false;
                    linkCheckOut.Visible = false;
                    linkLanguage.Visible = false;
                    linkFinalUpload.Visible = false;
                    lintenet.Visible = false;
                }
                userID = ((USER_MST)Session["USER"]).USER_ID;
                LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                if (Session["SAFirstname"] != null)
                {
                    string Username = Session["SAFirstname"].ToString();
                    lblFirstName.Text = Username;
                }
                else
                {
                    string UserName = ((USER_MST)Session["USER"]).FIRST_NAME;
                    lblFirstName.Text = UserName.ToString();
                }


                //bindModule();


                Session["Previous"] = Session["Current"];
                Session["Current"] = Request.RawUrl;
                if (Session["SiteModuleID"] != null)
                {
                    int MID = Convert.ToInt32(Session["SiteModuleID"]);

                    //GlobleClass.DeleteTempUser(TID, userID, LocationID, MID);
                    //GlobleClass.getMenuGloble(TID, userID, LocationID, MID);

                    menubind(MID);
                    if(DB.MODULE_MST.Where(p=>p.Module_Id==MID && p.TenentID==TID).Count()>0)
                    {
                        lblmodule.Text = "Module:" + DB.MODULE_MST.Single(p => p.Module_Id == MID && p.TenentID == TID).Module_Name;
                    }
                    

                }
                //int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                //string NewLogText = ((USER_MST)Session["USER"]).FIRST_NAME;
                //string UID = ((USER_MST)Session["USER"]).LAST_NAME;
                //int CrupID = Convert.ToInt32(((USER_MST)Session["USER"]).CRUP_ID);
                //string table = ((USER_MST)Session["USER"]).FIRST_NAME;

                BindDdl();
                int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                string UNAME = ((USER_MST)Session["USER"]).FIRST_NAME;
                int LID=((USER_MST)Session["USER"]).LOCATION_ID;
                //Hawally
                if(DB.TBLLOCATIONs.Where(p => p.TenentID == TID && p.LOCATIONID == LID).Count() > 0)
                {
                    string Location1 = DB.TBLLOCATIONs.Single(p => p.TenentID == TID && p.LOCATIONID == LID).LOCNAME1;
                    ViewState["Location"] = Location1;
                }
                else
                {
                    string Location1 = "Hawally";
                    ViewState["Location"] = Location1;
                }
                string Location = ViewState["Location"].ToString();
                lbltentid.Text = "TID:" + TID.ToString() +" : " +Location+ "\n";
                lblrole.Text = "Role:" + DB.ROLE_MST.Single(p => p.ROLE_ID == UTID && p.TenentID == TID).ROLE_NAME1;
                if (TID == 0)
                {
                    lbltentid.Visible = false;
                    lblusername.Visible = true;
                }


                lblusername.Text = "User:" + UNAME.ToString();

                //GlobleClass.UpdateLog(NewLogText, CrupID, table, UserName, TID,UID, LID);

                // For Attandance
                int UserID = GetLogginID();
                DateTime TodayDate = DateTime.Now.Date;
                List<Attandance> ObjList = (from item in DB.Attandances where item.UserID == UserID && item.InTime.Value.Year == TodayDate.Year && item.InTime.Value.Month == TodayDate.Month && item.InTime.Value.Day == TodayDate.Day select item).ToList();
                if (ObjList.Where(p => p.OutTime == null).Count() > 0)
                {
                    linkCheckIn.Visible = false;
                    //btnSignin.CssClass = "stdbtn";

                    if (TID == 7)
                        linkCheckOut.Visible = false;
                    else
                        linkCheckOut.Visible = true;
                    //btnSignOut.CssClass = "stdbtn btn_blue";
                    //linkCheckIn.BackColor = Color.Green;
                }
                else
                {
                    if (ObjList.Count() == 0)
                    {
                        Attandance Obj = new Attandance();
                        Obj.UserID = GetLogginID();
                        Obj.InTime = DateTime.Now;
                        Obj.isAbsent = false;
                        Obj.Deleted = true;
                        Obj.Active = true;
                        DB.Attandances.AddObject(Obj);
                        DB.SaveChanges();
                        linkCheckIn.Visible = false;
                        linkCheckOut.Visible = true;
                    }
                    else
                    {
                        linkCheckIn.Visible = true;
                        //btnSignin.CssClass = "stdbtn btn_red";
                        //btnSignOut.CssClass = "stdbtn";
                        //linkCheckIn.BackColor = Color.Red;
                        //btnSignOut.ForeColor = Color.Black;
                        linkCheckOut.Visible = false;
                    }
                }
                string Loggo = Classes.EcommAdminClass.Logo(TID);
                LOGOTODISPLAY.ImageUrl = "../assets/" + Loggo;
                //var DisplayLOGO = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == TID).LogotoDisplay;
                //if (DisplayLOGO != null)
                //{
                //    LOGOTODISPLAY.ImageUrl = "../assets/" + DisplayLOGO;
                //}

            }
        }
        public void CheckMaitanance()
        {
            try
            {
                if (!File.Exists(Server.MapPath("test.txt")))
                {
                    File.WriteAllText(Server.MapPath("test.txt"), "welcome"+ DateTime.Now.ToString());
                }
                else
                {
                    if (File.GetLastWriteTime(Server.MapPath("test.txt")).Day != DateTime.Now.Day)
                    {
                        string qry = "";
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
                        List<Database.TBLMaintanance> listTBLMaintanances = DB.TBLMaintanances.Where(p => p.Active == true && p.SwichType==1).ToList();
                        foreach(Database.TBLMaintanance item in listTBLMaintanances)
                            qry += item.Query;
                        command2 = new SqlCommand(qry, con);
                        con.Open();
                        command2.ExecuteReader();
                        con.Close();
                        File.WriteAllText(Server.MapPath("test.txt"), "welcome" + DateTime.Now.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                File.WriteAllText(Server.MapPath("test.txt"), "welcome" + DateTime.Now.ToString() + "Erorr : "+ ex.Message);
            }
        }
        public void BindDdl()
        {
            ddltenet.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y").GroupBy(p => p.TenentID).Select(p => p.FirstOrDefault());
            ddltenet.DataTextField = "TenentID";
            ddltenet.DataValueField = "TenentID";
            ddltenet.DataBind();
            ddltenet.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public string HeadOffieName()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies["tgadmin"] != null)
                {
                    return HttpContext.Current.Request.Cookies["tgadmin"]["UserName"];
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        public void menubind(int ModuleID)
        {
            

            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int ROLLID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);

            if(DB.MODULE_MST.Where(p=>p.TenentID==TID && p.Module_Id==ModuleID).Count()>0)
            {
                string ModielName = DB.MODULE_MST.Single(p => p.Module_Id == ModuleID && p.TenentID == TID).Module_Name;
                lblmodule.Text = "Module:" + ModielName;

                //int menu = DB.tempUsers.FirstOrDefault(p => p.TenentID == TID && p.MODULE_ID == ModuleID).MENUID;
                //string privilageFOR = DB.PRIVILAGE_MENU.SingleOrDefault(p => p.TenentID == TID && p.MENU_ID == menu).PRIVILAGEFOR.ToString();

                //int MTID = Convert.ToInt32(DB.MODULE_MST.SingleOrDefault(p => p.Module_Id == ModuleID).TenentID);
                //ViewState["MTID"] = MTID;
                //List<Database.FUNCTION_MST> List = DB.FUNCTION_MST.Where(p => p.MODULE_ID == ModuleID && p.TenentID == MTID).ToList();
                //if (List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TenentID == MTID).Count() > 0)
                //{
                //    //int MID = Convert.ToInt32(Request.QueryString["MID"]);
                //    ltsMenu.DataSource = List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TenentID == MTID).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                //    ltsMenu.DataBind();

                //    int MasterID = Convert.ToInt32(List.First(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator").MASTER_ID);
                //    lstMaster.DataSource = List.Where(p => p.MASTER_ID == MasterID && p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TenentID == MTID);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                //    lstMaster.DataBind();
                //}
                //else
                //{
                //    lstMaster.DataSource = List.Where(p => p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TenentID == MTID && p.MODULE_ID == ModuleID).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                //    lstMaster.DataBind();
                //}
                //lstisGloble.DataSource = List.Where(p => p.AMIGLOBALE == 1 && p.TenentID == MTID && p.MODULE_ID == ModuleID);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                //lstisGloble.DataBind();


                ViewState["MTID"] = TID;
                List<Database.tempUser> List = DB.tempUsers.Where(p => p.MODULE_ID == ModuleID && p.TenentID == TID && p.LocationID == LID && p.ACTIVEMENU == true && p.ROLE_ID == ROLLID).OrderBy(p => p.MENU_ORDER).ToList();
                //btnHome.PostBackUrl = "' onclick=\"return loadIframe('ifrm', " + List[0].LINK + ")\"";
                if (List.Count() > 0)
                {
                    lblDashboard.Text = " <a href=\"" + List[0].LINK + "\" onclick=\"return loadIframe('ifrm', this.href)\"><i class=\"icon-home\"></i><span class=\"title\">" + List[0].MENU_NAME1 + "</span> </a>";
                    ifrm.Attributes.Add("src", List[0].LINK);

                    if (List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TenentID == TID && p.ACTIVEMENU == true).Count() > 0)
                    {
                        //int MID = Convert.ToInt32(Request.QueryString["MID"]);
                        ltsMenu.DataSource = List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TenentID == TID && p.ACTIVEMENU == true).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                        ltsMenu.DataBind();

                        int MasterID = Convert.ToInt32(List.First(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.ACTIVEMENU == true).MASTER_ID);
                        lstMaster.DataSource = List.Where(p => p.MASTER_ID == MasterID && p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TenentID == TID && p.ACTIVEMENU == true);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                        lstMaster.DataBind();
                    }
                    else
                    {
                        lbldiscription.Text = "Your Login / password is Expired , please contact to Administrator...";
                        ModalPopupExtender1.Show();
                        //lstMaster.DataSource = List.Where(p => p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TenentID == TID && p.MODULE_ID == ModuleID && p.ACTIVEMENU == true).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                        //lstMaster.DataBind();
                    }
                    lstisGloble.DataSource = List.Where(p => p.AMIGLOBALE == 1 && p.TenentID == TID && p.MODULE_ID == ModuleID && p.ACTIVEMENU == true);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                    lstisGloble.DataBind();
                }
                else
                {
                    //string message = "alert('This " + ModielName + " No Menu')";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    lbldiscription.Text = "This " + ModielName + " has No Fuction";
                    ModalPopupExtender1.Show();
                }
            }

            
            List<Database.tempUser> ModulList = DB.tempUsers.Where(p => p.TenentID == TID && p.ROLE_ID == ROLLID).ToList();
            List<Database.MODULE_MST> ListMST = new List<MODULE_MST>();
            if (ModulList.Where(p => p.TenentID == TID && p.ROLE_ID == ROLLID).Count() > 0)
            {
                var List1 = ModulList.GroupBy(p => p.MODULE_ID).Select(p => p.FirstOrDefault()).ToList();

                foreach (Database.tempUser items in List1)
                {
                    if (TID == 0)
                    {
                        if (DB.MODULE_MST.Where(p => p.TenentID == TID && p.Module_Id == items.MODULE_ID).Count() > 0)
                        {
                            int perent = Convert.ToInt32(DB.MODULE_MST.Single(p => p.TenentID == TID && p.Module_Id == items.MODULE_ID).Parent_Module_id);
                            Database.MODULE_MST objMST = DB.MODULE_MST.Single(p => p.ACTIVE_FLAG == "Y" && p.Module_Id == perent && p.TenentID == TID);
                            ListMST.Add(objMST);
                        }
                    }
                    else
                    {
                        if (DB.MODULE_MST.Where(p => p.TenentID == TID && p.Module_Id == items.MODULE_ID).Count() > 0)
                        {
                            int perent = Convert.ToInt32(DB.MODULE_MST.Single(p => p.TenentID == TID && p.Module_Id == items.MODULE_ID).Parent_Module_id);
                            if (perent != 12)
                            {
                                if (DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Module_Id == perent && p.TenentID == TID).Count() > 0)
                                {
                                    Database.MODULE_MST objMST = DB.MODULE_MST.Single(p => p.ACTIVE_FLAG == "Y" && p.Module_Id == perent && p.TenentID == TID);
                                    ListMST.Add(objMST);
                                }
                            }
                        }
                    }
                }
                lstmodule.DataSource = ListMST.GroupBy(p=>p.Module_Id).Select(p=>p.FirstOrDefault()).ToList();// DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TenentID == TID && p.Module_Id != 12);
                lstmodule.DataBind();
            }
            //if (List.Where(p => p.TenentID == TID && p.ROLE_ID == ROLLID).Count() > 0)
            //{
            //    foreach (Database.tempUser Tempitem in List)
            //    {
            //        //int tempModuleID = Convert.ToInt32(DB.tempUsers.SingleOrDefault(p => p.TenentID == TID && p.MODULE_ID == Tempitem.MODULE_ID).MODULE_ID);                    
            //        int pmoduleid = Convert.ToInt32(DB.MODULE_MST.Single(p => p.TenentID == TID && p.Module_Id == ModuleID).Parent_Module_id);
            //        lstmodule.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TenentID == TID && p.Module_Id != 12 && p.Module_Id == pmoduleid);
            //        lstmodule.DataBind();
            //    }
            //}
        }
        public void bindModule()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
            if (TID == 0)
            {
                lstmodule.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TenentID == TID);
                lstmodule.DataBind();
            }
            else
            {
                lstmodule.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TenentID == TID && p.Module_Id != 12);
                lstmodule.DataBind();
            }
        }
        protected void lstmodule_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblHide = (Label)e.Item.FindControl("lblHide");
                int MID = Convert.ToInt32(lblHide.Text);
                ListView ltsProduct = (ListView)e.Item.FindControl("lstsubmodule");
                ltsProduct.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == MID && p.TenentID == TID);
                ltsProduct.DataBind();
                //menubind(MID);
            }

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?logout=logout");
        }
        //public string GetLink(int menuID)
        //{// <span class="title"><%# Eval("MENU_NAME1")%> </span></a> <ul class="sub-menu" style="display: none;">
        //    string menustr = "";
        //    int MTID = Convert.ToInt32(ViewState["MTID"]);
        //    string OnOff = "";
        //    if (DB.FUNCTION_MST.Where(p => p.MENU_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1).Count() > 0)
        //    {

        //        var obj = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1);
        //        OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
        //        string MID1 = obj.MASTER_ID.ToString();
        //        string MenuID1 = obj.MENU_ID.ToString();
        //        string ENCMID1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID1 + "~" + MenuID1).ToString();
        //        string itemstr1 = obj.URLREWRITE.ToString().Contains("?") ? obj.URLREWRITE.ToString() + "&MID=" + ENCMID1 : obj.URLREWRITE.ToString() + "?MID=" + ENCMID1;
        //        if (obj.MENU_LOCATION == "Separator")
        //        {
        //            OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
        //            menustr = "<a href='#'><i class='" + obj.ICONPATH + "'></i><span class='title' >" + obj.MENU_NAME1 + "</span><span class='arrow' style='color: #000;'></span><span class='badge badge" + OnOff + " </span></a>";
        //            menustr += " <ul class='sub-menu' style='display: none;'>";
        //            List<Database.FUNCTION_MST> itemList = DB.FUNCTION_MST.Where(p => p.MASTER_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1).OrderBy(a => a.MENU_ORDER).ToList();

        //            if (itemList.Count() > 0)
        //            {
        //                foreach (Database.FUNCTION_MST item in itemList)
        //                {
        //                    string MID = item.MASTER_ID.ToString();
        //                    string MenuID = item.MENU_ID.ToString();
        //                    string ENCMID = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID + "~" + MenuID).ToString();
        //                    OnOff = item.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
        //                    List<Database.FUNCTION_MST> itemList1 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item.MENU_ID && p.TenentID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
        //                    string itemstr = item.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;
        //                    if (itemList1.Count() > 0)
        //                    {
        //                        menustr += "<li class='active'><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item.ICONPATH + "'></i><span class='title' >" + item.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
        //                        menustr += "<ul class='sub-menu' style='display: none;'>";
        //                        foreach (Database.FUNCTION_MST item1 in itemList1)
        //                        {
        //                            OnOff = item1.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
        //                            List<Database.FUNCTION_MST> itemList2 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item1.MENU_ID && p.TenentID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
        //                            string item1str = item1.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;
        //                            if (itemList2.Count() > 0)
        //                            {
        //                                menustr += "<li ><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item1.ICONPATH + "'></i><span class='title' >" + item1.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
        //                                menustr += "<ul class='sub-menu' >";
        //                                foreach (Database.FUNCTION_MST item2 in itemList2)
        //                                {
        //                                    string item2str = item2.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;
        //                                    OnOff = item2.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
        //                                    menustr += "<li><a href='" + item2str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item2.ICONPATH + "'></i><span class='title' >" + item2.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
        //                                }
        //                                menustr += Displaysubmenu1(menuID);
        //                                menustr += "</li>";
        //                            }
        //                            else
        //                            {
        //                                menustr += "<li ><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item1.ICONPATH + "'></i><span class='title' >" + item1.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
        //                            }
        //                        }
        //                        menustr += Displaysubmenu1(menuID);
        //                        menustr += "</li>";
        //                    }
        //                    else
        //                    {
        //                        menustr += "<li ><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item.ICONPATH + "'></i><span class='title' >" + item.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
        //                    }
        //                }

        //            }
        //        }
        //        else
        //        {
        //            menustr = "<a href='" + itemstr1 + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='icon-home'></i><span class='title'>" + obj.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a>";
        //        }
        //    }

        //    return menustr;
        //}

        public string GetLink(int menuID)
        {// <span class="title"><%# Eval("MENU_NAME1")%> </span></a> <ul class="sub-menu" style="display: none;">
            string menustr = "";
            int MTID = Convert.ToInt32(ViewState["MTID"]);
            string OnOff = "";
            if (DB.FUNCTION_MST.Where(p => p.MENU_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1).Count() > 0)
            {

                var obj = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1);
                OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";
                string MID1 = obj.MASTER_ID.ToString();
                string MenuID1 = obj.MENU_ID.ToString();
                string ENCMID1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID1 + "~" + MenuID1).ToString();
                string itemstr1 = obj.URLREWRITE.ToString().Contains("?") ? obj.URLREWRITE.ToString() + "&MID=" + ENCMID1 : obj.URLREWRITE.ToString() + "?MID=" + ENCMID1;
                if (obj.MENU_LOCATION == "Separator")
                {
                    OnOff = obj.ACTIVE_FLAG == 1 && obj.ACTIVEMENU == true && obj.MENUDATE.Value >= DateTime.Now.Date ? "-success'>&nbsp;" : "-danger'>&nbsp";
                    menustr = "<a href='#'><i class='" + obj.ICONPATH + "'></i><span class='title' >" + obj.MENU_NAME1 + "</span><span class='arrow' style='color: #000;'></span><span class='badge badge" + OnOff + " </span></a>";
                    menustr += " <ul class='sub-menu' style='display: none;'>";
                    List<Database.FUNCTION_MST> itemList = DB.FUNCTION_MST.Where(p => p.MASTER_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1).OrderBy(a => a.MENU_ORDER).ToList();
                    if (OnOff == "-success'>&nbsp;")
                    {
                        if (itemList.Count() > 0)
                        {
                            foreach (Database.FUNCTION_MST item in itemList)
                            {
                                string itemstr = "";
                                string MID = item.MASTER_ID.ToString();
                                string MenuID = item.MENU_ID.ToString();
                                string ENCMID = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID + "~" + MenuID).ToString();
                                OnOff = item.ACTIVE_FLAG == 1 && item.ACTIVEMENU == true && item.MENUDATE.Value >= DateTime.Now.Date ? "-success'>&nbsp;" : "-danger'>&nbsp";
                                List<Database.FUNCTION_MST> itemList1 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item.MENU_ID && p.TenentID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
                                itemstr = OnOff == "-success'>&nbsp;" ? item.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID : "/ACM/Expired1.aspx";
                                //    itemstr = item.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;                          
                                if (itemList1.Count() > 0)
                                {
                                    menustr += "<li class='active'><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item.ICONPATH + "'></i><span class='title' >" + item.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
                                    menustr += "<ul class='sub-menu' style='display: none;'>";
                                    foreach (Database.FUNCTION_MST item1 in itemList1)
                                    {
                                        OnOff = item1.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";
                                        List<Database.FUNCTION_MST> itemList2 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item1.MENU_ID && p.TenentID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
                                        string item1str = item1.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;
                                        if (itemList2.Count() > 0)
                                        {
                                            menustr += "<li ><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item1.ICONPATH + "'></i><span class='title' >" + item1.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
                                            menustr += "<ul class='sub-menu' >";
                                            foreach (Database.FUNCTION_MST item2 in itemList2)
                                            {
                                                string item2str = item2.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString() + "&MID=" + ENCMID : item.URLREWRITE.ToString() + "?MID=" + ENCMID;
                                                OnOff = item2.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";
                                                menustr += "<li><a href='" + item2str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item2.ICONPATH + "'></i><span class='title' >" + item2.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
                                            }
                                            menustr += Displaysubmenu1(menuID);
                                            menustr += "</li>";
                                        }
                                        else
                                        {
                                            menustr += "<li ><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item1.ICONPATH + "'></i><span class='title' >" + item1.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
                                        }
                                    }
                                    menustr += Displaysubmenu1(menuID);
                                    menustr += "</li>";
                                }
                                else
                                {
                                    menustr += "<li ><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item.ICONPATH + "'></i><span class='title' >" + item.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a></li>";
                                }
                            }

                        }
                    }

                }
                else
                {
                    menustr = "<a href='" + itemstr1 + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='icon-home'></i><span class='title'>" + obj.MENU_NAME1 + "</span><span class='badge badge" + OnOff + " </span></a>";
                }
            }

            return menustr;
        }
        public string Displaysubmenu1(int menuID)
        {
            int MTID = Convert.ToInt32(ViewState["MTID"]);
            var obj = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == menuID && p.TenentID == MTID && p.ACTIVE_FLAG == 1);
            if (obj.MENU_LOCATION == "Left Menu")
                return "";
            else
                return " </ul> ";
        }
        public string getclass(string link)
        {
            string modulestr = Session["ModuleID"].ToString();
            if (modulestr == link)
            {
                return "class='active'";
            }
            else
            {
                if (Page.Request.Path.Contains(link))
                {
                    Session["ModuleID"] = link;
                    return "class='active'";
                }
                else
                {
                    return "";
                }
            }


        }
        protected void lstsubmodule_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "LinkModule_Id")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                Session["SiteModuleID"] = ID;
                menubind(ID);
            }
        }
        protected void linkFinalUpload_Click(object sender, EventArgs e)
        {
            refreshCurrentpage();
        }
        public void refreshCurrentpage()
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TID = Convert.ToInt32(ddltenet.SelectedValue);
            ddllocation.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenentID == TID);
            ddllocation.DataTextField = "LOCNAME1";
            ddllocation.DataValueField = "LOCATIONID";
            ddllocation.DataBind();
            ddllocation.Items.Insert(0, new ListItem("---Select---", "0"));
            ModalPopupExtender5.Show();
        }

        protected void linkMulticoler_Click(object sender, EventArgs e)
        {
            List<USER_MST> ast = new List<USER_MST>();
            int TID = Convert.ToInt32(ddltenet.SelectedValue);
            int LID = Convert.ToInt32(ddllocation.SelectedValue);
            int UID = ((USER_MST)Session["USER"]).USER_ID;
            USER_MST objUser = DB.USER_MST.Single(p => p.USER_ID == UID);
            USER_MST obj = new USER_MST();
            obj.TenentID = TID;
            obj.LOCATION_ID = LID;
            obj.USER_ID = objUser.USER_ID;
            obj.CRUP_ID = objUser.CRUP_ID;
            obj.FIRST_NAME = objUser.FIRST_NAME;
            obj.LAST_NAME = objUser.LAST_NAME;
            obj.FIRST_NAME1 = objUser.FIRST_NAME1;
            obj.LAST_NAME1 = objUser.LAST_NAME1;
            obj.FIRST_NAME2 = objUser.FIRST_NAME2;
            obj.LAST_NAME2 = objUser.LAST_NAME2;
            obj.LOGIN_ID = objUser.LOGIN_ID;
            obj.PASSWORD = objUser.PASSWORD;
            obj.USER_TYPE = objUser.USER_TYPE;
            obj.REMARKS = objUser.REMARKS;
            obj.ACTIVE_FLAG = objUser.ACTIVE_FLAG;
            obj.LAST_LOGIN_DT = objUser.LAST_LOGIN_DT;
            obj.USER_DETAIL_ID = objUser.USER_DETAIL_ID;
            obj.ACC_LOCK = objUser.ACC_LOCK;
            obj.FIRST_TIME = objUser.FIRST_TIME;
            obj.PASSWORD_CHNG = objUser.PASSWORD_CHNG;
            obj.THEME_NAME = objUser.THEME_NAME;
            obj.APPROVAL_DT = objUser.APPROVAL_DT;
            obj.VERIFICATION_CD = objUser.VERIFICATION_CD;
            obj.EmailAddress = objUser.EmailAddress;
            obj.Till_DT = objUser.Till_DT;
            obj.IsSignature = objUser.IsSignature;
            obj.SignatureImage = objUser.SignatureImage;
            obj.Avtar = objUser.Avtar;
            obj.CompId = objUser.CompId;
            ast.Add(obj);
            Session["USER"] = ast;
            var LIST = ((List<USER_MST>)Session["USER"]).ToList();
        }

        public int GetLogginID()
        {
            return Convert.ToInt32(((Database.USER_MST)Session["USER"]).USER_ID);
        }
        protected void linkCheckIn_Click(object sender, EventArgs e)
        {

            Attandance Obj = new Attandance();
            Obj.UserID = GetLogginID();
            Obj.InTime = DateTime.Now;
            Obj.isAbsent = false;
            Obj.Deleted = true;
            Obj.Active = true;
            DB.Attandances.AddObject(Obj);
            DB.SaveChanges();
            linkCheckIn.Visible = false;
            linkCheckOut.Visible = true;
            //linkCheckOut.CssClass = "stdbtn btn_blue";
            //linkCheckIn.CssClass = "stdbtn";
            //linkCheckIn.ForeColor = Color.Black;
            ifrm.Attributes.Add("src", "/CRM/Attendance.aspx");

        }

        protected void linkCheckOut_Click(object sender, EventArgs e)
        {
            int UserID = GetLogginID();
            DateTime TodayDate = DateTime.Now.Date;
            List<Attandance> ObjList = (from item in DB.Attandances where item.UserID == UserID && item.InTime.Value.Year == TodayDate.Year && item.InTime.Value.Month == TodayDate.Month && item.InTime.Value.Day == TodayDate.Day && item.OutTime == null select item).ToList();
            if (ObjList.Count() > 0)
            {
                int AttandanceID = ObjList[0].ID;
                Attandance Obj = DB.Attandances.Single(p => p.ID == AttandanceID);
                Obj.UserID = UserID;
                Obj.OutTime = DateTime.Now;
                DB.SaveChanges();
                linkCheckIn.Visible = true;
                linkCheckOut.Visible = false;
                //linkCheckIn.CssClass = "stdbtn btn_red";
                //linkCheckOut.CssClass = "stdbtn";
                //linkCheckOut.ForeColor = Color.Black;
                ifrm.Attributes.Add("src", "/CRM/Attendance.aspx");
            }
        }

        
    }
}