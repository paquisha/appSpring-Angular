namespace ScoreCard.Domain.Specifications;

public class OrderBy
{
    public OrderBy(string field, OrderType orderType)
    {
        Field = field;
        OrderType = orderType;
    }

    public string Field { get; }
    public OrderType OrderType { get; }
}
