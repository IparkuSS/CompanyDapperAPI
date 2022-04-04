using CompanyDapperAPI.DAL.Models;
using CompanyDapperAPI.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDapperAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        public CompanyController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepo.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
