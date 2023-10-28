using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CstblProduct_Plan
    {
        public int TenentID { get; set; }
        public int locationid { get; set; }
        public int planid { get; set; }
        public string planname1 { get; set; }
        public string planname2 { get; set; }
        public string planname3 { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<decimal> Plan_cost { get; set; }
        public int Plan_price1 { get; set; }
        public Nullable<int> Plan_price2 { get; set; }
        public Nullable<int> Plan_price3 { get; set; }
        public Nullable<int> MealRepeatInDay { get; set; }
        public Nullable<int> MealRepeatInWeek { get; set; }
        public Nullable<int> MealRepeatInMonth { get; set; }
        public Nullable<int> MealRepeatInYear { get; set; }
        public Nullable<int> ccount { get; set; }
        public string Plan_sale { get; set; }
        public Nullable<int> account { get; set; }
        public Nullable<int> crupid { get; set; }
        public string Plan_Image { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public Nullable<int> Switch1 { get; set; }
        public string Switch2 { get; set; }
        public Nullable<bool> Switch3 { get; set; }
        public string CombPackID { get; set; }
        public Nullable<int> SortBy { get; set; }
        public Nullable<bool> CustomAllow { get; set; }
    }

    public class CstblProduct_PlanList
    {
        public IList<CstblProduct_Plan> data { get; set; }
    }
    public class GetCstblProduct_Plan
    {
        public CstblProduct_Plan data { get; set; }
    }
}
