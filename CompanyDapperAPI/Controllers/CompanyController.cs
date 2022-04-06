using CompanyDapperAPI.DAL.Repository.Contracts;
using CompanyDapperAPI.Dto;
using Logger.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDapperAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        private ILoggerManager _logger;
        public CompanyController(ICompanyRepository companyRepo, ILoggerManager logger)
        {
            _companyRepo = companyRepo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepo.GetCompanies();
            return Ok(companies);
        }
        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyRepo.GetCompany(id);
            if (company == null)
            {
                _logger.LogError("company is null here");
                return BadRequest("company is null here");
            }
            return Ok(company);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyForCreationDto company)
        {
            var createdCompany = await _companyRepo.CreateCompany(company);
            return
                CreatedAtRoute("CompanyById", new { id = createdCompany.CompanyId }, createdCompany);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto company)
        {

            var dbCompany = await _companyRepo.GetCompany(id);
            if (dbCompany == null)
            {
                _logger.LogError("dbCompanyis null here");
                return NotFound("dbCompanyis null here");
            }
            await _companyRepo.UpdateCompany(id, company);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var dbCompany = await _companyRepo.GetCompany(id);
            if (dbCompany == null)
            {
                _logger.LogError("dbCompanyis null here");
                return NotFound("dbCompanyis null here");
            }

            await _companyRepo.DeleteCompany(id);
            return NoContent();

        }
    }
}
