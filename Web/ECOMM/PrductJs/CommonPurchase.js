
function checkMCS() {
    var hidMColor = document.getElementById("ContentPlaceHolder1_hidMColor").value;

    if (hidMColor == "True") {
        document.getElementById("ContentPlaceHolder1_divItem").style.display = "none";
      //  document.getElementById("ContentPlaceHolder1_anchorModelPopUp").style.display = "block";
        document.getElementById("ContentPlaceHolder1_hidMColor").value = "True";
    }
    else {
        document.getElementById("ContentPlaceHolder1_divItem").style.display = "block";
      //  document.getElementById("ContentPlaceHolder1_anchorModelPopUp").style.display = "none";
        document.getElementById("ContentPlaceHolder1_hidMColor").value = "False";
    }
}
function showForm() {
    var add = document.getElementById('ContentPlaceHolder1_pnlItemAdd');
    var view = document.getElementById('ContentPlaceHolder1_pnlItemShow');
    add.style.display = "block";
    view.style.display = "none";
}


function showOverHeadItem() {
    var add = document.getElementById('ContentPlaceHolder1_pnlOHCostForm');
    var view = document.getElementById('ContentPlaceHolder1_pnlOHCostGrid');
    add.style.display = "none";
    view.style.display = "block";
}
function showOverHeadForm() {
    var add = document.getElementById('ContentPlaceHolder1_pnlOHCostForm');
    var view = document.getElementById('ContentPlaceHolder1_pnlOHCostGrid');
    add.style.display = "block";
    view.style.display = "none";
}


function showItem() {
    var add = document.getElementById('ContentPlaceHolder1_pnlItemAdd');
    var view = document.getElementById('ContentPlaceHolder1_pnlItemShow');
    add.style.display = "none";
    view.style.display = "block";
    document.getElementById("ContentPlaceHolder1_divItem").style.display = "none";
  //  document.getElementById("ContentPlaceHolder1_anchorModelPopUp").style.display = "none";
}
function showForm() {
    var add = document.getElementById('ContentPlaceHolder1_pnlItemAdd');
    var view = document.getElementById('ContentPlaceHolder1_pnlItemShow');
    add.style.display = "block";
    view.style.display = "none";
    document.getElementById("ContentPlaceHolder1_divItem").style.display = "block";
}
function showItem() {
    var add = document.getElementById('ContentPlaceHolder1_pnlItemAdd');
    var view = document.getElementById('ContentPlaceHolder1_pnlItemShow');
    add.style.display = "none";
    view.style.display = "block";
    document.getElementById("ContentPlaceHolder1_divItem").style.display = "none";
  //  document.getElementById("ContentPlaceHolder1_anchorModelPopUp").style.display = "none";
}
function disButton() {
    document.getElementById("ContentPlaceHolder1_divItem").style.display = "block";
  //  document.getElementById("ContentPlaceHolder1_anchorModelPopUp").style.display = "block";
}



