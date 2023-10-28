using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
namespace Classes
{  
    public static class Transaction
    {
        static Database.CallEntities DB = new Database.CallEntities();
        public static void GlobleTransactionClass(int TenentID, int MYTRANSID, int ToTenentID, int TOLOCATIONID, string MainTranType, string TranType, int transid, int transsubid, string MYSYSNAME, decimal COMPID, decimal CUSTVENDID, string LF, string PERIOD_CODE, string ACTIVITYCODE, decimal MYDOCNO, string USERBATCHNO, decimal TOTQTY1, decimal TOTAMT, decimal AmtPaid, string PROJECTNO, string CounterID, string PrintedCounterInvoiceNo, int JOID, DateTime TRANSDATE, string REFERENCE, string NOTES, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, string USERID, bool ACTIVE, int COMPANYID, DateTime ENTRYDATE, DateTime ENTRYTIME, DateTime UPDTTIME, int InvoiceNO, decimal Discount, string Status, int Terms, string DatainserStatest, string Custmerid, string Swit1, string ExtraField2, int RefTransID)
        {
            Database.CallEntities DB = new Database.CallEntities();
            Database.ICTR_HD objICTR_HD = new Database.ICTR_HD();
            bool flag = false;
            if (DatainserStatest == "Add")
            {
                objICTR_HD = new Database.ICTR_HD();
                flag = true;
                objICTR_HD.InvoiceNO = InvoiceNO.ToString();
            }
            else
            {
                objICTR_HD = DB.ICTR_HD.Single(p => p.MYTRANSID == MYTRANSID && p.TenentID == TenentID);
            }
            objICTR_HD.TenentID = TenentID;
            objICTR_HD.MYTRANSID = MYTRANSID;
            objICTR_HD.ToTenantID = ToTenentID;
            objICTR_HD.locationID = TOLOCATIONID;
            objICTR_HD.MainTranType = MainTranType;
            objICTR_HD.TransType = TranType;
            objICTR_HD.transid = transid;
            objICTR_HD.transsubid = transsubid;
            objICTR_HD.TranType = TranType;
            objICTR_HD.COMPID = COMPID;
            objICTR_HD.MYSYSNAME = MYSYSNAME;
            objICTR_HD.CUSTVENDID = CUSTVENDID;
            objICTR_HD.LF = LF;
            objICTR_HD.PERIOD_CODE = PERIOD_CODE;
            objICTR_HD.ACTIVITYCODE = ACTIVITYCODE;
            objICTR_HD.MYDOCNO = MYDOCNO;
            objICTR_HD.USERBATCHNO = USERBATCHNO;
            objICTR_HD.TOTAMT = TOTAMT;
            objICTR_HD.TOTQTY = TOTQTY1;
            objICTR_HD.AmtPaid = AmtPaid;
            objICTR_HD.PROJECTNO = PROJECTNO;
            objICTR_HD.CounterID = CounterID;
            objICTR_HD.PrintedCounterInvoiceNo = PrintedCounterInvoiceNo;
            objICTR_HD.JOID = JOID;
            objICTR_HD.TRANSDATE = TRANSDATE;
            objICTR_HD.REFERENCE = REFERENCE;
            objICTR_HD.NOTES = NOTES;
            objICTR_HD.GLPOST = GLPOST;
            objICTR_HD.GLPOST1 = GLPOST1;
            objICTR_HD.GLPOSTREF = GLPOSTREF;
            objICTR_HD.GLPOSTREF1 = GLPOSTREF1;
            objICTR_HD.ICPOST = ICPOST;
            objICTR_HD.ICPOSTREF = ICPOSTREF;
            objICTR_HD.USERID = USERID;
            objICTR_HD.ACTIVE = true;
            //objICTR_HD.CREATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            //objICTR_HD.UPDATED_BY = Convert.ToInt32(Session["UserId"].ToString());
            objICTR_HD.COMPANYID = COMPANYID;
            objICTR_HD.ENTRYDATE = ENTRYDATE;
            objICTR_HD.ENTRYTIME = ENTRYTIME;
            objICTR_HD.UPDTTIME = UPDTTIME;
            objICTR_HD.Discount = Discount;
            objICTR_HD.Status = Status;
            objICTR_HD.Terms = Terms;
            objICTR_HD.ExtraField1 = Custmerid;
            objICTR_HD.ExtraField2 = ExtraField2;
            objICTR_HD.ExtraSwitch1 = Swit1;
            objICTR_HD.RefTransID = RefTransID;
            // objICTR_HD.ExtraSwitch2 = "";
            if (flag == true)
            {
                DB.ICTR_HD.AddObject(objICTR_HD);
            }
            DB.SaveChanges();

            
         }
            

