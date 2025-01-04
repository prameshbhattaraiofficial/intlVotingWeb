function ChangeLoanIntrestStatus(id) {
    var currstatus = $("#switch-" + id).is(':checked') ? true : false;
    $.ajax({
        url: '/LoanInterest/UpdateLoanIntrestStatus',
        type: 'POST',
        data: { Id: id, IsActive: currstatus },
        success: function (res) {
            return res;
        }
    })
}

