using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Web.Configuration;
using System.Drawing;
using System.Xml;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Linq;

using System.Web.Services.Protocols;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
    public static string SliderImagesFile = HttpContext.Current.Server.MapPath("~") + "/App_Data/SliderImages.xml";

    public static string DeptModuleImagePath = "/uploads/DeptModules/";

    public static string product_thumb_path = "uploads/Products/thumbnails/";
    public static string product_large_path = "/uploads/Products/largeimages/";
    public static string product_roomscene_path = "/uploads/Products/roomscene/";
    public static string product_brands_path = "/uploads/Products/brands/";
    public static string product_series_path = "/uploads/Products/series/";

    public static string PhotoGalley_thumb_path = "/uploads/PhotoGallery/Thumb/";
    public static string PhotoGalley_large_path = "/uploads/PhotoGallery/Large/";

    public static string StoreID = WebConfigurationManager.AppSettings["storeID"].ToString();
    public static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

    public static string sitepage_large_path = "/uploads/sitepages/";
    public static string siteMasterPage_path = "uploads/MasterPages/";

   // public static string varWebsiteRoot = GetSiteRoot();
    public static string FromEmail = "john.simonson@gmail.com";

    //public static void RadEditorSettings(Telerik.Web.UI.RadEditor radEditor)
    //{
    //    string storeID = Convert.ToString(HttpContext.Current.Session["StoreID"]);
    //    radEditor.FlashManager.ViewPaths = new string[] { "~/uploads/" + storeID + "/Editor/Flash/" };
    //    radEditor.FlashManager.UploadPaths = new string[] { "~/uploads/" + storeID + "/Editor/Flash/" };
    //    radEditor.FlashManager.DeletePaths = new string[] { "~/uploads/" + storeID + "/Editor/Flash/" };
    //    radEditor.ImageManager.ViewPaths = new string[] { "~/uploads/" + storeID + "/Editor/Images/" };
    //    radEditor.ImageManager.UploadPaths = new string[] { "~/uploads/" + storeID + "/Editor/Images/" };
    //    radEditor.ImageManager.DeletePaths = new string[] { "~/uploads/" + storeID + "/Editor/Images/" };
    //    radEditor.MediaManager.ViewPaths = new string[] { "~/uploads/" + storeID + "/Editor/Media/" };
    //    radEditor.MediaManager.UploadPaths = new string[] { "~/uploads/" + storeID + "/Editor/Media/" };
    //    radEditor.MediaManager.DeletePaths = new string[] { "~/uploads/" + storeID + "/Editor/Media/" };
    //    radEditor.DocumentManager.ViewPaths = new string[] { "~/uploads/" + storeID + "/Editor/Docs/" };
    //    radEditor.DocumentManager.UploadPaths = new string[] { "~/uploads/" + storeID + "/Editor/Docs/" };
    //    radEditor.DocumentManager.DeletePaths = new string[] { "~/uploads/" + storeID + "/Editor/Docs/" };
    //    radEditor.TemplateManager.DeletePaths = new string[] { "~/uploads/" + storeID + "/Editor/Templates/" };
    //    radEditor.TemplateManager.ViewPaths = new string[] { "~/uploads/" + storeID + "/Editor/Templates/" };
    //    radEditor.TemplateManager.UploadPaths = new string[] { "~/uploads/" + storeID + "/Editor/Templates/" };
    //}

    //public static void ReplaceZoneContent(ref string sourceContent)
    //{
    //    foreach (var item in ApplicationData.GetZones)
    //    {
    //        sourceContent = sourceContent.Replace("[Zone_"+item.ZoneShortCode+"]", item.ZoneContent);
    //    }
    //}
    public static void ReplaceSocialMediaLinkControl(ref string sourceContent)
    {
        int i = 1;
        //foreach (var item in ApplicationData.GetSocialMediaLinkThemes)
        //{
            sourceContent = sourceContent.Replace("[SocialMediaLinks]", "<%@ Register src=\"~/Controls/SocialMediaLink.ascx\" tagname=\"SocialMediaLink\" tagprefix=\"uc" + i + "\" %><uc" + i + ":SocialMediaLink ID=\"SocialMediaLink" + i + "\"  runat=\"server\" />");
        //    i = i + 1;
        //}
    }
    //public static void ReplaceSpecialsControl(ref string sourceContent)
    //{
    //    int i = 1;
    //    using (Model.ProductSectionDataContext ctx = new Model.ProductSectionDataContext())
    //    {
    //        foreach (var item in ctx.Specials.Where(c=>c.isVisible && c.ShortCode!=null))
    //        {
    //            sourceContent = sourceContent.Replace("[Specials_" + item.ShortCode + "]", "<%@ Register src=\"~/Uploads/Controls/Pages/Specials.ascx\" tagname=\"SpecialsShortCode\" tagprefix=\"uc" + i + "\" %><uc" + i + ":SpecialsShortCode ID=\"SpecialsShortCode" + i + "\" ShortCode=\"" + item.ShortCode + "\" runat=\"server\" />");
    //            i = i + 1;
    //        }
    //    }
    //}
    //public static string ParseUserControl(string content)
    //{
    //    return ParseUserControl(content, 0);
    //}
    
    //public static string ParseUserControl(string content,int sitePageID)
    //{
    //    string strContent;
    //    strContent = content;

    //    strContent = ParseUserControlCommon(strContent);
    //    if (sitePageID > 0)
    //    {
    //        int i = 0;
    //        while (strContent.Contains("[Content]"))
    //        {
    //            int startIndex = strContent.IndexOf("[Content]");
    //            int endIndex = strContent.IndexOf("]", startIndex);
    //            strContent = strContent.Remove(startIndex, (endIndex - startIndex) + 1);
    //            string Mode = Convert.ToString(HttpContext.Current.Request.QueryString["Mode"]);

    //            //strContent = strContent.Insert(startIndex, "<%@ Register src=\"~/Uploads/Controls/CustomRadEditor.ascx\" tagname=\"CustomRadEditor" + i + "\" tagprefix=\"uc1\" %><uc1:CustomRadEditor" + i + " ID=\"CustomRadEditor" + i + "\" Mode='" + Mode + "' SitePageID='" + sitePageID + "' ContentOrder='" + i + "' runat=\"server\" />");
    //            strContent = strContent.Insert(startIndex, "<%@ Register src=\"~/Uploads/Controls/CustomRadEditor.ascx\" tagname=\"CustomRadEditor" + i + "\" tagprefix=\"uc1\" %><uc1:CustomRadEditor" + i + " ID=\"CustomRadEditor" + i + "\" Mode='" + Mode + "' SitePageID='" + sitePageID + "' ContentOrder='" + i + "' runat=\"server\" />");
    //            i++;
    //        }
    //    }
    //    return strContent;
    //}
    //private static string ParseUserControlCommon(string content)
    //{
    //    string strContent;
    //    strContent = content;

    //    using (Model.WebStreamCMSDataContext ctx = new Model.WebStreamCMSDataContext())
    //    {
    //        List<Model.RegisteredWebUserControl> lstControls = ctx.RegisteredWebUserControls.ToList();
    //        foreach (var control in lstControls)
    //        {
    //            string tagName = control.TagName.Replace("-", "");
    //            strContent = strContent.Replace("[" + control.TagName + "]", "<%@ Register src=\"" + control.WebUserControlLocation + "\" tagname=\"" + tagName + "\" tagprefix=\"uc1\" %><uc1:" + tagName + " ID=\"" + tagName + "1\" runat=\"server\" />");
    //        }
    //    }

    //    strContent = strContent.Replace("[BlogPosts]", "<%@ Register src=\"~/Uploads/Controls/Blogs/BlogPosts.ascx\" tagname=\"BlogPosts\" tagprefix=\"uc1\" %><uc1:BlogPosts ID=\"BlogPosts1\" runat=\"server\"  />");
    //    strContent = strContent.Replace("[BlogArchives]", "<%@ Register src=\"~/Uploads/Controls/Blogs/BlogArchives.ascx\" tagname=\"BlogArchives\" tagprefix=\"uc1\" %><uc1:BlogArchives ID=\"BlogArchives1\" runat=\"server\"  />");
    //    strContent = strContent.Replace("[BlogCategories]", "<%@ Register src=\"~/Uploads/Controls/Blogs/BlogCategories.ascx\" tagname=\"BlogCategories\" tagprefix=\"uc1\" %><uc1:BlogCategories ID=\"BlogCategories1\" runat=\"server\"  />");
    //    strContent = strContent.Replace("[BlogPostDetails]", "<%@ Register src=\"~/Uploads/Controls/Blogs/BlogPostDetails.ascx\" tagname=\"BlogPostDetails\" tagprefix=\"uc1\" %><uc1:BlogPostDetails ID=\"BlogPostDetails1\" runat=\"server\" />");
        
    //    ReplaceControl(ref strContent, "ImageGallery", "<%@ Register src=\"~/Uploads/Controls/Pages/ImageGallery.ascx\" tagname=\"ImageGallery\" tagprefix=\"uc1\" %><uc1:ImageGallery ID=\"ImageGallery1\" runat=\"server\" />");

    //    Common.ReplaceSpecialsControl(ref strContent);
    //    Common.ReplaceZoneContent(ref strContent);
    //    return strContent;
    //}
    private static void ReplaceControl(ref string sourceContent, string controlName, string replacement)
    {
        if (!sourceContent.Contains("[" + controlName)) return;

        int startIndex = sourceContent.IndexOf("[" + controlName);
        int endIndex = sourceContent.IndexOf("]", startIndex);
        string ctrl = sourceContent.Substring(startIndex + 1, endIndex - startIndex - 1);

        string paramater = string.Empty;
        string colonSpliter = string.Empty;
        string fullCtrlName = string.Empty;

        string[] tmp = ctrl.Split(':');
        if (tmp.Length > 1)
        {
            paramater = tmp[1];
            colonSpliter = ":";
        }

        HttpContext.Current.Session["ctrlParamater_" + controlName] = paramater;
        fullCtrlName = string.Format("[{0}{1}{2}]", controlName, colonSpliter, paramater);
        sourceContent = sourceContent.Replace(fullCtrlName, replacement);
    }
    //public static string GetSiteRoot()
    //{
    //    string WebsiteRoot = GetStoreConfigValue("WebsiteRoot", "1000");
    //    if (String.IsNullOrEmpty(WebsiteRoot))
    //    {
    //        string Port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
    //        if (Port == null || Port == "80" || Port == "443")
    //            Port = "";
    //        else
    //            Port = ":" + Port;

    //        string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
    //        if (Protocol == null || Protocol == "0")
    //            Protocol = "http://";
    //        else
    //            Protocol = "https://";

    //        string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
    //        if (appPath == "/")
    //            appPath = "";
    //        //SERVER_NAME
    //        string sOut = Protocol + System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + appPath;
    //        return sOut;
    //    }
    //    else
    //    {
    //        return WebsiteRoot;
    //    }
    //}
    public static string SEOFriendlyName(string name)
    {
        return HttpContext.Current.Server.UrlEncode(name.Replace("'", "").Replace('"', '-').Replace(".", "").Replace(" ", "-").Replace("/", "-").Replace("<", "").Replace(">", "").Replace(":", "").Replace(";", "").Replace("&", "-").Replace("?", "-").Replace("--", "-").Trim('-', ' '));
    }
    public static void AlertMessage(Page PageName, String Message)
    {
        string Script;
        Message = Message.Replace("'", " ");
        Message = Message.Replace(";", " ");
        Message = Message.Replace("\n", " ");
        Message = Message.Replace("\r", " ");
        Script = "<script language=javascript>alert('" + Message + "')</script>";
        PageName.ClientScript.RegisterStartupScript(typeof(string), "g", Script);
        //PageName.Response.End();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static decimal? convertdecimal(string s)
    {
        if (string.IsNullOrEmpty(s))
            return (decimal)0;
        else
            return Convert.ToDecimal(s);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int convertinteger(string s)
    {
        if (string.IsNullOrEmpty(s))
            return (int)0;
        else
            return Convert.ToInt32(s);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string formatcurrency(object value)
    {
        decimal d = 0;
        string dd = "";
        if (value != null && value.ToString().Length > 0)
        {
            CultureInfo cu = CultureInfo.GetCultureInfo("en-US");
            d = Math.Round(Convert.ToDecimal(value), 2);
            dd = d.ToString("C", cu);
        }
        return dd;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strValue"></param>
    /// <returns></returns>
    public static bool CheckIfStringIsDecimalFormat(string strValue)
    {
        bool result = false;
        decimal decValue = 0;

        if (!String.IsNullOrEmpty(strValue))
        {
            result = decimal.TryParse(strValue, out decValue);
        }
        else { result = false; }

        return result;
    }
    public static string CheckNullString(object o)
    {
        if (o != null)
            return o.ToString();
        else
            return "";
    }
    public static decimal CheckNullDecimal(object o)
    {
        if (o != null)
        {
            try { return Convert.ToDecimal(o); }
            catch { return 0; }

        }
        else
            return 0;
    }

    /// <summary>
    /// Clean a string input - no HTML allowed
    /// </summary>
    /// <param name="strToClean"></param>
    /// <returns>Cleaned HtmlEncode string</returns>
    public static string CleanString(string strToClean)
    {
        string strResult = strToClean.Trim();

        if (!String.IsNullOrEmpty(strResult))
        {
            strResult = strResult.Replace("'", "");
            strResult = strResult.Replace("<", "");
            strResult = strResult.Replace(">", "");
            strResult = strResult.Replace("http://", "");
            strResult = strResult.Replace("\"", "&quot;");
        }
        return strResult;
    }

    /// <summary>
    /// Clean a URL string input, no HTML allowed, spaces changed to %20
    /// </summary>
    /// <param name="strToClean"></param>
    /// <returns>cleaned URL string</returns>
    public static string CleanURL(string strToClean)
    {
        string strResult = strToClean.Trim();

        if (!String.IsNullOrEmpty(strResult))
        {
            strResult = strResult.Replace("'", "");
            strResult = strResult.Replace("<", "");
            strResult = strResult.Replace(">", "");
            strResult = HttpUtility.UrlPathEncode(strResult);
        }

        return strResult;
    }

    public static int IntCheck(string strValue)
    {
        return String.IsNullOrEmpty(strValue) ? 0 : Convert.ToInt32(strValue);
    }

    public static bool BoolCheck(string strValue)
    {
        return strValue.ToLower() == "true" ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="img_original"></param>
    /// <param name="dblWidth"></param>
    /// <param name="dblheight"></param>
    /// <returns></returns>
    public static System.Drawing.Image GetResizeImage(System.Drawing.Bitmap img_original, int dblWidth, int dblheight)
    {
        int width = 0;
        int height = 0;
        if (img_original.Width > dblWidth | img_original.Height > dblheight)
        {
            if (img_original.Width > img_original.Height || img_original.Width == img_original.Height)
            {
                double proportion = (double)img_original.Width / dblWidth;
                width = dblWidth;
                height = (int)(img_original.Height / proportion);
            }
            if (img_original.Width < img_original.Height)
            {
                double proportion = (double)img_original.Height / dblheight;
                height = dblheight;
                width = (int)(img_original.Width / proportion);
            }
        }
        return img_original.GetThumbnailImage(width, height, null, IntPtr.Zero);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileUpload"></param>
    /// <param name="directory"></param>
    /// <param name="maxWidth"></param>
    /// <param name="maxHeight"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static bool UploadFile(FileUpload fileUpload, string directory, int maxWidth, int maxHeight,string filename)
    {
        // First we check to see if the user has selected a file
        if (fileUpload.HasFile)
        {

            string ext=System.IO.Path.GetExtension(fileUpload.FileName);

            // Create a bitmap of the content of the fileUpload control in memory
            Bitmap originalBMP = new Bitmap(fileUpload.FileContent);

            // Calculate the new image dimensions
            int origWidth = originalBMP.Width;
            int origHeight = originalBMP.Height;
            int sngRatio = origWidth / origHeight;

            int imgWidth = 0;
            int imgHeight = origHeight;

            if (origWidth > maxWidth)  
            {
                imgWidth = maxWidth;
                imgHeight =
Convert.ToInt32(Convert.ToDecimal(origHeight) *
(Convert.ToDecimal(imgWidth) / Convert.ToDecimal(origWidth)));
            }
            else { imgWidth = origWidth; }

            // Create a new bitmap which will hold the previous resized bitmap
            Bitmap newBMP = new Bitmap(originalBMP, imgWidth, imgHeight);
            // Create a graphic based on the new bitmap
            Graphics oGraphics = Graphics.FromImage(newBMP);

            // Set the properties for the new graphic file
            oGraphics.SmoothingMode =
System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
oGraphics.InterpolationMode =
System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Draw the new graphic based on the resized bitmap
            oGraphics.DrawImage(originalBMP, 0, 0, imgWidth, imgHeight);

            // Save the new graphic file to the server
            newBMP.Save(directory + filename, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Once finished with the bitmap objects, we deallocate them.
            originalBMP.Dispose();
            newBMP.Dispose();
            oGraphics.Dispose();

            return true;
        }
        else
        {
            return false;
        }
    }

//    public static bool UploadFile(UploadedFile fileUpload, string directory, int maxWidth, int maxHeight, string filename)
//    {
//        // First we check to see if the user has selected a file


//        string ext = System.IO.Path.GetExtension(fileUpload.FileName);

//        // Create a bitmap of the content of the fileUpload control in memory
//        Bitmap originalBMP = new Bitmap(fileUpload.InputStream);

//        // Calculate the new image dimensions
//        int origWidth = originalBMP.Width;
//        int origHeight = originalBMP.Height;
//        int sngRatio = origWidth / origHeight;

//        int imgWidth = 0;
//        int imgHeight = origHeight;

//        if (origWidth > maxWidth)
//        {
//            imgWidth = maxWidth;
//            imgHeight =
//Convert.ToInt32(Convert.ToDecimal(origHeight) *
//(Convert.ToDecimal(imgWidth) / Convert.ToDecimal(origWidth)));
//        }
//        else { imgWidth = origWidth; }

//        // Create a new bitmap which will hold the previous resized bitmap
//        Bitmap newBMP = new Bitmap(originalBMP, imgWidth, imgHeight);
//        // Create a graphic based on the new bitmap
//        Graphics oGraphics = Graphics.FromImage(newBMP);

//        // Set the properties for the new graphic file
//        oGraphics.SmoothingMode =
//System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
//        oGraphics.InterpolationMode =
//        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

//        // Draw the new graphic based on the resized bitmap
//        oGraphics.DrawImage(originalBMP, 0, 0, imgWidth, imgHeight);
//        string physicalpath = HttpContext.Current.Server.MapPath("~");
//        if (physicalpath.LastIndexOf("\\") != physicalpath.Length)
//            physicalpath = physicalpath + "\\";
//        //HttpContext.Current.Response.Write(physicalpath);
//        //HttpContext.Current.Response.End();
//        // Save the new graphic file to the server
//        newBMP.Save(physicalpath + directory + filename, System.Drawing.Imaging.ImageFormat.Jpeg);

//        // Once finished with the bitmap objects, we deallocate them.
//        originalBMP.Dispose();
//        newBMP.Dispose();
//        oGraphics.Dispose();

//        return true;


//    }

    public static string GetExtension(string ext)
    {
        string filename = "";
        if (String.IsNullOrEmpty(ext))
            return filename;

        filename += ".jpg";

        return filename;
    }


    //public static string GetStoreConfigValue(string key, object storeID1)
    //{
    //    string storeID = storeID1.ToString();
    //    if (HttpContext.Current.Application[key + storeID] == null)
    //    {
    //        //SqlDataReader dr =  SqlHelper.ExecuteReader(Common.connectionString, CommandType.Text, "select specialHomePage,ThemeName,TrackingScript,pageHeader,pageFooter,leftSide from StoreConfiguration ");
    //        SqlDataReader dr = SqlHelper.ExecuteReader(Common.connectionString, CommandType.Text, "select ThemeName,TrackingScript,pageHeader,pageFooter,sc.ThemeId,sc.WebsiteRoot,sc.storeName,LocationMenuName from StoreConfiguration sc left join WebsiteThemes wt on sc.ThemeId=wt.ThemeId");
    //        if (dr.Read())
    //        {
    //            //HttpContext.Current.Application["specialHomePage" + storeID] = dr.GetBoolean(0);
    //            HttpContext.Current.Application["ThemeName" + storeID] = dr.GetString(0);
    //            if (!dr.IsDBNull(1))
    //                HttpContext.Current.Application["TrackingScript" + storeID] = dr.GetString(1);
                
              
    //            if (!dr.IsDBNull(2))
    //                HttpContext.Current.Application["pageHeader" + storeID] = dr.GetString(2);
    //            if (!dr.IsDBNull(3))
    //                HttpContext.Current.Application["pageFooter" + storeID] = dr.GetString(3);
    //            if (!dr.IsDBNull(4))
    //                HttpContext.Current.Application["ThemeID" + storeID] = dr.GetInt32(4);
    //            if (!dr.IsDBNull(5))
    //                HttpContext.Current.Application["WebsiteRoot" + storeID] = dr.GetString(5);
    //            if (!dr.IsDBNull(6))
    //                HttpContext.Current.Application["storeName" + storeID] = dr.GetString(6);
    //            if (!dr.IsDBNull(7))
    //                HttpContext.Current.Application["LocationMenuName" + storeID] = dr.GetString(7);

    //        } dr.Close();

    //        return Convert.ToString(HttpContext.Current.Application[key + storeID]);
    //    }
    //    else
    //    {
    //        return Convert.ToString(HttpContext.Current.Application[key + storeID]);
    //    }
    //}


    public static bool SendEmail(string FromEmailID, string ToEmailID, string subject, string MailBody, Boolean IsBodyHtml)
    {
        MailMessage mm = new MailMessage();

        foreach (string toemail in ToEmailID.Split(';'))
            if (!String.IsNullOrEmpty(toemail))
                mm.To.Add(new MailAddress(toemail));

        mm.Bcc.Add("john.simonson@gmail.com");
        mm.Bcc.Add("jigarppatel@gmail.com");
        if (!String.IsNullOrEmpty(FromEmailID))
            mm.From = new MailAddress(FromEmailID);
        mm.Subject = subject;
        mm.IsBodyHtml = IsBodyHtml;
        mm.Body = MailBody;

        //try
        //{
            //SendMail(mm);
        //}
        //catch
        //{
        //    return false;
        //}
            SmtpClient smtp = new SmtpClient();
            smtp.Send(mm);
        return true;
    }

    private static void SendMail(MailMessage msg)
    {
        SmtpClient smtp = new SmtpClient();
      
        smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
        if (ConfigurationManager.AppSettings["SMTP"].ToString() != "127.0.0.1")
        {
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPEMail"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
        }
        smtp.Send(msg);
        msg.Dispose();       
        smtp = null;
    }

    public static string getExtraParameterValue(string XML, string key)
    {
        try
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\"?><root>" + XML + "</root>");
            return doc.GetElementsByTagName(key).Item(0).InnerText;
        }
        catch
        {
            return "";
        }
    }

    //public static void TrackingScript(Page p)
    //{
    //    string TrackingScript = "";
    //    if (HttpContext.Current.Session["TrackingScript"] == null)
    //    {

    //        HttpContext.Current.Session["TrackingScript"] = GetStoreConfigValue("TrackingScript", Common.StoreID);
    //    }
    //    else
    //    {
    //        TrackingScript = HttpContext.Current.Session["TrackingScript"].ToString();
    //    }
    //    string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
    //    if (Protocol == null || Protocol == "0")
    //        p.ClientScript.RegisterStartupScript(typeof(String), "TrackingScript", TrackingScript, true);
    //    else
    //        Protocol = "https://";
    //}
    public static string DrawText(String text, System.Drawing.Font font, Color textColor, Color backColor)
    {
        //first, create a dummy bitmap just to get a graphics object
        System.Drawing.Image img = new Bitmap(1, 1);




        Graphics drawing = Graphics.FromImage(img);

        //measure the string to see how big the image needs to be
        SizeF textSize = drawing.MeasureString(text, font);

        //free up the dummy image and old graphics object
        img.Dispose();
        drawing.Dispose();



        Bitmap bmp = new Bitmap((int)textSize.Width, (int)textSize.Height);

        Random rand = new Random();
        for (int y = 0; y < (int)textSize.Height; y++)
        {
            for (int x = 0; x < (int)textSize.Width; x++)
            {
                int a = rand.Next(256);
                int r = rand.Next(256);
                int g = rand.Next(256);
                int b = rand.Next(256);

                bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
            }
        }

        //create a new image of the right size
        img = bmp;
        drawing = Graphics.FromImage(img);

        //paint the background
        //drawing.Clear(backColor);

        //create a brush for the text
        Brush textBrush = new SolidBrush(textColor);

        drawing.DrawString(text, font, textBrush, 0, 0);

        drawing.Save();

        textBrush.Dispose();
        drawing.Dispose();
        string fileName = Guid.NewGuid().ToString() + ".png";
        img.Save(HttpContext.Current.Server.MapPath("~/uploads/Captcha/") + fileName, System.Drawing.Imaging.ImageFormat.Png);
        return "~/uploads/Captcha/" + fileName;

    }

//    public static void DeleteSitepagesHistory(int SitePageId)
//    {
//        string strQuery = @"delete from SitePageContentHistory where SitePagesHistoryId in
//            (
//	            select SitepagesHistoryId from sitepageshistory where sitepageid="+ SitePageId.ToString() +@" and SitePagesHistoryId not in
//	            (
//	                select top " + Constants.MaintainSitePagesHistoryRecords + @" SitepagesHistoryId from SitepagesHistory where sitepageid="+SitePageId+@" order by ChangedDate desc
//	            )
//            );";

//        strQuery += @"delete from sitepageshistory where sitepageid=" + SitePageId + @" and SitePagesHistoryId not in
//            (
//                select top 5 SitepagesHistoryId from SitepagesHistory where sitepageid="+ SitePageId + @" order by ChangedDate desc
//            )";
//        SqlHelper.ExecuteNonQuery(Common.connectionString, CommandType.Text, strQuery);
//    }

    //public static decimal BuildFreightRequestXML(decimal sWeight, string sOriginZipCode, string sDestinationZipCode, string sDestinationCountry, out string error)
    //{
        
    //    string sUsername = "";
    //    string sPassword = "";
    //    string sAccountNumber = "";
    //    string sRateCLass = "55";
    //    using (Model.ECommerceDataContext ctx = new Model.ECommerceDataContext())
    //    {
    //        Model.ECommerceSetting ecs = ctx.ECommerceSettings.FirstOrDefault();
    //        if (ecs != null)
    //        {
    //            sUsername = ecs.EstesUserName;
    //            sPassword = ecs.EstesPassword;
    //            sAccountNumber = ecs.EstesAccountNum;

    //            if (String.IsNullOrEmpty(sOriginZipCode))
    //            sOriginZipCode = ecs.ShippingOriginZipCode;
                
    //        }
    //    }

    //    RateQuoteService rqs = new RateQuoteService();
    //    rqs.auth = new AuthenticationType();
    //    rqs.auth.user = sUsername;
    //    rqs.auth.password = sPassword;


    //    rateRequest rr = new rateRequest();
    //    rr.requestID = "min-" + DateTime.Now.ToString("yyyy-MM-dd-hhmmss");

    //    rr.account = sAccountNumber;

    //    PointType ptDestination = new PointType();
    //    ptDestination.countryCode = "US";
    //    ptDestination.postalCode = sDestinationZipCode;
    //    rr.destinationPoint = ptDestination;

    //    PointType ptOrigin = new PointType();
    //    ptOrigin.countryCode = "US";
    //    ptOrigin.postalCode = sOriginZipCode;
    //    //ptOrigin.city = "Dalton";
    //    //ptOrigin.stateProvince = "GA";
    //    rr.originPoint = ptOrigin;
    //    rr.payor = "S";
    //    rr.terms = "PPD";
    //    rr.stackable = YesNoBlankType.N;

    //    rr.pickup = new PickupType();
    //    rr.pickup.close = DateTime.Now;
    //    rr.pickup.date = DateTime.Now;
    //    rr.pickup.ready = DateTime.Now;


    //    rr.liability = "S";
    //    BaseCommoditiesType bct = new BaseCommoditiesType();

    //    bct.commodity = new BaseCommodityType[1];
    //    bct.commodity[0] = new BaseCommodityType();
    //    bct.commodity[0].@class = Convert.ToDecimal(sRateCLass);
    //    bct.commodity[0].weight = sWeight.ToString("0");
    //    rr.Item = bct;


    //    try
    //    {
    //        rateQuote rq = rqs.getQuote(rr);
    //        PricingInfoType pit = rq.quote.pricing.Where(c => c.serviceLevel == "LTL Standard Transit: 5PM").FirstOrDefault();
    //        error = "";
    //        // add 10% to shipping costs
    //        return pit.standardPrice;// *Convert.ToDecimal(1.10);
    //    }
    //    catch (SoapException ex)
    //    {
    //        error = ex.Detail.InnerText;
    //    }
    //    catch (Exception ex)
    //    {
    //        error = ex.Message;
    //    }
    //    return 0;

    //}
}
