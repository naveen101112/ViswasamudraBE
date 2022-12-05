$(document).ready(function () {
    $('#adddetails').on('click', function (e) {
        e.preventDefault();
              // [ Initialize validation ]    

        $('#assetreqform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'stype': { required: true, },
                'sstype': { required: true, },
                'assetType': { required: true, },
                'assetSpec': { required: true, },
                'quantity': { required: true, },
                'uom': { required: true, }               
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

        if ($('#assetreqform').valid()) {            
            addtabledata();
        }
    });

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
        $.validator.addMethod(
            'fromtodate_format',
            function (value, element) {
                var reffromdate = new Date($('#header_RequiredFromDate').val());
                var reftodate = new Date($('#header_RequiredToDate').val());
                return this.optional(element) || (reffromdate < reftodate);
            },
            'Must be greater then Requisition From Date'
        );

        $('#dynamicform').validate({
            ignore: '.ignore, .select2-input',
            focusInvalid: false,
            rules: {
                'header.TaskType': { required: true, },               
                'header.Project': { required: true, },
                'header.RequiredFromDate': { required: true, },
                'header.RequiredToDate': { required: true, fromtodate_format: true },
                'header.RequestedBy': { required: true, },
                'header.ApprovedBy': { required: true, },
                'header.Remarks': { required: true, }                
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

        if ($('#dynamicform').valid()) {
            if ($('#assetReqTbl tr').length <= 1) {
                nType = 'danger';
                notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Please select asset you require", " Asset Req ");
            }
            else {
                $.ajax({
                    url: 'AssetRequisitionModification',
                    type: 'Post',
                    data: toJson(),
                    success: function (data) {
                        if (data?.status) {
                            nType = 'success';
                            message = data?.message;
                            redirect();
                            notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut,  message, " Asset Requisition Type ");
                        } else {
                            nType = 'danger';
                            message = data?.message;                                                        
                            notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "  Asset Requisition Type  ");
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        nType = 'danger';
                        message = 'Error In Operation';
                        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, message, " Asset Requisition Type ")
                    },
                })
                
            }
        }
    });

    $("#assetReqTbl").on('click', '.remTD', function () {
        if (confirm("Are you sure you want to delete this?")) {
            $(this).parent().parent().remove();
        }
    });

});

function addtabledata() {
    var nFrom = $(this).attr('data-from');
    var nAlign = $(this).attr('data-align');
    var nIcons = $(this).attr('data-notify-icon');
    var nType = $(this).attr('data-type');
    var nAnimIn = $(this).attr('data-animation-in');
    var nAnimOut = $(this).attr('data-animation-out');
    

    var td1text = $("#stype option:selected").text();
    var td1value = '<input type="hidden" value="' + $("#stype option:selected").val() +'">';    
    var td1 = td1text +  td1value;


    var td2text = $("#sstype option:selected").text();
    var td2value = '<input type="hidden" value="' + $("#sstype option:selected").val() + '">';
    var td2 = td2text  + td2value;


    var td3text = $("#assetType option:selected").text();
    var td3value = '<input type="hidden" value="' + $("#assetType option:selected").val() + '">';
    var td3 = td3text +  td3value;

    var td4text = $("#assetSpec option:selected").text();
    var td4value = '<input type="hidden" value="' + $("#assetSpec option:selected").val() + '">';
    var td4 = td4text +  td4value;

    var td5 = $("#quantity").val();

    var td6text = $("#uom option:selected").text();  
    var td6value = '<input type="hidden" value="' + $("#uom option:selected").val() + '">';
    var td6 = td6text +  td6value;

    let stat = 0; 
    $('#assetReqTbl > tbody  > tr').each(function () {
        if (this.cells.length > 0) {
            if ($("#stype option:selected").val() === this.cells[1].querySelector('input').value && $("#sstype option:selected").val() === this.cells[2].querySelector('input').value
                && $("#assetType option:selected").val() === this.cells[3].querySelector('input').value && $("#assetSpec option:selected").val() === this.cells[4].querySelector('input').value) {
                stat = 1;
            }
        }
    });

    if (stat == 0) {
        var firstRowContent = '<tr role="row"><td><a class="remTD feather icon-x-circle" href="#"></a></td>';
        var lastRowContent = '</tr >';
        var middle = '<td>' + td1 + '</td> <td>' + td2 + '</td> <td>' + td3 + '</td> <td>' + td4 + '</td> <td>' + td5 + '</td> <td>' + td6 + '</td>';
        $("#assetReqTbl tbody").append(firstRowContent + middle + lastRowContent);
    }
    else {
        nType = 'danger';
        notify(nFrom, nAlign, nIcons, nType, nAnimIn, nAnimOut, "Same specification already added ", " Asset Req ");
    }
}

function toJson() {
    var header ={
        Guid: $("#hdnGuid").val(), AssetRequisitionNo: $('#header_AssetRequisitionNo').val(), AssetRequisitionDate: $('#header_AssetRequisitionDate').val(),
        TaskType: $('#header_TaskType').val(), Project: $('#header_Project').val(), RequiredFromDate: $('#header_RequiredFromDate').val(),
        RequiredToDate: $('#header_RequiredToDate').val(), RequestedBy: $('#header_RequestedBy').val(), ApprovedBy: $('#header_ApprovedBy').val(),
        Remarks: $('#header_Remarks').val()
        };
    var details =[];
    $('#assetReqTbl > tbody  > tr').each(function () {
        var AssetRequisitionDetail = {};            
           if (this.cells.length > 0) {
               AssetRequisitionDetail['StructureType'] = this.cells[1].querySelector('input').value;
               AssetRequisitionDetail['StructureSubType'] = this.cells[2].querySelector('input').value;
               AssetRequisitionDetail['AssetType'] = this.cells[3].querySelector('input').value;
               AssetRequisitionDetail['AssetSpecification'] = this.cells[4].querySelector('input').value;
               AssetRequisitionDetail['QuantityRequired'] = this.cells[5].innerText;
               AssetRequisitionDetail['Uom'] = this.cells[6].querySelector('input').value;
               details.push(AssetRequisitionDetail);
           }        
        });
    
    return AssetRequisition = { header, details };
}

function redirect() {
    setTimeout(function () {        
        window.location.replace('/AssetRequisition/');
    }, 2000);
}



