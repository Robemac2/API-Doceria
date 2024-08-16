namespace API_Doceria.Helpers;

public class ConnectionStringBuilder
{
    private string? DatabaseUrl { get; set; }
    private string? DatabasePort { get; set; }
    private string? DatabaseName { get; set; }
    private string? DatabaseUser { get; set; }
    private string? DatabasePassword { get; set; }
    
    public ConnectionStringBuilder()
    {
        DatabaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        DatabasePort = Environment.GetEnvironmentVariable("DATABASE_PORT");
        DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
        DatabaseUser = Environment.GetEnvironmentVariable("DATABASE_USER");
        DatabasePassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
    }
    
    public string BuildConnectionString()
    {
        return $"Host={DatabaseUrl};Port={DatabasePort};Database={DatabaseName};Username={DatabaseUser};Password={DatabasePassword}";
    }
}