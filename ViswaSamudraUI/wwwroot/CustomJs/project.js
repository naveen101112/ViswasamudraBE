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
        $('#projectform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'Code': { required: true, },
                'Name': { required: true, },
                'Type': { required: true, },
                'ClientName': { required: false, },
                'StartDate': { required: false, },
                'EndDate': { required: false, },
                'ProjectSiteHead': { required: false, },
                'SiteHeadMobile': { required: false, },
                'GstinNo': { required: false, },
                'CityTown': { required: true, },
                'AddressLine1': { required: false, },
                'AddressLine2': { required: false, }
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

        if ($('#projectform').valid()) {
            $.ajax({
                url: 'ProjectModification',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    nType = 'success';
                    message = data;
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#Code').val() + ' - ' + $('#Name').val() + ' : ' + message, " Project ");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Project ")
                },

            });
        }
    });
});

function toJson() {
    return Project = { Guid: $("#hdnGuid").val(), Code: $('#code').val(), Name: $('#name').val(), Type: $('#type').val(), StartDate: $('#start_date').val(), EndDate: $('#end_date').val(), ProjectSiteHead: $('#project_site_head').val(), SiteHeadMobile: $('#site_head_mobile').val(), GstinNo: $('#gstin_no').val(), CityTown: $('#city_town').val(), AddressLine1: $('#address_line_1').val(), AddressLine2: $('#address_line_2').val(), CompanyCode: $('#company_code').val(), DeptCode: $('#dept_code').val(), ProjectHead: $('#project_head').val(), UserCode: $('#user_code').val() };
};