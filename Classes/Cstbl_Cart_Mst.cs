using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Cstbl_Cart_Mst
    {
        public int TenentID { get; set; }
        public int Custmer_ID { get; set; }
        public int Product_ID { get; set; }
        public long LocalID { get; set; }
        public Nullable<long> LOCATION_ID { get; set; }
        public Nullable<long> MYTRANSID { get; set; }
        public string OrderID { get; set; }
        public Nullable<int> MyTempID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<long> REF_ID { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string IP { get; set; }
        public string Oderstatus { get; set; }
        public Nullable<bool> ISFavourite { get; set; }
        public Nullable<bool> ISWishItem { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<long> CRUP_ID { get; set; }
        public Nullable<int> MYID { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string Uploadby { get; set; }
        public Nullable<System.DateTime> SyncDate { get; set; }
        public string Syncby { get; set; }
        public Nullable<int> SynID { get; set; }
    }

    public class Cstbl_Cart_MstList
    {
        public IList<Cstbl_Cart_Mst> data { get; set; }
    }
    public class GetCstbl_Cart_Mst
    {
        public Cstbl_Cart_Mst data { get; set; }
    }
}
