using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Models
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            return new CustomModelBinder();
        }
    }

    public class CustomModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);

            ForceModelValidation(bindingContext);
        }

        protected static void ForceModelValidation(ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as IValidatableObject;
            if (model == null) return;

            var modelState = bindingContext.ModelState;
            var errors = model.Validate(new ValidationContext(model, null, null));

            foreach (var error in errors)
            {
                foreach (var memberName in error.MemberNames)
                {
                    var memberNameClone = memberName;
                    var idx = modelState.Keys.IndexOf(k => k == memberNameClone);
                    if (idx < 0) continue;
                    if (modelState.Values.ToArray()[idx].Errors.Any()) continue;

                    modelState.AddModelError(memberName, error.ErrorMessage);
                }
            }
        }
    }

    public static class Exte
    {
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicate == null) throw new ArgumentNullException("predicate");

            var i = 0;
            foreach (var item in source)
            {
                if (predicate(item)) return i;
                i++;
            }

            return -1;
        }
    }
}