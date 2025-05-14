using RouteAggregator.Model;

public class ApplicationConfiguration(IConfiguration configuration) : IApplicationConfiguration
{
    public string? Flights1Url => configuration.GetValue<string>("Providers:Flights1Url");
    public string? Flights2Url => configuration.GetValue<string>("Providers:Flights2Url");
    public int RetriesCount => configuration.GetValue<int>("Providers:RetriesCount");
    public int RetriesDelayMs => configuration.GetValue<int>("Providers:RetriesDelayMs");
}