<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Newdemo.aspx.cs" Inherits="Web.Newdemo" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>
<html lang="en">
<!-- begin::Head -->
<head>
    <meta charset="utf-8" />
    <title>Digital | POS53
    </title>




    <meta name="description" content="Latest updates and statistic charts">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--begin::Fonts -->
 <%--   <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700">--%>
    <!--end::Fonts -->
    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="./assetsn/vendors/custom/fullcalendar/fullcalendar.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Page Vendors Styles -->
    <!--begin:: Global Mandatory Vendors -->
    <link href="./assetsn/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->
    <%--  <link href="./assetsn/vendors/general/tether/dist/css/tether.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-datetime-picker/css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-select/dist/css/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/select2/dist/css/select2.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/ion-rangeslider/css/ion.rangeSlider.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/nouislider/distribute/nouislider.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/owl.carousel/dist/assets/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/owl.carousel/dist/assets/owl.theme.default.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/dropzone/dist/dropzone.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/quill/dist/quill.snow.css" rel="stylesheet" type="text/css" />--%>
    <%--  <link href="./assetsn/vendors/general/@yaireo/tagify/dist/tagify.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/summernote/dist/summernote.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/bootstrap-markdown/css/bootstrap-markdown.min.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/animate.css/animate.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/toastr/build/toastr.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/dual-listbox/dist/dual-listbox.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/morris.js/morris.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/sweetalert2/dist/sweetalert2.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />--%>
    <link href="./assetsn/vendors/custom/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/custom/vendors/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="./assetsn/vendors/custom/vendors/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <%--  <link href="./assetsn/vendors/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />--%>
    <!--end:: Global Optional Vendors -->
    <!--begin::Global Theme Styles(used by all pages) -->

    <link href="./assetsn/css/demo6/style.bundle.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="./assetsn/media/logos/favicon.ico" />
    <script type="text/javascript">
        // <![CDATA[
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // this is the function I'm trying to replace:
        function loadIframe(iframeName, url) {
            if (window.frames[iframeName]) {
                window.frames[iframeName].location = url;
                return false;
            }
            return true;
        }


        // ]]>
    </script>
    <script type="text/javascript">
        function setIframeHeight(iframe) {
            if (iframe) {
                var iframeWin = iframe.contentWindow || iframe.contentDocument.parentWindow;
                if (iframeWin.document.body) {
                    iframe.height = 0 + iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;

                }
            }
        };
    </script>
    <style>
        .demo-preview__frame {
            border: none;
            -webkit-box-flex: 1;
            -ms-flex: 1;
            flex: 1;
            position: relative;
            z-index: 1;
            width: 100%;
            height: 100%;
        }
    </style>
    <script type="text/javascript">
        function changeClass() {
            if (document.getElementsByClassName("m-menu__item m-menu__item--submenu m-menu__item--rel").classList.contains('m-menu__item m-menu__item--submenu m-menu__item--rel')) {
                document.getElementsByClassName("m-menu__item m-menu__item--submenu m-menu__item--rel m-menu__item--open-dropdown m-menu__item--hover").classList.remove('m-menu__item m-menu__item--submenu m-menu__item--rel m-menu__item--open-dropdown m-menu__item--hover');
                document.getElementsByClassName("m-menu__item m-menu__item--submenu m-menu__item--rel").classList.add('m-menu__item m-menu__item--submenu m-menu__item--rel');
            }
        }
    </script>

    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                padding: 10px;
                min-height: 50px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>
