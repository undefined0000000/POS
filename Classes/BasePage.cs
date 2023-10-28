using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

using Repository;
//using AjaxControlToolkit;
using System.IO.Compression;
using Database;

/// <summary>
/// Class added by Shahid Iqbal
// Dated : Oct 07, 2015
// Every Page Permission will be Checked from here....
/// </summary>
public class BasePage : Page
{
    public int LoginUserID
    {
        get
        {
            if (Session["USER"] == null)
            {
                return 0;
            }
            return ((USER_MST)Session["USER"]).USER_ID;
        }

    }

    /// <summary>
    /// Function to handle messages
    /// </summary>
    /// <param name="Message">The Message to Display</param>
    /// <param name="MessageType">Message Type 1: Error(default), 2:Warning , 3:Information , 4:Success</param>
    public void ShowMessage(string Message, int MessageType = 1)
    {
        if (Master == null) return;
        var UP_Message = (UpdatePanel)Master.FindControl("UP_Message");
        var Div_Message = (Panel)Master.FindControl("ResultPanel");
        var AlertType = "";
        var type = "";
        switch (MessageType)
        {
            case 1:
                AlertType = "\"alert alert-danger animated bounceIn\"";
                type = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><div class=\"icon\"> <i class=\"fa fa-times\"></i>  <strong>Error! </strong>";
                break;
            case 2:
                AlertType = "\"alert alert-warning animated bounceIn\"";
                type = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><div class=\"icon\"> <i class=\"fa fa-warning\"></i>  <strong>Warning! </strong>";
                break;
            case 3:
                AlertType = "\"alert alert-info animated bounceIn\"";
                type = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><div class=\"icon\"> <i class=\"fa fa-info\"></i> <strong>Info! </strong>";
                break;
            case 4:
                AlertType = "\"alert alert-success animated bounceIn\"";
                type = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><div class=\"icon\"> <i class=\"fa fa-check\"></i>  <strong>Success! </strong>";
                break;
        }
/*<div id="" class="alert alert-info animated bounceIn media fade in">
            <div class="icon"><i class="fa fa-info"></i> <strong>Info! </strong><span>Please Provide Valid Amount</span></div>
           
        </div>*/
        var Div = "<div ID=\"Alert\"  class=" + AlertType + " media fade in>";
        //Div_Message.Controls.Add(new LiteralControl(Div));

        //var close_button = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><div class=\"icon\"> <h3><i class=\"fa " + icon + "></i></h3> </div> <strong>" + type + "</strong>";
       // Div_Message.Controls.Add(new LiteralControl(type));

        var newlabel = new Label();
        newlabel.Text = Message;
        //Div_Message.Controls.Add(newlabel);

       // Div_Message.Controls.Add(new LiteralControl("</div> </div>"));
        //Div_Message.Visible = true;
        //UP_Message.Update();


        //Div_Message.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button><span></span><p>" + Message + "</p>";
        //Div_Message.Attributes.Add("class", "alert alert-danger animated bounceIn");
        //Div_Message.Visible = true;
        //UP_Message.Update();



    }

 

  
    protected override void OnLoad(EventArgs e)
    {
        if (Master != null)
        {
            // Utility.Msg_Blank(this.Master);
        }
        if (!IsPostBack)
        {
            CheckPagePermission();
            //if (Request.Cookies["PageSize"] == null)
            //{
            //    //Save Cookie of Pager
            //    SavePagerCookie("10");
            //}
            ////PageSize = int.Parse(Request.Cookies["PageSize"]["NumberOfRows"]);
            //LoginUserID != ((USER_MST)Session["USER"]).USER_ID;
        }
     
        base.OnLoad(e);
    }

