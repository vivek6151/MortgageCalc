$(document).ready(function () {
    $('#mortgageForm').validate({
        errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'txtLoanAmount': {
                required: true,
                digits: true
            },

            'txtInterestRate': {
                required: true,
                digits: true,
                max: 24
            },

            'txtTermsInMonths': {
                required: true,
                digits: true,
                max: 100
            }
        },
        messages: {
            'txtLoanAmount': {
                required: 'Please enter Loan Amount',
                digits: 'Please enter number only'
            },

            'txtInterestRate': {
                required: 'Please enter Interest Rate',
                digits: 'Please enter number only'
            },

            'txtTermsInMonths': {
                required: 'Please enter period',
                digits: 'Please enter number only'
            }
        }
    });
}); 