function showItemSchDel() {
    var add = document.geddlSupplier_SelectedIndexChangedtElementById('pnlSchDelGrid');
    add.style.display = "none";
    view.style.display = "block";
}
function showFormScheDel() {
    var add = document.getElementById('ContentPlaceHolder1_pnlSchDelForm');
    var view = document.getElementById('ContentPlaceHolder1_pnlSchDelGrid');
    add.style.display = "block";
    view.style.display = "none";
}
function showGridScheDel() {
    var add = document.getElementById('ContentPlaceHolder1_pnlSchDelForm');
    var view = document.getElementById('ContentPlaceHolder1_pnlSchDelGrid');
    add.style.display = "none";
    view.style.display = "block";
}
function selectcurrency() {
    var LocalandForeign = document.getElementById('ContentPlaceHolder1_ddlLocalForeign');
    var LocalandForeignValue = LocalandForeign.options[LocalandForeign.selectedIndex].text;
    var ddlCurrency = document.getElementById('ContentPlaceHolder1_ddlCurrency');
    if (LocalandForeignValue == "Foreign") {
        document.getElementById('ContentPlaceHolder1_ddlSupplier').value = 0;
        document.getElementById('ContentPlaceHolder1_ddlCurrency').disabled = false;
        document.getElementById('ContentPlaceHolder1_txtUPriceLocal').disabled = true;
        document.getElementById('ContentPlaceHolder1_txtUPriceForeign').disabled = false;
    }
    else {
        ddlCurrency.disabled = true;
        document.getElementById('ContentPlaceHolder1_txtUPriceLocal').disabled = false;
        document.getElementById('ContentPlaceHolder1_txtUPriceForeign').disabled = true;
    }
    document.getElementById('ContentPlaceHolder1_txtUPriceLocal').value = "";
    document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = "";
    document.getElementById('ContentPlaceHolder1_txtUPriceForeign').value = "";
    document.getElementById('ContentPlaceHolder1_hidTotalCurrencyLocal').value = "";
    document.getElementById('ContentPlaceHolder1_txtTotalCurrencyLocal').value = "";
    document.getElementById('ContentPlaceHolder1_hidTotalCurrencyForeign').value = "";
    document.getElementById('ContentPlaceHolder1_txtTotalCurrencyForeign').value = "";
    document.getElementById('ContentPlaceHolder1_ddlLocalForeign').text = LocalandForeignValue;
    //document.getElementById('ContentPlaceHolder1_ddlLocalForeign').readOnly = true;

    var LocalandForeign1 = document.getElementById('ContentPlaceHolder1_ddlLocalForeign');
    var LocalandForeignValue1 = LocalandForeign.options[LocalandForeign.selectedIndex].text;
}
function ClearItemTab() {
    document.getElementById('ContentPlaceHolder1_ddlProduct').value = "0";
    document.getElementById('ContentPlaceHolder1_txtDescription').value = "";
    document.getElementById('ContentPlaceHolder1_ddlUOM').value = "";
    document.getElementById('ContentPlaceHolder1_txtUPriceLocal').value = "";
    document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = "";
    document.getElementById('ContentPlaceHolder1_txtUPriceForeign').value = "";
    document.getElementById('ContentPlaceHolder1_txtQuantity').value = "";
    document.getElementById('ContentPlaceHolder1_txtDiscount').value = "";
    document.getElementById('ContentPlaceHolder1_txtTax').value = "";
    document.getElementById('ContentPlaceHolder1_hidTotalCurrencyLocal').value = "";
    document.getElementById('ContentPlaceHolder1_txtTotalCurrencyLocal').value = "";
    document.getElementById('ContentPlaceHolder1_hidTotalCurrencyForeign').value = "";
    document.getElementById('ContentPlaceHolder1_hiddItemTab').value = "";
    document.getElementById('ContentPlaceHolder1_txtTotalCurrencyForeign').value = "";
    document.getElementById('ContentPlaceHolder1_btnAdd').value = "Add";
    document.getElementById('ContentPlaceHolder1_ddlProduct').disabled = false;
    document.getElementById('ContentPlaceHolder1_txtDescription').disabled = false;
    document.getElementById('ContentPlaceHolder1_txtDescription').disabled = false;
}
function ClearHDTab() {
    document.getElementById('ContentPlaceHolder1_ddlLocalForeign').value = "0";
    document.getElementById('ContentPlaceHolder1_txtOrderDate').value = "";
    document.getElementById('ContentPlaceHolder1_ddlSupplier').value = "0";
    document.getElementById('ContentPlaceHolder1_ddlCurrency').value = "0";
    document.getElementById('ContentPlaceHolder1_txtBatchNo').value = "";
    document.getElementById('ContentPlaceHolder1_ddlProjectNo').value = "";
    document.getElementById('ContentPlaceHolder1_txtRef').value = "";
    document.getElementById('ContentPlaceHolder1_txtNoteHD').value = "";
    document.getElementById('ContentPlaceHolder1_ddlCrmAct').value = "0";
    document.getElementById('ContentPlaceHolder1_btnSubmit').value = "Submit";
}
function ClearOHTab() {
    document.getElementById('ContentPlaceHolder1_ddlOHType').value = "0";
    document.getElementById('ContentPlaceHolder1_txtOHAmntLocal').value = "";
    document.getElementById('ContentPlaceHolder1_txtNote').value = "";
    document.getElementById('ContentPlaceHolder1_txtAI').value = "";
    document.getElementById('ContentPlaceHolder1_btnOHCostAdd').value = "Add";
}

