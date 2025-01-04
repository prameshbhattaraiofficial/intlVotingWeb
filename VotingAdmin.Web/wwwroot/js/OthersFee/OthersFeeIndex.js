function ChangePagesize(url, data) {
    var decodeurl = decodeURIComponent(url).split("/");
    var urlsplit = decodeurl[1];
    console.log(url, "Url");
  
    var FilterDetails = {
        searchVal: $('#tblSearch_' + urlsplit).val(),
        pageNumber: data,
        pageSize: $('#pagesize_' + urlsplit).find('option:selected').val(),
        serviceTypeCode: $('#OthersChargeServiceType').val(),
        sortBy: "",
        sortOrder: "",
    };
    var jsonData = JSON.stringify(FilterDetails);
    $.ajax({
        type: "POST",
        url: url,
        data: jsonData,
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            console.log(result.html);
            $("#TablePartial").html("");
            $("#TablePartial").html(result.html);

        },
        error: function (response) {
            alert("Error: " + response);
        }
    });
};

Sorting = (url, data, sortExpression) => {

    var decodeurl = decodeURIComponent(url).split("/");
    var urlsplit = decodeurl[1];

    var FilterDetails = {
        searchVal: $('#tblSearch_' + urlsplit).val(),
        pageNumber: data,
        pageSize: $('#pagesize_' + urlsplit).find('option:selected').val(),
        serviceTypeCode: $('#OthersChargeServiceType').val(),
        sortBy: sortExpression,
        sortOrder: ""
    };

    var jsonData = JSON.stringify(FilterDetails);
    $.ajax({
        type: "POST",
        url: url,
        data: jsonData,
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            console.log(result.html);
            $("#TablePartial").html("");
            $("#TablePartial").html(result.html);

        },
        error: function (response) {
            alert("Error: " + response);
        }
    });
}