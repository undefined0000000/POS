using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CsREFTABLE
    {
        public int TenentID { get; set; }
        public int REFID { get; set; }
        public string REFTYPE { get; set; }
        public string REFSUBTYPE { get; set; }
        public string SHORTNAME { get; set; }
        public string REFNAME1 { get; set; }
        public string REFNAME2 { get; set; }
        public string REFNAME3 { get; set; }
        public string SWITCH1 { get; set; }
        public string SWITCH2 { get; set; }
        public string SWITCH3 { get; set; }
        public Nullable<int> SWITCH4 { get; set; }
        public string Remarks { get; set; }
        public string ACTIVE { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string Infrastructure { get; set; }
        public string REF_Image { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CsREFTABLEList
    {
        public IList<CsREFTABLE> data { get; set; }
    }
    public class GetCsREFTABLE
    {
        public CsREFTABLE data { get; set; }
    }
}
