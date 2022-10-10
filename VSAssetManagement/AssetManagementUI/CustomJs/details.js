var basePath='https://localhost:44355';

function callAPI(params){
    $.ajax(basePath+params.url, {
        type: params.type,
        data: params.data,
        success: function (data, status, xhr) {
            console.log(data,status,xhr);
        },
        error: function (jqXhr, textStatus, errorMessage) {
            console.log(jqXhr,textStatus,errorMessage);
        }
    });
}

function onLoadData(){
    var params = {};
    params={
        url:'/utility/status/asset',
        data:'',
        type:'GET'
    }
    callAPI(params);
}