using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Web.UI.WebControls;

namespace Classes
{


    public static class ACMClass
    {

        public static int InsertDataACMFunction(int MEMUID12, int Master_ID, int Module_ID, string Menu_Type, string Name1, string Name2, string Name3,
            string LINK, string URLREWRITE, string MenuLocation, decimal MENU_ORDER, string DOC_PARENT, string SMALLTEXT,
            DateTime ACTIVETILLDATE, string CONPATH, string COMMANLINE, string METAKEYWORD, string METADESCRIPTION,
            string HEADERVISIBLEDATA, string HEADERINVISIBLEDATA, string FOOTERVISIBLEDATA, string FOOTERINVISIBLEDATA,
            int REFID, int TenentID, int LOCATIONID = 1, int MYBUSID = 0, int CRUP_ID = 0, string METATITLE = "",
            int ADDFLAGE = 0, int EDITFLAGE = 0, int DELFLAGE = 0, int PRINTFLAGE = 0, int AMIGLOBALE = 0, int MYPERSONAL = 0, int ACTIVE_FLAG = 0, DateTime? ActiveMenuDate = null, bool ActiveMenu = false, string spname1 = "", string spname2 = "", string spname3 = "", string spname4 = "", string spname5 = "")
        {
            Database.CallEntities DB = new Database.CallEntities();
            int MenuID = 0;
            Database.FUNCTION_MST objFUNCTION_MST = new Database.FUNCTION_MST();
            int MEMUID = MEMUID12;
            objFUNCTION_MST.MENU_ID = MEMUID;
            if (Master_ID != 0)
            {
                objFUNCTION_MST.MASTER_ID = Convert.ToInt32(Master_ID);
            }
            else
            {
                objFUNCTION_MST.MASTER_ID = 0;
            }
            if (Module_ID != 0)
            {
                objFUNCTION_MST.MODULE_ID = Convert.ToInt32(Module_ID);
            }

            objFUNCTION_MST.MENU_TYPE = Menu_Type;
            objFUNCTION_MST.MENU_NAME1 = Name1;
            objFUNCTION_MST.MENU_NAME2 = Name2;
            objFUNCTION_MST.MENU_NAME3 = Name3;
            objFUNCTION_MST.LINK = LINK;
            objFUNCTION_MST.URLREWRITE = URLREWRITE; if (MenuLocation != "")
                objFUNCTION_MST.MENU_LOCATION = MenuLocation;
            if (MENU_ORDER != 0)
            {
                objFUNCTION_MST.MENU_ORDER = Convert.ToDecimal(MENU_ORDER);
            }
            else
            {
                objFUNCTION_MST.MENU_ORDER = 0;
            }
            if (DOC_PARENT != "")
                objFUNCTION_MST.DOC_PARENT = DOC_PARENT;
            //objFUNCTION_MST.CRUP_ID = txtCRUP_ID.Text;
            objFUNCTION_MST.ADDFLAGE = ADDFLAGE;
            objFUNCTION_MST.EDITFLAGE = EDITFLAGE;
            objFUNCTION_MST.DELFLAGE = DELFLAGE;
            objFUNCTION_MST.PRINTFLAGE = PRINTFLAGE;
            objFUNCTION_MST.AMIGLOBALE = AMIGLOBALE;
            objFUNCTION_MST.MYPERSONAL = MYPERSONAL;
            if (SMALLTEXT != "")
                objFUNCTION_MST.SMALLTEXT = SMALLTEXT;
            objFUNCTION_MST.ACTIVETILLDATE = Convert.ToDateTime(ACTIVETILLDATE);
            if (CONPATH != "")
                objFUNCTION_MST.ICONPATH = CONPATH;
            if (COMMANLINE != "")
                objFUNCTION_MST.COMMANLINE = COMMANLINE;
            //if (SMALLTEXT != "")
            objFUNCTION_MST.ACTIVE_FLAG = ACTIVE_FLAG;
            //objFUNCTION_MST.METATITLE = txtMETATITLE.Text;
            if (METAKEYWORD != "")
                objFUNCTION_MST.METAKEYWORD = METAKEYWORD;
            if (METADESCRIPTION != "")
                objFUNCTION_MST.METADESCRIPTION = METADESCRIPTION;
            if (HEADERVISIBLEDATA != "")
                objFUNCTION_MST.HEADERVISIBLEDATA = HEADERVISIBLEDATA;
            if (HEADERINVISIBLEDATA != "")
                objFUNCTION_MST.HEADERINVISIBLEDATA = HEADERINVISIBLEDATA;
            if (FOOTERVISIBLEDATA != "")
                objFUNCTION_MST.FOOTERVISIBLEDATA = FOOTERVISIBLEDATA;
            if (FOOTERINVISIBLEDATA != "")
                objFUNCTION_MST.FOOTERINVISIBLEDATA = FOOTERINVISIBLEDATA;
            if (REFID != 0)
            {
                objFUNCTION_MST.REFID = Convert.ToInt32(REFID);
            }
            if (TenentID != 0)
            {
                objFUNCTION_MST.TenentID = Convert.ToInt32(TenentID);
            }

            if (MYBUSID != 0)
            {
                objFUNCTION_MST.MYBUSID = Convert.ToInt32(MYBUSID);
            }
            objFUNCTION_MST.ACTIVEMENU = ActiveMenu;
            objFUNCTION_MST.MENUDATE = ActiveMenuDate;
            objFUNCTION_MST.CRUP_ID = CRUP_ID;
            objFUNCTION_MST.SP1Name = spname1;
            objFUNCTION_MST.SP2Name = spname2;
            objFUNCTION_MST.SP3Name = spname3;
            objFUNCTION_MST.SP4Name = spname4;
            objFUNCTION_MST.SP5Name = spname5;

            DB.FUNCTION_MST.AddObject(objFUNCTION_MST);
            DB.SaveChanges();
            MenuID = MEMUID;
            return MenuID;
        }
        public static int InsertACM_CRMMainActivities(int TenentID, int COMPID, int LinkMasterCODE, int LocationID, int ID, int RouteID, int USERCODE, string ACTIVITYE, string ACTIVITYA, string ACTIVITYA2, bool AMIGLOBAL, bool MYPERSONNEL, int INTERVALDAYS, bool REPEATFOREVER, DateTime REPEATTILL, string REMINDERNOTE, int ESTCOST, int GROUPCODE, string USERCODEENTERED, DateTime UPDTTIME, DateTime UploadDate, string USERNAME, string Remarks, int CRUP_ID, string Version1, int Type, string MyStatus, int MainID, int ModuleID, string UrlRedirct, string Name, string Discription, string Prefix = null)
        {
            Database.CallEntities DB = new Database.CallEntities();

            int ActivityCode = DB.CRMMainActivities.Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Max(p => p.MasterCODE) + 1) : 1;
            int REFID = DB.REFTABLEs.Count() > 0 ? Convert.ToInt32(DB.REFTABLEs.Max(p => p.REFID) + 1) : 1;
            string REFNO = ACTIVITYE + "_" + ActivityCode + "_" + REFID;