</head>
<!-- end::Head -->
<!-- end::Body -->
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-aside--minimize kt-page--loading">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="toolscriptmanagerID" runat="server" enablepagemethods="true" >
        </asp:ScriptManager>
        <!-- begin:: Page -->
        <!-- begin:: Header Mobile -->
        <div id="kt_header_mobile" class="kt-header-mobile  kt-header-mobile--fixed ">
            <div class="kt-header-mobile__logo">
                <a href="dash.aspx" onclick="return loadIframe('ifrm', this.href)">
                    <img alt="Logo" src="./assetsn/media/logos/logo-6-sm.png" />
                </a>
            </div>
            <div class="kt-header-mobile__toolbar">
                <div class="kt-header-mobile__toolbar-toggler kt-header-mobile__toolbar-toggler--left" id="kt_aside_mobile_toggler"><span></span></div>

                <div class="kt-header-mobile__toolbar-toggler" id="kt_header_mobile_toggler"><span></span></div>
                <div class="kt-header-mobile__toolbar-topbar-toggler" id="kt_header_mobile_topbar_toggler"><i class="flaticon-more"></i></div>
            </div>
        </div>
        <!-- end:: Header Mobile -->
      <div class="kt-grid kt-grid--hor kt-grid--root">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--ver kt-page">
                <!-- begin:: Aside -->
                <button class="kt-aside-close " id="kt_aside_close_btn"><i class="la la-close"></i></button>

                <div class="kt-aside  kt-aside--fixed  kt-grid__item kt-grid kt-grid--desktop kt-grid--hor-desktop" id="kt_aside">
                    <!-- begin:: Aside Menu -->
                    <div class="kt-aside-menu-wrapper kt-grid__item kt-grid__item--fluid" id="kt_aside_menu_wrapper">
                        <div id="kt_aside_menu"
                            class="kt-aside-menu "
                            data-ktmenu-vertical="1"
                            data-ktmenu-scroll="1" data-ktmenu-dropdown-timeout="500">

                            <ul class="kt-menu__nav ">
                                <asp:ListView ID="ltsMenu" runat="server">
                                    <ItemTemplate>
                                        <li class="kt-menu__item  kt-menu__item--active" aria-haspopup="true">

                                            <asp:Literal ID="lblDashboard" runat="server"></asp:Literal>

                                        </li>
                                        <asp:Label ID="lblMenuHide" runat="server" Visible="false" Text=' <%# Eval("NodeID")%>'></asp:Label>
                                        <li class="kt-menu__item  kt-menu__item--submenu" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">
                                            <a href="javascript:;" class="kt-menu__link kt-menu__toggle">
                                                <i class="kt-menu__link-icon flaticon2-list-3"></i>
                                                <span class="kt-menu__link-text"><%# GetLname(Convert.ToInt32(Eval("NodeID")))%></span>
                                                <i class="kt-menu__ver-arrow la la-angle-right"></i>
                                            </a>

                                            <div class="kt-menu__submenu ">
                                                <span class="kt-menu__arrow"></span>
                                                <ul style="margin-left: -50px;">
                                                    <li class="kt-menu__item " aria-haspopup="true">
                                                          <span class="kt-menu__link-text">
                                                            </span></li>
                                                    <%# GetLink(Convert.ToInt32(Eval("NodeID")))%>
                                                            <%# Displaysubmenu1(Convert.ToInt32(Eval("NodeID")))%>
                                                </ul>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>

                            </ul>
                        </div>
                    </div>
                    <!-- end:: Aside Menu -->
                </div>

                <!-- end:: Aside -->
                <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor kt-wrapper" id="kt_wrapper">
                    <!-- begin:: Header -->
                    <div id="kt_header" class="kt-header kt-grid kt-grid--ver  kt-header--fixed ">
                        <!-- begin:: Aside -->
                        <div class="kt-header__brand kt-grid__item  " id="kt_header_brand">
                            <div class="kt-header__brand-logo">
                                 <%-- <div class="page-content" style="padding-right: 0px; padding-left: 0px;position:absolute;top:300px;left:50%">--%>
                                <a href="dash.aspx" >
                                    <img alt="Logo" src="Master/assetsp/media/logos/logo-mini-2-md.png" style="height: 41px;width: 98px;"/>
                                </a>
                                    <%--  </div>--%>
                            </div>
                        </div>
                        <!-- end:: Aside -->
                        <!-- begin:: Title -->
                        <h3 class="kt-header__title kt-grid__item">Applications
                        </h3>
                        <!-- end:: Title -->
                          <button class="kt-header-menu-wrapper-close" id="kt_header_menu_mobile_close_btn"><i class="la la-close"></i></button>
                        <div class="kt-header-menu-wrapper kt-grid__item kt-grid__item--fluid" id="kt_header_menu_wrapper">
                            <div id="kt_header_menu" class="kt-header-menu kt-header-menu-mobile  kt-header-menu--layout-default ">
                                <ul class="kt-menu__nav ">
                                 <% if (Session["SiteModuleID"].ToString() == "39")
                                                                       { %>
                                    <li class="kt-menu__item  kt-menu__item--active " aria-haspopup="true"><a href="dash.aspx" onclick="return loadIframe('ifrm', this.href)" class="kt-menu__link "><span class="kt-menu__link-text">Dashboard</span></a></li>
                                    <li class="kt-menu__item   "><a href="fullsr.aspx" class="kt-menu__link " ><span class="kt-menu__link-text">POS</span></a></li>
                                    <li class="kt-menu__item   "><a href="Orderlist.aspx" class="kt-menu__link " ><span class="kt-menu__link-text">Order</span></a></li>
                                    <li class="kt-menu__item   "><a href="Kitchen.aspx" class="kt-menu__link " ><span class="kt-menu__link-text">Kitchen</span></a></li>
                                   
                                    <li class="kt-menu__item   "><a href="newdayclose.aspx" class="kt-menu__link "><span class="kt-menu__link-text">Day Close</span></a></li>
                                    <%}%>
                                      <%else
                                          {%>
                                       <li class="kt-menu__item  kt-menu__item--active " aria-haspopup="true"><a href="Sales/POSIndex.aspx" onclick="return loadIframe('ifrm', this.href)" class="kt-menu__link "><span class="kt-menu__link-text">Dashboard</span></a></li>
                                    <li class="kt-menu__item   "><a href="POS/ClientTiketR.aspx" target="_blank" class="kt-menu__link " ><span class="kt-menu__link-text">Complaint</span></a></li>
                                    
                                    <%}%>
                                </ul>
                            </div>
                        </div>
                        <!-- begin: Header Menu -->
                        <button class="kt-header-menu-wrapper-close" id="kt_header_menu_mobile_close_btn"><i class="la la-close"></i></button>
                        <div class="kt-header-menu-wrapper kt-grid__item kt-grid__item--fluid" id="kt_header_menu_wrapper">
                            <div id="kt_header_menu" class="kt-header-menu kt-header-menu-mobile  kt-header-menu--layout-default ">
                               
                            </div>
                        </div>
                        <!-- end: Header Menu -->
                        <!-- begin:: Header Topbar -->
                        <div class="kt-header__topbar">
                            <!--begin: Search -->
                            <div class="kt-header__topbar-item kt-header__topbar-item--search dropdown" id="kt_quick_search_toggle">
                                <div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="10px,0px">
                                    <span class="kt-header__topbar-icon"><i class="flaticon2-search-1"></i></span>
                                </div>
                                <div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-lg">
                                    <div class="kt-quick-search kt-quick-search--dropdown kt-quick-search--result-compact" id="kt_quick_search_dropdown">
                                        <div method="get" class="kt-quick-search__form">
                                            <div class="input-group">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="flaticon2-search-1"></i></span></div>
                                                <input type="text" class="form-control kt-quick-search__input" placeholder="Search...">
                                                <div class="input-group-append"><span class="input-group-text"><i class="la la-close kt-quick-search__close"></i></span></div>
                                            </div>
                                        </div>
                                        <div class="kt-quick-search__wrapper kt-scroll" data-scroll="true" data-height="325" data-mobile-height="200">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--end: Search -->
                            <!--begin: Notifications -->
                            <div class="kt-header__topbar-item dropdown">
                                <div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="10px,0px">
                                    <span class="kt-header__topbar-icon kt-header__topbar-icon--success"><i class="flaticon2-bell-alarm-symbol"></i></span>
                                    <span class="kt-hidden kt-badge kt-badge--danger"></span>
                                </div>
                                <div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-xl">
                                    <div>
                                        <!--begin: Head -->
                                      
                                        <!--end: Head -->

                                        <div class="tab-content">
                                       <%--     <div class="tab-pane active show" id="topbar_notifications_notifications" role="tabpanel">
                                                <div class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">
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
                                                                New customer is registegreen
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
                                                            <i class="flaticon2-pie-chart kt-font-success"></i>
                                                        </div>
                                                        <div class="kt-notification__item-details">
                                                            <div class="kt-notification__item-title">
                                                                New customer is registegreen
                                                            </div>
                                                            <div class="kt-notification__item-time">
                                                                3 days ago
                                                            </div>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>--%>
                                            <div class="tab-pane" id="topbar_notifications_events" role="tabpanel">
                                                <div class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">
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
                                                                New customer is registegreen
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
                                                            <i class="flaticon2-favourite kt-font-brand"></i>
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
                                                      <%--  <div class="kt-notification__item-details">
                                                            <div class="kt-notification__item-title">
                                                                New report has been received
                                                            </div>
                                                            <div class="kt-notification__item-time">
                                                                23 hrs ago
                                                            </div>
                                                        </div>--%>2ws 
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
                                                            <i class="flaticon2-pie-chart kt-font-success"></i>
                                                        </div>
                                                        <div class="kt-notification__item-details">
                                                            <div class="kt-notification__item-title">
                                                                New customer is registegreen
                                                            </div>
                                                            <div class="kt-notification__item-time">
                                                                3 days ago
                                                            </div>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="tab-pane" id="topbar_notifications_logs" role="tabpanel">
                                                <div class="kt-grid kt-grid--ver" style="min-height: 200px;">
                                                    <div class="kt-grid kt-grid--hor kt-grid__item kt-grid__item--fluid kt-grid__item--middle">
                                                        <div class="kt-grid__item kt-grid__item--middle kt-align-center">
                                                            All caught up!
                                                        <br>
                                                            No new notifications.
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--end: Notifications -->
                            <!--begin: Quick actions -->
                       
                            <!--end: Quick actions -->
                            <!--begin: Cart -->
                          
                            <!--end: Cart-->
                            <!--begin: Language bar -->
                            <div class="kt-header__topbar-item kt-header__topbar-item--langs">
                                <div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="10px,0px">
                                    <span class="kt-header__topbar-icon kt-header__topbar-icon--brand">
                                        <img class="" src="./assetsn/media/flags/012-uk.svg" alt="" />
                                    </span>
                                </div>
                                <div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim">
                                    <ul class="kt-nav kt-margin-t-10 kt-margin-b-10">
                                        <li class="kt-nav__item kt-nav__item--active">
                                            <a href="#" class="kt-nav__link">
                                                <span class="kt-nav__link-icon">
                                                    <img src="./assetsn/media/flags/020-flag.svg" alt="" /></span>
                                                <span class="kt-nav__link-text">English</span>
                                            </a>
                                        </li>
                                        <li class="kt-nav__item">
                                            <a href="#" class="kt-nav__link">
                                                <span class="kt-nav__link-icon">
                                                    <img src="./assetsn/media/flags/016-spain.svg" alt="" /></span>
                                                <span class="kt-nav__link-text">Spanish</span>
                                            </a>
                                        </li>
                                        <li class="kt-nav__item">
                                            <a href="#" class="kt-nav__link">
                                                <span class="kt-nav__link-icon">
                                                    <img src="./assetsn/media/flags/017-germany.svg" alt="" /></span>
                                                <span class="kt-nav__link-text">German</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <!--end: Language bar -->
                            <!--begin: User bar -->
                            <div class="kt-header__topbar-item kt-header__topbar-item--user">
                                <div class="kt-header__topbar-wrapper" data-toggle="dropdown" data-offset="10px,0px">
                                    <span class="kt-hidden kt-header__topbar-welcome">Hi,</span>
                                    <span class="kt-hidden kt-header__topbar-username">Nick</span>
                                    <img class="kt-hidden" alt="Pic" src="./assetsn/media/users/300_21.jpg" />
                                    <span class="kt-header__topbar-icon kt-hidden-"><i class="flaticon2-user-outline-symbol"></i></span>
                                </div>
                                <div class="dropdown-menu dropdown-menu-fit dropdown-menu-right dropdown-menu-anim dropdown-menu-xl">
                                    <!--begin: Head -->
                                    <div class="kt-user-card kt-user-card--skin-dark kt-notification-item-padding-x" style="background-image: url(./assets/media/misc/bg-1.jpg)">
                                        <div class="kt-user-card__avatar">
                                            <img class="kt-hidden" alt="Pic" src="./assetsn/media/users/300_25.jpg" />
                                            <!--use below badge element instead the user avatar to display username's first letter(remove kt-hidden class to display it) -->
                                          <%--  <span class="kt-badge kt-badge--lg kt-badge--rounded kt-badge--bold kt-font-success">S</span>--%>
                                           <asp:Label ID="lbluser" runat="server" ></asp:Label>
                                            <br />
                                            <asp:Label ID="lblLocation" runat="server" ></asp:Label>
                                        </div>
                                       
                                    </div>
                                    <!--end: Head -->
                                    <!--begin: Navigation -->
                                    <div class="kt-notification">
                                     <%--   <a href="demo6/custom/apps/user/profile-1/personal-information.html" class="kt-notification__item">
                                            <div class="kt-notification__item-icon">
                                                <i class="flaticon2-calendar-3 kt-font-success"></i>
                                            </div>
                                            <div class="kt-notification__item-details">
                                                <div class="kt-notification__item-title kt-font-bold">
                                                    My Profile
                                                </div>
                                               
                                            </div>
                                        </a>
                                      --%>
                                     
                                    
                                     
                                        <div class="kt-notification__custom kt-space-between">
                                         

                                             <asp:Button ID="btSign" class="btn btn-secondary btn-sm btn-bold"  runat="server" Text="Sign Out" OnClick="btnLogOut_Click" />

                                           
                                        </div>
                                    </div>
                                    <!--end: Navigation -->
                                </div>
                            </div>
                            <!--end: User bar -->
                            <!--begin: Quick panel toggler -->
                          <%--  <div class="kt-header__topbar-item kt-header__topbar-item--quickpanel" data-toggle="kt-tooltip" title="Quick panel" data-placement="top">
                                <div class="kt-header__topbar-wrapper">
                                    <span class="kt-header__topbar-icon" id="kt_quick_panel_toggler_btn"><i class="flaticon2-cube-1"></i></span>
                                </div>
                            </div>--%>
                            <!--end: Quick panel toggler -->
                        </div>
                        <!-- end:: Header Topbar -->

                    </div>
                    <!-- end:: Header -->
                    <div class="m-content" style="height: 900px; padding-top: 15px;">
                        <%--<iframe runat="server" id="ifrm123" name="ifrm" frameborder="0" class="demo-preview__frame" clientidmode="Static" width="100%" height="100%" style="overflow: hidden"></iframe>--%>
                        <iframe class="demo-preview__frame" runat="server" id="ifrm" name="ifrm" style="overflow: hidden"></iframe>
                    </div>


                    <!-- begin:: Footer -->
                    <div class="kt-footer  kt-grid__item kt-grid kt-grid--desktop kt-grid--ver-desktop" id="kt_footer">
                        <div class="kt-container  kt-container--fluid ">
                            <div class="kt-footer__copyright">
                                2019&nbsp;&copy;&nbsp;<a href="http://keenthemes.com/metronic" target="_blank" class="kt-link">Keenthemes</a>
                            </div>
                            <div class="kt-footer__menu">
                                <a href="http://keenthemes.com/metronic" target="_blank" class="kt-footer__menu-link kt-link">About</a>
                                <a href="http://keenthemes.com/metronic" target="_blank" class="kt-footer__menu-link kt-link">Team</a>
                                <a href="http://keenthemes.com/metronic" target="_blank" class="kt-footer__menu-link kt-link">Contact</a>
                            </div>
                        </div>
                    </div>
                    <!-- end:: Footer -->
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
                                        New customer is registegreen
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
                                        New customer is registegreen
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
            <%--<div class="m-content" style="height: 900px; padding-top: 15px;">
                <iframe class="demo-preview__frame" runat="server" id="ifrm" name="ifrm" style="overflow: hidden"></iframe>
            </div>--%>
        </div>
        <!-- end::Quick Panel -->
        <!-- begin::Scrolltop -->
        <div id="kt_scrolltop" class="kt-scrolltop">
            <i class="fa fa-arrow-up"></i>
        </div>
        <!-- end::Scrolltop -->
        <!-- begin::Sticky Toolbar -->
      <%--  <ul class="kt-sticky-toolbar" style="margin-top: 30px;">
            <li class="kt-sticky-toolbar__item kt-sticky-toolbar__item--success" id="kt_demo_panel_toggle" data-toggle="kt-tooltip" title="POS Sales Register" data-placement="right">
                <a href="fullsr.aspx" class=""><i class="flaticon2-drop"></i></a>
            </li>
            <li class="kt-sticky-toolbar__item kt-sticky-toolbar__item--brand" data-toggle="kt-tooltip" title="Order List" data-placement="left">
                <a href="orderlist.aspx" target="_blank"><i class="flaticon2-gear"></i></a>
            </li>
            <li class="kt-sticky-toolbar__item kt-sticky-toolbar__item--warning" data-toggle="kt-tooltip" title="Documentation" data-placement="left">
                <a href="#" target="_blank"><i class="flaticon2-telegram-logo"></i></a>
            </li>

            <li class="kt-sticky-toolbar__item kt-sticky-toolbar__item--danger" id="kt_sticky_toolbar_chat_toggler" data-toggle="kt-tooltip" title="Chat" data-placement="left">
                <a href="#" data-toggle="modal" data-target="#kt_chat_modal"><i class="flaticon2-chat-1"></i></a>
            </li>
        </ul>--%>
        <!-- end::Sticky Toolbar -->
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
                        <img src="./assetsn/media/demos/preview/demo1.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo2.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo3.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo4.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo5.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo6.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo7.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo8.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo9.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo10.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo11.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo12.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo13.jpg" alt="" />
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
                        <img src="./assetsn/media/demos/preview/demo14.jpg" alt="" />
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
                                                    <img src="./assetsn/media/users/100_12.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/300_21.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/100_12.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/300_21.jpg" alt="image">
                                                </span>
                                            </div>
                                            <div class="kt-chat__text">
                                                You’ll receive notifications for all issues, pull requests!
                                            </div>
                                        </div>
                                        <div class="kt-chat__message kt-chat__message--success">
                                            <div class="kt-chat__user">
                                                <span class="kt-media kt-media--circle kt-media--sm">
                                                    <img src="./assetsn/media/users/100_12.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/300_21.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/100_12.jpg" alt="image">
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
                                                    <img src="./assetsn/media/users/300_21.jpg" alt="image">
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
                                        <div class="kt_chat__actions">
                                            <button type="button" class="btn btn-brand btn-md  btn-font-sm btn-upper btn-bold kt-chat__reply">reply</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

      
        </div>
        <!--ENd:: Chat-->
        <!-- begin::Global Config(global config for global JS sciprts) -->
        <script>
            var KTAppOptions = { "colors": { "state": { "brand": "#22b9ff", "light": "#ffffff", "dark": "#282a3c", "primary": "#5867dd", "success": "#34bfa3", "info": "#36a3f7", "warning": "#ffb822", "danger": "#fd3995" }, "base": { "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"], "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"] } } };
        </script>

              <span style="display: none" id="secondsIdle"></span>
            <asp:LinkButton ID="lnkFake" runat="server" ></asp:LinkButton>
            <cc1:ModalPopupExtender ID="mpeTimeout" BehaviorID="mpeTimeout" runat="server" PopupControlID="pnlPopup"
                TargetControlID="lnkFake" OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground"
                OnOkScript="ResetSession()">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Session Expiring!
                </div>
                <div class="body">
                    Your Session will expire in&nbsp;<span id="seconds"></span>&nbsp;seconds.<br />
                    Do you want to reset?
                </div>
                <div class="footer" align="right">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                    <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                </div>
            </asp:Panel>
            <script type="text/javascript">
                function SessionExpireAlert(timeout) {
                    var seconds = timeout / 1000;
                    document.getElementsByName("secondsIdle").innerHTML = seconds;
                    document.getElementsByName("seconds").innerHTML = seconds;
                    setInterval(function () {
                        seconds--;
                        document.getElementById("seconds").innerHTML = seconds;
                        document.getElementById("secondsIdle").innerHTML = seconds;
                    }, 1000);
                    setTimeout(function () {
                        //Show Popup before 20 seconds of timeout.
                        $find("mpeTimeout").show();
                    }, timeout - 20 * 1000);
                    setTimeout(function () {
                        window.location = "login.aspx";
                    }, timeout);
                };
                function ResetSession() {
                    //Redirect to refresh Session.
                    window.location = window.location.href;
                }
            </script>
    </form>
    <!-- end::Global Config -->
    <!--begin:: Global Mandatory Vendors -->
    <script src="./assetsn/vendors/general/jquery/dist/jquery.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/wnumb/wNumb.js" type="text/javascript"></script>
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->
    <%--<script src="./assetsn/vendors/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/bootstrap-datepicker.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/bootstrap-timepicker.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-maxlength/src/bootstrap-maxlength.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/bootstrap-switch.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/select2/dist/js/select2.full.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/handlebars/dist/handlebars.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/inputmask/dist/inputmask/inputmask.date.extensions.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/inputmask/dist/inputmask/inputmask.numeric.extensions.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/nouislider/distribute/nouislider.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/autosize/dist/autosize.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/dropzone/dist/dropzone.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/dropzone.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/quill/dist/quill.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/@yaireo/tagify/dist/tagify.polyfills.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/@yaireo/tagify/dist/tagify.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/summernote/dist/summernote.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/markdown/lib/markdown.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/bootstrap-markdown.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/bootstrap-notify.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/jquery-validation.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/toastr/build/toastr.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/dual-listbox/dist/dual-listbox.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/raphael/raphael.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/morris.js/morris.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/vendors/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/counterup/jquery.counterup.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/custom/js/vendors/sweetalert2.init.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/jquery.repeater/src/lib.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/jquery.repeater/src/repeater.js" type="text/javascript"></script>
    <script src="./assetsn/vendors/general/dompurify/dist/purify.js" type="text/javascript"></script>--%>
    <!--end:: Global Optional Vendors -->
    <!--begin::Global Theme Bundle(used by all pages) -->

    <script src="./assetsn/js/demo6/scripts.bundle.js" type="text/javascript"></script>
    <!--end::Global Theme Bundle -->
    <!--begin::Page Vendors(used by this page) -->
    <script src="./assetsn/vendors/custom/fullcalendar/fullcalendar.bundle.js" type="text/javascript"></script>
    <%--<script src="//maps.google.com/maps/api/js?key=AIzaSyBTGnKT7dt597vo9QgeQ7BFhvSRP4eiMSM" type="text/javascript"></script>--%>
    <script src="./assetsn/vendors/custom/gmaps/gmaps.js" type="text/javascript"></script>
    <!--end::Page Vendors -->
    <!--begin::Page Scripts(used by this page) -->
    <script src="./assetsn/js/demo6/pages/dashboard.js" type="text/javascript"></script>
    <!--end::Page Scripts -->

</body>
<!-- end::Body -->
</html>

