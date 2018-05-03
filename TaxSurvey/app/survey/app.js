
// create our angular app and inject ngAnimate and ui-router 
// =============================================================================
angular.module('formApp', ['ngAnimate', 'ui.router'])

    // configuring our routes 
    // =============================================================================
    .config(function ($stateProvider, $urlRouterProvider) {

        $stateProvider

            // route to show our basic form (/form)
            .state('form', {
                url: '/form',
                templateUrl: 'app/survey/form.html',
                controller: 'formController',
                resolve: {
                    questions: function (questionsFactory, $q) {
                        var defObj = $q.defer();
                        return questionsFactory.getAllQuestions().success(function (d) {
                            defObj.resolve(d);
                        });
                        return defObj.promise;
                    }
                }
            })
            // nested states 
            // each of these sections will have their own view
            // url will be nested (/form/profile)
            .state('form.profile', {
                url: '/profile',
                templateUrl: 'app/survey/form-profile.html'
            })

            // url will be /form/interests
            .state('form.interests', {
                url: '/interests',
                templateUrl: 'app/survey/form-interests.html',
                controller: 'questionController'
            })

            // url will be /form/payment
            .state('form.payment', {
                url: '/payment',
                templateUrl: 'app/survey/form-payment.html'
            })

            .state('form.question', {
            url: '/question/:questionId',
            templateUrl: 'app/survey/question.html',
            controller: 'questionController'
            })

        .state('form.surveyChart', {
            url: '/surveyChart',
            templateUrl: 'app/survey/surveyChart.html',
            controller: 'surveyChartController'
        })


        // catch all route
        // send users to the form page 
        //$urlRouterProvider.otherwise('/form/profile');

        $urlRouterProvider.otherwise(function ($injector, $location, $stateParams) {
            var state = $injector.get('$state');
            state.go("form.question", {questionId : 1}); // here we get { query: ... }
            return $location.path();
        });
    })

    // our controller for the form
    // =============================================================================
