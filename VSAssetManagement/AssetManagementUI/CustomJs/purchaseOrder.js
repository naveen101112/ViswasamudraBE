
$(document).ready(function() {
    $('#btnPurchaseOrder').click(
        function(){
            var params = {};
            params={
                url:'PurchaseOrder/createRecord',
                type:'PUT',
                data: toJson(),
                successCallback: function (data, status) {
                    var id = $('#hdnGuid').val();
                    window.location.href = '@Url.Action("PoGetDetailById", "PurchaseOrder")/' + id;                   
                }
            }          
        }
    );
});

function toJson(){    
    return PurchaseOrder={ PurchaseOrderNo: $('#poNo').val(), PurchaseOrderDate: $('#poData').val(), ReceivedBy: $('#recivedBy').val(), ReceivedDate: $('#recivedDate').val() };    
};

