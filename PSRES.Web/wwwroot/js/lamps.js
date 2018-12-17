$(document).ready(function () {

    var dutycycleradio = $("#dutycyclecontrolradio");
    var dutycyclenumber = $("#dutycyclecontrolnumber");
    var dutycyclerange = $("#dutycyclecontrolrange");
    var frequencyradio = $("#frequencycontrolradio");
    var frequencynumber = $("#frequencycontrolnumber");
    var frequencyrange = $("#frequencycontrolrange");
    var setbutton = $("#setbutton");
    var selectallcheck = $("#controlalllamps");
    var lampselector = $("#lampselector");
    var lampnumber = $(".lamplabel");


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




    //dutycycleradio.on("input", function () {
    //    if (dutycycleradio.prop("checked")) {

    //        dutycyclenumber.prop("disabled", false);
    //        dutycyclerange.prop("disabled", false);

    //        frequencynumber.prop("disabled", true);
    //        frequencyrange.prop("disabled", true);

    //        setbutton.prop("disabled", false);
    //    } else {
    //        if (!(frequencyradio.prop("checked"))) {
    //            setbutton.prop("disabled", true);
    //        }
    //    }

    //})



    
    //frequencyradio.on("input", function () {
    //    if (frequencyradio.prop("checked")) {

    //        dutycyclenumber.prop("disabled", true);
    //        dutycyclerange.prop("disabled", true);

    //        frequencynumber.prop("disabled", false);
    //        frequencyrange.prop("disabled", false);

    //        setbutton.prop("disabled", false);
    //    } else {
    //        if (!(dutycycleradio.prop("checked"))) {
    //            setbutton.prop("disabled", true);
    //        }
    //    }
    //})

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