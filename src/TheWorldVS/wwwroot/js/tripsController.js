(function () {
    'use strict';

    angular
        .module('app-trips')
        .controller('tripsController', tripsController);

    tripsController.$inject = ['$scope']; 

    function tripsController($scope) {
        $scope.title = 'tripsController';
        $scope.name = 'Bobby';
        $scope.trips = [{
            name: "US Trip",
            created: new Date()
        }, {
            name: "World Trip",
            created: new Date()
        }];

        activate();

        function activate() { }
    }
})();

