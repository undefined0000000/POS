using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.POS
{
    public class WebApiclass
    {
    }

    [Serializable]
    public class TempProduct
    {
        public int Tenent { get; set; }
        public int Myid { get; set; }
        public int product_id { get; set; }
        public string UOMNAME { get; set; }
        public int UOMID { get; set; }
        public string Shopid { get; set; }
        public string product_name { get; set; }
        public string product_name_Arabic { get; set; }
        public string product_name_print { get; set; }
        public string category { get; set; }
        public string supplier { get; set; }
        public int taxapply { get; set; }
        public string imagename { get; set; }
        public int status { get; set; }
        public decimal msrp { get; set; }
        public decimal price { get; set; }
        public decimal Total { get; set; }
        public decimal OpQty { get; set; }
        public decimal OnHand { get; set; }
        public decimal QtyOut { get; set; }
        public int QtyConsumed { get; set; }
        public int QtyReserved { get; set; }
        public decimal QtyRecived { get; set; }
        public int minQty { get; set; }

        public decimal RowTotal { get; set; }
        public int MaxQty { get; set; }
        public string payment_type { get; set; }
        public decimal Discount { get; set; }
        public string CustItemCode { get; set; }
        public string BarCode { get; set; }
        public string BatchNo { get; set; }
        public string ExpiryDate { get; set; }
        public string Remarks { get; set; }

    }
    [Serializable]
    public class PaymentDatasale
    {
        public string invoice { get; set; }
        public string payment_type { get; set; }
        public string Reffrance_NO { get; set; }
        public decimal payment_amount { get; set; }
    }

    public class Response
    {
        public object data { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public bool success { get; set; }
    }

    public class DraftSave
    {
        public int TenentID { get; set; }
        public string Shopid { get; set; }
        public int Userid { get; set; }
        public string UserName { get; set; }
        public decimal TotalPayable { get; set; }
        public string OrderWay { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public int ShiftID { get; set; }
        public string Invoice { get; set; }
        public IList<SalesItemList> dgrvSalesItemList { get; set; }
    }

    public class SalesItemList
    {
        public string Items_Name { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public decimal Total { get; set; }
        public string itemID { get; set; }
        public string UOMNAME { get; set; }
        public int UOMID { get; set; }
        public decimal Disamt { get; set; }
        public decimal taxamt { get; set; }
        public decimal Dis { get; set; }
        public int taxapply { get; set; }
        public int kitchendisplay { get; set; }
        public string BatchNo { get; set; }
        public decimal OnHand { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SalesID { get; set; }
        public string invoice { get; set; }
        public string Payment_Type { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public string CustItemCode { get; set; }
        public string Remarks { get; set; }
    }

    public class CashSave
    {
        public int TenentID { get; set; }
        public string Shopid { get; set; }
        public int Userid { get; set; }
        public string UserName { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal TotalCashRecived { get; set; }
        public string OrderWay { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public string DiscountTotaloverall { get; set; }
        public string overalldisRate { get; set; }
        public string Delivery_Cahrge { get; set; }
        public int ShiftID { get; set; }
        public string Invoice { get; set; }
        public IList<SalesItemList> dgrvSalesItemList { get; set; }
    }


    public class CashSave2
    {
        public int TenentID { get; set; }
        public int LID { get; set; }
        public string Invoice { get; set; }
        public Int64 MYTRANSID { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public string MYPRODID { get; set; }
        public int Userid { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal TotalCashRecived { get; set; }
        public Decimal TotalAmount { get; set; }
        public string Orderway { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMode { get; set; }
        public string payment_type { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public string DiscountTotaloverall { get; set; }
        public string overalldisRate { get; set; }
        public string Delivery_Cahrge { get; set; }
        public string UserName { get; set; }
       
        public string DESCRIPTION { get; set; }
        public decimal UOM { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal ChangeAmount { get; set; }
        public int DID { get; set; }
        public string DiscountAmt { get; set; }
        public IList<SalesItemList> dgrvSalesItemList { get; set; }
        public IList<PaymentData> GridPayment { get; set; }
    }

    public class OnlySave
    {
        public int TenentID { get; set; }
        public string Shopid { get; set; }
        public int Userid { get; set; }
        public int MYTRANSID { get; set; }
        public string UserName { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal TotalCashRecived { get; set; }
        public string OrderWay { get; set; }
        public string Customer { get; set; }
        public int CustomerID { get; set; }
        public string DiscountTotaloverall { get; set; }
        public string overalldisRate { get; set; }
        public string Delivery_Cahrge { get; set; }
        public int ShiftID { get; set; }
        public string salesDate { get; set; }
        public IList<SalesItemList> dgrvSalesItemList { get; set; }
        public IList<PaymentData> GridPayment { get; set; }
    }
    public class PaymentData
    {
        public string payment_type { get; set; }
        public string Reffrance_NO { get; set; }
        public decimal payment_amount { get; set; }
    }
}