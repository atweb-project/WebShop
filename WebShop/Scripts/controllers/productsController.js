
app.controller('productsController', [
    '$scope',
    function productsController($scope) {
        $scope.items = [
      { name: 'Bed', price: '699', oldprice: '760', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sapien risus, blandit at fringilla ac, varius sed dolor. Donec augue lacus, vulputate sed consectetur facilisis, interdum pharetra ligula. Nulla suscipit erat nibh, ut porttitor nisl dapibus eu.', image: 'product1.jpg' },
      { name: 'Nightstand', price: '399', oldprice: '450', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sapien risus, blandit at fringilla ac, varius sed dolor. Donec augue lacus, vulputate sed consectetur facilisis, interdum pharetra ligula. Nulla suscipit erat nibh, ut porttitor nisl dapibus eu.', image: 'product2.jpg' },
      { name: 'Hammock', price: '599', oldprice: '640', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sapien risus, blandit at fringilla ac, varius sed dolor. Donec augue lacus, vulputate sed consectetur facilisis, interdum pharetra ligula. Nulla suscipit erat nibh, ut porttitor nisl dapibus eu.', image: 'product3.jpg' }
        ];
    }
]);

