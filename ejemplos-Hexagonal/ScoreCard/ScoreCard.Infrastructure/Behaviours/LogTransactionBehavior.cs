using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Models;

namespace ScoreCard.Infrastructure.Behaviours;

public class LogTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LogTransactionBehavior<TRequest, TResponse>> _logger;

    public LogTransactionBehavior(ILogger<LogTransactionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        if (response is EntityResponse { IsSuccess: false } entityResponse)
        {
            _logger.LogInformation("{Code}: {Message}",
                entityResponse.EntityErrorResponse.Code,
                entityResponse.EntityErrorResponse.Message);
        }

        return response;
    }
}