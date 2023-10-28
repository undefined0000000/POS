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
using System.Data.Entity.Core.Objects;
using System.Configuration;
using System.Transactions;
using System.Web.Configuration;
using Repository;

namespace Web
{
    public partial class Newdemo : System.Web.UI.Page
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

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER"] != null && string.IsNullOrEmpty(Session["USER"].ToString()))//error
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                
                int LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                DataTable Locations =  DAL.Get_Location(LocationID,TID);

                string UserFirst = ((USER_MST)Session["USER"]).FIRST_NAME;

                lbluser.Text = "User : " + UserFirst;
                lblLocation.Text =  "Location : " + Locations.Rows[0][0].ToString();
                if(Session["SiteModuleID"].ToString() == "39" )
                { 
                this.ifrm.Attributes.Add("onload", "setIframeHeight(document.getElementById('" + ifrm.ClientID + "'));");
                ifrm.Attributes.Add("src", "dash.aspx");
                }
                else
                {
                    this.ifrm.Attributes.Add("onload", "setIframeHeight(document.getElementById('" + ifrm.ClientID + "'));");
                    ifrm.Attributes.Add("src", "Sales\\POSIndex.aspx");
                }


                // Response.Redirect(@"\CRM\Calender\Default.aspx");

                if (HeadOffieName() == "")
                {
                    if (Session["SAFirstname"] == null)
                        Session.Abandon();
                    //Response.Redirect("Login.aspx");
                }
                else
                {
                    HttpCookie aCookie = Request.Cookies["tgadmin"];
                    //int UID = Convert.ToInt32(aCookie.Values["UserName"]);
                    int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                    string Lang = aCookie.Values["CLANGUAGE"];
                    //int Modulid = DB.MODULE_MAP.Single(p =>p.TenentID==TID && p.UserID == UID && p.SP1Name == "DefaultSet").MODULE_ID;
                    USER_MST UserList = DB.USER_MST.Single(p => p.USER_ID == UID && p.TenentID == TID);
                    Session["USER"] = UserList;
                    Session["Firstname"] = UserList.FIRST_NAME.ToString();

                    if (Session["SiteModuleID"] != null)
                    {
                        int Modulid = Convert.ToInt32(Session["SiteModuleID"]);
                        Session["SiteModuleID"] = Modulid;
                    }
                    Session["LANGUAGE"] = Lang;
                }
                if (Session["USER"] == null || Session["USER"] == "0")
                {
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
                userID = ((USER_MST)Session["USER"]).USER_ID;
                LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                if (Session["SAFirstname"] != null)
                {
                    string Username = Session["SAFirstname"].ToString();
                    //lblFirstName.Text = Username;
                }
                else
                {
                    string UserName = ((USER_MST)Session["USER"]).FIRST_NAME;
                    // lblFirstName.Text = UserName.ToString();
                }

                Session["Previous"] = Session["Current"];
                Session["Current"] = Request.RawUrl;
                if (Session["USER"] != null)
                {
                    int MID = Convert.ToInt32(Session["SiteModuleID"]);
                    //BulitMenus();
                    menubind(MID);

                    //sahir if (DB.MODULE_MST.Where(p => p.Module_Id == MID).Count() > 0)
                    //sahir {
                    //sahir     //lblmodule.Text = "Module:" + DB.MODULE_MST.Single(p => p.Module_Id == MID).Module_Name;
                    //sahir }
                }

                int UTID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                string UNAME = ((USER_MST)Session["USER"]).FIRST_NAME;
                int LID = ((USER_MST)Session["USER"]).LOCATION_ID;
                //Hawally
                if (DB.TBLLOCATIONs.Where(p => p.TenentID == TID && p.LOCATIONID == LID).Count() > 0)
                {
                    string Location1 = DB.TBLLOCATIONs.Single(p => p.TenentID == TID && p.LOCATIONID == LID).LOCNAME1;
                    ViewState["Location"] = Location1;
                }
                else
                {
                    string Location1 = "Hawally";
                    ViewState["Location"] = Location1;
                }

            }
        }

        public void checksession()
        {
            if (Session["USER"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        public string GetLname(int MMID)
        {
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            string MNAME = "";
            DataTable dt = ClsActivities.GetParentByNode(MMID, TID);
            bool IsParent = Convert.ToBoolean(dt.Rows[0][1]);
            if (IsParent)
            {
                MNAME = dt.Rows[0][0].ToString();


            }

            return MNAME;
        }
        public string GetLink(int menuID)
        {
            string menustr = "";
            int MTID = Convert.ToInt32(ViewState["MTID"]);
            string OnOff = "";
            int TID1 = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            DataTable CheckStatus = ClsActivities.GetParentByNode(menuID, TID1);
            int ROLLID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            if (CheckStatus.Rows.Count > 0) //&& p.TenentID == MTID  && p.ACTIVE_FLAG == 1
            {

                DataTable obj = CheckStatus;// && p.TenentID == MTID && p.ACTIVE_FLAG == 1
                //OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";
                string MID1 = obj.Rows[0]["ParentID"].ToString();
                string MenuID1 = obj.Rows[0]["NodeID"].ToString();
                string ENCMID1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID1 + "~" + MenuID1).ToString();
                string itemstr1 = obj.Rows[0]["NodeNavUrl"].ToString();

                if (Convert.ToBoolean(obj.Rows[0]["IsParent"]) == true)
                {
                    //OnOff = obj.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";//&& obj.ACTIVEMENU == true && obj.MENUDATE.Value >= DateTime.Now.Date                    
                    //menustr = "<a href='#' class='m-menu__link m-menu__toggle'><span class='m-menu__item-here'></span><span class='m-menu__link-text'>" + obj.MENU_NAME1 + "<i class='m-menu__hor-arrow la la-angle-down'></i><i class='m-menu__ver-arrow la la-angle-right'></i></a>";
                    menustr += "<div class='kt-aside-menu'><span class='m-menu__arrow m-menu__arrow--adjust'></span>";
                    menustr += " <ul style='margin-top: -17px;'>";
                    List<ClsActivities> itemList = ClsActivities.GetMasterID(menuID, TID1, ROLLID).ToList(); // && p.TenentID == MTID && p.ACTIVE_FLAG == 1
                    //if (OnOff == "-success'>&nbsp;")
                    //{
                    if (itemList.Count() > 0)
                    {
                        foreach (ClsActivities item in itemList)
                        {
                            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                            int uid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);

                            // Database.tempUser1 Tempobj = DB.tempUser1.Single(p => p.TenentID == TID && p.MENUID == item.MENU_ID && p.UserID == uid);
                            bool MT = true;
                            OnOff = MT == true ? "-success" : "-danger";
                            string itemstr = "";
                            string MID = item.ParentID.ToString();
                            string MenuID = item.NodeID.ToString();
                            string ENCMID = Classes.GlobleClass.EncryptionHelpers.Encrypt(MID + "~" + MenuID).ToString();
                            //OnOff = item.ACTIVE_FLAG == 1 && MT == true ? "-success'>&nbsp;" : "-danger'>&nbsp"; //&& item.ACTIVEMENU == true && item.MENUDATE.Value >= DateTime.Now.Date 
                            List<ClsActivities> itemList1 = ClsActivities.GetMasterID(item.NodeID, TID1, ROLLID).ToList(); // && p.TenentID == MTID
                            itemstr = OnOff == "-success" ? item.NodeNavUrl.ToString().Contains("?") ? item.NodeNavUrl.ToString() + "&MID=" + ENCMID : item.NodeNavUrl.ToString() + "?MID=" + ENCMID : "/ACM/Expired1.aspx";
                            if (itemList1.Count() > 0)

                            {
                                menustr += "<li class='kt-menu__item  kt-menu__item--submenu' data-redirect='true' data-menu-submenu-toggle='hover' aria-haspopup='true'><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><span class='kt-menu__link-text' >" + item.PageTitle + "</span></span></a></li>";
                                menustr += "<div class='kt-menu__submenu'><span class='kt-menu__arrow'></span>";
                                menustr += "<ul class='kt-menu__subnav'>";
                                foreach (ClsActivities item1 in itemList1)
                                {
                                    //OnOff = item1.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";
                                    List<ClsActivities> itemList2 = ClsActivities.GetMasterID(item1.NodeID, TID1, ROLLID).ToList();// && p.TenentID == MTID
                                    string item1str = item1.NodeNavUrl.ToString().Contains("?") ? item.NodeNavUrl.ToString() + "&MID=" + ENCMID : item.NodeNavUrl.ToString() + "?MID=" + ENCMID;
                                    if (itemList2.Count() > 0)
                                    {
                                        menustr += "<li class='kt-menu__item ' aria-haspopup='true'><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><i class='kt-menu__link-bullet kt-menu__link-bullet--line'> <span style='background-color: green'></span></i><span class='kt-menu__link-text' >" + item1.PageTitle + "</a></li>";
                                        menustr += "<ul class='kt-menu__subnav'>";
                                        foreach (ClsActivities item2 in itemList2)
                                        {
                                            string item2str = item2.NodeNavUrl.ToString().Contains("?") ? item.NodeNavUrl.ToString() + "&MID=" + ENCMID : item.NodeNavUrl.ToString() + "?MID=" + ENCMID;
                                            //OnOff = item2.ACTIVE_FLAG == 1 ? "-success'>&nbsp;" : "-danger'>&nbsp";                                                    
                                            menustr += "<li class='kt-menu__item' aria-haspopup='true'><a href='" + item2str + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><i class='kt-menu__link-bullet kt-menu__link-bullet--line'> <span style='background-color: green'></span></i><span class='kt-menu__link-text' >" + item2.PageTitle + "</span></a></li>";
                                        }
                                        menustr += Displaysubmenu1(menuID);
                                        menustr += "</li>";
                                    }
                                    else
                                    {
                                        menustr += "<li class='kt-menu__item' data-redirect='true' aria-haspopup='true'><a href='" + item1str + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><i class='kt-menu__link-bullet kt-menu__link-bullet--line'> <span style='background-color: green'></span></i><span class='kt-menu__link-text' >" + item1.PageTitle + "</span></a></li>";
                                    }
                                }
                                menustr += Displaysubmenu1(menuID);
                                menustr += "</li>";
                            }
                            else
                            {
                                if (itemstr.Contains("/ReportMst/Profile"))
                                {
                                    int comp = (((TBLCOMPANYSETUP)Session["CustomerUser"]).COMPID);//
                                    menustr += "<li class='kt-menu__item' aria-haspopup='true'><a href='" + itemstr + "?CID=" + comp + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><span class='kt-menu__link-text' >" + item.PageTitle + "</span></a></li>";
                                }
                                //else if (itemstr.Contains("/ACM/DemoPOS.aspx"))
                                //{
                                //    menustr += "<li class='kt-menu__item' aria-haspopup='true'><a href='" + itemstr + "' target='_blank' class='kt-menu__link'><span class='kt-menu__link-text' >" + item.PageTitle + "</span></a></li>";
                                //}
                                else
                                {
                                    //main
                                    menustr += "<li class='kt-menu__item'  aria-haspopup='true'><a href='" + itemstr + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><i class='kt-menu__link-bullet kt-menu__link-bullet--line'> <span style='background-color: green'></span></i><span class='kt-menu__link-text' >" + item.PageTitle + "</span></a></li>";
                                }
                            }

                        }

                    }


                }
                else
                {
                    menustr += "<li class='kt-menu__item' data-redirect='true' aria-haspopup='true'><a href='" + itemstr1 + "' onclick=\"return loadIframe('ifrm', this.href)\" class='kt-menu__link'><span class='kt-menu__link-text' >" + obj.Rows[0]["PageTitle"] + "</span></a></li>";
                }
            }

            return menustr;
        }

        public string Displaysubmenu1(int menuID)
        {
            int MTID = Convert.ToInt32(ViewState["MTID"]);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            DataTable dt = ClsActivities.GetParentByNode(menuID, TID);
            bool IsParent = Convert.ToBoolean(dt.Rows[0][1]);
            if (!IsParent)
                return "";
            else
                return " </ul></div> ";
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
        public void CheckLogin()
        {
            if (Session["USER"] == null || Session["USER"] == "0")
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
        }
        private void BulitMenus()
        {
            try
            {
                int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
                int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
                int ROLLID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
                int uid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
                Session["MCMenus"] = ClsActivities.GetMenusByRoleId(ROLLID.ToString(), TID);
                string menus = "";
                List<ClsActivities> userActivities = (List<ClsActivities>)HttpContext.Current.Session["MCMenus"];
                menus += "<li><a href='/home/home.aspx'><i class='fa fa-home'></i><span>Home</span></a></li>";
                var parentPages = userActivities.Where(a => a.IsParent == 1);
                int b = 1;
                string activeParent = "";
                /*
                 <li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
                <a href="javascript:;" class="kt-menu__link kt-menu__toggle">
                    <i class="kt-menu__link-icon flaticon2-list-3"></i>
                    <span class="kt-menu__link-text"><%# GetLname(Convert.ToInt32(Eval("MENUID")))%></span>
                    <i class="kt-menu__ver-arrow la la-angle-right"></i>
                </a>

                <div class="kt-menu__submenu ">
                    <span class="kt-menu__arrow"></span>
                    <ul style="margin-left: -50px;">
                        <li class="kt-menu__item " aria-haspopup="true">
                                <span class="kt-menu__link-text">
                                <%# GetLink(Convert.ToInt32(Eval("MENUID")))%>
                                <%# Displaysubmenu1(Convert.ToInt32(Eval("MENUID")))%></span></li>
                    </ul>
                </div>
            </li>
                 */
                foreach (var parent in parentPages)
                {
                    string p = "p" + b;
                    b += 1;
                    menus += "<li class='kt-menu__item  kt-menu__item--submenu nav-parent " + p + "  '><a href=" + parent.NodeNavUrl + "><i class='" + parent.NodeImageUrl + "'></i><span>" + parent.PageTitle + "</span><span class='kt-menu__link-text'></span></a>";
                    ClsActivities parent1 = parent;
                    var chiledPages = userActivities.Where(a => a.ParentID == parent1.NodeID && a.IsVisibleInMenu == true);
                    if (chiledPages.Count() > 0)
                    {
                        menus += "<div class='kt-menu__submenu'>";
                        menus += "<ul class=''>";
                        foreach (var chiled in chiledPages)
                        {
                            string currentPageUri = Request.RawUrl;
                            if (currentPageUri.Contains("?"))
                                currentPageUri = currentPageUri.Substring(0, currentPageUri.IndexOf("?"));

                            if (String.CompareOrdinal(currentPageUri, chiled.NodeNavUrl) == 0)
                            {
                                activeParent = p;

                            }

                            menus += "<li class='kt-menu__item '><a href='" + chiled.NodeNavUrl + "'>" + chiled.PageTitle + "</a></li>";
                        }
                        menus += "</ul>";
                        menus += "</div>";
                    }
                    menus += "</li>";
                }
                if (activeParent != "")
                {
                    menus = menus.Replace(activeParent, "active");
                }
                //  ltsMenu.InnerHtml = menus;
                ClsSystemUsers u = (ClsSystemUsers)Session["MCLoginUser"];
                // UpdateUserPicture(u);
            }
            catch (Exception ex)
            {
                //   Utility.Msg_Error(Master, ex.Message);
            }
        }


        public void menubind(int ModuleID)
        {
            int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            int TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            int ROLLID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_TYPE);
            int uid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);

            ViewState["MTID"] = TID;



            List<ClsActivities> List = ClsActivities.GetMenusByRoleId(uid.ToString(), TID).ToList();
            Session["MCUserActivities"] = ClsActivities.GetRoleActivities(uid.ToString(),TID);

            if (List.Count() > 0)
            {
                List<ClsActivities> ListDash = List.Where(p => p.IsParent == 1).ToList();
                string Dashname = ListDash[0].PageTitle;

                if (List.Where(p => p.IsParent == 1).Count() > 0)// && p.ACTIVEMENU == true                        
                {
                    //
                    List<ClsActivities> MenuMain = List.Where(p => p.IsParent == 1).ToList();
                    List<ClsActivities> Temp = new List<ClsActivities>();
                    foreach (ClsActivities mitem in MenuMain)
                    {
                        if (List.Where(p => p.ParentID == mitem.NodeID).Count() > 0)
                        {
                            ClsActivities mobj = List.Single(p => p.NodeID == mitem.NodeID);
                            Temp.Add(mobj);
                        }
                    }
                    //
                    List = Temp;
                    ltsMenu.DataSource = List.Where(p => p.IsParent == 1);// && p.ACTIVEMENU == true
                    ltsMenu.DataBind();


                }

            }
        }
    }
}