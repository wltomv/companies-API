using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace companies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<List<string>>> getCompanies()
        {
            //TODO: temporal data 
            List<string> companies = new List<string>
            {
                "Company 1",
                "Company 2",
                "Company 3"
            };
            return Ok(companies);
        }
    }
}
