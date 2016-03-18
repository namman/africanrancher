(function () {
    'use strict';

    angular
        .module('app')
        .controller('bovinesController', bovinesController);

    bovinesController.$inject = ['$location','$scope']; 

    function bovinesController($location,$scope) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'bovinesController';

        $scope.title = "Test title";

        activate();

        function activate() { }
    }
})();
