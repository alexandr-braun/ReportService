using System;

namespace ReportService.Domain
{
    public class Employee
    {
        public string FullName { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string fullName, decimal salary)
        {
            FullName = string.IsNullOrWhiteSpace(fullName) ? throw new ArgumentNullException(nameof(fullName)) : fullName;
            Salary = salary;
        }
    }
}