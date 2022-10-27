$(document).ready(function () {
    function notify(from, align, icon, type, animIn, animOut, msg) {
        $.growl({
            icon: icon,
            title: ' Project - ',
            message: $('#code').val() + ':' + msg,
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
        e.preventDefault();
        $.ajax({
            url: 'ProjectModification',
            data: toJson(),
            type: 'Post',
            success: function (data) {
                nType = 'success';
                message = data;
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                nType = 'danger';
                message = 'Error In Updation';
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message)
            },

        });
    });
});

function toJson() {
    return Project = { Guid: $("#hdnGuid").val(), Code: $('#code').val(), Name: $('#name').val(), Type: $('#type').val(), StartDate: $('#start_date').val(), EndDate: $('#end_date').val(), ProjectSiteHead: $('#project_site_head').val(), SiteHeadMobile: $('#site_head_mobile').val(), GstinNo: $('#gstin_no').val(), CityTown: $('#city_town').val(), AddressLine1: $('#address_line_1').val(), AddressLine2: $('#address_line_2').val(), CompanyCode: $('#company_code').val(), DeptCode: $('#dept_code').val(), ProjectHead: $('#project_head').val(), UserCode: $('#user_code').val() };
};