using Homework7.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Homework7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger _log;

        public CompanyController(ILogger log)
        {
            _log = log;
        }

        [HttpGet("{name}")]
        public ActionResult<Company> Index([FromRoute] Company company)
        {
            if (string.IsNullOrEmpty(company.Name))
            {
                ModelState.AddModelError(nameof(company.Name), "Name of company is null or empty");
            }
            else if (company.Name.Length < 3 || company.Name.Length > 50)
            {
                ModelState.AddModelError(nameof(company.Name), "Invalid length of company name");
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            _log.Warning("Hello World!");

            return company;
        }
    }
}
