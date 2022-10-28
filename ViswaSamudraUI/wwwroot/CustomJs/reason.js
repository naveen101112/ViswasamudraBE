﻿$(document).ready(function () {
    function notify(from, align, icon, type, animIn, animOut, msg) {
        $.growl({
            icon: icon,
            title: ' Reason - ',
            message: $('#ReasonCode').val() + ' - ' + $('#ReasonName').val() + ':' + msg,
            url: ''
        }, {
            element: 'body',
            type: type,
            allow_dismiss: true,
            placement: {
                from: from,
                align: align
            },
            offset: {
                x: 30,
                y: 30
            },
            spacing: 10,
            z_index: 999999,
            delay: 2500,
            timer: 1000,
            url_target: '_blank',
            mouse_over: false,
            animate: {
                enter: animIn,
                exit: animOut
            },
            icon_type: 'class',
            template: '<div data-growl="container" class="alert" role="alert">' +
                '<button type="button" class="close" data-growl="dismiss">' +
                '<span aria-hidden="true">&times;</span>' +
                '<span class="sr-only">Close</span>' +
                '</button>' +
                '<span data-growl="icon"></span>' +
                '<span data-growl="title"></span>' +
                '<span data-growl="message"></span>' +
                '<a href="#!" data-growl="url"></a>' +
                '</div>'
        });
    };
    
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
                    nType = 'success';
                    message = data;
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message)
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message)
                },

            });
        }
    });

});

function toJson() {   
    return Reason = { Guid: $("#hdnGuid").val(), ReasonCode: $('#ReasonCode').val(), ReasonName: $('#ReasonName').val(), ReasonType: $('#ReasonType').val() };
};