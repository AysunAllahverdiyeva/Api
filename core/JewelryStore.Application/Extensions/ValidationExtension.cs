using FluentValidation;
using JewelryStore.Application.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Extensions
{
    public static class ValidationExtension
    {
        public static async Task ThrowIfValidationFailAsync<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);

            if (!validationResult.IsValid)
            {
                throw new JewelryStoreValidationException(validationResult.Errors);
            }
        }
        public static IRuleBuilderOptions<T, TProperty> CheckNull<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.WithMessage($"Data is required");
        }
    }
}
