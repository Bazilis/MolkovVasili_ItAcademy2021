using Homework7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework7.Controllers
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
