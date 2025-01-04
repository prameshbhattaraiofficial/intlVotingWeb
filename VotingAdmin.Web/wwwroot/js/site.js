
sendmail = (url, customerId, uniqueReferenceNo) => {
    var decodeurl = decodeURIComponent(url) + "?customerId=" + customerId + "&uniqueReferenceNo=" + uniqueReferenceNo;
    $('#sendmail').hide()
    $.ajax({
        type: "POST",
        url: decodeurl,
        success: function (res) {
            if (res) {
                new PNotify({
                    // title: 'Success ',
                    text: 'Mail Send',
                    type: 'Success',

                    animation: {
                        effect_in: 'fade',
                        effect_out: 'slide'
                    }
                });
            } else {
                new PNotify({
                    // title: 'Success ',
                    text: 'Sorry CouldNot Send Mail',
                    type: 'Error',

                    animation: {
                        effect_in: 'fade',
                        effect_out: 'slide',

                    }
                });

            }

        },
        beforeSend: function () {
            $('.loader').show();


        },
        complete: function () {
            $('.loader').hide();

        },
        error: function (res) {
            //error code here
            new PNotify({
                // title: 'Success ',
                text: 'Internal Server Error',
                type: 'Error',

                animation: {
                    effect_in: 'fade',
                    effect_out: 'slide'
                }

            });
        }
    });
    $('#sendmail').show()

}
ShowImage = (imageUrl, contestname) => {
    { debugger }
    console.log("hi")
    $("#add-new .modal-dialog").removeClass("modal-lg");
    $("#add-new .modal-dialog").addClass("modal-md");
    $("#add-new .modal-body").html(`<img style='width: 100%;height: 100%;' src='${imageUrl}' alt='${contestname}'>` );
    $("#add-new .modal-body").append("<div id='modalloading'  class='loader'><center><span class='fa fa-spinner fa-spin fa-3x'></span></center></div >");
    $("#add-new .modal-title").html(contestname);
    $("#add-new").modal({ backdrop: 'static', keyboard: false });
    $("#add-new").modal('show');

}



ShowPopUp = (Url, title = '', aclass = null) => {
    var decodeurl = decodeURIComponent(Url);

    $.ajax({
        type: "GET",
        url: decodeurl,
        success: function (res) {
            debugger;
            aclass == null ? $("#add-new .modal-dialog").addClass("modal-lg") : $("#add-new .modal-dialog").removeClass().addClass('modal-dialog').addClass(aclass);
            $("#add-new .modal-body").html(res);
            $("#add-new .modal-body").append("<div id='modalloading'  class='loader'><center><span class='fa fa-spinner fa-spin fa-3x'></span></center></div >");
            $("#add-new .modal-title").html(title);
            // $("#add-new").modal({ backdrop: 'static', keyboard: false });
            $("#add-new").modal('show');
        }, error: function (err) {

            switch (err.status) {
                case 400:
                    new PNotify({
                        // title: 'Success ',
                        text: 'Bad request!',
                        type: 'Error',

                        animation: {
                            effect_in: 'fade',
                            effect_out: 'slide'
                        }
                    });
                    break;
                case 404:
                    new PNotify({
                        title: 'Error notice',
                        text: 'Not found.',
                        type: 'error',
                        animation: {
                            effect_in: 'fade',
                            effect_out: 'slide'
                        }
                    });
                    break;
                default:
                    new PNotify({
                        // title: 'Success ',
                        text: 'Internal Server Error',
                        type: 'Error',

                        animation: {
                            effect_in: 'fade',
                            effect_out: 'slide'
                        }
                    });
            }
        }

    })

}
PopUPAjaxPost = form => {
    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.isvalid) {
                $("#TablePartial").html("");
                $("#TablePartial").html(res.html);
                $("#add-new .modal-body").html("");
                $("#add-new .modal-title").html("");
                $("#add-new").modal('hide');
            }
            else {
                $("#add-new .modal-body").html(res.html);
                $("#add-new .modal-dialog").addClass("modal-sm")
            }
        },
        beforeSend: function () {
            $('.loader').show();
        },
        complete: function () {
            $('.loader').hide();
        },
        error: function (err) {
            location.reload();
        }
    })
    return false;
}
PopUPAjaxPost3 = form => {
    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: function (res) {

            $("#customerlist").html("");
            $("#customerlist").html(res);
            $("#add-new .modal-body").html("");
            $("#add-new .modal-title").html("");
            $("#add-new").modal('hide');


        },
        beforeSend: function () {
            $('.loader').show();
        },
        complete: function () {
            $('.loader').hide();
        },
        error: function (err) {
            console.log(err);
        }
    })

}

PopUPAjaxPost2 = form => {
    $.ajax({
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        contentType: false,
        processData: false,
        success: function (res) {
            if (res.isvalid) {
                $("#TablePartial").html("");
                $("#TablePartial").html(res.html);
                $("#add-new .modal-body").html("");
                $("#add-new .modal-title").html("");
                $("#add-new").modal('hide');
            }
            else
                /*   $("#add-new .modal-dialog").addClass("modal-sm");*/
                $("#add-new .modal-body").html(res);
        },
        beforeSend: function () {
            $('.loader').show();
        },
        complete: function () {
            $('.loader').hide();
        },
        error: function (err) {
            console.log(err);
        }
    })
    return false;
}

