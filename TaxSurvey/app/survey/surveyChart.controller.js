(function () {
    'use strict';

    angular
	  .module('formApp')
		.controller('surveyChartController', ['$scope', 'questionsFactory', '$state', '$stateParams', surveyChartController]);

    function surveyChartController($scope, questionsFactory, $state, $stateParams) {

        var columnChart = AmCharts.makeChart("columnChart", {
            "theme": "light",
            "type": "serial",
            "startDuration": 2,
            "dataProvider": [{
                "country": "Compliance",
                "visits": 20,
                "color": "#FF0F00"
            }, {
                "country": "Efficiency",
                "visits": 40,
                "color": "#FF6600"
            }, {
                "country": "Psychological",
                "visits": 80,
                "color": "#FF9E01"
            }],
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

            //alert(event.item.category);
            pieChart.dataProvider = [{
                "country": "Time",
                "value": 10
            }, {
                "country": "Money",
                "value": 30
            }, {
                "country": "Others",
                "value": 70
            }];
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