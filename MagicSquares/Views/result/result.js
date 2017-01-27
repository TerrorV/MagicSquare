angular.module('MagicSquare.result', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/result/:squareSize', {
        templateUrl: 'result/result.html'
    });
}])
.controller('ResultCtrl', function ResultCtrl($scope, $http, $routeParams) {
    var resultContext = this;
    resultContext.squareSize = $routeParams.squareSize;
    $http.get('/api/Square/' + $routeParams.squareSize).
	        then(function (data) {
	            resultContext.gridResult = data.data;
	        });
});