    private void CheckPagePermission()
    {
        var reqUrl = Request.RawUrl;
        var currentPage = reqUrl.Substring(reqUrl.LastIndexOf('/') + 1, (reqUrl.Length - reqUrl.LastIndexOf('/')) - 1);
        //if url contains query string remove it.
        if (currentPage.Contains("?"))
            currentPage = currentPage.Substring(0, currentPage.IndexOf("?"));
        //switch (currentPage)
        //{
        //    case "ConsultantDetail.aspx"://ConsultantDetail and consultantlisting are same activities but different permissions
        //        currentPage = "ConsultantsListing.aspx";
        //        break;
        //    case "AddConsultants.aspx"://AddConsultant and consultants listing are same activities but different permissions
        //        currentPage = "ConsultantsListing.aspx";
        //        break;
        //    case "PatientDetail.aspx"://PatientDetail patients listing are same activities but different permissions
        //        currentPage = "PatientsListing.aspx";
        //        break;
        //    case "Registration.aspx"://Patient Registration and patients listing are same activities but different permissions
        //        currentPage = "PatientsListing.aspx";
        //        break;
        //    case "Appointments.aspx"://New Appointment and appointments listing are same activities but different permissions
        //        currentPage = "AppointmentsListing.aspx";
        //        break;
        //    case "VoucherDetail.aspx":
        //        currentPage = "VoucherListings.aspx";
        //        break;
        //    default: break;
        //}
        if (currentPage.ToLower() != "home.aspx" && currentPage.ToLower() != "def1.aspx")
        {
          
                var userActivities = (List<ClsActivities>)Session["MCUserActivities"];
                var match = from a in userActivities
                            where a.ActivityName.ToLower().Trim() == currentPage.ToLower().Trim()
                            select a;
                var en = match.GetEnumerator();
                en.MoveNext();
                if (en.Current == null)
                    Response.Redirect("~/Login.aspx");
                else
                {
                    var act = (ClsActivities)en.Current;
                    if (!act.ActivityAdd && !act.ActivityDelete && !act.ActivityUpdate && !act.ActivityView)
                        Response.Redirect("~/Login.aspx");
                    else
                        SetCurrentActivity(act);
                }
           
        }
    }

    protected internal void SetCurrentActivity(ClsActivities activity)
    {
        ViewState["MCCurrentActitity"] = activity;
    }

    protected ClsActivities CurrentActitity
    {
        get { return (ClsActivities)ViewState["MCCurrentActitity"]; }
    }

    public bool GetPermissionByName(string permissionName)
    {
        try
        {
            var status = false;
            if (Session["UserActivities"] != null)
            {
                var userActivities = (List<ClsActivities>)Session["UserActivities"];
                var match = from a in userActivities
                            where a.ActivityPage.ToLower().Trim() == permissionName.ToLower().Trim()
                            select a;
                var en = match.GetEnumerator();
                en.MoveNext();
                if (en.Current == null)
                {
                    status = false;
                }
                else
                {
                    var act = (ClsActivities)en.Current;
                    if (!act.ActivityAdd && !act.ActivityDelete && !act.ActivityUpdate && !act.ActivityView)
                        status = false;
                    else
                        status = true;
                }
            }
            return status;
        }
        catch
        {
            return false;
        }
    }

    protected override object LoadPageStateFromPersistenceMedium()
    {
        var alteredViewState = string.Empty;
        byte[] bytes;
        object rawViewState;
        var fomatter = new LosFormatter();
        PageStatePersister.Load();
        if (PageStatePersister.ViewState != null)
            alteredViewState = PageStatePersister.ViewState.ToString();
        else
            alteredViewState = string.Empty;
        bytes = Convert.FromBase64String(alteredViewState);
        bytes = Compressor.Decompress(bytes);
        rawViewState = fomatter.Deserialize(Convert.ToBase64String(bytes));
        return new Pair(PageStatePersister.ControlState, rawViewState);
    }
    public class Compressor
    {
        public static byte[] Compress(byte[] data)
        {
            var output = new MemoryStream();
            var gzip = new GZipStream(output, CompressionMode.Compress, true);
            gzip.Write(data, 0, data.Length);
            gzip.Close();
            return output.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            var Input = new MemoryStream();
            Input.Write(data, 0, data.Length);
            Input.Position = 0;
            var gzip = new GZipStream(Input, CompressionMode.Decompress, true);
            var output = new MemoryStream();
            var buff = new byte[64];
            var read = gzip.Read(buff, 0, buff.Length);
            while (read > 0)
            {
                output.Write(buff, 0, read);
                read = gzip.Read(buff, 0, buff.Length);
            }

            gzip.Close();
            return output.ToArray();
        }
    }

