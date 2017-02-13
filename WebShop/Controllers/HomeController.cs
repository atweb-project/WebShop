using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        protected ICustomerService _CustomerService;

        public HomeController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "WebShop";

            return View();
        }

        public JsonResult GetJsonResult()
        {
            var list = _CustomerService.GetCustomers();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
