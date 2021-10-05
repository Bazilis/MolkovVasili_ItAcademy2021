using Homework8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        // GET customer/index/{name}
        [HttpGet]
        [Route("[action]/{name}")]
        public ActionResult<CustomerItem> Index([FromRoute] CustomerItem customer)
        {
            return customer;
        }
    }
}
