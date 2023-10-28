pnlContents<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Web.OrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--begin::Base Path (base relative path for assets of this page) -->
    <base href="../../../../">
    <!--end::Base Path -->
    <meta charset="utf-8" />

    <title>DIGITAL | POS53</title>
    <meta name="description" content="Basic datatables examples" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />
    <!--end::Fonts -->

    <!--begin::Page Vendors Styles(used by this page) -->
    <link href="assetsn/vendors/custom/datatables/datatables.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Page Vendors Styles -->


    <!--begin:: Global Mandatory Vendors -->
    <link href="assetsn/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Mandatory Vendors -->

    <!--begin:: Global Optional Vendors -->
    <link href="assetsn/vendors/general/tether/dist/css/tether.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-datetime-picker/css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-select/dist/css/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/select2/dist/css/select2.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/ion-rangeslider/css/ion.rangeSlider.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/nouislider/distribute/nouislider.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/owl.carousel/dist/assetsn/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/owl.carousel/dist/assetsn/owl.theme.default.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/dropzone/dist/dropzone.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/quill/dist/quill.snow.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/@yaireo/tagify/dist/tagify.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/summernote/dist/summernote.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/bootstrap-markdown/css/bootstrap-markdown.min.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/animate.css/animate.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/toastr/build/toastr.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/dual-listbox/dist/dual-listbox.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/morris.js/morris.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/sweetalert2/dist/sweetalert2.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Optional Vendors -->
      <link href="assetsn/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->

    <link href="assetsn/vendors/general/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/custom/vendors/flaticon2/flaticon.css" rel="stylesheet" type="text/css" />
    <link href="assetsn/vendors/general/@fortawesome/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!--begin::Global Theme Styles(used by all pages) -->
 
    <link href="assetsn/css/demo6/style.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Global Theme Styles -->

    <!--begin::Layout Skins(used by all pages) -->
    <!--end::Layout Skins -->

    <link rel="shortcut icon" href="./assetsn/media/logos/favicon.ico" />

  

    <style>
        .dt-right {
            display: none;
        }

        #drp123 {
            display: none;
        }

        #drp1234 {
            display: none;
        }

        #lastActionth {
            display: none;
        }

        #lastAction {
            display: none;
        }
    </style>
