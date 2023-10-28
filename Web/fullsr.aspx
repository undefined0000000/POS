<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="fullsr.aspx.cs" Inherits="Web.fullsr" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html lang="en">
<!-- begin::Head -->
<head>

    <!--begin::Base Path (base relative path for assets of this page) -->
    <base href="./">
    <!--end::Base Path -->
    <meta charset="utf-8" />

    <title>DIGITAL | POS53</title>
    <meta name="description" content="Latest updates and statistic charts">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--begin::Fonts -->
    <%--<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700">--%>
    <!--end::Fonts -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="assetsn/vendors/custom/fullcalendar/fullcalendar.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Page Vendors Styles -->
    <!--begin:: Global Mandatory Vendors -->
    <link href="assetsn/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->

    <link href="assetsn/vendors/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Optional Vendors -->
    <!--begin::Global Theme Styles(used by all pages) -->

    <link href="assetsn/css/demo6/style.bundlesr.css" rel="stylesheet" type="text/css" />
    <!--end::Global Theme Styles -->
    <!--begin::Layout Skins(used by all pages) -->
    <!--end::Layout Skins -->

    <link rel="shortcut icon" href="assetsn/media/logos/favicon.ico" />
    <script src="assets/toast/jquery.js"></script>
    <script src="assets/toast/script.js"></script>
    <script src="assets/toast/toastr.min.js"></script>
    <link href="assets/toast/toastr.min.css" rel="stylesheet" />

  
    <script type="text/javascript">
        function ace_itemCoutry(sender, e) {
           
            var HiddenField3 = $get('<%= HiddenField3.ClientID %>');
            HiddenField3.value = e.get_value();
            var HiddenpaymentCustomer = $get('<%= HiddenpaymentCustomer.ClientID %>');
            HiddenpaymentCustomer.value = e.get_value();
        }
        function paymentCustomer(sender, e) {
            var HiddenpaymentCustomer = $get('<%= HiddenpaymentCustomer.ClientID %>');
            HiddenpaymentCustomer.value = e.get_value();
            var HiddenField3 = $get('<%= HiddenField3.ClientID %>');
            HiddenField3.value = e.get_value();
        }

        function backItemlink() {
            document.getElementById('ProductTab').className = "active";
            document.getElementById('PaymentTab').className = "";
        }

        function PaymentItemlink() {
            document.getElementById('ProductTab').className = "";
            document.getElementById('PaymentTab').className = "active";
        }



    </script>

    <script src="JS/jquery_004.js"></script>
    <script type="text/javascript">

        function openPopup() {

            window.open("payment.aspx", "_blank", "WIDTH=1080,HEIGHT=790,scrollbars=no, menubar=no,resizable=yes,directories=no,location=no");

        }
        //<![CDATA[    
        //
    </script>

     <script type="text/javascript">

        function calcash(btnid) {

            var textpaid = document.getElementById('txtchangepaidamount').value;
            var textvalue = document.getElementById('txtchangecashamount').value;
            if (textvalue == 0) { textvalue = ""; }
            document.getElementById('txtchangecashamount').value = textvalue + "" + btnid.value;
            document.getElementById('txtchangechangeamount').value =  (textvalue + "" + btnid.value) - textpaid
        }
        function clearamt()
        {
            document.getElementById('txtchangecashamount').value = "";
            document.getElementById('txtchangechangeamount').value = "";

        }

        function calcashc(btnid) {

            var textpaid = document.getElementById('txtcpaidamount').value;
            var textvalue = document.getElementById('txtccashamount').value;
            if (textvalue == 0) { textvalue = ""; }
            document.getElementById('txtccashamount').value = textvalue + "" + btnid.value;
            document.getElementById('txtcchangeamount').value = (textvalue + "" + btnid.value) - textpaid
        }
        function clearamtc() {
            document.getElementById('txtccashamount').value = "";
            document.getElementById('txtcchangeamount').value = "";

        }
        //<![CDATA[    
        //
    </script>

    <script type="text/javascript">

        function openPopup() {

         
        }
        //<![CDATA[    
        //
    </script>

      <link rel="stylesheet" href="/sbijava/uirevamp/saralkhata/css/phishing_login.css" type="text/css" />
    <script type="text/javascript" src="/sbijava/uirevamp/saralkhata/js/virtualkb_login.js"></script>
    <script type="text/javascript" src="/sbijava/uirevamp/saralkhata/js/common.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#<%= LabelTID.ClientID %>').hide();
            $('#<%= LabelLID.ClientID %>').hide();
            $('#<%= idfProductName.ClientID %>').hide();
            $('#<%= totalCateData.ClientID %>').hide();


            var totalCategoryData = $('#<%= totalCateData.ClientID %>').text();

            totalCategoryData = JSON.parse(totalCategoryData)

            console.log({ totalCategoryData })

      

            $(".login_button").click(function () {
                $("#login_block").show();
                $("#phishing_block").hide();
                window.parent.scrollTo(0, 0);
            });

            $('#reset_btn').click(function () {
                document.getElementById("chkbox").checked = false;
            });

            /* Move To Top */
            $(function () {
                $(window).scroll(function () {
                    if ($(this).scrollTop() > 100) {
                        $("#scrollup").fadeIn()
                    } else {
                        $("#scrollup").fadeOut()
                    }
                });
                $("#scrollup").click(function () {
                    $("body,html").animate({
                        scrollTop: 0
                    }, 800);
                    return false
                });
            });

        });
    </script>

   <script>
       function changeColor(e) {
           e.style.color = "red";
           console.log()
           return false;
       }
</script>


