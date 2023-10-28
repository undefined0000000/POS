using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Database;
using Classes;

namespace Web
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WinConnection : System.Web.Services.WebService
    {
        CallEntities DB = new CallEntities();

        [WebMethod(EnableSession = true)]

        // public static string getAllCart()
        // {
        //     int TID = Convert.ToInt32(((USER_MST)HttpContext.Current.Session["USER"]).TenentID);
        //     // Use the TID variable 
        //     // ...
        //     return TID
        // }
        public string GetConnection(int pqr, string abc)
        {
            if (DB.Win_mycompanysetup_winapp.Where(p => p.TenentID == pqr && p.Mac_Addr == abc).Count() > 0)
            {
                string CON = "";
                if (DB.MODULE_MST.Where(p => p.TenentID == 0 && p.Module_Name == "POS_WIN" && p.Parent_Module_id != 0).Count() > 0)
                    CON = DB.MODULE_MST.Where(p => p.TenentID == 0 && p.Module_Name == "POS_WIN" && p.Parent_Module_id != 0).FirstOrDefault().ConStr.ToString();

                string encCOn = Classes.EncryptionClass.Encrypt(CON);

                return encCOn;
            }

            return "";
        }
    }
}
