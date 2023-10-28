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
using System.Data;

namespace Classes
{
    public static class EcommAdminClass
    {
        static Database.CallEntities DB = new Database.CallEntities();
        public static List<USER_MST> getDataUSER_MST(int TID)//haresh
        {

            List<USER_MST> List = new List<USER_MST>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "USER_MST");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["USER_MST"] != null)
            //        List = ((List<USER_MST>)System.Web.HttpContext.Current.Cache["USER_MST"]).ToList();
            //    else
            //    {
            //        List = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y").OrderBy(m => m.USER_ID).ToList();
            //        System.Web.HttpContext.Current.Cache["USER_MST"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.USER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.USER_ID).ToList();
            //    System.Web.HttpContext.Current.Cache["USER_MST"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<MODULE_MST> getDataMODULE_MST(int TID)
        {

            List<MODULE_MST> List = new List<MODULE_MST>();
            List = DB.MODULE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.Module_Id).ToList();
            return List;
        }
        public static List<MODULE_MAP> getDataMODULE_MAP(int TID)
        {

            List<MODULE_MAP> List = new List<MODULE_MAP>();
            List = DB.MODULE_MAP.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.MODULE_MAP_ID).ToList();
            return List;
        }
        public static List<PRIVILEGE_MST> getDataPRIVILEGE_MST(int TID)
        {

            List<PRIVILEGE_MST> List = new List<PRIVILEGE_MST>();
            List = DB.PRIVILEGE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.PRIVILEGE_ID).ToList();
            return List;
        }
        public static List<Tbl_RouteMST> getDataTbl_RouteMST(int TID)
        {

            List<Tbl_RouteMST> List = new List<Tbl_RouteMST>();
            List = DB.Tbl_RouteMST.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.Name1).ToList();
            return List;
        }
        public static List<TBLCOMPANYSETUP> getDataTBLCOMPANYSETUP(int TID)//haresh
        {

            List<TBLCOMPANYSETUP> List = new List<TBLCOMPANYSETUP>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLCOMPANYSETUP");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] != null)
            //        List = ((List<TBLCOMPANYSETUP>)System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"]).ToList();
            //    else
            //    {
            //        List = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "Y").OrderBy(m => m.COMPNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.COMPNAME1).ToList();
            //System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] = List;
            // objChache.IsCache = false;
            // DB.SaveChanges();
            // }
            return List;
        }

        public static List<ISSearchDetail> getDataISSearchDetail(int TID)//haresh
        {

            List<ISSearchDetail> List = new List<ISSearchDetail>();
            var objChache = DB.Cache_Mst.Single(p => p.TableName == "ISSearchDetail");
            if (objChache.IsCache == false)
            {
                if (System.Web.HttpContext.Current.Cache["ISSearchDetail"] != null)
                    List = ((List<ISSearchDetail>)System.Web.HttpContext.Current.Cache["ISSearchDetail"]).ToList();
                else
                {
                    List = DB.ISSearchDetails.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.ID).ToList();
                    System.Web.HttpContext.Current.Cache["ISSearchDetail"] = List;
                    objChache.IsCache = false;
                    DB.SaveChanges();
                }
            }
            else
            {
                List = DB.ISSearchDetails.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.ID).ToList();
                System.Web.HttpContext.Current.Cache["ISSearchDetail"] = List;
                objChache.IsCache = false;
                DB.SaveChanges();
            }
            return List;
        }
        public static List<ROLE_MST> getDataROLE_MST(int TID)//haresh
        {

            List<ROLE_MST> List = new List<ROLE_MST>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "ROLE_MST");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["ROLE_MST"] != null)
            //        List = ((List<ROLE_MST>)System.Web.HttpContext.Current.Cache["ROLE_MST"]).ToList();
            //    else
            //    {
            //        List = DB.ROLE_MST.Where(p => p.ACTIVE_FLAG == "Y").OrderBy(m => m.ROLE_NAME).ToList();
            //        System.Web.HttpContext.Current.Cache["ROLE_MST"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.ROLE_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.ROLE_NAME).ToList();
            //    System.Web.HttpContext.Current.Cache["ROLE_MST"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<ERP_QUESTION_BANK> getDataERP_QUESTION_BANK(int TID)//haresh
        {

            List<ERP_QUESTION_BANK> List = new List<ERP_QUESTION_BANK>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "ERP_QUESTION_BANK");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["ERP_QUESTION_BANK"] != null)
            //        List = ((List<ERP_QUESTION_BANK>)System.Web.HttpContext.Current.Cache["ERP_QUESTION_BANK"]).ToList();
            //    else
            //    {
            //        List = DB.ERP_QUESTION_BANK.Where(p => p.ACTIVE_FLAG == "Y").OrderBy(m => m.QUESTION).ToList();
            //        System.Web.HttpContext.Current.Cache["ERP_QUESTION_BANK"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.ERP_QUESTION_BANK.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.QUESTION).ToList();
            //    System.Web.HttpContext.Current.Cache["ERP_QUESTION_BANK"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tblCOUNTRY> getDatatblCOUNTRY(int TID)//haresh
        {

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
            List = DB.tblCOUNTRies.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.COUNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["tblCOUNTRY"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<TBLLOCATION> getDataTBLLOCATION(int TID)  //haresh
        {

            List<TBLLOCATION> List = new List<TBLLOCATION>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLLOCATION");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLLOCATION"] != null)
            //        List = ((List<TBLLOCATION>)System.Web.HttpContext.Current.Cache["TBLLOCATION"]).ToList();
            //    else
            //    {
            //        List = DB.TBLLOCATION.Where(p => p.Active == "Y").OrderBy(m => m.LOCNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLLOCATION"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLLOCATIONs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.LOCNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLLOCATION"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<FUNCTION_MST> getDataFUNCTION_MST(int TID)//Bhavesh
        {

            List<FUNCTION_MST> List = new List<FUNCTION_MST>();
            List = DB.FUNCTION_MST.Where(p => p.ACTIVE_FLAG == 1 && p.TenentID == TID).OrderBy(m => m.MENU_NAME1).ToList();
            return List;
        }

        public static List<Tbl_Position_Mst> getDataPosition_Mst(int TID)//Bhavesh
        {

            List<Tbl_Position_Mst> List = new List<Tbl_Position_Mst>();
            List = DB.Tbl_Position_Mst.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.PositionName).ToList();
            return List;
        }
        public static List<tblCONTACTBu> getDatatblCONTACTBus(int TID)//Bhavesh
        {

            List<tblCONTACTBu> List = new List<tblCONTACTBu>();
            List = DB.tblCONTACTBus.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.JobTitle).ToList();
            return List;
        }
        public static List<TBLCOMPANY_LOCATION> getDataTBLCOMPANY_LOCATION(int TID)//Bhavesh
        {

            List<TBLCOMPANY_LOCATION> List = new List<TBLCOMPANY_LOCATION>();
            List = DB.TBLCOMPANY_LOCATION.Where(p => p.ACTIVE == "Y" && p.TenentID == TID).OrderBy(m => m.LOCATION_NAME1).ToList();
            return List;
        }
        public static List<tblLanguage> getDatatblLanguages(int TID)//Bhavesh
        {

            List<tblLanguage> List = new List<tblLanguage>();
            List = DB.tblLanguages.Where(p => p.ACTIVE == "Y" && p.TenentID == TID).OrderBy(m => m.LangName1).ToList();
            return List;
        }
        public static List<Mail_Templet> getDataMail_Templet(int TID)//Bhavesh
        {

            List<Mail_Templet> List = new List<Mail_Templet>();
            List = DB.Mail_Templet.Where(p => p.Actived == true).OrderBy(m => m.Title).ToList();
            return List;
        }
        public static List<Eco_CRMMainActivitiesTikit> getDataEco_CRMMainActivitiesTikit(int TID)//haresh
        {

            List<Eco_CRMMainActivitiesTikit> List = new List<Eco_CRMMainActivitiesTikit>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_CRMMainActivitiesTikit");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] != null)
            //        List = ((List<Eco_CRMMainActivitiesTikit>)System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_CRMMainActivitiesTikit.Where(p => p.TenentID == 1 && p.REFTYPE == "Eco" && p.ACTIVITYTYPE == "TKT" && p.MyStatus != "Closed").OrderBy(m => m.MyStatus).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Eco_CRMMainActivitiesTikit.Where(p => p.TenentID == 1 && p.REFTYPE == "Eco" && p.ACTIVITYTYPE == "TKT" && p.MyStatus != "Closed").OrderBy(m => m.MyStatus).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_CRMMainActivitiesTikit"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<tbl_test_order> getDatatbl_test_order(int TID)//haresh
        {

            List<tbl_test_order> List = new List<tbl_test_order>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tbl_test_order");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tbl_test_order"] != null)
            //        List = ((List<tbl_test_order>)System.Web.HttpContext.Current.Cache["tbl_test_order"]).ToList();
            //    else
            //    {
            //        List = DB.tbl_test_order.Where(p => p.Deleted == true).OrderBy(m => m.ID).ToList();
            //        System.Web.HttpContext.Current.Cache["tbl_test_order"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tbl_test_order.Where(p => p.Deleted == true).OrderBy(m => m.ID).ToList();
            //    System.Web.HttpContext.Current.Cache["tbl_test_order"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<REFTABLE> getDataREFTABLE(int TID)//haresh
        {

            List<REFTABLE> List = new List<REFTABLE>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "REFTABLE");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["REFTABLE"] != null)
            //        List = ((List<REFTABLE>)System.Web.HttpContext.Current.Cache["REFTABLE"]).ToList();
            //    else
            //    {
            //        List = DB.REFTABLE.Where(p => p.ACTIVE == "Y").OrderBy(m => m.REFNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["REFTABLE"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.REFTABLEs.Where(p => p.ACTIVE == "Y" && p.TenentID == TID).OrderBy(m => m.REFNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["REFTABLE"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<CAT_MST> getDataCAT_MST(int TID)//haresh
        {

            List<CAT_MST> List = new List<CAT_MST>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "CAT_MST");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["CAT_MST"] != null)
            //        List = ((List<CAT_MST>)System.Web.HttpContext.Current.Cache["CAT_MST"]).ToList();
            //    else
            //    {
            //        List = DB.CAT_MST.Where(p => p.Active == "1").OrderBy(m => m.CAT_NAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["CAT_MST"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.CAT_MST.Where(p => p.Active == "1" && p.TenentID == TID).OrderBy(m => m.CAT_NAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["CAT_MST"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tblState> getDatatblStates(int TID)//haresh
        {

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
        public static List<TBLPRODUCT> getDataTBLPRODUCT(int TID)//haresh
        {

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
            List = DB.TBLPRODUCTs.Where(p => p.ACTIVE == "1" && p.TenentID == TID).OrderBy(m => m.ProdName1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLPRODUCT"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Product_Cat_Mst> getDataProduct_Cat_Mst(int TID)//haresh
        {

            List<Product_Cat_Mst> List = new List<Product_Cat_Mst>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Product_Cat_Mst");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Product_Cat_Mst"] != null)
            //        List = ((List<Product_Cat_Mst>)System.Web.HttpContext.Current.Cache["Product_Cat_Mst"]).ToList();
            //    else
            //    {
            //        List = DB.Product_Cat_Mst.Where(p => p.Active == "1").OrderBy(m => m.CATID).ToList();
            //        System.Web.HttpContext.Current.Cache["Product_Cat_Mst"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Product_Cat_Mst.Where(p => p.Active == "1" && p.TenentID == TID).OrderBy(m => m.CATID).ToList();
            //    System.Web.HttpContext.Current.Cache["Product_Cat_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<TBLSIZE> getDataTBLSIZE(int TID)//haresh
        {

            List<TBLSIZE> List = new List<TBLSIZE>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLSIZE");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLSIZE"] != null)
            //        List = ((List<TBLSIZE>)System.Web.HttpContext.Current.Cache["TBLSIZE"]).ToList();
            //    else
            //    {
            //        List = DB.TBLSIZE.Where(p => p.ACTIVE == "Y").OrderBy(m => m.SIZEDESC1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLSIZE"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLSIZEs.Where(p => p.ACTIVE == "Y" && p.TenentID == TID).OrderBy(m => m.SIZEDESC1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLSIZE"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<MYBU> getDataMYBUS(int TID)//haresh
        {

            List<MYBU> List = new List<MYBU>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "MYBUS");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["MYBUS"] != null)
            //        List = ((List<MYBUS>)System.Web.HttpContext.Current.Cache["MYBUS"]).ToList();
            //    else
            //    {
            //        List = DB.MYBUS.OrderBy(m => m.BUSNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["MYBUS"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.MYBUS.Where(p => p.TenentID == TID).OrderBy(p => p.BUSNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["MYBUS"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<ICUOM> getDataICUOM(int TID)//haresh
        {

            List<ICUOM> List = new List<ICUOM>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "ICUOM");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["ICUOM"] != null)
            //        List = ((List<ICUOM>)System.Web.HttpContext.Current.Cache["ICUOM"]).ToList();
            //    else
            //    {
            //        List = DB.ICUOM.Where(p => p.Active == "Y").OrderBy(m => m.UOMNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["ICUOM"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.ICUOMs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.UOMNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["ICUOM"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLCOLOR> getDataTBLCOLOR(int TID)//haresh
        {

            List<TBLCOLOR> List = new List<TBLCOLOR>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLCOLOR");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLCOLOR"] != null)
            //        List = ((List<TBLCOLOR>)System.Web.HttpContext.Current.Cache["TBLCOLOR"]).ToList();
            //    else
            //    {
            //        List = DB.TBLCOLOR.Where(p => p.Active == "Y").OrderBy(m => m.COLORDESC1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLCOLOR"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLCOLORs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.COLORDESC1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLCOLOR"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Banner> getDataBanner(int TID)//haresh
        {

            List<Banner> List = new List<Banner>();

            List = DB.Banners.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.BannerID).ToList();

            return List;
        }
        public static List<DEPTOFSale> getDataDEPTOFSale(int TID)//haresh
        {

            List<DEPTOFSale> List = new List<DEPTOFSale>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "DEPTOFSale");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["DEPTOFSale"] != null)
            //        List = ((List<DEPTOFSale>)System.Web.HttpContext.Current.Cache["DEPTOFSale"]).ToList();
            //    else
            //    {
            //        List = DB.DEPTOFSale.Where(p => p.Active_Flag == true).OrderBy(m => m.DeptDesc1).ToList();
            //        System.Web.HttpContext.Current.Cache["DEPTOFSale"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.DEPTOFSales.Where(p => p.Active_Flag == true && p.TenentID == TID).OrderBy(m => m.DeptDesc1).ToList();
            //    System.Web.HttpContext.Current.Cache["DEPTOFSale"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLGROUP> getDataTBLGROUP(int TID)//haresh
        {

            List<TBLGROUP> List = new List<TBLGROUP>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLGROUP");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLGROUP"] != null)
            //        List = ((List<TBLGROUP>)System.Web.HttpContext.Current.Cache["TBLGROUP"]).ToList();
            //    else
            //    {
            //        List = DB.TBLGROUP.Where(p => p.ACTIVE_Flag == true).OrderBy(m => m.ITGROUPDESC1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLGROUP"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLGROUPs.Where(p => p.ACTIVE_Flag == true && p.TenentID == TID).OrderBy(m => m.ITGROUPDESC1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLGROUP"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<tblBusProd> getDatatblBusProd(int TID)//haresh
        {

            List<tblBusProd> List = new List<tblBusProd>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tblBusProd");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tblBusProd"] != null)
            //        List = ((List<tblBusProd>)System.Web.HttpContext.Current.Cache["tblBusProd"]).ToList();
            //    else
            //    {
            //        List = DB.tblBusProd.Where(p => p.ACTIVE == true).OrderBy(m => m.BUSNAME).ToList();
            //        System.Web.HttpContext.Current.Cache["tblBusProd"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tblBusProds.Where(p => p.ACTIVE == true && p.TenentID == TID).OrderBy(m => m.BUSNAME).ToList();
            //    System.Web.HttpContext.Current.Cache["tblBusProd"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Fetaures_List_Mst> getDataFetaures_List_Mst(int TID)//haresh
        {

            List<Fetaures_List_Mst> List = new List<Fetaures_List_Mst>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Fetaures_List_Mst");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Fetaures_List_Mst"] != null)
            //        List = ((List<Fetaures_List_Mst>)System.Web.HttpContext.Current.Cache["Fetaures_List_Mst"]).ToList();
            //    else
            //    {
            //        List = DB.Fetaures_List_Mst.Where(p => p.Active == true).OrderBy(m => m.FetauresName1).ToList();
            //        System.Web.HttpContext.Current.Cache["Fetaures_List_Mst"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Fetaures_List_Mst.Where(p => p.Active == true).OrderBy(m => m.FetauresName1).ToList();
            //    System.Web.HttpContext.Current.Cache["Fetaures_List_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<tblprod_feature> getDatatblprod_feature(int TID)//haresh
        {

            List<tblprod_feature> List = new List<tblprod_feature>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tblprod_feature");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tblprod_feature"] != null)
            //        List = ((List<tblprod_feature>)System.Web.HttpContext.Current.Cache["tblprod_feature"]).ToList();
            //    else
            //    {
            //        List = DB.tblprod_feature.Where(p => p.Active == true).OrderBy(m => m.FeatureName).ToList();
            //        System.Web.HttpContext.Current.Cache["tblprod_feature"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tblprod_feature.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.FeatureName).ToList();
            //    System.Web.HttpContext.Current.Cache["tblprod_feature"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<ImageTable> getDataImageTable(int TID)//haresh
        {

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
            List = DB.ImageTables.Where(p => p.Active == "1" && p.TenentID == TID).OrderBy(m => m.MYPRODID).ToList();
            //    System.Web.HttpContext.Current.Cache["ImageTable"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<Tbl_Multi_Color_Size_Mst> getDataTbl_Multi_Color_Size_Mst(int TID)//haresh
        {

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
            List = DB.Tbl_Multi_Color_Size_Mst.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.CompniyAndContactID).ToList();
            //    System.Web.HttpContext.Current.Cache["Tbl_Multi_Color_Size_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<tbl_Cart_Mst> getDatatbl_Cart_Mst(int TID)//haresh
        {

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
            List = DB.tbl_Cart_Mst.Where(p => p.Active == true && p.TenentID == TID).OrderBy(m => m.Product_ID).ToList();
            //    System.Web.HttpContext.Current.Cache["tbl_Cart_Mst"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<Eco_ERP_SUPPLIER_MST> getDataEco_ERP_SUPPLIER_MST(int TID)//haresh
        {

            List<Eco_ERP_SUPPLIER_MST> List = new List<Eco_ERP_SUPPLIER_MST>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_Eco_ERP_SUPPLIER_MST");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_Eco_ERP_SUPPLIER_MST"] != null)
            //        List = ((List<Eco_Eco_ERP_SUPPLIER_MST>)System.Web.HttpContext.Current.Cache["Eco_Eco_ERP_SUPPLIER_MST"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_Eco_ERP_SUPPLIER_MST.Where(p => p.ACTIVE_FLAG == "Y").OrderBy(m => m.SUPPLIER_NAME).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_Eco_ERP_SUPPLIER_MST"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.Eco_ERP_SUPPLIER_MST.Where(p => p.ACTIVE_FLAG == "Y" && p.TenentID == TID).OrderBy(m => m.SUPPLIER_NAME).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_Eco_ERP_SUPPLIER_MST"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLSYSTEM> getDataTBLSYSTEMS(int TID)//haresh
        {

            List<TBLSYSTEM> List = new List<TBLSYSTEM>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLSYSTEMS");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLSYSTEMS"] != null)
            //        List = ((List<TBLSYSTEMS>)System.Web.HttpContext.Current.Cache["TBLSYSTEMS"]).ToList();
            //    else
            //    {
            //        List = DB.TBLSYSTEMS.Where(p => p.ACTIVE == "1").OrderBy(m => m.SYSDESC1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLSYSTEMS"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLSYSTEMS.Where(p => p.ACTIVE == "1" && p.TenentID == TID).OrderBy(m => m.SYSDESC1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLSYSTEMS"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<TBLPERIOD> getDataTBLPERIODS(int TID)//haresh
        {

            List<TBLPERIOD> List = new List<TBLPERIOD>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLPERIODS");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLPERIODS"] != null)
            //        List = ((List<TBLPERIODS>)System.Web.HttpContext.Current.Cache["TBLPERIODS"]).ToList();
            //    else
            //    {
            //        List = DB.TBLPERIODS.Where(p => p.STATUS1 == "1").OrderBy(m => m.PRD_PERIOD1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLPERIODS"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLPERIODS.Where(p => p.STATUS1 == "1" && p.TenentID == TID).OrderBy(m => m.PRD_PERIOD1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLPERIODS"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<tbltranstype> getDatatbltranstype(int TID)//haresh
        {

            List<tbltranstype> List = new List<tbltranstype>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "tbltranstype");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["tbltranstype"] != null)
            //        List = ((List<tbltranstype>)System.Web.HttpContext.Current.Cache["tbltranstype"]).ToList();
            //    else
            //    {
            //        List = DB.tbltranstype.Where(p => p.Active == "Y").OrderBy(m => m.transtype1).ToList();
            //        System.Web.HttpContext.Current.Cache["tbltranstype"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tbltranstypes.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.transtype1).ToList();
            //    System.Web.HttpContext.Current.Cache["tbltranstype"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<TBLSYSUSERBATCH> getDataTBLSYSUSERBATCH(int TID)//haresh
        {

            List<TBLSYSUSERBATCH> List = new List<TBLSYSUSERBATCH>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLSYSUSERBATCH");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLSYSUSERBATCH"] != null)
            //        List = ((List<TBLSYSUSERBATCH>)System.Web.HttpContext.Current.Cache["TBLSYSUSERBATCH"]).ToList();
            //    else
            //    {
            //        List = DB.TBLSYSUSERBATCH.Where(p => p.STATUS1 == "1").OrderBy(m => m.MYSYSNAME).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLSYSUSERBATCH"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLSYSUSERBATCHes.Where(p => p.STATUS1 == "1").OrderBy(m => m.MYSYSNAME).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLSYSUSERBATCH"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLPROJECT> getDataTBLPROJECT(int TID)//haresh
        {

            List<TBLPROJECT> List = new List<TBLPROJECT>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLPROJECT");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLPROJECT"] != null)
            //        List = ((List<TBLPROJECT>)System.Web.HttpContext.Current.Cache["TBLPROJECT"]).ToList();
            //    else
            //    {
            //        List = DB.TBLPROJECT.Where(p => p.ACTIVE == true).OrderBy(m => m.PROJECTNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLPROJECT"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLPROJECTs.Where(p => p.ACTIVE == true && p.TenentID == TID).OrderBy(m => m.PROJECTNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLPROJECT"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<tbltranssubtype> getDataEco_tbltranssubtype(int TID)//haresh
        {

            List<tbltranssubtype> List = new List<tbltranssubtype>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "Eco_tbltranssubtype");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["Eco_tbltranssubtype"] != null)
            //        List = ((List<Eco_tbltranssubtype>)System.Web.HttpContext.Current.Cache["Eco_tbltranssubtype"]).ToList();
            //    else
            //    {
            //        List = DB.Eco_tbltranssubtype.Where(p => p.Active == "Y").OrderBy(m => m.transsubtype1).ToList();
            //        System.Web.HttpContext.Current.Cache["Eco_tbltranssubtype"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.tbltranssubtypes.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.transsubtype1).ToList();
            //    System.Web.HttpContext.Current.Cache["Eco_tbltranssubtype"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }

        public static List<TBLBIN> getDataTBLBIN(int TID)//haresh
        {

            List<TBLBIN> List = new List<TBLBIN>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLBIN");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLBIN"] != null)
            //        List = ((List<TBLBIN>)System.Web.HttpContext.Current.Cache["TBLBIN"]).ToList();
            //    else
            //    {
            //        List = DB.TBLBIN.Where(p => p.ACTIVE == "Y").OrderBy(m => m.BINDesc1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLBIN"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLBINs.Where(p => p.ACTIVE == "Y" && p.TenentID == TID).OrderBy(m => m.BINDesc1).ToList();
            //System.Web.HttpContext.Current.Cache["TBLBIN"] = List;
            //objChache.IsCache = false;
            //DB.SaveChanges();
            //}
            return List;
        }
        public static List<TBLCONTACT> getDataTBLCONTACT(int TID)//haresh
        {

            List<TBLCONTACT> List = new List<TBLCONTACT>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLCONTACT");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["TBLCONTACT"] != null)
            //        List = ((List<TBLCONTACT>)System.Web.HttpContext.Current.Cache["TBLCONTACT"]).ToList();
            //    else
            //    {
            //        List = DB.TBLCONTACT.Where(p => p.Active == "Y").OrderBy(m => m.PersName1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLCONTACT"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.TBLCONTACTs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.PersName1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLCONTACT"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        public static List<ICEXTRACOST> getDataICEXTRACOST(int TID)//haresh
        {

            List<ICEXTRACOST> List = new List<ICEXTRACOST>();
            //var objChache = DB.Cache_Mst.Single(p => p.TableName == "ICEXTRACOST");
            //if (objChache.IsCache == false)
            //{
            //    if (System.Web.HttpContext.Current.Cache["ICEXTRACOST"] != null)
            //        List = ((List<ICEXTRACOST>)System.Web.HttpContext.Current.Cache["ICEXTRACOST"]).ToList();
            //    else
            //    {
            //        List = DB.ICEXTRACOST.Where(p => p.Active == "Y").OrderBy(m => m.OHNAME1).ToList();
            //        System.Web.HttpContext.Current.Cache["TBLBIN"] = List;
            //        objChache.IsCache = false;
            //        DB.SaveChanges();
            //    }
            //}
            //else
            //{
            List = DB.ICEXTRACOSTs.Where(p => p.Active == "Y" && p.TenentID == TID).OrderBy(m => m.OHNAME1).ToList();
            //    System.Web.HttpContext.Current.Cache["TBLBIN"] = List;
            //    objChache.IsCache = false;
            //    DB.SaveChanges();
            //}
            return List;
        }
        //-----------------Jobportal DropDown Table------------------
        public static List<tbl_Applicant_SOJobDesc> getApplicant_SOJobDesc(int TID)
        {

            List<tbl_Applicant_SOJobDesc> List = new List<tbl_Applicant_SOJobDesc>();
            List = DB.tbl_Applicant_SOJobDesc.Where(p => p.Active == true).ToList();
            return List;
        }
        public static List<tbl_SkillEducation> getSkillEducation(int TID)
        {

            List<tbl_SkillEducation> List = new List<tbl_SkillEducation>();
            List = DB.tbl_SkillEducation.ToList();
            return List;
        }
        public static List<tbl_Applicant_SOJobDomain> getApplicantDomain(int TID)
        {

            List<tbl_Applicant_SOJobDomain> List = new List<tbl_Applicant_SOJobDomain>();
            List = DB.tbl_Applicant_SOJobDomain.Where(p => p.Active == true).ToList();
            return List;
        }
        public static List<tbl_Applicant_SOJobSubDomain> getApplicantSubDomain(int TID)
        {

            List<tbl_Applicant_SOJobSubDomain> List = new List<tbl_Applicant_SOJobSubDomain>();
            List = DB.tbl_Applicant_SOJobSubDomain.Where(p => p.Active == true).ToList();
            return List;
        }
        public static List<CRMMainActivity> getCRMMainActivities(int TID)
        {

            List<CRMMainActivity> List = new List<CRMMainActivity>();
            List = DB.CRMMainActivities.Where(p => p.ACTIVITYE == "Ticket" && p.TenentID == TID).ToList();
            return List;
        }

        //-----------------End Jobportal DropDown Table------------------
        public static DropDownList getdropdown(DropDownList drp, int TID, string switch1, string switch2, string switch3, string TableName)//haresh
        {

            int UID, LID = 0;

            if (TableName == "GlobleEmployee")
            {
                UID = Convert.ToInt32(switch1);
                LID = Convert.ToInt32(switch2);

                string LangID = switch3;
                var result2 = (from User in DB.USER_MST.Where(p => p.TenentID == TID && p.Till_DT != null)
                               join
                                   emp in DB.tbl_Employee.Where(p => p.TenentID == TID && p.LocationID == LID) on User.EmpID equals emp.employeeID
                               //where emp.userID != UID
                               select new { emp.employeeID, emp.firstname }).ToList();
                //var List = result2.GroupBy(p => p.FIRST_NAME).Select(p => p.FirstOrDefault()).ToList();
                drp.DataSource = result2.OrderBy(p => p.firstname);
                drp.DataValueField = "employeeID";
                if (LangID == "en-US")
                    drp.DataTextField = "firstname";
                else if (LangID == "ar-KW")
                    drp.DataTextField = "name2";
                else
                    drp.DataTextField = "name3";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Employee --", "0"));
            }
            if (TableName == "tbl_Employee")
            {
                LID = Convert.ToInt32(switch1);
                drp.DataSource = DB.tbl_Employee.Where(p => p.TenentID == TID && p.LocationID == LID && p.Deleted == false);
                drp.DataTextField = "firstname";
                drp.DataValueField = "employeeID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Salesman--", "0"));
            }

            if (TableName == "TBLCOMPANYSETUP")
            {
                if (switch2 == "1")
                {
                    drp.DataSource = getDataTBLCOMPANYSETUP(TID).Where(p => p.SALER == true);
                    drp.DataTextField = "COMPNAME1";
                    drp.DataValueField = "COMPID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Supplier--", "0"));
                }
                else if (switch2 == "2")
                {
                    drp.DataSource = getDataTBLCOMPANYSETUP(TID).Where(p => p.BUYER == true);
                    drp.DataTextField = "COMPNAME1";
                    drp.DataValueField = "COMPID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Customer--", "0"));
                }
                else if (switch1 == "")
                {
                    drp.DataSource = getDataTBLCOMPANYSETUP(TID).OrderBy(p => p.COMPNAME1);
                    drp.DataTextField = "COMPNAME1";
                    drp.DataValueField = "COMPID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Company--", "0"));
                }
                else
                {
                    drp.DataSource = getDataTBLCOMPANYSETUP(TID).Where(p => p.PHYSICALLOCID == switch1).OrderBy(p => p.COMPNAME1);
                    drp.DataTextField = "COMPNAME1";
                    drp.DataValueField = "COMPID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Company--", "0"));
                }

            }
            else if (TableName == "USER_MST")
            {
                //int UROLEID = Convert.ToInt32(switch1);
                drp.DataSource = getDataUSER_MST(TID);
                drp.DataTextField = "FIRST_NAME";
                drp.DataValueField = "USER_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User Name--", "0"));
            }
            else if (TableName == "CRMBaseTable")
            {
                int UROLEID = Convert.ToInt32(switch1);
                drp.DataSource = DB.CRMBaseTables.Where(p => p.TenentID == TID && p.RunningSerial == UROLEID);
                drp.DataTextField = "ActName1";
                drp.DataValueField = "ActivityID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Activity Name--", "0"));
            }
            else if (TableName == "MODULE_MST")
            {
                if (switch1 == "0")
                    drp.DataSource = getDataMODULE_MST(TID).Where(p => p.Parent_Module_id != 0);

                else
                    drp.DataSource = getDataMODULE_MST(TID).Where(p => p.Parent_Module_id != 0);
                drp.DataTextField = "Module_Name";
                drp.DataValueField = "Module_Id";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Module Name--", "0"));
            }
            else if (TableName == "MODULE_MAP")
            {
                drp.DataSource = getDataMODULE_MAP(TID);
                drp.DataTextField = "MySerial";
                drp.DataValueField = "MODULE_MAP_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User Name--", "0"));
            }
            else if (TableName == "PRIVILEGE_MST")
            {
                drp.DataSource = getDataPRIVILEGE_MST(TID);
                drp.DataTextField = "PRIVILEGE_NAME";
                drp.DataValueField = "PRIVILEGE_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select User Name--", "0"));
            }

            else if (TableName == "Tbl_RouteMST")
            {
                drp.DataSource = getDataTbl_RouteMST(TID);
                drp.DataTextField = "Name1";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }

            else if (TableName == "getCRMMainActivities")
            {
                drp.DataSource = getDataTbl_RouteMST(TID);
                drp.DataTextField = "Reference";
                drp.DataValueField = "Reference";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
            else if (TableName == "ICEXTRACOST")
            {
                //int UROLEID = Convert.ToInt32(switch1);
                drp.DataSource = getDataICEXTRACOST(TID).Where(p => p.Active == "Y");
                drp.DataTextField = "OHNAME1";
                drp.DataValueField = "OVERHEADID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select OH Cost--", "0"));
            }
            else if (TableName == "TBLBIN")
            {

                drp.DataSource = getDataTBLBIN(TID);
                drp.DataTextField = "BINDesc1";
                drp.DataValueField = "BIN_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Bacth Name--", "0"));
            }
            else if (TableName == "tbltranssubtype")
            {
                if (switch1 != "")
                {
                    int MID = Convert.ToInt32(switch1);
                    drp.DataSource = getDataEco_tbltranssubtype(TID).Where(p => p.transid == MID);
                }
                else
                {
                    drp.DataSource = getDataEco_tbltranssubtype(TID);

                }
                drp.DataTextField = "transsubtype1";
                drp.DataValueField = "transsubid";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Sub Transaction Type--", "0"));
            }
            else if (TableName == "TBLCONTACT")
            {
                drp.DataSource = getDataTBLCONTACT(TID);
                drp.DataTextField = "PersName1";
                drp.DataValueField = "ContactMyID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }

            else if (TableName == "Banners")
            {
                drp.DataSource = getDataBanner(TID);
                drp.DataTextField = "BannerName";
                drp.DataValueField = "BannerID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            }
            else if (TableName == "TBLPROJECT")
            {
                drp.DataSource = getDataTBLPROJECT(TID);
                drp.DataTextField = "PROJECTNAME1";
                drp.DataValueField = "PROJECTID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Project Name--", "0"));

            }
            else if (TableName == "TBLSYSUSERBATCH")
            {
                drp.DataSource = getDataTBLSYSUSERBATCH(TID);
                drp.DataTextField = "USERCODE";
                drp.DataValueField = "USERBATCHNO";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Batch Name--", "0"));
            }
            else if (TableName == "tbltranstype")
            {
                drp.DataSource = getDatatbltranstype(TID);
                drp.DataTextField = "transtype1";
                drp.DataValueField = "transid";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Main Transaction Type--", "0"));
            }

            else if (TableName == "TBLSYSTEMS")
            {
                drp.DataSource = getDataTBLSYSTEMS(TID);
                drp.DataTextField = "SYSDESC1";
                drp.DataValueField = "MYSYSNAME";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select SYSNAME--", "0"));
            }

            else if (TableName == "ROLE_MST")
            {
                drp.DataSource = getDataROLE_MST(TID);
                drp.DataTextField = "ROLE_NAME";
                drp.DataValueField = "ROLE_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select USER_TYPE--", "0"));
            }

            else if (TableName == "ERP_QUESTION_BANK")
            {
                drp.DataSource = getDataERP_QUESTION_BANK(TID);
                drp.DataTextField = "QUESTION";
                drp.DataValueField = "QUESTION_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select QUESTION--", "0"));
            }

            else if (TableName == "tblCOUNTRY")
            {
                if (TID != null && switch1 != "")
                {
                    if (switch1 == "Prics")
                    {
                        drp.DataSource = getDatatblCOUNTRY(TID).Where(p => p.Active == "Y");
                        drp.DataTextField = "CURRENCYNAME1";
                        drp.DataValueField = "COUNTRYID";
                        drp.DataBind();
                        drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Currency", "0"));
                    }
                    else if (switch1 == "Nationality")
                    {
                        drp.DataSource = getDatatblCOUNTRY(TID);
                        drp.DataTextField = "NATIONALITY1";
                        drp.DataValueField = "COUNTRYID";
                        drp.DataBind();
                        drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Nationality--", "0"));
                    }
                    else
                    {
                        drp.DataSource = getDatatblCOUNTRY(TID);
                        drp.DataTextField = "COUNAME1";
                        drp.DataValueField = "COUNTRYID";
                        drp.DataBind();
                        drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Country--", "0"));
                    }
                }
                else
                {
                    drp.DataSource = getDatatblCOUNTRY(TID);
                    drp.DataTextField = "COUNAME1";
                    drp.DataValueField = "COUNTRYID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Country--", "0"));

                    if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COUNTRYID != null).Count() > 0)
                    {
                        string CCID = DB.MYCOMPANYSETUPs.FirstOrDefault(p => p.TenentID == TID).COUNTRYID.ToString();
                        //drp.SelectedValue = CCID;
                        //drp.SelectedValue = DB.MYCOMPANYSETUPs.Where(p => p.TenentID == TID).Select(p => p.COUNTRYID).FirstOrDefault().ToString();
                    }

                }

            }
            else if (TableName == "FUNCTION_MST")
            {
                if (switch2 != "")
                {
                    int mid = Convert.ToInt32(switch2);
                    drp.DataSource = getDataFUNCTION_MST(TID).Where(p => p.MENU_LOCATION == switch1 && p.MODULE_ID == mid);
                }
                else
                {
                    drp.DataSource = getDataFUNCTION_MST(TID);
                }
                drp.DataTextField = "MENU_NAME1";
                drp.DataValueField = "MENU_ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Master Menu--", "0"));

            }
            else if (TableName == "TBLLOCATION")
            {
                if (switch1 == "")
                {
                    drp.DataSource = getDataTBLLOCATION(TID);
                }
                else
                {
                    LID = Convert.ToInt32(switch1);
                    drp.DataSource = getDataTBLLOCATION(TID).Where(p => p.LOCATIONID == LID);
                }
                drp.DataTextField = "LOCNAME1";
                drp.DataValueField = "LOCATIONID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Location--", "0"));
            }
            else if (TableName == "Tbl_Position_Mst")
            {
                drp.DataSource = getDataPosition_Mst(TID);
                drp.DataTextField = "PositionName";
                drp.DataValueField = "PositionID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
            else if (TableName == "ICTR_HD")
            {
                int TRS = Convert.ToInt32(switch1);
                int locationID = Convert.ToInt32(switch2);
                if (switch2 != "")
                {
                
                    //drp.DataSource = DB.ICTR_HD.Where(p => p.TenentID == TID && p.transid == TRS && p.transsubid == TRSM && p.MYSYSNAME == switch3);
                    var Datas = from item in DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.transid == TRS && p.locationID == locationID && p.MYSYSNAME == switch3 && p.Orderway != "Returned").ToList()
                                select new
                                {
                                    Name = item.InvoiceNO + " - " + ((Int64)item.MYTRANSID).ToString() + " - " + (Convert.ToDateTime(item.ENTRYDATE).ToString("dd/MM/yyyy")) + " - " + item.TransDocNo,
                                    ID = ((Int64)item.MYTRANSID).ToString()
                                };
                    drp.DataSource = Datas;
                }
                else
                {
                    //drp.DataSource = DB.ICTR_HD.Where(p => p.TenentID == TID && p.transid == TRS && p.MYSYSNAME == switch3);
                    var Datas = from item in DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.locationID==locationID && p.transid == TRS && p.MYSYSNAME == switch3 && p.Orderway != "Returned").ToList().OrderBy(p => p.MYTRANSID)
                    select new
                                {
                                    // Name = item.InvoiceNO + " - " + ((Int64)item.MYTRANSID).ToString() + " - " + (Convert.ToDateTime(item.ENTRYDATE).ToString("dd/MM/yyyy")) + " - " + item.TransDocNo,

                                    Name = item.MYTRANSID  + " - " + (Convert.ToDateTime(item.ENTRYDATE).ToString("dd/MM/yyyy")),
                                    ID = ((Int64)item.MYTRANSID).ToString()
                                };
                    drp.DataSource = Datas;
                }

                drp.DataTextField = "Name";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
            else if (TableName == "TBLCOMPANY_LOCATION")
            {
                if (switch1 == "1")
                {
                    drp.DataSource = getDataTBLCOMPANY_LOCATION(TID);
                    drp.DataTextField = "LOCATION_NAME1";
                    drp.DataValueField = "SHORTNAME";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }
                else
                {
                    drp.DataSource = getDataTBLCOMPANY_LOCATION(TID);
                    drp.DataTextField = "LOCATION_NAME1";
                    drp.DataValueField = "LOCATIONID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }

            }

            else if (TableName == "tblLanguage")
            {
                drp.DataSource = getDatatblLanguages(TID);
                drp.DataTextField = "LangName1";
                drp.DataValueField = "MYCONLOCID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }

            else if (TableName == "Mail_Templet")
            {
                drp.DataSource = getDataMail_Templet(TID);
                drp.DataTextField = "Title";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
            else if (TableName == "REFTABLE")
            {
                if (switch3 != "")
                {
                    if (switch3 == "Sales")
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2 && P.SHORTNAME == switch3).OrderBy(p => p.REFNAME1);
                        drp.DataTextField = "REFNAME1";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                    else if (switch3 == "Purchase")//For payment Voucher
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2 && P.SHORTNAME == switch3).OrderBy(p => p.REFNAME1);
                        drp.DataTextField = "REFNAME1";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                    else if (switch3 == "Inventeri")
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2 && P.SHORTNAME == switch3).OrderBy(p => p.REFNAME1);
                        drp.DataTextField = "REFNAME1";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                    else if (switch3 == "ItemImgUploadAllFile")
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2 && P.SWITCH4 != 1).OrderBy(p => p.REFNAME1);
                        drp.DataTextField = "REFNAME1";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                    else if (switch2 == "REFTYPE")
                    {
                        drp.DataSource = getDataREFTABLE(TID).GroupBy(a => a.REFTYPE).Select(grp => grp.FirstOrDefault());
                        drp.DataTextField = "REFTYPE";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                    else if (switch1 == "REFSUBTYPE")
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFSUBTYPE == switch1).GroupBy(a => a.REFSUBTYPE).Select(grp => grp.FirstOrDefault());
                        drp.DataTextField = "REFSUBTYPE";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }

                    else
                    {
                        drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch2 && P.REFSUBTYPE == switch1 && P.SHORTNAME == switch3).OrderBy(p => p.REFNAME1);
                        drp.DataTextField = "REFNAME1";
                        drp.DataValueField = "REFID";
                        drp.DataBind();
                        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                    }
                }
                else if (switch2 == "DOCTYPE")
                {
                    drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2).GroupBy(a => a.REFSUBTYPE).Select(grp => grp.FirstOrDefault());
                    drp.DataTextField = "REFSUBTYPE";
                    drp.DataValueField = "REFID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
                }
                else
                {
                    drp.DataSource = getDataREFTABLE(TID).Where(P => P.REFTYPE == switch1 && P.REFSUBTYPE == switch2);
                    drp.DataTextField = "REFNAME1";
                    drp.DataValueField = "REFID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("-- Select a--", "0"));
                }

            }
            else if (TableName == "CAT_MST")
            {
                drp.DataSource = getDataCAT_MST(TID).Where(p => p.CAT_TYPE == switch1);
                drp.DataTextField = "CAT_NAME1";
                drp.DataValueField = "CATID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Category--", "0"));
            }
            else if (TableName == "tblCONTACTBus")
            {
                drp.DataSource = getDatatblCONTACTBus(TID);
                drp.DataTextField = "JobTitle";
                drp.DataValueField = "ContactMyID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }

            else if (TableName == "tbltranssubtype")
            {
                drp.DataSource = getDataEco_tbltranssubtype(TID);
                drp.DataTextField = "transtype1";
                drp.DataValueField = "transid";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
            else if (TableName == "tblStates")
            {

                if (switch1 != "")
                {
                    int CID = Convert.ToInt32(switch1);
                    drp.DataSource = getDatatblStates(TID).Where(p => p.COUNTRYID == CID).OrderBy(p => p.MYNAME1);
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Not Known--", "0"));
                }
                else
                    drp.DataSource = getDatatblStates(TID).OrderBy(p => p.MYNAME1);
                drp.DataTextField = "MYNAME1";
                drp.DataValueField = "StateID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Not Known--", "0"));
            }
            else if (TableName == "TBLPRODUCT")
            {
                if (TID != null && switch1 != "")
                {
                    UID = Convert.ToInt32(switch1);
                    drp.DataSource = getDataTBLPRODUCT(TID).Where(p => p.COMPANYID == UID);
                }
                else
                    drp.DataSource = getDataTBLPRODUCT(TID);
                drp.DataTextField = "ProdName1";
                drp.DataValueField = "MYPRODID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --", "0"));
            }
            else if (TableName == "TBLPRODUCTWithICIT_BR")
            {
                LID = Convert.ToInt32(switch1);
                var result2 = (from pm in DB.ICIT_BR.Where(a => a.OnHand > 0 && a.TenentID == TID && a.LocationID == LID)
                               join Module in DB.TBLPRODUCTs.Where(c => c.TenentID == TID && c.ACTIVE == "1" && c.LOCATION_ID == LID) on pm.MyProdID equals Module.MYPRODID
                               select new { p1 = Module.MYPRODID, p2 = Module.ProdName1 }).ToList();
                drp.DataSource = result2;
                drp.DataValueField = "p1";
                drp.DataTextField = "p2";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Product--", "0"));
            }
            else if (TableName == "TBLSIZE")
            {
                drp.DataSource = getDataTBLSIZE(TID);
                drp.DataTextField = "SIZETYPE";
                drp.DataValueField = "SIZECODE";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --", "0"));
            }
            else if (TableName == "MYBUS")
            {
                if (switch1 != "")
                {
                    drp.DataSource = getDataMYBUS(TID).Where(p => p.BUSTYPE != switch1);
                }
                drp.DataSource = getDataMYBUS(TID);
                drp.DataTextField = "BUSNAME1";
                drp.DataValueField = "BUSID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Business Product--", "0"));
            }
            else if (TableName == "ICUOM")
            {

                drp.DataSource = getDataICUOM(TID);
                drp.DataTextField = "UOMNAME1";
                drp.DataValueField = "UOM";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Unit of Measure--", "0"));
            }
            else if (TableName == "DEPTOFSale")
            {

                drp.DataSource = getDataDEPTOFSale(TID);
                drp.DataTextField = "DeptDesc1";
                drp.DataValueField = "SalDeptID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select  Department of Sale--", "0"));
            }

            else if (TableName == "TBLCOLOR")
            {

                drp.DataSource = getDataTBLCOLOR(TID).Where(p => p.TenentID == TID);
                drp.DataTextField = "COLORDESC1";
                drp.DataValueField = "COLORID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select  Colors--", "0"));
            }
            else if (TableName == "TBLGROUP")
            {

                drp.DataSource = getDataTBLGROUP(TID);
                drp.DataTextField = "ITGROUPDESC1";
                drp.DataValueField = "ITGROUPID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select  IT Group--", "0"));
            }
            else if (TableName == "Fetaures_List_Mst")
            {
                drp.DataSource = getDataFetaures_List_Mst(TID);
                drp.DataTextField = "FetauresName1";
                drp.DataValueField = "MyID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Feature Type--", "0"));
            }
            else if (TableName == "Tbl_Multi_Color_Size_Mst")
            {
                if (TID != 0 && switch1 != "" && switch2 != "")
                {
                    int RCODID = Convert.ToInt32(switch2);
                    drp.DataSource = getDataTbl_Multi_Color_Size_Mst(TID).Where(p => p.CompniyAndContactID == TID && p.RecordType == switch1 && p.RecTypeID != RCODID);
                }
                else
                {
                    drp.DataSource = getDataTbl_Multi_Color_Size_Mst(TID).Where(p => p.CompniyAndContactID == TID && p.RecordType == switch1);
                }
                drp.DataTextField = "RecValue";
                drp.DataValueField = "RecTypeID";
                drp.DataBind();
                drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select --", "0"));
            }

            else if (TableName == "tbl_SkillEducation")
            {
                if (switch1 == "Hobbie")
                {
                    drp.DataSource = getSkillEducation(TID).Where(p => p.RecType == switch1);
                    drp.DataTextField = "DescName1";
                    drp.DataValueField = "DescID";
                    drp.DataBind();
                    drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Hobbie--", "0"));
                }
                else if (switch2 == "Institute")
                {
                    drp.DataSource = getSkillEducation(TID).Where(p => p.RecType == switch2).GroupBy(p => p.DescType).Select(p => p.FirstOrDefault());
                    drp.DataTextField = "DescName1";
                    drp.DataValueField = "DescID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("--Select Training Institue--", "0"));
                }
                else if (switch3 == "Language")
                {
                    drp.DataSource = getSkillEducation(TID).Where(p => p.RecType == switch3);
                    drp.DataTextField = "DescName1";
                    drp.DataValueField = "DescID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("--Select Language--", "0"));
                }
                else if (switch1 == "Skill")
                {
                    drp.DataSource = getSkillEducation(TID).Where(p => p.RecType == switch1);
                    drp.DataTextField = "DescName1";
                    drp.DataValueField = "DescID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("--Select Skill--", "0"));
                }
                else if (switch2 == "Education")
                {
                    drp.DataSource = getSkillEducation(TID).Where(p => p.RecType == switch2).GroupBy(p => p.DescType).Select(p => p.FirstOrDefault());
                    drp.DataTextField = "DescType";
                    drp.DataValueField = "DescID";
                    drp.DataBind();
                    drp.Items.Insert(0, new ListItem("--Select Education Degree--", "0"));
                }

                //int UROLEID = Convert.ToInt32(switch1);

            }
            //-----------------Jobportal DropDown Bind----------------------


            else if (TableName == "tbl_Applicant_SOJobDomain")
            {
                drp.DataSource = getApplicantDomain(TID).Take(15);
                drp.DataTextField = "DomainName1";
                drp.DataValueField = "DomainId";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("--Select Job Domain--", "0"));
            }
            else if (TableName == "tbl_Applicant_SOJobSubDomain")
            {
                drp.DataSource = getApplicantSubDomain(TID).Take(15);
                drp.DataTextField = "SubDomainName1";
                drp.DataValueField = "SubDomainId";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("--Select Job Sub Domain--", "0"));
            }
            else if (TableName == "tbl_Applicant_SOJobDesc")
            {
                drp.DataSource = getApplicant_SOJobDesc(TID).Take(15);
                drp.DataTextField = "JobName1";
                drp.DataValueField = "JobId";
                drp.DataBind();

            }

            drp = new DropDownList();
            return drp;
        }

        public static void BindDRP<T>(DropDownList drp, int TID, string switch1, string switch2, string switch3, List<T> List)
        {

            drp.DataSource = List;
            drp.DataTextField = switch2;
            drp.DataValueField = switch3;
            drp.DataBind();
            drp.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Company--", "0"));
        }

        public static List<T> Bindtest<T>(string tableName, int TID) where T : class
        {


            var List = new List<T>();
            if (tableName == "TBLPRODUCT")
                List = (List<T>)DB.TBLPRODUCTs.Where(p => p.ACTIVE == "1" && p.TenentID == TID);

            var objChache = DB.Cache_Mst.Single(p => p.TableName == tableName);
            if (objChache.IsCache == false)
            {
                if (System.Web.HttpContext.Current.Cache[tableName] != null)
                    List = ((List<T>)System.Web.HttpContext.Current.Cache[tableName]).ToList();
                else
                {
                    System.Web.HttpContext.Current.Cache[tableName] = List;
                    objChache.IsCache = false;
                    DB.SaveChanges();
                }
            }
            else
            {

                System.Web.HttpContext.Current.Cache[tableName] = List;
                objChache.IsCache = false;
                DB.SaveChanges();
            }
            return List;
        }

        //public static List<T> LinqCache<T>(this Table<T> query) where T : class
        //{
        //    string tableName = query.Context.Mapping.GetTable(typeof(T)).TableName;
        //    List<T> result = HttpContext.Current.Cache[tableName] as List<T>;

        //    if (result == null)
        //    {
        //        using (SqlConnection cn = new SqlConnection(query.Context.Connection.ConnectionString))
        //        {
        //            cn.Open();
        //            SqlCommand cmd = new SqlCommand(query.Context.GetCommand(query).CommandText, cn);
        //            cmd.Notification = null;
        //            cmd.NotificationAutoEnlist = true;
        //            SqlCacheDependencyAdmin.EnableNotifications(query.Context.Connection.ConnectionString);
        //            if (!SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(query.Context.Connection.ConnectionString).Contains(tableName))
        //            {
        //                SqlCacheDependencyAdmin.EnableTableForNotifications(query.Context.Connection.ConnectionString, tableName);
        //            }

        //            SqlCacheDependency dependency = new SqlCacheDependency(cmd);
        //            cmd.ExecuteNonQuery();

        //            result = query.ToList();
        //            HttpContext.Current.Cache.Insert(tableName, result, dependency);
        //        }
        //    }
        //    return result;
        //}

        public static void insertICTR_HD( int TenentID = 0, Int64 MYTRANSID = 0 , int ToTenentID = 0, int TOLOCATIONID = 0, string MainTranType = null, string TranType = null, int transid = 0, int transsubid = 0, string MYSYSNAME = null, decimal? COMPID = null, decimal? CUSTVENDID = null, string LF = null, string PERIOD_CODE = null, string ACTIVITYCODE = null, decimal? MYDOCNO = null, string USERBATCHNO = null, decimal? TOTQTY1 = null, decimal? TOTAMT = null, decimal? AmtPaid = null, string PROJECTNO = null, string CounterID = null, string PrintedCounterInvoiceNo = null, int JOID = 0, DateTime? TRANSDATE = null, string REFERENCE = null, string NOTES = null, int CRUP_ID = 0, string GLPOST = null, string GLPOST1 = null, string GLPOSTREF1 = null, string GLPOSTREF = null, string ICPOST = null, string ICPOSTREF = null, string USERID = null, bool ACTIVE = false, int COMPANYID = 0, DateTime? ENTRYDATE = null, DateTime? ENTRYTIME = null, DateTime? UPDTTIME = null, int InvoiceNO = 0, decimal? Discount = null, string Status = null, int Terms = 0, string DatainserStatest = null, string Custmerid = null, string Swit1 = null, string ExtraField2 = null, int RefTransID = 0, string Reason = null, string TransDocNo = null, int LinkTransID = 0 , int TerminalID =0  )
        {
            DateTime Todate = DateTime.Now;
            Database.ICTR_HD_Sales objICTR_HD = new Database.ICTR_HD_Sales();
            bool flag = false;
            if (DatainserStatest == "Add")
            {
                objICTR_HD = new Database.ICTR_HD_Sales();
                flag = true;
                //objICTR_HD.InvoiceNO = InvoiceNO.ToString();
            }
            else
            {
                objICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID && p.locationID == TOLOCATIONID);
            }
            objICTR_HD.TerminalID = TerminalID;
            objICTR_HD.TenentID = TenentID;
            objICTR_HD.MYTRANSID = MYTRANSID;
            objICTR_HD.ToTenantID = ToTenentID;
            objICTR_HD.locationID = TOLOCATIONID;
            objICTR_HD.MainTranType = MainTranType;
            objICTR_HD.TransType = TranType;
            objICTR_HD.transid = transid;
            objICTR_HD.transsubid = transsubid;
            objICTR_HD.TranType = TranType;
           // objICTR_HD.COMPID = COMPID;
            objICTR_HD.MYSYSNAME = MYSYSNAME;
            objICTR_HD.CUSTVENDID = Convert.ToDecimal(CUSTVENDID);
            objICTR_HD.LF = LF;
            objICTR_HD.PERIOD_CODE = PERIOD_CODE;
            objICTR_HD.ACTIVITYCODE = ACTIVITYCODE;
            objICTR_HD.MYDOCNO = MYDOCNO;
            objICTR_HD.USERBATCHNO = USERBATCHNO;
            objICTR_HD.TOTAMT = TOTAMT;
            objICTR_HD.TOTQTY = TOTQTY1;
            objICTR_HD.AmtPaid = AmtPaid;
            objICTR_HD.PROJECTNO = PROJECTNO;
            objICTR_HD.CounterID = CounterID;
            objICTR_HD.PrintedCounterInvoiceNo = PrintedCounterInvoiceNo;
            objICTR_HD.JOID = JOID;
            objICTR_HD.TRANSDATE = Convert.ToDateTime(TRANSDATE);
            objICTR_HD.REFERENCE = REFERENCE;
            objICTR_HD.NOTES = NOTES;
            objICTR_HD.GLPOST = GLPOST;
            objICTR_HD.GLPOST1 = GLPOST1;
            objICTR_HD.GLPOSTREF = GLPOSTREF;
            objICTR_HD.GLPOSTREF1 = GLPOSTREF1;
            objICTR_HD.ICPOST = ICPOST;
            objICTR_HD.ICPOSTREF = ICPOSTREF;
            objICTR_HD.USERID = USERID;
            objICTR_HD.ACTIVE = true;
            //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            objICTR_HD.COMPANYID = COMPANYID;
            objICTR_HD.ENTRYDATE = ENTRYDATE;
            objICTR_HD.ENTRYTIME = ENTRYTIME;
            objICTR_HD.UPDTTIME = UPDTTIME;
            objICTR_HD.Discount = Discount;
            objICTR_HD.Status = Status;
            objICTR_HD.Terms = Terms;
            objICTR_HD.ExtraField1 = Custmerid;
            objICTR_HD.ExtraField2 = ExtraField2;
            objICTR_HD.ExtraSwitch1 = Swit1;
            objICTR_HD.RefTransID = RefTransID;
            objICTR_HD.ExtraSwitch2 = Reason;
            objICTR_HD.TransDocNo = TransDocNo;
            objICTR_HD.LinkTransID = LinkTransID;
            objICTR_HD.InvoiceNO = InvoiceNO.ToString();
            objICTR_HD.Orderway = "Returned";
            //objICTR_HD.OrderStatus = "Canceled";
            objICTR_HD.DeliveryStatus = "Rejected with Reason";
            if (flag == true)
            {
                DB.ICTR_HD_Sales.AddObject(objICTR_HD);
            }
            DB.SaveChanges();
        }


        public static void insert_ICTR_HD(int TenentID = 0, Int64 MYTRANSID = 0, int ToTenentID = 0, int TOLOCATIONID = 0, string MainTranType = null, string TranType = null, int transid = 0, int transsubid = 0, string MYSYSNAME = null, decimal? COMPID = null, decimal? CUSTVENDID = null, string LF = null, string PERIOD_CODE = null, string ACTIVITYCODE = null, decimal? MYDOCNO = null, string USERBATCHNO = null, decimal? TOTQTY1 = null, decimal? TOTAMT = null, decimal? AmtPaid = null, string PROJECTNO = null, string CounterID = null, string PrintedCounterInvoiceNo = null, int JOID = 0, DateTime? TRANSDATE = null, string REFERENCE = null, string NOTES = null, int CRUP_ID = 0, string GLPOST = null, string GLPOST1 = null, string GLPOSTREF1 = null, string GLPOSTREF = null, string ICPOST = null, string ICPOSTREF = null, string USERID = null, bool ACTIVE = false, int COMPANYID = 0, DateTime? ENTRYDATE = null, DateTime? ENTRYTIME = null, DateTime? UPDTTIME = null, string InvoiceNO = "0", decimal? Discount = null, string Status = null, int Terms = 0, string Custmerid = null, string Swit1 = null, string ExtraField2 = null, int RefTransID = 0, string Reason = null, string TransDocNo = null, int LinkTransID = 0, int invoice_Type = 0, int invoice_Source = 0,int TerminalID = 0)
        {

            DateTime Todate = DateTime.Now;
            Database.ICTR_HD_Sales objICTR_HD = new Database.ICTR_HD_Sales();
            bool flag = false;
            if (DB.ICTR_HD_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == TOLOCATIONID).Count() < 1)
            {
                objICTR_HD = new Database.ICTR_HD_Sales();
                flag = true;
            }
            else
            {
                objICTR_HD = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID && p.locationID == TOLOCATIONID);
            }
            objICTR_HD.TenentID = TenentID;
            objICTR_HD.MYTRANSID = MYTRANSID;
            objICTR_HD.ToTenantID = ToTenentID;
            objICTR_HD.locationID = TOLOCATIONID;
            objICTR_HD.MainTranType = MainTranType;
            objICTR_HD.TransType = TranType;
            objICTR_HD.transid = transid;
            objICTR_HD.transsubid = transsubid;
            objICTR_HD.TranType = TranType;
            objICTR_HD.COMPID = COMPID;
            objICTR_HD.MYSYSNAME = MYSYSNAME;
            objICTR_HD.CUSTVENDID = Convert.ToDecimal(CUSTVENDID);
            objICTR_HD.LF = LF;
            objICTR_HD.PERIOD_CODE = PERIOD_CODE;
            objICTR_HD.ACTIVITYCODE = ACTIVITYCODE;
            objICTR_HD.MYDOCNO = MYDOCNO;
            objICTR_HD.USERBATCHNO = USERBATCHNO;
            objICTR_HD.TOTAMT = TOTAMT;
            objICTR_HD.TOTQTY = TOTQTY1;
            objICTR_HD.AmtPaid = AmtPaid;
            objICTR_HD.PROJECTNO = PROJECTNO;
            objICTR_HD.CounterID = CounterID;
            objICTR_HD.PrintedCounterInvoiceNo = PrintedCounterInvoiceNo;
            objICTR_HD.JOID = JOID;
            objICTR_HD.TRANSDATE = Convert.ToDateTime(TRANSDATE);
            objICTR_HD.REFERENCE = REFERENCE;
            objICTR_HD.NOTES = NOTES;
            objICTR_HD.GLPOST = GLPOST;
            objICTR_HD.GLPOST1 = GLPOST1;
            objICTR_HD.GLPOSTREF = GLPOSTREF;
            objICTR_HD.GLPOSTREF1 = GLPOSTREF1;
            objICTR_HD.ICPOST = ICPOST;
            objICTR_HD.ICPOSTREF = ICPOSTREF;
            objICTR_HD.USERID = USERID;
            objICTR_HD.ACTIVE = true;
            //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            objICTR_HD.COMPANYID = COMPANYID;
            objICTR_HD.ENTRYDATE = ENTRYDATE;
            objICTR_HD.ENTRYTIME = ENTRYTIME;
            objICTR_HD.UPDTTIME = UPDTTIME;
            objICTR_HD.Discount = Discount;
            objICTR_HD.Status = Status;
            objICTR_HD.Terms = Terms;
            objICTR_HD.ExtraField1 = Custmerid;
            objICTR_HD.ExtraField2 = ExtraField2;
            objICTR_HD.ExtraSwitch1 = Swit1;
            objICTR_HD.RefTransID = RefTransID;
            objICTR_HD.ExtraSwitch2 = Reason;
            objICTR_HD.TransDocNo = TransDocNo;
            objICTR_HD.LinkTransID = LinkTransID;
            objICTR_HD.InvoiceNO = InvoiceNO.ToString();
            objICTR_HD.invoice_Source = invoice_Source;
            objICTR_HD.invoice_Type = invoice_Type;
            objICTR_HD.TerminalID = TerminalID;

            // objICTR_HD.ExtraSwitch2 = "";
            if (flag == true)
            {
                DB.ICTR_HD_Sales.AddObject(objICTR_HD);
            }
            DB.SaveChanges();
        }

        public static void insertICTR_DT(int TenentID, int MYTRANSID, int locationID, int MyProdID, string REFTYPE, string REFSUBTYPE, string PERIOD_CODE, string MYSYSNAME, int JOID, int JOBORDERDTMYID, int ACTIVITYID, string DESCRIPTION, string UOM, decimal QUANTITY, decimal UNITPRICE, decimal AMOUNT, decimal OVERHEADAMOUNT, string BATCHNO, int BIN_ID, string BIN_TYPE, string GRNREF, decimal DISPER, decimal DISAMT, decimal TAXPER, decimal TAXAMT, decimal PROMOTIONAMT, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, DateTime EXPIRYDATE, bool ACTIVE, string SWITCH1, int COMPANYID1, int DelFlag, string ITEMID, DateTime? StartDate = null, DateTime? EndDate = null, string Status = null)
        {
            Database.ICTR_DT_Sales objICTR_DT = new Database.ICTR_DT_Sales();


            objICTR_DT.TenentID = TenentID;
            objICTR_DT.MYTRANSID = MYTRANSID;
            objICTR_DT.locationID = locationID;
            var ListICTR_DT = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID && p.locationID == locationID);
            int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
            objICTR_DT.MYID = MYIDDT;
            objICTR_DT.MyProdID = MyProdID;
            objICTR_DT.REFTYPE = REFTYPE;
            objICTR_DT.REFSUBTYPE = REFSUBTYPE;
            objICTR_DT.PERIOD_CODE = PERIOD_CODE;
            objICTR_DT.MYSYSNAME = MYSYSNAME;
            objICTR_DT.JOID = JOID;
            objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
            objICTR_DT.ACTIVITYID = ACTIVITYID;
            objICTR_DT.DESCRIPTION = DESCRIPTION;
            objICTR_DT.UOM = UOM;
            objICTR_DT.QUANTITY = QUANTITY;
            objICTR_DT.UNITPRICE = UNITPRICE;
            objICTR_DT.AMOUNT = AMOUNT;
            objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
            objICTR_DT.BATCHNO = BATCHNO;
            objICTR_DT.BIN_ID = BIN_ID;
            objICTR_DT.BIN_TYPE = BIN_TYPE;
            objICTR_DT.GRNREF = GRNREF;
            objICTR_DT.DISPER = DISPER;
            objICTR_DT.DISAMT = DISAMT;
            objICTR_DT.TAXAMT = TAXAMT;
            objICTR_DT.TAXPER = TAXPER;
            objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
            objICTR_DT.GLPOST = GLPOST;
            objICTR_DT.GLPOST1 = GLPOST1;
            objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
            objICTR_DT.GLPOSTREF = GLPOSTREF;
            objICTR_DT.ICPOST = ICPOST;
            objICTR_DT.ICPOSTREF = ICPOSTREF;
            objICTR_DT.EXPIRYDATE = EXPIRYDATE;
            objICTR_DT.COMPANYID = COMPANYID1;
            objICTR_DT.SWITCH1 = SWITCH1;
            objICTR_DT.ACTIVE = ACTIVE;
            objICTR_DT.DelFlag = DelFlag;
            objICTR_DT.PlanStartDate = StartDate;
            objICTR_DT.PlanEndDate = EndDate;
            objICTR_DT.Stutas = Status;

            DB.ICTR_DT_Sales.AddObject(objICTR_DT);
            DB.SaveChanges();
        }

        public static void insert_ICTR_DT(int TenentID, Int64 MYTRANSID, int locationID, int MYID, int MyProdID, string REFTYPE, string REFSUBTYPE, string PERIOD_CODE, string MYSYSNAME, int JOID, int JOBORDERDTMYID, int ACTIVITYID, string DESCRIPTION, string UOM, decimal QUANTITY, decimal UNITPRICE, decimal AMOUNT, decimal OVERHEADAMOUNT, string BATCHNO, int BIN_ID, string BIN_TYPE, string GRNREF, decimal DISPER, decimal DISAMT, decimal TAXPER, decimal TAXAMT, decimal PROMOTIONAMT, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, DateTime EXPIRYDATE, bool ACTIVE, string SWITCH1, int COMPANYID1, int DelFlag, string ITEMID, string Status = null)
        {

            if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID).Count() > 0)
            {
                Database.ICTR_DT_Sales objICTR_DT = DB.ICTR_DT_Sales.Single(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID);

                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.SaveChanges();
            }
            else
            {
                Database.ICTR_DT_Sales objICTR_DT = new Database.ICTR_DT_Sales();

                objICTR_DT.TenentID = TenentID;
                objICTR_DT.MYTRANSID = MYTRANSID;
                objICTR_DT.locationID = locationID;
                var ListICTR_DT = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
                int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
                objICTR_DT.MYID = MYIDDT;
                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.ICTR_DT_Sales.AddObject(objICTR_DT);
                DB.SaveChanges();
            }


        }
        public static void insert_ICTR_DT_Sales(int TenentID, int MYTRANSID, int locationID, int MYID, int MyProdID, string REFTYPE, string REFSUBTYPE, string PERIOD_CODE, string MYSYSNAME, int JOID, int JOBORDERDTMYID, int ACTIVITYID, string DESCRIPTION, string UOM, decimal QUANTITY, decimal UNITPRICE, decimal AMOUNT, decimal OVERHEADAMOUNT, string BATCHNO, int BIN_ID, string BIN_TYPE, string GRNREF, decimal DISPER, decimal DISAMT, decimal TAXPER, decimal TAXAMT, decimal PROMOTIONAMT, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, DateTime EXPIRYDATE, bool ACTIVE, string SWITCH1, int COMPANYID1, int DelFlag, string ITEMID, string Status = null)
        {

            if (DB.ICTR_DT_Sales.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID).Count() > 0)
            {
                Database.ICTR_DT_Sales objICTR_DT = DB.ICTR_DT_Sales.Single(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID);

                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.SaveChanges();
            }
            else
            {
                Database.ICTR_DT_Sales objICTR_DT = new Database.ICTR_DT_Sales();

                objICTR_DT.TenentID = TenentID;
                objICTR_DT.MYTRANSID = MYTRANSID;
                objICTR_DT.locationID = locationID;
                var ListICTR_DT = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
                int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
                objICTR_DT.MYID = MYIDDT;
                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.ICTR_DT_Sales.AddObject(objICTR_DT);
                DB.SaveChanges();
            }


        }

        public static void insert_ICTR_DT_Sales_tmp(int TenentID, int MYTRANSID, int locationID, int MYID, int MyProdID, string REFTYPE, string REFSUBTYPE, string PERIOD_CODE, string MYSYSNAME, int JOID, int JOBORDERDTMYID, int ACTIVITYID, string DESCRIPTION, string UOM, decimal QUANTITY, decimal UNITPRICE, decimal AMOUNT, decimal OVERHEADAMOUNT, string BATCHNO, int BIN_ID, string BIN_TYPE, string GRNREF, decimal DISPER, decimal DISAMT, decimal TAXPER, decimal TAXAMT, decimal PROMOTIONAMT, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, bool ACTIVE, string SWITCH1, int COMPANYID1, int DelFlag, string ITEMID, string Status = null)
        {

            //List<Database.ICTR_HD_Sales_tmp> Tlistw = DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID).ToList();
            //List<Database.ICTR_DT_Sales_tmp> listhd = DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID).ToList();
            //if (Tlistw.Count() > 0)
            //{
            //    foreach (Database.ICTR_DT_Sales_tmp item in listhd)
            //    {
            //        DB.ICTR_DT_Sales_tmp.DeleteObject(item);
            //        DB.SaveChanges();
            //    }
            //}
            if (DB.ICTR_DT_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID).Count() > 0)
            {
                Database.ICTR_DT_Sales_tmp objICTR_DT = DB.ICTR_DT_Sales_tmp.Single(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.locationID == locationID && p.MYID == MYID);

                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = DateTime.Now;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.SaveChanges();
            }
            else
            {
                Database.ICTR_DT_Sales_tmp objICTR_DT = new Database.ICTR_DT_Sales_tmp();

                objICTR_DT.TenentID = TenentID;
                objICTR_DT.MYTRANSID = MYTRANSID;
                objICTR_DT.locationID = locationID;
                var ListICTR_DT = DB.ICTR_DT_Sales_tmp.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
                int MYIDDT = ListICTR_DT.Count() > 0 ? Convert.ToInt32(ListICTR_DT.Max(p => p.MYID) + 1) : 1;
                objICTR_DT.MYID = MYIDDT;
                objICTR_DT.TerminalID =1;
                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = DateTime.Now;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;
                objICTR_DT.Stutas = Status;
                DB.ICTR_DT_Sales_tmp.AddObject(objICTR_DT);
                DB.SaveChanges();
            }


        }

        public static void insert_ICTR_HD_Sales_tmp(int TenentID = 0, int MYTRANSID = 0, int ToTenentID = 0, int TOLOCATIONID = 0, string MainTranType = null, string TranType = null, int transid = 0, int transsubid = 0, string MYSYSNAME = null, decimal? COMPID = null, decimal? CUSTVENDID = null, string LF = null, string PERIOD_CODE = null, string ACTIVITYCODE = null, decimal? MYDOCNO = null, string USERBATCHNO = null, decimal? TOTQTY1 = null, decimal? TOTAMT = null, decimal? AmtPaid = null, string PROJECTNO = null, string CounterID = null, string PrintedCounterInvoiceNo = null, int JOID = 0, DateTime? TRANSDATE = null, string REFERENCE = null, string NOTES = null, int CRUP_ID = 0, string GLPOST = null, string GLPOST1 = null, string GLPOSTREF1 = null, string GLPOSTREF = null, string ICPOST = null, string ICPOSTREF = null, string USERID = null, bool ACTIVE = false, int COMPANYID = 0, DateTime? ENTRYDATE = null, DateTime? ENTRYTIME = null, DateTime? UPDTTIME = null, string InvoiceNO = "0", decimal? Discount = null, string Status = null, int Terms = 0, string Custmerid = null, string Swit1 = null, string ExtraField2 = null, int RefTransID = 0, string Reason = null, string TransDocNo = null, int LinkTransID = 0, int invoice_Type = 0, int invoice_Source = 0)
        {

            DateTime Todate = DateTime.Now;
            Database.ICTR_HD_Sales_tmp objICTR_HD = new Database.ICTR_HD_Sales_tmp();
            bool flag = false;
            if (DB.ICTR_HD_Sales_tmp.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID).Count() < 1)
            {
                objICTR_HD = new Database.ICTR_HD_Sales_tmp();
                flag = true;
            }
            else
            {
                objICTR_HD = DB.ICTR_HD_Sales_tmp.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
            }
            objICTR_HD.TenentID = TenentID;
            objICTR_HD.MYTRANSID = MYTRANSID;
            objICTR_HD.ToTenantID = ToTenentID;
            objICTR_HD.locationID = TOLOCATIONID;
            objICTR_HD.MainTranType = MainTranType;
            objICTR_HD.TransType = TranType;
            objICTR_HD.transid = transid;
            objICTR_HD.transsubid = transsubid;
            objICTR_HD.TranType = TranType;
            objICTR_HD.COMPID = COMPID;
            objICTR_HD.MYSYSNAME = MYSYSNAME;
            objICTR_HD.CUSTVENDID = Convert.ToDecimal(CUSTVENDID);
            objICTR_HD.LF = LF;
            objICTR_HD.PERIOD_CODE = PERIOD_CODE;
            objICTR_HD.ACTIVITYCODE = ACTIVITYCODE;
            objICTR_HD.MYDOCNO = MYDOCNO;
            objICTR_HD.USERBATCHNO = USERBATCHNO;
            objICTR_HD.TOTAMT = TOTAMT;
            objICTR_HD.TOTQTY = TOTQTY1;
            objICTR_HD.AmtPaid = AmtPaid;
            objICTR_HD.PROJECTNO = PROJECTNO;
            objICTR_HD.CounterID = CounterID;
            objICTR_HD.PrintedCounterInvoiceNo = PrintedCounterInvoiceNo;
            objICTR_HD.JOID = JOID;
            objICTR_HD.TRANSDATE = Convert.ToDateTime(TRANSDATE);
            objICTR_HD.REFERENCE = REFERENCE;
            objICTR_HD.NOTES = NOTES;
            objICTR_HD.GLPOST = GLPOST;
            objICTR_HD.GLPOST1 = GLPOST1;
            objICTR_HD.GLPOSTREF = GLPOSTREF;
            objICTR_HD.GLPOSTREF1 = GLPOSTREF1;
            objICTR_HD.ICPOST = ICPOST;
            objICTR_HD.ICPOSTREF = ICPOSTREF;
            objICTR_HD.USERID = USERID;
            objICTR_HD.ACTIVE = true;
            //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            objICTR_HD.COMPANYID = COMPANYID;
            objICTR_HD.ENTRYDATE = ENTRYDATE;
            objICTR_HD.ENTRYTIME = ENTRYTIME;
            objICTR_HD.UPDTTIME = UPDTTIME;
            objICTR_HD.Discount = Discount;
            objICTR_HD.Status = "Draft";
            objICTR_HD.OrderStatus = "Draft";
            objICTR_HD.PaymentStatus = "Partial";
            objICTR_HD.DeliveryStatus = "Under the Process";
            objICTR_HD.Terms = Terms;
            objICTR_HD.ExtraField1 = Custmerid;
            objICTR_HD.ExtraField2 = ExtraField2;
            objICTR_HD.ExtraSwitch1 = Swit1;
            objICTR_HD.RefTransID = RefTransID;
            objICTR_HD.ExtraSwitch2 = Reason;
            objICTR_HD.TransDocNo = TransDocNo;
            objICTR_HD.LinkTransID = LinkTransID;
            objICTR_HD.InvoiceNO = InvoiceNO.ToString();
            objICTR_HD.invoice_Source = invoice_Source;
            objICTR_HD.invoice_Type = invoice_Type;

            // objICTR_HD.ExtraSwitch2 = "";
            if (flag == true)
            {
                DB.ICTR_HD_Sales_tmp.AddObject(objICTR_HD);
            }
            DB.SaveChanges();
        }

        public static void insertICTR_DTEXT(int TenentID = 0, Int64 MYTRANSID = 0, int MyID = 0, int MyRunningSerial = 0, string CURRENCY = null, decimal? CURRENTCONVRATE = null, decimal? OTHERCURAMOUNT = null, decimal QUANTITY = 0, decimal? UNITPRICE = null, decimal? AMOUNT = null, decimal QUANTITYDELIVERD = 0, int DELIVERDLOCATenentID = 0, decimal? AMOUNTDELIVERD = null, string ACCOUNTID = null, string GRNREF = null, DateTime? EXPIRYDATE = null, int CRUP_ID = 0, string Remark = null, int TransNo1 = 0, bool ACTIVE = false)
        {

            ICTR_DTEXT objICTR_DTEXT = new ICTR_DTEXT();
            objICTR_DTEXT.TenentID = TenentID;
            objICTR_DTEXT.MYTRANSID = MYTRANSID;
            objICTR_DTEXT.MyID = MyID;
            objICTR_DTEXT.MyRunningSerial = MyRunningSerial;
            objICTR_DTEXT.CURRENTCONVRATE = CURRENTCONVRATE;
            objICTR_DTEXT.CURRENCY = CURRENCY;
            objICTR_DTEXT.OTHERCURAMOUNT = OTHERCURAMOUNT;

            objICTR_DTEXT.QUANTITY = QUANTITY;
            objICTR_DTEXT.UNITPRICE = UNITPRICE;
            objICTR_DTEXT.AMOUNT = AMOUNT;
            objICTR_DTEXT.QUANTITYDELIVERD = QUANTITYDELIVERD;
            // objICTR_DTEXT.DELIVERDLOCATenentID = 0;
            objICTR_DTEXT.ACCOUNTID = ACCOUNTID;
            objICTR_DTEXT.GRNREF = GRNREF;
            objICTR_DTEXT.EXPIRYDATE = EXPIRYDATE;
            objICTR_DTEXT.Remark = Remark;
            objICTR_DTEXT.TransNo = TransNo1;
            objICTR_DTEXT.ACTIVE = ACTIVE;
            DB.ICTR_DTEXT.AddObject(objICTR_DTEXT);
            DB.SaveChanges();

        }

        public static void insertICOVERHEADCOST(int TenentID = 0, int MYTRANSID = 0, int MYID = 0, int OVERHEADCOSTID = 0, decimal OLDCOST = 0, decimal NEWCOST = 0, int TOTQTY = 0, decimal TOTCOST = 0, decimal OTHERCOST = 0, decimal UNITCOST = 0, int CRUP_ID = 0, decimal COMPANY_SEQUENCE = 0, int ICT_COMPANYID = 0, int COMPANYID = 0, string Note = "")
        {

            ICOVERHEADCOST objICOVERHEADCOST = new ICOVERHEADCOST();
            objICOVERHEADCOST.TenentID = TenentID;
            objICOVERHEADCOST.MYTRANSID = MYTRANSID;
            objICOVERHEADCOST.MYID = MYID;
            objICOVERHEADCOST.OVERHEADCOSTID = OVERHEADCOSTID;
            objICOVERHEADCOST.TOTCOST = TOTCOST;
            objICOVERHEADCOST.OLDCOST = OLDCOST;
            objICOVERHEADCOST.NEWCOST = NEWCOST;
            objICOVERHEADCOST.TOTQTY = TOTQTY;
            objICOVERHEADCOST.UNITCOST = UNITCOST;
            objICOVERHEADCOST.OTHERCOST = OTHERCOST;
            objICOVERHEADCOST.COMPANY_SEQUENCE = 0;
            objICOVERHEADCOST.ICT_COMPANYID = ICT_COMPANYID;
            objICOVERHEADCOST.COMPANYID = COMPANYID;
            objICOVERHEADCOST.Note = Note;
            DB.ICOVERHEADCOSTs.AddObject(objICOVERHEADCOST);
            DB.SaveChanges();

        }

        public static void insertICIT_BR(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int Location, decimal UnitCost, int MYTRANSID, string Bin_Per, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
        {

            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;
            ICIT_BR objICIT_BR = new ICIT_BR();
            if (Fuctions == "ADD")
            {
                if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.LocationID == Location && p.UOM == UOM).Count() > 0)
                {
                    objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID &&  p.LocationID == Location && p.UOM == UOM);
                    OPQTY = Convert.ToDecimal(objICIT_BR.OpQty);
                    ONHANDQTY = Convert.ToDecimal(objICIT_BR.OnHand);
                    QtyOut = Convert.ToDecimal(objICIT_BR.QtyOut);
                    QtyConsumed = Convert.ToDecimal(objICIT_BR.QtyConsumed);
                    QtyReserved = Convert.ToDecimal(objICIT_BR.QtyReserved);
                    QtyReceived = Convert.ToDecimal(objICIT_BR.QtyReceived);
                    if (PageName == "Sales")
                    {
                        QtyOut = QtyOut + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else if (PageName == "Purchase")
                    {
                        QtyReceived = QtyReceived + NewQty;
                        ONHANDTOTAL = ONHANDQTY + NewQty;// (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else
                    {
                        if (PageName == "+")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            QtyOut = QtyOut + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                    }
                }
                else
                {
                    objICIT_BR = new ICIT_BR();
                    objICIT_BR.MySysName = "SAL";
                    objICIT_BR.UnitCost = UnitCost;
                    ONHANDTOTAL = NewQty;
                    QtyReceived = NewQty;
                    RoleFlag = true;
                }
            }
            objICIT_BR.TenentID = TenentID;
            objICIT_BR.MyProdID = MyProdID;
            objICIT_BR.period_code = period_code;
            objICIT_BR.UOM = UOM;
            objICIT_BR.LocationID = Location;
            objICIT_BR.MYTRANSID = MYTRANSID;
            objICIT_BR.Bin_Per = Bin_Per;
            objICIT_BR.OpQty = OPQTY;
            objICIT_BR.OnHand = ONHANDTOTAL;
            objICIT_BR.QtyOut = QtyOut;
            objICIT_BR.QtyConsumed = QtyConsumed;
            objICIT_BR.QtyReserved = QtyReserved;
            objICIT_BR.QtyReceived = QtyReceived;
            objICIT_BR.Reference = Reference;
            objICIT_BR.Active = Active;
            objICIT_BR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.ICIT_BR.AddObject(objICIT_BR);
            }
            DB.SaveChanges();

        }

        public static void insertICIT_BR_SIZECOLOR(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int Location, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
        {

            ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;
            int OPQTY = 0;
            int ONHANDQTY = 0;
            int QtyOut = 0;
            int QtyConsumed = 0;
            int QtyReserved = 0;
            int QtyReceived = 0;
            int ONHANDTOTAL = 0;
            int Qtyofoled = 0;
            int Qtyofnew = 0;

            if (Fuctions == "ADD")
            {
                if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
                {
                    objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                    OPQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                    ONHANDQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OnHand);
                    QtyOut = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyOut);
                    QtyConsumed = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyConsumed);
                    QtyReserved = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReserved);
                    QtyReceived = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReceived);
                    if (PageName == "Sales")
                    {
                        QtyOut = QtyOut + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else if (PageName == "Parchesh")
                    {
                        QtyReceived = QtyReceived + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else
                    {
                        if (PageName == "+")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            QtyOut = QtyOut - NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                    }
                }
                else
                {
                    objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                    objICIT_BR_SIZECOLOR.MySysName = "IC";
                    ONHANDTOTAL = NewQty;
                    QtyReceived = NewQty;
                    RoleFlag = true;
                }
            }
            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();




            //if (Fuctions == "ADD")
            //{
            //    if (PageName == "Sales")
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled - Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else if (PageName == "Parchesh")
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled + Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            if (PageName == "+")
            //                OpQty = Qtyofoled + Qtyofnew;
            //            else
            //                OpQty = Qtyofoled - Qtyofnew;
            //        }
            //    }
            //}



        }

        public static void insertICIT_BR_SIZE(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int Location, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
        {

            ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;

            int OPQTY = 0;
            int ONHANDQTY = 0;
            int QtyOut = 0;
            int QtyConsumed = 0;
            int QtyReserved = 0;
            int QtyReceived = 0;
            int ONHANDTOTAL = 0;

            if (Fuctions == "ADD")
            {
                if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
                {
                    objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                    OPQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                    ONHANDQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OnHand);
                    QtyOut = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyOut);
                    QtyConsumed = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyConsumed);
                    QtyReserved = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReserved);
                    QtyReceived = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReceived);
                    if (PageName == "Sales")
                    {
                        QtyOut = QtyOut + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else if (PageName == "Parchesh")
                    {
                        QtyReceived = QtyReceived + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else
                    {
                        if (PageName == "+")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            QtyOut = QtyOut - NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                    }
                }
                else
                {
                    objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                    objICIT_BR_SIZECOLOR.MySysName = "IC";
                    ONHANDTOTAL = NewQty;
                    QtyReceived = NewQty;
                    RoleFlag = true;
                }
            }

            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();







            //int Qtyofoled = 0;
            //int Qtyofnew = 0;
            //if (Fuctions == "ADD")
            //{
            //    if (PageName == "Sales")
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled - Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else if (PageName == "Parchesh")
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled + Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
            //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else
            //    {
            //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
            //        {
            //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
            //            Qtyofnew = OpQty;
            //            if (PageName == "+")
            //                OpQty = Qtyofoled + Qtyofnew;
            //            else
            //                OpQty = Qtyofoled - Qtyofnew;
            //        }
            //    }
            //}



        }

        public static void insertICIT_BR_Serialize(int TenentID, int MyProdID, string period_code, string MySysName, string UOM, string Serial_Number, int Location, int MyTransID, string Flag_GRN_GTN, string Active, int CRUP_ID, string pagename)
        {

            bool RoleFlag = false;
            ICIT_BR_Serialize objICIT_BR_Serialize = new ICIT_BR_Serialize();
            if (pagename == "Sales")
            {
                if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                {
                    objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                }
                else
                {
                    objICIT_BR_Serialize = new ICIT_BR_Serialize();
                    objICIT_BR_Serialize.MySysName = MySysName;
                    RoleFlag = true;
                }
            }
            else if (pagename == "Parchesh")
            {
                if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                {
                    objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                }
                else
                {
                    objICIT_BR_Serialize = new ICIT_BR_Serialize();
                    objICIT_BR_Serialize.MySysName = MySysName;
                    RoleFlag = true;
                }
            }
            else
            {
                if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                {
                    objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                }
                else
                {
                    objICIT_BR_Serialize = new ICIT_BR_Serialize();
                    objICIT_BR_Serialize.MySysName = MySysName;

                    RoleFlag = true;
                }
            }
            objICIT_BR_Serialize.TenentID = TenentID;
            objICIT_BR_Serialize.MyProdID = MyProdID;
            objICIT_BR_Serialize.period_code = period_code;

            objICIT_BR_Serialize.UOM = UOM;
            objICIT_BR_Serialize.Serial_Number = Serial_Number;
            objICIT_BR_Serialize.LocationID = Location;
            objICIT_BR_Serialize.Flag_GRN_GTN = Flag_GRN_GTN;
            objICIT_BR_Serialize.MyTransID = MyTransID;


            objICIT_BR_Serialize.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                objICIT_BR_Serialize.Active = "Y";
                DB.ICIT_BR_Serialize.AddObject(objICIT_BR_Serialize);
            }
            else
                objICIT_BR_Serialize.Active = "N";
            DB.SaveChanges();

        }

        public static void insertICIT_BR_Perishable(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, string BatchNo, int Location, int MYTRANSID, int NewQty, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
        {

            bool RoleFlag = false;

            int OPQTY = 0;
            int ONHANDQTY = 0;
            int QtyOut = 0;
            int QtyReceived = 0;
            int ONHANDTOTAL = 0;

            ICIT_BR_Perishable objICIT_BR_Perishable = new ICIT_BR_Perishable();
            if (Fuctions == "ADD")
            {
                if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
                {
                    objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                    OPQTY = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
                    ONHANDQTY = Convert.ToInt32(objICIT_BR_Perishable.OnHand);
                    QtyOut = Convert.ToInt32(objICIT_BR_Perishable.QtyOut);

                    QtyReceived = Convert.ToInt32(objICIT_BR_Perishable.QtyReceived);
                    if (PageName == "Sales")
                    {
                        QtyOut = QtyOut + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                    }
                    else if (PageName == "Parchesh")
                    {
                        QtyReceived = QtyReceived + NewQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                    }
                    else
                    {
                        if (PageName == "+")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                        }
                        else
                        {
                            QtyOut = QtyOut - NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                        }
                    }
                }
                else
                {
                    objICIT_BR_Perishable = new ICIT_BR_Perishable();
                    objICIT_BR_Perishable.MySysName = MySysName;
                    ONHANDTOTAL = NewQty;
                    QtyReceived = NewQty;
                    RoleFlag = true;
                }
            }
            objICIT_BR_Perishable.TenentID = TenentID;
            objICIT_BR_Perishable.MyProdID = MyProdID;
            objICIT_BR_Perishable.period_code = period_code;
            objICIT_BR_Perishable.UOM = UOM;
            objICIT_BR_Perishable.BatchNo = BatchNo;
            objICIT_BR_Perishable.LocationID = Location;
            objICIT_BR_Perishable.MYTRANSID = MYTRANSID;
            objICIT_BR_Perishable.OpQty = OPQTY;
            objICIT_BR_Perishable.OnHand = ONHANDTOTAL;
            objICIT_BR_Perishable.QtyOut = QtyOut;
            objICIT_BR_Perishable.QtyReceived = QtyReceived;
            objICIT_BR_Perishable.ProdDate = ProdDate;
            objICIT_BR_Perishable.ExpiryDate = ExpiryDate;
            objICIT_BR_Perishable.LeadDays2Destroy = LeadDays2Destroy;
            objICIT_BR_Perishable.Reference = Reference;
            objICIT_BR_Perishable.Active = Active;
            objICIT_BR_Perishable.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_Perishable.AddObject(objICIT_BR_Perishable);
            DB.SaveChanges();






            //int Qtyofoled = 0;
            //int Qtyofnew = 0;

            //if (Fuctions == "ADD")
            //{
            //    if (PageName == "Sales")
            //    {
            //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
            //        {
            //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled - Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_Perishable = new ICIT_BR_Perishable();
            //            objICIT_BR_Perishable.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else if (PageName == "Parchesh")
            //    {
            //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
            //        {
            //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
            //            Qtyofnew = OpQty;
            //            OpQty = Qtyofoled + Qtyofnew;
            //        }
            //        else
            //        {
            //            objICIT_BR_Perishable = new ICIT_BR_Perishable();
            //            objICIT_BR_Perishable.MySysName = MySysName;
            //            RoleFlag = true;
            //        }
            //    }
            //    else
            //    {
            //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
            //        {
            //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
            //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
            //            Qtyofnew = OpQty;
            //            if (PageName == "+")
            //                OpQty = Qtyofoled + Qtyofnew;
            //            else
            //                OpQty = Qtyofoled - Qtyofnew;
            //        }
            //    }
            //}


        }

        public static void insertICIT_BR_BIN(int TenentID, int MyProdID, string period_code, string MySysName, int Bin_ID, int UOM, int Location, string BatchNo, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string pagename, string Fuctions)
        {

            bool RoleFlag = false;
            int OPQTY = 0;
            int ONHANDQTY = 0;
            int QtyOut = 0;
            int QtyConsumed = 0;
            int QtyReserved = 0;
            int QtyReceived = 0;
            int ONHANDTOTAL = 0;
            int QTYOUTNEW = 0;
            int QTYINNEW = 0;
            ICIT_BR_BIN objICIT_BR_BIN = new ICIT_BR_BIN();
            if (Fuctions == "ADD")
            {
                if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
                {
                    objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                    OPQTY = Convert.ToInt32(objICIT_BR_BIN.OpQty);
                    ONHANDQTY = Convert.ToInt32(objICIT_BR_BIN.OnHand);
                    QtyOut = Convert.ToInt32(objICIT_BR_BIN.QtyOut);
                    QtyConsumed = Convert.ToInt32(objICIT_BR_BIN.QtyConsumed);
                    QtyReserved = Convert.ToInt32(objICIT_BR_BIN.QtyReserved);
                    QtyReceived = Convert.ToInt32(objICIT_BR_BIN.QtyReceived);
                    if (pagename == "Sales")
                    {
                        QtyOut = QtyOut + NewQty;
                        QTYOUTNEW = OPQTY + QtyReceived;
                        QTYINNEW = QtyOut + QtyConsumed;
                        ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                    }
                    else if (pagename == "Parchesh")
                    {
                        QtyReceived = QtyReceived + NewQty;
                        QTYOUTNEW = OPQTY + QtyReceived;
                        QTYINNEW = QtyOut + QtyConsumed;
                        ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                    }
                    else
                    {
                        if (pagename == "+")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            QTYOUTNEW = OPQTY + QtyReceived;
                            QTYINNEW = QtyOut + QtyConsumed;
                            ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                        }
                        else
                        {
                            QtyOut = QtyOut - NewQty;
                            QTYOUTNEW = OPQTY + QtyReceived;
                            QTYINNEW = QtyOut + QtyConsumed;
                            ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                        }
                    }
                }
                else
                {
                    objICIT_BR_BIN = new ICIT_BR_BIN();
                    objICIT_BR_BIN.MySysName = MySysName;
                    ONHANDTOTAL = NewQty;
                    QtyReceived = NewQty;
                    RoleFlag = true;
                }
            }
            objICIT_BR_BIN.TenentID = TenentID;
            objICIT_BR_BIN.MyProdID = MyProdID;
            objICIT_BR_BIN.period_code = period_code;
            objICIT_BR_BIN.Bin_ID = Bin_ID;
            objICIT_BR_BIN.UOM = UOM;
            objICIT_BR_BIN.LocationID = Location;
            objICIT_BR_BIN.MYTRANSID = MYTRANSID;
            objICIT_BR_BIN.OpQty = OPQTY;
            objICIT_BR_BIN.OnHand = ONHANDTOTAL;
            objICIT_BR_BIN.QtyOut = QtyOut;
            objICIT_BR_BIN.QtyConsumed = QtyConsumed;
            objICIT_BR_BIN.QtyReserved = QtyReserved;
            objICIT_BR_BIN.QtyReceived = QtyReceived;
            objICIT_BR_BIN.MinQty = 0;
            objICIT_BR_BIN.MaxQty = 0;
            objICIT_BR_BIN.LeadTime = 0;
            objICIT_BR_BIN.Reference = Reference;
            objICIT_BR_BIN.Active = Active;
            objICIT_BR_BIN.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_BIN.AddObject(objICIT_BR_BIN);
            DB.SaveChanges();





            //int Qtyofoled = 0;
            //int Qtyofnew = 0;

            //if (pagename == "Sales")
            //{
            //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
            //    {
            //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);

            //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
            //        Qtyofnew = OpQty;
            //        OpQty = Qtyofoled - Qtyofnew;

            //    }
            //    else
            //    {
            //        objICIT_BR_BIN = new ICIT_BR_BIN();
            //        objICIT_BR_BIN.MySysName = MySysName;
            //        RoleFlag = true;
            //    }
            //}
            //else if (pagename == "Parchesh")
            //{
            //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
            //    {
            //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
            //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
            //        Qtyofnew = OpQty;
            //        OpQty = Qtyofoled + Qtyofnew;
            //    }
            //    else
            //    {
            //        objICIT_BR_BIN = new ICIT_BR_BIN();
            //        objICIT_BR_BIN.MySysName = MySysName;
            //        RoleFlag = true;
            //    }
            //}
            //else
            //{
            //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
            //    {
            //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
            //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
            //        Qtyofnew = OpQty;
            //        if (pagename == "+")
            //            OpQty = Qtyofoled + Qtyofnew;
            //        else
            //            OpQty = Qtyofoled - Qtyofnew;
            //    }
            //}


        }

        public static void insertICGRNTRCOST_HD(int TenentID, int MYTRANSID, int MYID, int OVERHEADCOSTID, decimal NEWCOST, int CRUP_ID, decimal COMPANY_SEQUENCE, int COMPANYID, string Note)
        {

            ICGRNTRCOST_HD objICGRNTRCOST_HD = new ICGRNTRCOST_HD();
            objICGRNTRCOST_HD.TenentID = TenentID;
            objICGRNTRCOST_HD.MYTRANSID = MYTRANSID;
            objICGRNTRCOST_HD.MYID = MYID;
            objICGRNTRCOST_HD.OVERHEADID = OVERHEADCOSTID;
            objICGRNTRCOST_HD.AMOUNT = NEWCOST;
            objICGRNTRCOST_HD.NOTES = Note;
            objICGRNTRCOST_HD.COMPANY_SEQUENCE = COMPANY_SEQUENCE;
            objICGRNTRCOST_HD.COMPANYID = COMPANYID;
            objICGRNTRCOST_HD.ACTIVE = true;
            objICGRNTRCOST_HD.CRUP_ID = CRUP_ID;
            DB.ICGRNTRCOST_HD.AddObject(objICGRNTRCOST_HD);
            DB.SaveChanges();

        }
        public static void insertICIT_BR_TMP(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int BinID, string BatchNo, string Serialize, Int64 MYTRANSID, int LocationID, decimal NewQty, string Reference, string RecodName, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Active, int CRUP_ID, bool MinusAllow = false)
        {

            if (DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == MyProdID && p.period_code == period_code && p.MySysName == MySysName && p.UOM == UOM && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).Count() > 0)
            {
                var List = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == MyProdID && p.period_code == period_code && p.MySysName == MySysName && p.UOM == UOM && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).ToList();
                foreach (Database.ICIT_BR_TMP item in List)
                {
                    DB.ICIT_BR_TMP.DeleteObject(item);
                    DB.SaveChanges();
                }
            }
            ICIT_BR_TMP objICIT_BR_TMP = new ICIT_BR_TMP();
            objICIT_BR_TMP.TenentID = TenentID;
            objICIT_BR_TMP.MyProdID = MyProdID;
            objICIT_BR_TMP.period_code = period_code;
            objICIT_BR_TMP.MySysName = MySysName;
            objICIT_BR_TMP.UOM = UOM;
            objICIT_BR_TMP.SIZECODE = SIZECODE;
            objICIT_BR_TMP.COLORID = COLORID;
            objICIT_BR_TMP.Bin_ID = BinID;
            objICIT_BR_TMP.BatchNo = BatchNo;
            objICIT_BR_TMP.Serial_Number = Serialize;
            objICIT_BR_TMP.MYTRANSID = MYTRANSID;
            objICIT_BR_TMP.LocationID = LocationID;
            if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.LocationID == LocationID && p.period_code == period_code && p.UOM == UOM && p.MyProdID == MyProdID).Count() == 1)
            {
                ICIT_BR obj = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.LocationID == LocationID && p.period_code == period_code && p.UOM == UOM && p.MyProdID == MyProdID);
                objICIT_BR_TMP.OpQty = obj.OpQty;
                objICIT_BR_TMP.OnHand = obj.OnHand;
                objICIT_BR_TMP.QtyOut = obj.QtyOut;
                objICIT_BR_TMP.QtyConsumed = obj.QtyConsumed;
                objICIT_BR_TMP.QtyReserved = obj.QtyReserved;
                objICIT_BR_TMP.QtyReceived = obj.QtyReceived;
                objICIT_BR_TMP.MinQty = obj.MinQty;
                objICIT_BR_TMP.MaxQty = obj.MaxQty;
                objICIT_BR_TMP.LeadTime = obj.LeadTime;
            }
            else
            {
                objICIT_BR_TMP.OpQty = 0;
                objICIT_BR_TMP.OnHand = 0;
                objICIT_BR_TMP.QtyOut = 0;
                objICIT_BR_TMP.QtyConsumed = 0;
                objICIT_BR_TMP.QtyReserved = 0;
                objICIT_BR_TMP.MinQty = 0;
                objICIT_BR_TMP.QtyReceived = 0;
                objICIT_BR_TMP.MaxQty = 0;
                objICIT_BR_TMP.LeadTime = 0;
            }
            objICIT_BR_TMP.NewQty = decimal.ToInt32( NewQty);
            objICIT_BR_TMP.Reference = Reference;
            objICIT_BR_TMP.RecodName = RecodName;
            objICIT_BR_TMP.ProdDate = ProdDate;
            objICIT_BR_TMP.ExpiryDate = ExpiryDate;
            objICIT_BR_TMP.LeadDays2Destroy = LeadDays2Destroy;
            objICIT_BR_TMP.Active = Active;
            objICIT_BR_TMP.CRUP_ID = CRUP_ID;
            objICIT_BR_TMP.MinusAllow = MinusAllow;
            DB.ICIT_BR_TMP.AddObject(objICIT_BR_TMP);
            DB.SaveChanges();

        }
        public static void insertICIT_BRAllTraction(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int Location, decimal UnitCost, int MYTRANSID, string Bin_Per, int OpQty, int OnHand, int QtyOut, int QtyConsumed, int QtyReserved, int MinQty, int MaxQty, int LeadTime, string Reference, string Active, int CRUP_ID, string pagename)
        {

            bool RoleFlag = false;
            int Qtyofoled = 0;
            int Qtyofnew = 0;
            int OPQTY = 0;
            int ONHANDQTY = 0;
            int QtyReceived = 0;
            int ONHANDTOTAL = 0;
            ICIT_BR objICIT_BR = new ICIT_BR();
            if (pagename != null)
            {
                if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.MySysName == MySysName && p.LocationID == Location).Count() > 0)
                {
                    objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location);
                    OPQTY = Convert.ToInt32(objICIT_BR.OpQty);
                    ONHANDQTY = Convert.ToInt32(objICIT_BR.OnHand);
                    QtyOut = Convert.ToInt32(objICIT_BR.QtyOut);
                    QtyConsumed = Convert.ToInt32(objICIT_BR.QtyConsumed);
                    QtyReserved = Convert.ToInt32(objICIT_BR.QtyReserved);
                    QtyReceived = Convert.ToInt32(objICIT_BR.QtyReceived);
                    objICIT_BR = DB.ICIT_BR.Single(p => TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location);
                    Qtyofoled = Convert.ToInt32(objICIT_BR.OpQty);
                    Qtyofnew = OpQty;
                    if (pagename == "+")
                    {
                        QtyReceived = QtyReceived + OpQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                    else
                    {
                        QtyOut = QtyOut - OpQty;
                        ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                    }
                }
                else
                {
                    objICIT_BR = new ICIT_BR();
                    objICIT_BR.MySysName = MySysName;
                    objICIT_BR.UnitCost = UnitCost;
                    RoleFlag = true;
                }
            }
            else
            {
                objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.MyProdID == MyProdID && p.UOM == UOM && p.MYTRANSID == MYTRANSID);
            }
            objICIT_BR.TenentID = TenentID;
            objICIT_BR.MyProdID = MyProdID;
            objICIT_BR.period_code = period_code;
            objICIT_BR.UOM = UOM;
            objICIT_BR.LocationID = Location;
            objICIT_BR.MYTRANSID = MYTRANSID;
            objICIT_BR.Bin_Per = Bin_Per;
            objICIT_BR.OpQty = OPQTY;
            objICIT_BR.OnHand = ONHANDTOTAL;
            objICIT_BR.QtyOut = QtyOut;
            objICIT_BR.QtyConsumed = QtyConsumed;
            objICIT_BR.QtyReserved = QtyReserved;
            objICIT_BR.QtyReceived = QtyReceived;
            objICIT_BR.Reference = Reference;
            objICIT_BR.Active = Active;
            objICIT_BR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.ICIT_BR.AddObject(objICIT_BR);
            }
            DB.SaveChanges();

        }

        public static void BindProdu(int PID, DropDownList ddlUOM, TextBox txtDescription, TextBox txtserchProduct, int TID)
        {

            string FullDicption = "";
            string Woranti = "";
            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            string DIScrip = objTBLPRODUCT.ProdName1.ToString();
            //if (objTBLPRODUCT.Warranty != null)
            //{
            //    Woranti = objTBLPRODUCT.Warranty;
            //    FullDicption = DIScrip + "\n" + " Warranty : " + Woranti;
            //}
            //else
            //{
            //    Woranti = "0";
            //    FullDicption = DIScrip + "\n" + " Warranty : " + Woranti + " Month; One Day to check in working condition Only";
            //}
            //FullDicption = DIScrip + "\n" + " Warranty : " + Woranti;
            int MOU = Convert.ToInt32(objTBLPRODUCT.UOM);
            ddlUOM.Enabled = false;
            txtserchProduct.Text = objTBLPRODUCT.BarCode;
            txtDescription.Text = DIScrip + "\n " + objTBLPRODUCT.Warranty.ToString();
            ddlUOM.SelectedValue = MOU.ToString();

        }

        public static void BindProduMulti(int PID, DropDownList ddlUOM, TextBox txtDescription, TextBox txtserchProduct, int TID)
        {

            string FullDicption = "";
            string Woranti = "";
            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            string DIScrip = objTBLPRODUCT.ProdName1.ToString();
            //if (objTBLPRODUCT.Warranty != null)
            //{
            //    Woranti = objTBLPRODUCT.Warranty;
            //    FullDicption = DIScrip + "\n " + " Warranty : " + Woranti;
            //}
            //else
            //{
            //    Woranti = "0";
            //    FullDicption = DIScrip + "\n" + " Warranty : " + Woranti + " Month; One Day to check in working condition Only";
            //}
            //FullDicption = DIScrip + "\n" + " Warranty : " + Woranti;

            txtserchProduct.Text = objTBLPRODUCT.BarCode;
            txtDescription.Text = DIScrip + "\n " + objTBLPRODUCT.Warranty.ToString();

        }
        public static void BindMultiMultiUOM(int PID, ListView lidtUom, Label lblmultiuom, int TID)
        {

            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            Boolean MultiUOM = Convert.ToBoolean(objTBLPRODUCT.MultiUOM);
            if (MultiUOM == Convert.ToBoolean(1))
            {
                lblmultiuom.Visible = true;
                List<Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataTbl_Multi_Color_Size_Mst(TID).Where(p => p.CompniyAndContactID == PID && p.RecordType == "MultiUOM" && p.RecValue != "All Colors").ToList();
                lidtUom.DataSource = List;
                lidtUom.DataBind();

            }
            else
            {
                lblmultiuom.Visible = false;
            }
        }

        public static void BindPerishable(int PID, LinkButton LinkButton5, int TID)
        {

            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            Boolean Perishable = Convert.ToBoolean(objTBLPRODUCT.Perishable);
            if (Perishable == Convert.ToBoolean(1))
            {
                LinkButton5.Visible = true;
                // ViewState["Perishable"] = "Perishable";

            }
            else
            {
                LinkButton5.Visible = false;
            }
        }

        public static void BindMultiMultiColor(int PID, ListView listmulticoler, Label LinkButton8, int TID)
        {

            Database.TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            Boolean MultiColor = Convert.ToBoolean(objTBLPRODUCT.MultiColor);
            if (MultiColor == Convert.ToBoolean(1))
            {
                LinkButton8.Visible = true;
                List<Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataTbl_Multi_Color_Size_Mst(TID).Where(p => p.CompniyAndContactID == PID && p.RecordType == "MultiColor" && p.RecValue != "All Colors").ToList();
                listmulticoler.DataSource = List;
                listmulticoler.DataBind();
            }
            else
            {
                LinkButton8.Visible = false;
            }
        }

        public static void BindMultiMultiSize(int PID, ListView listSize, Label LinkButton6, int TID)
        {

            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            Boolean MultiSize = Convert.ToBoolean(objTBLPRODUCT.MultiSize);
            if (MultiSize == Convert.ToBoolean(1))
            {
                LinkButton6.Visible = true;
                List<Tbl_Multi_Color_Size_Mst> List = Classes.EcommAdminClass.getDataTbl_Multi_Color_Size_Mst(TID).Where(p => p.CompniyAndContactID == PID && p.RecordType == "MultiSize" && p.RecValue != "All Size").ToList();
                listSize.DataSource = List;
                listSize.DataBind();
            }
            else
            {
                LinkButton6.Visible = false;
            }
        }

        public static void BindMultiSerialized(int PID, ListView listSerial, Label LinkButton2, TextBox txtQuantity, int TID)
        {

            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
            Boolean Serialized = Convert.ToBoolean(objTBLPRODUCT.Serialized);
            if (Serialized == Convert.ToBoolean(1))
            {
                LinkButton2.Visible = true;
                if (txtQuantity.Text == "0")
                { }
                else
                {
                    int PQTY = Convert.ToInt32(txtQuantity.Text);

                    List<ICIT_BR_Serialize> ListICIT_BR_Serialize = new List<ICIT_BR_Serialize>();
                    for (int i = 0; i <= PQTY - 1; i++)
                    {
                        ICIT_BR_Serialize obj = new ICIT_BR_Serialize();
                        ListICIT_BR_Serialize.Add(obj);
                    }
                    listSerial.DataSource = ListICIT_BR_Serialize;
                    listSerial.DataBind();
                    // ViewState["Serialized"] = "Serialized";
                }
            }
            else
            {
                LinkButton2.Visible = false;
            }
        }

        public static void BindMultiSerializedInvoice(int TID, int PID, int LID, string OICODID, ListView listSerial, Label LinkButton2, TextBox txtQuantity)
        {

            TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID && p.LOCATION_ID == LID && p.ACTIVE == "1");
            Boolean Serialized = Convert.ToBoolean(objTBLPRODUCT.Serialized);
            if (Serialized == Convert.ToBoolean(1))
            {
                LinkButton2.Visible = true;
                if (txtQuantity.Text == "0")
                { }
                else
                {
                    //int PQTY = Convert.ToInt32(txtQuantity.Text);
                    //List<ICIT_BR_Serialize> ListICIT_BR_Serialize = new List<ICIT_BR_Serialize>();
                    //for (int i = 0; i <= PQTY - 1; i++)
                    //{
                    //    ICIT_BR_Serialize obj = new ICIT_BR_Serialize();
                    //    ListICIT_BR_Serialize.Add(obj);
                    //}
                    var Listserl = DB.ICIT_BR_Serialize.Where(p => p.TenentID == TID && p.LocationID == LID && p.MyProdID == PID && p.period_code == OICODID).ToList();

                    listSerial.DataSource = Listserl;
                    listSerial.DataBind();
                    // ViewState["Serialized"] = "Serialized";
                }
            }
            else
            {
                LinkButton2.Visible = false;
            }
        }
        public static bool IsAlphaNum(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;


            for (int i = 0; i < str.Length - 1; i++)
            {
                if (!(char.IsLetter(str[i])) && (!(char.IsNumber(str[i]))))
                    return false;
                else if (char.IsLetter(str[i]))
                {
                    return false;
                }
                else
                    return true;
            }

            return false;

        }
        public static int BindAddvanserchBR1(TextBox txtserchProduct, DropDownList ddlProduct, DropDownList ddlUOM, TextBox txtDescription, int TID, int LID, string lang)
        {
            string id1 = txtserchProduct.Text.ToString();
            //int id2 = 0;
            //if (IsAlphaNum(id1) == true)
            //    id2 = Convert.ToInt32(txtserchProduct.Text);

            var list1 = DB.View_ICBR_Product.Where(p => (p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper())
                || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper())
                || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper()) || p.keywords.ToUpper().Contains(id1.ToUpper())
                || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper()) || p.ProdName1.ToUpper().Contains(id1.ToUpper()))
                && p.Active == "Y" && p.TenentID == TID && p.LocationID == LID).OrderBy(p => p.MyProdID).ToList();//p.MyProdID == id2 ||
            string DrpTitle = lang == "en-US" ? "ProdName1" : lang == "fr-FR" ? "ProdName2" : "ProdName3";
            ddlProduct.DataSource = list1.GroupBy(p => p.MyProdID).Select(p => p.FirstOrDefault()).ToList();
            ddlProduct.DataTextField = DrpTitle;
            ddlProduct.DataValueField = "MyProdID";
            ddlProduct.DataBind();
            //if (list1.Count() > 0)
            //    lblAvailableQty.Text = "Available Qty : " + list1[0].OnHand.ToString();
            if (ddlProduct.SelectedValue == "")
            {

            }
            else
            {
                int PID = Convert.ToInt32(ddlProduct.SelectedValue);//BindProduMulti

                TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
                bool multi = Convert.ToBoolean(objTBLPRODUCT.MultiUOM);
                if (multi == Convert.ToBoolean(1))
                {
                    Classes.EcommAdminClass.BindProduMulti(PID, ddlUOM, txtDescription, txtserchProduct, TID);
                }
                else
                {
                    Classes.EcommAdminClass.BindProdu(PID, ddlUOM, txtDescription, txtserchProduct, TID);
                }
            }
            return list1.GroupBy(p => p.MyProdID).Select(p => p.FirstOrDefault()).Count();
        }

        public static int BindAddvanserchBR(TextBox txtserchProduct, DropDownList ddlProduct, DropDownList ddlUOM, TextBox txtDescription, int TID, int LID, Label lblAvailableQty, string lang)
        {
            string id1 = txtserchProduct.Text.ToString();
            //int id2 = 0;
            //if (IsAlphaNum(id1) == true)
            //    id2 = Convert.ToInt32(txtserchProduct.Text);

            var list1 = DB.View_ICBR_Product.Where(p => (p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper())
                || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper())
                || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper()) || p.keywords.ToUpper().Contains(id1.ToUpper())
                || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper()) || p.ProdName1.ToUpper().Contains(id1.ToUpper()))
                && p.Active == "Y" && p.TenentID == TID && p.LocationID == LID && p.OnHand > 0).OrderBy(p => p.MyProdID).ToList();//p.MyProdID == id2 ||
            string DrpTitle = lang == "en-US" ? "ProdName1" : lang == "fr-FR" ? "ProdName2" : "ProdName3";
            ddlProduct.DataSource = list1.GroupBy(p => p.MyProdID).Select(p => p.FirstOrDefault()).ToList();
            ddlProduct.DataTextField = DrpTitle;
            ddlProduct.DataValueField = "MyProdID";
            ddlProduct.DataBind();

            if (list1.Count() > 0)
                lblAvailableQty.Text = "Available Qty : " + list1[0].OnHand.ToString();
            if (ddlProduct.SelectedValue == "")
            {

            }
            else
            {
                int PID = Convert.ToInt32(ddlProduct.SelectedValue);//BindProduMulti

                TBLPRODUCT objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == PID && p.TenentID == TID);
                bool multi = Convert.ToBoolean(objTBLPRODUCT.MultiUOM);
                if (multi == Convert.ToBoolean(1))
                {
                    Classes.EcommAdminClass.BindProduMulti(PID, ddlUOM, txtDescription, txtserchProduct, TID);
                }
                else
                {
                    Classes.EcommAdminClass.BindProdu(PID, ddlUOM, txtDescription, txtserchProduct, TID);
                }

            }
            return list1.GroupBy(p => p.MyProdID).Select(p => p.FirstOrDefault()).Count();
        }
        public static int BindAddvanserchBRDash(string txtserchProduct, Repeater ddlProduct, int TID, string lang)
        {
            string id1 = txtserchProduct.ToString();
            int id2 = 0;
            if (IsAlphaNum(id1) == true)
                id2 = Convert.ToInt32(txtserchProduct);

            var list1 = DB.View_ICBR_Product.Where(p => (p.MyProdID == id2 || p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper())
                || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper())
                || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper()) || p.keywords.ToUpper().Contains(id1.ToUpper())
                || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper()) || p.ProdName1.ToUpper().Contains(id1.ToUpper()))
                && p.Active == "Y" && p.TenentID == TID).OrderBy(p => p.MyProdID).ToList();
            string DrpTitle = lang == "en-US" ? "Prod1" : lang == "fr-FR" ? "Prod2" : "Prod3";
            ddlProduct.DataSource = list1;
            ddlProduct.DataBind();

            return list1.Count();
        }


        public static List<ICTR_HD_Sales> grdPOICTR_HD(int TID, int transid, int transsubid)//parimal
        {
           // int LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            var List = DB.ICTR_HD_Sales.Where(p => p.TenentID == TID && p.ACTIVE == true && (p.transid == transid && p.transsubid == transsubid)).ToList();
            return List;
        }

        public static List<ICTR_DT_Sales> getListICTR_DT(int TID, int MYTRANSID)//parimal
        {
            var List = DB.ICTR_DT_Sales.Where(p => p.MYTRANSID == MYTRANSID && p.ACTIVE == true && p.TenentID == TID).ToList();
            return List;
        }

        public static List<ICTR_DT_Sales_tmp> getListICTR_DTemp(int TID, int MYTRANSID)//parimal
        {
            var List = DB.ICTR_DT_Sales_tmp.Where(p => p.MYTRANSID == MYTRANSID && p.ACTIVE == true && p.TenentID == TID).ToList();
            return List;
        }
        public static List<ICTR_HD_Sales> getListICTR_HD(int TID, int transid, int transsubid)//parimal
        {
            var List = DB.ICTR_HD_Sales.Where(p => p.transid == transid && p.transsubid == transsubid && p.TenentID == TID).ToList();
            return List;
        }

        public static List<ICIT_BR_TMP> getListICIT_BR_TMP(int TID, int MYTRANSID, int MyProdID)//parimal
        {
            var List = DB.ICIT_BR_TMP.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.MyProdID == MyProdID).ToList();
            return List;
        }

        public static List<ICTR_DTEXT> getListICTR_DTEXT(int TID, int MYTRANSID)//parimal
        {
            var List = DB.ICTR_DTEXT.Where(p => p.MYTRANSID == MYTRANSID && p.ACTIVE == true && p.TenentID == TID).ToList();
            return List;
        }
        public static List<ICTRPayTerms_HD> getListICTRPayTerms_HD(int TID, int MYTRANSID)//parimal
        {
            var List = DB.ICTRPayTerms_HD.Where(p => p.MyTransID == MYTRANSID && p.TenentID == TID).ToList();
            return List;
        }
        public static tbltranssubtype tbltranssubtype(int TID, int Transid, int Transsubid)//parimal
        {
            tbltranssubtype objtbltranssubtype = DB.tbltranssubtypes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid);
            return objtbltranssubtype;
        }

        public static string CompnyName_TBLCOMPANYSETUP(int TID, int CID)//parimal
        {
            TBLCOMPANYSETUP onj = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPID == CID);
            return onj.COMPNAME1;
        }
        public static List<TBLCOMPANYSETUP> COMPID_TBLCOMPANYSETUP(int TID, string UseID)//parimal
        {
            List<TBLCOMPANYSETUP> TBLCOMPANYSETUP = DB.TBLCOMPANYSETUPs.Where(p => p.USERID == UseID && p.TenentID == TID).ToList();
            return TBLCOMPANYSETUP;
        }
        public static string MYSYSNAME(int TID, int Transid, int Transsubid)
        {
            if (DB.tbltranssubtypes.Where(p => p.transid == Transid && p.transsubid == Transsubid).Count() > 0)
            {
                string MYSYSNAME = DB.tbltranssubtypes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid).MYSYSNAME;
                return MYSYSNAME;
            }
            else
                return "";

        }

        public static decimal CostAmount(int TID, int MyProdID, int LID, int UOM)
        {
            List<Database.ICIT_BR> ListIcit_br = DB.ICIT_BR.Where(p => p.TenentID == TID && p.MyProdID == MyProdID && p.LocationID == LID && p.UOM == UOM).ToList();
            List<Database.TBLPRODUCT> ListTBLPRODUCT = DB.TBLPRODUCTs.Where(p => p.TenentID == TID && p.MYPRODID == MyProdID && p.LOCATION_ID == LID && p.UOM == UOM).ToList();
            if (ListIcit_br.Count() > 0)
            {
                decimal CostAmount = Convert.ToDecimal(ListIcit_br.Single(p => p.TenentID == TID && p.MyProdID == MyProdID && p.LocationID == LID && p.UOM == UOM).UnitCost);
                return CostAmount;
            }
            else if (ListTBLPRODUCT.Count() > 0)
            {
                decimal CostAmount = Convert.ToDecimal(ListTBLPRODUCT.Single(p => p.TenentID == TID && p.MYPRODID == MyProdID && p.LOCATION_ID == LID && p.UOM == UOM).basecost);
                return CostAmount;
            }
            else
                return 0;

        }
        public static string TransDocNo(int TID, int Transid, int Transsubid)
        {
            var listtbltranssubtypes = DB.tbltranssubtypes.Where(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid).ToList();
            if (listtbltranssubtypes.Count() > 0)
            {
                int SirialNO1 = 0;
                SirialNO1 = (Convert.ToInt32(listtbltranssubtypes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid).serialno) + 1);
                string SirialNO = SirialNO1.ToString();
                // string Yearinvoice = listtbltranssubtypes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid).years.ToString();
                string TransDocNo = SirialNO;// + "/" + Yearinvoice + "/" + TID;

                //Database.tbltranssubtype objtblsubtype = DB.tbltranssubtypes.Single(p => p.TenentID == TID && p.transid == Transid && p.transsubid == Transsubid);
                //objtblsubtype.serialno = SirialNO;
                //DB.SaveChanges();

                return TransDocNo;
            }
            else
                return "";
        }
        public static int BindAddvanserch(TextBox txtserchProduct, DropDownList ddlProduct, DropDownList ddlUOM, TextBox txtDescription, int TID)
        {

            string id1 = txtserchProduct.Text.Trim().ToString();
            //id1.ToCharArray[0];
            //id1.Substring(0, 1);
            id1 = id1.TrimStart('0');
            var list1 = DB.View_Product_fetch.Where(p => (p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper()) || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper()) || p.keywords.ToUpper().Contains(id1.ToUpper()) || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper()) || p.ProdName1.ToUpper().Contains(id1.ToUpper())) && p.ACTIVE == "1" && p.TenentID == TID).OrderBy(p => p.MYPRODID).ToList();
            ddlProduct.DataSource = list1;
            ddlProduct.DataTextField = "ProdName1";
            ddlProduct.DataValueField = "MYPRODID";
            ddlProduct.DataBind();
            if (ddlProduct.SelectedValue == "")
            {

            }
            else
            {
                int PID = Convert.ToInt32(ddlProduct.SelectedValue);
                Classes.EcommAdminClass.BindProdu(PID, ddlUOM, txtDescription, txtserchProduct, TID);
            }
            return list1.Count();
        }
        public static int BindAddvanserchDash(string txtserchProduct, Repeater ddlProduct, int TID)
        {

            string id1 = txtserchProduct.Trim().ToString();
            //id1.ToCharArray[0];
            //id1.Substring(0, 1);
            id1 = id1.TrimStart('0');
            var list1 = DB.View_Product_fetch.Where(p => (p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper()) || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper()) || p.keywords.ToUpper().Contains(id1.ToUpper()) || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper()) || p.ProdName1.ToUpper().Contains(id1.ToUpper())) && p.ACTIVE == "1" && p.TenentID == TID).OrderBy(p => p.MYPRODID).ToList();
            ddlProduct.DataSource = list1;
            ddlProduct.DataBind();

            return list1.Count();
        }
        public static string BindItemCount(TextBox txtserchProduct, int TID)
        {

            string id1 = txtserchProduct.Text.ToString();
            var list1 = DB.TBLPRODUCTs.Where(p => (p.UserProdID.ToUpper().Contains(id1.ToUpper()) || p.BarCode.ToUpper().Contains(id1.ToUpper())
                || p.AlternateCode1.ToUpper().Contains(id1.ToUpper()) || p.AlternateCode2.ToUpper().Contains(id1.ToUpper()) || p.ShortName.ToUpper().Contains(id1.ToUpper())
                || p.ProdName1.ToUpper().Contains(id1.ToUpper()) || p.ProdName2.ToUpper().Contains(id1.ToUpper()) || p.ProdName3.ToUpper().Contains(id1.ToUpper())
                || p.keywords.ToUpper().Contains(id1.ToUpper()) || p.REMARKS.ToUpper().Contains(id1.ToUpper()) || p.DescToprint.ToUpper().Contains(id1.ToUpper())
                ) && p.ACTIVE == "1" && p.TenentID == TID).OrderBy(p => p.MYPRODID).ToList();
            if (list1.Count() > 0)
                return list1.Count() + "~" + list1[0].MYPRODID;
            else
                return "0";
        }
        public static void BindSerchcutomer(TextBox txtserchCustmer, DropDownList ddlSupplier, int TID)
        {

            string id1 = txtserchCustmer.Text.ToString();
            List<TBLCOMPANYSETUP> List = DB.TBLCOMPANYSETUPs.Where(p => (p.COMPNAME1.ToUpper().Contains(id1.ToUpper()) || p.COMPNAME2.ToUpper().Contains(id1.ToUpper()) || p.EMAIL1.ToUpper().Contains(id1.ToUpper())) && p.Active == "Y" && p.BUYER == true && p.TenentID == TID).OrderBy(p => p.COMPID).ToList();
            ddlSupplier.DataSource = List;
            ddlSupplier.DataTextField = "COMPNAME1";
            ddlSupplier.DataValueField = "COMPID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Customer--", "0"));

        }

        public static void insertICIT_Price_Different(int TenentID = 0, int locationID = 0, int MYTRANSID = 0, int MyProdID = 0, string MYSYSNAME = "", string MainTranType = "", string TranType = "", decimal OldPrice = 0, decimal NewPrice = 0, decimal TotalQty = 0, decimal Different = 0, decimal TotalDifferent = 0, string Userid = "", DateTime? Stardate = null, DateTime? Enddate = null, DateTime? Datetime = null)
        {

            ICIT_Price_Different objICIT_BR = new ICIT_Price_Different();
            objICIT_BR.TenentID = TenentID;
            objICIT_BR.locationID = locationID;
            objICIT_BR.MYTRANSID = MYTRANSID;
            objICIT_BR.MyProdID = MyProdID;
            objICIT_BR.MYSYSNAME = MYSYSNAME;
            objICIT_BR.MainTranType = MainTranType;
            objICIT_BR.TranType = TranType;
            objICIT_BR.Myid = DB.ICIT_Price_Different.Count() > 0 ? Convert.ToInt32(DB.ICIT_Price_Different.Max(p => p.Myid) + 1) : 1;
            objICIT_BR.OldPrice = OldPrice;
            objICIT_BR.NewPrice = NewPrice;
            objICIT_BR.TotalQty = TotalQty;
            objICIT_BR.Different = Different;
            objICIT_BR.TotalDifferent = TotalDifferent;
            objICIT_BR.Userid = Userid;
            objICIT_BR.Stardate = Stardate;
            objICIT_BR.Enddate = Enddate;
            objICIT_BR.Datetime = Datetime;
            DB.ICIT_Price_Different.AddObject(objICIT_BR);
            DB.SaveChanges();

        }

        public static void insertICTRPayTerms_HD(int TenentID = 0, int MyTransID = 0, int PaymentTermsId = 0, string CounterID = "", int LocationID = 0, int CashBankChequeID = 0, decimal Amount = 0, string ReferenceNo = "", DateTime? TransDate = null, DateTime? CheckOutDate = null, string Notes = null, int AccountID = 0, int CRUP_ID = 0, string ApprovalID = "", int AccountantID = 0, bool ChequeVerified = false, bool CashVerified = false, bool ATMVerified = false, bool VoucharVerified = false, DateTime? ChequeVerifiedDate = null, DateTime? CashVerifiedDate = null, DateTime? ATMVerifiedDate = null, DateTime? VoucharVerifiedDate = null, string JVRefNo = "")
        {


            if (DB.ICTRPayTerms_HD.Where(p => p.TenentID == TenentID && p.MyTransID == MyTransID && p.PaymentTermsId == PaymentTermsId).Count() > 0)
            {
                ICTRPayTerms_HD objICTRPayTerms_HD = DB.ICTRPayTerms_HD.Single(p => p.TenentID == TenentID && p.MyTransID == MyTransID && p.PaymentTermsId == PaymentTermsId);
                objICTRPayTerms_HD.TenentID = TenentID;
                objICTRPayTerms_HD.LocationID = LocationID;
                objICTRPayTerms_HD.MyTransID = MyTransID;
                objICTRPayTerms_HD.PaymentTermsId = PaymentTermsId;
                objICTRPayTerms_HD.CashBankChequeID = CashBankChequeID;
                objICTRPayTerms_HD.CounterID = CounterID;
                objICTRPayTerms_HD.TransDate = TransDate != null ? TransDate : DateTime.Now;
                objICTRPayTerms_HD.CheckOutDate = CheckOutDate;// come from Cash Delivery Popup
                objICTRPayTerms_HD.AccountantID = AccountantID;// come from Cash Delivery Popup
                objICTRPayTerms_HD.AccountID = AccountID;
                objICTRPayTerms_HD.CRUP_ID = CRUP_ID;
                objICTRPayTerms_HD.Notes = Notes;
                objICTRPayTerms_HD.Amount = Amount;
                objICTRPayTerms_HD.ReferenceNo = ReferenceNo;
                objICTRPayTerms_HD.ApprovalID = ApprovalID;
                objICTRPayTerms_HD.ChequeVerified = ChequeVerified;
                objICTRPayTerms_HD.CashVerified = CashVerified;
                objICTRPayTerms_HD.ATMVerified = ATMVerified;
                objICTRPayTerms_HD.VoucharVerified = VoucharVerified;
                objICTRPayTerms_HD.ChequeVerifiedDate = ChequeVerifiedDate;
                objICTRPayTerms_HD.CashVerifiedDate = CashVerifiedDate;
                objICTRPayTerms_HD.ATMVerifiedDate = ATMVerifiedDate;
                objICTRPayTerms_HD.VoucharVerifiedDate = VoucharVerifiedDate;
                objICTRPayTerms_HD.JVRefNo = JVRefNo;

                DB.SaveChanges();
            }
            else
            {
                ICTRPayTerms_HD objICTRPayTerms_HD = new ICTRPayTerms_HD();
                objICTRPayTerms_HD.TenentID = TenentID;
                objICTRPayTerms_HD.LocationID = LocationID;
                objICTRPayTerms_HD.MyTransID = MyTransID;
                objICTRPayTerms_HD.PaymentTermsId = PaymentTermsId;
                objICTRPayTerms_HD.CashBankChequeID = CashBankChequeID;
                objICTRPayTerms_HD.CounterID = CounterID;
                objICTRPayTerms_HD.TransDate = TransDate;
                objICTRPayTerms_HD.CheckOutDate = CheckOutDate;// come from Cash Delivery Popup
                objICTRPayTerms_HD.AccountantID = AccountantID;// come from Cash Delivery Popup
                objICTRPayTerms_HD.AccountID = AccountID;
                objICTRPayTerms_HD.CRUP_ID = CRUP_ID;
                objICTRPayTerms_HD.Notes = Notes;
                objICTRPayTerms_HD.Amount = Amount;
                objICTRPayTerms_HD.ReferenceNo = ReferenceNo;
                objICTRPayTerms_HD.ApprovalID = ApprovalID;
                objICTRPayTerms_HD.ChequeVerified = ChequeVerified;
                objICTRPayTerms_HD.CashVerified = CashVerified;
                objICTRPayTerms_HD.ATMVerified = ATMVerified;
                objICTRPayTerms_HD.VoucharVerified = VoucharVerified;
                objICTRPayTerms_HD.ChequeVerifiedDate = ChequeVerifiedDate;
                objICTRPayTerms_HD.CashVerifiedDate = CashVerifiedDate;
                objICTRPayTerms_HD.ATMVerifiedDate = ATMVerifiedDate;
                objICTRPayTerms_HD.VoucharVerifiedDate = VoucharVerifiedDate;
                objICTRPayTerms_HD.JVRefNo = JVRefNo;

                DB.ICTRPayTerms_HD.AddObject(objICTRPayTerms_HD);
                DB.SaveChanges();
            }




        }

        public static void insertICTRPayTerms_HD_TEMP(int TenentID = 0, int MyTransID = 0, int PaymentTermsId = 0, string CounterID = "", int LocationID = 0, int CashBankChequeID = 0, decimal Amount = 0, string ReferenceNo = "", DateTime? TransDate = null, DateTime? CheckOutDate = null, string Notes = null, int AccountID = 0, int CRUP_ID = 0, string ApprovalID = "", int AccountantID = 0, bool ChequeVerified = false, bool CashVerified = false, bool ATMVerified = false, bool VoucharVerified = false, DateTime? ChequeVerifiedDate = null, DateTime? CashVerifiedDate = null, DateTime? ATMVerifiedDate = null, DateTime? VoucharVerifiedDate = null, string JVRefNo = "")
        {

            ICTRPayTerms_HD_TEMP objICTRPayTerms_HD = new ICTRPayTerms_HD_TEMP();
            objICTRPayTerms_HD.TenentID = TenentID;
            objICTRPayTerms_HD.LocationID = LocationID;
            objICTRPayTerms_HD.MyTransID = MyTransID;
            objICTRPayTerms_HD.PaymentTermsId = PaymentTermsId;
            objICTRPayTerms_HD.CashBankChequeID = CashBankChequeID;
            objICTRPayTerms_HD.CounterID = CounterID;
            objICTRPayTerms_HD.TransDate = TransDate;
            objICTRPayTerms_HD.CheckOutDate = CheckOutDate;// come from Cash Delivery Popup
            objICTRPayTerms_HD.AccountantID = AccountantID;// come from Cash Delivery Popup
            objICTRPayTerms_HD.AccountID = AccountID;
            objICTRPayTerms_HD.CRUP_ID = CRUP_ID;
            objICTRPayTerms_HD.Notes = Notes;
            objICTRPayTerms_HD.Amount = Amount;
            objICTRPayTerms_HD.ReferenceNo = ReferenceNo;
            objICTRPayTerms_HD.ApprovalID = ApprovalID;
            objICTRPayTerms_HD.ChequeVerified = ChequeVerified;
            objICTRPayTerms_HD.CashVerified = CashVerified;
            objICTRPayTerms_HD.ATMVerified = ATMVerified;
            objICTRPayTerms_HD.VoucharVerified = VoucharVerified;
            objICTRPayTerms_HD.ChequeVerifiedDate = ChequeVerifiedDate;
            objICTRPayTerms_HD.CashVerifiedDate = CashVerifiedDate;
            objICTRPayTerms_HD.ATMVerifiedDate = ATMVerifiedDate;
            objICTRPayTerms_HD.VoucharVerifiedDate = VoucharVerifiedDate;
            objICTRPayTerms_HD.JVRefNo = JVRefNo;

            DB.ICTRPayTerms_HD_TEMP.AddObject(objICTRPayTerms_HD);
            DB.SaveChanges();

        }

        public static void insertICITEMS_PRICE(int TenentID = 0, int MYPRODID = 0, int UOM = 0, string ITEMID = "", decimal ORIGINALPRICE = 0, int MAXDISCOUNT = 0, decimal SPECIALSALE = 0, string REFERENCE = "", long CRUP_ID = 0, int LOCATIONID = 0, int COMPANYID = 0)
        {

            ICITEMS_PRICE objICIT_BR = new ICITEMS_PRICE();
            objICIT_BR.TenentID = TenentID;
            objICIT_BR.MYPRODID = MYPRODID;
            objICIT_BR.UOM = UOM;
            objICIT_BR.MyID = DB.ICITEMS_PRICE.Where(p => p.MYPRODID == MYPRODID && p.TenentID == TenentID).Count() > 0 ? Convert.ToInt32(DB.ICITEMS_PRICE.Where(p => p.MYPRODID == MYPRODID && p.TenentID == TenentID).Max(p => p.MyID) + 1) : 1;
            objICIT_BR.UserProdID = ITEMID;
            objICIT_BR.ORIGINALPRICE = ORIGINALPRICE;
            objICIT_BR.MAXDISCOUNT = MAXDISCOUNT;
            objICIT_BR.SPECIALSALE = SPECIALSALE;
            objICIT_BR.REFERENCE = REFERENCE;
            objICIT_BR.CRUP_ID = CRUP_ID;
            objICIT_BR.LOCATIONID = LOCATIONID;
            objICIT_BR.COMPANYID = COMPANYID;
            DB.ICITEMS_PRICE.AddObject(objICIT_BR);
            DB.SaveChanges();

        }

        public static void insertICTR_DTEditForreopen(int MYTRANSID = 0, int MYID = 0, int MyProdID = 0, int TenentID = 0, int locationID = 0, decimal? Prieshtotal = 0, decimal? FInelOC = 0)
        {

            ICTR_DT_Sales objICTR_DT = DB.ICTR_DT_Sales.Single(p => p.MYTRANSID == MYTRANSID && p.MYID == MYID && p.MyProdID == MyProdID && p.TenentID == TenentID && p.locationID == locationID);
            objICTR_DT.UNITPRICE = Prieshtotal;
            Decimal QTY = Convert.ToDecimal(objICTR_DT.QUANTITY);
            Decimal Prieshtotal1 = Convert.ToDecimal(Prieshtotal);
            decimal TotalAmount = Prieshtotal1 * QTY;
            objICTR_DT.AMOUNT = TotalAmount;
            objICTR_DT.OVERHEADAMOUNT = FInelOC;
            DB.SaveChanges();

        }

        public static void insertICIT_BREditForreopen(int TenentID, int LocationID, int MyProdID, string MySysName, string period_code, decimal Prieshtotal, int UOM)
        {

            ICIT_BR objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.LocationID == LocationID && p.MyProdID == MyProdID && p.MySysName == MySysName && p.period_code == period_code && p.UOM == UOM);
            objICIT_BR.UnitCost = Prieshtotal;
            DB.SaveChanges();

        }

        public static bool BindStockTaking(DateTime Date, int TID, Panel panelMsg, Label lblErreorMsg, bool Fleg)
        {

            DateTime CurrentDate = Date;
            int day = Convert.ToInt32(CurrentDate.Day);
            int month = Convert.ToInt32(CurrentDate.Month);
            int year = Convert.ToInt32(CurrentDate.Year);
            if (DB.StockTakingTables.Where(p => p.DateBegin.Value.Day <= day && p.DateBegin.Value.Month <= month && p.DateBegin.Value.Year <= year && p.DateClose.Value.Day >= day && p.DateClose.Value.Month >= month && p.DateClose.Value.Year >= year && p.MySysName == "IC" && p.TenentID == TID).Count() > 0)
            {
                panelMsg.Visible = true;
                lblErreorMsg.Text = "No add new transactions are allowed in all invntory + seales + purchase";
                Fleg = false;
                return Fleg;

            }
            else
            {
                Fleg = true;
                return Fleg;
            }

        }


        public static int Pidalcode(DateTime? Time = null, int TenentID = 0, string MYSYSNAME = null)
        {

            int PODID = 0;
            List<Database.TBLPERIOD> ListTBLPERIOD = DB.TBLPERIODS.Where(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.TenentID == TenentID && p.MYSYSNAME == MYSYSNAME).ToList();
            if (ListTBLPERIOD.Count() > 0)
            {
                PODID = Convert.ToInt32(ListTBLPERIOD.Single(p => p.PRD_START_DATE <= Time && p.PRD_END_DATE >= Time && p.TenentID == TenentID && p.MYSYSNAME == MYSYSNAME).PERIOD_CODE);

            }
            return PODID;
        }

        public static bool postprocess(int TenentID = 0, int LID = 0, int transid = 0, int trnassubid = 0, int MYTRANSID = 0, int MYID = 0, decimal QTY = 0, string Reference = null, DateTime? trnsDate = null, string MySysName = null, int MyProdID = 0, string ICPOST = null, decimal UnitCost = 0, TBLPRODUCT objTBLPRODUCT = null, int UOM = 0)//parimal  ICTR_DT objDT, ICTR_HD Objhd,
        {
            //check perameter value is not null,space and  zero
            if (TenentID != null && TenentID != 0 && LID != null && LID != 0 && UOM != null && UOM != 0 && transid != null && transid != 0 && trnassubid != null && trnassubid != 0 && MYTRANSID != null && MYTRANSID != 0 && QTY != null  && trnsDate != null && MySysName != null && MySysName != "" && MyProdID != null && MyProdID != 0 && ICPOST != null && ICPOST != "" && UnitCost != null && UnitCost != 0 && objTBLPRODUCT != null)//&& Reference != null && Reference != ""
            {

                Reference = "";
                if (ICPOST != "0")
                {

                    //objTBLPRODUCT = DB.TBLPRODUCTs.Single(p => p.MYPRODID == MyProdID && p.TenentID == TenentID);
                    Boolean MultiUOM = Convert.ToBoolean(objTBLPRODUCT.MultiUOM);
                    Boolean MultiColor = Convert.ToBoolean(objTBLPRODUCT.MultiColor);
                    Boolean Perishable = Convert.ToBoolean(objTBLPRODUCT.Perishable);
                    Boolean MultiSize = Convert.ToBoolean(objTBLPRODUCT.MultiSize);
                    Boolean Serialized = Convert.ToBoolean(objTBLPRODUCT.Serialized);
                    Boolean MultiBinStore = Convert.ToBoolean(objTBLPRODUCT.MultiBinStore);

                    Database.tbltranssubtype objsubtype = DB.tbltranssubtypes.Single(p => p.TenentID == TenentID && p.transid == transid && p.transsubid == trnassubid);

                    decimal nwQTY = 0;
                    string Bin_Per = "N";
                    string Active = "Y";
                    int CRUP_ID = 99999999;
                    int SIZECODE = 999999998;

                    string period_code = Pidalcode(trnsDate, TenentID, MySysName).ToString();
                    if (MultiUOM != Convert.ToBoolean(1))
                    {
                        PostICIT_BR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, QTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, objsubtype);

                    }

                    //PostTBLProduct(TenentID, LID, QTY, objTBLPRODUCT, objsubtype);


                    if (MultiColor == Convert.ToBoolean(1))
                    {
                        List<Database.ICIT_BR_TMP> listmulticoler = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == MYTRANSID && p.MySysName == MySysName && p.MyProdID == MyProdID && p.UOM == UOM && p.Active == "D" && p.COLORID != 999999998 && p.RecodName == "MultiColor" && p.TenentID == TenentID).ToList();
                        foreach (Database.ICIT_BR_TMP ItemColor in listmulticoler)
                        {
                            int COLORID = ItemColor.COLORID;
                            Reference = ItemColor.Reference.ToString();
                            Active = "Y";
                            SIZECODE = ItemColor.SIZECODE;
                            UOM = ItemColor.UOM;
                            nwQTY = Convert.ToDecimal(ItemColor.NewQty);

                            PostICIT_BR_SIZECOLOR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, SIZECODE, COLORID, nwQTY, UnitCost, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }

                    if (MultiSize == Convert.ToBoolean(1))
                    {
                        List<Database.ICIT_BR_TMP> listmultisize = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "MultiSize" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();

                        foreach (Database.ICIT_BR_TMP Itemsize in listmultisize)
                        {
                            int COLORID = Itemsize.COLORID;
                            Reference = Itemsize.Reference.ToString();
                            Active = "Y";
                            SIZECODE = Itemsize.SIZECODE;
                            UOM = Itemsize.UOM;
                            nwQTY = Convert.ToDecimal(Itemsize.NewQty);

                            PostICIT_BR_SIZE(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, SIZECODE, COLORID, nwQTY, UnitCost, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }
                    if (MultiUOM == Convert.ToBoolean(1))
                    {
                        //List<Database.ICIT_BR_TMP> listMUOMLIST = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "UOM" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();
                        //foreach (Database.ICIT_BR_TMP ItemMUOM in listMUOMLIST)
                        //{
                        //    int COLORID = ItemMUOM.COLORID;
                        //    Reference = ItemMUOM.Reference.ToString();
                        //    Active = "Y";
                        //    SIZECODE = ItemMUOM.SIZECODE;
                        //    UOM = ItemMUOM.UOM;
                        //    nwQTY = Convert.ToDecimal(ItemMUOM.NewQty);

                        nwQTY = QTY;
                        PostICIT_BR(TenentID, LID, MYTRANSID, MyProdID, UOM, period_code, nwQTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, objsubtype);
                        //}
                    }

                    if (MultiBinStore == Convert.ToBoolean(1))
                    {
                        List<Database.ICIT_BR_TMP> listBin123 = DB.ICIT_BR_TMP.Where(p => p.MyProdID == MyProdID && p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.UOM == UOM && p.Active == "D" && p.MySysName == "PUR" && p.RecodName == "MultiBIN" && p.Bin_ID != 999999998).ToList();
                        foreach (Database.ICIT_BR_TMP ItemMUOM in listBin123)
                        {
                            int COLORID = ItemMUOM.COLORID;
                            Reference = ItemMUOM.Reference.ToString();
                            Active = "Y";
                            int Bin_ID = Convert.ToInt32(ItemMUOM.Bin_ID);
                            SIZECODE = ItemMUOM.SIZECODE;
                            UOM = ItemMUOM.UOM;
                            nwQTY = Convert.ToDecimal(ItemMUOM.NewQty);
                            PostICIT_BR_BIN(TenentID, LID, MYTRANSID, MyProdID, MySysName, UOM, period_code, nwQTY, UnitCost, Bin_Per, Reference, Active, CRUP_ID, Bin_ID, objsubtype);
                        }
                    }

                    if (Perishable == Convert.ToBoolean(1))
                    {
                        List<Database.ICIT_BR_TMP> listperishibal = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MYTRANSID == MYTRANSID && p.RecodName == "Perishable" && p.MyProdID == MyProdID && p.UOM == UOM).ToList();
                        foreach (Database.ICIT_BR_TMP Itemperishibal in listperishibal)
                        {
                            int COLORID = Itemperishibal.COLORID;
                            Reference = Itemperishibal.Reference.ToString();
                            Active = "Y";
                            int Bin_ID = Convert.ToInt32(Itemperishibal.Bin_ID);
                            SIZECODE = Itemperishibal.SIZECODE;
                            UOM = Itemperishibal.UOM;
                            string BatchNo = Itemperishibal.BatchNo.ToString();
                            DateTime ProdDate = Convert.ToDateTime(Itemperishibal.ProdDate);
                            DateTime ExpiryDate = Convert.ToDateTime(Itemperishibal.ExpiryDate);
                            DateTime LeadDays2Destroy = Convert.ToDateTime(Itemperishibal.LeadDays2Destroy);

                            PostICIT_BR_Perishable(TenentID, MyProdID, period_code, MySysName, UOM, BatchNo, LID, MYTRANSID, QTY, ProdDate, ExpiryDate, LeadDays2Destroy, Reference, Active, CRUP_ID, objsubtype);
                        }
                    }

                    if (Serialized == Convert.ToBoolean(1))
                    {
                        List<Database.ICIT_BR_TMP> listSerial = DB.ICIT_BR_TMP.Where(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID && p.UOM == UOM && p.Active == "D" && p.MySysName == MySysName && p.MyProdID == MyProdID && p.Serial_Number != "NO" && p.RecodName == "Serialize").ToList();
                        foreach (Database.ICIT_BR_TMP ItemSerial in listSerial)
                        {
                            int COLORID = ItemSerial.COLORID;
                            Reference = ItemSerial.Reference.ToString();
                            Active = "Y";
                            SIZECODE = ItemSerial.SIZECODE;
                            string Serial_Number = ItemSerial.Serial_Number.ToString();
                            string Flag_GRN_GTN = "N";
                            string UOM1 = ItemSerial.UOM.ToString();
                            bool MinusAllow = Convert.ToBoolean(ItemSerial.MinusAllow);
                            PostICIT_BR_Serialize(TenentID, MyProdID, period_code, MySysName, UOM1, Serial_Number, LID, MYTRANSID, Flag_GRN_GTN, Active, CRUP_ID, objsubtype, MinusAllow);
                        }
                    }

                    //objDT.ICPOST = "0";
                    //DB.SaveChanges();

                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public static void PostICIT_BR(int TenentID, int Location, int MYTRANSID, int MYPRODID, int UOM, string period_code, decimal NewQty, decimal UnitCost, string Bin_Per, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {
            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;

            Database.ICIT_BR objICIT_BR = new Database.ICIT_BR();
          
            if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MYPRODID && p.LocationID == Location).Count() > 0)
            {
                objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MYPRODID  && p.LocationID == Location);

                DataTable brdt = DAL.Get_ICIT_BR(TenentID, MYPRODID, Location);
                if (brdt.Rows.Count > 0)
                {
                    OPQTY = Convert.ToDecimal(brdt.Rows[0]["OpQty"]);
                    ONHANDQTY = Convert.ToDecimal(brdt.Rows[0]["OnHand"]);
                    QtyOut = Convert.ToDecimal(brdt.Rows[0]["QtyOut"]);
                    QtyConsumed = Convert.ToDecimal(brdt.Rows[0]["QtyConsumed"]);
                    QtyReserved = Convert.ToDecimal(brdt.Rows[0]["QtyReserved"]);
                    QtyReceived = Convert.ToDecimal(brdt.Rows[0]["QtyReceived"]);
                }
                    //------------------ OpQtyBeh   ---------------------------------//
                    if (objsubtype.OpQtyBeh == "+")
                {
                    OPQTY = OPQTY + NewQty;
                }
                else if (objsubtype.OpQtyBeh == "-")
                {
                    OPQTY = OPQTY - NewQty;
                }
                else { }

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }


                ////----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


               // ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);
                ONHANDTOTAL = ONHANDQTY + NewQty;



            }
            else
            {

                objICIT_BR.MySysName = objsubtype.MYSYSNAME;
                objICIT_BR.UnitCost = UnitCost;

                //------------------ OpQtyBeh   ---------------------------------//
                if (objsubtype.OpQtyBeh == "+")
                {
                    OPQTY = OPQTY + NewQty;
                }
                else if (objsubtype.OpQtyBeh == "-")
                {
                    OPQTY = OPQTY - NewQty;
                }
                else { }

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }


                ////----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


                RoleFlag = true;

            }

            objICIT_BR.TenentID = TenentID;
            objICIT_BR.MyProdID = MYPRODID;
            objICIT_BR.period_code = period_code;
            objICIT_BR.UOM = UOM;
            objICIT_BR.LocationID = Location;
            objICIT_BR.MYTRANSID = MYTRANSID;
            objICIT_BR.Bin_Per = Bin_Per;
            objICIT_BR.OpQty = OPQTY;
            objICIT_BR.OnHand = ONHANDTOTAL;
            objICIT_BR.QtyOut = QtyOut;
            objICIT_BR.QtyConsumed = QtyConsumed;
            objICIT_BR.QtyReserved = QtyReserved;
            objICIT_BR.QtyReceived = QtyReceived;
            objICIT_BR.Reference = Reference;
            objICIT_BR.Active = Active;
            objICIT_BR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
            {
                DB.ICIT_BR.AddObject(objICIT_BR);
            }
            DB.SaveChanges();

            if (DB.TBLPRODUCTs.Where(p => p.TenentID == TenentID && p.UOM == UOM && p.MYPRODID == MYPRODID).Count() == 1)
            {
                Database.TBLPRODUCT obj = DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.UOM == UOM && p.MYPRODID == MYPRODID);
                obj.QTYINHAND = ONHANDTOTAL;
                DB.SaveChanges();
            }

            objICIT_BR = null;
        }

        public static void PostTBLProduct(int TenentID, int Location, decimal QTY, TBLPRODUCT objTBLPRODUCT, tbltranssubtype objsubtype)
        {

            decimal Total, PQTY = 0;
            int Pid = Convert.ToInt32(objTBLPRODUCT.MYPRODID);
            Database.TBLPRODUCT obj = DB.TBLPRODUCTs.Single(p => p.TenentID == TenentID && p.MYPRODID == Pid);
            string sign = objsubtype.OnHandBeh.ToString();

            if (sign == "+")
            {
                PQTY = Convert.ToDecimal(obj.QTYINHAND);
                Total = QTY + PQTY;
                obj.QTYINHAND = Total;
                DB.SaveChanges();
            }
            else if (sign == "-")
            {
                PQTY = Convert.ToDecimal(obj.QTYINHAND);
                Total = PQTY - QTY;
                obj.QTYINHAND = Total;
                DB.SaveChanges();
            }
            else { }
        }

        public static void PostICIT_BR_SIZECOLOR(int TenentID, int Location, int MYTRANSID, int MyProdID, int UOM, string period_code, int SIZECODE, int COLORID, decimal NewQty, decimal UnitCost, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            Database.ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new Database.ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;
            decimal Qtyofoled = 0;
            decimal Qtyofnew = 0;

            if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
            {
                objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                OPQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReceived);


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //check if toTenentID != null

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                //----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_SIZECOLOR.MySysName = "IC";


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //check if toTenentID != null

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    // QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                //----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    //QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    //QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//


                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);
                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();


        }

        public static void PostICIT_BR_SIZE(int TenentID, int Location, int MYTRANSID, int MyProdID, int UOM, string period_code, int SIZECODE, int COLORID, decimal NewQty, decimal UnitCost, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            Database.ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new Database.ICIT_BR_SIZECOLOR();
            bool RoleFlag = false;

            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;



            if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
            {
                objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                OPQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_SIZECOLOR.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_SIZECOLOR.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                ////----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_SIZECOLOR.MySysName = objsubtype.MYSYSNAME;

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                ////----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);

                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }


            objICIT_BR_SIZECOLOR.TenentID = TenentID;
            objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
            objICIT_BR_SIZECOLOR.period_code = period_code;

            objICIT_BR_SIZECOLOR.UOM = UOM;
            objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
            objICIT_BR_SIZECOLOR.COLORID = COLORID;
            objICIT_BR_SIZECOLOR.LocationID = Location;
            objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
            objICIT_BR_SIZECOLOR.OpQty = OPQTY;
            objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
            objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
            objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
            objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
            objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
            objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
            objICIT_BR_SIZECOLOR.MinQty = 0;
            objICIT_BR_SIZECOLOR.MaxQty = 0;
            objICIT_BR_SIZECOLOR.LeadTime = 0;
            objICIT_BR_SIZECOLOR.Reference = Reference;
            objICIT_BR_SIZECOLOR.Active = Active;
            objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
            DB.SaveChanges();

        }

        public static void PostICIT_BR_BIN(int TenentID, int Location, int MYTRANSID, int MyProdID, string MySysName, int UOM, string period_code, decimal NewQty, decimal UnitCost, string Bin_Per, string Reference, string Active, int CRUP_ID, int Bin_ID, tbltranssubtype objsubtype)
        {

            bool RoleFlag = false;
            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyConsumed = 0;
            decimal QtyReserved = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;
            decimal QTYOUTNEW = 0;
            decimal QTYINNEW = 0;
            Database.ICIT_BR_BIN objICIT_BR_BIN = new Database.ICIT_BR_BIN();



            if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
            {
                objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                OPQTY = Convert.ToDecimal(objICIT_BR_BIN.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_BIN.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_BIN.QtyOut);
                QtyConsumed = Convert.ToDecimal(objICIT_BR_BIN.QtyConsumed);
                QtyReserved = Convert.ToDecimal(objICIT_BR_BIN.QtyReserved);
                QtyReceived = Convert.ToDecimal(objICIT_BR_BIN.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;

                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    QtyOut = QtyOut + NewQty;

                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);


            }
            else
            {

                objICIT_BR_BIN.MySysName = MySysName;

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }

                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }

                //----------------- QtyConsumedBeh  -------------------------------//

                if (objsubtype.QtyConsumedBeh == "+")
                {
                    QtyConsumed = QtyConsumed + NewQty;
                }
                else if (objsubtype.QtyConsumedBeh == "-")
                {
                    QtyConsumed = QtyConsumed - NewQty;
                }
                else { }

                //----------------- QtyReservedBeh  -------------------------------//

                if (objsubtype.QtyReservedBeh == "+")
                {
                    QtyReserved = QtyReserved + NewQty;
                }
                else if (objsubtype.QtyReservedBeh == "-")
                {
                    QtyReserved = QtyReserved - NewQty;
                }
                else { }

                //----------------- QtyAtDestination  -------------------------------//

                //if (objsubtype.QtyAtDestination == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;
                //}
                //else if (objsubtype.QtyAtDestination == "-")
                //{
                //    QtyOut = QtyOut + NewQty;
                //}
                //else
                //{ }

                ////----------------- QtyAtSource  -------------------------------//

                //if (objsubtype.QtyAtSource == "+")
                //{
                //    QtyReceived = QtyReceived + NewQty;

                //}
                //else if (objsubtype.QtyAtSource == "-")
                //{
                //    QtyOut = QtyOut + NewQty;

                //}
                //else { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed + QtyReserved);

                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_BIN.TenentID = TenentID;
            objICIT_BR_BIN.MyProdID = MyProdID;
            objICIT_BR_BIN.period_code = period_code;
            objICIT_BR_BIN.Bin_ID = Bin_ID;
            objICIT_BR_BIN.UOM = UOM;
            objICIT_BR_BIN.LocationID = Location;
            objICIT_BR_BIN.MYTRANSID = MYTRANSID;
            objICIT_BR_BIN.OpQty = OPQTY;
            objICIT_BR_BIN.OnHand = ONHANDTOTAL;
            objICIT_BR_BIN.QtyOut = QtyOut;
            objICIT_BR_BIN.QtyConsumed = QtyConsumed;
            objICIT_BR_BIN.QtyReserved = QtyReserved;
            objICIT_BR_BIN.QtyReceived = QtyReceived;
            objICIT_BR_BIN.MinQty = 0;
            objICIT_BR_BIN.MaxQty = 0;
            objICIT_BR_BIN.LeadTime = 0;
            objICIT_BR_BIN.Reference = Reference;
            objICIT_BR_BIN.Active = Active;
            objICIT_BR_BIN.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_BIN.AddObject(objICIT_BR_BIN);
            DB.SaveChanges();


        }

        public static void PostICIT_BR_Perishable(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, string BatchNo, int Location, int MYTRANSID, decimal NewQty, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Reference, string Active, int CRUP_ID, tbltranssubtype objsubtype)
        {

            bool RoleFlag = false;

            decimal OPQTY = 0;
            decimal ONHANDQTY = 0;
            decimal QtyOut = 0;
            decimal QtyReceived = 0;
            decimal ONHANDTOTAL = 0;

            Database.ICIT_BR_Perishable objICIT_BR_Perishable = new Database.ICIT_BR_Perishable();

            if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
            {
                objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                OPQTY = Convert.ToDecimal(objICIT_BR_Perishable.OpQty);
                ONHANDQTY = Convert.ToDecimal(objICIT_BR_Perishable.OnHand);
                QtyOut = Convert.ToDecimal(objICIT_BR_Perishable.QtyOut);
                //QtyConsumed= Convert.ToInt32(objICIT_BR_Perishable)
                QtyReceived = Convert.ToDecimal(objICIT_BR_Perishable.QtyReceived);

                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }
                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }



                //----------------- QtyAtDestination  -------------------------------//

                if (objsubtype.QtyAtDestination == "+")
                {
                    QtyReceived = QtyReceived + NewQty;

                }
                else if (objsubtype.QtyAtDestination == "-")
                {
                    QtyOut = QtyOut + NewQty;

                }
                else
                { }



                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut);//+ QtyConsumed


            }
            else
            {

                objICIT_BR_Perishable.MySysName = MySysName;


                //------------------ QtyReceivedBeh   ---------------------------------//
                if (objsubtype.QtyReceivedBeh == "+")
                {
                    QtyReceived = QtyReceived + NewQty;
                }
                else if (objsubtype.QtyReceivedBeh == "-")
                {
                    QtyReceived = QtyReceived - NewQty;
                }
                else { }
                //----------------- QtyOutBeh  -------------------------------//

                if (objsubtype.QtyOutBeh == "+")
                {
                    QtyOut = QtyOut + NewQty;
                }
                else if (objsubtype.QtyOutBeh == "-")
                {
                    QtyOut = QtyOut - NewQty;
                }
                else { }



                //----------------- QtyAtDestination  -------------------------------//

                if (objsubtype.QtyAtDestination == "+")
                {
                    QtyReceived = QtyReceived + NewQty;

                }
                else if (objsubtype.QtyAtDestination == "-")
                {
                    QtyOut = QtyOut + NewQty;

                }
                else
                { }

                //----------------- OnHandBeh  -------------------------------//

                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut);//+ QtyConsumed
                //ONHANDTOTAL = NewQty;
                //QtyReceived = NewQty;
                RoleFlag = true;
            }

            objICIT_BR_Perishable.TenentID = TenentID;
            objICIT_BR_Perishable.MyProdID = MyProdID;
            objICIT_BR_Perishable.period_code = period_code;
            objICIT_BR_Perishable.UOM = UOM;
            objICIT_BR_Perishable.BatchNo = BatchNo;
            objICIT_BR_Perishable.LocationID = Location;
            objICIT_BR_Perishable.MYTRANSID = MYTRANSID;
            objICIT_BR_Perishable.OpQty = OPQTY;
            objICIT_BR_Perishable.OnHand = ONHANDTOTAL;
            objICIT_BR_Perishable.QtyOut = QtyOut;
            objICIT_BR_Perishable.QtyReceived = QtyReceived;
            objICIT_BR_Perishable.ProdDate = ProdDate;
            objICIT_BR_Perishable.ExpiryDate = ExpiryDate;
            objICIT_BR_Perishable.LeadDays2Destroy = LeadDays2Destroy;
            objICIT_BR_Perishable.Reference = Reference;
            objICIT_BR_Perishable.Active = Active;
            objICIT_BR_Perishable.CRUP_ID = CRUP_ID;
            if (RoleFlag == true)
                DB.ICIT_BR_Perishable.AddObject(objICIT_BR_Perishable);
            DB.SaveChanges();

        }

        public static void PostICIT_BR_Serialize(int TenentID, int MyProdID, string period_code, string MySysName, string UOM, string Serial_Number, int Location, int MyTransID, string Flag_GRN_GTN, string Active, int CRUP_ID, tbltranssubtype objsubtype, bool MinusAllow)
        {

            //if (objsubtype.MYSYSNAME == MySysName)
            //{
            if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            {
                Database.ICIT_BR_Serialize objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);

                objICIT_BR_Serialize.Serial_Number = Serial_Number;
                objICIT_BR_Serialize.Active = "N";
                objICIT_BR_Serialize.MinusAllow = MinusAllow;

                DB.SaveChanges();
            }
            else
            {
                Database.ICIT_BR_Serialize objICIT_BR_Serialize = new Database.ICIT_BR_Serialize();
                objICIT_BR_Serialize.MySysName = MySysName;
                objICIT_BR_Serialize.TenentID = TenentID;
                objICIT_BR_Serialize.MyProdID = MyProdID;
                objICIT_BR_Serialize.period_code = period_code;
                objICIT_BR_Serialize.UOM = UOM;
                objICIT_BR_Serialize.Serial_Number = Serial_Number;
                objICIT_BR_Serialize.LocationID = Location;
                objICIT_BR_Serialize.Flag_GRN_GTN = Flag_GRN_GTN;
                objICIT_BR_Serialize.MyTransID = MyTransID;
                objICIT_BR_Serialize.CRUP_ID = CRUP_ID;
                if (MinusAllow == true)
                {
                    objICIT_BR_Serialize.Active = "N";
                }
                else
                {
                    objICIT_BR_Serialize.Active = "Y";
                }

                objICIT_BR_Serialize.MinusAllow = MinusAllow;
                DB.ICIT_BR_Serialize.AddObject(objICIT_BR_Serialize);

                DB.SaveChanges();

            }
            //}




            // bool RoleFlag = false;
            //Database.ICIT_BR_Serialize objICIT_BR_Serialize = new Database.ICIT_BR_Serialize();


            //if (objsubtype.MYSYSNAME == MySysName)
            //{


            //    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            //    {
            //        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
            //    }
            //    else
            //    {

            //        objICIT_BR_Serialize.MySysName = MySysName;
            //        RoleFlag = true;
            //    }
            //}



            //objICIT_BR_Serialize.TenentID = TenentID;
            //objICIT_BR_Serialize.MyProdID = MyProdID;
            //objICIT_BR_Serialize.period_code = period_code;

            //objICIT_BR_Serialize.UOM = UOM;
            //objICIT_BR_Serialize.Serial_Number = Serial_Number;
            //objICIT_BR_Serialize.LocationID = Location;
            //objICIT_BR_Serialize.Flag_GRN_GTN = Flag_GRN_GTN;
            //objICIT_BR_Serialize.MyTransID = MyTransID;


            //objICIT_BR_Serialize.CRUP_ID = CRUP_ID;
            //if (RoleFlag == true)
            //{
            //    objICIT_BR_Serialize.Active = "Y";
            //    DB.ICIT_BR_Serialize.AddObject(objICIT_BR_Serialize);
            //}
            //else
            //    objICIT_BR_Serialize.Active = "Y";
            //DB.SaveChanges();



            //if (objsubtype.MYSYSNAME == "SAL")
            //{
            //    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            //    {
            //        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
            //    }
            //    else
            //    {
            //        objICIT_BR_Serialize = new ICIT_BR_Serialize();
            //        objICIT_BR_Serialize.MySysName = MySysName;
            //        RoleFlag = true;
            //    }
            //}
            //else if (objsubtype.MYSYSNAME == "PUR")
            //{
            //    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            //    {
            //        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
            //    }
            //    else
            //    {
            //        objICIT_BR_Serialize = new ICIT_BR_Serialize();
            //        objICIT_BR_Serialize.MySysName = MySysName;
            //        RoleFlag = true;
            //    }
            //}
            //else
            //{
            //    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
            //    {
            //        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
            //    }
            //    else
            //    {
            //        objICIT_BR_Serialize = new ICIT_BR_Serialize();
            //        objICIT_BR_Serialize.MySysName = MySysName;

            //        RoleFlag = true;
            //    }
            //}

        }
        public static void insertNewComapnySetupTry(int MYID, string Copmany, string UserName, int Packge, int NumOfUser, string email, string Mobile, int CountryID, string DatainserStatest)
        {
            Database.NewCompaniySetup_Tryel objNewCompaniySetup_Tryel = new Database.NewCompaniySetup_Tryel();
            bool flag = false;
            if (DatainserStatest == "Insert")
            {
                objNewCompaniySetup_Tryel = new Database.NewCompaniySetup_Tryel();
                objNewCompaniySetup_Tryel.TenentID = 0;
                objNewCompaniySetup_Tryel.MyID = DB.NewCompaniySetup_Tryel.Count() > 0 ? Convert.ToInt32(DB.NewCompaniySetup_Tryel.Max(p => p.MyID) + 1) : 1;
                objNewCompaniySetup_Tryel.LocationID = 1;
                flag = true;
            }
            else
            {
                objNewCompaniySetup_Tryel = DB.NewCompaniySetup_Tryel.Single(p => p.MyID == MYID);
            }
            objNewCompaniySetup_Tryel.CompanyName = Copmany;
            objNewCompaniySetup_Tryel.UserName = UserName;
            objNewCompaniySetup_Tryel.Package = Packge;
            objNewCompaniySetup_Tryel.NumberofUser = NumOfUser;
            objNewCompaniySetup_Tryel.EmailID = email;
            objNewCompaniySetup_Tryel.MobileNo = Mobile;
            objNewCompaniySetup_Tryel.Country = CountryID;
            objNewCompaniySetup_Tryel.Deleteby = true;
            objNewCompaniySetup_Tryel.ActiveBy = true;
            objNewCompaniySetup_Tryel.datetime = DateTime.Now;
            objNewCompaniySetup_Tryel.crupID = "0";
            if (flag == true)
            {
                DB.NewCompaniySetup_Tryel.AddObject(objNewCompaniySetup_Tryel);
            }
            DB.SaveChanges();
        }
        public static string Logo(int TID)
        {
            if (DB.MYCOMPANYSETUPs.Single(p => p.TenentID == TID).LogotoDisplay == null || DB.MYCOMPANYSETUPs.Single(p => p.TenentID == TID).LogotoDisplay == "")
            {
                return "No_image.png";
            }
            else
            {
                string DisplayLOGO = DB.MYCOMPANYSETUPs.Single(p => p.TenentID == TID).LogotoDisplay;
                return DisplayLOGO.ToString();
            }

        }

        public static String GetDateInMMDDYYY(string date)
        {

            // return date.Length < 9 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy",CultureInfo.InvariantCulture);
            return date.Length < 8 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString();

        }

        public static void UpdateActualDeliveryDate(int TID, int MYTRANSID, int DeliveryID, int MYPRODID, int NExtDeliveryNum, DateTime NExtDeliveryDate, DateTime ExpectedDelDate, int chiefID)
        {
            Database.planmealcustinvoiceHD objhd = DB.planmealcustinvoiceHDs.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID);
            objhd.NExtDeliveryNum = NExtDeliveryNum;
            objhd.NExtDeliveryDate = NExtDeliveryDate;
            DB.SaveChanges();

            Database.planmealcustinvoice objdt = DB.planmealcustinvoices.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.DeliveryID == DeliveryID && p.MYPRODID == MYPRODID);
            objdt.ActualDelDate = ExpectedDelDate;
            objdt.ProductionDate = ExpectedDelDate;
            objdt.chiefID = chiefID;
            DB.SaveChanges();
        }

        public static void driverChacklist_Delivered(int TID, int MYTRANSID, DateTime ActualDelDate, DateTime ExpectedDelDate, string stutas)
        {
            List<Database.planmealcustinvoice> ListInvoice = DB.planmealcustinvoices.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ToList();
            if (ListInvoice.Where(p => p.ExpectedDelDate == ExpectedDelDate).Count() > 0)
            {
                Database.planmealcustinvoice OBJ123 = ListInvoice.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.ExpectedDelDate == ExpectedDelDate).FirstOrDefault();
                int NExtDeliveryNum = OBJ123.DayNumber + 1;
                DateTime NexDelDate = ExpectedDelDate.AddDays(1);
                if (NexDelDate.DayOfWeek == DayOfWeek.Friday)
                {
                    NexDelDate = NexDelDate.AddDays(1);
                }

                List<Database.planmealcustinvoice> ListDt = ListInvoice.Where(p => p.ExpectedDelDate == ExpectedDelDate).ToList();

                foreach (Database.planmealcustinvoice items in ListDt)
                {
                    Database.planmealcustinvoice objdt = ListInvoice.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.DeliveryID == items.DeliveryID);
                    objdt.ActualDelDate = ActualDelDate;
                    objdt.NExtDeliveryDate = NexDelDate;
                    objdt.Status = "Delivered";
                    DB.SaveChanges();
                }

                List<Database.planmealcustinvoice> ListInvoice1 = DB.planmealcustinvoices.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ToList();
                List<Database.planmealcustinvoice> ListtotaldelDay = ListInvoice1.GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int totalDelDay = ListtotaldelDay.Count();

                List<Database.planmealcustinvoice> ListdelDay = ListInvoice1.Where(p => p.ActualDelDate != null).GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int DeliveredDays = ListdelDay.Count();

                List<Database.planmealcustinvoice> ListPEndingDay = ListInvoice1.Where(p => p.ActualDelDate == null).GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int PendingDays = ListPEndingDay.Count();

                Database.planmealcustinvoiceHD objhd = DB.planmealcustinvoiceHDs.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID);
                objhd.TotalSubDays = totalDelDay;
                objhd.DeliveredDays = DeliveredDays;
                objhd.NExtDeliveryNum = NExtDeliveryNum;
                objhd.NExtDeliveryDate = NexDelDate;
                if (PendingDays == 0)
                    objhd.CStatus = "Completed";
                if (DeliveredDays == 0)
                    objhd.CStatus = "Started";
                if (PendingDays != 0 && DeliveredDays != 0)
                    objhd.CStatus = "In Progress";
                DB.SaveChanges();

            }

        }

        public static void driverChacklist_Return(int TID, int MYTRANSID, DateTime ActualDelDate, DateTime ExpectedDelDate, int reasontype, DateTime ReasonDate)
        {
            List<Database.planmealcustinvoice> ListInvoice = DB.planmealcustinvoices.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ToList();
            if (ListInvoice.Where(p => p.ExpectedDelDate == ExpectedDelDate).Count() > 0)
            {
                Database.planmealcustinvoice OBJ123 = ListInvoice.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.ExpectedDelDate == ExpectedDelDate).FirstOrDefault();
                int NExtDeliveryNum = OBJ123.DayNumber + 1;

                DateTime NexDelDate = ExpectedDelDate.AddDays(1);
                if (NexDelDate.DayOfWeek == DayOfWeek.Friday)
                {
                    NexDelDate = NexDelDate.AddDays(1);
                }


                List<Database.planmealcustinvoice> ListDt = ListInvoice.Where(p => p.ExpectedDelDate == ExpectedDelDate).ToList();

                foreach (Database.planmealcustinvoice items in ListDt)
                {
                    Database.planmealcustinvoice objdt = DB.planmealcustinvoices.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID && p.DeliveryID == items.DeliveryID);
                    //objdt.ActualDelDate = ActualDelDate;
                    objdt.NExtDeliveryDate = NexDelDate;
                    objdt.ReturnReason = reasontype;
                    objdt.ReasonDate = ReasonDate;
                    objdt.Status = "Return";
                    DB.SaveChanges();
                }

                List<Database.planmealcustinvoice> ListInvoice1 = DB.planmealcustinvoices.Where(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID).ToList();
                List<Database.planmealcustinvoice> ListtotaldelDay = ListInvoice1.GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int totalDelDay = ListtotaldelDay.Count();

                List<Database.planmealcustinvoice> ListdelDay = ListInvoice1.Where(p => p.ActualDelDate != null).GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int DeliveredDays = ListdelDay.Count();

                List<Database.planmealcustinvoice> ListPEndingDay = ListInvoice1.Where(p => p.ActualDelDate == null).GroupBy(p => p.DayNumber).Select(p => p.FirstOrDefault()).ToList();
                int PendingDays = ListPEndingDay.Count();

                Database.planmealcustinvoiceHD objhd = DB.planmealcustinvoiceHDs.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID);
                objhd.TotalSubDays = totalDelDay;
                objhd.DeliveredDays = DeliveredDays;
                objhd.NExtDeliveryNum = NExtDeliveryNum;
                objhd.NExtDeliveryDate = NexDelDate;
                if (PendingDays == 0)
                    objhd.CStatus = "Completed";
                if (DeliveredDays == 0)
                    objhd.CStatus = "Started";
                if (PendingDays != 0 && DeliveredDays != 0)
                    objhd.CStatus = "In Progress";
                DB.SaveChanges();

            }

        }

        public static void FoodSubcriberChangeInsert(int TID, int CID, int LID, char CH, int parameter, decimal wight, int LikeItem, int DisLikeitem, int ComplainItem, int AllergyItem, string DelivieryTime1, int Plan, int MealDeliver, string LikeRemark1, string DisLikeRemark1, string ComplainRemark1, string Alergie, DateTime DateAdded, string WeightRemark, DateTime ComplainDate)
        {
            Database.tblcontact_addon1_dtl objtblcontact_addon1_dtl = new tblcontact_addon1_dtl();
            objtblcontact_addon1_dtl.TenentID = TID;
            objtblcontact_addon1_dtl.LocationID = LID;
            objtblcontact_addon1_dtl.customerID = CID;// Convert.ToInt32(drpCustomerId.SelectedValue);
            objtblcontact_addon1_dtl.myID = DB.tblcontact_addon1_dtl.Where(p => p.TenentID == TID && p.LocationID == LID && p.customerID == CID).Count() > 0 ? DB.tblcontact_addon1_dtl.Where(p => p.TenentID == TID && p.LocationID == LID && p.customerID == CID).Max(p => p.myID) + 1 : 1;
            objtblcontact_addon1_dtl.LikeType = CH.ToString();
            if (parameter == 1)
            {
                objtblcontact_addon1_dtl.Weight = wight;//Convert.ToDecimal(txtwight.Text);
            }
            else if (parameter == 2)
            {
                objtblcontact_addon1_dtl.LikeId = LikeItem; //Convert.ToInt32(drpItem.SelectedValue);
            }
            else if (parameter == 3)
            {
                objtblcontact_addon1_dtl.LikeId = DisLikeitem;// Convert.ToInt32(drpitems.SelectedValue);
            }
            else if (parameter == 4)
            {
                objtblcontact_addon1_dtl.ComplinID = ComplainItem; //Convert.ToInt32(drpcomplinid.SelectedValue);
            }
            else if (parameter == 5)
            {
                objtblcontact_addon1_dtl.Allergy = AllergyItem; //Convert.ToInt32(drpAllergy.SelectedValue);
            }
            else if (parameter == 6)
            {
                objtblcontact_addon1_dtl.DeliveryTime = DelivieryTime1;//drpDelivieryTime1.SelectedValue;
                objtblcontact_addon1_dtl.planid = Plan;//Convert.ToInt32(drpPlan.SelectedValue);
            }
            else
            {

            }
            objtblcontact_addon1_dtl.DateAdded = DateTime.Now;
            if (CH == 'L')
            {
                objtblcontact_addon1_dtl.ItemCode = LikeItem; //Convert.ToInt32(drpItem.SelectedValue);
            }
            if (CH == 'A')
            {
                objtblcontact_addon1_dtl.ItemCode = AllergyItem; //Convert.ToInt32(drpAllergy.SelectedValue);
            }
            if (CH == 'D')
            {
                objtblcontact_addon1_dtl.ItemCode = DisLikeitem;//Convert.ToInt32(drpitems.SelectedValue);
            }
            if (CH == 'M')
            {
                objtblcontact_addon1_dtl.ItemCode = MealDeliver; //Convert.ToInt32(drpMealDeliver.SelectedValue);
            }

            if (parameter == 1)
            {
                objtblcontact_addon1_dtl.DateAdded = DateAdded;//Convert.ToDateTime(txtdate.Text);
                objtblcontact_addon1_dtl.Remarks = WeightRemark;//txtRemarks.Text;                
            }
            else if (parameter == 2)
            {
                objtblcontact_addon1_dtl.Remarks = LikeRemark1;//txtremark.Text;
            }
            else if (parameter == 3)
            {
                objtblcontact_addon1_dtl.Remarks = DisLikeRemark1;//txtrem.Text;
            }
            else if (parameter == 4)
            {
                objtblcontact_addon1_dtl.DateAdded = ComplainDate;
                objtblcontact_addon1_dtl.Remarks = ComplainRemark1;// txtrema.Text;
            }
            else if (parameter == 5)
            {
                objtblcontact_addon1_dtl.Remarks = Alergie;//txtremak.Text;
            }
            else if (parameter == 6)
            {
                objtblcontact_addon1_dtl.Remarks = MealDeliver.ToString();//drpMealDeliver.SelectedValue;
            }
            else
            {

            }
            objtblcontact_addon1_dtl.active = true;
            DB.tblcontact_addon1_dtl.AddObject(objtblcontact_addon1_dtl);
            DB.SaveChanges();
        }
        public static void FoodSubcriberChangeUpdate(int TID, int CID, int LID, char CH, int Parame, int myid, decimal wight, int LikeItem, int DisLikeitem, int ComplainItem, int AllergyItem, string DelivieryTime1, int Plan, int MealDeliver, string LikeRemark1, string DisLikeRemark1, string ComplainRemark1, string Alergie, DateTime DateAdded, string WeightRemark, DateTime ComplainDate)
        {

            Database.tblcontact_addon1_dtl objtblcontact_addon1_dtl = DB.tblcontact_addon1_dtl.Single(p => p.TenentID == TID && p.LocationID == 1 && p.customerID == CID && p.myID == myid);
            //objtblcontact_addon1_dtl.LikeType = CH.ToString();
            if (Parame == 1)
            {
                objtblcontact_addon1_dtl.Weight = wight;//Convert.ToDecimal(txtwight.Text);
            }
            else if (Parame == 2)
            {
                objtblcontact_addon1_dtl.LikeId = LikeItem; //Convert.ToInt32(drpItem.SelectedValue);
            }
            else if (Parame == 3)
            {
                objtblcontact_addon1_dtl.LikeId = DisLikeitem;// Convert.ToInt32(drpitems.SelectedValue);
            }
            else if (Parame == 4)
            {
                objtblcontact_addon1_dtl.ComplinID = ComplainItem; //Convert.ToInt32(drpcomplinid.SelectedValue);
            }
            else if (Parame == 5)
            {
                objtblcontact_addon1_dtl.Allergy = AllergyItem; //Convert.ToInt32(drpAllergy.SelectedValue);
            }
            else if (Parame == 6)
            {
                objtblcontact_addon1_dtl.DeliveryTime = DelivieryTime1;//drpDelivieryTime1.SelectedValue;
                objtblcontact_addon1_dtl.planid = Plan;//Convert.ToInt32(drpPlan.SelectedValue);
            }
            else
            {

            }
            objtblcontact_addon1_dtl.DateAdded = DateTime.Now;
            if (CH == 'L')
            {
                objtblcontact_addon1_dtl.ItemCode = LikeItem; //Convert.ToInt32(drpItem.SelectedValue);
            }
            if (CH == 'A')
            {
                objtblcontact_addon1_dtl.ItemCode = AllergyItem; //Convert.ToInt32(drpAllergy.SelectedValue);
            }
            if (CH == 'D')
            {
                objtblcontact_addon1_dtl.ItemCode = DisLikeitem;//Convert.ToInt32(drpitems.SelectedValue);
            }
            if (CH == 'M')
            {
                objtblcontact_addon1_dtl.ItemCode = MealDeliver; //Convert.ToInt32(drpMealDeliver.SelectedValue);
            }

            if (Parame == 1)
            {
                objtblcontact_addon1_dtl.DateAdded = DateAdded;//Convert.ToDateTime(txtdate.Text);
                objtblcontact_addon1_dtl.Remarks = WeightRemark;//txtRemarks.Text;                
            }
            else if (Parame == 2)
            {
                objtblcontact_addon1_dtl.Remarks = LikeRemark1;//txtremark.Text;
            }
            else if (Parame == 3)
            {
                objtblcontact_addon1_dtl.Remarks = DisLikeRemark1;//txtrem.Text;
            }
            else if (Parame == 4)
            {
                objtblcontact_addon1_dtl.DateAdded = ComplainDate;
                objtblcontact_addon1_dtl.Remarks = ComplainRemark1;// txtrema.Text;
            }
            else if (Parame == 5)
            {
                objtblcontact_addon1_dtl.Remarks = Alergie;//txtremak.Text;
            }
            else if (Parame == 6)
            {
                objtblcontact_addon1_dtl.Remarks = MealDeliver.ToString();//drpMealDeliver.SelectedValue;
            }
            else
            {

            }
            objtblcontact_addon1_dtl.active = true;
            DB.SaveChanges();
        }

        public static void update_SubcriptionSetup(int TenentID = 0, int locationID = 1)
        {
            if (DB.tblSubscriptionSetups.Where(p => p.TenentID == TenentID && p.locationID == locationID).Count() > 0)
            {

                string Virsion = DB.tblSubscriptionSetups.Where(p => p.TenentID == TenentID && p.locationID == locationID).Count() > 0 ? DB.tblSubscriptionSetups.Where(p => p.TenentID == TenentID && p.locationID == locationID).FirstOrDefault().permversion.ToString() : "1.0";

                if (Virsion.Contains('.') == false)
                {
                    Virsion = Virsion + ".0";
                }

                string[] SplitVirsion = Virsion.Trim().Split('.');

                int vi = Convert.ToInt32(SplitVirsion[1].ToString()) + 1;

                string IncVirsion = SplitVirsion[0].ToString() + "." + vi;


                Database.tblSubscriptionSetup Obj = DB.tblSubscriptionSetups.Where(p => p.TenentID == TenentID && p.locationID == locationID).FirstOrDefault();
                Obj.permsyncdate = DateTime.Now;
                Obj.permversion = IncVirsion;
                DB.SaveChanges();
            }
        }




        //public static void insertICIT_BR_TMP(int TID = 0, int MyProdID = 0, string period_code = null, string MYSYSNAME = null, int UOM = 0, int SIZECODE = 0, int COLORID = 0, int BIN_ID = 0, string BatchNo = null, string Serialize = null, int MYTRANSID = 0, int LID = 0, int QUANTITY = 0, string REFERENCE = null, string RecodName = null, DateTime? ProdDate = null, DateTime? ExpiryDate = null, DateTime? LeadDays2Destroy = null, string Active = null, int CRUP_ID = 0)
        //{
        //    int UOM1 = Convert.ToInt32(UOM);

        //    if (DB.ICIT_BR_TMP.Where(p => p.TenentID == TID && p.LocationID == LID && p.period_code == period_code && p.UOM == UOM1 && p.MyProdID == MyProdID && p.COLORID == COLORID && p.SIZECODE == SIZECODE && p.MYTRANSID == MYTRANSID).Count() == 1)
        //    {
        //        ICIT_BR_TMP objICIT_BR_TMP = new ICIT_BR_TMP();
        //        objICIT_BR_TMP.TenentID = TID;
        //        objICIT_BR_TMP.MyProdID = MyProdID;
        //        objICIT_BR_TMP.period_code = period_code;
        //        objICIT_BR_TMP.MySysName = MYSYSNAME;
        //        objICIT_BR_TMP.UOM = UOM1;
        //        objICIT_BR_TMP.SIZECODE = SIZECODE;
        //        objICIT_BR_TMP.COLORID = COLORID;
        //        objICIT_BR_TMP.Bin_ID = BIN_ID;
        //        objICIT_BR_TMP.BatchNo = BatchNo;
        //        objICIT_BR_TMP.Serial_Number = Serialize;
        //        objICIT_BR_TMP.MYTRANSID = MYTRANSID;
        //        objICIT_BR_TMP.LocationID = LID;
        //        if (DB.ICIT_BR.Where(p => p.TenentID == TID && p.LocationID == LID && p.period_code == period_code && p.UOM == UOM1 && p.MyProdID == MyProdID).Count() == 1)
        //        {
        //            ICIT_BR obj = DB.ICIT_BR.Single(p => p.TenentID == TID && p.LocationID == LID && p.period_code == period_code && p.UOM == UOM1 && p.MyProdID == MyProdID);
        //            objICIT_BR_TMP.OpQty = obj.OpQty;
        //            objICIT_BR_TMP.OnHand = obj.OnHand;
        //            objICIT_BR_TMP.QtyOut = obj.QtyOut;
        //            objICIT_BR_TMP.QtyConsumed = obj.QtyConsumed;
        //            objICIT_BR_TMP.QtyReserved = obj.QtyReserved;
        //            objICIT_BR_TMP.QtyReceived = obj.QtyReceived;
        //            objICIT_BR_TMP.MinQty = obj.MinQty;
        //            objICIT_BR_TMP.MaxQty = obj.MaxQty;
        //            objICIT_BR_TMP.LeadTime = obj.LeadTime;
        //        }
        //        else
        //        {
        //            objICIT_BR_TMP.OpQty = 0;
        //            objICIT_BR_TMP.OnHand = 0;
        //            objICIT_BR_TMP.QtyOut = 0;
        //            objICIT_BR_TMP.QtyConsumed = 0;
        //            objICIT_BR_TMP.QtyReserved = 0;
        //            objICIT_BR_TMP.MinQty = 0;
        //            objICIT_BR_TMP.QtyReceived = 0;
        //            objICIT_BR_TMP.MaxQty = 0;
        //            objICIT_BR_TMP.LeadTime = 0;
        //        }
        //        objICIT_BR_TMP.NewQty = QUANTITY;
        //        objICIT_BR_TMP.Reference = REFERENCE;
        //        objICIT_BR_TMP.RecodName = RecodName;
        //        objICIT_BR_TMP.ProdDate = ProdDate;
        //        objICIT_BR_TMP.ExpiryDate = ExpiryDate;
        //        objICIT_BR_TMP.LeadDays2Destroy = LeadDays2Destroy;
        //        objICIT_BR_TMP.Active = Active;
        //        objICIT_BR_TMP.CRUP_ID = CRUP_ID;

        //        DB.SaveChanges();
        //    }
        //    else
        //    {

        //        ICIT_BR_TMP objICIT_BR_TMP = new ICIT_BR_TMP();
        //        objICIT_BR_TMP.TenentID = TID;
        //        objICIT_BR_TMP.MyProdID = MyProdID;
        //        objICIT_BR_TMP.period_code = period_code;
        //        objICIT_BR_TMP.MySysName = MYSYSNAME;
        //        objICIT_BR_TMP.UOM = UOM1;
        //        objICIT_BR_TMP.SIZECODE = SIZECODE;
        //        objICIT_BR_TMP.COLORID = COLORID;
        //        objICIT_BR_TMP.Bin_ID = BIN_ID;
        //        objICIT_BR_TMP.BatchNo = BatchNo;
        //        objICIT_BR_TMP.Serial_Number = Serialize;
        //        objICIT_BR_TMP.MYTRANSID = MYTRANSID;
        //        objICIT_BR_TMP.LocationID = LID;
        //        if (DB.ICIT_BR.Where(p => p.TenentID == TID && p.LocationID == LID && p.period_code == period_code && p.UOM == UOM1 && p.MyProdID == MyProdID).Count() == 1)
        //        {
        //            ICIT_BR obj = DB.ICIT_BR.Single(p => p.TenentID == TID && p.LocationID == LID && p.period_code == period_code && p.UOM == UOM1 && p.MyProdID == MyProdID);
        //            objICIT_BR_TMP.OpQty = obj.OpQty;
        //            objICIT_BR_TMP.OnHand = obj.OnHand;
        //            objICIT_BR_TMP.QtyOut = obj.QtyOut;
        //            objICIT_BR_TMP.QtyConsumed = obj.QtyConsumed;
        //            objICIT_BR_TMP.QtyReserved = obj.QtyReserved;
        //            objICIT_BR_TMP.QtyReceived = obj.QtyReceived;
        //            objICIT_BR_TMP.MinQty = obj.MinQty;
        //            objICIT_BR_TMP.MaxQty = obj.MaxQty;
        //            objICIT_BR_TMP.LeadTime = obj.LeadTime;
        //        }
        //        else
        //        {
        //            objICIT_BR_TMP.OpQty = 0;
        //            objICIT_BR_TMP.OnHand = 0;
        //            objICIT_BR_TMP.QtyOut = 0;
        //            objICIT_BR_TMP.QtyConsumed = 0;
        //            objICIT_BR_TMP.QtyReserved = 0;
        //            objICIT_BR_TMP.MinQty = 0;
        //            objICIT_BR_TMP.QtyReceived = 0;
        //            objICIT_BR_TMP.MaxQty = 0;
        //            objICIT_BR_TMP.LeadTime = 0;
        //        }
        //        objICIT_BR_TMP.NewQty = QUANTITY;
        //        objICIT_BR_TMP.Reference = REFERENCE;
        //        objICIT_BR_TMP.RecodName = RecodName;
        //        objICIT_BR_TMP.ProdDate = ProdDate;
        //        objICIT_BR_TMP.ExpiryDate = ExpiryDate;
        //        objICIT_BR_TMP.LeadDays2Destroy = LeadDays2Destroy;
        //        objICIT_BR_TMP.Active = Active;
        //        objICIT_BR_TMP.CRUP_ID = CRUP_ID;
        //        DB.ICIT_BR_TMP.AddObject(objICIT_BR_TMP);
        //        DB.SaveChanges();
        //    }
        //}


    }
}
