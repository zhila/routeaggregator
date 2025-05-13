namespace RouteAggregator.Model
{
    public interface IApplicationConfiguration
    {
        string Flights1Url { get; }
        string Flights2Url { get; }
        int RetriesCount { get; }
        int RetriesDelayMs { get; }
    }
}