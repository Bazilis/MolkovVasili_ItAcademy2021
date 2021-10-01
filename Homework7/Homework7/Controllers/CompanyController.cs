using Homework7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{name}")]
        public ActionResult<Company> Index([FromRoute] Company company)
        {
            if (string.IsNullOrEmpty(company.Name))
            {
                _logger.LogWarning($"{nameof(company.Name)} Name of company is null or empty");
                ModelState.AddModelError(nameof(company.Name), "Name of company is null or empty");
            }
            else if (company.Name.Length < 3 || company.Name.Length > 50)
            {
                _logger.LogWarning($"{nameof(company.Name)} Invalid length of company name");
                ModelState.AddModelError(nameof(company.Name), "Invalid length of company name");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid {ModelState}");
                return ValidationProblem(ModelState);
            }

            return company;
        }
    }
}
