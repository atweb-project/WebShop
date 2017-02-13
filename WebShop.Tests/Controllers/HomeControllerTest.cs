using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShop;
using WebShop.Controllers;
using WebShop.Model;
using WebShop.Repository;
using WebShop.Services.Implementations;
using WebShop.Services.Mapping;

namespace WebShop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
        //OrderController
        [TestMethod]
        public void Order()
        {
            var globalMappings = new GlobalMappings(new MappingTypes());
            globalMappings.Initialize();

            var dbContext = new WebShopDBEntities();
            var unitOfWork = new UnitOfWork(dbContext);
            //// Arrange
            var customerService = new CustomerService(dbContext,unitOfWork);
            var itemService = new ItemService(dbContext, unitOfWork);
            var orderService = new OrderService(dbContext, unitOfWork);
            var controller = new OrderController(customerService, itemService, orderService);
            //// Act
            //ViewResult result = controller.Index() as ViewResult;
            var orderViewModel = new OrderViewModel
            {
                Customer =  new CustomerViewModel()
                {
                    Address = "TestAddress" , FName = "Spyros" , CellPhone = "694xxxx" , LName = "P" , LandPhone = "21095111" 
                } , Comments = "Test Comments" , DeliveryDate = DateTime.Now.AddDays(-1)  , FromTime = "08" ,
                    OrderDate = DateTime.Now , ToTime = "09" 
            };
            orderViewModel.ListOfItemViewModels.Add(new ItemViewModel { IdItem = 2 , ItemKg = 10 });

            var order = controller.SaveOrder(orderViewModel);

            //// Assert
            Assert.IsNotNull(order);
        }
    }
}