    protected override void SavePageStateToPersistenceMedium(object viewStateIn)
    {
        var fomatter = new LosFormatter();
        var writer = new StringWriter();
        Pair rawPair;
        object rawViewState;
        string rawViewStateStr;
        string alteredViewState;
        byte[] bytes;

        if (viewStateIn.GetType() == typeof(Pair))
        {
            rawPair = (Pair)(viewStateIn);
            PageStatePersister.ControlState = rawPair.First;
            rawViewState = rawPair.Second;
        }
        else
        {
            rawViewState = viewStateIn;
        }
        fomatter.Serialize(writer, rawViewState);
        rawViewStateStr = writer.ToString();
        bytes = Convert.FromBase64String(rawViewStateStr);
        bytes = Compressor.Compress(bytes);
        alteredViewState = Convert.ToBase64String(bytes);
        PageStatePersister.ViewState = alteredViewState;
        PageStatePersister.Save();
    }

   



    protected void OpenReportWindow(string WinPopUpUrl)
    {
        if (WinPopUpUrl.StartsWith("/"))
            WinPopUpUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + WinPopUpUrl;
        else
            WinPopUpUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + "/" + WinPopUpUrl;
        var scriptBuidler = new StringBuilder(@"<script type='text/javascript' language='javascript'>");
        scriptBuidler.Append(@"window.open('");
        scriptBuidler.Append(WinPopUpUrl);
        scriptBuidler.Append(@"','','toolbar=0,location=0, directories=0, status=0, menubar=0,scrollbars=1,resizable=1,width=1014,height=714,left=0,top=0');");
        scriptBuidler.Append(@"</script>");
        //ToolkitScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Report Popup",
        // scriptBuidler.ToString(), false);

    }

    protected void OpenTwoWindows(string URLWindowA, string URLWindowB)
    {
        URLWindowA = "~" + URLWindowA;
        var scriptBuidler = new StringBuilder(@"<script type='text/javascript' language='javascript'>");
        scriptBuidler.Append(@"window.open('");
        scriptBuidler.Append(ResolveClientUrl(URLWindowA));
        scriptBuidler.Append(@"','','toolbar=0,location=0, directories=0, status=0, menubar=0,scrollbars=1,resizable=1,width=1014,height=714,left=0,top=0');");
        scriptBuidler.Append(@"window.open('");
        scriptBuidler.Append(ResolveClientUrl(URLWindowB));
        scriptBuidler.Append(@"','','toolbar=0,location=100, directories=0, status=0, menubar=0,scrollbars=1,resizable=1,width=1000,height=700,left=0,top=0');");
        scriptBuidler.Append(@"</script>");
        //ToolkitScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Report Popup",
        //    scriptBuidler.ToString(), false);

    }

    protected void OpenReportWindow(string WinPopUpUrl, string confirmText)
    {
        if (WinPopUpUrl.StartsWith("/"))
            WinPopUpUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + WinPopUpUrl;
        else
            WinPopUpUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + "/" + WinPopUpUrl;
        var scriptBuidler = new StringBuilder(@"<script type='text/javascript' language='javascript'>");
        scriptBuidler.Append(@"if(confirm('");
        scriptBuidler.Append(confirmText);
        scriptBuidler.Append(@"')){");
        scriptBuidler.Append(@"window.open('");
        scriptBuidler.Append(WinPopUpUrl);
        scriptBuidler.Append(@"','','toolbar=0,location=0, directories=0, status=0, menubar=0,scrollbars=1,resizable=1,width=1014,height=714,left=0,top=0');");
        scriptBuidler.Append(@"}");
        scriptBuidler.Append(@"</script>");
        //ToolkitScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Report Popup",
        // scriptBuidler.ToString(), false);

    }

    protected string GetFullUrl(string VirtualUrl)
    {
        if (VirtualUrl.StartsWith("~"))
            VirtualUrl = VirtualUrl.TrimStart(new char[] { '~' });
        if (VirtualUrl.StartsWith("http://"))
            return VirtualUrl;
        if (VirtualUrl.StartsWith("/"))
            VirtualUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + VirtualUrl;
        else
            VirtualUrl = Request.UrlReferrer.Scheme + "://" + Request.UrlReferrer.Authority + "/" + VirtualUrl;
        return VirtualUrl;
    }

