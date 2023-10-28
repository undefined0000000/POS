using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CsIcUom
    {
        public int TenentID { get; set; }
        public int UOM { get; set; }
        public string UOMNAMESHORT { get; set; }
        public string UOMNAME1 { get; set; }
        public string UOMNAME2 { get; set; }
        public string UOMNAME3 { get; set; }
        public string REMARKS { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string Active { get; set; }
        public string UOMNAME { get; set; }
        public string UOMNAMEO { get; set; }
        public string UOM_TYPE { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CsIcUomList
    {
        public IList<CsIcUom> data { get; set; }
    }
    public class GetCsIcUom
    {
        public CsIcUom data { get; set; }
    }
}
