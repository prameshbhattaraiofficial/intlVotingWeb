function RateProductType() {
    var ProductType = $("#ProductType").val();
    var url = "/Rates/GetProductFromType" + '?' + "ProductType=" + ProductType;
    var decodeurl = decodeURIComponent(url);
    $.ajax({
        type: "GET",
        url: decodeurl,
        data: ProductType,
        success: function (res) {
            var items = '<option value=" ">--All--</option > ';
            $.each(res, function (i, Producttype) {
                console.log(Producttype);
                items += "<option value='" + Producttype.value + "'>" + Producttype.text + "</option>";
            });
            $("#ProductCode").html(items);
        }
    })
};





