using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using Classes;
using System.Data;
namespace Web.ACM
{
    public partial class Demot : System.Web.UI.Page
    {
        List<Navigation> ChoiceList = new List<Navigation>();
        Database.CallEntities DB = new Database.CallEntities();
        int TID = 0;
        int userID = 0;
        int LocationID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {

                if (HeadOffieName() == "")
                {
                    if (Session["SAFirstname"]==null)
                        Session.Abandon();
                    //Response.Redirect("Login.aspx");
                }
                else
                {
                    HttpCookie aCookie = Request.Cookies["tgadmin"];
                    int UID = Convert.ToInt32(aCookie.Values["UserName"]);
                    string Lang = aCookie.Values["CLANGUAGE"];
                    int Modulid = DB.MODULE_MAP.Single(p => p.UserID == UID).MODULE_ID;
                    USER_MST UserList = DB.USER_MST.Single(p => p.USER_ID == UID);
                    Session["USER"] = UserList;
                    Session["Firstname"] = UserList.FIRST_NAME.ToString();
                    Session["SiteModuleID"] = Modulid;
                    Session["LANGUAGE"] = Lang;
                }
                if (Session["USER"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");

                }

                TID = Convert.ToInt32(((USER_MST)Session["USER"]).TENANT_ID);
                userID = ((USER_MST)Session["USER"]).USER_ID;
                LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                if(Session["SAFirstname"]!=null)
                {
                    string Username = Session["SAFirstname"].ToString();
                    lblFirstName.Text = Username;
                }
                else
                {
                    string UserName = ((USER_MST)Session["USER"]).FIRST_NAME;
                    lblFirstName.Text = UserName.ToString();
                }
                

                bindModule();


                Session["Previous"] = Session["Current"];
                Session["Current"] = Request.RawUrl;
                if (Session["SiteModuleID"] != null)
                {
                    int MID = Convert.ToInt32(Session["SiteModuleID"]);

                    //GlobleClass.DeleteTempUser(TID, userID, LocationID, MID);
                    // GlobleClass.getMenuGloble(TID, userID, LocationID, MID);

                    menubind(MID);
                    lblmodule.Text = "Module:"+DB.MODULE_MST.Single(p => p.Module_Id == MID&&p.TENANT_ID==TID).Module_Name;

                }
                //int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                //string NewLogText = ((USER_MST)Session["USER"]).FIRST_NAME;
                //string UID = ((USER_MST)Session["USER"]).LAST_NAME;
                //int CrupID = Convert.ToInt32(((USER_MST)Session["USER"]).CRUP_ID);
                //string table = ((USER_MST)Session["USER"]).FIRST_NAME;

                BindDdl();
               int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
               string UNAME = ((USER_MST)Session["USER"]).FIRST_NAME;
                lbltentid.Text = "TID:"+TID.ToString()+"\n";
                lblrole.Text = "Role:" + DB.ROLE_MST.Single(p => p.ROLE_ID == UTID && p.TENANT_ID==TID).ROLE_NAME1;
                if (TID == 0)
                {
                    lbltentid.Visible = false;
                    lblusername.Visible = true;
                }
                   

                lblusername.Text = "User:" + UNAME.ToString();
                
                //GlobleClass.UpdateLog(NewLogText, CrupID, table, UserName, TID,UID, LID); 
            }
        }
        public void BindDdl()
        {
            ddltenet.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y").GroupBy(p => p.TenantID).Select(p => p.FirstOrDefault());
            ddltenet.DataTextField = "TenantID";
            ddltenet.DataValueField = "TenantID";
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
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TENANT_ID);
            string ModielName = DB.MODULE_MST.Single(p => p.Module_Id == ModuleID && p.TENANT_ID == TID).Module_Name;
            lblmodule.Text = "Module:" + ModielName;
           
