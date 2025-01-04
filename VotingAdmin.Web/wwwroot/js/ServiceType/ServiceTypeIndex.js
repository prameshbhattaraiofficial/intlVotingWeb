

function ChangeServicetypeStatus(id) {

    var currstatus = $("#switch-" + id).is(':checked') ? true : false;
    $.ajax({
        url: '/ServiceType/UpdateservicetypeStatus',
        type: 'POST',
        data: { Id: id, IsActive: currstatus },
        success: function (res) {
            return res;
        }
    })
}

