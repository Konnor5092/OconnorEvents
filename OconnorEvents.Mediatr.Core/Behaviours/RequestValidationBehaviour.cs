using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OconnorEvents.Mediatr.Core.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OconnorEvents.Mediatr.Core.Behaviours
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = new List<ValidationFailure>();
            foreach (var validator in _validators)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors != null)
                {
                    failures.AddRange(validationResult.Errors);
                }
            }

            if (failures.Any(f => f.ErrorCode == "EntityExistsValidator"))
            {
                throw new EntityNotFoundException(failures.Where(f => f.ErrorCode == "EntityExistsValidator"));
            }

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