            //int MTID = Convert.ToInt32(DB.MODULE_MST.SingleOrDefault(p => p.Module_Id == ModuleID).TENANT_ID);
            //ViewState["MTID"] = MTID;
            //List<Database.FUNCTION_MST> List = DB.FUNCTION_MST.Where(p => p.MODULE_ID == ModuleID && p.TENANT_ID == MTID).ToList();
            //if (List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TENANT_ID == MTID).Count() > 0)
            //{
            //    //int MID = Convert.ToInt32(Request.QueryString["MID"]);
            //    ltsMenu.DataSource = List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TENANT_ID == MTID).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
            //    ltsMenu.DataBind();

            //    int MasterID = Convert.ToInt32(List.First(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator").MASTER_ID);
            //    lstMaster.DataSource = List.Where(p => p.MASTER_ID == MasterID && p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TENANT_ID == MTID);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
            //    lstMaster.DataBind();
            //}
            //else
            //{
            //    lstMaster.DataSource = List.Where(p => p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TENANT_ID == MTID && p.MODULE_ID == ModuleID).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
            //    lstMaster.DataBind();
            //}
            //lstisGloble.DataSource = List.Where(p => p.AMIGLOBALE == 1 && p.TENANT_ID == MTID && p.MODULE_ID == ModuleID);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
            //lstisGloble.DataBind();

          
            ViewState["MTID"] = TID;
            List<Database.tempUser> List = DB.tempUsers.Where(p => p.MODULE_ID == ModuleID && p.TENANT_ID == TID && p.LocationID == LID && p.ACTIVEMENU==true).OrderBy(p=>p.MENU_ORDER).OrderBy(p=>p.MENU_NAME1).ToList();
            //btnHome.PostBackUrl = "' onclick=\"return loadIframe('ifrm', " + List[0].LINK + ")\"";
            lblDashboard.Text = " <a href=\""+List[0].LINK+"\" onclick=\"return loadIframe('ifrm', this.href)\"><i class=\"icon-home\"></i><span class=\"title\">Dashboard</span> </a>";
            ifrm.Attributes.Add("src", List[0].LINK);
            if(List.Count()>0)
            {
                if (List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TENANT_ID == TID && p.ACTIVEMENU == true).Count() > 0)
                {
                    //int MID = Convert.ToInt32(Request.QueryString["MID"]);
                    ltsMenu.DataSource = List.Where(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.TENANT_ID == TID && p.ACTIVEMENU == true).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                    ltsMenu.DataBind();

                    int MasterID = Convert.ToInt32(List.First(p => p.ACTIVETILLDATE >= DateTime.Now && p.MENU_LOCATION == "Separator" && p.ACTIVEMENU == true).MASTER_ID);
                    lstMaster.DataSource = List.Where(p => p.MASTER_ID == MasterID && p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TENANT_ID == TID && p.ACTIVEMENU == true);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                    lstMaster.DataBind();
                }
                else
                {
                    lstMaster.DataSource = List.Where(p => p.MENU_LOCATION == "Left Menu" && p.MENU_NAME1 != "Dashboard" && p.TENANT_ID == TID && p.MODULE_ID == ModuleID && p.ACTIVEMENU == true).OrderBy(a => a.MENU_ORDER);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
                    lstMaster.DataBind();
                }
                lstisGloble.DataSource = List.Where(p => p.AMIGLOBALE == 1 && p.TENANT_ID == TID && p.MODULE_ID == ModuleID && p.ACTIVEMENU == true);//Classes.Globle.EncryptionHelpers.getMenuGloble(TID, userID);
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
        public void bindModule()
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TENANT_ID);
            //int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
            if (TID == 0)
            {
            lstmodule.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TENANT_ID == TID);
            lstmodule.DataBind();
            }
            else
            {
                lstmodule.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == 0 && p.TENANT_ID == TID && p.Module_Id != 12);
                lstmodule.DataBind();
            }
        }
        protected void lstmodule_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TENANT_ID);
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblHide = (Label)e.Item.FindControl("lblHide");
                int MID = Convert.ToInt32(lblHide.Text);
                ListView ltsProduct = (ListView)e.Item.FindControl("lstsubmodule");
                ltsProduct.DataSource = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.Parent_Module_id == MID && p.TENANT_ID == TID);
                ltsProduct.DataBind();
                //menubind(MID);
            }

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?logout=logout");
        }
        public string GetLink(int menuID)
        {// <span class="title"><%# Eval("MENU_NAME1")%> </span></a> <ul class="sub-menu" style="display: none;">
            string menustr = "";
            int MTID = Convert.ToInt32(ViewState["MTID"]);
            string OnOff = "";
            if(DB.FUNCTION_MST.Where(p => p.MENU_ID == menuID && p.TENANT_ID == MTID && p.ACTIVE_FLAG == 1).Count()>0)
            {
               
                var obj = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == menuID && p.TENANT_ID == MTID && p.ACTIVE_FLAG == 1);
                OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
                string MID1 = obj.MASTER_ID.ToString();
                string MenuID1 = obj.MENU_ID.ToString();
                string ENCMID1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID1 + "~" + MenuID1).ToString();
                string itemstr1 = obj.URLREWRITE.ToString().Contains("?") ? obj.URLREWRITE.ToString() + "&MID=" + ENCMID1 : obj.URLREWRITE.ToString() + "?MID=" + ENCMID1;
                if (obj.MENU_LOCATION == "Separator")
                {
                    OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
                    menustr = "<a href='#'><i class='" + obj.ICONPATH + "'></i><span class='title' >" + obj.MENU_NAME1 + "</span><span class='arrow' style='color: #000;'></span><span class='badge badge" + OnOff + " </span></a>";
                    menustr += " <ul class='sub-menu' style='display: none;'>";
                    List<Database.FUNCTION_MST> itemList = DB.FUNCTION_MST.Where(p => p.MASTER_ID == menuID && p.TENANT_ID == MTID && p.ACTIVE_FLAG == 1).OrderBy(a => a.MENU_ORDER).ToList();
                   
                    if (itemList.Count() > 0)
                    {
                        foreach (Database.FUNCTION_MST item in itemList)
                        {
                            string MID = item.MASTER_ID.ToString();
                            string MenuID = item.MENU_ID.ToString();
                            string ENCMID = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID + "~" + MenuID).ToString();
                            OnOff = item.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
                            List<Database.FUNCTION_MST> itemList1 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item.MENU_ID && p.TENANT_ID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
                            string itemstr = item.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString()+"&MID=" + ENCMID : item.URLREWRITE.ToString()+"?MID=" + ENCMID;
                            if (itemList1.Count() > 0)
                            {
                                menustr += "<li class='active'><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item.ICONPATH + "'></i><span class='title' >" + item.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
                                menustr += "<ul class='sub-menu' style='display: none;'>";
                                foreach (Database.FUNCTION_MST item1 in itemList1)
                                {
                                    OnOff = item1.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
                                    List<Database.FUNCTION_MST> itemList2 = DB.FUNCTION_MST.Where(p => p.MASTER_ID == item1.MENU_ID && p.TENANT_ID == MTID).OrderBy(a => a.MENU_ORDER).ToList();
                                    string item1str = item1.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString()+"&MID=" + ENCMID : item.URLREWRITE.ToString()+"?MID=" + ENCMID;
                                    if (itemList2.Count() > 0)
                                    {
                                        menustr += "<li ><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\"><i class='" + item1.ICONPATH + "'></i><span class='title' >" + item1.MENU_NAME1 + "</span><span class='arrow'></span><span class='badge badge" + OnOff + " </span></a>";
                                        menustr += "<ul class='sub-menu' >";
                                        foreach (Database.FUNCTION_MST item2 in itemList2)
                                        {
                                            string item2str = item2.URLREWRITE.ToString().Contains("?") ? item.URLREWRITE.ToString()+"&MID=" + ENCMID : item.URLREWRITE.ToString()+"?MID=" + ENCMID;
                                            OnOff = item2.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp;";
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
            var obj = DB.FUNCTION_MST.SingleOrDefault(p => p.MENU_ID == menuID && p.TENANT_ID == MTID&&p.ACTIVE_FLAG==1);
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
            ddllocation.DataSource = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenantID == TID);
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
            obj.TENANT_ID = TID;
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
    }
}