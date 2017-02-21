
app.factory('productsService', ['$http', function ($http) {

    var productsService = {};

    productsService.getItems= function () {
        return $http.get('/Order/GetItems');
    };

    return productsService;
}]);  

