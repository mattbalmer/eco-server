    class ElectionVotingGraph {

        constructor(idSelector) {

            this.options = {
                chart: {
                    style: {
                        fontFamily: 'Abel',
                    },
                    spacingBottom: 0,
                    spacingTop: 0,
                    spacingLeft: 0,
                    spacingRight: 0,
                    marginBottom: 0,
                    marginTop: 0,
                    marginLeft: 0,
                    marginRight: 0,
                    width: 300,
                    height: 300,
                    backgroundColor: "transparent",
                    type: 'pie',
                    renderTo: idSelector
                },
                colors: ['#96ED79', '#54CC80', '#90ed7d', '#f7a35c', '#8085e9', '#f15c80', '#e4d354', '#8085e8', '#8d4653', '#91e8e1'],
                title: {
                    text: '',
                    style: {
                        color: '#ffffff',
                        fontSize: '30px'
                    },
                },
                legend: {
                     enabled : false,
                    //layout: 'vertical',
                    align: 'right',
                    // verticalAlign: 'middle',
                    //itemMarginBottom:20,
                    itemHiddenStyle: '#ffffff',
                    itemStyle: {
                        fontSize: 15
                    }
                },
                credits: {
                    enabled: false
                },
                tooltip: {
                    enabled:false,
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        borderColor: '#4A8235',
                        dataLabels: {
                            enabled: true,
                            //format: '{point.name}: {point.percentage:.1f} %',
                            color: '#365729',
                            fill: '#365729',
                            connectorWidth: 0,
                            //borderColor: '#4A8235',
                            //borderWidth: 3,
                            //borderRadius: 4,
                            distance: -50,
                            //backgroundColor: '#5BA041',
                            //padding:10,
                            style: {
                                color: '#fff',
                                fontSize: '18px',
                                textShadow: 'none'
                            },
                            shadow: {
                                color: '#386427 ',
                                width: 1,
                                opacity: 0.25,
                                offsetY: 2,
                                offsetX: 2
                            },
                            formatter: function () {
                                if (this.percentage == 0) {

                                    // this.series.options.dataLabels.y = -160;
                                    // this.series.options.dataLabels.x = -250;
                                }
                                return this.point.name + ':  ' + Math.round(this.percentage) + '%';
                            }
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Current votes',
                    colorByPoint: true,
                    data: []
                }]
            };
        }

        draw(data) {
            this.options.series[0].data = data;
            return new Highcharts.Chart(this.options);
        }
    }
