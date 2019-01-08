$(document).ready(function () {

    var dutycycleradio = $("#dutycyclecontrolradio");
    var dutycyclenumber = $("#dutycyclecontrolnumber");
    var dutycyclerange = $("#dutycyclecontrolrange");
    var frequencyradio = $("#frequencycontrolradio");
    var frequencynumber = $("#frequencycontrolnumber");
    var frequencyrange = $("#frequencycontrolrange");
    var selectallcheck = $("#controlalllamps");
    var lampselector = $("#lampselector");
    var lampnumber = $(".verticallamplabel , .horizontallamplabel");

    


    dutycycleradio.on("input", function () {
            dutycyclenumber.prop("disabled", false);
            dutycyclerange.prop("disabled", false);

            frequencynumber.prop("disabled", true);
            frequencyrange.prop("disabled", true);
    })




    frequencyradio.on("input", function () {

            dutycyclenumber.prop("disabled", true);
            dutycyclerange.prop("disabled", true);

            frequencynumber.prop("disabled", false);
            frequencyrange.prop("disabled", false);
    })



    selectallcheck.click(function () {
        if (selectallcheck.prop("checked")) {
            lampselector.prop("disabled", true);
        } else {
            lampselector.prop("disabled", false);
        }
    })

    dutycyclenumber.on("input", function () {
        dutycyclerange.val(dutycyclenumber.val());
    })

    dutycyclerange.on("input", function () {
        dutycyclenumber.val(dutycyclerange.val());
    })


    frequencynumber.on("input", function () {
        frequencyrange.val(frequencynumber.val());
    })

    frequencyrange.on("input", function () {
        frequencynumber.val(frequencyrange.val());
    })


    lampnumber.click(function () {
        lampselector.val($(this).text());
    })

});