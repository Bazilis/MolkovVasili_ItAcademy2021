using Homework9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET employee/index/{name}
        [HttpGet]
        [Route("[action]")]
        public ActionResult<EmployeeItem> Index([FromQuery] EmployeeItem employee)
        {
            return employee;
        }
    }
}
