
app = angular.module('storeApp', []); 

app.controller('orderController', [              
    '$scope',                              
    function orderController($scope) {  


  $scope.options = [
    { label: '0', value: 0 },
    { label: '1', value: 1 },
    { label: '2', value: 2 },
    { label: '3', value: 3 },
    { label: '4', value: 4 },
    { label: '5', value: 5 }
  ];
 
 
  $scope.myBed = $scope.options[0];
  $scope.myNightstand = $scope.options[0];
  $scope.myHammock = $scope.options[0];

  $scope.pokus = 'trt';
  }
]);


app.controller('productsController', [              
    '$scope',                              
    function productsController($scope) {        
        $scope.items = [
      {name: 'Bed', price: '699', oldprice: '760'},
      {name: 'Nightstand', price: '399', oldprice: '450'},
      {name: 'Hammock', price: '599', oldprice: '640'}
       ];                 
    }                                                
]); 