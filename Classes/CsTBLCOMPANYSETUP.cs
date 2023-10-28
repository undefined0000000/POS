using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsTBLCOMPANYSETUP
    {
        public int TenentID { get; set; }
        public int COMPID { get; set; }
        public Nullable<int> OldCOMPid { get; set; }
        public string PHYSICALLOCID { get; set; }
        public string COMPNAME1 { get; set; }
        public string COMPNAME2 { get; set; }
        public string COMPNAME3 { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string CivilID { get; set; }
        public string EMAIL { get; set; }
        public string EMAIL1 { get; set; }
        public string EMAIL2 { get; set; }
        public string ITMANAGER { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string POSTALCODE { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<int> MYCONLOCID { get; set; }
        public Nullable<long> MYPRODID { get; set; }
        public Nullable<int> COUNTRYID { get; set; }
        public string BUSPHONE1 { get; set; }
        public string BUSPHONE2 { get; set; }
        public string BUSPHONE3 { get; set; }
        public string BUSPHONE4 { get; set; }
        public string MOBPHONE { get; set; }
        public string FAX { get; set; }
        public string FAX1 { get; set; }
        public string FAX2 { get; set; }
        public string PRIMLANGUGE { get; set; }
        public string WEBPAGE { get; set; }
        public Nullable<bool> ISMINISTRY { get; set; }
        public Nullable<bool> ISSMB { get; set; }
        public Nullable<bool> ISCORPORATE { get; set; }
        public Nullable<bool> INHAWALLY { get; set; }
        public Nullable<bool> SALER { get; set; }
        public Nullable<bool> BUYER { get; set; }
        public Nullable<bool> SALEDEPROD { get; set; }
        public Nullable<bool> EMAISUB { get; set; }
        public Nullable<System.DateTime> EMAILSUBDATE { get; set; }
        public string PRODUCTDEALIN { get; set; }
        public string REMARKS { get; set; }
        public string Keyword { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public Nullable<int> BUSID { get; set; }
        public Nullable<int> MYCATSUBID { get; set; }
        public string COMPNAME { get; set; }
        public string COMPNAMEO { get; set; }
        public string COMPNAMECH { get; set; }
        public string Active { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string CUSERID { get; set; }
        public string CPASSWRD { get; set; }
        public string USERID { get; set; }
        public Nullable<System.DateTime> ENTRYDATE { get; set; }
        public Nullable<System.DateTime> ENTRYTIME { get; set; }
        public Nullable<System.DateTime> UPDTTIME { get; set; }
        public Nullable<int> Approved { get; set; }
        public string CompanyType { get; set; }
        public byte[] Images { get; set; }
        public string BARCODE { get; set; }
        public string Avtar { get; set; }
        public Nullable<bool> Reload { get; set; }
        public Nullable<int> datasource { get; set; }
        public string PACI { get; set; }
        public string Marketting { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

  public class CsTBLCOMPANYSETUPList
    {
      public IList<CsTBLCOMPANYSETUP> data { get; set; }
  }
  public class GetCsTBLCOMPANYSETUP
    {
      public CsTBLCOMPANYSETUP data { get; set; }
  }
}