            Database.CRMMainActivity objACM_CRMMainActivities = new Database.CRMMainActivity();
            objACM_CRMMainActivities.TenentID = TenentID;
            objACM_CRMMainActivities.COMPID = COMPID;
            //if (Prefix == null || Prefix == "")
            //    objACM_CRMMainActivities.Prefix = "ONL";
            //else
            //    objACM_CRMMainActivities.Prefix = Prefix;
            objACM_CRMMainActivities.MasterCODE = ActivityCode;
            objACM_CRMMainActivities.LinkMasterCODE = LinkMasterCODE;
            objACM_CRMMainActivities.LocationID = LocationID;
            objACM_CRMMainActivities.MyID = ID;
            objACM_CRMMainActivities.RouteID = RouteID;
            objACM_CRMMainActivities.USERCODE = USERCODE;
            objACM_CRMMainActivities.ACTIVITYE = ACTIVITYE;
            objACM_CRMMainActivities.ACTIVITYA = ACTIVITYA;
            objACM_CRMMainActivities.ACTIVITYA2 = ACTIVITYA2;
            objACM_CRMMainActivities.Reference = REFNO;
            objACM_CRMMainActivities.AMIGLOBAL = AMIGLOBAL;
            objACM_CRMMainActivities.MYPERSONNEL = MYPERSONNEL;
            objACM_CRMMainActivities.INTERVALDAYS = INTERVALDAYS;
            objACM_CRMMainActivities.REPEATFOREVER = REPEATFOREVER;
            objACM_CRMMainActivities.REPEATTILL = REPEATTILL;
            objACM_CRMMainActivities.REMINDERNOTE = REMINDERNOTE;
            objACM_CRMMainActivities.ESTCOST = ESTCOST;
            objACM_CRMMainActivities.GROUPCODE = GROUPCODE;
            objACM_CRMMainActivities.USERCODEENTERED = USERCODEENTERED;
            objACM_CRMMainActivities.UPDTTIME = UPDTTIME;
            objACM_CRMMainActivities.UploadDate = UploadDate;
            objACM_CRMMainActivities.USERNAME = USERNAME;
            objACM_CRMMainActivities.Remarks = Remarks;
            objACM_CRMMainActivities.CRUP_ID = CRUP_ID;
            objACM_CRMMainActivities.Version = Version1;
            objACM_CRMMainActivities.Type = Type;
            objACM_CRMMainActivities.MyStatus = MyStatus;
            objACM_CRMMainActivities.MainID = MainID;
            objACM_CRMMainActivities.ModuleID = ModuleID;
            objACM_CRMMainActivities.DisplayFDName = Name;
            objACM_CRMMainActivities.Description = Discription;
            DB.CRMMainActivities.AddObject(objACM_CRMMainActivities);
            DB.SaveChanges();
            int REFID1 = REFID;
            string REFTYPE = ACTIVITYE;
            string REFSUBTYPE = ACTIVITYE;
            string SHORTNAME = REFNO;
            string REFNAME1 = REFNO;
            string REFNAME2 = REFNO;
            string REFNAME3 = REFNO;
            string SWITCH1 = "0";
            string SWITCH2 = "0";
            string SWITCH3 = "0";
            int SWITCH4 = ActivityCode;
            string ACTIVE = "Y";
            string Infrastructure = "N";
            DateTime SyncDate = DateTime.Now;
            Classes.ACMClass.InsertDataREFTABLE(TenentID, REFID1, REFTYPE, REFSUBTYPE, SHORTNAME, REFNAME1, REFNAME2, REFNAME3, SWITCH1, SWITCH2, SWITCH3, SWITCH4, Remarks, ACTIVE, CRUP_ID, Infrastructure, SyncDate);
            int MenuID = 0;
            int ActivityID = REFID;
            string perrefno = REFID.ToString();
            string GroupBy = ACTIVITYE;
            string AMIGLOBAL1 = "Y";
            int DocID = 0;
            int ToColumn = 0;
            int FromColumn = 0;
            string Active = "Y";
            string GROUPCODE1 = "A";
            int MainSubRefNo = 0;
            string Msg = Name;
            string Discrpiontikit = Discription;
            string URL = UrlRedirct;
            Classes.ACMClass.InsertACM_CRMActivities(TenentID, COMPID, ActivityCode, LinkMasterCODE, MenuID, ActivityID, ACTIVITYE, REFTYPE, REFSUBTYPE, perrefno, perrefno, USERNAME, perrefno, AMIGLOBAL1, AMIGLOBAL1, Msg, Discrpiontikit, ESTCOST, GROUPCODE1, USERCODEENTERED, UPDTTIME, UploadDate, USERNAME, CRUP_ID, UPDTTIME, UploadDate, GROUPCODE1, Version1, Type, MyStatus, GroupBy, DocID, ToColumn, FromColumn, Active, MainSubRefNo, URL, 0, 0, 0, 0, 0);
            return ActivityCode;
        }

