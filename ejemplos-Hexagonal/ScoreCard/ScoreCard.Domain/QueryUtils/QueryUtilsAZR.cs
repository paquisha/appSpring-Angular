namespace ScoreCard.Domain.QueryUtils;

public class QueryUtilsAZR
{
    private string SecurityScorePath = "//PlainTextQuerys//securityScore.txt";
    private string SecurityScoreControlPath = "//PlainTextQuerys//SecurityScoreControl.txt";
    private string SecurityStandarPath = "//PlainTextQuerys//SecurityStandar.txt";
    private string SecurityPlanPath = "//PlainTextQuerys//SecurityPlan.txt";
    private string SecurityRecomendationPath = "//PlainTextQuerys//SecurityRecommendations.txt";

    public string SecurityScoreQuery()
    {
        StreamReader sr = new StreamReader(SecurityScorePath);
        string contenido = sr.ReadToEnd();
        return "";
    }

    public string SecurityRecommendationQuery(string subscriptionId)
    {
        StreamReader sr = new StreamReader(SecurityRecomendationPath);
        string contenido = sr.ReadToEnd();
        contenido.Replace("{subscriptionId}", subscriptionId);
        return contenido;
    }
}