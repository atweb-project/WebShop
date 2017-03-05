
app.factory("orderService", ["$http", function ($http) {
    return {
        postOrder: function (orderViewModel) {
            return $http.post("/Order/SaveOrder", orderViewModel);
        }
    };
}]);  

