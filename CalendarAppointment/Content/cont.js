// Code goes here
(function () {
    var app = angular.module("githubViewer", []);
    var MainController = function ($scope, $http) {
        var onUserComplete = function (response) {
            $scope.user = response.data;
        }
        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        }
        $http.get("https://api.github.com/users/shanefromfargo")
            .then(onUserComplete, onError);

        $scope.MyTacoButton = function () {
            alert($scope.taco);
        }

    };

    app.controller("MainController", MainController);
}());


