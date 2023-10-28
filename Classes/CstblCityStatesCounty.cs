using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class CstblCityStatesCounty
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int COUNTRYID { get; set; }
        public string CityEnglish { get; set; }
        public string CityArabic { get; set; }
        public string CityOther { get; set; }
        public string LandLine { get; set; }
        public string ACTIVE1 { get; set; }
        public string ACTIVE2 { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public string AssignedRoute { get; set; }
        public string SHORTCODE { get; set; }
        public string ZONE { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class CstblCityStatesCountyList
    {
        public IList<CstblCityStatesCounty> data { get; set; }
    }
    public class GetCstblCityStatesCounty
{
        public CstblCityStatesCounty data { get; set; }
    }
}
