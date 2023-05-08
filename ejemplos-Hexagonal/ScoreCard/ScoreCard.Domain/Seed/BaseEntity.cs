using System.Text.Json.Serialization;
using MediatR;

namespace ScoreCard.Domain.Seed;

public class BaseEntity
{
    public virtual Guid Id { get; protected set; }
    private List<INotification> _domainEvents;

    [JsonIgnore] public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
}