using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsWin_purchase
    {
        public int TenentID { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string category { get; set; }
        public string supplier { get; set; }
        public string imagename { get; set; }
        public Nullable<int> taxapply { get; set; }
        public string Shopid { get; set; }
        public Nullable<int> status { get; set; }
        public string UOM { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string product_name_Arabic { get; set; }
        public string category_arabic { get; set; }
        public string product_name_print { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<int> IsPerishable { get; set; }

    }

  public class CsWin_purchaseList
    {
      public IList<CsWin_purchase> data { get; set; }
  }
  public class GetCsWin_purchase
    {
      public CsWin_purchase data { get; set; }
  }
}
