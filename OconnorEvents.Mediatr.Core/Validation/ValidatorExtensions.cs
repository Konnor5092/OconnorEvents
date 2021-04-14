using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.Core.Validation
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Guid> EntityExists<T>(this IRuleBuilder<T, Guid> ruleBuilder, DbContext context, Type type)
        {
            return ruleBuilder.SetValidator(new EntityExistsValidator<T>(context, type));
        }
    }
}
