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
        $('#loginForm').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'UserName': { required: true, },
                'Password': { required: true, }
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

        if ($('#loginForm').valid()) {
            openLoader('Authenticating.....');
            $.ajax({
                url: 'login/authenticate',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    closeLoader();
                    if (data?.status) {
                        nType = 'success';
                        message = data?.message;
                        window.localStorage.setItem("vs-login-auth-token", data?.userName);
                        //redirectDashBoard();
                        window.location.replace("../Dashboard/Index");
                    } else {
                        nType = 'danger';
                        message = data?.message ? data?.message : 'Error Login';
                        console.error("Error User Login:", data);
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message, " User Login ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    closeLoader();
                    nType = 'danger';
                    message = 'Error In login';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " UserLogin ")
                },

            });
        }
    });
});

function toJson() {
    console.log($('#Password').val());
    return Asset = {
        username: $('#UserName').val(), password: btoa($('#Password').val())
    };
};

function redirectDashBoard() {
    openLoader('Loading Dashboard.....');
    $.ajax({
        url: 'dashboard',
        data: toJson(),
        type: 'Get',
        success: function (data) {
            closeLoader();
            if (data?.status) {
                nType = 'success';
                message = data?.message;
                window.localStorage.setItem("vs-login-auth-token", data?.token);
                redirectDashBoard();
            } else {
                nType = 'danger';
                message = data?.message ? data?.message : 'Error Login';
                console.error("Error User Login:", data);
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Error Login", " User Login ");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            closeLoader();
            nType = 'danger';
            message = 'Error In login';
            notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " UserLogin ")
        },

    });
}