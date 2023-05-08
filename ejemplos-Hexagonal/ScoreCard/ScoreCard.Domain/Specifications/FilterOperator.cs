using System.Linq.Expressions;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Specifications;

public class FilterOperator: Enumeration
    {
        public static FilterOperator FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.InvariantCultureIgnoreCase));

            if (state == null)
                throw new Exception($"Possible values for operator: {string.Join(",", List().Select(s => s.Name))}");

            return state;
        }

        public static FilterOperator From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
                throw new Exception($"Possible values for operator: {string.Join(",", List().Select(s => s.Name))}");

            return state;
        }

        #region Enumerators

        public static FilterOperator Equal = new FilterOperator(1, "=", Expression.Equal);
        public static FilterOperator NotEqual = new FilterOperator(2, "!=", Expression.NotEqual);
        public static FilterOperator GreaterThanOrEqual = new FilterOperator(3, ">=", Expression.GreaterThanOrEqual);
        public static FilterOperator LessThanOrEqual = new FilterOperator(4, "<=", Expression.LessThanOrEqual);
        public static FilterOperator GreaterThan = new FilterOperator(3, ">", Expression.GreaterThan);
        public static FilterOperator LessThan = new FilterOperator(4, "<", Expression.LessThan);
        public static FilterOperator Contains = new FilterOperator(5, nameof(Contains), null);
        public static FilterOperator NotContains = new FilterOperator(6, nameof(NotContains), null, true);
        public static FilterOperator ContainsInList = new FilterOperator(7, nameof(ContainsInList), null);
        public static FilterOperator NotContainsInList = new FilterOperator(8, nameof(NotContainsInList), null, true);

        #endregion

        #region Constructor & properties

        public Func<Expression, Expression, BinaryExpression> OperatorExpression { get; }
        public bool IsNegative { get; }

        public FilterOperator(int id, string name, Func<Expression, Expression, BinaryExpression> expression,
            bool isNegative = false) : base(id, name)
        {
            OperatorExpression = expression;
            IsNegative = isNegative;
        }

        public static IEnumerable<FilterOperator> List()
        {
            return new[]
            {
                Equal, NotEqual, GreaterThan, LessThan, GreaterThanOrEqual, LessThanOrEqual, Contains,
                NotContains, ContainsInList, NotContainsInList
            };
        }

        #endregion
    }