    #region [Paging Functions and Parameters]
    public string SortExpression
    {
        get { try { return ViewState["SortExpression"].ToString(); } catch { return string.Empty; } }
        set { ViewState["SortExpression"] = value; }
    }
    public string SortDirection
    {
        get { try { return ViewState["SortDirection"].ToString(); } catch { return string.Empty; } }
        set { ViewState["SortDirection"] = value; }
    }
    public int PageIndex
    {
        get { try { return int.Parse(ViewState["PageIndex"].ToString()); } catch { return 0; } }
        set { ViewState["PageIndex"] = value; }
    }
    public int PageCount
    {
        get { return int.Parse(ViewState["PageCount"].ToString()); }
        set { ViewState["PageCount"] = value; }
    }
    public int PageSize
    {
        get { try { return int.Parse(ViewState["PageSize"].ToString()); } catch { try { return int.Parse(Request.Cookies["PageSize"]["NumberOfRows"]); } catch { return 10; } } }
        set { ViewState["PageSize"] = value; }
    }
    public int TotalRecords
    {
        get { try { return int.Parse(ViewState["TotalRecords"].ToString()); } catch { return 0; } }
        set { ViewState["TotalRecords"] = value; }
    }
    protected void SavePagerCookie(string value)
    {
        try
        { PageSize = int.Parse(value); if (PageSize < 1) { PageSize = 10; value = "10"; } }
        catch { PageSize = 10; value = "10"; }
        var Cookie_Pager = new HttpCookie("PageSize");
        Cookie_Pager["NumberOfRows"] = PageSize.ToString();
        Cookie_Pager.Expires = DateTime.MaxValue;
        Response.AppendCookie(Cookie_Pager);
    }
    protected void SetPagerButtonStates(GridViewRow gvPagerRow, ref GridView gridview)
    {
        var lb_No1 = (LinkButton)gvPagerRow.FindControl("lb_No1");
        var lb_No2 = (LinkButton)gvPagerRow.FindControl("lb_No2");
        var lb_No3 = (LinkButton)gvPagerRow.FindControl("lb_No3");
        var lb_First = (LinkButton)gvPagerRow.FindControl("lb_First");
        var lb_Previous = (LinkButton)gvPagerRow.FindControl("lb_Previous");
        var lb_Next = (LinkButton)gvPagerRow.FindControl("lb_Next");
        var lb_Last = (LinkButton)gvPagerRow.FindControl("lb_Last");

        var lbl_FirstPageRow = (Label)gvPagerRow.FindControl("lbl_rowstartindex");
        var lbl_LastpageRow = (Label)gvPagerRow.FindControl("lbl_rowendindex");
        var lbl_TotalRows = (Label)gvPagerRow.FindControl("lbl_totalrecords");
        var TxBx_PageSize = (TextBox)gvPagerRow.FindControl("TxBx_PageSize");

        lbl_TotalRows.Text = TotalRecords.ToString();
        lbl_FirstPageRow.Text = ((PageIndex * PageSize) + 1).ToString();
        lbl_LastpageRow.Text = ((PageIndex + 1) * PageSize).ToString();

        if (TotalRecords <= PageSize) //1 page
        {
            lb_First.Visible = false;
            lb_Previous.Visible = false;
            lb_Next.Visible = false;
            lb_Last.Visible = false;
            lb_No1.Visible = false;
            lb_No2.Visible = false;
            lb_No3.Visible = false;
        }
        else if (TotalRecords <= (2 * PageSize))
        {
            lb_No3.Visible = false;
        }

        if (PageIndex == 0)
        {
            lb_No1.Enabled = false;
            lb_First.Enabled = false;
            lb_Previous.Enabled = false;
            lb_First.Visible = false;
            lb_Previous.Visible = false;
        }

        if (PageIndex == PageCount - 1)
        {
            lbl_LastpageRow.Text = lbl_TotalRows.Text;
            if (lb_No3.Visible)
                lb_No3.Enabled = false;
            lb_Next.Visible = false;
            lb_Last.Visible = false;
        }

        if ((PageIndex + 1).ToString() != lb_No1.Text && (PageIndex + 1).ToString() != lb_No2.Text && (PageIndex + 1).ToString() != lb_No3.Text)
        {
            lb_No1.Text = (PageIndex + 1).ToString();
            lb_No2.Text = (PageIndex + 2).ToString();
            lb_No3.Text = (PageIndex + 3).ToString();
        }

        if (lb_No3.Visible && int.Parse(lb_No3.Text) >= PageCount)
        {
            lb_No3.Text = PageCount.ToString();
            lb_No2.Text = (PageCount - 1).ToString();
            lb_No1.Text = (PageCount - 2).ToString();
        }


        if (PageIndex + 1 == int.Parse(lb_No1.Text))
            lb_No1.Enabled = false;
        else if (PageIndex + 1 == int.Parse(lb_No2.Text))
            lb_No2.Enabled = false;
        else if (PageIndex + 1 == int.Parse(lb_No3.Text))
            lb_No3.Enabled = false;

        if ((PageIndex + 1) * PageSize >= TotalRecords)
        {
            lb_Last.Enabled = false;
            lb_Next.Enabled = false;
            lb_No3.Enabled = false;
        }
        TxBx_PageSize.Text = PageSize.ToString();

    }
    protected void SetGVPage(ref GridViewCommandEventArgs e, ref GridView GV)
    {
        var lb_No1 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No1");
        var lb_No2 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No2");
        var lb_No3 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No3");
        //LinkButton lb_First = (LinkButton)GV.BottomPagerRow.FindControl("lb_First");
        //LinkButton lb_Previous = (LinkButton)GV.BottomPagerRow.FindControl("lb_Previous");
        //LinkButton lb_Next = (LinkButton)GV.BottomPagerRow.FindControl("lb_Next");
        //LinkButton lb_Last = (LinkButton)GV.BottomPagerRow.FindControl("lb_Last");

        //Label lbl_FirstPageRow = (Label)GV.BottomPagerRow.FindControl("lbl_rowstartindex");
        //Label lbl_LastpageRow = (Label)GV.BottomPagerRow.FindControl("lbl_rowendindex");
        //Label lbl_TotalRows = (Label)GV.BottomPagerRow.FindControl("lbl_totalrecords");
        var TxBx_PageSize = (TextBox)GV.BottomPagerRow.FindControl("TxBx_PageSize");

        switch (e.CommandArgument.ToString().ToLower())
        {
            case "first":
                PageIndex = 0;
                break;
            case "prev":
                PageIndex--;
                break;
            case "1":
                PageIndex = int.Parse(lb_No1.Text.Trim()) - 1;
                break;
            case "2":
                PageIndex = int.Parse(lb_No2.Text.Trim()) - 1;
                break;
            case "3":
                PageIndex = int.Parse(lb_No3.Text.Trim()) - 1;
                break;
            case "next":
                PageIndex++;
                break;
            case "last":
                PageIndex = PageCount - 1;
                break;
            case "lb_change_pagesize":
                //'Save Cookie of Pager
                //Move to Custom Page
                SavePagerCookie(TxBx_PageSize.Text.Trim());
                GV.PageSize = PageSize;
                PageIndex = 0;
                GV.PageIndex = PageIndex;
                break;
            default:
                break;
        }
    }

