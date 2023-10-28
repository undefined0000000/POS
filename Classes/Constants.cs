using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
    public const string UploadPath = "~/Uploads/";
    public const string RootPath = "~/Webadmin/";
    public const string RootPathWithout = "/Webadmin/";
    public const string AdminLogin = "AdminLogin";
    public const string admin_username = "admin";
    public const string admin_password = "admin";
    public static string VideoCategory_thumb_path = "uploads/<|StoreID|>/Videos/";
    public static string Video_thumb_path = "uploads/<|StoreID|>/Videos/";
    public static string FilePathProducts = "~/uploads/Products/{id}/";

    public static string FlooringGuide_UserName = "serviceUser";
    public static string FlooringGuide_Password = "5erv1ceU5er#";
    public static string MaintainSitePagesHistoryRecords = "5";

    public static string PortalSellFloorsURL = "http://localhost:1159/";

    public static string FlooringDBConn = Convert.ToString(ConfigurationManager.ConnectionStrings["ISD2FlooringConnectionString"]);

}