            public static void insertICTR_DT(int TenentID, int MYTRANSID, int MYID, int locationID, int MyProdID, string REFTYPE, string REFSUBTYPE, string PERIOD_CODE, string MYSYSNAME, int JOID, int JOBORDERDTMYID, int ACTIVITYID, string DESCRIPTION, string UOM, int QUANTITY, decimal UNITPRICE, decimal AMOUNT, decimal OVERHEADAMOUNT, string BATCHNO, int BIN_ID, string BIN_TYPE, string GRNREF, decimal DISPER, decimal DISAMT, decimal TAXPER, decimal TAXAMT, decimal PROMOTIONAMT, int CRUP_ID, string GLPOST, string GLPOST1, string GLPOSTREF1, string GLPOSTREF, string ICPOST, string ICPOSTREF, DateTime EXPIRYDATE, bool ACTIVE, string SWITCH1, int COMPANYID1, int DelFlag, string ITEMID)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICTR_DT objICTR_DT = new ICTR_DT();
                objICTR_DT.TenentID = TenentID;
                objICTR_DT.MYTRANSID = MYTRANSID;
                objICTR_DT.locationID = locationID;
                objICTR_DT.MYID = MYID;
                objICTR_DT.MyProdID = MyProdID;
                objICTR_DT.REFTYPE = REFTYPE;
                objICTR_DT.REFSUBTYPE = REFSUBTYPE;
                objICTR_DT.PERIOD_CODE = PERIOD_CODE;
                objICTR_DT.MYSYSNAME = MYSYSNAME;
                objICTR_DT.JOID = JOID;
                objICTR_DT.JOBORDERDTMYID = JOBORDERDTMYID;
                objICTR_DT.ACTIVITYID = ACTIVITYID;
                objICTR_DT.DESCRIPTION = DESCRIPTION;
                objICTR_DT.UOM = UOM;
                objICTR_DT.QUANTITY = QUANTITY;
                objICTR_DT.UNITPRICE = UNITPRICE;
                objICTR_DT.AMOUNT = AMOUNT;
                objICTR_DT.OVERHEADAMOUNT = OVERHEADAMOUNT;
                objICTR_DT.BATCHNO = BATCHNO;
                objICTR_DT.BIN_ID = BIN_ID;
                objICTR_DT.BIN_TYPE = BIN_TYPE;
                objICTR_DT.GRNREF = GRNREF;
                objICTR_DT.DISPER = DISPER;
                objICTR_DT.DISAMT = DISAMT;
                objICTR_DT.TAXAMT = TAXAMT;
                objICTR_DT.TAXPER = TAXPER;
                objICTR_DT.PROMOTIONAMT = PROMOTIONAMT;
                objICTR_DT.GLPOST = GLPOST;
                objICTR_DT.GLPOST1 = GLPOST1;
                objICTR_DT.GLPOSTREF1 = GLPOSTREF1;
                objICTR_DT.GLPOSTREF = GLPOSTREF;
                objICTR_DT.ICPOST = ICPOST;
                objICTR_DT.ICPOSTREF = ICPOSTREF;
                objICTR_DT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DT.COMPANYID = COMPANYID1;
                objICTR_DT.SWITCH1 = SWITCH1;
                objICTR_DT.ACTIVE = ACTIVE;
                objICTR_DT.DelFlag = DelFlag;

                DB.ICTR_DT.AddObject(objICTR_DT);
                DB.SaveChanges();
            }

            public static void insertICTR_DTEXT(int TenentID, int MYTRANSID, int MyID, int MyRunningSerial, string CURRENCY, decimal CURRENTCONVRATE, decimal OTHERCURAMOUNT, int QUANTITY, decimal UNITPRICE, decimal AMOUNT, int QUANTITYDELIVERD, int DELIVERDLOCATenentID, decimal AMOUNTDELIVERD, string ACCOUNTID, string GRNREF, DateTime EXPIRYDATE, int CRUP_ID, string Remark, int TransNo1, bool ACTIVE)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICTR_DTEXT objICTR_DTEXT = new ICTR_DTEXT();
                objICTR_DTEXT.TenentID = TenentID;
                objICTR_DTEXT.MYTRANSID = MYTRANSID;
                objICTR_DTEXT.MyID = MyID;
                objICTR_DTEXT.MyRunningSerial = MyRunningSerial;
                objICTR_DTEXT.CURRENTCONVRATE = CURRENTCONVRATE;
                objICTR_DTEXT.CURRENCY = CURRENCY;
                objICTR_DTEXT.OTHERCURAMOUNT = OTHERCURAMOUNT;

