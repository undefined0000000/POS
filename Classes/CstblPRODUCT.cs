using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CstblPRODUCT
    {
        public int TenentID { get; set; }
        public long LOCATION_ID { get; set; }
        public long MYPRODID { get; set; }
        public string UserProdID { get; set; }
        public string BarCode { get; set; }
        public string AlternateCode1 { get; set; }
        public string AlternateCode2 { get; set; }
        public Nullable<int> UOM { get; set; }
        public string COLORID { get; set; }
        public Nullable<int> GROUPID { get; set; }
        public Nullable<int> SIZECODE { get; set; }
        public Nullable<int> ProdTypeRefId { get; set; }
        public Nullable<int> SupplyMethodID { get; set; }
        public Nullable<int> ProdMethodID { get; set; }
        public Nullable<int> SalDeptID { get; set; }
        public string ShortName { get; set; }
        public string ProdName1 { get; set; }
        public string ProdName2 { get; set; }
        public string ProdName3 { get; set; }
        public string DescToprint { get; set; }
        public string Brand { get; set; }
        public Nullable<bool> Serialized { get; set; }
        public Nullable<bool> HotItem { get; set; }
        public Nullable<bool> SKUProduction { get; set; }
        public string SKU { get; set; }
        public Nullable<bool> MultiSize { get; set; }
        public Nullable<bool> MultiUOM { get; set; }
        public Nullable<bool> MultiColor { get; set; }
        public Nullable<bool> MultiBinStore { get; set; }
        public Nullable<bool> Perishable { get; set; }
        public Nullable<bool> SaleAllow { get; set; }
        public Nullable<bool> PurAllow { get; set; }
        public string REMARKS { get; set; }
        public string keywords { get; set; }
        public Nullable<decimal> basecost { get; set; }
        public Nullable<decimal> onlinesale1 { get; set; }
        public Nullable<decimal> onlinesale2 { get; set; }
        public Nullable<decimal> msrp { get; set; }
        public Nullable<decimal> price { get; set; }
        public string currency { get; set; }
        public Nullable<long> QTYINHAND { get; set; }
        public Nullable<long> QTYRCVD { get; set; }
        public Nullable<long> QTYSOLD { get; set; }
        public byte[] PICTURE { get; set; }
        public string ACTIVE { get; set; }
        public string DIRECTSALE { get; set; }
        public string LINK2DIRECT { get; set; }
        public Nullable<long> Display_ID { get; set; }
        public Nullable<System.DateTime> DISPDATE3 { get; set; }
        public Nullable<System.DateTime> LASTPURDATE { get; set; }
        public Nullable<System.DateTime> LASTSALDATE { get; set; }
        public string Warranty { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public string SUBPRODNAME { get; set; }
        public string SUBPRODNAMEO { get; set; }
        public string SUBPRODNAMECH { get; set; }
        public Nullable<int> SORTNUMBER { get; set; }
        public string PLACEHOLDERLINE { get; set; }
        public string PLACEHOLDERCOLUMN { get; set; }
        public string PLACEHOLDERALIRL { get; set; }
        public string ONLINESALEALOW { get; set; }
        public string IsSoftware { get; set; }
        public string InternalNotes { get; set; }
        public Nullable<decimal> onlinesale3 { get; set; }
        public Nullable<long> MainCategoryID { get; set; }
        public Nullable<bool> DevloperActiv { get; set; }
        public string Option1 { get; set; }
        public Nullable<bool> Option2 { get; set; }
        public Nullable<System.DateTime> Option3 { get; set; }
        public string Option4 { get; set; }
        public Nullable<bool> Appove { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public byte[] ChangesDate { get; set; }
        public Nullable<bool> POSAllow { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string RecipeType { get; set; }
        public Nullable<int> recNo { get; set; }
    }

  public class CstblPRODUCTList
    {
      public IList<CstblPRODUCT> data { get; set; }
  }
  public class GetCstblPRODUCT
    {
      public CstblPRODUCT data { get; set; }
  }
}
