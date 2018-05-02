(function () {
    'use strict';

    angular
        .module('formApp')
        .controller('formController', ['$scope', 'questionsFactory', formController]);

    function formController($scope, questionsFactory) {
        // console.log($scope);
        // we will store all of our form data in this object
        $scope.formData = {};
        $scope.questions = questionsFactory.getAllQuestions();
        console.log($scope.questions);
        // function to process the form
        $scope.processForm = function () {
            alert('awesome!');
        };
    }
})();