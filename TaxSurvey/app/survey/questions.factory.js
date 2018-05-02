angular.module('formApp').
    factory('questionsFactory', questionsFactory);

function questionsFactory() {
    return {
        getAllQuestions: getAllQuestions
    }

    function getAllQuestions() {
        var questions = [];
        questions.push({ text: "What is your name?", type: 'text', weight: 10, options: [] });
        questions.push({ text: "Your gender?", type: 'radio', weight: 10, options: [{ text: 'Male', value: 1 }, { text: 'Female', value: 2 }] });
        questions.push({ text: "Your area of service?", type: 'checkbox', weight: 10, options: [{ text: 'Pune', value: 1 }, { text: 'Mumbai', value: 2 }, { text: 'Nagpur', value: 3 }] });
        return questions;
    }
}