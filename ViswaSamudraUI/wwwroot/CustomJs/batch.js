$(document).ready(function () {

    $("#opsbutton").click(function () {
        $("#PurchaseOrderId").removeClass('is-invalid');
    });

    $("#PurchaseOrderId").change(function () {      
        $.ajax({
            url: 'POGet',            
            type: 'Post',
            data: Batch = { Guid: $(this).val() },
            success: function (data) {                                                                   
                $("#PurchaseOrderNo").val(data.purchaseOrderNo);
                $("#PurchaseOrderDate").val(data.purchaseOrderDate);
                $("#PurchaseStore").val(data.purchaseStore);
                $("#PurchaseProject").(data.purchaseProject);
                $("#CompanyName").val(data.companyName);                                    
                closeLoader();   
            },
            error: function (xhr, ajaxOptions, thrownError) {
                nType = 'danger';
                message = 'Error In Updation';
                closeLoader();                
            },

        });
        if ($(this).val() == '' || $(this).val() < 1) {
            $("#PurchaseOrderId").addClass('is-invalid');
            $("#PurchaseOrderId").focus();
            $("#PurchaseOrderId").blur();
        } else {
            $("#PurchaseOrderId").removeClass('is-invalid');
        }
    });

    // [ notification-button ]
    $('#batchButton').on('click', function (e) {
        e.preventDefault();
        var poId = $("#PurchaseOrderId").val();
        if (poId == null || poId == undefined || poId == '') {
            //swal("Please select Purchase Order to proceed..", "Purchase Order Batch Save", "error");
            $("#PurchaseOrderId").addClass('is-invalid');
            $("#PurchaseOrderId").focus();
            $("#PurchaseOrderId").blur();
            return false;
        }

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
            swal({
                title: "Batch Generation!",
                text: "Do you want to auto-generate Assets for this Batch?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((yes) => {
                    if (yes) {
                        var request = toJson();
                        request["BatchStatus"] = "Processed";
                        saveBatch(request);
                    } else {
                        saveBatch(toJson());
                    }
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
            openLoader('Saving Purchase Order details.....');
            $.ajax({
                url: 'POModification',
                data: toPOJson(),
                type: 'Post',
                success: function (data) {
                    closeLoader();
                    if (data?.status) {
                        $('#PurchaseOrderNo').append(new Option($('#PurchaseOrderNo').val(), $('#PurchaseOrderNo').val()));
                        $("#PurchaseOrderNo").val($('#PurchaseOrderNo').val());
                        $('#opsbutton').click();
                        clearall();
                        nType = 'success';
                        message = data?.message;
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#PurchaseOrderNo').val() + ' : Created Successfully', " Purchase Order ");
                    } else {
                        nType = 'danger';
                        message = data?.message;
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Batch ");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    nType = 'danger';
                    message = 'Error In Updation';
                    closeLoader();
                    notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Batch ");
                },

            });
        }
    });
});

function toJson() {
    return Batch = { Guid: $("#hdnGuid").val(), BatchNo: $("#BatchNo").val(), BatchDescription: $("#BatchDescription").val(), BatchQuantity: $("#BatchQuantity").val(), AssetType: $("#AssetType").val(), AssetSpecification: $("#AssetSpecification").val(), PurchaseOrderId: $("#PurchaseOrderId").val(), Uom: $("#Uom").val(), UseFrequency: $("#UseFrequency").val(), UsageUom: $("#UsageUom").val(), BatchStatus: "New", InvoiceNo: $("#InvoiceNo").val(), InvoiceDate: $("#InvoiceDate").val(), ReceivedBy: $("#ReceivedBy").val(), ReceivedDate: $("#ReceivedDate").val(), StructureType: $("#StructureType").val(), StructureSubType: $("#StructureSubType").val(), CreatedBy: 'SYSTEM' };
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

function saveBatch(request) {
    openLoader('Saving Purchase Order Batch details.....');
    var nFrom = $(this).attr('data-from');
    var nAlign = $(this).attr('data-align');
    var nIcons = $(this).attr('data-notify-icon');
    var nType = $(this).attr('data-type');
    var nAnimIn = $(this).attr('data-animation-in');
    var nAnimOut = $(this).attr('data-animation-out');
    var message = '';
    $.ajax({
        url: 'BatchModification',
        data: request,
        type: 'Post',
        success: function (data) {
            closeLoader();
            if (data?.status) {
                nType = 'success';
                message = data;
                let mode = $("#hdnGuid").val().replaceAll('-', '') == 0 ? 'Created' : 'Updated';
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, $('#BatchNo').val() + ' - ' + $('#BatchDescription').val() + ' : ' + mode + ' Successfully', " Batch ");
                window.location.replace('/batch');
            } else {
                nType = 'danger';
                message = data?.message ? data?.message : 'Error saving';
                console.error("Error saving batch details:", data);
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Error saving", " Batch ");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            closeLoader();
            nType = 'danger';
            message = 'Error In Updation';
            notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, " Batch ")
        },

    });
}