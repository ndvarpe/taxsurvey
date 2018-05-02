(function() {
  'use strict';

  angular
    .module('formApp')
      .controller('questionController', ['$scope', 'questionsFactory', '$stateParams', questionController]);

  function questionController($scope, questionsFactory, $stateParams) {
      console.log($stateParams.questionId);
      $scope.question = $scope.$parent.questions.filter(function (q) { return q.Id == $stateParams.questionId })[0];
  }
})();