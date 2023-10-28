using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CstblLanguage
    {
        public int TenentID { get; set; }
        public int MYCONLOCID { get; set; }
        public Nullable<int> COUNTRYID { get; set; }
        public string LangName1 { get; set; }
        public string LangName2 { get; set; }
        public string LangName3 { get; set; }
        public string CULTUREOCDE { get; set; }
        public string ACTIVE { get; set; }
        public string REMARKS { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CstblLanguageList
    {
        public IList<CstblLanguage> data { get; set; }
    }
    public class GetCstblLanguage
    {
        public CstblLanguage data { get; set; }
    }
}
