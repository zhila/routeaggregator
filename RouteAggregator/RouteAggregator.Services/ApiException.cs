using System;

namespace RouteAggregator.Services
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }
    }
}