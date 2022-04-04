using CompanyDapperAPI.DAL.Models;

namespace CompanyDapperAPI.DAL.Repository.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
