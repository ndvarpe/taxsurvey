(function () {
    'use strict';

    angular
	  .module('formApp')
		.controller('surveyChartController', ['$scope', 'questionsFactory', '$state', '$stateParams', surveyChartController]);

    function surveyChartController($scope, questionsFactory, $state, $stateParams) {
        var data = $stateParams.data;
        $scope.comments = data ? data.comments : [];
        $scope.totalWeightage = data ? data.totalWeightage : 100;
        var dataProvider = [];

        $('#pieChart').hide();

        for(var key in data.barChart){
            dataProvider.push({
                "country": key,
                "visits": data.barChart[key],
                "color": "#FF0F00"
            });
        }

        var columnChart = AmCharts.makeChart("columnChart", {
            "theme": "light",
            "type": "serial",
            "startDuration": 2,
            "dataProvider": dataProvider,
            "valueAxes": [{
                "position": "left",
                "title": "Risk"
            }],
            "graphs": [{
                "balloonText": "[[category]]: <b>[[value]]</b>",
                "fillColorsField": "color",
                "fillAlphas": 1,
                "lineAlpha": 0.1,
                "type": "column",
                "valueField": "visits"
            }],
            "depth3D": 20,
            "angle": 30,
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "country",
            "categoryAxis": {
                "gridPosition": "start",
                "labelRotation": 90
            },
            "export": {
                "enabled": false
            },
            "listeners": [{
                "event": "clickGraphItem",
                "method": updatePieChart
            }]
        });

        function updatePieChart(event) {
            var piedataProvider = [];
            $('#pieChart').show();
            if (event.item.category == 'Compliance') {

                piedataProvider.push({
                    "country": "Time",
                    "value": data.pieChart['Time']
                });
                piedataProvider.push({
                    "country": "Money",
                    "value": data.pieChart['Money']
                });
                piedataProvider.push({
                    "country": "Other",
                    "value": data.pieChart['Other']
                });
            }
            else if (event.item.category == 'Efficiency') {

                piedataProvider.push({
                    "country": "Operational",
                    "value": data.pieChart['Operational']
                });
                piedataProvider.push({
                    "country": "Burden",
                    "value": data.pieChart['Burden']
                });
                piedataProvider.push({
                    "country": "Other",
                    "value": data.pieChart['CostOfPF']
                });
            } else {
                piedataProvider.push({
                    "country": "Psychological",
                    "value": data.barChart['Psychological']
                });
                piedataProvider.push({
                    "country": "Other",
                    "value": data.pieChart['Other']
                });
            }
            pieChart.dataProvider = piedataProvider;
           pieChart.validateData();
        }

        var pieChart = AmCharts.makeChart("pieChart", {
            "type": "pie",
            "theme": "light",
            "dataProvider": [{
                "country": "Time",
                "value": 50
            }, {
                "country": "Money",
                "value": 20
            }, {
                "country": "Others",
                "value": 30
            }],
            "valueField": "value",
            "titleField": "country",
            "outlineAlpha": 0.4,
            "depth3D": 15,
            "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
            "angle": 30,
            "export": {
                "enabled": false
            }
        });

    }
})();