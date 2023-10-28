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
using System.Data.Entity.Core.Objects.DataClasses;

namespace Classes
{
    public static class POSSynchronization
    {
        static Database.CallEntities DB = new Database.CallEntities();
        public static void SyncTBLProduct(int TID, int LOCATION_ID, long MYPRODID, string UserProdID, string BarCode, string AlternateCode1, string AlternateCode2, int UOM, string COLORID, int GROUPID, int SIZECODE, int ProdTypeRefId, int SupplyMethodID, int ProdMethodID, int SalDeptID, string ShortName, string ProdName1, string ProdName2, string ProdName3, string DescToprint, string Brand, bool Serialized, bool HotItem, bool SKUProduction, string SKU, bool MultiSize, bool MultiUOM, bool MultiColor, bool MultiBinStore, bool Perishable, bool SaleAllow, bool PurAllow, string REMARKS, string keywords, decimal basecost, decimal onlinesale1, decimal onlinesale2, decimal msrp, decimal price, string currency, long QTYINHAND, long QTYRCVD, long QTYSOLD, string ACTIVE, string DIRECTSALE, string LINK2DIRECT, long Display_ID, DateTime DISPDATE3, DateTime LASTPURDATE, DateTime LASTSALDATE, string Warranty, int COMPANYID, string SUBPRODNAME, string SUBPRODNAMEO, string SUBPRODNAMECH, int SORTNUMBER, string PLACEHOLDERLINE, string PLACEHOLDERCOLUMN, string PLACEHOLDERALIRL, string ONLINESALEALOW, string IsSoftware, string InternalNotes, decimal onlinesale3, long MainCategoryID, bool DevloperActiv, string Option1, bool Option2, DateTime Option3, string Option4, bool Appove, int CRUP_ID, bool POSAllow, DateTime UploadDate, string Uploadby, DateTime SyncDate, string Syncby, int SynID, string RecipeType, int recNo)
        {
            if (DB.TBLPRODUCTs.Where(p => p.TenentID == TID && p.MYPRODID == MYPRODID).Count() == 0)
            {
                Database.TBLPRODUCT Prodobj = new Database.TBLPRODUCT();
                Prodobj.TenentID = TID;
                Prodobj.LOCATION_ID = LOCATION_ID;
                Prodobj.MYPRODID = MYPRODID;
                Prodobj.UserProdID = UserProdID;
                Prodobj.BarCode = BarCode;
                Prodobj.AlternateCode1 = AlternateCode1;
                Prodobj.AlternateCode2 = AlternateCode2;
                Prodobj.UOM = SycnUOM(TID, UOM);
                Prodobj.COLORID = SyncColor(TID);
                Prodobj.GROUPID = SyncGroup(TID);
                Prodobj.SIZECODE = SycnSize(TID);
                Prodobj.ProdTypeRefId = SycnRef(TID, "PRODTYPE", "PRODTYPE", "99955", "POS");
                Prodobj.SupplyMethodID = SycnRef(TID, "SUPPM", "SUPPM", "99981", "Buy");
                Prodobj.ProdMethodID = SycnRef(TID, "PRODM", "PRODM", "99991", "Make 2 Order");
                Prodobj.SalDeptID = SyncSaleDept(TID);
                Prodobj.ShortName = ShortName;
                Prodobj.ProdName1 = ProdName1;
                Prodobj.ProdName2 = ProdName2;
                Prodobj.ProdName3 = ProdName3;
                Prodobj.DescToprint = DescToprint;
                Prodobj.Brand = SycnRef(TID, "BRAND", "OTH", "99999", "Not Used").ToString();
                Prodobj.Serialized = Serialized;
                Prodobj.HotItem = HotItem;
                Prodobj.SKUProduction = SKUProduction;
                Prodobj.SKU = SKU;
                Prodobj.MultiSize = MultiSize;
                Prodobj.MultiUOM = MultiUOM;
                Prodobj.MultiColor = MultiColor;
                Prodobj.MultiBinStore = MultiBinStore;
                Prodobj.Perishable = Perishable;
                Prodobj.SaleAllow = SaleAllow;
                Prodobj.PurAllow = PurAllow;
                Prodobj.REMARKS = REMARKS;
                Prodobj.keywords = keywords;
                Prodobj.basecost = basecost;
                Prodobj.onlinesale1 = onlinesale1;
                Prodobj.onlinesale2 = onlinesale2;
                Prodobj.msrp = msrp;
                Prodobj.price = price;
                Prodobj.currency = SyncCurrency(TID);
                Prodobj.QTYINHAND = QTYINHAND;
                Prodobj.QTYRCVD = QTYRCVD;
                Prodobj.QTYSOLD = QTYSOLD;
                Prodobj.ACTIVE = ACTIVE;
                Prodobj.DIRECTSALE = DIRECTSALE;
                Prodobj.LINK2DIRECT = LINK2DIRECT;
                Prodobj.Display_ID = Display_ID;//999999999
                Prodobj.DISPDATE3 = DISPDATE3;
                Prodobj.LASTPURDATE = LASTPURDATE;
                Prodobj.LASTSALDATE = LASTSALDATE;
                Prodobj.Warranty = Warranty;
                Prodobj.COMPANYID = COMPANYID;
                Prodobj.SUBPRODNAME = SUBPRODNAME;
                Prodobj.SUBPRODNAMEO = SUBPRODNAMEO;
                Prodobj.SUBPRODNAMECH = SUBPRODNAMECH;
                Prodobj.SORTNUMBER = SORTNUMBER;
                Prodobj.PLACEHOLDERLINE = PLACEHOLDERLINE;
                Prodobj.PLACEHOLDERCOLUMN = PLACEHOLDERCOLUMN;
                Prodobj.PLACEHOLDERALIRL = PLACEHOLDERALIRL;
                Prodobj.ONLINESALEALOW = ONLINESALEALOW;
                Prodobj.IsSoftware = IsSoftware;
                Prodobj.InternalNotes = InternalNotes;
                Prodobj.onlinesale3 = onlinesale3;
                Prodobj.MainCategoryID = MainCategoryID;
                Prodobj.DevloperActiv = DevloperActiv;
                Prodobj.Option1 = Option1;
                Prodobj.Option2 = Option2;
                Prodobj.Option3 = Option3;
                Prodobj.Option4 = Option4;
                Prodobj.Appove = Appove;
                Prodobj.CRUP_ID = CRUP_ID;
                Prodobj.POSAllow = POSAllow;
                Prodobj.UploadDate = UploadDate;
                Prodobj.Uploadby = Uploadby;
                Prodobj.SyncDate = SyncDate;
                Prodobj.Syncby = Syncby;
                Prodobj.SynID = SynID;
                Prodobj.RecipeType = RecipeType;
                Prodobj.recNo = recNo;
                DB.TBLPRODUCTs.AddObject(Prodobj);
                DB.SaveChanges();
            }
            if (MultiUOM == true)
            {
                int PID = Convert.ToInt32(MYPRODID);
                if (DB.Tbl_Multi_Color_Size_Mst.Where(p => p.TenentID == TID && p.CompniyAndContactID == PID && p.RecTypeID == UOM).Count() < 1)
                {
                    Tbl_Multi_Color_Size_Mst multiuom = new Tbl_Multi_Color_Size_Mst();
                    multiuom.TenentID = TID;
                    multiuom.RecordType = "MultiUOM";
                    multiuom.RecTypeID = Convert.ToInt32(UOM);
                    multiuom.CompniyAndContactID = PID;
                    multiuom.RunSerial = DB.Tbl_Multi_Color_Size_Mst.Where(p => p.TenentID == TID && p.CompniyAndContactID == PID).Count() > 0 ? Convert.ToInt32(DB.Tbl_Multi_Color_Size_Mst.Where(p => p.TenentID == TID && p.CompniyAndContactID == PID).Max(p => p.RunSerial) + 1) : 1;
                    multiuom.Recource = 5009;
                    multiuom.RecourceName = "Product";
                    multiuom.RecValue = DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == UOM).UOMNAME1;
                    multiuom.Active = true;
                    DB.Tbl_Multi_Color_Size_Mst.AddObject(multiuom);
                    DB.SaveChanges();
                }
                if (DB.ICITEMS_PRICE.Where(p => p.TenentID == TID && p.MYPRODID == MYPRODID && p.UOM == UOM).Count() < 1)
                {
                    Database.ICITEMS_PRICE objprice = new ICITEMS_PRICE();
                    objprice.TenentID = TID;
                    objprice.MYPRODID = MYPRODID;
                    objprice.UOM = UOM;
                    objprice.MyID = DB.ICITEMS_PRICE.Where(p => p.TenentID == TID && p.MYPRODID == MYPRODID && p.UOM == UOM).Count() > 0 ? Convert.ToInt32(DB.ICITEMS_PRICE.Where(p => p.TenentID == TID && p.MYPRODID == MYPRODID && p.UOM == UOM).Max(p => p.MyID) + 1) : 1;
                    objprice.UserProdID = UserProdID;
                    objprice.ORIGINALPRICE = 0;
                    objprice.MAXDISCOUNT = 0;
                    objprice.SPECIALSALE = 0;
                    objprice.REFERENCE = "";
                    objprice.CRUP_ID = 1;
                    objprice.LOCATIONID = LOCATION_ID;
                    objprice.COMPANYID = 1;
                    objprice.basecost = price;
                    objprice.onlinesale1 = msrp;
                    objprice.onlinesale2 = msrp;
                    objprice.onlinesale3 = msrp;
                    objprice.msrp = msrp;
                    objprice.price = price;
                    objprice.currency = currency;
                    DB.ICITEMS_PRICE.AddObject(objprice);
                    DB.SaveChanges();
                }
            }


        }
        public static string SyncColor(int TID)
        {
            string cid = "999999999";
            if (DB.TBLCOLORs.Where(p => p.COLORID == 999999999 && p.TenentID == TID).Count() < 1)
            {
                Database.TBLCOLOR OBJCOLOR = new Database.TBLCOLOR();
                OBJCOLOR.TenentID = TID;
                OBJCOLOR.COLORID = 999999999;
                OBJCOLOR.COLORDESC1 = "NOT USED";
                OBJCOLOR.COLORDESC2 = "NOT USED";
                OBJCOLOR.COLORREMARKS = "NOT USED";
                OBJCOLOR.hex = "NOT USED";
                OBJCOLOR.RGB = "NOT USED";
                OBJCOLOR.color = "";
                OBJCOLOR.CRUP_ID = 0;
                OBJCOLOR.Active = "Y";
                DB.TBLCOLORs.AddObject(OBJCOLOR);
                DB.SaveChanges();
                cid = OBJCOLOR.COLORID.ToString();
            }
            else
            {
                cid = "999999999";
            }
            return cid;
        }
        public static int SyncGroup(int TID)
        {
            int GID = 0;
            if (DB.TBLGROUPs.Where(p => p.TenentID == TID && p.ITGROUPID == 999999999).Count() < 1)
            {
                Database.TBLGROUP objGroup = new Database.TBLGROUP();
                objGroup.TenentID = TID;
                objGroup.LocationId = 1;
                objGroup.ITGROUPID = 999999999;
                objGroup.GroupType = "POS";
                objGroup.ITGROUPDESC1 = "Not Used";
                objGroup.ITGROUPDESC2 = "Not Used";
                objGroup.ITGROUPREMARKS = "Not Used";
                objGroup.ACTIVE_Flag = true;
                objGroup.ACTIVE = "1";
                objGroup.CRUP_ID = 0;
                DB.TBLGROUPs.AddObject(objGroup);
                DB.SaveChanges();
                GID = Convert.ToInt32(objGroup.ITGROUPID);
            }
            else
            {
                GID = 999999999;
            }
            return GID;
        }
        public static int SycnSize(int TID)
        {
            int size = 999999999;
            if (DB.TBLSIZEs.Where(p => p.SIZECODE == 999999999 && p.TenentID == TID).Count() < 1)
            {
                Database.TBLSIZE OBJSIZE = new Database.TBLSIZE();
                OBJSIZE.TenentID = TID;
                OBJSIZE.SIZECODE = 999999999;
                OBJSIZE.SIZETYPE = "Not Used";
                OBJSIZE.SIZEDESC1 = "Not Used";
                OBJSIZE.SIZEDESC2 = "Not Used";
                OBJSIZE.SIZEDESC3 = "Not Used";
                OBJSIZE.SIZEREMARKS = "Not Used";
                OBJSIZE.ACTIVE = "Y";
                DB.TBLSIZEs.AddObject(OBJSIZE);
                DB.SaveChanges();

                size = Convert.ToInt32(OBJSIZE.SIZECODE);
            }
            else
            {
                size = 999999999;
            }
            return size;
        }
        public static int SycnRef(int TID, string Reftype, string refsubtype, string ID, string Name)
        {
            int RID = Convert.ToInt32(ID);

            if (DB.REFTABLEs.Where(p => p.TenentID == TID && p.REFID == RID).Count() < 1)
            {
                Database.REFTABLE ObjRef = new Database.REFTABLE();
                ObjRef.TenentID = TID;
                ObjRef.REFID = RID;
                ObjRef.REFTYPE = Reftype;
                ObjRef.REFSUBTYPE = refsubtype;
                ObjRef.SHORTNAME = Name;
                ObjRef.REFNAME1 = Name;
                ObjRef.REFNAME2 = Name;
                ObjRef.REFNAME3 = Name;
                ObjRef.SWITCH1 = "1";
                ObjRef.SWITCH2 = "1";
                ObjRef.SWITCH3 = "1";
                ObjRef.SWITCH4 = 1;
                ObjRef.Remarks = Name;
                ObjRef.ACTIVE = "Y";
                DB.REFTABLEs.AddObject(ObjRef);
                DB.SaveChanges();
            }
            return RID;
        }
        public static int SyncSaleDept(int TID)
        {
            int DEPT = 999999999;
            if (DB.DEPTOFSales.Where(p => p.TenentID == TID && p.SalDeptID == 999999999).Count() < 1)
            {
                Database.DEPTOFSale ObjDEPT = new Database.DEPTOFSale();
                ObjDEPT.TenentID = TID;
                ObjDEPT.SalDeptID = 999999999;
                ObjDEPT.DeptDesc1 = "Not Exist Yet";
                ObjDEPT.DeptDesc2 = "Not Exist Yet";
                ObjDEPT.DeptDesc3 = "Not Exist Yet";
                ObjDEPT.DeptRemarks = "Not Exist Yet";
                ObjDEPT.Active_Flag = true;
                ObjDEPT.CRUP_ID = 0;
                DB.DEPTOFSales.AddObject(ObjDEPT);
                DB.SaveChanges();
            }
            return DEPT;
        }
        public static string SyncCurrency(int TID)
        {
            string Currency = "126";
            if (DB.tblCOUNTRies.Where(p => p.TenentID == TID && p.COUNTRYID == 126).Count() < 1)
            {
                Database.tblCOUNTRY objCountry = new Database.tblCOUNTRY();
                objCountry.TenentID = TID;
                objCountry.COUNTRYID = 126;
                objCountry.REGION1 = "د.ك";
                objCountry.COUNAME1 = "Kuwait";
                objCountry.COUNAME2 = "Kuwait";
                objCountry.COUNAME3 = "Kuwait";
                objCountry.CAPITAL = "Kuwait";
                objCountry.NATIONALITY1 = "Kuwait";
                objCountry.NATIONALITY2 = "Kuwait";
                objCountry.NATIONALITY3 = "Kuwait";
                objCountry.CURRENCYNAME1 = "Kuwaiti Dinar";
                objCountry.CURRENCYNAME2 = "Kuwaiti Dinar";
                objCountry.CURRENCYNAME3 = "Kuwaiti Dinar";
                objCountry.CURRENTCONVRATE = Convert.ToDecimal(1.00000);
                objCountry.CURRENCYSHORTNAME1 = "KWD";
                objCountry.CURRENCYSHORTNAME2 = "KWD";
                objCountry.CURRENCYSHORTNAME3 = "KWD";
                objCountry.CountryType = "Independent State";
                objCountry.CountryTSubType = "";
                objCountry.Sovereignty = "";
                objCountry.ISO4217CurCode = "KWD";
                objCountry.ISO4217CurName = "";
                objCountry.ITUTTelephoneCode = "965";
                objCountry.FaxLength = 8;
                objCountry.TelLength = 8;
                objCountry.ISO3166_1_2LetterCode = "KW";
                objCountry.ISO3166_1_3LetterCode = "KWT";
                objCountry.ISO3166_1Number = "";
                objCountry.IANACountryCodeTLD = ".kw";
                objCountry.Active = "Y";

            }
            return Currency;
        }
        public static int SycnUOM(int TID, int ID)
        {
            Database.ICUOM obj = new Database.ICUOM();
            if (DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == 99999).Count() < 1)
            {
                obj.TenentID = TID;
                obj.UOM = 99999;
                obj.UOMNAMESHORT = "Not Used";
                obj.UOMNAME1 = "Not Used";
                obj.UOMNAME2 = "Not Used";
                obj.UOMNAME3 = "Not Used";
                obj.REMARKS = "Not Used";
                obj.CRUP_ID = 0;
                obj.Active = "Y";
                DB.ICUOMs.AddObject(obj);
                DB.SaveChanges();
            }

