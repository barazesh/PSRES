$(document).ready(function () {

    var dutycyclecheck = $("#dutycyclecontrolradio");
    var dutycyclenumber = $("#dutycyclecontrolnumber");
    var dutycyclerange = $("#dutycyclecontrolrange");
    var frequencycheck = $("#frequencycontrolradio");
    var frequencynumber = $("#frequencycontrolnumber");
    var frequencyrange = $("#frequencycontrolrange");
    var setbutton = $("#setbutton");
    var selectallcheck = $("#controlalllamps");
    var lampselector = $("#lampselector");
    var lampnumber = $(".lamplabel");

    dutycyclecheck.click(function () {
        if (dutycyclecheck.prop("checked")) {
            dutycyclenumber.prop("disabled", false);
            dutycyclerange.prop("disabled", false);



            frequencynumber.prop("disabled", true);
            frequencyrange.prop("disabled", true);

            frequencycheck.prop("checked", false);
            setbutton.prop("disabled", false);
        } else {
            if (!(frequencycheck.prop("checked"))) {
                setbutton.prop("disabled", true);

            }
        }

    })
    
    frequencycheck.on("click", function () {
        if (frequencycheck.prop("checked")) {
            dutycyclenumber.prop("disabled", true);
            dutycyclerange.prop("disabled", true);


            frequencynumber.prop("disabled", false);
            frequencyrange.prop("disabled", false);


            dutycyclecheck.prop("checked", false);
            setbutton.prop("disabled", false);
        } else {
            if (!(dutycyclecheck.prop("checked"))) {
                setbutton.prop("disabled", true);
            }
        }
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