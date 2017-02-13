using System.Collections.Generic;

namespace WebShop.Infrastructure.Validations
{
    public interface IValidationErrors
    {
        List<IBaseError> Errors { get; set; }
    }
}