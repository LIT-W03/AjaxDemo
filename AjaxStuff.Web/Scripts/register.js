$(function () {
    $("#username").on('keyup', function () {
        var text = $(this).val();
        $.post('/home/UsernameExists', { username: text }, function (data) {
            if (data.exists) {
                $("#username-div").addClass('has-error');
                $("#register").prop('disabled', true);
            } else {
                $("#username-div").removeClass('has-error');
                $("#register").prop('disabled', false);
            }
        });
    });

    $("#get-cars").on('click', function () {
        $.get('/home/getcars', function (cars) {
            $("#cars li").remove();
            cars.forEach(function(car) {
                $("#cars").append(`<li data-id="${car.Id}">${car.Make} - ${car.Model} - ${car.Year}`);
            });
        });
    });
})