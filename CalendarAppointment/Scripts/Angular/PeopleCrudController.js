// Code goes here
(function () {
    var app = angular.module("People", ["xeditable"]);
    var PeopleCRUD = function ($scope, $http) {
        $scope.message = "Angular is loaded";

        var setPeopleScope = function (people)
        {
            $scope.people = people.data;
        }

        onError = function ()
        {
            alert("I have no idea what happened. But its not my problem");
        }
        $http.get("/people/getpeople")
            .then(setPeopleScope, onError);

        $scope.updatePerson = function (person)
        {
            $http.post("/people/createupdate", person).then(function (response)
            {
                console.log(response.data)
                if (response.data.id)
                {
                    for (i = 0; i < $scope.people.length; i++) {
                        if ($scope.people[i].Id == person.Id) {
                            $scope.people[i].Id = response.data.id
                        }
                    }
                }
            })
        }
        $scope.deletePerson = function (person)
        {
            $http.post("/people/deleteperson", person).then(function (response) {
                if (response.data.success == true) {
                    for (i = 0; i < $scope.people.length; i++) {
                        if ($scope.people[i].Id == person.Id) {
                            $scope.people.splice(i, 1);
                        }
                    }
                }
            });;
        }

        $scope.create = function ()
        {
            var tempPerson = { FirstName: "", LastName: "", Email: "", Phone: "", Id: 0 };
            $scope.people.push(tempPerson);
        }
    };

    app.controller("PeopleCRUD", PeopleCRUD);
    app.run(['editableOptions', function (editableOptions) {
        editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'
    }]);
}());

