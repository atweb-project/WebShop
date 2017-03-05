app.controller("productsController", function (productsService, $rootScope) {
    var self = this;
    self.items = [];
   // self.cartItems = [];
    self.selectedItem = {};

    var fetchItems = function () {
        return productsService.getItems().then(function (itms) {
            self.items = itms.data;
            console.log(self.items);
        }, function (error) {
            self.status = "Unable to load customer data: " + error;
            console.log(self.status);
        });
    };

    self.addItems = function (item) {
        item.Quantity++;
      //  self.cartItems.push(item);       
        var aTag = $("section[id='orderform']");
        $("html,body").animate({ scrollTop: aTag.offset().top - 60 }, "slow");
        console.log(item)
        $rootScope.$broadcast("addItem", item);
    };

    self.showInModal = function (item) {
        self.selectedItem = {};
        return self.selectedItem = item;
    };

    fetchItems();

});