function checkSizeColorTextBox() {
    var tot = 0;
    var qty = document.getElementById('ContentPlaceHolder1_txtQuantity').value;
    document.getElementById("ContentPlaceHolder1_lnlQty").innerHTML = qty + " remaining out of " + qty;

}
function QuantityCount() {
    var tot = 0;
    var qtyMain = document.getElementById('ContentPlaceHolder1_txtQuantity').value;
    var qanMain = parseInt(qtyMain);
    var qty = document.getElementById('tblMSC').rows.length;
    var qan = parseInt(qty) - 1;
    var sumQty = parseInt(0);
    var flagChkQty = true;
    for (tot = 0; tot < qan; tot++) {
        var qtySC = "ContentPlaceHolder1_GridviewPopMC_txtMCQunty_" + tot
        var intQtySC = parseInt(document.getElementById(qtySC).value);
        sumQty = parseInt(sumQty) + intQtySC;
        if (qanMain < sumQty) {
            document.getElementById(qtySC).value = "";
            sumQty = parseInt(sumQty) - intQtySC;
            flagChkQty = false;
            $().toastmessage('showWarningToast', "You enter more then quantity.");
            break;
        }
        else {
        }
    }
    var varrem = qan - sumQty;
    document.getElementById("ContentPlaceHolder1_hidRemQty").value = varrem + " remaining out of " + qan;
}
function CheckQtyMCS() {
    var tot = 0;
    var qtyMain = document.getElementById('ContentPlaceHolder1_txtQuantity').value;
    var qanMain = parseInt(qtyMain);
    var qty = document.getElementById('tblMSC').rows.length;
    var qan = parseInt(qty) - 1;
    var sumQty = parseInt(0);
    var flagChkQty = true;
    for (tot = 0; tot < qan; tot++) {
        var qtySC = "ContentPlaceHolder1_GridviewPopMC_txtMCQunty_" + tot
        var intQtySC = parseInt(document.getElementById(qtySC).value);
        if (isNaN(intQtySC)) { intQtySC = 0; }
        if (intQtySC == 0) {
            $().toastmessage('showWarningToast', "Please enter the quantity.");
            flagChkQty = false;
            break;
        }
        else {
            sumQty = parseInt(sumQty) + intQtySC;
            if (qanMain < sumQty) {
                document.getElementById(qtySC).value = "";
                sumQty = parseInt(sumQty) - intQtySC;
                flagChkQty = false;
                $().toastmessage('showWarningToast', "You enter more quantity compare to main quantity.");
                break;
            }
            else {
            }
        }
    }
    if (flagChkQty == false)
        return false;
    else
        return true;
}
function showWarningToast() {

    var temp1 = document.getElementById('ContentPlaceHolder1_ddlSupplier');
    if (temp1.value == "0") {
        $().toastmessage('showWarningToast', "Please select the supplier.");
        return false;
    }
    var temp2 = document.getElementById('ContentPlaceHolder1_txtOrderDate');
    if (temp2.value == "") {
        $().toastmessage('showWarningToast', "Please select the order date.");
        return false;
    }
    if (rowsCount == 1) {
        $().toastmessage('showWarningToast', "Please create the atleast one purchase quotation.");
        return false;
    }
}
function validationGrid() {
    var temp1 = document.getElementById('ContentPlaceHolder1_ddlSupplier');
    if (temp1.value == "0") {
        $().toastmessage('showWarningToast', "Please select the supplier.");
        return false;
    }
    var temp2 = document.getElementById('ContentPlaceHolder1_txtOrderDate');
    if (temp2.value == "") {
        $().toastmessage('showWarningToast', "Please select the order date.");
        return false;
    }
    var temp3 = document.getElementById('ContentPlaceHolder1_gvPurQuat_ddlInsProductName');
    if (temp3.value == "0") {
        $().toastmessage('showWarningToast', "Please select the product.");
        return false;
    }
    var temp4 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsScheduleDate');
    if (temp4.value == "") {
        $().toastmessage('showWarningToast', "Please select the schedule date.");
        return false;
    }
    var temp5 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsUpriceFooter');
    if (temp5.value == "") {
        $().toastmessage('showWarningToast', "Please enter the unit price.");
        return false;
    }
    var temp6 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsQuantity');
    if (temp6.value == "") {
        $().toastmessage('showWarningToast', "Please enter the quantity.");
        return false;
    }
}
function showSuccessToast1() {
    $().toastmessage('showSuccessToast', "Purchase quotation updated successfully.");
}
function showSuccessToast2() {
    $().toastmessage('showSuccessToast', "Purchase quotation successfully confirm to purchase order.");
}
function showSuccessSendMail() {
    $().toastmessage('showSuccessToast', "Purchase quotation send successfully.");
}
function checkproduct() {
    var temp3 = document.getElementById("ContentPlaceHolder1_gvPurQuat_ddlInsProductName");
    var temp5 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsDescription');
    var temp1 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsDis');
    var temp2 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsTax');
    var temp4 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsUpriceFooter');
    var temp6 = document.getElementById('ContentPlaceHolder1_gvPurQuat_txtInsQuantity');

    //if (temp3.value == "0") {
    //    temp5.value = "";
    //    $().toastmessage('showWarningToast', "Please select the product.");
    //    return false;
    //}
    if (document.getElementById('ContentPlaceHolder1_anchorModelPopUp').style.display == "block") {
        var tot = 0;
        var qtyMain = document.getElementById('ContentPlaceHolder1_txtQuantity').value;
        var qanMain = parseInt(qtyMain);
        var qty = document.getElementById('tblMSC').rows.length;
        var qan = parseInt(qty) - 2;
        if (parseInt(qan) <= 0) {
            $().toastmessage('showWarningToast', "Please enter the multicolor or size.");
            return false;
        }
        else {
            var sumQty = parseInt(0);
            var flagChkQty = true;
            for (tot = 0; tot < qan; tot++) {
                var qtySC = "ContentPlaceHolder1_GridviewPopMC_txtMCQunty_" + tot
                var intQtySC = parseInt(document.getElementById(qtySC).value);
                sumQty = parseInt(sumQty) + intQtySC;
            }
            if (parseInt(sumQty) == qanMain) {
                return true;
            }
            else {
                $().toastmessage('showWarningToast', "Quantity not match with sizecolor.");
                return false;
            }
        }
        return false;
    }
    else {
        var strUser = temp3.options[temp3.selectedIndex].text;
        if (temp3.value != "")
            temp5.value = strUser;
    }
}

