<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Web.ACM.Demo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Royal Hayat Hospital</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <%-- <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />--%>
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <%-- yogesh  <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/jquery-tags-input/jquery.tagsinput.css"/>
     <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.css" />
<link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
<link rel="stylesheet" type="text/css" href="../assets/global/plugins/typeahead/typeahead.css">
     <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-summernote/summernote.css">
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-datepicker/css/datepicker.css" />--%>
    <!-- END GLOBAL MANDATORY STYLES -->
    <%-- yogesh<link href="../assets/admin/pages/css/invoice.css" rel="stylesheet" type="text/css"/>
     <link href="../assets/pages/css/invoice.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/dropzone/css/dropzone.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/jstree/dist/themes/default/style.min.css" />--%>
    <!-- BEGIN PAGE LEVEL STYLES -->
    <%--   yogesh <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/bootstrap-select/bootstrap-select.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/jquery-multi-select/css/multi-select.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/datatables/extensions/Scroller/css/dataTables.scroller.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/datatables/extensions/ColReorder/css/dataTables.colReorder.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />--%>
    <!-- END PAGE LEVEL STYLES -->

    <!-- DOC: To use 'rounded corners' style just load 'components-rounded.css' stylesheet instead of 'components.css' in the below style tag -->
    <link href="../assets/global/css/components-rounded.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
    <%-- <link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
   <link href="../assets/admin/pages/css/todo.css" rel="stylesheet" type="text/css" />--%>
    <link href="../assets/admin/layout4/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout4/css/themes/light.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="../assets/admin/layout4/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="icon" href="../assets/favicon.ico" type="image/x-icon" />


    <%-- <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
    <style>
        .gethide {
            display: none;
        }

        .getshow {
            display: block;
        }
    </style>
    <style>
        .Validation {
            background: url("../assets/admin/pages/img/error-bg.png") no-repeat scroll left top transparent;
            font-size: 13px;
            height: 55px;
            left: 15%;
            color: #fff;
            padding: 12px 0 0 30px;
            position: absolute;
            top: -40px;
            width: 260px;
        }

        .modalPopup {
            padding: 1px;
            background-color: #fff;
            border: 1px solid #000;
        }

        .page-content {
            background: url(../assets/global/plugins/slider-revolution-slider/rs-plugin/assets/loader2.gif) center center no-repeat;
        }

        .demo-preview__frame {
    border: none;
    -webkit-box-flex: 1;
    -ms-flex: 1;
    flex: 1;
    position: relative;
    z-index: 1;
    width: 100%;
}
    </style>
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
                    iframe.height = 17 + iframeWin.document.documentElement.scrollHeight || iframeWin.document.body.scrollHeight;

                }
            }
        };
    </script>
    <script type="text/javascript" language="javascript">
        window.onkeydown = function (event) {
            if (event.keyCode == 8);
            return false;
        }
    </script>
    <script type="text/javascript">
        // disable back *******************************************
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", -1);
        window.onunload = function () { null };
        //*********************************************************


        //JS right click and ctrl+(n,a,j) disable
        function disableCtrlKeyCombination(e) {
            //list all CTRL + key combinations you want to disable
            var forbiddenKeys = new Array('a', 'n', 'j');

            var key;
            var isCtrl;

            if (window.event) {
                key = window.event.keyCode;     //IE
                if (window.event.ctrlKey)
                    isCtrl = true;
                else
                    isCtrl = false;
            }
            else {
                key = e.which;     //firefox

                if (e.ctrlKey)
                    isCtrl = true;
                else
                    isCtrl = false;
            }
            //Disabling F5 key
            if (key == 116) {
                alert('Key  F5 has been disabled.');
                return false;
            }
            //if ctrl is pressed check if other key is in forbidenKeys array
            if (isCtrl) {

                for (i = 0; i < forbiddenKeys.length; i++) {
                    //  alert(String.fromCharCode(key));
                    //case-insensitive comparation
                    if (forbiddenKeys[i].toLowerCase() == String.fromCharCode(key).toLowerCase()) {
                        alert('Key combination CTRL + '
                            + String.fromCharCode(key)
                            + ' has been disabled.');
                        return false;
                    }
                    if (key == 116) {
                        alert('Key combination CTRL + F5 has been disabled.');
                        return false;
                    }
                }
            }
            return true;
        }

        //Disable right mouse click Script

        var message = "Right click Disabled!";

        ///////////////////////////////////
        function clickIE4() {
            if (event.button == 2) {
                alert(message);
                return false;
            }
        }

        function clickNS4(e) {
            if (document.layers || document.getElementById && !document.all) {
                if (e.which == 2 || e.which == 3) {
                    alert(message);
                    return false;
                }
            }
        }

        if (document.layers) {
            document.captureEvents(Event.MOUSEDOWN);
            document.onmousedown = clickNS4;
        }

        else if (document.all && !document.getElementById) {
            document.onmousedown = clickIE4;
        }

        document.oncontextmenu = new Function("alert(message);return false");
    </script>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-sidebar-closed-hide-logo" onkeydown="disableF5();">
    <!-- BEGIN HEADER -->
    <form id="form1" runat="server">
        <asp:ScriptManager ID="toolscriptmanagerID" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="page-header navbar navbar-fixed-top">
                    <div class="page-header-inner">
                    </div>
                    <!-- BEGIN HEADER INNER -->
                    <div class="page-header-inner">
                        <!-- BEGIN LOGO -->
                        <div class="page-logo">
                            <a href="#">
                                <asp:Image ID="LOGOTODISPLAY" runat="server" class="logo-default" />
                                <%--<img src="../assets/logo.jpg" alt="logo" class="logo-default" style="width: 20%;" />--%>
                            </a>
                            <div class="menu-toggler sidebar-toggler">
                                <!-- DOC: Remove the above "hide" to enable the sidebar toggler button on header -->
                            </div>
                        </div>
                        <!-- END LOGO -->
                        <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                        <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse"></a>
                        <!-- END RESPONSIVE MENU TOGGLER -->
                        <!-- BEGIN PAGE ACTIONS -->
                        <!-- DOC: Remove "hide" class to enable the page header actions -->
                        <div class="page-actions">
                            <asp:ListView ID="lstmodule" runat="server" OnItemDataBound="lstmodule_ItemDataBound">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <button type="button" class="btn red-haze btn-sm dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                                            <span class="hidden-sm hidden-xs"><%# Eval("Module_Name")%>&nbsp;</span><i class="fa fa-angle-down"></i>
                                            <asp:Label ID="lblHide" runat="server" Visible="false" Text=' <%# Eval("Module_Id")%>'></asp:Label>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <asp:ListView ID="lstsubmodule" runat="server" OnItemCommand="lstsubmodule_ItemCommand">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton ID="LinkModule_Id" runat="server" CommandName="LinkModule_Id" CommandArgument='<%# Eval("Module_Id")%>'>  <i class="icon-docs"></i><%# Eval("Module_Name")%></asp:LinkButton>

                                                    </li>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <!-- END PAGE ACTIONS -->
                        <!-- BEGIN PAGE TOP -->
                        <div class="page-top">
                            <!-- BEGIN HEADER SEARCH BOX -->
                            <!-- DOC: Apply "search-form-expanded" right after the "search-form" class to have half expanded search box -->
                            <%--<div class="search-form">
                                <div class="input-group">
                                    <input type="text" class="form-control input-sm" placeholder="Search..." name="query">
                                    <span class="input-group-btn">
                                        <a href="javascript:;" class="btn submit"><i class="icon-magnifier"></i></a>
                                    </span>
                                </div>
                            </div>--%>
                            <!-- END HEADER SEARCH BOX -->
                            <!-- BEGIN TOP NAVIGATION MENU -->
                            <div class="top-menu">
                                <ul class="nav navbar-nav pull-right">


                                    <!-- END INBOX DROPDOWN -->
                                    <li class="separator hide"></li>
                                    <li class="dropdown dropdown-user dropdown-dark">
                                        <script type="text/javascript" src="https://secure.skypeassets.com/i/scom/js/skype-uri.js"></script>
                                        <div id="SkypeButton_Call_joharmandav_1">
                                            <script type="text/javascript">
                                                Skype.ui({
                                                    "name": "dropdown",
                                                    "element": "SkypeButton_Call_joharmandav_1",
                                                    "participants": ["joharmandav"],
                                                    "imageSize": 24
                                                });
                                            </script>
                                        </div>
                                    </li>
                                    <!-- BEGIN TODO DROPDOWN -->
                                    <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
                                    <li class="dropdown dropdown-extended dropdown-tasks dropdown-dark" id="header_task_bar">
                                        <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                                            <%-- <i class="icon-calendar"></i>--%>
                                            <span class="badge badge-primary">Action
                                            </span>
                                        </a>
                                        <ul class="dropdown-menu extended tasks">
                                            <li class="external">
                                                <h3>You have <span class="bold">12 pending</span> tasks</h3>
                                                <a href="page_todo.html">view all</a>
                                            </li>
                                            <li>
                                                <ul class="dropdown-menu-list scroller" style="height: 275px;" data-handle-color="#637283">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">New release v1.2 </span>
                                                                <span class="percent">30%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 40%;" class="progress-bar progress-bar-success" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">40% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">Application deployment</span>
                                                                <span class="percent">65%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 65%;" class="progress-bar progress-bar-danger" aria-valuenow="65" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">65% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">Mobile app release</span>
                                                                <span class="percent">98%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 98%;" class="progress-bar progress-bar-success" aria-valuenow="98" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">98% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">Database migration</span>
                                                                <span class="percent">10%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 10%;" class="progress-bar progress-bar-warning" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">10% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">Web server upgrade</span>
                                                                <span class="percent">58%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 58%;" class="progress-bar progress-bar-info" aria-valuenow="58" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">58% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">Mobile development</span>
                                                                <span class="percent">85%</span>
                                                            </span>
                                                            <span class="progress">
                                                                <span style="width: 85%;" class="progress-bar progress-bar-success" aria-valuenow="85" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">85% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <span class="task">
                                                                <span class="desc">New UI release</span>
                                                                <span class="percent">38%</span>
                                                            </span>
                                                            <span class="progress progress-striped">
                                                                <span style="width: 38%;" class="progress-bar progress-bar-important" aria-valuenow="18" aria-valuemin="0" aria-valuemax="100"><span class="sr-only">38% Complete</span></span>
                                                            </span>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                    </li>
                                    <!-- END TODO DROPDOWN -->
                                    <!-- BEGIN USER LOGIN DROPDOWN -->
                                    <!-- DOC: Apply "dropdown-dark" class after below "dropdown-extended" to change the dropdown styte -->
                                    <li class="dropdown dropdown-user dropdown-dark">
                                        <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true" style="padding-top: 0px; padding-bottom: 0px; padding-left: 0px;">

                                            <asp:Label class="username username-hide-on-mobile" ID="lblFirstName" runat="server"></asp:Label>
                                            <!-- DOC: Do not remove below empty space(&nbsp;) as its purposely used -->
                                            <%-- <img alt="" class="img-circle" src="..../assets/admin/layout4/img/avatar9.jpg" />--%>
                                            
                                        </a>


                                        <asp:Label ID="lblmodule" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblrole" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblusername" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbltentid" runat="server"></asp:Label>
                                        <asp:Label ID="lblpageid" runat="server"></asp:Label>
                                        <ul class="dropdown-menu dropdown-menu-default">
                                            <%--<li>
                                    <a href="extra_profile.html">
                                        <i class="icon-user"></i> My Profile
                                    </a>
                                </li>
                                <li>
                                    <a href="page_calendar.html">
                                        <i class="icon-calendar"></i> My Calendar
                                    </a>
                                </li>
                                <li>
                                    <a href="inbox.html">
                                        <i class="icon-envelope-open"></i> My Inbox <span class="badge badge-danger">
                                            3
                                        </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="page_todo.html">
                                        <i class="icon-rocket"></i> My Tasks <span class="badge badge-success">
                                            7
                                        </span>
                                    </a>
                                </li>
                                <li class="divider">
                                </li>
                                <li>
                                    <a href="extra_lock.html">
                                        <i class="icon-lock"></i> Lock Screen
                                    </a>
                                </li>--%>
                                            <li>
                                                <asp:LinkButton ID="btnLogOut" runat="server" OnClick="btnLogOut_Click"><i class="icon-key"></i> Log Out</asp:LinkButton>

                                                <asp:LinkButton ID="linkCheckIn" runat="server" OnClick="linkCheckIn_Click"><i class="icon-key"></i> Check In</asp:LinkButton>

                                                <asp:LinkButton ID="linkCheckOut" runat="server" OnClick="linkCheckOut_Click"><i class="icon-key"></i> Check Out</asp:LinkButton>

                                                <asp:LinkButton ID="linkLanguage" runat="server"><i class="icon-key"></i> Language</asp:LinkButton>
                                                <asp:LinkButton ID="linkFinalUpload" runat="server" OnClick="linkFinalUpload_Click"><i class="icon-key"></i> Update</asp:LinkButton>
                                                <asp:LinkButton ID="lintenet" runat="server"><i class="icon-key"></i> Set TenetId</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <!-- END USER LOGIN DROPDOWN -->
                                </ul>
                            </div>
                            <!-- END TOP NAVIGATION MENU -->
                        </div>
                        <!-- END PAGE TOP -->
                    </div>

                    <!-- END HEADER INNER -->
                </div>

                <asp:Panel ID="pnlMultiColoer" runat="server" Style="display: none;" DefaultButton="linkMulticoler">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="portlet box yellow">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-globe"></i>
                                        Select TenetID
                                    </div>
                                    <div class="actions btn-set">
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <div class="form-group" style="width: 717px; padding-bottom: 50px;">
                                        <div class="col-md-6">
                                            <asp:Label runat="server" ID="lblSupplier1s" class="col-md-4 control-label">Select TenetId</asp:Label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddltenet" CssClass="form-control select2me" runat="server" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label runat="server" ID="Label1" class="col-md-4 control-label">Select Location</asp:Label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddllocation" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="form-actions noborder">
                                        <asp:LinkButton ID="linkMulticoler" class="btn green-haze modalBackgroundbtn-circle" runat="server" OnClick="linkMulticoler_Click"> Save</asp:LinkButton>
                                        <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                        <asp:Button ID="Button5" runat="server" class="btn btn-default" Text="Cancel" />

                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button5" Enabled="True" PopupControlID="pnlMultiColoer" TargetControlID="lintenet"></cc1:ModalPopupExtender>

                <asp:Panel ID="Panel1" runat="server" Style="display: none;" DefaultButton="Button1">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="portlet box yellow">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-globe"></i>
                                        Msg
                                    </div>
                                    <div class="actions btn-set">
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <div class="form-group">
                                        <div class="col-md-12" style="padding-top: 10px; padding-bottom: 20px;">
                                            <asp:Label runat="server" ID="lbldiscription" Style="color: red" class="col-md-12 control-label"></asp:Label>

                                        </div>


                                    </div>
                                    <div class="form-actions noborder" style="padding-left: 70px;">

                                        <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                        <asp:Button ID="Button1" runat="server" class="btn green-haze modalBackgroundbtn-circle" Text="OK" />

                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button1" Enabled="True" PopupControlID="Panel1" TargetControlID="lintenet"></cc1:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- BEGIN CONTAINER -->
        <div class="page-container" style="padding-left: 5px; padding-top: 5px;">
            <!-- BEGIN SIDEBAR -->
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="page-sidebar-wrapper">
                        <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
                        <!-- DOC: Change data-auto-speed="200" to adjust the sub menu slide up/down speed -->
                        <div class="page-sidebar navbar-collapse collapse">
                            <ul class="page-sidebar-menu " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200" runat="server" id="stringModule" style="margin-top: -1px;">
                                <li class="start  ">

                                    <asp:Literal ID="lblDashboard" runat="server"></asp:Literal>
                                </li>
                                <asp:ListView ID="ltsMenu" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMenuHide" runat="server" Visible="false" Text=' <%# Eval("MENUID")%>'></asp:Label>
                                        <li class="start active ">
                                            <%# GetLink(Convert.ToInt32(Eval("MENUID")))%>

                                            <%# Displaysubmenu1(Convert.ToInt32(Eval("MENUID")))%>

                                        </li>

                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:ListView ID="lstMaster" runat="server">
                                    <ItemTemplate>
                                        <li class="start active ">
                                            <%# GetLink(Convert.ToInt32(Eval("MENUID")))%>
                                        </li>
                                    </ItemTemplate>

                                </asp:ListView>
                                <asp:ListView ID="lstisGloble" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# Eval("LINK")%>'>
                                                <i class="icon-docs"></i><%# Eval("MENU_NAME1")%><span class="badge badge-success">&nbsp; </span>
                                            </a>
                                        </li>
                                    </ItemTemplate>

                                </asp:ListView>


                            </ul>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- END SIDEBAR -->
            <!-- BEGIN CONTENT -->

            <div class="page-content-wrapper">
                <div class="page-content" style="padding-top: 0px; padding-left: 0px;">
                  <%--  <iframe class="demo-preview__frame" src="www.ayosoftech.com" ></iframe>--%>
                    <iframe class="demo-preview__frame" runat="server" id="ifrm" name="ifrm" ></iframe>
                    <%--<asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
                </asp:ContentPlaceHolder>--%>
                </div>
            </div>

            <!-- END CONTENT -->
        </div>
        <!-- END CONTAINER -->
        <!-- BEGIN FOOTER -->
        <div class="page-footer">
            <div class="page-footer-inner">
                2019 &copy; Royal Hayat Hospital.

 
            </div>
            <div class="scroll-to-top">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
    </form>



    <!-- END FOOTER -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
  <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/jquery-migrate.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
   
    
  
    <script src="../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/global/plugins/fuelux/js/spinner.min.js"></script>
