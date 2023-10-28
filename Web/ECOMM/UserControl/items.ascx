<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="items.ascx.cs" Inherits="Web.ECOMM.UserControl.items" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Panel ID="pnelMain" runat="server">

    <div class="portlet box green ">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-gift"></i>

            </div>
            <div class="tools">
                <a id="shlinkProductDetails" runat="server" href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
            <div class="actions btn-set">
                <asp:Button ID="BTNRECIVE" class="btn btn-info" runat="server" Style="height: 30px;" Text="RECIVE" OnClick="BTNRECIVE_Click" />
            </div>
        </div>
        <div id="shProductDetails" runat="server" class="portlet-body" style="padding-left: 25px;">
            <asp:Panel ID="pnlSuccessMsg123" runat="server" Visible="false">
                <div class="alert alert-danger alert-dismissable">
                    <button aria-hidden="true" data-dismiss="alert" class="close" type="button"></button>
                    <asp:Label ID="lblMsg123" runat="server"></asp:Label>
                </div>
            </asp:Panel>

            <table class="table table-striped table-bordered table-hover" id="sample_1">
                <thead class="repHeader">
                    <tr>
                        <th style="width: 5%;">
                            <asp:Label ID="Label1" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label>
                        </th>

                        <th style="width: 30%;">
                            <asp:Label ID="Label3" runat="server" Text=" Item Name" meta:resourcekey="lblEditResource1"></asp:Label></th>
                        <th style="width: 15%;">
                            <asp:Label ID="Label6" runat="server" Text="UOM" meta:resourcekey="lblEditResource1"></asp:Label></th>

                        <th style="width: 5%;">
                            <asp:Label ID="Label7" runat="server" Text="Qty Hand" meta:resourcekey="lblEditResource1"></asp:Label></th>
                        <th style="width: 5%;">
                            <asp:Label ID="Label4" runat="server" Text="Qty Found" meta:resourcekey="lblEditResource1"></asp:Label></th>
                        <th style="width: 5%;">
                            <asp:Label ID="Label9" runat="server" Text="Balance Qty" meta:resourcekey="lblEditResource1"></asp:Label></th>

                        <th style="width: 15%;">
                            <asp:Label ID="Label8" runat="server" Text="Multi Required"></asp:Label></th>

                        <%--<th style="width: 20%;">
                                                                            <asp:Label ID="Label9" runat="server" Text="Serialized" meta:resourcekey="lblEditResource1"></asp:Label></th>--%>
                    </tr>
                </thead>
                <tbody>

                    <asp:ListView ID="listMulticoloerand" runat="server" OnItemDataBound="listMulticoloerand_ItemDataBound" OnItemCommand="listMulticoloerand_ItemCommand" ItemPlaceholderID="p">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="p" runat="server"></asp:PlaceHolder>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="gradeA">
                                <td>
                                    <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>' meta:resourcekey="lblSRNOResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labeltarjication" runat="server" Visible="false" Text='<%#Eval("MYTRANSID") %>'></asp:Label>
                                    <asp:Label ID="lblproductid" runat="server" Visible="false" Text='<%#  Eval("MyProdID") %>'></asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text='<%# getproducode(Convert.ToInt32(Eval("MyProdID"))) %>'></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbluom" runat="server" Text='<%#getuom(Convert .ToInt32 ( Eval("UOM"))) %>'></asp:Label>

                                </td>

                                <td>
                                    <asp:TextBox ID="txtAmount1" Text='<%#getQty(Convert.ToInt32( Eval("MyProdID"))) %>' Enabled="false" runat="server" style="width: 100px;" />
                                    <%--<asp:Label ID="lblQtySystem" CssClass="price" runat="server" Visible="false" Text='<%# Eval("QUANTITY") %>'></asp:Label>
                            <input type="text" readonly id="txtq" name="txtq" style="width: 100px;" value='<%# Eval("QUANTITY") %>' onblur="abc(this);" />--%>
                                </td>

                                <td>
                                    <%-- <asp:TextBox ID="txtfoundqty" placeholder="Qty Found "  style="width: 100px;"  class="form-control" runat="server" ></asp:TextBox>--%>

                                    <%-- <input type="text" id="txtp" value='' style="width: 100px;" onblur="abc(this);" />--%>
                                    <asp:TextBox ID="txtfoundqty" runat="server" placeholder="Qty Found " onchange="Calulate(this)" Style="width: 100px;"> </asp:TextBox>

                                </td>
                                <td>
                                    <%--<input type="text" id="txtt" readonly value='' style="width: 100px;" />--%>
                                    <asp:TextBox ID="txtt" Enabled="false" runat="server" Style="width: 100px;"></asp:TextBox>

                                </td>

                                <td>
                                    <%--Strat MultiColoer pop--%>
                                    <asp:HyperLink ID="linkmultiuom" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblmultiuom" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                    <asp:Panel ID="pnlmultiuom" runat="server" CssClass="modalPopup" Style="display: none; height: auto; overflow: auto">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="portlet box purple">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Multi UOM
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <table class="table table-striped table-bordered table-hover">
                                                            <thead class="repHeader">
                                                                <tr>
                                                                    <th>
                                                                        <asp:Label ID="Label22" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label></th>
                                                                    <th>
                                                                        <asp:Label ID="Label33" runat="server" Text=" UOM" meta:resourcekey="lblSNameResource2"></asp:Label></th>
                                                                    <th>
                                                                        <asp:Label ID="Label35" runat="server" Text="Uom New Qty" meta:resourcekey="lblProOnameResource1"></asp:Label></th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>

                                                                <asp:ListView ID="listMUOMLIST" runat="server">

                                                                    <ItemTemplate>

                                                                        <tr class="gradeA">
                                                                            <td>
                                                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#(Container.DataItemIndex+1).ToString()%>'></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="LblColoername" runat="server" Text='<%#getuom(Convert .ToInt32 ( Eval("UOM"))) %>'></asp:Label>
                                                                                <asp:Label ID="LBLCOLERID" runat="server" Visible="false" Text='<%# Eval("UOM") %>'></asp:Label>
                                                                                <asp:Label ID="LblMyid" Visible="false" runat="server" Text='<%# Eval("MyProdID") %>'></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Label38" Text='<%# Eval("OpQty") %>' CssClass="form-control" runat="server"></asp:TextBox>
                                                                            </td>

                                                                        </tr>

                                                                    </ItemTemplate>

                                                                </asp:ListView>

                                                            </tbody>
                                                        </table>
                                                        <div class="actions btn-set">
                                                            <asp:LinkButton ID="btnmultiuom" class="btn green-haze modalBackgroundbtn-circle" runat="server" CommandName="Multiuom" CommandArgument='<%#Eval ("MyProdID") %>'> Save</asp:LinkButton>
                                                            <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                                            <asp:Button ID="Button11" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button11" Enabled="True" PopupControlID="pnlmultiuom" TargetControlID="linkmultiuom"></cc1:ModalPopupExtender>

                                    <%--End MultiColoer pop--%>
                                    <%--Strat MultiSize pop--%>
                                    <asp:HyperLink ID="HyperMulicolor" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblmultico" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                    <asp:Panel ID="panmulticol" runat="server" CssClass="modalPopup" Style="display: none; height: auto; overflow: auto">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="portlet box yellow">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Multi Coloer
                                                        </div>

                                                    </div>
                                                    <div class="portlet-body">
                                                        <table class="table table-striped table-bordered table-hover">

                                                            <thead class="repHeader">
                                                                <tr>
                                                                    <th>
                                                                        <asp:Label ID="Label30" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label></th>
                                                                    <th>
                                                                        <asp:Label ID="Label31" runat="server" Text="Multi Coloer" meta:resourcekey="lblSNameResource2"></asp:Label></th>

                                                                    <th>
                                                                        <asp:Label ID="Label34" runat="server" Text="Coloer New Qty" meta:resourcekey="lblProOnameResource1"></asp:Label></th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:ListView ID="listmulticoler" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr class="gradeA">
                                                                            <td>
                                                                                <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="LblColoername" runat="server" Text='<%#getcolerName(Convert .ToInt32 ( Eval("COLORID"))) %>'></asp:Label>
                                                                                <asp:Label ID="LBLCOLERID" runat="server" Visible="false" Text='<%# Eval("COLORID") %>'></asp:Label>
                                                                                <asp:Label ID="LblMyid" Visible="false" runat="server" Text='<%# Eval("MyProdID") %>'></asp:Label>

                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtcoloerqty" class="form-control" Text='<%#Eval("OpQty") %>' runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </tbody>
                                                        </table>
                                                        <div class="actions btn-set">
                                                            <asp:LinkButton ID="linkMulticoler" class="btn green-haze modalBackgroundbtn-circle" CommandName="btnMultiColoer" CommandArgument='<%# Eval("MyProdID") %>' runat="server"> Save</asp:LinkButton>
                                                            <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                                            <asp:Button ID="Button5" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button5" Enabled="True" PopupControlID="panmulticol" TargetControlID="HyperMulicolor"></cc1:ModalPopupExtender>


                                    <%--End MultiSize pop--%>
                                    <%--Strat MultiBin pop--%>
                                    <asp:HyperLink ID="hymultisize" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblmultisiz" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                    <asp:Panel ID="pnlmltizi" runat="server" CssClass="modalPopup" Style="display: none; height: auto; overflow: auto">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="portlet box purple">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Multi Size
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <table class="table table-striped table-bordered table-hover">

                                                            <thead class="repHeader">
                                                                <tr>
                                                                    <th>
                                                                        <asp:Label ID="Label28" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label></th>
                                                                    <th>
                                                                        <asp:Label ID="Label29" runat="server" Text=" Size" meta:resourcekey="lblSNameResource2"></asp:Label></th>
                                                                    <th>
                                                                        <asp:Label ID="Label32" runat="server" Text="Size New Qty" meta:resourcekey="lblProOnameResource1"></asp:Label></th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:ListView ID="listSize" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr class="gradeA">
                                                                            <td>
                                                                                <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="LblColoername" runat="server" Text='<%#getcolerName(Convert .ToInt32 ( Eval("SIZECODE"))) %>'></asp:Label>
                                                                                <asp:Label ID="LBLcOLERID" runat="server" Visible="false" Text='<%#Eval("SIZECODE") %>'></asp:Label>
                                                                                <asp:Label ID="LblMyid" Visible="false" runat="server" Text='<%# Eval("MyProdID") %>'></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtmultisze" class="form-control" Text='<%#Eval("OpQty") %>' runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </tbody>
                                                        </table>
                                                        <div class="actions btn-set">
                                                            <asp:LinkButton ID="LinkButton7" class="btn green-haze modalBackgroundbtn-circle" CommandArgument='<%# Eval("MyProdID") %>' CommandName="btmMultisize" runat="server"> Save</asp:LinkButton>
                                                            <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                                            <asp:Button ID="Button9" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />

                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button9" Enabled="True" PopupControlID="pnlmltizi" TargetControlID="hymultisize"></cc1:ModalPopupExtender>



                                    <%--End MultiBin pop--%>
                                    <%--Strat Serialized pop--%>
                                    <asp:HyperLink ID="hyperseriliz" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblserilez" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                    <asp:Panel ID="panSerializ" runat="server" CssClass="modalPopup" Style="display: none; height: 75%; overflow: auto">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="portlet box grey-cascade">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Serialization 
                                                        </div>

                                                    </div>
                                                    <div class="portlet-body">
                                                        <table class="table table-striped table-bordered table-hover">

                                                            <thead class="repHeader">
                                                                <tr>
                                                                    <th>
                                                                        <asp:Label ID="Label20" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label></th>

                                                                    <th>
                                                                        <asp:Label ID="Label26" runat="server" Text="Serialization No" meta:resourcekey="lblProOnameResource1"></asp:Label></th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:ListView ID="listSerial" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr class="gradeA">
                                                                            <td>
                                                                                <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                                <asp:Label ID="LblMyid" Visible="false" runat="server" Text='<%# Eval("MyProdID") %>'></asp:Label>
                                                                            </td>

                                                                            <td>
                                                                                <asp:TextBox ID="txtlistSerial" Text='<%# Eval("Serial_Number") %>' class="form-control" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </tbody>
                                                        </table>
                                                        <div class="actions btn-set">
                                                            <asp:LinkButton ID="LinkButton3" class="btn green-haze modalBackgroundbtn-circle" CommandArgument='<%# Eval("MYPRODID") %>' CommandName="bltiSirroliez" runat="server"> Save</asp:LinkButton>
                                                            <%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                                            <asp:Button ID="Button10" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button10" Enabled="True" PopupControlID="panSerializ" TargetControlID="hyperseriliz"></cc1:ModalPopupExtender>

                                    <%--End Serialized pop--%>
                                    <%--Strat pershibel pop--%>
                                    <asp:HyperLink ID="hprMultibin" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblmultibin" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>

                                    <asp:Panel ID="pnlmultibin" runat="server" CssClass="modalPopup" Style="display: none; height: auto; overflow: auto">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="form-horizontal form-row-seperated">
                                                            <div class="portlet box yellow">

                                                                <div class="portlet-title">

                                                                    <div class="caption">
                                                                        <i class="fa fa-globe"></i>Multi Bin<asp:Label ID="tblProdid" Visible="false" runat="server"></asp:Label><asp:Label ID="lblQTY" Visible="false" runat="server"></asp:Label><asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                                                                    </div>

                                                                </div>
                                                                <div class="portlet-body">

                                                                    <table class="table table-striped table-bordered table-hover">

                                                                        <thead class="repHeader">
                                                                            <tr>
                                                                                <th>
                                                                                    <asp:Label ID="Label8123" runat="server" Text="#" meta:resourcekey="lblSNResource1"></asp:Label></th>
                                                                                <th>
                                                                                    <asp:Label ID="Label21" runat="server" Text="Bin" meta:resourcekey="lblSNameResource2"></asp:Label></th>

                                                                                <th>
                                                                                    <asp:Label ID="Label36" runat="server" Text="Qty" meta:resourcekey="lblSNameResource2"></asp:Label></th>

                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:ListView ID="listBin" runat="server" OnItemDataBound="listBin_ItemDataBound">
                                                                                <ItemTemplate>
                                                                                    <tr class="gradeA">
                                                                                        <td>
                                                                                            <asp:Label ID="lblSRNO" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="dropBacthCode" runat="server" CssClass="table-group-action-input form-control input-medium">
                                                                                            </asp:DropDownList>
                                                                                            <asp:Label ID="LblMyid" Visible="false" runat="server" Text='<%# Eval("MyProdID") %>'></asp:Label>
                                                                                            <asp:Label ID="lblbinid" Visible="false" runat="server" Text='<%# Eval("Bin_ID") %>'></asp:Label>
                                                                                        </td>

                                                                                        <td>
                                                                                            <asp:TextBox ID="txtqty" class="form-control" Text='<%#Eval("OpQty") %>' runat="server"></asp:TextBox>
                                                                                        </td>

                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:ListView>
                                                                        </tbody>
                                                                    </table>
                                                                    <div class="actions btn-set">
                                                                        <asp:LinkButton ID="lbApproveIss" class="btn blue" CommandName="Btnbinmulti" CommandArgument='<%#Eval("MyProdID") %>' runat="server">Save</asp:LinkButton>
                                                                        <asp:Button ID="Button2" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button2" Enabled="True" PopupControlID="pnlmultibin" TargetControlID="hprMultibin"></cc1:ModalPopupExtender>

                                    <%--End pershibel pop--%>

                                    <asp:HyperLink ID="hpeperishibal" Visible="false" Style="cursor: pointer; color: blue; text-decoration: underline;" runat="server">
                                        <asp:Label ID="lblpereshibal" Visible="false" Text="Add" runat="server"></asp:Label>
                                    </asp:HyperLink>
                                    <asp:Panel ID="pnlpershibal" runat="server" CssClass="modalPopup" Style="display: none; height: auto; width: auto; overflow: auto">
                                        <div class="row" style="width: 415px;">
                                            <div class="col-md-12">
                                                <div class="portlet box purple">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Perishable
                                                        </div>

                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-2 form-group">
                                                            </div>
                                                            <div class="col-md-4 form-group" style="width: 170px;">
                                                                <asp:Label ID="Label9" runat="server" Text="Batch Number"></asp:Label>
                                                                <asp:TextBox AutoCompleteType="Disabled" ID="txtPerBatchNo" CssClass="form-control"
                                                                    runat="server" placeholder="Batch Number"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4 form-group" style="margin-left: 0px; padding-left: 20px; width: 170px;">
                                                                <asp:Label ID="Label19" runat="server" Text="Product Date"></asp:Label>
                                                                <asp:TextBox AutoCompleteType="Disabled" ID="txtProDate" CssClass="form-control"
                                                                    runat="server" placeholder="Product Date" onchange="checkdate(this)"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtProDate" Format="dd/MM/yyyy" Enabled="True">
                                                                </cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-2 form-group">
                                                            </div>
                                                            <div class="col-md-4 form-group" style="width: 170px;">
                                                                <asp:Label ID="Label23" runat="server" Text="Expiry Date"></asp:Label>
                                                                <asp:TextBox AutoCompleteType="Disabled" ID="txtExpDate" CssClass="form-control"
                                                                    runat="server" placeholder="Expiry Date" onchange="checkdate(this)"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtExpDate" Format="dd/MM/yyyy" Enabled="True">
                                                                </cc1:CalendarExtender>
                                                            </div>
                                                            <div class="col-md-4 form-group" style="margin-left: 0px; padding-left: 20px; width: 170px;">
                                                                <asp:Label ID="Label24" runat="server" Text="Lead to Destroy"></asp:Label>
                                                                <asp:TextBox AutoCompleteType="Disabled" ID="txtLead2Dest" CssClass="form-control"
                                                                    runat="server" placeholder="Lead to distroy" onchange="checkdate(this)"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLead2Dest" Format="dd/MM/yyyy" Enabled="True">
                                                                </cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                        <div class="actions btn-set">
                                                            <asp:LinkButton ID="LinkButton2" class="btn green-haze modalBackgroundbtn-circle" CommandArgument='<%# Eval("MYPRODID") %>' CommandName="btnPerishable" runat="server"> Save</asp:LinkButton>
                                                            <%--<%-- <asp:Button ID="Button1" runat="server" class="btn green-haze btn-circle"  validationgroup="S" Text="Update" OnClick="btnUpdate_Click" />--%>
                                                            <asp:Button ID="Button1" runat="server" OnClientClick="close(this)" class="btn btn-default" data-dismiss="modal" aria-hidden="true" Text="Cancel" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender6" runat="server" DynamicServicePath="" BackgroundCssClass="" CancelControlID="Button1" Enabled="True" PopupControlID="pnlpershibal" TargetControlID="hpeperishibal"></cc1:ModalPopupExtender>
                                </td>

                            </tr>


                        </ItemTemplate>
                    </asp:ListView>

                </tbody>
            </table>
            <asp:Label ID="lbltrzctiondate" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblrefteshnomber" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblbactnumber" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Panel>





