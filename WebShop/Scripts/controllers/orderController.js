
app.controller("orderController", function ($scope, orderService) {
    var self = this;
    self.cartItems = [];
    self.orderModel = {};
    $scope.$on("addItem", function (event, data) {
        self.cartItems.push(data);
        console.log(self.cartItems);
    });
    self.removeItem = function(index) {
        if (index.Quantity > 0) {
            index.Quantity--;
        }
        self.cartItems.splice(index, 1);
    };
    self.total = function() {
        var total = 0;
        angular.forEach(self.cartItems, function(item) {
            total += item.Quantity * item.Price;
        });
        return total;
    };
    self.saveOrder = function () {       
        self.orderModel.ListOfItemViewModels = self.cartItems;
        console.log(self.orderModel);
        return orderService.postOrder(self.orderModel).then(function (response) {
            console.log(response);
        }, function (error) {
              console.log(error);
        });
    };

});