<script type="text/javascript" src="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"></script>
<script type="text/javascript" src="../assets/global/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
<script type="text/javascript" src="../assets/global/plugins/jquery.input-ip-address-control-1.0.min.js"></script>
<script src="../assets/global/plugins/bootstrap-pwstrength/pwstrength-bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery-tags-input/jquery.tagsinput.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/bootstrap-touchspin/bootstrap.touchspin.js" type="text/javascript"></script>
<script src="../assets/global/plugins/typeahead/handlebars.min.js" type="text/javascript"></script>
<script src="../assets/global/plugins/typeahead/typeahead.bundle.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../assets/global/plugins/ckeditor/ckeditor.js"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <%--yogesh<script src="../assets/global/plugins/dropzone/dropzone.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <script src="../assets/global/plugins/bootstrap-markdown/lib/markdown.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-summernote/summernote.min.js" type="text/javascript"></script>--%>

    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <%--yogesh<script type="text/javascript" src="../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/select2/select2.min.js"></script>
     <script type="text/javascript" src="../assets/global/plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/jquery-multi-select/js/jquery.multi-select.js"></script>
    <script src="../assets/admin/pages/scripts/todo.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/datatables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/datatables/extensions/Scroller/js/dataTables.scroller.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script src="../assets/global/plugins/flot/jquery.flot.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/flot/jquery.flot.resize.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/flot/jquery.flot.categories.js" type="text/javascript"></script>
    <script src="../assets/admin/pages/scripts/ecommerce-index.js"></script>
    <script src="../assets/apps/scripts/todo-2.min.js" type="text/javascript"></script>--%>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- END PAGE LEVEL PLUGINS -->
    <%--    <script type="text/javascript" src="../assets/global/plugins/jquery-validation/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/jquery-validation/js/additional-methods.min.js"></script>
    <script type="text/javascript" src="../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script src="../assets/admin/pages/scripts/form-fileupload.js"></script>
    <link href="../assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css" rel="stylesheet" type="text/css" />
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
     <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
    <script src="../assets/admin/pages/scripts/form-validation.js"></script>
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../assets/admin/pages/scripts/ui-blockui.js"></script>
     <script src="../assets/global/plugins/jstree/dist/jstree.min.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->

    <script src="../assets/admin/pages/scripts/ui-tree.js"></script>--%>
   <%-- <script src="../assets/global/plugins/bootstrap-sessiontimeout/jquery.sessionTimeout.min.js" type="text/javascript"></script>--%>
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="../assets/global/plugins/jquery-idle-timeout/jquery.idletimeout.js" type="text/javascript"></script>
<script src="../assets/global/plugins/jquery-idle-timeout/jquery.idletimer.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
    <script src="../assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="../assets/admin/layout4/scripts/layout.js" type="text/javascript"></script>
    <script src="../assets/admin/layout4/scripts/demo.js" type="text/javascript"></script>
    <%-- yogesh <script src="../assets/admin/layout4/scripts/demo.js" type="text/javascript"></script>
   <script src="../assets/admin/pages/scripts/components-form-tools.js"></script>
    <script src="../assets/admin/pages/scripts/table-advanced.js"></script>
    <script src="../assets/admin/pages/scripts/table-editable.js"></script>
    <script src="../assets/admin/pages/scripts/components-editors.js"></script>
    <script src="../assets/admin/pages/scripts/components-dropdowns.js"></script>
    <script src="../assets/admin/pages/scripts/index3.js" type="text/javascript"></script>--%>
    <!-- BEGIN THEME LAYOUT SCRIPTS -->

    <!-- END THEME LAYOUT SCRIPTS -->


    <%-- <asp:ContentPlaceHolder ID="footer" runat="server">
    </asp:ContentPlaceHolder>--%>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script src="../assets/admin/pages/scripts/ui-idletimeout.js"></script>
    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Demo.init(); // init demo features
            // initialize session timeout settings
            UIIdleTimeout.init();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
