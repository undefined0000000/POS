using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CsTbl_Multi_Color_Size_Mst
    {
        public int TenentID { get; set; }
        public string RecordType { get; set; }
        public int RecTypeID { get; set; }
        public int CompniyAndContactID { get; set; }
        public int RunSerial { get; set; }
        public Nullable<int> Recource { get; set; }
        public string RecValue { get; set; }
        public Nullable<bool> Active { get; set; }
        public string RecourceName { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }

    }

    public class CsTbl_Multi_Color_Size_MstList
    {
        public IList<CsTbl_Multi_Color_Size_Mst> data { get; set; }
    }
    public class GetCsTbl_Multi_Color_Size_Mst
    {
        public CsTbl_Multi_Color_Size_Mst data { get; set; }
    }
}
