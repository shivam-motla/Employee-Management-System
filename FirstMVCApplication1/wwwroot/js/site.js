// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//$(function () {
    $('#country_add').change(function () {
        var cty = $('#inputCountry').val();
		$("#inputState").removeAttr('disabled');
		
		switch (cty) {
			case 'India':
				//$("#inputState").replaceWith(('<div class = "div"></div>'));
				$("#inputState").html('<option selected>Choose...</option> <option>UP</option > <option>Delhi</option><option>Rajasthan</option>');
				break;
			case 'US':
				
				$("#inputState").html('<option selected>Choose...</option> <option>Los Vegas</option > <option>New York</option><option>Florida</option>');
				break;
			case 'Russia':
				$("#inputState").html('<option selected>Choose...</option> <option>Moscow</option > <option>Ukrain</option>');
				break;
			case 'Other country':
				alert('not added');
				break;
			default:
				
				$("#inputState").attr('disabled', 'disabled');
		}
    });

$('#change_view').change(function () {
	//var ch = $('#switch').val();
	var ch = $('#switch').is(":checked");
	if (ch == false) {
		$("#table_view").hide();
		$("#card_view").show();
	}
	else {
		$("#table_view").show();
		$("#card_view").hide();
	}
	
});




