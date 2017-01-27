angular.module('MagicSquare.config', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/config', {
        templateUrl: 'config/config.html'
    });
}])
.controller('ConfigCtrl', function ResultCtrl($scope, $http) {
    var config = this;
    config.squareSize = 3;
    config.LoadConstant = function () {
        $http.get('/api/Square/' + config.squareSize + '/Constant').
        then(function (data) {
            config.constant = data.data;
        });

    };

    config.LoadConstant();
    //var resultContext = this;
    //$http.get('/api/Square/' + $routeParams.squareSize).
    //        then(function (data) {
    //            resultContext.gridResult = data.data;
    //        });
});