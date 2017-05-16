

$(function () {

    $("#ddlCustomer").change(function () {

        var customer = $(this).val();

        if (customer != "" && customer != null) {
            $.post("/Tools/GetAddress.ashx", { cid: customer }, function (data) {

                $("#ddlAddress").html(data.strAddress);
                $("#ddlPublicversion").html(data.strVersion);

            }, "json")
        }


    })


    $("#ddlDelivery").change(function () {

        var did = $(this).val();

        $.post("/Tools/GetDelivery.ashx", { did: did }, function (data) {

            $("#ddlDeliverystaff").html(data.strDelivery);

        }, "json")

    })




})



