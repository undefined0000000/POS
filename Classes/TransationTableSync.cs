using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class TransationTableSync
    {       
        public IList<CsIcUom> IcUom { get; set; }
        public IList<CstblLanguage> tblLanguage { get; set; }
        public IList<CsTBLLOCATION> TBLLOCATION { get; set; }
        public IList<CsREFTABLE> REFTABLE { get; set; }
        public IList<CstblProduct_Plan> tblProduct_Plan { get; set; }
        public IList<CstblCOUNTRY> tblCOUNTRY { get; set; }
        public IList<CstblPRODUCT> tblPRODUCT { get; set; }
        public IList<Csplanmealsetup> planmealsetup { get; set; }
        public IList<CsTbl_Multi_Color_Size_Mst> Tbl_Multi_Color_Size_Mst { get; set; }
        public IList<CsICITEMS_PRICE> ICITEMS_PRICE { get; set; }

    }

    public class TransPeram
    {
        public int TenentID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
    }
}