async function Cascadedropdown(Url, value, ReplaceId) {
    { debugger }
    var url = Url + value;
    var decodeurl = decodeURIComponent(url);
    $.ajax({
        async: true,
        type: "GET",
        url: decodeurl,
        success: await function (res) {
            var items = '<option value="0">--All--</option > ';
            $.each(res, function (i, IncommingValue) {
                console.log(IncommingValue);
                items += "<option value='" + IncommingValue.value + "'>" + IncommingValue.text + "</option>";
            });
            $("#" + ReplaceId).html(items);
        }
    })
};



PopUPAjaxDelete = (Url, title) => {
    var decodeurl = decodeURIComponent(Url);
    $.ajax({
        type: "GET",
        url: decodeurl,
        success: function (res) {
            $("#add-new .modal-dialog").removeClass("modal-lg");
            $("#add-new .modal-dialog").addClass("modal-md");
            $("#add-new .modal-body").html(res);
            $("#add-new .modal-body").append("<div id='modalloading'  class='loader'><center><span class='fa fa-spinner fa-spin fa-3x'></span></center></div >");
            $("#add-new .modal-title").html(title);
            $("#add-new").modal({ backdrop: 'static', keyboard: false });
            $("#add-new").modal('show');
        }
    })

}




//ChangePagesize = (url, data) => {

//    var decodeurl = decodeURIComponent(url).split("/");
//    var urlsplit = decodeurl[1];
//    console.log(url, "Url");

//    var FilterDetails = {
//        SearchName: $('#tblSearch_' + urlsplit).val(),
//        CurrentPageValue: JSON.stringify(data),
//        PageSizer: $('#pagesize_' + urlsplit).find('option:selected').val()
//    };
//    var jsonData = JSON.stringify(FilterDetails);
//    $.ajax({
//        type: "POST",
//        url: url,
//        data: jsonData,
//        contentType: "application/json",
//        dataType: "json",
//        success: function(result) {
//            console.log(result.html);
//            $("#TablePartial").html("");
//            $("#TablePartial").html(result.html);

//        },
//        error: function (response) {
//            alert("Error: " + response);
//        }
//    });

//}




ChangePagesize2 = (url, data) => {
    var FilteDetails = {
        CustomerId: $('#1CustomerId').val(),
        FullName: $('#1FullName').val(),
        MobileNo: $('#1MobileNo').val(),
        Email: $('#1Email').val(),
        RegisteredDateFrom: $('#1RegisteredDateFrom').val(),
        RegisteredDateTo: $('#1RegisteredDateTo').val(),
        CustomerStatusCode: "",
        KycStatusCode: "",
        SearchVal: $('#1SearchVal').val(),
        PageNumber: parseInt(data),
        PageSize: $('#1PageSize').val(),
        OrderBy: "",


    };
    var Url = url + "?ajaxcall=true"
    var jsonData = JSON.stringify(FilteDetails);
    $.ajax({
        type: "POST",
        url: Url,
        data: jsonData,
        contentType: "application/json",

        success: function (result) {
            console.log(result);

            $("#customerlist").html("");
            $("#customerlist").html(result);

        },
        error: function (result) {
            console.log(result)
        }

    });
    return false;
}

//Sorting = (url, data, sortExpression) => {
//    var decodeurl = decodeURIComponent(url).split("/");
//    var urlsplit = decodeurl[1];

//    var FilterDetails = {
//        SearchName: $('#tblSearch_' + urlsplit).val(),
//        CurrentPageValue: data,
//        PageSizer: $('#pagesize_' + urlsplit).find('option:selected').val(),
//        sortExpression: sortExpression,
//    };

//    var jsonData = JSON.stringify(FilterDetails);
//    $.ajax({
//        type: "POST",
//        url: url,
//        data: jsonData,
//        contentType: "application/json",
//        dataType: "json",
//        success: function (result) {
//            console.log(result.html);
//            $("#TablePartial").html("");
//            $("#TablePartial").html(result.html);

//        },
//        error: function (response) {
//            alert("Error: " + response);
//        }
//    });
//}





function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 47)) {
        return false;
    }

    return true;
}
function changeMenuIsactive(Url, MenuId, Action) {
    var decodeurl = decodeURIComponent(Url);
    var value = Action.checked;

    $.ajax({
        url: decodeurl,
        type: 'POST',
        data: { Id: MenuId, IsActive: value },
        success: function (res) {
            /*window.location.reload();*/
        }
    })
}
function changeDisplayOrder(Url, MenuId, DisplayOrder) {
    var decodeurl = decodeURIComponent(Url);
    var value = DisplayOrder.value;

    $.ajax({
        url: decodeurl,
        type: 'POST',
        data: { Id: MenuId, DisplayOrderValue: value },
        success: function (res) {
            /*window.location.reload();*/
        }
    })
}

$('input[type="number"]').click(function () {
    if (this.value < 0) {
        this.value = 0;
    }
});

function resetForm(formId) {
    const form = document.getElementById(formId);
    form.reset();
}



// Call the function on any input field with a value of zero


