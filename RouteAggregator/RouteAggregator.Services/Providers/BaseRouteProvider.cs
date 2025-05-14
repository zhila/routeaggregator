using RouteAggregator.Model;
using RouteAggregator.Model.Dto;
using RouteAggregator.Model.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteAggregator.Services.Providers
{
    public abstract class BaseRouteProvider<T> : IRouteProvider where T : class
    {
        private readonly IHttpClientFactory _clientFactory;

        protected BaseRouteProvider(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _clientFactory = clientFactory;
            ApplicationConfiguration = applicationConfiguration;
        }

        protected IApplicationConfiguration ApplicationConfiguration { get; }
        protected abstract string ApiUrl { get; }

        public async Task<IEnumerable<RouteDto>> GetRoutes()
        {
            return await ExecuteWithRetryAsync(async () =>
            {
                HttpClient client = _clientFactory.CreateClient();
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException(
                        $"Api {ApiUrl} call failed with status code: {response.StatusCode}");
                }

                var result = await response.Content.ReadAsStringAsync();
                try
                {
                    var results = JsonSerializer.Deserialize<IEnumerable<T>>(result);
                    return Map(results);
                }
                catch (SerializationException)
                {
                    return null;
                }
            }, ApplicationConfiguration.RetriesCount, ApplicationConfiguration.RetriesDelayMs);
        }

        protected abstract IEnumerable<RouteDto> Map(IEnumerable<T> results);

        private async Task<T> ExecuteWithRetryAsync<T>(
            Func<Task<T>> operation,
            int maxRetries,
            int delayMilliseconds
        )
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    return await operation();
                }
                catch (ApiException ex)
                {
                    if (attempt == maxRetries)
                    {
                        return default;
                    }

                    await Task.Delay(delayMilliseconds * attempt);
                }
            }

            return default;
        }
    }
}