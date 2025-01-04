function ChangeLoanStatus(id) {
    var currstatus = $("#switch-" + id).is(':checked') ? true : false;
    $.ajax({
        url: '/LoanType/UpdateLoanStatus',
        type: 'POST',
        data: { Id: id, IsActive: currstatus },
        success: function (res) {
            return res;
        }
    })
}



