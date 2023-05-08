namespace ScoreCard.Application.Dtos.Responses.ResponseAZR;

public class SecurityPlanAZRResponse
{
    public string? SubscriptionId { get; set; }
    public string? AzureDefenderPlan { get; set; }
    public string? Status { get; set; }

    public SecurityPlanAZRResponse(string? subscriptionId, string? azureDefenderPlan, string? status)
    {
        SubscriptionId = subscriptionId;
        AzureDefenderPlan = azureDefenderPlan;
        Status = status;
    }
}