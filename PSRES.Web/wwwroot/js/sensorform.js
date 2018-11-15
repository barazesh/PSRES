$(document).ready(function () {
    var form = $("#sensorData li");
    var button = $("#getButton");
    button.on("click", function () {
        form.slideToggle(500);
    });

    form.on("click", function () {
        console.log("hi you clicked on" + $(this).text());
    })
    form.hide();
});