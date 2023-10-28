<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detailpreview.ascx.cs" Inherits="Web.ECOMM.UserControl.Detailpreview" %>
<div class="tabbable">
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" style="color: #fff; background-color: #3598dc" href="#ac3-46">
            <asp:Label ID="Label25" runat="server" Text="Stock status" meta:resourcekey="lblProSFFResource1"></asp:Label>
        </a></li>
        <li><a data-toggle="tab" style="color: #fff; background-color: #f3c200" href="#ac3-44">
            <asp:Label ID="Label21" runat="server" Text="Supplier" meta:resourcekey="lblProSFFResource1"></asp:Label>
        </a></li>
        <li><a href="#ac3-45" data-toggle="tab" style="color: #fff; background-color: #8e5fa2">
            <asp:Label ID="Label23" runat="server" Text="Customer" meta:resourcekey="Label24Resource1"></asp:Label>
        </a></li>

    </ul>
    <div class="tab-content no-space">
        <div id="ac3-46" class="tab-pane active">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-horizontal form-row-seperated">
                        <div class="portlet box blue ">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-gift"></i>Stock status
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="javascript:;" class="reload"></a>
                                    <a href="javascript:;" class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body" style="padding-left: 25px;">
                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                                                                    <ContentTemplate>--%>

                                <table class="table table-striped table-bordered table-hover" id="sample_2">
                                    <thead class="repHeader">
                                        <tr>
                                            <th>
                                                <asp:Label ID="Label27" runat="server" Text="#"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label28" runat="server" Text="Location Name"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label29" runat="server" Text="Purchase"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label30" runat="server" Text="Sales"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label31" runat="server" Text="Stock in Hand"></asp:Label></th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="liststocktacking" runat="server">
                                            <ItemTemplate>
                                                <tr class="gradeA">
                                                    <td>
                                                        <asp:Label ID="lblSRNO" runat="server" Text='<%# (((RepeaterItem)Container).ItemIndex+1).ToString() %>' meta:resourcekey="lblSRNOResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBusID" runat="server" Text='<%# GetItem(Convert.ToInt32(Eval("MyProdID"))) %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Qname" runat="server" Text='<%# Eval("QtyReceived") %>' meta:resourcekey="QnameResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspn" runat="server" Text='<%# Eval("QtyOut") %>' meta:resourcekey="lblspnResource1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label26" runat="server" Text='<%# Eval("OnHand") %>' meta:resourcekey="lblspnResource1"></asp:Label>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="ac3-44" class="panel-collapse collapse">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-horizontal form-row-seperated">
                        <div class="portlet box yellow-crusta">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-gift"></i>Supplier
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="javascript:;" class="reload"></a>
                                    <a href="javascript:;" class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body" style="padding-left: 25px;">
                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                                                                    <ContentTemplate>--%>

                                <table class="table table-striped table-bordered table-hover" id="sample_2">
                                    <thead class="repHeader">
                                        <tr>
                                            <th>
                                                <asp:Label ID="Label32" runat="server" Text="#"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label34" runat="server" Text="Supplier Name"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label2" runat="server" Text="Item Desc"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="Label35" runat="server" Text="Qty"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="Label37" runat="server" Text="Date"></asp:Label></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="listsupplier" runat="server">
                                            <ItemTemplate>
                                                <tr class="gradeA">
                                                    <td>
                                                        <asp:Label ID="lblSRNO" runat="server" Text='<%# (((RepeaterItem)Container).ItemIndex+1).ToString() %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label44" runat="server" Text='<%#getsupplername(Convert.ToInt32( Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Qname" runat="server" Text='<%# Eval("QUANTITY") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspn" runat="server" Text='<%#gettarasdate(Convert.ToInt32(Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="ac3-45" class="panel-collapse collapse">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-horizontal form-row-seperated">
                        <div class="portlet box purple">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-gift"></i>Customer
                                </div>
                                <div class="tools">
                                    <a href="javascript:;" class="collapse"></a>
                                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                    <a href="javascript:;" class="reload"></a>
                                    <a href="javascript:;" class="remove"></a>
                                </div>
                            </div>
                            <div class="portlet-body" style="padding-left: 25px;">
                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                                                                    <ContentTemplate>--%>

                                <table class="table table-striped table-bordered table-hover" id="sample_2">
                                    <thead class="repHeader">
                                        <tr>
                                            <th>
                                                <asp:Label ID="Label40" runat="server" Text="#"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label41" runat="server" Text="Customer Name"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label5" runat="server" Text="Item Desc"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="Label42" runat="server" Text="Qty"></asp:Label></th>
                                            <th>
                                                <asp:Label ID="Label6" runat="server" Text="Status"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="Label43" runat="server" Text="Date"></asp:Label></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="listcustemer" runat="server">
                                            <ItemTemplate>
                                                <tr class="gradeA">
                                                    <td>
                                                        <asp:Label ID="lblSRNO" runat="server" Text='<%# (((RepeaterItem)Container).ItemIndex+1).ToString() %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label44" runat="server" Text='<%#getsupplername(Convert.ToInt32(  Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Qname" runat="server" Text='<%# Eval("QUANTITY") %>'></asp:Label>
                                                    </td>
                                                     <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblspn" runat="server" Text='<%#gettarasdate(Convert.ToInt32(Eval("MYTRANSID"))) %>'></asp:Label>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
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
