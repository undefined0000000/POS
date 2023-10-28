using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace Classes
{

    public static class CRMClass
    {
        public static List<TBLCOMPANYSETUP> getDataTBLCOMPANYSETUP(int TID)//haresh
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLCOMPANYSETUP> List = new List<TBLCOMPANYSETUP>();
            var objChache = DB.Cache_Mst.Single(p => p.TableName == "TBLCOMPANYSETUP");
            if (objChache.IsCache == false)
            {
                if (System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] != null)
                    List = ((List<TBLCOMPANYSETUP>)System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"]).ToList();
                else
                {
                    List = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "Y" && p.TenentID==TID).OrderBy(m => m.COMPNAME1).ToList();
                    System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] = List;
                    objChache.IsCache = false;
                    DB.SaveChanges();
                }
            }
            else
            {
                List = DB.TBLCOMPANYSETUPs.Where(p => p.Active == "Y" && p.TenentID==TID).OrderBy(m => m.COMPNAME1).ToList();
                System.Web.HttpContext.Current.Cache["TBLCOMPANYSETUP"] = List;
                objChache.IsCache = false;
                DB.SaveChanges();
            }
            return List;
        }
        //===================Bind a Table For QuestionMaster.aspx.cs=========================

        public static List<QuestionMaster> getdataQuestionMaster(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<QuestionMaster> list = new List<QuestionMaster>();
            list = DB.QuestionMasters.Where(p => p.Avtive == true && p.TenentID==TID).OrderBy(m => m.ID).ToList();
            DB.SaveChanges();
            return list;
        }
        //public static List<QuestionMaster> getdataQuestionMaster()
        //{
        //    Database.CallEntities DB = new Database.CallEntities();
        //    List<QuestionMaster> List = new List<QuestionMaster>();

        //    if (System.Web.HttpContext.Current.Cache["QuestionMaster"] != null)
        //    {
        //        List = ((List<QuestionMaster>)System.Web.HttpContext.Current.Cache["QuestionMaster"]).ToList();
        //    }
        //    else
        //    {
        //        List = DB.QuestionMaster.Where(p => p.Avtive == true).OrderBy(m => m.ID).ToList();
        //        System.Web.HttpContext.Current.Cache["TBLGROUP"] = List;
        //        //objChache.IsCache = false;
        //        DB.SaveChanges();
        //    }
        //    return List;
        //}
        public static List<TBLGROUP> getdataTBLGROUP(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLGROUP> List = new List<TBLGROUP>();

            //var objChache = DB.CRM_Cache_Mst.Single(p => p.TableName == "TBLGROUP");
            //if (objChache.IsCache == false)
            //{
            //if (System.Web.HttpContext.Current.Cache["TBLGROUP"] != null)
            //    List = ((List<TBLGROUP>)System.Web.HttpContext.Current.Cache["TBLGROUP"]).ToList();
            //else
            //{
            List = DB.TBLGROUPs.Where(p => p.ACTIVE == "1" && p.TenentID==TID).OrderBy(m => m.ITGROUPDESC1).ToList();
            //System.Web.HttpContext.Current.Cache["TBLGROUP"] = List;
            //objChache.IsCache = false;
            DB.SaveChanges();
            //}
            //}
            //else
            //{
            //List = DB.TBLGROUP.Where(p => p.ACTIVE == "Y").OrderBy(m => m.ITGROUPDESC1).ToList();
            //System.Web.HttpContext.Current.Cache["TBLGROUP"] = List;
            //objChache.IsCache = false;
            //DB.SaveChanges();
            //}
            return List;
        }

        public static List<IsChoice> getdataIsChoice(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<IsChoice> List = new List<IsChoice>();
            List = DB.IsChoices.Where(p => p.Active == true && p.TenentID==TID).OrderBy(m => m.ChoiceType).ToList();
            DB.SaveChanges();
            return List;

        }
        public static List<CAT_MST> getdataCAT_MST(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<CAT_MST> List = new List<CAT_MST>();
            List = DB.CAT_MST.Where(p => p.Active == "1" && p.TenentID == TID).OrderBy(m => m.CAT_NAME1).ToList();
            DB.SaveChanges();
            return List;
        }
        //===================Bind a Table For Campaign_Mst.aspx.cs=========================
        public static List<REFTABLE> getdataREFTABLE(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<REFTABLE> List = new List<REFTABLE>();
            List = DB.REFTABLEs.Where(p => p.ACTIVE == "Y" && p.TenentID==TID).ToList();
            //List = DB.REFTABLE.Where(p.REFTYPE == "CRM" && p.REFSUBTYPE == "Campaign Type");
            DB.SaveChanges();
            return List;
        }
        public static List<ISCampignStatu> getdataISCampignStatus(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<ISCampignStatu> List = new List<ISCampignStatu>();
            //List = DB.ISCampignStatus.ToList();
            List = DB.ISCampignStatus.Where(p => p.Active == true).OrderBy(m => m.ID).ToList();
            DB.SaveChanges();
            return List;
        }
        //===================Bind a Table For Opportunity_Mst.aspx.cs=========================
        public static List<TBLCONTACT> getdataTBLCONTACT(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLCONTACT> List = new List<TBLCONTACT>();
            List = DB.TBLCONTACTs.Where(p => p.Active == "Y" && p.TenentID==TID).ToList();
            DB.SaveChanges();
            return List;
        }
        //public static List<TBLPROJECT> getdataTBLPROJECT()
        //{
        //    Database.CallEntities DB = new Database.CallEntities();
        //    List<TBLPROJECT> List = new List<TBLPROJECT>();
        //    List = DB.TBLPROJECTs.Where(p => p.ACTIVE == true).ToList();
        //    DB.SaveChanges();
        //    return List;
        //}
        public static List<tbl_Campaign_Mst> getdatatbl_Campaign_Mst(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tbl_Campaign_Mst> List = new List<tbl_Campaign_Mst>();
            List = DB.tbl_Campaign_Mst.Where(p => p.Active == true && p.TenentID==TID).ToList();
            DB.SaveChanges();
            return List;
        }
        //===================Bind a Table For CRM_tbl_Lead Mst_Mst.aspx.cs=========================
        public static List<TBLCOMPANYSETUP> getdataTBLCOMPANYSETUP(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<TBLCOMPANYSETUP> List = new List<TBLCOMPANYSETUP>();
            List = DB.TBLCOMPANYSETUPs.ToList();
            DB.SaveChanges();
            return List;
        }
        public static List<tbl_Opportunity_Mst> getdatatbl_Opportunity_Mst(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<tbl_Opportunity_Mst> List = new List<tbl_Opportunity_Mst>();
            List = DB.tbl_Opportunity_Mst.Where(p => p.Active == true && p.TenentID==TID).ToList();
            DB.SaveChanges();
            return List;
        }
        public static List<ISDepartment1> getdataISDepartment1(int TID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            List<ISDepartment1> List = new List<ISDepartment1>();
            List = DB.ISDepartment1.Where(p => p.Active == true && p.TenentID==TID).ToList();
            DB.SaveChanges();
            return List;
        }
        public static DropDownList getcrmdropdown(DropDownList drp, int TID, string switch1, string switch2, string switch3, string TableName)
        {
            //if (TableName == "REFTABLE")
            //{
            //    //if (switch3 != "")
            //    //{
            //    //    drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == switch1 && p.REFSUBTYPE == switch2 && p.SWITCH2 == switch3);
            //    //    drp.DataTextField = "REFNAME1";
            //    //    drp.DataValueField = "REFID";
            //    //    drp.DataBind();
            //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            //    //}
            //    //else
            //    //{
            //    //    //DrpCampaignType.DataSource = DB.REFTABLE.Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "Campaign Type");
            //    //    drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == switch1 && p.REFSUBTYPE == switch2);
            //    //    drp.DataTextField = "REFNAME1";
            //    //    drp.DataValueField = "REFID";
            //    //    drp.DataBind();
            //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            //    //}

            //}
            //else
            if (TableName == "QuestionMaster")
            {
                drp.DataSource = getdataQuestionMaster(TID).Where(P => P.Avtive == true && P.Deleted == true &&  P.Perent_QID == 0);
                drp.DataTextField = "QuestionLang1";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            else if (TableName == "CAT_MST")
            {
                //drp.DataSource = DB.CAT_MST.Where(P => P.TenentID == TID && P.CAT_TYPE == "QUESTION" && P.Active == "1");
                if (switch2 != "")
                {
                    int CATID = Convert.ToInt32(switch1);
                    drp.DataSource = getdataCAT_MST(TID).Where(p => p.PARENT_CATID == CATID && p.TenentID == TID);
                }
                else if (switch3 == "WEBSALE")
                {
                    drp.DataSource = getdataCAT_MST(TID).Where(p => p.CAT_TYPE == "WEBSALE" && p.TenentID == TID && p.PARENT_CATID == 0);

                }
                else if (switch1 == "CAT")
                {
                    drp.DataSource = getdataCAT_MST(TID).Where(p => p.Active == "1" && p.PARENT_CATID == 0);
                }
                else
                {
                    drp.DataSource = getdataCAT_MST(TID).Where(p => p.CAT_TYPE == "QUESTION");

                }
                drp.DataTextField = "CAT_NAME1";
                drp.DataValueField = "CATID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            else if (TableName == "IsChoice")
            {
                drp.DataSource = getdataIsChoice(TID).Where(P => P.Active == true);
                drp.DataTextField = "ChoiceType";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            else if (TableName == "ISCampignStatus")
            {
                drp.DataSource = getdataISCampignStatus(TID).Where(p => p.Active == true && p.Deleted == true);
                drp.DataTextField = "Status";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            else if (TableName == "TBLCONTACT")
            {
                drp.DataSource = getdataTBLCONTACT(TID).Where(P => P.Active == "Y").OrderBy(p => p.PersName1);
                drp.DataTextField = "PersName1";
                drp.DataValueField = "ContactMyID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            //else if (TableName == "TBLPROJECT")
            //{
            //    drp.DataSource = getdataTBLPROJECT().Where(p => p.TenentID == TID);
            //    drp.DataTextField = "PROJECTNAME1";
            //    drp.DataValueField = "PROJECTID";
            //    drp.DataBind();
            //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            //}
            else if (TableName == "tbl_Campaign_Mst")
            {
                drp.DataSource = getdatatbl_Campaign_Mst(TID).Where(p => p.Active == true && p.Deleted == true);
                drp.DataTextField = "Name";
                drp.DataValueField = "ID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }

         
            //else if (TableName == "tbl_Opportunity_Msts")
            //{
            //    drp.DataSource = getdatatbl_Opportunity_Mst(TID).Where(p => p.Active == true && p.Deleted == true);
            //    drp.DataTextField = "Name";
            //    drp.DataValueField = "ID";
            //    drp.DataBind();
            //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            //}
            else if (TableName == "TBLCOMPANYSETUP")
            {
                //    if (switch1 != null)

                //        drp.DataSource = getdataTBLCOMPANYSETUP().Where(P => P.TenentID == TID && P.Approved == 1 && P.BUYER == true);


                //    else

                drp.DataSource = getDataTBLCOMPANYSETUP(TID).Where(P => P.Approved == 1);
                drp.DataTextField = "COMPNAME1";
                drp.DataValueField = "COMPID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));

            }
            else if (TableName == "tbl_Opportunity_Mst")
            {
                drp.DataSource = getdatatbl_Opportunity_Mst(TID).Where(P => P.Deleted == true && P.Active == true);
                drp.DataTextField = "Name";
                drp.DataValueField = "OpportID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
            else if (TableName == "ISDepartment1")
            {
                drp.DataSource = getdataISDepartment1(TID).Where(p => p.Active == true && p.Deleted == true);
                drp.DataTextField = "DepartmentName1";
                drp.DataValueField = "DepartmentID";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-- Select --", "0"));
            }

            //else if (TableName == "TBLGROUP")
            //{
            //    //drp.DataSource = DB.TBLGROUP.Where(P => P.ACTIVE == "Y");
            //    drp.DataSource = getdataTBLGROUP().Where(p => p.ACTIVE == "1").OrderBy(p=>p.ITGROUPID);
            //    drp.DataTextField = "ITGROUPDESC1";
            //    drp.DataValueField = "ITGROUPID";
            //    drp.DataBind();
            //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));

            //}
            drp = new DropDownList();
            return drp;
        }
        //===================Bind a DropDown For QuestionMaster.aspx.cs=========================
        //public static DropDownList getCRMdropdown(DropDownList drp, int TID, string switch1, string switch2, string switch3, string TableName)
        //{
        //    if (TableName == "TBLGROUP")
        //    {
        //        //drp.DataSource = DB.TBLGROUP.Where(P => P.ACTIVE == "Y");
        //        drp.DataSource = getdataTBLGROUP().Where(p => p.ACTIVE == "Y");
        //        drp.DataTextField = "ITGROUPDESC1";
        //        drp.DataValueField = "ITGROUPID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));

        //    }
        //    else if (TableName == "QuestionMaster")
        //    {
        //        if (switch1 == "1")
        //        {
        //            drp.DataSource = getdataQuestionMaster().Where(P => P.TenentID == TID && P.Avtive == true && P.Deleted == true);
        //            drp.DataTextField = "QuestionLang1";
        //            drp.DataValueField = "ID";
        //            drp.DataBind();
        //            drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //        }
        //        else if (switch2 == "2")
        //        {
        //            drp.DataSource = getdataQuestionMaster().Where(p => p.TenentID == TID && p.Avtive == true && p.Deleted == true && p.CreateBy == 2026);
        //            drp.DataTextField = "QuestionLang1";
        //            drp.DataValueField = "ID";
        //            drp.DataBind();
        //            drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //        }

        //    }
        //    //else if (TableName == "CAT_MST")
        //    //{
        //    //    //drp.DataSource = DB.CAT_MST.Where(P => P.TenentID == TID && P.CAT_TYPE == "QUESTION" && P.Active == "1");
        //    //    drp.DataSource = getdataCAT_MST().Where(p => p.CAT_TYPE == "QUESTION" && p.TenentID == TID);
        //    //    drp.DataTextField = "cat_name1";
        //    //    drp.DataValueField = "catid";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    //if (TableName == "IsChoice")
        //    //{
        //    //    drp.DataSource = getdataIsChoice().Where(P => P.TenentID == TID && P.Active == true);
        //    //    drp.DataTextField = "ChoiceType";
        //    //    drp.DataValueField = "ID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    //===================Bind a DropDown For Campaign_Msat.aspx.cs=========================    

        //    if (TableName == "REFTABLE")
        //    {
        //        //DrpCampaignType.DataSource = DB.REFTABLE.Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "Campaign Type");
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "Campaign Type");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "ACTVTY" && p.REFSUBTYPE == "STATUS");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "QuestionMaster")
        //    //{
        //    //drp.DataSource = getdataQuestionMaster().Where(p => p.TenentID == TID && p.Avtive == true && p.Deleted == true && p.CreateBy == 2026);
        //    //drp.DataTextField = "QuestionLang1";
        //    //drp.DataValueField = "ID";
        //    //drp.DataBind();
        //    //drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    //if (TableName == "ISCampignStatus")
        //    //{
        //    //    drp.DataSource = getdataISCampignStatus().Where(p => p.Active == true && p.Deleted == true);
        //    //    drp.DataTextField = "Status";
        //    //    drp.DataValueField = "ID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(P => P.REFTYPE == "CRM" && P.REFSUBTYPE == "Campaign" && P.TenentID == TID && P.SWITCH2 == "01").OrderBy(a => a.REFNAME1);
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(P => P.TenentID == TID && P.ACTIVE == "Y" && P.REFTYPE == "CATTYPE" && P.REFSUBTYPE == "CATTYPE");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //===================Bind a DropDown For Oppprtunity_Msat.aspx.cs=========================
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(P => P.REFTYPE == "CRM" && P.REFSUBTYPE == "Oppertunity" && P.TenentID == TID && P.SWITCH2 == "04").OrderBy(a => a.REFNAME1);
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "TBLCONTACT")
        //    //{
        //    //    drp.DataSource = getdataTBLCONTACT().Where(P => P.TenentID == TID && P.Active == "Y" && P.PHYSICALLOCID != "HLY");
        //    //    drp.DataTextField = "PersName1";
        //    //    drp.DataValueField = "ContactMyID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "TBLCONTACT")
        //    {
        //        drp.DataSource = getdataTBLCONTACT().Where(P => P.TenentID == TID && P.Active == "Y" && P.PHYSICALLOCID != "HLY");
        //        drp.DataTextField = "PersName1";
        //        drp.DataValueField = "ContactMyID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "TBLPROJECT")
        //    //{
        //    //    drp.DataSource = getdataTBLPROJECT().Where(p => p.TenentID == TID);
        //    //    drp.DataTextField = "PROJECTNAME1";
        //    //    drp.DataValueField = "PROJECTID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "ACTVTY" && p.REFSUBTYPE == "STATUS");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));

        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "OpportunityType");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "OpportunityStage");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "CRM" && p.REFSUBTYPE == "OpportunityLoss");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "tbl_Campaign_Mst")
        //    //{
        //    //    drp.DataSource = getdatatbl_Campaign_Mst().Where(p => p.TenentID == TID && p.Active == true && p.Deleted == true);
        //    //    drp.DataTextField = "Name";
        //    //    drp.DataValueField = "ID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    //===================Bind a DropDown For CRM_tbl_Lead Mst_Mst.aspx.cs=========================
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(P => P.REFTYPE == "CRM" && P.REFSUBTYPE == "Lead" && P.TenentID == TID && P.SWITCH2 == "02").OrderBy(a => a.REFNAME1);
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "TBLCOMPANYSETUP")
        //    //{
        //    //    drp.DataSource = getdataTBLCOMPANYSETUP().Where(P => P.TenentID == TID && P.Approved == 1 && P.SALER == true);
        //    //    drp.DataTextField = "COMPNAME";
        //    //    drp.DataValueField = "COMPID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "TBLCOMPANYSETUP")
        //    {
        //        drp.DataSource = getdataTBLCOMPANYSETUP().Where(P => P.TenentID == TID && P.Approved == 1 && P.SALER == true);
        //        drp.DataTextField = "COMPNAME";
        //        drp.DataValueField = "COMPID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "TBLPROJECT")
        //    {
        //        drp.DataSource = getdataTBLPROJECT().Where(p => p.TenentID == TID);
        //        drp.DataTextField = "PROJECTNAME1";
        //        drp.DataValueField = "PROJECTID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "ACTVTY" && p.REFSUBTYPE == "LEADSTATUS");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "REFTABLE")
        //    {
        //        drp.DataSource = getdataREFTABLE().Where(p => p.TenentID == TID && p.REFTYPE == "ACTVTY" && p.REFSUBTYPE == "STATUS");
        //        drp.DataTextField = "REFNAME1";
        //        drp.DataValueField = "REFID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "tbl_Opportunity_Mst")
        //    //{
        //    //    drp.DataSource = getdatatbl_Opportunity_Mst().Where(P => P.TenentID == TID && P.Deleted == true && P.Active == true);
        //    //    drp.DataTextField = "Name";
        //    //    drp.DataValueField = "OpportID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "tbl_Campaign_Mst")
        //    {
        //        drp.DataSource = getdatatbl_Campaign_Mst().Where(p => p.TenentID == TID && p.Active == true && p.Deleted == true);
        //        drp.DataTextField = "Name";
        //        drp.DataValueField = "ID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    if (TableName == "ISDepartment1")
        //    {
        //        drp.DataSource = getdataISDepartment1().Where(p => p.TenentID == TID && p.Active == true && p.Deleted == true);
        //        drp.DataTextField = "DepartmentName1";
        //        drp.DataValueField = "DepartmentID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    //if (TableName == "QuestionMaster")
        //    //{
        //    //    drp.DataSource = getdataQuestionMaster().Where(p => p.TenentID == TID && p.Avtive == true && p.Deleted == true && p.CreateBy == 2026);
        //    //    drp.DataTextField = "QuestionLang1";
        //    //    drp.DataValueField = "ID";
        //    //    drp.DataBind();
        //    //    drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    //}
        //    if (TableName == "TBLCOMPANYSETUP")
        //    {
        //        drp.DataSource = getdataTBLCOMPANYSETUP().Where(P => P.TenentID == TID && P.Approved == 0);
        //        drp.DataTextField = "COMPNAME";
        //        drp.DataValueField = "COMPID";
        //        drp.DataBind();
        //        drp.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    }
        //    drp = new DropDownList();
        //    return drp;
        //}


        public static void AdvanceSearchContact(int TID, ListView listSerial, TextBox PersName1, TextBox MOBPHONE, TextBox EMAIL1, TextBox FaxID, TextBox BUSPHONE1, TextBox CUSERID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            int Status1 = 0;
            string PerName = PersName1.Text;
            string mobphone = MOBPHONE.Text;
            string Email = EMAIL1.Text;
            string fax = FaxID.Text;
            string bisbho = BUSPHONE1.Text;
            string userid = CUSERID.Text;
            List<Database.TBLCONTACT> List = new List<Database.TBLCONTACT>();
            if (PerName != null && PerName != "")
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCONTACTs.Where(p => p.PersName1.ToUpper().Contains(PerName.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.PersName1.ToUpper().Contains(PerName.ToUpper())).ToList();
                    Status1 = 1;

                }
            }
            else
            {

            }
            //if (mobphone != "" && mobphone != null)
            //{
            //    if (Status1 == 0)
            //    {
            //        List = DB.TBLCONTACTs.Where(p => p.MOBPHONE.ToUpper().Contains(mobphone.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //    else
            //    {
            //        List = List.Where(p => p.MOBPHONE.ToUpper().Contains(mobphone.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //}
            //else
            //{

            //}
            if (Email != "" && Email != null)
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCONTACTs.Where(p => p.EMAIL1.ToUpper().Contains(Email.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.EMAIL1.ToUpper().Contains(Email.ToUpper())).ToList();
                    Status1 = 1;
                }
            }
            else
            {

            }
            //if (fax != "" && fax != "0")
            //{
            //    if (Status1 == 0)
            //    {
            //        List = DB.TBLCONTACTs.Where(p => p.FaxID.ToUpper().Contains(fax.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //    else
            //    {
            //        List = List.Where(p => p.FaxID.ToUpper().Contains(fax.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //}
            //else
            //{

            //}
            if (bisbho != "" && bisbho != null)
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCONTACTs.Where(p => p.BUSPHONE1.ToUpper().Contains(bisbho.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.BUSPHONE1.ToUpper().Contains(bisbho.ToUpper())).ToList();
                    Status1 = 1;
                }
            }
            else
            {

            }
            if (userid != "" && userid != null)
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCONTACTs.Where(p => p.USERID.ToUpper().Contains(userid.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.USERID.ToUpper().Contains(userid.ToUpper())).ToList();
                    Status1 = 1;
                }
            }
            else
            {

            }
            listSerial.DataSource = List.Take(5);
            listSerial.DataBind();

        }

        public static void AdvanceSearchCompany(int TID, ListView listSerial, TextBox CompName, TextBox CONTACT, TextBox CompWeb, TextBox EMAIL1)
        {
            Database.CallEntities DB = new Database.CallEntities();
            int Status1 = 0;
            string CName = CompName.Text;
            string CWeb = CompWeb.Text;
            string mobphone = CONTACT.Text;
            string Email = EMAIL1.Text;

            List<Database.TBLCOMPANYSETUP> List = new List<Database.TBLCOMPANYSETUP>();
            if (CName != null && CName != "")
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCOMPANYSETUPs.Where(p => p.COMPNAME1.ToUpper().Contains(CName.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.COMPNAME1.ToUpper().Contains(CName.ToUpper())).ToList();
                    Status1 = 1;

                }
            }
            else
            {

            }
            //if (mobphone != "" && mobphone != null)
            //{
            //    if (Status1 == 0)
            //    {
            //        List = DB.TBLCOMPANYSETUPs.Where(p => p.BUSPHONE1.ToUpper().Contains(mobphone.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //    else
            //    {
            //        List = List.Where(p => p.BUSPHONE1.ToUpper().Contains(mobphone.ToUpper())).ToList();
            //        Status1 = 1;
            //    }
            //}
            //else
            //{

            //}
            if (Email != "" && Email != null)
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCOMPANYSETUPs.Where(p => p.EMAIL1.ToUpper().Contains(Email.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.EMAIL1.ToUpper().Contains(Email.ToUpper())).ToList();
                    Status1 = 1;
                }
            }
            else
            {

            }
            if (CWeb != "" && CWeb != "0")
            {
                if (Status1 == 0)
                {
                    List = DB.TBLCOMPANYSETUPs.Where(p => p.WEBPAGE.ToUpper().Contains(CWeb.ToUpper())).ToList();
                    Status1 = 1;
                }
                else
                {
                    List = List.Where(p => p.WEBPAGE.ToUpper().Contains(CWeb.ToUpper())).ToList();
                    Status1 = 1;
                }
            }
            else
            {

            }


            listSerial.DataSource = List.Take(5);
            listSerial.DataBind();

        }

        public static int InserActivityMain(int TID = 0, int CID = 0, int LID = 0, int TRID = 0, int RID = 0, int UID = 0, string ACN1 = null, string Username = null, int MUID = 0, int Activityid = 0, string activityname = null, string CampynName = null, string Description = null, int DocNO = 0,int LinkMasterCODE=1, int GROUPCODE=1,bool Active=true)
        {
            Database.CallEntities DB = new Database.CallEntities();
            CRMMainActivity obj = new CRMMainActivity();
            int ActivityCode = DB.CRMMainActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMMainActivities.Where(p => p.TenentID == TID).Max(p => p.MasterCODE) + 1) : 1;
            string REFNO = ACN1 + "_" + ActivityCode + "_" + TRID;
            obj.TenentID = TID;
            obj.COMPID = CID;
            obj.MasterCODE = ActivityCode;
            obj.LinkMasterCODE = LinkMasterCODE;
            obj.LocationID = LID;
            obj.MyID = TRID;
            obj.RouteID = RID;
            obj.USERCODE = UID;
            obj.ACTIVITYE = ACN1;
            obj.ACTIVITYA = ACN1;
            obj.ACTIVITYA2 = ACN1;
            obj.Reference = REFNO;
            obj.AMIGLOBAL = true;
            obj.MYPERSONNEL = true;
            obj.INTERVALDAYS = 3;
            obj.REPEATFOREVER = false;
            obj.REPEATTILL = DateTime.Now;
            obj.REMINDERNOTE = " Youer Tarction is Pading";
            obj.ESTCOST = 1;
            obj.GROUPCODE = GROUPCODE;
            obj.USERCODEENTERED = "";
            obj.UPDTTIME = DateTime.Now;
            obj.USERNAME = Username;
            obj.Remarks = "";
            obj.CRUP_ID = 0;
            obj.Version = "";
            obj.Type = 0;
            obj.MyStatus = "";
            obj.MainID = 0;
            obj.ModuleID = MUID;
            obj.DisplayFDName = CampynName;
            obj.Description = Description;
            obj.Active = Active;
            DB.CRMMainActivities.AddObject(obj);
            DB.SaveChanges();

            string GROUPCODE1 = GROUPCODE.ToString();
            int LinkMasterCode = Classes.CRMClass.InsertActivity(TID, LID, CID, ActivityCode, ActivityCode, REFNO, Username, ACN1, Activityid, activityname, UID, DocNO,0,"Y", GROUPCODE1);
            //return ActivityCode;
            return LinkMasterCode;
        }

        public static int InsertActivity(int TID = 0,int LID=0, int CID = 0, int MCID = 0, int LMID = 0, string RENo = null, string UNAME = null, string RUID = null, int Activityid = 0, string activityname = null, int UID = 0, int DocNO = 0, int Type=0,string Active="Y", string GROUPCODE = "")
        {
            Database.CallEntities DB = new Database.CallEntities();
            var List = DB.CRMActivities.Where(p => p.TenentID == TID && p.COMPID == CID && p.MasterCODE == MCID&&p.Active=="Y").ToList();
            for(int i=0;i<List.Count();i++)
            {
                int TenentID = Convert.ToInt32(List[i].TenentID);
                int COMPID = Convert.ToInt32(List[i].COMPID);
                int MasterCODE = Convert.ToInt32(List[i].MasterCODE);
                CRMActivity objCRMActivity = DB.CRMActivities.Single(p => p.TenentID == TID && p.COMPID == CID && p.MasterCODE == MCID && p.Active == "Y");
                objCRMActivity.Active = "N";
                DB.SaveChanges();
            }
            CRMActivity obj = new CRMActivity();
            obj.TenentID = TID;
            obj.LocationID = LID;
            obj.COMPID = CID;
            obj.MasterCODE = MCID;
            obj.MyLineNo = DB.CRMActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TID).Max(p => p.MyLineNo) + 1) : 1;
            obj.LinkMasterCODE = DB.CRMActivities.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.CRMActivities.Where(p => p.TenentID == TID).Max(p => p.LinkMasterCODE) + 1) : 1;
            obj.MenuID = 0;
            obj.ActivityID = Activityid;
            obj.ACTIVITYTYPE = activityname;
            obj.REFTYPE = activityname;
            obj.REFSUBTYPE = activityname;
            obj.PerfReferenceNo = RENo;
            obj.EarlierRefNo = RENo;
            obj.NextUser = "";
            obj.NextRefNo = "";
            obj.AMIGLOBAL = "";
            obj.MYPERSONNEL = "";
            obj.ActivityPerform = "";
            obj.REMINDERNOTE = "";
            obj.ESTCOST = Activityid + 1;
            obj.GROUPCODE = GROUPCODE;
            obj.USERCODEENTERED = "";
            obj.UPDTTIME = DateTime.Now;
            obj.USERNAME = UNAME;
            obj.CRUP_ID = 0;
            obj.InitialDate = DateTime.Now;
            obj.DeadLineDate = DateTime.Now;
            obj.RouteID = RUID;
            obj.Version = "";
            obj.Type = Type;
            obj.MyStatus = "";
            obj.GroupBy = "";
            obj.DocID = DocNO;
            obj.ToColumn = 0;
            obj.FromColumn = 0;
            obj.Active = Active;
            obj.MainSubRefNo = 0;
            obj.UrlRedirct = "";
            DB.CRMActivities.AddObject(obj);
            DB.SaveChanges();
            int MMID = Convert.ToInt32(obj.LinkMasterCODE);
            return MMID;
        }

        public static int InsertAppointment(int ID, int TID = 0, int LID = 0, string Tilte = null, DateTime? StartDt = null, DateTime? EndDt = null, string Color = null, string url = null, bool Active = true, bool Deleted = true, string CRMRef = null, string Status = null, int MyID = 0, int Type = 0, int AType = 0, string Appofrom = null, string AppoTo = null, string remark = null)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.Appointment objAppointment = new Database.Appointment();
            int AID = 0;
            bool falg = false;
            if(Status == "Insert")
            {
                objAppointment = new Database.Appointment();
                objAppointment.TenentID = TID;
                objAppointment.LocationID = 1;
                objAppointment.ID = DB.Appointments.Where(p => p.TenentID == TID).Count() > 0 ? DB.Appointments.Where(p => p.TenentID == TID).Max(p => p.ID) + 1 : 1;
                AID = objAppointment.ID;
                objAppointment.Createby = 1;
                objAppointment.DateTime = DateTime.Now;
                falg = true;
            }
            else
            {
                objAppointment = DB.Appointments.Single(p => p.TenentID==TID && p.ID == ID);
            }
            objAppointment.MyID = MyID;
            objAppointment.MySerial = DB.Appointments.Where(p => p.MyID == MyID).Count() > 0 ? Convert.ToInt32(DB.Appointments.Where(p => p.MyID == MyID).Max(p => p.MySerial) + 1) : 1;
            objAppointment.TransactionStatus = "Y";
            objAppointment.Type = Type;
            objAppointment.ActionType = AType;
            objAppointment.Title = Tilte;
            objAppointment.StartDt = StartDt;
            objAppointment.EndDt = EndDt;
            objAppointment.Color = Color;
            objAppointment.url = url;
            objAppointment.Active = Active;
            objAppointment.Deleted = Deleted;
            objAppointment.CRMReference = CRMRef;
            objAppointment.FromAppoint = Appofrom;
            objAppointment.ToAppoint = AppoTo;
            //objAppointment.Remark = remark;
            if(falg == true)
            {
                DB.Appointments.AddObject(objAppointment);
            }
            DB.SaveChanges();
            return AID;
        }
        public static bool ISAdmin(int TID ,string AID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            // TODO :: Optimize this one.
            if (DB.MYCOMPANYSETUPs.Where(p => p.TenentID == TID && p.USERID == AID).Count() > 0)
                return true;
            else
                return false;
        }

        //public static DataTable GetAnswers(int TID)
        //{
        //    using (SqlConnection con = SqlHelper.createConnection())
        //    {

        //        DataTable DT = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Select_Answers", new SqlParameter("TID", TID)).Tables[0];

        //        return DT;
        //    }
        //}
        //public static bool INSERT_answer(int TID ,string answer)
        //{
        //    try
        //    {
        //        using (SqlConnection con = SqlHelper.createConnection())
        //        {                 

        //            SqlParameter[] param = new SqlParameter[]{
        //                 new SqlParameter("TID",TID),
        //             new SqlParameter("answer",answer),
               
        //        };
        //            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Insert_Answers", param);
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }

        //}
    }

}






