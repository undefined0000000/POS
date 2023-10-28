<%@ Page Title="" Language="C#" MasterPageFile="~/ACM/ACMMaster.Master" AutoEventWireup="true" CodeBehind="Acm_Node.aspx.cs" Inherits="Web.ACM.Acm_Node" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
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
                                        <asp:LinkButton ID="btnPagereload"  runat="server"><img src="../assets/admin/layout4/img/reload.png" style="margin-top: -7px;" /></asp:LinkButton>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                    <div class="actions btn-set">
                                       
                                        <asp:Button ID="btnAdd" runat="server" class="btn green-haze btn-circle" ValidationGroup="submit" Text="AddNew" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnCancel" runat="server" class="btn green-haze btn-circle"  Text="Cancel" />
                                        <asp:Button ID="btnEditLable" runat="server" class="btn green-haze btn-circle"  Text="Update Label" />
                                        &nbsp;
                                        <asp:LinkButton ID="LanguageEnglish" Style="color: #fff; width: 60px; padding: 0px;" runat="server" >E&nbsp;<img src="../assets/global/img/flags/us.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="LanguageArabic" Style="color: #fff; width: 40px; padding: 0px;" runat="server" >A&nbsp;<img src="../assets/global/img/flags/ae.png" /></asp:LinkButton>
                                        <asp:LinkButton ID="LanguageFrance" Style="color: #fff; width: 50px; padding: 0px;" runat="server" >F&nbsp;<img src="../assets/global/img/flags/fr.png" /></asp:LinkButton>
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <div class="portlet-body form">
                                        <div class="tabbable">
                                            <div class="tab-content no-space">
                                                <div class="tab-pane active" id="tab_general1">
                                                    <div class="form-body">

                                                        <div class="row">
                                                            <fieldset style="margin-bottom: 10px;">
                                                                <legend>Menu Details</legend>
                                                            </fieldset>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME11s" Text="Page Title" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME11s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPageTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME12h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME12h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color:black ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME21s" Text="Page Title Arabic" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME21s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPageTitle1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME22h"  class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME22h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">


                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color:black ">
                                                                    <asp:Label runat="server" ID="lblMENU_NAME31s" Text="Page Title France" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME31s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPageTitle2" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblMENU_NAME32h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtMENU_NAME32h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblSMALLTEXT1s" Text="Page Path" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSMALLTEXT1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPagePath" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblSMALLTEXT2h"  class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtSMALLTEXT2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </div>



                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group" style="color: ">
                                                                    <asp:Label runat="server" ID="lblDOC_PARENT1s" Text="Page Name" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDOC_PARENT1s" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                    <div class="col-md-8">
                                                                        <asp:TextBox ID="txtPageName" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <asp:Label runat="server" ID="lblDOC_PARENT2h" class="col-md-4 control-label"></asp:Label><asp:TextBox runat="server" ID="txtDOC_PARENT2h" class="col-md-4 control-label" Visible="false"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                             <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label15" runat="server" class="col-md-4 control-label" Text="Active Menu"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:CheckBox ID="Chkactivemenu" Checked="true" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                           
                                                        </div>


                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <asp:Label ID="Label1" runat="server" class="col-md-4 control-label" Text="Is Parent"></asp:Label>
                                                                    <div class="col-md-8">
                                                                        <asp:CheckBox ID="CheckBox1" Checked="false" OnCheckedChanged="CheckChange" runat="server" />
                                                                    </div>
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
                                                                    <asp:DropDownList ID="drpCopyTenent" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" ></asp:DropDownList>
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
                                                                    <asp:DropDownList ID="drpcopyModule" runat="server" CssClass="table-group-action-input form-control input-small" AutoPostBack="true" ></asp:DropDownList>
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
                                                        <asp:Button ID="btncancle1" runat="server" Text="Cancel" class="btn btn-sm default"  />
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
                                <asp:LinkButton ID="btnReload" class="btn green" runat="server" >Reload</asp:LinkButton>
                            </div>
                            <div class="tools">
                                <asp:DropDownList Style="width: 150px;" class="form-control input-inline " ID="drpSort" runat="server" AutoPostBack="true" >
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class="table table-striped table-hover table-bordered" id="sample_1">
                                <thead>
                                    <tr>
                                        <th style="width: 60px;">ACTION</th>
                                        
                                        <th>
                                            <asp:Label runat="server" ID="Label19" Text="MenuID"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="lblhMENU_NAME1" Text="Page Title"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="Label2" Text="Arabic"></asp:Label></th>
                                         <th>
                                            <asp:Label runat="server" ID="Label3" Text="Page Name"></asp:Label></th>
                                        <th>
                                            <asp:Label runat="server" ID="Label23" Text="Page URL"></asp:Label></th>
                                      
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:ListView ID="Listview1" OnItemCommand="ListView1_ItemCommand" runat="server"  >
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
                                                                <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("NodeID")%>' runat="server" class="btn btn-sm yellow filter-submit margin-bottom"><i class="fa fa-pencil"></i></asp:LinkButton></td>
                                                           <%-- <td>
                                                                <asp:LinkButton ID="btnDelete" CommandName="btnDelete"  CommandArgument='<%# Eval("NodeID")%>' runat="server" class="btn btn-sm red filter-cancel"><i class="fa fa-times"></i></asp:LinkButton></td>--%>

                                                        </tr>
                                                    </table>
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="MenuID" runat="server" Text='<%# Eval("NodeID")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="PageTitle" runat="server" Text='<%# Eval("PageTitle")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="PageArabic" runat="server" Text='<%# Eval("PageTitle1")%>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="PageName" runat="server" Text='<%# Eval("PagePath")%>'></asp:Label></td>
                                              
                                                <td>
                                                    <asp:Label ID="PageUrl" runat="server" Text='<%# Eval("NodeNavUrl")%>'></asp:Label></td>
                                              
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
