using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.Core.Validation
{
    public class EntityNotFoundException : ValidationException
    {
        public EntityNotFoundException(IEnumerable<ValidationFailure> errors) : base(errors) { }
    }
}