    //protected void SetPagerButtonStates(GridViewRow gvPagerRow, ref GridView gridview)
    //{
    //    LinkButton lb_No1 = (LinkButton)gvPagerRow.FindControl("lb_No1");
    //    LinkButton lb_No2 = (LinkButton)gvPagerRow.FindControl("lb_No2");
    //    LinkButton lb_No3 = (LinkButton)gvPagerRow.FindControl("lb_No3");
    //    LinkButton lb_First = (LinkButton)gvPagerRow.FindControl("lb_First");
    //    LinkButton lb_Previous = (LinkButton)gvPagerRow.FindControl("lb_Previous");
    //    LinkButton lb_Next = (LinkButton)gvPagerRow.FindControl("lb_Next");
    //    LinkButton lb_Last = (LinkButton)gvPagerRow.FindControl("lb_Last");

    //    Label lbl_FirstPageRow = (Label)gvPagerRow.FindControl("lbl_rowstartindex");
    //    Label lbl_LastpageRow = (Label)gvPagerRow.FindControl("lbl_rowendindex");
    //    Label lbl_TotalRows = (Label)gvPagerRow.FindControl("lbl_totalrecords");
    //    TextBox TxBx_PageSize = (TextBox)gvPagerRow.FindControl("TxBx_PageSize");

    //    lbl_TotalRows.Text = TotalRecords.ToString();
    //    lbl_FirstPageRow.Text = ((PageIndex * PageSize) + 1).ToString();
    //    lbl_LastpageRow.Text = ((PageIndex + 1) * PageSize).ToString();

    //    if (TotalRecords <= PageSize) //1 page
    //    {
    //        lb_First.Visible = false;
    //        lb_Previous.Visible = false;
    //        lb_Next.Visible = false;
    //        lb_Last.Visible = false;
    //        lb_No1.Visible = false;
    //        lb_No2.Visible = false;
    //        lb_No3.Visible = false;
    //    }
    //    else if (TotalRecords <= (2 * PageSize))
    //    {
    //        lb_No3.Visible = false;
    //    }

