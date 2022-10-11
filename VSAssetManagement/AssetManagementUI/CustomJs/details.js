var basePath='https://localhost:44355';

function callAPI(params){
    $.ajax(basePath+params.url, {
        type: params.type,
        data: params.data,
        success: params.successCallback,
        error: function (jqXhr, textStatus, errorMessage) {
            console.log(jqXhr,textStatus,errorMessage);
        }
    });
}

function onLoadData(status){
    $('#PageHeader').text(getAllUrlParams().title);
    var params = {};
    params={
        url:'/utility/status',
        data:{
            searchParam:"asset",
        },
        type:'GET',
        successCallback: function (data, status){
            console.log(data);
            tableFromJson(data);      
        }
    }
    var response=callAPI(params);
    
}
