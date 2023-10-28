<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="Web_User_Mst.aspx.cs" Inherits="Web.ACM.Web_User_Mst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tabletools-dropdown-on-portlet {
            left: -90px;
            margin-top: -35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="b" runat="server">
        <div class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">
                <%-- <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <a href="index.aspx">HOME </a>
                        <i class="fa fa-circle"></i>
                    </li>
                    <li>
                        <a href="#">USER_MST </a>
                    </li>
                </ul>--%>
                <asp:Panel ID="pnlSuccessMsg" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissable">
                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlGlogle" runat="server">
                    <div class="row">

                        <div class="col-md-12">
                            <div class="form-horizontal form-row-seperated">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>Glogle Configuration  
                                        <asp:Label runat="server" ID="Label2"></asp:Label>
                                            <asp:TextBox Style="color: #333333" ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                                        </div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse"></a>
                                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                            <asp:LinkButton ID="LinkButton1" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                            <a href="javascript:;" class="remove"></a>
                                        </div>

                                    </div>
                                    <div class="portlet-body">
                                        <div class="portlet-body form">
                                            <div class="tabbable">
                                                <div class="tab-content no-space">
                                                    <div class="tab-pane active" id="tab_general11">
                                                        <div class="form-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label1" Text="Tenant Id" class="col-md-4 control-label"></asp:Label>
                                                                        <div class="col-md-8">
                                                                            <asp:DropDownList ID="drpTenentID" runat="server" OnSelectedIndexChanged="drpTenentID_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-5">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label3" Text="Location" class="col-md-4 control-label"></asp:Label>
                                                                        <div class="col-md-8">
                                                                            <asp:DropDownList ID="drpLoctionId" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drpLoctionId_SelectedIndexChanged"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server" ControlToValidate="drpLoctionId" ErrorMessage="Location Name Required." CssClass="Validation"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:Button ID="btnGO" runat="server" CssClass="btn blue dz-square" Enabled="false" Text="Go" OnClick="btnGO_Click" />
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
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-horizontal form-row-seperated">

                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Add 
                                        <asp:Label runat="server" ID="lblHeader"></asp:Label>
                                        <asp:TextBox Style="color: #333333" ID="txtHeader" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <asp:LinkButton ID="btnPagereload" OnClick="btnPagereload_Click" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                    <div class="actions btn-set">
                                        <div class="btn-group btn-group-circle btn-group-solid">
                                           <%-- <asp:Button ID="btnFirst" class="btn red" runat="server" OnClick="btnFirst_Click" Text="First" />
                                            <asp:Button ID="btnNext" class="btn green" runat="server" OnClick="btnNext_Click" Text="Next" />
                                            <asp:Button ID="btnPrev" class="btn purple" runat="server" OnClick="btnPrev_Click" Text="Prev" />
                                            <asp:Button ID="btnLast" class="btn grey-cascade" runat="server" Text="Last" OnClick="btnLast_Click" />--%>
                                        </div>
                                        <asp:Button ID="btnAdd" runat="server" class="btn green-haze btn-circle" Text="AddNew"  OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnCancel" runat="server" class="btn green-haze btn-circle" OnClick="btnCancel_Click" Text="Cancel" />
                                        <asp:Button ID="btnEditLable" runat="server" class="btn green-haze btn-circle" OnClick="btnEditLable_Click" Text="Update Label" />
                                        &nbsp;
                                        <asp:LinkButton ID="LanguageEnglish" Style="color: #fff; width: 60px; padding: 0px;" runat="server" OnClick="LanguageEnglish_Click">E&nbsp;<img src="../assets/global/img/flags/us.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="LanguageArabic" Style="color: #fff; width: 40px; padding: 0px;" runat="server" OnClick="LanguageArabic_Click">A&nbsp;<img src="../assets/global/img/flags/ae.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="LanguageFrance" Style="color: #fff; width: 50px; padding: 0px;" runat="server" OnClick="LanguageFrance_Click">F&nbsp;<img src="../assets/global/img/flags/fr.png" /></asp:LinkButton>
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <div class="portlet-body form">
                                        <div class="tabbable">
                                            <div class="tab-content no-space">
                                                <div class="tab-pane active" id="tab_general1">
                                                    <div class="form-body">

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtFIRST_NAME" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFIRST_NAME" ErrorMessage="First Name Required." CssClass="Validation" ValidationGroup="s" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblLAST_NAME1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtLAST_NAME" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblLAST_NAME2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME11s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME11s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtFIRST_NAME1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME12h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME12h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblLAST_NAME11s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME11s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtLAST_NAME1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblLAST_NAME12h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME12h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME21s" class="col-md-4 control-label" Visible="false"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME21s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtFIRST_NAME2" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblFIRST_NAME22h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFIRST_NAME22h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblLAST_NAME21s" class="col-md-4 control-label" Visible="false"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME21s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtLAST_NAME2" runat="server" CssClass="form-control" Visible="false"> </asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblLAST_NAME22h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLAST_NAME22h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    <asp:UpdatePanel ID="contry" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>


                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="color: ">
                                                                            <asp:Label runat="server" ID="lblCOUNTRY1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCOUNTRY1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                <asp:DropDownList ID="drpCOUNTRY" OnSelectedIndexChanged="drpCOUNTRY_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="table-group-action-input form-control"></asp:DropDownList>
                                                                            </div>
                                                                            <asp:Label runat="server" ID="lblCOUNTRY2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCOUNTRY2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="color: ">
                                                                            <asp:Label runat="server" ID="lblSTATE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSTATE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                <asp:DropDownList ID="drpSTATE" runat="server" CssClass=" form-control"></asp:DropDownList>
                                                                            </div>
                                                                            <asp:Label runat="server" ID="lblSTATE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSTATE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="row">

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblCITY1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCITY1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtCITY" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblCITY2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCITY2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblZIP1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtZIP1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtZIP" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblZIP2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtZIP2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblADDRESS11s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDRESS11s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:TextBox TextMode="MultiLine" ID="txtADDRESS1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblADDRESS12h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDRESS12h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblADDRESS21s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDRESS21s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:TextBox TextMode="MultiLine" ID="txtADDRESS2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblADDRESS22h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDRESS22h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblHOUSE_NO1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHOUSE_NO1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtHOUSE_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtHOUSE_NO" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblHOUSE_NO2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHOUSE_NO2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblSTREET1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSTREET1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtSTREET" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblSTREET2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSTREET2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        
                                                        
                                                        
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblPH_NO1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPH_NO1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPH_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtPH_NO" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblPH_NO2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPH_NO2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblFAX_NO1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFAX_NO1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtFAX_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtFAX_NO" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblFAX_NO2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFAX_NO2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblPINCODE_NO1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPINCODE_NO1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPINCODE_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtPINCODE_NO" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblPINCODE_NO2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPINCODE_NO2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblPOST_OFFICE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPOST_OFFICE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPOST_OFFICE" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblPOST_OFFICE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPOST_OFFICE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblPAN_NO1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPAN_NO1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPAN_NO" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtPAN_NO" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblPAN_NO2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPAN_NO2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblEMAIL_ADDRESS1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtEMAIL_ADDRESS1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtEMAIL_ADDRESS" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblEMAIL_ADDRESS2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtEMAIL_ADDRESS2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMOBILE_NUM1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMOBILE_NUM1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtMOBILE_NUM" Text="0" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtMOBILE_NUM" FilterMode="ValidChars" runat="server" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMOBILE_NUM2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMOBILE_NUM2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblUSER_TYPE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtUSER_TYPE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:DropDownList ID="drpUSER_TYPE" runat="server" CssClass="table-group-action-input form-control"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" runat="server" ControlToValidate="drpUSER_TYPE" ErrorMessage="User Type Required." CssClass="Validation" ValidationGroup="s" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblUSER_TYPE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtUSER_TYPE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                                                                               
                                                            
                                                        </div>
                                                     
                                                        <div class="row">
                                                             <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblLOGIN_ID1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLOGIN_ID1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtLOGIN_ID" runat="server" CssClass="form-control"></asp:TextBox>
                                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLOGIN_ID" ErrorMessage="Login Name Required." CssClass="Validation" ValidationGroup="s" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblLOGIN_ID2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLOGIN_ID2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblPASSWORD1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPASSWORD1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPASSWORD" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPASSWORD" ErrorMessage="Password Required." CssClass="Validation" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblPASSWORD2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPASSWORD2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>     
                                                            
                                                        </div>
                                                  
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label ID="lblUserDate" CssClass="col-md-4 control-label" runat="server" Text="Active Date"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtuserdate" autocomplete="off" CssClass="form-control" runat="server" placeholder="MM-dd-yy"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtuserdate" Format="dd-MMM-yyyy" Enabled="True"></cc1:CalendarExtender>
                                                                        <asp:Label ID="Label4" CssClass="col-md-8 control-label" runat="server" ForeColor="Red" Text="(Active Start Date)"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblTill_DT1s" class="col-md-4 control-label" Text="Till Date"></asp:Label><asp:TextBox runat="server" ID="txtTill_DT1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtTill_DT" runat="server" autocomplete="off" CssClass="form-control" placeholder="MM-dd-yy"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTill_DT" Format="dd-MMM-yyyy" Enabled="True"></cc1:CalendarExtender>
                                                                        <asp:Label ID="Label6" CssClass="col-md-8 control-label" runat="server" ForeColor="Red" Text="(Active End Date)"></asp:Label>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblTill_DT2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtTill_DT2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                          
                                                             <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label8" Text="Location" class="col-md-4 control-label"></asp:Label>
                                                                        <div class="col-md-8">
                                                                            <asp:DropDownList ID="drpLocation" runat="server" CssClass=" form-control"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="drpLocation" ErrorMessage="Location Name Required." ValidationGroup="s" CssClass="Validation"></asp:RequiredFieldValidator>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label7" CssClass="col-md-4 control-label" runat="server" Text="Default Lang"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:DropDownList ID="DrpDefaulrLang" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                    </div>                                                                    
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            

                                                                  <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="lblActiveUser" CssClass="col-md-4 control-label" runat="server" Text="Active User"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:CheckBox ID="CHKActiveUser" CssClass="checkbox-inline dl-horizontal" runat="server" Checked="true" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            
                                                                 <div class="col-md-6">
                                                                <div class="form-group">
                                                             
                                                                    <asp:Label runat="server" ID="lblREMARKS1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtREMARKS1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                         <div class="col-md-8">
                                                                        <asp:TextBox ID="txtREMARKS" runat="server" CssClass="form-control"></asp:TextBox>
                                                                   </div>
                                                                             </div>
                                                                    <asp:Label runat="server" ID="lblREMARKS2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtREMARKS2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                               
                                                                     </div>
                                                            </div>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-gift"></i>
                                                <asp:Label runat="server" ID="Label5"></asp:Label>
                                                List
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse"></a>
                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                <asp:LinkButton ID="btnlistreload" OnClick="btnlistreload_Click" runat="server"><img src="../assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>

                                                <a href="javascript:;" class="remove"></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body form">
                                            <asp:Panel runat="server" ID="pnlGrid">
                                                <div class="tab-content">
                                                    <div id="tab_1_1" class="tab-pane active">

                                                        <div class="tab-content no-space">
                                                            <div class="tab-pane active" id="tab_general2">
                                                                <div class="table-container" style="">

                                                                    <div class="portlet-body">
                                                                        <div id="sample_1_wrapper" class="dataTables_wrapper no-footer">

                                                                            <div class="row">
                                                                                <div class="col-md-6 col-sm-12">
                                                                                    <div class="dataTables_length" id="sample_1_length">
                                                                                        <label>
                                                                                            Show
                                                                                       <asp:DropDownList class="form-control input-xsmall input-inline " ID="drpShowGrid" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpShowGrid_SelectedIndexChanged">
                                                                                           <asp:ListItem Value="5" Selected="True">5</asp:ListItem>
                                                                                           <asp:ListItem Value="15">15</asp:ListItem>
                                                                                           <asp:ListItem Value="20">20</asp:ListItem>
                                                                                           <asp:ListItem Value="30">30</asp:ListItem>
                                                                                           <asp:ListItem Value="40">40</asp:ListItem>
                                                                                           <asp:ListItem Value="50">50</asp:ListItem>
                                                                                           <asp:ListItem Value="100">100</asp:ListItem>
                                                                                       </asp:DropDownList>
                                                                                           
                                                                                                entries</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-6 col-sm-12">
                                                                                    <div id="sample_1_filter" class="dataTables_filter">
                                                                                        <label>Search:<input type="search" class="form-control input-small input-inline" placeholder="" aria-controls="sample_1"></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="table-scrollable">
                                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table class="table table-striped table-bordered table-hover dataTable no-footer" role="grid" aria-describedby="sample_1_info">
                                                                                            <thead>
                                                                                                <tr>

                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhFIRST_NAME" Text="First Name"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhLAST_NAME" Text="Last Name"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhCITY" Text="City"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhPH_NO" Text="Phone No"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhLOGIN_ID" Text="Login  Name"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhPASSWORD" Text="Password"></asp:Label></th>
                                                                                                    <th>
                                                                                                        <asp:Label runat="server" ID="lblhUSER_TYPE" Text="User Type"></asp:Label></th>

                                                                                                    <th style="width: 60px;">ACTION</th>
                                                                                                </tr>
                                                                                            </thead>
                                                                                            <tbody>
                                                                                                <asp:ListView ID="Listview1" runat="server" OnItemCommand="Listview1_ItemCommand" DataKey="FIRST_NAME,LAST_NAME,FIRST_NAME1,LAST_NAME1,FIRST_NAME2,LAST_NAME2,LOGIN_ID,PASSWORD,USER_TYPE,REMARKS,Avtar,CompId" DataKeyNames="FIRST_NAME,LAST_NAME,FIRST_NAME1,LAST_NAME1,FIRST_NAME2,LAST_NAME2,LOGIN_ID,PASSWORD,USER_TYPE,REMARKS,Avtar,CompId">
                                                                                                    <LayoutTemplate>
                                                                                                        <tr id="ItemPlaceholder" runat="server">
                                                                                                        </tr>
                                                                                                    </LayoutTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <tr>

                                                                                                            <td>
                                                                                                                <asp:Label ID="lblFIRST_NAME" runat="server" Text='<%# Eval("FIRST_NAME")%>'></asp:Label>
                                                                                                                 <asp:Label ID="lblUSERID" runat="server" Visible="false" Text='<%# Eval("USER_DETAIL_ID")%>'></asp:Label>
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblLAST_NAME" runat="server" Text='<%# Eval("LAST_NAME")%>'></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblCITY" runat="server" Text='<%#getcity(Convert.ToInt32( Eval("USER_DETAIL_ID")))%>'></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblPH_NO" runat="server" Text='<%#getPhonnumber(Convert.ToInt32( Eval("USER_DETAIL_ID")))%>'></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblLOGIN_ID" runat="server" Text='<%# Eval("LOGIN_ID")%>'></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblPASSWORD" runat="server" Text='<%# Eval("PASSWORD")%>'></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUSER_TYPE" runat="server" Text='<%#getUserType(Convert.ToInt32( Eval("USER_TYPE")))%>'></asp:Label></td>

                                                                                                            <td>
                                                                                                                <table>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("USER_ID")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                                                                                        <td>
                                                                                                                            <asp:LinkButton ID="btnDelete" CommandName="btnDelete" OnClientClick="return ConfirmMsg();" CommandArgument='<%# Eval("USER_ID")%>' runat="server" class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i></asp:LinkButton></td>
                                                                                                                        
                                                                                                                    </tr>
                                                                                                                </table>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </ItemTemplate>
                                                                                                </asp:ListView>

                                                                                            </tbody>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                            <div class="row">
                                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="col-md-5 col-sm-12">
                                                                                            <div class="dataTables_info" id="sample_1_info" role="status" aria-live="polite">
                                                                                                <asp:Label ID="lblShowinfEntry" runat="server"></asp:Label>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <div class="col-md-7 col-sm-12">
                                                                                    <div class="dataTables_paginate paging_simple_numbers" id="sample_1_paginate">
                                                                                      
                                                                                        <ul class="pagination">
                                                                                            <li class="paginate_button first " aria-controls="sample_1" tabindex="0" id="sample_1_fist">
                                                                                             
                                                                                                <asp:LinkButton ID="btnfirst1" OnClick="btnfirst_Click" runat="server"> First</asp:LinkButton>
                                                                                            </li>
                                                                                            <li class="paginate_button first " aria-controls="sample_1" tabindex="0" id="sample_1_Next">
                                                                                                
                                                                                                <asp:LinkButton ID="btnNext1" OnClick="btnNext1_Click" runat="server"> Next</asp:LinkButton>
                                                                                            </li>
                                                                                            <asp:ListView ID="ListView2" runat="server" OnItemCommand="ListView2_ItemCommand" OnItemDataBound="AnswerList_ItemDataBound">
                                                                                                <ItemTemplate>
                                                                                                    <td>
                                                                                                        <li class="paginate_button " aria-controls="sample_1" tabindex="0">
                                                                                                            <asp:LinkButton ID="LinkPageavigation" runat="server" CommandName="LinkPageavigation" CommandArgument='<%# Eval("ID")%>'> <%# Eval("ID")%></asp:LinkButton></li>

                                                                                                    </td>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                            <li class="paginate_button next" aria-controls="sample_1" tabindex="0" id="sample_1_Previos">
                                                                                                <asp:LinkButton ID="btnPrevious1" OnClick="btnPrevious1_Click" runat="server"> Prev</asp:LinkButton>
                                                                                            </li>
                                                                                            <li class="paginate_button next" aria-controls="sample_1" tabindex="0" id="sample_1_last">
                                                                                                <asp:LinkButton ID="btnLast1" OnClick="btnLast1_Click" runat="server"> Last</asp:LinkButton>
                                                                                            </li>
                                                                                        </ul>
                                                                                        
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <asp:HiddenField ID="hideID" runat="server" Value="" />
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnfirst1" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnNext1" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnPrevious1" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnLast1" EventName="Click" />
                                </Triggers>

                            </asp:UpdatePanel>--%>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="portlet box green-haze">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-globe"></i>
                                                <asp:Label runat="server" ID="Label5"></asp:Label>
                                                List
                                            </div>
                                            <div class="tools">
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <table class="table table-striped table-bordered table-hover" id="sample_1">
                                                <thead>
                                                    <tr>

                                                        <th>
                                                            <asp:Label runat="server" ID="lblhFIRST_NAME" Text="First Name"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhLAST_NAME" Text="Last Name"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhCITY" Text="Location"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhPH_NO" Text="Phone No"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhLOGIN_ID" Text="Login  Name"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhPASSWORD" Text="Password"></asp:Label></th>
                                                        <th>
                                                            <asp:Label runat="server" ID="lblhUSER_TYPE" Text="User Type"></asp:Label></th>

                                                        <th style="width: 60px;">ACTION</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:ListView ID="Listview1" runat="server" OnItemCommand="Listview1_ItemCommand" DataKey="FIRST_NAME,LAST_NAME,FIRST_NAME1,LAST_NAME1,FIRST_NAME2,LAST_NAME2,LOGIN_ID,PASSWORD,USER_TYPE,REMARKS,Avtar,CompId" DataKeyNames="FIRST_NAME,LAST_NAME,FIRST_NAME1,LAST_NAME1,FIRST_NAME2,LAST_NAME2,LOGIN_ID,PASSWORD,USER_TYPE,REMARKS,Avtar,CompId">
                                                        <LayoutTemplate>
                                                            <tr id="ItemPlaceholder" runat="server">
                                                            </tr>
                                                        </LayoutTemplate>
                                                        <ItemTemplate>
                                                            <tr>

                                                                <td>
                                                                    <asp:Label ID="lblFIRST_NAME" runat="server" Text='<%# Eval("FIRST_NAME")%>'></asp:Label>
                                                                    <asp:Label ID="lblUSERID" runat="server" Visible="false" Text='<%# Eval("USER_DETAIL_ID")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLAST_NAME" runat="server" Text='<%# Eval("LAST_NAME")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblCITY" runat="server" Text='<%# Eval("LOCNAME1")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblPH_NO" runat="server" Text='<%#getPhonnumber(Convert.ToInt32( Eval("USER_DETAIL_ID")))%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblLOGIN_ID" runat="server" Text='<%# Eval("LOGIN_ID")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblPASSWORD" runat="server" Text='<%# Eval("PASSWORD")%>'></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblUSER_TYPE" runat="server" Text='<%#getUserType(Convert.ToInt32( Eval("USER_TYPE")))%>'></asp:Label></td>

                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("USER_ID")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                                            <td>
                                                                                <asp:LinkButton ID="btnDelete" CommandName="btnDelete" OnClientClick="return ConfirmMsg();" CommandArgument='<%# Eval("USER_ID")%>' runat="server" class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i></asp:LinkButton></td>
                                                                            <td>
                                                                                <asp:LinkButton ID="LnkChange" runat="server" class="btn btn-sm red filter-cancel">Change Password</asp:LinkButton>

                                                                                <asp:Panel ID="pnlresponsive1" Style="padding: 1px; background-color: #fff; border: 1px solid #000; display: none" runat="server">
                                                                                    <div class="modal-dialog" style="position: fixed; left: 20%; top: 10%; width: 50%;">
                                                                                        <div class="modal-content">
                                                                                            <div class="row">
                                                                                                <%--style="position: fixed; left: 10%; top: 400px;" style="position: fixed; left: 0%; top: 400px;"--%>

                                                                                                <div class="col-md-12">
                                                                                                    <div class="portlet box green">
                                                                                                        <div class="portlet-title">
                                                                                                            <div class="caption">
                                                                                                                <i class="fa fa-globe"></i>
                                                                                                                <asp:Label runat="server" ID="Label20" Text='Change Password of - ' ForeColor="White"></asp:Label>
                                                                                                                <asp:Label runat="server" ID="Label21" Text='<%# Eval("FIRST_NAME")%>' ForeColor="White"></asp:Label>


                                                                                                            </div>

                                                                                                            <div class="tools">
                                                                                                                <a id="shlinkProductDetails" runat="server" href="javascript:;" class="collapse"></a>
                                                                                                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                                                                                <a href="javascript:;" class="reload"></a>
                                                                                                                <a href="javascript:;" class="remove"></a>
                                                                                                            </div>

                                                                                                            <div class="actions btn-set">

                                                                                                                <asp:LinkButton ID="lnkSetpass" class="btn blue" runat="server" CommandName="btnChangepass" CommandArgument='<%# Eval("USER_ID")%>'>Save</asp:LinkButton>


                                                                                                            </div>

                                                                                                        </div>
                                                                                                        <div class="portlet-body">
                                                                                                            <div class="form-group">
                                                                                                                <div class="col-md-12">
                                                                                                                    <asp:Panel ID="penalmsg" runat="server" Visible="false">
                                                                                                                        <div class="alert alert-danger alert-dismissable">
                                                                                                                            <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                                                                                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                                                                        </div>
                                                                                                                    </asp:Panel>


                                                                                                                    <div class="col-md-12">
                                                                                                                        <div class="col-md-6">New Password</div>

                                                                                                                        <div class="col-md-6">
                                                                                                                            <asp:TextBox ID="txtpass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                                            <asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password" ValidationGroup="btnChangepass" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                                                                                                        </div>

                                                                                                                    </div>

                                                                                                                    <div class="col-md-12">
                                                                                                                        <div class="col-md-6">Conform Password</div>

                                                                                                                        <div class="col-md-6">
                                                                                                                            <asp:TextBox ID="txtconpass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="Validation" ControlToValidate="txtconpass" ValidationGroup="btnChangepass" ErrorMessage="Enter Confirm PassWord"></asp:RequiredFieldValidator>
                                                                                                                        </div>
                                                                                                                    </div>

                                                                                                                    <div class="col-md-12">
                                                                                                                        <asp:LinkButton ID="lnkSetpass1" class="btn blue" runat="server" CommandName="btnChangepass" CommandArgument='<%# Eval("USER_ID")%>'>Save</asp:LinkButton>

                                                                                                                        <asp:Button ID="btncancel" runat="server" CssClass="btn red" Text="Cancel" />
                                                                                                                    </div>


                                                                                                                </div>
                                                                                                            </div>

                                                                                                            <%-- <div class="form-actions noborder">
                                                                                                   
                                                                                                </div>--%>
                                                                                                        </div>

                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                                                                                        BackgroundCssClass="modalBackground" CancelControlID="btncancel" Enabled="True"
                                                                                        PopupControlID="pnlresponsive1" TargetControlID="LnkChange">
                                                                                    </cc1:ModalPopupExtender>
                                                                                </asp:Panel>
                                                                            </td>


                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:ListView>

                                                </tbody>
                                            </table>
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
    <%--    <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10"
        runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server"
                    Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server"
                    ImageAlign="Middle" ImageUrl="assets/admin/layout4/img/loading.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>