    //    if (PageIndex == 0)
    //    {
    //        lb_No1.Enabled = false;
    //        lb_First.Enabled = false;
    //        lb_Previous.Enabled = false;
    //        lb_First.Visible = false;
    //        lb_Previous.Visible = false;
    //    }

    //    if (PageIndex == PageCount - 1)
    //    {
    //        lbl_LastpageRow.Text = lbl_TotalRows.Text;
    //        if (lb_No3.Visible)
    //            lb_No3.Enabled = false;
    //        lb_Next.Visible = false;
    //        lb_Last.Visible = false;
    //    }

    //    if ((PageIndex + 1).ToString() != lb_No1.Text && (PageIndex + 1).ToString() != lb_No2.Text && (PageIndex + 1).ToString() != lb_No3.Text)
    //    {
    //        lb_No1.Text = (PageIndex + 1).ToString();
    //        lb_No2.Text = (PageIndex + 2).ToString();
    //        lb_No3.Text = (PageIndex + 3).ToString();
    //    }

    //    if (lb_No3.Visible && int.Parse(lb_No3.Text) >= PageCount)
    //    {
    //        lb_No3.Text = PageCount.ToString();
    //        lb_No2.Text = (PageCount - 1).ToString();
    //        lb_No1.Text = (PageCount - 2).ToString();
    //    }


    //    if (PageIndex + 1 == int.Parse(lb_No1.Text))
    //        lb_No1.Enabled = false;
    //    else if (PageIndex + 1 == int.Parse(lb_No2.Text))
    //        lb_No2.Enabled = false;
    //    else if (PageIndex + 1 == int.Parse(lb_No3.Text))
    //        lb_No3.Enabled = false;

    //    if ((PageIndex + 1) * PageSize >= TotalRecords)
    //    {
    //        lb_Last.Enabled = false;
    //        lb_Next.Enabled = false;
    //        lb_No3.Enabled = false;
    //    }
    //    TxBx_PageSize.Text = PageSize.ToString();

    //}
    //protected void SetGVPage(ref GridViewCommandEventArgs e, ref GridView GV)
    //{
    //    LinkButton lb_No1 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No1");
    //    LinkButton lb_No2 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No2");
    //    LinkButton lb_No3 = (LinkButton)GV.BottomPagerRow.FindControl("lb_No3");
    //    //LinkButton lb_First = (LinkButton)GV.BottomPagerRow.FindControl("lb_First");
    //    //LinkButton lb_Previous = (LinkButton)GV.BottomPagerRow.FindControl("lb_Previous");
    //    //LinkButton lb_Next = (LinkButton)GV.BottomPagerRow.FindControl("lb_Next");
    //    //LinkButton lb_Last = (LinkButton)GV.BottomPagerRow.FindControl("lb_Last");

    //    //Label lbl_FirstPageRow = (Label)GV.BottomPagerRow.FindControl("lbl_rowstartindex");
    //    //Label lbl_LastpageRow = (Label)GV.BottomPagerRow.FindControl("lbl_rowendindex");
    //    //Label lbl_TotalRows = (Label)GV.BottomPagerRow.FindControl("lbl_totalrecords");
    //    TextBox TxBx_PageSize = (TextBox)GV.BottomPagerRow.FindControl("TxBx_PageSize");

    //    switch (e.CommandArgument.ToString().ToLower())
    //    {
    //        case "first":
    //            PageIndex = 0;
    //            break;
    //        case "prev":
    //            PageIndex--;
    //            break;
    //        case "1":
    //            PageIndex = int.Parse(lb_No1.Text.Trim()) - 1;
    //            break;
    //        case "2":
    //            PageIndex = int.Parse(lb_No2.Text.Trim()) - 1;
    //            break;
    //        case "3":
    //            PageIndex = int.Parse(lb_No3.Text.Trim()) - 1;
    //            break;
    //        case "next":
    //            PageIndex++;
    //            break;
    //        case "last":
    //            PageIndex = PageCount - 1;
    //            break;
    //        case "lb_change_pagesize":
    //            //'Save Cookie of Pager
    //            //Move to Custom Page
    //            SavePagerCookie(TxBx_PageSize.Text.Trim());
    //            GV.PageSize = PageSize;
    //            PageIndex = 0;
    //            GV.PageIndex = PageIndex;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    #endregion

}