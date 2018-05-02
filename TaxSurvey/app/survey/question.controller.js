(function() {
  'use strict';

  angular
    .module('formApp')
      .controller('questionController', ['$scope', 'questionsFactory', questionController]);

  function questionController($scope, questionsFactory) {
      console.log($scope);
  }
})();