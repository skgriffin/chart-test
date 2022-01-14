// the default colorPalette for this dashboard
var colorPalette = ['#00D8B6','#008FFB',  '#FEB019', '#FF4560', '#775DD0']

function LoadChart(vaultScores, barScores, beamScores, floorScores, labels) {
    var optionsBar = {
        chart: {
            type: 'area',
            height: 380,
            width: '100%',
            stacked: false,
            },
        plotOptions: {
            bar: {
                columnWidth: '45%',
            }
        },
        colors: colorPalette,
        series: [{
                    name: "Vault",
                    data: vaultScores,
                },
                {
                    name: "Bars",
                    data: barScores,
                },
                {
                    name: "Beam",
                    data: beamScores,
                },
                {
                    name: "Floor",
                    data: floorScores,
                }],
        labels: labels,
        xaxis: {
            labels: {
                show: true
            },
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
        },
        yaxis: {
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
            labels: {
                style: {
                colors: '#78909c'
                }
            }
        },
        title: {
            text: 'Event Scores',
            align: 'left',
            style: {
                fontSize: '18px'
            }
        }
    
    }
    
    var chartBar = new ApexCharts(document.querySelector('#bar'), optionsBar);
    chartBar.render();
}

function LoadDonutChart(series, labels) {
    // Donut Chart
    donutChart = {
        chart: {
            height: 350,
            type: 'donut',
            toolbar: {
                show: false,
            }
        },
        series: series,
        labels: labels,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 305
                },
                legend: {
                    position: 'bottom'
                }
            }
        }],
        title: {
            text: 'Levels',
            align: 'center',
            style: {
                fontSize: '18px'
            }
        }
    }
    donut = new ApexCharts(
        document.querySelector("#donut-chart"),
        donutChart
    );
    donut.render();
}

