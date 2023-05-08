namespace ScoreCard.Domain.Seed;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}