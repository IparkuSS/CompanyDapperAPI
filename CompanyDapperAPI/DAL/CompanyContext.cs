using System.Data;
using Microsoft.Data.SqlClient;

namespace CompanyDapperAPI.DAL
{
    public class CompanyContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CompanyContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
