function setActiveMenu(parent, child) {
    $("#" + parent + "-link").addClass(['active', 'pcoded-trigger']);
    $("#" + child + "-link").addClass("active");
}

function openLoader(status) {
    $(".loader").show();
    if (status) $('#loader-message').html(status);
}

function closeLoader() {
    $(".loader").hide();
    $('#loader-message').html("Please Wait....");
}