using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Domain
{
    public class Department
    {
        public string Name { get; private set; }
        public List<Employee> Employees { get; private set; }

        public decimal CalculateSalaries()
        {
            return Employees.Sum(e => e.Salary); 
        }

        public Department(string name, List<Employee> employees)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Employees = employees ?? throw new ArgumentNullException(nameof(employees));
        }
    }
}