using System.Threading;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.HttpClients.AccountingService
{
    public interface IAccountingServiceHttpClient
    {
        Task<decimal> GetEmployeeSalary(string employeeCode, CancellationToken cancellationToken);
    }
}