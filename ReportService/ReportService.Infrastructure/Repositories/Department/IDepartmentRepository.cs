using System.Threading.Tasks;

namespace ReportService.Infrastructure.Repositories.Department
{
    public interface IDepartmentRepository
    {
        Task<DepartmentDbModel[]> GetAll();
    }
}