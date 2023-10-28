using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class PostProcess
    {
        public int TenentID { get; set; }
        public int LID { get; set; }
        public int transid { get; set; }
        public int trnassubid { get; set; }
        public int MYTRANSID { get; set; }
        public int MYID { get; set; }
        public int QTY { get; set; }
        public string Reference { get; set; }
        public DateTime trnsDate { get; set; }
        public string MySysName { get; set; }
        public int MyProdID { get; set; }
        public string ICPOST { get; set; }
        public decimal UNITPRICE { get; set; }
        public int UOM { get; set; }
    }
}
