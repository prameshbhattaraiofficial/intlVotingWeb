function BindProductList() {
    var ProductTypeId = $("#ProductTypes").val();
    var url = "/Rates/GetProductFromType" + '?' + "ProductType=" + ProductTypeId;
    var decodeurl = decodeURIComponent(url);
    $.ajax({
        type: "GET",
        url: decodeurl,
        data: ProductTypeId,
        success: function (res) {
            var items = '<option value=" ">--All--</option > ';
            $.each(res, function (i, Producttype) {
                console.log(Producttype);
                items += "<option value='" + Producttype.value + "'>" + Producttype.text + "</option>";
            });
            $("#Products").html(items);
        }
    })
}