(function () {
    'use strict';

    angular
        .module('app')
        .controller('EditCourseController', EditCourseController);

    EditCourseController.$inject = ['$scope'];

    function EditCourseController($scope) {
        $scope.title = 'EditCourseController';

        activate();

        function activate() { }
    }
})();
