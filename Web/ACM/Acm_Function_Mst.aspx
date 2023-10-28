<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="Acm_Function_Mst.aspx.cs" Inherits="Web.ACM.Acm_Function_Mst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .tabletools-dropdown-on-portlet {
            left: -90px;
            margin-top: -35px;
        }
    </style>
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }

        #UpdateProgress1 {
            background-color: #fff;
            border: 1px solid #000;
            left: 400.5px;
            overflow: auto;
            padding: 1px;
            position: fixed;
            top: 500px;
            z-index: 100001;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>--%>
    <div id="b" runat="server">
        <div class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">

                <asp:Panel ID="pnlSuccessMsg" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissable">
                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </asp:Panel>

                <%--<asp:Panel ID="PNALGOL" runat="server" Visible="false">
                    <div class="row">

                        <div class="col-md-12">
                            <div class="form-horizontal form-row-seperated">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>Glogle Configuration 
                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                            <asp:TextBox Style="color: #333333" ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
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
                                                    <div class="tab-pane active" id="tab_general21">
                                                        <div class="form-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label2" class="col-md-4 control-label">Tenant ID</asp:Label><asp:TextBox runat="server" ID="TextBox2" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                            <asp:DropDownList ID="DrpTENANT_ID" runat="server" OnSelectedIndexChanged="DrpTENANT_ID_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>                                                                            
                                                                        </div>
                                                                        <asp:Label runat="server" ID="Label3" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox3" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-5">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label4" class="col-md-4 control-label">Location ID</asp:Label><asp:TextBox runat="server" ID="TextBox4" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                            <asp:DropDownList Enabled="false" ID="drplocation" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drplocation_SelectedIndexChanged"></asp:DropDownList>                                                                            
                                                                        </div>
                                                                        <asp:Label runat="server" ID="Label12" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox11" class="col-md-4 control-label" Visible="false"></asp:TextBox>
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
                </asp:Panel>--%>
                <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>--%>
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
                                        <asp:LinkButton ID="btnPagereload" OnClick="btnPagereload_Click" runat="server"><img src="../assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                    <div class="actions btn-set">
                                        <div class="btn-group btn-group-circle btn-group-solid">
                                            <asp:Button ID="btnFirst" class="btn red" runat="server" OnClick="btnFirst_Click" Text="First" />
                                            <asp:Button ID="btnNext" class="btn green" runat="server" OnClick="btnNext_Click" Text="Next" />
                                            <asp:Button ID="btnPrev" class="btn purple" runat="server" OnClick="btnPrev_Click" Text="Prev" />
                                            <asp:Button ID="btnLast" class="btn grey-cascade" runat="server" Text="Last" OnClick="btnLast_Click" />
                                        </div>
                                        <asp:Button ID="btnAdd" runat="server" class="btn green-haze btn-circle" ValidationGroup="submit" Text="AddNew" OnClick="btnAdd_Click" />
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

                                                        <asp:UpdatePanel ID="update1" runat="server">
                                                            <ContentTemplate>
                                                                <%-- <div class="row">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group" style="color: ">
                                                                                    <asp:Label runat="server" ID="Label1" class="col-md-4 control-label">Tenant ID</asp:Label><asp:TextBox runat="server" ID="TextBox1" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                        <asp:DropDownList ID="DrpTENANT_ID" runat="server" OnSelectedIndexChanged="DrpTENANT_ID_SelectedIndexChanged" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                                       
                                                                                    </div>
                                                                                    <asp:Label runat="server" ID="Label2" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox2" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <div class="form-group" style="color: ">
                                                                                    <asp:Label runat="server" ID="Label3" class="col-md-4 control-label">Location ID</asp:Label><asp:TextBox runat="server" ID="TextBox3" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                        <asp:DropDownList ID="drplocation" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drplocation_SelectedIndexChanged"></asp:DropDownList>
                                                                                     
                                                                                    </div>
                                                                                    <asp:Label runat="server" ID="Label4" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox4" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>--%>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="color: ">
                                                                            <asp:Label runat="server" ID="lblMODULE_ID1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMODULE_ID1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                <asp:DropDownList ID="drpMODULE_ID" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drpMODULE_ID_SelectedIndexChanged"></asp:DropDownList>
                                                                            </div>
                                                                            <asp:Label runat="server" ID="lblMODULE_ID2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMODULE_ID2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="color: ">
                                                                            <asp:Label runat="server" ID="lblMENU_LOCATION1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_LOCATION1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            <div class="col-md-8">
                                                                                <asp:DropDownList ID="drpMenuLocation" OnSelectedIndexChanged="drpMenuLocation_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="table-group-action-input form-control input-medium">
                                                                                    <asp:ListItem Value="0">---Select-----</asp:ListItem>
                                                                                    <asp:ListItem Value="Separator">Separator</asp:ListItem>
                                                                                    <asp:ListItem Value="Left Menu">Left Menu</asp:ListItem>
                                                                                    <asp:ListItem Value="Is Globle">Is Globle</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <asp:Label runat="server" ID="lblMENU_LOCATION2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_LOCATION2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group" style="color: ">
                                                                            <asp:Label runat="server" ID="Label10" class="col-md-4 control-label">User</asp:Label><asp:TextBox runat="server" ID="TextBox9" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                <asp:DropDownList ID="DrpUser" runat="server" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                            </div>
                                                                            <asp:Label runat="server" ID="Label11" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox10" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                                <asp:Panel class="row" ID="MenuSepret" runat="server" Visible="false">
                                                                    <fieldset style="margin-bottom: 10px;">
                                                                        <legend>Menu Leveling</legend>
                                                                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                            <ContentTemplate>--%>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMASTER_ID1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMASTER_ID1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:DropDownList ID="drpMASTER_ID" runat="server" CssClass="table-group-action-input form-control input-medium" AutoPostBack="true" OnSelectedIndexChanged="drpMASTER_ID_SelectedIndexChanged"></asp:DropDownList>
                                                                                    <%-- <asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidatorMASTER_ID" runat="server" ErrorMessage="Master  name Required." ControlToValidate="drpMASTER_ID" ValidationGroup="submit" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMASTER_ID2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMASTER_ID2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>

                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMENU_TYPE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_TYPE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:DropDownList ID="drpMENU_TYPE" AutoPostBack="true" OnSelectedIndexChanged="drpMENU_TYPE_SelectedIndexChanged" runat="server" CssClass="table-group-action-input form-control input-medium">
                                                                                        <asp:ListItem Value="1">Level 1</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Level 2</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMENU_TYPE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_TYPE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <asp:Panel ID="submenupanel" runat="server" Visible="false">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group" style="color: ">
                                                                                    <asp:Label runat="server" ID="Label8" class="col-md-4 control-label">Select Menu</asp:Label><asp:TextBox runat="server" ID="TextBox6" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                        <asp:DropDownList ID="DrpMultisubmenu" runat="server" CssClass="table-group-action-input form-control input-medium">
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                    <asp:Label runat="server" ID="Label9" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="TextBox8" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </asp:Panel>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblLINK1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLINK1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtLINK" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblLINK2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtLINK2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblURLREWRITE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtURLREWRITE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtURLREWRITE" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblURLREWRITE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtURLREWRITE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblADDFLAGE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDFLAGE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:CheckBox ID="cbADDFLAGE" runat="server" f />
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblADDFLAGE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtADDFLAGE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblEDITFLAGE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtEDITFLAGE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:CheckBox ID="cbEDITFLAGE" runat="server" />
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblEDITFLAGE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtEDITFLAGE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblDELFLAGE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDELFLAGE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:CheckBox ID="cbDELFLAGE" runat="server" />
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblDELFLAGE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDELFLAGE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblPRINTFLAGE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPRINTFLAGE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:CheckBox ID="cbPRINTFLAGE" runat="server" />
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblPRINTFLAGE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtPRINTFLAGE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMYPERSONAL1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMYPERSONAL1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:CheckBox ID="cbMYPERSONAL" runat="server" />
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMYPERSONAL2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMYPERSONAL2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMENU_ORDER1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_ORDER1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtMENU_ORDER" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMENU_ORDER2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_ORDER2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label ID="lblMETATITLE" runat="server" Text="METATITLE" class="col-md-4 control-label"></asp:Label>
                                                                                <asp:Label runat="server" ID="Label13" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="Label6" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtMETATITLE" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="Label20" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="Label7" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMETAKEYWORD1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMETAKEYWORD1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtMETAKEYWORD" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMETAKEYWORD2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMETAKEYWORD2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblMETADESCRIPTION1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMETADESCRIPTION1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                                    <asp:TextBox TextMode="MultiLine" ID="txtMETADESCRIPTION" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblMETADESCRIPTION2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMETADESCRIPTION2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblHEADERVISIBLEDATA1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHEADERVISIBLEDATA1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtHEADERVISIBLEDATA" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblHEADERVISIBLEDATA2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHEADERVISIBLEDATA2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblHEADERINVISIBLEDATA1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHEADERINVISIBLEDATA1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtHEADERINVISIBLEDATA" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblHEADERINVISIBLEDATA2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtHEADERINVISIBLEDATA2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblFOOTERVISIBLEDATA1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFOOTERVISIBLEDATA1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtFOOTERVISIBLEDATA" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblFOOTERVISIBLEDATA2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFOOTERVISIBLEDATA2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-6">
                                                                            <div class="form-group" style="color: ">
                                                                                <asp:Label runat="server" ID="lblFOOTERINVISIBLEDATA1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFOOTERINVISIBLEDATA1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                                <div class="col-md-8">
                                                                                    <asp:TextBox ID="txtFOOTERINVISIBLEDATA" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </div>
                                                                                <asp:Label runat="server" ID="lblFOOTERINVISIBLEDATA2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtFOOTERINVISIBLEDATA2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </fieldset>
                                                                </asp:Panel>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="row">
                                                            <fieldset style="margin-bottom: 10px;">
                                                                <legend>Menu Details</legend>
                                                            </fieldset>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME11s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME11s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtMENU_NAME1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME12h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME12h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME21s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME21s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtMENU_NAME2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME22h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME22h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">


                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME31s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME31s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtMENU_NAME3" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME32h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME32h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblSMALLTEXT1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSMALLTEXT1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtSMALLTEXT" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblSMALLTEXT2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSMALLTEXT2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblDOC_PARENT1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDOC_PARENT1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtDOC_PARENT" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblDOC_PARENT2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDOC_PARENT2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblAMIGLOBALE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtAMIGLOBALE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:CheckBox ID="cbAMIGLOBALE" runat="server" />
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblAMIGLOBALE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtAMIGLOBALE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblACTIVETILLDATE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtACTIVETILLDATE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox Placeholder="MM/dd/yyyy" ID="txtACTIVETILLDATE" runat="server" CssClass="form-control"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidator1" runat="server" ErrorMessage="ACTIVETILL DATE Required." ControlToValidate="txtACTIVETILLDATE" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        <cc1:CalendarExtender ID="TextBoxACTIVETILLDATE_CalendarExtender" runat="server" Enabled="True" PopupButtonID="calender" TargetControlID="txtACTIVETILLDATE" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtACTIVETILLDATE" FilterType="Custom,Numbers" ValidChars="/"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblACTIVETILLDATE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtACTIVETILLDATE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label16" runat="server" class="col-md-4 control-label" Text="Active To Date"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox Placeholder="MM/dd/yyyy" ID="txtMenudate" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator CssClass="Validation" ID="RequiredFieldValidator2" runat="server" ErrorMessage="ACTIVE To DATE Required." ControlToValidate="txtMenudate" ValidationGroup="submit"></asp:RequiredFieldValidator>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="calender" TargetControlID="txtMenudate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMenudate" FilterType="Custom,Numbers" ValidChars="/"></cc1:FilteredTextBoxExtender>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label15" runat="server" class="col-md-4 control-label" Text="Active Menu"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:CheckBox ID="Chkactivemenu" Checked="true" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblACTIVE_FLAG1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtACTIVE_FLAG1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:CheckBox ID="cbACTIVE_FLAG" Checked="true" runat="server" />
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblACTIVE_FLAG2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtACTIVE_FLAG2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblCOMMANLINE1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCOMMANLINE1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtCOMMANLINE" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblCOMMANLINE2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtCOMMANLINE2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblICONPATH1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtICONPATH1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-6">
                                                                        <asp:DropDownList ID="drpICONPATH" OnSelectedIndexChanged="drpICONPATH_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                        <%-- <asp:TextBox ID="txtICONPATH" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <i></i>
                                                                        <asp:Label runat="server" ID="lblIconpath" Style="font-size: 25px; margin-top: 10px;" class="icon-shield"></asp:Label>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblICONPATH2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtICONPATH2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>


                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblREFID1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtREFID1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:DropDownList ID="drpREFID" runat="server" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblREFID2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtREFID2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMYBUSID1s" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMYBUSID1s" class="col-md-4 control-label" Visible="false"></asp:TextBox><div class="col-md-8">
                                                                        <asp:DropDownList ID="drpMYBUSID" runat="server" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMYBUSID2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMYBUSID2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                                <div class="portlet box green">
                                                                    <div class="portlet-title">
                                                                        <div class="caption">
                                                                            <i class="fa fa-list"></i>
                                                                            <asp:Label ID="lblNew" runat="server" Text="List "></asp:Label>
                                                                        </div>
                                                                        <div class="tools">
                                                                            <a href="javascript:;" class="collapse"></a>
                                                                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                                                            <a href="javascript:;" class="reload"></a>
                                                                            <a href="javascript:;" class="remove"></a>
                                                                        </div>
                                                                    </div>
                                                                    <div class="portlet-body">
                                                                        <div class="portlet-body form">
                                                                            <div class="tabbable">
                                                                                <div class="tab-content no-space">
                                                                                    <div class="tab-pane active">
                                                                                        <div class="form-body">

                                                                                            <table class="table table-striped table-hover table-bordered" style="margin-left: 1px;">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>SP</th>
                                                                                                        <th>Name</th>
                                                                                                        <th>Value</th>
                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="text-align: center;">1</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtsp1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtvaluesp1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="text-align: center;">2</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtsp2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtvaluesp2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="text-align: center;">3</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtsp3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtvaluesp3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="text-align: center;">4</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtsp4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtvaluesp4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="text-align: center;">5</td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtsp5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="txtvaluesp5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                                    </tr>
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
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
            </div>
            <asp:Panel ID="pnlcoppy" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-copy"></i>
                                    <asp:Label runat="server" ID="Label28"></asp:Label>
                                    Copy Menu
                                </div>

                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="javascript:;" class="reload"></a>
                                    <a href="javascript:;" class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="portlet-body form">
                                    <div class="tabbable">
                                        <div class="tab-content no-space">
                                            <div class="tab-pane active">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="form-group">
                                                            <div class="col-md-12">

                                                                <asp:Label ID="lblmark" Style="color: Red; font-size: Medium; margin-left: 10px;" runat="server" Text="REMARK --> "></asp:Label>
                                                                <asp:Label ID="mark" ForeColor="Green" Font-Size="Medium" runat="server" Text=""></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: 10px;">
                                                        <div class="form-group">
                                                            <div class="col-md-6" style="color: black; font-weight: normal">
                                                                <label runat="server" id="Label58" class="col-md-4 control-label  ">
                                                                    <asp:Label ID="Label59" runat="server" Text="TenentID"></asp:Label>
                                                                </label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="drpCopyTenent" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" OnTextChanged="drpCopyTenent_TextChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" style="color: black; font-weight: normal">
                                                                <label runat="server" id="Label17" class="col-md-4 control-label  ">
                                                                    <asp:Label ID="Label18" runat="server" Text="OverWrite"></asp:Label>
                                                                </label>
                                                                <div class="col-md-8">
                                                                    <asp:CheckBox ID="Chkoverwrite" runat="server"></asp:CheckBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="margin-top: 10px;">
                                                        <div class="form-group">
                                                            <div class="col-md-6" style="color: black; font-weight: normal">
                                                                <label runat="server" id="Label24" class="col-md-4 control-label  ">
                                                                    <asp:Label ID="Label25" runat="server" Text="Module Name"></asp:Label>
                                                                </label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="drpcopyModule" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" OnSelectedIndexChanged="drpcopyModule_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" style="color: black; font-weight: normal">
                                                                <label runat="server" id="Label26" class="col-md-4 control-label  ">
                                                                    <asp:Label ID="Label27" runat="server" Text="Master Menu"></asp:Label>
                                                                </label>
                                                                <div class="col-md-8">
                                                                    <asp:DropDownList ID="drpcopyMaster" runat="server" CssClass="table-group-action-input form-control input-small"></asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <%--<asp:Button ID="btnpnlforcopy" Style="margin-left: 20px; margin-right: 0px;" CssClass="btn btn-sm green" runat="server" OnClick="btnpnlforcopy_Click" Text="Copy" />--%>
                                                        <asp:Button ID="btncancle1" runat="server" Text="Cancel" class="btn btn-sm default" OnClick="btncancle1_Click" />
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
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-edit"></i>
                                <asp:Label runat="server" ID="Label5"></asp:Label>
                                List
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                            <div class="actions btn-set">
                                <asp:LinkButton ID="btnReload" class="btn green" runat="server" OnClick="btnReload_Click">Reload</asp:LinkButton>
                            </div>
                            <div class="tools">
                                <asp:DropDownList Style="width: 150px;" class="form-control input-inline " ID="drpSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpSort_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class="table table-striped table-hover table-bordered" id="sample_1">
                                <thead>
                                    <tr>
                                        <th style="width: 60px;">ACTION</th>
                                        <th>
                                            <asp:Label runat="server" ID="lblTenent" Text="TenentID"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="Label19" Text="MenuID"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="lblhMENU_NAME1" Text="Menu name1"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="Label23" Text="ModuleID"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="lblhMODULE_ID" Text="Module  name"></asp:Label></th>
                                        <%--<th>
                                            <asp:Label runat="server" ID="lblhLINK" Text="Link"></asp:Label></th>--%>
                                        <th>
                                            <asp:Label runat="server" ID="lblhURLREWRITE" Text="Url Rewrite"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="lblhMENU_ORDER" Text="Menu order"></asp:Label></th>
                                        <%--<th>
                                            <asp:Label runat="server" ID="lblhAMIGLOBALE" Text="Amiglobale"></asp:Label></th>--%>
                                        <th>
                                            <asp:Label runat="server" ID="lblhACTIVETILLDATE" Text="Active Till Date"></asp:Label></th>


                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="Listview1" runat="server" OnItemDataBound="Listview1_ItemDataBound" OnItemCommand="Listview1_ItemCommand" DataKey="TenentID,MENU_ID,MASTER_ID,MODULE_ID,MENU_TYPE,MENU_NAME1,MENU_NAME2,MENU_NAME3,LINK,URLREWRITE,MENU_LOCATION,MENU_ORDER,DOC_PARENT,CRUP_ID,ADDFLAGE,EDITFLAGE,DELFLAGE,PRINTFLAGE,AMIGLOBALE,MYPERSONAL,SMALLTEXT,ACTIVETILLDATE,ICONPATH,COMMANLINE,ACTIVE_FLAG,METATITLE,METAKEYWORD,METADESCRIPTION,HEADERVISIBLEDATA,HEADERINVISIBLEDATA,FOOTERVISIBLEDATA,FOOTERINVISIBLEDATA,REFID,MYBUSID" DataKeyNames="TenentID,MENU_ID,MASTER_ID,MODULE_ID,MENU_TYPE,MENU_NAME1,MENU_NAME2,MENU_NAME3,LINK,URLREWRITE,MENU_LOCATION,MENU_ORDER,DOC_PARENT,CRUP_ID,ADDFLAGE,EDITFLAGE,DELFLAGE,PRINTFLAGE,AMIGLOBALE,MYPERSONAL,SMALLTEXT,ACTIVETILLDATE,ICONPATH,COMMANLINE,ACTIVE_FLAG,METATITLE,METAKEYWORD,METADESCRIPTION,HEADERVISIBLEDATA,HEADERINVISIBLEDATA,FOOTERVISIBLEDATA,FOOTERINVISIBLEDATA,REFID,MYBUSID">
                                        <LayoutTemplate>
                                            <tr id="ItemPlaceholder" runat="server">
                                            </tr>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                            <td>
                                                                <asp:LinkButton ID="btnDelete" CommandName="btnDelete" OnClientClick="return ConfirmMsg();" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i></asp:LinkButton></td>

                                                            <td>

                                                                <%--<asp:LinkButton ID="LinkButton2" CommandName="btncopy" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm blue filter-cancel" ToolTip="Copy"><i class="fa fa-copy"></i></asp:LinkButton>--%>
                                                                <asp:LinkButton ID="LinkButton2" CommandName="coppy" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID") +","+ Eval("MODULE_ID")%>' runat="server" class="btn btn-sm blue filter-cancel" ToolTip="Copy"><i class="fa fa-copy"></i></asp:LinkButton>

                                                                <%-- t --%>
                                                                <%--<panel id="pnlCopyTenent" style="padding: 1px; background-color: #fff; border: 2px solid pink; display: none; overflow: auto;" runat="server" cssclass="modalPopup">
                                                                            <div class="modal-dialog" style="position:fixed;left:27%;top:750px">
                                                                                <div class="col-md-12">
                                                                                    <div class="portlet box red-flamingo">
                                                                                        <div class="portlet-title">
                                                                                            <div class="caption">
                                                                                                <i class="fa fa-copy"></i>
                                                                                                Copy Menu
                                                                                            </div>
                                                                                        </div>                                                                                   
                                                                                    <div class="portlet-body">
                                                                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                            <ContentTemplate> 
                                                                                            <div class="tabbable">
                                                                                                <div class="tab-content no-space">
                                                                                                    <div class="form-body">
                                                                                                        <div class="row">
                                                                                                            <div class="form-group">
                                                                                                                        <div class="col-md-6" style="color: black; font-weight: normal">
                                                                                                                            <label runat="server" id="Label58" class="col-md-4 control-label  ">
                                                                                                                                <asp:Label ID="Label59" runat="server" Text="TenentID"></asp:Label>                                                                                                                            
                                                                                                                            </label>
                                                                                                                            <div class="col-md-8">
                                                                                                                                <asp:DropDownList ID="drpCopyTenent" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" OnTextChanged="drpCopyTenent_TextChanged"></asp:DropDownList>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                       <div class="col-md-6" style="color: black; font-weight: normal">
                                                                                                                           <label runat="server" id="Label17" class="col-md-4 control-label  ">
                                                                                                                                <asp:Label ID="Label18" runat="server" Text="OverWrite"></asp:Label>                                                                                                                            
                                                                                                                            </label>
                                                                                                                            <div class="col-md-8">
                                                                                                                                <asp:CheckBox ID="Chkoverwrite" runat="server"></asp:CheckBox>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="row" style="margin-top: 10px;">
                                                                                                            <div class="form-group">
                                                                                                                        <div class="col-md-6" style="color: black; font-weight: normal">
                                                                                                                            <label runat="server" id="Label24" class="col-md-4 control-label  ">
                                                                                                                                <asp:Label ID="Label25" runat="server" Text="Module Name"></asp:Label>                                                                                                                            
                                                                                                                            </label>
                                                                                                                            <div class="col-md-8">
                                                                                                                                <asp:DropDownList ID="drpcopyModule" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" OnSelectedIndexChanged="drpcopyModule_SelectedIndexChanged"></asp:DropDownList>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                        <div class="col-md-6" style="color: black; font-weight: normal">
                                                                                                                            <label runat="server" id="Label26" class="col-md-4 control-label  ">
                                                                                                                                <asp:Label ID="Label27" runat="server" Text="Master Menu"></asp:Label>                                                                                                                            
                                                                                                                            </label>
                                                                                                                            <div class="col-md-8">
                                                                                                                                <asp:DropDownList ID="drpcopyMaster" runat="server" CssClass="table-group-action-input form-control input-small"></asp:DropDownList>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>    
                                                                                                 </div>
                                                                                            </div>      
                                                                                             </ContentTemplate>
                                                                                                    </asp:UpdatePanel>                                                                                                                                             
                                                                                    <div class="modal-footer">
                                                                                         <asp:LinkButton ID="btnsCopytenent" class="btn green" runat="server" Text="Copy" CommandName="copy" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID") +","+ Eval("MODULE_ID")%>' />
                                                                                         <asp:LinkButton ID="btncancle1" runat="server"  Text="Cancel" class="btn default"/>
                                                                                    </div>
                                                                                     </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                             </panel>
                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                                                                    BackgroundCssClass="modalBackground" CancelControlID="btncancle1" Enabled="True"
                                                                    PopupControlID="pnlCopyTenent" TargetControlID="LinkButton2">
                                                                </cc1:ModalPopupExtender>--%>
                                                                <%-- t --%>
                                                           
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("TenentID")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("MENU_ID")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMENU_NAME1" runat="server" Text='<%# Eval("MENU_NAME1")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("MODULE_ID")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMODULE_ID" runat="server" Text='<%#getmodulname(Convert.ToInt32( Eval("MODULE_ID")))%>'></asp:Label></td>
                                                <%--<td>
                                                    <asp:Label ID="lblLINK" runat="server" Text='<%# Eval("LINK")%>'></asp:Label></td>--%>
                                                <td>
                                                    <asp:Label ID="lblURLREWRITE" runat="server" Text='<%# Eval("URLREWRITE")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblMENU_ORDER" runat="server" Text='<%# Eval("MENU_ORDER")%>'></asp:Label></td>
                                                <%--<td>
                                                    <asp:Label ID="lblAMIGLOBALE" runat="server" Text='<%# Eval("AMIGLOBALE")%>'></asp:Label></td>--%>
                                                <td>

                                                    <asp:Label ID="lblACTIVETILLDATE" runat="server" Text='<%# Convert.ToDateTime(Eval("ACTIVETILLDATE")).ToShortDateString()%>'></asp:Label>

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
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
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
                                                                                   
                                                                                                Entries&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList Style="width: 150px;" class="form-control input-inline " ID="drpSort" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpSort_SelectedIndexChanged">
                                                                                                </asp:DropDownList></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6 col-sm-12">
                                                                            <div id="sample_1_filter" class="dataTables_filter">
                                                                                <label>
                                                                                    <asp:TextBox ID="txtSearch" Placeholder="Search" class="form-control input-small input-inline" runat="server"></asp:TextBox>
                                                                                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-search"></i></asp:LinkButton></label>

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
                                                                                                <asp:Label runat="server" ID="lblhMODULE_ID" Text="Module  name"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhMENU_NAME1" Text="Menu name1"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhLINK" Text="Link"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhURLREWRITE" Text="Url Rewrite"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhMENU_ORDER" Text="Menu order"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhAMIGLOBALE" Text="Amiglobale"></asp:Label></th>
                                                                                            <th>
                                                                                                <asp:Label runat="server" ID="lblhACTIVETILLDATE" Text="Active Till Date"></asp:Label></th>

                                                                                            <th style="width: 60px;">ACTION</th>
                                                                                        </tr>
                                                                                    </thead>
                                                                                    <tbody>
                                                                                        <asp:ListView ID="Listview1" runat="server" OnItemCommand="Listview1_ItemCommand" DataKey="TenentID,MENU_ID,MASTER_ID,MODULE_ID,MENU_TYPE,MENU_NAME1,MENU_NAME2,MENU_NAME3,LINK,URLREWRITE,MENU_LOCATION,MENU_ORDER,DOC_PARENT,CRUP_ID,ADDFLAGE,EDITFLAGE,DELFLAGE,PRINTFLAGE,AMIGLOBALE,MYPERSONAL,SMALLTEXT,ACTIVETILLDATE,ICONPATH,COMMANLINE,ACTIVE_FLAG,METATITLE,METAKEYWORD,METADESCRIPTION,HEADERVISIBLEDATA,HEADERINVISIBLEDATA,FOOTERVISIBLEDATA,FOOTERINVISIBLEDATA,REFID,MYBUSID" DataKeyNames="TenentID,MENU_ID,MASTER_ID,MODULE_ID,MENU_TYPE,MENU_NAME1,MENU_NAME2,MENU_NAME3,LINK,URLREWRITE,MENU_LOCATION,MENU_ORDER,DOC_PARENT,CRUP_ID,ADDFLAGE,EDITFLAGE,DELFLAGE,PRINTFLAGE,AMIGLOBALE,MYPERSONAL,SMALLTEXT,ACTIVETILLDATE,ICONPATH,COMMANLINE,ACTIVE_FLAG,METATITLE,METAKEYWORD,METADESCRIPTION,HEADERVISIBLEDATA,HEADERINVISIBLEDATA,FOOTERVISIBLEDATA,FOOTERINVISIBLEDATA,REFID,MYBUSID">
                                                                                            <LayoutTemplate>
                                                                                                <tr id="ItemPlaceholder" runat="server">
                                                                                                </tr>
                                                                                            </LayoutTemplate>
                                                                                            <ItemTemplate>
                                                                                                <tr>

                                                                                                    <td>
                                                                                                        <asp:Label ID="lblMODULE_ID" runat="server" Text='<%#getmodulname(Convert.ToInt32( Eval("MODULE_ID")))%>'></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblMENU_NAME1" runat="server" Text='<%# Eval("MENU_NAME1")%>'></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblLINK" runat="server" Text='<%# Eval("LINK")%>'></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblURLREWRITE" runat="server" Text='<%# Eval("URLREWRITE")%>'></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblMENU_ORDER" runat="server" Text='<%# Eval("MENU_ORDER")%>'></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblAMIGLOBALE" runat="server" Text='<%# Eval("AMIGLOBALE")%>'></asp:Label></td>
                                                                                                    <td>

                                                                                                        <asp:Label ID="lblACTIVETILLDATE" runat="server" Text='<%# Convert.ToDateTime(Eval("ACTIVETILLDATE")).ToShortDateString()%>'></asp:Label>

                                                                                                    </td>

                                                                                                    <td>
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                                                                                <td>
                                                                                                                    <asp:LinkButton ID="btnDelete" CommandName="btnDelete" OnClientClick="return ConfirmMsg();" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i></asp:LinkButton></td>

                                                                                                                <td>
                                                                                                                    <asp:LinkButton ID="LinkButton2" CommandName="btncopy" CommandArgument='<%# Eval("MENU_ID") +","+Eval("TenentID")%>' runat="server" class="btn btn-sm blue filter-cancel" ToolTip="Copy"><i class="fa fa-copy"></i></asp:LinkButton></td>                                                                                                                
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
        </div>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--<asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" BackgroundCssClass="modalBackground"
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
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
    <script>

        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            Demo.init(); // init demo features
            TableEditable.init();
            ComponentsEditors.init();
            $("#draggable").draggable({
                handle: ".modal-header"
            });
            UITree.init();
            ComponentsFormTools.init();
            TableAdvanced.init();

        });
    </script>
</asp:Content>
