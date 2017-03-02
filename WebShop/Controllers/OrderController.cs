using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Infrastructure.Extensions;
using WebShop.Infrastructure.Validations;
using WebShop.Model;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ICustomerService customerService, IItemService itemService, IOrderService orderService)
            : base(customerService, itemService, orderService)
        {
        }

        [HttpGet]
        public JsonResult GetOrders()
        {
            return Json(this._OrderService.GetOrders(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetItems()
        {
            return Json(this._ItemService.GetItems().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateModelState]
        public JsonResult SaveItem(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this._ItemService.SaveItem(itemViewModel);
                    return Json(new {success = true});
                }
                catch (ValidationErrors propertyErrors)
                {
                    ModelState.AddValidationErrors(propertyErrors);
                }
            }
            else
                return JsonValidationError();

            return null;
        }

        [HttpPost]
        [ValidateModelState]
        public JsonResult SaveOrder(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this._OrderService.SaveOrder(orderViewModel);
                    return Json(new {success = true});
                }
                catch (ValidationErrors propertyErrors){
                    ModelState.AddValidationErrors(propertyErrors);
                }
            }
            else
                return JsonValidationError();

            return null;
        }
    }
}