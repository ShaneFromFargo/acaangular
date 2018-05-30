// Code goes here
(function () {
    var app = angular.module("githubViewer", []);
    var MainController = function ($scope, $http) {
        var onUserComplete = function (response) {
            console.log(response.data);
            $scope.users = response.data;
        }
        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        }
        $http.get("/bookings/getbookings")
            .then(onUserComplete, onError);

        $scope.search = function () {
            $http.get("/bookings/SearchBookings/" + $scope.searchParameter)
                .then(onUserComplete, onError);
        }

    };

    app.controller("MainController", MainController);
}());

