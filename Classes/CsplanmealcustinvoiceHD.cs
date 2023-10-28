using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsplanmealcustinvoiceHD
    {
        public int TenentID { get; set; }
        public int MYTRANSID { get; set; }
        public long LOCATION_ID { get; set; }
        public int CustomerID { get; set; }
        public int planid { get; set; }
        public int DayNumber { get; set; }
        public Nullable<int> TransID { get; set; }
        public string ContractID { get; set; }
        public Nullable<int> DefaultDriverID { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public string WeekofDay { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> TotalSubDays { get; set; }
        public Nullable<int> DeliveredDays { get; set; }
        public Nullable<System.DateTime> NExtDeliveryDate { get; set; }
        public Nullable<int> NExtDeliveryNum { get; set; }
        public Nullable<bool> SubscriptionOnHold { get; set; }
        public Nullable<System.DateTime> HoldDate { get; set; }
        public Nullable<System.DateTime> UnHoldDate { get; set; }
        public Nullable<int> Holdbyuser { get; set; }
        public string HoldREmark { get; set; }
        public Nullable<int> SubscriptonDayNumber { get; set; }
        public Nullable<decimal> Total_price { get; set; }
        public string ShortRemark { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public byte[] ChangesDate { get; set; }
        public Nullable<int> DriverID { get; set; }
        public string CStatus { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string PaymentStatus { get; set; }
    }

  public class CsplanmealcustinvoiceHDList
    {
      public IList<CsplanmealcustinvoiceHD> data { get; set; }
  }
  public class GetCsplanmealcustinvoiceHD
    {
      public CsplanmealcustinvoiceHD data { get; set; }
  }
}