var TotDebit = 0.00;
var flag = true;
function checkdate1(textbox) {
    var disc_id = textbox.id;
    var txtDis = disc_id.replace("txtDiscount", "txtTotalCurrencyForeign");
    var txtTax = disc_id.replace("txtTax", "txtTotalCurrencyForeign");
    var txtUPrice = disc_id.replace("txtUPriceForeign", "txtTotalCurrencyForeign");
    var txtLPrice = disc_id.replace("txtUPriceLocal", "txtTotalCurrencyForeign");
    var txtQun = disc_id.replace("txtQuantity", "txtTotalCurrencyForeign");
    var unitPriceValue = $(".uprice").val();
    var unitPriceLValue = $(".lprice").val();
    //s = s.substring(0, s.indexOf('?'));
    //document.write(s);
    var taxValue = $(".tax").val();
    var quantityValue = $(".quntity").val();
    var disValue = $(".dis").val();
    var Subtotal = $(".subtotal");
    var tempSubtol = unitPriceValue * quantityValue;
    var tempLSubtol = unitPriceLValue * quantityValue;
    if (disValue.indexOf("%") > -1) {
        var dis = disValue.replace("%", "");
        var totAmountDis = tempSubtol - (tempSubtol * (dis / 100));
        var totLAmountDis = tempLSubtol - (tempLSubtol * (dis / 100));
        //var totAmount = totAmountDis + (totAmountDis * (taxValue / 100));
        //var totLAmount = totLAmountDis + (totLAmountDis * (taxValue / 100));
    }

    else {
        var totAmountDis = tempSubtol - disValue;
        var totLAmountDis = tempLSubtol - disValue;
        //var totAmount = totAmountDis + taxValue;
        //var totLAmount = totLAmountDis + taxValue;
    }

    //var LocalandForeign = document.getElementById('ContentPlaceHolder1_ddlLocalForeign');
    //var LocalandForeignValue = LocalandForeign.options[LocalandForeign.selectedIndex].text;
    //var totAmount = 0;
    //var totLAmount;
    //if (LocalandForeignValue == "Local") {
    //    totAmount = 0;
    //}
    //else {
    totAmount = totAmountDis + (totAmountDis * (taxValue / 100));
    totLAmount = totLAmountDis + (totLAmountDis * (taxValue / 100));
    //}
    var T1 = parseFloat(totAmount);
    var T1L = parseFloat(totLAmount);
    var T2Tax = parseFloat(taxValue);
    var T3Qnty = parseFloat(quantityValue);
    var T4Dis = disValue;
    var T5UPrice = parseFloat(unitPriceValue);
    var T6LPrice = parseFloat(unitPriceLValue);

    if (isNaN(T1)) { T1 = 0; }
    if (isNaN(T1L)) { T1L = 0; }
    if (isNaN(T2Tax)) { T2Tax = 0; }
    if (isNaN(T3Qnty)) { T3Qnty = 0; }
    // if (isNaN(T4Dis)) { T4Dis = 0; }
    if (isNaN(T5UPrice)) { T5UPrice = 0; }
    if (isNaN(T6LPrice)) { T6LPrice = 0; }

    if (txtDis.indexOf("txtTotalCurrencyForeign") > -1) {
        document.getElementById(txtDis).value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtDiscount").value = T4Dis;
        document.getElementById("ContentPlaceHolder1_txtUPriceForeign").value = T5UPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtQuantity").value = T3Qnty;
        document.getElementById("ContentPlaceHolder1_txtTax").value = T2Tax.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyLocal").value = totLAmount.toFixed(2);
    }
    else if (txtTax.indexOf("txtTotalCurrencyForeign") > -1) {
        document.getElementById(txtTax).value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtDiscount").value = T4Dis;
        document.getElementById("ContentPlaceHolder1_txtUPriceForeign").value = T5UPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtQuantity").value = T3Qnty;
        document.getElementById("ContentPlaceHolder1_txtTax").value = T2Tax.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
    }
    else if (txtUPrice.indexOf("txtTotalCurrencyForeign") > -1) {
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
        document.getElementById(txtUPrice).value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtDiscount").value = T4Dis;
        document.getElementById("ContentPlaceHolder1_txtUPriceForeign").value = T5UPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtQuantity").value = T3Qnty;
        document.getElementById("ContentPlaceHolder1_txtTax").value = T2Tax.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
    }
    else if (txtLPrice.indexOf("txtUPriceLocal") > -1) {
        document.getElementById(txtLPrice).value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtDiscount").value = T4Dis;
        document.getElementById("ContentPlaceHolder1_txtUPriceForeign").value = T5UPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtQuantity").value = T3Qnty;
        document.getElementById("ContentPlaceHolder1_txtTax").value = T2Tax.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
    }
    else {
        document.getElementById(txtQun).value = T1.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtDiscount").value = T4Dis;
        document.getElementById("ContentPlaceHolder1_txtUPriceForeign").value = T5UPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtQuantity").value = T3Qnty;
        document.getElementById("ContentPlaceHolder1_txtTax").value = T2Tax.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidUPriceLocal").value = T6LPrice.toFixed(2);
        document.getElementById("ContentPlaceHolder1_txtTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyLocal").value = totLAmount.toFixed(2);
        document.getElementById("ContentPlaceHolder1_hidTotalCurrencyForeign").value = T1.toFixed(2);
    }
    document.getElementById("ContentPlaceHolder1_divItem").style.display = "block";
    //document.getElementById("ContentPlaceHolder1_lblTotalPrice").innerHTML = TotDebit.toFixed(2);
}

