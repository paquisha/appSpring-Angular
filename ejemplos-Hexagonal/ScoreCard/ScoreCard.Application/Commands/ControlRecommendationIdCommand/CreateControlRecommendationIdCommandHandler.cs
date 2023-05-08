using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Application.Queries.QueriesAZR;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Application.Commands.ControlRecommendationIdCommand;

public class
    CreateControlRecommendationIdCommandHandler : IRequestHandler<CreateControlRecommendationIdCommand,
        EntityResponse<bool>>
{
    private readonly ILogger<CreateControlRecommendationIdCommandHandler> _logger;
    private readonly IControlRecommendationIdRepository _controlRecommendation;
    private readonly ControlRecommendationIdAZRResponse _controlRecommendationAzr;
    private readonly IMediator _mediator;


    public CreateControlRecommendationIdCommandHandler(ILogger<CreateControlRecommendationIdCommandHandler> logger,
        IControlRecommendationIdRepository controlRecommendation,
        ControlRecommendationIdAZRResponse controlRecommendationAzr, IMediator mediator)
    {
        _logger = logger;
        _controlRecommendation = controlRecommendation;
        _controlRecommendationAzr = controlRecommendationAzr;
        _mediator = mediator;
    }


    public async Task<EntityResponse<bool>> Handle(CreateControlRecommendationIdCommand command,
        CancellationToken cancellationToken)

    {
        command.ControlRemediationId = ConstanteCRId.CONTROL_RECOMMENDATION_ID;
        var controlRecommendationId =
            new ControlRecommendationId(command.ControlRemediationId, command.SecurityScoreSnapshotId);
        _controlRecommendation.Add(controlRecommendationId);
        await _controlRecommendation.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}