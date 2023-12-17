using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ReportService.Infrastructure.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _dbConnection;

        public DepartmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<DepartmentDbModel[]> GetAll()
        {
            var query = "SELECT * FROM deps";
            return (await _dbConnection.QueryAsync<DepartmentDbModel>(query)).ToArray();
        }
    }
}