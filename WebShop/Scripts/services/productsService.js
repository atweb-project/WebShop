
app.factory("productsService", ["$http", function ($http) {
    return {
        getItems:function () {
            return $http.get("/Order/GetItems");
        }
    };
}]);  

