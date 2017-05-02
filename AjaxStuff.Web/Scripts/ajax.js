$(function () {

    $('.btn-success').on('click', function () {
        var params = {
            min: $("#min").val(),
            max: $("#max").val()
        }
        $.get('/home/getrandom', params ,function (data) {
            data.randomNumbers.forEach(function(num) {
                $("#my-div").append("<h1>" + num + "</h1>");
            });
        });
    });


    $("#reverse-text").on('click',function() {
        $.post('/home/reverse', { text: $("#input-text").val() }, function (data) {
            console.log(data);
            $("#my-div").append(`<h1>${data.ReversedText}</h1>`);
        });
    });
});