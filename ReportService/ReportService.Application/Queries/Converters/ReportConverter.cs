using System.Collections.Generic;
using System.Linq;
using ReportService.Application.Queries.GetReportData;
using ReportService.Domain;
using ReportService.Infrastructure.Repositories.Department;
using ReportService.Infrastructure.Repositories.Employee;

namespace ReportService.Application.Queries.Converters
{
    internal static class ReportConverter
    {
        public static Report ToDomain(IEnumerable<DepartmentDbModel> departmentModels, 
            IEnumerable<EmployeeDbModel> employeeModels, 
            Dictionary<int, decimal> salaries,
            GetReportDataQuery getReportDataQuery)
        {
            var departments = departmentModels
                .Select(departmentModel => new Department(
                    departmentModel.Name,
                    GetEmployeesForDepartment(departmentModel.Id, employeeModels, salaries)
                ))
                .ToList();

            var reportTitle = new ReportTitle(getReportDataQuery.Month, getReportDataQuery.Year);

            return new Report(reportTitle, departments);
        }

        private static List<Employee> GetEmployeesForDepartment(int departmentId, IEnumerable<EmployeeDbModel> employeeModels, Dictionary<int, decimal> salaries)
        {
            return employeeModels
                .Where(e => e.DepartmentId == departmentId)
                .Select(e => new Employee(
                    e.Name,
                    salaries.TryGetValue(e.Id, out var salary) ? salary : 0
                )).ToList();
        }
    }
}