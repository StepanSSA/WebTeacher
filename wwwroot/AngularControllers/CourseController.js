(function () {
    'use strict';

    angular
        .module('app')
        .controller('CourseController', CourseController);

    CourseController.$inject = ['$scope'];

    function CourseController($scope) {
        $scope.title = 'CourseController';


        $scope.LoadFile = function (videoId) {
            
        };

        activate();

        function activate() { }
    }
})();
