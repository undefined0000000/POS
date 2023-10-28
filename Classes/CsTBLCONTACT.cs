using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsTBLCONTACT
    {
        public int TenentID { get; set; }
        public decimal ContactMyID { get; set; }
        public Nullable<int> CONTACTID { get; set; }
        public string PHYSICALLOCID { get; set; }
        public string PersName1 { get; set; }
        public string PersName2 { get; set; }
        public string PersName3 { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string CivilID { get; set; }
        public string EMAIL1 { get; set; }
        public string MOBPHONE { get; set; }
        public string ITMANAGER { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string POSTALCODE { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<int> MYCONLOCID { get; set; }
        public Nullable<int> COUNTRYID { get; set; }
        public string BUSPHONE1 { get; set; }
        public string Active { get; set; }
        public string REMARKS { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<int> COMPANYID { get; set; }
        public Nullable<int> MYCATSUBID { get; set; }
        public string MYPRODID { get; set; }
        public string DESERIAL { get; set; }
        public Nullable<int> CATID { get; set; }
        public string CATTYPE { get; set; }
        public string SUBCATTYPE { get; set; }
        public Nullable<int> SUBCATID { get; set; }
        public string PERSNAME { get; set; }
        public string PERSNAMEO { get; set; }
        public string PERSNAMEO2 { get; set; }
        public string EMAIL2 { get; set; }
        public string PRIMLANGUGE { get; set; }
        public string WEBPAGE { get; set; }
        public Nullable<bool> ISSMB { get; set; }
        public Nullable<bool> INHAWALLY { get; set; }
        public Nullable<bool> EMAISUB { get; set; }
        public Nullable<System.DateTime> EMAILSUBDATE { get; set; }
        public string PRODUCTDEALIN { get; set; }
        public Nullable<bool> SALER { get; set; }
        public Nullable<bool> BUYER { get; set; }
        public Nullable<bool> FREELANCER { get; set; }
        public Nullable<bool> SALEDEPROD { get; set; }
        public string CUSERID { get; set; }
        public string CPASSWRD { get; set; }
        public string USERID { get; set; }
        public Nullable<System.DateTime> ENTRYTIME { get; set; }
        public Nullable<System.DateTime> UPDTTIME { get; set; }
        public string FaxID { get; set; }
        public string IMG { get; set; }
        public string Instuctor_Username { get; set; }
        public Nullable<int> ContacType { get; set; }
        public string BARCODE { get; set; }
        public Nullable<int> Switch1 { get; set; }
        public Nullable<int> Switch2 { get; set; }
        public Nullable<int> Switch3 { get; set; }
        public Nullable<int> Switch4 { get; set; }
        public string Switch5 { get; set; }
        public string PACI { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
        public string fb_token_id { get; set; }
        public string google_token_id { get; set; }
        public string device_id { get; set; }
    }

  public class CsTBLCONTACTList
    {
      public IList<CsTBLCONTACT> data { get; set; }
  }
  public class GetCsTBLCONTACT
    {
      public CsTBLCONTACT data { get; set; }
  }
}
