namespace ScoreCard.Application.Dtos.Responses;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public List<SubscriptionResponse>? Subscriptions { get; set; }
    public CustomerSecretInformationResponse? SecretInformation { get; set; }

    public CustomerResponse(Guid id, string name, bool isActive, List<SubscriptionResponse>? subscriptions, CustomerSecretInformationResponse? secretInformation)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
        Subscriptions = subscriptions;
        SecretInformation = secretInformation;
    }
    
    public CustomerResponse(Guid id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
}