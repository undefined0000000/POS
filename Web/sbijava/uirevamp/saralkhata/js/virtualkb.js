var fieldObj;
var bCaps=false;
var focus_count=0;
var sHTML="";
var tempVk ="";
function getArr()
{
var keyArr=[['~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+'],
			  		['`', ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'], '-', '='],
			  		[['q', 'w', 'e', 'r', 't'], ['y', 'u', 'i', 'o', 'p'], '{', '}', '|'],
			  		[['a', 's', 'd', 'f', 'g'], ['h', 'j', 'k', 'l'], '[', ']', '\\', '/'],
			  		[['z', 'x', 'c', 'v'], ['b', 'n', 'm'], '<', '>', ';', ':', '\'', '"'],
			  		[',', '.', '?']];

return (keyArr);
}
function getFocus(x) {
	
	fieldObj=document.getElementById(x);
}
function constructKeyboard(bool) {
	
	var check;
	if(typeof(bool) == 'undefined')
		check= document.getElementById('chkbox').checked;
	else
		check = bool;
	var keyArr = getArr();
	var str_trco="</tr><tr>";
	sHTML="<table	border='0' class='keyboardtb_new' cellspacing='3px' id='keypad' width='95%'><tr><td class='key_head' colspan='13'>Online Virtual Keyboard</td></tr><tr>";
	var dHTML="";
	for (var i=0; i<keyArr.length-1; i++){
		//alert(keyArr[i].length)
		for (var j=0; j<keyArr[i].length; j++){
			var code;
			if(typeof(keyArr[i][j])=='object'){
				while(keyArr[i][j].length>0){
					var ix=Math.floor(Math.random()*keyArr[i][j].length);
					var ch=keyArr[i][j].splice(ix,1);
					code=ch[0].charCodeAt(0);
					if(!check){
						sHTML="<table border='0' class='keyboardtbl' cellspacing='3px' id='keypad' width='100%'><tr><td><img src='images/login_img.png' alt='login image' /></td></tr></table>";
					}
					else
					{
						sHTML+="<td onClick='putChar(" + code + ")' class='keyboardtblenb'>" + ch + "</td>";
					}
				}
			}else{
				code=keyArr[i][j].charCodeAt(0);
				if(check)
					sHTML+="<td onClick='putChar(" + code + ")' class='keyboardtblenb'>" + keyArr[i][j] + "</td>";
				else
					sHTML="<table	border='0' class='keyboardtbl' cellspacing='3px' id='keypad' width='100%'><tr><td><img src='images/login_img.png' width='100%' alt='login image' /></td></tr></table>";
					//dHTML="<span id='logimg'><img src='images/login_img.png' alt='login image' /></span>";
			}
		}
		sHTML+=str_trco;
	}
	if(check){
	sHTML+="<td colspan='5' id='cap' onClick='setCaps(this)' class='keyboardtblenb' style='background:#E9EFF3;padding:5px 7px; width:100px; font-size:85%;'>CAPS LOCK</td>";
	sHTML+="<td colspan='5' id='clr' onClick='setClearAll()' class='keyboardtblenb' style='background:#E9EFF3;padding:5px 7px; width:100px; font-size:85%;'>CLEAR</td>";}
	else{
		sHTML="<table	border='0' class='keyboardtbl' cellspacing='3px' id='keypad' width='100%'><tr><td><img src='images/login_img.png' alt='login image' /></td></tr></table>";
	}
	var codeArray = new Array();
	for (var i=0; i<3; i++){
		codeArray[i]=keyArr[5][i];
	}
	shuffle(codeArray);
	for (var i=0; i<3; i++){
		var code=codeArray[i].charCodeAt(0);
		if(check)
			sHTML+="<td onClick='putChar(" + code + ")' class='keyboardtblenb' >" + codeArray[i] + "</td>";
		else
			sHTML="<table	border='0' class='keyboardtbl' cellspacing='3px' id='keypad' width='100%'><tr><td><img src='images/login_img.png' alt='login image' /></td></tr></table>";
	}
	sHTML+="</tr></table>";
	document.getElementById('kbplaceholder').innerHTML = sHTML;
}
shuffle = function(v){
    for(var j, x, i = v.length; i; j = parseInt(Math.random() * i), x = v[--i], v[i] = v[j], v[j] = x);
    return v;
};
function putChar(code){
	if(fieldObj.value.length < 20){
		var keycode=(code>96 && code<123 && bCaps) ? code-32 : code;
		var text=String.fromCharCode(keycode);
			fieldObj.value += text;
			setCaretTo();
	}
}
function setCaretTo(){
	var pos=fieldObj.value.length;
	if(fieldObj.createTextRange){
		var range=fieldObj.createTextRange();
		range.move('character', pos);
		range.select();
	}else if(fieldObj.selectionStart){
		fieldObj.focus();
		fieldObj.setSelectionRange(pos, pos);
	}
}
function changeCase(){
	var alphabets = document.getElementById('keypad').getElementsByTagName('TD');
	for(var i=0; i<alphabets.length; i++){
		var ch = alphabets[i].innerHTML;
		if((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') && ch.length==1){
			alphabets[i].innerHTML = bCaps ? ch.toUpperCase() : ch.toLowerCase();
		}
	}
}
function setCaps(obj){
	bCaps = !(bCaps);
	toggleCap(obj);
	changeCase();
}
function toggleCap(obj){
	 var str = bCaps ? "CAPS LOCK" : "CAPS LOCK";
	 obj.innerHTML = str;
}
function setClearAll(){
	fieldObj.value = "";
	fieldObj.focus();
}

function backspacevk(){
	var profpass;  
	profpass = document.getElementsByName(fieldObj.name+'enc')[0];
	//alert(profpass.value);
	var pfvaluevk = profpass.value;
	var len = pfvaluevk.length;
	if(pfvaluevk.lastIndexOf("|^|") == -1){
		profpass.value = "";
		fieldObj.value = "";
		return;
	}else if(pfvaluevk.lastIndexOf("|^|") == (pfvaluevk.length-3)){
		pfvaluevk = pfvaluevk.substring(0,pfvaluevk.lastIndexOf("|^|"));	
	}else{
		alert("error while doing backspace");
	} 
	
	if(pfvaluevk.lastIndexOf("|^|")!= -1){
		profpass.value = pfvaluevk.substring(0,pfvaluevk.lastIndexOf("|^|") +3);
	}else{
		profpass.value = "";
	}
	
	//alert(profpass.value);
	fieldObj.value = fieldObj.value.substring(0,fieldObj.value.length-1);
}

function vkClear(){
	fieldObj.value="";
	var encField= document.getElementById(fieldObj.name + 'enc');
	if(encField == null ) {
		encField= document.getElementById(fieldObj.id + 'enc');
	}	 
	encField.value="";
	return true;
}


