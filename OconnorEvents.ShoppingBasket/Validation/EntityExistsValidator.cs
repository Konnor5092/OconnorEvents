using FluentValidation;
using FluentValidation.Validators;
using OconnorEvents.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OconnorEvents.ShoppingBasket.Validation
{
    public class EntityExistsValidator<T> : PropertyValidator<T, Guid>
    {
        private readonly ShoppingBasketDbContext _context;
        private readonly Type _type;

        public EntityExistsValidator(ShoppingBasketDbContext context, Type type)
        {
            _context = context;
            _type = type;
        }

        public override string Name => "EntityExistsValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        => "No matching entity exists for property {PropertyName} with value {Id}";

        public override bool IsValid(ValidationContext<T> context, Guid value)
        {
            context.MessageFormatter.AppendArgument("Id", value);

            var efSetMethod = typeof(ShoppingBasketDbContext).GetMethod(nameof(ShoppingBasketDbContext.Set), 
                BindingFlags.Public | BindingFlags.Instance, null, new Type[] { }, null);

            efSetMethod = efSetMethod.MakeGenericMethod(_type);
            var queryResults = efSetMethod.Invoke(_context, null) as IQueryable<IEntity>;

            if (queryResults.Any(r => r.Id == value))
            {
                return true;
            }

            return false;
        }
    }
}
