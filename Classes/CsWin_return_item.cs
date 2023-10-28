using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsWin_return_item
    {
        public int TenentID { get; set; }
        public int ID { get; set; }
        public long return_id { get; set; }
        public string item_id { get; set; }
        public string itemName { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> RetailsPrice { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string return_time { get; set; }
        public string custno { get; set; }
        public string emp { get; set; }
        public string SoldInvoiceNo { get; set; }
        public string Comment { get; set; }
        public Nullable<decimal> disamt { get; set; }
        public Nullable<decimal> vatamt { get; set; }
        public Nullable<System.DateTime> logdate { get; set; }
        public string UOM { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string Customer { get; set; }
        public string ExpiryDate { get; set; }
        public string ReturnReason { get; set; }
        public Nullable<int> IsWastage { get; set; }
        public string BatchNo { get; set; }

    }

  public class CsWin_return_itemList
    {
      public IList<CsWin_return_item> data { get; set; }
  }
  public class GetCsWin_return_item
    {
      public CsWin_return_item data { get; set; }
  }
}
