using System.Threading.Tasks;

namespace ReportService.Infrastructure.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDbModel[]> GetAll();
    }
}