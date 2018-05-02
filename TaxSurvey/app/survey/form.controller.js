(function () {
    'use strict';

    angular
        .module('formApp')
        .controller('formController', ['$scope', 'questionsFactory', 'questions', formController]);

    function formController($scope, questionsFactory, questions ) {
        // console.log($scope);
        // we will store all of our form data in this object
        $scope.formData = {};
        $scope.questions = questions.data;
        //questionsFactory.getAllQuestions().then(function (d) {
        //    $scope.questions = d.data;
        //});
        console.log($scope.questions);
        // function to process the form
        $scope.processForm = function () {
            alert('awesome!');
        };
    }
})();