                objICTR_DTEXT.QUANTITY = QUANTITY;
                objICTR_DTEXT.UNITPRICE = UNITPRICE;
                objICTR_DTEXT.AMOUNT = AMOUNT;
                objICTR_DTEXT.QUANTITYDELIVERD = QUANTITYDELIVERD;
                // objICTR_DTEXT.DELIVERDLOCATenentID = 0;
                objICTR_DTEXT.ACCOUNTID = ACCOUNTID;
                objICTR_DTEXT.GRNREF = GRNREF;
                objICTR_DTEXT.EXPIRYDATE = EXPIRYDATE;
                objICTR_DTEXT.Remark = Remark;
                objICTR_DTEXT.TransNo = TransNo1;
                objICTR_DTEXT.ACTIVE = ACTIVE;
                DB.ICTR_DTEXT.AddObject(objICTR_DTEXT);
                DB.SaveChanges();

            }

            public static void insertICOVERHEADCOST(int TenentID, int MYTRANSID, int MYID, int OVERHEADCOSTID, decimal OLDCOST, decimal NEWCOST, int TOTQTY, decimal TOTCOST, decimal OTHERCOST, decimal UNITCOST, int CRUP_ID, decimal COMPANY_SEQUENCE, int ICT_COMPANYID, int COMPANYID, string Note)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICOVERHEADCOST objICOVERHEADCOST = new ICOVERHEADCOST();
                objICOVERHEADCOST.TenentID = TenentID;
                objICOVERHEADCOST.MYTRANSID = MYTRANSID;
                objICOVERHEADCOST.MYID = MYID;
                objICOVERHEADCOST.OVERHEADCOSTID = OVERHEADCOSTID;
                objICOVERHEADCOST.TOTCOST = TOTCOST;
                objICOVERHEADCOST.OLDCOST = OLDCOST;
                objICOVERHEADCOST.NEWCOST = NEWCOST;
                objICOVERHEADCOST.TOTQTY = TOTQTY;
                objICOVERHEADCOST.UNITCOST = UNITCOST;
                objICOVERHEADCOST.OTHERCOST = OTHERCOST;
                objICOVERHEADCOST.COMPANY_SEQUENCE = COMPANY_SEQUENCE;
                objICOVERHEADCOST.ICT_COMPANYID = ICT_COMPANYID;
                objICOVERHEADCOST.COMPANYID = COMPANYID;
                objICOVERHEADCOST.Note = Note;
                DB.ICOVERHEADCOSTs.AddObject(objICOVERHEADCOST);
                DB.SaveChanges();

            }

            public static void insertICIT_BR(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int Location, decimal UnitCost, int MYTRANSID, string Bin_Per, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
            {
                Database.CallEntities DB = new Database.CallEntities();
                bool RoleFlag = false;
                int OPQTY = 0;
                int ONHANDQTY = 0;
                int QtyOut = 0;
                int QtyConsumed = 0;
                int QtyReserved = 0;
                int QtyReceived = 0;
                int ONHANDTOTAL = 0;
                ICIT_BR objICIT_BR = new ICIT_BR();
                if (Fuctions == "ADD")
                {
                    if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location).Count() > 0)
                    {
                        objICIT_BR = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location);
                        OPQTY = Convert.ToInt32(objICIT_BR.OpQty);
                        ONHANDQTY = Convert.ToInt32(objICIT_BR.OnHand);
                        QtyOut = Convert.ToInt32(objICIT_BR.QtyOut);
                        QtyConsumed = Convert.ToInt32(objICIT_BR.QtyConsumed);
                        QtyReserved = Convert.ToInt32(objICIT_BR.QtyReserved);
                        QtyReceived = Convert.ToInt32(objICIT_BR.QtyReceived);
                        if (PageName == "Sales")
                        {
                            QtyOut = QtyOut + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else if (PageName == "Parchesh")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            if (PageName == "+")
                            {
                                QtyReceived = QtyReceived + NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                            else
                            {
                                QtyOut = QtyOut + NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                        }
                    }
                    else
                    {
                        objICIT_BR = new ICIT_BR();
                        objICIT_BR.MySysName = "IC";
                        objICIT_BR.UnitCost = UnitCost;
                        ONHANDTOTAL = NewQty;
                        QtyReceived = NewQty;
                        RoleFlag = true;
                    }
                }
                objICIT_BR.TenentID = TenentID;
                objICIT_BR.MyProdID = MyProdID;
                objICIT_BR.period_code = period_code;
                objICIT_BR.UOM = UOM;
                objICIT_BR.LocationID = Location;
                objICIT_BR.MYTRANSID = MYTRANSID;
                objICIT_BR.Bin_Per = Bin_Per;
                objICIT_BR.OpQty = OPQTY;
                objICIT_BR.OnHand = ONHANDTOTAL;
                objICIT_BR.QtyOut = QtyOut;
                objICIT_BR.QtyConsumed = QtyConsumed;
                objICIT_BR.QtyReserved = QtyReserved;
                objICIT_BR.QtyReceived = QtyReceived;
                objICIT_BR.Reference = Reference;
                objICIT_BR.Active = Active;
                objICIT_BR.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                {
                    DB.ICIT_BR.AddObject(objICIT_BR);
                }
                DB.SaveChanges();

            }

            public static void insertICIT_BR_SIZECOLOR(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int Location, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                bool RoleFlag = false;
                int OPQTY = 0;
                int ONHANDQTY = 0;
                int QtyOut = 0;
                int QtyConsumed = 0;
                int QtyReserved = 0;
                int QtyReceived = 0;
                int ONHANDTOTAL = 0;
                int Qtyofoled = 0;
                int Qtyofnew = 0;

                if (Fuctions == "ADD")
                {
                    if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
                    {
                        objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                        OPQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                        ONHANDQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OnHand);
                        QtyOut = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyOut);
                        QtyConsumed = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyConsumed);
                        QtyReserved = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReserved);
                        QtyReceived = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReceived);
                        if (PageName == "Sales")
                        {
                            QtyOut = QtyOut + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else if (PageName == "Parchesh")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            if (PageName == "+")
                            {
                                QtyReceived = QtyReceived + NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                            else
                            {
                                QtyOut = QtyOut - NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                        }
                    }
                    else
                    {
                        objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                        objICIT_BR_SIZECOLOR.MySysName = "IC";
                        ONHANDTOTAL = NewQty;
                        QtyReceived = NewQty;
                        RoleFlag = true;
                    }
                }
                objICIT_BR_SIZECOLOR.TenentID = TenentID;
                objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
                objICIT_BR_SIZECOLOR.period_code = period_code;

                objICIT_BR_SIZECOLOR.UOM = UOM;
                objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
                objICIT_BR_SIZECOLOR.COLORID = COLORID;
                objICIT_BR_SIZECOLOR.LocationID = Location;
                objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
                objICIT_BR_SIZECOLOR.OpQty = OPQTY;
                objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
                objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
                objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
                objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
                objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
                objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
                objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
                objICIT_BR_SIZECOLOR.MinQty = 0;
                objICIT_BR_SIZECOLOR.MaxQty = 0;
                objICIT_BR_SIZECOLOR.LeadTime = 0;
                objICIT_BR_SIZECOLOR.Reference = Reference;
                objICIT_BR_SIZECOLOR.Active = Active;
                objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                    DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
                DB.SaveChanges();




                //if (Fuctions == "ADD")
                //{
                //    if (PageName == "Sales")
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled - Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else if (PageName == "Parchesh")
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled + Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.COLORID == COLORID);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            if (PageName == "+")
                //                OpQty = Qtyofoled + Qtyofnew;
                //            else
                //                OpQty = Qtyofoled - Qtyofnew;
                //        }
                //    }
                //}



            }

            public static void insertICIT_BR_SIZE(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int Location, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICIT_BR_SIZECOLOR objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                bool RoleFlag = false;

                int OPQTY = 0;
                int ONHANDQTY = 0;
                int QtyOut = 0;
                int QtyConsumed = 0;
                int QtyReserved = 0;
                int QtyReceived = 0;
                int ONHANDTOTAL = 0;

                if (Fuctions == "ADD")
                {
                    if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
                    {
                        objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                        OPQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                        ONHANDQTY = Convert.ToInt32(objICIT_BR_SIZECOLOR.OnHand);
                        QtyOut = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyOut);
                        QtyConsumed = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyConsumed);
                        QtyReserved = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReserved);
                        QtyReceived = Convert.ToInt32(objICIT_BR_SIZECOLOR.QtyReceived);
                        if (PageName == "Sales")
                        {
                            QtyOut = QtyOut + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else if (PageName == "Parchesh")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                        }
                        else
                        {
                            if (PageName == "+")
                            {
                                QtyReceived = QtyReceived + NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                            else
                            {
                                QtyOut = QtyOut - NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - (QtyOut + QtyConsumed);
                            }
                        }
                    }
                    else
                    {
                        objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                        objICIT_BR_SIZECOLOR.MySysName = "IC";
                        ONHANDTOTAL = NewQty;
                        QtyReceived = NewQty;
                        RoleFlag = true;
                    }
                }

                objICIT_BR_SIZECOLOR.TenentID = TenentID;
                objICIT_BR_SIZECOLOR.MyProdID = MyProdID;
                objICIT_BR_SIZECOLOR.period_code = period_code;

                objICIT_BR_SIZECOLOR.UOM = UOM;
                objICIT_BR_SIZECOLOR.SIZECODE = SIZECODE;
                objICIT_BR_SIZECOLOR.COLORID = COLORID;
                objICIT_BR_SIZECOLOR.LocationID = Location;
                objICIT_BR_SIZECOLOR.MYTRANSID = MYTRANSID;
                objICIT_BR_SIZECOLOR.OpQty = OPQTY;
                objICIT_BR_SIZECOLOR.OnHand = ONHANDTOTAL;
                objICIT_BR_SIZECOLOR.OnHand_Q = ONHANDTOTAL;
                objICIT_BR_SIZECOLOR.QtyOut_Q = QtyOut;
                objICIT_BR_SIZECOLOR.QtyOut = QtyOut;
                objICIT_BR_SIZECOLOR.QtyConsumed = QtyConsumed;
                objICIT_BR_SIZECOLOR.QtyReserved = QtyReserved;
                objICIT_BR_SIZECOLOR.QtyReceived = QtyReceived;
                objICIT_BR_SIZECOLOR.MinQty = 0;
                objICIT_BR_SIZECOLOR.MaxQty = 0;
                objICIT_BR_SIZECOLOR.LeadTime = 0;
                objICIT_BR_SIZECOLOR.Reference = Reference;
                objICIT_BR_SIZECOLOR.Active = Active;
                objICIT_BR_SIZECOLOR.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                    DB.ICIT_BR_SIZECOLOR.AddObject(objICIT_BR_SIZECOLOR);
                DB.SaveChanges();







                //int Qtyofoled = 0;
                //int Qtyofnew = 0;
                //if (Fuctions == "ADD")
                //{
                //    if (PageName == "Sales")
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled - Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else if (PageName == "Parchesh")
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled + Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_SIZECOLOR = new ICIT_BR_SIZECOLOR();
                //            objICIT_BR_SIZECOLOR.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else
                //    {
                //        if (DB.ICIT_BR_SIZECOLOR.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE).Count() > 0)
                //        {
                //            objICIT_BR_SIZECOLOR = DB.ICIT_BR_SIZECOLOR.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.SIZECODE == SIZECODE);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_SIZECOLOR.OpQty);
                //            Qtyofnew = OpQty;
                //            if (PageName == "+")
                //                OpQty = Qtyofoled + Qtyofnew;
                //            else
                //                OpQty = Qtyofoled - Qtyofnew;
                //        }
                //    }
                //}



            }

            public static void insertICIT_BR_Serialize(int TenentID, int MyProdID, string period_code, string MySysName, string UOM, string Serial_Number, int Location, int MyTransID, string Flag_GRN_GTN, string Active, int CRUP_ID, string pagename)
            {
                Database.CallEntities DB = new Database.CallEntities();
                bool RoleFlag = false;
                ICIT_BR_Serialize objICIT_BR_Serialize = new ICIT_BR_Serialize();
                if (pagename == "Sales")
                {
                    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                    {
                        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                    }
                    else
                    {
                        objICIT_BR_Serialize = new ICIT_BR_Serialize();
                        objICIT_BR_Serialize.MySysName = MySysName;
                        RoleFlag = true;
                    }
                }
                else if (pagename == "Parchesh")
                {
                    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                    {
                        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                    }
                    else
                    {
                        objICIT_BR_Serialize = new ICIT_BR_Serialize();
                        objICIT_BR_Serialize.MySysName = MySysName;
                        RoleFlag = true;
                    }
                }
                else
                {
                    if (DB.ICIT_BR_Serialize.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number).Count() > 0)
                    {
                        objICIT_BR_Serialize = DB.ICIT_BR_Serialize.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Serial_Number == Serial_Number);
                    }
                    else
                    {
                        objICIT_BR_Serialize = new ICIT_BR_Serialize();
                        objICIT_BR_Serialize.MySysName = MySysName;

                        RoleFlag = true;
                    }
                }
                objICIT_BR_Serialize.TenentID = TenentID;
                objICIT_BR_Serialize.MyProdID = MyProdID;
                objICIT_BR_Serialize.period_code = period_code;

                objICIT_BR_Serialize.UOM = UOM;
                objICIT_BR_Serialize.Serial_Number = Serial_Number;
                objICIT_BR_Serialize.LocationID = Location;
                objICIT_BR_Serialize.Flag_GRN_GTN = Flag_GRN_GTN;
                objICIT_BR_Serialize.MyTransID = MyTransID;


                objICIT_BR_Serialize.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                {
                    objICIT_BR_Serialize.Active = "Y";
                    DB.ICIT_BR_Serialize.AddObject(objICIT_BR_Serialize);
                }
                else
                    objICIT_BR_Serialize.Active = "N";
                DB.SaveChanges();

            }

            public static void insertICIT_BR_Perishable(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, string BatchNo, int Location, int MYTRANSID, int NewQty, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Reference, string Active, int CRUP_ID, string Fuctions, string PageName)
            {
                Database.CallEntities DB = new Database.CallEntities();
                bool RoleFlag = false;

                int OPQTY = 0;
                int ONHANDQTY = 0;
                int QtyOut = 0;
                int QtyReceived = 0;
                int ONHANDTOTAL = 0;

                ICIT_BR_Perishable objICIT_BR_Perishable = new ICIT_BR_Perishable();
                if (Fuctions == "ADD")
                {
                    if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
                    {
                        objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                        OPQTY = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
                        ONHANDQTY = Convert.ToInt32(objICIT_BR_Perishable.OnHand);
                        QtyOut = Convert.ToInt32(objICIT_BR_Perishable.QtyOut);

                        QtyReceived = Convert.ToInt32(objICIT_BR_Perishable.QtyReceived);
                        if (PageName == "Sales")
                        {
                            QtyOut = QtyOut + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                        }
                        else if (PageName == "Parchesh")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                        }
                        else
                        {
                            if (PageName == "+")
                            {
                                QtyReceived = QtyReceived + NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                            }
                            else
                            {
                                QtyOut = QtyOut - NewQty;
                                ONHANDTOTAL = (OPQTY + QtyReceived) - QtyOut;
                            }
                        }
                    }
                    else
                    {
                        objICIT_BR_Perishable = new ICIT_BR_Perishable();
                        objICIT_BR_Perishable.MySysName = MySysName;
                        ONHANDTOTAL = NewQty;
                        QtyReceived = NewQty;
                        RoleFlag = true;
                    }
                }
                objICIT_BR_Perishable.TenentID = TenentID;
                objICIT_BR_Perishable.MyProdID = MyProdID;
                objICIT_BR_Perishable.period_code = period_code;
                objICIT_BR_Perishable.UOM = UOM;
                objICIT_BR_Perishable.BatchNo = BatchNo;
                objICIT_BR_Perishable.LocationID = Location;
                objICIT_BR_Perishable.MYTRANSID = MYTRANSID;
                objICIT_BR_Perishable.OpQty = OPQTY;
                objICIT_BR_Perishable.OnHand = ONHANDTOTAL;
                objICIT_BR_Perishable.QtyOut = QtyOut;
                objICIT_BR_Perishable.QtyReceived = QtyReceived;
                objICIT_BR_Perishable.ProdDate = ProdDate;
                objICIT_BR_Perishable.ExpiryDate = ExpiryDate;
                objICIT_BR_Perishable.LeadDays2Destroy = LeadDays2Destroy;
                objICIT_BR_Perishable.Reference = Reference;
                objICIT_BR_Perishable.Active = Active;
                objICIT_BR_Perishable.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                    DB.ICIT_BR_Perishable.AddObject(objICIT_BR_Perishable);
                DB.SaveChanges();






                //int Qtyofoled = 0;
                //int Qtyofnew = 0;

                //if (Fuctions == "ADD")
                //{
                //    if (PageName == "Sales")
                //    {
                //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
                //        {
                //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled - Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_Perishable = new ICIT_BR_Perishable();
                //            objICIT_BR_Perishable.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else if (PageName == "Parchesh")
                //    {
                //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
                //        {
                //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
                //            Qtyofnew = OpQty;
                //            OpQty = Qtyofoled + Qtyofnew;
                //        }
                //        else
                //        {
                //            objICIT_BR_Perishable = new ICIT_BR_Perishable();
                //            objICIT_BR_Perishable.MySysName = MySysName;
                //            RoleFlag = true;
                //        }
                //    }
                //    else
                //    {
                //        if (DB.ICIT_BR_Perishable.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo).Count() > 0)
                //        {
                //            objICIT_BR_Perishable = DB.ICIT_BR_Perishable.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.BatchNo == BatchNo);
                //            Qtyofoled = Convert.ToInt32(objICIT_BR_Perishable.OpQty);
                //            Qtyofnew = OpQty;
                //            if (PageName == "+")
                //                OpQty = Qtyofoled + Qtyofnew;
                //            else
                //                OpQty = Qtyofoled - Qtyofnew;
                //        }
                //    }
                //}


            }

            public static void insertICIT_BR_BIN(int TenentID, int MyProdID, string period_code, string MySysName, int Bin_ID, int UOM, int Location, string BatchNo, int MYTRANSID, int NewQty, string Reference, string Active, int CRUP_ID, string pagename, string Fuctions)
            {
                Database.CallEntities DB = new Database.CallEntities();
                bool RoleFlag = false;
                int OPQTY = 0;
                int ONHANDQTY = 0;
                int QtyOut = 0;
                int QtyConsumed = 0;
                int QtyReserved = 0;
                int QtyReceived = 0;
                int ONHANDTOTAL = 0;
                int QTYOUTNEW = 0;
                int QTYINNEW = 0;
                ICIT_BR_BIN objICIT_BR_BIN = new ICIT_BR_BIN();
                if (Fuctions == "ADD")
                {
                    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
                    {
                        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                        OPQTY = Convert.ToInt32(objICIT_BR_BIN.OpQty);
                        ONHANDQTY = Convert.ToInt32(objICIT_BR_BIN.OnHand);
                        QtyOut = Convert.ToInt32(objICIT_BR_BIN.QtyOut);
                        QtyConsumed = Convert.ToInt32(objICIT_BR_BIN.QtyConsumed);
                        QtyReserved = Convert.ToInt32(objICIT_BR_BIN.QtyReserved);
                        QtyReceived = Convert.ToInt32(objICIT_BR_BIN.QtyReceived);
                        if (pagename == "Sales")
                        {
                            QtyOut = QtyOut + NewQty;
                            QTYOUTNEW = OPQTY + QtyReceived;
                            QTYINNEW = QtyOut + QtyConsumed;
                            ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                        }
                        else if (pagename == "Parchesh")
                        {
                            QtyReceived = QtyReceived + NewQty;
                            QTYOUTNEW = OPQTY + QtyReceived;
                            QTYINNEW = QtyOut + QtyConsumed;
                            ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                        }
                        else
                        {
                            if (pagename == "+")
                            {
                                QtyReceived = QtyReceived + NewQty;
                                QTYOUTNEW = OPQTY + QtyReceived;
                                QTYINNEW = QtyOut + QtyConsumed;
                                ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                            }
                            else
                            {
                                QtyOut = QtyOut - NewQty;
                                QTYOUTNEW = OPQTY + QtyReceived;
                                QTYINNEW = QtyOut + QtyConsumed;
                                ONHANDTOTAL = QTYOUTNEW - QTYINNEW;
                            }
                        }
                    }
                    else
                    {
                        objICIT_BR_BIN = new ICIT_BR_BIN();
                        objICIT_BR_BIN.MySysName = MySysName;
                        ONHANDTOTAL = NewQty;
                        QtyReceived = NewQty;
                        RoleFlag = true;
                    }
                }
                objICIT_BR_BIN.TenentID = TenentID;
                objICIT_BR_BIN.MyProdID = MyProdID;
                objICIT_BR_BIN.period_code = period_code;
                objICIT_BR_BIN.Bin_ID = Bin_ID;
                objICIT_BR_BIN.UOM = UOM;
                objICIT_BR_BIN.LocationID = Location;
                objICIT_BR_BIN.MYTRANSID = MYTRANSID;
                objICIT_BR_BIN.OpQty = OPQTY;
                objICIT_BR_BIN.OnHand = ONHANDTOTAL;
                objICIT_BR_BIN.QtyOut = QtyOut;
                objICIT_BR_BIN.QtyConsumed = QtyConsumed;
                objICIT_BR_BIN.QtyReserved = QtyReserved;
                objICIT_BR_BIN.QtyReceived = QtyReceived;
                objICIT_BR_BIN.MinQty = 0;
                objICIT_BR_BIN.MaxQty = 0;
                objICIT_BR_BIN.LeadTime = 0;
                objICIT_BR_BIN.Reference = Reference;
                objICIT_BR_BIN.Active = Active;
                objICIT_BR_BIN.CRUP_ID = CRUP_ID;
                if (RoleFlag == true)
                    DB.ICIT_BR_BIN.AddObject(objICIT_BR_BIN);
                DB.SaveChanges();





                //int Qtyofoled = 0;
                //int Qtyofnew = 0;

                //if (pagename == "Sales")
                //{
                //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
                //    {
                //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);

                //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
                //        Qtyofnew = OpQty;
                //        OpQty = Qtyofoled - Qtyofnew;

                //    }
                //    else
                //    {
                //        objICIT_BR_BIN = new ICIT_BR_BIN();
                //        objICIT_BR_BIN.MySysName = MySysName;
                //        RoleFlag = true;
                //    }
                //}
                //else if (pagename == "Parchesh")
                //{
                //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
                //    {
                //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
                //        Qtyofnew = OpQty;
                //        OpQty = Qtyofoled + Qtyofnew;
                //    }
                //    else
                //    {
                //        objICIT_BR_BIN = new ICIT_BR_BIN();
                //        objICIT_BR_BIN.MySysName = MySysName;
                //        RoleFlag = true;
                //    }
                //}
                //else
                //{
                //    if (DB.ICIT_BR_BIN.Where(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID).Count() > 0)
                //    {
                //        objICIT_BR_BIN = DB.ICIT_BR_BIN.Single(p => p.TenentID == TenentID && p.period_code == period_code && p.MyProdID == MyProdID && p.UOM == UOM && p.LocationID == Location && p.Bin_ID == Bin_ID);
                //        Qtyofoled = Convert.ToInt32(objICIT_BR_BIN.OpQty);
                //        Qtyofnew = OpQty;
                //        if (pagename == "+")
                //            OpQty = Qtyofoled + Qtyofnew;
                //        else
                //            OpQty = Qtyofoled - Qtyofnew;
                //    }
                //}


            }
            public static void insertICGRNTRCOST_HD(int TenentID, int MYTRANSID, int MYID, int OVERHEADCOSTID, decimal NEWCOST, int CRUP_ID, decimal COMPANY_SEQUENCE, int COMPANYID, string Note)
            {
                Database.CallEntities DB = new Database.CallEntities();
                ICGRNTRCOST_HD objICGRNTRCOST_HD = new ICGRNTRCOST_HD();
                objICGRNTRCOST_HD.TenentID = TenentID;
                objICGRNTRCOST_HD.MYTRANSID = MYTRANSID;
                objICGRNTRCOST_HD.MYID = MYID;
                objICGRNTRCOST_HD.OVERHEADID = OVERHEADCOSTID;
                objICGRNTRCOST_HD.AMOUNT = NEWCOST;
                objICGRNTRCOST_HD.NOTES = Note;
                objICGRNTRCOST_HD.COMPANY_SEQUENCE = COMPANY_SEQUENCE;
                objICGRNTRCOST_HD.COMPANYID = COMPANYID;
                objICGRNTRCOST_HD.ACTIVE = true;
                objICGRNTRCOST_HD.CRUP_ID = CRUP_ID;
                DB.ICGRNTRCOST_HD.AddObject(objICGRNTRCOST_HD);
                DB.SaveChanges();

            }
            public static void insertICIT_BR_TMP(int TenentID, int MyProdID, string period_code, string MySysName, int UOM, int SIZECODE, int COLORID, int BinID, string BatchNo, string Serialize, int MYTRANSID, int LocationID, int NewQty, string Reference, string RecodName, DateTime ProdDate, DateTime ExpiryDate, DateTime LeadDays2Destroy, string Active, int CRUP_ID)
            {
                Database.CallEntities DB = new Database.CallEntities();
                if (DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == MyProdID && p.period_code == period_code && p.MySysName == MySysName && p.UOM == UOM && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).Count() > 0)
                {
                    var List = DB.ICIT_BR_TMP.Where(p => p.TenentID == TenentID && p.MyProdID == MyProdID && p.period_code == period_code && p.MySysName == MySysName && p.UOM == UOM && p.SIZECODE == SIZECODE && p.COLORID == COLORID && p.Bin_ID == BinID && p.BatchNo == BatchNo && p.Serial_Number == Serialize && p.MYTRANSID == MYTRANSID).ToList();
                    foreach (Database.ICIT_BR_TMP item in List)
                    {
                        DB.ICIT_BR_TMP.DeleteObject(item);
                        DB.SaveChanges();
                    }
                }
                ICIT_BR_TMP objICIT_BR_TMP = new ICIT_BR_TMP();
                objICIT_BR_TMP.TenentID = TenentID;
                objICIT_BR_TMP.MyProdID = MyProdID;
                objICIT_BR_TMP.period_code = period_code;
                objICIT_BR_TMP.MySysName = MySysName;
                objICIT_BR_TMP.UOM = UOM;
                objICIT_BR_TMP.SIZECODE = SIZECODE;
                objICIT_BR_TMP.COLORID = COLORID;
                objICIT_BR_TMP.Bin_ID = BinID;
                objICIT_BR_TMP.BatchNo = BatchNo;
                objICIT_BR_TMP.Serial_Number = Serialize;
                objICIT_BR_TMP.MYTRANSID = MYTRANSID;
                objICIT_BR_TMP.LocationID = LocationID;
                if (DB.ICIT_BR.Where(p => p.TenentID == TenentID && p.LocationID == LocationID && p.period_code == period_code && p.UOM == UOM && p.MyProdID == MyProdID).Count() == 1)
                {
                    ICIT_BR obj = DB.ICIT_BR.Single(p => p.TenentID == TenentID && p.LocationID == LocationID && p.period_code == period_code && p.UOM == UOM && p.MyProdID == MyProdID);
                    objICIT_BR_TMP.OpQty = obj.OpQty;
                    objICIT_BR_TMP.OnHand = obj.OnHand;
                    objICIT_BR_TMP.QtyOut = obj.QtyOut;
                    objICIT_BR_TMP.QtyConsumed = obj.QtyConsumed;
                    objICIT_BR_TMP.QtyReserved = obj.QtyReserved;
                    objICIT_BR_TMP.QtyReceived = obj.QtyReceived;
                    objICIT_BR_TMP.MinQty = obj.MinQty;
                    objICIT_BR_TMP.MaxQty = obj.MaxQty;
                    objICIT_BR_TMP.LeadTime = obj.LeadTime;
                }
                else
                {
                    objICIT_BR_TMP.OpQty = 0;
                    objICIT_BR_TMP.OnHand = 0;
                    objICIT_BR_TMP.QtyOut = 0;
                    objICIT_BR_TMP.QtyConsumed = 0;
                    objICIT_BR_TMP.QtyReserved = 0;
                    objICIT_BR_TMP.MinQty = 0;
                    objICIT_BR_TMP.QtyReceived = 0;
                    objICIT_BR_TMP.MaxQty = 0;
                    objICIT_BR_TMP.LeadTime = 0;
                }
                objICIT_BR_TMP.NewQty = NewQty;
                objICIT_BR_TMP.Reference = Reference;
                objICIT_BR_TMP.RecodName = RecodName;
                objICIT_BR_TMP.ProdDate = ProdDate;
                objICIT_BR_TMP.ExpiryDate = ExpiryDate;
                objICIT_BR_TMP.LeadDays2Destroy = LeadDays2Destroy;
                objICIT_BR_TMP.Active = Active;
                objICIT_BR_TMP.CRUP_ID = CRUP_ID;
                DB.ICIT_BR_TMP.AddObject(objICIT_BR_TMP);
                DB.SaveChanges();

            }

            public static tblsetupsalesh DEfaultSalesSetup(int TenentID, int LID, int TransID, int TransSubID, int Module)
            {
                Database.CallEntities DB = new Database.CallEntities();
               tblsetupsalesh objtblsetupsalesh=DB.tblsetupsaleshes.SingleOrDefault(p=>p.TenentID==TenentID && p.locationID==LID && p.transid==TransID && p.transsubid==TransSubID && p.module==Module);
               return objtblsetupsalesh;
            }
            public static tblActSLSetup DEfaultPaymetSetup(int TenentID, int LID, int TransID, int TransSubID, int Module)
            {
                Database.CallEntities DB = new Database.CallEntities();
                tblActSLSetup objtblpaymentSetup = DB.tblActSLSetups.SingleOrDefault(p => p.TenentID == TenentID && p.locationID == LID && p.transid == TransID && p.transsubid == TransSubID && p.module == Module);
                return objtblpaymentSetup;
            }
        
    }
}
