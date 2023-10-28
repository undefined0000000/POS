using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Database;
using System.Data.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Transactions;
using System.Configuration;
using System.Data.OleDb;

namespace Classes
{
    public static class WinPOS
    {

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CRMNewEntitiesNew"].ConnectionString);
        static SqlCommand command2 = new SqlCommand();
        static Database.CallEntities DB = new Database.CallEntities();
        public static void WinPOSUSER(int Tenent, string UName, string UPass, string Compname, string compname2, string compname3, string CommanDefauLANG, string CompAdd, string CompPhone, string CompWebside, string userLastName, string useradd, string usermobile, string userbirthdate, string useremail, string userusertype)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                int PID = DB.TBLCOMPANYSETUPs.Count() > 0 ? Convert.ToInt32(DB.TBLCOMPANYSETUPs.Max(p => p.COMPID) + 1) : 1;

                if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == Tenent).Count() == 0)
                {
                    Database.MYCOMPANYSETUP objMYCOMPANYSETUP = new Database.MYCOMPANYSETUP();
                    objMYCOMPANYSETUP.TenentID = Convert.ToInt32(Tenent);
                    objMYCOMPANYSETUP.COMPANYID = PID;
                    objMYCOMPANYSETUP.PHYSICALLOCID = "KWT";
                    objMYCOMPANYSETUP.COMPNAME1 = Compname;
                    objMYCOMPANYSETUP.COMPNAME2 = compname2;
                    objMYCOMPANYSETUP.COMPNAME3 = compname3;
                    objMYCOMPANYSETUP.COUNTRYID = Convert.ToInt32(126);
                    objMYCOMPANYSETUP.ADDR1 = CompAdd;
                    objMYCOMPANYSETUP.ADDR2 = "Not Used";
                    objMYCOMPANYSETUP.CITY = "1";
                    objMYCOMPANYSETUP.STATE = "1902"; //txtstate.Text;
                    objMYCOMPANYSETUP.POSTALCODE = "00000";
                    objMYCOMPANYSETUP.ZIPCODE = "00000";
                    objMYCOMPANYSETUP.PHONE = CompPhone;
                    objMYCOMPANYSETUP.FAX = "00000";
                    objMYCOMPANYSETUP.ARABIC = "Y";
                    objMYCOMPANYSETUP.DECIMALCURRENCY = Convert.ToDecimal(1.00);
                    objMYCOMPANYSETUP.REPORTDEFAULT = "Y";
                    objMYCOMPANYSETUP.REPORTDIRECTORY = "inv";
                    objMYCOMPANYSETUP.DATADIRECTORY = "inv";
                    objMYCOMPANYSETUP.BACKUPDIRECTORY = "inv";
                    objMYCOMPANYSETUP.EXECUTABLEDIRECTORY = "inv";
                    objMYCOMPANYSETUP.INVDATABASENAME = "inv";
                    objMYCOMPANYSETUP.ACTDATABASENAME = "NewSaas";
                    //objMYCOMPANYSETUP.USERID = null;
                    objMYCOMPANYSETUP.ENTRYDATE = DateTime.Now;
                    objMYCOMPANYSETUP.ENTRYTIME = DateTime.Now;
                    objMYCOMPANYSETUP.UPDTTIME = DateTime.Now;
                    objMYCOMPANYSETUP.REC_RUNNING_SRL = 1;
                    objMYCOMPANYSETUP.Approved = 0;
                    objMYCOMPANYSETUP.Companytype = Convert.ToInt32(100020);
                    string path = "demo.png";
                    objMYCOMPANYSETUP.LogotoDisplay = path;

                    DB.MYCOMPANYSETUPs.AddObject(objMYCOMPANYSETUP);
                    DB.SaveChanges();
                }
                Database.TBLCOMPANYSETUP objTBLCOMPANYSETUP = new Database.TBLCOMPANYSETUP();
                objTBLCOMPANYSETUP.TenentID = Convert.ToInt32(Tenent);
                objTBLCOMPANYSETUP.COMPID = Convert.ToInt32(PID);
                objTBLCOMPANYSETUP.PHYSICALLOCID = "KWT";
                string[] BDT = userbirthdate.ToString().Split('/');
                int Day = 0;
                int Month = 0;
                int year = 0;
                int cou = 1;
                for (int i = 0; i < BDT.Count(); i++)
                {
                    if (cou == 1)
                    {
                        Month = Convert.ToInt32(BDT[i]);
                        cou++;
                    }
                    else if (cou == 2)
                    {
                        Day = Convert.ToInt32(BDT[i]);
                        cou++;
                    }
                    else
                    {
                        year = Convert.ToInt32(BDT[i]);
                    }
                }
                objTBLCOMPANYSETUP.BirthDate = new DateTime(year, Month, Day);
                objTBLCOMPANYSETUP.COMPNAME1 = UName;
                objTBLCOMPANYSETUP.COMPNAME2 = userLastName;
                objTBLCOMPANYSETUP.COMPNAME3 = UName;
                objTBLCOMPANYSETUP.COUNTRYID = Convert.ToInt32(126);
                objTBLCOMPANYSETUP.ADDR1 = useradd;
                objTBLCOMPANYSETUP.ADDR2 = "Not Used";
                objTBLCOMPANYSETUP.CITY = "1";
                objTBLCOMPANYSETUP.STATE = "1902";
                objTBLCOMPANYSETUP.POSTALCODE = "00000";
                objTBLCOMPANYSETUP.ZIPCODE = "00000";
                objTBLCOMPANYSETUP.BUSPHONE1 = "00000";
                objTBLCOMPANYSETUP.MOBPHONE = usermobile;
                objTBLCOMPANYSETUP.EMAIL = useremail;
                objTBLCOMPANYSETUP.EMAIL1 = useremail;
                objTBLCOMPANYSETUP.FAX = "00000";
                //objTBLCOMPANYSETUP.USERID = null;
                objTBLCOMPANYSETUP.UPDTTIME = DateTime.Now;
                objTBLCOMPANYSETUP.Approved = 0;
                objTBLCOMPANYSETUP.Active = "Y";
                objTBLCOMPANYSETUP.CompanyType = "100020";
                DB.TBLCOMPANYSETUPs.AddObject(objTBLCOMPANYSETUP);
                DB.SaveChanges();


                //user insert


                int UserDTLID = 0;
                if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == Tenent && p.COMPANYID == PID).Count() > 0)
                {
                    Database.MYCOMPANYSETUP objMYCOMPANYSETUP1 = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == Tenent && p.COMPANYID == PID);
                    Database.USER_DTL OBJUSERDTL = new Database.USER_DTL();
                    OBJUSERDTL.TenentID = Tenent;
                    OBJUSERDTL.USER_DETAIL_ID = DB.USER_DTL.Count() > 0 ? Convert.ToInt32(DB.USER_DTL.Max(p => p.USER_DETAIL_ID) + 1) : 1;
                    OBJUSERDTL.LOCATION_ID = Convert.ToInt32(1);
                    OBJUSERDTL.TITLE = "Not Found";
                    OBJUSERDTL.HOUSE_NO = "Not Found";
                    OBJUSERDTL.STREET = "Not Found";
                    OBJUSERDTL.ADDRESS1 = objMYCOMPANYSETUP1.ADDR1.ToString();
                    OBJUSERDTL.ADDRESS2 = objMYCOMPANYSETUP1.ADDR2.ToString();
                    OBJUSERDTL.CITY = objMYCOMPANYSETUP1.CITY.ToString();
                    int Contryid = Convert.ToInt32(objMYCOMPANYSETUP1.COUNTRYID);
                    var Con_Code = DB.tblCOUNTRies.Single(p => p.TenentID == 0 && p.COUNTRYID == Contryid).ITUTTelephoneCode;
                    OBJUSERDTL.COUNTRY = Contryid;
                    OBJUSERDTL.COUNTRY_CODE = Con_Code.ToString();
                    OBJUSERDTL.STATE = objMYCOMPANYSETUP1.STATE.ToString();
                    OBJUSERDTL.ZIP = objMYCOMPANYSETUP1.ZIPCODE.ToString();
                    OBJUSERDTL.PINCODE_NO = "Not Found";
                    OBJUSERDTL.POST_OFFICE = objMYCOMPANYSETUP1.POSTALCODE.ToString();
                    OBJUSERDTL.EMAIL_ADDRESS = "Not Found";
                    OBJUSERDTL.MOBILE_NUM = Convert.ToDecimal(objMYCOMPANYSETUP1.PHONE);
                    DB.USER_DTL.AddObject(OBJUSERDTL);
                    DB.SaveChanges();
                    UserDTLID = OBJUSERDTL.USER_DETAIL_ID;
                }
                else
                {
                    Database.TBLCOMPANYSETUP objCompID = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == Tenent && p.COMPID == PID);
                    Database.USER_DTL OBJUSERDTL = new Database.USER_DTL();
                    OBJUSERDTL.TenentID = Tenent;
                    OBJUSERDTL.USER_DETAIL_ID = DB.USER_DTL.Count() > 0 ? Convert.ToInt32(DB.USER_DTL.Max(p => p.USER_DETAIL_ID) + 1) : 1;
                    OBJUSERDTL.LOCATION_ID = Convert.ToInt32(1);
                    OBJUSERDTL.TITLE = "Not Found";
                    OBJUSERDTL.HOUSE_NO = "Not Found";
                    OBJUSERDTL.STREET = "Not Found";
                    OBJUSERDTL.ADDRESS1 = objCompID.ADDR1.ToString();
                    OBJUSERDTL.ADDRESS2 = objCompID.ADDR2.ToString();
                    OBJUSERDTL.CITY = objCompID.CITY.ToString();
                    int Contryid = Convert.ToInt32(objCompID.COUNTRYID);
                    var Con_Code = DB.tblCOUNTRies.Single(p => p.TenentID == 0 && p.COUNTRYID == Contryid).ITUTTelephoneCode;
                    OBJUSERDTL.COUNTRY = Contryid;
                    OBJUSERDTL.COUNTRY_CODE = Con_Code.ToString();
                    OBJUSERDTL.STATE = objCompID.STATE.ToString();
                    OBJUSERDTL.ZIP = objCompID.ZIPCODE.ToString();
                    OBJUSERDTL.PINCODE_NO = "Not Found";
                    OBJUSERDTL.POST_OFFICE = objCompID.POSTALCODE.ToString();
                    OBJUSERDTL.EMAIL_ADDRESS = useremail;
                    OBJUSERDTL.MOBILE_NUM = Convert.ToDecimal(objCompID.MOBPHONE);
                    DB.USER_DTL.AddObject(OBJUSERDTL);
                    DB.SaveChanges();
                    UserDTLID = OBJUSERDTL.USER_DETAIL_ID;
                }




                int UserTenent = Tenent;
                int Userid = DB.USER_MST.Count() > 0 ? Convert.ToInt32(DB.USER_MST.Max(p => p.USER_ID) + 1) : 1;
                int Locationid = 1;
                string FIRST_NAME = UName;
                string LAST_NAME = userLastName;
                string FIRST_NAME1 = UName;
                string LAST_NAME1 = userLastName;
                string FIRST_NAME2 = UName;
                string LAST_NAME2 = userLastName;
                string LOGIN_ID = UName;
                string PASSWORD = Classes.GlobleClass.EncryptionHelpers.Encrypt(UPass);

                string PASSWORD_CHNG = "12345";
                int USER_TYPE = 10;
                string REMARKS = UName;
                string ACTIVE_FLAG = "Y";
                DateTime LAST_LOGIN_DT = DateTime.Now;
                string ACC_LOCK = "Y";
                string FIRST_TIME = "Y";
                string EmailAddress = useremail;
                string Avtar = null;
                DateTime USERDATE = DateTime.Now;//new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                DateTime Till_DT = USERDATE.AddMonths(1);//new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day);
                int CompId = PID;
                int USER_DETAIL_ID = UserDTLID;
                bool ACTIVEUSER = true;
                
                string Lang1 = "en-US";
                if (CommanDefauLANG == "English")
                {
                    Lang1 = "en-US";
                }
                else if (CommanDefauLANG == "Arabic")
                {
                    Lang1 = "ar-KW";
                }
                else
                {
                    Lang1 = "en-US";
                }

                string Flage = "ADD";
                Classes.ACMClass.InsertWeb_User_MST(UserTenent, Userid, Locationid, FIRST_NAME, LAST_NAME, FIRST_NAME1, LAST_NAME1, FIRST_NAME2, LAST_NAME2, LOGIN_ID, PASSWORD, PASSWORD_CHNG, USER_TYPE, REMARKS, ACTIVE_FLAG, LAST_LOGIN_DT, ACC_LOCK, FIRST_TIME, EmailAddress, Avtar, Till_DT, CompId, USER_DETAIL_ID, ACTIVEUSER, USERDATE, Flage, Lang1);

                //Database.MYCOMPANYSETUP changeuser = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == Tenent && p.COMPANYID == PID);
                //changeuser.USERID = Userid.ToString();
                //changeuser.TenantGroupID = Tenent;
                //DB.SaveChanges();


                if (DB.TenantGroups.Where(p => p.TenentID == Tenent).Count() == 0)
                {
                    Database.MYCOMPANYSETUP objMYCOMPANYSETUP = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == Tenent);
                    Database.TenantGroup OBJTGroup = new Database.TenantGroup();
                    OBJTGroup.MainTenantID = 0;
                    OBJTGroup.TenentID = Tenent;
                    OBJTGroup.COMPNAME1 = objMYCOMPANYSETUP.COMPNAME1;
                    OBJTGroup.COMPNAME2 = objMYCOMPANYSETUP.COMPNAME2;
                    OBJTGroup.COMPNAME3 = objMYCOMPANYSETUP.COMPNAME3;
                    OBJTGroup.COUNTRYID = objMYCOMPANYSETUP.COUNTRYID;
                    OBJTGroup.ADDR1 = objMYCOMPANYSETUP.ADDR1;
                    OBJTGroup.ADDR2 = objMYCOMPANYSETUP.ADDR2;
                    OBJTGroup.CITY = objMYCOMPANYSETUP.CITY;
                    OBJTGroup.STATE = objMYCOMPANYSETUP.STATE;
                    OBJTGroup.POSTALCODE = objMYCOMPANYSETUP.POSTALCODE;
                    OBJTGroup.ZIPCODE = objMYCOMPANYSETUP.ZIPCODE;
                    OBJTGroup.PHONE = objMYCOMPANYSETUP.PHONE;
                    OBJTGroup.FAX = objMYCOMPANYSETUP.FAX;
                    OBJTGroup.ARABIC = objMYCOMPANYSETUP.ARABIC;
                    OBJTGroup.DECIMALCURRENCY = objMYCOMPANYSETUP.DECIMALCURRENCY;
                    OBJTGroup.REPORTDEFAULT = objMYCOMPANYSETUP.REPORTDEFAULT;
                    OBJTGroup.REPORTDIRECTORY = objMYCOMPANYSETUP.REPORTDIRECTORY;
                    OBJTGroup.DATADIRECTORY = objMYCOMPANYSETUP.DATADIRECTORY;
                    OBJTGroup.BACKUPDIRECTORY = objMYCOMPANYSETUP.BACKUPDIRECTORY;
                    OBJTGroup.EXECUTABLEDIRECTORY = objMYCOMPANYSETUP.EXECUTABLEDIRECTORY;
                    OBJTGroup.INVDATABASENAME = objMYCOMPANYSETUP.INVDATABASENAME;
                    OBJTGroup.ACTDATABASENAME = objMYCOMPANYSETUP.ACTDATABASENAME;
                    OBJTGroup.Language1 = objMYCOMPANYSETUP.Language1;
                    OBJTGroup.Language2 = objMYCOMPANYSETUP.Language2;
                    OBJTGroup.Language3 = objMYCOMPANYSETUP.Language3;
                    OBJTGroup.USERID = Userid.ToString();
                    OBJTGroup.ENTRYDATE = objMYCOMPANYSETUP.ENTRYDATE;
                    OBJTGroup.ENTRYTIME = objMYCOMPANYSETUP.ENTRYTIME;
                    OBJTGroup.UPDTTIME = objMYCOMPANYSETUP.UPDTTIME;
                    OBJTGroup.REC_RUNNING_SRL = objMYCOMPANYSETUP.REC_RUNNING_SRL;
                    OBJTGroup.CRUP_ID = objMYCOMPANYSETUP.CRUP_ID;
                    DB.TenantGroups.AddObject(OBJTGroup);
                    DB.SaveChanges();
                }

                //Module Maping



                int USERR = Convert.ToInt32(Userid);
                int PrivilageID = DB.PRIVILEGE_MST.Single(p => p.MODULE_ID == 39).PRIVILEGE_ID;
                if (DB.MODULE_MAP.Where(p => p.TenentID == Tenent && p.UserID == USERR && p.MODULE_ID == 39 && p.PRIVILEGE_ID == PrivilageID).Count() > 0)
                {

                }
                else
                {
                    Database.MODULE_MAP OBJMap = new Database.MODULE_MAP();
                    OBJMap.TenentID = Tenent;
                    OBJMap.PRIVILEGE_ID = PrivilageID;
                    OBJMap.LOCATION_ID = 1;
                    OBJMap.MODULE_ID = 39;
                    OBJMap.MODULE_MAP_ID = DB.MODULE_MAP.Count() > 0 ? Convert.ToInt32(DB.MODULE_MAP.Max(p => p.MODULE_MAP_ID) + 1) : 1;
                    OBJMap.UserID = USERR;
                    OBJMap.ACTIVE_FLAG = "Y";
                    OBJMap.TenantID = 0;
                    OBJMap.CRUP_ID = 0;
                    OBJMap.MySerial = 0;
                    OBJMap.ALL_FLAG = "N";
                    OBJMap.ADD_FLAG = "N";
                    OBJMap.MODIFY_FLAG = "N";
                    OBJMap.DELETE_FLAG = "N";
                    OBJMap.VIEW_FLAG = "N";
                    OBJMap.SP1 = 0;
                    OBJMap.SP2 = 0;
                    OBJMap.SP3 = 0;
                    OBJMap.SP4 = 0;
                    OBJMap.SP5 = 0;
                    OBJMap.SP1Name = null;
                    OBJMap.SP2Name = null;
                    OBJMap.SP3Name = null;
                    OBJMap.SP4Name = null;
                    OBJMap.SP5Name = null;
                    if (DB.MODULE_MAP.Where(p => p.TenentID == Tenent && p.UserID == USERR).Count() == 0)
                        OBJMap.SP1Name = "DefaultSet";
                    DB.MODULE_MAP.AddObject(OBJMap);
                    DB.SaveChanges();
                }






                int RID = Convert.ToInt32(DB.USER_MST.Single(p => p.TenentID == Tenent && p.USER_ID == USERR).USER_TYPE);
                if (DB.USER_ROLE.Where(p => p.TenentID == Tenent && p.ROLE_ID == RID && p.USER_ID == USERR && p.PRIVILEGE_ID == PrivilageID).Count() > 0)
                {

                }
                else
                {
                    Database.USER_ROLE OBJrole = new Database.USER_ROLE();
                    OBJrole.TenentID = Tenent;
                    OBJrole.USER_ROLE_ID = DB.USER_ROLE.Count() > 0 ? Convert.ToInt32(DB.USER_ROLE.Max(p => p.USER_ROLE_ID) + 1) : 1;
                    OBJrole.PRIVILEGE_ID = PrivilageID;
                    OBJrole.LOCATION_ID = 1;
                    OBJrole.USER_ID = USERR;
                    OBJrole.ROLE_ID = RID;
                    OBJrole.ACTIVE_FLAG = "Y";
                    OBJrole.ACTIVE_FROM_DT = DateTime.Now; //new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    OBJrole.ACTIVE_TO_DT = DateTime.Now.AddYears(1); //new DateTime(DateTime.Today.Year + 1, DateTime.Today.Month, DateTime.Today.Day);
                    OBJrole.CRUP_ID = 0;
                    OBJrole.ALL_FLAG = 0;
                    OBJrole.ADD_FLAG = 0;
                    OBJrole.MODIFY_FLAG = 0;
                    OBJrole.DELETE_FLAG = 0;
                    OBJrole.VIEW_FLAG = 0;
                    OBJrole.SP1 = 0;
                    OBJrole.SP2 = 0;
                    OBJrole.SP3 = 0;
                    OBJrole.SP4 = 0;
                    OBJrole.SP5 = 0;
                    OBJrole.SP1Name = null;
                    OBJrole.SP2Name = null;
                    OBJrole.SP3Name = null;
                    OBJrole.SP4Name = null;
                    OBJrole.SP5Name = null;
                    DB.USER_ROLE.AddObject(OBJrole);
                    DB.SaveChanges();

                    if (DB.ROLE_MST.Where(p => p.TenentID == Tenent && p.ROLE_ID == RID).Count() == 0)
                    {
                        Database.ROLE_MST objEditROLE_MST = DB.ROLE_MST.Single(p => p.TenentID == 0 && p.ROLE_ID == RID);
                        Database.ROLE_MST objROLE_MST = new Database.ROLE_MST();
                        objROLE_MST.TenentID = Tenent;
                        objROLE_MST.ROLE_ID = RID;
                        objROLE_MST.ROLE_NAME = objEditROLE_MST.ROLE_NAME;
                        objROLE_MST.ROLE_NAME1 = objEditROLE_MST.ROLE_NAME1;
                        objROLE_MST.ROLE_NAME2 = objEditROLE_MST.ROLE_NAME2;
                        objROLE_MST.ROLE_DESC = objEditROLE_MST.ROLE_DESC;
                        objROLE_MST.ACTIVE_FLAG = "Y";
                        objROLE_MST.ACTIVE_FROM_DT = DateTime.Now;//new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                        objROLE_MST.ACTIVE_TO_DT = DateTime.Now.AddYears(1); //new DateTime(DateTime.Today.Year + 1, DateTime.Today.Month, DateTime.Today.Day);
                        objROLE_MST.ACTIVEROLE = true;
                        objROLE_MST.ROLLDATE = DateTime.Now.AddYears(1); //new DateTime(DateTime.Today.Year + 1, DateTime.Today.Month, DateTime.Today.Day);

                        DB.ROLE_MST.AddObject(objROLE_MST);
                        DB.SaveChanges();
                    }

                }



                if (DB.USER_RIGHTS.Where(p => p.TenentID == Tenent && p.USER_ID == USERR && p.PRIVILEGE_ID == PrivilageID).Count() > 0)
                {

                }
                else
                {
                    Database.USER_RIGHTS Rightobj = new Database.USER_RIGHTS();
                    Rightobj.TenentID = Tenent;
                    Rightobj.RIGHTS_ID = DB.USER_RIGHTS.Count() > 0 ? Convert.ToInt32(DB.USER_RIGHTS.Max(p => p.RIGHTS_ID) + 1) : 1;
                    Rightobj.LOCATION_ID = 1;
                    Rightobj.USER_ID = USERR;
                    Rightobj.PRIVILEGE_ID = PrivilageID;
                    Rightobj.ADD_FLAG = true;
                    Rightobj.MODIFY_FLAG = true;
                    Rightobj.DELETE_FLAG = true;
                    Rightobj.VIEW_FLAG = true;
                    Rightobj.ALL_FLAG = true;
                    Rightobj.CRUP_ID = 0;
                    Rightobj.IsLabelUpdate = true;
                    Rightobj.SP1 = true;
                    Rightobj.SP2 = true;
                    Rightobj.SP3 = true;
                    Rightobj.SP4 = true;
                    Rightobj.SP5 = true;
                    Rightobj.SP1Name = null;
                    Rightobj.SP2Name = null;
                    Rightobj.SP3Name = null;
                    Rightobj.SP4Name = null;
                    Rightobj.SP5Name = null;
                    Rightobj.status = "Final";
                    DB.USER_RIGHTS.AddObject(Rightobj);
                    DB.SaveChanges();
                }

                //tempuser data

                List<Database.FUNCTION_MST> tempfuction = DB.FUNCTION_MST.Where(p => p.MODULE_ID == 39 && p.ACTIVE_FLAG == 1).ToList();

                // For Module Privilage Wise insert data in Privilage_Menu
                List<Database.PRIVILAGE_MENUDemon> Privilage_MenuList = DB.PRIVILAGE_MENUDemon.Where(p => p.TenentID == Tenent).ToList();


                List<Database.MODULE_MAP> MapList = DB.MODULE_MAP.Where(p => p.TenentID == Tenent && p.UserID == USERR).ToList();
                foreach (Database.MODULE_MAP item in MapList)
                {

                    int ModuleID = Convert.ToInt32(item.MODULE_ID);
                    foreach (Database.FUNCTION_MST temfunitem in tempfuction.Where(p => p.MODULE_ID == ModuleID))
                    {
                        if (Privilage_MenuList.Where(p => p.PRIVILEGE_MENU_ID == ModuleID && p.TenentID == Tenent && p.PRIVILEGE_ID == PrivilageID && p.PRIVILAGEFOR == 2 && p.MENU_ID == temfunitem.MENU_ID).Count() == 0)
                        {
                            PRIVILAGE_MENUDemon objPRIVILAGE_MENU = new PRIVILAGE_MENUDemon();
                            objPRIVILAGE_MENU.PRIVILEGE_MENU_ID = ModuleID;
                            objPRIVILAGE_MENU.TenentID = Tenent;
                            objPRIVILAGE_MENU.PRIVILEGE_ID = PrivilageID;
                            objPRIVILAGE_MENU.PRIVILAGEFOR = 2;
                            objPRIVILAGE_MENU.LOCATION_ID = 1;
                            objPRIVILAGE_MENU.MENU_ID = temfunitem.MENU_ID;
                            objPRIVILAGE_MENU.MASTER_ID = temfunitem.MASTER_ID;
                            objPRIVILAGE_MENU.MENU_LOCATION = temfunitem.MENU_LOCATION;
                            objPRIVILAGE_MENU.ACTIVETILLDATE = temfunitem.MENUDATE;
                            objPRIVILAGE_MENU.ACTIVE_FLAG = "Y";
                            objPRIVILAGE_MENU.ALL_FLAG = "Y";
                            objPRIVILAGE_MENU.ADD_FLAG = "Y";
                            objPRIVILAGE_MENU.MODIFY_FLAG = "Y";
                            objPRIVILAGE_MENU.DELETE_FLAG = "Y";
                            objPRIVILAGE_MENU.VIEW_FLAG = "Y";
                            objPRIVILAGE_MENU.LABEL_FLAG = "Y";
                            objPRIVILAGE_MENU.SP1 = "N";
                            objPRIVILAGE_MENU.SP2 = "N";
                            objPRIVILAGE_MENU.SP3 = "N";
                            objPRIVILAGE_MENU.SP4 = "N";
                            objPRIVILAGE_MENU.SP5 = "Y";
                            objPRIVILAGE_MENU.ActiveMenu = "Y";
                            objPRIVILAGE_MENU.ActiveModule = "Y";
                            objPRIVILAGE_MENU.CreatedDate = DateTime.Now;
                            DB.PRIVILAGE_MENUDemon.AddObject(objPRIVILAGE_MENU);
                            DB.SaveChanges();
                            Privilage_MenuList.Add(objPRIVILAGE_MENU);
                        }
                    }
                }

                //For Role privilage wise insert Data in privilage_Menu

                List<Database.USER_ROLE> RoleList = DB.USER_ROLE.Where(p => p.TenentID == Tenent && p.USER_ID == USERR).ToList();
                foreach (Database.USER_ROLE item in RoleList)
                {

                    int Roleid = Convert.ToInt32(item.ROLE_ID);
                    foreach (Database.FUNCTION_MST temfunitem in tempfuction)
                    {
                        if (Privilage_MenuList.Where(p => p.PRIVILEGE_MENU_ID == Roleid && p.TenentID == Tenent && p.PRIVILEGE_ID == PrivilageID && p.PRIVILAGEFOR == 1 && p.MENU_ID == temfunitem.MENU_ID).Count() == 0)
                        {
                            PRIVILAGE_MENUDemon objPRIVILAGE_MENU = new PRIVILAGE_MENUDemon();
                            objPRIVILAGE_MENU.PRIVILEGE_MENU_ID = Roleid;
                            objPRIVILAGE_MENU.TenentID = Tenent;
                            objPRIVILAGE_MENU.PRIVILEGE_ID = PrivilageID;
                            objPRIVILAGE_MENU.PRIVILAGEFOR = 1;
                            objPRIVILAGE_MENU.LOCATION_ID = 1;
                            objPRIVILAGE_MENU.MENU_ID = temfunitem.MENU_ID;
                            objPRIVILAGE_MENU.MASTER_ID = temfunitem.MASTER_ID;
                            objPRIVILAGE_MENU.MENU_LOCATION = temfunitem.MENU_LOCATION;
                            objPRIVILAGE_MENU.ACTIVETILLDATE = temfunitem.MENUDATE;
                            objPRIVILAGE_MENU.ACTIVE_FLAG = "Y";
                            objPRIVILAGE_MENU.ALL_FLAG = "Y";
                            objPRIVILAGE_MENU.ADD_FLAG = "Y";
                            objPRIVILAGE_MENU.MODIFY_FLAG = "Y";
                            objPRIVILAGE_MENU.DELETE_FLAG = "Y";
                            objPRIVILAGE_MENU.VIEW_FLAG = "Y";
                            objPRIVILAGE_MENU.LABEL_FLAG = "Y";
                            objPRIVILAGE_MENU.SP1 = "N";
                            objPRIVILAGE_MENU.SP2 = "N";
                            objPRIVILAGE_MENU.SP3 = "N";
                            objPRIVILAGE_MENU.SP4 = "N";
                            objPRIVILAGE_MENU.SP5 = "Y";
                            objPRIVILAGE_MENU.ActiveMenu = "Y";
                            objPRIVILAGE_MENU.ActiveModule = "Y";
                            objPRIVILAGE_MENU.Action = "Y";
                            objPRIVILAGE_MENU.CreatedDate = DateTime.Now;
                            DB.PRIVILAGE_MENUDemon.AddObject(objPRIVILAGE_MENU);
                            DB.SaveChanges();
                            Privilage_MenuList.Add(objPRIVILAGE_MENU);
                        }
                    }
                }

                // For user privilage wise insert data in privilage_Menu

                List<Database.USER_RIGHTS> RIGHTSist = DB.USER_RIGHTS.Where(p => p.TenentID == Tenent && p.USER_ID == USERR).ToList();
                foreach (Database.USER_RIGHTS item in RIGHTSist)
                {

                    int userid = Convert.ToInt32(item.USER_ID);
                    foreach (Database.FUNCTION_MST temfunitem in tempfuction)
                    {
                        if (Privilage_MenuList.Where(p => p.PRIVILEGE_MENU_ID == userid && p.TenentID == Tenent && p.PRIVILEGE_ID == PrivilageID && p.PRIVILAGEFOR == 3 && p.MENU_ID == temfunitem.MENU_ID).Count() == 0)
                        {
                            PRIVILAGE_MENUDemon objPRIVILAGE_MENU = new PRIVILAGE_MENUDemon();
                            objPRIVILAGE_MENU.PRIVILEGE_MENU_ID = userid;
                            objPRIVILAGE_MENU.TenentID = Tenent;
                            objPRIVILAGE_MENU.PRIVILEGE_ID = PrivilageID;
                            objPRIVILAGE_MENU.PRIVILAGEFOR = 3;
                            objPRIVILAGE_MENU.LOCATION_ID = 1;
                            objPRIVILAGE_MENU.MENU_ID = temfunitem.MENU_ID;
                            objPRIVILAGE_MENU.MASTER_ID = temfunitem.MASTER_ID;
                            objPRIVILAGE_MENU.MENU_LOCATION = temfunitem.MENU_LOCATION;
                            objPRIVILAGE_MENU.ACTIVETILLDATE = temfunitem.MENUDATE;
                            objPRIVILAGE_MENU.ACTIVE_FLAG = "Y";
                            objPRIVILAGE_MENU.ALL_FLAG = "Y";
                            objPRIVILAGE_MENU.ADD_FLAG = "Y";
                            objPRIVILAGE_MENU.MODIFY_FLAG = "Y";
                            objPRIVILAGE_MENU.DELETE_FLAG = "Y";
                            objPRIVILAGE_MENU.VIEW_FLAG = "Y";
                            objPRIVILAGE_MENU.LABEL_FLAG = "Y";
                            objPRIVILAGE_MENU.SP1 = "N";
                            objPRIVILAGE_MENU.SP2 = "N";
                            objPRIVILAGE_MENU.SP3 = "N";
                            objPRIVILAGE_MENU.SP4 = "N";
                            objPRIVILAGE_MENU.SP5 = "Y";
                            objPRIVILAGE_MENU.ActiveMenu = "Y";
                            objPRIVILAGE_MENU.ActiveModule = "Y";
                            objPRIVILAGE_MENU.Action = "Y";
                            objPRIVILAGE_MENU.CreatedDate = DateTime.Now;
                            DB.PRIVILAGE_MENUDemon.AddObject(objPRIVILAGE_MENU);
                            DB.SaveChanges();
                            Privilage_MenuList.Add(objPRIVILAGE_MENU);
                        }
                    }
                }

                // insert record in tempuser

                List<Database.MODULE_MAP> MapList1 = DB.MODULE_MAP.Where(a => a.TenentID == Tenent && a.UserID == USERR).ToList();
                foreach (Database.MODULE_MAP item in MapList1)
                {

                    int ModuleID = Convert.ToInt32(item.MODULE_ID);
                    int ridd = DB.USER_ROLE.Single(a => a.TenentID == Tenent && a.PRIVILEGE_ID == PrivilageID && a.USER_ID == USERR).ROLE_ID;
                    //GlobleClass.DeleteTempUser(Tenent, USERR, 1, ModuleID);
                    GlobleClass.getMenuGloble(Tenent, USERR, 1, ModuleID, ridd);


                }

                scope.Complete();
            }
            int FromTID = Convert.ToInt32(1);
            int Comp = 0;
            string Str = "";
            var TDT = DateTime.Now.Date;
            if (DB.TBLLOCATIONs.Where(p => p.TenentID == Tenent).Count() == 0)
                Str += "INSERT INTO [dbo].[TBLLOCATION]([TenentID],[LOCATIONID],[PHYSICALLOCID],[LOCNAME1],[LOCNAME2],[LOCNAME3],[ADDRESS],[DEPT],[SECTIONCODE],[ACCOUNT],[MAXDISCOUNT],[USERID],[ENTRYDATE],[ENTRYTIME],[UPDTTIME],[Active],[LOCNAME],[LOCNAMEO],[LOCNAMECH],[CRUP_ID]) SELECT " + Tenent + ",[LOCATIONID],[PHYSICALLOCID],[LOCNAME1],[LOCNAME2],[LOCNAME3],[ADDRESS],[DEPT],[SECTIONCODE],[ACCOUNT],[MAXDISCOUNT],[USERID],[ENTRYDATE],[ENTRYTIME],[UPDTTIME],[Active],[LOCNAME],[LOCNAMEO],[LOCNAMECH],[CRUP_ID] from [TBLLOCATION] where [TenentID]=" + FromTID + ";";
            //if (DB.REFTABLEs.Where(p => p.TenentID == Tenent).Count() == 0)
            //    Str += "INSERT INTO [dbo].[REFTABLE]([TenentID],[REFID],[REFTYPE],[REFSUBTYPE],[SHORTNAME],[REFNAME1],[REFNAME2],[REFNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[SWITCH4],[Remarks],[ACTIVE],[CRUP_ID],[Infrastructure],[SyncDate]) Select " + Tenent + ",[REFID],[REFTYPE],[REFSUBTYPE],[SHORTNAME],[REFNAME1],[REFNAME2],[REFNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[SWITCH4],[Remarks],[ACTIVE],[CRUP_ID],[Infrastructure],[SyncDate] from [REFTABLE] where [TenentID]=" + FromTID + ";";
            Str += "INSERT INTO [dbo].[REFTABLE]([TenentID],[REFID],[REFTYPE],[REFSUBTYPE],[SHORTNAME],[REFNAME1],[REFNAME2],[REFNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[SWITCH4],[Remarks],[ACTIVE],[CRUP_ID],[Infrastructure],[SyncDate]) Select " + Tenent + ",[REFID],[REFTYPE],[REFSUBTYPE],[SHORTNAME],[REFNAME1],[REFNAME2],[REFNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[SWITCH4],[Remarks],[ACTIVE],[CRUP_ID],[Infrastructure],[SyncDate] from [REFTABLE] where [TenentID]=" + FromTID + " and REFID not in(select REFID from REFTABLE where TenentID = " + Tenent + " and REFID = REFTABLE.REFID);";
            if (DB.tblCOUNTRies.Where(p => p.TenentID == Tenent).Count() == 0)
                Str += "INSERT INTO [dbo].[tblCOUNTRY]([TenentID],[COUNTRYID],[REGION1],[COUNAME1],[COUNAME2],[COUNAME3],[CAPITAL],[NATIONALITY1],[NATIONALITY2],[NATIONALITY3],[CURRENCYNAME1],[CURRENCYNAME2],[CURRENCYNAME3],[CURRENTCONVRATE],[CURRENCYSHORTNAME1],[CURRENCYSHORTNAME2],[CURRENCYSHORTNAME3],[CountryType],[CountryTSubType],[Sovereignty],[ISO4217CurCode],[ISO4217CurName],[ITUTTelephoneCode],[FaxLength],[TelLength],[ISO3166_1_2LetterCode],[ISO3166_1_3LetterCode],[ISO3166_1Number],[IANACountryCodeTLD],[Active],[CRUP_ID]) select " + Tenent + ",[COUNTRYID],[REGION1],[COUNAME1],[COUNAME2],[COUNAME3],[CAPITAL],[NATIONALITY1],[NATIONALITY2],[NATIONALITY3],[CURRENCYNAME1],[CURRENCYNAME2],[CURRENCYNAME3],[CURRENTCONVRATE],[CURRENCYSHORTNAME1],[CURRENCYSHORTNAME2],[CURRENCYSHORTNAME3],[CountryType],[CountryTSubType],[Sovereignty],[ISO4217CurCode],[ISO4217CurName],[ITUTTelephoneCode],[FaxLength],[TelLength],[ISO3166_1_2LetterCode],[ISO3166_1_3LetterCode],[ISO3166_1Number],[IANACountryCodeTLD],[Active],[CRUP_ID] from [tblCOUNTRY] where [TenentID]=" + FromTID + ";";
            if (DB.TBLCOLORs.Where(p => p.TenentID == Tenent && p.COLORID == 999999999).Count() == 0)
                Str += "INSERT INTO [dbo].[TBLCOLOR]([TenentID],[COLORID],[COLORDESC1],[COLORDESC2],[COLORREMARKS],[hex],[RGB],[color],[CRUP_ID],[Active]) VALUES (" + Tenent + ",999999999,'NOT USED','NOT USED','NOT USED','NOT USED','NOT USED','NOT USED',0,'Y');";
            //Str += "INSERT INTO [dbo].[TBLCOLOR]([TenentID],[COLORID],[COLORDESC1],[COLORDESC2],[COLORREMARKS],[hex],[RGB],[color],[CRUP_ID],[Active]) select " + Tenent + ",[COLORID],[COLORDESC1],[COLORDESC2],[COLORREMARKS],[hex],[RGB],[color],[CRUP_ID],[Active] from [TBLCOLOR] where TenentID=" + FromTID + ";";
            if (DB.TBLSIZEs.Where(p => p.TenentID == Tenent && p.SIZECODE == 999999999).Count() == 0)
                Str += "INSERT INTO [dbo].[TBLSIZE]([TenentID],[SIZECODE],[SIZETYPE],[SIZEDESC1],[SIZEDESC2],[SIZEDESC3],[SIZEREMARKS],[CRUP_ID],[ACTIVE])VALUES(" + Tenent + ",999999999,'NOT Used','NOT Used','NOT Used','NOT Used','NOT Used',0,'Y');";
            //Str += "INSERT INTO [dbo].[TBLSIZE]([TenentID],[SIZECODE],[SIZETYPE],[SIZEDESC1],[SIZEDESC2],[SIZEDESC3],[SIZEREMARKS],[CRUP_ID],[ACTIVE])select " + Tenent + ",[SIZECODE],[SIZETYPE],[SIZEDESC1],[SIZEDESC2],[SIZEDESC3],[SIZEREMARKS],[CRUP_ID],[ACTIVE] from [TBLSIZE] where TenentID=" + FromTID + ";";
            if (DB.ICUOMs.Where(p => p.TenentID == Tenent && p.UOM == 99999).Count() == 0)
                Str += "INSERT INTO [dbo].[ICUOM]([TenentID],[UOM],[UOMNAMESHORT],[UOMNAME1],[UOMNAME2],[UOMNAME3],[REMARKS],[CRUP_ID],[Active],[UOMNAME],[UOMNAMEO],[UploadDate],[SynID])VALUES(" + Tenent + ",99999,'Not Used','Not Used','Not Used','Not Used','Not Used',0,'Y','Not Used','Not Used','" + TDT + "',1);";
            if (DB.CAT_MST.Where(p => p.TenentID == Tenent && p.CATID == 99999).Count() == 0)
                Str += "INSERT INTO [dbo].[CAT_MST]([TenentID],[CATID],[PARENT_CATID],[DefaultPic],[SHORT_NAME],[CAT_NAME1],[CAT_NAME2],[CAT_NAME3],[CAT_DESCRIPTION],[CAT_TYPE],[WARRANTY],[CRUP_ID],[Active],[SupplierPercent],[UploadDate],[SynID]) VALUES (" + Tenent + ",99999,0,'cc','Not Used','Not Used','Not Used','Not Used','Not Used','WEBSALE','0 Months',0,'1',0.0,'" + TDT + "',1);";
            if (DB.TBLGROUPs.Where(p => p.TenentID == Tenent && p.ITGROUPID == 999999999).Count() == 0)
                Str += "INSERT INTO [dbo].[TBLGROUP]([TenentID],[LocationId],[ITGROUPID],[GroupType],[ITGROUPDESC1],[ITGROUPDESC2],[ITGROUPREMARKS],[ACTIVE_Flag],[USERCODE],[GROUPID],[remarks],[ACTIVE],[CRUP_ID],[Infastructure]) VALUES (" + Tenent + ",1,999999999,'','Not Used','Not Used','Not Used','True','','','','1',0,'False');";
            if (DB.DEPTOFSales.Where(p => p.TenentID == Tenent && p.SalDeptID == 999999999).Count() == 0)
                Str += "INSERT INTO [dbo].[DEPTOFSale]([TenentID],[SalDeptID],[DeptDesc1],[DeptDesc2],[DeptDesc3],[DeptRemarks],[SalesAccountID],[Margin],[ExpenseAccountID],[PurchaseAccountID],[Active_Flag],[CRUP_ID],[DeptManagerID]) VALUES (" + Tenent + ",999999999,'Not Exist Yet','Not Exist Yet','Not Exist Yet','Not Exist Yet','0',0.0,'','','True',0,0);";
            if (DB.MYBUS.Where(p => p.TenentID == Tenent).Count() == 0)
                Str += "INSERT INTO [dbo].[MYBUS]([TenentID],[BUSID],[BUSTYPE],[SHORTNAME],[BUSNAME1],[BUSNAME2],[BUSNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[Remarks],[COMPANID],[BUSNAME],[BUSNAMEO],[BUSNAMCHIN],[BUSYPE],[CRUP_ID]) Select " + Tenent + ",[BUSID],[BUSTYPE],[SHORTNAME],[BUSNAME1],[BUSNAME2],[BUSNAME3],[SWITCH1],[SWITCH2],[SWITCH3],[Remarks],[COMPANID],[BUSNAME],[BUSNAMEO],[BUSNAMCHIN],[BUSYPE],[CRUP_ID] from [MYBUS] Where TenentID=" + FromTID + ";";
            if (DB.RefLabelMSTs.Where(p => p.TenentID == Tenent).Count() == 0)
                Str += "INSERT INTO [dbo].[RefLabelMST]([TenentID],[RefLabelID],[RefType],[RefSubType],[LE1],[LE2],[LE3],[LE4],[LE5],[LE6],[LE7],[LE8],[LE9],[LE10],[LF1],[LF2],[LF3],[LF4],[LF5],[LF6],[LF7],[LF8],[LF9],[LF10],[LA1],[LA2],[LA3],[LA4],[LA5],[LA6],[LA7],[LA8],[LA9],[LA10]) Select " + Tenent + ",[RefLabelID],[RefType],[RefSubType],[LE1],[LE2],[LE3],[LE4],[LE5],[LE6],[LE7],[LE8],[LE9],[LE10],[LF1],[LF2],[LF3],[LF4],[LF5],[LF6],[LF7],[LF8],[LF9],[LF10],[LA1],[LA2],[LA3],[LA4],[LA5],[LA6],[LA7],[LA8],[LA9],[LA10] from [RefLabelMST] where TenentID=" + FromTID + ";";
            //if (DB.tbltranstypes.Where(p => p.TenentID == Tenent).Count() == 0)
            //Str += "select * into TempCopy_tbltranstype from tbltranstype where TenentID = " + FromTID + ";update TempCopy_tbltranstype set TenentID = " + Tenent + " where TenentID = " + FromTID + ";INSERT INTO tbltranstype select * from TempCopy_tbltranstype where TenentID = " + Tenent + ";drop table TempCopy_tbltranstype;";                
            //if (DB.tbltranssubtypes.Where(p => p.TenentID == Tenent).Count() == 0)
            //Str += "select * into TempCopy_tbltranssubtype from tbltranssubtype where TenentID = " + FromTID + ";update TempCopy_tbltranssubtype set TenentID = " + Tenent + " where TenentID = " + FromTID + ";INSERT INTO tbltranssubtype select * from TempCopy_tbltranssubtype where TenentID = " + Tenent + ";drop table TempCopy_tbltranssubtype;";
            Str += "INSERT INTO [dbo].[tbltranstype]([TenentID],[transid],[MYSYSNAME],[inoutSwitch],[transtype1],[transtype2],[transtype3],[serialno],[years],[Active],[CRUP_ID],[transtype],[switch1]) select " + Tenent + ",[transid],[MYSYSNAME],[inoutSwitch],[transtype1],[transtype2],[transtype3],[serialno],[years],[Active],[CRUP_ID],[transtype],[switch1] from tbltranstype where TenentID=" + FromTID + " and transid not in(select transid from tbltranstype where TenentID=" + Tenent + " and transid=tbltranstype.transid);";
            Str += "INSERT INTO [dbo].[tbltranssubtype]([TenentID],[transid],[MYSYSNAME],[transsubid],[transsubtype1],[transsubtype2],[transsubtype3],[OpQtyBeh],[OnHandBeh],[QtyOutBeh],[QtyConsumedBeh],[QtyReservedBeh],[QtyAtDestination],[QtyAtSource],[serialno],[years],[Active],[CRUP_ID],[transsubtype],[CashBeh],[QtyReceivedBeh]) select " + Tenent + ",[transid],[MYSYSNAME],[transsubid],[transsubtype1],[transsubtype2],[transsubtype3],[OpQtyBeh],[OnHandBeh],[QtyOutBeh],[QtyConsumedBeh],[QtyReservedBeh],[QtyAtDestination],[QtyAtSource],[serialno],[years],[Active],[CRUP_ID],[transsubtype],[CashBeh],[QtyReceivedBeh] from tbltranssubtype where TenentID = " + FromTID + " and transsubid not in(select transsubid from tbltranssubtype where TenentID=" + Tenent + " and transid = tbltranssubtype.transid and transsubid = tbltranssubtype.transsubid);";
            if (DB.tblLanguages.Where(p => p.TenentID == Tenent).Count() == 0)//
                Str += "INSERT INTO [dbo].[tblLanguage]([TenentID],[MYCONLOCID],[COUNTRYID],[LangName1],[LangName2],[LangName3],[CULTUREOCDE],[ACTIVE],[REMARKS],[CRUP_ID],[Deleted],[UploadDate],[Uploadby],[SyncDate],[Syncby],[SynID])select " + Tenent + ",[MYCONLOCID],[COUNTRYID],[LangName1],[LangName2],[LangName3],[CULTUREOCDE],[ACTIVE],[REMARKS],[CRUP_ID],[Deleted],[UploadDate],[Uploadby],[SyncDate],[Syncby],[SynID] from tblLanguage where TenentID=" + 0 + ";";
            if (DB.tblsetupPurchases.Where(p => p.TenentID == Tenent).Count() == 0)
                Str += "INSERT INTO [dbo].[tblsetupPurchase]([TenentID],[locationID],[module],[DeliveryLocation],[BottomTagLine],[CompniID],[LastClosePeriod],[CurrentPeriod],[PaymentDays],[ReminderDays],[AcceptWarantee],[AutoGeneratePO],[AutoGenerateGRN],[transid2],[transsubid2],[transid1],[transsubid1],[Created],[DateTime],[Active],[Deleted]) select " + Tenent + ",[locationID],[module],[DeliveryLocation],[BottomTagLine],[CompniID],[LastClosePeriod],[CurrentPeriod],[PaymentDays],[ReminderDays],[AcceptWarantee],[AutoGeneratePO],[AutoGenerateGRN],[transid2],[transsubid2],[transid1],[transsubid1],[Created],[DateTime],[Active],[Deleted] from tblsetupPurchase where TenentID = " + FromTID + ";";
            if (DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == Tenent && p.COMPNAME1.Contains("Cash")).Count() == 0)
            {
                Comp = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == Tenent).Count() > 0 ? Convert.ToInt32(DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == Tenent).Max(p => p.COMPID) + 1) : 1;
                Str += "INSERT INTO [dbo].[TBLCOMPANYSETUP]([TenentID],[COMPID],[OldCOMPid],[PHYSICALLOCID],[COMPNAME1],[COMPNAME2],[COMPNAME3],[BirthDate],[CivilID],[EMAIL],[EMAIL1],[EMAIL2],[ITMANAGER],[ADDR1],[ADDR2],[CITY],[STATE],[POSTALCODE],[ZIPCODE],[MYCONLOCID],[MYPRODID],[COUNTRYID],[BUSPHONE1],[BUSPHONE2],[BUSPHONE3],[BUSPHONE4],[MOBPHONE],[FAX],[FAX1],[FAX2],[PRIMLANGUGE],[WEBPAGE],[ISMINISTRY],[ISSMB],[ISCORPORATE],[INHAWALLY],[SALER],[BUYER],[SALEDEPROD],[EMAISUB],[EMAILSUBDATE],[PRODUCTDEALIN],[REMARKS],[Keyword],[COMPANYID],[BUSID],[MYCATSUBID],[COMPNAME],[COMPNAMEO],[COMPNAMECH],[Active],[CRUP_ID],[CUSERID],[CPASSWRD],[USERID],[ENTRYDATE],[ENTRYTIME],[UPDTTIME],[Approved],[CompanyType],[Images],[BARCODE],[Avtar],[Reload],[datasource],[PACI],[Marketting],[UploadDate],[Uploadby],[SyncDate],[Syncby],[SynID]) VALUES (" + Tenent + "," + Comp + ",0 ,'KWT','Cash','Cash' ,'Cash',NULL,'' ,'','','' ,'0','','' ,'1','1902','' ,'',0,0 ,126,'','' ,'','','' ,'','','' ,'1','',0 ,0,0,0 ,0,0,0 ,0,NULL,'' ,'','',0 ,0,0,'' ,'','','Y' ,0,'','' ,'',NULL,NULL ,NULL,0,'82005' ,NULL,'','' ,0,0,'' ,'',NULL,'' ,NULL,'',0);";
            }
            else
            {
                Comp = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == Tenent && p.COMPNAME1.Contains("Cash")).COMPID;
            }
            Str += "INSERT INTO [dbo].[tblsetupsalesh]([TenentID],[locationID],[transid],[transsubid],[module],[DeliveryLocation],[CompniID],[LastClosePeriod],[CurrentPeriod],[PaymentDays],[ReminderDays],[AcceptWarantee],[DescWithWarantee],[DescWithSerial],[DescWithColor],[AllowMinusQty],[HeaderLine],[TagLine],[BottomTagLine],[PaymentDetails],[TCQuotation],[IntroLetter],[COUNTRYID],[SalesAdminID],[CRUP_ID],[InvoicePrintURL],[DeliveryPrintURL],[CounterName],[EmployeeId],[DeftCoustomer],[Created],[DateTime],[Active],[Deleted]) select " + Tenent + ",[locationID],[transid],[transsubid],[module],[DeliveryLocation],[CompniID],[LastClosePeriod],[CurrentPeriod],[PaymentDays],[ReminderDays],[AcceptWarantee],[DescWithWarantee],[DescWithSerial],[DescWithColor],[AllowMinusQty],[HeaderLine],[TagLine],[BottomTagLine],[PaymentDetails],[TCQuotation],[IntroLetter],[COUNTRYID],[SalesAdminID],[CRUP_ID],[InvoicePrintURL],[DeliveryPrintURL],[CounterName],[EmployeeId]," + Comp + ",[Created],[DateTime],[Active],[Deleted] from [tblsetupsalesh] where TenentID=" + FromTID + " and transsubid not in ( SELECT transsubid from tblsetupsalesh  WHERE TenentID=" + Tenent + " and locationID=1 and transid = tblsetupsalesh.transid and transsubid = tblsetupsalesh.transsubid);";
            if (DB.tblSetupInventories.Where(p => p.TenentID == Tenent).Count() == 0)
            {
                Str += "INSERT INTO [dbo].[tblSetupInventory]([TenentID],[locationID],[TransferOutTransType],[TransferOutTransSubType],[TransferInTransType],[TransferInTransSubType],[ConsumeTransType],[ConsumeTransSubType],[transidOut],[transsubidOut],[transidin],[transsubidIn],[transidConsume],[transsubidConsume],[MYSYSNAMEOut],[MYSYSNAMEIn],[StockTeking],[StockTakingPeriodBegin],[StockTakingPeriodEnd],[StockTakingTransTypeIn],[StockTakingTransTypeOut],[StockTakingTransSubTypeIn],[StockTakingTransSubTypeOut],[StockTakingtransidInLast],[StockTakingtransidOutLast],[DefaultCUSTVENDID],[Created],[DateTime],[Active],[Deleted]) VALUES (" + Tenent + ",1,'Transfer Notes - Out','Transfer Notes - Out','Transfer Notes - In','Transfer Notes - In','Transfer Notes - Consume','Transfer Notes - Consume',21,221,11,111,31,331,'IC','IC',NULL,NULL,NULL,'In StockTaking','Out StockTaking','In StockTaking','Out StockTaking',301,401," + Comp + ",NULL,NULL,NULL,NULL);";
            }
            Str += "INSERT INTO [dbo].[TBLSYSTEMS]([TenentID],[SystemID],[MYSYSNAME],[SYSDESC1],[SYSDESC2],[SYSDESC3],[SHORTNAME],[REMARKS],[STARTDATE],[CRUP_ID],[ACTIVE],[SYSDESC],[SYSDESCO],[SYSDESCCH]) SELECT " + Tenent + ",[SystemID],[MYSYSNAME],[SYSDESC1],[SYSDESC2],[SYSDESC3],[SHORTNAME],[REMARKS],[STARTDATE],[CRUP_ID],[ACTIVE],[SYSDESC],[SYSDESCO],[SYSDESCCH] from TBLSYSTEMS where TenentID=" + FromTID + " and SystemID not in(select SystemID from TBLSYSTEMS where TenentID=" + Tenent + " and SystemID=TBLSYSTEMS.SystemID);";
            Str += "INSERT INTO [dbo].[ICEXTRACOST]([TenentID],[OVERHEADID],[OHNAME1],[OHNAME2],[OHNAME3],[ACCOUNTID],[Active],[CRUP_ID],[OHNAME],[OHNAMEO]) Select " + Tenent + ",[OVERHEADID],[OHNAME1],[OHNAME2],[OHNAME3],[ACCOUNTID],[Active],[CRUP_ID],[OHNAME],[OHNAMEO] from ICEXTRACOST where TenentID=" + FromTID + " and OVERHEADID not in(select OVERHEADID from ICEXTRACOST where TenentID=" + Tenent + " and OVERHEADID=ICEXTRACOST.OVERHEADID);";
            Str += "INSERT INTO [dbo].[ICUOM]([TenentID],[UOM],[UOMNAMESHORT],[UOMNAME1],[UOMNAME2],[UOMNAME3],[REMARKS],[CRUP_ID],[Active],[UOMNAME],[UOMNAMEO],[UOM_TYPE],[UploadDate],[Uploadby],[SyncDate],[Syncby],[SynID]) Select " + Tenent + ",[UOM],[UOMNAMESHORT],[UOMNAME1],[UOMNAME2],[UOMNAME3],[REMARKS],[CRUP_ID],[Active],[UOMNAME],[UOMNAMEO],[UOM_TYPE],[UploadDate],[Uploadby],[SyncDate],[Syncby],[SynID] From ICUOM Where TenentID=0 and UOM_TYPE='POS' and UOM not in(select UOM from ICUOM where TenentID=" + Tenent + " and UOM=ICUOM.UOM);";
            if (DB.Win_tbl_customer.Where(p => p.TenentID == Tenent && p.ID == 1).Count() == 0)
                Str += "INSERT INTO [dbo].[Win_tbl_customer]([TenentID],[ID],[Name],[EmailAddress],[Phone],[Address],[City],[PeopleType],[UploadDate],[Uploadby],[SynID],[NameArabic]) VALUES (" + Tenent + ",1,'Gest','Gest@gmail.com','12345678','Kuwait','Kuwait','Customer','10/12/2018  00:00:00 AM','Parimal',9,'غيست');";
            if (DB.Win_tbl_orderWay_Maintenance.Where(p => p.TenentID == Tenent).Count() == 0)
            {
                Str += "INSERT INTO [dbo].[Win_tbl_orderWay_Maintenance]([TenentID],[ID],[OrderWayID],[Name1],[Name2],[Commission_per],[Commission_Amount],[DeliveryCharges],[Paid_Commission],[Pending_Commission]) VALUES (" + Tenent + ",1,'Walk In','Walk In','Walk In',0,0,0,0,0);";
                Str += "INSERT INTO [dbo].[Win_tbl_orderWay_Maintenance]([TenentID],[ID],[OrderWayID],[Name1],[Name2],[Commission_per],[Commission_Amount],[DeliveryCharges],[Paid_Commission],[Pending_Commission]) VALUES (" + Tenent + ",2,'Talabat','Talabat','Talabat',0,0,0,0,0);";
                Str += "INSERT INTO [dbo].[Win_tbl_orderWay_Maintenance]([TenentID],[ID],[OrderWayID],[Name1],[Name2],[Commission_per],[Commission_Amount],[DeliveryCharges],[Paid_Commission],[Pending_Commission]) VALUES (" + Tenent + ",3,'Carriage','Carriage','Carriage',0,0,0,0,0);";
                Str += "INSERT INTO [dbo].[Win_tbl_orderWay_Maintenance]([TenentID],[ID],[OrderWayID],[Name1],[Name2],[Commission_per],[Commission_Amount],[DeliveryCharges],[Paid_Commission],[Pending_Commission]) VALUES (" + Tenent + ",4,'Home Delivery 1','Home Delivery 1','Home Delivery 1',0,0,0,0,0);";
                Str += "INSERT INTO [dbo].[Win_tbl_orderWay_Maintenance]([TenentID],[ID],[OrderWayID],[Name1],[Name2],[Commission_per],[Commission_Amount],[DeliveryCharges],[Paid_Commission],[Pending_Commission]) VALUES (" + Tenent + ",5,'Home Delivery 2','Home Delivery 2','Home Delivery 2',0,0,0,0,0);";
            }
            if (Str != "")
            {
                command2 = new SqlCommand(Str, con);
                con.Open();
                command2.ExecuteReader();
                con.Close();
            }
        }

        public static void Win_registation(int Tenent, string UName, string UPass, string Compname, string compname2, string compname3, string CommanDefauLANG, string CompAdd, string CompPhone, string CompWebside, string userLastName, string useradd, string usermobile, string userbirthdate, string useremail, string userusertype, bool RegStatus)
        {
            Database.Win_WebRegistration objreg = new Database.Win_WebRegistration();
            objreg.TenentID = Tenent;
            objreg.UserName = UName;
            objreg.UserPassword = UPass;
            objreg.CompName1 = Compname;
            objreg.CompName2 = compname2;
            objreg.CompName3 = compname3;
            objreg.DefaultLANGUAGE = CommanDefauLANG;
            objreg.CompAddress = CompAdd;
            objreg.CompPhone = CompPhone;
            objreg.CompWebside = CompWebside;
            objreg.UserLastname = userLastName;
            objreg.UserAddress = useradd;
            objreg.UserPhone = usermobile;
            objreg.UserBirthdate = userbirthdate;
            objreg.UserEmail = useremail;
            objreg.UserType = userusertype;
            objreg.RegStatus = RegStatus;
            DB.Win_WebRegistration.AddObject(objreg);
            DB.SaveChanges();
        }
    }
}
