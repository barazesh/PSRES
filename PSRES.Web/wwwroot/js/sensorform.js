alert("sensor form loaded");
var form = $("#sensorData li");
var button = document.getElementById("getButton");
button.on("click", function () {
    form.hidden = false;
    for (var i = 0; i < form.length; i++) {
        form[i].innerText = form[i].innerText + "hi"

    }
    alert("getting data");
})
form.hide();
