namespace ReportService.Infrastructure.Repositories.Employee
{
    public class EmployeeDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public int DepartmentId { get; set; }
    }
}