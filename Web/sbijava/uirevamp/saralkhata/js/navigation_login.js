/*Top Navigation Hover*/
$(document).ready(function(){
	var obj;
	var objIndex = $('#navigation li').index($('.active_menu'));
	var positionLeft = ["20px","82px","435px","357px","464px"];
	var positionWidth = [$('.active_menu a').css('width'),"168px","57px","82px","53px"];
	$('#navigation li.menu_hoverbtm').css({left:positionLeft[objIndex],width:positionWidth[objIndex]}); 	
	if(objIndex < 0){
		$('.menu_hoverbtm').hide();
	}
	
	$('#navigation li a').mouseover(function(){
		obj = $(this);	
		animateMenu(obj);								 
	}); 
	
	$('#navigation').mouseleave(function(){
		setMenuDefault();						 
	}); 
	
	$('#navigation li a').focus(function(){
		obj = $(this);	
		animateMenu(obj);	
	});
	
	$('#navigation li a').blur(function(){
		setMenuDefault();
	});
	
	function animateMenu(obj){
		var position = obj.position();
		var thiswidth = obj.width();
		$('#navigation li.menu_hoverbtm').stop().show().animate({left:(position.left-5),width:(thiswidth)},600); 
	}
	
	
	function setMenuDefault(){ 
		$('#navigation li.menu_hoverbtm').stop().animate({left:positionLeft[objIndex],width:positionWidth[objIndex]},600); 	
		if(objIndex < 0){
			$('.menu_hoverbtm').hide();
		}
	}
	
	
}); 