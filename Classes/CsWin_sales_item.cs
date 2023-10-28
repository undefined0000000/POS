using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsWin_sales_item
    {
        public int TenentID { get; set; }
        public int sales_id { get; set; }
        public long item_id { get; set; }
        public string itemName { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> RetailsPrice { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> profit { get; set; }
        public string sales_time { get; set; }
        public string itemcode { get; set; }
        public Nullable<decimal> discount { get; set; }
        public string taxapply { get; set; }
        public Nullable<int> status { get; set; }
        public string UOM { get; set; }
        public string Customer { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> OnlineTransID { get; set; }
        public Nullable<int> SynID { get; set; }
        public string InvoiceNO { get; set; }
        public Nullable<decimal> returnQty { get; set; }
        public Nullable<decimal> returnTotal { get; set; }
        public string product_name_print { get; set; }
        public string ExpiryDate { get; set; }
        public string OrderStutas { get; set; }
        public string SoldBy { get; set; }
        public Nullable<int> COD { get; set; }
        public string Driver { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
        public string PaymentMode { get; set; }
        public string Shopid { get; set; }
        public string c_id { get; set; }
        public string BatchNo { get; set; }
        public string OrderWay { get; set; }

    }

  public class CsWin_sales_itemList
    {
      public IList<CsWin_sales_item> data { get; set; }
  }
  public class GetCsWin_sales_item
    {
      public CsWin_sales_item data { get; set; }
  }
}
