/// <reference path="angular.js" />

var app = angular
    .module("EmployeeService", ["ui.router"])
    .config(function ($stateProvider, $urlRouterProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/Employee");

        $stateProvider
            .state("display", {
                url: "/Employee",
                templateUrl: "Pages/DisplayEmployee.html",
                controller: "GetAllEmployeeController",
            })

            .state("update", {
                url: "/Employee/:id",
                templateUrl: "Pages/UpdateEmployee.html",
                controller: "GetEmployeeController"
            })
    })

    .controller("GetAllEmployeeController", function ($scope, $http) {

        $scope.showError = false;

        $http.get('http://localhost:60068/api/Employee')
            .then(function (response) {
                $scope.employees = response.data;
            }, function (reason) {
                $scope.showError = true;
                console.log(reason.data);
                $scope.error = reason.data;
            });

    })

    .controller("AddEmployeeController", function ($scope, $http, $state) {

        $scope.showError = false;

        $scope.addEmployee = function () {
            var employee = {
                firstName: $scope.firstName,
                lastName: $scope.lastName,
                gender: $scope.gender,
                specialization: $scope.specialization,
                salary: $scope.salary
            };
            $http.post('http://localhost:60068/api/Employee', employee)
                .then(function (response) {
                    console.log(response.data);
                    $state.reload();
                }, function (reason) {
                        $scope.showError = true;
                        console.log(reason.data);
                        $scope.error = reason.data;
                });
        }
    })

    .controller("DeleteEmployeeController", function ($scope, $http, $state, $location) {

        $scope.deleteEmployeeId = function (id) {
            $scope.employeeId = id;
        }

        $scope.confirmedDeleteEmployeeId = function () {
            $http.delete('http://localhost:60068/api/Employee/' + $scope.employeeId)
                .then(function (response) {
                    console.log(response.data);
                    $location.path("display");
                    $state.reload();
                });
        }
    })

    .controller("GetEmployeeController", function ($scope, $http, $location, $stateParams) {

        $http.get('http://localhost:60068/api/Employee/' + $stateParams.id)
            .then(function (response) {
                $scope.updatefirstName = response.data.firstName;
                $scope.updatelastName = response.data.lastName;
                $scope.updategender = response.data.gender;
                $scope.updatespecialization = response.data.specialization;
                $scope.updatesalary = response.data.salary;
            });

        $scope.confirmedUpdateEmployeeData = function () {
            var employee = {
                firstName: $scope.updatefirstName,
                lastName: $scope.updatelastName,
                gender: $scope.updategender,
                specialization: $scope.updatespecialization,
                salary: $scope.updatesalary
            };
            $http.put('http://localhost:60068/api/Employee/' + $stateParams.id, employee)
                .then(function (response) {
                    console.log(response.data);
                 
                    $location.path("display");
                });
        }

    });

