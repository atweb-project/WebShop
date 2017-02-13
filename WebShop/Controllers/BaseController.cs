using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Infrastructure.Exeption;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    [ErrorLogger]
    public abstract class BaseController : Controller
    {
        protected readonly ICustomerService _CustomerService;
        protected readonly IItemService _ItemService;
        protected readonly IOrderService _OrderService;

        protected BaseController(ICustomerService customerService, IItemService itemService, IOrderService orderService)
        {
            _CustomerService = customerService;
            _ItemService = itemService;
            _OrderService = orderService;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (!System.Web.HttpContext.Current.IsDebuggingEnabled)
            {
                if (filterContext.Exception is DataNotFoundException)
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = RedirectToAction("NoAccess", "Error");
                }
            }
            base.OnException(filterContext);
        }
        protected string RenderPartialView(string partialViewName, object model)
        {
            if (ControllerContext == null)
                return string.Empty;

            if (model == null)
                throw new ArgumentNullException("model");

            if (string.IsNullOrEmpty(partialViewName))
                throw new ArgumentNullException("partialViewName");

            ModelState.Clear();//Remove possible model binding error.
            ViewData.Model = model;//Set the model to the partial view

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, partialViewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
                result.AddError(validationError.ErrorMessage);
            
            return result;
        }
        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();
            result.AddError(errorMessage);
            return result;
        }
        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }
        protected String GetErrorMessage<T>(T descriptioninterfaceviewmodel)
        {
            String message = String.Empty;

            if (!ModelState.IsValid)
            {
                message = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));

            }

            return message;
        }
    }
}