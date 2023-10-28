

function CheckUOM(rdbtnMUOM) {
    var drp = document.getElementById('ContentPlaceHolder1_ddluom');
    var RB1 = document.getElementById("ContentPlaceHolder1_rdbtnMUOM");
    var radio = RB1.getElementsByTagName("input");
    for (var i = 0; i < radio.length; i++) {
        if (radio[i].checked) {
            var SelectedValue = +radio[i].value;
        }
    }
    if (SelectedValue == '1') {
        drp.style.display = "block";
    }
    else {
        drp.style.display = "none";
    }
}
function CheckUOMforMulticolor(RadioBtnMoreItenMulticolor) {
    var drp = document.getElementById('ContentPlaceHolder1_dropMulticooler');
    var RB1 = document.getElementById("ContentPlaceHolder1_RadioBtnMoreItenMulticolor");
    var txt = document.getElementById('ContentPlaceHolder1_pnelmulticooler');

    var radio = RB1.getElementsByTagName("input");
    for (var i = 0; i < radio.length; i++) {
        if (radio[i].checked) {
            var SelectedValue = +radio[i].value;
        }
    }
    if (SelectedValue == '1') {
        drp.style.display = "block";
        txt.style.display = "block";
    }
    else {
        drp.style.display = "none";
        txt.style.display = "none";
    }
}






