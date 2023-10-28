using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
  public class CsUserMst
    {
        public int TenentID { get; set; }
        public int USER_ID { get; set; }
        public int LOCATION_ID { get; set; }
        public int CRUP_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME1 { get; set; }
        public string LAST_NAME1 { get; set; }
        public string FIRST_NAME2 { get; set; }
        public string LAST_NAME2 { get; set; }
        public string LOGIN_ID { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> USER_TYPE { get; set; }
        public string REMARKS { get; set; }
        public string ACTIVE_FLAG { get; set; }
        public Nullable<System.DateTime> LAST_LOGIN_DT { get; set; }
        public Nullable<int> USER_DETAIL_ID { get; set; }
        public string ACC_LOCK { get; set; }
        public string FIRST_TIME { get; set; }
        public string PASSWORD_CHNG { get; set; }
        public string THEME_NAME { get; set; }
        public Nullable<System.DateTime> APPROVAL_DT { get; set; }
        public string VERIFICATION_CD { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> Till_DT { get; set; }
        public Nullable<bool> IsSignature { get; set; }
        public string SignatureImage { get; set; }
        public string Avtar { get; set; }
        public Nullable<int> CompId { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<bool> CheckinSwitch { get; set; }
        public Nullable<long> LoginActive { get; set; }
        public Nullable<bool> ACTIVEUSER { get; set; }
        public Nullable<System.DateTime> USERDATE { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
    }

  public class CsUserMstList
  {
      public IList<CsUserMst> data { get; set; }
  }
  public class GetCsUserMst
  {
      public CsUserMst data { get; set; }
  }
}