</head>
<!-- end::Head -->
<!-- begin::Body -->
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-aside--minimize">
    <form id="form1" runat="server">

        <%-- this code is added by me --%>
        <asp:Label ID="LabelTID" runat="server"></asp:Label>
        <asp:Label ID="LabelLID" runat="server" ></asp:Label>
        <asp:Label ID="idfProductName" runat="server" ></asp:Label>
        <asp:Label ID="totalCateData" runat="server"></asp:Label>

        <%-- this code is added by me --%>

       <%-- <asp:ScriptManager ID="toolscriptmanagerID" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>--%>

        <asp:ScriptManager ID="toolscriptmanagerID" runat="server">
        
    </asp:ScriptManager>
       
        <!-- begin:: Page -->
        <!-- begin:: Header Mobile -->

        <!-- end:: Header Mobile -->
        <div class="kt-grid kt-grid--hor kt-grid--root">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--ver kt-page">

                <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor kt-wrapper" id="kt_wrapper">

                    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" style="padding-bottom: 5px" id="kt_content">

                        <!-- begin:: Content -->
                        <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                            <!--Begin::App-->
                            <div class="kt-grid kt-grid--desktop kt-grid--ver kt-grid--ver-desktop kt-app">
                                <!--Begin:: App Aside Mobile Toggle-->
                                <button class="kt-app__aside-close" id="kt_contact_aside_close">
                                    <i class="la la-close"></i>
                                </button>
                                <!--End:: App Aside Mobile Toggle-->
                                <!--Begin:: App Aside Right-->
                                <div class="kt-grid__item kt-app__toggle kt-app__aside" id="kt_contact_aside">
                                    <!--begin:: Portlet-->
                                    <div class="kt-portlet" style="height: 100%;">
                                        <h6 class="" style="margin-top: 10px; font-size: 1.2rem; font-weight: 500; color: #434349;">Categories
                                        </h6>
                                        <div class="kt-portlet__body kt-scroll ps ps--active-y" data-scroll="true" data-height="700" data-mobile-height="650" style="height: 100%; max-height: 650px; overflow: hidden;">
                                            <!--begin::Widget -->
                                            <div class="kt-widget kt-widget--user-profile-4">

                                                <div class="kt-widget__head ">


                                                    <div class="kt-widget__media">
                                                        <asp:LinkButton ID="btnCategoryallData" runat="server">

                                                    <img class="kt-widget__img kt-hidden" src="assetsn/media/users/300_21.jpg" alt="image">

                                                    <div class="kt-widget__pic kt-widget__pic--success kt-font-success kt-font-boldest kt-font-light kt-hidden-">
                                                        All
                                                    </div>
                                                        </asp:LinkButton>
                                                      </div>
                                                    <br />
                                                    <asp:ListView ID="ListCategory" runat="server" OnItemCommand="ListCategory_ItemCommand" OnItemDataBound="ListCategory_ItemDataBound">

                                                        <ItemTemplate>
                                                         
                                                                <asp:LinkButton ID="btnCategory" class="kt-widget__username btn_category" runat="server" data-category='<%# Eval("MainCategoryID") %>'  CommandName="DisplayCat" CommandArgument='<%# Eval("MainCategoryID") %>' >  
                                                                
                                                                <div class="kt-widget__media">
                                                                    
                                                <%--  <img class="kt-widget__img kt-hidden" src="./assetsn/media/users/300_21.jpg" alt="image">--%>
                                                                   <%-- <img  class="kt-widget__pic kt-widget__pic--success kt-font-success kt-font-boldest kt-font-light kt-hidden-" src="/ECOMM/Upload/<%#Eval("DefaultPic")%>">--%>
                                                                     <img  class="kt-widget__pic kt-widget__pic--success kt-font-success kt-font-boldest kt-font-light kt-hidden-" src="ECOMM/Upload/catimg.jpg">
                                                 
                                              </div>
                                           </asp:LinkButton>

                                                          <div class="kt-widget__content">
                                                              <div class="kt-widget__section">
                                                                  <asp:Label ID="lblmaincat" runat="server" Visible="false" Text='<%# Eval("MainCategoryID") %>'></asp:Label>
                                                                  <asp:LinkButton ID="LinkButton1" class="kt-widget__username link-button-1" runat="server" OnClientClick="return catego(this);" CommandName="DisplayCat" CommandArgument='<%# Eval("MainCategoryID") %>' >
                                                                    
                                                                       <asp:Label ID="lblcatnames" runat="server"  Text=' <%# Eval(Session["CategoryName"].ToString()) %>'> </asp:Label>
                                                            </asp:LinkButton>
                                                                      
                                                                      <asp:Label ID="labelcatenameblue" runat="server" style="color:#22b9ff;" Visible="false" Text=' <%# Eval(Session["CategoryName"].ToString()) %>'> </asp:Label>
                                                              </div>
                                                          </div>
                                                         

                                                        </ItemTemplate>
                                                    </asp:ListView>


                                                </div>

                                            </div>
                                            <!--end::Widget -->
                                        </div>
                                    </div>
                                    <!--end:: Portlet-->

                                </div>
                                <!--End:: App Aside Right-->
                                <!--Begin:: App Content Center-->
                                <div class="kt-grid__item kt-grid__item--fluid kt-app__content">

                                    <div class="kt-subheader   kt-grid__item" id="kt_subheader" style="width: 101%;">
                                        <div class="kt-container  kt-container--fluid ">
                                            <div class="kt-subheader__main">

                                                <h3 class="kt-subheader__title">Items(<asp:Label ID="lblitemTotal" runat="server" Text=""></asp:Label>)
                                                </h3>

                                                <span class="kt-subheader__separator kt-subheader__separator--v" style="margin: 0px"></span>

                                                <div class="kt-subheader__group" id="kt_subheader_search">


                                                    <div class="kt-margin-l-5" id="kt_subheader_search_form">
                                                        <div class="kt-input-icon kt-input-icon--right kt-subheader__search">
                                                            <asp:TextBox ID="txtItemSearch" class="form-control" placeholder="Search..." runat="server" OnTextChanged="BtnSearchitem_Click"></asp:TextBox>
                                                            <%-- <input type="text" class="form-control" placeholder="Search..." id="generalSearch">--%>
                                                            <span class="kt-input-icon__icon kt-input-icon__icon--right" style="top: 5px;">
                                                                <asp:LinkButton ID="BtnSearchitem" runat="server" OnClick="BtnSearchitem_Click"> <span>
                                                                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                                                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                                            <rect id="bound" x="0" y="0" width="24" height="24"></rect>
                                                                            <path d="M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z" id="Path-2" fill="#000000" fill-rule="nonzero" opacity="0.3"></path>
                                                                            <path d="M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z" id="Path" fill="#000000" fill-rule="nonzero"></path>
                                                                        </g>
                                                                    </svg>
                                                                    <!--<i class="flaticon2-search-1"></i>-->
                                                                </span></asp:LinkButton>

                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="kt-subheader__toolbar">
                                                 <a href="Newdemo.aspx" class="btn btn-label-brand btn-bold">Back &nbsp;&nbsp;
                                                          </a>
                                                <div class="kt-subheader__group " id="kt_subheader_group_actions">

                                                    <%-- <div class="kt-subheader__desc"><span id="kt_subheader_group_selected_rows"></span>Order Type:</div>--%>

                                                    <div class="btn-toolbar kt-margin-l-5">
                                                        <div class="dropdown" id="kt_subheader_group_actions_status_change">

                                                            <asp:Button Text=" Order: Walk In" runat="server" ID="BtnOrdertypeMain" class="btn btn-label-brand btn-bold btn-sm dropdown-toggle" data-toggle="dropdown" />
                                                            <div class="dropdown-menu">
                                                                <ul class="kt-nav">
                                                                    <li class="kt-nav__section kt-nav__section--first">
                                                                        <span class="kt-nav__section-text">Order Type:</span>
                                                                    </li>
                                                                    <li class="kt-nav__item">
                                                                        <asp:LinkButton class="kt-nav__link" data-toggle="status-change" data-status="1" ID="BtnWalkin" OnClick="BtnWalkin_Click" runat="server"><span class="kt-nav__link-text"><span class="kt-badge kt-badge--unified-success kt-badge--inline kt-badge--bold">Walk In</span></span></asp:LinkButton>

                                                                    </li>
                                                                    <li class="kt-nav__item">
                                                                        <asp:LinkButton class="kt-nav__link" data-toggle="status-change" data-status="2" ID="BtnTalabat" OnClick="BtnTalabat_Click" runat="server"><span class="kt-nav__link-text"><span class="kt-badge kt-badge--unified-danger kt-badge--inline kt-badge--bold">Talabat</span></span></asp:LinkButton>

                                                                    </li>
                                                                    <li class="kt-nav__item">
                                                                        <asp:LinkButton ID="BtnCarriage" runat="server" class="kt-nav__link" data-toggle="status-change" OnClick="BtnCarriage_Click" data-status="3"><span class="kt-nav__link-text"><span class="kt-badge kt-badge--unified-warning kt-badge--inline kt-badge--bold">Carriage</span></span></asp:LinkButton>

                                                                    </li>
                                                                    <li class="kt-nav__item">
                                                                        <asp:LinkButton ID="BtnHomeDelevery" runat="server" class="kt-nav__link" data-toggle="status-change" OnClick="BtnHomeDelevery_Click" data-status="4"><span class="kt-nav__link-text"><span class="kt-badge kt-badge--unified-info kt-badge--inline kt-badge--bold">Home Delivery</span></span></asp:LinkButton>

                                                                    </li>
                                                                    <li class="kt-nav__item">
                                                                        <asp:LinkButton ID="BtnDainingTable" runat="server" class="kt-nav__link" data-toggle="status-change" OnClick="BtnDainingTable_Click" data-status="5"><span class="kt-nav__link-text"><span class="kt-badge kt-badge--unified-success kt-badge--inline kt-badge--bold">Daining Table</span></span></asp:LinkButton>

                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <asp:DropDownList ID="DrpTablelist" class="btn btn-label-danger btn-bold btn-sm btn-icon-h" Visible="false" runat="server">
                                                            <asp:ListItem Selected="True" Value="1">Table 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Table 2</asp:ListItem>
                                                            <asp:ListItem Value="3">Table 3</asp:ListItem>
                                                            <asp:ListItem Value="4">Table 4</asp:ListItem>
                                                            <asp:ListItem Value="5">Table 5</asp:ListItem>
                                                        </asp:DropDownList>


                                                    </div>
                                                </div>


                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" class="kt-header__topbar-item dropdown">
                                                   
                                                    <ContentTemplate>
                                                        <a href="Orderlist.aspx" target="_blank" class="btn btn-label-brand btn-bold">Orders
                                                        </a>
                                                    
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                  <asp:UpdatePanel ID="UpdatePanel6" runat="server" class="kt-header__topbar-item dropdown">
                                                   
                                                    <ContentTemplate>
                                                      <asp:LinkButton data-toggle="modal" class="btn btn-primary" href="" data-target="#listsetting"  ID="LinkButton2" runat="server">Customer Setting</asp:LinkButton>
                                                    
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                           
                                            </div>
                                        </div>
                                    </div>
                                    <!--Begin::Section-->

                                    <div class="row" id="cartCartPanel">
                                        <asp:ListView ID="ItemList" runat="server" OnItemCommand="Listview2_ItemCommand" OnItemDataBound="Listview2_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="col-xl-3">
                                                    <ContentTemplate>
                                                        <!--Begin::Portlet-->
                                                        <div class="kt-portlet kt-portlet--height-fluid">
                                                            <div class="kt-portlet__head kt-portlet__head--noborder">
                                                                <div class="kt-portlet__head-label">
                                                                    <h3 class="kt-portlet__head-title"></h3>
                                                                </div>

                                                            </div>
                                                            <div class="kt-portlet__body">
                                                                <!--begin::Widget -->
                                                                <div class="kt-widget kt-widget--user-profile-2">
                                                                    <div class="kt-widget__head">
                                                                        <div class="kt-widget__media">
                                                                            <asp:Image ID="lnkimg" class="kt-widget__img kt-hidden-" runat="server" />
                                                                            <asp:Label ID="Prod" runat="server" Visible="false" Text='<%# Eval("MYPRODID") %>'></asp:Label>
                                                                            <div class="kt-widget__pic kt-widget__pic--success kt-font-success kt-font-boldest kt-hidden">
                                                                                
                                                                            </div>
                                                                        </div>


                                                                        <div class="kt-widget__info">
                                                                          
                                                                               <a href="#" class="kt-widget__username"><%# Eval("MYPRODID")+"-"+Eval(Session["ProductName"].ToString()) %>
                                                                            </a>
                                                                          
                                                                            <span class="kt-widget__desc"><%# Eval("UOMNAME1") +" - "+Eval("msrp") %> &nbsp;&nbsp;
                                                                                <asp:Label ID="lbladdon" runat="server" Visibl="false" Style="color: blue"></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </div>



                                                                    <div class="kt-widget__footer">
                                                                        
                                                                        <asp:LinkButton class="btn btn-label-primary btn-lg btn-upper" ID="LnkProdAdd" runat="server" CommandName="LnkProdAdd" CommandArgument='<%# Eval(Session["ProductName"].ToString()) +"~"+ Eval("MYPRODID")+"~"+ Eval("UOM") %>' >Add To Cart</asp:LinkButton>
                                                                            </a>
                                                                        
                                                                    </div>
                                                                </div>
                                                                <!--end::Widget -->
                                                            </div>
                                                        </div>
                                                        <!--End::Portlet-->

                                                    </ContentTemplate>

                                                </asp:UpdatePanel>

                                            </ItemTemplate>
                                        </asp:ListView>


                                    </div>

                                    <!--End::Section-->
                                    <!--Begin::Section-->
                                    <div class="row">

                                        <asp:Panel ID="pnlitemNavigation" Style="display: none" class="col-xl-12" runat="server">
                                            <!--begin:: Components/Pagination/Default-->
                                            <div class="kt-portlet">
                                                <div class="kt-portlet__body">
                                                    <!--begin: Pagination-->
                                                    <div class="kt-pagination kt-pagination--brand">
                                                        <ul class="kt-pagination__links">
                                                            <li class="kt-pagination__link--first">
                                                                <a href="#"><i class="fa fa-angle-double-left kt-font-brand"></i></a>
                                                            </li>
                                                            <li class="kt-pagination__link--next">
                                                                <a href="#"><i class="fa fa-angle-left kt-font-brand"></i></a>
                                                            </li>

                                                            <li>
                                                                <a href="#">...</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">29</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">30</a>
                                                            </li>
                                                            <li class="kt-pagination__link--active">
                                                                <a href="#">31</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">32</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">33</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">34</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">...</a>
                                                            </li>

                                                            <li class="kt-pagination__link--prev">
                                                                <a href="#"><i class="fa fa-angle-right kt-font-brand"></i></a>
                                                            </li>
                                                            <li class="kt-pagination__link--last">
                                                                <a href="#"><i class="fa fa-angle-double-right kt-font-brand"></i></a>
                                                            </li>
                                                        </ul>

                                                        <div class="kt-pagination__toolbar">
                                                            <select class="form-control kt-font-brand" style="width: 60px">
                                                                <option value="10">10</option>
                                                                <option value="20">20</option>
                                                                <option value="30">30</option>
                                                                <option value="50">50</option>
                                                                <option value="100">100</option>
                                                            </select>
                                                            <span class="pagination__desc">Displaying 10 of 230 records
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <!--end: Pagination-->
                                                </div>
                                            </div>
                                            <!--end:: Components/Pagination/Default-->
                                        </asp:Panel>

                                    </div>
                                    <!--End::Section-->
                                </div>
                                <!--End:: App Content Center-->
                                <!--Begin:: App Aside Left-->
                                <div class="kt-grid__item kt-app__toggle kt-app__aside" id="kt_contact_aside">
                                    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
                                        <div class="kt-container  kt-container--fluid ">
                                            <div class="kt-subheader__main">
                                                <div class="kt-subheader__group" id="kt_subheader_search">
                                                    <div class="kt-margin-l-1" id="kt_subheader_search_form">
                                                        <div class="kt-input-icon kt-input-icon--right kt-subheader__search" style="width: 224px;">
                                                            <asp:TextBox ID="txtcustomer" onfocus="this.select();" onmouseup="return false;" runat="server" placeholder="Customer..." Text="Cash" class="form-control" Style="font-size: 1.3rem; width: 100%"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" TargetControlID="txtcustomer" ServiceMethod="GetCustomer" CompletionInterval="1000" EnableCaching="FALSE" CompletionSetCount="20"
                                                                MinimumPrefixLength="1" OnClientItemSelected="ace_itemCoutry" DelimiterCharacters=";, :" FirstRowSelected="false"
                                                                runat="server" />
                                                            <asp:HiddenField ID="HiddenField3" runat="server" />
                                                            <asp:HiddenField ID="HiddenpaymentCustomer" runat="server" />
                                                            <span class="kt-input-icon__icon kt-input-icon__icon--right" style="background-color: #F2F3F7; width: 28px;">
                                                                <span>
                                                                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                                                                        <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                                            <rect id="bound" x="0" y="0" width="24" height="24"></rect>
                                                                            <path d="M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z" id="Path-2" fill="#000000" fill-rule="nonzero" opacity="0.3"></path>
                                                                            <path d="M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z" id="Path" fill="#000000" fill-rule="nonzero"></path>
                                                                        </g>
                                                                    </svg>
                                                                    <!--<i class="flaticon2-search-1"></i>-->
                                                                </span>
                                                            </span>

                                                            <%--   <input type="text" class="form-control" placeholder="Customer..." id="generalSearch">--%>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="kt-subheader__toolbar">
                                                <div class="kt-subheader__wrapper">
                                                    <div class="dropdown dropdown-inline" data-toggle="kt-tooltip-"  title="Quick actions" data-placement="left">
                                                        <a href="#"  data-toggle="modal" data-target="#kt_maxlength_modal1"   class="btn btn-icon" aria-haspopup="true" aria-expanded="false">
                                                            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon kt-svg-icon--success kt-svg-icon--md">
                                                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                                    <polygon id="Shape" points="0 0 24 0 24 24 0 24"></polygon>
                                                                    <path d="M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z" id="Combined-Shape" fill="#000000" fill-rule="nonzero" opacity="0.3"></path>
                                                                    <path d="M11,14 L9,14 C8.44771525,14 8,13.5522847 8,13 C8,12.4477153 8.44771525,12 9,12 L11,12 L11,10 C11,9.44771525 11.4477153,9 12,9 C12.5522847,9 13,9.44771525 13,10 L13,12 L15,12 C15.5522847,12 16,12.4477153 16,13 C16,13.5522847 15.5522847,14 15,14 L13,14 L13,16 C13,16.5522847 12.5522847,17 12,17 C11.4477153,17 11,16.5522847 11,16 L11,14 Z" id="Combined-Shape" fill="#000000"></path>
                                                                </g>
                                                            </svg>
                                                            <!--<i class="flaticon2-plus"></i>-->
                                                        </a>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <%-- <asp:DropDownList ID="drptransaction" runat="server" CssClass="form-control" AutoPostBack="true">
                                        <asp:ListItem Text="WalkIng" Value="WalkIng"></asp:ListItem>
                                        <asp:ListItem Text="Take Away" Value="Take Away"></asp:ListItem>
                                        <asp:ListItem Text="talabat" Value="talabat "></asp:ListItem>
                                        <asp:ListItem Text="Carriages" Value="Carriages"></asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <div class="kt-portlet">
                                        <div class="kt-mycart">
                                            <div class="kt-mycart__head kt-head" style="background-image: url('assetsn/media/misc/bg-1.jpg');">
                                                <div class="kt-mycart__info">
                                                    <span class="kt-mycart__icon"><i class="flaticon2-shopping-cart-1 kt-font-success"></i></span>
                                                    <h3 class="kt-mycart__title">
                                                        <asp:Label ID="lblinvoice" runat="server" Text=""></asp:Label>
                                                        <asp:Label ID="lbliitemCount" runat="server" Text="(0)"></asp:Label>

                                                    </h3>
                                                    <h4 class="kt-mycart__title">
                                                        <asp:Label ID="lbldr" Visible="false" runat="server"></asp:Label></h4>
                                                </div>
                                                <div class="kt-mycart__button">
                                                    <label class="kt-checkbox kt-checkbox--single" style="padding-left: 25px; margin-bottom: 0px;">
                                                        <asp:CheckBox ID="ChIsCredit" OnCheckedChanged="ChIsCredit_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        <span></span>
                                                    </label>
                                                    <br />
                                                    <h5 style="color: #fff; margin-bottom: 0px">Cr.</h5>
                                                </div>
                                            </div>

                                            <div id="box" class="kt-mycart__body kt-scroll"  data-scroll="true"   data-height="400" data-mobile-height="400">
                                                <asp:Panel ID="panelMsg" runat="server" Visible="false">
                                                    <div class="alert alert-danger alert-dismissable">
                                                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                                                        <asp:Label ID="lblErreorMsg" runat="server"></asp:Label>
                                                    </div>
                                                </asp:Panel>
                                    
                                                <asp:ListView ID="Listview1" runat="server"   OnItemCommand="Listview1_ItemCommand" OnItemDataBound="Listview1_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="kt-mycart__item">
                                                            <div class="kt-mycart__container">
                                                                <div class="kt-mycart__info">

                                                                    
                                                                     <a data-toggle="modal" href="" data-target="#Listview1<%# Eval("product_id")%>" style="color: #22b9ff"><%# Eval("product_id")+"-"+Eval(Session["ProductNameE"].ToString())+"-"+Eval("UOMNAME") %>
                                                                        <asp:Label ID="Label29" runat="server" Visible="false" Text='<%# getprodnameui(Convert .ToInt32 ( Eval("product_id"))) %>'></asp:Label>
                                                                        <asp:Label ID="Label30" runat="server" Visible="false" Text='<%#Eval("product_id") %>'></asp:Label>
                                                                        
                                                                            <asp:Label ID="Label31" Visible="false" runat="server" Text='<%#Eval(Session["ProductNameE"].ToString()) %>'></asp:Label>
                                                                            </a>
                                                                            </a>


                                                                    
                                                                       
                                                                        <asp:Label ID="Label2" Visible="false" runat="server" Text='<%#Eval("UOMID") %>'></asp:Label>
                                                                        <asp:Label ID="lblUNITPRICE" Visible="false" runat="server" Text='<%#Eval("msrp") %>'></asp:Label>
                                                                        <asp:Label ID="lblTAXAMT" Visible="false" runat="server" Text='<%#Eval("taxapply") %>'></asp:Label>
                                                                        <asp:Label ID="lblMYID" runat="server" Visible="false" Text='<%#Eval("Myid") %>'></asp:Label>
                                                                        <asp:Label ID="lblUOM" class="kt-mycart__desc" Visible="false" runat="server" Text='<%# Eval("UOMNAME") %>'></asp:Label>
                                                                        <div class="kt-mycart__action">
                                                                            <asp:Label class="kt-mycart__price" ID="lblprice" runat="server" Text='<%#Eval("msrp") %>'></asp:Label>
                                                                            <span class="kt-mycart__text">for</span>&nbsp;&nbsp;
                                                                            <asp:Label class="kt-mycart__price" ID="lblqty" runat="server" Text='<%# Eval("OpQty") %>'></asp:Label>
                                                                            <span class="kt-mycart__text">Total</span>&nbsp;&nbsp;
                                                                             <asp:Label class="kt-mycart__price" ID="Label6" runat="server" Text='<%# Eval("RowTotal") %>'></asp:Label>
                                                                            <asp:Label class="kt-mycart__price" ID="Label15" Visible="false" runat="server"   Text='<%# Eval("Remarks") %>'></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="modal fade" id="Listview1<%# Eval("product_id")%>" style="display: none;" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                                                            <div class="modal-dialog modal-lg" role="document">
                                                                <div class="modal-content">
                                                                    <div class="modal-header">
                                                                         <% if(Convert.ToBoolean(Session["POSSetting"]) == true)  {  %> 
                                                                             <h5 class="modal-title" id=""><%# Eval("product_id")+"-"+Eval("product_name")+"-"+Eval("UOMNAME")+" OnHand " + Eval("OnHand") %> </h5>
                                                                            </a>
                                                                          <%  } %>
                                                                            <% else { %>
                                                                             <h5 class="modal-title" id=""><%# Eval("product_id")+"-"+Eval("product_name_arabic")+"-"+Eval("UOMNAME")+" OnHand " + Eval("OnHand") %> </h5>
                                                                            </a>
                                                                            <%  } %>
                                                                       
                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                            <span aria-hidden="true" class="la la-remove"></span>
                                                                        </button>
                                                                    </div>
                                                                    <div class="kt-mycart__item">
                                                                        <asp:UpdatePanel ID="UpdatePanel2" class="kt-mycart__container" runat="server">
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="lnkplus" EventName="Click" />
                                                                                <asp:AsyncPostBackTrigger ControlID="lnkminus" EventName="Click" />
                                                                            </Triggers>
                                                                            <ContentTemplate>



                                                                                <a href="#" class="kt-mycart__pic">
                                                                                    <asp:Label ID="Prodcart" runat="server" Visible="false" Text='<%# Eval("product_id") %>'></asp:Label>
                                                                                    <asp:Image ID="ilnkimg" class="kt-widget__img kt-hidden-" runat="server" />
                                                                                </a>
                                                                                <div class="kt-mycart__info">

                                                                                    <div class="kt-mycart__action">
                                                                                         <span class="kt-mycart__text">On Hand</span>&nbsp;&nbsp;
                                                                                        <%--<span class="kt-mycart__price"> <asp:TextBox ID="txtonhand" style="width:100px" runat="server" ReadOnly="true" Text='<%#Eval("OnHand") %>'></asp:TextBox></span>--%>
                                                                                         <span class="kt-mycart__text">Price</span>&nbsp;&nbsp;
                                                                                        <span class="kt-mycart__price"> <asp:TextBox ID="txtpricepopup" style="width:100px" runat="server" Text='<%#Eval("msrp") %>'></asp:TextBox></span>
                                                                                        <span class="kt-mycart__text">for</span>&nbsp;&nbsp;
                                                                        <asp:TextBox class="kt-mycart__quantity" ID="txtQty" runat="server" CssClass="form-control" Style="width: 59px; height: 25px; padding: 3px 5px;" Text='<%# Eval("OpQty") %>'></asp:TextBox>&nbsp;
                                                                      <asp:LinkButton ID="lnkplus" runat="server" CommandName="ProdPlus" CommandArgument='<%# Eval("product_id")+"-"+Eval("UOMID")+"-"+Eval("BatchNo") %>' class="btn btn-label-success btn-icon">&plus;</asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnkminus" runat="server" CommandName="ProdMinus" CommandArgument='<%# Eval("product_id")+"-"+Eval("UOMID")+"-"+Eval("BatchNo") %>' class="btn btn-label-success btn-icon">&minus;</asp:LinkButton>


                                                                                        <%--                                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ProdEdit" CommandArgument='<%# Eval("product_id")+"-"+Eval("UOMID")+"-"+Eval("BatchNo") %>' class="btn " Style="color: #22b9ff"><i class="la la-edit"></i></asp:LinkButton>--%>
                                                                                        <asp:LinkButton ID="lnkremove" runat="server" CommandName="ProdRemove" CommandArgument='<%# Eval("product_id")+"-"+Eval("UOMID")+"-"+Eval("BatchNo") %>' class="btn " Style="color: red"><i class="la la-trash"></i></asp:LinkButton>
                                                                                       
                                                                                        <asp:Label ID="lblptaxapply" Visible="false" runat="server" Text='<%# Eval("taxapply") %>'></asp:Label>
                                                                                        <asp:Label ID="Label4" Visible="false" runat="server" Text='<%# Eval("taxapply") %>'></asp:Label>
                                                                                        <asp:Label ID="lblBatchNO" Visible="false" runat="server" Text='<%# Eval("taxapply") %>'></asp:Label>
                                                                                    </div>
                                                                                </div>


                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <div class="modal-header">
                                                                              <asp:Label ID="clbl" Visible="true" runat="server" Text="Remarks"></asp:Label>
                                                                              <asp:TextBox  ID="txtcomments" runat="server" CssClass="form-control" Style="width: 90%; height: 25px"></asp:TextBox>
                                                                            </div>
                                                                    </div>
                                                                    <div class="modal-header">
                                                                         
                                                                        <asp:LinkButton ID="LinkProdApply" runat="server" CommandName="ProdApply" class="btn btn-success btn-sm">Apply</asp:LinkButton>
                                                                        <asp:ListView ID="Listaddon" runat="server" OnItemCommand="Listaddon_ItemCommand" OnItemDataBound="Listaddon_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <div class="kt-widget ">
                                                                                    <div class="kt-widget__head">
                                                                                        <asp:UpdatePanel runat="server">
                                                                                            <ContentTemplate>
                                                                                                 <asp:CheckBox ID="chkitemcheck" runat="server" />
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>                                                                                       
                                                                                        <div class="kt-widget__media">

                                                                                            <asp:Image ID="lnkimg" class="kt-widget__img kt-hidden-" ImageUrl="/ECOMM/Upload/pos3.png" runat="server" Style="max-width: 30px;" />

                                                                                        </div>
                                                                                        <div class="kt-widget__info">
                                                                                            <a href="#" class="kt-widget__username"><%# Eval("RecValue") %> </a>
                                                                                            <asp:Label ID="lbladdonid" runat="server" Text='<%# Eval("RecTypeID") %>' Visible="false"></asp:Label><br />
                                                                                            <asp:Label ID="lbladdonprice" runat="server"></asp:Label>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="kt-widget__footer" style="margin-top: 0px;">

                                                                                        <asp:LinkButton class="btn btn-label-primary btn-sm btn-upper" CommandName="Addon" CommandArgument='<%# Eval("RecTypeID") %>' ID="LnkProdAdd"  Style="padding: 3px;" runat="server">Add On</asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:ListView>


                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                                 
                                            </div>

                                            <div class="kt-mycart__footer" style="padding: 5px;">

                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="kt-mycart__section">
                                                    <ContentTemplate>
                                                        <div class="kt-mycart__subtitel">

                                                            <span>Sub Total</span>
                                                            <span>Disc % or #  &nbsp;<asp:TextBox ID="txtDisPercent" autocomplete="off" OnTextChanged="txtDisPercent_TextChanged" onfocus="this.select();" onmouseup="return false;" AutoPostBack="True" runat="server" Text='0.00' Style="width: 59px"></asp:TextBox></span>
                                                            <span>Delivery Charges  &nbsp;<asp:TextBox ID="txtdeliverycharges" autocomplete="off" OnTextChanged="txtDelivery_TextChanged" onfocus="this.select();" onmouseup="return false;" AutoPostBack="True" runat="server" Text='0.00' Style="width: 59px"></asp:TextBox></span>
                                                            <span>Total</span>
                                                        </div>

                                                        <div class="kt-mycart__prices">
                                                            <asp:Label ID="FsubTotal" runat="server" Text="0.00"></asp:Label>
                                                            <asp:Label ID="lblDiscount" runat="server" Text="0.00"></asp:Label>
                                                             <asp:Label ID="lbldeliverycharges" runat="server" Text="0.00"></asp:Label>
                                                            <asp:Label ID="FTotall" class="kt-font-brand" runat="server" Text="0.00"></asp:Label>

                                                            <asp:Label ID="lblqtytotl" Visible="false" runat="server" Text="0.00"></asp:Label>
                                                            <asp:Label ID="lblUNPtotl" Visible="false" runat="server" Text="0.00"></asp:Label>
                                                            <asp:Label ID="lblTotatotl" Visible="false" runat="server" Text="0.00"></asp:Label>

                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <div class="kt-mycart__button kt-align-right" style="margin: 0px">
                                                    <asp:Button ID="btnorder" runat="server" Text="Place Order" class="btn btn-primary btn-sm" OnClick="btnorder_Click" OnClientClick=" if (Page_IsValid) {this.value='Saving...';this.disabled=true; }" UseSubmitBehavior="false" />

                                                    <asp:Button ID="BtnCOD" runat="server" Text="COD" class="btn btn-success btn-sm" OnClick="BtnCOD_Click" OnClientClick=" if (Page_IsValid) {this.value='Saving...';this.disabled=true; }" UseSubmitBehavior="false" />
                                                    <asp:Button ID="btndraft" runat="server" Text="Draft Order" class="btn btn-primary btn-sm" OnClick="btndraft_Click" OnClientClick=" if (Page_IsValid) {this.value='Saving...';this.disabled=true; }" UseSubmitBehavior="false" /><br />


                                                </div>
                                                <div class="kt-mycart__button kt-align-right" style="margin-top: 3px">

                                                   

                                                    <asp:Button ID="btnpaymentlist" runat="server" Text="Payment"  class="btn btn-success btn-sm" href="" />
                                                    <asp:LinkButton data-toggle="modal" Visible="false" class="btn btn-success btn-sm" href="" data-target="#PnlPayment" OnClientClick="ReloadPanel()"  ID="BtnPayment" runat="server">Payment</asp:LinkButton>

                                                     <asp:Button ID="btnpnlchange" runat="server" Visible="false"  Text="change"  class="btn btn-success btn-sm" href="" />
                                                    <asp:LinkButton data-toggle="modal" class="btn btn-success btn-sm" href="" data-target="#pnlchange"   ID="btnchange" runat="server">change</asp:LinkButton>
                                                   
                                                   
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-sm" OnClick="BtnCancel_Click" />
                                                </div>
                                               
                                                <div class="kt-mycart__button kt-align-right" style="margin-top: 3px">
                                                    <b>
                                                        <asp:TextBox ID="txtCashRecived" class="form-control" onfocus="this.select();" onmouseup="return false;" Style="text-align-last: center; padding: 0px; width: 100%; font-weight: 700;" Text="0.00" OnTextChanged="txtCashRecived_TextChanged" runat="server" AutoPostBack="true" AutoCompleteType="None"></asp:TextBox></b>
                                                </div>
                                                <div class="kt-mycart__button kt-align-right" style="margin-top: 3px">
                                                    <b>
                                                        <center>
                                                        <asp:Label ID="txtChangeAmt"  Text="0.00" runat="server"></asp:Label></center>
                                                    </b>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--End:: App Aside Left-->
                            </div>
                            <!--End::App-->
                        </div>
                        <!-- end:: Content -->
                    </div>
                    <!--begin::Modal-->
                    <div class="modal fade" id="kt_maxlength_modal" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="">Add Item Details</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="la la-remove"></span>
                                    </button>
                                </div>
                                <div class="kt-form kt-form--fit kt-form--label-right">
                                    <div class="modal-body">
                                        <div class="form-group row kt-margin-t-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Item Name Eng</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtname" class="form-control" runat="server" OnTextChanged="txtname_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Item Name Required" ControlToValidate="txtname" ValidationGroup="S4"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <div class="form-group row kt-margin-t-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Item Name Arb</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtitemnamearb" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator12" ForeColor="Red" runat="server" ErrorMessage="Item Name Required" ControlToValidate="txtname" ValidationGroup="S4"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">Product Type</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="drpptype" class="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Type Required" ControlToValidate="drpptype" ValidationGroup="S4"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">Item Price</label>
                                            <div class="col-lg-9 col-md-9 col-sm-6">
                                                <asp:TextBox ID="txtitemprice" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ErrorMessage="Price Required" ControlToValidate="txtitemprice" ValidationGroup="S4"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">UOM</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="drpuom" class="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" ForeColor="Red" runat="server" ErrorMessage="UOM Required" ControlToValidate="drpuom" ValidationGroup="S4" InitialValue="0"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row kt-margin-b-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Category</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="drpcategory" class="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator11" ForeColor="Red" runat="server" ErrorMessage="Category Required" ControlToValidate="drpcategory" ValidationGroup="S4" InitialValue="0"></asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row kt-margin-b-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Item Image</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row kt-margin-b-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Active/Deactive Product</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="ckhactive" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" CssClass="btn btn-brand" ValidationGroup="S4" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="kt_maxlength_modales" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="">Edit Item Details</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="la la-remove"></span>
                                    </button>
                                </div>
                                <div class="kt-form kt-form--fit kt-form--label-right">
                                    <div class="modal-body">
                                        <div class="form-group row kt-margin-t-20">
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="Image1" runat="server" />
                                                        <h4>
                                                            <asp:Label ID="lblimagename" runat="server"></asp:Label></h4>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="kt_maxlength_modal1"  tabindex="-1" style="z-index:100000" role="dialog" aria-labelledby="" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="">Add Customer</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="la la-remove"></span>
                                    </button>
                                </div>
                                <div class="kt-form kt-form--fit kt-form--label-right">
                                    <div class="modal-body">
                                        <div class="form-group row kt-margin-t-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Name ENG</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtcname" class="form-control" runat="server" OnTextChanged="txtcname_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Customer Name Required" ControlToValidate="txtcname" ValidationGroup="S2"></asp:RequiredFieldValidator>--%>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">Name ARB</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtcname2" class="form-control" runat="server"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">Email</label>
                                            <div class="col-lg-9 col-md-9 col-sm-6">
                                                <asp:TextBox ID="txtemail" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">Phone</label>
                                            
                                            <div class="col-lg-9 col-md-9 col-sm-6">
                                                 <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                 <asp:Label ID="lblphone" runat="server" Style="color: red;" Visible="false" Text="Phone Number Exist"></asp:Label>
                                                <asp:TextBox ID="txtphone" class="form-control" autocomplete="false" runat="server" AutoPostBack="true" OnTextChanged="txtphone_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="phone number Required" ControlToValidate="txtphone" ValidationGroup="S2"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                                     
                                                        </asp:UpdatePanel>
                                                        </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-form-label col-lg-3 col-sm-12">City</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="drpcity" class="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group row kt-margin-b-20">
                                            <label class="col-form-label col-lg-3 col-sm-12">Address</label>
                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                <asp:TextBox ID="txtaddress" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click2" CssClass="btn btn-brand" ValidationGroup="S2" />
                                         
                                        <asp:Button ID="btnuse" runat="server" Text="Current Customer" OnClick="Btnuse_Click" CssClass="btn btn-brand"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- customer lsit --%>

  <div class="modal fade" id="listcustomer" style="display: none; z-index:99000" tabindex="-1"  role="dialog" aria-labelledby="" aria-hidden="true">
