$(document).ready(function () {
    // [ notification-button ]
    $('#batchButton').on('click', function (e) {
        e.preventDefault();

        var nFrom = $(this).attr('data-from');
        var nAlign = $(this).attr('data-align');
        var nIcons = $(this).attr('data-notify-icon');
        var nType = $(this).attr('data-type');
        var nAnimIn = $(this).attr('data-animation-in');
        var nAnimOut = $(this).attr('data-animation-out');
        var message = '';

        // [ Initialize validation ]
        $('#batchform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                "BatchNo": { required: true, },
                "BatchDescription": { required: false, },
                "Quantity": { required: true, },
                "AssetType": { required: true, },
                "AssetSpecification": { required: true, },
                "RecordStatus": { required: true, },
                "PurchaseBatchMasterGuid": { required: true, },
                "Uom": { required: true, },
                "UseFrequency": { required: true, },
                "UsageUom": { required: true, },
                "BatchStatus": { required: true, },
                "InvoiceNo": { required: true, },
                "InvoiceDate": { required: true, },
                "ReceivedBy": { required: true, },
                "ReceivedDate": { required: true, },
                "StructureType": { required: true, },
                "StructureSubType": { required: true, }
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

        if ($('#batchform').valid()) {
            $.ajax({
                url: 'BatchModification',
                data: toJson(),
                type: 'Post',
                success: function (data) {
                    nType = 'success';
                    message = data;
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#BatchNo').val() + ' - ' + $('#BatchDescription').val() + ' : Updated Successfully', " Batch ");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Batch ")
                },

            });
        }
    });

    $('#POButton').on('click', function (e) {
        e.preventDefault();

        var nFrom = $(this).attr('data-from');
        var nAlign = $(this).attr('data-align');
        var nIcons = $(this).attr('data-notify-icon');
        var nType = $(this).attr('data-type');
        var nAnimIn = $(this).attr('data-animation-in');
        var nAnimOut = $(this).attr('data-animation-out');
        var message = '';

        // [ Initialize validation ]
        $('#poform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                "PurchaseOrderNo": { required: true, },
                "PurchaseOrderDate": { required: false, },
                "PurchaseStore": { required: true, },
                "PurchaseProject": { required: true, },
                "CompanyName": { required: true, }
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

        if ($('#poform').valid()) {
            $.ajax({
                url: 'POModification',
                data: toPOJson(),
                type: 'Post',
                success: function (data) {
                    $('#PurchaseOrderNo').append(new Option($('#PurchaseOrderNo').val(), $('#PurchaseOrderNo').val()));
                    $("#PurchaseOrderNo").val($('#PurchaseOrderNo').val());
                    $('#opsbutton').click();
                    clearall();
                    nType = 'success';
                    message = data;
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#PurchaseOrderNo').val() + ' : Created Successfully', " Purchase Order ");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Batch ")
                },

            });
        }
    });
});

function toJson() {
    return Project = { Guid: $("#hdnGuid").val(), BatchNo: $("#BatchNo").val(), BatchDescription: $("#BatchDescription").val(), Quantity: $("#BatchQuantity").val(), AssetType: $("#AssetType").val(), AssetSpecification: $("#AssetSpecification").val(), PurchaseOrderId: $("#PurchaseOrderId").val(), Uom: $("#Uom").val(), UseFrequency: $("#UseFrequency").val(), UsageUom: $("#UsageUom").val(), BatchStatus: $("#BatchStatus").val(), InvoiceNo: $("#InvoiceNo").val(), InvoiceDate: $("#InvoiceDate").val(), ReceivedBy: $("#ReceivedBy").val(), ReceivedDate: $("#ReceivedDate").val(), StructureType: $("#StructureType").val(), StructureSubType: $("#StructureSubType").val() };
};

function toPOJson() {
    return PurchaseOrder = { PurchaseOrderNo: $("#PurchaseOrderNo").val(), PurchaseOrderDate: $("#PurchaseOrderDate").val(), PurchaseStore: $("#PurchaseStore").val(), PurchaseProject: $("#PurchaseProject").val(), CompanyName: $("#CompanyName").val() };
};

function clearall() {
    $("#PurchaseOrderNo").val('');
    $("#PurchaseOrderDate").val('');
    $("#PurchaseStore").val('');
    $("#PurchaseProject").val('');
    $("#CompanyName").val('');
}