function showWarningToast() {
    debugger
    var temp = document.getElementById("ContentPlaceHolder1_pm_txtProductName").value;
    if (temp == "") {
        //alert("Please enter the product name.");
        var message = 'Localize(pname)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp1 = document.getElementById("ContentPlaceHolder1_txtProBar").value;
    if (temp1 == "") {
        //alert("Please enter the Barcode.");
        var message = 'Localize(barcode)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp2 = document.getElementById("ContentPlaceHolder1_txtShortName").value;
    if (temp2 == "") {
        //alert("Please enter the Short name.");
        var message = 'Localize(sname)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
}
function showWarningToast2() {
    var temp = document.getElementById("ContentPlaceHolder1_DDLBussPro").value;
    if (temp == "0") {
        //alert("Please select the Business Product.");
        var message = 'Localize(buspro)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
}
function showWarningToast3() {
    var temp = document.getElementById("ContentPlaceHolder1_ddlOffWebProduct").value;
    if (temp == "0") {
        //alert("Please select the Offer Product.");
        var message = 'Localize(offpro)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp1 = document.getElementById("ContentPlaceHolder1_ddlOfferinterva").value;
    if (temp1 == "0") {
        //alert("Please select the Offer Interval.");
        var message = 'Localize(offInterval)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp2 = document.getElementById("ContentPlaceHolder1_txtOffreFromDt").value;
    if (temp2 == "") {
        //alert("Please Enter the Offer from Date.");
        var message = 'Localize(offrmdt)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp3 = document.getElementById("ContentPlaceHolder1_txtOffreToDt").value;
    if (temp3 == "") {
        //alert("Please Enter the Offer To Date.");
        var message = 'Localize(offtodt)';
        $().toastmessage('showWarningToast', message);
        return false;
    }
}
//  function showWarningToast4() {
//    var temp = document.getElementById("txtRelativeProName.ClientID").value;
//    if (temp == "") {
//        //alert("Please Enter the Relative Product Name.");
//        $().toastmessage('showWarningToast', "Please enter the relative product name.");
//        return false;
//    }
//}
function showWarningToast5() {
    var temp = document.getElementById("ContentPlaceHolder1_ddlWebBusPro").value;
    if (temp == "0") {
        var message = 'Localize(buspro)';
        //alert("Please select the Business Product.");
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp1 = document.getElementById("ContentPlaceHolder1_ddlwebinterval").value;
    if (temp1 == "0") {
        var message = 'Localize(webinterval)';
        //alert("Please select the Web Interval.");
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp2 = document.getElementById("ContentPlaceHolder1_txtwebfromdt").value;
    if (temp2 == "") {
        var message = 'Localize(webfrmdt)';
        //alert("Please Enter the Web from Date.");
        $().toastmessage('showWarningToast', message);
        return false;
    }
    var temp3 = document.getElementById("ContentPlaceHolder1_txtwebtomdt").value;
    if (temp3 == "") {
        var message = 'Localize(webtodt)';
        //alert("Please Enter the Web To Date");
        $().toastmessage('showWarningToast', message);
        return false;
    }
}
function showWarningToast6() {
    // var temp = document.getElementById("txtsersoftInterser.ClientID %>").value;
    if (temp == "") {
        //alert("Please Enter the Internal Serial.");
        $().toastmessage('showWarningToast', "Please enter the internal serial.");
        return false;
    }
    // var temp1 = document.getElementById("<txtsersoftActSer.ClientID %>").value;
    if (temp1 == "") {
        //alert("Please Enter the Actual Serial.");
        $().toastmessage('showWarningToast', "Please enter the actual serial.");
        return false;
    }
    //   var temp2 = document.getElementById("<=txtsersoftRemarks.ClientID %>").value;
    if (temp2 == "") {
        //alert("Please Enter the Remarks.");
        $().toastmessage('showWarningToast', "Please enter the remarks.");
        return false;
    }
}

function showSuccessToast() {
    //alert("Product Category created SuccessFully.");
    var message = 'Localize(created)';
    $().toastmessage('showSuccessToast', message);
}
function showSuccessToast1() {
    var message = 'Localize(updated)';
    $().toastmessage('showSuccessToast', message);
    //alert("Product Category Updated SuccessFully.");
}
function showWarningToast1() {
    //alert("Product name already exists");
    var message = 'Localize(already)';
    $().toastmessage('showWarningToast', message);
}


function OnColorPicked(sender) {
    // var parent = document.getElementById('<=lblSampleColore.ClientID %>');
    parent.style.backgroundColor = sender.getColor();
}

//Bussines Master

function showbussgrid() {
    var add = document.getElementById('ContentPlaceHolder1_pnlbussadd');
    var view = document.getElementById('ContentPlaceHolder1_pnlbussshow');
    add.style.display = "none";
    view.style.display = "block";
}
function showbussaddform() {
    var add = document.getElementById('ContentPlaceHolder1_pnlbussadd');
    var view = document.getElementById('ContentPlaceHolder1_pnlbussshow');
    add.style.display = "block";
    view.style.display = "none";
}


function clearBus() {
    var a = (confirm('Are you sure you want to clear all bus product data?'))
    if (a == true) {
        document.getElementById('ContentPlaceHolder1_DDLBussPro').value = "0";
        //document.getElementById('ContentPlaceHolder1_RadioButtonList').selectedvalue = "0";
        document.getElementById('ContentPlaceHolder1_txtbppl').value = "";
        document.getElementById('ContentPlaceHolder1_txtbprl').value = "";
        document.getElementById('ContentPlaceHolder1_txtpbcol').value = "";
        document.getElementById('ContentPlaceHolder1_txtbpl2d').value = "";
        document.getElementById('ContentPlaceHolder1_txtbpsno').value = "";
        document.getElementById('ContentPlaceHolder1_BtmBussAddRow').value = "Save";
        //document.getElementById('ContentPlaceHolder1_GridBussPro').outerHTML = "";
        var Param1 = "test";
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Products_Master.aspx/ClearBusAddrow",
                data: "{Param1: '" + Param1 + "'}",
                dataType: "json",
                success: OnSuccess,
                error: function (result) {
                }
            });
        });
    }
    else {
        return false;
    }
}
function clearWeb() {
    var a = (confirm('Are you sure you want to clear all Web product data?'))
    if (a == true) {
        document.getElementById('ContentPlaceHolder1_ddlWebBusPro').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlwebinterval').value = "0";
        document.getElementById('ContentPlaceHolder1_txtwebfromdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebtomdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebtillmdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebDisponWeb').value = "";
        document.getElementById('ContentPlaceHolder1_txtweblastshow').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebSortno').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcline').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebLink2d').value = "";
        document.getElementById('ContentPlaceHolder1_GridWebproMaster').innerText = null;;
        document.getElementById('ContentPlaceHolder1_BtnWebProMst').value = "Save";

        return true;
    }
    else {
        return false;
    }
}
function clearRelative() {
    var a = (confirm('Are you sure you want to clear all Relative product data?'))
    if (a == true) {
        document.getElementById('ContentPlaceHolder1_txtRelativeProName').value = "";
        document.getElementById('ContentPlaceHolder1_RadioRelativeAct').value = "0";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcLine').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeLink2d').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeSortNo').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeSpaci').value = "";
        document.getElementById('ContentPlaceHolder1_GridRelativeproMaster').innerText = "";
        document.getElementById('ContentPlaceHolder1_BtnRelaviveSave').value = "Save";
        return true;
    }
    else {
        return false;
    }
}
function clearallText() {
    var a = (confirm('Are you sure you want to clear all product data?'))
    if (a == true) {
        document.getElementById('ContentPlaceHolder1_pm_txtProductName').value = "";
        document.getElementById('ContentPlaceHolder1_txtProBar').value = "";
        document.getElementById('ContentPlaceHolder1_ddlProdType').value = "0";
        document.getElementById('ContentPlaceHolder1_txtACode1').value = "";
        document.getElementById('ContentPlaceHolder1_txtACode2').value = "";

        document.getElementById('ContentPlaceHolder1_DDLBussPro').value = "0";
        // document.getElementById('ContentPlaceHolder1_RadioButtonList').value = "0";
        document.getElementById('ContentPlaceHolder1_txtbppl').value = "";
        document.getElementById('ContentPlaceHolder1_txtbprl').value = "";
        document.getElementById('ContentPlaceHolder1_txtpbcol').value = "";
        document.getElementById('ContentPlaceHolder1_txtbpl2d').value = "";
        document.getElementById('ContentPlaceHolder1_txtbpsno').value = "";
        document.getElementById('ContentPlaceHolder1_BtmBussAddRow').value = "Save";
        // document.getElementById('ContentPlaceHolder1_GridBussPro').innerText = "";

        document.getElementById('ContentPlaceHolder1_txtItemRelSubProName2').value = "";
        document.getElementById('ContentPlaceHolder1_txtItemRelSubProName3').value = "";
        document.getElementById('ContentPlaceHolder1_txtShortName').value = "";
        document.getElementById('ContentPlaceHolder1_txtItemReldesc').value = "";
        document.getElementById('ContentPlaceHolder1_txtItemRelloadlink').value = "";
        document.getElementById('ContentPlaceHolder1_txtItemRelloadlinkRW').value = "";

        document.getElementById('ContentPlaceHolder1_ddlBrandname').value = "0";
        //   document.getElementById('ContentPlaceHolder1_rbtnSKUP').value = "0";
        document.getElementById('ContentPlaceHolder1_txtxitemchcolore').value = "";
        document.getElementById('ContentPlaceHolder1_ddlsize').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlSuppCat').value = "0";
        //document.getElementById('ContentPlaceHolder1_rdbtnMUOM').value = 0
        document.getElementById('ContentPlaceHolder1_ddluom').value = 0
        document.getElementById('ContentPlaceHolder1_txtQtnonHand').value = "";
        document.getElementById('ContentPlaceHolder1_txtMoreItenKeyword').value = "";
        // document.getElementById('ContentPlaceHolder1_ddlMoreItenProMethod').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlItGrp').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlDofSale').value = "0";
        // document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenHotItem').value = "0";
        //document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenSerItem').value = "0";
        //document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenMulticolor').value = "";
        //document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenMultisize').value = "";
        //document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenPurchAllow').value = "";
        //document.getElementById('ContentPlaceHolder1_RadioBtnMoreItenSellAllow').value = "";
        //document.getElementById('ContentPlaceHolder1_rbtnMBSto').value = "";
        //document.getElementById('ContentPlaceHolder1_rbtPsle').value = "";
        //   document.getElementById('ContentPlaceHolder1_ddlMoreItenSupplyMethod').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlMoreItenwarranty').value = "0";
        document.getElementById('ContentPlaceHolder1_txtMoreItenwarrantySortno').value = "";
        document.getElementById('ContentPlaceHolder1_txtMoreItenwarrantyplcline').value = "";
        document.getElementById('ContentPlaceHolder1_txtMoreItenwarrantyplcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtMoreItenwarrantyplcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtMoreItenwarrantyLink2d').value = "";

        document.getElementById('ContentPlaceHolder1_txtnoteprinote').value = "";
        document.getElementById('ContentPlaceHolder1_txtnotepricostprice').value = "";
        document.getElementById('ContentPlaceHolder1_txtnotepriCurrency').value = "";
        document.getElementById('ContentPlaceHolder1_txtnoteprisaleori1').value = "";
        document.getElementById('ContentPlaceHolder1_txtnotepriwebsalepri').value = "";
        document.getElementById('ContentPlaceHolder1_txtnoteprisaleori2').value = "";
        document.getElementById('ContentPlaceHolder1_txtnoteprimrp').value = "";
        document.getElementById('ContentPlaceHolder1_txtnoteprisaleori3').value = "";

        document.getElementById('ContentPlaceHolder1_CKEProDtlOverview').value = "";
        document.getElementById('ContentPlaceHolder1_CKEProDtlFeatures').value = "";
        document.getElementById('ContentPlaceHolder1_CKEProDtlSpecification').value = "";
        document.getElementById('ContentPlaceHolder1_CKEProDtlFAQDownload').value = "";

        document.getElementById('ContentPlaceHolder1_ddlWebBusPro').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlwebinterval').value = "0";
        document.getElementById('ContentPlaceHolder1_txtwebfromdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebtomdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebtillmdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebDisponWeb').value = "";
        document.getElementById('ContentPlaceHolder1_txtweblastshow').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebSortno').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcline').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebplcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtwebLink2d').value = "";
        // document.getElementById('ContentPlaceHolder1_GridWebproMaster').innerText = "";
        document.getElementById('ContentPlaceHolder1_BtnWebProMst').value = "Save";

        document.getElementById('ContentPlaceHolder1_txtRelativeProName').value = "";
        // document.getElementById('ContentPlaceHolder1_RadioRelativeAct').value = "0";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcLine').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativePlcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeLink2d').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeSortNo').value = "";
        document.getElementById('ContentPlaceHolder1_txtRelativeSpaci').value = "";
        // document.getElementById('ContentPlaceHolder1_GridRelativeproMaster').innerText = "";
        document.getElementById('ContentPlaceHolder1_BtnRelaviveSave').value = "Save";

        document.getElementById('ContentPlaceHolder1_ddlImages').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlImages1').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlImages2').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlImages3').value = "0";
        var temp = document.getElementById('ContentPlaceHolder1_FileUpload1').value;
        if (temp != null)
        { document.getElementById("ContentPlaceHolder1_FileUpload1").outerHTML = temp.outerHTML; }
        var temp1 = document.getElementById('ContentPlaceHolder1_FileUpload2').value;
        if (temp1 != null)
        { document.getElementById("ContentPlaceHolder1_FileUpload2").outerHTML = temp1.outerHTML; }
        var temp2 = document.getElementById('ContentPlaceHolder1_FileUpload3').value;
        if (temp2 != null)
        { document.getElementById("ContentPlaceHolder1_FileUpload3").outerHTML = temp2.outerHTML; }
        var temp3 = document.getElementById('ContentPlaceHolder1_FileUpload4').value;
        if (temp3 != null)
        { document.getElementById("ContentPlaceHolder1_FileUpload4").outerHTML = temp3.outerHTML; }

        document.getElementById('ContentPlaceHolder1_ddlOffWebProduct').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlOfferinterval').value = "0";
        document.getElementById('ContentPlaceHolder1_txtOffreFromDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreToDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreTillDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreDispOnWeb').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreLasrShow').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreShortNo').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcLine').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreLink2D').value = "";
        // document.getElementById('ContentPlaceHolder1_GridOffreproMaster').innerText = "";
        document.getElementById('ContentPlaceHolder1_BtnOffreSave').value = "Save";

        //document.getElementById('ContentPlaceHolder1_RatioProSaleFen').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenRemark').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenBarcode').value = "";
        //document.getElementById('ContentPlaceHolder1_RadioProSaleFenAct').value = "0";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenLaodpage').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenBoxshot').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenTiralURL').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenLBoxshot').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenCartUrl').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenMBoxshot').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenProDtlLink').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenSBoxshot').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenLead').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenOsPlatform').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenOhter').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenCorpLogo').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenProType').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenLink').value = "";
        document.getElementById('ContentPlaceHolder1_txtProSaleFenPayout').value = "";

        document.getElementById('ContentPlaceHolder1_txtINFOlastdisonweb').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOsysremark').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOlastpurchdt').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOlastsaledt').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOQntyRes').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOQntySold').value = "";
        document.getElementById('ContentPlaceHolder1_txtINFOQntyonhand').value = "";
        document.getElementById('ContentPlaceHolder1_pm_txtProductName').value = "";

        //document.getElementById('ContentPlaceHolder1_RadioINFOAct').value = "0";

    }

}

