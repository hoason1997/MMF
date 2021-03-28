// Load google charts
//google.charts.load('current', { 'packages': ['corechart'] });
google.charts.load('current', { 'packages': ['line','corechart'] });

google.charts.setOnLoadCallback(drawChart);
google.charts.setOnLoadCallback(drawVisualization);
google.charts.setOnLoadCallback(drawLineChart);

// Draw the simple pie chart and set the chart values
function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['Đường thô', 'Percentages'],
        ['Đường phèn', 55],
        ['Đường mía lùi', 20],
        ['Đường khô', 10],
        ['Đường bụi', 10],
        ['Đường nhập', 5]
    ]);

    // Optional; add a title and set the width and height of the chart
    var options = { 'width': 500, 'height': 500 };

    // Display the chart inside the <div> element with id="piechart"
    var chart = new google.visualization.PieChart(document.getElementById('piechart'));
    chart.draw(data, options);
}

// Draw the combo chart and set the chart values
function drawVisualization() {
    // Some raw data (not necessarily accurate)
    var data = google.visualization.arrayToDataTable([
        ['Month', 'Đường phèn', 'Đường mía lùi', 'Đường khô', 'Đường bụi', 'Đường nhập'],
        ['11/2020', 165, 938, 522, 998, 450],
        ['12/2020', 135, 1120, 599, 1268, 288],
        ['01/2021', 157, 1167, 587, 807, 397],
        ['02/2021', 139, 1110, 615, 968, 215],
        ['03/2021', 136, 691, 629, 1026, 366]
    ]);

    var options = {
        title: 'Sản lượng đường qua các tháng',
        vAxis: { title: 'Tấn' },
        hAxis: { title: 'Tháng' },
        seriesType: 'bars',
        'width': 900, 'height': 500,
        series: { 5: { type: 'line' } }
    };

    var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}

// Draw the line chart and set the chart values
function drawLineChart() {

    var chartDiv = document.getElementById('chart_line');

    var data = new google.visualization.DataTable();
    data.addColumn('date', 'Tháng');
    data.addColumn('number', "Đường thô");
    data.addColumn('number', "Đường sản xuất");
    data.addColumn('number', "Đường đóng bao");

    data.addRows([
        [new Date(2020, 8), 112, 66, 555],
        [new Date(2020, 9), 11, 665, 55],
        [new Date(2020, 10), 114, 66, 555],
        [new Date(2020, 11), 11, 66, 55],
        [new Date(2020, 12), 114, 665, 55],
        [new Date(2021, 1), 11, 66, 555],
        [new Date(2021, 2), 112, 626, 145],
        [new Date(2021, 3), 611, 266, 325],
    ]);

    var materialOptions = {
        
        width: 1000,
        height: 500,
        series: {
            // Gives each series an axis name that matches the Y-axis below.
            0: { axis: 'Tấn' },
        },
        axes: {
            // Adds labels to each axis; they don't have to match the axis names.
            y: {
                Tấn: { label: 'Tấn' },
            }
        }
    };

    function drawMaterialChart() {
        var materialChart = new google.charts.Line(chartDiv);
        materialChart.draw(data, materialOptions);
        button.innerText = 'Change to Classic';
        button.onclick = drawClassicChart;
    }

    function drawClassicChart() {
        var classicChart = new google.visualization.LineChart(chartDiv);
        classicChart.draw(data, classicOptions);
        button.innerText = 'Change to Material';
        button.onclick = drawMaterialChart;
    }

    drawMaterialChart();

}