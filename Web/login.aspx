<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" EnableViewState="True" %>

<html lang="en">
<!-- begin::Head -->
<head>
    <!--begin::Base Path (base relative path for assets of this page) -->

    <meta charset="utf-8" />

    <title>POS53 | Login </title>
    <meta name="description" content="Login page example">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Asap+Condensed:500">
    <!--end::Fonts -->
    <!--begin::Page Custom Styles(used by this page) -->
    <link href="./assetsp/css/pages/login/login-2.css" rel="stylesheet" type="text/css" />
    <!--end::Page Custom Styles -->
    <!--begin:: Global Mandatory Vendors -->
    <link href="./assetsp/vendors/general/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />
   
    <!--begin::Global Theme Styles(used by all pages) -->

    <link href="./assetsp/css/style.bundle.css" rel="stylesheet" type="text/css" />
   
    <link rel="shortcut icon" href="./assetsp/media/logos/favicon.ico" />
</head>
<!-- end::Head -->
<!-- begin::Body -->

<body class="kt-page-content-white kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--transparent kt-page--loading">
    <form id="form1" autocomplete="off" runat="server">
            <asp:ScriptManager ID="toolscriptmanagerID" runat="server">
        </asp:ScriptManager>
        <!-- begin:: Page -->
        <div class="kt-grid kt-grid--ver kt-grid--root kt-page">
            <div class="kt-grid kt-grid--hor kt-grid--root kt-login kt-login--v2 kt-login--signin" id="kt_login">
                <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" style="background-image: url(./assetsp/media//bg/bg-1.jpg);">
                    <div class="kt-grid__item kt-grid__item--fluid kt-login__wrapper">
                        <div class="kt-login__container">
                            <div class="kt-login__logo">
                                <a href="#">
                                    <img src="./assetsp/media/logos/logo-mini-2-md.png">
                                </a>
                            </div>
                            <div class="kt-login__signin">
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">Sign In</h3>

                                </div>
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">
                                        <asp:Label ID="lblusermatch"  runat="server"></asp:Label>
                                    </h3>
                                </div>
                                <div class="kt-form" style="width: 288px;">
                                    <div class="input-group">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser"  ErrorMessage="*" CssClass="Validation" ValidationGroup="submititems" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtUser" Text="sale" runat="server" onchange="securityCheck(this)"
                                            autocomplete="off" class="form-control" placeholder="Login Id" Style="color: white;" ></asp:TextBox>
                                    </div>
                                    <div class="input-group">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass" ErrorMessage="*" CssClass="Validation" ValidationGroup="submititems" ForeColor="Red"></asp:RequiredFieldValidator><!--<input class="form-control placeholder-no-fix" type="text" placeholder="Email" name="email" />-->
                                        <asp:TextBox autocomplete="off" ID="txtPass" Text="1" Style="color: white;"  runat="server"  placeholder="Password" class="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttenent" ErrorMessage="*" CssClass="Validation" ValidationGroup="submititems" ForeColor="Red"></asp:RequiredFieldValidator><!--<input class="form-control placeholder-no-fix" type="text" placeholder="Email" name="email" />-->
                                        <asp:TextBox autocomplete="off" ID="txttenent" Text="17" Style="color: white;" runat="server" placeholder="Tenent ID" class="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="row kt-login__extra">
                                        <div class="col">
                                            <label class="kt-checkbox">
                                                <asp:CheckBox ID="chkRememberPassword" runat="server" />
                                               
                                                Remember me
                                            <span></span>
                                            </label>
                                        </div>
                                        <div class="col kt-align-right">
                                            <a href="javascript:;" id="kt_login_forgot" class="kt-link kt-login__link">Forget Password ?</a>
                                        </div>
                                        <asp:HiddenField ID="hideID" runat="server" Value="" />
                                       
                                    </div>
                          
                                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <asp:Label runat="server" ID="lbllocation" Visible="false" Text="Select Location" CssClass="control-label" Style="color:red"></asp:Label>
                                   <asp:DropDownList ID="drplocation" Visible="false" AutoPostBack="true"  runat="server" CssClass="table-group-action-input form-control" style="color:white" ></asp:DropDownList>
                                       </ContentTemplate>
                                        <Triggers>
                                         <asp:AsyncPostBackTrigger ControlID="drplocation" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                        </asp:UpdatePanel>

                                    <div class="kt-login__actions">
                                        <asp:Button ID="btnLogin" runat="server" class="btn btn-pill kt-login__btn-primary" Text="Login" ValidationGroup="submititems" OnClick="btnLogin_Click" />
                                         
                                    </div>
                                </div>
                            </div>
                           

                            <div class="kt-login__signup">
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">Sign Up</h3>
                                    <div class="kt-login__desc">Enter your details to create your account:</div>
                                </div>
                                <div class="kt-login__form kt-form">
                                    <div class="input-group">
                                        <input class="form-control" type="text" placeholder="Fullname" name="fullname">
                                    </div>
                                    <div class="input-group">
                                        <input class="form-control" type="text" placeholder="Email" name="email" autocomplete="off">
                                    </div>
                                    <div class="input-group">
                                        <input class="form-control" type="password" placeholder="Password" name="password">
                                    </div>
                                    <div class="input-group">
                                        <input class="form-control" type="password" placeholder="Confirm Password" name="rpassword">
                                    </div>
                                    <div class="row kt-login__extra">
                                        <div class="col kt-align-left">
                                            <label class="kt-checkbox">
                                                <input type="checkbox" name="agree">I Agree the <a href="#" class="kt-link kt-login__link kt-font-bold">terms and conditions</a>.
                                            <span></span>
                                            </label>
                                            <span class="form-text text-muted"></span>
                                        </div>
                                    </div>
                                    <div class="kt-login__actions">
                                        <button id="kt_login_signup_submit" class="btn btn-pill kt-login__btn-primary">Sign Up</button>&nbsp;&nbsp;
                                    <button id="kt_login_signup_cancel" class="btn btn-pill kt-login__btn-secondary">Cancel</button>
                                    </div>
                                </div>
                            </div>
                            <div class="kt-login__forgot">
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">Forgotten Password ?</h3>
                                    <div class="kt-login__desc">Enter your email to reset your password:</div>
                                </div>
                                <div class="kt-form">
                                    <div class="input-group">
                                        <input class="form-control" type="text" placeholder="Email" name="email" id="kt_email" autocomplete="off">
                                    </div>
                                    <div class="kt-login__actions">
                                        <button id="kt_login_forgot_submit" class="btn btn-pill kt-login__btn-primary">Request</button>&nbsp;&nbsp;
                                    <button id="kt_login_forgot_cancel" class="btn btn-pill kt-login__btn-secondary">Cancel</button>
                                    </div>
                                </div>
                            </div>
                            <div class="kt-login__account">
                                <span class="kt-login__account-msg">Don't have an account yet ?
                                </span>&nbsp;&nbsp;
                            <a href="javascript:;" id="kt_login_signup" class="kt-link kt-link--light kt-login__account-link">Sign Up</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- end:: Page -->
    <!-- begin::Global Config(global config for global JS sciprts) -->
    <script>
        var KTAppOptions = { "colors": { "state": { "brand": "#5d78ff", "light": "#ffffff", "dark": "#282a3c", "primary": "#5867dd", "success": "#34bfa3", "info": "#36a3f7", "warning": "#ffb822", "danger": "#fd3995" }, "base": { "label": ["#c5cbe3", "#a1a8c3", "#3d4465", "#3e4466"], "shape": ["#f0f3ff", "#d9dffa", "#afb4d4", "#646c9a"] } } };
    </script>
    <!-- end::Global Config -->
    <!--begin:: Global Mandatory Vendors -->
    <script src="./assetsp/vendors/general/jquery/dist/jquery.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/popper.js/dist/umd/popper.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
   <%-- <script src="./assetsp/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>--%>
    <script src="./assetsp/vendors/general/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/sticky-js/dist/sticky.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/wnumb/wNumb.js" type="text/javascript"></script>
    <!--end:: Global Mandatory Vendors -->
    <!--begin:: Global Optional Vendors -->
    <%-- <script src="./assetsp/vendors/general/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/block-ui/jquery.blockUI.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/bootstrap-datepicker.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/bootstrap-timepicker.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-maxlength/src/bootstrap-maxlength.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/bootstrap-switch.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/select2/dist/js/select2.full.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/handlebars/dist/handlebars.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/inputmask/dist/inputmask/inputmask.date.extensions.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/inputmask/dist/inputmask/inputmask.numeric.extensions.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/nouislider/distribute/nouislider.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/autosize/dist/autosize.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/dropzone/dist/dropzone.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/dropzone.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/quill/dist/quill.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/@yaireo/tagify/dist/tagify.polyfills.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/@yaireo/tagify/dist/tagify.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/summernote/dist/summernote.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/markdown/lib/markdown.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/bootstrap-markdown.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/bootstrap-notify.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/jquery-validation.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/toastr/build/toastr.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/dual-listbox/dist/dual-listbox.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/raphael/raphael.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/morris.js/morris.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/vendors/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/counterup/jquery.counterup.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/custom/js/vendors/sweetalert2.init.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/jquery.repeater/src/lib.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/jquery.repeater/src/repeater.js" type="text/javascript"></script>
    <script src="./assetsp/vendors/general/dompurify/dist/purify.js" type="text/javascript"></script>--%>
    <!--end:: Global Optional Vendors -->
    <!--begin::Global Theme Bundle(used by all pages) -->

    <script src="./assetsp/js/scripts.bundle.js" type="text/javascript"></script>
    <!--end::Global Theme Bundle -->
    <!--begin::Page Scripts(used by this page) -->
    <script src="./assetsp/js/pages/login/login-general.js" type="text/javascript"></script>
    <!--end::Page Scripts -->
</body>
<!-- end::Body -->
  
</html>