function clearOffer() {
    var a = (confirm('Are you sure you want to clear all Offer product data?'))
    if (a == true) {
        document.getElementById('ContentPlaceHolder1_ddlOffWebProduct').value = "0";
        document.getElementById('ContentPlaceHolder1_ddlOfferinterval').value = "0";
        document.getElementById('ContentPlaceHolder1_txtOffreFromDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreToDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreTillDt').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreDispOnWeb').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreLasrShow').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreShortNo').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcLine').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcAliRL').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffrePlcCol').value = "";
        document.getElementById('ContentPlaceHolder1_txtOffreLink2D').value = "";
        document.getElementById('ContentPlaceHolder1_GridOffreproMaster').outerHTML = "";
        document.getElementById('ContentPlaceHolder1_BtnOffreSave').value = "Save";
        // return true;
    }
    else {
        // return false;
    }
}

//Itemch Master

function showItemgrid() {
    var add = document.getElementById('ContentPlaceHolder1_PnlItemchar');
    var view = document.getElementById('ContentPlaceHolder1_PnlItemcharGrd');
    add.style.display = "none";
    view.style.display = "block";
}
function showItemaddform() {
    var add = document.getElementById('ContentPlaceHolder1_PnlItemchar');
    var view = document.getElementById('ContentPlaceHolder1_PnlItemcharGrd');
    add.style.display = "block";
    view.style.display = "none";
}

