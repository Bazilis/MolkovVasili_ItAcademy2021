using Homework8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        // GET organization/index/{name}/{bankAccount}
        [HttpGet]
        [Route("[action]/{name}/{bankAccount}")]
        public ActionResult<OrganizationItem> Index([FromRoute] OrganizationItem organization)
        {
            return organization;
        }
    }
}
