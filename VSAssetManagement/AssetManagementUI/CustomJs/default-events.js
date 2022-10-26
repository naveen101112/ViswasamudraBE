$(document).ready(function() {
    // [ Foo-table ]
    $('#demo-foo-filtering').footable({
        "paging": {
            "enabled": true
        },
        "filtering": {
            "enabled": false
        },
        "sorting": {
            "enabled": true
        }
    });

    $('#update-data').click(
        function(){
            let body={};
            body = toJson($('#form-data'));
            console.log(body);
            let type = $('#type').val();
            var params = {};
            params={
                url:'/'+type,
                type:'PUT',
                data : body,
                successCallback: function (data, status){
                    console.log(data);
                    window.location.reload();
                    //loadGridData('/'+type);
                }
            }
            var response=callAPI(params);
        }
    );
});


function toJson(form){
    var data = {};
    var dataArray = form.serializeArray();
    for(var i=0;i<dataArray.length;i++){
        data[dataArray[i].name] = dataArray[i].value;
    }
    return data;
};

function editForm(element){
    console.log(element.getAttribute('alt'));
    $('#data-grid').hide();
    $('#edit-form').show();
    let type = $('#type').val();
    var params = {};
    params={
        url:'/'+type+'/'+element.getAttribute('alt'),
        type:'GET',
        successCallback: function (data, status){
            console.log(data);
            $.each(data, function(key, value) {
                if(key=='status'){
                    $('status').val(value);
                    $('status').change();
                }
                else
                $('#form-data').find("input[name='" + key + "']").val(value);
            });
        }
    }
    var response=callAPI(params);
}