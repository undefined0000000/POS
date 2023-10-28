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
    public partial class Acm_Maintance : System.Web.UI.Page
    {
        Database.CallEntities DB = new Database.CallEntities();
    //    Database.CallEntities DB1 = new Database.CallEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlSuccessMsg.Visible = false ;
        }

        protected void btnEcoMaintance_Click(object sender, EventArgs e)
        {
            //using (var scope = new System.Transactions.TransactionScope())
            //{
            //try
            //{
            var ListUSER = DB.USER_MST.Where(p => p.TenentID == 1).ToList();
            foreach (Database.USER_MST item in ListUSER)
            {
                DB.USER_MST.DeleteObject(item);
                DB.SaveChanges();
            }
            var ListDTl = DB.USER_DTL.Where(p => p.TenentID == 1).ToList();
            foreach (Database.USER_DTL item in ListDTl)
            {
                DB.USER_DTL.DeleteObject(item);
                DB.SaveChanges();
            }
            var List = DB.USER_DTL.Where(p => p.TenentID == 1).ToList();
            for (int i = 0; i <= List.Count() - 1; i++)
            {
                USER_DTL obj = new USER_DTL();
                obj.TenentID = List[i].TenentID;
                obj.USER_DETAIL_ID = List[i].USER_DETAIL_ID;
                obj.CRUP_ID = List[i].CRUP_ID;
                obj.COUNTRY_CODE = List[i].COUNTRY_CODE;
                obj.TITLE = List[i].TITLE;
                obj.HOUSE_NO = List[i].HOUSE_NO;
                obj.STREET = List[i].STREET;
                obj.ADDRESS1 = List[i].ADDRESS1;
                obj.ADDRESS2 = List[i].ADDRESS2;
                obj.CITY = List[i].CITY;
                obj.COUNTRY = List[i].COUNTRY;
                obj.STATE = List[i].STATE;
                obj.ZIP = List[i].ZIP;
                obj.PH_NO = List[i].PH_NO;
                obj.FAX_NO = List[i].FAX_NO;
                obj.FROM_REG_DT = List[i].FROM_REG_DT;
                obj.VILLAGE_TOWN_CITY = List[i].VILLAGE_TOWN_CITY;
                obj.TEHSIL = List[i].TEHSIL;
                obj.PINCODE_NO = List[i].PINCODE_NO;
                obj.POST_OFFICE = List[i].POST_OFFICE;
                obj.PAN_NO = List[i].PAN_NO;
                obj.EMAIL_ADDRESS = List[i].EMAIL_ADDRESS;
                obj.MOBILE_NUM = List[i].MOBILE_NUM;
                obj.SEC_QUES = List[i].SEC_QUES;
                obj.SEC_ANS = List[i].SEC_ANS;
                DB.USER_DTL.AddObject(obj);
                DB.SaveChanges();
            }
            var ListMst = DB.USER_MST.Where(p => p.TenentID == 1 && p.ACTIVE_FLAG == "Y").ToList();
            for (int i = 0; i <= ListMst.Count() - 1; i++)
            {
                USER_MST obj = new USER_MST();
                obj.TenentID = ListMst[i].TenentID;
                obj.LOCATION_ID = ListMst[i].LOCATION_ID;
                obj.USER_ID = ListMst[i].USER_ID;
                obj.CRUP_ID = ListMst[i].CRUP_ID;
                obj.FIRST_NAME = ListMst[i].FIRST_NAME;
                obj.LAST_NAME = ListMst[i].LAST_NAME;
                obj.FIRST_NAME1 = ListMst[i].FIRST_NAME1;
                obj.LAST_NAME1 = ListMst[i].LAST_NAME1;
                obj.FIRST_NAME2 = ListMst[i].FIRST_NAME2;
                obj.LAST_NAME2 = ListMst[i].LAST_NAME2;
                obj.LOGIN_ID = ListMst[i].LOGIN_ID;
                obj.PASSWORD = ListMst[i].PASSWORD;
                obj.USER_TYPE = ListMst[i].USER_TYPE;
                obj.REMARKS = ListMst[i].REMARKS;
                obj.ACTIVE_FLAG = ListMst[i].ACTIVE_FLAG;
                obj.LAST_LOGIN_DT = ListMst[i].LAST_LOGIN_DT;
                obj.USER_DETAIL_ID = ListMst[i].USER_DETAIL_ID;
                obj.ACC_LOCK = ListMst[i].ACC_LOCK;
                obj.FIRST_TIME = ListMst[i].FIRST_TIME;
                obj.PASSWORD_CHNG = ListMst[i].PASSWORD_CHNG;
                obj.THEME_NAME = ListMst[i].THEME_NAME;
                obj.APPROVAL_DT = ListMst[i].APPROVAL_DT;
                obj.VERIFICATION_CD = ListMst[i].VERIFICATION_CD;
                obj.EmailAddress = ListMst[i].EmailAddress;
                obj.Avtar = ListMst[i].Avtar;
                obj.CompId = ListMst[i].CompId;
                DB.USER_MST.AddObject(obj);
                DB.SaveChanges();
            }
            pnlSuccessMsg.Visible = true;
            lblMsg.Text = "Eco User Data Are SuccessFuli Insert";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            //    scope.Complete(); //  To commit.
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    throw;
            //    //}
            //}
        }

        protected void btnEcoMenu_Click(object sender, EventArgs e)
        {
            //var option = new TransactionOptions
            //    {
            //        IsolationLevel = IsolationLevel.ReadCommitted,
            //        Timeout = TimeSpan.FromSeconds(60)
            //    };
            //using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            //{
                var ListUSER = DB.tempUsers.Where(p => p.TenentID == 1).ToList();
                foreach (Database.tempUser item in ListUSER)
                {
                    DB.tempUsers.DeleteObject(item);
                    DB.SaveChanges();
                }
                var ListMst = DB.tempUsers.Where(p => p.TenentID == 1).ToList();
                for (int i = 0; i <= ListMst.Count() - 1; i++)
                {
                    tempUser obj = new tempUser();
                    obj.TenentID = ListMst[i].TenentID;
                    obj.PRIVILAGEID = ListMst[i].PRIVILAGEID;
                    obj.PRIVILAGESOURCE = ListMst[i].PRIVILAGESOURCE;
                    obj.MENUID = ListMst[i].MENUID;
                    obj.PRIVILAGE_MENUID = ListMst[i].PRIVILAGE_MENUID;
                    obj.MODULE_ID = ListMst[i].MODULE_ID;
                    obj.UserID = ListMst[i].UserID;
                    obj.ROLE_ID = ListMst[i].ROLE_ID;
                    obj.ADD_FLAG = ListMst[i].ADD_FLAG;
                    obj.MODIFY_FLAG = ListMst[i].MODIFY_FLAG;
                    obj.DELETE_FLAG = ListMst[i].DELETE_FLAG;
                    obj.VIEW_FLAG = ListMst[i].VIEW_FLAG;
                    obj.PRINTFLAGE = ListMst[i].PRINTFLAGE;
                    obj.ALL_FLAG = ListMst[i].ALL_FLAG;
                    obj.LINK = ListMst[i].LINK;
                    obj.MASTER_ID = ListMst[i].MASTER_ID;
                    obj.MENU_TYPE = ListMst[i].MENU_TYPE;
                    obj.MENU_NAME1 = ListMst[i].MENU_NAME1;
                    obj.MENU_NAME2 = ListMst[i].MENU_NAME2;
                    obj.MENU_NAME3 = ListMst[i].MENU_NAME3;
                    obj.URLREWRITE = ListMst[i].URLREWRITE;
                    obj.MENU_LOCATION = ListMst[i].MENU_LOCATION;
                    obj.MENU_ORDER = ListMst[i].MENU_ORDER;
                    obj.DOC_PARENT = ListMst[i].DOC_PARENT;
                    obj.AMIGLOBALE = ListMst[i].AMIGLOBALE;
                    obj.MYPERSONAL = ListMst[i].MYPERSONAL;
                    obj.SMALLTEXT = ListMst[i].SMALLTEXT;
                    obj.ICONPATH = ListMst[i].ICONPATH;
                    obj.METATITLE = ListMst[i].METATITLE;
                    obj.METAKEYWORD = ListMst[i].METAKEYWORD;
                    obj.METADESCRIPTION = ListMst[i].METADESCRIPTION;
                    obj.HEADERVISIBLEDATA = ListMst[i].HEADERVISIBLEDATA;
                    obj.HEADERINVISIBLEDATA = ListMst[i].HEADERINVISIBLEDATA;
                    obj.FOOTERVISIBLEDATA = ListMst[i].FOOTERVISIBLEDATA;
                    obj.FOOTERINVISIBLEDATA = ListMst[i].FOOTERINVISIBLEDATA;
                    obj.REFID = ListMst[i].REFID;
                    obj.MYBUSID = ListMst[i].MYBUSID;
                    obj.ACTIVETILLDATE = ListMst[i].ACTIVETILLDATE;
                    obj.ACTIVEMENU = ListMst[i].ACTIVEMENU;
                    obj.ACTIVEPRIVILAGE = ListMst[i].ACTIVEPRIVILAGE;
                    obj.ACTIVEMODULE = ListMst[i].ACTIVEMODULE;
                    obj.ACTIVEROLE = ListMst[i].ACTIVEROLE;
                    obj.URADD_FLAG = ListMst[i].URADD_FLAG;
                    obj.URMODIFY_FLAG = ListMst[i].URMODIFY_FLAG;
                    obj.URDELETE_FLAG = ListMst[i].URDELETE_FLAG;
                    obj.URVIEW_FLAG = ListMst[i].URVIEW_FLAG;
                    obj.URALL_FLAG = ListMst[i].URALL_FLAG;
                    DB.tempUsers.AddObject(obj);
                    DB.SaveChanges();
                }
                pnlSuccessMsg.Visible = true;
                lblMsg.Text = "Eco Menu Data Are SuccessFuli Insert";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
            //    scope.Complete();
            //}

        }
    }
}