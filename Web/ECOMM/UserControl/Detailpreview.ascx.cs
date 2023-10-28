using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
namespace Web.ECOMM.UserControl
{
    public partial class Detailpreview : System.Web.UI.UserControl
    {
        Database.CallEntities DB = new Database.CallEntities();
        int TID, LID, UID, EMPID, userID1, userTypeid = 0;
        string LangID = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            SessionLoad();
            if (!IsPostBack)
            {
                bindlist();
            }
        }
        public void SessionLoad()
        {
            TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
            EMPID = Convert.ToInt32(((USER_MST)Session["USER"]).EmpID);
            LangID = Session["LANGUAGE"].ToString();
            userID1 = ((USER_MST)Session["USER"]).USER_ID;
            userTypeid = Convert.ToInt32(((USER_MST)Session["USER"]).USER_DETAIL_ID);

        }
        public void bindlist()
        {
            //if (Session["ProductID"] != null)
            //{
            //    int PID = Convert.ToInt32(Session["ProductID"]);
            try
            {
                liststocktacking.DataSource = DB.ICIT_BR.Where(p => p.TenentID == TID && p.LocationID == LID); //p.MyProdID == PID && 
                liststocktacking.DataBind();

                listsupplier.DataSource = DB.ICTR_DT_Sales.Where(p => p.MYSYSNAME == "PUR" && p.TenentID == TID); //p.MyProdID == PID && 
                listsupplier.DataBind();

                listcustemer.DataSource = DB.ICTR_DT_Sales.Where(p => p.MYSYSNAME == "SAL" && p.TenentID == TID); //p.MyProdID == PID && 
                listcustemer.DataBind();
                //}
            }
            catch
            {

            }
        }
        public string getsupplername(int ID)
        {
            try
            {
                if (ID == 0)
                {
                    return "Not Found";
                }
                else if (DB.ICTR_HD_Sales.Where(p => p.MYTRANSID == ID && p.TenentID == TID).Count() > 0)
                {
                    int Suppid = Convert.ToInt32(DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == ID && p.TenentID == TID).CUSTVENDID);
                    return DB.TBLCOMPANYSETUPs.Single(p => p.COMPID == Suppid && p.TenentID == TID).COMPNAME1;
                }
                else
                {
                    return "Not Found";
                }
            }
            catch
            {
                return "Not Found";
            }
        }
        public string gettarasdate(int ID)
        {
            try
            {
                DateTime date = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == ID && p.TenentID == TID).TRANSDATE;
                string dt = date.ToString("dd/MMM/yyyy");
                return dt;
            }
            catch
            {
                return "";
            }
        }
        public string GetStatus(int ID)
        {
            try
            {
                if (DB.ICTR_HD_Sales.Where(p => p.MYTRANSID == ID && p.TenentID == TID).Count() > 0)
                {
                    string statuss = DB.ICTR_HD_Sales.Single(p => p.MYTRANSID == ID && p.TenentID == TID).Status;
                    if (statuss == "DSO")
                        return "Draft";
                    else if (statuss == "SO")
                        return "Confirm";
                    else if (statuss == "DPO")
                        return "Draft";
                    else if (statuss == "RDPOCT")
                        return "Confirm";
                    else
                        return "Not Found";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch
            {
                return "Not Found";
            }
        }
        public string GetItem(int ID)
        {
            try
            {
                if (DB.TBLPRODUCTs.Where(p => p.MYPRODID == ID && p.TenentID == TID).Count() > 0)
                {
                    string Prodname = DB.TBLPRODUCTs.Single(p => p.MYPRODID == ID && p.TenentID == TID).ProdName1;
                    return Prodname;
                }
                else
                {
                    return "Not Found";
                }
            }
            catch
            {
                return "Not Found";
            }
        }

    }
}