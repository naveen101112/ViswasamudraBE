$(document).ready(function () {
    //$('#df').dataTable({ searching: false, paging: false, info: false });
    
})

function openstoredetails(structure, substructure, assettype, asasetspec) {    
    var header = {
        STRUCTURE: structure,
        SUB_STRUCTURE: substructure,
        ASSET_TYPE: assettype,
        ASSET_SPEC: asasetspec
    };
    $.ajax({
        url: 'DetailedReport/ShowStoreAndProject',
        type:'Post',
        data: header,
        success: function (data) {
            $('#storediv').empty();
            $('#storediv').append(data); 
            $('#openmodel').click();
        },
        error: function (xhr, ajaxOptions, thrownError) { }
    })
}