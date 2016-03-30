(function() {
    'use strict';

    angular
        .module('app-trips')
        .controller("tripEditorController", tripEditorController);

    tripEditorController.$inject = ['$routeParams', '$http'];

    function tripEditorController($routeParams, $http) {

        /* jshint validthis: true */
        var vm = this;
        

        vm.tripName = $routeParams.tripName;
        vm.stops = [];
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.newStop = {};
        vm.addStop = addStop;

        var url = "/api/trips/" + vm.tripName + "/stops";
       
        getStops();

        function addStop() {
            vm.isBusy = true;
            $http.post(url, vm.newStop)
                .then(function (response) {
                    vm.stops.push(response.data);
                    _showMap(vm.stops);
                    vm.newStop = {};
                }, function () {
                    vm.errorMessage = "Failed to add new stop.";
                })
                .finally(function (err) {
                    vm.isBusy = false;
                });

        }

        function getStops() {
            $http.get(url)
                .then(function (response) {
                    angular.copy(response.data, vm.stops);
                    _showMap(vm.stops);
                }, function() {
                    vm.errorMessage = "Failed to get stops.";
                })
                .finally(function(err) {
                    vm.isBusy = false;
                });
        }
    }

    function _showMap(stops) {
        if (stops && stops.length > 0) {
            var mapStops = _.map(stops, function(item){
                return {
                    lat: item.latitude,
                    long: item.longitude,
                    info: item.name
                };
            });

            travelMap.createMap({
                stops: mapStops,
                selector: "#map",
                currentStop: 1,
                initialZoom: 3
            })
        }
    }
})();