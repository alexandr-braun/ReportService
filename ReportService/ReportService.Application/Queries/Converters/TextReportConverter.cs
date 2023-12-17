using System.Text;
using ReportService.Domain;

namespace ReportService.Application.Queries.Converters
{
    internal static class TextReportConverter
    {
        internal static string FromDomain(Report report)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{report.Title}\n");
            stringBuilder.AppendLine("---");

            foreach (var department in report.Departments)
            {
                stringBuilder.AppendLine($"{department.Name}\n");

                foreach (var employee in department.Employees)
                {
                    stringBuilder.AppendLine($"{employee.FullName}\t\t{employee.Salary}р");
                }

                stringBuilder.AppendLine($"Всего по отделу\t\t{department.CalculateSalaries()}р\n");
                stringBuilder.AppendLine("---");
            }

            stringBuilder.AppendLine($"Всего по предприятию\t\t{report.CalculateSalaries()}р");

            return stringBuilder.ToString();
        } 
    }
}