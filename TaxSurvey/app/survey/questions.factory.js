angular.module('formApp').
    factory('questionsFactory', ['$http', '$location', questionsFactory]);

function questionsFactory($http, $location) {
    return {
        getAllQuestions: getAllQuestions
    }

    function getAllQuestions() {
        var questions = [];
        var baseUrl  = $location.$$absUrl;
        return $http.get('http://localhost:51885/api/questioner', function(data){
            console.log(data);
        });
        //questions.push({ Id : 1, Text: "What is your name?", Type: 'text', Weight: 10, Options: [] });
        //questions.push({ Id: 2, Text: "Your gender?", Type: 'radio', Weight: 10, Options: [{ Text: 'Male', Value: 1 }, { Text: 'Female', Value: 2 }] });
        //questions.push({ Id: 3, Text: "Your area of service?", Type: 'checkbox', Weight: 10, Options: [{ Text: 'Pune', Value: 1 }, { Text: 'Mumbai', Value: 2 }, { Text: 'Nagpur', Value: 3 }] });
        //return questions;
    }
}