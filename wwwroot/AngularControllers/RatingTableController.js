(function () {
    'use strict';

    angular
        .module('app')
        .controller('RatingTableController', RatingTableController);

    RatingTableController.$inject = ['$scope'];

    function RatingTableController($scope) {
        $scope.data;
        activate();
        function activate()
        {
            
        }
    }
})();
