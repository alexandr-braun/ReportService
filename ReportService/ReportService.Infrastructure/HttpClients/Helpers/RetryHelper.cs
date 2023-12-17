using System;
using System.Linq;
using System.Net;
using Flurl.Http;
using Polly;
using Polly.Retry;

namespace ReportService.Infrastructure.HttpClients.Helpers
{
    internal static class RetryHelper
    {
        internal static AsyncRetryPolicy BuildRetryPolicy()
        {
            var retryCount = 2;
            var retryPolicy = Policy
                .Handle<FlurlHttpException>(IsTransientError)
                .WaitAndRetryAsync(retryCount, retryAttempt =>
                {
                    var nextAttemptIn = TimeSpan.FromMilliseconds(100);
                    return nextAttemptIn;
                });

            return retryPolicy;
        }
		
        private static bool IsTransientError(FlurlHttpException exception)
        {
            var httpStatusCodesWorthRetrying = new[] {
                (int)HttpStatusCode.RequestTimeout,
                (int)HttpStatusCode.BadGateway,
                (int)HttpStatusCode.ServiceUnavailable,
                (int)HttpStatusCode.GatewayTimeout
            };

            return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
        }
    }
}