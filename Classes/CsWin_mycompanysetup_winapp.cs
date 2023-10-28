using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsWin_mycompanysetup_winapp
    {
        public int TenentID { get; set; }
        public string Shopid { get; set; }
        public int TenentGroupID { get; set; }
        public Nullable<int> PhysicalLocID { get; set; }
        public string COMPNAME1 { get; set; }
        public string COMPNAME2 { get; set; }
        public string COMPNAME3 { get; set; }
        public Nullable<int> COUNTRYID { get; set; }
        public Nullable<int> ARABIC { get; set; }
        public string Mac_Addr { get; set; }
        public string DefaultLanguage { get; set; }
        public string ActivationCode { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public Nullable<System.DateTime> installDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string AppVer { get; set; }
        public Nullable<System.DateTime> AppVerDate { get; set; }
        public string DBVer { get; set; }
        public Nullable<System.DateTime> DBVerDate { get; set; }
        public Nullable<int> AllowUser { get; set; }
    }

  public class CsWin_mycompanysetup_winappList
    {
      public IList<CsWin_mycompanysetup_winapp> data { get; set; }
  }
  public class GetCsWin_mycompanysetup_winapp
    {
      public CsWin_mycompanysetup_winapp data { get; set; }
  }
}
