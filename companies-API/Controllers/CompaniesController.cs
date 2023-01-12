using companies.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace companies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly companiesContext _context;

        public CompaniesController(companiesContext context) => _context = context;

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<List<Company>>> getCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            return Ok(companies);
        }
    }
}
