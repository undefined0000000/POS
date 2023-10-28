using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CsTBLLOCATION
    {
        public int TenentID { get; set; }
        public int LOCATIONID { get; set; }
        public string PHYSICALLOCID { get; set; }
        public string LOCNAME1 { get; set; }
        public string LOCNAME2 { get; set; }
        public string LOCNAME3 { get; set; }
        public string ADDRESS { get; set; }
        public string DEPT { get; set; }
        public string SECTIONCODE { get; set; }
        public string ACCOUNT { get; set; }
        public int MAXDISCOUNT { get; set; }
        public string USERID { get; set; }
        public System.DateTime ENTRYDATE { get; set; }
        public System.DateTime ENTRYTIME { get; set; }
        public System.DateTime UPDTTIME { get; set; }
        public string Active { get; set; }
        public string LOCNAME { get; set; }
        public string LOCNAMEO { get; set; }
        public string LOCNAMECH { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CsTBLLOCATIONList
    {
        public IList<CsTBLLOCATION> data { get; set; }
    }
    public class GetCsTBLLOCATION
    {
        public CsTBLLOCATION data { get; set; }
    }
}
