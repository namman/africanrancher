(function () {
    'use strict';

    angular
        .module('app')
        .controller('bovinesController', bovinesController);

    bovinesController.$inject = ['$location','$scope','$http']; 

    function bovinesController($location,$scope,$http) {
        /* jshint validthis:true */

        var bovinesGridViewModel = function() {
            var bovineKendoModel = kendo.data.Model.define({
                fields: {
                    'Id': {
                        editable: false,
                        type: 'number'
                    },
                    'EarTag': {
                        editable: true,
                        type: 'string'
                    },
                },
                id: 'Id'
            });

            var bovinesDataSource = new kendo.data.DataSource( {
                schema: {
                    model: bovineKendoModel
                },
                transport: {
                    read: {
                        datatype: 'json',
                        url: 'api/bovines'
                    }
                }
            });

            var options = {
                columns: [
                    {
                        field: "Id",
                        title: "Id"
                    },
                    {
                        field: 'EarTag',
                        title: 'Ear Tag'
                    }
                ],
                dataSource: bovinesDataSource

            }
            
            return {
                options: options
            }

        }();

        activate();

        function activate() {
            $scope.bovinesGridOptions = bovinesGridViewModel.options;
        }
    }
})();
