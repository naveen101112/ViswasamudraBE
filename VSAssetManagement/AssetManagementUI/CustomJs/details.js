var basePath='https://localhost:44355';

function callAPI(params){
    $.ajax(basePath+params.url, {
        type: params.type,
        data: params.data,
        dataType: 'json',
        success: params.successCallback,
        error: function (jqXhr, textStatus, errorMessage) {
            console.log(jqXhr,textStatus,errorMessage);
        }
    });
}

function loadGridData(){
    $('#data-grid').show();
    $('#edit-form').hide();
    var urlString = '/'+$('#type').val()+'/grid';
    var params = {};
    params={
        url:urlString,
        type:'GET',
        successCallback: function (data, status){
            console.log(data);
            var tableObject = {
                jsonData: data,
                noSort: ['id'],
                editable: true
            }
            tableFromJson(tableObject);      
        }
    }
    callAPI(params);
}

function onLoadData(param){
    //$('#PageHeader').text(getAllUrlParams().title);
    param={
        title:'Asset',
        type:'asset'
    }
    $('#PageHeader').text(param.title);
    var params = {};
    params={
        url:'/utility/status',
        data:{
            searchParam: param.type,
        },
        type:'GET',
        successCallback: function (data, status){
            console.log(data);
            var tableObject = {
                jsonData: data,
                noSort: ['id']
            }
            tableFromJson(tableObject);      
        }
    }
    var response=callAPI(params);
    
}