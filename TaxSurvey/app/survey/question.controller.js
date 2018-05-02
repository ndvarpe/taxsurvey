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
              case 'checkbox':
                              var selectedAnswers = $scope.question.Options.filter(function (opt) { return opt.Selected == true });
                              if (selectedAnswers && selectedAnswers.length > 0) {
                                  if ($scope.question.Id == $scope.totalQuestions.length) {
                                      console.log($scope.$parent.questions);
                                  }
                                  else{
                                      $state.go('form.question', { questionId: $scope.question.Id + 1 });
                                  }
                              }
                            break;
              case 'text':
                              if ($scope.question.Answer) {
                                  $state.go('form.question', { questionId: $scope.question.Id + 1 });
                              }
                              if ($scope.question.Id == $scope.totalQuestions.length) {
                                  console.log($scope.$parent.questions);
                              }
                              else {
                                  $state.go('form.question', { questionId: $scope.question.Id + 1 });
                              }
                              break;
              default:
                            break;
          }
      }
  }
})();