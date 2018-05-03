(function () {
    'use strict';

    angular
        .module('formApp')
        .controller('questionController', ['$scope', 'questionsFactory', '$state', '$stateParams', questionController]);

    function questionController($scope, questionsFactory, $state, $stateParams) {
        $scope.totalQuestions = $scope.$parent.questions;
        $scope.question = $scope.$parent.questions.filter(function (q) { return q.QuestionId == $stateParams.questionId })[0];
        $scope.submitAnswer = function () {
            $scope.question.IsAnswered = true;
            switch ($scope.question.Type) {
                case 'radio': if ($scope.question.SelectedOption != 0) {
                    var selectedOption = $scope.question.Options.filter(function (o) { return o.Value == $scope.question.SelectedOption })[0];
                    if (selectedOption && selectedOption.NextQuestionId) {
                        if ($scope.question.QuestionId == $scope.totalQuestions.length) {
                            $scope.$parent.processForm();
                        }
                        else {
                            var nextQuestion = $scope.$parent.questions.filter(function (q) { return q.QuestionId == selectedOption.NextQuestionId })[0];
                            if (nextQuestion) {
                                nextQuestion.PreviousQuestionId = $scope.question.QuestionId;
                            }
                            $state.go('form.question', { questionId: selectedOption.NextQuestionId });
                        }
                    }
                }
                    break;
                case 'checkbox':
                    var selectedAnswers = $scope.question.Options.filter(function (opt) { return opt.IsSelected == true });
                    if (selectedAnswers && selectedAnswers.length > 0) {
                        if ($scope.question.QuestionId == $scope.totalQuestions.length) {
                            console.log($scope.$parent.questions);
                            $scope.$parent.processForm();
                        }
                        else {
                            var nextQuestion = $scope.$parent.questions.filter(function (q) { return q.QuestionId == selectedAnswers[0].NextQuestionId })[0];
                            if (nextQuestion) {
                                nextQuestion.PreviousQuestionId = $scope.question.QuestionId;
                            }
                            $state.go('form.question', { questionId: selectedAnswers[0].NextQuestionId});
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
        $scope.previousQuestion = function () {
            $scope.question.IsAnswered = false;
            $state.go('form.question', { questionId: $scope.question.PreviousQuestionId });
        }
    }
})();