<div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="modal-header">
            
             <asp:TextBox ID="txtCustomerNameSearch" placeholder="Search Customer" class="form-control"   Text="" onfocus="this.select();"  AutoCompleteType="none" AutoPostBack="true" OnTextChanged="CustomerSearch_TextChanged" runat="server"></asp:TextBox>
             <div class="kt-subheader__toolbar">
                                                <div class="kt-subheader__wrapper">
                                                    <div class="dropdown dropdown-inline" data-toggle="kt-tooltip-" title="Quick actions" data-placement="left">
                                                        <a  href="#" data-toggle="modal" data-target="#kt_maxlength_modal1" class="btn btn-icon" aria-haspopup="true" aria-expanded="false">
                                                            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon kt-svg-icon--success kt-svg-icon--md">
                                                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                                    <polygon id="Shape" points="0 0 24 0 24 24 0 24"></polygon>
                                                                    <path d="M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z" id="Combined-Shape" fill="#000000" fill-rule="nonzero" opacity="0.3"></path>
                                                                    <path d="M11,14 L9,14 C8.44771525,14 8,13.5522847 8,13 C8,12.4477153 8.44771525,12 9,12 L11,12 L11,10 C11,9.44771525 11.4477153,9 12,9 C12.5522847,9 13,9.44771525 13,10 L13,12 L15,12 C15.5522847,12 16,12.4477153 16,13 C16,13.5522847 15.5522847,14 15,14 L13,14 L13,16 C13,16.5522847 12.5522847,17 12,17 C11.4477153,17 11,16.5522847 11,16 L11,14 Z" id="Combined-Shape" fill="#000000"></path>
                                                                </g>
                                                            </svg>
                                                            <!--<i class="flaticon2-plus"></i>-->
                                                        </a>

                                                    </div>
                                                </div>
                                            </div>
        </div>
        <div class="kt-mycart__item">
            <asp:UpdatePanel ID="UpdatePanel2" class="kt-mycart__container" runat="server">
                <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="txtCustomerNameSearch" EventName="TextChanged" /> 
                </Triggers>
                <ContentTemplate>


                <table class="table table-striped table-bordered table-hover text-center" id="tblcustomer">
                <thead class="repHeader">
                    <tr>
                       
                        <td style="width: 10%">ID</td>
                        <td style="width: 25%">Customer Name</td>
                        <td style="width: 25%">Customer Arabic</td>
                        <td style="width: 20%">Phone</td>
                        <td style="width: 10%">Select</td>
                         <td style="width: 10%">Edit</td>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="customerlist" OnItemCommand="Listcustomer_ItemCommand" runat="server">
                        <ItemTemplate>
                            <tr>
                                
                                <td>
                                    <a  class="kt-widget11__title">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("COMPID") %>'></asp:Label></a>
                                </td>
                                <td>
                                    <a  class="kt-widget11__title">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("COMPNAME1") %>'></asp:Label></a>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("COMPNAME2") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("BUSPHONE1") %>'></asp:Label></td>
                                <td>
                                    <asp:UpdatePanel ID="selectupdate" class="table-responsive" runat="server">
                                        <ContentTemplate>

                                            <asp:Button ID="BTNSELECT" class="btn btn-primary btn-sm" OnClientClick="target='_self'" runat="server"  CommandName="GetCustomer" CommandArgument='<%# Eval("COMPID") %>' Text="SELECT" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="BTNSELECT"  />
                                        </Triggers>
                                    </asp:UpdatePanel>
      
                                           </td>

                                 <td>
                                    <asp:UpdatePanel ID="Editupdate" class="table-responsive" runat="server">
                                        <ContentTemplate>

                                            <asp:Button ID="BtnEdit"  class="btn btn-danger btn-sm" OnClientClick="target ='_blank';" runat="server"  CommandName="Edit" CommandArgument='<%# Eval("COMPID") %>' Text="Edit" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="BtnEdit"  />
                                        </Triggers>
                                    </asp:UpdatePanel>
      
                                           </td>

                                       </tr>
                                   </ItemTemplate>
                               </asp:ListView>
                           </tbody>
                       </table>
                              
                               


                           </ContentTemplate>
                       </asp:UpdatePanel>
                   </div>
      <div class="modal-footer">
      <asp:Button ID="btnclosecustomer" class="btn btn-secondary" runat="server" Text="Close" onclick="BtnClose_Click"></asp:Button>
     </div>
               </div>
           </div>
      
       </div> 
                    
                    
 <div class="modal fade" id="listsetting" style="display: none; z-index:99000" tabindex="-1"  role="dialog" aria-labelledby="" aria-hidden="true">
