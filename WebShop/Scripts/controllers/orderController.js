
app.controller("orderController", function ($scope) {
    var self = this;
    self.cartItems = [];
    self.initialQuantity = 1;
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

});
