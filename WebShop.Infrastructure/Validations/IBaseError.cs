﻿namespace WebShop.Infrastructure.Validations
{
    public interface IBaseError
    {
        string PropertyName { get; }
        string PropertyExceptionMessage { get; }
    }
}