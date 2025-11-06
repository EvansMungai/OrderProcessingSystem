using Polly;
using Polly.Extensions.Http;

namespace OrderProcessing.Infrastructure.Resilience;

/// <summary>
/// Provides Polly-based resilience policies for HTTP requests.
/// </summary>
public static class PollyPolicies
{
    /// <summary>
    /// Returns a retry policy with exponential backoff for transient HTTP errors.
    /// </summary>
    /// <returns>An asynchronous retry policy for HTTP responses.</returns>
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() => 
        HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    /// <summary>
    /// Returns a circuit breaker policy that opens after 5 failures and resets after 30 seconds.
    /// </summary>
    /// <returns>An asynchronous circuit breaker policy for HTTP responses.</returns>
    public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
        HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}