function checkNumber(textbox) {
    var disc_id = textbox.id;
    var disval = document.getElementById(disc_id).value;
    if (disval >= 0 && disval <= 100) {
        return true;
    }
    else {
        document.getElementById(disc_id).value = parseFloat(0).toFixed(2);
        $().toastmessage('showWarningToast', "Please enter a number between 0-100.");
        return false;
    }
}
function checkUnitprice(textbox) {
    var disc_id = textbox.id;
    var disval = document.getElementById(disc_id).value;
    if (disval >= 0 && disval <= 9999999999) {
        return true;
    }
    else {
        document.getElementById(disc_id).value = parseFloat(0).toFixed(2);
        $().toastmessage('showWarningToast', "Please enter a number between 0-9999999999.");
        return false;
    }
}
function checkQuntity(textbox) {
    var disc_id = textbox.id;
    var disval = document.getElementById(disc_id).value;
    if (disval >= 0 && disval <= 999999) {
        return true;
    }
    else {
        document.getElementById(disc_id).value = parseFloat(0).toFixed(2);
        $().toastmessage('showWarningToast', "Please enter a number between 0-999999.");
        return false;
    }
}
function showhidepanel(va) {
    if (va == "lst") {
        document.getElementById("ContentPlaceHolder1_pnlCreateForm").style.display = "none";
        document.getElementById("ContentPlaceHolder1_pnlGridView").style.display = "block";
    }
    else if (va == "frm") {
        document.getElementById("ContentPlaceHolder1_pnlCreateForm").style.display = "block";
        document.getElementById("ContentPlaceHolder1_pnlGridView").style.display = "none";
    }
}
//function ClearScheDelTab() {
//    document.getElementById('ContentPlaceHolder1_ddlProductMCS').value = "0";
//    document.getElementById('ContentPlaceHolder1_txtScheDate').value = "";
//    document.getElementById('ContentPlaceHolder1_txtLTD').value = "";
//    document.getElementById('ContentPlaceHolder1_txtQTD').value = ""; 
//    document.getElementById('ContentPlaceHolder1_txtDAD').value = "";
//    document.getElementById('ContentPlaceHolder1_txtQAD').value = "";
//    document.getElementById('ContentPlaceHolder1_btnSchDelAdd').value = "Add";
//}