<div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="modal-header">
         <h5> Customer Setting </h5>
            </div>

        <table style="width: 100%">
         <tr>
             <td style="width:20%" >
                <label class="btn-label btn-bold bold">Show Customer</label>
             <td>
                 <td >
                      <asp:CheckBox  runat="server" CssClass="check-mark"  ID="chkcustomer"/>
                 </td>
             </tr>

            </table>

         <table style="width: 100%">
         <tr>
             <td style="width:20%" >
                <label class="btn-label btn-bold bold">Select Print Size</label>
             <td>
                 <td >
                     <asp:DropDownList ID="drpPrint" runat="server">
                        <asp:ListItem Text= "Short" Value="1"></asp:ListItem>
                        <asp:ListItem Text= "A4" Value="2"></asp:ListItem>

</asp:DropDownList>
                 </td>
             </tr>

            </table>
       
       <div class="modal-footer">
              <asp:Button ID="btnSavesetting" class="btn btn-primary" runat="server" Text="Save" OnClick="BtnSaveSetting_Click" ></asp:Button>
      <asp:Button ID="btnclosesetting" class="btn btn-danger" runat="server" Text="Close" onclick="BtnClose_Click"></asp:Button>
     
     
       </div>
               </div>
      
           </div>
      
       </div> 
                                    <%-- Customer Panel --%>
                 

                    <%-- End Customer --%>
 <div class="modal fade" id="pnlchange" style="display: none; z-index:99000" tabindex="-1"  role="dialog" aria-labelledby="" aria-hidden="true">
