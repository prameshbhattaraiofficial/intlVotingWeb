
    function ChangeStatus(Roleid, rolename, Discription) {
        var currstatus = $("#switch-" + Roleid).is(':checked') ? true : false;
    $.ajax({
        url: '/Roles/UpdateRoleStatus',
    type: 'POST',
    data: {currstatus: currstatus, roleid: Roleid, rolename: rolename, discription: Discription },
    success: function (res) {
                return res;
            }
        })        
    }
