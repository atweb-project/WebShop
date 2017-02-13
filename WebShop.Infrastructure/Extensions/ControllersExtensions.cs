using System.Web.ModelBinding;
using System.Web.Mvc;
using WebShop.Infrastructure.Validations;

namespace WebShop.Infrastructure.Extensions
{
    public static class ControllersExtensions
    {
        public static void AddValidationErrors(this System.Web.Mvc.ModelStateDictionary modelState, IValidationErrors propertyErrors)
        {
            foreach (var databaseValidationError in propertyErrors.Errors)
            {
                modelState.AddModelError(databaseValidationError.PropertyName ?? string.Empty, databaseValidationError.PropertyExceptionMessage);
            }
        }
    }
}