//Web Product Master

function showwebmgrid() {
    var add = document.getElementById('ContentPlaceHolder1_Panelwebproadd');
    var view = document.getElementById('ContentPlaceHolder1_Panelwebproshow');
    add.style.display = "none";
    view.style.display = "block";
}
function showwebddform() {
    var add = document.getElementById('ContentPlaceHolder1_Panelwebproadd');
    var view = document.getElementById('ContentPlaceHolder1_Panelwebproshow');
    add.style.display = "block";
    view.style.display = "none";
}

//Relative Product Master

function showRelativegrid() {
    var add = document.getElementById('ContentPlaceHolder1_PanelRELAproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelRELAproshow');
    add.style.display = "none";
    view.style.display = "block";
}
function showRelativeddform() {
    var add = document.getElementById('ContentPlaceHolder1_PanelRELAproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelRELAproshow');
    add.style.display = "block";
    view.style.display = "none";
}

//Serial Soft Product Master

function showSERSOFTgrid() {
    var add = document.getElementById('ContentPlaceHolder1_PanelSERSOFTAproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelSERSOFTAproshow');
    add.style.display = "none";
    view.style.display = "block";
}
function showSERSOFTddform() {
    var add = document.getElementById('ContentPlaceHolder1_PanelSERSOFTAproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelSERSOFTAproshow');
    add.style.display = "block";
    view.style.display = "none";
}

