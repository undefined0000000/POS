using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace Web.Sales
{
    public class PropertyFile
    {
        CallEntities DB = new CallEntities();
        DateTime CurrentDate = DateTime.Now;
        public PropertyFile()
        {
            int CODID = 0;
           

            LangId = 1;
            ToTenantID = 1;
            TOLOCATIONID = 1;
            TranType = "I";
            transid = 5;
            transid = 1;
            MYSYSNAME = "IC";
            COMPID = 1;
            if (CODID != 0)
                PERIOD_CODE = CODID.ToString();
            else
                PERIOD_CODE = "20";
            MYDOCNO = "2";
            AmtPaid = -1;
            CounterID = "0";
            PrintedCounterInvoiceNo = "5";
            JOID = 1;
            GLPOST = "2";
            GLPOST1 = "2";
            GLPOSTREF = "2";
            GLPOSTREF1 = "2";
            ICPOST = "2";
            ICPOSTREF = "2";
            CountryID = 36;
            QuantityDelivered = 0;
            Amount = 500;
            DeliveredLocaTenantID = null;
            AmountDelivered = null;
            DeliveryRef = "DeliverRef";
            UserBatch = "123";
            maintranstype = "ACT";
            TransType = "PaymentVoucher";
        }
        public int LangId { get; set; }
        public int ToTenantID { get; set; }
        public int TOLOCATIONID { get; set; }
        public string TranType { get; set; }
        public int transid { get; set; }
        public int transsubid { get; set; }
        public string MYSYSNAME { get; set; }
        public int COMPID { get; set; }
        public string PERIOD_CODE { get; set; }
        public string MYDOCNO { get; set; }
        public int AmtPaid { get; set; }
        public string CounterID { get; set; }
        public string PrintedCounterInvoiceNo { get; set; }
        public int JOID { get; set; }
        public string GLPOST { get; set; }
        public string GLPOST1 { get; set; }
        public string GLPOSTREF { get; set; }
        public string GLPOSTREF1 { get; set; }
        public string ICPOST { get; set; }
        public string ICPOSTREF { get; set; }
        public int CountryID { get; set; }
        public decimal Amount { get; set; }
        public int QuantityDelivered { get; set; }
        public int? DeliveredLocaTenantID { get; set; }
        public int? AmountDelivered { get; set; }
        public string DeliveryRef { get; set; }
        public string UserBatch { get; set; }
        public string maintranstype { get; set; }
        public string TransType { get; set; }


    }
}