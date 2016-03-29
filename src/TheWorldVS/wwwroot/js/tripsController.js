(function () {
    'use strict';

    angular
        .module('app-trips')
        .controller('tripsController', tripsController);

    tripsController.$inject = ['$http'];

    function tripsController($http) {

        /* jshint validthis: true */
        var vm = this;

        vm.title = 'tripsController';
        vm.trips = [];
        vm.newTrip = {};
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.addTrip = addTrip;

        function getTrips() {
            $http.get('/api/trips')
            .then(function (response) {
                angular.copy(response.data, vm.trips);

            }, function () {
                vm.errorMessage = "Failed to get trips";
            })
            .finally(function () {
                vm.isBusy = false;
            });
        }

        function addTrip () {
            vm.isBusy = true;
            $http.post('/api/trips', vm.newTrip)
            .then(function (response) {
                vm.trips.push(response.data);
                vm.newTrip = {};
            }, function () {
                vm.errorMessage = "Failed to save new trip";
            })
            .finally(function () {
                vm.isBusy = false;
            });
        }

        activate();

        function activate() {
             return getTrips();
         }
    }
})();

