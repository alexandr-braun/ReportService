using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReportService.Application.Queries.Converters;
using ReportService.Infrastructure.HttpClients.AccountingService;
using ReportService.Infrastructure.Repositories.Department;
using ReportService.Infrastructure.Repositories.Employee;

namespace ReportService.Application.Queries.GetReportData
{
    public class GetReportDataQueryHandler
    {
        private readonly IAccountingServiceHttpClient _accountingServiceHttpClient;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public GetReportDataQueryHandler(IAccountingServiceHttpClient accountingServiceHttpClient, 
            IEmployeeRepository employeeRepository, 
            IDepartmentRepository departmentRepository)
        {
            _accountingServiceHttpClient = accountingServiceHttpClient;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<string> Handle(GetReportDataQuery getReportDataQuery, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAll();
            var employees = await _employeeRepository.GetAll();

            var salaryTasks = employees.Select(async employee =>
                new
                {
                    EmployeeId = employee.Id,
                    Salary = await _accountingServiceHttpClient.GetEmployeeSalary(employee.Inn, cancellationToken)
                }).ToList();
            var salaries = (await Task.WhenAll(salaryTasks))
                .ToDictionary(
                    result => result.EmployeeId,
                    result => result.Salary
                );

            var reportEntity = ReportConverter.ToDomain(departments, employees, salaries, getReportDataQuery);
            var reportText = TextReportConverter.FromDomain(reportEntity);
            return reportText;
        }
    }
}