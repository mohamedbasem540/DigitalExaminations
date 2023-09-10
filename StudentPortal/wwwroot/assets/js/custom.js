
$(document).ready(function() {
	'use strict';

  // $('.test-step .button').on('click', function(e) {
  // 	e.preventDefault();
  //   $(this).parents('.test-step').next().addClass('active');
  //   $(this).parents('.test-step').removeClass('active');
  // })

  // $('.test-step .prev-btn').on('click', function(e) {
  //   e.preventDefault();
  //   $(this).parents('.test-step').prev().addClass('active');
  //   $(this).parents('.test-step').removeClass('active');
  // })

    function togglePassword() {
        let input = document.getElementById("Password");
        var eye = document.getElementById("eye");
        var eyeSlash = document.getElementById("eye-slash");

        if (input.type === "password") {
            input.type = "text"
            eye.style.display = "none";
            eyeSlash.style.display = "inline";
        } else {
            input.type = "password"
            eye.style.display = "inline";
            eyeSlash.style.display = "none";
        }
    }

    $('.pass-toggler-btn').on('click', 'i', function () {
        togglePassword();
    })

})
