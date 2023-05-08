namespace ScoreCard.Domain.Seed;

public interface IUnitOfWork: IDisposable
{
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

    
}