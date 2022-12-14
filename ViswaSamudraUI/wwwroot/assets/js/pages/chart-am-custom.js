'use strict';
$(document).ready(function () {
    $('g:has(> g[stroke="#3cabff"])').hide();
    setTimeout(function() {
     

        // [ XY-Stacked-1 chart ] start
        $(function() {
            am4core.useTheme(am4themes_animated);

            var chart = am4core.create("am-xy-1", am4charts.XYChart);
            chart.data = [
            {
                "country": "Lithuania",
                "research": 501.9,
                "marketing": 250,
                "sales": 199
            }, {
                "country": "Czech Republic",
                "research": 301.9,
                "marketing": 222,
                "sales": 251
            }, {
                "country": "Ireland",
                "research": 201.1,
                "marketing": 170,
                "sales": 199
            }, {
                "country": "Germany",
                "research": 165.8,
                "marketing": 122,
                "sales": 90
            }, {
                "country": "Australia",
                "research": 139.9,
                "marketing": 99,
                "sales": 252
            }, {
                "country": "Austria",
                "research": 128.3,
                "marketing": 85,
                "sales": 84
            }, {
                "country": "UK",
                "research": 99,
                "marketing": 93,
                "sales": 142
            }, {
                "country": "Belgium",
                "research": 60,
                "marketing": 50,
                "sales": 55
            }, {
                "country": "The Netherlands",
                "research": 50,
                "marketing": 42,
                "sales": 25
            }];

            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "country";        
            
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
           

            var series = chart.series.push(new am4charts.ColumnSeries());
            series.dataFields.valueY = "research";
            series.dataFields.categoryX = "country";
            series.name = "Research";
            series.tooltipText = "{name}: [bold]{valueY}[/]";
            series.stacked = true;

            var series2 = chart.series.push(new am4charts.ColumnSeries());
            series2.dataFields.valueY = "marketing";
            series2.dataFields.categoryX = "country";
            series2.name = "Marketing";
            series2.tooltipText = "{name}: [bold]{valueY}[/]";
            series2.stacked = true;

            var series3 = chart.series.push(new am4charts.ColumnSeries());
            series3.dataFields.valueY = "sales";
            series3.dataFields.categoryX = "country";
            series3.name = "Sales";
            series3.tooltipText = "{name}: [bold]{valueY}[/]";
            series3.stacked = true;

            chart.cursor = new am4charts.XYCursor();
            if (chart.logo) {
                chart.logo.disabled=true;
            }

        });
    }, 700);
});
