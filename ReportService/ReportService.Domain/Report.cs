using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Domain
{
    public class Report
    {
        public ReportTitle Title { get; private set; }
        public List<Department> Departments { get; private set; }
     
        public decimal CalculateSalaries()
        {
            return Departments.Sum(d => d.CalculateSalaries());
        }

        public Report(ReportTitle title, List<Department> departments)
        {
            Title = title;
            Departments = departments ?? throw new ArgumentNullException(nameof(departments));
        }
    }
}