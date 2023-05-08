using FluentValidation;
using MediatR;
using ScoreCard.Domain.Exceptions;

namespace ScoreCard.Infrastructure.Behaviours;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>[] _validators;

    public ValidatorBehavior(
        IValidator<TRequest>[] validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(x => x.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            throw new ResumDomainException($"Some validation errorss were found",
                new ValidationException("Validation exception", failures));
        }

        return await next();
    }
}