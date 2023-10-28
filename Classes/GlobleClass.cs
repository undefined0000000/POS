using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.NetworkInformation;

namespace Classes
{
    public static class GlobleClass
    {
        static Database.CallEntities DB = new Database.CallEntities();
        public static void getMenuGloble(int TenentId, int UserID, int LocationID, int ModuleID, int Roleid)
        {
            Database.USER_MST Dateobj = DB.USER_MST.Single(p => p.TenentID == TenentId && p.USER_ID == UserID);
            List<Database.tempUser1> userlist = new List<Database.tempUser1>();
            Database.tempUser1 obj = new Database.tempUser1();
            Database.FUNCTION_MST MenuObj = new Database.FUNCTION_MST();
            //for MODULE_MAP
            var result2 = (from pm in DB.PRIVILAGE_MENUDemon.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.PRIVILAGEFOR == 2 && p.PRIVILEGE_MENU_ID == ModuleID)
                           join
                                Module in DB.MODULE_MAP.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.UserID == UserID && p.ACTIVE_FLAG == "Y" && p.MODULE_ID == ModuleID) on pm.PRIVILEGE_ID equals Module.PRIVILEGE_ID

                           select new { Module.TenentID, Module.PRIVILEGE_ID, Module.MODULE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, pm.LOCATION_ID, Module.UserID, pm.ADD_FLAG, pm.ALL_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, pm.ActiveMenu, pm.ActiveModule }).ToList();//Module.ACTIVE_FLAG, //pm.ActiveMenu is Menu ,pm.ActiveModule is Module
            var List = result2.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();

            foreach (var item2 in List)
            {
                obj = new Database.tempUser1();
                if (DB.FUNCTION_MST.Where(p => p.MENU_ID == item2.MENU_ID && p.MODULE_ID == item2.MODULE_ID).Count() > 0)
                {
                    MenuObj = DB.FUNCTION_MST.Single(p => p.MENU_ID == item2.MENU_ID && p.MODULE_ID == item2.MODULE_ID);
                    obj.TenentID = item2.TenentID;
                    obj.LocationID = item2.LOCATION_ID;
                    obj.PRIVILAGEID = item2.PRIVILEGE_ID;
                    obj.PRIVILAGESOURCE = "2";
                    obj.MENUID = item2.MENU_ID;
                    obj.PRIVILAGE_MENUID = item2.PRIVILEGE_MENU_ID;
                    obj.MODULE_ID = item2.MODULE_ID;
                    obj.UserID = item2.UserID;
                    obj.ROLE_ID = Roleid;
                    obj.ADD_FLAG = item2.ADD_FLAG;
                    obj.MODIFY_FLAG = item2.MODIFY_FLAG;
                    obj.DELETE_FLAG = item2.DELETE_FLAG;
                    obj.VIEW_FLAG = item2.VIEW_FLAG;
                    obj.ALL_FLAG = item2.ALL_FLAG;
                    obj.PRINTFLAGE = item2.PRIVILEGE_ID;
                    obj.LINK = MenuObj.LINK;
                    obj.MASTER_ID = MenuObj.MASTER_ID;
                    obj.MENU_TYPE = MenuObj.MENU_TYPE;
                    obj.MENU_NAME1 = MenuObj.MENU_NAME1;
                    obj.MENU_NAME2 = MenuObj.MENU_NAME2;
                    obj.MENU_NAME3 = MenuObj.MENU_NAME3;
                    obj.URLREWRITE = MenuObj.URLREWRITE;
                    obj.MENU_LOCATION = MenuObj.MENU_LOCATION;
                    obj.MENU_ORDER = MenuObj.MENU_ORDER;
                    obj.DOC_PARENT = MenuObj.DOC_PARENT;
                    obj.AMIGLOBALE = MenuObj.AMIGLOBALE;
                    obj.MYPERSONAL = MenuObj.MYPERSONAL;
                    obj.SMALLTEXT = MenuObj.SMALLTEXT;
                    obj.ICONPATH = MenuObj.ICONPATH;
                    obj.METATITLE = MenuObj.METATITLE;
                    obj.METAKEYWORD = MenuObj.METAKEYWORD;
                    obj.METADESCRIPTION = MenuObj.METADESCRIPTION;
                    obj.HEADERVISIBLEDATA = MenuObj.HEADERVISIBLEDATA;
                    obj.HEADERINVISIBLEDATA = MenuObj.HEADERINVISIBLEDATA;
                    obj.FOOTERVISIBLEDATA = MenuObj.FOOTERVISIBLEDATA;
                    obj.FOOTERINVISIBLEDATA = MenuObj.FOOTERINVISIBLEDATA;
                    obj.SP1 = 0;
                    obj.SP2 = 0;
                    obj.SP3 = 0;
                    obj.SP4 = 0;
                    obj.SP5 = 0;
                    obj.REFID = MenuObj.REFID;
                    obj.MYBUSID = MenuObj.MYBUSID;
                    obj.ACTIVETILLDATE = Dateobj.Till_DT;//MenuObj.ACTIVETILLDATE;
                    obj.MENUDATE = Dateobj.USERDATE;//MenuObj.MENUDATE;
                    if (obj.MENU_LOCATION == "Separator")
                        obj.ACTIVEMENU = true;
                    else
                        obj.ACTIVEMENU = item2.ActiveMenu == "Y" && MenuObj.ACTIVE_FLAG == 1 ? true : false;

                    obj.ACTIVEMODULE = item2.ActiveModule == "Y" ? true : false;
                    DB.tempUser1.AddObject(obj);
                    DB.SaveChanges();
                }
            }


