using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CstblStates
    {
        public int COUNTRYID { get; set; }
        public int StateID { get; set; }
        public string MYNAME1 { get; set; }
        public string MYNAME2 { get; set; }
        public string MYNAME3 { get; set; }
        public string ACTIVE1 { get; set; }
        public string ACTIVE2 { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CstblStatesList
    {
        public IList<CstblStates> data { get; set; }
    }
    public class GetCstblStates
    {
        public CstblStates data { get; set; }
    }
}