//Offer Product Master

function showOFFERgrid() {
    var add = document.getElementById('ContentPlaceHolder1_PanelOFFERproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelOFFERproshow');
    add.style.display = "none";
    view.style.display = "block";
}
function showOFFERddform() {
    var add = document.getElementById('ContentPlaceHolder1_PanelOFFERproadd');
    var view = document.getElementById('ContentPlaceHolder1_PanelOFFERproshow');
    add.style.display = "block";
    view.style.display = "none";
}

// Show Hide Line Panel 

function showpanebussline() {
    var view = document.getElementById('ContentPlaceHolder1_panebussline');
    if (view.style.display == "none") {
        view.style.display = "block";
        view1.value = "Hide";
    }
    else {
        view.style.display = "none";
        view1.value = "Show";
    }
}


function showpanepanewebline() {
    var view = document.getElementById('ContentPlaceHolder1_panewebline');
    if (view.style.display == "none") {
        view.style.display = "block";
        view1.value = "Hide";
    }
    else {
        view.style.display = "none";
        view1.value = "Show";
    }
}


function showpanepaneofferline() {
    var view = document.getElementById('ContentPlaceHolder1_PanelOFFERline');
    if (view.style.display == "none") {
        view.style.display = "block";
        view1.value = "Hide";
    }
    else {
        view.style.display = "none";
        view1.value = "Show";
    }
}





function showpanePanelRELATIVEline() {
    var view = document.getElementById('ContentPlaceHolder1_PanelRELATIVEline');
    if (view.style.display == "none") {
        view.style.display = "block";
        view1.value = "Hide";
    }
    else {
        view.style.display = "none";
        view1.value = "Show";
    }
}


function showPanelOFFERline() {
    var view = document.getElementById('ContentPlaceHolder1_PanelOFFERline');
    if (view.style.display == "none") {
        view.style.display = "block";
        view1.value = "Hide";
    }
    else {
        view.style.display = "none";
        view1.value = "Show";
    }
}

// Show Hide Main Three Panel 

