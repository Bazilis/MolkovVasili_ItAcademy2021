using Homework6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet("{name}")]
        public ActionResult<Customer> Index([FromRoute] Customer customer)
        {
            return customer;
        }
    }
}
