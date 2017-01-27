/// <reference path="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.6.1/angular.js" />
'use strict';

// Declare app level module which depends on views, and components
angular.module('MagicSquare', [
  'ngRoute',
  'MagicSquare.result',
  'MagicSquare.config'
]).
config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('!');

    $routeProvider.otherwise({ redirectTo: '/config' });
}]);
