using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }
    }
}
