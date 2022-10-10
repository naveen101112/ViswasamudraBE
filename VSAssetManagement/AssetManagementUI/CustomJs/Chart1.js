am5.ready(function() {
		
		// Create root element
		// https://www.amcharts.com/docs/v5/getting-started/#Root_element
		var root1 = am5.Root.new("chartdiv1");
		
		
		// Set themes
		// https://www.amcharts.com/docs/v5/concepts/themes/
		root1.setThemes([
		  am5themes_Animated.new(root1)
		]);
		
		
		// Create chart
		// https://www.amcharts.com/docs/v5/charts/xy-chart/
		var chart1 = root1.container.children.push(am5xy.XYChart.new(root1, {
		  panX: true,
		  panY: true,
		  wheelX: "panX",
		  wheelY: "zoomX",
		  pinchZoomX:true
		}));
		
		// Add cursor
		// https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
		var cursor1 = chart1.set("cursor", am5xy.XYCursor.new(root1, {}));
		cursor1.lineY.set("visible", false);
		
		
		// Create axes
		// https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
		var xRenderer1 = am5xy.AxisRendererX.new(root1, { minGridDistance: 30 });
		xRenderer1.labels.template.setAll({
		  rotation: -90,
		  centerY: am5.p50,
		  centerX: am5.p100,
		  paddingRight: 15
		});
		
		var xAxis1 = chart1.xAxes.push(am5xy.CategoryAxis.new(root1, {
		  maxDeviation: 0.3,
		  categoryField: "country",
		  renderer: xRenderer1,
		  tooltip: am5.Tooltip.new(root1, {})
		}));
		
		var yAxis1 = chart1.yAxes.push(am5xy.ValueAxis.new(root1, {
		  maxDeviation: 0.3,
		  renderer: am5xy.AxisRendererY.new(root1, {})
		}));
		
		
		// Create series
		// https://www.amcharts.com/docs/v5/charts/xy-chart/series/
		var series1 = chart1.series.push(am5xy.ColumnSeries.new(root1, {
		  name: "Series 1",
		  xAxis: xAxis1,
		  yAxis: yAxis1,
		  valueYField: "value",
		  sequencedInterpolation: true,
		  categoryXField: "country",
		  tooltip: am5.Tooltip.new(root1, {
			labelText:"{valueY}"
		  })
		}));
		
		series1.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5 });
		series1.columns.template.adapters.add("fill", function(fill, target) {
		  return chart1.get("colors").getIndex(series1.columns.indexOf(target));
		});
		
		series1.columns.template.adapters.add("stroke", function(stroke, target) {
		  return chart1.get("colors").getIndex(series1.columns.indexOf(target));
		});
		
		
		// Set data
		var data1 = [{
		  country: "USA",
		  value: 2025
		}, {
		  country: "China",
		  value: 1882
		}, {
		  country: "Japan",
		  value: 1809
		}, {
		  country: "Germany",
		  value: 1322
		}, {
		  country: "UK",
		  value: 1122
		}, {
		  country: "France",
		  value: 1114
		}, {
		  country: "India",
		  value: 984
		}, {
		  country: "Spain",
		  value: 711
		}, {
		  country: "Netherlands",
		  value: 665
		}, {
		  country: "South Korea",
		  value: 443
		}, {
		  country: "Canada",
		  value: 441
		}];
		
		xAxis1.data.setAll(data1);
		series1.data.setAll(data1);
		
		
		// Make stuff animate on load
		// https://www.amcharts.com/docs/v5/concepts/animations/
		series1.appear(1000);
		chart1.appear(1000, 100);
		
		}); // end am5.ready()