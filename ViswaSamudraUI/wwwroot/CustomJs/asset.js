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
        $('#assetform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'AssetCode': { required: true, },
                'AssetName': { required: true, },
                'TagId': { required: true, },
                'StructureType': { required: false, },
                'StructureSubType': { required: false, },
                'AssetType': { required: false, },
                'AssetSpecification': { required: false, },
                'CompanyName': { required: false, },
                'ProjectCode': { required: false, },
                'Store': { required: true, },
                'BatchNo': { required: false, }                
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

        if ($('#assetform').valid()) {
            openLoader('Saving Asset details.....');
            $.ajax({
                url: 'AssetModification',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    closeLoader();
                    if (data?.status) {
                        nType = 'success';
                        message = data?.message;
                        let mode = $("#hdnGuid").val().replaceAll('-', '') == 0 ? 'Created' : 'Updated';
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#AssetCode').val() + ' - ' + $('#AssetName').val() + ' : ' + mode + " successfully.", " Asset ");                       
                    } else {
                        nType = 'danger';
                        message = data?.message ? data?.message : 'Error saving';
                        console.error("Error saving project details:", data);
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Error saving", " Asset ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    closeLoader();
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Asset ")
                },

            });
        }
    });
});

function toJson() {
    return Asset = {
        Guid: $("#hdnGuid").val(), AssetCode: $('#AssetCode').val(), AssetName: $('#AssetName').val(),
        CompanyName: $('#CompanyName').val(), ProjectCode: $('#ProjectCode').val(), StructureType: $('#StructureType').val(),
        TagId: $('#TagId').val(), AssetType: $('#AssetType').val(), AssetSpecification: $('#AssetSpecification').val(),
        Store: $('#Store').val(), BatchNo: $('#BatchNo').val(), StructureSubType: $('#StructureSubType').val()
    };
};