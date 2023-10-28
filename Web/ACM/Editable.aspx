<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="Editable.aspx.cs" Inherits="Web.ACM.Editable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- BEGIN PLUGINS USED BY X-EDITABLE -->
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/select2/select2.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-datepicker/css/datepicker.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-editable/bootstrap-editable/css/bootstrap-editable.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-editable/inputs-ext/address/address.css"/>
   
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
			<!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
			<div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
							<h4 class="modal-title">Modal title</h4>
						</div>
						<div class="modal-body">
							 Widget settings form goes here
						</div>
						<div class="modal-footer">
							<button type="button" class="btn blue">Save changes</button>
							<button type="button" class="btn default" data-dismiss="modal">Close</button>
						</div>
					</div>
					<!-- /.modal-content -->
				</div>
				<!-- /.modal-dialog -->
			</div>
			<!-- /.modal -->
			<!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
			<!-- BEGIN PAGE HEADER-->
			<!-- BEGIN PAGE HEAD -->
			<div class="page-head">
				<!-- BEGIN PAGE TITLE -->
				<div class="page-title">
					<h1>Form X-editable <small>form x-editable samples</small></h1>
				</div>
				<!-- END PAGE TITLE -->
				<!-- BEGIN PAGE TOOLBAR -->
				<div class="page-toolbar">
					<!-- BEGIN THEME PANEL -->
					<div class="btn-group btn-theme-panel">
						<a href="javascript:;" class="btn dropdown-toggle" data-toggle="dropdown">
						<i class="icon-settings"></i>
						</a>
						<div class="dropdown-menu theme-panel pull-right dropdown-custom hold-on-click">
							<div class="row">
								<div class="col-md-4 col-sm-4 col-xs-12">
									<h3>THEME</h3>
									<ul class="theme-colors">
										<li class="theme-color theme-color-default active" data-theme="default">
											<span class="theme-color-view"></span>
											<span class="theme-color-name">Dark Header</span>
										</li>
										<li class="theme-color theme-color-light" data-theme="light">
											<span class="theme-color-view"></span>
											<span class="theme-color-name">Light Header</span>
										</li>
									</ul>
								</div>
								<div class="col-md-8 col-sm-8 col-xs-12 seperator">
									<h3>LAYOUT</h3>
									<ul class="theme-settings">
										<li>
											 Theme Style
											<select class="layout-style-option form-control input-small input-sm">
												<option value="square" selected="selected">Square corners</option>
												<option value="rounded">Rounded corners</option>
											</select>
										</li>
										<li>
											 Layout
											<select class="layout-option form-control input-small input-sm">
												<option value="fluid" selected="selected">Fluid</option>
												<option value="boxed">Boxed</option>
											</select>
										</li>
										<li>
											 Header
											<select class="page-header-option form-control input-small input-sm">
												<option value="fixed" selected="selected">Fixed</option>
												<option value="default">Default</option>
											</select>
										</li>
										<li>
											 Top Dropdowns
											<select class="page-header-top-dropdown-style-option form-control input-small input-sm">
												<option value="light">Light</option>
												<option value="dark" selected="selected">Dark</option>
											</select>
										</li>
										<li>
											 Sidebar Mode
											<select class="sidebar-option form-control input-small input-sm">
												<option value="fixed">Fixed</option>
												<option value="default" selected="selected">Default</option>
											</select>
										</li>
										<li>
											 Sidebar Menu
											<select class="sidebar-menu-option form-control input-small input-sm">
												<option value="accordion" selected="selected">Accordion</option>
												<option value="hover">Hover</option>
											</select>
										</li>
										<li>
											 Sidebar Position
											<select class="sidebar-pos-option form-control input-small input-sm">
												<option value="left" selected="selected">Left</option>
												<option value="right">Right</option>
											</select>
										</li>
										<li>
											 Footer
											<select class="page-footer-option form-control input-small input-sm">
												<option value="fixed">Fixed</option>
												<option value="default" selected="selected">Default</option>
											</select>
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
					<!-- END THEME PANEL -->
				</div>
				<!-- END PAGE TOOLBAR -->
			</div>
			<!-- END PAGE HEAD -->
			<!-- BEGIN PAGE BREADCRUMB -->
			<ul class="page-breadcrumb breadcrumb">
				<li>
					<a href="index.html">Home</a>
					<i class="fa fa-circle"></i>
				</li>
				<li>
					<a href="#">Form Stuff</a>
					<i class="fa fa-circle"></i>
				</li>
				<li>
					<a href="#">Form X-editable</a>
				</li>
			</ul>
			<!-- END PAGE BREADCRUMB -->
			<!-- END PAGE HEADER-->
			<!-- BEGIN PAGE CONTENT-->
			<div class="portlet light">
				<div class="portlet-body">
					<div class="row">
						<div class="col-md-12">
							<label><input type="checkbox" id="autoopen">&nbsp;Auto-open next field</label>
							<label><input type="checkbox" id="inline">&nbsp;Inline editing</label>
							<button id="enable" class="btn blue">Enable / Disable</button>
							<hr>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12">
							<Table id="user" class="table table-bordered table-striped">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%">Username
                                        </td>
                                        <td style="width: 50%">
                                            <%--<asp:LinkButton ID="username1" runat="server" data-type="text" data-pk="1" data-placement="right" data-placeholder="Required" data-original-title="Enter your firstname">superuser</asp:LinkButton>--%>
                                            <a href="javascript:;" runat="server"  id="username" data-type="text" data-pk="1" data-original-title="Enter username"><asp:Label ID="Label1"  runat="server" ></asp:Label></a>
                                        </td>
                                        
                                        <td style="width: 35%">
                                            <span class="text-muted">Simple text field </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>First name
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="firstname" runat="server" data-type="text" data-pk="1" data-placement="right" data-placeholder="Required" data-original-title="Enter your firstname"></asp:LinkButton>
                                            <%--<a href="javascript:;" id="firstname" data-type="text" data-pk="1" data-placement="right" data-placeholder="Required" data-original-title="Enter your firstname"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Required text field, originally empty </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Sex
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="sex" runat="server" data-type="select" data-pk="1" data-value="" data-original-title="Select sex"></asp:LinkButton>
                                            <%--<a href="javascript:;" id="sex" data-type="select" data-pk="1" data-value="" data-original-title="Select sex"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Select, loaded from js array. Custom display </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Group
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="group" runat="server" data-type="select" data-pk="1" data-value="5" data-source="/groups" data-original-title="Select group">Admin</asp:LinkButton>
                                            <%--<a href="javascript:;" id="group" data-type="select" data-pk="1" data-value="5" data-source="/groups" data-original-title="Select group">Admin </a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Select, loaded from server. <strong>No buttons</strong> mode </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Status
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="status" runat="server" data-type="select" data-pk="1" data-value="0" data-source="/status" data-original-title="Select status">Active</asp:LinkButton>
                                            <%--<a href="javascript:;" id="status" data-type="select" data-pk="1" data-value="0" data-source="/status" data-original-title="Select status">Active </a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Error when loading list items </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Plan vacation?
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="vacation" runat="server" data-type="date" data-viewformat="dd.mm.yyyy" data-pk="1" data-placement="right" data-original-title="When you want vacation to start?">25.02.2013</asp:LinkButton>
                                            <%--<a href="javascript:;" id="vacation" data-type="date" data-viewformat="dd.mm.yyyy" data-pk="1" data-placement="right" data-original-title="When you want vacation to start?">25.02.2013 </a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Datepicker </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date of birth
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="dob" runat="server" data-type="combodate" data-value="1984-05-15" data-format="YYYY-MM-DD" data-viewformat="DD/MM/YYYY" data-template="D / MMM / YYYY" data-pk="1" data-original-title="Select Date of birth">25.02.2013</asp:LinkButton>
                                            <%--<a href="javascript:;" id="dob" data-type="combodate" data-value="1984-05-15" data-format="YYYY-MM-DD" data-viewformat="DD/MM/YYYY" data-template="D / MMM / YYYY" data-pk="1" data-original-title="Select Date of birth"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Date field (combodate) </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Setup event
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="event" runat="server" data-type="combodate" data-template="D MMM YYYY HH:mm" data-format="YYYY-MM-DD HH:mm" data-viewformat="MMM D, YYYY, HH:mm" data-pk="1" data-original-title="Setup event date and time"></asp:LinkButton>
                                            <%--<a href="javascript:;" id="event" data-type="combodate" data-template="D MMM YYYY HH:mm" data-format="YYYY-MM-DD HH:mm" data-viewformat="MMM D, YYYY, HH:mm" data-pk="1" data-original-title="Setup event date and time"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Datetime field (combodate) </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Meeting start
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="meeting_start" runat="server" data-type="datetime" data-pk="1" data-url="/post" data-placement="right" title="Set date & time">15/03/2013 12:45</asp:LinkButton>
                                            <%--<a href="javascript:;" id="meeting_start" data-type="datetime" data-pk="1" data-url="/post" data-placement="right" title="Set date & time">15/03/2013 12:45 </a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Bootstrap datetime </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Comments
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="comments" runat="server" data-type="textarea" data-pk="1" data-placeholder="Your comments here..." data-original-title="Enter comments">awesome<br>user!</asp:LinkButton>
                                            <%--<a href="javascript:;" id="comments" data-type="textarea" data-pk="1" data-placeholder="Your comments here..." data-original-title="Enter comments">awesome<br>
                                                user!</a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Textarea. Buttons below. Submit by <i>ctrl+enter</i>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Type State
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="state" runat="server" data-type="typeahead" data-pk="1" data-placement="right" data-original-title="Start typing State.."></asp:LinkButton>
                                            <%--<a href="javascript:;" id="state" data-type="typeahead" data-pk="1" data-placement="right" data-original-title="Start typing State.."></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Bootstrap 2.x typeahead </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fresh fruits
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="fruits" runat="server" data-type="checklist" data-value="2,3" data-original-title="Select fruits"></asp:LinkButton>
                                            <%--<a href="javascript:;" id="fruits" data-type="checklist" data-value="2,3" data-original-title="Select fruits"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Checklist </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tags
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="tags" runat="server" data-type="select2" data-pk="1" data-original-title="Enter tags">html, javascript </asp:LinkButton>
                                            <%--<a href="javascript:;" id="tags" data-type="select2" data-pk="1" data-original-title="Enter tags">html, javascript </a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Select2 (tags mode) </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Country
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="country" runat="server" data-type="select2" data-pk="1" data-value="BS" data-original-title="Select country"></asp:LinkButton>
                                            <%--<a href="javascript:;" id="country" data-type="select2" data-pk="1" data-value="BS" data-original-title="Select country"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Select2 (dropdown mode) </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Address
                                        </td>
                                        <td>
                                             <asp:LinkButton ID="address" runat="server" data-type="address" data-pk="1" data-original-title="Please, fill address"></asp:LinkButton>                                         
                                            <%--<a href="javascript:;" id="address" data-type="address" data-pk="1" data-original-title="Please, fill address"></a>--%>
                                        </td>
                                        <td>
                                            <span class="text-muted">Your custom input, several fields </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Notes
                                        </td>
                                        <td>
                                            <div id="note" data-pk="1" data-type="wysihtml5" data-toggle="manual" data-original-title="Enter notes">
                                                <h3>WYSIWYG</h3>
                                                WYSIWYG means <i>What You See Is What You Get</i>.<br>
                                                But may also refer to:
										<ul>
                                            <li>WYSIWYG (album), a 2000 album by Chumbawamba
                                            </li>
                                            <li>"Whatcha See is Whatcha Get", a 1971 song by The Dramatics
                                            </li>
                                            <li>WYSIWYG Film Festival, an annual Christian film festival
                                            </li>
                                        </ul>
                                                <i>Source:</i>
                                                <a href="http://en.wikipedia.org/wiki/WYSIWYG_%28disambiguation%29">wikipedia.org </a>
                                            </div>
                                        </td>
                                        <td>
                                            <a href="javascript:;" id="pencil">
                                                <i class="fa fa-pencil"></i>[edit] </a>
                                            <br>
                                            <span class="text-muted">Wysihtml5 (bootstrap only).<br>
                                                Toggle by another element </span>
                                        </td>
                                    </tr>
                                </tbody>
							</Table>
						</div>
					</div>
                    <div>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn blue" OnClientClick="MyFunction()" OnClick="btnsubmit_Click"/>    
                    </div>
					<div class="row">
						<div class="col-md-12">
							<h3>Console <small>(all ajax requests here are emulated)</small></h3>
							<div>
								<textarea id="console" rows="8" style="width: 70%" class="form-control"></textarea>
							</div>
						</div>
					</div>
				</div>
			</div>
			<!-- END PAGE CONTENT-->
		</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

<!-- BEGIN PAGE LEVEL PLUGINS -->
<!-- BEGIN PLUGINS USED BY X-EDITABLE -->
<script type="text/javascript" src="../../assets/global/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-datepicker/js/locales/bootstrap-datepicker.zh-CN.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/moment.min.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/jquery.mockjax.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-editable/bootstrap-editable/js/bootstrap-editable.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-editable/inputs-ext/address/address.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-editable/inputs-ext/wysihtml5/wysihtml5.js"></script>
<!-- END X-EDITABLE PLUGIN -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="../../assets/global/scripts/metronic.js" type="text/javascript"></script>
<script src="../../assets/admin/layout4/scripts/layout.js" type="text/javascript"></script>
<script src="../../assets/admin/layout4/scripts/demo.js" type="text/javascript"></script>
<script src="../../assets/admin/pages/scripts/form-editable.js"></script>
<script>
    jQuery(document).ready(function () {
        // initiate layout and plugins
        Metronic.init(); // init metronic core components
        Layout.init(); // init current layout
        Demo.init(); // init demo features
        FormEditable.init();
    });
</script>
</asp:Content>