function showhidepanel(va) {
    if (va == "grd") {
        document.getElementById("ContentPlaceHolder1_GrdView").style.display = "block";
        document.getElementById("ContentPlaceHolder1_LstView").style.display = "none";
        document.getElementById("ContentPlaceHolder1_FrmView").style.display = "none";


    }
    else if (va == "lst") {
        document.getElementById("ContentPlaceHolder1_GrdView").style.display = "none";
        document.getElementById("ContentPlaceHolder1_LstView").style.display = "block";
        document.getElementById("ContentPlaceHolder1_FrmView").style.display = "none";


    }
    else if (va == "frm") {
        document.getElementById("ContentPlaceHolder1_GrdView").style.display = "none";
        document.getElementById("ContentPlaceHolder1_LstView").style.display = "none";
        document.getElementById("ContentPlaceHolder1_FrmView").style.display = "block";
    }
}

function showhidepanelMoreItem(va) {
    if (va == "grd") {
        document.getElementById("ContentPlaceHolder1_pnelBissnesh").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panMoreItem").style.display = "none";
        document.getElementById("ContentPlaceHolder1_pnelInternal").style.display = "none";


    }
    else if (va == "lst") {
        document.getElementById("ContentPlaceHolder1_pnelBissnesh").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panMoreItem").style.display = "block";
        document.getElementById("ContentPlaceHolder1_pnelInternal").style.display = "none";


    }
    else if (va == "frm") {
        document.getElementById("ContentPlaceHolder1_pnelBissnesh").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panMoreItem").style.display = "none";
        document.getElementById("ContentPlaceHolder1_pnelInternal").style.display = "block";
    }
}

function showhidepanelWebProd(va) {
    if (va == "3Product") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";
    }
    else if (va == "4Webprod") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";
        document.getElementById("ContentPlaceHolder1_pnelMainImag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelAllImg").style.display = "none";
    }
    else if (va == "Product") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";


    }
    else if (va == "Webproduct") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";


    }

    else if (va == "Imagges") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none"; 
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_pnelMainImag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelAllImg").style.display = "none";
    }
    else if (va == "Offer") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "block";
    }
}
function ShowImag(va) {
    if (va == "ImaMain") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_pnelMainImag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none"; 
        document.getElementById("ContentPlaceHolder1_panelAllImg").style.display = "none";
    }
    else if (va == "ImgAll") {
        document.getElementById("ContentPlaceHolder1_panelpdetails").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelpWebsoft").style.display = "block";
        document.getElementById("ContentPlaceHolder1_panelProduct").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelwebprod123").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelimag").style.display = "block";
        document.getElementById("ContentPlaceHolder1_pnelMainImag").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelOff").style.display = "none";
        document.getElementById("ContentPlaceHolder1_panelAllImg").style.display = "block";
    }
}


//function showFormView() {
//    // Display From View
//    document.getElementById("ContentPlaceHolder1_GrdView").style.display = "none";
//    document.getElementById("ContentPlaceHolder1_LstView").style.display = "none";
//    document.getElementById("ContentPlaceHolder1_FrmView").style.display = "block";

//    // Display Grid Data
//    document.getElementById("ContentPlaceHolder1_pnlbussadd").style.display = "none";
//    document.getElementById("ContentPlaceHolder1_pnlbussshow.").style.display = "block";

//    //document.getElementById("PnlItemchar.ClientID %>").style.display = "none";
//    //document.getElementById(" PnlItemcharGrd.ClientID %>").style.display = "block";

//    document.getElementById("ContentPlaceHolder1_Panelwebproadd").style.display = "none";
//    document.getElementById("ContentPlaceHolder1_Panelwebproshow").style.display = "block";

//    //  document.getElementById("<PanelRELAproadd.ClientID %>").style.display = "none";
//    //document.getElementById("< PanelRELAproshow.ClientID %>").style.display = "block";

//    // document.getElementById("PanelSERSOFTAproadd.ClientID %>").style.display = "none";
//    // document.getElementById(" PanelSERSOFTAproshow.ClientID %>").style.display = "block";

//    document.getElementById("ContentPlaceHolder1_PanelOFFERproadd").style.display = "none";
//    document.getElementById("ContentPlaceHolder1_PanelOFFERproshow").style.display = "block";

//    document.getElementById("ContentPlaceHolder1_Div_RELATIVEPRODUCT").style.display = "block";
//    document.getElementById("ContentPlaceHolder1_Div_OFFER_PRODUCT").style.display = "block";

//}
