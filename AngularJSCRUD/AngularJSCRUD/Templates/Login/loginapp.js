var app = angular.module('loginApp', []);


app.factory('loginService', function ($http) {
    //Initialize factory Object.
    var fact = {};
    fact.getUserDetails = function (d) {
        debugger;
        return $http({
            url: '/Login/LoginUser',
            method: 'POST',
            data: JSON.stringify(d),
            headers: { 'content-type': 'application/json' }
        });
    };

    return fact;
});

app.controller('loginController', function ($scope, loginService) {
    //Initialize user data object
    $scope.loginData = {
        Username: '',
        Password: ''
    }
    $scope.msg = "";
    $scope.Submitted = false;
    $scope.IsLoggedIn = false;
    $scope.IsFormValid = false;

    //Check whether the form is valid or not using $watch
    $scope.$watch("myForm.$valid", function (TrueOrFalse) {
        $scope.IsFormValid = TrueOrFalse; //returns true if form valid
    });

    $scope.LoginForm = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
            loginService.getUserDetails($scope.UserModel).then(function (d) {
                debugger;
                if (d.data.Username != null) {
                    debugger;
                    $scope.IsLoggedIn = true;
                    //$scope.msg = "You Successfully Logged Mr/Ms " + d.data.FullName;
                    window.location.href = '#/Employees'
                }
                else {
                    alert("Invalid credentials buddy! Try Again");
                }
            });
        }
    }
});