using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class Csplanmealcustinvoice
    {
        public int TenentID { get; set; }
        public int MYTRANSID { get; set; }
        public int DeliveryID { get; set; }
        public long MYPRODID { get; set; }
        public int UOM { get; set; }
        public long LOCATION_ID { get; set; }
        public int CustomerID { get; set; }
        public int planid { get; set; }
        public int MealType { get; set; }
        public string ProdName1 { get; set; }
        public Nullable<int> OprationDay { get; set; }
        public int DayNumber { get; set; }
        public Nullable<int> TransID { get; set; }
        public string ContractID { get; set; }
        public string WeekofDay { get; set; }
        public string NameOfDay { get; set; }
        public Nullable<int> TotalWeek { get; set; }
        public Nullable<int> NoOfWeek { get; set; }
        public Nullable<int> DisplayWeek { get; set; }
        public Nullable<int> TotalDeliveryDay { get; set; }
        public Nullable<int> ActualDeliveryDay { get; set; }
        public Nullable<int> ExpectedDeliveryDay { get; set; }
        public Nullable<int> DeliveryTime { get; set; }
        public Nullable<int> DeliveryMeal { get; set; }
        public Nullable<int> DriverID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> ExpectedDelDate { get; set; }
        public Nullable<System.DateTime> ActualDelDate { get; set; }
        public Nullable<System.DateTime> NExtDeliveryDate { get; set; }
        public Nullable<int> ReturnReason { get; set; }
        public Nullable<System.DateTime> ReasonDate { get; set; }
        public Nullable<System.DateTime> ProductionDate { get; set; }
        public Nullable<int> chiefID { get; set; }
        public Nullable<int> SubscriptonDayNumber { get; set; }
        public Nullable<decimal> Calories { get; set; }
        public Nullable<decimal> Protein { get; set; }
        public Nullable<decimal> Carbs { get; set; }
        public Nullable<decimal> Fat { get; set; }
        public Nullable<decimal> ItemWeight { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> Item_cost { get; set; }
        public Nullable<decimal> Item_price { get; set; }
        public Nullable<decimal> Total_price { get; set; }
        public string ShortRemark { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public byte[] ChangesDate { get; set; }
        public Nullable<int> DeliverySequence { get; set; }
        public Nullable<int> Switch1 { get; set; }
        public Nullable<int> Switch2 { get; set; }
        public string Switch3 { get; set; }
        public string Switch4 { get; set; }
        public string Switch5 { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

  public class CsplanmealcustinvoiceList
    {
      public IList<Csplanmealcustinvoice> data { get; set; }
  }
  public class GetCsplanmealcustinvoice
    {
      public Csplanmealcustinvoice data { get; set; }
  }
}
