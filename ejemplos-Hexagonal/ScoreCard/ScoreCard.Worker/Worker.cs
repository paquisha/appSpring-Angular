using MediatR;
using Microsoft.EntityFrameworkCore;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Queries.CustomerSecretInformationQueries;
using ScoreCard.Application.Queries.QueriesAZR;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Infrastructure;
using ScoreCard.Worker.Dtos;

namespace ScoreCard.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _mediator;
    private readonly ScoreCardDbContext _dbContext;

    public Worker(ILogger<Worker> logger, IMediator mediator, ScoreCardDbContext dbContext)
    {
        _logger = logger;
        _mediator = mediator;
        _dbContext = dbContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            CargaDatos();

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(30000, stoppingToken);
        }
    }

    private async void CargaDatos()
    {
        var request = new ReadCustomerWorkerRequest();
        var query = request.ToApplicationRequest();
        var response = await _mediator.Send(query);
        var customers = response.Value;

        foreach (var customer in customers)
        {
            foreach (var subscription in customer.Subscriptions)
            {
                //todo llamar funciones de azure, metodo que crea snapshot
                //securityScoreControl
                var sSecurityControlRequest = new ReadSecurityScoreControlWorkerRequest();
                var sSecurityScoreControlQuery = sSecurityControlRequest.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                var sSecurityScoreControlResponse = await _mediator.Send(sSecurityScoreControlQuery);
                var securityScoreControls = sSecurityScoreControlResponse.Value;

                //ControlRecommendationId---cambiar
                //var controlRecommendationId = new ReadControlRecommendationIdRequest();
                //var controlRecommendationQuery = controlRecommendationId.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                //var controlRecommendationResponse = await _mediator.Send(controlRecommendationQuery);
                //var controlRecommendationsId = controlRecommendationResponse.Value;

                //SecurityRecommendation
                var securityRecommendation = new ReadSecurityRecommendationRequest();
                var securityRecommendationQuery = securityRecommendation.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                var securityRecommendationResponse = await _mediator.Send(securityRecommendationQuery);
                var securityRecommendations = securityRecommendationResponse.Value;

                //SecurityStandard
                //var securityStandard = new ReadSecurityStandarWorkerRequest();
                //var securityStandardQuery = securityStandard.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                //var securityStandardResponse = await _mediator.Send(securityStandardQuery);
                //var securityStandards = securityStandardResponse.Value;

                //secureScore
                //var secureScore = new ReadSecureScoreWorkerRequest();
                //var secureScoreQuery = secureScore.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                //var secureScoreResponse = await _mediator.Send(secureScoreQuery);
                //var securesScore = secureScoreResponse.Value;

                //securityPlan
                var securityplan = new ReadSecurityPlanWorkerRequest();
                var securityplanquery = securityplan.ToApplicationRequest(subscription.SubscriptionId.ToString(), customer.SecretInformation.TenantId.ToString(), customer.SecretInformation.ApplicationId.ToString(), customer.SecretInformation.ClientSecret.ToString());
                var securityplanresponse = await _mediator.Send(securityplanquery);
                var securityplans = securityplanresponse.Value;



                // var snapshot = new CreateSecurityScoreSnapshotWorkerRequest(DateTime.Now, customer.Id, subscription.Id);
                // var querySnapshot = snapshot.ToApplicationRequest();
                // var responseSnapshot = await _mediator.Send(querySnapshot);
                // var snapshotCreated = responseSnapshot.Value;
                // var snapshot = new SecurityScoreSnapshot(DateTime.Now, customer.Id, subscription.Id);
                // snapshot.AddSecurityPlan(subscription.Id.ToString(), "plan", "estado");
                // snapshot.AddSecurityScore("tenantid", subscription.Id.ToString(), 1, 1, 1, 1);
                // snapshot.AddSecurityStandard("tenantid", subscription.Id.ToString(), "complianceStandart", "state", 1,1,1);
                // snapshot.AddControlRecommendationId("controlRemediationId");
                // snapshot.AddSecurityScoreControl("tenantid", subscription.Id.ToString(), "controlName", "controlID", 1,
                //     1, 1, 1, 1, 1,1, "controlType");
                // _secutiryScoreSnapshotRepository.Add(snapshot);
                // await _secutiryScoreSnapshotRepository.UnitOfWork.SaveEntitiesAsync();
            }
        }
    }
}