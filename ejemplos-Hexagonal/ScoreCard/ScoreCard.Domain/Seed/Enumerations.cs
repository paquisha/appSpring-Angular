namespace ScoreCard.Domain.Seed;


     /// <summary>
    ///     Expiration time added to current date
    /// </summary>
    public static class PublicAccessTokenExpiresIn
    {
        public static int Minutes => 120;
    }

    /// <summary>
    ///     Expiration time added to current date
    /// </summary>
    public static class MemberUserResetPasswordTokenExpiresIn
    {
        public static int Minutes => 5;
    }

    /// <summary>
    ///     IMPORTANT: Do not change (Same value as legacy ecosystems in Go)
    /// </summary>
    public static class BCryptWorkFactor
    {
        public static int Value => 4;
    }

    public static class PublicAccessTokenScopes
    {
        public static string User => nameof(User).ToUpper();
    }

    public static class UserGender
    {
        public static string Male => nameof(Male).ToLowerInvariant();
        public static string Female => nameof(Female).ToLowerInvariant();
        public static string Other => nameof(Other).ToLowerInvariant();

        public static List<string> All => new List<string> { Male, Female, Other };
    }

    public static class ProductLocation
    {
        public static string Canada => nameof(Canada).ToLowerInvariant();
        public static string UnitedStates => nameof(UnitedStates).ToLowerInvariant();
        public static string Brazil => nameof(Brazil).ToLowerInvariant();
        public static string Ecuador => nameof(Ecuador).ToLowerInvariant();
        public static string Argentina => nameof(Argentina).ToLowerInvariant();
        public static string Others => nameof(Others).ToLowerInvariant();

        public static List<string> All =>
            new List<string> { Canada, UnitedStates, Brazil, Ecuador, Argentina, Others };
    }

    public static class ProductStatus
    {
        public static string New => nameof(New).ToLowerInvariant();
        public static string Used => nameof(Used).ToLowerInvariant();

        public static List<string> All => new List<string> { New, Used };
    }

    public static class ProductType
    {
        public static string International => nameof(International).ToLowerInvariant();
        public static string Local => nameof(Local).ToLowerInvariant();

        public static List<string> All => new List<string> { International, Local };
    }
    
    public static class PlanName
    {
        public static string Basic => nameof(Basic);
        public static string Premium => nameof(Premium);

        public static List<string> All => new List<string> { Basic, Premium };
    }
    
    public static class ProductVariationStatus
    {
        public static string Send => nameof(Send).ToLowerInvariant();
        public static string Pending => nameof(Pending).ToLowerInvariant();
        public static string Active => nameof(Active).ToLowerInvariant();

        public static List<string> All => new List<string> { Send, Pending, Active };
    }

    public  static class ConstanteCRId
    {
        public static string CONTROL_RECOMMENDATION_ID = "";
    }
