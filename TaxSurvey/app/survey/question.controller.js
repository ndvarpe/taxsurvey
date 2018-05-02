(function() {
  'use strict';

  angular
    .module('formApp')
      .controller('questionController', ['$scope', 'questionsFactory', '$state', '$stateParams', questionController]);

  function questionController($scope, questionsFactory, $state, $stateParams) {
      $scope.totalQuestions = $scope.$parent.questions;
      $scope.question = $scope.$parent.questions.filter(function (q) { return q.Id == $stateParams.questionId })[0];
      $scope.submitAnswer = function () {
          console.log($scope.question);
          switch ($scope.question.Type) {
              case 'radio':
                              if ($scope.question.Answer) {
                                  $state.go('form.question', { questionId: $scope.question.Id + 1 });
                              }
                            break;
              case 'text':
                              if ($scope.question.Answer) {
                                  $state.go('form.question', { questionId: $scope.question.Id + 1 });
                              }
                            break; 
              case 'checkbox':
                              if ($scope.question.Answer) {
                                  $state.go('form.question', { questionId: $scope.question.Id + 1 });
                              }
                            break;
          }
      }
  }
})();