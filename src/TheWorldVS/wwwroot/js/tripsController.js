(function () {
    'use strict';

    angular
        .module('app-trips')
        .controller('tripsController', tripsController);

    tripsController.$inject = ['$scope', '$http'];

    function tripsController($scope, $http) {
        $scope.title = 'tripsController';
        $scope.trips = [{
            name: "US Trip",
            created: new Date()
        }, {
            name: "World Trip",
            created: new Date()
        }];
        $scope.newTrip = {};

        $http.get('/api/trips')
            .then(function (response) {
                angular.copy(response.data, $scope.trips);
                
            }, function () {

        });

        $scope.addTrip = function () {
            $scope.trips.push({ name: $scope.newTrip.name, created: new Date() });
            $scope.newTrip = {};
        }

        activate();

        function activate() { }
    }
})();

