$(document).ready(function () {

    var dutycyclecheck = $("#dutycyclecontrolradio");
    var dutycyclefield = $("#dutycyclecontrolfield");
    var frequencycheck = $("#frequencycontrolradio");
    var frequencyfield = $("#frequencycontrolfield");
    var setbutton = $("#setbutton");
    var selectallcheck = $("#controlalllamps");
    var lampselector = $("#lampselector");

    dutycyclecheck.click(function () {
        if (dutycyclecheck.prop("checked")) {
            dutycyclefield.prop("disabled", false);


            frequencyfield.prop("disabled", true);
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
            frequencyfield.prop("disabled", false);


            dutycyclefield.prop("disabled", true);
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

});