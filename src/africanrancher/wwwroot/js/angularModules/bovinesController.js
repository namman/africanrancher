(function() {
    "use strict";

    angular
        .module("app")
        .controller("bovinesController", bovinesController);

    bovinesController.$inject = ["$location", "$scope", "$http"];

    function bovinesController($location, $scope, $http) {
        /* jshint validthis:true */

        var bovinesGridViewModel = function() {
            var bovineKendoModel = kendo.data.Model.define({
                fields: {
                    'Bolus': {
                        editable: true,
                        type: "string"
                    },
                    'EarTag': {
                        editable: true,
                        type: "string"
                    },
                    'Brand': {
                        editable: true,
                        type: "string"
                    },
                    'BirthDate': {
                        editable: true,
                        type: "date"
                    },
                    'WeeningDate': {
                        editable: true,
                        type: 'date'
                    },
                    'Breed': {
                        editable: true,
                        type: 'string'
                    },
                    'SireBolus': {
                        editable: true,
                        type: "string"
                    },
                    'DamBolus': {
                        editable: true,
                        type: "string"
                    }
                },
                id: "Id"
            });

            var bovinesDataSource = new kendo.data.DataSource({
                schema: {
                    model: bovineKendoModel
                },
                transport: {
                    read: {
                        datatype: "json",
                        url: "api/bovines"
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
                        field: "EarTag",
                        title: "Ear Tag"
                    },
                    {
                        field: "Bolus",
                        title: "Bolus"
                    },
                    {
                        field: "BirthDate",
                        title: "Calved"
                    },
                    {
                        field: 'WeeningDate',
                        title: 'Weening Date'
                    },
                {
                    field: 'Breed',
                    title: 'Breed'
                },
                    {
                        field: "SireBolus",
                        title: "Sire Bolus"
                    },
                    {
                        field: "DamBolus",
                        title: "Dam Bolus"
                    }
                ],
                dataSource: bovinesDataSource
            };
            return {
                options: options
            };
        }();

        activate();

        function activate() {
            $scope.bovinesGridOptions = bovinesGridViewModel.options;
        }
    }
})();