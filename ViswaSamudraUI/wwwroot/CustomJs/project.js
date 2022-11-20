$(document).ready(function () {

    $('#loadRecord').click(function () {
        openLoader("Loading details...");
    });

    $('#deleteRecord').click(function () {
        openLoader("Deleting record...");
    });

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
                'ProjectCode': { required: true, },
                'ProjectName': { required: true, },
                'ProjectType': { required: true, },
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
            openLoader('Saving Project details.....');
            $.ajax({
                url: 'ProjectModification',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    closeLoader();
                    if (data?.status) {
                        nType = 'success';
                        message = data?.message;
                        let mode = $("#hdnGuid").val().replaceAll('-', '') == 0 ? 'Created' : 'Updated';
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#ProjectCode').val() + ' - ' + $('#ProjectName').val() + ' : ' + mode + " successfully.", " Project ");
                        //window.location.replace('/project');
                    } else {
                        nType = 'danger';
                        message = data?.message ? data?.message : 'Error saving';
                        console.error("Error saving project details:", data);
                        if (message.includes("Project Exist"))
                            notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Project Name or Code are existed", " Project ");
                        else
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Error saving", " Project ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    closeLoader();
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Project ")
                },

            });
        }
    });
});

function toJson() {
    return Project = { Guid: $("#hdnGuid").val(), ProjectCode: $('#ProjectCode').val(), ProjectName: $('#ProjectName').val(), ClientName: $('#ClientName').val(), ProjectType: $('#ProjectType').val(), ProjectStartDate: $('#ProjectStartDate').val(), ProjectEndDate: $('#ProjectEndDate').val(), ProjectSiteHead: $('#ProjectSiteHead').val(), SiteHeadMobile: $('#SiteHeadMobile').val(), GstinNo: $('#GstinNo').val(), CityTown: $('#CityTown').val(), AddressLine1: $('#AddressLine1').val(), AddressLine2: $('#AddressLine2').val() };
};