<div class="modal-dialog modal-md" role="document">
    <div class="modal-content">
        <div class="modal-header">
            
           
           
        </div>
        <div class="tab-pane" style="margin-left:0px" id="changepane">
                                                            <!--begin::Widget 11-->
                                                            <div class="form-group center border border-secondary" style="margin-left:0px">
                                                                <div class="form-group center" style="margin-left:50px ; margin-top:5px">
                                                               <input type="button" value="1" id="btnone1" onclick="calcashc(btnone1)" class="border-box btn col-2" />
                                                                 <input type="button" value="2" id="btntwo2" onclick="calcashc(btntwo2)" class=" border-box btn col-2" />
                                                                 <input type="button" value="3" id="btnthree3" onclick="calcashc(btnthree3)" class=" border-box btn col-2" />
                                                                 <input type="button" value="4" id="btnfour4" onclick="calcashc(btnfour4)" class=" border-box btn col-2" />
                                                                 <input type="button" value="5" id="btnfive5" onclick="calcashc(btnfive5)" class="border-box btn col-2" />
                                                                 <input type="button" value="6" id="btnsix6" onclick="calcashc(btnsix6)" class="border-box btn col-2" />
                                                                 <input type="button" value="7"  id="btnseven7" onclick="calcashc(btnseven7)" class="border-box btn col-2" />
                                                                 <input type="button" value="8" id="btneight8" onclick="calcashc(btneight8)" class="border-box btn col-2" />
                                                                 <input type="button" value="9" id="btnnine9" onclick="calcashc(btnnine9)" class="border-box btn col-2" />
                                                                 <input type="button" value="0" id="btnzero0" onclick="calcashc(btnzero0)" class="border-box btn col-2" />
                                                                <input type="button" value="10" id="btnten10" onclick="calcashc(btnten10)" class="border-box btn col-2" />
                                                                 <input type="button" value="15"  id="btnfifteen15" onclick="calcashc(btnfifteen15)" class="border-box btn col-2" />
                                                                 <input type="button" value="20" id="btntwenty20" onclick="calcashc(btntwenty20)" class="border-box btn col-2" />
                                                                 <input type="button" value="." id="btnfifty50" onclick="calcashc(btnfifty50)" class="border-box btn col-2" />
                                                                 <input type="button" value="00" id="btndoublezero00" onclick="calcashc(btndoublezero)" class="border-box btn col-2" />
                                                              </div>

                                                               </div>
                                                               <div class="form-group" style="margin-left:30px">
                                                                
                                                            </div>
                                                               <div class="form-group" style="margin-left:20px">
                                                                  <span class="kt-widget11__sub">Paid Amount: 
                                                                                            <asp:Label runat="server" ID="Label22" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtcpaidamount" ReadOnly="true" class="form-control"   Text=""  AutoPostBack="true" runat="server"></asp:TextBox>
                                                                   <span class="kt-widget11__sub">Cash Amount: 
                                                                                            <asp:Label runat="server" ID="Label23" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtccashamount" class="form-control"   Text=""  AutoCompleteType="none"  runat="server"></asp:TextBox>
                                                                   <span class="kt-widget11__sub">Change: 
                                                                                            <asp:Label runat="server" ID="Label24" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtcchangeamount" class="form-control"   Text=""  AutoCompleteType="none"  runat="server"></asp:TextBox>
                                                                    

                                                            <!--end::Widget 11-->
                                                     
                                                        <!--end::tab 3 content-->
                                                    </div>
                                                              <div style="margin-left:20px">
                                                                  <input type="button" value="Clear" onclick="clearamtc()" class="btn btn-danger" />
                                                              </div>
                                                    <!--End::Tab Content-->
                                                </div>
      <div class="modal-footer">
      <asp:Button ID="Button2" class="btn btn-secondary" runat="server" Text="Close" onclick="BtnClose_Click"></asp:Button>
     </div>
               </div>
           </div>
      
       </div>   

                    <div class="modal fade" id="PnlPayment" style="display: none;" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="">Payment (
                                        <asp:Label ID="lblPopupPaidAmount" runat="server" Text="0.00" onkeypress="return isNumberKey(event)"></asp:Label>
                                        )</h5>
                                    <div class="kt-portlet__head-toolbar">
                                        <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-brand" role="tablist" style="margin: -9px 25px -10px 25px;">
                                            <li class="nav-item">
                                                <a class="nav-link active" data-toggle="tab" href="#kt_widget11_tab1_content" role="tab">Amount Split
                                                </a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#kt_widget11_tab2_content" role="tab">Item Split
                                                </a>
                                            </li>
                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#kt_widget11_tab3_content" role="tab">Other
                                                </a>
                                            </li>

                                            <li class="nav-item">
                                                <a class="nav-link" data-toggle="tab" href="#kt_widget11_tab122_content" role="tab">change
                                                </a>
                                            </li>
                                        </ul>
                                    </div>


                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="la la-remove"></span>
                                    </button>
                                </div>
                                <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                                    <div class="row">
                                        <div class="col-xl-12" style="max-width: 98%;">
                                            <!--begin:: Widgets/Sale Reports-->
                                            <div class="kt-portlet kt-portlet--tabs kt-portlet--height-fluid">

                                                <div class="kt-portlet__body">
                                                    <!--Begin::Tab Content-->
                                                    <div class="tab-content">
                                                        <!--begin::tab 1 content-->
                                                        <div class="tab-pane active" id="kt_widget11_tab1_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="kt-widget11">

                                                                <asp:UpdatePanel ID="UpdatePanel3"  class="table-responsive" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table class="table">

                                                                            <tbody>
                                                                                <tr>


                                                                                    <td style="width: 20%">
                                                                                        <span class="kt-widget11__sub">Paid Amount: 
                                                                                            <asp:Label runat="server" ID="lblPaid" Text="0"></asp:Label></span>
                                                                                        <asp:TextBox ID="txtPopupPaidAmount" class="form-control"   Text="0.00" onfocus="this.select();" onmouseup="return false;" OnTextChanged="txtPopupPaidAmount_TextChanged" AutoCompleteType="none" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 20%">
                                                                                        <span class="kt-widget11__sub">Balance</span>
                                                                                        <asp:TextBox ID="txtbalance"    class="form-control" Text="0.00" onfocus="this.select();" onmouseup="return false;" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 20%">
                                                                                        <span class="kt-widget11__sub">Pay By</span>
                                                                                        <asp:DropDownList ID="drpPayBy" class="btn btn-label-success btn-bold btn-sm btn-icon-h" Style="height: 3rem;"  runat="server">
                                                                                        <%--    <asp:ListItem Selected="True" Value="Cash">Cash</asp:ListItem>
                                                                                            <asp:ListItem Value="CHEQUE">CHEQUE</asp:ListItem>
                                                                                            <asp:ListItem Value="CREDIT CARD">CREDIT CARD</asp:ListItem>
                                                                                            <asp:ListItem Value="DEBIT CARD">DEBIT CARD</asp:ListItem>
                                                                                            <asp:ListItem Value="Knet">Knet</asp:ListItem>
                                                                                            <asp:ListItem Value="Talabat">Talabat</asp:ListItem>
                                                                                             <asp:ListItem Value="Link">Link</asp:ListItem>
                                                                                            <asp:ListItem Value="MyFatoorah">MyFatoorah</asp:ListItem>--%>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 40%">
                                                                                        <span class="kt-widget11__sub">Referance</span>
                                                                                        <asp:Label ID="lblrefreq" runat="server" Style="color: red;" Visible="false" Text="please enter Reference"></asp:Label>
                                                                                        <asp:TextBox ID="txtPayReffrance"  onfocus="disableautocompletion(this.id);getFocus(this.id);"  class="form-control" Placeholder="Referance..." autocomplete="off" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                                                                    </td>
                                                                                    <td><span class="kt-widget11__sub">+</span>
                                                                                        <asp:Button ID="btnaddpaymenttype" runat="server" Text="ADD" class="btn btn-label-brand btn-bold btn-sm" OnClick="btnaddpaymenttype_Click" />
                                                                                        <%--<button type="button" class="btn btn-label-brand btn-bold btn-sm">ADD</button>--%></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <span class="kt-widget11__sub">Cash: 
                                                                                            <asp:Label runat="server" ID="Label16" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtcash" class="form-control"   Text="" onfocus="this.select();" onmouseup="return false;" OnTextChanged="txtcashamount_TextChanged" AutoCompleteType="none" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <span class="kt-widget11__sub">Change: 
                                                                                            <asp:Label runat="server" ID="Label17" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtchange" ReadOnly="true" class="form-control"   Text="" onfocus="this.select();" onmouseup="return false;"  AutoCompleteType="none" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                            </tbody>
                                                                        </table>
                                                                        <hr />
                                                                        <table class="table">
                                                                            <thead>
                                                                                <tr>
                                                                                    <td style="width: 10%">#</td>
                                                                                    <td style="width: 10%">Invoice</td>
                                                                                    <td style="width: 10%">Pay By</td>
                                                                                    <td style="width: 40%">Referance No</td>
                                                                                    <td style="width: 15%">Amount </td>
                                                                                    <td style="width: 15%">Action</td>

                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <asp:ListView ID="GridPayment"  runat="server" OnItemCommand="GridPayment_ItemCommand">
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td>1</td>
                                                                                            <td>
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("invoice") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td>
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("payment_type") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("Reffrance_NO") %>'></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("payment_amount") %>'></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:UpdatePanel class="table-responsive" runat="server">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:Button ID="btndel" class="kt-badge kt-badge--inline kt-badge--brand" runat="server" CommandName="GridRemove" CommandArgument='<%# Eval("payment_type") %>' Text="Delete" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="btndel" EventName="Click" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>

                                                                                            </td>

                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:ListView>
                                                                            </tbody>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="txtPopupPaidAmount" EventName="TextChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>

                                                                <hr />
                                                                <div class="kt-widget11__action kt-align-right">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPaymentComment"  autocomplete="off" Visible="false" autofocus="autofocus" tabindex="12" size="30" maxlength="30" onfocus="disableautocompletion(this.id);getFocus(this.id);" onblur="disableautocompletion(this.id);"  onkeypress="return disableCtrlKeyCombination(event);" onkeydown="return disableCtrlKeyCombination(event);" class="form-control" Placeholder="Comment..." runat="server"></asp:TextBox></td>
                                                                            <asp:TextBox ID="TextBox1"  autocomplete="off" autofocus="autofocus" tabindex="12" size="30" maxlength="30" onfocus="disableautocompletion(this.id);getFocus(this.id);" onblur="disableautocompletion(this.id);"  onkeypress="return disableCtrlKeyCombination(event);" onkeydown="return disableCtrlKeyCombination(event);" class="form-control" Placeholder="Comment..." runat="server"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkbox" runat="server" class="chek_box" onclick="constructKeyboard();" Text="Enable Virtual Keyboard" /></td>

                                                                            <td>
                                                                                <asp:Button ID="btnpopuporder" class="btn btn-label-brand btn-bold btn-sm" OnClick="btnpopuporder_Click" runat="server" Text="Place Order" OnClientClick=" if (Page_IsValid) {this.value='Saving...';this.disabled=true; }" UseSubmitBehavior="false"/>
                                                                                <asp:Button ID="btnpopupsaveonly" class="btn btn-label-brand btn-bold btn-sm" OnClick="btnpopupsaveonly_Click" runat="server" Visible="false" Text="Save Only" OnClientClick=" if (Page_IsValid) {this.value='Saving...';this.disabled=true; }" UseSubmitBehavior="false" />
                                                                                <asp:Button ID="btnpopupcancel" class="btn btn-label-brand btn-bold btn-sm" OnClick="btnpopupcancel_Click" runat="server" Text="Cancel" />
                                                                                <%-- <button type="button" class="btn btn-label-brand btn-bold btn-sm">Place Order</button>
                                                                                <button type="button" class="btn btn-label-success btn-bold btn-sm">Save Only</button>
                                                                                <button type="button" class="btn btn-label-danger btn-bold btn-sm">Cancel</button></td>--%>
                                                                        </tr>
                                                                    </table>


                                                                </div>
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-comn">
                                                                    <div id="login_banner">
                                                                        <div id="vkb_content" class="virtual_key ">
                                                                            <span id="kbplaceholder"></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--end::Widget 11-->
                                                        </div>
                                                        <!--end::tab 1 content-->
                                                        <!--begin::tab 2 content-->
                                                        <div class="tab-pane" id="kt_widget11_tab2_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="kt-widget11">
                                                                <div class="table-responsive">
                                                                </div>


                                                                <asp:UpdatePanel ID="UpdatePanel4" class="table-responsive" runat="server">
                                                                    <ContentTemplate>

                                                                        <hr />

                                                                        <div class="table-responsive">
                                                                            <h4>Invoice 1</h4>
                                                                        </div>
                                                                        <table class="table">
                                                                            <thead>
                                                                                <tr>
                                                                                    <td style="width: 10%">#</td>
                                                                                    <td style="width: 30%">Product</td>
                                                                                    <td style="width: 10%">QTY</td>
                                                                                    <td style="width: 10%">Price</td>
                                                                                    <td style="width: 20%">UOM</td>
                                                                                    <td style="width: 20%">Action</td>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <asp:ListView ID="ListInvoice1" runat="server" OnItemCommand="ListInvoice1_ItemCommand">
                                                                                    <ItemTemplate>

                                                                                        <tr>
                                                                                            <td style="padding-top: 0px;"><%# Eval("product_id") %></td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                     <% if(Convert.ToBoolean(Session["POSSetting"]) == true)  {  %> 
                                                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("product_name") %>'></asp:Label></a>
                                                                            </a>
                                                                          <%  } %>
                                                                            <% else { %>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("product_name_arabic") %>'></asp:Label></a>
                                                                            </a>
                                                                            <%  } %>
                                                                                                    
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("OpQty") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("msrp") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("UOMNAME") %>'></asp:Label></td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <asp:UpdatePanel ID="UpdatePanel4" class="table-responsive" runat="server">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:Button ID="btnmove" class="btn btn-label-brand btn-bold btn-sm" runat="server" CommandName="moveinvoice" CommandArgument='<%# Eval("product_id") %>' Text="Move" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="btnmove" EventName="Click" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:ListView>
                                                                            </tbody>
                                                                            <tfoot>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblinvoice1total" runat="server" Style="font-weight: bold; font-size: large" Text=""></asp:Label></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                            </tfoot>
                                                                        </table>


                                                                        <div class="table-responsive">
                                                                            <h4>Invoice 2</h4>
                                                                        </div>
                                                                        <table class="table">
                                                                            <thead>
                                                                                <tr>
                                                                                    <td style="width: 10%">#</td>
                                                                                    <td style="width: 30%">Product</td>
                                                                                    <td style="width: 10%">QTY</td>
                                                                                    <td style="width: 10%">Price</td>
                                                                                    <td style="width: 20%">UOM</td>
                                                                                    <td style="width: 20%">Action</td>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <asp:ListView ID="Listinvoice2" runat="server" OnItemCommand="Listinvoice2_ItemCommand">
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td style="padding-top: 0px;"><%# Eval("product_id") %></td>
                                                                                            <td style="padding-top: 0px;">
                                                                                               
                                                                                                    <% if(Convert.ToBoolean(Session["POSSetting"]) == true)  {  %> 
                                                                            <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("product_name") %>'></asp:Label></a>
                                                                          <%  } %>
                                                                            <% else { %>
                                                                             <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("product_name_arabic") %>'></asp:Label></a>
                                                                            <%  } %>
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("OpQty") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <a href="#" class="kt-widget11__title">
                                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("msrp") %>'></asp:Label></a>
                                                                                            </td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("UOMNAME") %>'></asp:Label></td>
                                                                                            <td style="padding-top: 0px;">
                                                                                                <asp:UpdatePanel ID="UpdatePanel4" class="table-responsive" runat="server">
                                                                                                    <ContentTemplate>

                                                                                                        <asp:Button ID="btnmovein" class="btn btn-label-brand btn-bold btn-sm" runat="server" CommandName="moveinvoicein" CommandArgument='<%# Eval("product_id") %>' Text="Move" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:AsyncPostBackTrigger ControlID="btnmovein" EventName="Click" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:ListView>
                                                                            </tbody>
                                                                            <tfoot>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblinvoice2total" runat="server" Text="" Style="font-weight: bold; font-size: large"></asp:Label></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                            </tfoot>
                                                                        </table>


                                                                    </ContentTemplate>

                                                                </asp:UpdatePanel>
                                                                <div class="kt-widget11__action kt-align-right">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <asp:Button ID="btninvoicedraft" class="btn btn-label-brand btn-bold btn-sm" OnClick="btninvoicedraft_Click" runat="server" Text="Draft Order" />

                                                                        </tr>
                                                                    </table>


                                                                </div>
                                                            </div>
                                                            <!--end::Widget 11-->
                                                        </div>
                                                        <!--end::tab 2 content-->
                                                        <!--begin::tab 3 content-->
                                                        <div class="tab-pane" id="kt_widget11_tab3_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="kt-widget11">
                                                                <div class="table-responsive">
                                                                    Other
                                                                </div>
                                                                <div class="kt-widget11__action kt-align-right">
                                                                    <button type="button" class="btn btn-label-success btn-bold btn-sm">Submit</button>
                                                                </div>
                                                            </div>
                                                            <!--end::Widget 11-->
                                                        </div>

                                                          <div class="tab-pane" style="margin-left:0px" id="kt_widget11_tab122_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="form-group center border border-secondary" style="margin-left:0px">
                                                                <div class="form-group center" style="margin-left:50px ; margin-top:5px">
                                                               <input type="button" value="1" id="btnone" onclick="calcash(btnone)" class="border-box btn col-2" />
                                                                 <input type="button" value="2" id="btntwo" onclick="calcash(btntwo)" class=" border-box btn col-2" />
                                                                 <input type="button" value="3" id="btnthree" onclick="calcash(btnthree)" class=" border-box btn col-2" />
                                                                 <input type="button" value="4" id="btnfour" onclick="calcash(btnfour)" class=" border-box btn col-2" />
                                                                 <input type="button" value="5" id="btnfive" onclick="calcash(btnfive)" class="border-box btn col-2" />
                                                                 <input type="button" value="6" id="btnsix" onclick="calcash(btnsix)" class="border-box btn col-2" />
                                                                 <input type="button" value="7"  id="btnseven" onclick="calcash(btnseven)" class="border-box btn col-2" />
                                                                 <input type="button" value="8" id="btneight" onclick="calcash(btneight)" class="border-box btn col-2" />
                                                                 <input type="button" value="9" id="btnnine" onclick="calcash(btnnine)" class="border-box btn col-2" />
                                                                 <input type="button" value="0" id="btnzero" onclick="calcash(btnzero)" class="border-box btn col-2" />
                                                                <input type="button" value="10" id="btnten" onclick="calcash(btnten)" class="border-box btn col-2" />
                                                                 <input type="button" value="15"  id="btnfifteen" onclick="calcash(btnfifteen)" class="border-box btn col-2" />
                                                                 <input type="button" value="20" id="btntwenty" onclick="calcash(btntwenty)" class="border-box btn col-2" />
                                                                 <input type="button" value="." id="btnfifty" onclick="calcash(btnfifty)" class="border-box btn col-2" />
                                                                 <input type="button" value="00" id="btndoublezero" onclick="calcash(btndoublezero)" class="border-box btn col-2" />
                                                              </div>

                                                               </div>
                                                               <div class="form-group" style="margin-left:30px">
                                                                
                                                            </div>
                                                               <div class="form-group">
                                                                  <span class="kt-widget11__sub">Paid Amount: 
                                                                                            <asp:Label runat="server" ID="Label18" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtchangepaidamount" ReadOnly="true" class="form-control"   Text=""  AutoPostBack="true" runat="server"></asp:TextBox>
                                                                   <span class="kt-widget11__sub">Cash Amount: 
                                                                                            <asp:Label runat="server" ID="Label20" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtchangecashamount" class="form-control"   Text=""  AutoCompleteType="none"  runat="server"></asp:TextBox>
                                                                   <span class="kt-widget11__sub">Change: 
                                                                                            <asp:Label runat="server" ID="Label21" Text=""></asp:Label></span>
                                                                                        <asp:TextBox ID="txtchangechangeamount" class="form-control"   Text=""  AutoCompleteType="none"  runat="server"></asp:TextBox>
                                                                    

                                                            <!--end::Widget 11-->
                                                     
                                                        <!--end::tab 3 content-->
                                                    </div>
                                                              <div>
                                                                  <input type="button" value="Clear" onclick="clearamt()" class="btn btn-danger" />
                                                              </div>
                                                    <!--End::Tab Content-->
                                                </div>
                                            </div>
                                            <!--end:: Widgets/Sale Reports-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="modal fade" id="PnlOrder" style="display: none;" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="">Add Order</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true" class="la la-remove"></span>
                                    </button>
                                </div>
                                <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                                    <div class="row">
                                        <div class="col-xl-12" style="max-width: 98%;">
                                            <!--begin:: Widgets/Sale Reports-->
                                            <div class="kt-portlet kt-portlet--tabs kt-portlet--height-fluid">
                                                <div class="kt-portlet__head">
                                                    <div class="kt-portlet__head-label">
                                                        <h3 class="kt-portlet__head-title">Sales Reports
                                                        </h3>
                                                    </div>
                                                    <div class="kt-portlet__head-toolbar">
                                                        <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-brand" role="tablist">
                                                            <li class="nav-item">
                                                                <a class="nav-link active" data-toggle="tab" href="#kt_widget11_tab1_content" role="tab">Amount Split
                                                                </a>
                                                            </li>
                                                            <li class="nav-item">
                                                                <a class="nav-link" data-toggle="tab" href="#kt_widget11_tab2_content" role="tab">Item Split
                                                                </a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="kt-portlet__body">
                                                    <!--Begin::Tab Content-->
                                                    <div class="tab-content">
                                                        <!--begin::tab 1 content-->
                                                        <div class="tab-pane active" id="kt_widget11_tab1_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="kt-widget11">
                                                                <div class="table-responsive">
                                                                    <table class="table">
                                                                        <thead>
                                                                            <tr>
                                                                                <td style="width: 1%">#</td>
                                                                                <td style="width: 40%">Application</td>
                                                                                <td style="width: 14%">Sales</td>
                                                                                <td style="width: 15%">Change</td>
                                                                                <td style="width: 15%">Status</td>
                                                                                <td style="width: 15%" class="kt-align-right">Total</td>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span>
                                                                                    </label>
                                                                                </td>
                                                                                <td>
                                                                                    <a href="#" class="kt-widget11__title">Loop</a>
                                                                                    <span class="kt-widget11__sub">CRM System</span>
                                                                                </td>
                                                                                <td>19,200</td>
                                                                                <td>KD 63</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--brand">new</span></td>
                                                                                <td class="kt-align-right kt-font-brand kt-font-bold">KD 34,740</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <a href="#" class="kt-widget11__title">Selto</a>
                                                                                    <span class="kt-widget11__sub">Powerful Website Builder</span>
                                                                                </td>
                                                                                <td>24,310</td>
                                                                                <td>KD 39</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--success">approved</span></td>
                                                                                <td class="kt-align-right kt-font-brand kt-font-bold">KD 46,010</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <a href="#" class="kt-widget11__title">Jippo</a>
                                                                                    <span class="kt-widget11__sub">The Best Selling App</span>
                                                                                </td>
                                                                                <td>9,076</td>
                                                                                <td>KD 105</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--warning">pending</span></td>
                                                                                <td class="kt-align-right kt-font-brand kt-font-bold">KD 67,800</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <a href="#" class="kt-widget11__title">Verto</a>
                                                                                    <span class="kt-widget11__sub">Web Development Tool</span>
                                                                                </td>
                                                                                <td>11,094</td>
                                                                                <td>KD 16</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--danger">on hold</span></td>
                                                                                <td class="kt-align-right kt-font-brand kt-font-bold">KD 18,520</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <div class="kt-widget11__action kt-align-right">
                                                                    <button type="button" class="btn btn-label-brand btn-bold btn-sm">Import Report</button>
                                                                </div>
                                                            </div>
                                                            <!--end::Widget 11-->
                                                        </div>
                                                        <!--end::tab 1 content-->
                                                        <!--begin::tab 2 content-->
                                                        <div class="tab-pane" id="kt_widget11_tab2_content">
                                                            <!--begin::Widget 11-->
                                                            <div class="kt-widget11">
                                                                <div class="table-responsive">
                                                                    <table class="table">
                                                                        <thead>
                                                                            <tr>
                                                                                <td style="width: 1%">#</td>
                                                                                <td style="width: 40%">Application</td>
                                                                                <td style="width: 14%">Sales</td>
                                                                                <td style="width: 15%">Change</td>
                                                                                <td style="width: 15%">Status</td>
                                                                                <td style="width: 15%" class="kt-align-right">Total</td>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span>
                                                                                    </label>
                                                                                </td>
                                                                                <td>
                                                                                    <span class="kt-widget11__title">Loop</span>
                                                                                    <span class="kt-widget11__sub">CRM System</span>
                                                                                </td>
                                                                                <td>19,200</td>
                                                                                <td>KD 63</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--danger">pending</span></td>
                                                                                <td class="kt-align-right kt-font-brand  kt-font-bold">KD 23,740</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <span class="kt-widget11__title">Selto</span>
                                                                                    <span class="kt-widget11__sub">Powerful Website Builder</span>
                                                                                </td>
                                                                                <td>24,310</td>
                                                                                <td>KD 39</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--success">new</span></td>
                                                                                <td class="kt-align-right kt-font-success  kt-font-bold">KD 46,010</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <span class="kt-widget11__title">Jippo</span>
                                                                                    <span class="kt-widget11__sub">The Best Selling App</span>
                                                                                </td>
                                                                                <td>9,076</td>
                                                                                <td>KD 105</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--brand">approved</span></td>
                                                                                <td class="kt-align-right kt-font-danger kt-font-bold">KD 15,800</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <label class="kt-checkbox kt-checkbox--single">
                                                                                        <input type="checkbox"><span></span></label>
                                                                                </td>
                                                                                <td>
                                                                                    <span class="kt-widget11__title">Verto</span>
                                                                                    <span class="kt-widget11__sub">Web Development Tool</span>
                                                                                </td>
                                                                                <td>11,094</td>
                                                                                <td>KD 16</td>
                                                                                <td><span class="kt-badge kt-badge--inline kt-badge--info">done</span></td>
                                                                                <td class="kt-align-right kt-font-warning kt-font-bold">KD 8,520</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <div class="kt-widget11__action kt-align-right">
                                                                    <button type="button" class="btn btn-label-success btn-bold btn-sm">Generate Report</button>
                                                                </div>
                                                            </div>
                                                            <!--end::Widget 11-->
                                                        </div>
                                                        <!--end::tab 2 content-->
                                                        <!--begin::tab 3 content-->
                                                        <div class="tab-pane" id="kt_widget11_tab3_content">
                                                        </div>
                                                        <!--end::tab 3 content-->
                                                    </div>
                                                    <!--End::Tab Content-->
                                                </div>
                                            </div>
                                            <!--end:: Widgets/Sale Reports-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!--end::Modal-->

                  
                </div>
                      <!-- begin:: Footer -->
                   
                    <!-- end:: Footer -->
            </div>
                   

                  
          
                     <div class="kt-footer  kt-grid__item kt-grid kt-grid--desktop kt-grid--ver-desktop" style="padding: 5px 0;" id="kt_footer">
                        <div class="kt-container  kt-container--fluid ">
                            <div class="kt-footer__copyright">
                                2019&nbsp;&copy;&nbsp;<a href="http://pos53.com" target="_blank" class="kt-link">DIGITAL POS53</a>
                            </div>


                            <div class="kt-footer__menu hidden">
                             <%--   <a href="ECOMM/PRODUCTMASTER.aspx" target="_blank" class="btn btn-primary btn-sm">Add Item</a>&nbsp;
                                <a href="#" target="_blank" class="btn btn-primary btn-sm">Add Customer</a>&nbsp;
                                <a href="Orderlist.aspx" target="_blank" class="btn btn-primary btn-sm">Orders</a>&nbsp;
                                 <a href="Fullsrarabic.aspx" target="_blank" class="btn btn-primary btn-sm">POS Arabic</a>&nbsp;
                                  <a href="Login.aspx" target="_blank" class="btn btn-primary btn-sm">Logout</a>&nbsp;--%>
                                    <div class="kt-mycart__subtitel">

                                                          
                                                            <span>Quotation No  &nbsp;<asp:TextBox ID="txtQuotation" autocomplete="off"   runat="server"  Style="width: 120px"></asp:TextBox></span>
                                                            <span>LPO  &nbsp;<asp:TextBox ID="txtlpo" autocomplete="off"   runat="server"  Style="width: 120px"></asp:TextBox></span>
                                                            
                                                        </div>
                            </div>
                        </div>
                    </div>
        </div>

        <!-- end:: Page -->
        <!-- begin::Quick Panel -->
        <div id="kt_quick_panel" class="kt-quick-panel">
            <a href="#" class="kt-quick-panel__close" id="kt_quick_panel_close_btn"><i class="flaticon2-delete"></i></a>

            <div class="kt-quick-panel__nav">
                <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-3x nav-tabs-line-brand  kt-notification-item-padding-x" role="tablist">
                    <li class="nav-item active">
                        <a class="nav-link active" data-toggle="tab" href="#kt_quick_panel_tab_notifications" role="tab">Notifications</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#kt_quick_panel_tab_logs" role="tab">Audit Logs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#kt_quick_panel_tab_settings" role="tab">Settings</a>
                    </li>
                </ul>
            </div>
            <div class="kt-quick-panel__content">
                <div class="tab-content">
                    <div class="tab-pane fade show kt-scroll active" id="kt_quick_panel_tab_notifications" role="tabpanel">
                        <div class="kt-notification">
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-line-chart kt-font-success"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New order has been received
                                    </div>
                                    <div class="kt-notification__item-time">
                                        2 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-box-1 kt-font-brand"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New customer is registered
                                    </div>
                                    <div class="kt-notification__item-time">
                                        3 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-chart2 kt-font-danger"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        Application has been approved
                                    </div>
                                    <div class="kt-notification__item-time">
                                        3 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-image-file kt-font-warning"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New file has been uploaded
                                    </div>
                                    <div class="kt-notification__item-time">
                                        5 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-drop kt-font-info"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New user feedback received
                                    </div>
                                    <div class="kt-notification__item-time">
                                        8 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-pie-chart-2 kt-font-success"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        System reboot has been successfully completed
                                    </div>
                                    <div class="kt-notification__item-time">
                                        12 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-favourite kt-font-danger"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New order has been placed
                                    </div>
                                    <div class="kt-notification__item-time">
                                        15 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item kt-notification__item--read">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-safe kt-font-primary"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        Company meeting canceled
                                    </div>
                                    <div class="kt-notification__item-time">
                                        19 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-psd kt-font-success"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New report has been received
                                    </div>
                                    <div class="kt-notification__item-time">
                                        23 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon-download-1 kt-font-danger"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        Finance report has been generated
                                    </div>
                                    <div class="kt-notification__item-time">
                                        25 hrs ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon-security kt-font-warning"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New customer comment recieved
                                    </div>
                                    <div class="kt-notification__item-time">
                                        2 days ago
                                    </div>
                                </div>
                            </a>
                            <a href="#" class="kt-notification__item">
                                <div class="kt-notification__item-icon">
                                    <i class="flaticon2-pie-chart kt-font-warning"></i>
                                </div>
                                <div class="kt-notification__item-details">
                                    <div class="kt-notification__item-title">
                                        New customer is registered
                                    </div>
                                    <div class="kt-notification__item-time">
                                        3 days ago
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="tab-pane fade kt-scroll" id="kt_quick_panel_tab_logs" role="tabpanel">
                        <div class="kt-notification-v2">
                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon-bell kt-font-brand"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        5 new user generated report
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Reports based on sales
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon2-box kt-font-danger"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        2 new items submited
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        by Grog John
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon-psd kt-font-brand"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        79 PSD files generated
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Reports based on sales
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon2-supermarket kt-font-warning"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        $2900 worth producucts sold
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Total 234 items
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon-paper-plane-1 kt-font-success"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        4.5h-avarage response time
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Fostest is Barry
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon2-information kt-font-danger"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        Database server is down
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        10 mins ago
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon2-mail-1 kt-font-brand"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        System report has been generated
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Fostest is Barry
                                    </div>
                                </div>
                            </a>

                            <a href="#" class="kt-notification-v2__item">
                                <div class="kt-notification-v2__item-icon">
                                    <i class="flaticon2-hangouts-logo kt-font-warning"></i>
                                </div>
                                <div class="kt-notification-v2__itek-wrapper">
                                    <div class="kt-notification-v2__item-title">
                                        4.5h-avarage response time
                                    </div>
                                    <div class="kt-notification-v2__item-desc">
                                        Fostest is Barry
                                    </div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="tab-pane kt-quick-panel__content-padding-x fade kt-scroll" id="kt_quick_panel_tab_settings" role="tabpanel">
                        <div class="kt-form">
                            <div class="kt-heading kt-heading--sm kt-heading--space-sm">Customer Care</div>

                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Enable Notifications:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--success kt-switch--sm">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_1">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Enable Case Tracking:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--success kt-switch--sm">
                                        <label>
                                            <input type="checkbox" name="quick_panel_notifications_2">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-last form-group-xs row">
                                <label class="col-8 col-form-label">Support Portal:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--success kt-switch--sm">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_2">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>

                            <div class="kt-separator kt-separator--space-md kt-separator--border-dashed"></div>

                            <div class="kt-heading kt-heading--sm kt-heading--space-sm">Reports</div>

                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Generate Reports:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--danger">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_3">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Enable Report Export:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--danger">
                                        <label>
                                            <input type="checkbox" name="quick_panel_notifications_3">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-last form-group-xs row">
                                <label class="col-8 col-form-label">Allow Data Collection:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--danger">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_4">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>

                            <div class="kt-separator kt-separator--space-md kt-separator--border-dashed"></div>

                            <div class="kt-heading kt-heading--sm kt-heading--space-sm">Memebers</div>

                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Enable Member singup:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--brand">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_5">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-xs row">
                                <label class="col-8 col-form-label">Allow User Feedbacks:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--brand">
                                        <label>
                                            <input type="checkbox" name="quick_panel_notifications_5">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group form-group-last form-group-xs row">
                                <label class="col-8 col-form-label">Enable Customer Portal:</label>
                                <div class="col-4 kt-align-right">
                                    <span class="kt-switch kt-switch--sm kt-switch--brand">
                                        <label>
                                            <input type="checkbox" checked="checked" name="quick_panel_notifications_6">
                                            <span></span>
                                        </label>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end::Quick Panel -->

        <!-- begin::Demo Panel -->

        <div id="kt_demo_panel" class="kt-demo-panel">
            <div class="kt-demo-panel__head">
                <h3 class="kt-demo-panel__title">Select A Demo
                <!--<small>5</small>-->
                </h3>
                <a href="#" class="kt-demo-panel__close" id="kt_demo_panel_close"><i class="flaticon2-delete"></i></a>
            </div>
            <div class="kt-demo-panel__body">
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 1
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo1.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 2
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo2.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 3
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo3.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 4
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo4.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 5
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo5.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item kt-demo-panel__item--active">
                    <div class="kt-demo-panel__item-title">
                        Demo 6
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo6.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 7
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo7.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 8
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo8.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 9
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo9.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 10
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo10.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 11
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo11.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 12
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo12.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="newdemo.aspx" class="btn btn-brand btn-elevate " target="_blank">Preview</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 13
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo13.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="#" class="btn btn-brand btn-elevate disabled">Coming soon</a>

                        </div>
                    </div>
                </div>
                <div class="kt-demo-panel__item ">
                    <div class="kt-demo-panel__item-title">
                        Demo 14
                    </div>
                    <div class="kt-demo-panel__item-preview">
                        <img src="assetsn/media/demos/preview/demo14.jpg" alt="" />
                        <div class="kt-demo-panel__item-preview-overlay">
                            <a href="#" class="btn btn-brand btn-elevate disabled">Coming soon</a>

                        </div>
                    </div>
                </div>
                <a href="https://1.envato.market/EA4JP" target="_blank" class="kt-demo-panel__purchase btn btn-brand btn-elevate btn-bold btn-upper">Buy Metronic Now!
                </a>
            </div>
        </div>
        <!-- end::Demo Panel -->
        <!--Begin:: Chat-->
        <div class="modal fade- modal-sticky-bottom-right" id="kt_chat_modal" role="dialog" data-backdrop="false">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="kt-chat">
                        <div class="kt-portlet kt-portlet--last">
                            <div class="kt-portlet__head">
                                <div class="kt-chat__head ">
                                    <div class="kt-chat__left">
                                        <div class="kt-chat__label">
                                            <a href="#" class="kt-chat__title">Jason Muller</a>
                                            <span class="kt-chat__status">
                                                <span class="kt-badge kt-badge--dot kt-badge--success"></span>Active
                                            </span>
                                        </div>
                                    </div>
                                    <div class="kt-chat__right">
                                        <div class="dropdown dropdown-inline">
                                            <button type="button" class="btn btn-clean btn-sm btn-icon btn-icon-md" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <i class="flaticon-more-1"></i>
                                            </button>
                                            <div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-md">
                                                <!--begin::Nav-->
                                                <ul class="kt-nav">
                                                    <li class="kt-nav__head">Messaging
                                                    <i class="flaticon2-information" data-toggle="kt-tooltip" data-placement="right" title="Click to learn more..."></i>
                                                    </li>
                                                    <li class="kt-nav__separator"></li>
                                                    <li class="kt-nav__item">
                                                        <a href="#" class="kt-nav__link">
                                                            <i class="kt-nav__link-icon flaticon2-group"></i>
                                                            <span class="kt-nav__link-text">New Group</span>
                                                        </a>
                                                    </li>
                                                    <li class="kt-nav__item">
                                                        <a href="#" class="kt-nav__link">
                                                            <i class="kt-nav__link-icon flaticon2-open-text-book"></i>
                                                            <span class="kt-nav__link-text">Contacts</span>
                                                            <span class="kt-nav__link-badge">
                                                                <span class="kt-badge kt-badge--brand  kt-badge--rounded-">5</span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li class="kt-nav__item">
                                                        <a href="#" class="kt-nav__link">
                                                            <i class="kt-nav__link-icon flaticon2-bell-2"></i>
                                                            <span class="kt-nav__link-text">Calls</span>
                                                        </a>
                                                    </li>
                                                    <li class="kt-nav__item">
                                                        <a href="#" class="kt-nav__link">
                                                            <i class="kt-nav__link-icon flaticon2-dashboard"></i>
                                                            <span class="kt-nav__link-text">Settings</span>
                                                        </a>
                                                    </li>
                                                    <li class="kt-nav__item">
                                                        <a href="#" class="kt-nav__link">
                                                            <i class="kt-nav__link-icon flaticon2-protected"></i>
                                                            <span class="kt-nav__link-text">Help</span>
                                                        </a>
                                                    </li>
                                                    <li class="kt-nav__separator"></li>
                                                    <li class="kt-nav__foot">
                                                        <a class="btn btn-label-brand btn-bold btn-sm" href="#">Upgrade plan</a>
                                                        <a class="btn btn-clean btn-bold btn-sm" href="#" data-toggle="kt-tooltip" data-placement="right" title="Click to learn more...">Learn more</a>
                                                    </li>
                                                </ul>
                                                <!--end::Nav-->
                                            </div>
                                        </div>

                                        <button type="button" class="btn btn-clean btn-sm btn-icon" data-dismiss="modal">
                                            <i class="flaticon2-cross"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="kt-portlet__body">
                                <div class="kt-scroll kt-scroll--pull" data-height="410" data-mobile-height="300">
                                    <div class="kt-chat__messages kt-chat__messages--solid">
                                        <div class="kt-chat__message kt-chat__message--success">
                                            <div class="kt-chat__user">
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/100_12.jpg" alt="image">
                                                </span>
                                                <a href="#" class="kt-chat__username">Jason Muller</span></a>
                                                <span class="kt-chat__datetime">2 Hours</span>
                                            </div>
                                            <div class="kt-chat__text">
                                                How likely are you to recommend our company<br>
                                                to your friends and family?
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--right kt-chat__message--brand">
                                            <div class="kt-chat__user">
                                                <span class="kt-chat__datetime">30 Seconds</span>
                                                <a href="#" class="kt-chat__username">You</span></a>
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/300_21.jpg" alt="image">
                                                </span>
                                            </div>
                                            <div class="kt-chat__text">
                                                Hey there, we’re just writing to let you know that you’ve<br>
                                                been subscribed to a repository on GitHub.
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--success">
                                            <div class="kt-chat__user">
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/100_12.jpg" alt="image">
                                                </span>
                                                <a href="#" class="kt-chat__username">Jason Muller</span></a>
                                                <span class="kt-chat__datetime">30 Seconds</span>
                                            </div>
                                            <div class="kt-chat__text">
                                                Ok, Understood!
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--right kt-chat__message--brand">
                                            <div class="kt-chat__user">
                                                <span class="kt-chat__datetime">Just Now</span>
                                                <a href="#" class="kt-chat__username">You</span></a>
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/300_21.jpg" alt="image">
                                                </span>
                                            </div>
                                            <div class="kt-chat__text">
                                                You’ll receive notifications for all issues, pull requests!
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--success">
                                            <div class="kt-chat__user">
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/100_12.jpg" alt="image">
                                                </span>
                                                <a href="#" class="kt-chat__username">Jason Muller</span></a>
                                                <span class="kt-chat__datetime">2 Hours</span>
                                            </div>
                                            <div class="kt-chat__text">
                                                You were automatically <b class="kt-font-brand">subscribed</b>
                                                <br>
                                                because you’ve been given access to the repository
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--right kt-chat__message--brand">
                                            <div class="kt-chat__user">
                                                <span class="kt-chat__datetime">30 Seconds</span>
                                                <a href="#" class="kt-chat__username">You</span></a>
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/300_21.jpg" alt="image">
                                                </span>
                                            </div>

                                            <div class="kt-chat__text">
                                                You can unwatch this repository immediately
                                                <br>
                                                by clicking here: <a href="#" class="kt-font-bold kt-link"></a>
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--success">
                                            <div class="kt-chat__user">
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/100_12.jpg" alt="image">
                                                </span>
                                                <a href="#" class="kt-chat__username">Jason Muller</span></a>
                                                <span class="kt-chat__datetime">30 Seconds</span>
                                            </div>
                                            <div class="kt-chat__text">
                                                Discover what students who viewed Learn
                                                <br>
                                                Figma - UI/UX Design Essential Training also viewed
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--right kt-chat__message--brand">
                                            <div class="kt-chat__user">
                                                <span class="kt-chat__datetime">Just Now</span>
                                                <a href="#" class="kt-chat__username">You</span></a>
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="assetsn/media/users/300_21.jpg" alt="image">
                                                </span>
                                            </div>
                                            <div class="kt-chat__text">
                                                Most purchased Business courses during this sale!
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="kt-portlet__foot">
                                <div class="kt-chat__input">
                                    <div class="kt-chat__editor">
                                        <textarea placeholder="Type here..." style="height: 50px"></textarea>
                                    </div>
                                    <div class="kt-chat__toolbar">
                                        <div class="kt_chat__tools">
                                            <a href="#"><i class="flaticon2-link"></i></a>
                                            <a href="#"><i class="flaticon2-photograph"></i></a>
                                            <a href="#"><i class="flaticon2-photo-camera"></i></a>
                                        </div>
                                        <dreply</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">

            $("#btnCategoryallData").click(function(e){
                e.preventDefault();
               
              
                var totalCategoryData = $('#<%= totalCateData.ClientID %>').text();

                totalCategoryData = JSON.parse(totalCategoryData)

                drawCartCard(totalCategoryData);
               
            });

            $(".btn_category").click(function (e) {
                e.preventDefault();
                var CID = this.getAttribute('data-category');
                var TID = $('#<%= LabelTID.ClientID %>').text();
                var LID = $('#<%= LabelLID.ClientID %>').text();
                console.log('btn_category')

                this.style.backgroundColor = 'red';

                var totalCategoryData = $('#<%= totalCateData.ClientID %>').text();

                totalCategoryData = JSON.parse(totalCategoryData)

                drawCartCard(totalCategoryData, CID);


            })

            function drawCartCard(items=[], CID = false) {
                
                var itemlistView = $('#cartCartPanel');
                var prod = $('#<%= idfProductName.ClientID %>').text();

                
                    itemlistView.html("");

                    var categories; 


                    if (!CID) {
                        categories = items;
                    }
                    else {
                        categories = items.filter(function (item) {
                            return item.MainCategoryID == CID;
                        })
                    }

                categories.forEach(function (item, idx) {

                        var content = `
                             <div class="col-md-3">
                                         <!--Begin::Portlet-->
                                         <div class="kt-portlet kt-portlet--height-fluid">
                                             <div class="kt-portlet__head kt-portlet__head--noborder">
                                                 <div class="kt-portlet__head-label">
                                                     <h3 class="kt-portlet__head-title"></h3>
                                                 </div>

                                             </div>
                                             <div class="kt-portlet__body">
                                                 <!--begin::Widget -->
                                                 <div class="kt-widget kt-widget--user-profile-2">
                                                     <div class="kt-widget__head">
                                                         <div class="kt-widget__media">
                                                             <asp:Image ID="lnkimg_Update" class="kt-widget__img kt-hidden-" runat="server" />
                                                             <asp:Label ID="Prod_Update" runat="server" Visible="false" Text="${item.MYPRODID}"></asp:Label>
                                                             <div class="kt-widget__pic kt-widget__pic--success kt-font-success kt-font-boldest kt-hidden">
                                                 
                                                             </div>
                                                         </div>


                                                         <div class="kt-widget__info">
                                           
                                                                <a href="#" class="kt-widget__username">${item.MYPRODID}-${item[prod]}
                                                             </a>
                                           
                                                             <span class="kt-widget__desc">Piece - ${item.msrp} &nbsp;&nbsp;
                                                                 <asp:Label ID="lbladdon_Update" runat="server" Visibl="false" Style="color: blue"></asp:Label>
                                                             </span>
                                                         </div>
                                                     </div>



                                                     <div class="kt-widget__footer">
                                         
                                                         <asp:LinkButton class="btn btn-label-primary btn-lg btn-upper" ID="LnkProdAdd_Update" runat="server" CommandName="LnkProdAdd" CommandArgument='<%# Eval(Session["ProductName"].ToString()) +"~"+ Eval("MYPRODID")+"~"+ Eval("UOM") %>' >Add To Cart</asp:LinkButton>
                                                             </a>

                                                     </div>
                                                 </div>
                                                 <!--end::Widget -->
                                             </div>
                                         </div>
                                         <!--End::Portlet-->
                                     </div>
                                    `
                        var pre = itemlistView.html();

                        itemlistView.html("" + pre + content)
                    })
          
                
            }


            function ReloadPanel() {
               
                __doPostBack("<%=UpdatePanel3.UniqueID %>", "");
            }
            function PrintPanel() {

                var panel = document.getElementById("<%=pnlContents.ClientID %>");
                var printWindow = window.open('', '', 'height=400,width=400');
               //printWindow.document.write('<html><head><title>DIV Contents</title> ');
               printWindow.document.write('</head><body >');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                
                printWindow.document.close();
                
                setTimeout(function () {
                
                    printWindow.print();
                    window.location = "fullsr.aspx";
                }, 500);
                return false;

                var panel = document.getElementById("invoice");
              
            }
              function PrintPanelA4() {

                var panel = document.getElementById("<%=pnlContentsA4.ClientID %>");
                var printWindow = window.open('', '', 'height=400,width=800');
               //printWindow.document.write('<html><head><title>DIV Contents</title> ');
               printWindow.document.write('</head><body >');
                printWindow.document.write(panel.innerHTML);
                printWindow.document.write('</body></html>');
                
                printWindow.document.close();
                
                setTimeout(function () {
                
                    printWindow.print();
                    window.location = "fullsr.aspx";
                }, 500);
                return false;

                var panel = document.getElementById("invoice");
              
            }
           

         
        </script>    
       <asp:Panel ID="pnlContents" Style="display: none" runat="server">


            <div modal-window="modal-window" class="modal fade ng-scope ng-isolate-scope in" role="dialog" aria-labelledby="modal-title" aria-describedby="modal-body" size="md" index="0" animate="animate" ng-style="{'z-index': 1050 + $$topModalIndex*10, display: 'block'}" tabindex="-1" uib-modal-animation-class="fade" modal-in-class="in" modal-animation="true" style="z-index: 1050; display: block;">
                <div class="modal-dialog modal-md">
                    <div class="modal-content" uib-modal-transclude="">

                        <div class="modal-body ng-scope" id="modal-body">
                            <div bind-html-compile="rawHtml">
                                <div class="table-responsive ng-scope">
                                    <div id="invoice" class="row">
                                        <div class="col-xs-12 col-md-12">
                                            <style id="styles" type="text/css">
                                                /*Common CSS*/
                                                .receipt-template {
                                                    width: 302px;
                                                    margin: 0 auto;
                                                }

                                                    .receipt-template .text-small {
                                                        font-size: 10px;
                                                    }

                                                    .receipt-template .block {
                                                        display: block;
                                                    }

                                                    .receipt-template .inline-block {
                                                        display: inline-block;
                                                    }

                                                    .receipt-template .bold {
                                                        font-weight: 700;
                                                    }

                                                    .receipt-template .italic {
                                                        font-style: italic;
                                                    }

                                                    .receipt-template .align-right {
                                                        text-align: right;
                                                    }

                                                    .receipt-template .align-center {
                                                        text-align: center;
                                                    }

                                                    .receipt-template .main-title {
                                                        font-size: 14px;
                                                        font-weight: 700;
                                                        text-align: center : 10px 0 5p;
                                                    }

                                                late .hea ing {
                                                    p;
                                                }

                                                mplate .ti le {
                                                    font-size: 16 x;
                                                    nt-weig t: 70 r;
                                                }

                                                te .sub-ti le {
                                                    font-size: 12 x;
                                                    nt-weig t: 70 r;
                                                }

                                                emplat tabl
                                                }


                                                eceipt-template t,
                                                t-template th {
                                                }

                                                te .info-a ea {
                                                    font-size: 12 x;
                                                    l;
                                                }

                                                .listing-are {
                                                    l;
                                                }

                                                n
                                                }

                                                ad tr {
                                                    d #000;
                                                    d #000;
                                                    e;
                                                }

                                                dy tr {
                                                    d #000;
                                                    a;
                                                }

                                                d {
                                                    :;
                                                }

                                                le td {
                                                    a;
                                                }

                                                }

                                                thead tr {
                                                    solid #000;
                                                    1;
                                                }
                                                /*Receipt Heading /
             eceipt-head r {
  t

                                                            }

                                                                          logo-a ea  {
                                                    idth: 8 px;
                                                    
                                                    ight: 8 p;
  m

                                                        }

                                      .logo {
                                                                 -block;
                                                          : 100%;
       i

                                                            }

                                                                             ress-area {
                                                         ottom: 5px;
                                                      l

                                                            }

                                                                     der .info 
                                                       o

                                                            }

                                                                           tore-name 
                                                       size: 24px;
                                                        eight: 00
                                                     margin: 0;
                                                               }


                                                Invoice Info Area /
                i
                                                                }

     mer Customer Area /
            customer-ar a {
                                                    
                                                                 }

                                                *Calculation Area /
               culation-ar a  {
         2px solid #0 0;
                                                      
                                                            }

                                                                          table td {
     t

                                                        }

                                          ld(2) {
                   a
                                                                   /*Item Listing /
               t
                                                                   /*Barcode Area /
           .barcode-ar a {
                                                    
                                                    rgin-top: 1 px;
  t

                                                            }

                                                                 -area img 
   idth: 10 %;
         :
                                                                   /*Footer Area /
           .footer-are  {
  -height: 1 222;
                                                                       /*Me i
                                                         @media print {
                                                        eipt-t mplat
                                                      
                                                                 }

                                                        n

                                                                        }
                                            </style>
                                           
                                     
                                            <section class="receipt-template">
                                                 <header class="receipt-header" style="margin-left:60px">
                                                
                                                     <%-- <img src="../ECOMM/Upload/logo.png" runat="server" id="logoid" style="width:120px;height:90px" />--%>
                                                     <asp:Image runat="server" ID="logoid" style="width:120px;height:90px ; text-align-last:center ; margin-left:10px"/>
                                                     </header>
                                                  <header class="bold" style="margin-left:40px">
                                                     <div class="address-area" style="text-align:center ;margin-right:30%" >
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label8" ></asp:Label>
                                                        </span>
                                                    
                                                    </div>

                                                       <div class="address-area" style="text-align:center ;margin-right:30%">
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label9" ></asp:Label>
                                                        </span>
                                                    
                                                    </div>

                                                       <div class="address-area" style="text-align:center ;margin-right:30%">
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label10" ></asp:Label>
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label14" ></asp:Label>
                                                        </span>
                                                    
                                                    </div>
                                                        <div class="address-area" style="text-align:center ;margin-right:30%">
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label13" ></asp:Label>
                                                        
                                                        </span>
                                                    
                                                    </div>
                                                      
                                                       <div class="address-area" style="text-align:center ;margin-right:30%">
                                                        <span class="info address" style="text-align:center ; ">
                                                           <asp:Label runat="server" CssClass="fa-store" ID="txtstore" Text=""></asp:Label>
                                                        </span>
                                                    
                                                    </div>
                                                     
                                                   
                                                    
                                                            
                                                
                                                </header>
                                              

                                                <section class="info-area">
                                                    <table>
                                                        <tbody>

                                                            <tr >
                                                                <td class="w-30"><span>Invoice ID:</span></td>
                                                                <td>INV/<asp:Label ID="lblpin" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr >
                                                                <td class="w-30"><span>Date:</span></td>
                                                                <td><asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                                            </tr>

                                                             <tr>
                                                               
                                                                <td>
                                                                   <h4 >Bill To</h4>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                               
                                                                <td>
                                                                    <asp:Label ID="labelUSerNAme" runat="server"></asp:Label></td>
                                                            </tr>
                                                             <tr>
                                                               
                                                                <td>
                                                                    <asp:Label ID="UserAddress" runat="server"></asp:Label></td>
                                                            </tr>
                                                             <tr>
                                                               
                                                                <td>
                                                                    <asp:Label ID="UserMobile" runat="server"></asp:Label></td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </section>


                                                <section class="listing-area item-list">
                                                    <table border="1" cellpadding="1" cellspacing="1">
                                                        <thead>
                                                            <tr>
                                                                <td style="text-align: left;  font-family: Arial, Helvetica, sans-serif ; color:black">Name</td>
                                                            
                                                                <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black">Qty</td>
                                                                <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black">Price</td>
                                                                <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black">Amount</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listProductst"  runat="server" >
                                                                <ItemTemplate>
                                                                    <tr>
                                                                       <%-- <td><%# getprodname(Convert.ToInt32 (Eval("MyProdID")))%> </td>--%>
                                                                        <td style="text-align: left ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:50% " >
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# GetDesc(Eval("DESCRIPTION").ToString()) %>'></asp:Label>
                                                                          
                                                                          </td>
                                                                         
                                                                        
                                                                        <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:10%"><%#Eval("QUANTITY")%></td>
                                                                        <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:20%"><%#Eval("UNITPRICE")%> </td>
                                                                        <td style="text-align: center ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:20%"><%#Eval("AMOUNT")%> </td>
                                                                         <tr <%# (String.IsNullOrEmpty(Convert.ToString(Eval("Remarks")))? "hidden" : "" )%>>
                                                                            <%--<td colspan="4"  style="text-align: left ; font-family: Arial, Helvetica, sans-serif; font-size:smaller " >Note : <%#Eval("Remarks")%></td>--%>
                                                                             <td colspan="4" style="text-align: left ; font-family:'Bodoni MT'; font-size:smaller ">
                                                                                  <%# (String.IsNullOrEmpty(Convert.ToString(Eval("Remarks")))? "" :String.Concat("Note:",Eval("Remarks")))%>  
                                                                             </td>
                                                                       </tr>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                </section>
                                                <br />
                                                <section class="info-area calculation-area">
                                                    <table class="pull-right"  style="text-align:right ; margin-left:auto">
                                                        <tbody>
                                                            <tr>
                                                                <td class="w-70" style="text-align: right;">Total Amount:</td>
                                                                <td style="text-align: right;">
                                                                    <asp:Label  ID="lblSubtotal"  runat="server"></asp:Label></td>
                                                            </tr>

                                                            <tr>
                                                                <td class="w-70" style="text-align: right;">Delivery Charges:</td>
                                                                <td style="text-align: right;">
                                                                    <asp:Label  ID="lbldeliver"  runat="server"></asp:Label></td>
                                                            </tr>

                                                            <tr>
                                                                <td style="text-align: right;" class="w-70">Discount:</td>
                                                                <td style="text-align: right;">
                                                                    <asp:Label ID="Label3" runat="server"></asp:Label></td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td class="w-70" style="text-align: right;">Shipping Chrg:</td>
                                                                <td>0.00</td>
                                                            </tr>--%>
                                                          <%--  <tr>
                                                                <td  style="text-align: right;"  class="w-70">Total Due:</td>
                                                                <td style="text-align: right;">
                                                                    <asp:Label ID="lbldue" runat="server"></asp:Label></td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td style="text-align: right;" class="w-70">Amount Paid:</td>
                                                                <td style="text-align: right;">
                                                                    <asp:Label ID="lblGalredTot" runat="server"></asp:Label></td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </section>

                                                <section class="info-area italic">
                                                    <span class="text-small"><b></b>
                                                        <asp:Label ID="lblword" Style="font-family:Calibri; font-size:medium" runat="server"></asp:Label></span><br /><br />
                                                    <span class="text-small"><b></b> 
                                                    <asp:Label  ID="Label11" Style="font-family:Calibri; font-size:medium" runat="server"></asp:Label><br />
                                                        <asp:Label  ID="Label12" Style="font-family:Calibri; font-size:small" runat="server"></asp:Label>
                                                    </span>

                                                </section>


                                                <section class="listing-area payment-list">
                                                    <div class="heading">
                                                        <h2 class="sub-title">Payments</h2>
                                                    </div>
                                                    <table  border="1" cellpadding="1" cellspacing="1">
                                                        <thead>
                                                            <tr>
                                                                <td style="font-family: Arial ; color:black" class="w-10 text-center">Sl.</td>
                                                                <td  style="width:60% ;font-family: Arial ; color:black" class="w-50 text-center">Payment Method</td>
                                                                <td  style="font-family: Arial ; color:black" class="w-20 text-right">Amount</td>
                                                                <td style="font-family: Arial ; color:black" class="w-20 text-right">Balance</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="Listviewpayment" runat="server">

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td class="text-center" style="font-family: Arial ; color:black">1</td>
                                                                        <td style="font-family: Arial ; color:black"><%#Eval("payment_type")%></td>
                                                                        <td class="text-right" style="font-family: Arial ; color:black">
                                                                            <asp:Label ID="Label5" runat="server"><%#Eval("payment_amount")%></asp:Label></td>
                                                                        <td style="font-family: Arial ; color:black" class="text-right"><%#Eval("change_amount")%></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                    
                                                </section>


                                            </section>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>








        </asp:Panel>

       <asp:Panel ID="pnlContentsA4" Style="display: none" runat="server">
             <div modal-window="modal-window" class="modal fade ng-scope ng-isolate-scope in" role="dialog" aria-labelledby="modal-title" aria-describedby="modal-body" size="md" index="0" animate="animate" ng-style="{'z-index': 1050 + $$topModalIndex*10, display: 'block'}" tabindex="-1" uib-modal-animation-class="fade" modal-in-class="in" modal-animation="true" style="z-index: 1050; display: block;">
                    <div class="modal-dialog modal-md">
                    <div class="modal-content" uib-modal-transclude="">

                        <div class="modal-body ng-scope" id="modal-body">
                            <div bind-html-compile="rawHtml">
                                <div class="table-responsive ng-scope">
                                    <div id="invoice" class="row">
                                        <div class="col-xs-12 col-md-12">
                                    <table style="width: 100%">
                                            
                                    <tr style="text-align: center">
                                              
                                                <td style="align-items:center">
                                                  <asp:Image runat="server" ID="logoida4" style="width:120px;height:90px ; text-align-last:center ; margin-left:10px"/></td>
                                             
                                                 </tr>
                                          <tr style="text-align: center">
                                                <td>  <asp:Label runat="server"  CssClass="fa-address-card" ID="lblCompanynamearabicA4" ></asp:Label> </td>
                                               </tr>
                                            <tr style="text-align: center">
                                                <td>  <asp:Label runat="server"  CssClass="fa-address-card" ID="lblcompanynamea4" ></asp:Label> </td>
                                               </tr>
                                            <tr style="text-align: center">
                                                 <td>  <asp:Label runat="server"  CssClass="fa-address-card" ID="lblcompanyaddressa4" ></asp:Label> </td>
                                               </tr>
                                            <tr style="text-align: center">
                                                 <td>  <asp:Label runat="server"  CssClass="fa-address-card" ID="lblcompanyphonea4" ></asp:Label>
                                                            </td>
                                                </tr>
                                            <tr style="text-align: center">
                                                <td>  <asp:Label Visible="false" runat="server"  CssClass="fa-address-card" ID="lblcompanyemaila4" ></asp:Label> </td>
                                               </tr>
                                            <tr style="text-align: center">
                                                 <td> <asp:Label Visible="false" runat="server" CssClass="fa-store" ID="lblstorea4" Text=""></asp:Label></td>
                                            </tr>
                                            
                                        </table>
                                        <hr />
                                    <table  style="width: 100%; height:  auto ; border:1px solid black;border-collapse:collapse;">
                                            <tbody >
                                                <tr style="border:1px solid black;border-collapse:collapse;">
                                                  
                                                                <td style="width:20% ; border:1px solid black;border-collapse:collapse;"><span class="muted">Customer  </span>
                                                                <span class="muted">/  عميل:  </span> </td>
                                                                <td style="width:35% ; border:1px solid black;border-collapse:collapse">
                                                                      <asp:Label ID="lblA4Customer" runat="server"></asp:Label>
                                                                 
                                                                </td>
                                                                   <td style="width:15% ; border:1px solid black;border-collapse:collapse"><span class="muted">Date  </span>
                                                                   <span class="muted">/  تاريخ:  </span></td>
                                                                <td style="width:30% ; border:1px solid black;border-collapse:collapse">
                                                                    <asp:Label ID="lblA4InvoiceDate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                <tr style="border:1px solid black;border-collapse:collapse">
                                                    
                                                    <th rowspan="2" style="width:20% ; border:1px solid black;border-collapse:collapse ; font-weight:normal ; text-align:left"> <asp:Label  ID="Label25"  runat="server">Address / عنوان :</asp:Label></th>
                                                     <th  rowspan="2" style="width:20% ; border:1px solid black;border-collapse:collapse ; font-weight:normal"> <asp:Label  ID="lblA4CustomerAdd"  runat="server"></asp:Label></th>
                                                                

                                                                <td  style="width:15% ; border:1px solid black;border-collapse:collapse"><span class="muted">Invoice </span>
                                                                <span class="muted">/فاتورة: </span></td>
                                                                <td style="width:35%">
                                                                    <asp:Label ID="lblA4InvoiceID" runat="server"></asp:Label></td>
                                                             
                                                             </tr>
                                                <tr style="border:1px solid black;border-collapse:collapse"">
                                                    <td style="width:15% ; border:1px solid black;border-collapse:collapse"><span class="muted">Quotation # </span>
                                                               </td>
                                                                    <td style="width:10% ; border:1px solid black;border-collapse:collapse">
                                                                    <asp:Label ID="lblQuotation" runat="server"></asp:Label></td>
                                                </tr>
                                                         <tr>
                                                                <td style="width:20% ;  white-space:pre-line ; border:1px solid black;border-collapse:collapse"><span class="muted">Customer Code : </span>
                                                                <span class="muted"></span></td>
                                                                <td style="border:1px solid black;border-collapse:collapse">
                                                                    <asp:Label ID="lblcustomerCode"  runat="server"></asp:Label></td>

                                                               
                                                                <td style="width:10% ; border:1px solid black;border-collapse:collapse"><span class="muted">LPO # </span>
                                                               </td>
                                                                <td style="width:15% ; border:1px solid black;border-collapse:collapse">
                                                                    <asp:Label ID="lblLPP" runat="server"></asp:Label></td>
                                                                </tr>
                                              
                                            </tbody>

                                        </table>
                           

                                        <table style="width: 100% ; border:1px solid black;border-collapse:collapse;">
                                            <thead>
                                                <tr style="border:1px solid black;border-collapse:collapse">
                                                    <td style="text-align: center; width: 3% ; border:1px solid black;border-collapse:collapse"><strong>#</strong></td>
                                                    <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><strong>Item Code<br />
                                                        رمز الصنف</strong></td>
                                                    <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><strong>Item Description<br />
                                                        أوصاف البند</strong></td>
                                                    <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><strong>Qty<br />
                                                        كمية</strong></td>
                                                    <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><strong>Unit Price<br />
                                                        سعر الوحدة</strong></td>
                                                    <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><strong>Total Price<br />
                                                       السعر الكلي </strong></td>
                                                    
                                                    
                                                            
                                                </tr>

                                            </thead>

                                            <tbody>
                                                <asp:ListView ID="listproductA4" runat="server">

                                                    <ItemTemplate>
                                                        <tr style="border:1px solid black;border-collapse:collapse">
                                                            <td style="text-align: center ; border:1px solid black;border-collapse:collapse"><%#Container.DataItemIndex+1%></td>
                                                            <td style="text-align: center ; border:1px solid black;border-collapse:collapse ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:15%"><%#Eval("MyProdID")%> </td>  
                                                             <td style="text-align: left ; border:1px solid black;border-collapse:collapse ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:45% " >
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# GetDesc(Eval("DESCRIPTION").ToString()) %>'></asp:Label>
                                                                          
                                                                          </td>  
                                                                                                                     
                                                            <td style="text-align: center ; border:1px solid black;border-collapse:collapse ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:10%"><%#Eval("QUANTITY")%></td>
                                                                        <td style="text-align: center ; border:1px solid black;border-collapse:collapse ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:15%"><%#Eval("UNITPRICE")%> </td>
                                                                        <td style="text-align: center ; border:1px solid black;border-collapse:collapse ; font-family: Arial, Helvetica, sans-serif ; color:black ; width:20%"><%#Eval("AMOUNT")%> </td>
                                                                         <tr <%# (String.IsNullOrEmpty(Convert.ToString(Eval("Remarks")))? "hidden" : "" )%>>
                                                                            <%--<td colspan="4"  style="text-align: left ; font-family: Arial, Helvetica, sans-serif; font-size:smaller " >Note : <%#Eval("Remarks")%></td>--%>
                                                                             <td colspan="4" style="text-align: left ; border:1px solid black;border-collapse:collapse ; font-family:'Bodoni MT'; font-size:smaller ">
                                                                                  <%# (String.IsNullOrEmpty(Convert.ToString(Eval("Remarks")))? "" :String.Concat("Note:",Eval("Remarks")))%>  
                                                                             </td>
                                                            
                                                           
                                                          
                                                           
                                                            

                                                            
                                                        </tr>

                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                           
                                        </table>
                             
                                                <br />
                                                <section class="">
                                                    <table style="width: 100% ; border:1px solid black;border-collapse:collapse">
                                                        <tbody>
                                                       
                                                            <tr>
                                                                 <th  rowspan="2" style="width:60% ; border-top-style: hidden; border-left-style: hidden;border-collapse:collapse"> <asp:Label  ID="Label33"  runat="server"></asp:Label></th>
                                                                 
                                                                <td class="w-70" style="text-align: right ; border:1px solid black;border-collapse:collapse ; width:20%">المجموع / Total:</td>
                                                                <td style="text-align: right ; border:1px solid black;border-collapse:collapse ; width:10%">
                                                                    <asp:Label  ID="lblA4Subtotal"  runat="server"></asp:Label></td>
                                                            </tr>

                                                          <%--  <tr style="visibility:hidden">
                                                                <td  class="w-70" style=" visibility:hidden ; text-align: right ; border:1px solid black;border-collapse:collapse ;width:15%">Delivery Charges:</td>
                                                                <td style="text-align: right ; visibility:hidden ; border:1px solid black;border-collapse:collapse ; width:10%">
                                                                    <asp:Label  ID="lblA4Delivery"  runat="server"></asp:Label></td>
                                                            </tr>--%>

                                                            <tr>
                                                                
                                                                <td style="text-align: right ; border:1px solid black;border-collapse:collapse ;width:20%" class="w-70">خصومات  / Discount:</td>
                                                                <td style="text-align: right ; border:1px solid black;border-collapse:collapse ; width:10%">
                                                                    <asp:Label ID="lblA4Discount" runat="server"></asp:Label></td>
                                                            </tr>
                                                         
                                                            <tr>
                                                                 <th  style="width:60% ; border:1px solid black;border-collapse:collapse"> <asp:Label  ID="lblA4words"  runat="server"></asp:Label></th>
                                                                <td style="text-align: right ; border:1px solid black;border-collapse:collapse ;width:20%" class="w-70">المجموع الإجمالي/ Grand Paid:</td>
                                                                <td style="text-align: right ; border:1px solid black;border-collapse:collapse ; width:10%">
                                                                    <asp:Label ID="lblA4Grandtotal" runat="server"></asp:Label></td>
                                                            </tr>

                                                            
                                                         
                                                        </tbody>
                                                       
                                                    </table>
                                                    <br />
                                                    <table style="width: 100% ; border:1px solid black;border-collapse:collapse">
                                                        <tbody>
                                                            <tr>
                                                              <td style="width:50% ; border:1px solid black;border-collapse:collapse"><span class="muted">Receiver Name :  </span>
                                                                <span class="muted">/  تم الاستلام بواسطة : (الاسم):  </span> </td>
                                                                <td style="width:50% ; border:1px solid black;border-collapse:collapse"><span class="muted">SalesMan :   </span>
                                                                <span class="muted">/  البائع : (الاسم):  </span> </td>
                                                            </tr>

                                                            <tr> 
                                                              <td style="width:50%  ; border:1px solid black;border-collapse:collapse ; white-space:pre-line"><span class="muted">Stamp :  </span>
                                                                <span class="muted">/  ختم:  </span> </td>
                                                                <td style="width:50% ; border:1px solid black;border-collapse:collapse ; white-space:pre-line"><span class="muted">Stamp :  </span>
                                                                <span class="muted">/  ختم: </span> </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <br />

                                                    <table style="width: 100% ; border:1px solid black;border-collapse:collapse">
                                                         <tbody>
                                                            <tr>
 
                                                  <td style=" colspan="3">  <asp:Label  ID="lblNoteEnglish" Style="font-family:Calibri; font-size:medium" runat="server"></asp:Label></td>
                                                  
                                               

                                             
                                                            </tr>
                                                             <tr>
 <td> <asp:Label  ID="lblNoteArabic" Style="font-family:Calibri; font-size:small" runat="server"></asp:Label></td>
                                                             </tr>
                                                        </tbody>
                                                    </table>
                                                </section>
                                         <section class="info-area italic hidden">
                                                    <span class="text-small"><b></b>
                                                        <asp:Label ID="Label45" Style="font-family:Calibri; font-size:medium" runat="server"></asp:Label></span><br /><br />
                                                    <span class="text-small"><b></b> 
                                                    <asp:Label  ID="Label46" Style="font-family:Calibri; font-size:medium" runat="server"></asp:Label><br />
                                                        <asp:Label  ID="Label47" Style="font-family:Calibri; font-size:small" runat="server"></asp:Label>
                                                    </span>

                                                </section>

                                            <section class="listing-area payment-list hidden">
                                                    <div class="heading">
                                                        <%--<h2 class="sub-title">Payments</h2>--%>
                                                    </div>
                                                    <table   style="width: 100% ;  visibility:hidden" border="1" cellpadding="1" cellspacing="1">
                                                        <thead>
                                                            <tr>
                                                                <td style="font-family: Arial ; color:black" class="w-10 text-center">Sl.</td>
                                                                <td  style="width:60% ;font-family: Arial ; color:black" class="w-50 text-center">Payment Method</td>
                                                                <td  style="font-family: Arial ; color:black" class="w-20 text-right">Amount</td>
                                                                <td style="font-family: Arial ; color:black" class="w-20 text-right">Balance</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listpaymentA4" runat="server">

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td class="text-center" style="font-family: Arial ; color:black">1</td>
                                                                        <td style="font-family: Arial ; color:black"><%#Eval("payment_type")%></td>
                                                                        <td class="text-right" style="font-family: Arial ; color:black">
                                                                            <asp:Label ID="Label5" runat="server"><%#Eval("payment_amount")%></asp:Label></td>
                                                                        <td style="font-family: Arial ; color:black" class="text-right"><%#Eval("change_amount")%></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                    
                                                </section>


                                        </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                                   </div>
           
                                </asp:Panel>
    
      
        <!--ENd:: Chat-->
        <!-- begin::Global Config(global config for global JS sciprts) -->
        <script>
            var KTAppOptions = { "colors": { "state": { "brand": "#22b9ff", "light": "#ffffff", "dark": "#282a3c", "primary": "#5867dd", "success": "#34bfa3", "info": "#36a3f7", "warning": "#ffb822", "danger": "#fd3995" }, "base": { "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"], "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"] } } };
        </script>
    </form>
    <!-- end::Global Config -->
    <!--begin:: Global Mandatory Vendors -->
    <script src="../assetsn/vendors/general/jquery/dist/jquery.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/wnumb/wNumb.js" type="text/javascript"></script>
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->
    <script src="../assetsn/vendors/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
    <script src="../assetsn/vendors/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
   

    <script src="../assetsn/js/demo6/scripts.bundle.js" type="text/javascript"></script>
    
        <script type="text/javascript">
            $(document).ready(function () {
                ScrollDown();
            });
            function ScrollDown() {
                var divChat = document.getElementById('box');
               // alert("sahir");
                divChat.scrollTop = divChat.scrollHeight;
            }

           
          

        </script>
    
</body>
<!-- end::Body -->
</html>
