using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ReportService.Infrastructure.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<EmployeeDbModel[]> GetAll()
        {
            var query = "SELECT * FROM emps";
            return (await _dbConnection.QueryAsync<EmployeeDbModel>(query)).ToArray();
        }
    }

}