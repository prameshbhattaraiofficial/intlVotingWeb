
function ChangePagesize(url, data) {
    var decodeurl = decodeURIComponent(url).split("/");
    var urlsplit = decodeurl[1];
    var Url = url + "?ajaxcall=true";
    var FilteDetails = {
        
        PageSize: parseInt($('#pagesize_' + urlsplit).val()), 
        PageNumber: parseInt(data),
        SearchVal: $('#tblSearch_' + urlsplit).val(),
        SortBy: "",
        SortOrder: "",
        UserName: $('#1UserName').val(),
        FullName: $('#1FullName').val(),
        Email: $('#1Email').val(),
        Mobile: $('#1Mobile').val(),
       

    };
   
    var jsonData = JSON.stringify(FilteDetails);
    $.ajax({
        type: "POST",
        url: Url,
        data: jsonData,
        contentType: "application/json",
        success: function (result) {
            console.log(result.html);
            $("#TablePartial").html("");
            $("#TablePartial").html(result);

        },
        error: function (response) {
            alert("Error: " + response);
        }
    });
};