$(document).ready(function () {


    $('.checkout').click(function () {

        $.ajax({
            url: "/Home/EnviarDados",
            method: "post",
            type: "json",
            success: function (data) {
                window.location = data;
            }

        });

    });


});