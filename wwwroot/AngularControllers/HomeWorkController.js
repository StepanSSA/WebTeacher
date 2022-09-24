(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeWorkController', HomeWorkController);

    HomeWorkController.$inject = ['$scope'];

    function HomeWorkController($scope) {

        $scope.data;
        $scope.filterBy;
        $scope.reverseBool = false;

        activate();

        function activate() { }
    }
})();
