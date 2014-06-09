$(function () {

    $.fn.CallAutoCompleteService = function (settings) {

        if (settings == null)
            return false;

        $(this).autocomplete({

            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: settings.method,
                    data: "{'" + settings.parameter + "':'" + request.term + "'}",
                    dataType: "json",
                    async: true,
                    success: function (data) {
                        //response(data.d);
                        var results = data.d;
                        response(results.slice(0, 15));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
//                        alert("readyState: " + XMLHttpRequest.readyState + "\nstatus: " + XMLHttpRequest.status);
//                        alert("responseText: " + XMLHttpRequest.responseText);
//                        alert(errorThrown);
                    }
                });


            },
            minLength: settings.minLength

        });

        return true;

    };

//    //Setup loader for AJAX call
//    $("body").on({
//        ajaxStart: function () {
//            $(this).addClass("loading");
//        },
//        ajaxStop: function () {
//            $(this).removeClass("loading");
//        }
//    });        

    


});

