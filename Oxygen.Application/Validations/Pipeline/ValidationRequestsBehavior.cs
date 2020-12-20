using FluentValidation;
using FluentValidation.Results;
using Flunt.Notifications;
using MediatR;
using Oxygen.Application.Results;
using Oxygen.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oxygen.Application.Validations.Pipeline
{
    public class VaidacaoRequestsBehavior<TRequest, TResponse>
                                     : IPipelineBehavior<TRequest, TResponse>
                                     where TRequest : IRequest<TResponse> where TResponse : Result
    {
        private readonly IEnumerable<IValidator> _validators;
        public VaidacaoRequestsBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any() ? Errors(failures) : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var resultado = new Result();

            foreach (var failure in failures)
                resultado.AddNotifications(failures.Select(a => new Notification(a.PropertyName, a.ErrorMessage)).ToList(), ErrorCode.Business);

            return Task.FromResult(resultado as TResponse);
        }

    }
}
