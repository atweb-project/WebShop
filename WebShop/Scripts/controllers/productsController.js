
app.controller('productsController', [
    '$scope',
    function productsController($scope) {
        $scope.items = [
      { name: 'Bed', price: '699', oldprice: '760' },
      { name: 'Nightstand', price: '399', oldprice: '450' },
      { name: 'Hammock', price: '599', oldprice: '640' }
        ];
    }
]);

