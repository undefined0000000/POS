<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="AcmMaster.aspx.cs" Inherits="Web.ACM.AcmMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  id="b" runat="server">
        <div class="col-md-12">
            <div class="tabbable-custom tabbable-noborder">

                <asp:Panel ID="pnlSuccessMsg" runat="server" Visible="false">
                    <div class="alert alert-success alert-dismissable">
                        <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </asp:Panel>

                <div class="row">

                    <div class="col-md-12">
                        <div class="form-horizontal form-row-seperated">
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Acm User profile 
                                        <asp:Label runat="server" ID="Label3"></asp:Label>
                                        <asp:TextBox Style="color: #333333" ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <asp:LinkButton ID="LinkButton1" runat="server"><img src="/assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                    <div class="actions btn-set">
                                        <asp:LinkButton ID="btnsubmit" CssClass="btn btn-primary" runat="server" Style="color: #fff; background-color: #36d7b7;" OnClick="btnsubmit_Click"> Submit</asp:LinkButton>
                                        <asp:LinkButton ID="btncensl" CssClass="btn btn-primary" runat="server" Style="color: #fff; background-color: red;" OnClick="btncensl_Click">Discart</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="portlet-body form">
                                        <div class="tabbable">
                                            <div class="tab-content no-space">
                                                <div class="tab-pane active" id="tab_general11">
                                                    <div class="form-body">
                                                        <fieldset style="margin-bottom: 10px;">
                                                            <legend>User</legend>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label5" class="col-md-4 control-label">First Name</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtfirstname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label6" class="col-md-4 control-label">Last Name</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtlastname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label8" class="col-md-4 control-label">Login Id</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtlonginId" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label9" class="col-md-4 control-label">Password</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtpassword" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                        <fieldset style="margin-bottom: 10px;">
                                                            <legend>Module</legend>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label10" class="col-md-4 control-label">Parent Module Name</asp:Label><div class="col-md-8">
                                                                            <asp:DropDownList ID="drpmodulname" runat="server" CssClass="table-group-action-input form-control input-medium"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label11" class="col-md-4 control-label">Module_Name</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtmodulname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label12" class="col-md-4 control-label">MYSYSNAME</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtsysname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label13" class="col-md-4 control-label">Module_Desc</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtmoduldes" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </fieldset>
                                                        <fieldset style="margin-bottom: 10px;">
                                                            <legend>Privilage</legend>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label19" class="col-md-4 control-label">Privilege Name</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtprivilegename" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label20" class="col-md-4 control-label">Privilege Desc</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtprivileDesc" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </fieldset>
                                                        <fieldset style="margin-bottom: 10px;">
                                                            <legend>Role</legend>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label26" class="col-md-4 control-label">ROLE_NAME</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtrolename" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label27" class="col-md-4 control-label">ROLE_DESC</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtroledesc" CssClass="form-control" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label28" class="col-md-4 control-label">ACTIVE_FROM_DT</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtactiveformdate" CssClass="form-control" runat="server"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtactiveformdate" Format="MM/dd/yyyy" Enabled="True">
                                                                            </cc1:CalendarExtender>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group" style="color: ">
                                                                        <asp:Label runat="server" ID="Label29" class="col-md-4 control-label">ACTIVE_TO_DT</asp:Label><div class="col-md-8">
                                                                            <asp:TextBox ID="txtactivetodate" CssClass="form-control" runat="server"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtactivetodate" Format="MM/dd/yyyy" Enabled="True">
                                                                            </cc1:CalendarExtender>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </fieldset>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
