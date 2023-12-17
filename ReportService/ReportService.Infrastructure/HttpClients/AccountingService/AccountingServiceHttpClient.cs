using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Options;
using ReportService.Infrastructure.HttpClients.Helpers;

namespace ReportService.Infrastructure.HttpClients.AccountingService
{
    public class AccountingServiceHttpClient : IAccountingServiceHttpClient
    {
        private readonly string _baseUri;

        public AccountingServiceHttpClient(IOptions<AccountingServiceHttpClientOptions> options)
        {
            _baseUri = options.Value.BaseUri ?? throw new ArgumentNullException(nameof(options.Value.BaseUri));
        }

        public async Task<decimal> GetEmployeeSalary(string employeeCode, CancellationToken cancellationToken)
        {
            var requestUri = $"{_baseUri}/inn/{employeeCode}";

            try
            {
                var retryPolicy = RetryHelper.BuildRetryPolicy();
                var response = await retryPolicy.ExecuteAsync(() => requestUri.GetAsync());

                if (!response.ResponseMessage.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request to accounting service failed with status code: {response.StatusCode}");
                }

                var stringResponse = await response.ResponseMessage.Content.ReadAsStringAsync(cancellationToken);
                return Convert.ToDecimal(stringResponse);
            }
            catch (FlurlHttpException ex)
            {
                throw new HttpRequestException("Error contacting the accounting service", ex);
            }
        }

    }
}