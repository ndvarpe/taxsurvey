angular.module('formApp').
    factory('questionsFactory', ['$http', '$location', questionsFactory]);

function questionsFactory($http, $location) {
    return {
        getAllQuestions: getAllQuestions,
        postAnswers: postAnswers
    }

    function getAllQuestions() {
        var questions = [];
        var baseUrl  = $location.$$absUrl;
        return $http.get('http://localhost:51885/api/questioner');
    }

    function postAnswers(questions) {
        //return $http.post('http://localhost:51885/api/questioner/Post', questions);
        return $http({
            url: 'http://localhost:51885/api/questioner/Post',
            method: "POST",
            data: JSON.stringify(questions), //JSON.stringify(questions),
            headers: {
                'Content-Type': 'application/json', /*or whatever type is relevant */
                'Accept': 'application/json' /* ditto */
            },
        })
    }
}