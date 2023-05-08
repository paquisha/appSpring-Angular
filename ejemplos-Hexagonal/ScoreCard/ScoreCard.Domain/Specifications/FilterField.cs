namespace ScoreCard.Domain.Specifications;

public class FilterField<T>
    where T : class
{
    public FilterField(string fieldName)
    {
        FieldName = fieldName;
    }

    public string FieldName { get; }
}