            int MID = 0;
            //for USER_ROLE
            var result1 = (from pm in DB.PRIVILAGE_MENUDemon.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.PRIVILAGEFOR == 1 && p.PRIVILEGE_MENU_ID == Roleid)
                           join
                             ur in DB.USER_ROLE.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.USER_ID == UserID && p.ACTIVE_FLAG == "Y") on pm.PRIVILEGE_ID equals ur.PRIVILEGE_ID // && p.ACTIVE_FROM_DT <= DateTime.Now && p.ACTIVE_TO_DT >= DateTime.Now

                           select new { ur.TenentID, ur.PRIVILEGE_ID, ur.ROLE_ID, pm.PRIVILAGEFOR, pm.MENU_ID, pm.PRIVILEGE_MENU_ID, ur.ACTIVE_FLAG, ur.USER_ID, pm.ADD_FLAG, pm.ACTIVETILLDATE, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, ur.ACTIVE_TO_DT, pm.Action, pm.ActiveMenu }).ToList();
            var List1 = result1.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();
            foreach (var item1 in List1)
            {
                MID = Convert.ToInt32(item1.MENU_ID);
                if (DB.tempUser1.Where(p => p.MENUID == MID && p.UserID == item1.USER_ID && p.TenentID == TenentId).Count() > 0)
                {
                    var obj1 = DB.tempUser1.Single(p => p.MENUID == MID && p.TenentID == TenentId && p.LocationID == LocationID && p.UserID == item1.USER_ID);
                    obj1.PRIVILAGESOURCE = "1";
                    //obj1.ROLE_ID = item1.ROLE_ID;
                    //obj1.ACTIVETILLDATE = item1.ACTIVETILLDATE;
                    //obj1.MENUDATE = item1.ACTIVE_TO_DT;
                    obj1.ACTIVEROLE = item1.Action == "Y" ? true : false; //item1.ACTIVE_FLAG == "Y" ? true : false;
                    //if (obj1.MENU_LOCATION == "Separator")
                    //    obj1.ACTIVEMENU = true;
                    //else
                    //    obj1.ACTIVEMENU = item1.ActiveMenu == "Y" ? true : false;
                    DB.SaveChanges();
                }
            }



            //for USER_RIGHT
            var result3 = (from pm in DB.PRIVILAGE_MENUDemon.Where(a => a.LOCATION_ID == LocationID && a.TenentID == TenentId && a.PRIVILAGEFOR == 3 && a.PRIVILEGE_MENU_ID == UserID)
                           join
                              URR in DB.USER_RIGHTS.Where(b => b.LOCATION_ID == LocationID && b.TenentID == TenentId && b.USER_ID == UserID && b.status == "Final") on pm.PRIVILEGE_ID equals URR.PRIVILEGE_ID

                           select new { URR.TenentID, URR.PRIVILEGE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, URR.USER_ID, URR.ADD_FLAG, URR.MODIFY_FLAG, URR.DELETE_FLAG, URR.VIEW_FLAG, URR.ALL_FLAG, a = pm.ADD_FLAG, b = pm.MODIFY_FLAG, c = pm.DELETE_FLAG, d = pm.VIEW_FLAG, pm.Action, pm.ActiveModule, pm.SP5 }).ToList();
            var List2 = result3.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();
            foreach (var item3 in List2)
            {
                MID = Convert.ToInt32(item3.MENU_ID);
                if (DB.tempUser1.Where(p => p.MENUID == MID && p.UserID == UserID && p.TenentID == TenentId).Count() > 0)
                {
                    var obj2 = DB.tempUser1.Single(p => p.MENUID == MID && p.TenentID == TenentId && p.LocationID == LocationID && p.UserID == UserID);
                    obj2.PRIVILAGESOURCE = "3";
                    obj2.ACTIVEUSER = item3.Action == "Y" ? true : false;
                    obj2.ACTIVEMODULE = item3.ActiveModule == "Y" ? true : false;
                    obj2.SP5 = item3.SP5 == "Y" ? 1 : 0;
                    //obj2.URADD_FLAG = item3.ADD_FLAG;
                    //obj2.URMODIFY_FLAG = item3.MODIFY_FLAG;
                    //obj2.URDELETE_FLAG = item3.DELETE_FLAG;
                    //obj2.URVIEW_FLAG = item3.VIEW_FLAG;
                    //obj2.URALL_FLAG = item3.ALL_FLAG;
                    DB.SaveChanges();
                }

            }

        }
        public static void DeleteTempUser(int TID, int userID, int LocationID, int ModuleID)
        {
            List<Database.tempUser1> ListTempUser = DB.tempUser1.Where(p => p.TenentID == TID && p.UserID == userID && p.MODULE_ID == ModuleID && p.LocationID == LocationID).ToList();
            if (ListTempUser.Count > 0)
            {
                foreach (Database.tempUser1 item in ListTempUser)
                {
                    DB.tempUser1.DeleteObject(item);

                }
                DB.SaveChanges();
            }

        }
        public static int getModuleID(int PRIVILEGE_ID, int TID)
        {
            var PrivilageID = DB.PRIVILEGE_MST.OrderBy(p => p.MODULE_ID).FirstOrDefault(p => p.PRIVILEGE_ID == PRIVILEGE_ID);
            return Convert.ToInt32(PrivilageID.MODULE_ID);
        }
        public static DateTime GetDateMMDDYYYY(string strDate)
        {
            string[] datearray = strDate.Split('/');
            DateTime Date = new DateTime(Convert.ToInt32(datearray[2]), Convert.ToInt32(datearray[1]), Convert.ToInt32(datearray[0]));
            return Date;
        }

        public static string GetDateDDMMYYYY(DateTime Date)
        {

            return Date.ToString("dd/MM/yyyy");
        }
        public static class EncryptionHelpers
        {

            static Database.CallEntities DB = new Database.CallEntities();
            private const string cryptoKey = "cryptoKey";
            private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
            // login check for ACM
            static string message = "";
            public static string CheckLogin(string TenentId, string User_Id, string Password, string UserType)
            {

                int TID = Convert.ToInt32(TenentId);
                int UserTypeID = UserType == "" ? 1 : Convert.ToInt32(UserType);
                var obj = DB.USER_MST.Single(p => p.TenentID == TID && p.LOGIN_ID == User_Id && p.PASSWORD == Password && p.USER_TYPE == UserTypeID);
                if (obj.ACTIVE_FLAG != "Y")
                {
                    message = "Contact Adminisrtrator or support to activate your account!";

                    //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
                }
                if (obj.ACC_LOCK != "N")
                {
                    message += " Contact Adminisrtrator or support to Unlock your account!";

                    //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
                }
                if (obj.Till_DT <= DateTime.Now)
                {
                    message += " Contact Adminisrtrator or support to renew your account!";
                    //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
                }
                return message;
            }
            //User Verify in login for ACM
            public static USER_MST LoginVerified(string TenentId, string User_Id, string Password)
            {
                try
                {

               
                int TID = Convert.ToInt32(TenentId);

                string Password1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(Password);
                    string p2 = Classes.GlobleClass.EncryptionHelpers.Decrypt("8k9PKKGuFEkGCe5LbXKuhA==");

                    // int UserTypeID = UserType == "" ? 1 : Convert.ToInt32(UserType);
                    List<Database.USER_MST> ListUser = DAL.GetLogin(TID, User_Id, Password1); //DB.USER_MST.Where(p => p.TenentID == TID && p.LOGIN_ID == User_Id && p.PASSWORD == Password1).ToList();
                if (ListUser.Count() > 0)
                {
                    var UserList = ListUser.Single(p => p.TenentID == TID && p.LOGIN_ID == User_Id && p.PASSWORD == Password1);
                    LoginParamiter(TenentId, User_Id);
                    if (LoginParamiter(TenentId, User_Id) != true)
                    {
                        //Print Error Message
                    }
                    return UserList;
                }
                else
                {
                    return null;
                }
                }
                catch (Exception ex)
                {
                    return null;

                }
            }



            public static TBLCONTACT LoginVerified1(string TenentId, string User_Id, string Password)
            {
                int TID = Convert.ToInt32(TenentId);

                string Password1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(Password);
                // int UserTypeID = UserType == "" ? 1 : Convert.ToInt32(UserType);
                List<Database.TBLCONTACT> ListContact = DB.TBLCONTACTs.Where(p => p.TenentID == TID && p.CUSERID == User_Id && p.CPASSWRD == Password1).ToList();
                if (ListContact.Count() > 0)
                {
                    var UserList1 = ListContact.Single(p => p.TenentID == TID && p.CUSERID == User_Id && p.CPASSWRD == Password1);
                    LoginParamiter(TenentId, User_Id);
                    if (LoginParamiter(TenentId, User_Id) != true)
                    {
                        //Print Error Message
                    }
                    return UserList1;
                }
                else
                {
                    return null;
                }

            }

            public static TBLCOMPANYSETUP LoginVerified2(string TenentId, string User_Id, string Password)
            {
                int TID = Convert.ToInt32(TenentId);

                string Password1 = Classes.GlobleClass.EncryptionHelpers.Encrypt(Password);
                List<Database.TBLCOMPANYSETUP> ListCompany = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.CUSERID == User_Id && p.CPASSWRD == Password1).ToList();
                // int UserTypeID = UserType == "" ? 1 : Convert.ToInt32(UserType);
                if (ListCompany.Count() > 0)
                {
                    var UserList1 = ListCompany.Single(p => p.TenentID == TID && p.CUSERID == User_Id && p.CPASSWRD == Password1);
                    LoginParamiter(TenentId, User_Id);
                    if (LoginParamiter(TenentId, User_Id) != true)
                    {
                        //Print Error Message
                    }
                    return UserList1;
                }
                else
                {
                    return null;
                }

            }
            public static bool LoginParamiter(string TenentId, string User_Id)
            {
                //                Bring Role of the user on session
                //Bring IP Address logged in on Session
                //Tenange Group in Session
                //Allowed Module in Session

                return true;
            }


            public static string Encrypt(string s)
            {
                if (s == null || s.Length == 0) return string.Empty;

                string result = string.Empty;

                try
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(s);

                    TripleDESCryptoServiceProvider des =
                        new TripleDESCryptoServiceProvider();

                    MD5CryptoServiceProvider MD5 =
                        new MD5CryptoServiceProvider();

                    des.Key =
                        MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                    des.IV = IV;
                    result = Convert.ToBase64String(
                        des.CreateEncryptor().TransformFinalBlock(
                            buffer, 0, buffer.Length));
                }
                catch
                {
                    result = "0";
                }
                if (result.Contains("+"))
                {
                    result = result.Replace("+", "~");
                }
                return result;
            }
            public static string Decrypt(string s)
            {
                if (s.Contains("~"))
                {
                    s = s.Replace("~", "+");
                }

                if (s == null || s.Length == 0) return string.Empty;

                string result = string.Empty;

                try
                {
                    byte[] buffer = Convert.FromBase64String(s);

                    TripleDESCryptoServiceProvider des =
                        new TripleDESCryptoServiceProvider();

                    MD5CryptoServiceProvider MD5 =
                        new MD5CryptoServiceProvider();

                    des.Key =
                        MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                    des.IV = IV;

                    result = Encoding.ASCII.GetString(
                        des.CreateDecryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
                }
                catch
                {
                    result = "0";
                }
                return result;
            }
            public static int WriteLog1(string LogText, string MstText, string table, string UserID, int MeniID, int AuditNo)
            {

                int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
                string UID = ((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID;
                int NewCID = DB.CRUP_MST.Count() > 0 ? Convert.ToInt32(DB.CRUP_MST.Max(p => p.CRUP_ID) + 1) : 1;

                try
                {
                    CRUP_MST objUserLog = new CRUP_MST();
                    objUserLog.TENANT_ID = TID;
                    objUserLog.CRUP_ID = NewCID;
                    objUserLog.MySerial = 1;
                    objUserLog.PHYSICALLOCID = table;//come from to tblPHYSICALLOCation table
                    objUserLog.CREATED_DT = DateTime.Now;
                    objUserLog.CREATED_BY = UID;
                    objUserLog.ActivityNote = LogText;
                    objUserLog.MENU_ID = MeniID;
                    //objUserLog.CREATED_DT = DateTime.Now;
                    //objUserLog.UPDATED_BY = ((Database.ERP_WEB_USER_MST)Session["USER"]).ID;
                    DB.CRUP_MST.AddObject(objUserLog);
                    DB.SaveChanges();

                    tblAudit objtblAudit = new tblAudit();
                    objtblAudit.TENANT_ID = TID;
                    objtblAudit.CRUP_ID = NewCID;
                    objtblAudit.AuditNo = AuditNo;//comefrom Reftable
                    objtblAudit.MySerial = 1;
                    objtblAudit.TableName = table;
                    objtblAudit.AuditType = MstText;//"Create";//comefrom Reftable
                    objtblAudit.NewValue = LogText;
                    objtblAudit.CreatedDate = DateTime.Now;
                    objtblAudit.CreatedUserName = UserID;
                    DB.tblAudits.AddObject(objtblAudit);
                    DB.SaveChanges();

                    return NewCID;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            public static int WriteLog(string LogText, string MstText, string table, string UserID, int MeniID, int AuditNo, int Serial)
            {

                int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
                string UID = ((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID;
                int NewCID = DB.CRUP_MST.Count() > 0 ? Convert.ToInt32(DB.CRUP_MST.Max(p => p.CRUP_ID) + 1) : 1;

                try
                {
                    CRUP_MST objUserLog = new CRUP_MST();
                    objUserLog.TENANT_ID = TID;
                    objUserLog.CRUP_ID = NewCID;
                    objUserLog.MySerial = 1;
                    objUserLog.PHYSICALLOCID = table;//come from to tblPHYSICALLOCation table
                    objUserLog.CREATED_DT = DateTime.Now;
                    objUserLog.CREATED_BY = UID;
                    objUserLog.ActivityNote = LogText;
                    objUserLog.MENU_ID = MeniID;
                    //objUserLog.CREATED_DT = DateTime.Now;
                    //objUserLog.UPDATED_BY = ((Database.ERP_WEB_USER_MST)Session["USER"]).ID;
                    DB.CRUP_MST.AddObject(objUserLog);
                    DB.SaveChanges();
                    tblAudit objtblAudit = new tblAudit();
                    objtblAudit.TENANT_ID = TID;
                    objtblAudit.CRUP_ID = NewCID;
                    objtblAudit.AuditNo = AuditNo;//comefrom Reftable
                    objtblAudit.MySerial = Serial;
                    objtblAudit.TableName = table;
                    objtblAudit.AuditType = MstText;//"Create";//comefrom Reftable
                    objtblAudit.NewValue = LogText;
                    objtblAudit.CreatedDate = DateTime.Now;
                    objtblAudit.CreatedUserName = UserID;
                    DB.tblAudits.AddObject(objtblAudit);
                    DB.SaveChanges();
                    return NewCID;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }

            public static int ModifyLog(string LogText, string MstText, string table, string UserID, int MeniID, int crupID)
            {
                int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
                string UID = ((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID;
                int NewCID = crupID;

                try
                {
                    CRUP_MST objUserLog = DB.CRUP_MST.Single(p => p.TENANT_ID == TID && p.CRUP_ID == crupID);
                    objUserLog.MySerial = 2;
                    objUserLog.PHYSICALLOCID = table;//come from to tblPHYSICALLOCation table
                    objUserLog.CREATED_DT = DateTime.Now;
                    objUserLog.CREATED_BY = UID;
                    objUserLog.ActivityNote = LogText;
                    objUserLog.MENU_ID = MeniID;
                    DB.SaveChanges();

                    tblAudit objtblAudit = DB.tblAudits.Single(p => p.TENANT_ID == TID && p.CRUP_ID == crupID);
                    objtblAudit.TableName = table;
                    objtblAudit.AuditType = MstText;//"Create";//comefrom Reftable
                    objtblAudit.NewValue = LogText;
                    objtblAudit.CreatedDate = DateTime.Now;
                    objtblAudit.CreatedUserName = UserID;
                    DB.SaveChanges();

                    return NewCID;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            public static void UpdateLog(string NewLogText, int CrupID, string table, string UIDD)
            {

                int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
                string UID = ((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID;
                tblAudit objtblAudit = new tblAudit();
                objtblAudit.TENANT_ID = TID;
                objtblAudit.CRUP_ID = CrupID;
                int mySerial = objtblAudit.MySerial;
                mySerial = mySerial + 1;
                objtblAudit.MySerial = DB.tblAudits.Where(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID).Count() > 0 ? Convert.ToInt32(DB.tblAudits.Where(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID).Max(p => p.MySerial) + 1) : 1;//mySerial;
                //objtblAudit.MySerial += 1;
                objtblAudit.TableName = table;
                objtblAudit.AuditType = "Update";
                objtblAudit.NewValue = NewLogText;
                objtblAudit.UpdateDate = DateTime.Now;
                objtblAudit.UpdateUserName = UIDD;
                DB.tblAudits.AddObject(objtblAudit);
              //  DB.SaveChanges();
                if (DB.CRUP_MST.Where(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID).Count() > 0)
                {
                    CRUP_MST objUserLog = DB.CRUP_MST.SingleOrDefault(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID);
                    //int Serial = Convert.ToInt32(objUserLog.MySerial);
                    //Serial = Serial + 1;
                    objUserLog.MySerial = DB.CRUP_MST.Where(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID).Count() > 0 ? Convert.ToInt32(DB.CRUP_MST.Where(p => p.TENANT_ID == TID && p.CRUP_ID == CrupID).Max(p => p.MySerial) + 1) : 1;//Serial;
                    //objUserLog.MySerial += 1;
                    objUserLog.UPDATED_DT = DateTime.Now;
                    objUserLog.UPDATED_BY = UID;
                  //  DB.SaveChanges();
                }
            }
        }
        
        public static void getUserMenuGloble(int TenentId, int UserID, int LocationID, int ModuleID, int Roleid)
        {

            List<Database.tempUser1> userlist = new List<Database.tempUser1>();
            Database.tempUser1 obj = new Database.tempUser1();
            Database.FUNCTION_MST MenuObj = new Database.FUNCTION_MST();
            //for MODULE_MAP
            var result2 = (from pm in DB.PRIVILAGE_MENUDemon.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.PRIVILAGEFOR == 2 && p.PRIVILEGE_MENU_ID == ModuleID)
                           join
                                Module in DB.MODULE_MAP.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.UserID == UserID && p.ACTIVE_FLAG == "Y" && p.MODULE_ID == ModuleID) on pm.PRIVILEGE_ID equals Module.PRIVILEGE_ID

                           select new { Module.TenentID, Module.PRIVILEGE_ID, Module.MODULE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, pm.LOCATION_ID, Module.UserID, pm.ADD_FLAG, pm.ALL_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, pm.ActiveMenu, pm.ActiveModule }).ToList();//Module.ACTIVE_FLAG, //pm.ActiveMenu is Menu ,pm.ActiveModule is Module
            var List = result2.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();

            foreach (var item2 in List)
            {

                obj = new Database.tempUser1();
                if (DB.FUNCTION_MST.Where(p => p.MENU_ID == item2.MENU_ID && p.MODULE_ID == item2.MODULE_ID).Count() > 0)
                {
                    MenuObj = DB.FUNCTION_MST.Single(p => p.MENU_ID == item2.MENU_ID && p.MODULE_ID == item2.MODULE_ID);
                    if (DB.tempUser1.Where(p => p.TenentID == TenentId && p.UserID == UserID && p.MENUID == item2.MENU_ID && p.ROLE_ID == Roleid && p.PRIVILAGEID == item2.PRIVILEGE_ID && p.LocationID == LocationID).Count() > 0)
                    {

                    }
                    else
                    {
                        obj.TenentID = item2.TenentID;
                        obj.LocationID = item2.LOCATION_ID;
                        obj.PRIVILAGEID = item2.PRIVILEGE_ID;
                        obj.PRIVILAGESOURCE = "2";
                        obj.MENUID = item2.MENU_ID;
                        obj.PRIVILAGE_MENUID = item2.PRIVILEGE_MENU_ID;
                        obj.MODULE_ID = item2.MODULE_ID;
                        obj.UserID = item2.UserID;
                        obj.ROLE_ID = Roleid;
                        obj.ADD_FLAG = item2.ADD_FLAG;
                        obj.MODIFY_FLAG = item2.MODIFY_FLAG;
                        obj.DELETE_FLAG = item2.DELETE_FLAG;
                        obj.VIEW_FLAG = item2.VIEW_FLAG;
                        obj.ALL_FLAG = item2.ALL_FLAG;
                        obj.PRINTFLAGE = item2.PRIVILEGE_ID;
                        obj.LINK = MenuObj.LINK;
                        obj.MASTER_ID = MenuObj.MASTER_ID;
                        obj.MENU_TYPE = MenuObj.MENU_TYPE;
                        obj.MENU_NAME1 = MenuObj.MENU_NAME1;
                        obj.MENU_NAME2 = MenuObj.MENU_NAME2;
                        obj.MENU_NAME3 = MenuObj.MENU_NAME3;
                        obj.URLREWRITE = MenuObj.URLREWRITE;
                        obj.MENU_LOCATION = MenuObj.MENU_LOCATION;
                        obj.MENU_ORDER = MenuObj.MENU_ORDER;
                        obj.DOC_PARENT = MenuObj.DOC_PARENT;
                        obj.AMIGLOBALE = MenuObj.AMIGLOBALE;
                        obj.MYPERSONAL = MenuObj.MYPERSONAL;
                        obj.SMALLTEXT = MenuObj.SMALLTEXT;
                        obj.ICONPATH = MenuObj.ICONPATH;
                        obj.METATITLE = MenuObj.METATITLE;
                        obj.METAKEYWORD = MenuObj.METAKEYWORD;
                        obj.METADESCRIPTION = MenuObj.METADESCRIPTION;
                        obj.HEADERVISIBLEDATA = MenuObj.HEADERVISIBLEDATA;
                        obj.HEADERINVISIBLEDATA = MenuObj.HEADERINVISIBLEDATA;
                        obj.FOOTERVISIBLEDATA = MenuObj.FOOTERVISIBLEDATA;
                        obj.FOOTERINVISIBLEDATA = MenuObj.FOOTERINVISIBLEDATA;
                        obj.SP1 = 0;
                        obj.SP2 = 0;
                        obj.SP3 = 0;
                        obj.SP4 = 0;
                        obj.SP5 = 0;
                        obj.REFID = MenuObj.REFID;
                        obj.MYBUSID = MenuObj.MYBUSID;
                        obj.ACTIVETILLDATE = MenuObj.ACTIVETILLDATE;
                        obj.MENUDATE = MenuObj.MENUDATE;
                        if (obj.MENU_LOCATION == "Separator")
                            obj.ACTIVEMENU = true;
                        else
                        {
                            obj.ACTIVEMENU = false;//item2.ActiveMenu == "Y" && MenuObj.ACTIVE_FLAG == 1 ? true : false;
                        }
                        obj.ACTIVEMODULE = item2.ActiveModule == "Y" ? true : false;
                        DB.tempUser1.AddObject(obj);
                        DB.SaveChanges();
                    }

                }
            }

            int MID = 0;
            //for USER_ROLE
            var result1 = (from pm in DB.PRIVILAGE_MENUDemon.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.PRIVILAGEFOR == 1)
                           join
                             ur in DB.USER_ROLE.Where(p => p.TenentID == TenentId && p.LOCATION_ID == LocationID && p.USER_ID == UserID && p.ACTIVE_FLAG == "Y" && p.ACTIVE_FROM_DT <= DateTime.Now && p.ACTIVE_TO_DT >= DateTime.Now) on pm.PRIVILEGE_ID equals ur.PRIVILEGE_ID

                           select new { ur.TenentID, ur.PRIVILEGE_ID, ur.ROLE_ID, pm.PRIVILAGEFOR, pm.MENU_ID, pm.PRIVILEGE_MENU_ID, ur.ACTIVE_FLAG, ur.USER_ID, pm.ADD_FLAG, pm.ACTIVETILLDATE, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, ur.ACTIVE_TO_DT, pm.Action, pm.ActiveMenu }).ToList();
            var List1 = result1.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();
            foreach (var item1 in List1)
            {
                MID = Convert.ToInt32(item1.MENU_ID);
                if (DB.tempUser1.Where(p => p.MENUID == MID && p.UserID == item1.USER_ID).Count() > 0)
                {
                    var obj1 = DB.tempUser1.Single(p => p.MENUID == MID && p.TenentID == TenentId && p.LocationID == LocationID && p.UserID == item1.USER_ID);
                    obj1.PRIVILAGESOURCE = "1";
                    //obj1.ROLE_ID = item1.ROLE_ID;
                    obj1.ACTIVETILLDATE = item1.ACTIVETILLDATE;
                    obj1.MENUDATE = item1.ACTIVE_TO_DT;
                    obj1.ACTIVEROLE = item1.Action == "Y" ? true : false; //item1.ACTIVE_FLAG == "Y" ? true : false;
                    if (obj1.MENU_LOCATION == "Separator")
                        obj1.ACTIVEMENU = true;
                    else
                    {
                        string MM = item1.ActiveMenu;
                        obj1.ACTIVEMENU = item1.ActiveMenu == "Y" ? true : false;
                    }
                    DB.SaveChanges();
                }
            }

            //for USER_RIGHT
            var result3 = (from pm in DB.PRIVILAGE_MENUDemon.Where(a => a.LOCATION_ID == LocationID && a.TenentID == TenentId && a.PRIVILAGEFOR == 3 && a.PRIVILEGE_MENU_ID == UserID)
                           join
                              URR in DB.USER_RIGHTS.Where(b => b.LOCATION_ID == LocationID && b.TenentID == TenentId && b.USER_ID == UserID && b.status == "Final") on pm.PRIVILEGE_ID equals URR.PRIVILEGE_ID

                           select new { URR.TenentID, URR.PRIVILEGE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, URR.USER_ID, URR.ADD_FLAG, URR.MODIFY_FLAG, URR.DELETE_FLAG, URR.VIEW_FLAG, URR.ALL_FLAG, a = pm.ADD_FLAG, b = pm.MODIFY_FLAG, c = pm.DELETE_FLAG, d = pm.VIEW_FLAG, pm.Action, pm.ActiveModule }).ToList();
            var List2 = result3.GroupBy(p => p.MENU_ID).Select(p => p.FirstOrDefault()).ToList();
            foreach (var item3 in List2)
            {
                MID = Convert.ToInt32(item3.MENU_ID);
                if (DB.tempUser1.Where(p => p.MENUID == MID && p.UserID == UserID).Count() > 0)
                {
                    var obj2 = DB.tempUser1.Single(p => p.MENUID == MID && p.TenentID == TenentId && p.LocationID == LocationID && p.UserID == UserID);
                    obj2.PRIVILAGESOURCE = "3";
                    obj2.ACTIVEUSER = item3.Action == "Y" ? true : false;
                    obj2.ACTIVEMODULE = item3.ActiveModule == "Y" ? true : false;
                    //obj2.URADD_FLAG = item3.ADD_FLAG;
                    //obj2.URMODIFY_FLAG = item3.MODIFY_FLAG;
                    //obj2.URDELETE_FLAG = item3.DELETE_FLAG;
                    //obj2.URVIEW_FLAG = item3.VIEW_FLAG;
                    //obj2.URALL_FLAG = item3.ALL_FLAG;
                    DB.SaveChanges();
                }

            }

        }

        //Logg table entry to generate occure error

        public static void InsertErrorLog1(string tablename, string Pagename, string evantname,string LineNo)
        {
            string url = string.Empty;

            if (HttpContext.Current != null)
            {
                string loginUserId = (((USER_MST)HttpContext.Current.Session["USER"]).USER_ID).ToString();

                string ipAddress = IPAddress;
                string hostname = HttpContext.Current.Request.UserHostName;
                string INFo = GetMACAddress();

                string username = (((USER_MST)HttpContext.Current.Session["USER"]).LOGIN_ID).ToString();
                url = "IP: " + ipAddress + ", HostName:" + hostname + ", MAC Address:" + INFo + "<br/>" + "UserID: " + loginUserId + ", UserName: " + username + "<br/>" + "  URL: " + HttpContext.Current.Request.Url.ToString();
                url += "<br /> Pagename: " + Pagename + ", TableName:" + tablename + ", EventName:" + evantname + ", " + LineNo;
                //url += "<br /> UrlReferrer: " + HttpContext.Current.Request.UrlReferrer;

                string platfrom, browserName, browserVersion;
                GetBrowser(out platfrom, out browserName, out browserVersion);
                string browser = "<br />OS: " + platfrom + " Browser: " + browserName + " Version: " +
                                 browserVersion;
                url += browser;

                GlobleClass.EncryptionHelpers.WriteLog(url, evantname, tablename, loginUserId.ToString(), 0,0,0);
            }

        }
        public static string GetMACAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) //&& nic.OperationalStatus == OperationalStatus.Up
                {
                    return nic.GetPhysicalAddress().ToString();
                }
            }
            return null;
        }
        public static string IPAddress
        {
            get
            {
                try
                {
                    if (System.ServiceModel.OperationContext.Current != null)
                    {
                        System.ServiceModel.OperationContext context = System.ServiceModel.OperationContext.Current;
                        System.ServiceModel.Channels.MessageProperties properties = context.IncomingMessageProperties;
                        System.ServiceModel.Channels.RemoteEndpointMessageProperty endpoint = properties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;
                        return endpoint.Address;
                    }
                    string result = String.Empty;
                    result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (result != null && result != String.Empty)
                    {
                        if (result.IndexOf(".") == -1)
                            result = null;
                        else
                        {
                            if (result.IndexOf(",") != -1)
                            {
                                //contains ","£¬maybe have more proxy. get the fist proxy inner ip.
                                result = result.Replace(" ", "").Replace("\"", "");
                                string[] temparyip = result.Split(",;".ToCharArray());
                                for (int i = 0; i < temparyip.Length; i++)
                                {
                                    if (IsIPAddress(temparyip[i])
                                        && temparyip[i].Substring(0, 3) != "10."
                                        && temparyip[i].Substring(0, 7) != "192.168"
                                        && temparyip[i].Substring(0, 7) != "172.16.")
                                    {
                                        return temparyip[i];    // can't find inner address
                                    }
                                }
                            }
                            else if (IsIPAddress(result)) //is proxy ip
                                return result;
                            else
                                result = null;
                        }
                    }
                    string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    if (null == result || result == String.Empty)
                        result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    if (result == null || result == String.Empty)
                        result = HttpContext.Current.Request.UserHostAddress;
                    
                    return result;
                }
                catch
                {
                    return "";
                }
            }
        }
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }
        public static void GetBrowser(out string platForm, out string browserName, out string browserVersion)
        {
            browserName = HttpContext.Current.Request.UserAgent.Contains("Chrome") ? "Chrome" : HttpContext.Current.Request.Browser.Browser;
            platForm = HttpContext.Current.Request.UserAgent.ToLower();
            if (platForm.Contains("ipod;"))
            {
                platForm = "iPod";
            }
            else if (platForm.Contains("iphone;"))
            {
                platForm = "iPhone";
            }
            else if (platForm.Contains("iphone simulator;"))
            {
                platForm = "iPhone";
            }
            else if (platForm.Contains("macintosh;"))
            {
                platForm = "Mac";
            }
            else if (platForm.Contains("ipad;"))
            {
                platForm = "iPad";
            }
            else if (platForm.Contains("android"))
            {
                platForm = "Android";
            }
            else
            {
                platForm = HttpContext.Current.Request.Browser.Platform;
            }
            browserVersion = HttpContext.Current.Request.Browser.Version;
        }
       
        public static string LineNo(string Line)
        {
            string[] EAR = Line.ToString().Split(':');
            string sep = "";
            string Line2 = "";
            for (int a = 0; a <= EAR.Count() - 1; a++)
            {
                sep = EAR[a];
                if (sep.Contains("line"))
                    Line2 = sep;
            }
            return Line2;
        }
    }
    public static class EncryptionHelper
    {
        private const string cryptoKey = "cryptoKey";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Encrypts provided string parameter
        /// </summary>
        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }
            if (result.Contains("+"))
            {
                result = result.Replace("+", "~");
            }
            return result;
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            if (s.Contains("~"))
            {
                s = s.Replace("~", "+");
            }

            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }

            return result;
        }

        //((DMSMaster)Page.Master).WriteLog("MaterialDelivary(11001),ID:" + DocUniqueID.ToString(), "tbl_DMSMaterialDelivary");

    }

}
