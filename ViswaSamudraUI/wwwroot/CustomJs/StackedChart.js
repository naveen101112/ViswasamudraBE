'use strict';
$(document).ready(function () {
    $.ajax({
        url:'DetailedReport/GetDashboardData',        
        type: 'Post',
        success: function (data) {
            loaddashboarddata(data);
        },
        error: function (xhr, ajaxOptions, thrownError) { }
    })
});

function loaddashboarddata(data) {
    var dataGot =[]= data;
    var stackeddata = [];

    for (var i = 0; i < dataGot.length; i++) {
        var item = dataGot[i].split("$$$");

        if (item[0] === 'Assets') {
            var assetsummary = item[1].split(",");
            for (var asum = 0; asum < assetsummary.length; asum++) {
                var assetsummarydetails = assetsummary[asum].split(":");
                var classupper = 'fas fa-long-arrow-alt-down m-r-10';
                var classlower = 'fas fa-long-arrow-alt-down m-r-10';

                if (assetsummarydetails[0] == 'AVAILABLE') {
                    $("#totalAssetsAvailable").text('Available ' + assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'TOTAL') {
                    $("#totalAssets").text('TOTAL ' + assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'UNDER_USE_PER') {
                    $("#percentageAssetsInUse").text(assetsummarydetails[1] + '%');
                }
                if (assetsummarydetails[0] == 'UNDER_USE') {
                    $("#totalAssetsInUse").text(assetsummarydetails[1]);
                }

                if (assetsummarydetails[0] == 'TRFR_INWARD') {
                    $("#inward").text(assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'TRFR_INWARD_PER') {
                    $("#inwardper").text(assetsummarydetails[1] + '%');

                    if (assetsummarydetails[1] > 50)
                        $("#showinwardper").addClass(classupper);
                    else
                        $("#showinwardper").addClass(classlower);
                    $('#inwardperprogres').css('width', assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'TRFR_OUTWARD') {
                    $("#outward").text(assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'TRFR_OUTWARD_PER') {
                    $("#outwardper").text(assetsummarydetails[1] + '%');

                    if (assetsummarydetails[1] > 50)
                        $("#showoutwardper").addClass(classupper);
                    else
                        $("#showoutwardper").addClass(classlower);
                    $('#outwardprogress').css('width', assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'UNDER_REPAIR') {
                    $("#underrepair").text(assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'UNDER_REPAIR_PER') {
                    $("#underrepairper").text(assetsummarydetails[1] + '%');
                    if (assetsummarydetails[1] > 50)
                        $("#showunderrepairper").addClass(classupper);
                    else
                        $("#showunderrepairper").addClass(classlower);
                    $('#underrepairprogress').css('width', assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'UNDER_SCRAP') {
                    $("#scrap").text(assetsummarydetails[1]);
                }
                if (assetsummarydetails[0] == 'UNDER_SCRAP_PER') {
                    $("#scrapper").text(assetsummarydetails[1] + '%');

                    if (assetsummarydetails[1] > 50)
                        $("#showscrapper").addClass(classupper);
                    else
                        $("#showscrapper").addClass(classlower);
                    $('#scrapperprogress').css('width', assetsummarydetails[1]);

                }
            }
        }

        if (item[0] === 'Requests') {
            var assetrequest = item[1].split(",");
            for (var asum = 0; asum < assetrequest.length; asum++) {
                var assetrequestdetails = assetrequest[asum].split(":");

                if (assetrequestdetails[0] == 'APRVD_REQS') {
                    $("#approvedRequest").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'APRVD_REQS_QTY') {
                    $("#approvedQuantity").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'PNDNG_REQS') {
                    $("#pendingRequest").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'PNDNG_REQS_QTY') {
                    $("#pendingQuantity").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'PRTIAL_FLFLD_REQS') {
                    $("#partialRequest").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'PRTIAL_FLFLD_REQ_QTY') {
                    $("#partialQuantity").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'CMPLTLY_FLFLD_REQUESTS') {
                    $("#completedRequest").text(assetrequestdetails[1]);
                }
                if (assetrequestdetails[0] == 'CMPLTLY_FLFLD_QTY') {
                    $("#completedQuantity").text(assetrequestdetails[1]);
                }

            }
        }

        if (item[0] === 'Utilization') {
            var assetutilz = item[1].split(",");
            var zeroper; var zerototwtyper; var twtytofrtyper; var frtytosixtyper; var sixtytoeityper;
            var eitytohrdper; var hrdper;
            for (var asum = 0; asum < assetutilz.length; asum++) {
                var assetutilzdetails = assetutilz[asum].split(":");

                if (assetutilzdetails[0] == 'USED_0PCT') {
                    zeroper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_BTWN_0TO20PCT') {
                    zerototwtyper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_BTWN_20TO40PCT') {
                    twtytofrtyper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_BTWN_40TO60PCT') {
                    frtytosixtyper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_BTWN_60TO80PCT') {
                    sixtytoeityper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_BTWN_80TO100PCT') {
                    eitytohrdper = assetutilzdetails[1];
                }
                if (assetutilzdetails[0] == 'USED_100PCT') {
                    hrdper = assetutilzdetails[1];
                }


            }
            callgantt(zeroper, zerototwtyper, twtytofrtyper, frtytosixtyper, sixtytoeityper, eitytohrdper, hrdper);
        }

        if (item[0] === 'StackedChart') {
            stackeddata.push(item[1]);
        }
    }
    

    var projectlist = []; var availableList = []; var useList = [];
    var inwardList = []; var outwardList = []; var repairList = []; var scrapList =[]
    for (var i = 0; i < stackeddata.length; i++) {
        var projects = stackeddata[i].split(",");
        for (var asum = 0; asum < projects.length; asum++) {
            var projectdetails = projects[asum].split(":");            
            if (projectdetails[0] == 'PROJECT_CODE') {                
                projectlist.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'AVAILABLE') {
                availableList.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'UNDER_USE') {
                useList.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'TRFR_INWARD') {
                inwardList.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'TRFR_OUTWARD') {
                outwardList.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'UNDER_REPAIR') {
                repairList.push(projectdetails[1]);
            }
            if (projectdetails[0] == 'UNDER_SCRAP') {
                scrapList.push(projectdetails[1]);
            }
        }
    }
    callstacked(projectlist, availableList, useList, inwardList, outwardList, repairList, scrapList);
}


function callgantt(z, zt, tf, fs, se, eh, h) {
    var labelArray = ["Utilization"],
        zeroper = [z], zerototwtyper = [zt], twtytofrtyper = [tf], frtytosixtyper = [fs], sixtytoeityper = [se], eitytohrdper = [eh], hrdper = [h];
    var ctx = document.getElementById('ganttGraph').getContext('2d');
    var chart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: labelArray,
            datasets: [{
                label: '0%',
                data: zeroper,
                backgroundColor: '#ed6141',
                borderColor: '#ed6141',
                borderWidth: 1
            },
            {
                label: '0-20%',
                data: zerototwtyper,
                backgroundColor: '#edb041',
                borderColor: '#edb041',
                borderWidth: 1,
            },
            {
                label: '20-40%',
                data: twtytofrtyper,
                backgroundColor: '#ede041',
                borderColor: '#ede041',
                borderWidth: 1,
            },
            {
                label: '40-60%',
                data: frtytosixtyper,
                backgroundColor: '#cbed41',
                borderColor: '#cbed41',
                borderWidth: 1,
            },
            {
                label: '60-80%',
                data: sixtytoeityper,
                backgroundColor: '#7bed41',
                borderColor: '#7bed41',
                borderWidth: 1,
            },
            {
                label: '80-100%',
                data: eitytohrdper,
                backgroundColor: '#6cb149',
                borderColor: '#6cb149',
                borderWidth: 1,
            },
            {
                label: '100%',
                data: hrdper,
                backgroundColor: '#35661c',
                borderColor: '#35661c',
                borderWidth: 1,
            }
            ]
        },
        options: {
            scales: {

                xAxes: [{
                    stacked: true,
                }],
                yAxes: [{
                    stacked: true,
                    ticks: {
                        display: false
                    }

                }]
            },
            plugins: {
                datalabels: {
                    color: 'white',
                    font: {
                        weight: 'bold'
                    },
                    formatter: function (value, context) {
                        return Math.round(value) + '%';
                    }
                }
            }
        }
    });
}
function callstacked(projectlist, availableList, useList, inwardList, outwardList, repairList, scrapList) {
    var Stackedbar = document.getElementById("stackedGraph").getContext('2d');
    var data1 = {
        labels: projectlist,
        datasets: [{
            label: "Available",
            data: availableList,
            borderColor: '#71b5ef',
            backgroundColor: '#71b5ef',
            hoverborderColor: '#71b5ef',
            hoverBackgroundColor: '#71b5ef',
        }, {
            label: "Under Use",
            data: useList,
            borderColor: '#71efe3',
            backgroundColor: '#71efe3',
            hoverborderColor: '#71efe3',
            hoverBackgroundColor: '#71efe3',
        },
        {
            label: "In Ward",
            data: inwardList,
            borderColor: '#79ef71',
            backgroundColor: '#79ef71',
            hoverborderColor: '#79ef71',
            hoverBackgroundColor: '#79ef71',
            },
            {
                label: "Out Ward",
                data: outwardList,
                borderColor: '#dc71ef',
                backgroundColor: '#dc71ef',
                hoverborderColor: '#dc71ef',
                hoverBackgroundColor: '#dc71ef',
            },
            {
                label: "Under Repair",
                data: repairList,
                borderColor: '#4680ff',
                backgroundColor: '#FDFB99',
                hoverborderColor: '#FDFB99',
                hoverBackgroundColor: '#FDFB99',
            },
            {
                label: "Scrape",
                data: scrapList,
                borderColor: '#ef8e71',
                backgroundColor: '#ef8e71',
                hoverborderColor: '#ef8e71',
                hoverBackgroundColor: '#ef8e71',
            }
        ]
    };
    var myBarChart = new Chart(Stackedbar, {
        plugins: {
            datalabels: {
                formatter: function (value, context) {
                    return context.dataset.data[context.dataIndex].label;  // labels in each data object                    
                }
            }
        },
        type: 'bar',
        data: data1,
        options: {
            scaleLabel: "<%= value + '$' %>",
            legend: {
                display: false
            },
            barValueSpacing: 10,
            scales: {
                xAxes: [{
                    stacked: true,
                    ticks: {
                        mirror: true                        
                    }
                }],
                yAxes: [{
                    stacked: true,
                    ticks: {
                        mirror: false
                    }
                }]
            },

        },
    });
}

 
