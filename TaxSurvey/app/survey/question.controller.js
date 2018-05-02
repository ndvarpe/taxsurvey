(function() {
  'use strict';

  angular
    .module('formApp')
      .controller('questionController', ['$scope', 'questionsFactory', '$state', '$stateParams', questionController]);

  function questionController($scope, questionsFactory, $state, $stateParams) {
      $scope.totalQuestions = $scope.$parent.questions;
      $scope.question = $scope.$parent.questions.filter(function (q) { return q.QuestionId == $stateParams.questionId })[0];
      $scope.submitAnswer = function () {
          console.log($scope.question);
          switch ($scope.question.Type) {
              case 'radio':
              case 'checkbox':
                              var selectedAnswers = $scope.question.Options.filter(function (opt) { return opt.IsSelected == true });
                              if (selectedAnswers && selectedAnswers.length > 0) {
                                  if ($scope.question.QuestionId == $scope.totalQuestions.length) {
                                      console.log($scope.$parent.questions);
                                      $scope.$parent.processForm();
                                  }
                                  else{
                                      $state.go('form.question', { questionId: $scope.question.QuestionId + 1 });
                                  }
                              }
                            break;
              case 'text':
                              if ($scope.question.Answer) {
                                  $state.go('form.question', { questionId: $scope.question.QuestionId + 1 });
                              }
                              if ($scope.question.QuestionId == $scope.totalQuestions.length) {
                                  console.log($scope.$parent.questions);
                                  $scope.$parent.processForm();
                              }
                              else {
                                  $state.go('form.question', { questionId: $scope.question.QuestionId + 1 });
                              }
                              break;
              default:
                            break;
          }
      }
  }
})();