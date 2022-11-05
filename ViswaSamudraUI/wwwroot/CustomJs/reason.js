$(document).ready(function () {    
    // [ notification-button ]
    $('.notifications.btn').on('click', function (e) {
        e.preventDefault();

        var nFrom = $(this).attr('data-from');
        var nAlign = $(this).attr('data-align');
        var nIcons = $(this).attr('data-notify-icon');
        var nType = $(this).attr('data-type');
        var nAnimIn = $(this).attr('data-animation-in');
        var nAnimOut = $(this).attr('data-animation-out');
        var message = '';

        // [ Initialize validation ]
        $('#reasonform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'reason_name': {
                    required: true,                    
                },
                'reason_code': {
                    required: true,
                },
                'reason_type': {
                    required: true,
                },
            },

            // Errors //

            errorPlacement: function errorPlacement(error, element) {
                var $parent = $(element).parents('.form-group');

                // Do not duplicate errors
                if ($parent.find('.jquery-validation-error').length) {
                    return;
                }

                $parent.append(
                    error.addClass('jquery-validation-error small form-text invalid-feedback')
                );
            },
            highlight: function (element) {
                var $el = $(element);
                var $parent = $el.parents('.form-group');

                $el.addClass('is-invalid');

                // Select2 and Tagsinput
                if ($el.hasClass('select2-hidden-accessible') || $el.attr('data-role') === 'tagsinput') {
                    $el.parent().addClass('is-invalid');
                }
            },
            unhighlight: function (element) {
                $(element).parents('.form-group').find('.is-invalid').removeClass('is-invalid');
            }
        });


        if ($('#reasonform').valid()) {
            $.ajax({
                url: 'ReasonModification',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    if (data?.status) {
                        nType = 'success';
                        message = data?.message;
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#ReasonCode').val() + ' - ' + $('#ReasonName').val() + ' : ' + message, " Reason ");
                    } else {
                        nType = 'danger';
                        message = data?.message;
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Reason ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message," Reason ")
                },

            });
        }
    });

});

function toJson() {   
    return Reason = { Guid: $("#hdnGuid").val(), ReasonCode: $('#ReasonCode').val(), ReasonName: $('#ReasonName').val(), ReasonType: $('#ReasonType').val() };
};