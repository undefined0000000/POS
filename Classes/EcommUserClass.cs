using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Database;

namespace Classes
{
    public static class EcommUserClass
    {
        public static List<TempDisplayEcomTable> getDataTempDisplayEcomTable(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TempDisplayEcomTable> List = new List<TempDisplayEcomTable>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TempDisplayEcomTable");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TempDisplayEcomTable"] != null)
            //        List = ((List<TempDisplayEcomTable>)System.Web.HttpContext.Current.Cache["TempDisplayEcomTable"]).ToList();
            //    else
            //    {
            //        List = DB.TempDisplayEcomTable.Where(p => p.Active == "1").OrderBy(m => m.MyID).ToList();
            //        System.Web.HttpContext.Current.Cache["TempDisplayEcomTable"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{ 
            List = DB.TempDisplayEcomTables.Where(p => p.Active == "1" && p.TenentID==TID).OrderBy(m => m.MyID).ToList();
            //System.Web.HttpContext.Current.Cache["TempDisplayEcomTable"] = List;
            //objChache.IsCache = false;
            //  DB.SaveChanges();
            //}
            return List;
        }
        public static List<Tbl_Multi_Color_Size_Mst> getDataTbl_Multi_Color_Size_Mst(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<Tbl_Multi_Color_Size_Mst> List = new List<Tbl_Multi_Color_Size_Mst>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Tbl_Multi_Color_Size_Mst");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Tbl_Multi_Color_Size_Mst"] != null)
            //        List = ((List<Tbl_Multi_Color_Size_Mst>)System.Web.HttpContext.Current.Cache["Tbl_Multi_Color_Size_Mst"]).ToList();
            //    else
            //    {
            //        List = DB.Tbl_Multi_Color_Size_Mst.Where(p => p.Active == true).OrderBy(m => m.CompniyAndContactID).ToList();
            //        System.Web.HttpContext.Current.Cache["Tbl_Multi_Color_Size_Mst"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Tbl_Multi_Color_Size_Mst.Where(p => p.Active == true && p.TenentID==TID).OrderBy(m => m.CompniyAndContactID).ToList();
            //    System.Web.HttpContext.Current.Cache["Tbl_Multi_Color_Size_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tbl_Cart_Mst> getDatatbl_Cart_Mst(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tbl_Cart_Mst> List = new List<tbl_Cart_Mst>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tbl_Cart_Mst");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tbl_Cart_Mst"] != null)
            //        List = ((List<tbl_Cart_Mst>)System.Web.HttpContext.Current.Cache["tbl_Cart_Mst"]).ToList();
            //    else
            //    {
            //        List = DB.tbl_Cart_Mst.Where(p => p.Active == true).OrderBy(m => m.Product_ID).ToList();
            //        System.Web.HttpContext.Current.Cache["tbl_Cart_Mst"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tbl_Cart_Mst.Where(p => p.Active == true && p.TenentID==TID).OrderBy(m => m.Product_ID).ToList();
            //    System.Web.HttpContext.Current.Cache["tbl_Cart_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<ImageTable> getDataImageTable(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<ImageTable> List = new List<ImageTable>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "ImageTable");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["ImageTable"] != null)
            //        List = ((List<ImageTable>)System.Web.HttpContext.Current.Cache["ImageTable"]).ToList();
            //    else
            //    {
            //        List = DB.ImageTable.Where(p => p.Active == "1").OrderBy(m => m.MYPRODID).ToList();
            //        System.Web.HttpContext.Current.Cache["ImageTable"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.ImageTables.Where(p => p.Active == "1" && p.TenentID==TID).OrderBy(m => m.MYPRODID).ToList();
            //    System.Web.HttpContext.Current.Cache["ImageTable"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tblCOUNTRY> getDatatblCOUNTRY(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tblCOUNTRY> List = new List<tblCOUNTRY>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tblCOUNTRY");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tblCOUNTRY"] != null)
            //        List = ((List<tblCOUNTRY>)System.Web.HttpContext.Current.Cache["tblCOUNTRY"]).ToList();
            //    else
            //    {
            //        List = DB.tblCOUNTRY.Where(p => p.Active == "Y").OrderBy(m => m.COUNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["tblCOUNTRY"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tblCOUNTRies.Where(p => p.Active == "Y" && p.TenentID==TID).OrderBy(m => m.COUNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["tblCOUNTRY"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tblState> getDatatblStates(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tblState> List = new List<tblState>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tblStates");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tblStates"] != null)
            //        List = ((List<tblStates>)System.Web.HttpContext.Current.Cache["tblStates"]).ToList();
            //    else
            //    {
            //        List = DB.tblStates.Where(p => p.ACTIVE == "Y").OrderBy(m => m.MYNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["tblStates"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tblStates.Where(p => p.ACTIVE1 == "Y").OrderBy(m => m.MYNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["tblStates"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Favourite_list> getDataFavourite_list(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<Database.Favourite_list> List = new List<Database.Favourite_list>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Favourite_list");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Favourite_list"] != null)
            //        List = ((List<Favourite_list>)System.Web.HttpContext.Current.Cache["Favourite_list"]).ToList();
            //    else
            //    {
            //        List = DB.Favourite_list.OrderBy(m => m.Session_id).ToList();
            //        System.Web.HttpContext.Current.Cache["Favourite_list"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Favourite_list.OrderBy(m => m.Session_id).ToList();
            //    System.Web.HttpContext.Current.Cache["Favourite_list"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLPRODUCT> getDataTBLPRODUCT(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLPRODUCT> List = new List<TBLPRODUCT>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLPRODUCT");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLPRODUCT"] != null)
            //        List = ((List<TBLPRODUCT>)System.Web.HttpContext.Current.Cache["TBLPRODUCT"]).ToList();
            //    else
            //    {
            //        List = DB.TBLPRODUCT.Where(p => p.ACTIVE == "1").OrderBy(m => m.ProdName1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLPRODUCT"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLPRODUCTs.Where(p => p.ACTIVE == "1" && p.TenentID==TID).OrderBy(m => m.ProdName1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLPRODUCT"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBL_INVOICE> getDataTBL_INVOICE(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBL_INVOICE> List = new List<TBL_INVOICE>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBL_INVOICE");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBL_INVOICE"] != null)
            //        List = ((List<TBL_INVOICE>)System.Web.HttpContext.Current.Cache["TBL_INVOICE"]).ToList();
            //    else
            //    {
            //        List = DB.TBL_INVOICE.OrderBy(m => m.customer_name).ToList();
            //        System.Web.HttpContext.Current.Cache["TBL_INVOICE"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBL_INVOICE.OrderBy(m => m.customer_name).ToList();
            //    System.Web.HttpContext.Current.Cache["TBL_INVOICE"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Eco_CRMMainActivitiesTikit> getDataEco_CRMMainActivitiesTikit(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<Eco_CRMMainActivitiesTikit> List = new List<Eco_CRMMainActivitiesTikit>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_CRMMainActivitiesTikit");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] != null)
            //        List = ((List<Eco_CRMMainActivitiesTikit>)System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_CRMMainActivitiesTikit.Where(p => p.TenentID == 1 && p.REFTYPE == "Eco" && p.ACTIVITYTYPE == "TKT" ).OrderBy(m => m.MyStatus).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Eco_CRMMainActivitiesTikit.Where(p => p.TenentID == 1 && p.REFTYPE == "Eco" && p.ACTIVITYTYPE == "TKT").OrderBy(m => m.MyStatus).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Eco_CRMActivitiesTikit> getDataEco_CRMActivitiesTikit(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<Eco_CRMActivitiesTikit> List = new List<Eco_CRMActivitiesTikit>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_CRMActivitiesTikit");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_CRMActivitiesTikit"] != null)
            //        List = ((List<Eco_CRMActivitiesTikit>)System.Web.HttpContext.Current.Cache["Eco_CRMActivitiesTikit"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_CRMActivitiesTikit.Where(p => p.Active == "Y").OrderBy(m => m.TenentID).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_CRMActivitiesTikit"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Eco_CRMActivitiesTikit.Where(p => p.Active == "Y" && p.TenentID==TID).OrderBy(m => m.TenentID).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_CRMActivitiesTikit"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tblWishList> getDatatblWishLists(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tblWishList> List = new List<tblWishList>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tblWishLists");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tblWishLists"] != null)
            //        List = ((List<tblWishLists>)System.Web.HttpContext.Current.Cache["tblWishLists"]).ToList();
            //    else
            //    {
            //        List = DB.tblWishLists.OrderBy(m => m.WL_ID).ToList();
            //        System.Web.HttpContext.Current.Cache["tblWishLists"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tblWishLists.OrderBy(m => m.WL_ID).ToList();
            //    System.Web.HttpContext.Current.Cache["tblWishLists"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLCOMPANYSETUP> getDataTBLCOMPANYSETUP(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLCOMPANYSETUP> List = new List<TBLCOMPANYSETUP>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_TBLCOMPANYSETUP");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_TBLCOMPANYSETUP"] != null)
            //        List = ((List<Eco_TBLCOMPANYSETUP>)System.Web.HttpContext.Current.Cache["Eco_TBLCOMPANYSETUP"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_TBLCOMPANYSETUP.Where(p => p.Active == "Y").OrderBy(m => m.COMPNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_TBLCOMPANYSETUP"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "Y" && p.TenentID==TID).OrderBy(m => m.COMPNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_TBLCOMPANYSETUP"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        
        //public static DropDownList getdropdown(DropDownList drp, int TID, string switch1, string switch2, string switch3, string TableName)//haresh
        //{
          
           
            //if (TableName == "tblCOUNTRY")
            //{
            //    drp.DataSource = getDatatblCOUNTRY().Where(p => p.TenentID == TID);
            //    drp.DataTextField = "COUNAME1";
            //    drp.DataValueField = "COUNTRYID";
            //    drp.DataBind();
            //    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select COUNTRY--", "0"));
            //}
          
            //else if (TableName == "Eco_TBLCOMPANYSETUP")
            //{
            //    drp.DataSource = getDataTBLCOMPANYSETUP().Where(p => p.TenentID == TID && p.PHYSICALLOCID == switch1);
            //    drp.DataTextField = "COMPNAME1";
            //    drp.DataValueField = "COMPID";
            //    drp.DataBind();
            //    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Not Exists", "0"));
            //}
            //drp = new DropDownList();
           // return drp;
        //}

        public static void insertTBLCONTACT(int TenentID, int ContactMyID, int CONTACTID, string PHYSICALLOCID, string PersName1, string PersName2, string PersName3, string EMAIL1, string MOBPHONE, string ITMANAGER, string ADDR1, string ADDR2, string CITY, string STATE, string POSTALCODE, string ZIPCODE, int MYCONLOCID, int COUNTRYID, string BUSPHONE1, string Active, string REMARKS, int CRUP_ID, int COMPANYID, int MYCATSUBID, string MYPRODID, string DESERIAL, int CATID, string CATTYPE, string SUBCATTYPE, int SUBCATID, string PERSNAME, string PERSNAMEO, string PERSNAMEO2, string EMAIL2, string PRIMLANGUGE, string WEBPAGE, bool ISSMB, bool INHAWALLY, bool EMAISUB, DateTime EMAILSUBDATE, string PRODUCTDEALIN, bool SALER, bool BUYER, bool FREELANCER, bool SALEDEPROD, string CUSERID, string CPASSWRD, string USERID, DateTime ENTRYTIME, DateTime UPDTTIME, string IMG)
        {
            Database.CallEntities DB = new Database.CallEntities();
            TBLCONTACT objTBLCONTACT = new TBLCONTACT();
            objTBLCONTACT.TenentID = TenentID;
            objTBLCONTACT.ContactMyID = ContactMyID;
            objTBLCONTACT.CONTACTID = CONTACTID;
            objTBLCONTACT.PHYSICALLOCID = PHYSICALLOCID;
            objTBLCONTACT.PersName1 = PersName1;
            objTBLCONTACT.PersName2 = PersName2;
            objTBLCONTACT.PersName3 = PersName3;
            objTBLCONTACT.EMAIL1 = EMAIL1;
            objTBLCONTACT.MOBPHONE = MOBPHONE;
            objTBLCONTACT.ITMANAGER = ITMANAGER;
            objTBLCONTACT.ADDR1 = ADDR1;
            objTBLCONTACT.ADDR2 = ADDR2;
            objTBLCONTACT.CITY = CITY;
            objTBLCONTACT.STATE = STATE;
            objTBLCONTACT.POSTALCODE = POSTALCODE;
            objTBLCONTACT.ZIPCODE = ZIPCODE;
            objTBLCONTACT.MYCONLOCID = MYCONLOCID;
            objTBLCONTACT.COUNTRYID = COUNTRYID;
            objTBLCONTACT.BUSPHONE1 = BUSPHONE1;
            objTBLCONTACT.Active = Active;
            objTBLCONTACT.REMARKS = REMARKS;
            objTBLCONTACT.CRUP_ID = CRUP_ID;
            objTBLCONTACT.COMPANYID = COMPANYID;
            objTBLCONTACT.MYCATSUBID = MYCATSUBID;
            objTBLCONTACT.MYPRODID = MYPRODID;
            objTBLCONTACT.DESERIAL = DESERIAL;
            objTBLCONTACT.CATID = CATID;
            objTBLCONTACT.CATTYPE = CATTYPE;
            objTBLCONTACT.SUBCATTYPE = SUBCATTYPE;
            objTBLCONTACT.SUBCATID = SUBCATID;
            objTBLCONTACT.PERSNAME = PERSNAME;
            objTBLCONTACT.PERSNAMEO = PERSNAMEO;
            objTBLCONTACT.PERSNAMEO2 = PERSNAMEO2;
            objTBLCONTACT.EMAIL2 = EMAIL2;
            objTBLCONTACT.PRIMLANGUGE = PRIMLANGUGE;
            objTBLCONTACT.WEBPAGE = WEBPAGE;
            objTBLCONTACT.ISSMB = ISSMB;
            objTBLCONTACT.INHAWALLY = INHAWALLY;
            objTBLCONTACT.EMAISUB = EMAISUB;
            objTBLCONTACT.EMAILSUBDATE = EMAILSUBDATE;
            objTBLCONTACT.PRODUCTDEALIN = PRODUCTDEALIN;
            objTBLCONTACT.SALER = SALER;
            objTBLCONTACT.BUYER = BUYER;
            objTBLCONTACT.FREELANCER = FREELANCER;
            objTBLCONTACT.SALEDEPROD = SALEDEPROD;
            objTBLCONTACT.CUSERID = CUSERID;
            objTBLCONTACT.CPASSWRD = CPASSWRD;
            objTBLCONTACT.USERID = USERID;
            objTBLCONTACT.ENTRYTIME = ENTRYTIME;
            objTBLCONTACT.UPDTTIME = UPDTTIME;
          //  objTBLCONTACT.IMG = IMG;
            DB.TBLCONTACTs.AddObject(objTBLCONTACT);
            DB.SaveChanges();
        }

        public static void insertTbl_Multi_Color_Size_Mst(int TenentID, string RecordType, int RecTypeID, int CompniyAndContactID, int RunSerial, int Recource, string RecValue, bool Active, string RecourceName)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Tbl_Multi_Color_Size_Mst OBJTbl_Multi_Color_Size_Mst = new Tbl_Multi_Color_Size_Mst();
            OBJTbl_Multi_Color_Size_Mst.TenentID = TenentID;
            OBJTbl_Multi_Color_Size_Mst.RecordType = RecordType;
            OBJTbl_Multi_Color_Size_Mst.RecTypeID = RecTypeID;
            OBJTbl_Multi_Color_Size_Mst.CompniyAndContactID = CompniyAndContactID;
            OBJTbl_Multi_Color_Size_Mst.RunSerial = RunSerial;
            OBJTbl_Multi_Color_Size_Mst.Recource = Recource;
            OBJTbl_Multi_Color_Size_Mst.RecValue = RecValue;
            OBJTbl_Multi_Color_Size_Mst.Active = Active;
            OBJTbl_Multi_Color_Size_Mst.RecourceName = RecourceName;
            DB.Tbl_Multi_Color_Size_Mst.AddObject(OBJTbl_Multi_Color_Size_Mst);
            DB.SaveChanges();
        }
    }
}
