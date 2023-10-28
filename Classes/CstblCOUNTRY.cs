using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CstblCOUNTRY
    {
        public int TenentID { get; set; }
        public int COUNTRYID { get; set; }
        public string REGION1 { get; set; }
        public string COUNAME1 { get; set; }
        public string COUNAME2 { get; set; }
        public string COUNAME3 { get; set; }
        public string CAPITAL { get; set; }
        public string NATIONALITY1 { get; set; }
        public string NATIONALITY2 { get; set; }
        public string NATIONALITY3 { get; set; }
        public string CURRENCYNAME1 { get; set; }
        public string CURRENCYNAME2 { get; set; }
        public string CURRENCYNAME3 { get; set; }
        public decimal CURRENTCONVRATE { get; set; }
        public string CURRENCYSHORTNAME1 { get; set; }
        public string CURRENCYSHORTNAME2 { get; set; }
        public string CURRENCYSHORTNAME3 { get; set; }
        public string CountryType { get; set; }
        public string CountryTSubType { get; set; }
        public string Sovereignty { get; set; }
        public string ISO4217CurCode { get; set; }
        public string ISO4217CurName { get; set; }
        public string ITUTTelephoneCode { get; set; }
        public Nullable<int> FaxLength { get; set; }
        public Nullable<int> TelLength { get; set; }
        public string ISO3166_1_2LetterCode { get; set; }
        public string ISO3166_1_3LetterCode { get; set; }
        public string ISO3166_1Number { get; set; }
        public string IANACountryCodeTLD { get; set; }
        public string Active { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CstblCOUNTRYList
    {
        public IList<CstblCOUNTRY> data { get; set; }
    }
    public class GetCstblCOUNTRY
    {
        public CstblCOUNTRY data { get; set; }
    }
}
