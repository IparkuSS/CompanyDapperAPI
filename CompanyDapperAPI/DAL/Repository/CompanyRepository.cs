using CompanyDapperAPI.DAL.Models;
using CompanyDapperAPI.DAL.Repository.Contracts;
using Dapper;

namespace CompanyDapperAPI.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _context;
        public CompanyRepository(CompanyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
    }
}
