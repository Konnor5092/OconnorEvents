using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Validation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Guid> EntityExists<T>(this IRuleBuilder<T, Guid> ruleBuilder, ShoppingBasketDbContext context, Type type)
        {
            return ruleBuilder.SetValidator(new EntityExistsValidator<T>(context, type));
        }
    }
}
