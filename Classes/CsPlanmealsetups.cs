using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsPlanmealsetups
    {
        public int TenentID { get; set; }
        public long LOCATION_ID { get; set; }
        public int planid { get; set; }
        public int MealType { get; set; }
        public long MYPRODID { get; set; }
        public int UOM { get; set; }
        public Nullable<int> serial_no { get; set; }
        public Nullable<decimal> Calories { get; set; }
        public Nullable<decimal> Protein { get; set; }
        public Nullable<decimal> Carbs { get; set; }
        public Nullable<decimal> Fat { get; set; }
        public Nullable<decimal> ItemWeight { get; set; }
        public Nullable<decimal> Item_cost { get; set; }
        public string ShortRemark { get; set; }
        public Nullable<int> MealRepeatInDay { get; set; }
        public Nullable<int> MealRepeatInWeek { get; set; }
        public Nullable<int> MealRepeatInMonth { get; set; }
        public Nullable<int> MealRepeatInYear { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public byte[] ChangesDate { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

  public class CsPlanmealsetupsList
    {
      public IList<CsPlanmealsetups> data { get; set; }
  }
  public class GetCsPlanmealsetups
    {
      public CsPlanmealsetups data { get; set; }
  }
}