</head>
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-aside--minimize kt-page--loading">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="toolscriptmanagerID" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div>
            <!-- begin:: Page -->

            <!-- begin:: Header Mobile -->
            <div id="kt_header_mobile" class="kt-header-mobile  kt-header-mobile--fixed ">
                <div class="kt-header-mobile__logo">
                    <a href="demo6/index.html">
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


                    <!-- end:: Aside -->
                    <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor kt-wrapper" id="kt_wrapper">
                        <!-- begin:: Header -->

                        <!-- end:: Header -->
                        <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">


                            <!-- begin:: Content -->
                            <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">


                                <div class="kt-portlet kt-portlet--mobile">
                                    <div class="kt-portlet__head kt-portlet__head--lg">
                                        <div class="kt-portlet__head-label">
                                            <span class="kt-portlet__head-icon">
                                                <i class="kt-font-brand flaticon2-line-chart"></i>
                                            </span>
                                            <h3 class="kt-portlet__head-title">Order List &nbsp;
                                            </h3>
                                            <asp:Label ID="lbllistDate" runat="server"></asp:Label>
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" class="kt-header__topbar-item dropdown">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                                </Triggers>
                                                <ContentTemplate>

                                                    <asp:Timer ID="Timer1" runat="server" OnTick="GetTime" Interval="10000" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="kt-portlet__head-toolbar col-md-11" style="height: 59px;">
                                                <div class="kt-portlet__head-wrapper">
                                                    <div class="kt-portlet__head-actions">

                                                        <asp:LinkButton ID="lnkdraft" runat="server" OnClick="lnkdraft_Click">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Draft / </asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Final </asp:LinkButton>

                                                        <a href="orderList.aspx" class="btn btn-brand btn-elevate btn-icon-sm">Today
                                                        </a>
                                                        <asp:Button ID="BtnWeek" class="btn btn-brand btn-elevate btn-icon-sm" OnClick="BtnWeek_Click" runat="server" Text="This Week" />
                                                        <asp:Button ID="BtnMonth" class="btn btn-brand btn-elevate btn-icon-sm" OnClick="BtnMonth_Click" runat="server" Text="This Month" />
                                                        <asp:Button ID="BtnFull" class="btn btn-brand btn-elevate btn-icon-sm" OnClick="BtnFull_Click" runat="server" Text="Full" />
                                                         
                                                       
                                                          <a href="Newdemo.aspx" class="btn btn-brand btn-elevate btn-icon-sm">Back &nbsp;&nbsp;
                                                          </a> 
                                                        <div class="dropdown dropdown-inline">

                                                            <div class="kt-input-icon kt-input-icon--left">
                                                                <asp:TextBox runat="server" CssClass="form-control"  placeholder="Customer Search"  id="generalSearch" OnTextChanged="BtnSearchitem_Click" ></asp:TextBox>
                                                                <span class="kt-input-icon__icon kt-input-icon__icon--left">
                                                                    <span><i class="la la-search"></i></span>
                                                                  
                                                                </span>
                                                                
                                                            </div>
                                                            
                                                        </div>
                                                         <div class="dropdown dropdown-inline">

                                                            <div class="kt-input-icon kt-input-icon--left">
                                                              <button type="button" class="btn btn-brand" onclick="<%=btnHidden.ClientID %>.click()">
                                                                 <i class="la la-search" aria-hidden="true"></i>
                                                                   Search
                                                                    </button>

                                                                        <asp:Button runat="server" style="display:none;" ID="btnHidden"
                                                                          OnClick="BtnSearchitem_Click"></asp:Button>
                                                              
                                                                
                                                            </div>
                                                            
                                                        </div>
                                                      <%--   <div class="dropdown dropdown-inline">

                                                            <div class="kt-input-icon kt-input-icon--left">
                                                                <asp:TextBox runat="server" CssClass="form-control"  placeholder="Invoice Search"  id="txtinvoicesearc" OnTextChanged="BtnSearchInvoice_Click" ></asp:TextBox>
                                                                <span class="kt-input-icon__icon kt-input-icon__icon--left">
                                                                    <span><i class="la la-search"></i></span>
                                                                  
                                                                </span>
                                                                
                                                            </div>
                                                            
                                                        </div>--%>
                                                        
                                                       
                                                         
                                                    </div>
                                                </div>
                                        
                                            </div>
                                        </div>
                                        <div class="kt-portlet__head-toolbar">

                                            <div class="kt-portlet__head-wrapper">
                                                <div class="kt-portlet__head-actions">
                                                    <div class="dropdown dropdown-inline">
                                                        <br />
                                                        <br />
                                                        
                                                        <button type="button" class="btn btn-default btn-icon-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="la la-download"></i>Export  	
                                                        </button>
                                                        <div class="dropdown-menu dropdown-menu-right">
                                                            <ul class="kt-nav">
                                                                <li class="kt-nav__section kt-nav__section--first">
                                                                    <span class="kt-nav__section-text">Choose an option</span>
                                                                </li>
                                                                <li class="kt-nav__item">
                                                                    <a  class="kt-nav__link">
                                                                        <asp:LinkButton ID="btnexportToday"  runat="server"  class="la la-download btn-icon-sm btn btn-brand btn-elevate"  >Export ToDay</asp:LinkButton>
                                                                    </a>
                                                                </li>

                                                                <li class="kt-nav__item">
                                                                    <a  class="kt-nav__link">
                                                                        <asp:LinkButton ID="btnexportWeek"  runat="server"  class="la la-download btn-icon-sm btn btn-brand btn-elevate"  >Export One Week</asp:LinkButton>
                                                                    </a>
                                                                </li>
                                                                  <li class="kt-nav__item">
                                                                    <a  class="kt-nav__link">
                                                                        <asp:LinkButton ID="btnExportMonth"  runat="server"  class="la la-download btn-icon-sm btn btn-brand btn-elevate"  >Export One Month</asp:LinkButton>
                                                                    </a>
                                                                </li>
                                                              
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    &nbsp;
		<a href="fullsr.aspx" class="btn btn-brand btn-elevate btn-icon-sm">
            <i class="la la-plus"></i>
            New Record
        </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal fade" id="kt_maxlength_modal" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                                        <div class="modal-dialog modal-lg" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="">Add Driver Detail</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true" class="la la-remove"></span>
                                                    </button>
                                                </div>
                                                <div class="kt-form kt-form--fit kt-form--label-right">
                                                    <div class="modal-body">
                                                        <div class="form-group row kt-margin-t-20">
                                                            <label class="col-form-label col-lg-3 col-sm-12">Driver Name</label>
                                                            <div class="col-lg-9 col-md-9 col-sm-12">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="drpemployee" Style="width: 90%;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpemployee_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Item Name Required" ControlToValidate="drpemployee" ValidationGroup="S4"></asp:RequiredFieldValidator>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-brand" OnClick="btnsubmit_Click" />
                                                    </div>
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

                                                                                <asp:UpdatePanel ID="UpdatePanel3" class="table-responsive" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table class="table">

                                                                                            <tbody>
                                                                                                <tr>


                                                                                                    <td style="width: 20%">
                                                                                                        <span class="kt-widget11__sub">Paid Amount: 
                                                                                            <asp:Label runat="server" ID="lblPaid" Text="0"></asp:Label></span>
                                                                                                        <asp:TextBox ID="txtPopupPaidAmount" class="form-control" Text="0.00" onfocus="this.select();" onmouseup="return false;" OnTextChanged="txtPopupPaidAmount_TextChanged" AutoCompleteType="none" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td style="width: 20%">
                                                                                                        <span class="kt-widget11__sub">Balance</span>
                                                                                                        <asp:TextBox ID="txtbalance" class="form-control" Text="0.00" onfocus="this.select();" onmouseup="return false;" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td style="width: 20%">
                                                                                                        <span class="kt-widget11__sub">Pay By</span>
                                                                                                        <asp:DropDownList ID="drpPayBy" class="btn btn-label-success btn-bold btn-sm btn-icon-h" Style="height: 3rem;" runat="server">
                                                                                                            <asp:ListItem Selected="True" Value="1">CASH</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">CHEQUE</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">CREDIT CARD</asp:ListItem>
                                                                                                            <asp:ListItem Value="4">DEBIT CARD</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">KNET</asp:ListItem>
                                                                                                            <asp:ListItem Value="6">TALABAT</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td style="width: 40%">
                                                                                                        <span class="kt-widget11__sub">Referance</span>
                                                                                                        <asp:TextBox ID="txtPayReffrance" class="form-control" Placeholder="Referance..." autocomplete="off" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td><span class="kt-widget11__sub">&nbsp;</span>
                                                                                                        <asp:Button ID="btnaddpaymenttype" autocomplete="off" runat="server" Text="ADD" class="btn btn-label-brand btn-bold btn-sm" OnClick="btnaddpaymenttype_Click" />
                                                                                                        <%--<button type="button" class="btn btn-label-brand btn-bold btn-sm">ADD</button>--%></td>
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
                                                                                                <asp:ListView ID="GridPayment" runat="server">
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
                                                                                                                <span class="kt-badge kt-badge--inline kt-badge--brand">Delete </span></td>

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
                                                                                                <asp:TextBox ID="txtPaymentComment" class="form-control" Placeholder="Comment..." runat="server"></asp:TextBox></td>
                                                                                            <td>

                                                                                                <asp:Button ID="btnpopuporder" class="btn btn-label-brand btn-bold btn-sm" runat="server" Text="Place Order" OnClick="btnpopuporder_Click" />
                                                                                                <asp:Button ID="btnpopupcancel" class="btn btn-label-brand btn-bold btn-sm" runat="server" Text="Cancel" />
                                                                                        </tr>
                                                                                    </table>


                                                                                </div>
                                                                            </div>
                                                                            <!--end::Widget 11-->
                                                                        </div>
                                                                        <!--end::tab 1 content-->
                                                                        <!--begin::tab 2 content-->

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

                                    <div class="kt-portlet__body">
                                        <!--begin: Datatable -->
                                       <%-- <table class="table table-striped- table-bordered table-hover table-checkable" id="kt_table_1">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>&nbsp;</th>
                                                    <th>Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                    <th>Inv No</th>
                                                    <th>Order Type - Customer Name</th>
                                                    <th>Amount</th>
                                                    <th>Order status</th>
                                                    <th>Payment Type</th>
                                                    <th>Delivery Status </th>
                                                    <th>Action &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                    <th id="lastActionth"></th>
                                                </tr>
                                            </thead>

                                            <tbody>--%>
                                                <asp:ListView ID="grdPO" runat="server"  OnItemDataBound="grdPO_ItemDataBound" OnItemCommand="grdPO_ItemCommand" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                                                    <GroupTemplate>  
        <tr runat="server" id="itemPlaceholderContainer">  
            <td runat="server" id="itemPlaceholder"></td>  
        </tr>  
    </GroupTemplate>  
                                                     <ItemTemplate>
                                                        <tr>
                                                            <td></td>
                                                            <td>

                                                                <asp:LinkButton ID="LinkButton1" runat="server" class="kt-checkbox kt-checkbox--single kt-checkbox--solid" CommandName="chektrue" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                                    <asp:CheckBox ID="chkmyid" runat="server" class="kt-group-checkable" />
                                                                </asp:LinkButton>
                                                                <span></span>

                                                            </td>

                                                            <td>
                                                                <asp:Label ID="lblODate" runat="server" Text='<%# Eval("TRANSDATE", "{0:dd-MMM-yyyy}") %>'></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMYTRANSID" runat="server" Text='<%# Eval("MYTRANSID") %>'></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Eval("MYTRANSID") %>'></asp:Label>

                                                                <asp:Label ID="lblPSN" runat="server" Text='<%#getsuppername(Convert .ToInt32 ( Eval("CUSTVENDID"))) %>'></asp:Label>
                                                                -
                                                                <asp:Label ID="Label25" runat="server">
                                                <span runat="server"  Visible='<%# (string)Eval("Orderway") == " Order: Walk In"%>'>                                                                                 
                                                                              Walk In
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label26" runat="server">
                                                <span runat="server"   Visible='<%# (string)Eval("Orderway") == " Order: Talabat"%>'>                                                                                 
                                                                              Talabat
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label27" runat="server">
                                                <span runat="server"   Visible='<%# (string)Eval("Orderway") == " Order: Carriage"%>'>                                                                                 
                                                                              Carriage
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label28" runat="server">
                                                <span runat="server"   Visible='<%# (string)Eval("Orderway") == " Order: Home Delivery"%>'>                                                                                 
                                                                              Home Delivery
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label29" runat="server">
                                                <span runat="server"  Visible='<%# (string)Eval("Orderway") == " Order: Daining Table"%>'>                                                                                 
                                                                              Daining Table
                                                                            </span>
                                                                </asp:Label>

                                                                <asp:Label ID="lbluserid" Visible="false" runat="server" Text='<%#Eval("USERID") %>'></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TOTAMT") %>'></asp:Label>
                                                                <asp:Label ID="lblStatus" runat="server" Visible="false" Text='<%# Eval("Status") %>'></asp:Label>

                                                            </td>
                                                            <td><%-- <%# Status(Convert.ToInt32(Eval("MYTRANSID")))%>--%>
                                                                <asp:Label ID="lblorderstatus" runat="server" Text='<%# Eval("OrderStatus") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="Label7" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("OrderStatus") == "New"%>'>                                                                                 
                                                                              New
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label8" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                <span runat="server" class="btn btn-sm green" style="background-color: green;"  Visible='<%# (string)Eval("OrderStatus") == "Completed"%>'>                                                                                 
                                                                              Completed
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label15" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                <span runat="server" class="btn btn-sm green" style="background-color: yellow;"  Visible='<%# (string)Eval("OrderStatus") == "Draft"%>'>                                                                                 
                                                                              Draft
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label16" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                <span runat="server" class="btn btn-sm green" style="background-color: red;"  Visible='<%# (string)Eval("OrderStatus") == "Canceled"%>'>                                                                                 
                                                                              Canceled
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label17" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("OrderStatus") == "Returned"%>'>                                                                                 
                                                                              Returned
                                                                            </span>
                                                                </asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblpayment" runat="server" Text='<%# Eval("PaymentStatus") %>'></asp:Label>
                                                                <asp:Label ID="Label12"   runat="server">
                                                 <span runat="server"   Visible='<%# (string)Eval("PaymentStatus") == "Cash"%>'>                                                                                 
                                                                              Cash
                                                                            </span>
                                                                </asp:Label>
                                                              <%--  <asp:Label ID="Label6" Style="font-size: large;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: yellow;"  Visible='<%# (string)Eval("PaymentStatus") == "COD"%>'>                                                                                 
                                                                              COD
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label9" Style="font-size: large;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: orange;"  Visible='<%# (string)Eval("PaymentStatus") == "Talabat"%>'>                                                                                 
                                                                              Talabat
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label10" Style="font-size: large;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("PaymentStatus") == "Credit"%>'>                                                                                 
                                                                              Credit
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label11" Style="font-family:Calibri; font-size:medium;" runat="server">
                                                        <span runat="server" class="btn btn-sm green" style="background-color: lightsalmon;"  Visible='<%# (string)Eval("PaymentStatus") == "Knet"%>'>                                                                                 
                                                                              Knet
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label12" Style="font-family:Calibri; font-size:medium;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: green;"  Visible='<%# (string)Eval("PaymentStatus") == "Cash"%>'>                                                                                 
                                                                              Cash
                                                                            </span>
                                                                </asp:Label>
                                                                
                                                                <asp:Label ID="Label13" Style="font-size: large;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("PaymentStatus") == "Partial"%>'>                                                                                 
                                                                              Partial
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label14" Style="font-size: large;" runat="server">
                                                 <span runat="server" class="btn btn-sm green" style="background-color: red;"  Visible='<%# (string)Eval("PaymentStatus") == "Cancel"%>'>                                                                                 
                                                                              Cancel
                                                                            </span>
                                                                </asp:Label>

                                                            </td>--%>
                                                            <td><%-- <%# Status(Convert.ToInt32(Eval("MYTRANSID")))%>--%>
                                                                <asp:Label ID="lbldelivery" runat="server" Text='<%# Eval("DeliveryStatus") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblpt" runat="server" Text='<%# Eval("PaymentType") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblspnoo" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("DeliveryStatus") == "Under the Process"%>'>                                                                                 
                                                                              Under the Process
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label30" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightpink;"  Visible='<%# (string)Eval("DeliveryStatus") == "In Kitchen"%>'>                                                                                 
                                                                              In Kitchen
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label18" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightgray;"  Visible='<%# (string)Eval("DeliveryStatus") == "Processed"%>'>                                                                                 
                                                                              Processed
                                                                            </span>

                                                                </asp:Label>
                                                                <asp:Label ID="Label20" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightpink;"  Visible='<%# (string)Eval("DeliveryStatus") == "Driver Assign"%>'>                                                                                 
                                                                              Driver Assign
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label21" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightseagreen;"  Visible='<%# (string)Eval("DeliveryStatus") == "Driver On Way"%>'>                                                                                 
                                                                              Driver On Way 
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label22" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: green;"  Visible='<%# (string)Eval("DeliveryStatus") == "Delivered"%>'>                                                                                 
                                                                              Delivered
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label23" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: lightblue;"  Visible='<%# (string)Eval("DeliveryStatus") == "Rejected with Reason"%>'>                                                                                 
                                                                             Rejected with Reason
                                                                            </span>
                                                                </asp:Label>
                                                                <asp:Label ID="Label24" Style="width: 147px; color: black; font-size: large;" runat="server">
                                                    <span runat="server" class="btn btn-sm green" style="background-color: red;"  Visible='<%# (string)Eval("DeliveryStatus") == "Cancel With Remarks"%>'>                                                                                 
                                                                            Cancel With Remarks
                                                                            </span>
                                                                </asp:Label>

                                                            </td>
                                                            <td>
                                                                <span class="dropdown">

                                                                    <asp:LinkButton ID="LinkButton2" class="btn btn-sm btn-clean btn-icon btn-icon-md" data-toggle="dropdown" aria-expanded="false" runat="server" CommandName="Assign" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                                        <i class="la la-ellipsis-h"></i>
                                                                    </asp:LinkButton>

                                                                    <div class="dropdown-menu dropdown-menu-right" style=" position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(-32px, 27px, 0px); background-color: #ADD8E6;" x-placement="bottom-end">

                                                                        <asp:LinkButton ID="lnkassignemp"  data-toggle="modal" data-target="#kt_maxlength_modal" Style="color: black;" class="dropdown-item" runat="server" CommandName="Assign" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                           <i class="la la-edit"></i>Assign Driver </asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkpayment" class="dropdown-item" runat="server" CommandName="Assign" Style="color: black;"  CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                          <i class="la la-leaf"></i>Payment </asp:LinkButton>
                                                                        <asp:LinkButton ID="lnksalesreturn" class="dropdown-item" runat="server" Style="color: black;" CommandName="Salesreturn" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                        <i class="la la-edit"></i>Sales return</asp:LinkButton>

                                                    <%--     <asp:LinkButton ID="Linkproductreturn" class="dropdown-item" runat="server" Style="color: black;" CommandName="Productreturn" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                        <i class="la la-edit"></i>Product return</asp:LinkButton>--%>

                                                          <asp:LinkButton ID="lnkdelivery" runat="server" class="dropdown-item" CommandName="delivery" Style="color: black;" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                          <i class="la la-leaf"></i>Delivered </asp:LinkButton>
                                                                        <asp:LinkButton CommandName="btnprient" CommandArgument='<%# Eval("MYTRANSID") %>' ID="Print" Style="color: black;" class="dropdown-item" runat="server"><i class="la la-print"></i>Print</asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkbtndelete" class="dropdown-item" runat="server" Style="color: black;" OnClientClick="return confirm('Do you want to delete invoice?')" CommandName="Delete" CommandArgument='<%# Eval("MYTRANSID") %>'>
                                                           <i class="la la-remove"></i>Delete</asp:LinkButton>
                                                                    </div>
                                                                </span>
                                                                <asp:LinkButton ID="lnkbtnPurchase_Order" CommandName="Edit" CommandArgument='<%# Eval("MYTRANSID") %>' runat="server" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Edit">  <i class="la la-edit"></i></asp:LinkButton>
                                                            </td>
                                                            <td id="lastAction"></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                       <LayoutTemplate>
                                                    
        <table class="table table-striped- table-bordered table-hover table-checkable" runat="server">  
           
            <tr runat="server">  
                <td runat="server">  
                    <table  runat="server" class="table table-striped table-bordered table-hover" id="groupPlaceholderContainer">  
                         <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>&nbsp;</th>
                                                    <th>Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                    <th>Inv No</th>
                                                    <th>Order Type - Customer Name</th>
                                                    <th>Amount</th>
                                                    <th>Order status</th>
                                                    <th>Payment Type</th>
                                                    <th>Delivery Status </th>
                                                    <th>Action &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                   <%-- <th id="lastActionth"></th>--%>
                                                </tr>
                                            </thead>
                          <tr runat="server" id="groupPlaceholder"></tr>  
                    </table>  
                </td>  
            </tr>  
               
            <tr runat="server">  
             
                <td runat="server" class="pagination pull-right">  
                    <asp:DataPager runat="server"   PageSize="20" ID="DataPager1">  
                        <Fields>  
                            <asp:NextPreviousPagerField  ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>  
                            <asp:NumericPagerField NumericButtonCssClass="1px solid black" ></asp:NumericPagerField>  
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>  
                        </Fields>  
                    </asp:DataPager>  
                </td>  
            </tr>  
        </table>  
    </LayoutTemplate>  
                                                </asp:ListView>
                                         <div class="col-md-6 col-sm-12">
                                                                                <div class="dataTables_length" id="sample_1_length">
                                                                                    <label>
                                                                                        Show
                                                                                       <asp:DropDownList class="form-control input-xsmall input-inline " ID="drpShowGrid" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpShowGrid_SelectedIndexChanged">
                                                                                           <asp:ListItem Value="5" >5</asp:ListItem>
                                                                                           <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                                                                                           <asp:ListItem Value="50" >50</asp:ListItem>
                                                                                           <asp:ListItem Value="100" >100</asp:ListItem>
                                                                                       </asp:DropDownList>
                                                                                        </label>
                                                                                    </div>
                                                                                </div>     
                                           <%-- </tbody>

                                        </table>--%>
                                        <!--end: Datatable -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- end:: Page -->

            <!-- begin::Quick Panel -->
            <!-- end::Quick Panel -->

            <!-- begin::Scrolltop -->
            <div id="kt_scrolltop" class="kt-scrolltop">
                <i class="fa fa-arrow-up"></i>
            </div>
            <!-- end::Scrolltop -->
            <!-- begin::Sticky Toolbar -->

            <!-- end::Sticky Toolbar -->
            <!-- begin::Demo Panel -->




            <!--Begin:: Chat-->

            <script type="text/javascript">
                function PrintPanel() {

                    var panel = document.getElementById("<%=pnlContents.ClientID %>");
                    var printWindow = window.open('', '', 'height=400,width=400');
                  //  printWindow.document.write('<html><head><title>DIV Contents</title>');
                    printWindow.document.write('</head><body >');
                    printWindow.document.write(panel.innerHTML);
                    printWindow.document.write('</body></html>');
                    printWindow.document.close();
                    setTimeout(function () {
                        printWindow.print();
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
                                                     <asp:Image runat="server" ID="logoid" style="width:120px;height:90px ; text-align-last:center; margin-left:10px"/>
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

                                                       <div class="address-area" style="text-align:center ;margin-right:30%"">
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label10" ></asp:Label>
                                                           
                                                        </span>
                                                    
                                                    </div>
                                                        <div class="address-area" style="text-align:center ;margin-right:30%"">
                                                        <span class="info address" style="text-align:center">
                                                         
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label14" ></asp:Label>
                                                        </span>
                                                    
                                                    </div>
                                                        <div class="address-area" style="text-align:center ;margin-right:30%"">
                                                        <span class="info address" style="text-align:center">
                                                            <asp:Label runat="server"  CssClass="fa-address-card" ID="Label13" ></asp:Label>
                                                        
                                                        </span>
                                                    
                                                    </div>
                                                      
                                                       <div class="address-area" style="text-align:center ;margin-right:30%"">
                                                        <span class="info address" style="text-align:center ; margin-right:30%">
                                                           <asp:Label runat="server" CssClass="fa-store" ID="txtstore" Text=""></asp:Label>
                                                        </span>
                                                    
                                                    </div>
                                                     <br />
                                                   
                                                    
                                                            
                                                
                                                </header>
                                              

                                                <section class="info-area">
                                                    <table>
                                                        <tbody>

                                                            <tr >
                                                                <td class="w-30" style="font-family:'Bodoni MT'"><span>Invoice ID:</span></td>
                                                                <td>INV/<asp:Label ID="lblpin" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr >
                                                                <td class="w-30" style="font-family:'Bodoni MT'"><span>Date:</span></td>
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
                                                    <asp:Label  ID="Label11" style="font-family:Calibri ; font-size:medium" runat="server"></asp:Label><br />
                                                        <asp:Label  ID="Label12" style="font-family:Calibri ; font-size:small"  runat="server"></asp:Label>
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
                                                                <td  colspan="3" style="width:30% ; border:1px solid black;border-collapse:collapse">
                                                                    <asp:Label ID="lblA4InvoiceDate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                <tr style="border:1px solid black;border-collapse:collapse">
                                                    
                                                    <th rowspan="2" style="width:20% ; border:1px solid black;border-collapse:collapse ; font-weight:normal ; text-align:left"> <asp:Label  ID="Label25"  runat="server">Address / عنوان :</asp:Label></th>
                                                     <th  rowspan="2" style="width:20% ; border:1px solid black;border-collapse:collapse ; font-weight:normal"> <asp:Label  ID="lblA4CustomerAdd"  runat="server"></asp:Label></th>
                                                                

                                                                <td  style="width:15% ; border:1px solid black;border-collapse:collapse"><span class="muted">Invoice </span>
                                                                <span class="muted">/فاتورة: </span></td>
                                                                <td colspan="3" style="width:35%">
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
                                                                <td colspan="3" style="width:50% ; border:1px solid black;border-collapse:collapse"><span class="muted">SalesMan :   </span>
                                                                <span class="muted">/  البائع : (الاسم):  </span> </td>
                                                            </tr>

                                                            <tr> 
                                                              <td style="width:50%  ; border:1px solid black;border-collapse:collapse ; white-space:pre-line"><span class="muted">Stamp :  </span>
                                                                <span class="muted">/  ختم:  </span> </td>
                                                                <td colspan="4" style="width:50% ; border:1px solid black;border-collapse:collapse ; white-space:pre-line"><span class="muted">Stamp :  </span>
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
 <td  colspan="3"> <asp:Label  ID="lblNoteArabic" Style="font-family:Calibri; font-size:small" runat="server"></asp:Label></td>
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
        </div>
        <script>
            var KTAppOptions = { "colors": { "state": { "brand": "#22b9ff", "light": "#ffffff", "dark": "#282a3c", "primary": "#5867dd", "success": "#34bfa3", "info": "#36a3f7", "warning": "#ffb822", "danger": "#fd3995" }, "base": { "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"], "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"] } } };
        </script>
      
        <!-- end::Global Config -->

        <!--begin:: Global Mandatory Vendors -->
        <script src="assetsn/vendors/general/jquery/dist/jquery.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/moment/min/moment.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/wnumb/wNumb.js" type="text/javascript"></script>
        <!--end:: Global Mandatory Vendors -->

        <!--begin:: Global Optional Vendors -->
        <script src="assetsn/vendors/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/bootstrap-datepicker.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/bootstrap-timepicker.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-maxlength/src/bootstrap-maxlength.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/bootstrap-switch.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/select2/dist/js/select2.full.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/handlebars/dist/handlebars.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/inputmask/dist/inputmask/inputmask.date.extensions.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/inputmask/dist/inputmask/inputmask.numeric.extensions.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/nouislider/distribute/nouislider.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/autosize/dist/autosize.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/dropzone/dist/dropzone.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/dropzone.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/quill/dist/quill.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/@yaireo/tagify/dist/tagify.polyfills.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/@yaireo/tagify/dist/tagify.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/summernote/dist/summernote.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/markdown/lib/markdown.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/bootstrap-markdown.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/bootstrap-notify.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/jquery-validation.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/toastr/build/toastr.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/dual-listbox/dist/dual-listbox.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/raphael/raphael.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/morris.js/morris.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/vendors/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/counterup/jquery.counterup.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
        <script src="assetsn/vendors/custom/js/vendors/sweetalert2.init.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/jquery.repeater/src/lib.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/jquery.repeater/src/repeater.js" type="text/javascript"></script>
        <script src="assetsn/vendors/general/dompurify/dist/purify.js" type="text/javascript"></script>
        <!--end:: Global Optional Vendors -->

        <!--begin::Global Theme Bundle(used by all pages) -->

        <script src="assetsn/js/demo6/scripts.bundle.js" type="text/javascript"></script>
        <!--end::Global Theme Bundle -->
   
        <!--begin::Page Vendors(used by this page) -->
        <script src="assetsn/vendors/custom/datatables/datatables.bundle.js" type="text/javascript"></script>
        <!--end::Page Vendors -->

        <!--begin::Page Scripts(used by this page) -->
        <script src="assetsn/js/demo6/pages/crud/datatables/basic/basic.js" type="text/javascript"></script>
          <script>
            function openHistModal() {
                $('#PnlPayment').modal('show');
            }
        </script>
        <!--end::Page Scripts -->
    </form>
</body>
</html>
