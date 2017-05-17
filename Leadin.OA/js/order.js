

$(function () {

    $("#ddlCustomer").change(function () {

        var customer = $(this).val();

        if (customer != "" && customer != null) {
            $.post("/Tools/GetAddress.ashx", { cid: customer }, function (data) {

                $("#ddlAddress").html(data.strAddress);
                $("#ddlPublicversion").html(data.strVersion);

            }, "json")
        }
        else
        {
            $("#ddlAddress").html("<option value=\"\">请选择收货信息</option>");
            $("#ddlPublicversion").html("<option value=\"\">请选择公版</option>");
        }

    })


    $("#ddlDelivery").change(function () {

        var did = $(this).val();
        if (did == "")
        {
            $("#ddlDeliverystaff").html("<option value=\"\">请选择配送人</option>");
        }
        else
        { 
        $.post("/Tools/GetDelivery.ashx", { did: did }, function (data) {

            $("#ddlDeliverystaff").html(data.strDelivery);

        }, "json")
        }
    })




})