        public static void InsertACM_CRMActivities(int TenentID, int COMPID, int MasterCODE, int LinkMasterCODE, int MenuID, int ActivityID, string ACTIVITYTYPE, string REFTYPE, string REFSUBTYPE, string PerfReferenceNo, string EarlierRefNo, string NextUser, string NextRefNo, string AMIGLOBAL, string MYPERSONNEL, string ActivityPerform, string REMINDERNOTE, int ESTCOST, string GROUPCODE, string USERCODEENTERED, DateTime UPDTTIME, DateTime UploadDate, string USERNAME, int CRUP_ID, DateTime InitialDate, DateTime DeadLineDate, string RouteID, string Version1, int Type, string MyStatus, string GroupBy, int DocID, int ToColumn, int FromColumn, string Active, int MainSubRefNo, string URl, int HelpDept = 0, int HelpComplain = 0, int HelpLocation = 0, int HelpCatID = 0, int HelpSubID = 0, string Prefix = null, int aspcomment = 0, int investigation = 0)
        {

            Database.CallEntities DB = new Database.CallEntities();
            if (DB.CRMActivities.Where(p => p.MasterCODE == MasterCODE && p.TenentID == TenentID && p.Active == "Y").Count() > 0)
            {
                var list = DB.CRMActivities.Where(p => p.MasterCODE == MasterCODE && p.TenentID == TenentID && p.Active == "Y").ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    int ID = Convert.ToInt32(list[i].MyLineNo);
                    CRMActivity obj = DB.CRMActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE && p.MyLineNo == ID && p.Active == "Y");
                    obj.Active = "N";
                    DB.SaveChanges();
                }
            }
            //int UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            Database.CRMActivity objACM_CRMActivities = new Database.CRMActivity();
            objACM_CRMActivities.TenentID = TenentID;
            objACM_CRMActivities.COMPID = COMPID;
            //if (Prefix == "" || Prefix == null)
            //    objACM_CRMActivities.Prefix = "ONL";
            //else
            //    objACM_CRMActivities.Prefix = Prefix;
            //string PN = DB.CRMMainActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).Patient_Name;
            //string MRN = DB.CRMMainActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).MRN;
            //string CN = DB.CRMMainActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).ComplaintNumber;
            //int report = Convert.ToInt32(DB.CRMMainActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).ReportedBy);
            //string contact = DB.CRMMainActivities.Single(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).Contact;
            objACM_CRMActivities.MasterCODE = MasterCODE;
            int Lines = DB.CRMActivities.Where(p => p.TenentID == TenentID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TenentID && p.MasterCODE == MasterCODE).Max(p => p.MyLineNo) + 1) : 1;
            objACM_CRMActivities.MyLineNo = Lines;
            objACM_CRMActivities.LinkMasterCODE = LinkMasterCODE;
            objACM_CRMActivities.LocationID = 1;
            objACM_CRMActivities.MenuID = MenuID;
            objACM_CRMActivities.ActivityID = ActivityID;
            objACM_CRMActivities.ACTIVITYTYPE = ACTIVITYTYPE;
            objACM_CRMActivities.REFTYPE = REFTYPE;
            objACM_CRMActivities.REFSUBTYPE = REFSUBTYPE;
            objACM_CRMActivities.PerfReferenceNo = PerfReferenceNo;
            objACM_CRMActivities.EarlierRefNo = EarlierRefNo;
            objACM_CRMActivities.NextUser = NextUser;
            objACM_CRMActivities.NextRefNo = NextRefNo;
            objACM_CRMActivities.AMIGLOBAL = AMIGLOBAL;
            objACM_CRMActivities.MYPERSONNEL = MYPERSONNEL;
            objACM_CRMActivities.ActivityPerform = ActivityPerform;
            objACM_CRMActivities.REMINDERNOTE = REMINDERNOTE;
            objACM_CRMActivities.ESTCOST = ESTCOST;
            objACM_CRMActivities.GROUPCODE = GROUPCODE;
            objACM_CRMActivities.USERCODEENTERED = USERCODEENTERED;
            objACM_CRMActivities.UPDTTIME = UPDTTIME;
            objACM_CRMActivities.UploadDate = UploadDate;
            objACM_CRMActivities.USERNAME = USERNAME;
            objACM_CRMActivities.CRUP_ID = CRUP_ID;
            objACM_CRMActivities.InitialDate = InitialDate;
            objACM_CRMActivities.DeadLineDate = DeadLineDate;
            objACM_CRMActivities.RouteID = "helpdesk";
            objACM_CRMActivities.Version = Version1;
            objACM_CRMActivities.Type = 1;
            objACM_CRMActivities.MyStatus = MyStatus;
            // objACM_CRMActivities.USERCODE = UID.ToString();
            objACM_CRMActivities.GroupBy = GroupBy;
            objACM_CRMActivities.DocID = DocID;
            objACM_CRMActivities.ToColumn = ToColumn;
            objACM_CRMActivities.FromColumn = FromColumn;
            objACM_CRMActivities.Active = Active;
            objACM_CRMActivities.MainSubRefNo = MainSubRefNo;
            objACM_CRMActivities.UrlRedirct = URl;
            objACM_CRMActivities.Prefix = "OFL";


            //objACM_CRMActivities.TickDepartmentID = HelpDept;// , HelpComplain, HelpLocation, HelpCatID, HelpSubID
            //objACM_CRMActivities.TickPhysicalLocation = HelpLocation;
            //objACM_CRMActivities.TickComplainType = HelpComplain;
            //objACM_CRMActivities.TickCatID = HelpCatID;
            //objACM_CRMActivities.TickSubCatID = HelpSubID;
            //objACM_CRMActivities.aspcomment = aspcomment;
            //objACM_CRMActivities.Patient_Name = PN;
            //objACM_CRMActivities.MRN = MRN;
            //objACM_CRMActivities.ReportedBy = report;
            //objACM_CRMActivities.Contact = contact;
            //objACM_CRMActivities.investigation = investigation;
            //objACM_CRMActivities.ComplaintNumber = CN;

            DB.CRMActivities.AddObject(objACM_CRMActivities);
            DB.SaveChanges();

            if (MyStatus == "Closed")
            {
                Database.CRMActivity objact = DB.CRMActivities.Single(p => p.TenentID == TenentID && p.COMPID == COMPID && p.MasterCODE == MasterCODE && p.MyLineNo == Lines);
                objact.ExpEndDate = DateTime.Now;
                DB.SaveChanges();
            }
        }
        public static void InsertDataACMPRIVILAGEMENU(int TenentID, int LOCATIONID, int PRIVILEGE_ID, int MEMUID, int PRIVILEGE_MENU_ID = 0, string IS_VISIBLE = "", string IS_ENABLE = "", string ACTIVE_FLAG = "", int CRUP_ID = 999999999, int MySerial = 0, string ALL_FLAG = "", string ADD_FLAG = "", string MODIFY_FLAG = "", string DELETE_FLAG = "", string VIEW_FLAG = "", int PRIVILAGEFOR = 0)
        {
            //  int PrivillageID = 0;
            bool flag = false;
            Database.CallEntities DB = new Database.CallEntities();
            Database.PRIVILAGE_MENUDemon objPRIVILAGE_MENU = new Database.PRIVILAGE_MENUDemon();
            if (PRIVILEGE_MENU_ID == 0)
            {
                objPRIVILAGE_MENU = new Database.PRIVILAGE_MENUDemon();
                //  objPRIVILAGE_MENU.PRIVILEGE_MENU_ID = DB.PRIVILAGE_MENU.Count() > 0 ? Convert.ToInt32(DB.PRIVILAGE_MENU.Max(p => p.PRIVILEGE_MENU_ID) + 1) : 1; ;
                flag = true;
            }
            else
            {
                objPRIVILAGE_MENU = DB.PRIVILAGE_MENUDemon.Single(p => p.PRIVILEGE_MENU_ID == PRIVILEGE_MENU_ID);
            }

            objPRIVILAGE_MENU.TenentID = TenentID;
            objPRIVILAGE_MENU.LOCATION_ID = LOCATIONID;
            objPRIVILAGE_MENU.PRIVILEGE_ID = PRIVILEGE_ID;
            objPRIVILAGE_MENU.PRIVILAGEFOR = PRIVILAGEFOR;
            objPRIVILAGE_MENU.MENU_ID = MEMUID;
            objPRIVILAGE_MENU.IS_VISIBLE = IS_VISIBLE;
            objPRIVILAGE_MENU.IS_ENABLE = IS_ENABLE;
            objPRIVILAGE_MENU.ACTIVE_FLAG = ACTIVE_FLAG;
            objPRIVILAGE_MENU.CRUP_ID = 1;
            objPRIVILAGE_MENU.MySerial = MySerial;
            objPRIVILAGE_MENU.ALL_FLAG = ALL_FLAG;
            objPRIVILAGE_MENU.ADD_FLAG = ADD_FLAG;
            objPRIVILAGE_MENU.MODIFY_FLAG = MODIFY_FLAG;
            objPRIVILAGE_MENU.DELETE_FLAG = DELETE_FLAG;
            objPRIVILAGE_MENU.VIEW_FLAG = VIEW_FLAG;
            if (flag == true)
            {
                DB.PRIVILAGE_MENUDemon.AddObject(objPRIVILAGE_MENU);
            }

            DB.SaveChanges();

        }

        public static void InsertDataACMMODULEMAP(int TenentID, int LOCATION_ID, bool Flagvalue, int PRIVILEGE_ID, int MODULE_ID, int UserID, int MODULE_MAP_ID = 0, string ACTIVE_FLAG = "", int CRUP_ID = 1, int MySerial = 999999999, string ALL_FLAG = "", string ADD_FLAG = "", string MODIFY_FLAG = "", string DELETE_FLAG = "", string VIEW_FLAG = "")
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool flag = Flagvalue;
            Database.MODULE_MAP objMODULE_MAP = new Database.MODULE_MAP();

            objMODULE_MAP = new Database.MODULE_MAP();
            //flag = true;

            //else
            //{
            //    objMODULE_MAP = DB.MODULE_MAP.SingleOrDefault(p => p.MODULE_MAP_ID == MODULE_MAP_ID);
            //}
            if (TenentID != 0)
            {
                objMODULE_MAP.TenentID = TenentID;
            }
            if (LOCATION_ID != 0)
            {
                objMODULE_MAP.LOCATION_ID = LOCATION_ID;
            }
            if (PRIVILEGE_ID != 0)
            {
                objMODULE_MAP.PRIVILEGE_ID = PRIVILEGE_ID;
            }
            if (MODULE_ID != 0)
            {
                objMODULE_MAP.MODULE_ID = MODULE_ID;
            }
            if (UserID != 0)
            {
                objMODULE_MAP.UserID = UserID;
            }

            objMODULE_MAP.ACTIVE_FLAG = ACTIVE_FLAG;
            if (TenentID != 0)
            {
                objMODULE_MAP.TenentID = TenentID;
            }
            if (CRUP_ID != 0)
            {
                objMODULE_MAP.CRUP_ID = CRUP_ID;
            }

            objMODULE_MAP.MySerial = MySerial;
            objMODULE_MAP.ALL_FLAG = ALL_FLAG;
            objMODULE_MAP.ADD_FLAG = ADD_FLAG;
            objMODULE_MAP.MODIFY_FLAG = MODIFY_FLAG;
            objMODULE_MAP.DELETE_FLAG = DELETE_FLAG;
            objMODULE_MAP.VIEW_FLAG = VIEW_FLAG;
            objMODULE_MAP.MODULE_MAP_ID = MODULE_MAP_ID;
            if (flag == true)
            {
               
                //objMODULE_MAP.MODULE_MAP_ID = DB.MODULE_MAP.Count() > 0 ? Convert.ToInt32(DB.MODULE_MAP.Max(p => p.MODULE_MAP_ID) + 1) : 1; ;

                // objMODULE_MAP.MODULE_MAP_ID = DB.MODULE_MAP.Count() > 0 ? Convert.ToInt32(DB.MODULE_MAP.Max(p => p.MODULE_MAP_ID) + 1) : 1; ;

                DB.MODULE_MAP.AddObject(objMODULE_MAP);
            }
            DB.SaveChanges();
        }

        public static void InsertDataACMUSERROLE(int TenentID, int LOCATIONID, int PRIVILEGE_ID, int USER_ID, int ROLE_ID = 0, int USER_ROLE_ID = 0, DateTime? ACTIVE_FROM_DT = null, DateTime? ACTIVE_TO_DT = null, int CRUP_ID = 1, string ACTIVE_FLAG = "N")
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool RoleFlag = false;
            Database.USER_ROLE objUSER_ROLE = new Database.USER_ROLE();
            if (USER_ROLE_ID == 0)
            {
                objUSER_ROLE = new Database.USER_ROLE();
                objUSER_ROLE.ROLE_ID = DB.USER_ROLE.Count() > 0 ? Convert.ToInt32(DB.USER_ROLE.Max(p => p.ROLE_ID) + 1) : 1;
                RoleFlag = true;
            }
            else
            {
                objUSER_ROLE = DB.USER_ROLE.Single(p => p.USER_ROLE_ID == USER_ROLE_ID);
            }
            objUSER_ROLE.TenentID = TenentID;
            objUSER_ROLE.LOCATION_ID = LOCATIONID;
            //objUSER_ROLE.USER_ROLE_ID = USER_ROLE_ID;
            objUSER_ROLE.PRIVILEGE_ID = PRIVILEGE_ID;
            objUSER_ROLE.ROLE_ID = ROLE_ID;
            objUSER_ROLE.USER_ID = USER_ID;
            objUSER_ROLE.ACTIVE_FLAG = ACTIVE_FLAG;
            if (ACTIVE_FROM_DT != null)
            {
                objUSER_ROLE.ACTIVE_FROM_DT = Convert.ToDateTime(ACTIVE_FROM_DT);
            }
            else
            {
                objUSER_ROLE.ACTIVE_FROM_DT = DateTime.Now;
            }
            if (ACTIVE_FROM_DT != null)
            {
                objUSER_ROLE.ACTIVE_TO_DT = Convert.ToDateTime(ACTIVE_TO_DT);
            }
            else
            {
                objUSER_ROLE.ACTIVE_TO_DT = DateTime.Now;
            }
            objUSER_ROLE.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.USER_ROLE.AddObject(objUSER_ROLE);
            }
            DB.SaveChanges();
        }

        public static void InsertDataACMUSERRIGHTS(int TenentID, int LOCATIONID, int PRIVILEGE_ID, int USER_ID, int RIGHTS_ID = 0, bool ADD_FLAG = false, bool MODIFY_FLAG = false, bool DELETE_FLAG = false, bool VIEW_FLAG = false, bool ALL_FLAG = false, int CRUP_ID = 999999999, bool IsLabelUpdate = false)
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool RightFlag = false;
            Database.USER_RIGHTS objUSER_RIGHTS = new Database.USER_RIGHTS();
            if (RIGHTS_ID == 0)
            {
                objUSER_RIGHTS = new Database.USER_RIGHTS();
                objUSER_RIGHTS.RIGHTS_ID = DB.USER_RIGHTS.Count() > 0 ? Convert.ToInt32(DB.USER_RIGHTS.Max(p => p.RIGHTS_ID) + 1) : 1;
                RightFlag = true;
            }
            else
            {
                objUSER_RIGHTS = DB.USER_RIGHTS.Single(p => p.RIGHTS_ID == RIGHTS_ID);
            }
            objUSER_RIGHTS.TenentID = TenentID;
            objUSER_RIGHTS.LOCATION_ID = LOCATIONID;
            if (USER_ID != 0)
            {
                objUSER_RIGHTS.USER_ID = USER_ID;
            }

            objUSER_RIGHTS.PRIVILEGE_ID = PRIVILEGE_ID;
            objUSER_RIGHTS.ADD_FLAG = ADD_FLAG;
            objUSER_RIGHTS.MODIFY_FLAG = MODIFY_FLAG;
            objUSER_RIGHTS.DELETE_FLAG = DELETE_FLAG;
            objUSER_RIGHTS.VIEW_FLAG = VIEW_FLAG;
            objUSER_RIGHTS.ALL_FLAG = ALL_FLAG;
            objUSER_RIGHTS.CRUP_ID = CRUP_ID;
            objUSER_RIGHTS.IsLabelUpdate = IsLabelUpdate;
            if (RightFlag == true)
            {
                DB.USER_RIGHTS.AddObject(objUSER_RIGHTS);
            }
            DB.SaveChanges();
        }


        public static void InsertDataACMROLEMASTER(int TenentID, int LOCATION_ID, int ROLE_ID, string ROLE_NAME, string ROLE_NAME1, string ROLE_NAME2, string ROLE_DESC, string ACTIVE_FLAG, DateTime ACTIVE_FROM_DT, DateTime ACTIVE_TO_DT, int ERP_TenentID, int CRUP_ID = 999999999)
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool RoleFlag = false;
            Database.ROLE_MST objROLE_MST = new Database.ROLE_MST();
            if (ROLE_ID == 0)
            {
                objROLE_MST = new Database.ROLE_MST();
                //  objROLE_MST.ROLE_ID = DB.ROLE_MST.Count() > 0 ? Convert.ToInt32(DB.USER_RIGHT.Max(p => p.RIGHTS_ID) + 1) : 1; ;
                RoleFlag = true;
            }
            else
            {
                objROLE_MST = DB.ROLE_MST.Single(p => p.ROLE_ID == ROLE_ID);
            }
            objROLE_MST.TenentID = TenentID;
            //  objROLE_MST.LOCATION_ID = LOCATION_ID;
            objROLE_MST.ROLE_ID = ROLE_ID;
            objROLE_MST.ROLE_NAME = ROLE_NAME;
            objROLE_MST.ROLE_NAME1 = ROLE_NAME1;
            objROLE_MST.ROLE_NAME2 = ROLE_NAME2;
            objROLE_MST.ROLE_DESC = ROLE_DESC;
            objROLE_MST.ACTIVE_FLAG = ACTIVE_FLAG;
            objROLE_MST.ACTIVE_FROM_DT = ACTIVE_FROM_DT;
            objROLE_MST.ACTIVE_TO_DT = ACTIVE_TO_DT;
            objROLE_MST.ERP_TENANT_ID = ERP_TenentID;
            objROLE_MST.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.ROLE_MST.AddObject(objROLE_MST);
            }
            DB.SaveChanges();
        }


        public static void InsertDataACMPRIVILLEGEMASTER(int TenentID, int LOCATION_ID, int PRIVILEGE_ID, string PRIVILEGE_NAME, string PRIVILEGE_DESC, string ACTIVE_FLAG, int CRUP_ID, int MODULE_ID, string PRIVILEGE_NAME1, string PRIVILEGE_NAME2)
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool RoleFlag = false;
            Database.PRIVILEGE_MST objPRIVILEGE_MST = new Database.PRIVILEGE_MST();
            if (PRIVILEGE_ID == 0)
            {
                objPRIVILEGE_MST = new Database.PRIVILEGE_MST();
                objPRIVILEGE_MST.PRIVILEGE_ID = DB.PRIVILEGE_MST.Count() > 0 ? Convert.ToInt32(DB.PRIVILEGE_MST.Max(p => p.PRIVILEGE_ID) + 1) : 1;
                RoleFlag = true;
            }
            else
            {
                objPRIVILEGE_MST = DB.PRIVILEGE_MST.Single(p => p.PRIVILEGE_ID == PRIVILEGE_ID && p.TenentID == TenentID);
            }
            objPRIVILEGE_MST.TenentID = TenentID;
            //  objPRIVILEGE_MST.LOCATION_ID = LOCATION_ID;
            //objPRIVILEGE_MST.PRIVILEGE_ID = PRIVILEGE_ID;
            objPRIVILEGE_MST.PRIVILEGE_NAME = PRIVILEGE_NAME;
            objPRIVILEGE_MST.PRIVILEGE_DESC = PRIVILEGE_DESC;
            objPRIVILEGE_MST.ACTIVE_FLAG = ACTIVE_FLAG;
            objPRIVILEGE_MST.CRUP_ID = CRUP_ID;
            objPRIVILEGE_MST.MODULE_ID = MODULE_ID;
            objPRIVILEGE_MST.PRIVILEGE_NAME1 = PRIVILEGE_NAME1;
            objPRIVILEGE_MST.PRIVILEGE_NAME2 = PRIVILEGE_NAME2;
            if (RoleFlag == true)
            {
                DB.PRIVILEGE_MST.AddObject(objPRIVILEGE_MST);
            }
            DB.SaveChanges();
        }


        public static int InsertDataACMMODULEMASTER(int TenentID, int LOCATION_ID, int Module_Id, string MYSYSNAME, string Module_Name, string Module_NameO, string Module_NameT, string Module_Desc, int Parent_Module_id, int Module_Order, string ACTIVE_FLAG, string Module_Location, int CRUP_ID = 999999999)
        {
            Database.CallEntities DB = new Database.CallEntities();
            bool Module_IdFlag = false;
            Database.MODULE_MST objMODULE_MST = new Database.MODULE_MST();
            if (Module_Id == 0)
            {
                objMODULE_MST = new Database.MODULE_MST();
                objMODULE_MST.Module_Id = DB.MODULE_MST.Count() > 0 ? Convert.ToInt32(DB.MODULE_MST.Max(p => p.Module_Id) + 1) : 1;
                Module_IdFlag = true;
            }
            else
            {
                objMODULE_MST = DB.MODULE_MST.Single(p => p.Module_Id == Module_Id);
            }
            //objMODULE_MST.TenentID = TenentID;
            // objMODULE_MST.LOCATION_ID = LOCATION_ID;
            objMODULE_MST.MYSYSNAME = MYSYSNAME;
            objMODULE_MST.Module_Name = Module_Name;
            objMODULE_MST.Module_NameO = Module_NameO;
            objMODULE_MST.Module_NameT = Module_NameT;
            objMODULE_MST.Module_Desc = Module_Desc;
            objMODULE_MST.Parent_Module_id = Parent_Module_id;
            objMODULE_MST.Module_Order = Module_Order;
            objMODULE_MST.ACTIVE_FLAG = ACTIVE_FLAG;
            objMODULE_MST.CRUP_ID = CRUP_ID;
            objMODULE_MST.Module_Location = Module_Location;
            if (Module_IdFlag == true)
            {
                DB.MODULE_MST.AddObject(objMODULE_MST);
            }
            DB.SaveChanges();
            return objMODULE_MST.Module_Id;
        }

        public static void InsertDATAACMREFTABLE(int TenentID, int Location_ID, int MenuID, int ActivityID, string MainActivityType, string SubActivityType, string SHORTNAME, string NameEng, string NameOth2, string NameOth3, string AspxFileName, string Parameter1, string Parameter2, string Parameter3, int Parameter4, string Parameter5, string Parameter6, int Parameter7, int Parameter8, int Parameter9, int Parameter10, string Remarks, string ACTIVE, int CRUP_ID, string Infrastructure, DateTime SyncDate)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.REFTABLE obj_Ref = new Database.REFTABLE();
            obj_Ref.TenentID = TenentID;
            //obj_Ref.Location_ID = Location_ID;
            //obj_Ref.MenuID = MenuID;
            //obj_Ref.ActivityID = ActivityID;
            //obj_Ref.MainActivityType = MainActivityType;
            //obj_Ref.SubActivityType = SubActivityType;
            obj_Ref.SHORTNAME = SHORTNAME;
            //obj_Ref.NameEng = NameEng;
            //obj_Ref.NameOth2 = NameOth2;
            //obj_Ref.NameOth3 = NameOth3;
            //obj_Ref.AspxFileName = AspxFileName;
            //obj_Ref.Parameter1 = Parameter1;
            //obj_Ref.Parameter2 = Parameter2;
            //obj_Ref.Parameter3 = Parameter3;
            //obj_Ref.Parameter4 = Parameter4;
            //obj_Ref.Parameter5 = Parameter5;
            //obj_Ref.Parameter6 = Parameter6;
            //obj_Ref.Parameter7 = Parameter7;
            //obj_Ref.Parameter8 = Parameter8;
            //obj_Ref.Parameter9 = Parameter9;
            //obj_Ref.Parameter10 = Parameter10;
            obj_Ref.Remarks = Remarks;
            obj_Ref.ACTIVE = ACTIVE;
            obj_Ref.CRUP_ID = CRUP_ID;
            obj_Ref.Infrastructure = Infrastructure;
            obj_Ref.SyncDate = SyncDate;
            DB.REFTABLEs.AddObject(obj_Ref);
            DB.SaveChanges();
        }
        public static void INSERTDATAACESSRIGHTS(int TenentID, int LOCATION_ID, int USER_ID, int Activity_ID, int Module_ID, bool ADD_FLAG, bool MODIFY_FLAG, bool DELETE_FLAG, bool VIEW_FLAG, bool ALL_FLAG, int CRUP_ID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.ACTIVITYRIGHT obj_Rights = new Database.ACTIVITYRIGHT();
            obj_Rights.TenentID = TenentID;
            obj_Rights.LOCATION_ID = LOCATION_ID;
            obj_Rights.USER_ID = USER_ID;
            obj_Rights.Activity_ID = Activity_ID;
            obj_Rights.Module_ID = Module_ID;
            obj_Rights.ADD_FLAG = ADD_FLAG;
            obj_Rights.MODIFY_FLAG = MODIFY_FLAG;
            obj_Rights.DELETE_FLAG = DELETE_FLAG;
            obj_Rights.VIEW_FLAG = VIEW_FLAG;
            obj_Rights.ALL_FLAG = ALL_FLAG;
            obj_Rights.CRUP_ID = CRUP_ID;
            DB.ACTIVITYRIGHTS.AddObject(obj_Rights);
            DB.SaveChanges();
        }


        public static void UpdateTempUser(int MEMUID12, int Master_ID, int Module_ID,
            string Menu_Type, string Name1, string Name2,
            string Name3, string LINK, string URLREWRITE,
            string MenuLocation, decimal MENU_ORDER, string DOC_PARENT,
            string SMALLTEXT, DateTime ACTIVETILLDATE, string CONPATH,
            string COMMANLINE, string METAKEYWORD, string METADESCRIPTION,
            string HEADERVISIBLEDATA, string HEADERINVISIBLEDATA, string FOOTERVISIBLEDATA,
            string FOOTERINVISIBLEDATA, int REFID, int TenentID,
            int LOCATIONID = 1, int MYBUSID = 0, int CRUP_ID = 0,
            string METATITLE = "", int ADDFLAGE = 0, int EDITFLAGE = 0,
            int DELFLAGE = 0, int PRINTFLAGE = 0, int AMIGLOBALE = 0,
            int MYPERSONAL = 0, int ACTIVE_FLAG = 0, DateTime? ActiveMenuDate = null,
            bool ActiveMenu = false, int USER_ID = 0, int ROLEID = 0, string flage = "")
        {
            Database.CallEntities DB = new Database.CallEntities();
            if (flage == "Insert")
            {
                Database.tempUser OBJtempuser = new Database.tempUser();
                OBJtempuser.TenentID = TenentID;
                OBJtempuser.PRIVILAGEID = PRINTFLAGE;
                OBJtempuser.PRIVILAGESOURCE = "2";
                OBJtempuser.MENUID = MEMUID12;
                OBJtempuser.LocationID = LOCATIONID;
                //obj.PRIVILAGE_MENUID = PRIVILEGE_MENU_ID;
                OBJtempuser.MODULE_ID = Module_ID;
                OBJtempuser.UserID = USER_ID;
                OBJtempuser.ROLE_ID = ROLEID;
                OBJtempuser.ADD_FLAG = ADDFLAGE == 1 ? "Y" : "N";
                OBJtempuser.MODIFY_FLAG = EDITFLAGE == 1 ? "Y" : "N";
                OBJtempuser.DELETE_FLAG = DELFLAGE == 1 ? "Y" : "N";
                OBJtempuser.VIEW_FLAG = EDITFLAGE == 1 ? "Y" : "N";
                //obj.PRINTFLAGE = PRINTFLAGE == 1 ? "Y" : "N";
                OBJtempuser.LINK = LINK;
                OBJtempuser.MASTER_ID = Master_ID;
                OBJtempuser.MENU_TYPE = Menu_Type;
                OBJtempuser.MENU_NAME1 = Name1;
                OBJtempuser.MENU_NAME2 = Name2;
                OBJtempuser.MENU_NAME3 = Name3;
                OBJtempuser.URLREWRITE = URLREWRITE;
                OBJtempuser.MENU_LOCATION = MenuLocation;
                OBJtempuser.MENU_ORDER = MENU_ORDER;
                OBJtempuser.DOC_PARENT = DOC_PARENT;
                OBJtempuser.AMIGLOBALE = AMIGLOBALE;
                OBJtempuser.MYPERSONAL = MYPERSONAL;
                OBJtempuser.SMALLTEXT = SMALLTEXT;
                OBJtempuser.ICONPATH = CONPATH;
                OBJtempuser.METATITLE = METATITLE;
                OBJtempuser.METAKEYWORD = METAKEYWORD;
                OBJtempuser.METADESCRIPTION = METADESCRIPTION;
                OBJtempuser.HEADERVISIBLEDATA = HEADERVISIBLEDATA;
                OBJtempuser.HEADERINVISIBLEDATA = HEADERINVISIBLEDATA;
                OBJtempuser.FOOTERVISIBLEDATA = FOOTERVISIBLEDATA;
                OBJtempuser.FOOTERINVISIBLEDATA = FOOTERINVISIBLEDATA;
                OBJtempuser.REFID = REFID;
                OBJtempuser.MYBUSID = MYBUSID;
                OBJtempuser.ACTIVETILLDATE = ActiveMenuDate;
                OBJtempuser.ACTIVEMENU = ActiveMenu == true ? true : false;
                DB.tempUsers.AddObject(OBJtempuser);
                DB.SaveChanges();
            }
            if (flage == "Update")
            {
                if (DB.tempUsers.Where(p => p.MENUID == MEMUID12 && p.TenentID == TenentID && p.MODULE_ID == Module_ID).Count() > 0)
                {
                    var obj = DB.tempUsers.Single(p => p.MENUID == MEMUID12 && p.TenentID == TenentID && p.MODULE_ID == Module_ID);
                    obj.TenentID = TenentID;
                    //obj.PRIVILAGEID = PRINTFLAGE;
                    //obj.PRIVILAGESOURCE = "2";
                    //obj.MENUID = MEMUID12;
                    //obj.PRIVILAGE_MENUID = PRIVILEGE_MENU_ID;
                    obj.MODULE_ID = Module_ID;
                    obj.ADD_FLAG = ADDFLAGE == 1 ? "Y" : "N";
                    obj.MODIFY_FLAG = EDITFLAGE == 1 ? "Y" : "N";
                    obj.DELETE_FLAG = DELFLAGE == 1 ? "Y" : "N";
                    obj.VIEW_FLAG = EDITFLAGE == 1 ? "Y" : "N";
                    //obj.PRINTFLAGE = PRINTFLAGE == 1 ? "Y" : "N";
                    obj.LINK = LINK;
                    obj.MASTER_ID = Master_ID;
                    obj.MENU_TYPE = Menu_Type;
                    obj.MENU_NAME1 = Name1;
                    obj.MENU_NAME2 = Name2;
                    obj.MENU_NAME3 = Name3;
                    obj.URLREWRITE = URLREWRITE;
                    obj.MENU_LOCATION = MenuLocation;
                    obj.MENU_ORDER = MENU_ORDER;
                    obj.DOC_PARENT = DOC_PARENT;
                    obj.AMIGLOBALE = AMIGLOBALE;
                    obj.MYPERSONAL = MYPERSONAL;
                    obj.SMALLTEXT = SMALLTEXT;
                    obj.ICONPATH = CONPATH;
                    obj.METATITLE = METATITLE;
                    obj.METAKEYWORD = METAKEYWORD;
                    obj.METADESCRIPTION = METADESCRIPTION;
                    obj.HEADERVISIBLEDATA = HEADERVISIBLEDATA;
                    obj.HEADERINVISIBLEDATA = HEADERINVISIBLEDATA;
                    obj.FOOTERVISIBLEDATA = FOOTERVISIBLEDATA;
                    obj.FOOTERINVISIBLEDATA = FOOTERINVISIBLEDATA;
                    obj.REFID = REFID;
                    obj.MYBUSID = MYBUSID;
                    obj.ACTIVETILLDATE = ACTIVETILLDATE;
                    obj.ACTIVEMENU = ACTIVE_FLAG == 1 ? true : false;
                    // obj.ACTIVEMODULE = 
                    DB.SaveChanges();
                }
            }
        }

        public static int InsertACM_CRMMainActivities(int TenentID, int COMPID, int LinkMasterCODE, int LocationID, int ID, int RouteID, int USERCODE, string ACTIVITYE, string ACTIVITYA, string ACTIVITYA2, bool AMIGLOBAL, bool MYPERSONNEL, int INTERVALDAYS, bool REPEATFOREVER, DateTime REPEATTILL, string REMINDERNOTE, int ESTCOST, int GROUPCODE, string USERCODEENTERED, DateTime UPDTTIME, string USERNAME, string Remarks, int CRUP_ID, string Version1, int Type, string MyStatus, int MainID, int ModuleID, string UrlRedirct, string Name, string Discription)
        {
            Database.CallEntities DB = new Database.CallEntities();

            int ActivityCode = DB.CRMMainActivities.Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Max(p => p.MasterCODE) + 1) : 1;
            int REFID = DB.REFTABLEs.Count() > 0 ? Convert.ToInt32(DB.REFTABLEs.Max(p => p.REFID) + 1) : 1;
            string REFNO = ACTIVITYE + "_" + ActivityCode + "_" + REFID;

            Database.CRMMainActivity objACM_CRMMainActivities = new Database.CRMMainActivity();
            objACM_CRMMainActivities.TenentID = TenentID;
            objACM_CRMMainActivities.COMPID = COMPID;
            objACM_CRMMainActivities.MasterCODE = ActivityCode;
            objACM_CRMMainActivities.LinkMasterCODE = LinkMasterCODE;
            objACM_CRMMainActivities.LocationID = LocationID;
            objACM_CRMMainActivities.MyID = ID;
            objACM_CRMMainActivities.RouteID = RouteID;
            objACM_CRMMainActivities.USERCODE = USERCODE;
            objACM_CRMMainActivities.ACTIVITYE = ACTIVITYE;
            objACM_CRMMainActivities.ACTIVITYA = ACTIVITYA;
            objACM_CRMMainActivities.ACTIVITYA2 = ACTIVITYA2;
            objACM_CRMMainActivities.Reference = REFNO;
            objACM_CRMMainActivities.AMIGLOBAL = AMIGLOBAL;
            objACM_CRMMainActivities.MYPERSONNEL = MYPERSONNEL;
            objACM_CRMMainActivities.INTERVALDAYS = INTERVALDAYS;
            objACM_CRMMainActivities.REPEATFOREVER = REPEATFOREVER;
            objACM_CRMMainActivities.REPEATTILL = REPEATTILL;
            objACM_CRMMainActivities.REMINDERNOTE = REMINDERNOTE;
            objACM_CRMMainActivities.ESTCOST = ESTCOST;
            objACM_CRMMainActivities.GROUPCODE = GROUPCODE;
            objACM_CRMMainActivities.USERCODEENTERED = USERCODEENTERED;
            objACM_CRMMainActivities.UPDTTIME = UPDTTIME;
            objACM_CRMMainActivities.USERNAME = USERNAME;
            objACM_CRMMainActivities.Remarks = Remarks;
            objACM_CRMMainActivities.CRUP_ID = CRUP_ID;
            objACM_CRMMainActivities.Version = Version1;
            objACM_CRMMainActivities.Type = Type;
            objACM_CRMMainActivities.MyStatus = MyStatus;
            objACM_CRMMainActivities.MainID = MainID;
            objACM_CRMMainActivities.ModuleID = ModuleID;
            objACM_CRMMainActivities.DisplayFDName = Name;
            objACM_CRMMainActivities.Description = Discription;
            DB.CRMMainActivities.AddObject(objACM_CRMMainActivities);
            DB.SaveChanges();
            int REFID1 = REFID;
            string REFTYPE = ACTIVITYE;
            string REFSUBTYPE = ACTIVITYE;
            string SHORTNAME = REFNO;
            string REFNAME1 = REFNO;
            string REFNAME2 = REFNO;
            string REFNAME3 = REFNO;
            string SWITCH1 = "0";
            string SWITCH2 = "0";
            string SWITCH3 = "0";
            int SWITCH4 = ActivityCode;
            string ACTIVE = "Y";
            string Infrastructure = "N";
            DateTime SyncDate = DateTime.Now;
            Classes.ACMClass.InsertDataREFTABLE(TenentID, REFID1, REFTYPE, REFSUBTYPE, SHORTNAME, REFNAME1, REFNAME2, REFNAME3, SWITCH1, SWITCH2, SWITCH3, SWITCH4, Remarks, ACTIVE, CRUP_ID, Infrastructure, SyncDate);
            int MenuID = 0;
            int ActivityID = REFID;
            string perrefno = REFID.ToString();
            string GroupBy = ACTIVITYE;
            string AMIGLOBAL1 = "Y";
            int DocID = 0;
            int ToColumn = 0;
            int FromColumn = 0;
            string Active = "Y";
            string GROUPCODE1 = "A";
            int MainSubRefNo = 0;
            string Msg = Name;
            string Discrpiontikit = Discription;
            string URL = UrlRedirct;
            Classes.ACMClass.InsertACM_CRMActivities(TenentID, COMPID, ActivityCode, LinkMasterCODE, MenuID, ActivityID, ACTIVITYE, REFTYPE, REFSUBTYPE, perrefno, perrefno, USERNAME, perrefno, AMIGLOBAL1, AMIGLOBAL1, Msg, Discrpiontikit, ESTCOST, GROUPCODE1, USERCODEENTERED, UPDTTIME, USERNAME, CRUP_ID, UPDTTIME, UPDTTIME, GROUPCODE1, Version1, Type, MyStatus, GroupBy, DocID, ToColumn, FromColumn, Active, MainSubRefNo, URL);
            return ActivityCode;
        }

        public static void InsertACM_CRMActivities(int TenentID, int COMPID, int MasterCODE, int LinkMasterCODE, int MenuID, int ActivityID, string ACTIVITYTYPE, string REFTYPE, string REFSUBTYPE, string PerfReferenceNo, string EarlierRefNo, string NextUser, string NextRefNo, string AMIGLOBAL, string MYPERSONNEL, string ActivityPerform, string REMINDERNOTE, int ESTCOST, string GROUPCODE, string USERCODEENTERED, DateTime UPDTTIME, string USERNAME, int CRUP_ID, DateTime InitialDate, DateTime DeadLineDate, string RouteID, string Version1, int Type, string MyStatus, string GroupBy, int DocID, int ToColumn, int FromColumn, string Active, int MainSubRefNo, string URl)
        {

            Database.CallEntities DB = new Database.CallEntities();
            if (DB.CRMActivities.Where(p => p.MasterCODE == MasterCODE && p.TenentID == TenentID && p.Active == "Y").Count() > 0)
            {
                var list = DB.CRMActivities.Where(p => p.MasterCODE == MasterCODE && p.TenentID == TenentID && p.Active == "Y").ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    int ID = Convert.ToInt32(list[i].MyLineNo);
                    CRMActivity obj = DB.CRMActivities.Single(p => p.TenentID == TenentID && p.MyLineNo == ID && p.Active == "Y");
                    obj.Active = "N";
                    DB.SaveChanges();
                }
            }
            Database.CRMActivity objACM_CRMActivities = new Database.CRMActivity();
            objACM_CRMActivities.TenentID = TenentID;
            objACM_CRMActivities.COMPID = COMPID;
            objACM_CRMActivities.MasterCODE = MasterCODE;
            objACM_CRMActivities.MyLineNo = DB.CRMActivities.Where(p => p.TenentID == TenentID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TenentID).Max(p => p.MyLineNo) + 1) : 1;
            objACM_CRMActivities.LinkMasterCODE = LinkMasterCODE;
            objACM_CRMActivities.MenuID = MenuID;
            objACM_CRMActivities.ActivityID = ActivityID;
            objACM_CRMActivities.ACTIVITYTYPE = ACTIVITYTYPE;
            objACM_CRMActivities.REFTYPE = REFTYPE;
            objACM_CRMActivities.REFSUBTYPE = REFSUBTYPE;
            objACM_CRMActivities.PerfReferenceNo = PerfReferenceNo;
            objACM_CRMActivities.EarlierRefNo = EarlierRefNo;
            objACM_CRMActivities.NextUser = NextUser;
            objACM_CRMActivities.NextRefNo = NextRefNo;
            objACM_CRMActivities.AMIGLOBAL = AMIGLOBAL;
            objACM_CRMActivities.MYPERSONNEL = MYPERSONNEL;
            objACM_CRMActivities.ActivityPerform = ActivityPerform;
            objACM_CRMActivities.REMINDERNOTE = REMINDERNOTE;
            objACM_CRMActivities.ESTCOST = ESTCOST;
            objACM_CRMActivities.GROUPCODE = GROUPCODE;
            objACM_CRMActivities.USERCODEENTERED = USERCODEENTERED;
            objACM_CRMActivities.UPDTTIME = UPDTTIME;
            objACM_CRMActivities.USERNAME = USERNAME;
            objACM_CRMActivities.CRUP_ID = CRUP_ID;
            objACM_CRMActivities.InitialDate = InitialDate;
            objACM_CRMActivities.DeadLineDate = DeadLineDate;
            objACM_CRMActivities.RouteID = RouteID;
            objACM_CRMActivities.Version = Version1;
            objACM_CRMActivities.Type = Type;
            objACM_CRMActivities.MyStatus = MyStatus;
            objACM_CRMActivities.GroupBy = GroupBy;
            objACM_CRMActivities.DocID = DocID;
            objACM_CRMActivities.ToColumn = ToColumn;
            objACM_CRMActivities.FromColumn = FromColumn;
            objACM_CRMActivities.Active = Active;
            objACM_CRMActivities.MainSubRefNo = MainSubRefNo;
            objACM_CRMActivities.UrlRedirct = URl;
            DB.CRMActivities.AddObject(objACM_CRMActivities);
            DB.SaveChanges();

        }

        public static void InsertDataREFTABLE(int TenentID, int REFID, string REFTYPE, string REFSUBTYPE, string SHORTNAME, string REFNAME1, string REFNAME2, string REFNAME3, string SWITCH1, string SWITCH2, string SWITCH3, int SWITCH4, string Remarks, string ACTIVE, int CRUP_ID, string Infrastructure, DateTime SyncDate)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.REFTABLE objREFTABLE = new Database.REFTABLE();
            objREFTABLE.TenentID = TenentID;
            objREFTABLE.REFID = REFID;
            objREFTABLE.REFTYPE = REFTYPE;
            objREFTABLE.REFSUBTYPE = REFSUBTYPE;
            objREFTABLE.SHORTNAME = SHORTNAME;
            objREFTABLE.REFNAME1 = REFNAME1;
            objREFTABLE.REFNAME2 = REFNAME2;
            objREFTABLE.REFNAME3 = REFNAME3;
            objREFTABLE.SWITCH1 = SWITCH1;
            objREFTABLE.SWITCH2 = SWITCH2;
            objREFTABLE.SWITCH3 = SWITCH3;
            objREFTABLE.SWITCH4 = SWITCH4;
            objREFTABLE.Remarks = Remarks;
            objREFTABLE.ACTIVE = ACTIVE;
            objREFTABLE.CRUP_ID = CRUP_ID;
            objREFTABLE.Infrastructure = Infrastructure;
            objREFTABLE.SyncDate = SyncDate;
            DB.REFTABLEs.AddObject(objREFTABLE);
            DB.SaveChanges();
        }

        public static void InsertDataCRMProgHW(int TenentID, int ActivityID, int StatusID, string ButtionName, bool Allowed, string Parameter2, string Parameter3, bool Active, DateTime Datetime, int Crup_Id, DateTime? RemindDate = null, string URL = null, string URLWrite = null, int LinkMasterCoode = 0)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.CRMProgHW objCRMProgHW = new Database.CRMProgHW();
            objCRMProgHW.TenentID = TenentID;
            objCRMProgHW.ActivityID = ActivityID;
            if (LinkMasterCoode != 0)
                objCRMProgHW.RunningSerial = LinkMasterCoode;
            else
                objCRMProgHW.RunningSerial = DB.CRMProgHWs.Where(p => p.TenentID == TenentID && p.ActivityID == ActivityID).Count() > 0 ? Convert.ToInt32(DB.CRMProgHWs.Where(p => p.TenentID == TenentID && p.ActivityID == ActivityID).Max(p => p.RunningSerial) + 1) : 1;
            objCRMProgHW.StatusID = StatusID;
            objCRMProgHW.ButtionName = ButtionName;
            objCRMProgHW.Allowed = Allowed;
            objCRMProgHW.Parameter2 = Parameter2;
            objCRMProgHW.Parameter3 = Parameter3;
            objCRMProgHW.Active = Active;
            objCRMProgHW.Datetime = Datetime;
            objCRMProgHW.CRUP_ID = Crup_Id;
            objCRMProgHW.URL = URL;
            objCRMProgHW.URLRewrite = URLWrite;
            objCRMProgHW.ReminderDate = RemindDate;
            DB.CRMProgHWs.AddObject(objCRMProgHW);
            DB.SaveChanges();
        }
        public static List<TBLLOCATION> getTBLLOCATION()
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLLOCATION> List = new List<TBLLOCATION>();
            List = DB.TBLLOCATIONs.Where(p => p.Active == "Y").ToList();
            return List;
        }
        public static DropDownList getdropdown(DropDownList drp, int TID, string switch1, string switch2, string switch3, string TableName)
        {
            if (TableName == "TBLLOCATION")
            {
                drp.DataSource = getTBLLOCATION();
                drp.DataTextField = "LOCNAME1";
                drp.DataValueField = "LOCATIONID";
                drp.DataBind();
            }
            drp = new DropDownList();
            return drp;
        }
        public static bool InsertWeb_User_MST(int UserTenent, int Userid, int Locationid, string FIRST_NAME, string LAST_NAME, string FIRST_NAME1, string LAST_NAME1, string FIRST_NAME2, string LAST_NAME2, string LOGIN_ID, string PASSWORD, string PASSWORD_CHNG, int USER_TYPE, string REMARKS, string ACTIVE_FLAG, DateTime LAST_LOGIN_DT, string ACC_LOCK, string FIRST_TIME, string EmailAddress, string Avtar, DateTime Till_DT, int CompId, int USER_DETAIL_ID, bool ACTIVEUSER, DateTime USERDATE, string Flage, string Lang)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.USER_MST objUSER_MST = new Database.USER_MST();
           
                objUSER_MST = new Database.USER_MST();
           
            objUSER_MST.TenentID = UserTenent;
            objUSER_MST.USER_ID = Userid;
            objUSER_MST.LOCATION_ID = Locationid;
            objUSER_MST.FIRST_NAME = FIRST_NAME;
            objUSER_MST.LAST_NAME = LAST_NAME;
            objUSER_MST.FIRST_NAME1 = FIRST_NAME1;
            objUSER_MST.LAST_NAME1 = LAST_NAME1;
            objUSER_MST.FIRST_NAME2 = FIRST_NAME2;
            objUSER_MST.LAST_NAME2 = LAST_NAME2;
            objUSER_MST.LOGIN_ID = LOGIN_ID;
            objUSER_MST.PASSWORD = PASSWORD;
            objUSER_MST.PASSWORD_CHNG = PASSWORD_CHNG;
            objUSER_MST.USER_TYPE = USER_TYPE;
            objUSER_MST.REMARKS = REMARKS;
            objUSER_MST.ACTIVE_FLAG = ACTIVE_FLAG;
            objUSER_MST.LAST_LOGIN_DT = LAST_LOGIN_DT;
            objUSER_MST.ACC_LOCK = ACC_LOCK;
            objUSER_MST.FIRST_TIME = FIRST_TIME;
            objUSER_MST.EmailAddress = EmailAddress;
            objUSER_MST.Avtar = Avtar;
            objUSER_MST.Till_DT = Till_DT;
            objUSER_MST.CompId = CompId;
            objUSER_MST.USER_DETAIL_ID = USER_DETAIL_ID;
            objUSER_MST.ACTIVEUSER = ACTIVEUSER;
            objUSER_MST.USERDATE = USERDATE;
            objUSER_MST.Language1 = Lang;
            if (Flage == "ADD")
            {
                DB.USER_MST.AddObject(objUSER_MST);
            }
            DB.SaveChanges();
            return true;
        }
        public static bool UpdateWeb_User_MST(int UserTenent, int Userid, int Locationid, string FIRST_NAME, string LAST_NAME, string FIRST_NAME1, string LAST_NAME1, string FIRST_NAME2, string LAST_NAME2, string LOGIN_ID, string PASSWORD, string PASSWORD_CHNG, int USER_TYPE, string REMARKS, string ACTIVE_FLAG, DateTime LAST_LOGIN_DT, string ACC_LOCK, string FIRST_TIME, string EmailAddress, string Avtar, DateTime Till_DT, int CompId, int USER_DETAIL_ID, bool ACTIVEUSER, DateTime USERDATE, string Flage, string Lang)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.USER_MST objUSER_MST = new Database.USER_MST();
          
                objUSER_MST = DB.USER_MST.Single(p => p.USER_ID == Userid && p.TenentID == UserTenent);
         
            objUSER_MST.TenentID = UserTenent;
            objUSER_MST.USER_ID = Userid;
            // objUSER_MST.LOCATION_ID = Locationid;
            objUSER_MST.FIRST_NAME = FIRST_NAME;
            objUSER_MST.LAST_NAME = LAST_NAME;
            objUSER_MST.FIRST_NAME1 = FIRST_NAME1;
            objUSER_MST.LAST_NAME1 = LAST_NAME1;
            objUSER_MST.FIRST_NAME2 = FIRST_NAME2;
            objUSER_MST.LAST_NAME2 = LAST_NAME2;
            objUSER_MST.LOGIN_ID = LOGIN_ID;
            objUSER_MST.PASSWORD = PASSWORD;
            objUSER_MST.PASSWORD_CHNG = PASSWORD_CHNG;
            objUSER_MST.USER_TYPE = USER_TYPE;
            objUSER_MST.REMARKS = REMARKS;
            
            objUSER_MST.LAST_LOGIN_DT = LAST_LOGIN_DT;
            objUSER_MST.ACC_LOCK = ACC_LOCK;
            objUSER_MST.FIRST_TIME = FIRST_TIME;
            objUSER_MST.EmailAddress = EmailAddress;
            objUSER_MST.Avtar = Avtar;
            objUSER_MST.Till_DT = Till_DT;
            objUSER_MST.CompId = CompId;
            objUSER_MST.USER_DETAIL_ID = USER_DETAIL_ID;
            objUSER_MST.ACTIVEUSER = ACTIVEUSER;
            if(ACTIVEUSER)
            {
                objUSER_MST.ACTIVE_FLAG = "Y";
            }
            else
            {
                objUSER_MST.ACTIVE_FLAG = "N";
            }
            objUSER_MST.USERDATE = USERDATE;
            objUSER_MST.Language1 = Lang;
            if (Flage == "ADD")
            {
                DB.USER_MST.AddObject(objUSER_MST);
            }
            DB.SaveChanges();
            return true;
        }
    }
}
