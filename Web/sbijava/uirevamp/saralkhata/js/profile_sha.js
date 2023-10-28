function verifyProfilePasswordSha(formname)
{
	var formObj=eval("document."+formname);
	if(formObj.profilePassword.value == "")
	{
		alert("Enter profile password");
		formObj.profilePassword.focus();
		return false;
	}
	encryptSha2ProfilePassword(formname,"profilePassword", "shaprofpassword");
	encryptPassword(formname,"profilePassword");
	//alert(formObj.shaprofpassword.value);
	formObj.submit();
}

function profilePWDValidationSha(formname)
{
	var changeFromObj=eval("document."+formname);
	var newpass=eval("document."+formname+".newPassword.value");
	var profpassword =eval("document."+formname+".profpassword");
	profpassword.value = newpass;
	if(changeFromObj.oldProfilePassword.value == ""){
		alert("Enter old profile password");
		changeFromObj.oldProfilePassword.focus();
		return false;
	}		
	else if(changeFromObj.newPassword.value == ""){
		alert("Enter new profile Password");
		changeFromObj.newPassword.focus();
		return false;
	}
	else if(changeFromObj.confirmPassword.value == ""){
		alert ("Re-type the new profile Password");
		changeFromObj.confirmPassword.focus();
		return false;
	}else if(changeFromObj.newPassword.value == changeFromObj.oldProfilePassword.value){
		alert("Old profile password and new profile password cannot be the same");
		changeFromObj.newPassword.focus();
		return false;
	}		
	else if(changeFromObj.newPassword.value != changeFromObj.confirmPassword.value ){
		alert("New profile password and Re-type new profile password fields should match");
		changeFromObj.confirmPassword.focus();
		return false;
	}		
	else if(!passwordCheck(changeFromObj.newPassword.value)){
		changeFromObj.newPassword.focus();
		return false;	
	}
	else{
		encryptSha2ProfilePassword(formname,"newPassword", "shaprofpassword");
	   encryptPassword(formname,"newPassword");	   
	   var encConfirmPwd=eval("document."+formname+".newPassword.value");
	   var confirmpass=eval("document."+formname+".confirmPassword");
	   confirmpass.value=encConfirmPwd;
	   
	   changeFromObj.submit();	
	}
}	

function validateSetPasswordSha(formname){
   	var formObj=eval("document."+formname);
	var newpass=eval("document."+formname+".profilePassword.value");
	var profpassword =eval("document."+formname+".profpassword");
	profpassword.value = newpass;
	
	if(formObj.profilePassword.value == ""){
		alert("Enter profile password");
		formObj.profilePassword.focus();
		return false;
	}		
	else if(formObj.confirmprofilePassword.value == ""){
		alert("Enter confirm password");
		formObj.confirmprofilePassword.focus();
		return false;
	}else if(formObj.profilePassword.value != formObj.confirmprofilePassword.value){
		alert("Profile password and confirm password should be the same");
		formObj.profilePassword.focus();
		return false;
	}else if(!passwordCheck(formObj.profilePassword.value))
		return false;
	//if(document.getElementById("hintQuestion") != null){
		if(formObj.hintQuestion.value == ""){
			alert("Select hint question");
			formObj.hintQuestion.focus();
			return false;
		}else if(formObj.hintAnswer.value == ""){
			alert("Enter hint answer");
			formObj.hintAnswer.focus();
			return false;
		}else if(!checkanswer("setProfilePwd","hintAnswer","hint answer"))
			return false;
	//}
	
	if(!validateDOBPOB(formObj,'no'))
		return false;
		encryptSha2ProfilePassword(formname,"profilePassword", "shaprofpassword");
	   encryptPassword(formname,"profilePassword");
	   var encConfirmPwd=eval("document."+formname+".profilePassword.value");
	   var confirmpass=eval("document."+formname+".confirmprofilePassword");
	   confirmpass.value=encConfirmPwd;
	   formObj.submit();	
}

function submitLoginSha(md5KeyValue)
{   	
	//added for CR 5034 - begin.
	var username ="";
	var errorCode = document.quickLookForm.errorCode.value;
	if (errorCode!=null && errorCode == 'K001'){
		username = document.quickLookForm.kModeUserName.value;// user name from tmpl_style
		//alert("11"+username);
	}
	else{
		username = document.quickLookForm.userName.value;		
		//alert("22"+username);
	}
	//added for CR 5034 - end.
	var password= document.quickLookForm.password.value;
	var regexp = new RegExp("\\d{19}");
	if(username==""){
		alert("Enter username");
		document.quickLookForm.userName.focus();
		return false;
	}
	else if(password=="")
	{
		alert("Enter password");
		document.quickLookForm.password.focus();
		return false;
	}  
	else{
		if( password.length>20){
			alert("Password length should not be more than 20 characters");
			document.quickLookForm.password.value="";
			document.quickLookForm.password.focus();
			return false;
		}

        document.getElementById("Button2").disabled=true;
        var md5keystring = md5KeyValue;//document.quickLookForm.md5key.value ;
       // var md5keystring = document.quickLookForm.md5key.value ;
		var encSaltPass=encryptLoginPassword(md5keystring,username,password);
		var encSaltSHAPass=encryptSha2LoginPassword(md5keystring,username,password);
		document.quickLookForm.password.value=encSaltPass; //changed
		document.quickLookForm.shapassword.value=encSaltSHAPass; //changed
		document.quickLookForm.action="loginsubmit.html"
		document.quickLookForm.submit();
		
	}
	return true;
}

function encryptSha2ProfilePassword(formname,strpwd,inpfld){
	try{
		var username=eval("document."+formname+".username.value");
		var profPass=eval("document."+formname+"."+strpwd+".value");
		var shaHash =username+"|"+profPass;
		var encString = CryptoJS.SHA512(shaHash); 
		//aruna
		var ppf=eval("document."+formname+"."+inpfld);
		ppf.value=encString;
	}catch(error){
	}
}

//unlock user id changes by manju starts
function encryptUnlockUserID(md5KeyValue)
{   	
	
	var username =document.unlockUserForm.userName.value;		
	var password= document.unlockUserForm.password.value;
	var captchaValue= document.unlockUserForm.unlockUsercaptcha.value;
	var regexp = new RegExp("\\d{19}");
	if(username==""){
		alert("Enter username");
		document.unlockUserForm.userName.focus();
		var password ="";
		return false;
	}
	else if(password=="")
	{
		alert("Enter password");
		document.unlockUserForm.password.focus();
		return false;
	} else if(captchaValue=="")
	{
		alert("Enter the text as shown in the image");
		document.unlockUserForm.unlockUsercaptcha.focus();
		var password ="";
		return false;
	} 
	else{
		if( password.length>20){
			alert("Password length should not be more than 20 characters");
			document.unlockUserForm.password.value="";
			document.unlockUserForm.password.focus();
			var password ="";
			return false;
		}

        document.getElementById("confirm").disabled=true;
        var md5keystring = md5KeyValue;
		var encSaltPass=encryptLoginPassword(md5keystring,username,password);
		var encSaltSHAPass=encryptSha2LoginPassword(md5keystring,username,password);
		document.unlockUserForm.password.value=encSaltPass; //changed
		document.unlockUserForm.shapassword.value=encSaltSHAPass; //changed
		document.unlockUserForm.action="unlockUserInterim.html";
		document.unlockUserForm.submit();
		
	}
	var password ="";
	return true;
}