            return ID;
        }

        public static void AddProduct()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);
            var result1 = (from pm in DB.Win_purchase.Where(p => p.TenentID == TID)
                           join
                             ur in DB.Win_tbl_item_uom_price.Where(p => p.TenentID == TID) on pm.product_id equals ur.itemID
                           where pm.product_id == ur.itemID
                           select new
                           {
                               pm.product_id,
                               pm.product_name,
                               pm.category,
                               pm.supplier,
                               pm.imagename,
                               pm.taxapply,
                               pm.Shopid,
                               pm.status,
                               pm.UploadDate,
                               pm.Uploadby,
                               pm.SyncDate,
                               pm.Syncby,
                               pm.SynID,
                               pm.product_name_Arabic,
                               pm.category_arabic,
                               pm.product_name_print,
                               pm.ExpiryDate,
                               pm.IsPerishable,
                               pm.CustItemCode,
                               pm.BarCode,
                               ur.ID,
                               ur.itemID,
                               ur.UOMID,
                               ur.msrp,
                               ur.price
                           }
                           ).ToList();

            foreach (var item in result1)
            {
                int TenentID = TID;
                int LOCATION_ID = 1;
                long MYPRODID = item.product_id;
                string UserProdID = item.product_id.ToString();
                string BarCode = item.product_id.ToString();
                string AlternateCode1 = item.product_id.ToString();
                string AlternateCode2 = item.product_id.ToString();
                int WinUOMID = Convert.ToInt32(item.UOMID);
                int UOM = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == WinUOMID).Count() > 0 ? Convert.ToInt32(DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == WinUOMID).UOM) : 99999;
                string COLORID = "999999999";
                int GROUPID = 999999999;
                int SIZECODE = 999999999;
                int ProdTypeRefId = 99955;
                int SupplyMethodID = 99981;
                int ProdMethodID = 99991;
                int SalDeptID = 999999999;
                string ShortName = item.product_name;
                string ProdName1 = item.product_name;
                string ProdName2 = item.product_name;
                string ProdName3 = item.product_name;
                string DescToprint = item.product_name_print;
                string Brand = "99999";
                bool Serialized = false;
                bool HotItem = false;
                bool SKUProduction = false;
                string SKU = "";
                bool MultiSize = false;
                bool MultiUOM = DB.Win_tbl_item_uom_price.Where(p => p.TenentID == TID && p.itemID == item.product_id).Count() > 1 ? true : false;//multiuom
                bool MultiColor = false;
                bool MultiBinStore = false;
                bool Perishable = false;
                bool SaleAllow = true;
                bool PurAllow = true;
                string REMARKS = "POS";
                string keyword = "POS";
                decimal basecost = Convert.ToDecimal(item.price);
                decimal onlinesale1 = Convert.ToDecimal(item.price);
                decimal onlinesale2 = Convert.ToDecimal(item.price);
                decimal msrp = Convert.ToDecimal(item.msrp);
                decimal price = Convert.ToDecimal(item.price);
                string currency = "126";
                long QTYINHAND = 0;
                long QTYRCVD = 0;
                long QTYSOLD = 0;
                string ACTIVE = "1";
                string DIRECTSALE = "1";
                string LINK2DIRECT = "";
                long Display_ID = 999999999;
                DateTime DISPDATE3 = DateTime.Now;
                DateTime LASTPURDATE = DateTime.Now;
                DateTime LASTSALDATE = DateTime.Now;
                string Warranty = "0 , No Warantee";
                int COMPANYID = 0;
                string SUBPRODNAME = "";
                string SUBPRODNAMEO = "";
                string SUBPRODNAMECH = "";
                int SORTNUMBER = 0;
                string PLACEHOLDERLINE = "";
                string PLACEHOLDERCOLUMN = "";
                string PLACEHOLDERALIRL = "";
                string ONLINESALEALOW = "Y";
                string IsSoftware = "";
                string InternalNotes = "";
                decimal onlinesale3 = Convert.ToDecimal(item.price);
                int WinCatID = Convert.ToInt32(item.category);
                long MainCategoryID = DB.CAT_MST.Where(m => m.TenentID == TID && m.CATID == WinCatID).Count() > 0 ? Convert.ToInt64(DB.CAT_MST.Single(m => m.TenentID == TID && m.CATID == WinCatID).CATID) : 1;
                bool DevloperActiv = true;
                string Option1 = "";
                bool Option2 = false;
                DateTime Option3 = DateTime.Now;
                string Option4 = "";
                bool Appove = false;
                int CRUP_ID = 0;
                bool POSAllow = true;
                DateTime UploadDate = DateTime.Now;
                string Uploadby = uname;
                DateTime SyncDate = DateTime.Now;
                string Syncby = "";
                int SynID = 0;
                string RecipeType = "";
                int recNo = 0;

                SyncTBLProduct(TenentID, LOCATION_ID, MYPRODID, UserProdID, BarCode, AlternateCode1, AlternateCode2, UOM, COLORID, GROUPID, SIZECODE, ProdTypeRefId, SupplyMethodID, ProdMethodID, SalDeptID, ShortName, ProdName1, ProdName2, ProdName3, DescToprint, Brand, Serialized, HotItem, SKUProduction, SKU, MultiSize, MultiUOM, MultiColor, MultiBinStore, Perishable, SaleAllow, PurAllow, REMARKS, keyword, basecost, onlinesale1, onlinesale2, msrp, price, currency, QTYINHAND, QTYRCVD, QTYSOLD, ACTIVE, DIRECTSALE, LINK2DIRECT, Display_ID, DISPDATE3, LASTPURDATE, LASTSALDATE, Warranty, COMPANYID, SUBPRODNAME, SUBPRODNAMEO, SUBPRODNAMECH, SORTNUMBER, PLACEHOLDERLINE, PLACEHOLDERCOLUMN, PLACEHOLDERALIRL, ONLINESALEALOW, IsSoftware, InternalNotes, onlinesale3, MainCategoryID, DevloperActiv, Option1, Option2, Option3, Option4, Appove, CRUP_ID, POSAllow, UploadDate, Uploadby, SyncDate, Syncby, SynID, RecipeType, recNo);
                //icitem_price
                if (DB.ICITEMS_PRICE.Where(p => p.TenentID == TID && p.MYPRODID == MYPRODID && p.UOM == UOM).Count() < 1)
                {
                    Database.ICITEMS_PRICE objprice = new ICITEMS_PRICE();
                    objprice.TenentID = TID;
                    objprice.MYPRODID = MYPRODID;
                    objprice.UOM = UOM;
                    objprice.MyID = 1;
                    objprice.UserProdID = UserProdID;
                    objprice.ORIGINALPRICE = 0;
                    objprice.MAXDISCOUNT = 0;
                    objprice.SPECIALSALE = 0;
                    objprice.REFERENCE = "";
                    objprice.CRUP_ID = 1;
                    objprice.LOCATIONID = 1;
                    objprice.COMPANYID = 1;
                    objprice.basecost = basecost;
                    objprice.onlinesale1 = basecost;
                    objprice.onlinesale2 = basecost;
                    objprice.onlinesale3 = basecost;
                    objprice.msrp = Convert.ToDecimal(item.msrp);
                    objprice.price = basecost;
                    objprice.currency = "126";
                    DB.ICITEMS_PRICE.AddObject(objprice);
                    DB.SaveChanges();
                }
            }
        }
        public static void AddPurchase()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);
            int comppid = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).CompId);
            //select * from Win_tbl_purchase_history where TenentID=9000009
            List<Database.Win_tbl_purchase_history> ListPurcha = DB.Win_tbl_purchase_history.Where(p => p.TenentID == TID).ToList();

            //purchase default
            //reftable - ddlLocalForeign(Local/Foreign)
            // tblCOUNTRY - ddlCurrency
            // drpoverhend - ICEXTRACOSTs
            //SYnc HD
            List<Database.Win_tbl_purchase_history> SyncHDDTTrans = ListPurcha.GroupBy(p => new { p.supplier, p.purchase_date }).Select(p => p.FirstOrDefault()).ToList();
            foreach (Database.Win_tbl_purchase_history itemHD in SyncHDDTTrans)
            {
                decimal CUSTVENDID = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPNAME1 == itemHD.supplier).Count() > 0 ? Convert.ToDecimal(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == itemHD.supplier).COMPID) : 0;
                if (CUSTVENDID == 0)
                {
                    CUSTVENDID = DirectCustSupp();
                }
                DateTime TRANSDATE = Convert.ToDateTime(itemHD.purchase_date);
                int Mytrancidd = DB.ICTR_HD.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;

                string SP = itemHD.supplier.ToString();
                string DT = itemHD.purchase_date.ToString();
                string SirialNO11 = "";
                var listtbltranssubtypes1 = DB.tbltranssubtypes.Where(p => p.TenentID == TID && p.transid == 2101 && p.transsubid == 21011).ToList();
                if (listtbltranssubtypes1.Count() > 0)
                {
                    int SirialNO1 = (Convert.ToInt32(listtbltranssubtypes1.Single(p => p.TenentID == TID && p.transid == 2101 && p.transsubid == 21011).serialno) + 1);
                    SirialNO11 = SirialNO1.ToString();
                }
                else
                    SirialNO11 = "";
                if (DB.ICTR_HD.Where(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE && p.signatures == "WinPOS").Count() > 0)
                {
                    Mytrancidd = Convert.ToInt32(DB.ICTR_HD.Single(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE && p.signatures == "WinPOS").MYTRANSID);
                }
                int TenentID = TID;
                int MYTRANSID = Mytrancidd;
                int ToTenantID = 1;
                int locationID = 1;
                string MainTranType = "I";
                string TranType = "Goods Received Note - Purchase";
                int transid = 2101;
                int transsubid = 21011;
                string MYSYSNAME = "PUR";
                decimal COMPID = comppid;
                CUSTVENDID = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPNAME1 == itemHD.supplier).Count() > 0 ? Convert.ToDecimal(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == itemHD.supplier).COMPID) : 0;
                string LF = "L";
                string PERIOD_CODE = "0";
                string ACTIVITYCODE = "0";
                decimal MYDOCNO = 99999999;
                string USERBATCHNO = "";
                decimal TOTQTY = Convert.ToDecimal(DB.Win_tbl_purchase_history.Where(p => p.TenentID == TID && p.supplier == SP && p.purchase_date == DT).Sum(p => p.product_quantity));
                decimal TOTAMT = Convert.ToDecimal(DB.Win_tbl_purchase_history.Where(p => p.TenentID == TID && p.supplier == SP && p.purchase_date == DT).Sum(p => p.cost_price));
                decimal AmtPaid = 0;
                string PROJECTNO = "0";
                string CounterID = "0";
                string PrintedCounterInvoiceNo = "5";
                int JOID = 99999999;
                TRANSDATE = Convert.ToDateTime(itemHD.purchase_date);
                string REFERENCE = "";
                string NOTES = "";
                int CRUP_ID = 0;
                string GLPOST = "1";
                string GLPOST1 = "1";
                string GLPOSTREF1 = "1";
                string GLPOSTREF = "1";
                string ICPOST = "1";
                string ICPOSTREF = "1";
                string USERID = uname;
                bool ACTIVE = true;
                int COMPANYID = 126;
                DateTime ENTRYDATE = DateTime.Now;
                DateTime ENTRYTIME = DateTime.Now;
                DateTime UPDTTIME = DateTime.Now;
                string InvoiceNO = "";
                decimal Discount = Convert.ToDecimal(0);
                string Status = "RDPOCT";
                int Terms = 99999;
                string Custmerid = "";
                string Swit1 = "";
                string ExtraField2 = "";
                int RefTransID = Mytrancidd;
                string Reason = "0";
                string TransDocNo = SirialNO11;
                int LinkTransID = 0;
                int invoice_Type = 0;
                int invoice_Source = 0;
                if (DB.ICTR_HD.Where(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE).Count() == 0)
                {
                    Classes.EcommAdminClass.insert_ICTR_HD(TenentID, MYTRANSID, ToTenantID, locationID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, PERIOD_CODE, ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, ACTIVE, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                    Database.ICTR_HD Comman = DB.ICTR_HD.Single(p => p.TenentID == TID && p.MYTRANSID == MYTRANSID);
                    Comman.signatures = "WinPOS";
                    DB.SaveChanges();
                }
                //Sync DT

                List<Database.Win_tbl_purchase_history> SyncDTTrans = DB.Win_tbl_purchase_history.Where(p => p.TenentID == TID && p.supplier == SP && p.purchase_date == DT).ToList();
                foreach (Database.Win_tbl_purchase_history itemDT in SyncDTTrans)
                {
                    if (DB.Win_tbl_purchase_history.Where(p => p.TenentID == TID && p.Live_MytranceIDHD == itemDT.Live_MytranceIDHD && p.Live_MyidDT == itemDT.Live_MyidDT).Count() < 1)
                    {
                        int TenentIDDT = TID;
                        int MYTRANSIDDT = Mytrancidd;
                        int locationIDDT = 1;
                        int MYID = DB.ICTR_DT.Where(p => p.TenentID == TID && p.MYTRANSID == Mytrancidd).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT.Where(p => p.TenentID == TID && p.MYTRANSID == Mytrancidd).Max(p => p.MYID) + 1) : 1;
                        int MyProdIDDT = Convert.ToInt32(itemDT.product_id);
                        string REFTYPEDT = "LF";
                        string REFSUBTYPEDT = "LF";
                        string PERIOD_CODEDT = "0";
                        string MYSYSNAMEDT = "PUR";
                        int JOIDDT = 99999999;
                        int JOBORDERDTMYIDDT = 1;
                        int ACTIVITYIDDT = 0;
                        string DESCRIPTIONDT = itemDT.product_name;
                        int WinUOMID = Convert.ToInt32(itemDT.UOM);
                        string UOMDT = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOM == WinUOMID).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOM == WinUOMID).UOM.ToString() : "99999";
                        int QUANTITYDT = Convert.ToInt32(itemDT.product_quantity);
                        decimal UNITPRICEDT = Convert.ToDecimal(itemDT.cost_price);
                        decimal AMOUNTDT = QUANTITYDT * UNITPRICEDT;
                        decimal OVERHEADAMOUNTDT = Convert.ToDecimal(0);
                        string BATCHNODT = "";
                        int BIN_IDDT = 1;
                        string BIN_TYPEDT = "Bin";
                        string GRNREFDT = "2";
                        decimal DISPERDT = Convert.ToDecimal(0);
                        decimal DISAMTDT = Convert.ToDecimal(0);
                        decimal TAXPERDT = Convert.ToDecimal(0);
                        decimal TAXAMTDT = Convert.ToDecimal(0);
                        decimal PROMOTIONAMTDT = Convert.ToDecimal(0);
                        int CRUP_IDDT = 0;
                        string GLPOSTDT = "1";
                        string GLPOST1DT = "1";
                        string GLPOSTREF1DT = "1";
                        string GLPOSTREFDT = "1";
                        string ICPOSTDT = "1";
                        string ICPOSTREFDT = "1";
                        DateTime EXPIRYDATE = Convert.ToDateTime(DT);
                        bool ACTIVEDT = true;
                        string SWITCH1DT = "0";
                        int COMPANYID1DT = comppid;
                        int DelFlagDT = 0;
                        string ITEMIDDT = "";
                        string StatusDT = "";


                        Classes.EcommAdminClass.insert_ICTR_DT(TenentIDDT, MYTRANSIDDT, locationIDDT, MYID, MyProdIDDT, REFTYPEDT, REFSUBTYPEDT, PERIOD_CODEDT, MYSYSNAMEDT, JOIDDT, JOBORDERDTMYIDDT, ACTIVITYIDDT, DESCRIPTIONDT, UOMDT, QUANTITYDT, UNITPRICEDT, AMOUNTDT, OVERHEADAMOUNTDT, BATCHNODT, BIN_IDDT, BIN_TYPEDT, GRNREFDT, DISPERDT, DISAMTDT, TAXPERDT, TAXAMTDT, PROMOTIONAMTDT, CRUP_IDDT, GLPOSTDT, GLPOST1DT, GLPOSTREF1DT, GLPOSTREFDT, ICPOSTDT, ICPOSTREFDT, EXPIRYDATE, ACTIVEDT, SWITCH1DT, COMPANYID1DT, DelFlagDT, ITEMIDDT, StatusDT);

                        Database.TBLPRODUCT ObjProduct = DB.TBLPRODUCTs.Single(p => p.MYPRODID == MyProdIDDT && p.TenentID == TID);

                        string period_code1 = "0";
                        int SIZECODE = 999999998;
                        int COLORID = 999999998;
                        int BinID = 999999998;
                        string BatchNo = "999999998";
                        string Serialize = "NO";
                        string RecodName = "UOM";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate111 = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active1 = "D";
                        int UOM11 = Convert.ToInt32(UOMDT);

                        if (ObjProduct.MultiUOM == true)
                        {
                            Classes.EcommAdminClass.insertICIT_BR_TMP(TID, MyProdIDDT, period_code1, MYSYSNAMEDT, UOM11, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSIDDT, 1, QUANTITYDT, REFERENCE, RecodName, ProdDate, ExpiryDate111, LeadDays2Destroy, Active1, CRUP_IDDT);
                        }
                        bool flag1 = Classes.EcommAdminClass.postprocess(TID, 1, 2101, 21011, MyProdIDDT, MYID, QUANTITYDT, REFERENCE, EXPIRYDATE, MYSYSNAMEDT, MyProdIDDT, ICPOST, UNITPRICEDT, ObjProduct, UOM11);

                        long historyid = itemDT.id;
                        Database.Win_tbl_purchase_history Win_Hobj = DB.Win_tbl_purchase_history.Single(p => p.TenentID == TID && p.id == historyid);
                        Win_Hobj.Live_MytranceIDHD = MYTRANSIDDT;
                        Win_Hobj.Live_MyidDT = MYID;
                        DB.SaveChanges();
                    }
                }


            }
        }
        public static void AddSale()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);
            int comppid = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).CompId);
            List<Database.Win_sales_item> ListSale = DB.Win_sales_item.Where(p => p.TenentID == TID).ToList();

            List<Database.Win_sales_item> SyncHDDTTranssale = ListSale.GroupBy(p => new { p.Customer, p.sales_time }).Select(p => p.FirstOrDefault()).ToList();
            foreach (Database.Win_sales_item itemHD in SyncHDDTTranssale)
            {
                decimal CUSTVENDID = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPNAME1 == itemHD.Customer).Count() > 0 ? Convert.ToDecimal(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == itemHD.Customer).COMPID) : 0;
                DateTime TRANSDATE = Convert.ToDateTime(itemHD.sales_time);
                int Mytrancidd = DB.ICTR_HD.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.ICTR_HD.Where(p => p.TenentID == TID).Max(p => p.MYTRANSID) + 1) : 1;

                string SP = itemHD.Customer.ToString();
                string DT = itemHD.sales_time.ToString();
                string SirialNO11 = "";
                var listtbltranssubtypes1 = DB.tbltranssubtypes.Where(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103).ToList();
                if (listtbltranssubtypes1.Count() > 0)
                {
                    int SirialNO1 = (Convert.ToInt32(listtbltranssubtypes1.Single(p => p.TenentID == TID && p.transid == 4101 && p.transsubid == 410103).serialno) + 1);
                    SirialNO11 = SirialNO1.ToString();
                }
                else
                    SirialNO11 = "";
                if (DB.ICTR_HD.Where(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE).Count() > 0)
                {
                    Mytrancidd = Convert.ToInt32(DB.ICTR_HD.Single(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE).MYTRANSID);
                }

                int TenentID = TID;
                int MYTRANSID = Mytrancidd;
                int ToTenantID = 1;
                int locationID = 1;
                string MainTranType = "O";
                string TranType = "POS Invoice";
                int transid = 4101;
                int transsubid = 410103;
                string MYSYSNAME = "SAL";
                decimal COMPID = comppid;
                CUSTVENDID = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPNAME1 == itemHD.Customer).Count() > 0 ? Convert.ToDecimal(DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == itemHD.Customer).COMPID) : 0;
                string LF = "L";
                string PERIOD_CODE = "0";
                string ACTIVITYCODE = "0";
                decimal MYDOCNO = 2;
                string USERBATCHNO = "";
                decimal TOTQTY = Convert.ToDecimal(DB.Win_sales_item.Where(p => p.TenentID == TID && p.Customer == SP && p.sales_time == DT).Sum(p => p.Qty));
                decimal TOTAMT = Convert.ToDecimal(DB.Win_sales_item.Where(p => p.TenentID == TID && p.Customer == SP && p.sales_time == DT).Sum(p => p.Total));
                decimal AmtPaid = 0;
                string PROJECTNO = "0";
                string CounterID = "0";
                string PrintedCounterInvoiceNo = "5";
                int JOID = 99999999;
                TRANSDATE = Convert.ToDateTime(itemHD.sales_time);
                string REFERENCE = "";
                string NOTES = "";
                int CRUP_ID = 0;
                string GLPOST = "1";
                string GLPOST1 = "1";
                string GLPOSTREF1 = "1";
                string GLPOSTREF = "1";
                string ICPOST = "1";
                string ICPOSTREF = "1";
                string USERID = uname;
                bool ACTIVE = true;
                int COMPANYID = 126;
                DateTime ENTRYDATE = DateTime.Now;
                DateTime ENTRYTIME = DateTime.Now;
                DateTime UPDTTIME = DateTime.Now;
                string InvoiceNO = "";
                decimal Discount = Convert.ToDecimal(0);
                string Status = "SO";
                int Terms = 99999;
                string Custmerid = "";
                string Swit1 = "";
                string ExtraField2 = "";
                int RefTransID = Mytrancidd;
                string Reason = "0";
                string TransDocNo = SirialNO11;
                int LinkTransID = 0;
                int invoice_Type = 0;
                int invoice_Source = 0;
                if (DB.ICTR_HD.Where(p => p.TenentID == TID && p.CUSTVENDID == CUSTVENDID && p.TRANSDATE == TRANSDATE).Count() == 0)
                {
                    Classes.EcommAdminClass.insert_ICTR_HD(TenentID, MYTRANSID, ToTenantID, locationID, MainTranType, TranType, transid, transsubid, MYSYSNAME, COMPID, CUSTVENDID, LF, PERIOD_CODE, ACTIVITYCODE, MYDOCNO, USERBATCHNO, TOTQTY, TOTAMT, AmtPaid, PROJECTNO, CounterID, PrintedCounterInvoiceNo, JOID, TRANSDATE, REFERENCE, NOTES, CRUP_ID, GLPOST, GLPOST1, GLPOSTREF1, GLPOSTREF, ICPOST, ICPOSTREF, USERID, ACTIVE, COMPANYID, ENTRYDATE, ENTRYTIME, UPDTTIME, InvoiceNO, Discount, Status, Terms, Custmerid, Swit1, ExtraField2, RefTransID, Reason, TransDocNo, LinkTransID, invoice_Type, invoice_Source);
                }
                //Sync DT
                List<Database.Win_sales_item> SyncDTTrans = DB.Win_sales_item.Where(p => p.TenentID == TID && p.Customer == SP && p.sales_time == DT).ToList();
                foreach (Database.Win_sales_item itemDT in SyncDTTrans)
                {
                    if (DB.Win_sales_item.Where(p => p.TenentID == TID && p.Live_MytranceIDHD == itemDT.Live_MytranceIDHD && p.Live_MyidDT == itemDT.Live_MyidDT).Count() < 1)
                    {
                        int TenentIDDT = TID;
                        int MYTRANSIDDT = Mytrancidd;
                        int locationIDDT = 1;
                        int MYID = DB.ICTR_DT.Where(p => p.TenentID == TID && p.MYTRANSID == Mytrancidd).Count() > 0 ? Convert.ToInt32(DB.ICTR_DT.Where(p => p.TenentID == TID && p.MYTRANSID == Mytrancidd).Max(p => p.MYID) + 1) : 1;
                        int MyProdIDDT = Convert.ToInt32(itemDT.itemcode);
                        string REFTYPEDT = "LF";
                        string REFSUBTYPEDT = "LF";
                        string PERIOD_CODEDT = "0";
                        string MYSYSNAMEDT = "SAL";
                        int JOIDDT = 99999999;
                        int JOBORDERDTMYIDDT = 1;
                        int ACTIVITYIDDT = 0;
                        string DESCRIPTIONDT = itemDT.itemName;
                        string UOMDT = DB.ICUOMs.Where(p => p.TenentID == TID && p.UOMNAME1 == itemDT.UOM).Count() > 0 ? DB.ICUOMs.Single(p => p.TenentID == TID && p.UOMNAME1 == itemDT.UOM).UOM.ToString() : "99999";
                        int QUANTITYDT = Convert.ToInt32(itemDT.Qty);
                        decimal UNITPRICEDT = Convert.ToDecimal(itemDT.RetailsPrice);
                        decimal AMOUNTDT = QUANTITYDT * UNITPRICEDT;
                        decimal OVERHEADAMOUNTDT = Convert.ToDecimal(0);
                        string BATCHNODT = "";
                        int BIN_IDDT = 1;
                        string BIN_TYPEDT = "Bin";
                        string GRNREFDT = "2";
                        decimal DISPERDT = Convert.ToDecimal(0);
                        decimal DISAMTDT = Convert.ToDecimal(0);
                        decimal TAXPERDT = Convert.ToDecimal(0);
                        decimal TAXAMTDT = Convert.ToDecimal(0);
                        decimal PROMOTIONAMTDT = Convert.ToDecimal(0);
                        int CRUP_IDDT = 0;
                        string GLPOSTDT = "1";
                        string GLPOST1DT = "1";
                        string GLPOSTREF1DT = "1";
                        string GLPOSTREFDT = "1";
                        string ICPOSTDT = "1";
                        string ICPOSTREFDT = "1";
                        DateTime EXPIRYDATE = Convert.ToDateTime(DT);
                        bool ACTIVEDT = true;
                        string SWITCH1DT = "0";
                        int COMPANYID1DT = comppid;
                        int DelFlagDT = 0;
                        string ITEMIDDT = "";
                        string StatusDT = "";


                        Classes.EcommAdminClass.insert_ICTR_DT(TenentIDDT, MYTRANSIDDT, locationIDDT, MYID, MyProdIDDT, REFTYPEDT, REFSUBTYPEDT, PERIOD_CODEDT, MYSYSNAMEDT, JOIDDT, JOBORDERDTMYIDDT, ACTIVITYIDDT, DESCRIPTIONDT, UOMDT, QUANTITYDT, UNITPRICEDT, AMOUNTDT, OVERHEADAMOUNTDT, BATCHNODT, BIN_IDDT, BIN_TYPEDT, GRNREFDT, DISPERDT, DISAMTDT, TAXPERDT, TAXAMTDT, PROMOTIONAMTDT, CRUP_IDDT, GLPOSTDT, GLPOST1DT, GLPOSTREF1DT, GLPOSTREFDT, ICPOSTDT, ICPOSTREFDT, EXPIRYDATE, ACTIVEDT, SWITCH1DT, COMPANYID1DT, DelFlagDT, ITEMIDDT, StatusDT);

                        Database.TBLPRODUCT ObjProduct = DB.TBLPRODUCTs.Single(p => p.MYPRODID == MyProdIDDT && p.TenentID == TID);

                        string period_code1 = "0";
                        int SIZECODE = 999999998;
                        int COLORID = 999999998;
                        int BinID = 999999998;
                        string BatchNo = "999999998";
                        string Serialize = "NO";
                        string RecodName = "UOM";
                        DateTime ProdDate = DateTime.Now;
                        DateTime ExpiryDate111 = DateTime.Now;
                        DateTime LeadDays2Destroy = DateTime.Now;
                        string Active1 = "D";
                        int UOM11 = Convert.ToInt32(UOMDT);

                        if (ObjProduct.MultiUOM == true)
                        {
                            Classes.EcommAdminClass.insertICIT_BR_TMP(TID, MyProdIDDT, period_code1, MYSYSNAMEDT, UOM11, SIZECODE, COLORID, BinID, BatchNo, Serialize, MYTRANSIDDT, 1, QUANTITYDT, REFERENCE, RecodName, ProdDate, ExpiryDate111, LeadDays2Destroy, Active1, CRUP_IDDT);
                        }
                        //sale payment term
                        if (DB.ICTRPayTerms_HD.Where(p => p.TenentID == TID && p.MyTransID == MYTRANSIDDT).Count() < 1)
                        {
                            string IDRefresh = "Cash";
                            string IdApprouv = MYTRANSIDDT.ToString();

                            int PaymentTermsId = Convert.ToInt32(1250001);
                            int AccountID = 0;
                            Decimal Amount = Convert.ToDecimal(TOTAMT);

                            Classes.EcommAdminClass.insertICTRPayTerms_HD(TID, MYTRANSIDDT, PaymentTermsId, CounterID, 1, 0, Amount, IDRefresh, null, null, null, AccountID, CRUP_ID, IdApprouv, 0, false, false, false, false, null, null, null, null, null);
                        }
                        //
                        bool flag1 = Classes.EcommAdminClass.postprocess(TID, 1, 4101, 410103, MyProdIDDT, MYID, QUANTITYDT, REFERENCE, EXPIRYDATE, MYSYSNAMEDT, MyProdIDDT, ICPOST, UNITPRICEDT, ObjProduct, UOM11);

                        Database.Win_sales_item Win_Hobj = DB.Win_sales_item.Single(p => p.TenentID == TID && p.sales_id == itemDT.sales_id && p.itemcode == itemDT.itemcode && p.UOM == itemDT.UOM && p.BatchNo == itemDT.BatchNo);
                        Win_Hobj.Live_MytranceIDHD = MYTRANSIDDT;
                        Win_Hobj.Live_MyidDT = MYID;
                        DB.SaveChanges();
                    }
                }

            }
        }
        public static void AddTblCompSetup()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);
            int comppid = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).CompId);
            //select * from Win_tbl_purchase_history where TenentID=9000009

            List<Database.Win_tbl_customer> CustList = DB.Win_tbl_customer.Where(p => p.TenentID == TID && (p.PeopleType == "Customer" || p.PeopleType == "Supplier")).ToList();
            foreach (Database.Win_tbl_customer suppitem in CustList)
            {
                string SuppName = suppitem.Name.Trim().ToString();
                int id = Convert.ToInt32(suppitem.ID);
                if (DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPID == id).Count() < 1)
                {
                    Database.TBLCOMPANYSETUP SUPPOBJ = new Database.TBLCOMPANYSETUP();
                    int cid = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Max(p => p.COMPID) + 1) : 1;
                    SUPPOBJ.TenentID = TID;
                    SUPPOBJ.COMPID = cid;
                    SUPPOBJ.OldCOMPid = 0;
                    SUPPOBJ.PHYSICALLOCID = "KWT";
                    SUPPOBJ.COMPNAME1 = SuppName;
                    SUPPOBJ.COMPNAME2 = SuppName;
                    SUPPOBJ.COMPNAME3 = SuppName;
                    SUPPOBJ.BirthDate = null;
                    SUPPOBJ.CivilID = "";
                    SUPPOBJ.EMAIL1 = suppitem.EmailAddress;
                    SUPPOBJ.ITMANAGER = "0";
                    SUPPOBJ.ADDR1 = "";
                    SUPPOBJ.ADDR2 = "";
                    SUPPOBJ.CITY = "1";
                    SUPPOBJ.STATE = "1902";
                    SUPPOBJ.POSTALCODE = "";
                    SUPPOBJ.ZIPCODE = "";
                    SUPPOBJ.MYCONLOCID = 1;
                    SUPPOBJ.MYPRODID = 0;
                    SUPPOBJ.COUNTRYID = 126;
                    SUPPOBJ.BUSPHONE1 = "99999999";
                    SUPPOBJ.MOBPHONE = "99999999";
                    SUPPOBJ.FAX = "";
                    SUPPOBJ.PRIMLANGUGE = "1";
                    SUPPOBJ.WEBPAGE = "";
                    SUPPOBJ.ISMINISTRY = false;
                    SUPPOBJ.ISSMB = false;
                    SUPPOBJ.ISCORPORATE = false;
                    SUPPOBJ.INHAWALLY = false;
                    SUPPOBJ.SALER = suppitem.PeopleType == "Customer" ? false : true;
                    SUPPOBJ.BUYER = suppitem.PeopleType == "Customer" ? true : false;
                    SUPPOBJ.SALEDEPROD = false;
                    SUPPOBJ.EMAISUB = false;
                    SUPPOBJ.EMAILSUBDATE = DateTime.Now;
                    SUPPOBJ.PRODUCTDEALIN = "";
                    SUPPOBJ.REMARKS = "";
                    SUPPOBJ.Keyword = "";
                    SUPPOBJ.COMPANYID = 0;
                    SUPPOBJ.Active = "Y";
                    SUPPOBJ.CRUP_ID = 0;
                    SUPPOBJ.CUSERID = "";
                    SUPPOBJ.CPASSWRD = "";
                    SUPPOBJ.USERID = "";
                    SUPPOBJ.ENTRYDATE = DateTime.Now;
                    SUPPOBJ.ENTRYTIME = DateTime.Now;
                    SUPPOBJ.UPDTTIME = DateTime.Now;
                    SUPPOBJ.Approved = 0;
                    SUPPOBJ.CompanyType = suppitem.PeopleType == "Customer" ? "82003" : "82002";
                    SUPPOBJ.BARCODE = cid.ToString();
                    SUPPOBJ.datasource = 0;
                    SUPPOBJ.PACI = "";
                    SUPPOBJ.Marketting = "";
                    DB.TBLCOMPANYSETUPs.AddObject(SUPPOBJ);
                    DB.SaveChanges();
                }
            }

        }
        public static decimal DirectCustSupp()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            if (DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && p.COMPNAME1 == "Unknown" && p.CompanyType == "82002").Count() > 0)
            {
                int Ven = DB.TBLCOMPANYSETUPs.Single(p => p.TenentID == TID && p.COMPNAME1 == "Unknown" && p.CompanyType == "82002").COMPID;
                decimal Vender = Ven;
                return Vender;
            }
            else
            {
                string type = "Supplier";
                Database.TBLCOMPANYSETUP SUPPOBJ = new Database.TBLCOMPANYSETUP();
                int cid = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Count() > 0 ? Convert.ToInt32(DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID).Max(p => p.COMPID) + 1) : 1;
                SUPPOBJ.TenentID = TID;
                SUPPOBJ.COMPID = cid;
                SUPPOBJ.OldCOMPid = 0;
                SUPPOBJ.PHYSICALLOCID = "KWT";
                SUPPOBJ.COMPNAME1 = "Unknown";
                SUPPOBJ.COMPNAME2 = "Unknown";
                SUPPOBJ.COMPNAME3 = "Unknown";
                SUPPOBJ.BirthDate = null;
                SUPPOBJ.CivilID = "";
                SUPPOBJ.EMAIL1 = "Unknown@Unknown.com";
                SUPPOBJ.ITMANAGER = "0";
                SUPPOBJ.ADDR1 = "";
                SUPPOBJ.ADDR2 = "";
                SUPPOBJ.CITY = "1";
                SUPPOBJ.STATE = "1902";
                SUPPOBJ.POSTALCODE = "";
                SUPPOBJ.ZIPCODE = "";
                SUPPOBJ.MYCONLOCID = 1;
                SUPPOBJ.MYPRODID = 0;
                SUPPOBJ.COUNTRYID = 126;
                SUPPOBJ.BUSPHONE1 = "99999999";
                SUPPOBJ.MOBPHONE = "99999999";
                SUPPOBJ.FAX = "";
                SUPPOBJ.PRIMLANGUGE = "1";
                SUPPOBJ.WEBPAGE = "";
                SUPPOBJ.ISMINISTRY = false;
                SUPPOBJ.ISSMB = false;
                SUPPOBJ.ISCORPORATE = false;
                SUPPOBJ.INHAWALLY = false;
                SUPPOBJ.SALER = type == "Customer" ? false : true;
                SUPPOBJ.BUYER = type == "Customer" ? true : false;
                SUPPOBJ.SALEDEPROD = false;
                SUPPOBJ.EMAISUB = false;
                SUPPOBJ.EMAILSUBDATE = DateTime.Now;
                SUPPOBJ.PRODUCTDEALIN = "";
                SUPPOBJ.REMARKS = "";
                SUPPOBJ.Keyword = "";
                SUPPOBJ.COMPANYID = 0;
                SUPPOBJ.Active = "Y";
                SUPPOBJ.CRUP_ID = 0;
                SUPPOBJ.CUSERID = "";
                SUPPOBJ.CPASSWRD = "";
                SUPPOBJ.USERID = "";
                SUPPOBJ.ENTRYDATE = DateTime.Now;
                SUPPOBJ.ENTRYTIME = DateTime.Now;
                SUPPOBJ.UPDTTIME = DateTime.Now;
                SUPPOBJ.Approved = 0;
                SUPPOBJ.CompanyType = type == "Customer" ? "82003" : "82002";
                SUPPOBJ.BARCODE = cid.ToString();
                SUPPOBJ.datasource = 0;
                SUPPOBJ.PACI = "";
                SUPPOBJ.Marketting = "";
                DB.TBLCOMPANYSETUPs.AddObject(SUPPOBJ);
                DB.SaveChanges();

                decimal Vender = cid;
                return Vender;
            }
        }
        public static void Synchonizes()
        {
            AddTblCompSetup();
            AddProduct();
            AddPurchase();
            AddSale();
            Win_PRoduct();
            Win_Customer();
        }
        //Syncronous web to win

        public static void Win_PRoduct()
        {
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);

            string SOID = DB.Win_usermgt.Where(p => p.TenentID == TID).Count() > 0 ? DB.Win_usermgt.Where(p => p.TenentID == TID).First().Shopid : "";
            List<Database.TBLPRODUCT> ProdList = DB.TBLPRODUCTs.Where(p => p.TenentID == TID).ToList();
            foreach (Database.TBLPRODUCT itemss in ProdList)
            {
                string uomid = itemss.UOM.ToString();
                if (DB.Win_purchase.Where(p => p.TenentID == TID && p.product_id == itemss.MYPRODID).Count() < 1)
                {
                    Database.Win_purchase Purobj = new Database.Win_purchase();
                    Purobj.TenentID = TID;
                    Purobj.product_id = Convert.ToInt32(itemss.MYPRODID);
                    Purobj.product_name = itemss.ProdName1;
                    Purobj.category = itemss.MainCategoryID.ToString();
                    Purobj.supplier = "1";
                    Purobj.imagename = "item.png";
                    Purobj.taxapply = 0;
                    Purobj.Shopid = SOID;
                    Purobj.status = 1;
                    Purobj.UOM = "Y";
                    Purobj.UploadDate = DateTime.Now;
                    Purobj.Uploadby = uname;
                    Purobj.SynID = 1;
                    Purobj.product_name_Arabic = itemss.ProdName1;
                    Purobj.category_arabic = "";
                    Purobj.product_name_print = itemss.ProdName1;
                    Purobj.IsPerishable = 0;
                    Purobj.CustItemCode = itemss.MYPRODID.ToString();
                    Purobj.BarCode = itemss.MYPRODID.ToString();
                    DB.Win_purchase.AddObject(Purobj);
                }
            }
        }
        public static void Win_Customer()
        {
            //82003
            int TID = Convert.ToInt32(((USER_MST)System.Web.HttpContext.Current.Session["USER"]).TenentID);
            string uname = (((USER_MST)System.Web.HttpContext.Current.Session["USER"]).LOGIN_ID);

            List<Database.TBLCOMPANYSETUP> CustList = DB.TBLCOMPANYSETUPs.Where(p => p.TenentID == TID && (p.CompanyType == "82002" || p.CompanyType == "82003")).ToList();
            foreach (Database.TBLCOMPANYSETUP itemss in CustList)
            {
                if (DB.Win_tbl_customer.Where(p => p.TenentID == TID && p.ID == itemss.COMPID).Count() < 1)
                {
                    Database.Win_tbl_customer custobj = new Database.Win_tbl_customer();
                    custobj.TenentID = TID;
                    custobj.ID = itemss.COMPID;
                    custobj.Name = itemss.COMPNAME1;
                    custobj.EmailAddress = itemss.EMAIL1;
                    custobj.Phone = itemss.MOBPHONE;
                    custobj.Address = itemss.ADDR1;
                    custobj.City = "Hawalli";
                    custobj.PeopleType = itemss.CompanyType == "82003" ? "Customer" : "Supplier";
                    custobj.UploadDate = DateTime.Now;
                    custobj.Uploadby = uname;
                    custobj.SynID = 1;
                    custobj.NameArabic = itemss.COMPNAME1;
                    custobj.DateOfBirth = itemss.BirthDate;
                    custobj.Remark = itemss.REMARKS;
                    DB.Win_tbl_customer.AddObject(custobj);
                    DB.SaveChanges();
                }
            }
        }


    }
}
